using System;
using System.Collections.Generic;
using System.Net.Mime;
using ns54;

namespace ns47;

internal static class Class137
{
	public static ContentType smethod_0(string string_0)
	{
		if (string_0 != null)
		{
			ContentType contentType = new ContentType();
			List<KeyValuePair<string, string>> list = Class141.smethod_0(string_0);
			foreach (KeyValuePair<string, string> item in list)
			{
				string text = item.Key.ToUpperInvariant().Trim();
				string text2 = Class156.smethod_10(item.Value.Trim());
				string text3 = text;
				string text4 = text3;
				if (text4 == null || text4.Length != 0)
				{
					switch (text4)
					{
					case "BOUNDARY":
						contentType.Boundary = text2;
						continue;
					case "CHARSET":
						contentType.CharSet = text2;
						continue;
					case "NAME":
						contentType.Name = Class156.smethod_179(text2);
						continue;
					}
					if (contentType.Parameters != null)
					{
						contentType.Parameters.Add(text, text2);
						continue;
					}
					throw new Exception("The ContentType parameters property is null. This will never be thrown.");
				}
				if (text2.ToUpperInvariant().Equals("TEXT"))
				{
					text2 = "text/plain";
				}
				contentType.MediaType = text2;
			}
			return contentType;
		}
		throw new ArgumentNullException("headerValue");
	}

	public static ContentDisposition smethod_1(string string_0)
	{
		if (string_0 != null)
		{
			ContentDisposition contentDisposition = new ContentDisposition();
			List<KeyValuePair<string, string>> list = Class141.smethod_0(string_0);
			foreach (KeyValuePair<string, string> item in list)
			{
				string text = item.Key.ToUpperInvariant().Trim();
				string text2 = Class156.smethod_10(item.Value.Trim());
				string text3 = text;
				string text4 = text3;
				uint num = Class156.smethod_119(text4);
				if (num > 1871182975)
				{
					if (num > 2878731272u)
					{
						if (num == 3159649708u)
						{
							if (text4 == "READ-DATE")
							{
								DateTime readDate = new DateTime(Class156.smethod_236(text2).Ticks);
								contentDisposition.ReadDate = readDate;
								continue;
							}
						}
						else if (num == 4267520964u && text4 == "MODIFICATION-DATE")
						{
							DateTime modificationDate = new DateTime(Class156.smethod_236(text2).Ticks);
							contentDisposition.ModificationDate = modificationDate;
							continue;
						}
					}
					else if (num == 2166136261u)
					{
						if (text4 != null && text4.Length == 0)
						{
							contentDisposition.DispositionType = text2;
							continue;
						}
					}
					else if (num == 2878731272u && text4 == "FILENAME")
					{
						goto IL_00e2;
					}
				}
				else if (num == 1387956774)
				{
					if (text4 == "NAME")
					{
						goto IL_00e2;
					}
				}
				else
				{
					switch (num)
					{
					case 1636987420u:
						if (text4 == "SIZE")
						{
							contentDisposition.Size = Class156.smethod_265(text2);
							continue;
						}
						break;
					case 1871182975u:
						if (text4 == "CREATION-DATE")
						{
							DateTime creationDate = new DateTime(Class156.smethod_236(text2).Ticks);
							contentDisposition.CreationDate = creationDate;
							continue;
						}
						break;
					}
				}
				if (!text.StartsWith("X-"))
				{
					throw new ArgumentException("Unknown parameter in Content-Disposition. Ask developer to fix! Parameter: " + text);
				}
				contentDisposition.Parameters.Add(text, text2);
				continue;
				IL_00e2:
				contentDisposition.FileName = Class156.smethod_179(text2);
			}
			return contentDisposition;
		}
		throw new ArgumentNullException("headerValue");
	}
}
