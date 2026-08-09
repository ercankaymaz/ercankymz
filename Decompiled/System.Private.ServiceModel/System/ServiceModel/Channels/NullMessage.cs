namespace System.ServiceModel.Channels;

internal class NullMessage : StringMessage
{
	public NullMessage()
		: base(string.Empty)
	{
	}
}
