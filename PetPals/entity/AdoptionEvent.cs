using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.entity
{
    public class AdoptionEvent
    {
        public List<IAdoptable> Participants { get; set; } = new List<IAdoptable>();

        public void RegisterParticipant(IAdoptable participant)
        {
            Participants.Add(participant);
        }

        public void HostEvent()
        {
            Console.WriteLine("Hosting adoption event...");
            foreach (var participant in Participants)
            {
                participant.Adopt();
            }
        }
    }
}