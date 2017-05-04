using System.Linq;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Data.Mocks.DBSets
{
    public class FakeOrganizationsDbSet : FakeDbSet<Organization>
    {
        public override Organization Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(organization => organization.Id == wantedId);
        }
    }
}
