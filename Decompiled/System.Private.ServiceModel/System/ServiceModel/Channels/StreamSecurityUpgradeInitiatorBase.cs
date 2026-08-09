using System.IO;
using System.Runtime;
using System.ServiceModel.Security;
using System.Threading.Tasks;

namespace System.ServiceModel.Channels;

internal abstract class StreamSecurityUpgradeInitiatorBase : StreamSecurityUpgradeInitiator
{
	private SecurityMessageProperty _remoteSecurity;

	private bool _securityUpgraded;

	private string _nextUpgrade;

	private bool _isOpen;

	protected EndpointAddress RemoteAddress { get; }

	protected Uri Via { get; }

	protected StreamSecurityUpgradeInitiatorBase(string upgradeString, EndpointAddress remoteAddress, Uri via)
	{
		RemoteAddress = remoteAddress;
		Via = via;
		_nextUpgrade = upgradeString;
	}

	public override string GetNextUpgrade()
	{
		string nextUpgrade = _nextUpgrade;
		_nextUpgrade = null;
		return nextUpgrade;
	}

	public override SecurityMessageProperty GetRemoteSecurity()
	{
		if (!_securityUpgraded)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.OperationInvalidBeforeSecurityNegotiation));
		}
		return _remoteSecurity;
	}

	public override Stream InitiateUpgrade(Stream stream)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
		}
		if (!_isOpen)
		{
			Open(TimeSpan.Zero);
		}
		Stream result = OnInitiateUpgrade(stream, out _remoteSecurity);
		_securityUpgraded = true;
		return result;
	}

	internal override async Task<Stream> InitiateUpgradeAsync(Stream stream)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
		}
		if (!_isOpen)
		{
			Open(TimeSpan.Zero);
		}
		OutWrapper<SecurityMessageProperty> remoteSecurityWrapper = new OutWrapper<SecurityMessageProperty>();
		Stream result = await OnInitiateUpgradeAsync(stream, remoteSecurityWrapper);
		_remoteSecurity = remoteSecurityWrapper;
		_securityUpgraded = true;
		return result;
	}

	internal override void Open(TimeSpan timeout)
	{
		_isOpen = true;
	}

	internal override Task OpenAsync(TimeSpan timeout)
	{
		_isOpen = true;
		return Task.CompletedTask;
	}

	internal override void Close(TimeSpan timeout)
	{
		_isOpen = false;
	}

	internal override Task CloseAsync(TimeSpan timeout)
	{
		_isOpen = false;
		return Task.CompletedTask;
	}

	protected abstract Stream OnInitiateUpgrade(Stream stream, out SecurityMessageProperty remoteSecurity);

	protected abstract Task<Stream> OnInitiateUpgradeAsync(Stream stream, OutWrapper<SecurityMessageProperty> remoteSecurity);
}
