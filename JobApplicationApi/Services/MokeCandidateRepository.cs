using JobApplicationApi.IServices;
using JobApplicationApi.Models;

namespace JobApplicationApi.Services
{
    public class MokeCandidateRepository : ICandidateService
    {
        List<Candidate> listCandidate;

        public MokeCandidateRepository()
        {
            listCandidate = new List<Candidate>() {
            new Candidate(){Id= 1,Name="Imran",Date= DateTime.Now ,POB="Sadhli"},
            new Candidate(){Id= 2,Name="Abhi",Date= DateTime.Now ,POB="Surat"},
            new Candidate(){Id= 3,Name="Rohan",Date= DateTime.Now ,POB="Amlsad"}

           };
        }

        public IEnumerable<Candidate> GetCandidate()
        {
            return listCandidate;
        }
        public Candidate AddCandidate(Candidate candidate)
        {
            if (candidate != null)
            {
                candidate.Id = listCandidate.Max(x => x.Id) + 1;
                listCandidate.Add(candidate);
                return candidate;
            }
            return null;
        }

        public Candidate DeleteCandidate(int id)
        {
            var candidate = listCandidate.FirstOrDefault(x => x.Id == id);
            if (candidate != null)
            {
                listCandidate.Remove(candidate);
                return candidate;
            }
            return null;
        }

    }
}
