using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace mega.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            var json = """
                                [{
                  "Id": "1",
                  "Name": "Carlene",
                  "Role": "Mr",
                  "Status": "Active",
                  "Company": "Dabtype",
                  "AvatarUrl": "https://tinyurl.com/maecenas/tincidunt/lacus/at/velit/vivamus/vel.js?pellentesque=sit&eget=amet&nunc=consectetuer&donec=adipiscing&quis=elit&orci=proin&eget=interdum&orci=mauris&vehicula=non&condimentum=ligula&curabitur=pellentesque&in=ultrices&libero=phasellus&ut=id",
                  "IsVerified": true
                }, {
                  "Id": "2",
                  "Name": "Rab",
                  "Role": "Ms",
                  "Status": "Inactive",
                  "Company": "Linkbuzz",
                  "AvatarUrl": "http://tuttocitta.it/vestibulum/velit/id/pretium/iaculis/diam/erat.xml?accumsan=ut&felis=odio&ut=cras&at=mi&dolor=pede&quis=malesuada&odio=in&consequat=imperdiet&varius=et&integer=commodo&ac=vulputate&leo=justo&pellentesque=in",
                  "IsVerified": true
                }, {
                  "Id": "3",
                  "Name": "Hilliary",
                  "Role": "Mrs",
                  "Status": "Active",
                  "Company": "Edgeify",
                  "AvatarUrl": "https://slashdot.org/ac/neque/duis/bibendum/morbi/non/quam.html?aliquam=ultricies&erat=eu&volutpat=nibh&in=quisque&congue=id&etiam=justo&justo=sit",
                  "IsVerified": true
                }, {
                  "Id": "4",
                  "Name": "Domini",
                  "Role": "Mr",
                  "Status": "Banned",
                  "Company": "Eire",
                  "AvatarUrl": "https://ted.com/vestibulum/ante/ipsum/primis/in/faucibus.aspx?adipiscing=non&molestie=quam&hendrerit=nec&at=dui&vulputate=luctus&vitae=rutrum&nisl=nulla&aenean=tellus&lectus=in&pellentesque=sagittis&eget=dui&nunc=vel&donec=nisl&quis=duis&orci=ac&eget=nibh&orci=fusce&vehicula=lacus&condimentum=purus&curabitur=aliquet&in=at&libero=feugiat&ut=non&massa=pretium&volutpat=quis&convallis=lectus&morbi=suspendisse&odio=potenti&odio=in&elementum=eleifend&eu=quam&interdum=a&eu=odio&tincidunt=in&in=hac&leo=habitasse&maecenas=platea&pulvinar=dictumst&lobortis=maecenas&est=ut&phasellus=massa&sit=quis&amet=augue&erat=luctus",
                  "IsVerified": true
                }, {
                  "Id": "5",
                  "Name": "Starlin",
                  "Role": "Mr",
                  "Status": "Active",
                  "Company": "Abatz",
                  "AvatarUrl": "http://people.com.cn/pharetra/magna/vestibulum/aliquet.jsp?quam=at&fringilla=turpis&rhoncus=donec&mauris=posuere&enim=metus&leo=vitae&rhoncus=ipsum&sed=aliquam&vestibulum=non&sit=mauris&amet=morbi&cursus=non&id=lectus&turpis=aliquam&integer=sit&aliquet=amet&massa=diam&id=in&lobortis=magna&convallis=bibendum&tortor=imperdiet&risus=nullam&dapibus=orci&augue=pede&vel=venenatis&accumsan=non&tellus=sodales&nisi=sed&eu=tincidunt&orci=eu&mauris=felis&lacinia=fusce&sapien=posuere&quis=felis&libero=sed&nullam=lacus&sit=morbi&amet=sem&turpis=mauris&elementum=laoreet&ligula=ut&vehicula=rhoncus&consequat=aliquet&morbi=pulvinar&a=sed&ipsum=nisl&integer=nunc&a=rhoncus&nibh=dui&in=vel&quis=sem&justo=sed&maecenas=sagittis&rhoncus=nam&aliquam=congue&lacus=risus&morbi=semper&quis=porta&tortor=volutpat&id=quam&nulla=pede&ultrices=lobortis&aliquet=ligula&maecenas=sit&leo=amet&odio=eleifend&condimentum=pede&id=libero&luctus=quis&nec=orci&molestie=nullam&sed=molestie&justo=nibh&pellentesque=in&viverra=lectus&pede=pellentesque&ac=at&diam=nulla&cras=suspendisse&pellentesque=potenti&volutpat=cras&dui=in&maecenas=purus&tristique=eu&est=magna&et=vulputate&tempus=luctus&semper=cum",
                  "IsVerified": false
                }, {
                  "Id": "6",
                  "Name": "Florinda",
                  "Role": "Ms",
                  "Status": "Inactive",
                  "Company": "Jabberbean",
                  "AvatarUrl": "https://yolasite.com/velit/vivamus/vel/nulla/eget/eros.html?interdum=faucibus&mauris=orci&non=luctus&ligula=et&pellentesque=ultrices&ultrices=posuere&phasellus=cubilia&id=curae&sapien=duis&in=faucibus&sapien=accumsan&iaculis=odio&congue=curabitur&vivamus=convallis&metus=duis&arcu=consequat&adipiscing=dui&molestie=nec&hendrerit=nisi&at=volutpat&vulputate=eleifend&vitae=donec&nisl=ut&aenean=dolor&lectus=morbi&pellentesque=vel&eget=lectus&nunc=in&donec=quam&quis=fringilla&orci=rhoncus&eget=mauris&orci=enim&vehicula=leo&condimentum=rhoncus&curabitur=sed&in=vestibulum&libero=sit&ut=amet&massa=cursus&volutpat=id&convallis=turpis&morbi=integer&odio=aliquet&odio=massa&elementum=id&eu=lobortis&interdum=convallis&eu=tortor&tincidunt=risus&in=dapibus&leo=augue&maecenas=vel&pulvinar=accumsan&lobortis=tellus&est=nisi",
                  "IsVerified": true
                }, {
                  "Id": "7",
                  "Name": "Jarred",
                  "Role": "Rev",
                  "Status": "Active",
                  "Company": "Yadel",
                  "AvatarUrl": "https://usatoday.com/accumsan.xml?etiam=praesent&justo=blandit&etiam=lacinia&pretium=erat&iaculis=vestibulum&justo=sed&in=magna&hac=at&habitasse=nunc&platea=commodo&dictumst=placerat&etiam=praesent&faucibus=blandit&cursus=nam&urna=nulla&ut=integer&tellus=pede&nulla=justo&ut=lacinia&erat=eget&id=tincidunt&mauris=eget&vulputate=tempus&elementum=vel&nullam=pede&varius=morbi&nulla=porttitor&facilisi=lorem&cras=id&non=ligula&velit=suspendisse&nec=ornare&nisi=consequat&vulputate=lectus&nonummy=in&maecenas=est&tincidunt=risus&lacus=auctor&at=sed&velit=tristique&vivamus=in&vel=tempus&nulla=sit&eget=amet&eros=sem&elementum=fusce&pellentesque=consequat&quisque=nulla&porta=nisl&volutpat=nunc&erat=nisl&quisque=duis&erat=bibendum&eros=felis&viverra=sed&eget=interdum&congue=venenatis&eget=turpis&semper=enim&rutrum=blandit&nulla=mi&nunc=in&purus=porttitor&phasellus=pede&in=justo&felis=eu&donec=massa&semper=donec&sapien=dapibus&a=duis&libero=at&nam=velit&dui=eu&proin=est&leo=congue&odio=elementum&porttitor=in&id=hac&consequat=habitasse&in=platea&consequat=dictumst&ut=morbi&nulla=vestibulum&sed=velit&accumsan=id&felis=pretium&ut=iaculis&at=diam&dolor=erat&quis=fermentum&odio=justo&consequat=nec&varius=condimentum&integer=neque&ac=sapien&leo=placerat&pellentesque=ante",
                  "IsVerified": true
                }, {
                  "Id": "8",
                  "Name": "Donnajean",
                  "Role": "Mrs",
                  "Status": "Banned",
                  "Company": "Geba",
                  "AvatarUrl": "http://qq.com/posuere/cubilia/curae/duis.png?nisi=vel&volutpat=nulla&eleifend=eget&donec=eros&ut=elementum&dolor=pellentesque&morbi=quisque&vel=porta&lectus=volutpat&in=erat&quam=quisque&fringilla=erat&rhoncus=eros&mauris=viverra&enim=eget&leo=congue&rhoncus=eget&sed=semper&vestibulum=rutrum&sit=nulla&amet=nunc&cursus=purus&id=phasellus&turpis=in&integer=felis&aliquet=donec&massa=semper&id=sapien&lobortis=a&convallis=libero&tortor=nam&risus=dui&dapibus=proin&augue=leo&vel=odio&accumsan=porttitor&tellus=id&nisi=consequat&eu=in&orci=consequat&mauris=ut&lacinia=nulla&sapien=sed&quis=accumsan&libero=felis&nullam=ut&sit=at&amet=dolor&turpis=quis&elementum=odio&ligula=consequat&vehicula=varius&consequat=integer&morbi=ac&a=leo&ipsum=pellentesque&integer=ultrices&a=mattis&nibh=odio&in=donec&quis=vitae&justo=nisi&maecenas=nam&rhoncus=ultrices&aliquam=libero&lacus=non&morbi=mattis&quis=pulvinar&tortor=nulla&id=pede&nulla=ullamcorper&ultrices=augue&aliquet=a&maecenas=suscipit&leo=nulla&odio=elit&condimentum=ac&id=nulla&luctus=sed",
                  "IsVerified": true
                }, {
                  "Id": "9",
                  "Name": "Christiana",
                  "Role": "Ms",
                  "Status": "Active",
                  "Company": "Chatterbridge",
                  "AvatarUrl": "http://omniture.com/aliquet/ultrices/erat/tortor/sollicitudin/mi/sit.jsp?ipsum=vitae&primis=consectetuer&in=eget&faucibus=rutrum&orci=at&luctus=lorem&et=integer&ultrices=tincidunt&posuere=ante&cubilia=vel&curae=ipsum&nulla=praesent&dapibus=blandit&dolor=lacinia&vel=erat&est=vestibulum&donec=sed&odio=magna&justo=at&sollicitudin=nunc&ut=commodo&suscipit=placerat&a=praesent&feugiat=blandit&et=nam&eros=nulla&vestibulum=integer&ac=pede&est=justo&lacinia=lacinia&nisi=eget&venenatis=tincidunt&tristique=eget&fusce=tempus&congue=vel&diam=pede&id=morbi&ornare=porttitor&imperdiet=lorem&sapien=id&urna=ligula&pretium=suspendisse&nisl=ornare&ut=consequat&volutpat=lectus&sapien=in&arcu=est&sed=risus&augue=auctor&aliquam=sed&erat=tristique&volutpat=in&in=tempus&congue=sit&etiam=amet&justo=sem&etiam=fusce&pretium=consequat&iaculis=nulla&justo=nisl&in=nunc&hac=nisl&habitasse=duis&platea=bibendum&dictumst=felis&etiam=sed&faucibus=interdum&cursus=venenatis&urna=turpis&ut=enim",
                  "IsVerified": true
                }, {
                  "Id": "10",
                  "Name": "Bartolomeo",
                  "Role": "Rev",
                  "Status": "Inactive",
                  "Company": "Divanoodle",
                  "AvatarUrl": "https://macromedia.com/cras/pellentesque/volutpat/dui/maecenas/tristique.jsp?lacinia=et&eget=magnis&tincidunt=dis&eget=parturient&tempus=montes&vel=nascetur&pede=ridiculus&morbi=mus&porttitor=etiam&lorem=vel&id=augue&ligula=vestibulum&suspendisse=rutrum&ornare=rutrum&consequat=neque&lectus=aenean&in=auctor&est=gravida&risus=sem&auctor=praesent&sed=id&tristique=massa&in=id&tempus=nisl&sit=venenatis&amet=lacinia&sem=aenean&fusce=sit&consequat=amet&nulla=justo&nisl=morbi&nunc=ut&nisl=odio&duis=cras&bibendum=mi&felis=pede&sed=malesuada&interdum=in&venenatis=imperdiet&turpis=et&enim=commodo&blandit=vulputate&mi=justo&in=in&porttitor=blandit&pede=ultrices&justo=enim&eu=lorem",
                  "IsVerified": true
                }]
                """;
            UserDto[] users = System.Text.Json.JsonSerializer.Deserialize<UserDto[]>(json);
            return Ok(users);
        }
    }

    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
    }
}
