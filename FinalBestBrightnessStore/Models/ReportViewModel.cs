namespace FinalBestBrightnessStore.Models
{
    public class ReportViewModel
    {
        public int DateRange { get; set; }
        public int SalesPersonId { get; set; }
        public List<SalesPerson> SalesPersons { get; set; }
        public List<ReportOrder> Orders { get; set; }
    }
    public class ReportOrder
    {
        public int SalePersonId { get; set; }
        public string SalesPersonName { get; set; }
        public int NumberOfProductsSold { get; set; }
        public DateTime DateOfOrder { get; set; }
        public decimal TotalAmountMade { get; set; }
    }
}
