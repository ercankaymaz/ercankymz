using System.Xml;

namespace System.ServiceModel.Channels;

internal class StringMessage : ContentOnlyMessage
{
	private string _data;

	public override bool IsEmpty => string.IsNullOrEmpty(_data);

	public StringMessage(string data)
	{
		_data = data;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		if (_data != null && _data.Length > 0)
		{
			writer.WriteElementString("BODY", _data);
		}
	}
}
