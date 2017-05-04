using System.Linq;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Data.Mocks.DBSets
{
    public class FakeUsersDbSet : FakeDbSet<ApplicationUser>
    {
        public override ApplicationUser Find(params object[] keyValues)
        {
            string wantedId = (string)keyValues[0];
            return this.Set.FirstOrDefault(x => x.Id == wantedId);
        }
    }
}
