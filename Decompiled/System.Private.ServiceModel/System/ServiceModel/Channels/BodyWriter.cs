using System.Threading.Tasks;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class BodyWriter
{
	internal class BufferedBodyWriter : BodyWriter
	{
		private XmlBuffer _buffer;

		public BufferedBodyWriter(XmlBuffer buffer)
			: base(isBuffered: true)
		{
			_buffer = buffer;
		}

		protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
		{
			XmlDictionaryReader reader = _buffer.GetReader(0);
			using (reader)
			{
				reader.ReadStartElement();
				while (reader.NodeType != XmlNodeType.EndElement)
				{
					writer.WriteNode(reader, defattr: false);
				}
				reader.ReadEndElement();
			}
		}
	}

	private bool _canWrite;

	private object _thisLock;

	public bool IsBuffered { get; }

	internal virtual bool IsEmpty => false;

	internal virtual bool IsFault => false;

	protected BodyWriter(bool isBuffered)
	{
		IsBuffered = isBuffered;
		_canWrite = true;
		if (!IsBuffered)
		{
			_thisLock = new object();
		}
	}

	public BodyWriter CreateBufferedCopy(int maxBufferSize)
	{
		if (maxBufferSize < 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("maxBufferSize", maxBufferSize, System.SR.ValueMustBeNonNegative));
		}
		if (IsBuffered)
		{
			return this;
		}
		lock (_thisLock)
		{
			if (!_canWrite)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.BodyWriterCanOnlyBeWrittenOnce));
			}
			_canWrite = false;
		}
		BodyWriter bodyWriter = OnCreateBufferedCopy(maxBufferSize);
		if (!bodyWriter.IsBuffered)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.BodyWriterReturnedIsNotBuffered));
		}
		return bodyWriter;
	}

	protected virtual BodyWriter OnCreateBufferedCopy(int maxBufferSize)
	{
		return OnCreateBufferedCopy(maxBufferSize, XmlDictionaryReaderQuotas.Max);
	}

	internal BodyWriter OnCreateBufferedCopy(int maxBufferSize, XmlDictionaryReaderQuotas quotas)
	{
		XmlBuffer xmlBuffer = new XmlBuffer(maxBufferSize);
		using (XmlDictionaryWriter xmlDictionaryWriter = xmlBuffer.OpenSection(quotas))
		{
			xmlDictionaryWriter.WriteStartElement("a");
			OnWriteBodyContents(xmlDictionaryWriter);
			xmlDictionaryWriter.WriteEndElement();
		}
		xmlBuffer.CloseSection();
		xmlBuffer.Close();
		return new BufferedBodyWriter(xmlBuffer);
	}

	protected abstract void OnWriteBodyContents(XmlDictionaryWriter writer);

	protected virtual Task OnWriteBodyContentsAsync(XmlDictionaryWriter writer)
	{
		OnWriteBodyContents(writer);
		return Task.CompletedTask;
	}

	protected virtual IAsyncResult OnBeginWriteBodyContents(XmlDictionaryWriter writer, AsyncCallback callback, object state)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	protected virtual void OnEndWriteBodyContents(IAsyncResult result)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	private void EnsureWriteBodyContentsState(XmlDictionaryWriter writer)
	{
		if (writer == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("writer"));
		}
		if (IsBuffered)
		{
			return;
		}
		lock (_thisLock)
		{
			if (!_canWrite)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.BodyWriterCanOnlyBeWrittenOnce));
			}
			_canWrite = false;
		}
	}

	public void WriteBodyContents(XmlDictionaryWriter writer)
	{
		EnsureWriteBodyContentsState(writer);
		OnWriteBodyContents(writer);
	}

	internal Task WriteBodyContentsAsync(XmlDictionaryWriter writer)
	{
		EnsureWriteBodyContentsState(writer);
		return OnWriteBodyContentsAsync(writer);
	}

	public IAsyncResult BeginWriteBodyContents(XmlDictionaryWriter writer, AsyncCallback callback, object state)
	{
		EnsureWriteBodyContentsState(writer);
		return OnBeginWriteBodyContents(writer, callback, state);
	}

	public void EndWriteBodyContents(IAsyncResult result)
	{
		OnEndWriteBodyContents(result);
	}
}
