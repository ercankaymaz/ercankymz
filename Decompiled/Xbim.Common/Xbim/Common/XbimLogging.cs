using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Xbim.Common.Configuration;

namespace Xbim.Common;

[Obsolete("Obsoleted. Use Dependency Injection instead")]
public class XbimLogging
{
	private static ILoggerFactory _loggerFactory;

	[Obsolete("Use XbimServices.Current.GetLoggerFactory() instead")]
	public static ILoggerFactory LoggerFactory
	{
		get
		{
			if (_loggerFactory == null)
			{
				_loggerFactory = XbimServices.Current.GetLoggerFactory();
			}
			return _loggerFactory;
		}
		set
		{
			_loggerFactory = value;
		}
	}

	[Obsolete]
	public XbimLogging()
		: this(NullLoggerFactory.Instance)
	{
	}

	[Obsolete]
	public XbimLogging(ILoggerFactory loggerFactory)
	{
		_loggerFactory = loggerFactory;
	}

	[Obsolete("Use XbimServices.Current.CreateLogger")]
	public static ILogger CreateLogger(string categoryName)
	{
		return LoggerFactory.CreateLogger(categoryName);
	}

	[Obsolete("Prefer a DI approach or use XbimServices.Current.CreateLogger<T>", false)]
	public static ILogger<T> CreateLogger<T>()
	{
		return XbimServices.Current.CreateLogger<T>();
	}
}
