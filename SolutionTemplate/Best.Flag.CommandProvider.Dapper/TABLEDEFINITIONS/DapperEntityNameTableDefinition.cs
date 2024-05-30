using Best.Practices.Core.CommandProvider.Dapper.CommandProviders;
using System.Data;

namespace $safeprojectname$.TableDefinitions
{
    public class DapperApplicationTableDefinition
    {
        public static readonly DapperTableDefinition TableDefinition = new DapperTableDefinition
        {
            TableName = "Application",
            ColumnDefinitions = new List<DapperTableColumnDefinition>()
            {
                new DapperTableColumnDefinition
                {
                    DbFieldName = "Id",
                    EntityFieldName = "Id", //nameof(Entity.Id),
                    Type = DbType.Guid
                }
            }
        };
    }
}