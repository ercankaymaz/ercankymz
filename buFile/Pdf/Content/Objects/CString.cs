// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.CString
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Value})")]
public class CString : CObject
{
  private string _value;
  private CStringType _cStringType;

  public CString Clone() => (CString) this.Copy();

  protected override CObject Copy() => base.Copy();

  public string Value
  {
    get => this._value;
    set => this._value = value;
  }

  public CStringType CStringType
  {
    get => this._cStringType;
    set => this._cStringType = value;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    switch (this.CStringType)
    {
      case CStringType.String:
        stringBuilder.Append("(");
        int length = this._value.Length;
        for (int index = 0; index < length; ++index)
        {
          char ch = this._value[index];
          switch (ch)
          {
            case '\b':
              stringBuilder.Append("\\b");
              break;
            case '\t':
              stringBuilder.Append("\\t");
              break;
            case '\n':
              stringBuilder.Append("\\n");
              break;
            case '\f':
              stringBuilder.Append("\\f");
              break;
            case '\r':
              stringBuilder.Append("\\r");
              break;
            case '(':
              stringBuilder.Append("\\(");
              break;
            case ')':
              stringBuilder.Append("\\)");
              break;
            case '\\':
              stringBuilder.Append("\\\\");
              break;
            default:
              stringBuilder.Append(ch);
              break;
          }
        }
        stringBuilder.Append(')');
        break;
      case CStringType.HexString:
        throw new NotImplementedException();
      case CStringType.UnicodeString:
        throw new NotImplementedException();
      case CStringType.UnicodeHexString:
        throw new NotImplementedException();
      case CStringType.Dictionary:
        stringBuilder.Append(this._value);
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
    return stringBuilder.ToString();
  }

  internal override void WriteObject(ContentWriter writer) => writer.WriteRaw(this.ToString());
}
