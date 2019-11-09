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
            throw new NotImplementedException();
        }

        public bool EatCandy(Guid candyIdToDelete)
        {
            throw new NotImplementedException();
        }
    }
}