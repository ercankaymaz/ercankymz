// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfCheckBoxField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using System.Collections.Generic;

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public sealed class PdfCheckBoxField : PdfButtonField
{
  private string _checkedName = "/Yes";
  private string _uncheckedName = "/Off";

  internal PdfCheckBoxField(PdfDocument document)
    : base(document)
  {
    this._document = document;
  }

  internal PdfCheckBoxField(PdfDictionary dict)
    : base(dict)
  {
  }

  public bool Checked
  {
    get
    {
      bool flag;
      if (!this.HasKids)
      {
        string str = this.Elements.GetString("/V");
        flag = str.Length != 0 && str != "/Off";
      }
      else if (this.Fields.Elements.Items.Length == 2)
      {
        string str = ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[0]).Value).Elements.GetString("/V");
        flag = str.Length != 0 && str != "/Off" && str != "/Nein";
      }
      else
        flag = false;
      return flag;
    }
    set
    {
      if (!this.HasKids)
      {
        string str = value ? this.GetNonOffValue() : "/Off";
        this.Elements.SetName("/V", str);
        this.Elements.SetName("/AS", str);
      }
      else
      {
        if (this.Fields.Elements.Items.Length != 2)
          return;
        if (value)
        {
          string str = "";
          if (((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[0]).Value).Elements["/AP"] is PdfDictionary element1 && element1.Elements["/N"] is PdfDictionary element2)
          {
            foreach (string key in (IEnumerable<string>) element2.Elements.Keys)
            {
              if (key != "/Off")
              {
                str = key;
                break;
              }
            }
          }
          if (str.Length != 0)
          {
            ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[0]).Value).Elements.SetName("/V", str);
            ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[0]).Value).Elements.SetName("/AS", str);
          }
          if (((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[1]).Value).Elements["/AP"] is PdfDictionary element3 && element3.Elements["/N"] is PdfDictionary element4)
          {
            foreach (string key in (IEnumerable<string>) element4.Elements.Keys)
            {
              if (key == "/Off")
              {
                str = key;
                break;
              }
            }
          }
          if (str.Length == 0)
            return;
          ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[1]).Value).Elements.SetName("/V", str);
          ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[1]).Value).Elements.SetName("/AS", str);
        }
        else
        {
          string str = "";
          if (((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[1]).Value).Elements["/AP"] is PdfDictionary element5 && element5.Elements["/N"] is PdfDictionary element6)
          {
            foreach (string key in (IEnumerable<string>) element6.Elements.Keys)
            {
              if (key != "/Off")
              {
                str = key;
                break;
              }
            }
          }
          if (str.Length != 0)
          {
            ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[1]).Value).Elements.SetName("/V", str);
            ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[1]).Value).Elements.SetName("/AS", str);
          }
          if (((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[0]).Value).Elements["/AP"] is PdfDictionary element7 && element7.Elements["/N"] is PdfDictionary element8)
          {
            foreach (string key in (IEnumerable<string>) element8.Elements.Keys)
            {
              if (key == "/Off")
              {
                str = key;
                break;
              }
            }
          }
          if (str.Length == 0)
            return;
          ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[0]).Value).Elements.SetName("/V", str);
          ((PdfDictionary) ((PdfReference) this.Fields.Elements.Items[0]).Value).Elements.SetName("/AS", str);
        }
      }
    }
  }

  public string CheckedName
  {
    get => this._checkedName;
    set => this._checkedName = value;
  }

  public string UncheckedName
  {
    get => this._uncheckedName;
    set => this._uncheckedName = value;
  }

  internal override DictionaryMeta Meta => PdfCheckBoxField.Keys.Meta;

  public new class Keys : PdfButtonField.Keys
  {
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string Opt = "/Opt";
    private static DictionaryMeta _meta;

    internal static DictionaryMeta Meta
    {
      get
      {
        return PdfCheckBoxField.Keys._meta ?? (PdfCheckBoxField.Keys._meta = KeysBase.CreateMeta(typeof (PdfCheckBoxField.Keys)));
      }
    }
  }
}
