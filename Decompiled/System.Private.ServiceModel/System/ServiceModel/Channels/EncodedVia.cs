namespace System.ServiceModel.Channels;

internal class EncodedVia : EncodedFramingRecord
{
	public EncodedVia(string via)
		: base(FramingRecordType.Via, via)
	{
	}
}
