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
    /// class for changing information 
    /// </summary>
    public class FormAbsenceChangeDataRepository
    {
        private readonly AppDbContext _context;

        public FormAbsenceChangeDataRepository(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// returns 0 if failed to create data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> CreateDataAsync(FormAbsence model)
        {
            _context.Connection();
            int countChangeData = 0;
            if (model == null)
                return countChangeData;
         
            var sqlExpression =
                "INSERT INTO FormAbsence (reason, start_date, duration, discounted, description)" +
                $" VALUES ({((int)model.Reason)}, '{model.StartDate.Date}', {model.Duration}, '{model.Discounted}', '{model.Description}')";
            using (SqlConnection connection = new SqlConnection(_context.ConnectString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                countChangeData = await command.ExecuteNonQueryAsync();
            }
            return countChangeData;
        }
        /// <summary>
        /// returns 0 if data update failed
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> UpdateDataAsync(FormAbsence model)
        {
            _context.Connection();
            int countChangeData = 0;
            
            if (model == null)
                return countChangeData;

            var sqlExpression =
                $"UPDATE FormAbsence SET reason = {((Causes)model.Reason)}, start_date = '{model.StartDate.Date}', " +
                $"duration = {model.Duration}, discounted = '{model.Discounted}', description = '{model.Description}'" +
                $"WHERE id = {model.Id}"; 
            using (SqlConnection connection = new SqlConnection(_context.ConnectString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                countChangeData = await command.ExecuteNonQueryAsync();
            }
            return countChangeData;
        }
        /// <summary>
        /// returns 0 if it was not possible to delete data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<int> DeleteDataAsync(FormAbsence model)
        {
            _context.Connection();
            int countChangeData = 0;
            if (model == null)
                return countChangeData;
            
            var sqlExpression = $"DELETE FROM FormAbsence WHERE id = {model.Id}";
            using (SqlConnection connection = new SqlConnection(_context.ConnectString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                countChangeData = await command.ExecuteNonQueryAsync();
            }
            return countChangeData;
        }
    }
}
