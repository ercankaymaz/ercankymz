using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using buPop3.Mime.Header;
using ns54;

namespace buPop3.Mime;

public class MessagePart
{
	[CompilerGenerated]
	private ContentType contentType_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private ContentTransferEncoding contentTransferEncoding_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private ContentDisposition contentDisposition_0;

	[CompilerGenerated]
	private Encoding encoding_0;

	[CompilerGenerated]
	private byte[] byte_0;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private List<MessagePart> list_0;

	public ContentType ContentType
	{
		[CompilerGenerated]
		get
		{
			return contentType_0;
		}
		[CompilerGenerated]
		private set
		{
			contentType_0 = value;
		}
	}

	public string ContentDescription
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		private set
		{
			string_0 = value;
		}
	}

	public ContentTransferEncoding ContentTransferEncoding
	{
		[CompilerGenerated]
		get
		{
			return contentTransferEncoding_0;
		}
		[CompilerGenerated]
		private set
		{
			contentTransferEncoding_0 = value;
		}
	}

	public string ContentId
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		private set
		{
			string_1 = value;
		}
	}

	public ContentDisposition ContentDisposition
	{
		[CompilerGenerated]
		get
		{
			return contentDisposition_0;
		}
		[CompilerGenerated]
		private set
		{
			contentDisposition_0 = value;
		}
	}

	public Encoding BodyEncoding
	{
		[CompilerGenerated]
		get
		{
			return encoding_0;
		}
		[CompilerGenerated]
		private set
		{
			encoding_0 = value;
		}
	}

	public byte[] Body
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		internal set
		{
			byte_0 = value;
		}
	}

	public bool IsMultiPart => ContentType.MediaType.StartsWith("multipart/", StringComparison.OrdinalIgnoreCase);

	public bool IsText
	{
		get
		{
			string mediaType = ContentType.MediaType;
			return mediaType.StartsWith("text/", StringComparison.OrdinalIgnoreCase) || mediaType.Equals("message/rfc822", StringComparison.OrdinalIgnoreCase);
		}
	}

	public bool IsAttachment => (!IsText && !IsMultiPart) || (ContentDisposition != null && !ContentDisposition.Inline);

	public string FileName
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		private set
		{
			string_2 = value;
		}
	}

	public List<MessagePart> MessageParts
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		private set
		{
			list_0 = value;
		}
	}

	internal MessagePart(byte[] byte_1, MessageHeader messageHeader_0)
	{
		if (byte_1 != null)
		{
			if (messageHeader_0 == null)
			{
				throw new ArgumentNullException("headers");
			}
			ContentType = messageHeader_0.ContentType;
			ContentDescription = messageHeader_0.ContentDescription;
			ContentTransferEncoding = messageHeader_0.ContentTransferEncoding;
			ContentId = messageHeader_0.ContentId;
			ContentDisposition = messageHeader_0.ContentDisposition;
			ContentType contentType = ContentType;
			ContentDisposition contentDisposition = ContentDisposition;
			string text = "(no name)";
			FileName = Class156.smethod_147(text, contentDisposition, contentType);
			BodyEncoding = Class156.smethod_268(ContentType.CharSet);
			Class156.smethod_274(this, byte_1);
			return;
		}
		throw new ArgumentNullException("rawBody");
	}

	internal void method_0(byte[] byte_1)
	{
		string boundary = ContentType.Boundary;
		List<byte[]> list = Class156.smethod_0(boundary, byte_1);
		MessageParts = new List<MessagePart>(list.Count);
		foreach (byte[] item2 in list)
		{
			MessagePart item = Class156.smethod_169(item2);
			MessageParts.Add(item);
		}
	}

	public string GetBodyAsText()
	{
		return BodyEncoding.GetString(Body);
	}

	public void Save(FileInfo file)
	{
		if (file != null)
		{
			using (FileStream messageStream = new FileStream(file.FullName, FileMode.Create))
			{
				Save(messageStream);
				return;
			}
		}
		throw new ArgumentNullException("file");
	}

	public void Save(Stream messageStream)
	{
		if (messageStream == null)
		{
			throw new ArgumentNullException("messageStream");
		}
		messageStream.Write(Body, 0, Body.Length);
	}
}
