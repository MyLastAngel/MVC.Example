using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVC.Server
{
    // Контейнер контроллеров
    public class ExternalPartsProvider : ApplicationPart, IApplicationPartTypeProvider
    {
        #region Поля
        readonly List<TypeInfo> types = new List<TypeInfo>();
        #endregion

        #region Свойства
        public IEnumerable<TypeInfo> Types => types;
        public override string Name => "Внешние билиотеки";
        #endregion

        public ExternalPartsProvider(IEnumerable<TypeInfo> items)
        {
            types.AddRange(items);
        }
    }
}
