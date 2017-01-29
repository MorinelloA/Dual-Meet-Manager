using DualMeetManager.Domain.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DualMeetManager
{
    class Program
    {
        static void Main(string[] args)
        {
            IndEvent indEvent1 = new IndEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "P1", "PLM", "11.3"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(8.0m, 1.0m));
            IndEvent indEvent2 = new IndEvent("PLM", "GWY", new EventPoints(0.0m, 5.0m, "P5", "PLM", "11.2"), new EventPoints(3.0m, 0.0m, "P2", "PLM", "11.4"), new EventPoints(0.0m, 1.0m, "G1", "GWY", "11.5"), Tuple.Create(3.0m, 6.0m));
            Dictionary<string, IndEvent> indEvents = new Dictionary<string, IndEvent>();
            indEvents.Add("Boy's 100", indEvent1);
            indEvents.Add("Boy's 200", indEvent2);

            RelayEvent relayEvent1 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "11.3"), new EventPoints(0.0m, 0.0m, "A", "GWY", "11.4"), Tuple.Create(5.0m, 0.0m));
            RelayEvent relayEvent2 = new RelayEvent("PLM", "GWY", new EventPoints(5.0m, 0.0m, "A", "PLM", "400"), new EventPoints(0.0m, 0.0m, "A", "GWY", "500"), Tuple.Create(5.0m, 0.0m));
            Dictionary<string, RelayEvent> relayEvents = new Dictionary<string, RelayEvent>();
            relayEvents.Add("Boy's 4x100", relayEvent1);
            relayEvents.Add("Boy's 4x400", relayEvent2);

            OverallScore myOverallScore = new OverallScore(Tuple.Create("PLM", "Plum", 10.0m), Tuple.Create("GWY", "Gateway", 6.0m), indEvents, relayEvents);

            Console.WriteLine(myOverallScore.ToString());
        }
    }
}
