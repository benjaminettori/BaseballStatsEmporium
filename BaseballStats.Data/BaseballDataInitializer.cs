using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseballStats.Data
{
    public class BaseballDataInitializer : CreateDatabaseIfNotExists<BaseballStatsContext>
    {
        protected override void Seed(BaseballStatsContext context)
        {
            SeedTable(context, "BaseballStats.Data.SqlScripts.Players.sql");
            SeedTable(context, "BaseballStats.Data.SqlScripts.Pitching.sql");            
            SeedTable(context, "BaseballStats.Data.SqlScripts.PitchingPost.sql");
        }

        private void SeedTable(DbContext context, string script)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string sqlCommand;
            using(var playerStream = assembly.GetManifestResourceStream(script))
            {
                using(var reader = new StreamReader(playerStream))
                {                    
                    sqlCommand = reader.ReadToEnd();                                        
                }
            }

            using(var sqlConnection = new SqlConnection(context.Database.Connection.ConnectionString))
            {
                var commandObject = new SqlCommand(sqlCommand, sqlConnection);
                commandObject.CommandTimeout = 0;
                commandObject.Connection.Open();
                commandObject.ExecuteNonQuery();                
            }
        }        
    }
}
