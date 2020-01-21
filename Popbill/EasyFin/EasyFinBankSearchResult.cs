using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.EasyFin
{
    public class EasyFinBankSearchResult
    {
        public int? code;

        public int? total;

        public int? perPage;

        public int? pageNum;

        public int? pageCount;

        public String message;

        public List<EasyFinBankSearchDetail> list;
    }
}
