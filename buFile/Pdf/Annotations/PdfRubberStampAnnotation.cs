// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Annotations.PdfRubberStampAnnotation
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;

#nullable disable
namespace PdfSharp.Pdf.Annotations;

public sealed class PdfRubberStampAnnotation : PdfAnnotation
{
  public PdfRubberStampAnnotation() => this.Initialize();

  public PdfRubberStampAnnotation(PdfDocument document)
    : base(document)
  {
    this.Initialize();
  }

  private void Initialize()
  {
    this.Elements.SetName("/Subtype", "/Stamp");
    this.Color = XColors.Yellow;
  }

  public PdfRubberStampAnnotationIcon Icon
  {
    get
    {
      string name = this.Elements.GetName("/Name");
      PdfRubberStampAnnotationIcon icon;
      if (name == "")
      {
        icon = PdfRubberStampAnnotationIcon.NoIcon;
      }
      else
      {
        string str = name.Substring(1);
        icon = Enum.IsDefined(typeof (PdfRubberStampAnnotationIcon), (object) str) ? (PdfRubberStampAnnotationIcon) Enum.Parse(typeof (PdfRubberStampAnnotationIcon), str, false) : PdfRubberStampAnnotationIcon.NoIcon;
      }
      return icon;
    }
    set
    {
      if ((!Enum.IsDefined(typeof (PdfRubberStampAnnotationIcon), (object) value) ? 0 : (value != 0 ? 1 : 0)) != 0)
        this.Elements.SetName("/Name", "/" + value.ToString());
      else
        this.Elements.Remove("/Name");
    }
  }

  internal override DictionaryMeta Meta => PdfRubberStampAnnotation.Keys.Meta;

  internal new class Keys : PdfAnnotation.Keys
  {
    [KeyInfo(KeyType.Name | KeyType.Optional)]
    public const string Name = "/Name";
    private static DictionaryMeta _meta;

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfRubberStampAnnotation.Keys._meta ?? (PdfRubberStampAnnotation.Keys._meta = KeysBase.CreateMeta(typeof (PdfRubberStampAnnotation.Keys)));
      }
    }
  }
}
