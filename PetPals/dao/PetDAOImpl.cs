using PetPals.entity;
using System;
using Microsoft.Data.SqlClient;
using PetPals.Util;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao
{
    public class PetDAOImpl : IPetDAO
    {
        public List<Pet> GetAllPets()
        {
            List<Pet> pets = new List<Pet>();
            using (SqlConnection conn = DBConnUtil.GetConnection("conn.txt"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pets", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string type = reader["Type"].ToString();
                    string name = reader["Name"].ToString();
                    int age = Convert.ToInt32(reader["Age"]);
                    string breed = reader["Breed"].ToString();

                    if (type == "Dog")
                        pets.Add(new Dog(name, age, breed, reader["DogBreed"].ToString()));
                    else if (type == "Cat")
                        pets.Add(new Cat(name, age, breed, reader["CatColor"].ToString()));
                }
                reader.Close();
            }
            return pets;
        }

        public void AddPet(Pet pet)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection("conn.txt"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (pet is Dog dog)
                {
                    cmd.CommandText = "INSERT INTO Pets (Name, Age, Breed, Type, DogBreed) VALUES (@Name, @Age, @Breed, 'Dog', @DogBreed)";
                    cmd.Parameters.AddWithValue("@Name", dog.Name);
                    cmd.Parameters.AddWithValue("@Age", dog.Age);
                    cmd.Parameters.AddWithValue("@Breed", dog.Breed);
                    cmd.Parameters.AddWithValue("@DogBreed", dog.DogBreed);
                }
                else if (pet is Cat cat)
                {
                    cmd.CommandText = "INSERT INTO Pets (Name, Age, Breed, Type, CatColor) VALUES (@Name, @Age, @Breed, 'Cat', @CatColor)";
                    cmd.Parameters.AddWithValue("@Name", cat.Name);
                    cmd.Parameters.AddWithValue("@Age", cat.Age);
                    cmd.Parameters.AddWithValue("@Breed", cat.Breed);
                    cmd.Parameters.AddWithValue("@CatColor", cat.CatColor);
                }

                cmd.ExecuteNonQuery();
            }
        }
    }
}