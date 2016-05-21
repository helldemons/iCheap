using iCheap.Models;

namespace iCheap.Repositories
{
    public class MapHelper
    {
        public static Categories MapCategory(
            Categories category,
            Categories parent)
        {
            if (category != null)
                category.Parent = parent;

            return category;
        }

        public static BlogCategories MapBlogCategory(
            BlogCategories blogCategory,
            BlogCategories parent)
        {
            if (blogCategory != null)
                blogCategory.Parent = parent;

            return blogCategory;
        }

        public static Products MapProducts(
            Products product,
            Origins origin,
            Brands brand,
            Categories category)
        {
            if (product != null)
            {
                product.Brand = brand;
                product.Origin = origin;
                product.Category = category;
            }

            return product;
        }
    }
}
