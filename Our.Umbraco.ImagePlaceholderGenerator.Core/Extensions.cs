using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.IO;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Our.Umbraco.ImagePlaceholderGenerator.Core
{
	public static class Extensions
	{
		public static string GetPlaceholderUri(this IPublishedContent content, int maxWidth = 4, int maxHeight = 4, string propertyAlias = "umbracoFile")
		{
			var cache = new CacheHelper();
			return cache.GetImagePlaceholder(content.GetPropertyValue<string>(propertyAlias), maxWidth, maxHeight);
		}

		public static string GetPlaceholderUri(this UrlHelper urlHelper, string path, int maxWidth = 4, int maxHeight = 4)
		{
			var cache = new CacheHelper();
			var cacheKey = HttpContext.Current.Server.MapPath(path);

			return cache.GetImagePlaceholder(cacheKey, maxWidth, maxHeight);
		}
	}
}
