using System.Runtime.InteropServices;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderServer
{
	IApplicationConfigurationBuilderServerSelected AsServer(string[] baseAddresses, string[] alternateBaseAddresses = null);
}
