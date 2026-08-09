namespace System.ServiceModel.Channels;

internal class EncodedContentType : EncodedFramingRecord
{
	private EncodedContentType(FramingEncodingType encodingType)
		: base(new byte[2]
		{
			3,
			(byte)encodingType
		})
	{
	}

	private EncodedContentType(string contentType)
		: base(FramingRecordType.ExtensibleEncoding, contentType)
	{
	}

	public static EncodedContentType Create(string contentType)
	{
		return contentType switch
		{
			"application/soap+msbinsession1" => new EncodedContentType(FramingEncodingType.BinarySession), 
			"application/soap+msbin1" => new EncodedContentType(FramingEncodingType.Binary), 
			"application/soap+xml; charset=utf-8" => new EncodedContentType(FramingEncodingType.Soap12Utf8), 
			"text/xml; charset=utf-8" => new EncodedContentType(FramingEncodingType.Soap11Utf8), 
			"application/soap+xml; charset=utf16" => new EncodedContentType(FramingEncodingType.Soap12Utf16), 
			"text/xml; charset=utf16" => new EncodedContentType(FramingEncodingType.Soap11Utf16), 
			"application/soap+xml; charset=unicodeFFFE" => new EncodedContentType(FramingEncodingType.Soap12Utf16FFFE), 
			"text/xml; charset=unicodeFFFE" => new EncodedContentType(FramingEncodingType.Soap11Utf16FFFE), 
			"multipart/related" => new EncodedContentType(FramingEncodingType.MTOM), 
			_ => new EncodedContentType(contentType), 
		};
	}
}
