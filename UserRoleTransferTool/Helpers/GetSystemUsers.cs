using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using Microsoft.Xrm.Sdk.Query;
using System.ComponentModel;

namespace UserRoleTransferTool.Helpers
{
    public class GetSystemUsers
    {
        public List<Entity> RetrieveUsers(IOrganizationService service, BackgroundWorker worker = null)
        {
            var users = new List<Entity>();

            if (worker != null && worker.WorkerReportsProgress)
            {
                worker.ReportProgress(0, "Retrieve systemusers");
            }

            var usersList = service.RetrieveMultiple(new QueryExpression("systemuser")
            {
                ColumnSet = new ColumnSet("systemuserid", "fullname", "internalemailaddress"),
            });

            foreach (var user in usersList.Entities)
            {
                user.Attributes.Add("type", "user");
            }

            users.AddRange(usersList.Entities);
            return users;
        }

        public List<Entity> RetrieveTeams(IOrganizationService service, BackgroundWorker worker = null)
        {
            var teams = new List<Entity>();

            if (worker != null && worker.WorkerReportsProgress)
            {
                worker.ReportProgress(0, "Retrieve teams");
            }

            var teamsList = service.RetrieveMultiple(new QueryExpression("team")
            {
                ColumnSet = new ColumnSet("teamid", "name", "emailaddress"),
            });

            foreach (var team in teamsList.Entities)
            {
                team.Attributes.Add("type", "team");
            }

            teams.AddRange(teamsList.Entities);
            return teams;
        }
    }
}
