using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ns54;

internal static class Class141
{
	public static List<KeyValuePair<string, string>> smethod_0(string string_0)
	{
		if (string_0 != null)
		{
			string_0 = Regex.Replace(string_0, "=\\s*\"(?<value>[^\"]*)\"\\s", "=\"${value}\"; ");
			string_0 = Regex.Replace(string_0, "^(?<first>[^;\\s]+)\\s(?<second>[^;\\s]+)", "${first}; ${second}");
			List<string> list = Class156.smethod_189(';', string_0.Trim());
			List<KeyValuePair<string, string>> list2 = new List<KeyValuePair<string, string>>(list.Count);
			foreach (string item in list)
			{
				if (item.Trim().Length == 0)
				{
					continue;
				}
				string[] array = item.Trim().Split(new char[1] { '=' }, 2);
				if (array.Length != 1)
				{
					if (array.Length != 2)
					{
						throw new ArgumentException("When splitting the part \"" + item + "\" by = there was " + array.Length + " parts. Only 1 and 2 are supported");
					}
					list2.Add(new KeyValuePair<string, string>(array[0], array[1]));
				}
				else
				{
					list2.Add(new KeyValuePair<string, string>("", array[0]));
				}
			}
			return smethod_1(list2);
		}
		throw new ArgumentNullException("toDecode");
	}

	private static List<KeyValuePair<string, string>> smethod_1(List<KeyValuePair<string, string>> list_0)
	{
		if (list_0 != null)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>(list_0.Count);
			int count = list_0.Count;
			string string_ = default(string);
			for (int i = 0; i < count; i++)
			{
				KeyValuePair<string, string> item = list_0[i];
				string key = item.Key;
				string text = Class156.smethod_10(item.Value);
				if (!key.EndsWith("*0", StringComparison.OrdinalIgnoreCase) && !key.EndsWith("*0*", StringComparison.OrdinalIgnoreCase))
				{
					if (!key.EndsWith("*", StringComparison.OrdinalIgnoreCase))
					{
						list.Add(item);
						continue;
					}
					key = key.Replace("*", "");
					text = Class156.smethod_229(ref string_, text);
					list.Add(new KeyValuePair<string, string>(key, text));
					continue;
				}
				string string_2 = "notEncoded - Value here is never used";
				if (!key.EndsWith("*0*", StringComparison.OrdinalIgnoreCase))
				{
					key = key.Replace("*0", "");
				}
				else
				{
					text = Class156.smethod_229(ref string_2, text);
					key = key.Replace("*0*", "");
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(text);
				int num = i + 1;
				int num2 = 1;
				while (num < count)
				{
					string key2 = list_0[num].Key;
					string text2 = Class156.smethod_10(list_0[num].Value);
					if (!key2.Equals(key + "*" + num2))
					{
						if (!key2.Equals(key + "*" + num2 + "*"))
						{
							break;
						}
						if (string_2 != null)
						{
							text2 = Class156.smethod_72(string_2, text2);
						}
						stringBuilder.Append(text2);
						i++;
					}
					else
					{
						stringBuilder.Append(text2);
						i++;
					}
					num++;
					num2++;
				}
				text = stringBuilder.ToString();
				list.Add(new KeyValuePair<string, string>(key, text));
			}
			return list;
		}
		throw new ArgumentNullException("pairs");
	}
}
