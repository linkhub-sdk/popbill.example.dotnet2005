Imports Popbill
Imports Popbill.Statement
Imports System.ComponentModel

Public Class frmExample

    '링크아이디 
    Private LinkID As String = "TESTER"

    '비밀키, 유출에 주의
    Private SecretKey As String = "kf1YBAzWFzu2SAJH/nkSCbAm8SuPmZuvYmDnRY23EK8="

    Private statementService As StatementService

    Private Sub frmExample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        statementService = New StatementService(LinkID, SecretKey)

        '연동환경 설정값
        '상업용 전환시 False로 수정
        statementService.IsTest = True

    End Sub

    Private Function selectedItemCode() As Integer
        selectedItemCode = 121

        If cboItemCode.Text = "거래명세서" Then selectedItemCode = 121
        If cboItemCode.Text = "청구서" Then selectedItemCode = 122
        If cboItemCode.Text = "견적서" Then selectedItemCode = 123
        If cboItemCode.Text = "발주서" Then selectedItemCode = 124
        If cboItemCode.Text = "입금표" Then selectedItemCode = 125
        If cboItemCode.Text = "영수증" Then selectedItemCode = 126

    End Function

    '회원가입여부 확인
    Private Sub btnCheckIsMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckIsMember.Click
        Try
            Dim response As Response = statementService.CheckIsMember(txtCorpNum.Text, LinkID)

            MsgBox(response.code.ToString() + " | " + response.message)

        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '회원가입 요청
    Private Sub btnJoinMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJoinMember.Click
        Dim joinInfo As JoinForm = New JoinForm

        joinInfo.LinkID = LinkID
        joinInfo.CorpNum = "1231212312" '사업자번호 "-" 제외
        joinInfo.CEOName = "대표자성명"
        joinInfo.CorpName = "상호"
        joinInfo.Addr = "주소"
        joinInfo.ZipCode = "500-100"
        joinInfo.BizType = "업태"
        joinInfo.BizClass = "업종"
        joinInfo.ID = "userid"  '6자 이상 20자 미만
        joinInfo.PWD = "pwd_must_be_long_enough" '6자 이상 20자 미만
        joinInfo.ContactName = "담당자명"
        joinInfo.ContactTEL = "02-999-9999"
        joinInfo.ContactHP = "010-1234-5678"
        joinInfo.ContactFAX = "02-999-9998"
        joinInfo.ContactEmail = "test@test.com"

        Try
            Dim response As Response = statementService.JoinMember(joinInfo)

            MsgBox(response.message)


        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '잔여 포인트 확인
    Private Sub btnGetBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetBalance.Click
        Try
            Dim remainPoint As Double = statementService.GetBalance(txtCorpNum.Text)


            MsgBox(remainPoint)


        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '발행단가 확인
    Private Sub btnUnitCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnitCost.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim unitCost As Single = statementService.GetUnitCost(txtCorpNum.Text, itemCode)


            MsgBox(unitCost)


        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '파트너 잔여포인트 확인
    Private Sub btnGetPartnerBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPartnerBalance.Click
        Try
            Dim remainPoint As Double = statementService.GetPartnerBalance(txtCorpNum.Text)


            MsgBox(remainPoint)


        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '팝빌 로그인 URL
    Private Sub btnGetPopbillURL_LOGIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPopbillURL_LOGIN.Click
        Try
            Dim url As String = statementService.GetPopbillURL(txtCorpNum.Text, txtUserID.Text, "LOGIN")

            MsgBox(url)

        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '팝빌 포인트충전 URL
    Private Sub btnGetPopbillURL_CHRG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPopbillURL_CHRG.Click
        Try
            Dim url As String = statementService.GetPopbillURL(txtCorpNum.Text, txtUserID.Text, "CHRG")

            MsgBox(url)

        Catch ex As PopbillException
            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '문서관리번호 사용여부 
    Private Sub btnCheckMgtKeyInUse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckMgtKeyInUse.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim InUse As Boolean = statementService.CheckMgtKeyInuse(txtCorpNum.Text, itemCode, txtMgtKey.Text)

            MsgBox(IIf(InUse, "사용중", "미사용중"))

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try

    End Sub

    '임시저장
    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Dim Statement As New Statement

        Statement.writeDate = "20150312"             '필수, 기재상 작성일자
        Statement.purposeType = "영수"               '필수, {영수, 청구}
        Statement.taxType = "과세"                   '필수, {과세, 영세, 면세}
        Statement.formCode = txtFormCode.Text       '맞춤양식코드, 공백입력시 기본양식

        Statement.itemCode = selectedItemCode()     '문서코드

        Statement.mgtKey = txtMgtKey.Text       '문서관리번호

        Statement.senderCorpNum = txtCorpNum.Text
        Statement.senderTaxRegID = "" '종사업자 식별번호. 필요시 기재. 형식은 숫자 4자리.
        Statement.senderCorpName = "공급자 상호"
        Statement.senderCEOName = "공급자"" 대표자 성명"
        Statement.senderAddr = "공급자 주소"
        Statement.senderBizClass = "공급자 업종"
        Statement.senderBizType = "공급자 업태,업태2"
        Statement.senderContactName = "공급자 담당자명"
        Statement.senderEmail = "test@test.com"
        Statement.senderTEL = "070-7070-0707"
        Statement.senderHP = "010-000-2222"

        Statement.receiverCorpNum = "8888888888"
        Statement.receiverCorpName = "공급받는자 상호"
        Statement.receiverCEOName = "공급받는자 대표자 성명"
        Statement.receiverAddr = "공급받는자 주소"
        Statement.receiverBizClass = "공급받는자 업종"
        Statement.receiverBizType = "공급받는자 업태"
        Statement.receiverContactName = "공급받는자 담당자명"
        Statement.receiverEmail = "test@receiver.com"

        Statement.supplyCostTotal = "100000"         '필수 공급가액 합계
        Statement.taxTotal = "10000"                 '필수 세액 합계
        Statement.totalAmount = "110000"             '필수 합계금액.  공급가액 + 세액

        Statement.serialNum = "123"
        Statement.remark1 = "비고1"
        Statement.remark2 = "비고2"
        Statement.remark3 = "비고3"

        Statement.businessLicenseYN = False '사업자등록증 이미지 첨부시 설정.
        Statement.bankBookYN = False         '통장사본 이미지 첨부시 설정.
        Statement.faxsendYN = False          '발행시 Fax발송시 설정.
        Statement.smssendYN = False      '발행시 문자발송기능 사용시 활용


        '상세항목 추가.
        Statement.detailList = New List(Of StatementDetail)

        Dim newDetail As StatementDetail = New StatementDetail

        newDetail.serialNum = 1             '일련번호 1부터 순차 기재
        newDetail.purchaseDT = "20150310"   '거래일자  yyyyMMdd
        newDetail.itemName = "품명"
        newDetail.spec = "규격"
        newDetail.unit = "단위"
        newDetail.qty = "1" '수량           ' 소숫점 2자리까지 문자열로 기재가능
        newDetail.unitCost = "100000"       ' 소숫점 2자리까지 문자열로 기재가능
        newDetail.supplyCost = "100000"
        newDetail.tax = "10000"
        newDetail.remark = "비고"
        newDetail.spare1 = "spare1"
        newDetail.spare2 = "spare2"
        newDetail.spare3 = "spare3"
        newDetail.spare4 = "spare4"
        newDetail.spare5 = "spare5"

        Statement.detailList.Add(newDetail)

        '추가속성, 자세한사항은 "전자명세서 API 연동매뉴얼 > 5.2기본양식 추가속성 테이블" 참조

        Statement.propertyBag = New Dictionary(Of String, String)

        Statement.propertyBag.Add("CBalance", "150000") '현잔액
        Statement.propertyBag.Add("Deposit", "50000")   '입금액
        Statement.propertyBag.Add("Balance", "100000")  '전잔액

        Try
            Dim response As Response = statementService.Register(txtCorpNum.Text, Statement, txtUserID.Text)

            MsgBox(response.code.ToString() + " | " + response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try


    End Sub

    '수정
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim Statement As New Statement

        Statement.writeDate = "20150312"             '필수, 기재상 작성일자
        Statement.purposeType = "영수"               '필수, {영수, 청구}
        Statement.taxType = "과세"                   '필수, {과세, 영세, 면세}
        Statement.formCode = txtFormCode.Text       '맞춤양식코드, 공백입력시 기본양식

        Statement.itemCode = selectedItemCode()     '문서코드

        Statement.mgtKey = txtMgtKey.Text       '문서관리번호

        Statement.senderCorpNum = txtCorpNum.Text
        Statement.senderTaxRegID = "" '종사업자 식별번호. 필요시 기재. 형식은 숫자 4자리.
        Statement.senderCorpName = "공급자 상호_수정"
        Statement.senderCEOName = "공급자"" 대표자 성명_수정"
        Statement.senderAddr = "공급자 주소"
        Statement.senderBizClass = "공급자 업종"
        Statement.senderBizType = "공급자 업태,업태2"
        Statement.senderContactName = "공급자 담당자명"
        Statement.senderEmail = "test@test.com"
        Statement.senderTEL = "070-7070-0707"
        Statement.senderHP = "010-000-2222"

        Statement.receiverCorpNum = "8888888888"
        Statement.receiverCorpName = "공급받는자 상호"
        Statement.receiverCEOName = "공급받는자 대표자 성명"
        Statement.receiverAddr = "공급받는자 주소"
        Statement.receiverBizClass = "공급받는자 업종"
        Statement.receiverBizType = "공급받는자 업태"
        Statement.receiverContactName = "공급받는자 담당자명"
        Statement.receiverEmail = "test@receiver.com"

        Statement.supplyCostTotal = "100000"         '필수 공급가액 합계
        Statement.taxTotal = "10000"                 '필수 세액 합계
        Statement.totalAmount = "110000"             '필수 합계금액.  공급가액 + 세액

        Statement.serialNum = "123"
        Statement.remark1 = "비고1"
        Statement.remark2 = "비고2"
        Statement.remark3 = "비고3"

        Statement.businessLicenseYN = False '사업자등록증 이미지 첨부시 설정.
        Statement.bankBookYN = False         '통장사본 이미지 첨부시 설정.
        Statement.faxsendYN = False          '발행시 Fax발송시 설정.
        Statement.smssendYN = False      '발행시 문자발송기능 사용시 활용


        '상세항목 추가.
        Statement.detailList = New List(Of StatementDetail)

        Dim newDetail As StatementDetail = New StatementDetail

        newDetail.serialNum = 1             '일련번호 1부터 순차 기재
        newDetail.purchaseDT = "20150310"   '거래일자  yyyyMMdd
        newDetail.itemName = "품명"
        newDetail.spec = "규격"
        newDetail.unit = "단위"
        newDetail.qty = "1" '수량           ' 소숫점 2자리까지 문자열로 기재가능
        newDetail.unitCost = "100000"       ' 소숫점 2자리까지 문자열로 기재가능
        newDetail.supplyCost = "100000"
        newDetail.tax = "10000"
        newDetail.remark = "비고"
        newDetail.spare1 = "spare1"
        newDetail.spare2 = "spare2"
        newDetail.spare3 = "spare3"
        newDetail.spare4 = "spare4"
        newDetail.spare5 = "spare5"

        Statement.detailList.Add(newDetail)

        '추가속성, 자세한사항은 "전자명세서 API 연동매뉴얼 > 5.2기본양식 추가속성 테이블" 참조

        Statement.propertyBag = New Dictionary(Of String, String)

        Statement.propertyBag.Add("CBalance", "150000") '현잔액
        Statement.propertyBag.Add("Deposit", "50000")   '입금액
        Statement.propertyBag.Add("Balance", "100000")  '전잔액

        Try
            Dim response As Response = statementService.Update(txtCorpNum.Text, selectedItemCode(), txtMgtKey.Text, Statement, txtUserID.Text)

            MsgBox(response.code.ToString() + " | " + response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '발행
    Private Sub btnIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIssue.Click

        Dim itemCode As Integer = selectedItemCode()
        Dim memo As String = "발행 메모"

        Try
            Dim response As Response = statementService.Issue(txtCorpNum.Text, itemCode, txtMgtKey.Text, memo, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '발행취소
    Private Sub btnCancelIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelIssue.Click

        Dim itemCode As Integer = selectedItemCode()
        Dim memo As String = "발행취소 메모"

        Try
            Dim response As Response = statementService.CancelIssue(txtCorpNum.Text, itemCode, txtMgtKey.Text, memo, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '삭제
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim response As Response = statementService.Delete(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '첨부파일 추가 
    Private Sub btnAttachFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttachFile.Click

        Dim itemCode As Integer = selectedItemCode()

        If fileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim strFileName As String = fileDialog.FileName

            Try
                Dim response As Response = statementService.AttachFile(txtCorpNum.Text, itemCode, txtMgtKey.Text, strFileName, txtUserID.Text)

                MsgBox(response.message)
            Catch ex As PopbillException
                MsgBox(ex.code.ToString() + " | " + ex.Message)
            End Try

        End If
    End Sub

    '첨부파일 목록 확인
    Private Sub btnGetFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetFiles.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim fileList As List(Of AttachedFile) = statementService.GetFiles(txtCorpNum.Text, itemCode, txtMgtKey.Text)


            Dim tmp As String = "일련번호 | 표시명 | 파일아이디 | 등록일자" + vbCrLf

            For Each file As AttachedFile In fileList
                tmp += file.serialNum.ToString() + " | " + file.displayName + " | " + file.attachedFile + " | " + file.regDT + vbCrLf

            Next
            MsgBox(tmp)


        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '첨부파일 삭제
    Private Sub btnDeleteFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteFile.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim response As Response = statementService.DeleteFile(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtFileID.Text, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try

    End Sub

    '문서 상태/요약 정보 조회
    Private Sub btnGetInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfo.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim statementInfo As StatementInfo = statementService.GetInfo(txtCorpNum.Text, itemCode, txtMgtKey.Text)

            Dim tmp As String = ""

            tmp += "itemKey : " + statementInfo.itemKey + vbCrLf
            tmp += "stateCode : " + CStr(statementInfo.stateCode) + vbCrLf
            tmp += "taxType : " + statementInfo.taxType + vbCrLf
            tmp += "purposeType : " + statementInfo.purposeType + vbCrLf

            tmp += "writeDate : " + statementInfo.writeDate + vbCrLf

            tmp += "senderCorpName : " + statementInfo.senderCorpName + vbCrLf
            tmp += "senderCorpNum : " + statementInfo.senderCorpNum + vbCrLf
            tmp += "receiverCorpName : " + statementInfo.receiverCorpName + vbCrLf
            tmp += "receiverCorpNum : " + statementInfo.receiverCorpNum + vbCrLf

            tmp += "supplyCostTotal : " + statementInfo.supplyCostTotal + vbCrLf
            tmp += "taxTotal : " + statementInfo.taxTotal + vbCrLf

            tmp += "issueDT : " + statementInfo.issueDT + vbCrLf
            tmp += "stateDT : " + statementInfo.stateDT + vbCrLf
            tmp += "openYN : " + CStr(statementInfo.openYN) + vbCrLf
            tmp += "openDT : " + statementInfo.openDT + vbCrLf


            tmp += "stateMemo : " + statementInfo.stateMemo + vbCrLf

            tmp += "regDT : " + statementInfo.regDT + vbCrLf

            MsgBox(tmp)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '다량 문서 요약/상태 정보 조회
    Private Sub btnGetInfos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetInfos.Click
        Dim itemCode As Integer = selectedItemCode()

        Dim MgtKeyList As List(Of String) = New List(Of String)

        ''최대 1000건.
        MgtKeyList.Add("20150312-01")
        MgtKeyList.Add("20150312-02")
        MgtKeyList.Add("20150312-03")

        Try
            Dim statementInfoList As List(Of StatementInfo) = statementService.GetInfos(txtCorpNum.Text, itemCode, MgtKeyList)

            Dim info As StatementInfo = New StatementInfo

            Dim tmp As String = ""

            For Each info In statementInfoList
                tmp += "itemKey : " + info.itemKey + vbCrLf
                tmp += "stateCode : " + CStr(info.stateCode) + vbCrLf
                tmp += "taxType : " + info.taxType + vbCrLf
                tmp += "purposeType : " + info.purposeType + vbCrLf

                tmp += "writeDate : " + info.writeDate + vbCrLf

                tmp += "senderCorpName : " + info.senderCorpName + vbCrLf
                tmp += "senderCorpNum : " + info.senderCorpNum + vbCrLf
                tmp += "receiverCorpName : " + info.receiverCorpName + vbCrLf
                tmp += "receiverCorpNum : " + info.receiverCorpNum + vbCrLf

                tmp += "supplyCostTotal : " + info.supplyCostTotal + vbCrLf
                tmp += "taxTotal : " + info.taxTotal + vbCrLf

                tmp += "issueDT : " + info.issueDT + vbCrLf
                tmp += "stateDT : " + info.stateDT + vbCrLf
                tmp += "openYN : " + CStr(info.openYN) + vbCrLf
                tmp += "openDT : " + info.openDT + vbCrLf


                tmp += "stateMemo : " + info.stateMemo + vbCrLf

                tmp += "regDT : " + info.regDT + vbCrLf + vbCrLf
            Next

            MsgBox(tmp)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '문서 상세정보 조회
    Private Sub btnGetDetailInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDetailInfo.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim statement As Statement = statementService.GetDetailInfo(txtCorpNum.Text, itemCode, txtMgtKey.Text)

            '자세한 문세정보는 작성시 항목을 참조하거나, 연동메뉴얼 참조.

            Dim tmp As String = ""

            tmp += "writeDate : " + statement.writeDate + vbCrLf

            tmp += "taxType : " + statement.taxType + vbCrLf

            tmp += "senderCorpNum : " + statement.senderCorpNum + vbCrLf
            tmp += "senderTaxRegID : " + statement.senderTaxRegID + vbCrLf
            tmp += "senderCorpName : " + statement.senderCorpName + vbCrLf
            tmp += "senderCEOName : " + statement.senderCEOName + vbCrLf
            tmp += "senderAddr : " + statement.senderAddr + vbCrLf
            tmp += "senderBizClass : " + statement.senderBizClass + vbCrLf
            tmp += "senderBizType : " + statement.senderBizType + vbCrLf
            tmp += "senderContactName : " + statement.senderContactName + vbCrLf
            tmp += "senderDeptName : " + statement.senderDeptName + vbCrLf
            tmp += "senderTEL : " + statement.senderTEL + vbCrLf
            tmp += "senderHP : " + statement.senderHP + vbCrLf
            tmp += "senderEmail : " + statement.senderEmail + vbCrLf


            tmp += "receiverCorpNum : " + statement.receiverCorpNum + vbCrLf
            tmp += "receiverTaxRegID : " + statement.receiverTaxRegID + vbCrLf
            tmp += "receiverCorpName : " + statement.receiverCorpName + vbCrLf
            tmp += "receiverCEOName : " + statement.receiverCEOName + vbCrLf
            tmp += "receiverAddr : " + statement.receiverAddr + vbCrLf
            tmp += "receiverBizClass : " + statement.receiverBizClass + vbCrLf
            tmp += "receiverBizType : " + statement.receiverBizType + vbCrLf
            tmp += "receiverContactName : " + statement.receiverContactName + vbCrLf
            tmp += "receiverDeptName : " + statement.receiverDeptName + vbCrLf
            tmp += "receiverTEL : " + statement.receiverTEL + vbCrLf
            tmp += "receiverHP : " + statement.receiverHP + vbCrLf
            tmp += "receiverEmail : " + statement.receiverEmail + vbCrLf + vbCrLf

            '''  상세내역 생략 '''
            tmp += "Properties" + vbCrLf

            Dim key

            For Each key In statement.propertyBag.Keys
                tmp += vbTab + key + " : " + statement.propertyBag.Item(key) + vbCrLf
            Next

            tmp += "detailList" + vbCrLf

            Dim detail As StatementDetail

            For Each detail In statement.detailList
                tmp += vbTab + CStr(detail.serialNum) + " : " + detail.itemName + " | " + detail.supplyCost + vbCrLf
            Next

            MsgBox(tmp)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '문서 이력 
    Private Sub btnGetLogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetLogs.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim logList As List(Of StatementLog) = statementService.GetLogs(txtCorpNum.Text, itemCode, txtMgtKey.Text)


            Dim tmp As String = ""


            For Each log As StatementLog In logList
                tmp += log.docLogType.ToString + " | " + log.log + " | " + log.procType + " | " + log.procCorpName + " | " + log.procContactName + " | " + log.procMemo + " | " + log.regDT + " | " + log.ip + vbCrLf
            Next

            MsgBox(tmp)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '알림 메일 전송
    Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click

        Dim itemCode As Integer = selectedItemCode()

        '수신메일주소
        Dim receiver As String = "test@test.com"

        Try
            Dim response As Response = statementService.SendEmail(txtCorpNum.Text, itemCode, txtMgtKey.Text, receiver, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '알림문자 전송
    Private Sub btnSendSMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendSMS.Click

        Dim itemCode As Integer = selectedItemCode()

        Dim senderNum As String = "07075103710"     '발신자번호
        Dim receiverNum As String = "010111222"     '수신자번호
        Dim contents As String = "전자명세서 문자알림 내용" '메시지 내용

        Try
            Dim response As Response = statementService.SendSMS(txtCorpNum.Text, itemCode, txtMgtKey.Text, senderNum, receiverNum, contents, txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '전자명세서 팩스전송
    Private Sub btnSendFAX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendFAX.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim response As Response = statementService.SendFAX(txtCorpNum.Text, itemCode, txtMgtKey.Text, "1111-2222", "000-2222-4444", txtUserID.Text)

            MsgBox(response.message)

        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)
        End Try
    End Sub

    '문서 내용 보기 URL
    Private Sub btnGetPopUpURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPopUpURL.Click

        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim url As String = statementService.GetPopUpURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try

    End Sub

    '인쇄 팝업 URL
    Private Sub btnGetPrintURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPrintURL.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim url As String = statementService.GetPrintURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '공급받는자 인쇄 URL
    Private Sub btnGetEPrintURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetEPrintURL.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim url As String = statementService.GetEPrintURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '공급받는자 메일 링크 URL
    Private Sub btnGetMailURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMailURL.Click
        Dim itemCode As Integer = selectedItemCode()

        Try
            Dim url As String = statementService.GetMailURL(txtCorpNum.Text, itemCode, txtMgtKey.Text, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '다량 인쇄 팝업 URL
    Private Sub btnGetMassPrintURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMassPrintURL.Click
        Dim itemCode As Integer = selectedItemCode()

        Dim MgtKeyList As List(Of String) = New List(Of String)

        ''최대 1000건.
        MgtKeyList.Add("20150312-01")
        MgtKeyList.Add("20150312-02")
        MgtKeyList.Add("20150312-03")

        Try
            Dim url As String = statementService.GetMassPrintURL(txtCorpNum.Text, itemCode, MgtKeyList, txtUserID.Text)

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '임시 문서함 URL
    Private Sub btnGetURL_TBOX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetURL_TBOX.Click

        Try
            Dim url As String = statementService.GetURL(txtCorpNum.Text, txtUserID.Text, "TBOX")

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub

    '발행 문서함 URL
    Private Sub btnGetURL_SBOX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetURL_SBOX.Click

        Try
            Dim url As String = statementService.GetURL(txtCorpNum.Text, txtUserID.Text, "SBOX")

            MsgBox(url)
        Catch ex As PopbillException

            MsgBox(ex.code.ToString() + " | " + ex.Message)

        End Try
    End Sub
End Class
