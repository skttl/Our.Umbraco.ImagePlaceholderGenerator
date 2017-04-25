using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Cache;

namespace Our.Umbraco.ImagePlaceholderGenerator.Core
{
	public class CacheHelper
	{
		private readonly ICacheProvider _cache;
		private readonly GeneratorHelper _generator;

		public CacheHelper()
		{
			_cache = ApplicationContext.Current.ApplicationCache.StaticCache;
			_generator = new GeneratorHelper();
		}

		public string GetImagePlaceholder(string cacheKey, int maxWidth = 4, int maxHeight = 4)
		{
			return _cache.GetCacheItem<string>(cacheKey + "/" + maxWidth + "x" + maxHeight, () => _generator.CreateImagePlaceholder(cacheKey, maxWidth, maxHeight));
		}
	}
}
