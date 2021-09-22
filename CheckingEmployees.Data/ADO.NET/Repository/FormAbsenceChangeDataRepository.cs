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
        /// returns null if failed to create data
        /// returns new model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<FormAbsence> CreateDataAsync(FormAbsence model)
        {
            _context.Connection();
            int countChangeData = 0;
            if (model == null)
                return null;
            var sqlExpression =
                "INSERT INTO FormAbsence (reason, start_date, duration, discounted, description)" +
                $" VALUES ({((int)model.Reason)}, '{model.StartDate.Date}', {model.Duration}, '{model.Discounted}', '{model.Description}')";
            
            using (SqlConnection connection = new SqlConnection(_context.ConnectString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                countChangeData = await command.ExecuteNonQueryAsync();

                command.CommandText = "SELECT MAX(id) FROM FormAbsence";
                object resultId = await command.ExecuteScalarAsync();
                model.Id = Convert.ToInt32(resultId);
            }
            return model;
        }
        /// <summary>
        /// returns null if data update failed
        /// return FormAbsence
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<FormAbsence> UpdateDataAsync(FormAbsence model)
        {
            _context.Connection();
            int countChangeData = 0;
            
            if (model == null)
                return null;

            var sqlExpression =
                $"UPDATE FormAbsence SET reason = {((int)model.Reason)}, start_date = '{model.StartDate.Date}', " +
                $"duration = {model.Duration}, discounted = '{model.Discounted}', description = '{model.Description}'" +
                $"WHERE id = {model.Id}"; 
            using (SqlConnection connection = new SqlConnection(_context.ConnectString))
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                countChangeData = await command.ExecuteNonQueryAsync();
            }
            return model;
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
