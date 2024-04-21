#region

using System;
using System.IO;
using System.Linq.Expressions;
using Core.Data;
using UnityEngine;

#endregion

namespace Feature.Repository
{
    /// <summary>
    ///     userのデータを保存するクラスのwrapper
    /// </summary>
    public class UserRepository
    {
        private static readonly string RootPath = Application.persistentDataPath;
        private static readonly string SaveDirPath = Path.Combine(RootPath, "preference");
        private readonly string saveFilePath = "user_data.json";

        private readonly UserData userData = new();

        public UserRepository()
        {
            EnsureDirectoryExists();
        }

        private string GetFilePath() => Path.Combine(SaveDirPath, saveFilePath);


        private void EnsureDirectoryExists()
        {
            if (!Directory.Exists(SaveDirPath))
            {
                Directory.CreateDirectory(SaveDirPath);
            }
        }

        public void Load()
        {
            userData.Load(GetFilePath());
        }

        public void Delete()
        {
            userData.Delete(GetFilePath());
        }

        public void Save()
        {
            userData.Save();
        }

        public TValue GetSpecificField<T, TValue>(Expression<Func<T, object>> selector)
            where T : IDefaultable<T>, new() => userData.GetSpecificField<T, TValue>(selector);
    }
}