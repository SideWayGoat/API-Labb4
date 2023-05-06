using ClassLibraryLabb4;
using System.Collections;

namespace API_Labb4.Services
{
    public interface IPeopleInterestRepo
    {
        Task<IEnumerable<Person>> GetAllPeople();
        Task<IEnumerable<Interest>> GetInterestForPerson(int personId);
        Task<IEnumerable<Link>> GetLinkForPerson(int personId);
        Task AddInterestToPerson(int personId, int interestId);
        Task AddNewLinkForInterest(int interestId, string links);
    }
}
