using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using buPop3.Mime.Header;
using ns48;
using ns50;
using ns51;
using ns54;

namespace buPop3.Mime;

public class Message
{
	[CompilerGenerated]
	private MessageHeader messageHeader_0;

	[CompilerGenerated]
	private MessagePart messagePart_0;

	[CompilerGenerated]
	private byte[] byte_0;

	public MessageHeader Headers
	{
		[CompilerGenerated]
		get
		{
			return messageHeader_0;
		}
		[CompilerGenerated]
		private set
		{
			messageHeader_0 = value;
		}
	}

	public MessagePart MessagePart
	{
		[CompilerGenerated]
		get
		{
			return messagePart_0;
		}
		[CompilerGenerated]
		private set
		{
			messagePart_0 = value;
		}
	}

	public byte[] RawMessage
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		private set
		{
			byte_0 = value;
		}
	}

	public Message(byte[] rawMessageContent)
		: this(rawMessageContent, parseBody: true)
	{
	}

	public Message(byte[] rawMessageContent, bool parseBody)
	{
		RawMessage = rawMessageContent;
		byte[] byte_ = default(byte[]);
		Class156.smethod_191(ref byte_, out MessageHeader headers, rawMessageContent);
		Headers = headers;
		if (parseBody)
		{
			MessagePart = new MessagePart(byte_, Headers);
		}
	}

	public MailMessage ToMailMessage()
	{
		MailMessage mailMessage = new MailMessage();
		mailMessage.Subject = Headers.Subject;
		mailMessage.SubjectEncoding = Encoding.UTF8;
		MessagePart messagePart = FindFirstHtmlVersion();
		if (messagePart == null)
		{
			messagePart = FindFirstPlainTextVersion();
		}
		else
		{
			mailMessage.IsBodyHtml = true;
		}
		if (messagePart != null)
		{
			mailMessage.Body = messagePart.GetBodyAsText();
			mailMessage.BodyEncoding = messagePart.BodyEncoding;
		}
		IEnumerable<MessagePart> enumerable = FindAllTextVersions();
		foreach (MessagePart item in enumerable)
		{
			if (item != messagePart)
			{
				MemoryStream contentStream = new MemoryStream(item.Body);
				AlternateView alternateView = new AlternateView(contentStream);
				alternateView.ContentId = item.ContentId;
				alternateView.ContentType = item.ContentType;
				mailMessage.AlternateViews.Add(alternateView);
			}
		}
		IEnumerable<MessagePart> enumerable2 = FindAllAttachments();
		foreach (MessagePart item2 in enumerable2)
		{
			MemoryStream contentStream2 = new MemoryStream(item2.Body);
			Attachment attachment = new Attachment(contentStream2, item2.ContentType);
			attachment.ContentId = item2.ContentId;
			mailMessage.Attachments.Add(attachment);
		}
		if (Headers.From != null && Headers.From.HasValidMailAddress)
		{
			mailMessage.From = Headers.From.MailAddress;
		}
		if (Headers.ReplyTo != null && Headers.ReplyTo.HasValidMailAddress)
		{
			mailMessage.ReplyToList.Add(Headers.ReplyTo.MailAddress);
		}
		if (Headers.Sender != null && Headers.Sender.HasValidMailAddress)
		{
			mailMessage.Sender = Headers.Sender.MailAddress;
		}
		foreach (RfcMailAddress item3 in Headers.To)
		{
			if (item3.HasValidMailAddress)
			{
				mailMessage.To.Add(item3.MailAddress);
			}
		}
		foreach (RfcMailAddress item4 in Headers.Cc)
		{
			if (item4.HasValidMailAddress)
			{
				mailMessage.CC.Add(item4.MailAddress);
			}
		}
		foreach (RfcMailAddress item5 in Headers.Bcc)
		{
			if (item5.HasValidMailAddress)
			{
				mailMessage.Bcc.Add(item5.MailAddress);
			}
		}
		return mailMessage;
	}

	public MessagePart FindFirstPlainTextVersion()
	{
		return FindFirstMessagePartWithMediaType("text/plain");
	}

	public MessagePart FindFirstHtmlVersion()
	{
		return FindFirstMessagePartWithMediaType("text/html");
	}

	public List<MessagePart> FindAllTextVersions()
	{
		return new Class133().VisitMessage(this);
	}

	public List<MessagePart> FindAllAttachments()
	{
		return new Class132().VisitMessage(this);
	}

	public MessagePart FindFirstMessagePartWithMediaType(string mediaType)
	{
		return new Class135().VisitMessage(this, mediaType);
	}

	public List<MessagePart> FindAllMessagePartsWithMediaType(string mediaType)
	{
		return new Class134().VisitMessage(this, mediaType);
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
		messageStream.Write(RawMessage, 0, RawMessage.Length);
	}

	public static Message Load(FileInfo file)
	{
		if (file != null)
		{
			if (file.Exists)
			{
				using (FileStream messageStream = new FileStream(file.FullName, FileMode.Open))
				{
					return Load(messageStream);
				}
			}
			throw new FileNotFoundException("Cannot load message from non-existent file", file.FullName);
		}
		throw new ArgumentNullException("file");
	}

	public static Message Load(Stream messageStream)
	{
		if (messageStream != null)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				byte[] buffer = new byte[4096];
				int count;
				while ((count = messageStream.Read(buffer, 0, 4096)) > 0)
				{
					memoryStream.Write(buffer, 0, count);
				}
				byte[] rawMessageContent = memoryStream.ToArray();
				return new Message(rawMessageContent);
			}
		}
		throw new ArgumentNullException("messageStream");
	}
}
