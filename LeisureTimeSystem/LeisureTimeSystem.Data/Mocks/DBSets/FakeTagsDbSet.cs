using System.Linq;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Data.Mocks.DBSets
{
    public class FakeTagsDbSet : FakeDbSet<Tag>
    {
        public override Tag Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(discipline => discipline.Id == wantedId);
        }

    }
}
