// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfSoftMask
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Advanced;

public class PdfSoftMask : PdfDictionary
{
  public PdfSoftMask(PdfDocument document)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Mask");
  }

  public class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Mask")]
    public const string Type = "/Type";
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string S = "/S";
    [KeyInfo(KeyType.Stream | KeyType.Required)]
    public const string G = "/G";
    [KeyInfo(KeyType.Array | KeyType.Optional)]
    public const string BC = "/BC";
    [KeyInfo(KeyType.FunctionOrName | KeyType.Optional)]
    public const string TR = "/TR";
  }
}
