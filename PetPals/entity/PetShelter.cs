using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.entity
{
    public class PetShelter
    {
        private List<Pet> availablePets = new List<Pet>();

        public void AddPet(Pet pet)
        {
            availablePets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            availablePets.Remove(pet);
        }

        public void ListAvailablePets()
        {
            if (availablePets.Count == 0)
            {
                Console.WriteLine("No pets available.");
                return;
            }

            foreach (var pet in availablePets)
            {
                Console.WriteLine(pet?.ToString() ?? "Missing pet information");
            }
        }

        public List<Pet> GetAvailablePets()
        {
            return availablePets;
        }
    }
}