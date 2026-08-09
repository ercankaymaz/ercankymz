using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime;

namespace System.ServiceModel.Security;

internal sealed class InMemoryNonceCache : NonceCache
{
	internal sealed class NonceCacheImpl : TimeBoundedCache
	{
		internal sealed class NonceKeyComparer : IEqualityComparer, IEqualityComparer<byte[]>
		{
			public int GetHashCode(object o)
			{
				return GetHashCode((byte[])o);
			}

			public int GetHashCode(byte[] o)
			{
				return o[0] | (o[1] << 8) | (o[2] << 16) | (o[3] << 24);
			}

			public int Compare(object x, object y)
			{
				return Compare((byte[])x, (byte[])y);
			}

			public int Compare(byte[] x, byte[] y)
			{
				if (x == y)
				{
					return 0;
				}
				if (x == null)
				{
					return -1;
				}
				if (y == null)
				{
					return 1;
				}
				int num = x.Length;
				int num2 = y.Length;
				if (num == num2)
				{
					for (int i = 0; i < num; i++)
					{
						int num3 = x[i] - y[i];
						if (num3 != 0)
						{
							return num3;
						}
					}
					return 0;
				}
				if (num > num2)
				{
					return 1;
				}
				return -1;
			}

			public new bool Equals(object x, object y)
			{
				return Compare(x, y) == 0;
			}

			public bool Equals(byte[] x, byte[] y)
			{
				return Compare(x, y) == 0;
			}
		}

		private static NonceKeyComparer s_comparer = new NonceKeyComparer();

		private static object s_dummyItem = new object();

		private static int s_lowWaterMark = 50;

		private static int s_minimumNonceLength = 4;

		private TimeSpan _cachingTimeSpan;

		public NonceCacheImpl(TimeSpan cachingTimeSpan, int maxCachedNonces)
			: base(s_lowWaterMark, maxCachedNonces, s_comparer, PurgingMode.AccessBasedPurge, TimeSpan.FromTicks(cachingTimeSpan.Ticks >> 2), doRemoveNotification: false)
		{
			_cachingTimeSpan = cachingTimeSpan;
		}

		public bool TryAddNonce(byte[] nonce)
		{
			if (nonce == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("nonce");
			}
			if (nonce.Length < s_minimumNonceLength)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.NonceLengthTooShort);
			}
			DateTime expirationTime = TimeoutHelper.Add(DateTime.UtcNow, _cachingTimeSpan);
			return TryAddItem(nonce, s_dummyItem, expirationTime, replaceExistingEntry: false);
		}

		public bool CheckNonce(byte[] nonce)
		{
			if (nonce == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("nonce");
			}
			if (nonce.Length < s_minimumNonceLength)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(System.SR.NonceLengthTooShort);
			}
			if (GetItem(nonce) != null)
			{
				return true;
			}
			return false;
		}
	}

	private NonceCacheImpl _cacheImpl;

	public InMemoryNonceCache(TimeSpan cachingTime, int maxCachedNonces)
	{
		base.CacheSize = maxCachedNonces;
		base.CachingTimeSpan = cachingTime;
		_cacheImpl = new NonceCacheImpl(cachingTime, maxCachedNonces);
	}

	public override bool CheckNonce(byte[] nonce)
	{
		return _cacheImpl.CheckNonce(nonce);
	}

	public override bool TryAddNonce(byte[] nonce)
	{
		return _cacheImpl.TryAddNonce(nonce);
	}

	public override string ToString()
	{
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		stringWriter.WriteLine("NonceCache:");
		stringWriter.WriteLine("   Caching Timespan: {0}", base.CachingTimeSpan);
		stringWriter.WriteLine("   Capacity: {0}", base.CacheSize);
		return stringWriter.ToString();
	}
}
