using System.Linq;
using LeisureTimeSystem.Models.EntityModels;

namespace LeisureTimeSystem.Data.Mocks.DBSets
{
    public class FakeCoursesDbSet : FakeDbSet<Course>
    {
        public override Course Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(course => course.Id == wantedId);
        }
    }
}
