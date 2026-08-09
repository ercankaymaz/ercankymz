using System.Net.Security;

namespace System.ServiceModel.Channels;

public class SecurityCapabilities : ISecurityCapabilities
{
	internal bool _supportsServerAuth;

	internal bool _supportsClientAuth;

	internal bool _supportsClientWindowsIdentity;

	internal ProtectionLevel _requestProtectionLevel;

	internal ProtectionLevel _responseProtectionLevel;

	public ProtectionLevel SupportedRequestProtectionLevel => _requestProtectionLevel;

	public ProtectionLevel SupportedResponseProtectionLevel => _responseProtectionLevel;

	public bool SupportsClientAuthentication => _supportsClientAuth;

	public bool SupportsClientWindowsIdentity => _supportsClientWindowsIdentity;

	public bool SupportsServerAuthentication => _supportsServerAuth;

	public static SecurityCapabilities None => new SecurityCapabilities(supportsClientAuth: false, supportsServerAuth: false, supportsClientWindowsIdentity: false, ProtectionLevel.None, ProtectionLevel.None);

	public SecurityCapabilities(bool supportsClientAuth, bool supportsServerAuth, bool supportsClientWindowsIdentity, ProtectionLevel requestProtectionLevel, ProtectionLevel responseProtectionLevel)
	{
		_supportsClientAuth = supportsClientAuth;
		_supportsServerAuth = supportsServerAuth;
		_supportsClientWindowsIdentity = supportsClientWindowsIdentity;
		_requestProtectionLevel = requestProtectionLevel;
		_responseProtectionLevel = responseProtectionLevel;
	}

	public static bool IsEqual(ISecurityCapabilities capabilities1, ISecurityCapabilities capabilities2)
	{
		if (capabilities1 == null)
		{
			capabilities1 = None;
		}
		if (capabilities2 == null)
		{
			capabilities2 = None;
		}
		if (capabilities1.SupportedRequestProtectionLevel != capabilities2.SupportedRequestProtectionLevel)
		{
			return false;
		}
		if (capabilities1.SupportedResponseProtectionLevel != capabilities2.SupportedResponseProtectionLevel)
		{
			return false;
		}
		if (capabilities1.SupportsClientAuthentication != capabilities2.SupportsClientAuthentication)
		{
			return false;
		}
		if (capabilities1.SupportsClientWindowsIdentity != capabilities2.SupportsClientWindowsIdentity)
		{
			return false;
		}
		if (capabilities1.SupportsServerAuthentication != capabilities2.SupportsServerAuthentication)
		{
			return false;
		}
		return true;
	}
}
