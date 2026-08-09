using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns54;

namespace buPop3.Mime.Header;

public class Received
{
	[CompilerGenerated]
	private DateTime dateTime_0;

	[CompilerGenerated]
	private Dictionary<string, string> dictionary_0;

	[CompilerGenerated]
	private string string_0;

	public DateTime Date
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		private set
		{
			dateTime_0 = value;
		}
	}

	public Dictionary<string, string> Names
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
		[CompilerGenerated]
		private set
		{
			dictionary_0 = value;
		}
	}

	public string Raw
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

	public Received(string headerValue)
	{
		if (headerValue != null)
		{
			Raw = headerValue;
			Date = DateTime.MinValue;
			if (headerValue.Contains(";"))
			{
				string text = headerValue.Substring(headerValue.LastIndexOf(";") + 1);
				Date = Class156.smethod_236(text);
			}
			Names = Class156.smethod_14(headerValue);
			return;
		}
		throw new ArgumentNullException("headerValue");
	}
}
