// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfCrossReferenceTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfCrossReferenceTable
{
  private readonly PdfDocument _document;
  public Dictionary<PdfObjectID, PdfReference> ObjectTable = new Dictionary<PdfObjectID, PdfReference>();
  private bool _isUnderConstruction;
  internal int _maxObjectNumber;
  private static int _nestingLevel;
  private Dictionary<PdfItem, object> _overflow = new Dictionary<PdfItem, object>();
  private PdfDictionary _deadObject;

  public PdfCrossReferenceTable(PdfDocument document) => this._document = document;

  internal bool IsUnderConstruction
  {
    get => this._isUnderConstruction;
    set => this._isUnderConstruction = value;
  }

  public void Add(PdfReference iref)
  {
    if (iref.ObjectID.ObjectNumber == 948)
      this.GetType();
    if (iref.ObjectID.IsEmpty)
      iref.ObjectID = new PdfObjectID(this.GetNewObjectNumber());
    if (this.ObjectTable.ContainsKey(iref.ObjectID))
      throw new InvalidOperationException("Object already in table.");
    this.ObjectTable.Add(iref.ObjectID, iref);
  }

  public void Add(PdfObject value)
  {
    if (value.Owner == null)
      value.Document = this._document;
    else
      Debug.Assert(value.Owner == this._document);
    if (value.ObjectID.IsEmpty)
      value.SetObjectID(this.GetNewObjectNumber(), 0);
    if (this.ObjectTable.ContainsKey(value.ObjectID))
      throw new InvalidOperationException("Object already in table.");
    this.ObjectTable.Add(value.ObjectID, value.Reference);
  }

  public void Remove(PdfReference iref) => this.ObjectTable.Remove(iref.ObjectID);

  public PdfReference this[PdfObjectID objectID]
  {
    get
    {
      PdfReference pdfReference;
      this.ObjectTable.TryGetValue(objectID, out pdfReference);
      return pdfReference;
    }
  }

  public bool Contains(PdfObjectID objectID) => this.ObjectTable.ContainsKey(objectID);

  public int GetNewObjectNumber() => ++this._maxObjectNumber;

  internal void WriteObject(PdfWriter writer)
  {
    writer.WriteRaw("xref\n");
    PdfReference[] allReferences = this.AllReferences;
    int length = allReferences.Length;
    writer.WriteRaw($"0 {length + 1}\n");
    writer.WriteRaw($"{0:0000000000} {(int) ushort.MaxValue:00000} {"f"} \n");
    for (int index = 0; index < length; ++index)
    {
      PdfReference pdfReference = allReferences[index];
      writer.WriteRaw($"{pdfReference.Position:0000000000} {pdfReference.GenerationNumber:00000} {"n"} \n");
    }
  }

  internal PdfObjectID[] AllObjectIDs
  {
    get
    {
      ICollection keys = (ICollection) this.ObjectTable.Keys;
      PdfObjectID[] allObjectIds = new PdfObjectID[keys.Count];
      keys.CopyTo((Array) allObjectIds, 0);
      return allObjectIds;
    }
  }

  internal PdfReference[] AllReferences
  {
    get
    {
      Dictionary<PdfObjectID, PdfReference>.ValueCollection values = this.ObjectTable.Values;
      List<PdfReference> pdfReferenceList = new List<PdfReference>((IEnumerable<PdfReference>) values);
      pdfReferenceList.Sort((IComparer<PdfReference>) PdfReference.Comparer);
      PdfReference[] array = new PdfReference[values.Count];
      pdfReferenceList.CopyTo(array, 0);
      return array;
    }
  }

  internal void HandleOrphanedReferences()
  {
  }

  internal int Compact()
  {
    int count = this.ObjectTable.Count;
    PdfReference[] pdfReferenceArray = this.TransitiveClosure((PdfObject) this._document._trailer);
    Dictionary<int, int> dictionary1 = new Dictionary<int, int>();
    foreach (PdfObjectID key in this.ObjectTable.Keys)
      dictionary1.Add(key.ObjectNumber, 0);
    dictionary1.Clear();
    foreach (PdfReference pdfReference in this.ObjectTable.Values)
      dictionary1.Add(pdfReference.ObjectNumber, 0);
    Dictionary<PdfReference, int> dictionary2 = new Dictionary<PdfReference, int>();
    foreach (PdfReference key in pdfReferenceArray)
      dictionary2.Add(key, 0);
    foreach (PdfReference key in this.ObjectTable.Values)
    {
      if (!dictionary2.ContainsKey(key))
        key.GetType();
    }
    foreach (PdfReference pdfReference in this.ObjectTable.Values)
    {
      if (pdfReference.Value == null)
        this.GetType();
      Debug.Assert(pdfReference.Value != null);
    }
    foreach (PdfReference pdfReference in pdfReferenceArray)
    {
      if (!this.ObjectTable.ContainsKey(pdfReference.ObjectID))
        this.GetType();
      Debug.Assert(this.ObjectTable.ContainsKey(pdfReference.ObjectID));
      if (pdfReference.Value == null)
        this.GetType();
      Debug.Assert(pdfReference.Value != null);
    }
    this._maxObjectNumber = 0;
    this.ObjectTable.Clear();
    foreach (PdfReference pdfReference in pdfReferenceArray)
    {
      if (!this.ObjectTable.ContainsKey(pdfReference.ObjectID))
      {
        this.ObjectTable.Add(pdfReference.ObjectID, pdfReference);
        this._maxObjectNumber = Math.Max(this._maxObjectNumber, pdfReference.ObjectNumber);
      }
    }
    return count - this.ObjectTable.Count;
  }

  internal void Renumber()
  {
    PdfReference[] allReferences = this.AllReferences;
    this.ObjectTable.Clear();
    int length = allReferences.Length;
    for (int index = 0; index < length; ++index)
    {
      PdfReference pdfReference = allReferences[index];
      pdfReference.ObjectID = new PdfObjectID(index + 1);
      this.ObjectTable.Add(pdfReference.ObjectID, pdfReference);
    }
    this._maxObjectNumber = length;
  }

  [Conditional("DEBUG_")]
  public void CheckConsistence()
  {
    Dictionary<PdfReference, object> dictionary1 = new Dictionary<PdfReference, object>();
    foreach (PdfReference key in this.ObjectTable.Values)
    {
      Debug.Assert(!dictionary1.ContainsKey(key), "Duplicate iref.");
      Debug.Assert(key.Value != null);
      dictionary1.Add(key, (object) null);
    }
    Dictionary<PdfObjectID, object> dictionary2 = new Dictionary<PdfObjectID, object>();
    foreach (PdfReference pdfReference in this.ObjectTable.Values)
    {
      Debug.Assert(!dictionary2.ContainsKey(pdfReference.ObjectID), "Duplicate iref.");
      dictionary2.Add(pdfReference.ObjectID, (object) null);
    }
    ICollection values = (ICollection) this.ObjectTable.Values;
    int count = values.Count;
    PdfReference[] pdfReferenceArray = new PdfReference[count];
    values.CopyTo((Array) pdfReferenceArray, 0);
    for (int index1 = 0; index1 < count; ++index1)
    {
      for (int index2 = 0; index2 < count; ++index2)
      {
        if (index1 != index2)
        {
          Debug.Assert(pdfReferenceArray[index1].Document == this._document);
          Debug.Assert(pdfReferenceArray[index1] != pdfReferenceArray[index2]);
          Debug.Assert(pdfReferenceArray[index1] != pdfReferenceArray[index2]);
          Debug.Assert(pdfReferenceArray[index1].Value != pdfReferenceArray[index2].Value);
          Debug.Assert(!object.Equals((object) pdfReferenceArray[index1].ObjectID, (object) pdfReferenceArray[index2].Value.ObjectID));
          Debug.Assert(pdfReferenceArray[index1].ObjectNumber != pdfReferenceArray[index2].Value.ObjectNumber);
          Debug.Assert(pdfReferenceArray[index1].Document == pdfReferenceArray[index2].Document);
          this.GetType();
        }
      }
    }
  }

  public PdfReference[] TransitiveClosure(PdfObject pdfObject)
  {
    return this.TransitiveClosure(pdfObject, (int) short.MaxValue);
  }

  public PdfReference[] TransitiveClosure(PdfObject pdfObject, int depth)
  {
    Dictionary<PdfItem, object> objects = new Dictionary<PdfItem, object>();
    this._overflow = new Dictionary<PdfItem, object>();
    this.TransitiveClosureImplementation(objects, pdfObject);
    while (this._overflow.Count > 0)
    {
      PdfObject[] array = new PdfObject[this._overflow.Count];
      this._overflow.Keys.CopyTo((PdfItem[]) array, 0);
      this._overflow = new Dictionary<PdfItem, object>();
      for (int index = 0; index < array.Length; ++index)
      {
        PdfObject pdfObject1 = array[index];
        this.TransitiveClosureImplementation(objects, pdfObject1);
      }
    }
    ICollection keys = (ICollection) objects.Keys;
    PdfReference[] pdfReferenceArray = new PdfReference[keys.Count];
    keys.CopyTo((Array) pdfReferenceArray, 0);
    return pdfReferenceArray;
  }

  private void TransitiveClosureImplementation(
    Dictionary<PdfItem, object> objects,
    PdfObject pdfObject)
  {
    try
    {
      ++PdfCrossReferenceTable._nestingLevel;
      if (PdfCrossReferenceTable._nestingLevel >= 1000)
      {
        if (this._overflow.ContainsKey((PdfItem) pdfObject))
          return;
        this._overflow.Add((PdfItem) pdfObject, (object) null);
      }
      else
      {
        IEnumerable enumerable = (IEnumerable) null;
        switch (pdfObject)
        {
          case PdfDictionary pdfDictionary:
            enumerable = (IEnumerable) pdfDictionary.Elements.Values;
            break;
          case PdfArray pdfArray:
            enumerable = (IEnumerable) pdfArray.Elements;
            break;
          default:
            Debug.Assert(false, "Should not come here.");
            break;
        }
        if (enumerable == null)
          return;
        foreach (PdfItem pdfItem in enumerable)
        {
          int num;
          switch (pdfItem)
          {
            case PdfReference key:
              if (key.Document != this._document)
              {
                this.GetType();
                Debug.WriteLine($"Bad iref: {key.ObjectID.ToString()}");
              }
              Debug.Assert(key.Document == this._document || key.Document == null, "External object detected!");
              if (!objects.ContainsKey((PdfItem) key))
              {
                PdfObject pdfObject1 = key.Value;
                if (key.Document != null)
                {
                  if (pdfObject1 == null)
                  {
                    key = this.ObjectTable[key.ObjectID];
                    Debug.Assert(key.Value != null);
                    pdfObject1 = key.Value;
                  }
                  Debug.Assert(key.Document == this._document);
                  objects.Add((PdfItem) key, (object) null);
                  if ((pdfObject1 is PdfArray ? 1 : (pdfObject1 is PdfDictionary ? 1 : 0)) != 0)
                  {
                    this.TransitiveClosureImplementation(objects, pdfObject1);
                    continue;
                  }
                  continue;
                }
                continue;
              }
              continue;
            case PdfObject pdfObject2:
              num = pdfObject2 is PdfDictionary ? 1 : (pdfObject2 is PdfArray ? 1 : 0);
              break;
            default:
              num = 0;
              break;
          }
          if (num != 0)
            this.TransitiveClosureImplementation(objects, pdfObject2);
        }
      }
    }
    finally
    {
      --PdfCrossReferenceTable._nestingLevel;
    }
  }

  public PdfReference DeadObject
  {
    get
    {
      if (this._deadObject == null)
      {
        this._deadObject = new PdfDictionary(this._document);
        this.Add((PdfObject) this._deadObject);
        this._deadObject.Elements.Add("/DeadObjectCount", (PdfItem) new PdfInteger());
      }
      return this._deadObject.Reference;
    }
  }
}
