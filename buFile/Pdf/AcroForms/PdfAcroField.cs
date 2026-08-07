// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.AcroForms.PdfAcroField
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.AcroForms;

public abstract class PdfAcroField : PdfDictionary
{
  private PdfAcroField.PdfAcroFieldCollection _fields;

  internal PdfAcroField(PdfDocument document)
    : base(document)
  {
  }

  protected PdfAcroField(PdfDictionary dict)
    : base(dict)
  {
  }

  public string Name => this.Elements.GetString("/T");

  public PdfAcroFieldFlags Flags => (PdfAcroFieldFlags) this.Elements.GetInteger("/Ff");

  internal PdfAcroFieldFlags SetFlags
  {
    get => (PdfAcroFieldFlags) this.Elements.GetInteger("/Ff");
    set => this.Elements.SetInteger("/Ff", (int) value);
  }

  public virtual PdfItem Value
  {
    get => this.Elements["/V"];
    set
    {
      if (this.ReadOnly)
        throw new InvalidOperationException("The field is read only.");
      this.Elements["/V"] = (value is PdfString ? 1 : (value is PdfName ? 1 : 0)) != 0 ? value : throw new NotImplementedException("Values other than string cannot be set.");
    }
  }

  public bool ReadOnly
  {
    get => (this.Flags & PdfAcroFieldFlags.ReadOnly) != 0;
    set
    {
      if (value)
        this.SetFlags |= PdfAcroFieldFlags.ReadOnly;
      else
        this.SetFlags &= ~PdfAcroFieldFlags.ReadOnly;
    }
  }

  public PdfAcroField this[string name] => this.GetValue(name);

  protected virtual PdfAcroField GetValue(string name)
  {
    return !string.IsNullOrEmpty(name) ? (!this.HasKids ? (PdfAcroField) null : this.Fields.GetValue(name)) : this;
  }

  public bool HasKids
  {
    get
    {
      PdfItem element = this.Elements["/Kids"];
      return element != null && element is PdfArray && ((PdfArray) element).Elements.Count > 0;
    }
  }

  [Obsolete("Use GetDescendantNames")]
  public string[] DescendantNames => this.GetDescendantNames();

  public string[] GetDescendantNames()
  {
    List<string> names = new List<string>();
    if (this.HasKids)
      this.Fields.GetDescendantNames(ref names, (string) null);
    List<string> stringList = new List<string>();
    foreach (string str in names)
      stringList.Add(str);
    return stringList.ToArray();
  }

  public string[] GetAppearanceNames()
  {
    Dictionary<string, object> names = new Dictionary<string, object>();
    if (this.Elements["/AP"] is PdfDictionary element)
    {
      PdfAcroField.AppDict(element, names);
      if (this.HasKids)
      {
        foreach (PdfItem pdfItem in this.Fields.Elements.Items)
        {
          if (pdfItem is PdfReference && ((PdfReference) pdfItem).Value is PdfDictionary dict)
            PdfAcroField.AppDict(dict, names);
        }
      }
    }
    string[] array = new string[names.Count];
    names.Keys.CopyTo(array, 0);
    return array;
  }

  private static void AppDict(PdfDictionary dict, Dictionary<string, object> names)
  {
    if (dict.Elements["/D"] is PdfDictionary element1)
      PdfAcroField.AppDict2(element1, names);
    if (!(dict.Elements["/N"] is PdfDictionary element2))
      return;
    PdfAcroField.AppDict2(element2, names);
  }

  private static void AppDict2(PdfDictionary dict, Dictionary<string, object> names)
  {
    foreach (string key in (IEnumerable<string>) dict.Elements.Keys)
    {
      if (!names.ContainsKey(key))
        names.Add(key, (object) null);
    }
  }

  internal virtual void GetDescendantNames(ref List<string> names, string partialName)
  {
    if (this.HasKids)
    {
      PdfAcroField.PdfAcroFieldCollection fields = this.Fields;
      string str = this.Elements.GetString("/T");
      Debug.Assert(str != "");
      if (str.Length <= 0)
        return;
      partialName = string.IsNullOrEmpty(partialName) ? str : $"{partialName}.{str}";
      fields.GetDescendantNames(ref names, partialName);
    }
    else
    {
      string str = this.Elements.GetString("/T");
      Debug.Assert(str != "");
      if (str.Length <= 0)
        return;
      if (!string.IsNullOrEmpty(partialName))
        names.Add($"{partialName}.{str}");
      else
        names.Add(str);
    }
  }

  public PdfAcroField.PdfAcroFieldCollection Fields
  {
    get
    {
      if (this._fields == null)
        this._fields = (PdfAcroField.PdfAcroFieldCollection) (object) this.Elements.GetValue("/Kids", VCF.CreateIndirect);
      return this._fields;
    }
  }

