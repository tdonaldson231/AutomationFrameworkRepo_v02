using Xunit;
using AutomationFramework_v8._0.Src.Lib;
using AventStack.ExtentReports;
using MySql.Data.MySqlClient;
using System.Data;
using MySqlX.XDevAPI.Common;
using Xunit.Abstractions;

namespace Sql
{
    [Collection("Extent Report Collection")]
    public class Sql : Base, IClassFixture<DatabaseFixture>
    {
        private readonly ITestOutputHelper _output;
        private readonly DatabaseFixture _databaseFixture;
        private readonly ExtentReportsFixture _reportFixture;
        private ExtentTest _test;
        private string ConnectionString = Base.mySqlConnection;
        private string testMsg;

        public Sql(ExtentReportsFixture reportFixture, DatabaseFixture databaseFixture, TestConfigFixture config, ITestOutputHelper output) : base(config)
        {
            _reportFixture = reportFixture;
            _databaseFixture = databaseFixture;
            _output = output;
            _output.WriteLine($"Test Environment (Sql): {testEnvironment}");
        }

        /// <name>
        ///   Test Case: SqlStoredProcedureCheckingScores
        /// </name>
        /// <summary>
        ///   Verify the stored procedure returns the scores of all the users then verifies
        ///   if any of the scores are less than the expected value.
        /// </summary>
        /// <testid>
        ///     MRN-821: <link to test case id here>
        /// </testid>
        /// <bug>
        /// </bug>
        /// <note>
        ///   Note: Throws an Assert the stored procedure does not return data or if any of
        ///   the scores are less than the expected value (silly but just for demo).
        /// </note>
        [Fact]
        [Trait("Category", "Regression")]
        [Trait("Category", "SQL")]
        public async Task SqlStoredProcedureCheckingScores()
        {
            _test = _reportFixture.Extent.CreateTest("SqlStoredProcedureCheckingScores");

            try
            {
                string storedProcedureName = "GetHighScores";
                int minScore = 70;
                using var connection = new MySqlConnection(ConnectionString);
                await connection.OpenAsync();
                Assert.True(connection.State == ConnectionState.Open);

                using var command = new MySqlCommand(storedProcedureName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@min_score", minScore);
                using var reader = await command.ExecuteReaderAsync();

                bool hasRows = false;
                while (await reader.ReadAsync())
                {
                    hasRows = true;
                    var id = reader.GetInt32("id");
                    var name = reader.GetString("name");
                    var score = reader.GetInt32("score");

                    _test.Info($"ID: {id}, Name: {name}, Score: {score}");

                    // checking if the score is greater than or equal to what is specified
                    Assert.True(score >= minScore, $"Score {score} is less than expected.");
                }

                Assert.True(hasRows, "No records were returned from the stored procedure.");
                testMsg = "Stored procedure executed and returned valid results.";
                _test.Pass(testMsg);
            }
            catch (Exception ex)
            {
                testMsg = $"Stored procedure execution failed: {ex.Message}";
                _test.Fail(testMsg);
                
                throw;
            }
            finally
            {
                _output.WriteLine(testMsg);
            }
        }

        /// <name>
        ///   Test Case: SqlQueryCheckSpecificUserScore
        /// </name>
        /// <summary>
        ///   Verify a specific user and score are detected after running a SQL query 
        ///   against a MySql DB with test data.
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
        [Trait("Category", "SQL")]
        public async Task SqlQueryCheckSpecificUserScore()
        {
            _test = _reportFixture.Extent.CreateTest("SqlQueryCheckSpecificUserScore");

            try
            {
                string query = "SELECT name, score FROM results;";
                var results = await FetchResultsAsync(query);

                // Assert that at least one result exists
                Assert.True(results.Count > 0, "No results found in 'results' table.");
                // Assert that the specified user score is greater than or equal to 75
                Assert.Contains(results, r => r.Name == "Ringo" && r.Score >= 75);

                testMsg = "SQL query executed successfully.";
                _test.Pass(testMsg);
            }
            catch (Exception ex)
            {
                testMsg = $"SQL query failed: {ex.Message}";
                _test.Fail(testMsg);
                throw;
            }
            finally
            {
                _output.WriteLine(testMsg);
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

