// Decompiled with JetBrains decompiler
// Type: Opc.Ua.LocalizedText
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class LocalizedText : ICloneable, IFormattable
{
  private static readonly LocalizedText s_Null = new LocalizedText();
  private string m_locale;
  private string m_text;
  private TranslationInfo m_translationInfo;

  private LocalizedText()
  {
    this.m_locale = (string) null;
    this.m_text = (string) null;
  }

  public LocalizedText(string key, string locale, string text, params object[] args)
    : this(new TranslationInfo(key, locale, text, args))
  {
  }

  public LocalizedText(TranslationInfo translationInfo)
  {
    this.m_locale = translationInfo != null ? translationInfo.Locale : throw new ArgumentNullException(nameof (translationInfo));
    this.m_text = translationInfo.Text;
    this.m_translationInfo = translationInfo;
    if (this.m_translationInfo.Args == null || this.m_translationInfo.Args.Length == 0)
      return;
    CultureInfo provider = CultureInfo.InvariantCulture;
    if (!string.IsNullOrEmpty(this.m_locale))
    {
      try
      {
        provider = new CultureInfo(this.m_locale);
      }
      catch
      {
        provider = CultureInfo.InvariantCulture;
      }
    }
    try
    {
      this.m_text = string.Format((IFormatProvider) provider, this.m_translationInfo.Text, this.m_translationInfo.Args);
    }
    catch
    {
      this.m_text = this.m_translationInfo.Text;
    }
  }

  public LocalizedText(LocalizedText value)
  {
    this.m_locale = !(value == (LocalizedText) null) ? value.m_locale : throw new ArgumentNullException(nameof (value));
    this.m_text = value.m_text;
  }

  public LocalizedText(string text)
  {
    this.m_locale = (string) null;
    this.m_text = text;
  }

  public LocalizedText(string locale, string text)
  {
    this.m_locale = locale;
    this.m_text = text;
  }

  public LocalizedText(string key, string locale, string text)
  {
    this.m_locale = locale;
    this.m_text = text;
    if (string.IsNullOrEmpty(key))
      return;
    this.m_translationInfo = new TranslationInfo(key, locale, text);
  }

  public string Locale => this.m_locale;

  [DataMember(Name = "Locale", Order = 1)]
  internal string XmlEncodedLocale
  {
    get => this.m_locale;
    set => this.m_locale = value;
  }

  public string Text => this.m_text;

  [DataMember(Name = "Text", Order = 2)]
  internal string XmlEncodedText
  {
    get => this.m_text;
    set => this.m_text = value;
  }

  public string Key
  {
    get => this.m_translationInfo != null ? this.m_translationInfo.Key : (string) null;
    set
    {
      if (this.m_translationInfo != null)
        this.m_translationInfo.Key = value;
      else
        this.m_translationInfo = new TranslationInfo(value, this.m_locale, this.m_text);
    }
  }

  public TranslationInfo TranslationInfo
  {
    get => this.m_translationInfo;
    set => this.m_translationInfo = value;
  }

  public override bool Equals(object obj)
  {
    if ((object) this == obj)
      return true;
    LocalizedText localizedText = obj as LocalizedText;
    return !(localizedText == (LocalizedText) null) && (!(localizedText.m_locale != this.m_locale) || string.IsNullOrEmpty(localizedText.m_locale) && string.IsNullOrEmpty(this.m_locale)) && localizedText.m_text == this.m_text;
  }

  public static bool operator ==(LocalizedText value1, LocalizedText value2)
  {
    return (object) value1 != null ? value1.Equals((object) value2) : (object) value2 == null;
  }

  public static bool operator !=(LocalizedText value1, LocalizedText value2)
  {
    return (object) value1 != null ? !value1.Equals((object) value2) : value2 != null;
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    if (this.m_text != null)
      hashCode.Add<string>(this.m_text);
    if (this.m_locale != null)
      hashCode.Add<string>(this.m_locale);
    return hashCode.ToHashCode();
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return string.Format(formatProvider, "{0}", (object) this.m_text);
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) this;

  public static LocalizedText ToLocalizedText(string value) => new LocalizedText(value);

  public static implicit operator LocalizedText(string value) => new LocalizedText(value);

  public static LocalizedText Null => LocalizedText.s_Null;

  public static bool IsNullOrEmpty(LocalizedText value)
  {
    return value == (LocalizedText) null || string.IsNullOrEmpty(value.m_text);
  }
}
