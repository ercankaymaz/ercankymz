using System;

namespace DevAge.Windows.Forms;

[Serializable]
public class RichText : IComparable<RichText>, IComparable
{
	private string m_Rtf = string.Empty;

	public string Rtf
	{
		get
		{
			return m_Rtf;
		}
		set
		{
			m_Rtf = value;
		}
	}

	public RichText(string rtf)
	{
		m_Rtf = rtf;
	}

	public RichText(RichText other)
	{
		Rtf = other.Rtf;
	}

	public int CompareTo(object obj)
	{
		RichText other = obj as RichText;
		return CompareTo(other);
	}

	public int CompareTo(RichText other)
	{
		string text = RichTextConversion.RichTextToString(this);
		string strB = RichTextConversion.RichTextToString(other);
		return text.CompareTo(strB);
	}

	public override string ToString()
	{
		return Rtf;
	}
}
