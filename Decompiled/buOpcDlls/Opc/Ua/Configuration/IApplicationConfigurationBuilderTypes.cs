using System.Runtime.InteropServices;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderTypes : IApplicationConfigurationBuilderTransportQuotas, IApplicationConfigurationBuilderServer, IApplicationConfigurationBuilderClient
{
}
