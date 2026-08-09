using System.Runtime.InteropServices;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderSecurity
{
	IApplicationConfigurationBuilderSecurityOptions AddSecurityConfiguration(string subjectName, string pkiRoot = null, string appRoot = null, string rejectedRoot = null);

	IApplicationConfigurationBuilderSecurityOptionStores AddSecurityConfigurationStores(string subjectName, string appRoot, string trustedRoot, string issuerRoot, string rejectedRoot = null);
}
