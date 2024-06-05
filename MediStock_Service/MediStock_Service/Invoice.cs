using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MediStock_Service
{
    [DataContract]
    public class Invoice
    {
        private int? _bill_no;
        private DateTime? _date;
        private int? _total_amount;
        private string _doc_name;
        private string _contact;
        private string _customer_name;

        [DataMember]
        public int? bill_no
        {
            get { return _bill_no; }
            set { _bill_no = value; }
        }

        [DataMember]
        public DateTime? date
        {
            get { return _date; }
            set { _date = value; }
        }

        [DataMember]
        public string doc_name
        {
            get { return _doc_name; }
            set { _doc_name = value; }
        }

        [DataMember]
        public string contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        [DataMember]
        public int? total_amount
        {
            get { return _total_amount; }
            set { _total_amount = value; }
        }

        [DataMember]
        public string customer_name
        {
            get { return _customer_name; }
            set { _customer_name = value; }
        }
    }
}
