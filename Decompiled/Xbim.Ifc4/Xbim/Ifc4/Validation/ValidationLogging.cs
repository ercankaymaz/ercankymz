using Microsoft.Extensions.Logging;
using Xbim.Common.Configuration;

namespace Xbim.Ifc4.Validation;

internal class ValidationLogging
{
	internal static ILogger CreateLogger<T>()
	{
		return XbimServices.Current.GetLoggerFactory().CreateLogger<T>();
	}
}
