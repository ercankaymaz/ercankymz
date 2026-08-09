using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using ns27;

namespace buMutliTextbox;

public class ExportToRTF
{
	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	internal buMultiTextBox buMultiTextBox_0;

	internal Dictionary<Color, int> dictionary_0 = new Dictionary<Color, int>();

	public bool IncludeLineNumbers
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public bool UseOriginalFont
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public ExportToRTF()
	{
		UseOriginalFont = true;
	}

	public string GetRtf(buMultiTextBox tb)
	{
		buMultiTextBox_0 = tb;
		Range range = new Range(tb);
		range.SelectAll();
		return GetRtf(range);
	}

	public string GetRtf(Range r)
	{
		buMultiTextBox_0 = r.tb;
		Dictionary<StyleIndex, object> dictionary = new Dictionary<StyleIndex, object>();
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StyleIndex styleIndex = StyleIndex.None;
		r.Normalize();
		int iLine = r.Start.iLine;
		dictionary[StyleIndex.None] = null;
		dictionary_0.Clear();
		int num = Class76.smethod_168(this, r.tb.LineNumberColor);
		if (IncludeLineNumbers)
		{
			stringBuilder2.AppendFormat("{{\\cf{1} {0}}}\\tab", iLine + 1, num);
		}
		foreach (Place item in (IEnumerable<Place>)r)
		{
			Char obj = r.tb[item.iLine][item.iChar];
			if (obj.style != styleIndex)
			{
				Class76.smethod_573(this, stringBuilder, stringBuilder2, styleIndex);
				styleIndex = obj.style;
				dictionary[styleIndex] = null;
			}
			if (item.iLine != iLine)
			{
				for (int i = iLine; i < item.iLine; i++)
				{
					stringBuilder2.AppendLine("\\line");
					if (IncludeLineNumbers)
					{
						stringBuilder2.AppendFormat("{{\\cf{1} {0}}}\\tab", i + 2, num);
					}
				}
				iLine = item.iLine;
			}
			switch (obj.c)
			{
			case '\\':
				stringBuilder2.Append("\\\\");
				continue;
			case '{':
				stringBuilder2.Append("\\{");
				continue;
			case '}':
				stringBuilder2.Append("\\}");
				continue;
			}
			char c = obj.c;
			int num2 = c;
			if (num2 >= 128)
			{
				stringBuilder2.AppendFormat("{{\\u{0}}}", num2);
			}
			else
			{
				stringBuilder2.Append(obj.c);
			}
		}
		Class76.smethod_573(this, stringBuilder, stringBuilder2, styleIndex);
		SortedList<int, Color> sortedList = new SortedList<int, Color>();
		foreach (KeyValuePair<Color, int> item2 in dictionary_0)
		{
			sortedList.Add(item2.Value, item2.Key);
		}
		stringBuilder2.Length = 0;
		stringBuilder2.AppendFormat("{{\\colortbl;");
		foreach (KeyValuePair<int, Color> item3 in sortedList)
		{
			stringBuilder2.Append(GetColorAsString(item3.Value) + ";");
		}
		stringBuilder2.AppendLine("}");
		if (UseOriginalFont)
		{
			stringBuilder.Insert(0, string.Format("{{\\fonttbl{{\\f0\\fmodern {0};}}}}{{\\fs{1} ", buMultiTextBox_0.Font.Name, (int)(2f * buMultiTextBox_0.Font.SizeInPoints), buMultiTextBox_0.CharHeight));
			stringBuilder.AppendLine("}");
		}
		stringBuilder.Insert(0, stringBuilder2.ToString());
		stringBuilder.Insert(0, "{\\rtf1\\ud\\deff0");
		stringBuilder.AppendLine("}");
		return stringBuilder.ToString();
	}

	public static string GetColorAsString(Color color)
	{
		if (!(color == Color.Transparent))
		{
			return $"\\red{color.R}\\green{color.G}\\blue{color.B}";
		}
		return "";
	}
}
