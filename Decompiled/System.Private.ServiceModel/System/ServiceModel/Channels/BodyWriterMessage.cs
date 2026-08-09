using System.Collections.Generic;
using System.Runtime;
using System.ServiceModel.Diagnostics;
using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

internal class BodyWriterMessage : Message
{
	private class OnWriteMessageAsyncResult : AsyncResult
	{
		private BodyWriterMessage _message;

		private XmlDictionaryWriter _writer;

		public OnWriteMessageAsyncResult(XmlDictionaryWriter writer, BodyWriterMessage message, AsyncCallback callback, object state)
			: base(callback, state)
		{
			_message = message;
			_writer = writer;
			if (HandleWriteBodyContents(null))
			{
				Complete(completedSynchronously: true);
			}
		}

		private bool HandleWriteBodyContents(IAsyncResult result)
		{
			if (result == null)
			{
				result = _message.OnBeginWriteBodyContents(_writer, PrepareAsyncCompletion(HandleWriteBodyContents), this);
				if (!result.CompletedSynchronously)
				{
					return false;
				}
			}
			_message.OnEndWriteBodyContents(result);
			_message.WriteMessagePostamble(_writer);
			return true;
		}

		public static void End(IAsyncResult result)
		{
			AsyncResult.End<OnWriteMessageAsyncResult>(result);
		}
	}

	private MessageProperties _properties;

	private MessageHeaders _headers;

	public override bool IsFault
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			return BodyWriter.IsFault;
		}
	}

	public override bool IsEmpty
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			return BodyWriter.IsEmpty;
		}
	}

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

	public override MessageVersion Version
	{
		get
		{
			if (base.IsDisposed)
			{
				throw TraceUtility.ThrowHelperError(CreateMessageDisposedException(), this);
			}
			return _headers.MessageVersion;
		}
	}

	protected internal BodyWriter BodyWriter { get; private set; }

	private BodyWriterMessage(BodyWriter bodyWriter)
	{
		BodyWriter = bodyWriter;
	}

	public BodyWriterMessage(MessageVersion version, string action, BodyWriter bodyWriter)
		: this(bodyWriter)
	{
		_headers = new MessageHeaders(version);
		_headers.Action = action;
	}

	public BodyWriterMessage(MessageVersion version, ActionHeader actionHeader, BodyWriter bodyWriter)
		: this(bodyWriter)
	{
		_headers = new MessageHeaders(version);
		_headers.SetActionHeader(actionHeader);
	}

	public BodyWriterMessage(MessageHeaders headers, KeyValuePair<string, object>[] properties, BodyWriter bodyWriter)
		: this(bodyWriter)
	{
		_headers = new MessageHeaders(headers);
		_properties = new MessageProperties(properties);
	}

	protected override MessageBuffer OnCreateBufferedCopy(int maxBufferSize)
	{
		BodyWriter bodyWriter = ((!BodyWriter.IsBuffered) ? BodyWriter.CreateBufferedCopy(maxBufferSize) : BodyWriter);
		KeyValuePair<string, object>[] array = new KeyValuePair<string, object>[Properties.Count];
		((ICollection<KeyValuePair<string, object>>)Properties).CopyTo(array, 0);
		return new BodyWriterMessageBuffer(_headers, array, bodyWriter);
	}

	protected override void OnClose()
	{
		Exception ex = null;
		try
		{
			base.OnClose();
		}
		catch (Exception ex2)
		{
			if (Fx.IsFatal(ex2))
			{
				throw;
			}
			ex = ex2;
		}
		try
		{
			if (_properties != null)
			{
				_properties.Dispose();
			}
		}
		catch (Exception ex3)
		{
			if (Fx.IsFatal(ex3))
			{
				throw;
			}
			if (ex == null)
			{
				ex = ex3;
			}
		}
		if (ex != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(ex);
		}
		BodyWriter = null;
	}

	protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
	{
		BodyWriter.WriteBodyContents(writer);
	}

	protected override Task OnWriteBodyContentsAsync(XmlDictionaryWriter writer)
	{
		return BodyWriter.WriteBodyContentsAsync(writer);
	}

	protected override IAsyncResult OnBeginWriteMessage(XmlDictionaryWriter writer, AsyncCallback callback, object state)
	{
		return null;
	}

	protected override void OnEndWriteMessage(IAsyncResult result)
	{
	}

	protected override IAsyncResult OnBeginWriteBodyContents(XmlDictionaryWriter writer, AsyncCallback callback, object state)
	{
		return BodyWriter.BeginWriteBodyContents(writer, callback, state);
	}

	protected override void OnEndWriteBodyContents(IAsyncResult result)
	{
		BodyWriter.EndWriteBodyContents(result);
	}

	protected override void OnBodyToString(XmlDictionaryWriter writer)
	{
		if (BodyWriter.IsBuffered)
		{
			BodyWriter.WriteBodyContents(writer);
		}
		else
		{
			writer.WriteString(System.SR.MessageBodyIsStream);
		}
	}
}
