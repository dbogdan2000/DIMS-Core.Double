using System;
using DIMS_Core.Common.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DIMS_Core.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString GetSexName<TModel>(this IHtmlHelper<TModel> helper, Func<TModel, SexType> prop)
        {
            var value = prop(helper.ViewData.Model);

            return value switch
                   {
                       SexType.Man => new("Man"),
                       SexType.Woman => new("Woman"),
                       _ => new(string.Empty)
                   };
        }
    }
}