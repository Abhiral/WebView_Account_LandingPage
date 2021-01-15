using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace SajiloAccount.Models
{
    //public class UsersContext : DbContext
    //{
    //    public UsersContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public DbSet<UserProfile> UserProfiles { get; set; }
    //}

    [Table("UserProfile")]
    public class UserProfile
    {
        public UserProfile()
        {
            CanLogin = true;
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [DisplayName("User Name")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "E-Mail (User Name)")]
        public string UserName { get; set; }

        [DisplayName("Can Login")]
        public bool CanLogin { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Required]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        [Required]
        public int RoleId { get; set; }

        public string Organization { get; set; }

        [Required]
        [DisplayName("Organization")]
        public int OrganizationId { get; set; }


        public List<UserProfile> UserList { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        public int UserId { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
    public class ForgotPasswordModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        public string Email { get; set; }
    }

    public class InventoryTransactionModel
    {
        public InventoryTransactionModel()
        {
            Transactions = new List<InventoryTransactionModel>();
            TransactionDetails = new List<InventoryTransactionDetailModel>();
            //TransactionPayment = new InventoryPaymentModel();
            TransactionPayments = new List<InventoryPaymentModel>();
            TransactionVoucherDetailList = new List<TransactionVoucherDetailModel>();

            IsActive = true;
            IsParty = true;
            IsEditCase = false;
        }
        public int InventoryTransactionID { get; set; }
        [DisplayName("Transaction Type")]
        public int TransactionTypeId { get; set; }
        [DisplayName("Transaction Type")]
        public string TransactionType { get; set; }
        [Required(ErrorMessage = "Please enter Transaction Date")]
        [DisplayName("Transaction Date")]
        public System.DateTime TransactionDate { get; set; }
        [Required(ErrorMessage = "Please enter Transaction Date")]
        [DisplayName("Transaction Date")]
        public string TransactionDateNepali { get; set; }
        public int OrganizationId { get; set; }
        public int VoucherId { get; set; }
        public string PartyType { get; set; }
        [DisplayName("Bill Number")]
        public string BillNumber { get; set; }
        [DisplayName("Payment Type")]
        public int PaymentTypeId { get; set; }
        public int PaymentType { get; set; }
        [DisplayName("Party Name")]
        [Required(ErrorMessage = "Please select one Party")]
        public Nullable<int> PartyId { get; set; }
        [DisplayName("Party Name")]
        [Required(ErrorMessage = "Party Name is Required !!")]
        public string PartyName { get; set; }
        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }
        public string Remarks { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public decimal? Amount { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        [DisplayName("Item/Service")]
        public int? GoodsId { get; set; }
        public decimal? Quantity { get; set; }
        [DisplayName("Grand Total")]
        public decimal GrandTotal { get; set; }
        [DisplayName("VAT Amount")]
        public decimal VATAmount { get; set; }
        [DisplayName("Grand Total")]
        public decimal GrandTotalWithVAT { get; set; }
        [DisplayName("Adjustment Type")]
        public int AdjustmentType { get; set; }
        public string BilledBy { get; set; }
        [DisplayName("Is Party")]
        public bool IsParty { get; set; }
        [DisplayName("Is VAT Bill")]
        public bool IsVatBill { get; set; }
        public bool IsEditCase { get; set; }
        [DisplayName("Make Payment")]
        public bool MakePayment { get; set; }
        public int ReturnParentId { get; set; }
        public string PurchaserAddress { get; set; }
        public string PurchaserPanNumber { get; set; }
        public string VoucherNumber { get; set; }
        public string InvoiceType { get; set; }
        public int Printed_Time { get; set; }
        public Nullable<decimal> DiscountForAll { get; set; }
        public List<InventoryTransactionModel> Transactions { get; set; }
       public List<InventoryTransactionDetailModel> TransactionDetails { get; set; }
        // public List<InventoryPaymentModel> TransactionPaymentList { get; set; }
        public List<TransactionVoucherDetailModel> TransactionVoucherDetailList { get; set; }
        public List<InventoryPaymentModel> TransactionPayments { get; set; }
        //public PartyOrganizationModel PartyOrganization { get; set; }
        //public OrganizationModel Organization { get; set; }
    }

    public class TransactionVoucherDetailModel
    {
        public int VoucherDetailID { get; set; }
        public int VoucherID { get; set; }
        public string DrCr { get; set; }
        public int AccountHeadId { get; set; }
        public string AccountHeadName { get; set; }
        //[DisplayFormat(DataFormatString = "{0:#,#.00}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
        public string Narration { get; set; }
        public Nullable<int> RefAccountHeadId { get; set; }
    }

    public class AccountHeadModel
    {
        public AccountHeadModel()
        {
            Status = true;
            IsBank = false;
        }
        public int AccountHeadID { get; set; }
        public string AccountSubType { get; set; }
        [Required]
        [DisplayName("Account Sub Type")]
        public int? AccountSubTypeID { get; set; }
        [DisplayName("Account Type")]
        public string AccountType { get; set; }
        [DisplayName("Account Type")]
        public int? AccountTypeID { get; set; }
        public int OrganizationId { get; set; }
        [DisplayName("Account Group")]
        public int? AccountHeadGroupID { get; set; }
        [DisplayName("Account Group")]
        public string AccountGroup { get; set; }
        [DisplayName("Head Code")]
        public string AccountHeadCode { get; set; }
        [DisplayName("Account Head English")]
        public string AccountHeadNameEnglish { get; set; }
        [DisplayName("Account Head Nepali")]
        public string AccountHeadNameNepali { get; set; }
        [DisplayName("Expense Type")]
        public Nullable<int> ExpenseTypeID { get; set; }
        [DisplayName("Ref. Code")]
        public string ReferenceCode { get; set; }
        [DisplayName("Arth Budget")]
        public Nullable<bool> IsArthBudget { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Created By")]
        public int CreatedBy { get; set; }
        [DisplayName("Created Date")]
        public System.DateTime CreatedDate { get; set; }
        [DisplayName("Modified By")]
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Modified Date")]
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [DisplayName("Is Bank")]
        public Nullable<bool> IsBank { get; set; }
        [DisplayName("Is Employee")]
        public Nullable<bool> IsEmployee { get; set; }
        [DisplayName("Is Student")]
        public Nullable<bool> IsStudent { get; set; }
        [DisplayName("Is Inventory Party")]
        public Nullable<bool> IsInventoryParty { get; set; }
        [DisplayName("Category")]
        public Nullable<int> CategoryID { get; set; }
        [DisplayName("Display Order")]
        public Nullable<int> DisplayOrder { get; set; }
        public bool Status { get; set; }
        [DisplayName("Parent")]
        public Nullable<int> ParentId { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public List<AccountHeadModel> AccountHeadList { get; set; }
    }

    public class GoodsModel
    {
        public GoodsModel()
        {
            Goods = new List<GoodsModel>();
            IsActive = true;
        }
        [DisplayName("Goods Name")]
        public int GoodsId { get; set; }
        public decimal Stock { get; set; }
        [DisplayName("Organization")]
        public int OrganizationId { get; set; }
        [DisplayName("Goods Name")]
        public string GoodsName { get; set; }
        public int UnitTypeId { get; set; }
        [DisplayName("Unit Type")]
        public string UnitType { get; set; }
        [DisplayName("Default Rate")]
        public Nullable<decimal> DefaultRate { get; set; }
        public string Manufacturer { get; set; }
        public string Remarks { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public int counter { get; set; }
        public DateTime ToDate { get; set; }
        [DisplayName("To Date")]
        public string ToDateNepali { get; set; }
        public decimal RemainingStockAmount { get; set; }
        public List<GoodsModel> Goods { get; set; }
    }

    public class InventoryPaymentModel
    {
        public int PaymentId { get; set; }
        public int InventoryTransactionId { get; set; }
        public int AccountHeadId { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal PaymentAmount { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public string AccountHeadName { get; set; }
        public string TransactionType { get; set; }
    }

    public class InventoryTransactionDetailModel
    {
        public int InventoryTransactionDetailId { get; set; }
        public int InventoryTransactionId { get; set; }
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public decimal GoodsRate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Stock { get; set; }
        public bool IsActive { get; set; }
        public int counter { get; set; }
        public decimal Total { get; set; }

        public decimal SubTotal { get; set; }

        public Nullable<decimal> DiscountPercentage { get; set; }

        public Nullable<decimal> Discount { get; set; }
        public string TransactionType { get; set; }

        public int ReturnParentId { get; set; }

    }
}
