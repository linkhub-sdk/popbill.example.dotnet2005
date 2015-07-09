using System;
using System.Collections.Generic;
using System.Text;

namespace Popbill.Closedown
{
    public class ClosedownService : BaseService
    {
        public ClosedownService(String LinkID, String SecretKey)
            : base(LinkID, SecretKey)
        {
            this.AddScope("170");
        }

        public Single GetUnitCost(String CorpNum)
        {
            UnitCostResponse response = httpget<UnitCostResponse>("/CloseDown/UnitCost", CorpNum, null);

            return Single.Parse(response.unitCost);
        }


        public CorpState checkCorpNum(String MemberCorpNum, String CheckCorpNum)
        {
            if (String.IsNullOrEmpty(CheckCorpNum)) throw new PopbillException(-99999999, "조회할 사업자번호가 입력되지 않았습니다.");
            if (String.IsNullOrEmpty(MemberCorpNum)) throw new PopbillException(-99999999, "팝빌회원 사업자번호가 입력되지 않았습니다.");

            //return httpget<CashbillInfo>("/Cashbill/" + MgtKey, CorpNum, null);
            return httpget<CorpState>("/CloseDown?CN="+CheckCorpNum, MemberCorpNum, null);
        }

        public List<CorpState> checkCorpNums(String MemberCorpNum, List<String> CorpNumList)
        {
            if (String.IsNullOrEmpty(MemberCorpNum)) throw new PopbillException(-99999999, "팝빌회원 사업자번호가 입력되지 않았습니다.");
            if (CorpNumList == null || CorpNumList.Count == 0) throw new PopbillException(-99999999, "조회할 사업자번호 목록이 입력되지 않았습니다.");

            String PostData = toJsonString(CorpNumList);

            return httppost<List<CorpState>>("/CloseDown", MemberCorpNum, null, PostData, null);
        }
    }
}
