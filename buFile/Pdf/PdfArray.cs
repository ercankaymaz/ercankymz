// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfArray
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#nullable disable
namespace PdfSharp.Pdf;

[System.Diagnostics.DebuggerDisplay("{DebuggerDisplay}")]
public class PdfArray : PdfObject, IEnumerable<PdfItem>, IEnumerable
{
  private PdfArray.ArrayElements _elements;

  public PdfArray()
  {
  }

  public PdfArray(PdfDocument document)
    : base(document)
  {
  }

  public PdfArray(PdfDocument document, params PdfItem[] items)
    : base(document)
  {
    foreach (PdfItem pdfItem in items)
      this.Elements.Add(pdfItem);
  }

  protected PdfArray(PdfArray array)
    : base((PdfObject) array)
  {
    if (array._elements == null)
      return;
    array._elements.ChangeOwner(this);
  }

  public PdfArray Clone() => (PdfArray) this.Copy();

  protected override object Copy()
  {
    PdfArray pdfArray = (PdfArray) base.Copy();
    if (pdfArray._elements != null)
    {
      pdfArray._elements = pdfArray._elements.Clone();
      int count = pdfArray._elements.Count;
      for (int index = 0; index < count; ++index)
      {
        PdfItem element = pdfArray._elements[index];
        if (element is PdfObject)
          pdfArray._elements[index] = element.Clone();
      }
    }
    return (object) pdfArray;
  }

  public PdfArray.ArrayElements Elements
  {
    get => this._elements ?? (this._elements = new PdfArray.ArrayElements(this));
  }

