

namespace Events.Application.DTOs
{
    public record PaginatedMemberListDTO(int CurrentPage, int TotalPages, int PageSize, int TotalCount, MemberDTO[] MemberList);
}
