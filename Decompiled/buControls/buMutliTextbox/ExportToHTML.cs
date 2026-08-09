using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using ns27;

namespace buMutliTextbox;

public class ExportToHTML
{
	public string LineNumbersCSS = "<style type=\"text/css\"> .lineNumber{font-family : monospace; font-size : small; font-style : normal; font-weight : normal; color : Teal; background-color : ThreedFace;} </style>";

	[CompilerGenerated]
	private bool bool_0;

	[CompilerGenerated]
	private bool bool_1;

	[CompilerGenerated]
	private bool bool_2;

	[CompilerGenerated]
	private bool bool_3;

	[CompilerGenerated]
	private bool bool_4;

	[CompilerGenerated]
	private bool bool_5;

	private buMultiTextBox buMultiTextBox_0;

	public bool UseNbsp
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

	public bool UseForwardNbsp
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

	public bool UseOriginalFont
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool UseStyleTag
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public bool UseBr
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public bool IncludeLineNumbers
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public ExportToHTML()
	{
		UseNbsp = true;
		UseOriginalFont = true;
		UseStyleTag = true;
		UseBr = true;
	}

	public string GetHtml(buMultiTextBox tb)
	{
		buMultiTextBox_0 = tb;
		Range range = new Range(tb);
		range.SelectAll();
		return GetHtml(range);
	}

	public string GetHtml(Range r)
	{
		buMultiTextBox_0 = r.tb;
		Dictionary<StyleIndex, object> dictionary = new Dictionary<StyleIndex, object>();
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StyleIndex styleIndex = StyleIndex.None;
		r.Normalize();
		int iLine = r.Start.iLine;
		dictionary[StyleIndex.None] = null;
		if (UseOriginalFont)
		{
			stringBuilder.AppendFormat("<font style=\"font-family: {0}, monospace; font-size: {1}pt; line-height: {2}px;\">", r.tb.Font.Name, r.tb.Font.SizeInPoints, r.tb.CharHeight);
		}
		if (IncludeLineNumbers)
		{
			stringBuilder2.AppendFormat("<span class=lineNumber>{0}</span>  ", iLine + 1);
		}
		bool flag = false;
		foreach (Place item in (IEnumerable<Place>)r)
		{
			Char obj = r.tb[item.iLine][item.iChar];
			if (obj.style != styleIndex)
			{
				Class76.smethod_491(this, stringBuilder, stringBuilder2, styleIndex);
				styleIndex = obj.style;
				dictionary[styleIndex] = null;
			}
			if (item.iLine != iLine)
			{
				for (int i = iLine; i < item.iLine; i++)
				{
					stringBuilder2.Append((!UseBr) ? "\r\n" : "<br>");
					if (IncludeLineNumbers)
					{
						stringBuilder2.AppendFormat("<span class=lineNumber>{0}</span>  ", i + 2);
					}
				}
				iLine = item.iLine;
				flag = false;
			}
			switch (obj.c)
			{
			case '<':
				stringBuilder2.Append("&lt;");
				continue;
			case ' ':
				if ((!flag && UseForwardNbsp) || UseNbsp)
				{
					stringBuilder2.Append("&nbsp;");
					continue;
				}
				break;
			case '&':
				stringBuilder2.Append("&amp;");
				continue;
			case '>':
				stringBuilder2.Append("&gt;");
				continue;
			}
			flag = true;
			stringBuilder2.Append(obj.c);
		}
		Class76.smethod_491(this, stringBuilder, stringBuilder2, styleIndex);
		if (UseOriginalFont)
		{
			stringBuilder.Append("</font>");
		}
		if (UseStyleTag)
		{
			stringBuilder2.Length = 0;
			stringBuilder2.Append("<style type=\"text/css\">");
			foreach (StyleIndex key in dictionary.Keys)
			{
				stringBuilder2.AppendFormat(".fctb{0}{{ {1} }}\r\n", Class76.smethod_587(key, this), method_0(key));
			}
			stringBuilder2.Append("</style>");
			stringBuilder.Insert(0, stringBuilder2.ToString());
		}
		if (IncludeLineNumbers)
		{
			stringBuilder.Insert(0, LineNumbersCSS);
		}
		return stringBuilder.ToString();
	}

	internal string method_0(StyleIndex styleIndex_0)
	{
		List<Style> list = new List<Style>();
		TextStyle textStyle = null;
		int num = 1;
		bool flag = false;
		for (int i = 0; i < buMultiTextBox_0.Styles.Length; i++)
		{
			if (buMultiTextBox_0.Styles[i] != null && ((uint)styleIndex_0 & (uint)num) != 0 && buMultiTextBox_0.Styles[i].IsExportable)
			{
				Style style = buMultiTextBox_0.Styles[i];
				list.Add(style);
				if (style is TextStyle && (!flag || buMultiTextBox_0.AllowSeveralTextStyleDrawing))
				{
					flag = true;
					textStyle = style as TextStyle;
				}
			}
			num <<= 1;
		}
		string text = "";
		text = ((!flag) ? buMultiTextBox_0.DefaultStyle.GetCSS() : textStyle.GetCSS());
		foreach (Style item in list)
		{
			if (!(item is TextStyle))
			{
				text += item.GetCSS();
			}
		}
		return text;
	}

	public static string GetColorAsString(Color color)
	{
		if (!(color == Color.Transparent))
		{
			return $"#{color.R:x2}{color.G:x2}{color.B:x2}";
		}
		return "";
	}
}
