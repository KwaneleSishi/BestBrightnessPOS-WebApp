namespace FinalBestBrightnessStore.Models
{
    public class AdminDashboard
    {
        public int ProductCount { get; set; }
        public int CategoryCount { get; set; }
        public int SalesPersonCount { get; set; }
        public int StockManangerCount { get; set; }
        public decimal TotalIncome { get; set; }
        public List<Category> Categories { get; set; }
    }
}
