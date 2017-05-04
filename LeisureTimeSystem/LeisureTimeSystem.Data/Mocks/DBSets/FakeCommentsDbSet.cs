using System.Linq;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Data.Mocks.DBSets
{
    public class FakeCommentsDbSet : FakeDbSet<Comment>
    {
        public override Comment Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(discipline => discipline.Id == wantedId);
        }
    }
}
