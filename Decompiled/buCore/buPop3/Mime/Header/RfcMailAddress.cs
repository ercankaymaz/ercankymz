using System;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace buPop3.Mime.Header;

public class RfcMailAddress
{
	[CompilerGenerated]
	private string string_0;

	[CompilerGenerated]
	private string string_1;

	[CompilerGenerated]
	private string string_2;

	[CompilerGenerated]
	private MailAddress mailAddress_0;

	public string Address
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

	public string DisplayName
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

	public string Raw
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

	public MailAddress MailAddress
	{
		[CompilerGenerated]
		get
		{
			return mailAddress_0;
		}
		[CompilerGenerated]
		private set
		{
			mailAddress_0 = value;
		}
	}

	public bool HasValidMailAddress => MailAddress != null;

	internal RfcMailAddress(MailAddress mailAddress_1, string string_3)
	{
		if (mailAddress_1 != null)
		{
			if (string_3 == null)
			{
				throw new ArgumentNullException("raw");
			}
			MailAddress = mailAddress_1;
			Address = mailAddress_1.Address;
			DisplayName = mailAddress_1.DisplayName;
			Raw = string_3;
			return;
		}
		throw new ArgumentNullException("mailAddress");
	}

	internal RfcMailAddress(string string_3)
	{
		if (string_3 == null)
		{
			throw new ArgumentNullException("raw");
		}
		MailAddress = null;
		Address = string.Empty;
		DisplayName = string_3;
		Raw = string_3;
	}

	public override string ToString()
	{
		if (!HasValidMailAddress)
		{
			return Raw;
		}
		return MailAddress.ToString();
	}
}
