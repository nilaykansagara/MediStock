using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ServiceModel;

namespace MediStock_Service
{
    [ServiceContract]
    public interface stock_service
    {
        [OperationContract]
        DataSet GetStock();


        [OperationContract]
       List<Stock> GetStockItem(string name, string com_name = null);


        [OperationContract]
        void AddStock(Stock obj);


        [OperationContract]
        void UpdateStock(Stock obj);


        [OperationContract]
        List<Invoice> GetInvoiceofdDate(DateTime dt);


        [OperationContract]
        List<Invoice_Order> GetOrder(int bill_no);


        [OperationContract]
        Invoice SearchInvoice(string contact, int? bill_no = null);


        [OperationContract]
        Invoice MakeInvoice(Invoice obj);


        [OperationContract]
        void AddOrders(Invoice_Order obj);


        [OperationContract]
        List<Stock> GetUpcomingExpStock();


        [OperationContract]
        List<Stock> GetLessStock();


        [OperationContract]
        void DeleteStock(int id);


        [OperationContract]
        List<Stock> GetExpiredStock();
    }
}
