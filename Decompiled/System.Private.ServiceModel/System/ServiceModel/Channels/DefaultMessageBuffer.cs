using System.Collections.Generic;

namespace System.ServiceModel.Channels;

internal class DefaultMessageBuffer : MessageBuffer
{
	private XmlBuffer _msgBuffer;

	private KeyValuePair<string, object>[] _properties;

	private bool[] _understoodHeaders;

	private bool _closed;

	private MessageVersion _version;

	private Uri _to;

	private string _action;

	private bool _isNullMessage;

	private object ThisLock => _msgBuffer;

	public override int BufferSize => _msgBuffer.BufferSize;

	public DefaultMessageBuffer(Message message, XmlBuffer msgBuffer)
	{
		_msgBuffer = msgBuffer;
		_version = message.Version;
		_isNullMessage = message is NullMessage;
		_properties = new KeyValuePair<string, object>[message.Properties.Count];
		((ICollection<KeyValuePair<string, object>>)message.Properties).CopyTo(_properties, 0);
		_understoodHeaders = new bool[message.Headers.Count];
		for (int i = 0; i < _understoodHeaders.Length; i++)
		{
			_understoodHeaders[i] = message.Headers.IsUnderstood(i);
		}
		if (_version == MessageVersion.None)
		{
			_to = message.Headers.To;
			_action = message.Headers.Action;
		}
	}

	public override void Close()
	{
		lock (ThisLock)
		{
			if (_closed)
			{
				return;
			}
			_closed = true;
			for (int i = 0; i < _properties.Length; i++)
			{
				if (_properties[i].Value is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
		}
	}

	public override Message CreateMessage()
	{
		if (_closed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(CreateBufferDisposedException());
		}
		Message message = ((!_isNullMessage) ? Message.CreateMessage(_msgBuffer.GetReader(0), int.MaxValue, _version) : new NullMessage());
		lock (ThisLock)
		{
			message.Properties.CopyProperties(_properties);
		}
		for (int i = 0; i < _understoodHeaders.Length; i++)
		{
			if (_understoodHeaders[i])
			{
				message.Headers.AddUnderstood(i);
			}
		}
		if (_to != null)
		{
			message.Headers.To = _to;
		}
		if (_action != null)
		{
			message.Headers.Action = _action;
		}
		return message;
	}
}
