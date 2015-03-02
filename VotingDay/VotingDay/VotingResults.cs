using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingDay
{
    public class VotingResults
    {
        public List<Candidate> Candidates;
        public Candidate Winner;
        public Candidate CondorcetWinner;
        public bool hasCondorcetWinner;
        public bool satisfiesCondorcet;

        public VotingResults(List<Candidate> candidates)
        {
            Candidates = candidates;
            OrderCandidatesByVotes();
            Winner = Candidates[0];
            
            //CondorcetAnalyzer analyzer = new CondorcetAnalyzer(this);

            //hasCondorcetWinner = analyzer.FoundCondorcetWinner;
            //satisfiesCondorcet = analyzer.CondorcetConditionSatisfied;
            //CondorcetWinner = analyzer.CondorcetWinner;
        }

        private void OrderCandidatesByVotes()
        {
            Candidates = Candidates.OrderByDescending(c => c.Votes).ThenBy(c => c.Name).ToList();
        }
    }
}
