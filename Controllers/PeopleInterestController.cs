using API_Labb4.Services;
using ClassLibraryLabb4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API_Labb4.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PeopleInterestController : ControllerBase
    {
        private IPeopleInterestRepo _peopleInterestRepo;
        public PeopleInterestController(IPeopleInterestRepo peopleInterestRepo)
        {
            this._peopleInterestRepo = peopleInterestRepo;
        }
        [HttpGet("/Get All People")]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                return Ok(await _peopleInterestRepo.GetAllPeople());
            }
            catch (Exception)
            {
                return StatusCode(418);
            }
        }

        [HttpGet("/Interest By PersonID")]
        public async Task<IActionResult> GetInterestsByID(int id)
        {
            try
            {
                return Ok(await _peopleInterestRepo.GetInterestForPerson(id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(418);
            }
        }
        [HttpGet("Links in interest by person ID")]
        public async Task<IActionResult> GetLinksOfInterest(int id)
        {
            try
            {
                return Ok(await _peopleInterestRepo.GetLinkForPerson(id));
            }
            catch (Exception)
            {
                return StatusCode(418);
            }
        }
        [HttpPost("New Interest for person with id")]
        public async Task<IActionResult> NewInterestForPerson(int id, int interestId)
        {
            try
            {
                await _peopleInterestRepo.AddInterestToPerson(id, interestId);
                return Ok("New Interest was Added");
            }
            catch (Exception)
            {
                return StatusCode(418);
            }
        }
        [HttpPost("New Link for Interest")]
        public async Task<IActionResult> NewLinkForInterest(int interestId, string link)
        {
            try
            {
                await _peopleInterestRepo.AddNewLinkForInterest(interestId, link);
                return Ok("New Link was added to interest");
            }
            catch (Exception)
            {
                return StatusCode(418);
            }
        }
    }
}
