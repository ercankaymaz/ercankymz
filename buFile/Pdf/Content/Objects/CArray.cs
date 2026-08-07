// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.CArray
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("(count={Count})")]
public class CArray : CSequence
{
  public CArray Clone() => (CArray) this.Copy();

  protected override CObject Copy() => base.Copy();

  public override string ToString() => $"[{base.ToString()}]";

  internal override void WriteObject(ContentWriter writer) => writer.WriteRaw(this.ToString());
}
