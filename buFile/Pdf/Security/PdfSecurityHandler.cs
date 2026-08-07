// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Security.PdfSecurityHandler
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Security;

public abstract class PdfSecurityHandler : PdfDictionary
{
  internal PdfSecurityHandler(PdfDocument document)
    : base(document)
  {
  }

  internal PdfSecurityHandler(PdfDictionary dict)
    : base(dict)
  {
  }

  internal class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string Filter = "/Filter";
    [KeyInfo("1.3", KeyType.Name | KeyType.Optional)]
    public const string SubFilter = "/SubFilter";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string V = "/V";
    [KeyInfo("1.4", KeyType.Integer | KeyType.Optional)]
    public const string Length = "/Length";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string CF = "/CF";
    [KeyInfo("1.5", KeyType.Name | KeyType.Optional)]
    public const string StmF = "/StmF";
    [KeyInfo("1.5", KeyType.Name | KeyType.Optional)]
    public const string StrF = "/StrF";
    [KeyInfo("1.6", KeyType.Name | KeyType.Optional)]
    public const string EFF = "/EFF";
  }
}
