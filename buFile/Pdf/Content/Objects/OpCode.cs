// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.OpCode
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

public sealed class OpCode
{
  public readonly string Name;
  public readonly OpCodeName OpCodeName;
  public readonly int Operands;
  public readonly OpCodeFlags Flags;
  public readonly string Postscript;
  public readonly string Description;

  internal OpCode(
    string name,
    OpCodeName opcodeName,
    int operands,
    string postscript,
    OpCodeFlags flags,
    string description)
  {
    this.Name = name;
    this.OpCodeName = opcodeName;
    this.Operands = operands;
    this.Postscript = postscript;
    this.Flags = flags;
    this.Description = description;
  }
}
