using DinkToPdf;
using DinkToPdf.Contracts;
using FinalBestBrightnessStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalBestBrightnessStore.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConverter _converter;

        public ReportsController(ApplicationDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }
        public IActionResult Report()
        {
            var model = new ReportViewModel
            {
                SalesPersons = _context.SalesPersons.ToList()
            };
            return View(model);
        }/*
        public IActionResult GeneratePdf(ReportViewModel model)
        {
            return View("GeneratePdf", model);

        }*/
        [HttpPost]
        public IActionResult GenerateReport(ReportViewModel model)
        {
            DateTime startDate = DateTime.Now.AddMonths(-model.DateRange);
            DateTime endDate = DateTime.Now;

            var orders = _context.CustomerOrders
                .Where(o => o.DateOfOrder >= startDate && o.DateOfOrder <= endDate && o.SalePersonId == model.SalesPersonId)
                .Select(o => new ReportOrder
                {
                    SalePersonId = o.SalePersonId,
                    SalesPersonName = _context.SalesPersons.FirstOrDefault(s => s.salePersonId == o.SalePersonId).name + " " +
                                      _context.SalesPersons.FirstOrDefault(s => s.salePersonId == o.SalePersonId).surname,
                    NumberOfProductsSold = o.OrderItems.Sum(i => i.Quantity),
                    DateOfOrder = o.DateOfOrder,
                    TotalAmountMade = o.OrderItems.Sum(i => i.Quantity * i.Price)
                }).ToList();

            model.SalesPersons = _context.SalesPersons.ToList();
            model.Orders = orders;

            return View("Report", model);
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePdf(ReportViewModel model)
        {
            var orders = await _context.CustomerOrders
                .Where(o => o.DateOfOrder >= DateTime.Now.AddMonths(-model.DateRange) && o.DateOfOrder <= DateTime.Now && o.SalePersonId == model.SalesPersonId)
                /*.Where(o => o.SalePersonId == model.SalesPersonId && o.DateOfOrder >= model.StartDate && o.DateOfOrder <= model.EndDate)*/
                .ToListAsync();

            var htmlContent = @"
        <table>
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Product Name</th>
                    <th>Quantity</th>
                    <th>Price</th>
                    <th>Total</th>
                </tr>
            </thead>
            <tbody>";

            foreach (var order in orders)
            {
                var orderItems = await _context.OrderItems.Where(i => i.Id == order.Id).ToListAsync();

                foreach (var item in orderItems)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.prodId == item.prodId);
                    htmlContent += $@"
                <tr>
                    <td>{order.DateOfOrder:dd-MM-yyyy}</td>
                    <td>{product.productName}</td>
                    <td>{item.Quantity}</td>
                    <td>{item.Price}</td>
                    <td>{item.Quantity * item.Price}</td>
                </tr>";
                }
            }

            var totalAmountMade = orders.Sum(o => o.TotalAmountMade);
            htmlContent += $@"
        </tbody>
        </table>
        <div class='total'>
            <strong>Total Amount Made: {totalAmountMade:C}</strong>
        </div>";

            // Code to generate PDF
            // ...

             return View("GeneratePdf", model);// Or return appropriate response
        }

        /*
        public IActionResult GeneratePdf(ReportViewModel model)
        {
            var orders = _context.CustomerOrders
                .Where(o => o.DateOfOrder >= DateTime.Now.AddMonths(-model.DateRange) && o.DateOfOrder <= DateTime.Now && o.SalePersonId == model.SalesPersonId)
                .Select(o => new ReportOrder
                {
                    SalePersonId = o.SalePersonId,
                    SalesPersonName = _context.SalesPersons.FirstOrDefault(s => s.salePersonId == o.SalePersonId).name + " " +
                                      _context.SalesPersons.FirstOrDefault(s => s.salePersonId == o.SalePersonId).surname,
                    NumberOfProductsSold = o.OrderItems.Sum(i => i.Quantity),
                    DateOfOrder = o.DateOfOrder,
                    TotalAmountMade = o.OrderItems.Sum(i => i.Quantity * i.Price)
                }).ToList();

            var salesPerson = _context.SalesPersons.FirstOrDefault(s => s.salePersonId == model.SalesPersonId);

            string htmlContent = GeneratePdfHtml(salesPerson, orders, model.DateRange);
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" },
                    },
                },
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf", "SalesReport.pdf");
        }*/

        private string GeneratePdfHtml(SalesPerson salesPerson, List<ReportOrder> orders, int dateRange)
        {
            DateTime startDate = DateTime.Now.AddMonths(-dateRange);
            DateTime endDate = DateTime.Now;

            string htmlContent = $@"
                <html>
                <head>
                    <style>
                        body {{ font-family: Arial, sans-serif; }}
                        .header {{ display: flex; justify-content: space-between; }}
                        .header h2 {{ margin: 0; }}
                        .header .store-info {{ text-align: right; }}
                        .store-info img {{ height: 50px; }}
                        table {{ width: 100%; border-collapse: collapse; margin-top: 20px; }}
                        table, th, td {{ border: 1px solid black; }}
                        th, td {{ padding: 8px; text-align: left; }}
                        .total {{ text-align: right; margin-top: 20px; }}
                    </style>
                </head>
                <body>
                    <div class='header'>
                        <div>
                            <h2>Salesperson Statement</h2>
                            <p>{salesPerson.name} {salesPerson.surname}</p>
                            <p>{salesPerson.email}</p>
                        </div>
                        <div class='store-info'>
                            <h2>Best Brightness Store</h2>
                            <img src='~/lib/bootstrap/imgs/WhatsApp Image 2024-07-02 at 06.18.28_075aad19.jpg' alt='Store Logo'>
                            <p>From: {startDate:dd-MM-yyyy}</p>
                            <p>To: {endDate:dd-MM-yyyy}</p>
                            <p>Print Date: {DateTime.Now:dd-MM-yyyy}</p>
                        </div>
                    </div>
                    <table>
                        <thead>
                            <tr>
                                <th>Posting Date</th>
                                <th>Product Name</th>
                                <th>Quantity</th>
                                <th>Price</th>
                                <th>Total Price</th>
                            </tr>
                        </thead>
                        <tbody>";

            foreach (var order in orders)
            {
                foreach (var item in _context.OrderItems.Where(i => i.Id == order.SalePersonId))
                {
                    var product = _context.Products.FirstOrDefault(p => p.prodId == item.prodId);
                    htmlContent += $@"
                        <tr>
                            <td>{order.DateOfOrder:dd-MM-yyyy}</td>
                            <td>{product.productName}</td>
                            <td>{item.Quantity}</td>
                            <td>{item.Price}</td>
                            <td>{item.Quantity * item.Price}</td>
                        </tr>";
                }
            }

            decimal totalAmountMade = orders.Sum(o => o.TotalAmountMade);
            htmlContent += $@"
                        </tbody>
                    </table>
                    <div class='total'>
                        <p><strong>Total Amount Made: {totalAmountMade:C}</strong></p>
                    </div>
                </body>
                </html>";

            return htmlContent;
        }
      

    }
}
