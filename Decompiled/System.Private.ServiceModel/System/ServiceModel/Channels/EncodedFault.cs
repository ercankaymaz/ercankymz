namespace System.ServiceModel.Channels;

internal class EncodedFault : EncodedFramingRecord
{
	public EncodedFault(string fault)
		: base(FramingRecordType.Fault, fault)
	{
	}
}
