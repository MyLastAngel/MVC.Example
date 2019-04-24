using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVC.Server.Managers
{
    public static class ExternalManager
    {
        #region Свойства
        /// <summary>Загруженные из внешних библиотек контролеры (MVC.External)</summary>
        public static List<TypeInfo> ExternalControllers { get; private set; }
        #endregion

        static ExternalManager()
        {
            ExternalControllers = new List<TypeInfo>();

            Load();
        }

        /// <summary>Загружаем список контролеров из библиотеки</summary>
        public static void Load()
        {
            string s = typeof(Program).Assembly.Location;
            var files = Directory.GetFiles(Path.GetDirectoryName(s), "MVC.*.dll");

            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(files[i]);
                    foreach (var type in assembly.GetExportedTypes())
                    {
                        if (type.IsClass && typeof(Controller).IsAssignableFrom(type))
                            ExternalControllers.Add(type.GetTypeInfo());
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
