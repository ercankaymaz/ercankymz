using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DevAge.Windows.Forms;

public static class RichTextConversion
{
	public static RichText StringToRichText(string txt)
	{
		return StringToRichText(txt, FontStyle.Regular);
	}

	public static RichText StringToRichText(string txt, FontStyle fontStyle)
	{
		string empty = string.Empty;
		RichTextBox richTextBox = new RichTextBox();
		try
		{
			richTextBox.Text = txt;
			if (fontStyle != FontStyle.Regular)
			{
				richTextBox.Font = new Font(richTextBox.Font, fontStyle);
			}
			empty = richTextBox.Rtf;
		}
		catch (Exception)
		{
			richTextBox.Text = string.Empty;
			empty = richTextBox.Rtf;
		}
		richTextBox.Dispose();
		return new RichText(empty);
	}

	public static string RichTextToString(RichText rtf)
	{
		string result = string.Empty;
		RichTextBox richTextBox = new RichTextBox();
		try
		{
			richTextBox.Rtf = rtf.Rtf;
			result = richTextBox.Text;
		}
		catch (Exception)
		{
		}
		richTextBox.Dispose();
		return result;
	}

	public static string RichTextToStringStripWhitespaces(RichText rtf)
	{
		return Regex.Replace(RichTextToString(rtf), "[\\t\\n\\r\\f\\v]", string.Empty);
	}
}
