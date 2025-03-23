using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace mega.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
static string json = """
[{"username":"ikohrsen0","name":"Ivy Kohrsen","email":"ikohrsen0@wunderground.com","phone_number":"938-217-5065","status":"Suspended","role":"Superadmin"},
{"username":"mtrusdale1","name":"Martica Trusdale","email":"mtrusdale1@ucsd.edu","phone_number":"487-962-4732","status":"Suspended","role":"Admin"},
{"username":"vbode2","name":"Virgilio Bode","email":"vbode2@thetimes.co.uk","phone_number":"886-318-0168","status":"Active","role":"Cashier"},
{"username":"npicknett3","name":"Nina Picknett","email":"npicknett3@cloudflare.com","phone_number":"136-350-7873","status":"Active","role":"Superadmin"},
{"username":"spedican4","name":"Susie Pedican","email":"spedican4@vistaprint.com","phone_number":"554-387-4705","status":"Active","role":"Cashier"},
{"username":"epollington5","name":"Ediva Pollington","email":"epollington5@tiny.cc","phone_number":"718-631-5515","status":"Active","role":"Superadmin"},
{"username":"hcarnie6","name":"Horatio Carnie","email":"hcarnie6@ebay.com","phone_number":"749-218-3803","status":"Suspended","role":"Admin"},
{"username":"etohill7","name":"Ellerey Tohill","email":"etohill7@bloglines.com","phone_number":"834-518-3035","status":"Active","role":"Admin"},
{"username":"mmatveyev8","name":"Mack Matveyev","email":"mmatveyev8@vimeo.com","phone_number":"829-784-0328","status":"Suspended","role":"Cashier"},
{"username":"mkinrade9","name":"Marchelle Kinrade","email":"mkinrade9@nifty.com","phone_number":"190-845-5198","status":"Suspended","role":"Cashier"},
{"username":"jcausbya","name":"Juana Causby","email":"jcausbya@princeton.edu","phone_number":"460-732-6700","status":"Suspended","role":"Cashier"},
{"username":"acoxb","name":"Alexine Cox","email":"acoxb@yahoo.co.jp","phone_number":"633-852-5847","status":"Inactive","role":"Cashier"},
{"username":"zsandlec","name":"Zach Sandle","email":"zsandlec@ihg.com","phone_number":"561-387-6098","status":"Suspended","role":"Admin"},
{"username":"eilyinykhd","name":"Eadith Ilyinykh","email":"eilyinykhd@ucoz.com","phone_number":"211-382-3585","status":"Suspended","role":"Superadmin"},
{"username":"gpeinkee","name":"Georgia Peinke","email":"gpeinkee@meetup.com","phone_number":"618-305-1459","status":"Inactive","role":"Cashier"},
{"username":"svsanellif","name":"Stanfield Vsanelli","email":"svsanellif@unicef.org","phone_number":"248-159-0210","status":"Inactive","role":"Cashier"},
{"username":"skropachg","name":"Sascha Kropach","email":"skropachg@naver.com","phone_number":"666-802-0976","status":"Active","role":"Superadmin"},
{"username":"anugenth","name":"Angelita Nugent","email":"anugenth@fotki.com","phone_number":"570-690-7928","status":"Inactive","role":"Superadmin"},
{"username":"lvani","name":"Lisbeth Van Leijs","email":"lvani@shareasale.com","phone_number":"911-657-4861","status":"Active","role":"Superadmin"},
{"username":"jvaninij","name":"Jennifer Vanini","email":"jvaninij@deviantart.com","phone_number":"451-382-3503","status":"Active","role":"Cashier"},
{"username":"mkupiszk","name":"Megen Kupisz","email":"mkupiszk@scientificamerican.com","phone_number":"672-480-2149","status":"Inactive","role":"Cashier"},
{"username":"jmallockl","name":"Jacob Mallock","email":"jmallockl@google.it","phone_number":"770-810-4595","status":"Inactive","role":"Superadmin"},
{"username":"bmicahm","name":"Belva Micah","email":"bmicahm@qq.com","phone_number":"109-455-5861","status":"Inactive","role":"Admin"},
{"username":"rstoacleyn","name":"Rutherford Stoacley","email":"rstoacleyn@mlb.com","phone_number":"590-453-0675","status":"Suspended","role":"Cashier"},
{"username":"fmulliso","name":"Franklin Mullis","email":"fmulliso@fda.gov","phone_number":"373-476-4822","status":"Active","role":"Admin"},
{"username":"djoinerp","name":"Derwin Joiner","email":"djoinerp@ucsd.edu","phone_number":"643-710-6331","status":"Suspended","role":"Superadmin"},
{"username":"tcomiskeyq","name":"Tawnya Comiskey","email":"tcomiskeyq@lycos.com","phone_number":"432-920-2844","status":"Active","role":"Admin"},
{"username":"evaggr","name":"Ethelyn Vagg","email":"evaggr@youku.com","phone_number":"629-149-9534","status":"Active","role":"Admin"},
{"username":"ssimpkinss","name":"Sander Simpkins","email":"ssimpkinss@auda.org.au","phone_number":"221-628-2221","status":"Inactive","role":"Cashier"},
{"username":"timost","name":"Tawsha Imos","email":"timost@ycombinator.com","phone_number":"875-867-1467","status":"Inactive","role":"Cashier"},
{"username":"egaitu","name":"Earl Gait","email":"egaitu@taobao.com","phone_number":"878-722-1557","status":"Inactive","role":"Admin"},
{"username":"carnoultv","name":"Cassie Arnoult","email":"carnoultv@amazon.co.uk","phone_number":"767-839-9476","status":"Inactive","role":"Admin"},
{"username":"iproudw","name":"Isiahi Proud","email":"iproudw@ning.com","phone_number":"282-263-8431","status":"Active","role":"Cashier"},
{"username":"lprykex","name":"Lutero Pryke","email":"lprykex@latimes.com","phone_number":"978-705-2839","status":"Inactive","role":"Cashier"},
{"username":"tplaunchy","name":"Trefor Plaunch","email":"tplaunchy@harvard.edu","phone_number":"798-957-0150","status":"Suspended","role":"Admin"},
{"username":"bfurleyz","name":"Brigitta Furley","email":"bfurleyz@jimdo.com","phone_number":"654-742-1078","status":"Suspended","role":"Superadmin"},
{"username":"stern10","name":"Sigismundo Tern","email":"stern10@surveymonkey.com","phone_number":"825-817-1276","status":"Suspended","role":"Superadmin"},
{"username":"deyree11","name":"Dillon Eyree","email":"deyree11@ucoz.ru","phone_number":"891-548-3195","status":"Inactive","role":"Superadmin"},
{"username":"gsweeting12","name":"Gage Sweeting","email":"gsweeting12@japanpost.jp","phone_number":"806-242-4742","status":"Active","role":"Superadmin"},
{"username":"dthornley13","name":"Deni Thornley","email":"dthornley13@cbc.ca","phone_number":"819-555-3682","status":"Suspended","role":"Cashier"},
{"username":"gaggiss14","name":"Gillan Aggiss","email":"gaggiss14@ca.gov","phone_number":"305-780-7997","status":"Active","role":"Cashier"},
{"username":"llightowlers15","name":"Lawton Lightowlers","email":"llightowlers15@seattletimes.com","phone_number":"472-383-2617","status":"Active","role":"Admin"},
{"username":"denga16","name":"Daffy Enga","email":"denga16@qq.com","phone_number":"787-400-8660","status":"Active","role":"Cashier"},
{"username":"wsimmonett17","name":"Worthy Simmonett","email":"wsimmonett17@elegantthemes.com","phone_number":"941-550-1510","status":"Suspended","role":"Cashier"},
{"username":"lbaggiani18","name":"Lena Baggiani","email":"lbaggiani18@istockphoto.com","phone_number":"619-163-8500","status":"Inactive","role":"Superadmin"},
{"username":"tsawfoot19","name":"Trace Sawfoot","email":"tsawfoot19@utexas.edu","phone_number":"318-969-1905","status":"Active","role":"Superadmin"},
{"username":"fjacques1a","name":"Fianna Jacques","email":"fjacques1a@networksolutions.com","phone_number":"201-277-5900","status":"Active","role":"Superadmin"},
{"username":"jalexsandrovich1b","name":"Jenny Alexsandrovich","email":"jalexsandrovich1b@rediff.com","phone_number":"464-230-3638","status":"Suspended","role":"Cashier"},
{"username":"sorman1c","name":"Schuyler Orman","email":"sorman1c@omniture.com","phone_number":"298-454-2740","status":"Active","role":"Admin"},
{"username":"ralyukin1d","name":"Roderigo Alyukin","email":"ralyukin1d@globo.com","phone_number":"408-463-9263","status":"Inactive","role":"Superadmin"},
{"username":"fbartell1e","name":"Fianna Bartell","email":"fbartell1e@unesco.org","phone_number":"751-352-4755","status":"Suspended","role":"Admin"},
{"username":"gfendley1f","name":"Gillan Fendley","email":"gfendley1f@google.pl","phone_number":"896-437-0050","status":"Active","role":"Cashier"},
{"username":"snewgrosh1g","name":"Scottie Newgrosh","email":"snewgrosh1g@printfriendly.com","phone_number":"444-818-1513","status":"Inactive","role":"Superadmin"},
{"username":"craden1h","name":"Connor Raden","email":"craden1h@slideshare.net","phone_number":"407-733-5765","status":"Active","role":"Admin"},
{"username":"fgreswell1i","name":"Fergus Greswell","email":"fgreswell1i@usgs.gov","phone_number":"747-122-9588","status":"Suspended","role":"Admin"},
{"username":"awick1j","name":"Angelo Wick","email":"awick1j@linkedin.com","phone_number":"811-494-8015","status":"Suspended","role":"Superadmin"},
{"username":"wjudkin1k","name":"Wandis Judkin","email":"wjudkin1k@instagram.com","phone_number":"640-291-3781","status":"Suspended","role":"Cashier"},
{"username":"psmithson1l","name":"Phillida Smithson","email":"psmithson1l@theguardian.com","phone_number":"657-351-7771","status":"Inactive","role":"Cashier"},
{"username":"rkewley1m","name":"Rosalyn Kewley","email":"rkewley1m@deliciousdays.com","phone_number":"340-148-1932","status":"Suspended","role":"Superadmin"},
{"username":"cmapes1n","name":"Calypso Mapes","email":"cmapes1n@goodreads.com","phone_number":"182-729-9691","status":"Inactive","role":"Superadmin"},
{"username":"tpople1o","name":"Tracie Pople","email":"tpople1o@washingtonpost.com","phone_number":"480-428-1877","status":"Inactive","role":"Cashier"},
{"username":"vshailer1p","name":"Vito Shailer","email":"vshailer1p@feedburner.com","phone_number":"441-450-3274","status":"Inactive","role":"Admin"},
{"username":"ckeenlayside1q","name":"Courtnay Keenlayside","email":"ckeenlayside1q@virginia.edu","phone_number":"535-875-1244","status":"Suspended","role":"Superadmin"},
{"username":"cgoodlett1r","name":"Candida Goodlett","email":"cgoodlett1r@google.it","phone_number":"163-267-6780","status":"Suspended","role":"Cashier"},
{"username":"nlloydwilliams1s","name":"Nesta Lloyd-Williams","email":"nlloydwilliams1s@friendfeed.com","phone_number":"838-885-2724","status":"Inactive","role":"Superadmin"},
{"username":"fpaffett1t","name":"Florence Paffett","email":"fpaffett1t@1688.com","phone_number":"834-892-5416","status":"Suspended","role":"Superadmin"},
{"username":"ozarb1u","name":"Osmond Zarb","email":"ozarb1u@fastcompany.com","phone_number":"945-757-4736","status":"Inactive","role":"Admin"},
{"username":"nclaughton1v","name":"Nance Claughton","email":"nclaughton1v@devhub.com","phone_number":"150-446-6851","status":"Suspended","role":"Superadmin"},
{"username":"bsummers1w","name":"Betteann Summers","email":"bsummers1w@sakura.ne.jp","phone_number":"254-725-2897","status":"Inactive","role":"Superadmin"},
{"username":"imcgarry1x","name":"Ingrim McGarry","email":"imcgarry1x@simplemachines.org","phone_number":"445-201-3138","status":"Active","role":"Superadmin"},
{"username":"dwebling1y","name":"Darleen Webling","email":"dwebling1y@utexas.edu","phone_number":"379-497-6732","status":"Suspended","role":"Cashier"},
{"username":"ddelamaine1z","name":"Dasi Delamaine","email":"ddelamaine1z@marriott.com","phone_number":"723-478-2987","status":"Inactive","role":"Admin"},
{"username":"mcaisley20","name":"Marius Caisley","email":"mcaisley20@dedecms.com","phone_number":"916-225-6132","status":"Inactive","role":"Cashier"},
{"username":"ptointon21","name":"Pauletta Tointon","email":"ptointon21@zdnet.com","phone_number":"280-888-3322","status":"Suspended","role":"Superadmin"},
{"username":"dcroxall22","name":"Dulcie Croxall","email":"dcroxall22@artisteer.com","phone_number":"101-213-9804","status":"Suspended","role":"Cashier"},
{"username":"afernehough23","name":"Astrix Fernehough","email":"afernehough23@1und1.de","phone_number":"411-329-4469","status":"Suspended","role":"Admin"},
{"username":"jadamiak24","name":"Jo Adamiak","email":"jadamiak24@ca.gov","phone_number":"972-534-2610","status":"Inactive","role":"Cashier"},
{"username":"hpuckinghorne25","name":"Hill Puckinghorne","email":"hpuckinghorne25@is.gd","phone_number":"302-702-1513","status":"Active","role":"Cashier"},
{"username":"hadamovsky26","name":"Holly Adamovsky","email":"hadamovsky26@mysql.com","phone_number":"438-661-1516","status":"Suspended","role":"Admin"},
{"username":"bde27","name":"Bourke De Michele","email":"bde27@auda.org.au","phone_number":"957-858-1326","status":"Suspended","role":"Admin"},
{"username":"tkeating28","name":"Tucker Keating","email":"tkeating28@vistaprint.com","phone_number":"339-851-4034","status":"Active","role":"Superadmin"},
{"username":"gbeavan29","name":"Geoffrey Beavan","email":"gbeavan29@pen.io","phone_number":"113-293-9863","status":"Active","role":"Admin"},
{"username":"sstrathman2a","name":"Shem Strathman","email":"sstrathman2a@howstuffworks.com","phone_number":"888-958-3987","status":"Inactive","role":"Superadmin"},
{"username":"cnijssen2b","name":"Camala Nijssen","email":"cnijssen2b@auda.org.au","phone_number":"115-471-4208","status":"Suspended","role":"Admin"},
{"username":"tszwandt2c","name":"Tammara Szwandt","email":"tszwandt2c@newsvine.com","phone_number":"221-428-9564","status":"Inactive","role":"Admin"},
{"username":"hsmitheram2d","name":"Hartwell Smitheram","email":"hsmitheram2d@npr.org","phone_number":"371-682-1162","status":"Active","role":"Superadmin"},
{"username":"asyred2e","name":"Ayn Syred","email":"asyred2e@nps.gov","phone_number":"179-140-5671","status":"Inactive","role":"Superadmin"},
{"username":"twilber2f","name":"Tessie Wilber","email":"twilber2f@gravatar.com","phone_number":"578-649-5442","status":"Active","role":"Cashier"},
{"username":"sganforth2g","name":"Silvia Ganforth","email":"sganforth2g@soundcloud.com","phone_number":"900-302-8062","status":"Inactive","role":"Cashier"},
{"username":"slanda2h","name":"Shell Landa","email":"slanda2h@nbcnews.com","phone_number":"351-469-2113","status":"Active","role":"Admin"},
{"username":"kburnyate2i","name":"Kaitlin Burnyate","email":"kburnyate2i@google.co.uk","phone_number":"904-183-9977","status":"Active","role":"Cashier"},
{"username":"bcoffey2j","name":"Benedikta Coffey","email":"bcoffey2j@webs.com","phone_number":"650-416-8846","status":"Inactive","role":"Admin"},
{"username":"pelcum2k","name":"Pavlov Elcum","email":"pelcum2k@wunderground.com","phone_number":"627-205-4040","status":"Inactive","role":"Superadmin"},
{"username":"hsharper2l","name":"Hadlee Sharper","email":"hsharper2l@buzzfeed.com","phone_number":"142-512-4515","status":"Suspended","role":"Cashier"},
{"username":"dmidson2m","name":"Dill Midson","email":"dmidson2m@geocities.com","phone_number":"732-386-8592","status":"Suspended","role":"Cashier"},
{"username":"ngiacomozzo2n","name":"Nananne Giacomozzo","email":"ngiacomozzo2n@omniture.com","phone_number":"632-828-0068","status":"Inactive","role":"Superadmin"},
{"username":"fdaniello2o","name":"Farly Daniello","email":"fdaniello2o@gizmodo.com","phone_number":"768-765-6147","status":"Active","role":"Superadmin"},
{"username":"lmaso2p","name":"Larry Maso","email":"lmaso2p@mediafire.com","phone_number":"634-539-7011","status":"Inactive","role":"Cashier"},
{"username":"ncastello2q","name":"Nehemiah Castello","email":"ncastello2q@storify.com","phone_number":"694-737-9803","status":"Suspended","role":"Cashier"},
{"username":"lglencrosche2r","name":"Leonhard Glencrosche","email":"lglencrosche2r@reuters.com","phone_number":"853-252-3790","status":"Suspended","role":"Cashier"}]
""";

        public async Task<IActionResult> Get()
        {
            
            UserDto[] users = System.Text.Json.JsonSerializer.Deserialize<UserDto[]>(json);
            return Ok(users);
        }
    }

    public class UserDto
    {
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;
    }
}
