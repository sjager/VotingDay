using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingDay;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            testCondorcetStuff();
        }

        static void testCondorcetStuff()
        {
            Candidate testCandidate1 = new Candidate()
            {
                Name = "test 1",
                Votes = 4
            };

            Candidate testCandidate2 = new Candidate()
            {
                Name = "test 2",
                Votes = 3
            };

            Candidate testCandidate3 = new Candidate()
            {
                Name = "test 3",
                Votes = 2
            };

            Candidate testCandidate4 = new Candidate()
            {
                Name = "test 4",
                Votes = 1
            };

            List<Candidate> testList = new List<Candidate> { testCandidate1, testCandidate2, testCandidate3, testCandidate4 };

            VotingResults testVR = new VotingResults(testList);

            Console.WriteLine("done");
        }
    }
}
