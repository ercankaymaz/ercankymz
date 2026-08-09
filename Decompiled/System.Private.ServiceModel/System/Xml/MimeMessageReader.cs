using System.IO;
using System.ServiceModel;

namespace System.Xml;

internal class MimeMessageReader
{
	private static byte[] CRLFCRLF = new byte[4] { 13, 10, 13, 10 };

	private bool getContentStreamCalled;

	private MimeHeaderReader mimeHeaderReader;

	private DelimittedStreamReader reader;

	public MimeMessageReader(Stream stream)
	{
		if (stream == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
		}
		reader = new DelimittedStreamReader(stream);
		mimeHeaderReader = new MimeHeaderReader(reader.GetNextStream(CRLFCRLF));
	}

	public Stream GetContentStream()
	{
		if (getContentStreamCalled)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.MimeMessageGetContentStreamCalledAlready));
		}
		mimeHeaderReader.Close();
		Stream nextStream = reader.GetNextStream(null);
		getContentStreamCalled = true;
		return nextStream;
	}

	public MimeHeaders ReadHeaders(int maxBuffer, ref int remaining)
	{
		MimeHeaders mimeHeaders = new MimeHeaders();
		while (mimeHeaderReader.Read(maxBuffer, ref remaining))
		{
			mimeHeaders.Add(mimeHeaderReader.Name, mimeHeaderReader.Value, ref remaining);
		}
		return mimeHeaders;
	}
}
