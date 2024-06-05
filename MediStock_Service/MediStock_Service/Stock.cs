using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MediStock_Service
{
    [DataContract]
    public class Stock
    {
        private int? _item_id;
        private string _item_name;
        private int? _item_price;
        private DateTime? _item_exp;
        private int? _item_available;
        private int? _storage_row;
        private int? _storage_col;
        private string _item_comp;
        private int? _med_per_packate;

        [DataMember]
        public int? item_id
        { 
            get { return _item_id; }
            set { _item_id = value; } 
        }

        [DataMember]
        public string item_name
        {
            get { return _item_name; }
            set { _item_name = value; }
        }

        [DataMember]
        public int? item_price
        {
            get { return _item_price; }
            set { _item_price = value; }
        }

        [DataMember]
        public DateTime? item_exp
        {
            get { return _item_exp; }
            set { _item_exp = value; }
        }

        [DataMember]
        public int? item_available
        {
            get { return _item_available; }
            set { _item_available = value; }
        }

        [DataMember]
        public int? storage_row
        {
            get { return _storage_row; }
            set { _storage_row = value; }
        }

        [DataMember]
        public int? storage_col
        {
            get { return _storage_col; }
            set { _storage_col = value; }
        }

        [DataMember]
        public string item_comp
        {
            get { return _item_comp; }
            set { _item_comp = value; }
        }

        [DataMember]
        public int? med_per_packate
        {
            get { return _med_per_packate; }
            set { _med_per_packate = value; }
        }


    }
}
