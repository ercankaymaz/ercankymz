// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfDictionary
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Filters;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
public class PdfDictionary : PdfObject, IEnumerable<KeyValuePair<string, PdfItem>>, IEnumerable
{
  internal PdfDictionary.DictionaryElements _elements;
  private PdfDictionary.PdfStream _stream;

  public PdfDictionary()
  {
  }

  public PdfDictionary(PdfDocument document)
    : base(document)
  {
  }

  protected PdfDictionary(PdfDictionary dict)
    : base((PdfObject) dict)
  {
    if (dict._elements != null)
      dict._elements.ChangeOwner(this);
    if (dict._stream == null)
      return;
    dict._stream.ChangeOwner(this);
  }

  public PdfDictionary Clone() => (PdfDictionary) this.Copy();

  protected override object Copy()
  {
    PdfDictionary pdfDictionary = (PdfDictionary) base.Copy();
    if (pdfDictionary._elements != null)
    {
      pdfDictionary._elements = pdfDictionary._elements.Clone();
      pdfDictionary._elements.ChangeOwner(pdfDictionary);
      foreach (PdfName keyName in pdfDictionary._elements.KeyNames)
      {
        if (pdfDictionary._elements[keyName] is PdfObject element)
        {
          PdfObject pdfObject = element.Clone();
          pdfDictionary._elements[keyName] = (PdfItem) pdfObject;
        }
      }
    }
    if (pdfDictionary._stream != null)
    {
      pdfDictionary._stream = pdfDictionary._stream.Clone();
      pdfDictionary._stream.ChangeOwner(pdfDictionary);
    }
    return (object) pdfDictionary;
  }

  public PdfDictionary.DictionaryElements Elements
  {
    get => this._elements ?? (this._elements = new PdfDictionary.DictionaryElements(this));
  }

