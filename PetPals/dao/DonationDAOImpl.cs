using PetPals.entity;
using Microsoft.Data.SqlClient;
using PetPals.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.dao
{
    public class DonationDAOImpl : IDonationDAO
    {
        public void RecordDonation(Donation donation)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection("conn.txt"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (donation is CashDonation cash)
                {
                    cmd.CommandText = "INSERT INTO Donations (DonorName, Amount, DonationType, DonationDate) VALUES (@DonorName, @Amount, 'Cash', @DonationDate)";
                    cmd.Parameters.AddWithValue("@DonorName", cash.DonorName);
                    cmd.Parameters.AddWithValue("@Amount", cash.Amount);
                    cmd.Parameters.AddWithValue("@DonationDate", cash.DonationDate);
                }
                else if (donation is ItemDonation item)
                {
                    cmd.CommandText = "INSERT INTO Donations (DonorName, Amount, DonationType, ItemType) VALUES (@DonorName, @Amount, 'Item', @ItemType)";
                    cmd.Parameters.AddWithValue("@DonorName", item.DonorName);
                    cmd.Parameters.AddWithValue("@Amount", item.Amount);
                    cmd.Parameters.AddWithValue("@ItemType", item.ItemType);
                }

                cmd.ExecuteNonQuery();
            }
        }
    }
}
