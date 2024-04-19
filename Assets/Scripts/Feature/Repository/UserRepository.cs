using System;
using System.IO;
using System.Linq.Expressions;
using Core.Data;
using UnityEngine;

namespace Feature.Repository
{
    /// <summary>
    /// userのデータを保存するクラスのwrapper
    /// </summary>
    public class UserRepository
    {
        private static readonly string RootPath = Application.persistentDataPath;
        private static readonly string SaveDirPath = Path.Combine(RootPath, "preference");

        private readonly UserData _userData = new();
        private readonly string _saveFilePath = "user_data.json";

        public UserRepository()
        {
            EnsureDirectoryExists();
        }
        
        private string GetFilePath()
        {
            return Path.Combine(SaveDirPath, _saveFilePath);
        }


        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(SaveDirPath))
            {
                Directory.CreateDirectory(SaveDirPath);
            }
        }

        public void Load()
        {
            _userData.Load(GetFilePath());
        }

        public void Delete()
        {
            _userData.Delete(GetFilePath());
        }

        public void Save()
        {
            _userData.Save();
        }

        public TValue GetSpecificField<T, TValue>(Expression<Func<T, object>> selector) where T : IDefaultable<T>, new()
        {
            return _userData.GetSpecificField<T, TValue>(selector);
        }
    }
}