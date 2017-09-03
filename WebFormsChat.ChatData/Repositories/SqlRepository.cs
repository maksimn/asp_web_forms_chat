using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebFormsChat.ChatData.Models;

namespace WebFormsChat.ChatData.Repositories {
    public sealed class SqlRepository : IUserRepository, IMessageRepository {
        private string cnnString = "data source=MAKSIMPC;Integrated Security=True;" + 
                                   "Initial Catalog=WebFormsChat";

        public IEnumerable<ChatMessage> ChatMessages {
            get {
                using (var conn = new SqlConnection(cnnString)) {
                    using (var command = new SqlCommand("GetChatMessages", conn) {
                        CommandType = CommandType.StoredProcedure
                    }) {
                        conn.Open();
                        var reader = command.ExecuteReader();
                        var messages = new List<ChatMessage>();
                        while (reader.Read()) {
                            messages.Add(new ChatMessage() {
                                Id = (int)reader["Id"],
                                UserName = (string)reader["UserName"],
                                Text = (string)reader["Text"]
                            });
                        }
                        return messages;
                    }
                }
            }
        }

        public int UserCount {
            get {
                using (var conn = new SqlConnection(cnnString)) {
                    using (var command = new SqlCommand("NumberOfUsers", conn) {
                        CommandType = CommandType.StoredProcedure }) {
                        conn.Open();
                        var reader = command.ExecuteReader();
                        while(reader.Read()) {
                            return (int)reader["NumUsers"];
                        }
                    }
                }
                return -1;
            }
        }

        public void AddChatMessage(ChatMessage chatMessage) {
            using (var conn = new SqlConnection(cnnString)) {
                using (var command = new SqlCommand("AddChatMessage", conn) {
                    CommandType = CommandType.StoredProcedure
                }) {
                    command.Parameters.Add(new SqlParameter("@userName", chatMessage.UserName));
                    command.Parameters.Add(new SqlParameter("@text", chatMessage.Text));
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddUser(UserRegistrationInput input) {
            try {
                using (var conn = new SqlConnection(cnnString)) {
                    using (var command = new SqlCommand("AddUser", conn) {
                        CommandType = CommandType.StoredProcedure
                    }) {
                        command.Parameters.Add(new SqlParameter("@userName", input.UserName));
                        command.Parameters.Add(new SqlParameter("@passwordHash", input.Password));
                        conn.Open();

                        command.ExecuteNonQuery();
                    }
                }
            } catch (SqlException e) {
                if (e.Message.Contains("duplicate key")) {
                    throw new DuplicateNameException();
                } 
                throw e;
            }
        }

        public void Clear() {
            using (var conn = new SqlConnection(cnnString)) {
                using (var command = new SqlCommand("DeleteAllUsers", conn) {
                    CommandType = CommandType.StoredProcedure
                }) {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public User GetUserByName(string userName) {
            using (var conn = new SqlConnection(cnnString)) {
                using (var command = new SqlCommand("GetUserByName", conn) {
                    CommandType = CommandType.StoredProcedure
                }) {
                    command.Parameters.Add(new SqlParameter("@userName", userName));
                    conn.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read()) {
                        return new User() {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            PasswordHash = (string)reader["PasswordHash"]
                        };
                    }
                }
            }

            return null;
        }

        public bool LoginUser(string userName, string password) {
            var user = GetUserByName(userName);
            return user != null && user.PasswordHash == password; 
        }
    }
}
