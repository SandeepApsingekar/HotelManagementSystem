using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Web.Functions
{
    public static class LabelClass
    {
        public static IHtmlString LabelEx(this HtmlHelper helper, string target, string text )
        {
            HtmlString str = new HtmlString("<label for=" + target + ">" + text + "</label>");
            return new MvcHtmlString(str.ToString());
        }

        public static IHtmlString ImgEx(this HtmlHelper helper, string src, string alt, object htmlAttributes)
        {
            TagBuilder tb = new TagBuilder("img");
            //convert the relative path to the url
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);
            tb.MergeAttribute("class", htmlAttributes.ToString());
            //We are saying using tagrender to say that close by itself
            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}