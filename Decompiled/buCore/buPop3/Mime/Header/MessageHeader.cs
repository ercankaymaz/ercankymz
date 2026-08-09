using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using ns54;

namespace buPop3.Mime.Header;

public sealed class MessageHeader
{
	[CompilerGenerated]
	private NameValueCollection nameValueCollection_0;

	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private List<string> list_0;

	[CompilerGenerated]
	private List<RfcMailAddress> list_1;

	[CompilerGenerated]
	private List<Received> list_2;

	[CompilerGenerated]
	private MailPriority mailPriority_0;

	[CompilerGenerated]
	private ContentTransferEncoding contentTransferEncoding_0;

	[CompilerGenerated]
	private List<RfcMailAddress> list_3;

	[CompilerGenerated]
	private List<RfcMailAddress> list_4;

	[CompilerGenerated]
	private List<RfcMailAddress> list_5;

	[CompilerGenerated]
	private RfcMailAddress rfcMailAddress_0;

	[CompilerGenerated]
	private RfcMailAddress rfcMailAddress_1;

	[CompilerGenerated]
	private List<string> list_6;

	[CompilerGenerated]
	private List<string> list_7;

	[CompilerGenerated]
	private RfcMailAddress rfcMailAddress_2;

	[CompilerGenerated]
	private ContentType contentType_0;

	[CompilerGenerated]
	private ContentDisposition contentDisposition_0;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private string string_3;

	[CompilerGenerated]
	private string string_4;

	[CompilerGenerated]
	private RfcMailAddress rfcMailAddress_3;

	[CompilerGenerated]
	private string string_5;

	public NameValueCollection UnknownHeaders
	{
		[CompilerGenerated]
		get
		{
			return nameValueCollection_0;
		}
		[CompilerGenerated]
		private set
		{
			nameValueCollection_0 = value;
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
		internal set
		{
			string_0 = value;
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
		internal set
		{
			string_1 = value;
		}
	}

	public List<string> Keywords
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

	public List<RfcMailAddress> DispositionNotificationTo
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		internal set
		{
			list_1 = value;
		}
	}

	public List<Received> Received
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		private set
		{
			list_2 = value;
		}
	}

	public MailPriority Importance
	{
		[CompilerGenerated]
		get
		{
			return mailPriority_0;
		}
		[CompilerGenerated]
		internal set
		{
			mailPriority_0 = value;
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
		internal set
		{
			contentTransferEncoding_0 = value;
		}
	}

	public List<RfcMailAddress> Cc
	{
		[CompilerGenerated]
		get
		{
			return list_3;
		}
		[CompilerGenerated]
		internal set
		{
			list_3 = value;
		}
	}

	public List<RfcMailAddress> Bcc
	{
		[CompilerGenerated]
		get
		{
			return list_4;
		}
		[CompilerGenerated]
		internal set
		{
			list_4 = value;
		}
	}

	public List<RfcMailAddress> To
	{
		[CompilerGenerated]
		get
		{
			return list_5;
		}
		[CompilerGenerated]
		internal set
		{
			list_5 = value;
		}
	}

	public RfcMailAddress From
	{
		[CompilerGenerated]
		get
		{
			return rfcMailAddress_0;
		}
		[CompilerGenerated]
		internal set
		{
			rfcMailAddress_0 = value;
		}
	}

	public RfcMailAddress ReplyTo
	{
		[CompilerGenerated]
		get
		{
			return rfcMailAddress_1;
		}
		[CompilerGenerated]
		internal set
		{
			rfcMailAddress_1 = value;
		}
	}

	public List<string> InReplyTo
	{
		[CompilerGenerated]
		get
		{
			return list_6;
		}
		[CompilerGenerated]
		internal set
		{
			list_6 = value;
		}
	}

	public List<string> References
	{
		[CompilerGenerated]
		get
		{
			return list_7;
		}
		[CompilerGenerated]
		internal set
		{
			list_7 = value;
		}
	}

	public RfcMailAddress Sender
	{
		[CompilerGenerated]
		get
		{
			return rfcMailAddress_2;
		}
		[CompilerGenerated]
		internal set
		{
			rfcMailAddress_2 = value;
		}
	}

	public ContentType ContentType
	{
		[CompilerGenerated]
		get
		{
			return contentType_0;
		}
		[CompilerGenerated]
		internal set
		{
			contentType_0 = value;
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
		internal set
		{
			contentDisposition_0 = value;
		}
	}

	public string Date
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		internal set
		{
			string_2 = value;
		}
	}

	public DateTime DateSent
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		internal set
		{
			dateTime_0 = value;
		}
	}

	public string MessageId
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		internal set
		{
			string_3 = value;
		}
	}

	public string MimeVersion
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		internal set
		{
			string_4 = value;
		}
	}

	public RfcMailAddress ReturnPath
	{
		[CompilerGenerated]
		get
		{
			return rfcMailAddress_3;
		}
		[CompilerGenerated]
		internal set
		{
			rfcMailAddress_3 = value;
		}
	}

	public string Subject
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		internal set
		{
			string_5 = value;
		}
	}

	internal MessageHeader(NameValueCollection nameValueCollection_1)
	{
		if (nameValueCollection_1 == null)
		{
			throw new ArgumentNullException("headers");
		}
		To = new List<RfcMailAddress>(0);
		Cc = new List<RfcMailAddress>(0);
		Bcc = new List<RfcMailAddress>(0);
		Received = new List<Received>();
		Keywords = new List<string>();
		InReplyTo = new List<string>(0);
		References = new List<string>(0);
		DispositionNotificationTo = new List<RfcMailAddress>();
		UnknownHeaders = new NameValueCollection();
		Importance = MailPriority.Normal;
		ContentTransferEncoding = ContentTransferEncoding.SevenBit;
		ContentType = new ContentType("text/plain; charset=us-ascii");
		Class156.smethod_244(this, nameValueCollection_1);
	}
}
