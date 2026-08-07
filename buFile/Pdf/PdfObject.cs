// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfObject
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

public abstract class PdfObject : PdfItem
{
  internal PdfDocument _document;
  private PdfObjectInternals _internals;
  private PdfReference _iref;

  protected PdfObject()
  {
  }

  protected PdfObject(PdfDocument document) => this.Document = document;

  protected PdfObject(PdfObject obj)
    : this(obj.Owner)
  {
    if (obj._iref == null)
      return;
    obj._iref.Value = this;
  }

  public PdfObject Clone() => (PdfObject) this.Copy();

  protected override object Copy()
  {
    PdfObject pdfObject = (PdfObject) base.Copy();
    pdfObject._document = (PdfDocument) null;
    pdfObject._iref = (PdfReference) null;
    return (object) pdfObject;
  }

  internal void SetObjectID(int objectNumber, int generationNumber)
  {
    PdfObjectID objectID = new PdfObjectID(objectNumber, generationNumber);
    if (this._iref == null)
      this._iref = this._document._irefTable[objectID];
    if (this._iref == null)
    {
      PdfReference pdfReference = new PdfReference(this);
      Debug.Assert(this._iref != null);
      this._iref.ObjectID = objectID;
    }
    this._iref.Value = this;
    this._iref.Document = this._document;
  }

  public virtual PdfDocument Owner => this._document;

  internal virtual PdfDocument Document
  {
    set
    {
      if (this._document == value)
        return;
      this._document = this._document == null ? value : throw new InvalidOperationException("Cannot change document.");
      if (this._iref == null)
        return;
      this._iref.Document = value;
    }
  }

  public bool IsIndirect => this._iref != null;

  public PdfObjectInternals Internals
  {
    get => this._internals ?? (this._internals = new PdfObjectInternals(this));
  }

  internal virtual void PrepareForSave()
  {
  }

  internal override void WriteObject(PdfWriter writer)
  {
    Debug.Assert(false, "Must not come here!");
  }

  internal PdfObjectID ObjectID => this._iref != null ? this._iref.ObjectID : PdfObjectID.Empty;

  internal int ObjectNumber => this.ObjectID.ObjectNumber;

  internal int GenerationNumber => this.ObjectID.GenerationNumber;

  internal static PdfObject DeepCopyClosure(PdfDocument owner, PdfObject externalObject)
  {
    PdfObject[] closure = externalObject.Owner.Internals.GetClosure(externalObject);
    int length = closure.Length;
    PdfImportedObjectTable iot = new PdfImportedObjectTable(owner, externalObject.Owner);
    for (int index = 0; index < length; ++index)
    {
      PdfObject pdfObject1 = closure[index];
      PdfObject pdfObject2 = pdfObject1.Clone();
      Debug.Assert(pdfObject2.Reference == null);
      pdfObject2.Document = owner;
      if (pdfObject1.Reference != null)
      {
        owner._irefTable.Add(pdfObject2);
        Debug.Assert(pdfObject2.Reference != null);
        iot.Add(pdfObject1.ObjectID, pdfObject2.Reference);
      }
      else
        Debug.Assert(index == 0);
      closure[index] = pdfObject2;
    }
    for (int index = 0; index < length; ++index)
    {
      PdfObject pdfObject = closure[index];
      Debug.Assert(pdfObject.Owner == owner);
      PdfObject.FixUpObject(iot, owner, pdfObject);
    }
    return closure[0];
  }

  internal static PdfObject ImportClosure(
    PdfImportedObjectTable importedObjectTable,
    PdfDocument owner,
    PdfObject externalObject)
  {
    Debug.Assert(importedObjectTable.Owner == owner, "importedObjectTable does not belong to the owner.");
    Debug.Assert(importedObjectTable.ExternalDocument == externalObject.Owner, "The ExternalDocument of the importedObjectTable does not belong to the owner of object to be imported.");
    PdfObject[] closure = externalObject.Owner.Internals.GetClosure(externalObject);
    int length = closure.Length;
    for (int index = 0; index < length; ++index)
    {
      PdfObject pdfObject1 = closure[index];
      Debug.Assert(pdfObject1.Owner != owner);
      if (importedObjectTable.Contains(pdfObject1.ObjectID))
      {
        PdfReference pdfReference = importedObjectTable[pdfObject1.ObjectID];
        Debug.Assert(pdfReference != null);
        Debug.Assert(pdfReference.Value != null);
        Debug.Assert(pdfReference.Document == owner);
        closure[index] = pdfReference.Value;
      }
      else
      {
        PdfObject pdfObject2 = pdfObject1.Clone();
        Debug.Assert(pdfObject2.Reference == null);
        pdfObject2.Document = owner;
        if (pdfObject1.Reference != null)
        {
          owner._irefTable.Add(pdfObject2);
          Debug.Assert(pdfObject2.Reference != null);
          importedObjectTable.Add(pdfObject1.ObjectID, pdfObject2.Reference);
        }
        else
          Debug.Assert(index == 0);
        closure[index] = pdfObject2;
      }
    }
    for (int index = 0; index < length; ++index)
    {
      PdfObject pdfObject = closure[index];
      Debug.Assert(owner != null);
      PdfObject.FixUpObject(importedObjectTable, importedObjectTable.Owner, pdfObject);
    }
    return closure[0];
  }

