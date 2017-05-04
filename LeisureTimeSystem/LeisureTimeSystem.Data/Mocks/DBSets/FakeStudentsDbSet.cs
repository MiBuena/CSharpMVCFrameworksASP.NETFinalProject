using System.Linq;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Data.Mocks.DBSets
{
    public class FakeStudentsDbSet : FakeDbSet<Student>
    {
        public override Student Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(student => student.Id == wantedId);
        }

    }
}
