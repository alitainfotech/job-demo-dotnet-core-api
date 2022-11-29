using JobApplicationApi.Models;

namespace JobApplicationApi.IServices
{
    public interface ICandidateService
    {
        Candidate AddCandidate(Candidate candidate);
        IEnumerable<Candidate> GetCandidate();
        //Candidate GetCandidateById(int id);
        //Candidate UpdateCandidate(Candidate employee);
        Candidate DeleteCandidate(int id);
    }
}
