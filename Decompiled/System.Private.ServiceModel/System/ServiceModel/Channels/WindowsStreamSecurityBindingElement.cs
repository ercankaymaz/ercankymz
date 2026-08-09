using System.ComponentModel;
using System.Net.Security;
using System.ServiceModel.Security;

namespace System.ServiceModel.Channels;

public class WindowsStreamSecurityBindingElement : StreamUpgradeBindingElement
{
	private ProtectionLevel _protectionLevel;

	[DefaultValue(ProtectionLevel.EncryptAndSign)]
	public ProtectionLevel ProtectionLevel
	{
		get
		{
			return _protectionLevel;
		}
		set
		{
			ProtectionLevelHelper.Validate(value);
			_protectionLevel = value;
		}
	}

	public WindowsStreamSecurityBindingElement()
	{
		_protectionLevel = ProtectionLevel.EncryptAndSign;
	}

	protected WindowsStreamSecurityBindingElement(WindowsStreamSecurityBindingElement elementToBeCloned)
		: base(elementToBeCloned)
	{
		_protectionLevel = elementToBeCloned._protectionLevel;
	}

	public override BindingElement Clone()
	{
		return new WindowsStreamSecurityBindingElement(this);
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		context.BindingParameters.Add(this);
		return context.BuildInnerChannelFactory<TChannel>();
	}

	public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		context.BindingParameters.Add(this);
		return context.CanBuildInnerChannelFactory<TChannel>();
	}

	public override StreamUpgradeProvider BuildClientStreamUpgradeProvider(BindingContext context)
	{
		return new WindowsStreamSecurityUpgradeProvider(this, context, isClient: true);
	}

	public override T GetProperty<T>(BindingContext context)
	{
		if (context == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("context");
		}
		if (typeof(T) == typeof(ISecurityCapabilities))
		{
			return (T)(object)new SecurityCapabilities(supportsClientAuth: true, supportsServerAuth: true, supportsClientWindowsIdentity: true, _protectionLevel, _protectionLevel);
		}
		if (typeof(T) == typeof(IdentityVerifier))
		{
			return (T)(object)IdentityVerifier.CreateDefault();
		}
		return context.GetInnerProperty<T>();
	}

	internal override bool IsMatch(BindingElement b)
	{
		if (b == null)
		{
			return false;
		}
		if (!(b is WindowsStreamSecurityBindingElement windowsStreamSecurityBindingElement))
		{
			return false;
		}
		if (_protectionLevel != windowsStreamSecurityBindingElement._protectionLevel)
		{
			return false;
		}
		return true;
	}
}
