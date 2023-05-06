using API_Labb4.Models;
using ClassLibraryLabb4;
using Microsoft.EntityFrameworkCore;

namespace API_Labb4.Services
{
    public class PeopleInterestRepo : IPeopleInterestRepo
    {
        private AppDbContext _context;
        public PeopleInterestRepo(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AddInterestToPerson(int personId, int interestId)
        {
            await _context.PersonInterests.AddAsync(new PersonInterest
            {
                PersonID = personId,
                InterestID = interestId
            });
            await _context.SaveChangesAsync();
        }

        public async Task AddNewLinkForInterest(int interestId, string links)
        {
            await _context.Links.AddAsync(new Link
            {
                InterestID = interestId,
                URL = links
            });
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetInterestForPerson(int personId)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.PersonID == personId);
            if (person != null)
            {
                var personInterest = await _context.PersonInterests.Where(p => p.PersonID == personId).Select(i => i.Interest).ToListAsync();
                return personInterest;
            }
            return null;
        }
        public async Task<IEnumerable<Link>> GetLinkForPerson(int personId)
        {
            var person = await _context.Persons.FindAsync(personId);
            if (person != null)
            {
                var personLink = await _context.PersonInterests.Where(i => i.PersonID == personId).SelectMany(x => x.Interest.Links).ToListAsync();
                return personLink;
            }
            return null;
        }
    }
}
