using TrueStory.Products.Core.Contracts.Product;

namespace TrueStory.Products.RestfulApi.Helpers
{
    /// <summary>
    /// Helper class for filtering and paginating product details.
    /// </summary>
    public static class ProductHelper
    {
        /// <summary>
        /// Filter and paginate a list of product details.
        /// </summary>
        /// <param name="products"></param>
        /// <param name="nameFilter"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PagedResult<ProductDetails> FilterAndPaginate(
            List<ProductDetails> products,
            string? nameFilter,
            int page,
            int pageSize)
        {
            var filtered = string.IsNullOrWhiteSpace(nameFilter)
                ? products
                : products
                    .Where(p => p.Name != null && p.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            var totalCount = filtered.Count;
            var items = filtered
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<ProductDetails>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                Items = items
            };
        }
    }

}