  public sealed class PdfAcroFieldCollection : PdfArray
  {
    private PdfAcroFieldCollection(PdfArray array)
      : base(array)
    {
    }

    public int Count => this.Elements.Count;

    public string[] Names
    {
      get
      {
        int count = this.Elements.Count;
        string[] names = new string[count];
        for (int index = 0; index < count; ++index)
          names[index] = ((PdfDictionary) ((PdfReference) this.Elements[index]).Value).Elements.GetString("/T");
        return names;
      }
    }

    public string[] DescendantNames
    {
      get
      {
        List<string> names = new List<string>();
        this.GetDescendantNames(ref names, (string) null);
        return names.ToArray();
      }
    }

    internal void GetDescendantNames(ref List<string> names, string partialName)
    {
      int count = this.Elements.Count;
      for (int index = 0; index < count; ++index)
        this[index]?.GetDescendantNames(ref names, partialName);
    }

    public PdfAcroField this[int index]
    {
      get
      {
        PdfItem element = this.Elements[index];
        Debug.Assert(element is PdfReference);
        PdfDictionary dict = ((PdfReference) element).Value as PdfDictionary;
        Debug.Assert(dict != null);
        if ((dict is PdfAcroField pdfAcroField ? 0 : (dict != null ? 1 : 0)) != 0)
          pdfAcroField = this.CreateAcroField(dict);
        return pdfAcroField;
      }
    }

    public PdfAcroField this[string name] => this.GetValue(name);

    internal PdfAcroField GetValue(string name)
    {
      PdfAcroField pdfAcroField1;
      if (string.IsNullOrEmpty(name))
      {
        pdfAcroField1 = (PdfAcroField) null;
      }
      else
      {
        int length = name.IndexOf('.');
        string str = length == -1 ? name : name.Substring(0, length);
        string name1 = length == -1 ? "" : name.Substring(length + 1);
        int count = this.Elements.Count;
        for (int index = 0; index < count; ++index)
        {
          PdfAcroField pdfAcroField2 = this[index];
          if (pdfAcroField2.Name == str)
          {
            pdfAcroField1 = pdfAcroField2.GetValue(name1);
            goto label_8;
          }
        }
        pdfAcroField1 = (PdfAcroField) null;
      }
label_8:
      return pdfAcroField1;
    }

    private PdfAcroField CreateAcroField(PdfDictionary dict)
    {
      string name = dict.Elements.GetName("/FT");
      PdfAcroFieldFlags integer = (PdfAcroFieldFlags) dict.Elements.GetInteger("/Ff");
      PdfAcroField acroField;
      switch (name)
      {
        case "/Btn":
          acroField = (integer & PdfAcroFieldFlags.Pushbutton) == 0 ? ((integer & PdfAcroFieldFlags.Radio) == 0 ? (PdfAcroField) new PdfCheckBoxField(dict) : (PdfAcroField) new PdfRadioButtonField(dict)) : (PdfAcroField) new PdfPushButtonField(dict);
          break;
        case "/Tx":
          acroField = (PdfAcroField) new PdfTextField(dict);
          break;
        case "/Ch":
          acroField = (integer & PdfAcroFieldFlags.Combo) == 0 ? (PdfAcroField) new PdfListBoxField(dict) : (PdfAcroField) new PdfComboBoxField(dict);
          break;
        case "/Sig":
          acroField = (PdfAcroField) new PdfSignatureField(dict);
          break;
        default:
          acroField = (PdfAcroField) new PdfGenericField(dict);
          break;
      }
      return acroField;
    }
  }

  public class Keys : KeysBase
  {
    [KeyInfo(KeyType.Name | KeyType.Required)]
    public const string FT = "/FT";
    [KeyInfo(KeyType.Dictionary)]
    public const string Parent = "/Parent";
    [KeyInfo(KeyType.Array | KeyType.Optional, typeof (PdfAcroField.PdfAcroFieldCollection))]
    public const string Kids = "/Kids";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string T = "/T";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string TU = "/TU";
    [KeyInfo(KeyType.TextString | KeyType.Optional)]
    public const string TM = "/TM";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string Ff = "/Ff";
    [KeyInfo(KeyType.Various | KeyType.Optional)]
    public const string V = "/V";
    [KeyInfo(KeyType.Various | KeyType.Optional)]
    public const string DV = "/DV";
    [KeyInfo(KeyType.Dictionary | KeyType.Optional)]
    public const string AA = "/AA";
    [KeyInfo(KeyType.Dictionary | KeyType.Required)]
    public const string DR = "/DR";
    [KeyInfo(KeyType.String | KeyType.Required)]
    public const string DA = "/DA";
    [KeyInfo(KeyType.Integer | KeyType.Optional)]
    public const string Q = "/Q";
  }
}
