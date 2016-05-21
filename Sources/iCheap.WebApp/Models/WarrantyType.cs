using System.ComponentModel;

namespace iCheap.WebApp
{
    public enum WarrantyType
    {
        [Description("Ngày")]
        Day = 1,
        [Description("Tháng")]
        Month = 2,
        [Description("Năm")]
        Year = 3
    }
}