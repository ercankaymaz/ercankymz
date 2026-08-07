// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.RichText
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Windows.Forms;

[Serializable]
public class RichText : IComparable<RichText>, IComparable
{
  private string m_Rtf = string.Empty;

  public RichText(string rtf) => this.m_Rtf = rtf;

  public RichText(RichText other) => this.Rtf = other.Rtf;

  public string Rtf
  {
    get => this.m_Rtf;
    set => this.m_Rtf = value;
  }

  public int CompareTo(object obj) => this.CompareTo(obj as RichText);

  public int CompareTo(RichText other)
  {
    return RichTextConversion.RichTextToString(this).CompareTo(RichTextConversion.RichTextToString(other));
  }

  public override string ToString() => this.Rtf;
}
