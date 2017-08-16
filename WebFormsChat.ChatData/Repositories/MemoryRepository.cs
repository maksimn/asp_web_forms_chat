﻿using System;
using System.Collections.Generic;
using WebFormsChat.ChatData.Models;

namespace WebFormsChat.ChatData.Repositories {
    public sealed class MemoryRepository : IChatRepository {
        private static List<User> _users = new List<User>();

        public int UserCount {
            get { return _users.Count; }
        }

        public void AddUser(string userName, string password) {
            int newId = _users.Count;
            var newUser = new User() { Id = newId, Name = userName, PasswordHash = password };

            _users.Add(newUser);
        }

        public void Clear() {
            _users.Clear();
        }

        public User GetUserByName(string userName) {
            return _users.Find(u => u.Name == userName);
        }
    }
}
