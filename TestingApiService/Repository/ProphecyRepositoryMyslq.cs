using MySql.Data.MySqlClient;
using TestingApiService.Settings;

namespace TestingApiService.Repository
{
    public class ProphecyRepositoryMyslq
    {
        public void LogPropheciesResponse(string topic, string prophecyText)
        {
            using (var conn = new MySqlConnection(ApiSettings.MysqlConnectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection to PostgreSQL database successful!");

                    using (var cmd = new MySqlCommand(
                        @"CREATE TABLE IF NOT EXISTS log_prophecys(
                            topic varchar(50) NOT NULL,
                            prophecy_text varchar(200)
                        );", conn))
                    {
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"CREATE TABLE log_prophecys result, rows affected: {result}");
                    }

                    using (var cmd = new MySqlCommand(@"INSERT INTO log_prophecys(topic, prophecy_text)	VALUES (@topic, @prophecy_text);", conn))
                    {
                        cmd.Parameters.AddWithValue("@topic", topic);
                        cmd.Parameters.AddWithValue("@prophecy_text", prophecyText);
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"INSERT INTO log_prophecys, rows affected: {result}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"LogTestExecutionTime Error: {ex.Message}");
                }
            }
        }
    }
}
