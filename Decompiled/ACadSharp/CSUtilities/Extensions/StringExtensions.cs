using System;
using System.Collections.Generic;
using System.Linq;

namespace CSUtilities.Extensions;

internal static class StringExtensions
{
	public static bool IsNull(this string str)
	{
		return str == null;
	}

	public static bool IsNullOrEmpty(this string str)
	{
		return string.IsNullOrEmpty(str);
	}

	public static bool IsNullOrWhiteSpace(this string str)
	{
		return string.IsNullOrWhiteSpace(str);
	}

	public static void TrowIfNullOrEmpty(this string str)
	{
		str.TrowIfNullOrEmpty("String cannot be null or empty");
	}

	public static void TrowIfNullOrEmpty(this string str, string message)
	{
		if (string.IsNullOrEmpty(str))
		{
			throw new ArgumentException(message);
		}
	}

	public static string[] GetLines(this string str)
	{
		if (str == null)
		{
			return null;
		}
		str = str.Replace("\r\n", "\n");
		string[] array = str.Split('\n');
		if (string.IsNullOrEmpty(array.Last()))
		{
			array = array.Take(array.Length - 1).ToArray();
		}
		return array;
	}

	public static bool IsNumeric(this string s)
	{
		double result;
		return double.TryParse(s, out result);
	}

	public static byte[] ToByteArray(this string str)
	{
		return (from x in Enumerable.Range(0, str.Length)
			where x % 2 == 0
			select Convert.ToByte(str.Substring(x, 2), 16)).ToArray();
	}

	public static string ReadBetween(this string str, char start, char end, bool keepTokens = false)
	{
		if (str.TryReadBetween(start, end, out var group, keepTokens))
		{
			return group;
		}
		throw new FormatException("Closing character not found, this is an open line.");
	}

	public static bool TryReadBetween(this string s, char start, char end, out string group, bool keepTokens = false)
	{
		Stack<int> stack = new Stack<int>();
		bool flag = true;
		group = "";
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == end && !flag)
			{
				stack.Pop();
				if (!stack.Any())
				{
					if (keepTokens)
					{
						group += s[i];
					}
					return true;
				}
			}
			if (s[i] == start)
			{
				stack.Push(i);
				if (flag)
				{
					if (keepTokens)
					{
						group += s[i];
					}
					flag = false;
					continue;
				}
			}
			if (!flag)
			{
				group += s[i];
			}
		}
		return false;
	}

	public static string ReadUntil(this string str, char c)
	{
		string residual;
		return str.ReadUntil(c, out residual);
	}

	public static string ReadUntil(this string str, char c, out string residual)
	{
		string text = "";
		residual = "";
		for (int i = 0; i < str.Length; i++)
		{
			if (str[i] == c)
			{
				residual += str.Substring(i);
				break;
			}
			text += str[i];
		}
		return text;
	}

	public static string RemoveStartWhiteSpaces(this string str)
	{
		while (str.StartsWith(" "))
		{
			str = str.Remove(0, 1);
		}
		return str;
	}

	public static string RemoveLast(this string str)
	{
		return str.Remove(str.Length - 1);
	}

	public static char? FirstEqual(this string str, IEnumerable<char> characters)
	{
		int? index;
		return str.FirstEqual(characters, out index);
	}

	public static char? FirstEqual(this string str, IEnumerable<char> characters, out int? index)
	{
		char? result = null;
		index = null;
		foreach (char character in characters)
		{
			int num = str.IndexOf(character);
			if ((!index.HasValue || num < index) && num > -1)
			{
				index = num;
				result = character;
			}
		}
		return result;
	}

	public static string[] ToArgs(this string str, bool keepCollons = false, bool ignoreEmpty = true)
	{
		return str.ToArgs(' ', '"', keepCollons, ignoreEmpty);
	}

	public static string[] ToArgs(this string str, char separator, bool keepCollons = false, bool ignoreEmpty = true)
	{
		return str.ToArgs(separator, '"', keepCollons, ignoreEmpty);
	}

	public static string[] ToArgs(this string str, char separator, char stringDelimitier, bool keepCollons = false, bool ignoreEmpty = true)
	{
		List<string> list = new List<string>();
		string text = "";
		bool flag = false;
		for (int i = 0; i < str.Length; i++)
		{
			char c = str[i];
			if (c == stringDelimitier)
			{
				flag = !flag;
				if (keepCollons)
				{
					text += c;
				}
			}
			else if (c == separator && !flag)
			{
				if (!(string.IsNullOrEmpty(text) && ignoreEmpty))
				{
					list.Add(text);
					text = "";
				}
			}
			else
			{
				text += c;
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			if (!ignoreEmpty)
			{
				list.Add(text);
			}
		}
		else
		{
			list.Add(text);
		}
		return list.ToArray();
	}

	public static char? TryGet(this string str, int index)
	{
		if (index < 0 || index >= str.Length)
		{
			return null;
		}
		return str[index];
	}

	public static string[] ToArgs(this string str, char separator, IDictionary<char, char> groupDelimitiers, bool keepTokens = false)
	{
		List<string> list = new List<string>();
		List<char> list2 = new List<char>(groupDelimitiers.Keys);
		list2.Add(separator);
		for (int i = 0; i < str.Length; i++)
		{
			str.Substring(i);
			int? index;
			char? c = str.Substring(i).FirstEqual(list2, out index);
			if (!c.HasValue)
			{
				string text = str.Substring(i);
				list.Add(text);
				i += text.Length;
			}
			else if (c == separator)
			{
				string text2 = str.SubstringByIndex(i, i + index.Value);
				if (!string.IsNullOrEmpty(text2))
				{
					list.Add(text2);
					i += text2.Length;
				}
			}
			else if (groupDelimitiers.ContainsKey(c.Value))
			{
				string text3 = str.Substring(i + index.Value).ReadBetween(c.Value, groupDelimitiers[c.Value], keepTokens);
				list.Add(str.Substring(i).ReadUntil(c.Value) + text3);
				i += text3.Length;
			}
		}
		return list.ToArray();
	}

	public static string SubstringByIndex(this string s, int startIndex, int endIndex)
	{
		return s.Remove(endIndex).Substring(startIndex);
	}
}
