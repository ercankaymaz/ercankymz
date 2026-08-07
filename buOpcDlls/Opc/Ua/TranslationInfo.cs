// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TranslationInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class TranslationInfo
{
  private string m_key;
  private string m_locale;
  private string m_text;
  private object[] m_args;

  public TranslationInfo()
  {
  }

  public TranslationInfo(string key, LocalizedText text)
  {
    this.m_key = key;
    if (!(text != (LocalizedText) null))
      return;
    this.m_text = text.Text;
    this.m_locale = text.Locale;
  }

  public TranslationInfo(XmlQualifiedName symbolicId, params object[] args)
  {
    this.m_key = symbolicId.ToString();
    this.m_locale = string.Empty;
    this.m_text = string.Empty;
    this.m_args = args;
  }

  public TranslationInfo(string key, string locale, string text)
  {
    this.m_key = key;
    this.m_locale = locale;
    this.m_text = text;
  }

  public TranslationInfo(string key, string locale, string format, params object[] args)
  {
    this.m_key = key;
    this.m_locale = locale;
    this.m_text = format;
    this.m_args = args;
  }

  public string Key
  {
    get => this.m_key;
    set => this.m_key = value;
  }

  public string Locale
  {
    get => this.m_locale;
    set => this.m_locale = value;
  }

  public string Text
  {
    get => this.m_text;
    set => this.m_text = value;
  }

  public object[] Args
  {
    get => this.m_args;
    set => this.m_args = value;
  }
}
