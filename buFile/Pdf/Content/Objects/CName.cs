// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.CName
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Name})")]
public class CName : CObject
{
  private string _name;

  public CName() => this._name = "/";

  public CName(string name) => this.Name = name;

  public CName Clone() => (CName) this.Copy();

  protected override CObject Copy() => base.Copy();

  public string Name
  {
    get => this._name;
    set
    {
      if (string.IsNullOrEmpty(this._name))
        throw new ArgumentNullException(nameof (value));
      this._name = this._name[0] == '/' ? value : throw new ArgumentException(PSSR.NameMustStartWithSlash);
    }
  }

  public override string ToString() => this._name;

  internal override void WriteObject(ContentWriter writer)
  {
    writer.WriteRaw(this.ToString() + " ");
  }
}
