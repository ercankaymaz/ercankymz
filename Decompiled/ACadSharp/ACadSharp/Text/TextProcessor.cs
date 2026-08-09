using System;
using System.Collections.Generic;
using System.Text;
using CSUtilities.Extensions;

namespace ACadSharp.Text;

public static class TextProcessor
{
	public static string Parse(string text, out List<string> groups)
	{
		groups = new List<string>();
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int end = 0;
		while (end < text.Length)
		{
			char? c = text.TryGet(end - 1);
			char? c2 = text.TryGet(end);
			char? c3 = text.TryGet(end + 1);
			if (c2 == '\\' && c3.HasValue)
			{
				switch (c3)
				{
				case '\\':
				case '{':
				case '}':
					stringBuilder.Append(c3);
					end += 2;
					break;
				case 'C':
				case 'c':
					processColor(text, end, out end);
					break;
				case 'F':
				case 'f':
					processFont(text, end, out end);
					break;
				case 'H':
				case 'h':
					processHeight(text, end, out end);
					break;
				case 'p':
					processJustification(text, end, out end);
					break;
				case 'P':
				case 'n':
					stringBuilder.Append(Environment.NewLine);
					end += 2;
					break;
				default:
					end++;
					break;
				}
			}
			else if (c2 == '{' && c != '\\')
			{
				end++;
			}
			else if (c2 == '}' && c != '\\')
			{
				end++;
			}
			else
			{
				stringBuilder.Append(c2);
				end++;
			}
		}
		return stringBuilder.ToString();
	}

	public static string Unescape(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		bool flag = false;
		while (num < text.Length)
		{
			int num2 = text.IndexOf("\\", num);
			if (num2 <= 0)
			{
				string text2 = text.Substring(num, text.Length - num);
				if (flag && text2.Contains("}"))
				{
					text2 = text2.Replace("}", string.Empty);
					flag = false;
				}
				stringBuilder.Append(text2);
				break;
			}
			char num3 = text[num2 - 1];
			_ = text[num2];
			char c = text[num2 + 1];
			if (num3 == '{')
			{
				num2--;
				flag = true;
			}
			if (num2 > num)
			{
				string text3 = text.Substring(num, num2 - num);
				if (flag && text3.Contains("}"))
				{
					text3 = text3.Replace("}", string.Empty);
					flag = false;
				}
				stringBuilder.Append(text3);
			}
			int end;
			switch (c)
			{
			case 'F':
			case 'f':
				processFont(text, num2, out end);
				num2 = end;
				break;
			case 'C':
			case 'c':
				processColor(text, num2, out end);
				num2 = end;
				break;
			case 'P':
			case 'n':
				stringBuilder.Append(Environment.NewLine);
				num2 += 2;
				break;
			case '\\':
			case '{':
			case '}':
				stringBuilder.Append(c);
				break;
			}
			num = num2;
		}
		return stringBuilder.ToString();
	}

	private static void processFont(string text, int start, out int end)
	{
		end = text.IndexOf(';', start);
		end++;
		string[] array = text.Substring(start, end - start).Split('|');
		FontData fontData = new FontData
		{
			Name = array[0]
		};
	}

	private static void processColor(string text, int start, out int end)
	{
		end = text.IndexOf(';', start);
		end++;
	}

	private static void processHeight(string text, int start, out int end)
	{
		end = text.IndexOf(';', start);
		end++;
	}

	private static void processJustification(string text, int start, out int end)
	{
		end = text.IndexOf(';', start);
		end++;
	}
}
