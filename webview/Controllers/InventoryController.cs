using SajiloAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountBLL;
using App.DateConverter;

namespace webview.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult Sales(int? transactionId)
        {
            InventoryTransactionModel tModel = new InventoryTransactionModel();
            //List<AccountHeadModel> DrAccounts = _iAccountingService.GetAccountHeadList().Where(x => x.AccountHeadNameEnglish == CommonAccounts.CashInHand || x.AccountHeadNameEnglish == CommonAccounts.ChequeInHand || x.IsBank == true).ToList();
            List<AccountHeadModel> DrAccounts = new List<AccountHeadModel>();
            DrAccounts.Add(new AccountHeadModel { AccountHeadID = 1, AccountHeadNameEnglish = "Cash In Hand" });
            DrAccounts.Add(new AccountHeadModel { AccountHeadID = 1, AccountHeadNameEnglish = "Cheque In Hand" });
            if (transactionId != null)
            {
                tModel = new InventoryTransactionModel()
                {
                    TransactionDateNepali = "2076/04/23",
                    IsEditCase = true,
                };

                tModel.TransactionPayments = new List<InventoryPaymentModel>();
                tModel.TransactionPayments.Add(new InventoryPaymentModel
                {
                    PaymentDate = DateTime.Now,
                    AccountHeadName = "Cash in Hand",
                    ReceiptNumber = "56789098",
                    PaymentAmount = 300
                });
                tModel.TransactionPayments.Add(new InventoryPaymentModel
                {
                    PaymentDate = DateTime.Now,
                    AccountHeadName = "Cash in Hand",
                    ReceiptNumber = "56789098",
                    PaymentAmount = 300
                });


                tModel.TransactionVoucherDetailList.Add(new TransactionVoucherDetailModel
                {
                    DrCr = "Dr",
                    AccountHeadName = "Abc",
                    Amount = 200
                });

                tModel.TransactionVoucherDetailList.Add(new TransactionVoucherDetailModel
                {
                    DrCr = "Cr",
                    AccountHeadName = "Credit Account",
                    Amount = 200
                });

                //tModel = _iInventoryService.GetTransactionById(Convert.ToInt32(transactionId));
                //tModel.TransactionVoucherDetailList = tModel.TransactionVoucherDetailList.Where(x => x.DrCr == "Dr").ToList();
                //tModel.IsEditCase = true;
                //tModel.TransactionPayments = _iInventoryService.GetTransactionPayments(Convert.ToInt32(transactionId));

                if (tModel.PartyId != null)
                {
                    tModel.IsParty = true;
                }
                else
                {
                    tModel.IsParty = false;
                }
            }
            else
            {
                //DrAccounts = DrAccounts.Where(x => x.Status == true).ToList();
                tModel.TransactionDate = System.DateTime.Now;
                //tModel.TransactionDateNepali = DateConverter.GetNepaliDate(tModel.TransactionDate);'
                tModel.TransactionDateNepali = DateConverter.GetNepaliDate(tModel.TransactionDate);
                // tModel.TransactionTypeId = CommonService.GetConfigChoices(CommonConfigChoiceCategory.TransactionType).Where(x => x.SelectText == CommonConfigChoice.Sales).Select(x => x.SelectId).FirstOrDefault();
            }
            //if (transactionId == null)
            //{
            //    tModel.TransactionVoucherDetailList.Add(new TransactionVoucherDetailModel
            //    {
            //        DrCr = EnumCollection.DrCr.Dr.ToString()
            //    });
            //}


            tModel.TransactionDetails = new List<InventoryTransactionDetailModel>();
            tModel.TransactionDetails.Add(new InventoryTransactionDetailModel
            {
                InventoryTransactionDetailId = 1,
                GoodsId = 2,
                GoodsName = "Banana",
                Quantity = 5,
                GoodsRate = 50,
                IsActive = true,

                Discount = 20,
                SubTotal = 50,
                Total = 180,


            });

            tModel.TransactionDetails.Add(new InventoryTransactionDetailModel
            {
                InventoryTransactionDetailId = 1,
                GoodsId = 2,
                GoodsName = "Apple",
                Quantity = 10,
                GoodsRate = 80,
                IsActive = true,

                Discount = 30,
                SubTotal = 150,
                Total = 200,
            });




            List<GoodsModel> Goods = new List<GoodsModel>();
            Goods.Add(new GoodsModel { GoodsId = 1, GoodsName = "Copy" });
            Goods.Add(new GoodsModel { GoodsId = 1, GoodsName = "Book" });



            ViewBag.GoodsList = new SelectList(Goods, "GoodsId", "GoodsName");
            ViewBag.DrCrCollection = new SelectList(CommonService.GetDebitCredit().Where(x => x.Value == "Dr"), "Value", "Text");
            ViewBag.DebitAccounts = new SelectList(DrAccounts, "AccountHeadID", "AccountHeadNameEnglish");
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "3", Text = "BIkesh" });
            list.Add(new SelectListItem { Value = "34", Text = "kamlesh" });



            ViewBag.Parties = new SelectList(list, "Value", "Text");
            ViewBag.Types = new SelectList(Enumerable.Empty<SelectListItem>());

            return View(tModel);
        }

        public ActionResult Purchases(int? transactionId)
        {
            InventoryTransactionModel tModel = new InventoryTransactionModel();
            List<AccountHeadModel> CrAccounts = new List<AccountHeadModel>();
            CrAccounts.Add(new AccountHeadModel { AccountHeadID = 1, AccountHeadNameEnglish = "Cash In Hand" });
            CrAccounts.Add(new AccountHeadModel { AccountHeadID = 1, AccountHeadNameEnglish = "Cheque In Hand" });
            if (transactionId != null)
            {
                tModel = new InventoryTransactionModel()
                {
                    TransactionDateNepali = "2076/04/23",
                    IsEditCase = true,
                };

                tModel.TransactionPayments = new List<InventoryPaymentModel>();
                tModel.TransactionPayments.Add(new InventoryPaymentModel
                {
                    PaymentDate = DateTime.Now,
                    AccountHeadName = "Cash in Hand",
                    ReceiptNumber = "56789098",
                    PaymentAmount = 300
                });
                tModel.TransactionPayments.Add(new InventoryPaymentModel
                {
                    PaymentDate = DateTime.Now,
                    AccountHeadName = "Cash in Hand",
                    ReceiptNumber = "56789098",
                    PaymentAmount = 300
                });


                tModel.TransactionVoucherDetailList.Add(new TransactionVoucherDetailModel
                {
                    DrCr = "Dr",
                    AccountHeadName = "Abc",
                    Amount = 200
                });

                tModel.TransactionVoucherDetailList.Add(new TransactionVoucherDetailModel
                {
                    DrCr = "Cr",
                    AccountHeadName = "Credit Account",
                    Amount = 200
                });

                //tModel = _iInventoryService.GetTransactionById(Convert.ToInt32(transactionId));
                //tModel.TransactionVoucherDetailList = tModel.TransactionVoucherDetailList.Where(x => x.DrCr == "Dr").ToList();
                //tModel.IsEditCase = true;
                //tModel.TransactionPayments = _iInventoryService.GetTransactionPayments(Convert.ToInt32(transactionId));

                if (tModel.PartyId != null)
                {
                    tModel.IsParty = true;
                }
                else
                {
                    tModel.IsParty = false;
                }
            }

            else
            {
                //CrAccounts = CrAccounts.Where(x => x.Status == true).ToList();
                tModel.TransactionDate = System.DateTime.Now;
                tModel.TransactionDateNepali = DateConverter.GetNepaliDate(tModel.TransactionDate);
                //tModel.TransactionTypeId = CommonService.GetConfigChoices(CommonConfigChoiceCategory.TransactionType).Where(x => x.SelectText == CommonConfigChoice.Purchase).Select(x => x.SelectId).FirstOrDefault();
            }
            tModel.TransactionDate = DateTime.Now;
            tModel.TransactionDateNepali = DateConverter.GetNepaliDate(tModel.TransactionDate);
            tModel.TransactionDetails = new List<InventoryTransactionDetailModel>();
            tModel.TransactionDetails.Add(new InventoryTransactionDetailModel
            {
                InventoryTransactionDetailId = 1,
                GoodsId = 2,
                GoodsName = "Banana",
                Quantity = 5,
                GoodsRate = 50,
                IsActive = true,

                Discount = 20,
                SubTotal = 50,
                Total = 180,


            });

            tModel.TransactionDetails.Add(new InventoryTransactionDetailModel
            {
                InventoryTransactionDetailId = 1,
                GoodsId = 2,
                GoodsName = "Apple",
                Quantity = 10,
                GoodsRate = 80,
                IsActive = true,

                Discount = 30,
                SubTotal = 150,
                Total = 200,
            });




            List<GoodsModel> Goods = new List<GoodsModel>();
            Goods.Add(new GoodsModel { GoodsId = 1, GoodsName = "Copy" });
            Goods.Add(new GoodsModel { GoodsId = 1, GoodsName = "Book" });



            ViewBag.GoodsList = new SelectList(Goods, "GoodsId", "GoodsName");
            ViewBag.DrCrCollection = new SelectList(CommonService.GetDebitCredit().Where(x => x.Value == "Dr"), "Value", "Text");
            ViewBag.DebitAccounts = new SelectList(CrAccounts, "AccountHeadID", "AccountHeadNameEnglish");
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "3", Text = "BIkesh" });
            list.Add(new SelectListItem { Value = "34", Text = "kamlesh" });

            ViewBag.DrCrCollection = new SelectList(CommonService.GetDebitCredit().Where(x => x.Value == "Cr"), "Value", "Text");
            ViewBag.CredidAccounts = new SelectList(CrAccounts, "AccountHeadID", "AccountHeadNameEnglish");
            ViewBag.GoodsList = new SelectList(CommonService.GetGoodsList(), "SelectId", "SelectText");
            return View(tModel);
        }
    }
}