#! /usr/bin/bash

# db.sh - Database migration management script
# Usage: db.sh <command> [options]
#
# Commands:
#   -a, --add <migration_name>  Add a new migration
#   -u, --up                    Update database to latest migration
#   -s, --sql <output_name>     Generate SQL script
#
# Options:
#   --no-build, -nb            Skip build before executing command
#   --info, -i                 Show database context info and migration list (only with --up)
#   --connection, -c <string>  Specify connection string (only with --up)
#   --from <migration>         From migration (only with --sql)
#   --to <migration>           To migration (only with --sql)

# Default values
command=""
migration_name=""
no_build=""
info=""
connection=""
output_name=""
from_migration=""
to_migration=""

# Base project configuration
server_proj="..csproj"
ef_proj="..csproj"
context=".DbContext"
scripts_dir="."

# Parse command
case $1 in
  -a|--add)
    command="add"
    migration_name="$2"
    shift 2
    ;;
  -u|--up)
    command="up"
    shift
    ;;
  -s|--sql)
    command="sql"
    output_name="$2"
    shift 2
    ;;
  *)
    echo "Error: Invalid command"
    echo "Usage: db.sh <command> [options]"
    echo ""
    echo "Commands:"
    echo "  -a, --add <migration_name>  Add a new migration"
    echo "  -u, --up                    Update database to latest migration"
    echo "  -s, --sql <output_name>     Generate SQL script"
    echo ""
    echo "Options:"
    echo "  --no-build, -nb            Skip build before executing command"
    echo "  --info, -i                 Show database context info and migration list (only with --up)"
    echo "  --connection, -c <string>  Specify connection string (only with --up)"
    echo "  --from <migration>         From migration (only with --sql)"
    echo "  --to <migration>           To migration (only with --sql)"
    exit 1
    ;;
esac

# Parse options
while [[ $# -gt 0 ]]; do
  case $1 in
    --no-build|-nb)
      no_build="--no-build"
      shift
      ;;
    --info|-i)
      info="--info"
      shift
      ;;
    --connection|-c)
      connection="$2"
      shift 2
      ;;
    --from)
      from_migration="$2"
      shift 2
      ;;
    --to)
      to_migration="$2"
      shift 2
      ;;
    *)
      shift
      ;;
  esac
done

# Validate required arguments
if [ "$command" = "add" ] && [ -z "$migration_name" ]; then
  echo "Error: Migration name is required for add command"
  exit 1
fi

if [ "$command" = "sql" ] && [ -z "$output_name" ]; then
  echo "Error: Output name is required for sql command"
  echo "Printing migration list..."
  dotnet ef migrations list \
    -s "$server_proj" \
    -p "$ef_proj" \
    --context "$context" \
    $no_build \
    -- --automation
  exit 1
fi

# Ensure output name has .sql extension
if [ "$command" = "sql" ] && [[ "$output_name" != *.sql ]]; then
  output_name="${output_name}.sql"
fi

# log the connection string
echo "> Connection string: $connection"

# Execute commands
if [ "$command" = "add" ]; then
  echo "Adding migration: $migration_name"
  dotnet ef migrations add "$migration_name" \
    -s "$server_proj" \
    -p "$ef_proj" \
    --context "$context" \
    $no_build \
    -- --automation

elif [ "$command" = "up" ]; then
  if [ -n "$info" ]; then
    echo "Database context info:"
    dotnet ef dbcontext info \
      -s "$server_proj" \
      --context "$context" \
      --no-build \
      -- --automation ${connection:+-- --connection "$connection"}

    echo -e "\nMigration list:"
    dotnet ef migrations list \
      -s "$server_proj" \
      -p "$ef_proj" \
      --context "$context" \
      $no_build \
      -- --automation ${connection:+-- --connection "$connection"}
  else
    echo "Updating database to latest migration"
    dotnet ef database update \
      -s "$server_proj" \
      -p "$ef_proj" \
      --context "$context" \
      $no_build \
      -- --automation ${connection:+-- --connection "$connection"}
  fi

elif [ "$command" = "sql" ]; then
  echo "Generating SQL script: $output_name"
  
  # Build the command based on provided migrations
  if [ -z "$from_migration" ]; then
    dotnet ef migrations script \
      -o "$scripts_dir/$output_name" \
      -s "$server_proj" \
      -p "$ef_proj" \
      --context "$context" \
      $no_build \
      -- --automation
  elif [ -z "$to_migration" ]; then
    dotnet ef migrations script "$from_migration" \
      -o "$scripts_dir/$output_name" \
      -s "$server_proj" \
      -p "$ef_proj" \
      --context "$context" \
      $no_build \
      -- --automation
  else
    dotnet ef migrations script "$from_migration" "$to_migration" \
      -o "$scripts_dir/$output_name" \
      -s "$server_proj" \
      -p "$ef_proj" \
      --context "$context" \
      $no_build \
      -- --automation
  fi
fi
