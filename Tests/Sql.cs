using Xunit;
using AutomationFramework_v8._0.Src.Lib;
using AventStack.ExtentReports;
using MySql.Data.MySqlClient;
using System.Data;
using MySqlX.XDevAPI.Common;

namespace Sql
{
    [Collection("Extent Report Collection")]
    public class Sql : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;
        private readonly ExtentReportsFixture _reportFixture;
        private ExtentTest _test;
        private string ConnectionString = Base.mySqlConnection;

        public Sql(ExtentReportsFixture reportFixture, DatabaseFixture databaseFixture)
        {
            _reportFixture = reportFixture;
            _databaseFixture = databaseFixture;
        }

        //[Fact]
        public async Task TestDatabaseConnection()
        {
            _test = _reportFixture.Extent.CreateTest("TestDatabaseConnection");
            try
            {
                using var connection = new MySqlConnection(ConnectionString);
                await connection.OpenAsync();
                Assert.True(connection.State == ConnectionState.Open);

                _test.Pass("Database connection established successfully.");
            }
            catch (Exception ex)
            {
                _test.Fail($"Database connection failed: {ex.Message}");
                throw;
            }
        }

        /// <name>
        ///   Test Case: SqlQuerySpecificUserScore
        /// </name>
        /// <summary>
        ///   Verify a specific user and score are detected after running
        ///   a SQL query against a MySql DB with test data.
        /// </summary>
        /// <testid>
        ///     MRN-777: <link to test case id here>
        /// </testid>
        /// <bug>
        /// </bug>
        /// <note>
        ///   Note: Throws an Assert if the name of the user and score are not as expected
        ///         Or if no test data is found.
        /// </note>
        [Fact]
        public async Task SqlQuerySpecificUserScore()
        {
            _test = _reportFixture.Extent.CreateTest("SqlQuerySpecificUserScore");

            try
            {
                string query = "SELECT name, score FROM results;";
                var results = await FetchResultsAsync(query);

                // Assert that at least one result exists
                Assert.True(results.Count > 0, "No results found in 'results' table.");
                                // Assert that Ringo's score is greater than or equal to 75
                Assert.Contains(results, r => r.Name == "Ringo" && r.Score >= 75);

                _test.Pass("SQL query executed successfully.");
            }
            catch (Exception ex)
            {
                _test.Fail($"SQL query failed: {ex.Message}");
                throw;
            }
        }

        private async Task<List<(string Name, int Score)>> FetchResultsAsync(string query)
        {
            var results = new List<(string Name, int Score)>();

            using var connection = new MySqlConnection(ConnectionString);
            await connection.OpenAsync();

            using var command = new MySqlCommand(query, connection);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                string name = reader.GetString("name");
                int score = reader.GetInt32("score");

                Console.WriteLine($"Name: {name}, Score: {score}");

                results.Add((name, score));
            }

            return results;
        }
    }
}

