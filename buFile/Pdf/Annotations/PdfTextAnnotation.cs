// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Annotations.PdfTextAnnotation
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Annotations;

public sealed class PdfTextAnnotation : PdfAnnotation
{
  public PdfTextAnnotation() => this.Initialize();

  public PdfTextAnnotation(PdfDocument document)
    : base(document)
  {
    this.Initialize();
  }

  private void Initialize()
  {
    this.Elements.SetName("/Subtype", "/Text");
    this.Icon = PdfTextAnnotationIcon.Comment;
  }

  public bool Open
  {
    get => this.Elements.GetBoolean("/Open");
    set => this.Elements.SetBoolean("/Open", value);
  }

  public PdfTextAnnotationIcon Icon
  {
    get
    {
      string name = this.Elements.GetName("/Name");
      PdfTextAnnotationIcon icon;
      if (name == "")
      {
        icon = PdfTextAnnotationIcon.NoIcon;
      }
      else
      {
        string str = name.Substring(1);
        icon = Enum.IsDefined(typeof (PdfTextAnnotationIcon), (object) str) ? (PdfTextAnnotationIcon) Enum.Parse(typeof (PdfTextAnnotationIcon), str, false) : PdfTextAnnotationIcon.NoIcon;
      }
      return icon;
    }
    set
    {
      if ((!Enum.IsDefined(typeof (PdfTextAnnotationIcon), (object) value) ? 0 : (value != 0 ? 1 : 0)) != 0)
        this.Elements.SetName("/Name", "/" + value.ToString());
      else
        this.Elements.Remove("/Name");
    }
  }

  internal override DictionaryMeta Meta => PdfTextAnnotation.Keys.Meta;

  internal new class Keys : PdfAnnotation.Keys
  {
    [KeyInfo(KeyType.Boolean | KeyType.Optional)]
    public const string Open = "/Open";
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Name = "/Name";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfTextAnnotation.Keys._meta ?? (PdfTextAnnotation.Keys._meta = KeysBase.CreateMeta(typeof (PdfTextAnnotation.Keys)));
      }
    }
  }
}
