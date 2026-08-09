using System.Runtime.InteropServices;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderClient
{
	IApplicationConfigurationBuilderClientSelected AsClient();
}
