// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.CComment
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Text})")]
public class CComment : CObject
{
  private string _text;

  public CComment Clone() => (CComment) this.Copy();

  protected override CObject Copy() => base.Copy();

  public string Text
  {
    get => this._text;
    set => this._text = value;
  }

  public override string ToString() => "% " + this._text;

  internal override void WriteObject(ContentWriter writer) => writer.WriteLineRaw(this.ToString());
}
