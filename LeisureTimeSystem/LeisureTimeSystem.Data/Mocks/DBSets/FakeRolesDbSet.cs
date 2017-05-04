using System.Linq;
using LeisureTimeSystem.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeisureTimeSystem.Data.Mocks.DBSets
{
    public class FakeRolesDbSet : FakeDbSet<IdentityRole>
    {
        public override IdentityRole Find(params object[] keyValues)
        {
            string wantedId = (string)keyValues[0];
            return this.Set.FirstOrDefault(x => x.Id == wantedId);
        }
    }
}
