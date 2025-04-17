using System;
using PetPals.dao;
using PetPals.entity;
using PetPals.exception;

namespace PetPals
{
    class MainModule
    {
        static void Main(string[] args)
        {
            IPetDAO petDAO = new PetDAOImpl();
            IDonationDAO donationDAO = new DonationDAOImpl();
            IEventDAO eventDAO = new EventDAOImpl();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== Welcome to PetPals Adoption Platform =====");
                Console.WriteLine("1. Add a Pet");
                Console.WriteLine("2. View All Pets");
                Console.WriteLine("3. Make a Donation");
                Console.WriteLine("4. Register for an Adoption Event");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Pet Type (Dog/Cat): ");
                            string type = Console.ReadLine();

                            Console.Write("Enter Pet Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter Pet Age: ");
                            int age = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Pet Breed: ");
                            string breed = Console.ReadLine();

                            if (type.ToLower() == "dog")
                            {
                                Console.Write("Enter Dog Breed: ");
                                string dogBreed = Console.ReadLine();
                                Pet dog = new Dog(name, age, breed, dogBreed);
                                petDAO.AddPet(dog);
                                Console.WriteLine("Dog added successfully.");
                            }
                            else if (type.ToLower() == "cat")
                            {
                                Console.Write("Enter Cat Color: ");
                                string catColor = Console.ReadLine();
                                Pet cat = new Cat(name, age, breed, catColor);
                                petDAO.AddPet(cat);
                                Console.WriteLine("Cat added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid pet type.");
                            }
                            break;

                        case 2:
                            Console.WriteLine("Available Pets:");
                            var pets = petDAO.GetAllPets();
                            if (pets.Count == 0)
                            {
                                Console.WriteLine("No pets available.");
                            }
                            else
                            {
                                foreach (var pet in pets)
                                    Console.WriteLine(pet);
                            }
                            break;

                        case 3:
                            Console.Write("Enter Donor Name: ");
                            string donorName = Console.ReadLine();

                            Console.Write("Enter Donation Type (Cash/Item): ");
                            string donationType = Console.ReadLine();

                            Console.Write("Enter Amount: ");
                            decimal amount = Convert.ToDecimal(Console.ReadLine());

                            if (donationType.ToLower() == "cash")
                            {
                                DateTime date = DateTime.Now;
                                Donation cashDonation = new CashDonation(donorName, amount, date);
                                donationDAO.RecordDonation(cashDonation);
                                Console.WriteLine("Cash donation recorded.");
                            }
                            else if (donationType.ToLower() == "item")
                            {
                                Console.Write("Enter Item Type: ");
                                string item = Console.ReadLine();
                                Donation itemDonation = new ItemDonation(donorName, amount, item);
                                donationDAO.RecordDonation(itemDonation);
                                Console.WriteLine("Item donation recorded.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid donation type.");
                            }
                            break;

                        case 4:
                            Console.Write("Enter Event ID (check DB): ");
                            int eventId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Participant Name: ");
                            string participant = Console.ReadLine();

                            eventDAO.RegisterParticipant(eventId, participant);
                            Console.WriteLine("Participant registered successfully.");
                            break;

                        case 5:
                            exit = true;
                            Console.WriteLine("Thank you for using PetPals!");
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (InvalidPetAgeException ex)
                {
                    Console.WriteLine($"[Error] Invalid Age: {ex.Message}");
                }
                catch (InsufficientFundsException ex)
                {
                    Console.WriteLine($"[Error] Donation Issue: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}");
                }
            }
        }
    }
}