  public virtual IEnumerator<PdfItem> GetEnumerator() => this.Elements.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("[ ");
    int count = this.Elements.Count;
    for (int index = 0; index < count; ++index)
      stringBuilder.Append(this.Elements[index]?.ToString() + " ");
    stringBuilder.Append("]");
    return stringBuilder.ToString();
  }

  internal override void WriteObject(PdfWriter writer)
  {
    writer.WriteBeginObject((PdfObject) this);
    int count = this.Elements.Count;
    for (int index = 0; index < count; ++index)
      this.Elements[index].WriteObject(writer);
    writer.WriteEndObject();
  }

  private string DebuggerDisplay
  {
    get
    {
      return string.Format((IFormatProvider) CultureInfo.InvariantCulture, "array({0},[{1}])", (object) this.ObjectID.DebuggerDisplay, (object) (this._elements == null ? 0 : this._elements.Count));
    }
  }

  public sealed class ArrayElements : 
    IList<PdfItem>,
    ICollection<PdfItem>,
    IEnumerable<PdfItem>,
    IEnumerable,
    ICloneable
  {
    private List<PdfItem> _elements;
    private PdfArray _ownerArray;

    internal ArrayElements(PdfArray array)
    {
      this._elements = new List<PdfItem>();
      this._ownerArray = array;
    }

    object ICloneable.Clone()
    {
      PdfArray.ArrayElements arrayElements = (PdfArray.ArrayElements) this.MemberwiseClone();
      arrayElements._elements = new List<PdfItem>((IEnumerable<PdfItem>) arrayElements._elements);
      arrayElements._ownerArray = (PdfArray) null;
      return (object) arrayElements;
    }

    public PdfArray.ArrayElements Clone() => (PdfArray.ArrayElements) ((ICloneable) this).Clone();

    internal void ChangeOwner(PdfArray array)
    {
      if (this._ownerArray != null)
        ;
      this._ownerArray = array;
      array._elements = this;
    }

    public bool GetBoolean(int index)
    {
      if ((index < 0 ? 1 : (index >= this.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.IndexOutOfRange);
      switch ((object) this[index])
      {
        case null:
          return false;
        case PdfBoolean pdfBoolean:
          return pdfBoolean.Value;
        case PdfBooleanObject pdfBooleanObject:
          return pdfBooleanObject.Value;
        default:
          throw new InvalidCastException("GetBoolean: Object is not a boolean.");
      }
    }

    public int GetInteger(int index)
    {
      if ((index < 0 ? 1 : (index >= this.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.IndexOutOfRange);
      switch ((object) this[index])
      {
        case null:
          return 0;
        case PdfInteger pdfInteger:
          return pdfInteger.Value;
        case PdfIntegerObject pdfIntegerObject:
          return pdfIntegerObject.Value;
        default:
          throw new InvalidCastException("GetInteger: Object is not an integer.");
      }
    }

    public double GetReal(int index)
    {
      if ((index < 0 ? 1 : (index >= this.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.IndexOutOfRange);
      switch ((object) this[index])
      {
        case null:
          return 0.0;
        case PdfReal pdfReal:
          return pdfReal.Value;
        case PdfRealObject pdfRealObject:
          return pdfRealObject.Value;
        case PdfInteger pdfInteger:
          return (double) pdfInteger.Value;
        case PdfIntegerObject pdfIntegerObject:
          return (double) pdfIntegerObject.Value;
        default:
          throw new InvalidCastException("GetReal: Object is not a number.");
      }
    }

    public double? GetNullableReal(int index)
    {
      if ((index < 0 ? 1 : (index >= this.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.IndexOutOfRange);
      switch ((object) this[index])
      {
        case null:
          return new double?();
        case PdfNull _:
          return new double?();
        case PdfNullObject _:
          return new double?();
        case PdfReal pdfReal:
          return new double?(pdfReal.Value);
        case PdfRealObject pdfRealObject:
          return new double?(pdfRealObject.Value);
        case PdfInteger pdfInteger:
          return new double?((double) pdfInteger.Value);
        case PdfIntegerObject pdfIntegerObject:
          return new double?((double) pdfIntegerObject.Value);
        default:
          throw new InvalidCastException("GetReal: Object is not a number.");
      }
    }

    public string GetString(int index)
    {
      if ((index < 0 ? 1 : (index >= this.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.IndexOutOfRange);
      switch ((object) this[index])
      {
        case null:
          return string.Empty;
        case PdfString pdfString:
          return pdfString.Value;
        case PdfStringObject pdfStringObject:
          return pdfStringObject.Value;
        default:
          throw new InvalidCastException("GetString: Object is not a string.");
      }
    }

    public string GetName(int index)
    {
      object obj = (index < 0 ? 1 : (index >= this.Count ? 1 : 0)) == 0 ? (object) this[index] : throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.IndexOutOfRange);
      if (obj == null)
        return string.Empty;
      PdfName pdfName = obj as PdfName;
      if (pdfName != (string) null)
        return pdfName.Value;
      PdfNameObject pdfNameObject = obj as PdfNameObject;
      return pdfNameObject != (string) null ? pdfNameObject.Value : throw new InvalidCastException("GetName: Object is not a name.");
    }

    [Obsolete("Use GetObject, GetDictionary, GetArray, or GetReference")]
    public PdfObject GetIndirectObject(int index)
    {
      if ((index < 0 ? 1 : (index >= this.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.IndexOutOfRange);
      return !(this[index] is PdfReference pdfReference) ? (PdfObject) null : pdfReference.Value;
    }

    public PdfObject GetObject(int index)
    {
      PdfItem pdfItem = (index < 0 ? 1 : (index >= this.Count ? 1 : 0)) == 0 ? this[index] : throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.IndexOutOfRange);
      return !(pdfItem is PdfReference pdfReference) ? pdfItem as PdfObject : pdfReference.Value;
    }

    public PdfDictionary GetDictionary(int index) => this.GetObject(index) as PdfDictionary;

    public PdfArray GetArray(int index) => this.GetObject(index) as PdfArray;

    public PdfReference GetReference(int index) => this[index] as PdfReference;

    public PdfItem[] Items => this._elements.ToArray();

    public bool IsReadOnly => false;

    public PdfItem this[int index]
    {
      get => this._elements[index];
      set
      {
        this._elements[index] = value != null ? value : throw new ArgumentNullException(nameof (value));
      }
    }

    public void RemoveAt(int index) => this._elements.RemoveAt(index);

    public bool Remove(PdfItem item) => this._elements.Remove(item);

    public void Insert(int index, PdfItem value) => this._elements.Insert(index, value);

    public bool Contains(PdfItem value) => this._elements.Contains(value);

    public void Clear() => this._elements.Clear();

    public int IndexOf(PdfItem value) => this._elements.IndexOf(value);

    public void Add(PdfItem value)
    {
      if ((!(value is PdfObject pdfObject) ? 0 : (pdfObject.IsIndirect ? 1 : 0)) != 0)
        this._elements.Add((PdfItem) pdfObject.Reference);
      else
        this._elements.Add(value);
    }

    public bool IsFixedSize => false;

    public bool IsSynchronized => false;

    public int Count => this._elements.Count;

    public void CopyTo(PdfItem[] array, int index) => this._elements.CopyTo(array, index);

    public object SyncRoot => (object) null;

    public IEnumerator<PdfItem> GetEnumerator()
    {
      return (IEnumerator<PdfItem>) this._elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._elements.GetEnumerator();
  }
}
