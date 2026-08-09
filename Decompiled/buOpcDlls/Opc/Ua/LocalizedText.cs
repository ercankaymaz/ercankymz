using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class LocalizedText : ICloneable, IFormattable
{
	private static readonly LocalizedText s_Null = new LocalizedText();

	private string m_locale;

	private string m_text;

	private TranslationInfo m_translationInfo;

	public string Locale => m_locale;

	[DataMember(Name = "Locale", Order = 1)]
	internal string XmlEncodedLocale
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

	public string Text => m_text;

	[DataMember(Name = "Text", Order = 2)]
	internal string XmlEncodedText
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

	public string Key
	{
		get
		{
			if (m_translationInfo != null)
			{
				return m_translationInfo.Key;
			}
			return null;
		}
		set
		{
			if (m_translationInfo != null)
			{
				m_translationInfo.Key = value;
			}
			else
			{
				m_translationInfo = new TranslationInfo(value, m_locale, m_text);
			}
		}
	}

	public TranslationInfo TranslationInfo
	{
		get
		{
			return m_translationInfo;
		}
		set
		{
			m_translationInfo = value;
		}
	}

	public static LocalizedText Null => s_Null;

	private LocalizedText()
	{
		m_locale = null;
		m_text = null;
	}

	public LocalizedText(string key, string locale, string text, params object[] args)
		: this(new TranslationInfo(key, locale, text, args))
	{
	}

	public LocalizedText(TranslationInfo translationInfo)
	{
		if (translationInfo == null)
		{
			throw new ArgumentNullException("translationInfo");
		}
		m_locale = translationInfo.Locale;
		m_text = translationInfo.Text;
		m_translationInfo = translationInfo;
		if (m_translationInfo.Args == null || m_translationInfo.Args.Length == 0)
		{
			return;
		}
		CultureInfo provider = CultureInfo.InvariantCulture;
		if (!string.IsNullOrEmpty(m_locale))
		{
			try
			{
				provider = new CultureInfo(m_locale);
			}
			catch
			{
				provider = CultureInfo.InvariantCulture;
			}
		}
		try
		{
			m_text = string.Format(provider, m_translationInfo.Text, m_translationInfo.Args);
		}
		catch
		{
			m_text = m_translationInfo.Text;
		}
	}

	public LocalizedText(LocalizedText value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		m_locale = value.m_locale;
		m_text = value.m_text;
	}

	public LocalizedText(string text)
	{
		m_locale = null;
		m_text = text;
	}

	public LocalizedText(string locale, string text)
	{
		m_locale = locale;
		m_text = text;
	}

	public LocalizedText(string key, string locale, string text)
	{
		m_locale = locale;
		m_text = text;
		if (!string.IsNullOrEmpty(key))
		{
			m_translationInfo = new TranslationInfo(key, locale, text);
		}
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		LocalizedText localizedText = obj as LocalizedText;
		if (localizedText == null)
		{
			return false;
		}
		if (localizedText.m_locale != m_locale && (!string.IsNullOrEmpty(localizedText.m_locale) || !string.IsNullOrEmpty(m_locale)))
		{
			return false;
		}
		return localizedText.m_text == m_text;
	}

	public static bool operator ==(LocalizedText value1, LocalizedText value2)
	{
		return value1?.Equals(value2) ?? ((object)value2 == null);
	}

	public static bool operator !=(LocalizedText value1, LocalizedText value2)
	{
		if ((object)value1 != null)
		{
			return !value1.Equals(value2);
		}
		return (object)value2 != null;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		if (m_text != null)
		{
			hashCode.Add(m_text);
		}
		if (m_locale != null)
		{
			hashCode.Add(m_locale);
		}
		return hashCode.ToHashCode();
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			return string.Format(formatProvider, "{0}", m_text);
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return this;
	}

	public static LocalizedText ToLocalizedText(string value)
	{
		return new LocalizedText(value);
	}

	public static implicit operator LocalizedText(string value)
	{
		return new LocalizedText(value);
	}

	public static bool IsNullOrEmpty(LocalizedText value)
	{
		if (value == null)
		{
			return true;
		}
		return string.IsNullOrEmpty(value.m_text);
	}
}
