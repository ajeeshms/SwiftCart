using System;
using System.Data;
using System.IO;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using SwiftCart.Data.Repository;
using SwiftCart.Models;
using System.Collections.Generic;
using System.Linq;
using SwiftCart;
using SwiftCart.Logging;

namespace SwiftCart {
    public partial class Invoice : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ExportCartToExcel();
        }

        private IEnumerable<CartItemModel> GetCartItems() {
            var cart = Session["Cart"] as List<CartItemModel> ?? new List<CartItemModel>();
            return cart;
        }
        private void ExportCartToExcel() {
            try {
                // Get cart items from session
                var cartItems = GetCartItems();
                if (cartItems == null || cartItems.Count() == 0) {
                    Response.Write("No items in the cart.");
                    return;
                }

                // Create Excel application
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;

                // Create a workbook and sheet
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Cart Details";

                // Column Headers
                worksheet.Cells[1, 1] = "Product Name";
                worksheet.Cells[1, 2] = "Quantity";
                worksheet.Cells[1, 3] = "Price";
                worksheet.Cells[1, 4] = "Total";

                // Set header style
                Excel.Range headerRange = worksheet.Range["A1:D1"];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

                // Fill data
                int row = 2;
                foreach (var item in cartItems) {
                    worksheet.Cells[row, 1] = item.Name;
                    worksheet.Cells[row, 2] = item.Quantity;
                    worksheet.Cells[row, 3] = item.Price;
                    worksheet.Cells[row, 4] = item.Quantity * item.Price;
                    row++;
                }

                // Autofit columns
                worksheet.Columns.AutoFit();

                // Save workbook to memory stream
                MemoryStream memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream, Excel.XlFileFormat.xlOpenXMLWorkbook); // XLSX format

                // Clean up COM objects
                workbook.Close(false);
                excelApp.Quit();
                Marshal.ReleaseComObject(worksheet);
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(excelApp);

                LoggerHelper.LogInfo("Invoice created");
                // Send file to browser
                byte[] fileBytes = memoryStream.ToArray();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=Invoice.xlsx");
                Response.BinaryWrite(fileBytes);
                Response.End();
            }
            catch (Exception ex) {
                LoggerHelper.LogError("Error while accessing database", ex);
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}