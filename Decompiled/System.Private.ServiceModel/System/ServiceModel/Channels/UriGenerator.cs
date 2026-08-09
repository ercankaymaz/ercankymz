using System.Globalization;
using System.Threading;

namespace System.ServiceModel.Channels;

internal class UriGenerator
{
	private long _id;

	private string _prefix;

	public UriGenerator()
		: this("uuid")
	{
	}

	public UriGenerator(string scheme)
		: this(scheme, ";")
	{
	}

	public UriGenerator(string scheme, string delimiter)
	{
		if (scheme == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("scheme"));
		}
		if (scheme.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.UriGeneratorSchemeMustNotBeEmpty, "scheme"));
		}
		_prefix = scheme + ":" + Guid.NewGuid().ToString() + delimiter + "id=";
	}

	public string Next()
	{
		long num = Interlocked.Increment(ref _id);
		return _prefix + num.ToString(CultureInfo.InvariantCulture);
	}
}
