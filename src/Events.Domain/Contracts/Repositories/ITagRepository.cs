using Events.Domain.Entities;
using TGF.CA.Domain.Contracts.Repositories;

namespace Events.Domain.Contracts.Repositories
{
    //Tag is its own aggegrate of one entiity, event template should not reference directly this tag, fix it and create an intermiediate entioy cllaed EventTemplatetag like with EventTag
    public interface ITagRepository : IRepositoryBase<Tag, Guid>
    {
    }
}
