using Microsoft.Practices.Unity;
using System;
using WebFormsChat.ChatData.Models;
using WebFormsChat.ChatData.Repositories;

namespace WebFormsChat.Frontend.Pages {
    public partial class Profile : System.Web.UI.Page {
        public User UserData { get; set; }

        [Dependency]
        public IUserRepository UserRepository { get; set; } 

        protected void Page_Load(object sender, EventArgs e) {
            if (!User.Identity.IsAuthenticated) {
                Response.StatusCode = 401;
                Response.End();
            } else {
                UserData = UserRepository.GetUserByName(User.Identity.Name);
                if (!IsPostBack) {
                    SetHeaderColorPickerStateFromSession();
                }
            }
        }

        private void SetHeaderColorPickerStateFromSession() {
            if (Session["HeaderColor"] != null) {
                HeaderColorPicker.SelectedValue = Session["HeaderColor"] as string;
            }
        }

        protected void OnHeaderColorPickerSelectedIndexChanged(object sender, EventArgs e) {
            Session["HeaderColor"] = HeaderColorPicker.SelectedValue;
        }
    }
}