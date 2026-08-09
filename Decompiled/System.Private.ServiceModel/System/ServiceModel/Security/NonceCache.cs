using System.Runtime;

namespace System.ServiceModel.Security;

public abstract class NonceCache
{
	private TimeSpan _cachingTime;

	private int _maxCachedNonces;

	public TimeSpan CachingTimeSpan
	{
		get
		{
			return _cachingTime;
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
			_cachingTime = value;
		}
	}

	public int CacheSize
	{
		get
		{
			return _maxCachedNonces;
		}
		set
		{
			if (value < 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBeNonNegative));
			}
			_maxCachedNonces = value;
		}
	}

	public abstract bool TryAddNonce(byte[] nonce);

	public abstract bool CheckNonce(byte[] nonce);
}
