using Microsoft.Extensions.DependencyInjection;

namespace Xbim.Common.Configuration;

public interface IXbimConfigurationBuilder
{
	IServiceCollection Services { get; }
}
