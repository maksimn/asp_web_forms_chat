using System.Web;
using System.Web.UI.WebControls;

namespace WebFormsChat.Frontend.Pages.Themes {
    public class HeaderTheme {
        public static string InjectStylesheet() {
            var session = HttpContext.Current.Session;
            if (session["HeaderColor"] as string == "Синий") {
                return "<link rel =\"stylesheet\" href =\"/Pages/css/headerBlueTheme.css\">";
            }
            return "";
        }

        public static void InitThemeControl(ListControl listControl) {
            var session = HttpContext.Current.Session;
            if (session["HeaderColor"] != null) {
                listControl.SelectedValue = session["HeaderColor"] as string;
            }
        }

        public static void SetThemeFromControl(ListControl listControl) {
            HttpContext.Current.Session["HeaderColor"] = listControl.SelectedValue;
        }
    }
}