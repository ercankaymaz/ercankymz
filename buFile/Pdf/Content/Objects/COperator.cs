// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.COperator
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Name}, operands={Operands.Count})")]
public class COperator : CObject
{
  private CSequence _seqence;
  private readonly OpCode _opcode;

  protected COperator()
  {
  }

  internal COperator(OpCode opcode) => this._opcode = opcode;

  public COperator Clone() => (COperator) this.Copy();

  protected override CObject Copy() => base.Copy();

  public virtual string Name => this._opcode.Name;

  public CSequence Operands => this._seqence ?? (this._seqence = new CSequence());

  public OpCode OpCode => this._opcode;

  public override string ToString()
  {
    return this._opcode.OpCodeName != OpCodeName.Dictionary ? this.Name : " ";
  }

  internal override void WriteObject(ContentWriter writer)
  {
    int count = this._seqence != null ? this._seqence.Count : 0;
    for (int index = 0; index < count; ++index)
      this._seqence[index].WriteObject(writer);
    writer.WriteLineRaw(this.ToString());
  }
}
