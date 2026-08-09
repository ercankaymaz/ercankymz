using System;
using System.Runtime.InteropServices;

namespace Opc.Ua.Security;

[ComVisible(true)]
public static class SecurityConfigurationManagerFactory
{
	public static ISecurityConfigurationManager CreateInstance(string typeName)
	{
		if (string.IsNullOrEmpty(typeName))
		{
			return new SecurityConfigurationManager();
		}
		Type type = Type.GetType(typeName);
		if (type == null)
		{
			throw ServiceResultException.Create(2151481344u, "Cannot load type: {0}", typeName);
		}
		if (!(Activator.CreateInstance(type) is ISecurityConfigurationManager result))
		{
			throw ServiceResultException.Create(2151481344u, "Type does not support the ISecurityConfigurationManager interface: {0}", typeName);
		}
		return result;
	}
}
