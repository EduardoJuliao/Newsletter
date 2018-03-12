using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ApplicationForm
{
    internal static class MvcExtensions
    {
        public static IEnumerable<string> GetError(this ModelStateDictionary ms)
        {
            return ms.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
        }

        public static string GetErrorString(this ModelStateDictionary ms)
        {
            return string.Join(Environment.NewLine, ms.GetError());
        }
    }
}