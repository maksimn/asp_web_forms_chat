using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Web.Caching;
using System.Web.Security;
using WebFormsChat.ChatData.Models;
using WebFormsChat.Frontend.Services;

namespace WebFormsChat.Frontend.Pages {
    public partial class Chat : System.Web.UI.Page {
        [Dependency]
        public IChatService ChatService { get; set; }

        public IEnumerable<ChatMessage> ChatMessages {
            get {
                var chatMessages = Cache["ChatMessages"] as IEnumerable<ChatMessage>;
                if (chatMessages == null) {
                    chatMessages = ChatService.ChatMessages;
                    var dependency = new SqlCacheDependency("WebFormsChat", "ChatMessages");
                    Cache.Insert("ChatMessages", chatMessages, dependency);
                } 
                return chatMessages;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!User.Identity.IsAuthenticated) {
                Response.StatusCode = 401;
                Response.End();
            }
        }

        protected void SignOutHandler(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
            Response.StatusCode = 401;
            Response.End();
        }
    }
}