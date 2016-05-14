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
    }
}
