using System.Runtime.InteropServices;
using System.Xml;

namespace Opc.Ua;

[ComVisible(true)]
public class TranslationInfo
{
	private string m_key;

	private string m_locale;

	private string m_text;

	private object[] m_args;

	public string Key
	{
		get
		{
			return m_key;
		}
		set
		{
			m_key = value;
		}
	}

	public string Locale
	{
		get
		{
			return m_locale;
		}
		set
		{
			m_locale = value;
		}
	}

	public string Text
	{
		get
		{
			return m_text;
		}
		set
		{
			m_text = value;
		}
	}

	public object[] Args
	{
		get
		{
			return m_args;
		}
		set
		{
			m_args = value;
		}
	}

	public TranslationInfo()
	{
	}

	public TranslationInfo(string key, LocalizedText text)
	{
		m_key = key;
		if (text != null)
		{
			m_text = text.Text;
			m_locale = text.Locale;
		}
	}

	public TranslationInfo(XmlQualifiedName symbolicId, params object[] args)
	{
		m_key = symbolicId.ToString();
		m_locale = string.Empty;
		m_text = string.Empty;
		m_args = args;
	}

	public TranslationInfo(string key, string locale, string text)
	{
		m_key = key;
		m_locale = locale;
		m_text = text;
	}

	public TranslationInfo(string key, string locale, string format, params object[] args)
	{
		m_key = key;
		m_locale = locale;
		m_text = format;
		m_args = args;
	}
}
