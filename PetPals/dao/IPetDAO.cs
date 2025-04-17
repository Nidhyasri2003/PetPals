using PetPals.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao
{
    public interface IPetDAO
    {
        List<Pet> GetAllPets();
        void AddPet(Pet pet);
    }
}