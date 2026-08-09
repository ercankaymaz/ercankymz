using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System.Formats.Asn1;

[Serializable]
[System_002EFormats_002EAsn1_002ENullableContext(2)]
[System_002EFormats_002EAsn1_002ENullable(0)]
[ComVisible(true)]
public class AsnContentException : Exception
{
	public AsnContentException()
		: base(System_002EFormats_002EAsn13538873_002ESR.ContentException_DefaultMessage)
	{
	}

	public AsnContentException(string message)
		: base(message ?? System_002EFormats_002EAsn13538873_002ESR.ContentException_DefaultMessage)
	{
	}

	public AsnContentException(string message, Exception inner)
		: base(message ?? System_002EFormats_002EAsn13538873_002ESR.ContentException_DefaultMessage, inner)
	{
	}

	[System_002EFormats_002EAsn1_002ENullableContext(1)]
	protected AsnContentException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