  public IEnumerator<KeyValuePair<string, PdfItem>> GetEnumerator()
  {
    return this.Elements.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public override string ToString()
  {
    PdfName[] keyNames = this.Elements.KeyNames;
    List<PdfName> pdfNameList = new List<PdfName>((IEnumerable<PdfName>) keyNames);
    pdfNameList.Sort((IComparer<PdfName>) PdfName.Comparer);
    pdfNameList.CopyTo(keyNames, 0);
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("<< ");
    foreach (PdfName key in keyNames)
      stringBuilder.Append($"{key?.ToString()} {this.Elements[key]?.ToString()} ");
    stringBuilder.Append(">>");
    return stringBuilder.ToString();
  }

  internal override void WriteObject(PdfWriter writer)
  {
    writer.WriteBeginObject((PdfObject) this);
    PdfName[] keyNames = this.Elements.KeyNames;
    if (this._stream != null)
      Debug.Assert(this.Elements.ContainsKey("/Length"), "Dictionary has a stream but no length is set.");
    if (writer.Layout == PdfWriterLayout.Verbose)
    {
      List<PdfName> pdfNameList = new List<PdfName>((IEnumerable<PdfName>) keyNames);
      pdfNameList.Sort((IComparer<PdfName>) PdfName.Comparer);
      pdfNameList.CopyTo(keyNames, 0);
    }
    foreach (PdfName key in keyNames)
      this.WriteDictionaryElement(writer, key);
    if (this.Stream != null)
      this.WriteDictionaryStream(writer);
    writer.WriteEndObject();
  }

  internal virtual void WriteDictionaryElement(PdfWriter writer, PdfName key)
  {
    PdfItem pdfItem = !(key == (string) null) ? this.Elements[key] : throw new ArgumentNullException(nameof (key));
    if ((!(pdfItem is PdfObject) ? 0 : (((PdfObject) pdfItem).IsIndirect ? 1 : 0)) != 0)
    {
      pdfItem = (PdfItem) ((PdfObject) pdfItem).Reference;
      Debug.Assert(false, "Check when we come here.");
    }
    key.WriteObject(writer);
    pdfItem.WriteObject(writer);
    writer.NewLine();
  }

  internal virtual void WriteDictionaryStream(PdfWriter writer)
  {
    writer.WriteStream(this, (writer.Options & PdfWriterOptions.OmitStream) == PdfWriterOptions.OmitStream);
  }

  public PdfDictionary.PdfStream Stream
  {
    get => this._stream;
    set => this._stream = value;
  }

  public PdfDictionary.PdfStream CreateStream(byte[] value)
  {
    this._stream = this._stream == null ? new PdfDictionary.PdfStream(value, this) : throw new InvalidOperationException("The dictionary already has a stream.");
    this.Elements["/Length"] = (PdfItem) new PdfInteger(this._stream.Length);
    return this._stream;
  }

  internal virtual DictionaryMeta Meta => (DictionaryMeta) null;

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "dictionary({0},[{1}])={2}", (object) this.ObjectID.DebuggerDisplay, (object) this.Elements.Count, (object) this._elements.DebuggerDisplay);
    }
  }

  [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
  public sealed class DictionaryElements : 
    IDictionary<string, PdfItem>,
    ICollection<KeyValuePair<string, PdfItem>>,
    IEnumerable<KeyValuePair<string, PdfItem>>,
    IEnumerable,
    ICloneable
  {
    private Dictionary<string, PdfItem> _elements;
    private PdfDictionary _ownerDictionary;

    internal DictionaryElements(PdfDictionary ownerDictionary)
    {
      this._elements = new Dictionary<string, PdfItem>();
      this._ownerDictionary = ownerDictionary;
    }

    object ICloneable.Clone()
    {
      PdfDictionary.DictionaryElements dictionaryElements = (PdfDictionary.DictionaryElements) this.MemberwiseClone();
      dictionaryElements._elements = new Dictionary<string, PdfItem>((IDictionary<string, PdfItem>) dictionaryElements._elements);
      dictionaryElements._ownerDictionary = (PdfDictionary) null;
      return (object) dictionaryElements;
    }

    public PdfDictionary.DictionaryElements Clone()
    {
      return (PdfDictionary.DictionaryElements) ((ICloneable) this).Clone();
    }

    internal void ChangeOwner(PdfDictionary ownerDictionary)
    {
      if (this._ownerDictionary != null)
        ;
      this._ownerDictionary = ownerDictionary;
      ownerDictionary._elements = this;
    }

    internal PdfDictionary Owner => this._ownerDictionary;

    public bool GetBoolean(string key, bool create)
    {
      object obj = (object) this[key];
      if (obj == null)
      {
        if (create)
          this[key] = (PdfItem) new PdfBoolean();
        return false;
      }
      if (obj is PdfReference)
        obj = (object) ((PdfReference) obj).Value;
      if (obj is PdfBoolean pdfBoolean)
        return pdfBoolean.Value;
      return obj is PdfBooleanObject pdfBooleanObject ? pdfBooleanObject.Value : throw new InvalidCastException("GetBoolean: Object is not a boolean.");
    }

    public bool GetBoolean(string key) => this.GetBoolean(key, false);

    public void SetBoolean(string key, bool value) => this[key] = (PdfItem) new PdfBoolean(value);

    public int GetInteger(string key, bool create)
    {
      object obj = (object) this[key];
      if (obj == null)
      {
        if (create)
          this[key] = (PdfItem) new PdfInteger();
        return 0;
      }
      if (obj is PdfReference pdfReference)
        obj = (object) pdfReference.Value;
      if (obj is PdfInteger pdfInteger)
        return pdfInteger.Value;
      return obj is PdfIntegerObject pdfIntegerObject ? pdfIntegerObject.Value : throw new InvalidCastException("GetInteger: Object is not an integer.");
    }

    public int GetInteger(string key) => this.GetInteger(key, false);

    public void SetInteger(string key, int value) => this[key] = (PdfItem) new PdfInteger(value);

    public double GetReal(string key, bool create)
    {
      object obj = (object) this[key];
      if (obj == null)
      {
        if (create)
          this[key] = (PdfItem) new PdfReal();
        return 0.0;
      }
      if (obj is PdfReference pdfReference)
        obj = (object) pdfReference.Value;
      if (obj is PdfReal pdfReal)
        return pdfReal.Value;
      if (obj is PdfRealObject pdfRealObject)
        return pdfRealObject.Value;
      if (obj is PdfInteger pdfInteger)
        return (double) pdfInteger.Value;
      return obj is PdfIntegerObject pdfIntegerObject ? (double) pdfIntegerObject.Value : throw new InvalidCastException("GetReal: Object is not a number.");
    }

    public double GetReal(string key) => this.GetReal(key, false);

    public void SetReal(string key, double value) => this[key] = (PdfItem) new PdfReal(value);

    public string GetString(string key, bool create)
    {
      object obj = (object) this[key];
      if (obj == null)
      {
        if (create)
          this[key] = (PdfItem) new PdfString();
        return "";
      }
      if (obj is PdfReference pdfReference)
        obj = (object) pdfReference.Value;
      if (obj is PdfString pdfString)
        return pdfString.Value;
      if (obj is PdfStringObject pdfStringObject)
        return pdfStringObject.Value;
      PdfName pdfName = obj as PdfName;
      if (pdfName != (string) null)
        return pdfName.Value;
      PdfNameObject pdfNameObject = obj as PdfNameObject;
      return pdfNameObject != (string) null ? pdfNameObject.Value : throw new InvalidCastException("GetString: Object is not a string.");
    }

    public string GetString(string key) => this.GetString(key, false);

    public bool TryGetString(string key, out string value)
    {
      value = (string) null;
      object obj = (object) this[key];
      bool flag;
      if (obj == null)
      {
        flag = false;
      }
      else
      {
        if (obj is PdfReference pdfReference)
          obj = (object) pdfReference.Value;
        if (obj is PdfString pdfString)
        {
          value = pdfString.Value;
          flag = true;
        }
        else if (obj is PdfStringObject pdfStringObject)
        {
          value = pdfStringObject.Value;
          flag = true;
        }
        else
        {
          PdfName pdfName = obj as PdfName;
          if (pdfName != (string) null)
          {
            value = pdfName.Value;
            flag = true;
          }
          else
          {
            PdfNameObject pdfNameObject = obj as PdfNameObject;
            if (pdfNameObject != (string) null)
            {
              value = pdfNameObject.Value;
              flag = true;
            }
            else
              flag = false;
          }
        }
      }
      return flag;
    }

    public void SetString(string key, string value) => this[key] = (PdfItem) new PdfString(value);

    public string GetName(string key)
    {
      object obj = (object) this[key];
      if (obj == null)
        return string.Empty;
      if (obj is PdfReference pdfReference)
        obj = (object) pdfReference.Value;
      PdfName pdfName = obj as PdfName;
      if (pdfName != (string) null)
        return pdfName.Value;
      PdfNameObject pdfNameObject = obj as PdfNameObject;
      return pdfNameObject != (string) null ? pdfNameObject.Value : throw new InvalidCastException("GetName: Object is not a name.");
    }

    public void SetName(string key, string value)
    {
      int num;
      switch (value)
      {
        case null:
          throw new ArgumentNullException(nameof (value));
        case "":
          num = 1;
          break;
        default:
          num = value[0] != '/' ? 1 : 0;
          break;
      }
      if (num != 0)
        value = "/" + value;
      this[key] = (PdfItem) new PdfName(value);
    }

    public PdfRectangle GetRectangle(string key, bool create)
    {
      PdfRectangle pdfRectangle1 = new PdfRectangle();
      object obj = (object) this[key];
      PdfRectangle rectangle;
      if (obj == null)
      {
        if (create)
          this[key] = (PdfItem) (pdfRectangle1 = new PdfRectangle());
        rectangle = pdfRectangle1;
      }
      else
      {
        if (obj is PdfReference)
          obj = (object) ((PdfReference) obj).Value;
        PdfRectangle pdfRectangle2;
        if ((!(obj is PdfArray pdfArray) ? 0 : (pdfArray.Elements.Count == 4 ? 1 : 0)) != 0)
        {
          pdfRectangle2 = new PdfRectangle(pdfArray.Elements.GetReal(0), pdfArray.Elements.GetReal(1), pdfArray.Elements.GetReal(2), pdfArray.Elements.GetReal(3));
          this[key] = (PdfItem) pdfRectangle2;
        }
        else
          pdfRectangle2 = (PdfRectangle) obj;
        rectangle = pdfRectangle2;
      }
      return rectangle;
    }

    public PdfRectangle GetRectangle(string key) => this.GetRectangle(key, false);

    public void SetRectangle(string key, PdfRectangle rect) => this._elements[key] = (PdfItem) rect;

    public XMatrix GetMatrix(string key, bool create)
    {
      XMatrix matrix = new XMatrix();
      object obj = (object) this[key];
      if (obj == null)
      {
        if (create)
          this[key] = (PdfItem) new PdfLiteral("[1 0 0 1 0 0]");
        return matrix;
      }
      if (obj is PdfReference pdfReference)
        obj = (object) pdfReference.Value;
      if ((!(obj is PdfArray pdfArray) ? 0 : (pdfArray.Elements.Count == 6 ? 1 : 0)) != 0)
      {
        matrix = new XMatrix(pdfArray.Elements.GetReal(0), pdfArray.Elements.GetReal(1), pdfArray.Elements.GetReal(2), pdfArray.Elements.GetReal(3), pdfArray.Elements.GetReal(4), pdfArray.Elements.GetReal(5));
        return matrix;
      }
      if (obj is PdfLiteral)
        throw new NotImplementedException("Parsing matrix from literal.");
      throw new InvalidCastException("Element is not an array with 6 values.");
    }

    public XMatrix GetMatrix(string key) => this.GetMatrix(key, false);

    public void SetMatrix(string key, XMatrix matrix)
    {
      this._elements[key] = (PdfItem) PdfLiteral.FromMatrix(matrix);
    }

    public DateTime GetDateTime(string key, DateTime defaultValue)
    {
      object obj = (object) this[key];
      if (obj == null)
        return defaultValue;
      if (obj is PdfReference pdfReference)
        obj = (object) pdfReference.Value;
      if (obj is PdfDate pdfDate)
        return pdfDate.Value;
      string date;
      if (obj is PdfString pdfString)
        date = pdfString.Value;
      else
        date = obj is PdfStringObject pdfStringObject ? pdfStringObject.Value : throw new InvalidCastException("GetName: Object is not a name.");
      if (date != "")
      {
        try
        {
          defaultValue = Parser.ParseDateTime(date, defaultValue);
        }
        catch
        {
        }
      }
      return defaultValue;
    }

    public void SetDateTime(string key, DateTime value)
    {
      this._elements[key] = (PdfItem) new PdfDate(value);
    }

    internal int GetEnumFromName(string key, object defaultValue, bool create)
    {
      if (!(defaultValue is Enum))
        throw new ArgumentException(nameof (defaultValue));
      object obj = (object) this[key];
      int enumFromName;
      if (obj == null)
      {
        if (create)
          this[key] = (PdfItem) new PdfName(defaultValue.ToString());
        enumFromName = (int) defaultValue;
      }
      else
      {
        Debug.Assert(obj is Enum);
        enumFromName = (int) Enum.Parse(defaultValue.GetType(), obj.ToString().Substring(1), false);
      }
      return enumFromName;
    }

    internal int GetEnumFromName(string key, object defaultValue)
    {
      return this.GetEnumFromName(key, defaultValue, false);
    }

    internal void SetEnumAsName(string key, object value)
    {
      this._elements[key] = value is Enum ? (PdfItem) new PdfName("/" + value?.ToString()) : throw new ArgumentException(nameof (value));
    }

    public PdfItem GetValue(string key, VCF options)
    {
      PdfItem pdfItem1 = this[key];
      PdfItem pdfItem2;
      switch (pdfItem1)
      {
        case null:
          if (options != 0)
          {
            Type valueType = this.GetValueType(key);
            if (!(valueType != (Type) null))
              throw new NotImplementedException("Cannot create value for key: " + key);
            Debug.Assert(typeof (PdfItem).IsAssignableFrom(valueType), "Type not allowed.");
            PdfObject pdfObject;
            if (typeof (PdfDictionary).IsAssignableFrom(valueType))
            {
              pdfItem1 = (PdfItem) (pdfObject = (PdfObject) this.CreateDictionary(valueType, (PdfDictionary) null));
            }
            else
            {
              if (!typeof (PdfArray).IsAssignableFrom(valueType))
                throw new NotImplementedException("Type other than array or dictionary.");
              pdfItem1 = (PdfItem) (pdfObject = (PdfObject) this.CreateArray(valueType, (PdfArray) null));
            }
            if (options == VCF.CreateIndirect)
            {
              this._ownerDictionary.Owner._irefTable.Add(pdfObject);
              this[key] = (PdfItem) pdfObject.Reference;
              goto default;
            }
            this[key] = (PdfItem) pdfObject;
            goto default;
          }
          goto default;
        case PdfReference pdfReference:
          PdfItem pdfItem3 = (PdfItem) pdfReference.Value;
          if (pdfItem3 == null)
            throw new InvalidOperationException("Indirect reference without value.");
          Type valueType1 = this.GetValueType(key);
          Debug.Assert(valueType1 != (Type) null, "No value type specified in meta information. Please send this file to PDFsharp support.");
          if ((!(valueType1 != (Type) null) ? 0 : (valueType1 != pdfItem3.GetType() ? 1 : 0)) != 0)
          {
            if (typeof (PdfDictionary).IsAssignableFrom(valueType1))
            {
              Debug.Assert(pdfItem3 is PdfDictionary, "Bug in PDFsharp. Please send this file to PDFsharp support.");
              pdfItem3 = (PdfItem) this.CreateDictionary(valueType1, (PdfDictionary) pdfItem3);
            }
            else
            {
              if (!typeof (PdfArray).IsAssignableFrom(valueType1))
                throw new NotImplementedException("Type other than array or dictionary.");
              Debug.Assert(pdfItem3 is PdfArray, "Bug in PDFsharp. Please send this file to PDFsharp support.");
              pdfItem3 = (PdfItem) this.CreateArray(valueType1, (PdfArray) pdfItem3);
            }
          }
          pdfItem2 = pdfItem3;
          break;
        case PdfDictionary dictionary:
          Debug.Assert(!dictionary.IsIndirect);
          Type valueType2 = this.GetValueType(key);
          Debug.Assert(valueType2 != (Type) null, "No value type specified in meta information. Please send this file to PDFsharp support.");
          if (dictionary.GetType() != valueType2)
            dictionary = this.CreateDictionary(valueType2, dictionary);
          pdfItem2 = (PdfItem) dictionary;
          break;
        case PdfArray array:
          Debug.Assert(!array.IsIndirect);
          Type valueType3 = this.GetValueType(key);
          if ((!(valueType3 != (Type) null) ? 0 : (valueType3 != array.GetType() ? 1 : 0)) != 0)
            array = this.CreateArray(valueType3, array);
          pdfItem2 = (PdfItem) array;
          break;
        default:
          pdfItem2 = pdfItem1;
          break;
      }
      return pdfItem2;
    }

    public PdfItem GetValue(string key) => this.GetValue(key, VCF.None);

    private Type GetValueType(string key)
    {
      Type valueType = (Type) null;
      DictionaryMeta meta = this._ownerDictionary.Meta;
      if (meta != null)
      {
        KeyDescriptor keyDescriptor = meta[key];
        if (keyDescriptor != null)
          valueType = keyDescriptor.GetValueType();
      }
      return valueType;
    }

    private PdfArray CreateArray(Type type, PdfArray oldArray)
    {
      PdfArray array;
      if (oldArray == null)
      {
        ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (Binder) null, new Type[1]
        {
          typeof (PdfDocument)
        }, (ParameterModifier[]) null);
        Debug.Assert(constructor != (ConstructorInfo) null, "No appropriate constructor found for type: " + type.Name);
        array = constructor.Invoke(new object[1]
        {
          (object) this._ownerDictionary.Owner
        }) as PdfArray;
      }
      else
      {
        ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (Binder) null, new Type[1]
        {
          typeof (PdfArray)
        }, (ParameterModifier[]) null);
        Debug.Assert(constructor != (ConstructorInfo) null, "No appropriate constructor found for type: " + type.Name);
        array = constructor.Invoke(new object[1]
        {
          (object) oldArray
        }) as PdfArray;
      }
      return array;
    }

    private PdfDictionary CreateDictionary(Type type, PdfDictionary oldDictionary)
    {
      PdfDictionary dictionary;
      if (oldDictionary == null)
      {
        ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (Binder) null, new Type[1]
        {
          typeof (PdfDocument)
        }, (ParameterModifier[]) null);
        Debug.Assert(constructor != (ConstructorInfo) null, "No appropriate constructor found for type: " + type.Name);
        dictionary = constructor.Invoke(new object[1]
        {
          (object) this._ownerDictionary.Owner
        }) as PdfDictionary;
      }
      else
      {
        ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (Binder) null, new Type[1]
        {
          typeof (PdfDictionary)
        }, (ParameterModifier[]) null);
        Debug.Assert(constructor != (ConstructorInfo) null, "No appropriate constructor found for type: " + type.Name);
        dictionary = constructor.Invoke(new object[1]
        {
          (object) oldDictionary
        }) as PdfDictionary;
      }
      return dictionary;
    }

    private PdfItem CreateValue(Type type, PdfDictionary oldValue)
    {
      PdfObject pdfObject = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, (Binder) null, new Type[1]
      {
        typeof (PdfDocument)
      }, (ParameterModifier[]) null).Invoke(new object[1]
      {
        (object) this._ownerDictionary.Owner
      }) as PdfObject;
      if (oldValue != null)
      {
        pdfObject.Reference = oldValue.Reference;
        pdfObject.Reference.Value = pdfObject;
        if (pdfObject is PdfDictionary)
          ((PdfDictionary) pdfObject)._elements = oldValue._elements;
      }
      return (PdfItem) pdfObject;
    }

    public void SetValue(string key, PdfItem value)
    {
      Debug.Assert(((!(value is PdfObject) ? 0 : (((PdfObject) value).Reference == null ? 1 : 0)) | (!(value is PdfObject) ? 1 : 0)) != 0, "You try to set an indirect object directly into a dictionary.");
      this._elements[key] = value;
    }

    public PdfObject GetObject(string key)
    {
      PdfItem pdfItem = this[key];
      return !(pdfItem is PdfReference pdfReference) ? pdfItem as PdfObject : pdfReference.Value;
    }

    public PdfDictionary GetDictionary(string key) => this.GetObject(key) as PdfDictionary;

    public PdfArray GetArray(string key) => this.GetObject(key) as PdfArray;

    public PdfReference GetReference(string key) => this[key] as PdfReference;

    public void SetObject(string key, PdfObject obj)
    {
      this[key] = obj.Reference == null ? (PdfItem) obj : throw new ArgumentException("PdfObject must not be an indirect object.", nameof (obj));
    }

    public void SetReference(string key, PdfObject obj)
    {
      this[key] = obj.Reference != null ? (PdfItem) obj.Reference : throw new ArgumentException("PdfObject must be an indirect object.", nameof (obj));
    }

    public void SetReference(string key, PdfReference iref)
    {
      this[key] = iref != null ? (PdfItem) iref : throw new ArgumentNullException(nameof (iref));
    }

    public bool IsReadOnly => false;

    public IEnumerator<KeyValuePair<string, PdfItem>> GetEnumerator()
    {
      return (IEnumerator<KeyValuePair<string, PdfItem>>) this._elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) this._elements).GetEnumerator();

    public PdfItem this[string key]
    {
      get
      {
        PdfItem pdfItem;
        this._elements.TryGetValue(key, out pdfItem);
        return pdfItem;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        if ((!(value is PdfObject pdfObject) ? 0 : (pdfObject.IsIndirect ? 1 : 0)) != 0)
          value = (PdfItem) pdfObject.Reference;
        this._elements[key] = value;
      }
    }

    public PdfItem this[PdfName key]
    {
      get => this[key.Value];
      set
      {
        int num;
        switch (value)
        {
          case null:
            throw new ArgumentNullException(nameof (value));
          case PdfDictionary pdfDictionary when pdfDictionary._stream != null:
            throw new ArgumentException("A dictionary with stream cannot be a direct value.");
          case PdfObject pdfObject:
            num = pdfObject.IsIndirect ? 1 : 0;
            break;
          default:
            num = 0;
            break;
        }
        if (num != 0)
          value = (PdfItem) pdfObject.Reference;
        this._elements[key.Value] = value;
      }
    }

    public bool Remove(string key) => this._elements.Remove(key);

    public bool Remove(KeyValuePair<string, PdfItem> item) => throw new NotImplementedException();

    public bool ContainsKey(string key) => this._elements.ContainsKey(key);

    public bool Contains(KeyValuePair<string, PdfItem> item) => throw new NotImplementedException();

    public void Clear() => this._elements.Clear();

    public void Add(string key, PdfItem value)
    {
      if (string.IsNullOrEmpty(key))
        throw new ArgumentNullException(nameof (key));
      if (key[0] != '/')
        throw new ArgumentException("The key must start with a slash '/'.");
      if ((!(value is PdfObject pdfObject) ? 0 : (pdfObject.IsIndirect ? 1 : 0)) != 0)
        value = (PdfItem) pdfObject.Reference;
      this._elements.Add(key, value);
    }

    public void Add(KeyValuePair<string, PdfItem> item) => this.Add(item.Key, item.Value);

    public PdfName[] KeyNames
    {
      get
      {
        ICollection keys = (ICollection) this._elements.Keys;
        int count = keys.Count;
        string[] strArray = new string[count];
        keys.CopyTo((Array) strArray, 0);
        PdfName[] keyNames = new PdfName[count];
        for (int index = 0; index < count; ++index)
          keyNames[index] = new PdfName(strArray[index]);
        return keyNames;
      }
    }

    public ICollection<string> Keys
    {
      get
      {
        ICollection keys1 = (ICollection) this._elements.Keys;
        string[] keys2 = new string[keys1.Count];
        keys1.CopyTo((Array) keys2, 0);
        return (ICollection<string>) keys2;
      }
    }

    public bool TryGetValue(string key, out PdfItem value)
    {
      return this._elements.TryGetValue(key, out value);
    }

    public ICollection<PdfItem> Values
    {
      get
      {
        ICollection values1 = (ICollection) this._elements.Values;
        PdfItem[] values2 = new PdfItem[values1.Count];
        values1.CopyTo((Array) values2, 0);
        return (ICollection<PdfItem>) values2;
      }
    }

    public bool IsFixedSize => false;

    public bool IsSynchronized => false;

    public int Count => this._elements.Count;

    public void CopyTo(KeyValuePair<string, PdfItem>[] array, int arrayIndex)
    {
      throw new NotImplementedException();
    }

    public object SyncRoot => (object) null;

    internal string DebuggerDisplay
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "key={0}:(", (object) this._elements.Count);
        bool flag = false;
        foreach (string key in (IEnumerable<string>) this._elements.Keys)
        {
          if (flag)
            stringBuilder.Append(' ');
          flag = true;
          stringBuilder.Append(key);
        }
        stringBuilder.Append(")");
        return stringBuilder.ToString();
      }
    }
  }

  public sealed class PdfStream
  {
    private PdfDictionary _ownerDictionary;
    private byte[] _value;

    internal PdfStream(PdfDictionary ownerDictionary)
    {
      this._ownerDictionary = ownerDictionary != null ? ownerDictionary : throw new ArgumentNullException(nameof (ownerDictionary));
    }

    internal PdfStream(byte[] value, PdfDictionary owner)
      : this(owner)
    {
      this._value = value;
    }

    public PdfDictionary.PdfStream Clone()
    {
      PdfDictionary.PdfStream pdfStream = (PdfDictionary.PdfStream) this.MemberwiseClone();
      pdfStream._ownerDictionary = (PdfDictionary) null;
      if (pdfStream._value != null)
      {
        pdfStream._value = new byte[pdfStream._value.Length];
        this._value.CopyTo((Array) pdfStream._value, 0);
      }
      return pdfStream;
    }

    internal void ChangeOwner(PdfDictionary dict)
    {
      if (this._ownerDictionary != null)
        ;
      this._ownerDictionary = dict;
      this._ownerDictionary._stream = this;
    }

    public int Length => this._value != null ? this._value.Length : 0;

    internal bool HasDecodeParams
    {
      get => this._ownerDictionary.Elements.GetDictionary("/DecodeParms") != null;
    }

    internal int DecodePredictor
    {
      get
      {
        PdfDictionary dictionary = this._ownerDictionary.Elements.GetDictionary("/DecodeParms");
        return dictionary == null ? 0 : dictionary.Elements.GetInteger("/Predictor");
      }
    }

    internal int DecodeColumns
    {
      get
      {
        PdfDictionary dictionary = this._ownerDictionary.Elements.GetDictionary("/DecodeParms");
        return dictionary == null ? 0 : dictionary.Elements.GetInteger("/Columns");
      }
    }

    public byte[] Value
    {
      get => this._value;
      set
      {
        this._value = value != null ? value : throw new ArgumentNullException(nameof (value));
        this._ownerDictionary.Elements.SetInteger("/Length", value.Length);
      }
    }

    public byte[] UnfilteredValue
    {
      get
      {
        byte[] numArray = (byte[]) null;
        if (this._value != null)
        {
          PdfItem element = this._ownerDictionary.Elements["/Filter"];
          if (element != null)
          {
            numArray = Filtering.Decode(this._value, element) ?? PdfEncoders.RawEncoding.GetBytes($"«Cannot decode filter '{element}'»");
          }
          else
          {
            numArray = new byte[this._value.Length];
            this._value.CopyTo((Array) numArray, 0);
          }
        }
        return numArray ?? new byte[0];
      }
    }

    public bool TryUnfilter()
    {
      bool flag;
      if (this._value != null)
      {
        PdfItem element = this._ownerDictionary.Elements["/Filter"];
        if (element != null)
        {
          byte[] numArray = Filtering.Decode(this._value, element);
          if (numArray != null)
          {
            this._ownerDictionary.Elements.Remove("/Filter");
            this.Value = numArray;
          }
          else
          {
            flag = false;
            goto label_6;
          }
        }
      }
      flag = true;
label_6:
      return flag;
    }

    public void Zip()
    {
      if (this._value == null || this._ownerDictionary.Elements.ContainsKey("/Filter"))
        return;
      this._value = Filtering.FlateDecode.Encode(this._value, this._ownerDictionary._document.Options.FlateEncodeMode);
      this._ownerDictionary.Elements["/Filter"] = (PdfItem) new PdfName("/FlateDecode");
      this._ownerDictionary.Elements["/Length"] = (PdfItem) new PdfInteger(this._value.Length);
    }

    public override string ToString()
    {
      string str1;
      if (this._value == null)
      {
        str1 = "«null»";
      }
      else
      {
        PdfItem element = this._ownerDictionary.Elements["/Filter"];
        string str2;
        if (element != null)
        {
          byte[] bytes = Filtering.Decode(this._value, element);
          if (bytes == null)
            throw new NotImplementedException("Unknown filter");
          str2 = PdfEncoders.RawEncoding.GetString(bytes, 0, bytes.Length);
        }
        else
          str2 = PdfEncoders.RawEncoding.GetString(this._value, 0, this._value.Length);
        str1 = str2;
      }
      return str1;
    }

    public class Keys : KeysBase
    {
      [KeyInfo(KeyType.Integer | KeyType.Required)]
      public const string Length = "/Length";
      [KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
      public const string Filter = "/Filter";
      [KeyInfo(KeyType.ArrayOrDictionary | KeyType.Optional)]
      public const string DecodeParms = "/DecodeParms";
      [KeyInfo("1.2", KeyType.String | KeyType.Optional)]
      public const string F = "/F";
      [KeyInfo("1.2", KeyType.NameOrArray | KeyType.Optional)]
      public const string FFilter = "/FFilter";
      [KeyInfo("1.2", KeyType.ArrayOrDictionary | KeyType.Optional)]
      public const string FDecodeParms = "/FDecodeParms";
      [KeyInfo("1.5", KeyType.Integer | KeyType.Optional)]
      public const string DL = "/DL";
    }
  }
}
