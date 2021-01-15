


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace AccountBLL
{
    public class RoleControllerActionModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<RoleControllerActionModel> AuthLists { get; set; }

    }
    public class NepaliMonthModel
    {
        public int Month { get; set; }
        public string MonthName { get; set; }
    }



    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }

        public Nullable<int> OrganizationId { get; set; }
    }
    public class SelectModel
    {
        public int SelectId { get; set; }
        public string SelectText { get; set; }
    }
    public class CommonService
    {
        public static List<SelectModel> GetPartiesByType()
        {
            //var currentOrganizationId = GetUserOrganizationId(WebSecurity.CurrentUserId);
            
           

            var list = new List<SelectModel>();
            list.Add(new SelectModel { SelectId = 2, SelectText = "BIkesh" });
            list.Add(new SelectModel { SelectId = 3, SelectText = "Kamlesh" });

            return list;

        }


        public static List<SelectModel> GetConfigChoices(string category)
        {

            var list = new List<SelectModel>();
            list.Add(new SelectModel { SelectId = 2, SelectText = "Choice A" });
            list.Add(new SelectModel { SelectId = 3, SelectText = "Choice B" });

            return list;

            
        }

        public static System.Collections.IEnumerable GetGoodsList()
        {
            var list = new List<SelectModel>();
            list.Add(new SelectModel { SelectId = 2, SelectText = "Apple" });
            list.Add(new SelectModel { SelectId = 3, SelectText = "Mango" });
            list.Add(new SelectModel { SelectId = 3, SelectText = "Wine" });

            return list;

        }

        public static string GetCurrencyFormat(decimal amount)
        {
            CultureInfo hindi = new CultureInfo("hi-IN");
            return string.Format(hindi, "{0:#,0.00}", amount);
        }

        public static List<SelectListItem> GetDebitCredit()
        {
            List<SelectListItem> drcr = new List<SelectListItem>();
            drcr.Add(new SelectListItem { Text = "Dr", Value = "Dr" });
            drcr.Add(new SelectListItem { Text = "Cr", Value = "Cr" });
            return drcr;
        }

    }

}
