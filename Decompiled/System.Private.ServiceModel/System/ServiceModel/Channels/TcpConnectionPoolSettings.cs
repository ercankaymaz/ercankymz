using System.Runtime;

namespace System.ServiceModel.Channels;

public sealed class TcpConnectionPoolSettings
{
	private string _groupName;

	private TimeSpan _idleTimeout;

	private TimeSpan _leaseTimeout;

	private int _maxOutboundConnectionsPerEndpoint;

	public string GroupName
	{
		get
		{
			return _groupName;
		}
		set
		{
			_groupName = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public TimeSpan IdleTimeout
	{
		get
		{
			return _idleTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRange0));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_idleTimeout = value;
		}
	}

	public TimeSpan LeaseTimeout
	{
		get
		{
			return _leaseTimeout;
		}
		set
		{
			if (value < TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRange0));
			}
			if (TimeoutHelper.IsTooLarge(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.SFxTimeoutOutOfRangeTooBig));
			}
			_leaseTimeout = value;
		}
	}

	public int MaxOutboundConnectionsPerEndpoint
	{
		get
		{
			return _maxOutboundConnectionsPerEndpoint;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
			}
			_maxOutboundConnectionsPerEndpoint = value;
		}
	}

	internal TcpConnectionPoolSettings()
	{
		_groupName = "default";
		_idleTimeout = ConnectionOrientedTransportDefaults.IdleTimeout;
		_leaseTimeout = TcpTransportDefaults.ConnectionLeaseTimeout;
		_maxOutboundConnectionsPerEndpoint = 10;
	}

	internal TcpConnectionPoolSettings(TcpConnectionPoolSettings tcp)
	{
		_groupName = tcp._groupName;
		_idleTimeout = tcp._idleTimeout;
		_leaseTimeout = tcp._leaseTimeout;
		_maxOutboundConnectionsPerEndpoint = tcp._maxOutboundConnectionsPerEndpoint;
	}

	internal TcpConnectionPoolSettings Clone()
	{
		return new TcpConnectionPoolSettings(this);
	}

	internal bool IsMatch(TcpConnectionPoolSettings tcp)
	{
		if (_groupName != tcp._groupName)
		{
			return false;
		}
		if (_idleTimeout != tcp._idleTimeout)
		{
			return false;
		}
		if (_leaseTimeout != tcp._leaseTimeout)
		{
			return false;
		}
		if (_maxOutboundConnectionsPerEndpoint != tcp._maxOutboundConnectionsPerEndpoint)
		{
			return false;
		}
		return true;
	}
}
