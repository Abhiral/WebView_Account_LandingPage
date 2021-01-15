namespace App.Enums
{

    public class AppConstants
    {
        public static string SelectString = "--Select One--";
        public static string Select { get { return AppConstants.SelectString; } }

    }

    public class CommonConfigChoiceCategory
    {
        public static string TransactionType = "abc";
        public static string UnitType = "Unit Types";
        public static string PartyType = "Party Type";
        public static string FollowUpType = "Follow Up Type";
    }

    public class CommonInventoryTransactions
    {
        public static string SalesString = "Sales";
        public static string PurchaseString = "Purchase";
        public static string SalesReturnString = "Sales Return";
        public static string PurchaseReturnString = "Purchase Return";
        public static string AdjustmentString = "Adjustment";

        public static string Purchase { get { return CommonInventoryTransactions.PurchaseString; } }
        public static string Sales { get { return CommonInventoryTransactions.SalesString; } }
        public static string PurchaseReturn { get { return CommonInventoryTransactions.PurchaseReturnString; } }
        public static string SalesReturn { get { return CommonInventoryTransactions.SalesReturnString; } }
        public static string Adjustment { get { return CommonInventoryTransactions.AdjustmentString; } }


    }

    public class CommonPartyType
    {
        public static string Employee = "Employee";
        public static string Vendor = "Vendor";
        public static string Customer = "Customer";
    }
}