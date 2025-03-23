# Mega

## API

## Client

- Install [volta](https://volta.sh/)
- Install node: `volta install node@22`
- Install pnpm: `npm i -g pnpm`
- Install dependencies: `pnpm --prefix src\megaapp\ install`

Start the server:

```
pnpm --prefix src\megaapp\ run dev
```

## Release

Run the command `.\release.ps1`, it'll build .net and react app to `.\publish` folder.