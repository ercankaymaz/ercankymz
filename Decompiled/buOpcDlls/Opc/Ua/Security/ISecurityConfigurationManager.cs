using System.Runtime.InteropServices;

namespace Opc.Ua.Security;

[ComVisible(true)]
public interface ISecurityConfigurationManager
{
	SecuredApplication ReadConfiguration(string filePath);

	void WriteConfiguration(string filePath, SecuredApplication configuration);
}
