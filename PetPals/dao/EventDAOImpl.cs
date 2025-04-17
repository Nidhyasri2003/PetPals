using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PetPals.Util;

namespace PetPals.dao
{
    public class EventDAOImpl : IEventDAO
    {
        public void RegisterParticipant(int eventId, string participantName)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection("conn.txt"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Participants (EventId, ParticipantName) VALUES (@EventId, @Name)", conn);
                cmd.Parameters.AddWithValue("@EventId", eventId);
                cmd.Parameters.AddWithValue("@Name", participantName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}