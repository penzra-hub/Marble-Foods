using AspNetCoreHero.Results;

namespace MarbleFoods.Application.Services.MFServiceInterface
{
    public interface IPaginationHelper
    {
        Task<PaginatedResult<T>> ApplyPaginationAsync<T>(
            IQueryable<T> query,
            int? pageNumber,
            int? pageSize,
            CancellationToken cancellationToken = default);
    }
}
