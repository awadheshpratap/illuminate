using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FizzWare.NBuilder;
using Illuminate.Model;
namespace Illuminate.Web.API.MockDataGenerator
{
    public class ContentGenerator
    {
        public static Dictionary<int, ContentLegacy> GenerateContent()
        {
            ContentLegacy content = Builder<ContentLegacy>.CreateNew().With(x => x.Id = IdGenerator.Next()).Build();
            Dictionary<int, ContentLegacy> contentDict = new Dictionary<int, ContentLegacy>();
            contentDict[content.Id] = content;
            return contentDict;
        }
    }
}