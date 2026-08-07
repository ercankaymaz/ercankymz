// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Actions.PdfAction
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Actions;

public abstract class PdfAction : PdfDictionary
{
  protected PdfAction() => this.Elements.SetName("/Type", "/Action");

  protected PdfAction(PdfDocument document)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Action");
  }

  internal class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Action")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string S = "/S";
    [KeyInfo(KeyType.ArrayOrDictionary | KeyType.Optional)]
    public const string Next = "/Next";
  }
}
