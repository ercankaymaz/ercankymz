using System.IO;

namespace System.ServiceModel.Channels;

internal class ViaStringDecoder : StringDecoder
{
	private Uri _via;

	public Uri ValueAsUri
	{
		get
		{
			if (!base.IsValueDecoded)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.FramingValueNotAvailable));
			}
			return _via;
		}
	}

	public ViaStringDecoder(int sizeQuota)
		: base(sizeQuota)
	{
	}

	protected override Exception OnSizeQuotaExceeded(int size)
	{
		Exception ex = new InvalidDataException(System.SR.Format(System.SR.FramingViaTooLong, size));
		FramingEncodingString.AddFaultString(ex, "http://schemas.microsoft.com/ws/2006/05/framing/faults/ViaTooLong");
		return ex;
	}

	protected override void OnComplete(string value)
	{
		try
		{
			_via = new Uri(value);
			base.OnComplete(value);
		}
		catch (UriFormatException innerException)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidDataException(System.SR.Format(System.SR.FramingViaNotUri, value), innerException));
		}
	}
}
