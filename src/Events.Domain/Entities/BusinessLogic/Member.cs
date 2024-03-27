
namespace Events.Domain.Entities
{
    //Simple logic goes into another file of the partial entity class, both the partial file with properties and the one with the logic must be in the same namespace
    public partial class Member
    {
        public bool IsNotTypeOne()
        {
            return Type != ValueObjects.MemberType.TypeOne;
        }
    }
}
