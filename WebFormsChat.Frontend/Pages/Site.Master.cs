namespace WebFormsChat.Frontend.Pages {
    public partial class Site : System.Web.UI.MasterPage {
        protected bool HasSpecialHeaderTheme() {
            return Session["HeaderColor"] as string == "Синий";
        }
    }
}