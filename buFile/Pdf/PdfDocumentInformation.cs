// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfDocumentInformation
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfDocumentInformation : PdfDictionary
{
  public PdfDocumentInformation(PdfDocument document)
    : base(document)
  {
  }

  internal PdfDocumentInformation(PdfDictionary dict)
    : base(dict)
  {
  }

  public string Title
  {
    get => this.Elements.GetString("/Title");
    set => this.Elements.SetString("/Title", value);
  }

  public string Author
  {
    get => this.Elements.GetString("/Author");
    set => this.Elements.SetString("/Author", value);
  }

  public string Subject
  {
    get => this.Elements.GetString("/Subject");
    set => this.Elements.SetString("/Subject", value);
  }

  public string Keywords
  {
    get => this.Elements.GetString("/Keywords");
    set => this.Elements.SetString("/Keywords", value);
  }

  public string Creator
  {
    get => this.Elements.GetString("/Creator");
    set => this.Elements.SetString("/Creator", value);
  }

  public string Producer => this.Elements.GetString("/Producer");

  public DateTime CreationDate
  {
    get => this.Elements.GetDateTime("/CreationDate", DateTime.MinValue);
    set => this.Elements.SetDateTime("/CreationDate", value);
  }

  public DateTime ModificationDate
  {
    get => this.Elements.GetDateTime("/ModDate", DateTime.MinValue);
    set => this.Elements.SetDateTime("/ModDate", value);
  }

  internal override DictionaryMeta Meta => PdfDocumentInformation.Keys.Meta;

  internal sealed class Keys : KeysBase
  {
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string Title = "/Title";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string Author = "/Author";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string Subject = "/Subject";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string Keywords = "/Keywords";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string Creator = "/Creator";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string Producer = "/Producer";
    [KeyInfo(KeyType.Date | KeyType.Optional)]
    public const string CreationDate = "/CreationDate";
    [KeyInfo(KeyType.String | KeyType.Optional)]
    public const string ModDate = "/ModDate";
    [KeyInfo("1.3", KeyType.Name | KeyType.Optional)]
    public const string Trapped = "/Trapped";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfDocumentInformation.Keys._meta ?? (PdfDocumentInformation.Keys._meta = KeysBase.CreateMeta(typeof (PdfDocumentInformation.Keys)));
      }
    }
  }
}
