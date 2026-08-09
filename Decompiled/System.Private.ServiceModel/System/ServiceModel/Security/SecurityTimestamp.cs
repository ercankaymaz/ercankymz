using System.Globalization;
using System.Runtime;
using System.Xml;

namespace System.ServiceModel.Security;

internal sealed class SecurityTimestamp
{
	private const string DefaultFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

	internal static readonly TimeSpan defaultTimeToLive = SecurityProtocolFactory.defaultTimestampValidityDuration;

	private char[] _computedCreationTimeUtc;

	private char[] _computedExpiryTimeUtc;

	private DateTime _creationTimeUtc;

	private DateTime _expiryTimeUtc;

	private readonly string _digestAlgorithm;

	private readonly byte[] _digest;

	public DateTime CreationTimeUtc => _creationTimeUtc;

	public DateTime ExpiryTimeUtc => _expiryTimeUtc;

	public string Id { get; }

	public string DigestAlgorithm => _digestAlgorithm;

	public SecurityTimestamp(DateTime creationTimeUtc, DateTime expiryTimeUtc, string id)
		: this(creationTimeUtc, expiryTimeUtc, id, null, null)
	{
	}

	internal SecurityTimestamp(DateTime creationTimeUtc, DateTime expiryTimeUtc, string id, string digestAlgorithm, byte[] digest)
	{
		if (creationTimeUtc > expiryTimeUtc)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new ArgumentOutOfRangeException("creationTimeUtc", System.SR.CreationTimeUtcIsAfterExpiryTime));
		}
		_creationTimeUtc = creationTimeUtc;
		_expiryTimeUtc = expiryTimeUtc;
		Id = id;
		_digestAlgorithm = digestAlgorithm;
		_digest = digest;
	}

	internal byte[] GetDigest()
	{
		return _digest;
	}

	internal char[] GetCreationTimeChars()
	{
		if (_computedCreationTimeUtc == null)
		{
			_computedCreationTimeUtc = ToChars(ref _creationTimeUtc);
		}
		return _computedCreationTimeUtc;
	}

	internal char[] GetExpiryTimeChars()
	{
		if (_computedExpiryTimeUtc == null)
		{
			_computedExpiryTimeUtc = ToChars(ref _expiryTimeUtc);
		}
		return _computedExpiryTimeUtc;
	}

	private static char[] ToChars(ref DateTime utcTime)
	{
		char[] array = new char["yyyy-MM-ddTHH:mm:ss.fffZ".Length];
		int offset = 0;
		ToChars(utcTime.Year, array, ref offset, 4);
		array[offset++] = '-';
		ToChars(utcTime.Month, array, ref offset, 2);
		array[offset++] = '-';
		ToChars(utcTime.Day, array, ref offset, 2);
		array[offset++] = 'T';
		ToChars(utcTime.Hour, array, ref offset, 2);
		array[offset++] = ':';
		ToChars(utcTime.Minute, array, ref offset, 2);
		array[offset++] = ':';
		ToChars(utcTime.Second, array, ref offset, 2);
		array[offset++] = '.';
		ToChars(utcTime.Millisecond, array, ref offset, 3);
		array[offset++] = 'Z';
		return array;
	}

	private static void ToChars(int n, char[] buffer, ref int offset, int count)
	{
		for (int num = offset + count - 1; num >= offset; num--)
		{
			buffer[num] = (char)(48 + n % 10);
			n /= 10;
		}
		offset += count;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "SecurityTimestamp: Id={0}, CreationTimeUtc={1}, ExpirationTimeUtc={2}", Id, XmlConvert.ToString(new DateTimeOffset(CreationTimeUtc)), XmlConvert.ToString(new DateTimeOffset(ExpiryTimeUtc)));
	}

	internal void ValidateRangeAndFreshness(TimeSpan timeToLive, TimeSpan allowedClockSkew)
	{
		if (CreationTimeUtc >= ExpiryTimeUtc)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.TimeStampHasCreationAheadOfExpiry, CreationTimeUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture), ExpiryTimeUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture))));
		}
		ValidateFreshness(timeToLive, allowedClockSkew);
	}

	internal void ValidateFreshness(TimeSpan timeToLive, TimeSpan allowedClockSkew)
	{
		DateTime utcNow = DateTime.UtcNow;
		if (ExpiryTimeUtc <= TimeoutHelper.Subtract(utcNow, allowedClockSkew))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.TimeStampHasExpiryTimeInPast, ExpiryTimeUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture), utcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture), allowedClockSkew)));
		}
		if (CreationTimeUtc >= TimeoutHelper.Add(utcNow, allowedClockSkew))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.TimeStampHasCreationTimeInFuture, CreationTimeUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture), utcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture), allowedClockSkew)));
		}
		if (CreationTimeUtc <= TimeoutHelper.Subtract(utcNow, TimeoutHelper.Add(timeToLive, allowedClockSkew)))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MessageSecurityException(System.SR.Format(System.SR.TimeStampWasCreatedTooLongAgo, CreationTimeUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture), utcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture), timeToLive, allowedClockSkew)));
		}
	}
}
