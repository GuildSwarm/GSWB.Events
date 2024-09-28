using Events.Domain.Contracts.Repositories;
using Events.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Validation.Tag
{
    public class TagIdListValidator : AbstractValidator<IEnumerable<Guid>>
    {
        private readonly ITagRepository _tagRepository;
        public TagIdListValidator(ITagRepository aTagRepository) 
        { 
            _tagRepository = aTagRepository;
            RuleFor(tagIdList => tagIdList).MustAsync(IsGetByIdListSuccess);
        }
        private async Task<bool> IsGetByIdListSuccess(IEnumerable<Guid> aTagIdList, CancellationToken aCancellationToken = default)
        => (await _tagRepository.GetByIdListAsync(aTagIdList, aCancellationToken)).IsSuccess;

    }
}
