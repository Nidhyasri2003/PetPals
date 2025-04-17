using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.entity
{
    public abstract class Donation
    {
        public string DonorName { get; set; }
        public decimal Amount { get; set; }

        public Donation(string donorName, decimal amount)
        {
            if (amount < 10)
                throw new ArgumentException("Minimum donation is $10");
            DonorName = donorName;
            Amount = amount;
        }

        public abstract void RecordDonation();
    }
}