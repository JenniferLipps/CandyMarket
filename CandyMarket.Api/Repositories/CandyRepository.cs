using System;
using System.Collections.Generic;
using CandyMarket.Api.DataModels;
using CandyMarket.Api.Dtos;
using System.Data.SqlClient;
using Dapper;

namespace CandyMarket.Api.Repositories
{
    public class CandyRepository : ICandyRepository
    {
        string _connectionString = "Server=localhost;Database=CandyMarket;Trusted_Connection=True;";

        public IEnumerable<Candy> GetAllCandy()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Open();

                var candies = db.Query<Candy>("Select * from Candy");

                return candies.AsList();
            }
        }

        public bool AddCandy(AddCandyDto newCandy)
        {
            using (var db = new SqlConnection(_connectionString))
            {
              var addCandy = @"insert into [Candy]
                                    ([Name]) 
                                    output inserted.* 
                                    values 
                                    (@name)";
                
                var parameters = new { 
                    name = newCandy.Name 
                };

               var rowsAffected = db.Execute(addCandy, parameters);
                return rowsAffected == 1;
            }
        }

        public bool EatCandy(Guid candyIdToDelete)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var eatCandy = @"Delete from [Candy]
                                where [id] = @Id";

                var parameters = new
                {
                    id = candyIdToDelete
                };

                return db.Execute(eatCandy, parameters ) == 1;
            }
        }
    }
}