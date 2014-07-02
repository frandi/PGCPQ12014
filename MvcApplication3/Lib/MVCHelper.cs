using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication3.Lib
{
    public static class MVCHelper
    {
        public static MvcHtmlString AwesomeTag(this HtmlHelper helper, string param1)
        {
            return MvcHtmlString.Create(string.Format("<div class=awesome>{0}</div>", param1));
        }
    }
}