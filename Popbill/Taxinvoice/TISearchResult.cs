using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.Taxinvoice
{
    public class TISearchResult
    {
        public int code;
        
        public int total;
        
        public int perPage;
        
        public int pageNum;
        
        public int pageCount;
        
        public String message;
        public List<TaxinvoiceInfo> list;
    }
}
