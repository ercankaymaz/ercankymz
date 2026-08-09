using System;
using System.Security.AccessControl;

namespace Microsoft.Win32;

public static class RegistryAclExtensions
{
	public static RegistrySecurity GetAccessControl(this RegistryKey key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		return key.GetAccessControl();
	}

	public static RegistrySecurity GetAccessControl(this RegistryKey key, AccessControlSections includeSections)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		return key.GetAccessControl(includeSections);
	}

	public static void SetAccessControl(this RegistryKey key, RegistrySecurity registrySecurity)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		key.SetAccessControl(registrySecurity);
	}
}
