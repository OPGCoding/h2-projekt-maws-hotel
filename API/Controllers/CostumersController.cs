using HotelBooking.Data;
using HotelBooking.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumersController : ControllerBase
    {
        private readonly Database databaseContekst;

        public CostumersController(Database DatabaseContekst)
        {
            databaseContekst = DatabaseContekst;
        }

        [HttpGet]
        public IActionResult HentAlleKunder()
        {
           var alleKunder = databaseContekst.Costumers.ToList();

            return Ok(alleKunder);
        }

        [HttpGet]
        [Route("{id:guid}")]
         
        public IActionResult HentKundebyId(Guid id) {

            var kunde = databaseContekst.Costumers.Find(id);
        
            if (kunde is null)
            {
                return NotFound();
            }

            return Ok(kunde);
        }


        [HttpPost] 
        public IActionResult NyKunde(Models.CostumerDto costumerDto)
        {
            var kundeEntity = new Costumer()
            {
                Name = costumerDto.Name,
                Email = costumerDto.Email,
                Adresse = costumerDto.Adresse,
                TelefonNr = costumerDto.TelefonNr,
            };



            databaseContekst.Costumers.Add(kundeEntity);
            databaseContekst.SaveChanges();

            return Ok(kundeEntity);

            


            
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult KundeUpdate(Guid id, KundeUpdateDto updateKundeDto) {
            var kunde = databaseContekst.Costumers.Find(id);
                
                if (kunde is null)
            {
                return NotFound();
            }
                 kunde.Name = updateKundeDto.Name;
                kunde.Email = updateKundeDto.Email;
            kunde.Adresse = updateKundeDto.Adresse;
            kunde.TelefonNr = updateKundeDto.TelefonNr;


            databaseContekst.SaveChanges();
            return Ok(kunde);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult SletKunde(Guid id)
        {
            var kunde = databaseContekst.Costumers.Find(id);
            if (kunde is null)
            {
                return NotFound();
            }
            databaseContekst.Costumers.Remove(kunde);
            databaseContekst.SaveChanges();

            return Ok();
        }

        
    }
}
