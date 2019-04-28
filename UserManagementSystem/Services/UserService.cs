using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using UserManagementSystem.Model;

namespace UserManagementSystem.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> Users;
        private readonly IMongoCollection<UserCredentials> userCredentials;
        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("UsersDb"));
            var database = client.GetDatabase("UsersDb");
            Users = database.GetCollection<User>("Users");
            userCredentials = database.GetCollection<UserCredentials>("UserCredentials");
        }
        public bool UserAuthentication(UserCredentials userCredentialsParam)
        {

            if (userCredentialsParam !=null)
            { 
             var userCredential = userCredentials.Find(item => item.UserName == userCredentialsParam.UserName && item.Password == userCredentialsParam.Password);
            if (userCredential.CountDocuments()>0)
                return true;
        }
            return false;
        }
        //GET
        public List<User> GetUsers(UserCredentials userCredentialsParam)
        {
            if (UserAuthentication(userCredentialsParam))
            {
                if (Users != null && Users.Find(item => true) != null)
                    return Users.Find(item => true).ToList();
            }
            return null;
        }

        //GET(id)
        public User GetUserById(UserCredentials userCredentialsParam,string id)
        {
            if (UserAuthentication(userCredentialsParam))
            {
                if (Users.Find<User>(item => item.Id == id) != null)
                    return Users.Find<User>(item => item.Id == id).FirstOrDefault();
            }
            return null;
        }

        //POST
        public User AddUser(UserCredentials userCredentialsParam,User user)
        {
            if (UserAuthentication(userCredentialsParam))
            {
                Users.InsertOne(user);
                return user;
            }
            return null;
        }

        //PUT
        public void UpdateUserById(UserCredentials userCredentialsParam, string id, User user)
        {
            if (UserAuthentication(userCredentialsParam))
            {
                Users.ReplaceOne(item => item.Id == id, user);
            }
        }

        //DELETE
        public void RemoveUserById(UserCredentials userCredentialsParam,string id)
        {
            if (UserAuthentication(userCredentialsParam))
            {
                Users.DeleteOne(item => item.Id == id);
            }
        }

        //POST
        public List<User> GetSearchedUsers(UserCredentials userCredentialsParam,string name, string userName, string zipCode, string companyName)
        {
            if (UserAuthentication(userCredentialsParam))
            {
                if (Users != null && Users.Find(item => true) != null)
                {
                    List<User> users = Users.Find(item => (string.IsNullOrEmpty(name) || item.Name == name) &&
                                                          (string.IsNullOrEmpty(userName) || item.UserName == userName) &&
                                                          (string.IsNullOrEmpty(zipCode) || item.Address.Zipcode == zipCode) &&
                                                          (string.IsNullOrEmpty(companyName) || item.Company.Name == companyName)
                    ).ToList();
                    return users;
                }
            }
            return null;
        }
    }
}

