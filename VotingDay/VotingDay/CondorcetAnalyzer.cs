using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingDay
{
    class CondorcetAnalyzer
    {

        private Candidate _condorcetWinner = null;
        private VotingResults _vr;
        private bool _condorcetConditionSatisfied = false;
        private bool _foundCondorcetWinner = false;

        public Candidate CondorcetWinner
        {
            get
            {
                return _condorcetWinner;
            }
            private set
            {
                _condorcetWinner = value;
            }
        }

        public bool CondorcetConditionSatisfied
        {
            get
            {
                return _condorcetConditionSatisfied;
            }
            private set
            {
                _condorcetConditionSatisfied = value;
            }
        }

        public bool FoundCondorcetWinner
        {
            get
            {
                return _foundCondorcetWinner;
            }
            private set
            {
                _foundCondorcetWinner = value;
            }
        }

        public CondorcetAnalyzer(VotingResults results)
        {
            this._vr = results;
            FindCondorcetWinner();
            DetermineSatisfaction();
        }

        //this is all wrong...but it may come in handy later?
        public void FindCondorcetWinner()
        {

            int largestHit = 0;
            _condorcetWinner = null;

            foreach(Candidate c in _vr.Candidates.ToList())
            {
                List<Candidate> candidatesSubset = _vr.Candidates;
                candidatesSubset.Remove(c);

                int preferenceTally = 0;

                foreach(Candidate compareCandidate in candidatesSubset)
                {
                    if(c.Votes > compareCandidate.Votes)
                    {
                        preferenceTally++;
                    }
                }
                
                if(preferenceTally == largestHit)
                {
                    _foundCondorcetWinner = false;
                    _condorcetWinner = null;
                }
                else if(preferenceTally > largestHit)
                {
                    _condorcetWinner = c;
                    largestHit = preferenceTally;
                    _foundCondorcetWinner = true;
                }
            }
        }

        public void DetermineSatisfaction()
        {
            if(_foundCondorcetWinner)
            {
                _condorcetConditionSatisfied = _condorcetWinner.Votes == _vr.Winner.Votes;
            }
        }

    }
}