  private static void FixUpObject(PdfImportedObjectTable iot, PdfDocument owner, PdfObject value)
  {
    Debug.Assert(iot.Owner == owner);
    if (value is PdfDictionary pdfDictionary)
    {
      if (pdfDictionary.Owner == null)
        pdfDictionary.Document = owner;
      else
        Debug.Assert(pdfDictionary.Owner == owner);
      foreach (PdfName keyName in pdfDictionary.Elements.KeyNames)
      {
        PdfItem element = pdfDictionary.Elements[keyName];
        Debug.Assert(element != null, "A dictionary element cannot be null.");
        switch (element)
        {
          case PdfReference pdfReference1:
            if (pdfReference1.Document != owner)
            {
              PdfReference pdfReference = iot[pdfReference1.ObjectID];
              Debug.Assert(pdfReference != null);
              Debug.Assert(pdfReference.Document == owner);
              pdfDictionary.Elements[keyName] = (PdfItem) pdfReference;
              break;
            }
            break;
          case PdfObject pdfObject:
            PdfObject.FixUpObject(iot, owner, pdfObject);
            break;
          default:
            PdfObject.DebugCheckNonObjects(element);
            break;
        }
      }
    }
    else if (value is PdfArray pdfArray)
    {
      if (pdfArray.Owner == null)
        pdfArray.Document = owner;
      else
        Debug.Assert(pdfArray.Owner == owner);
      int count = pdfArray.Elements.Count;
      for (int index = 0; index < count; ++index)
      {
        PdfItem element = pdfArray.Elements[index];
        Debug.Assert(element != null, "An array element cannot be null.");
        switch (element)
        {
          case PdfReference pdfReference2:
            if (pdfReference2.Document != owner)
            {
              Debug.Assert(pdfReference2.Document == iot.ExternalDocument);
              PdfReference pdfReference = iot[pdfReference2.ObjectID];
              Debug.Assert(pdfReference != null);
              Debug.Assert(pdfReference.Document == owner);
              pdfArray.Elements[index] = (PdfItem) pdfReference;
              break;
            }
            break;
          case PdfObject pdfObject:
            PdfObject.FixUpObject(iot, owner, pdfObject);
            break;
          default:
            PdfObject.DebugCheckNonObjects(element);
            break;
        }
      }
    }
    else
    {
      int num;
      if ((object) (value as PdfNameObject) == null)
      {
        switch (value)
        {
          case PdfStringObject _:
          case PdfBooleanObject _:
          case PdfIntegerObject _:
            break;
          default:
            num = value is PdfNumberObject ? 1 : 0;
            goto label_28;
        }
      }
      num = 1;
label_28:
      if (num != 0)
      {
        Debug.Assert(value.IsIndirect);
        Debug.Assert(value.Owner == owner);
      }
      else
        Debug.Assert(false, "Should not come here. Object is neither a dictionary nor an array.");
    }
  }

  [Conditional("DEBUG")]
  private static void DebugCheckNonObjects(PdfItem item)
  {
    switch (item)
    {
      case PdfName _:
        break;
      case PdfBoolean _:
        break;
      case PdfInteger _:
        break;
      case PdfNumber _:
        break;
      case PdfString _:
        break;
      case PdfRectangle _:
        break;
      case PdfNull _:
        break;
      default:
        Type type = item.GetType();
        Debug.Assert(type != (Type) null, $"CheckNonObjects: Add {type.Name} to the list.");
        break;
    }
  }

  public PdfReference Reference
  {
    get => this._iref;
    internal set => this._iref = value;
  }
}
