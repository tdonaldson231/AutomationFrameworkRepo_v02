using AutomationFramework_v8._0.Src.Lib;
using MySql.Data.MySqlClient;
using Xunit;

public class DatabaseFixture : IAsyncLifetime
{
    public DockerComposeHelper DockerHelper { get; private set; }

    public async Task InitializeAsync()
    {
        DockerHelper = new DockerComposeHelper();
        await WaitForDatabaseAsync();
    }

    public async Task DisposeAsync()
    {
        await DockerHelper.DisposeAsync();
    }

    private async Task WaitForDatabaseAsync(int maxAttempts = 15)
    {
        int attempts = 0;
        while (attempts < maxAttempts)
        {
            try
            {
                using var connection = new MySqlConnection(Base.mySqlConnection);
                await connection.OpenAsync();
                return;
            }
            catch
            {
                attempts++;
                await Task.Delay(2500); // Wait before retrying
            }
        }

        throw new Exception("Failed to connect to the database after multiple attempts.");
    }
}
