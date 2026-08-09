using System.ServiceModel.Diagnostics;
using System.Xml;

namespace System.ServiceModel.Channels;

internal abstract class ContentOnlyMessage : Message
{
	private MessageHeaders _headers;

	private MessageProperties _properties;

	public override MessageHeaders Headers
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			return _headers;
		}
	}

	public override MessageProperties Properties
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			if (_properties == null)
			{
				_properties = new MessageProperties();
			}
			return _properties;
		}
	}

	public override MessageVersion Version => _headers.MessageVersion;

	protected ContentOnlyMessage()
	{
		_headers = new MessageHeaders(MessageVersion.None);
	}

	protected override void OnBodyToString(XmlDictionaryWriter writer)
	{
		OnWriteBodyContents(writer);
	}
}
