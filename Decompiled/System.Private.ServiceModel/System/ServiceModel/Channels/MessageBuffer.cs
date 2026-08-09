using System.IO;
using System.Xml;

namespace System.ServiceModel.Channels;

public abstract class MessageBuffer : IDisposable
{
	public abstract int BufferSize { get; }

	public virtual string MessageContentType => "application/soap+msbin1";

	void IDisposable.Dispose()
	{
		Close();
	}

	public abstract void Close();

	public virtual void WriteMessage(Stream stream)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("stream"));
		}
		Message message = CreateMessage();
		using (message)
		{
			XmlDictionaryWriter xmlDictionaryWriter = XmlDictionaryWriter.CreateBinaryWriter(stream, XD.Dictionary, null, ownsStream: false);
			using (xmlDictionaryWriter)
			{
				message.WriteMessage(xmlDictionaryWriter);
			}
		}
	}

	public abstract Message CreateMessage();

	internal Exception CreateBufferDisposedException()
	{
		return new ObjectDisposedException("", System.SR.MessageBufferIsClosed);
	}
}
