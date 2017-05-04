using System.Linq;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Data.Mocks.DBSets
{
    public class FakeAddressesDbSet : FakeDbSet<Address>
    {
        public override Address Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(x => x.Id == wantedId);
        }
    }
}
