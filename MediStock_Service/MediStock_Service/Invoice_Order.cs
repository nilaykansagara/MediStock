using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MediStock_Service
{
    [DataContract]
    public class Invoice_Order
    {
        private int? _item_id;
        private int? _id;
        private int? _bill_no;
        private int? _no_of_packet;
        private string _item_name;
        private string _item_com_name;

        [DataMember]
        public int? id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember]
        public int? item_id
        {
            get { return _item_id; }
            set { _item_id = value; }
        }

        [DataMember]
        public int? bill_no
        {
            get { return _bill_no; }
            set { _bill_no = value; }
        }

        [DataMember]
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; }
        }

        [DataMember]
        public int? no_of_packet
        {
            get { return _no_of_packet; }
            set { _no_of_packet = value; }
        }

        [DataMember]
        public string item_com_name
        {
            get { return _item_com_name; }
            set { _item_com_name = value; }
        }
    }
}
