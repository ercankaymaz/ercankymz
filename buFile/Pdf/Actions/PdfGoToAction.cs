// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Actions.PdfGoToAction
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Actions;

public sealed class PdfGoToAction : PdfAction
{
  public PdfGoToAction() => this.Inititalize();

  public PdfGoToAction(PdfDocument document)
    : base(document)
  {
    this.Inititalize();
  }

  private void Inititalize()
  {
    this.Elements.SetName("/Type", "/Action");
    this.Elements.SetName("/S", "/Goto");
  }

  internal new class Keys : PdfAction.Keys
  {
    [KeyInfo(KeyType.Rectangle | KeyType.Array | KeyType.Required)]
    public const string D = "/D";
  }
}
