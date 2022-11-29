using Microsoft.EntityFrameworkCore;
using JobApplicationApi.IServices;
using JobApplicationApi.Models;

namespace JobApplicationApi.Services
{
    public class CandidateService : ICandidateService
    {
        APICoreDBContext dbContext;

        public CandidateService(APICoreDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public IEnumerable<Candidate> GetCandidate()
        {
            var candidates = dbContext.Candidates.ToList();
            return candidates;
        }
        public Candidate AddCandidate(Candidate candidate)
        {
            if (candidate != null)
            {
                dbContext.Candidates.Add(candidate);
                dbContext.SaveChanges();
                return candidate;
            }
            return null;
        }
        public Candidate DeleteCandidate(int id)
        {
            var candidate = dbContext.Candidates.FirstOrDefault(x => x.Id == id);
            if (candidate != null)
            {
                dbContext.Entry(candidate).State = EntityState.Deleted;
                dbContext.SaveChanges();
                return candidate;
            }
            return null;
        }
    }
}
