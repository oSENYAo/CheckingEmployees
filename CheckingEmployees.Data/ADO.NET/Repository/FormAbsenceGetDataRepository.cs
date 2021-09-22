using CheckingEmployees.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckingEmployees.Data.ADO.NET.Repository
{
    /// <summary>
    /// class for getting information 
    /// </summary>
    /// 
    public class FormAbsenceGetDataRepository
    {
        private readonly AppDbContext _context;

        public FormAbsenceGetDataRepository(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// return async List<FormAbsence>
        /// </summary>
        /// <returns></returns>
        public async Task<List<FormAbsence>> GetAllAsync()
        {
            _context.Connection();
            
            var sqlExpression = "SELECT * FROM FormAbsence";
            List<FormAbsence> formAbsence = new List<FormAbsence>();
            using (SqlConnection connection = new SqlConnection(_context.ConnectString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        formAbsence.Add(new FormAbsence
                        {
                            Id = reader.GetInt32(0),
                            Reason = (Causes)reader.GetInt32(1),
                            StartDate = reader.GetDateTime(2),
                            Duration = reader.GetInt32(3),
                            Discounted = reader.GetBoolean(4),
                            Description = reader.GetString(5)
                        });
                    }
                }
                await reader.CloseAsync();
            }

            return formAbsence;
        }
        /// <summary>
        /// returns model FormAbsence async by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FormAbsence> GetByIdAsync(int id)
        {
            _context.Connection();

            var sqlExpression = $"SELECT * FROM FormAbsence WHERE id = {id}";
            FormAbsence formAbsence = new FormAbsence();
            using (SqlConnection connection = new SqlConnection(_context.ConnectString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        formAbsence.Id = reader.GetInt32(0);
                        formAbsence.Reason = (Causes)reader.GetInt32(1);
                        formAbsence.StartDate = reader.GetDateTime(2);
                        formAbsence.Duration = reader.GetInt32(3);
                        formAbsence.Discounted = reader.GetBoolean(4);
                        formAbsence.Description = reader.GetString(5);
                    }
                }
                await reader.CloseAsync();
            }
            return formAbsence;
        }
    }
}
