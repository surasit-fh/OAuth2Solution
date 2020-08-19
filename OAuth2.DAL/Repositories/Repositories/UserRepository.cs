using MongoDB.Bson;
using MongoDB.Driver;
using OAuth2.DAL.Repositories.InterfaceRepositories;
using OAuth2.DAL.Services;
using OAuth2.Model.Models.Interfaces;
using OAuth2.Model.Models.MongoDBs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAuth2.DAL.Repositories.Repositories
{
    public class UserRepository : InterfaceUserRepository
    {
        public List<UserInfo> GetUserAll()
        {
            try
            {
                List<UserInfo> listUserResponse = new List<UserInfo>();
                List<UserModel> listUser = MongoDBCollections.UsersCollection.Find(new BsonDocument()).ToList();

                if (listUser.Count > 0)
                {
                    foreach (UserModel userModel in listUser)
                    {
                        listUserResponse.Add(new UserInfo()
                        {
                            UserId = userModel.UserId.ToString(),
                            FirstName = userModel.FirstName,
                            LastName = userModel.LastName,
                            Username = userModel.Username,
                            Password = userModel.Password,
                            UserRole = userModel.UserRole
                        });
                    }
                }

                return listUserResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserInfo GetUserById(string userId)
        {
            try
            {
                UserInfo userResponse = new UserInfo();
                List<UserModel> listUser = MongoDBCollections.UsersCollection.Find(obj => obj.UserId == ObjectId.Parse(userId)).ToList();
                UserModel userModel = listUser.Find(obj => obj.UserId == ObjectId.Parse(userId));

                if (userModel != null)
                {
                    userResponse.UserId = userModel.UserId.ToString();
                    userResponse.FirstName = userModel.FirstName;
                    userResponse.LastName = userModel.LastName;
                    userResponse.Username = userModel.Username;
                    userResponse.Password = userModel.Password;
                    userResponse.UserRole = userModel.UserRole;
                }

                return userResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserInfo> GetUserByCriteria(UserInfo userInfo)
        {
            try
            {
                FilterDefinitionBuilder<UserModel> builder = new FilterDefinitionBuilder<UserModel>();
                FilterDefinition<UserModel> filter = !builder.Eq("UserId", BsonNull.Value);

                if (!string.IsNullOrEmpty(userInfo.Username))
                {
                    filter = filter & builder.Eq("Username", userInfo.Username);
                }

                if (!string.IsNullOrEmpty(userInfo.Password))
                {
                    filter = filter & builder.Eq("Password", userInfo.Password);
                }

                List<UserInfo> listUserResponse = new List<UserInfo>();
                List<UserModel> listUser = MongoDBCollections.UsersCollection.Find(filter).ToList();

                if (listUser.Count > 0)
                {
                    foreach (UserModel userModel in listUser)
                    {
                        listUserResponse.Add(new UserInfo()
                        {
                            UserId = userModel.UserId.ToString(),
                            FirstName = userModel.FirstName,
                            LastName = userModel.LastName,
                            Username = userModel.Username,
                            Password = userModel.Password,
                            UserRole = userModel.UserRole
                        });
                    }
                }

                return listUserResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertUser(UserInfo userInfo)
        {
            try
            {
                UserModel userModel = new UserModel()
                {
                    UserId = ObjectId.GenerateNewId(),
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Username = userInfo.Username,
                    Password = userInfo.Password,
                    UserRole = userInfo.UserRole,
                    CreateDate = DateTime.UtcNow,
                    LastUpdateDate = DateTime.UtcNow
                };

                MongoDBCollections.UsersCollection.InsertOne(userModel);
                string UserId = userModel.UserId.ToString();
                return UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(UserInfo userInfo)
        {
            try
            {
                UpdateDefinition<UserModel> objUser = new UpdateDefinitionBuilder<UserModel>()
                    .Set(obj => obj.Username, !string.IsNullOrEmpty(userInfo.Username) ? userInfo.Username : string.Empty)
                    .Set(obj => obj.Password, !string.IsNullOrEmpty(userInfo.Password) ? userInfo.Password : string.Empty)
                    .Set(obj => obj.LastUpdateDate, DateTime.UtcNow);

                UpdateResult updateResult = MongoDBCollections.UsersCollection.UpdateOne(obj => obj.UserId == ObjectId.Parse(userInfo.UserId), objUser);

                if (updateResult.IsAcknowledged)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(string userId)
        {
            try
            {
                DeleteResult deleteResult = MongoDBCollections.UsersCollection.DeleteOne(obj => obj.UserId == ObjectId.Parse(userId));

                if (deleteResult.IsAcknowledged)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        List<UserInfo> InterfaceUserRepository.GetUserAll()
        {
            throw new NotImplementedException();
        }

        UserInfo InterfaceUserRepository.GetUserById(string userId)
        {
            throw new NotImplementedException();
        }

        List<UserInfo> InterfaceUserRepository.GetUserByCriteria(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        string InterfaceUserRepository.InsertUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        bool InterfaceUserRepository.UpdateUser(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }

        bool InterfaceUserRepository.DeleteUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}