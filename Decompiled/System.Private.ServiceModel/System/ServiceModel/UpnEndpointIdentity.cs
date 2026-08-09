using System.IdentityModel.Claims;
using System.Runtime;
using System.Security.Claims;
using System.Security.Principal;
using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel;

public class UpnEndpointIdentity : EndpointIdentity
{
	private SecurityIdentifier _upnSid;

	private bool _hasUpnSidBeenComputed;

	private WindowsIdentity _windowsIdentity;

	private object _thisLock = new object();

	public UpnEndpointIdentity(string upnName)
	{
		if (upnName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("upnName");
		}
		Initialize(System.IdentityModel.Claims.Claim.CreateUpnClaim(upnName));
	}

	public UpnEndpointIdentity(System.IdentityModel.Claims.Claim identity)
	{
		if (identity == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("identity");
		}
		if (!identity.ClaimType.Equals(System.IdentityModel.Claims.ClaimTypes.Upn))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.Format(System.SR.UnrecognizedClaimTypeForIdentity, identity.ClaimType, System.IdentityModel.Claims.ClaimTypes.Upn));
		}
		Initialize(identity);
	}

	internal UpnEndpointIdentity(WindowsIdentity windowsIdentity)
	{
		_windowsIdentity = windowsIdentity ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("windowsIdentity");
		_upnSid = windowsIdentity.User;
		_hasUpnSidBeenComputed = true;
	}

	internal override void EnsureIdentityClaim()
	{
		if (_windowsIdentity == null)
		{
			return;
		}
		lock (_thisLock)
		{
			if (_windowsIdentity != null)
			{
				Initialize(System.IdentityModel.Claims.Claim.CreateUpnClaim(GetUpnFromWindowsIdentity(_windowsIdentity)));
				_windowsIdentity.Dispose();
				_windowsIdentity = null;
			}
		}
	}

	private string GetUpnFromWindowsIdentity(WindowsIdentity windowsIdentity)
	{
		string text = null;
		string text2 = null;
		try
		{
			text = ((ClaimsIdentity)(object)windowsIdentity).Name;
			if (IsMachineJoinedToDomain())
			{
				text2 = GetUpnFromDownlevelName(text);
			}
		}
		catch (Exception exception)
		{
			if (Fx.IsFatal(exception))
			{
				throw;
			}
		}
		return text2 ?? text;
	}

	private bool IsMachineJoinedToDomain()
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	private string GetUpnFromDownlevelName(string downlevelName)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal override void WriteContentsTo(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
		}
		writer.WriteElementString(XD.AddressingDictionary.Upn, XD.AddressingDictionary.IdentityExtensionNamespace, (string)base.IdentityClaim.Resource);
	}

	internal SecurityIdentifier GetUpnSid()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		if (!_hasUpnSidBeenComputed)
		{
			lock (_thisLock)
			{
				string text = (string)base.IdentityClaim.Resource;
				if (!_hasUpnSidBeenComputed)
				{
					try
					{
						NTAccount val = new NTAccount(text);
						IdentityReference obj = ((IdentityReference)val).Translate(typeof(SecurityIdentifier));
						_upnSid = (SecurityIdentifier)(object)((obj is SecurityIdentifier) ? obj : null);
					}
					catch (Exception ex)
					{
						if (Fx.IsFatal(ex))
						{
							throw;
						}
						if (ex is NullReferenceException)
						{
							throw;
						}
						SecurityTraceRecordHelper.TraceSpnToSidMappingFailure(text, ex);
					}
					finally
					{
						_hasUpnSidBeenComputed = true;
					}
				}
			}
		}
		return _upnSid;
	}
}
