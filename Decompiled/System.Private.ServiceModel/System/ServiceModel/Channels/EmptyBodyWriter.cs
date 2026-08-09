using System.Xml;

namespace System.ServiceModel.Channels;

internal class EmptyBodyWriter : BodyWriter
{
	private static EmptyBodyWriter s_value;

	public static EmptyBodyWriter Value
	{
		get
		{
			if (s_value == null)
			{
				s_value = new EmptyBodyWriter();
			}
			return s_value;
		}
	}

	internal override bool IsEmpty => true;

	private EmptyBodyWriter()
		: base(isBuffered: true)
	{
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
	}
}
