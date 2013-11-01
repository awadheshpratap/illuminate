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
        public static Dictionary<int, Content> GenerateContent()
        {
            Content content = Builder<Content>.CreateNew().With(x => x.Id = IdGenerator.Next()).Build();
            Dictionary<int, Content> contentDict = new Dictionary<int, Content>();
            contentDict[content.Id] = content;
            return contentDict;
        }
    }
}