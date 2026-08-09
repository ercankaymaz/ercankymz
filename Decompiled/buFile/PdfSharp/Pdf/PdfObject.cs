#define DEBUG
using System;
using System.Diagnostics;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

public abstract class PdfObject : PdfItem
{
	internal PdfDocument _document;

	private PdfObjectInternals _internals;

	private PdfReference _iref;

	public virtual PdfDocument Owner => _document;

	internal virtual PdfDocument Document
	{
		set
		{
			if (_document != value)
			{
				if (_document != null)
				{
					throw new InvalidOperationException("Cannot change document.");
				}
				_document = value;
				if (_iref != null)
				{
					_iref.Document = value;
				}
			}
		}
	}

	public bool IsIndirect => _iref != null;

	public PdfObjectInternals Internals => _internals ?? (_internals = new PdfObjectInternals(this));

	internal PdfObjectID ObjectID => (_iref != null) ? _iref.ObjectID : PdfObjectID.Empty;

	internal int ObjectNumber => ObjectID.ObjectNumber;

	internal int GenerationNumber => ObjectID.GenerationNumber;

	public PdfReference Reference
	{
		get
		{
			return _iref;
		}
		internal set
		{
			_iref = value;
		}
	}

	protected PdfObject()
	{
	}

	protected PdfObject(PdfDocument document)
	{
		Document = document;
	}

	protected PdfObject(PdfObject obj)
		: this(obj.Owner)
	{
		if (obj._iref != null)
		{
			obj._iref.Value = this;
		}
	}

	public new PdfObject Clone()
	{
		return (PdfObject)Copy();
	}

	protected override object Copy()
	{
		PdfObject pdfObject = (PdfObject)base.Copy();
		pdfObject._document = null;
		pdfObject._iref = null;
		return pdfObject;
	}

	internal void SetObjectID(int objectNumber, int generationNumber)
	{
		PdfObjectID objectID = new PdfObjectID(objectNumber, generationNumber);
		if (_iref == null)
		{
			_iref = _document._irefTable[objectID];
		}
		if (_iref == null)
		{
			new PdfReference(this);
			Debug.Assert(_iref != null);
			_iref.ObjectID = objectID;
		}
		_iref.Value = this;
		_iref.Document = _document;
	}

	internal virtual void PrepareForSave()
	{
	}

	internal override void WriteObject(PdfWriter writer)
	{
		Debug.Assert(condition: false, "Must not come here!");
	}

	internal static PdfObject DeepCopyClosure(PdfDocument owner, PdfObject externalObject)
	{
		PdfObject[] closure = externalObject.Owner.Internals.GetClosure(externalObject);
		int num = closure.Length;
		PdfImportedObjectTable pdfImportedObjectTable = new PdfImportedObjectTable(owner, externalObject.Owner);
		for (int i = 0; i < num; i++)
		{
			PdfObject pdfObject = closure[i];
			PdfObject pdfObject2 = pdfObject.Clone();
			Debug.Assert(pdfObject2.Reference == null);
			pdfObject2.Document = owner;
			if (pdfObject.Reference != null)
			{
				owner._irefTable.Add(pdfObject2);
				Debug.Assert(pdfObject2.Reference != null);
				pdfImportedObjectTable.Add(pdfObject.ObjectID, pdfObject2.Reference);
			}
			else
			{
				Debug.Assert(i == 0);
			}
			closure[i] = pdfObject2;
		}
		for (int j = 0; j < num; j++)
		{
			PdfObject pdfObject3 = closure[j];
			Debug.Assert(pdfObject3.Owner == owner);
			FixUpObject(pdfImportedObjectTable, owner, pdfObject3);
		}
		return closure[0];
	}

	internal static PdfObject ImportClosure(PdfImportedObjectTable importedObjectTable, PdfDocument owner, PdfObject externalObject)
	{
		Debug.Assert(importedObjectTable.Owner == owner, "importedObjectTable does not belong to the owner.");
		Debug.Assert(importedObjectTable.ExternalDocument == externalObject.Owner, "The ExternalDocument of the importedObjectTable does not belong to the owner of object to be imported.");
		PdfObject[] closure = externalObject.Owner.Internals.GetClosure(externalObject);
		int num = closure.Length;
		for (int i = 0; i < num; i++)
		{
			PdfObject pdfObject = closure[i];
			Debug.Assert(pdfObject.Owner != owner);
			if (importedObjectTable.Contains(pdfObject.ObjectID))
			{
				PdfReference pdfReference = importedObjectTable[pdfObject.ObjectID];
				Debug.Assert(pdfReference != null);
				Debug.Assert(pdfReference.Value != null);
				Debug.Assert(pdfReference.Document == owner);
				closure[i] = pdfReference.Value;
				continue;
			}
			PdfObject pdfObject2 = pdfObject.Clone();
			Debug.Assert(pdfObject2.Reference == null);
			pdfObject2.Document = owner;
			if (pdfObject.Reference != null)
			{
				owner._irefTable.Add(pdfObject2);
				Debug.Assert(pdfObject2.Reference != null);
				importedObjectTable.Add(pdfObject.ObjectID, pdfObject2.Reference);
			}
			else
			{
				Debug.Assert(i == 0);
			}
			closure[i] = pdfObject2;
		}
		for (int j = 0; j < num; j++)
		{
			PdfObject value = closure[j];
			Debug.Assert(owner != null);
			FixUpObject(importedObjectTable, importedObjectTable.Owner, value);
		}
		return closure[0];
	}

	private static void FixUpObject(PdfImportedObjectTable iot, PdfDocument owner, PdfObject value)
	{
		Debug.Assert(iot.Owner == owner);
		if (value is PdfDictionary pdfDictionary)
		{
			if (pdfDictionary.Owner == null)
			{
				pdfDictionary.Document = owner;
			}
			else
			{
				Debug.Assert(pdfDictionary.Owner == owner);
			}
			PdfName[] keyNames = pdfDictionary.Elements.KeyNames;
			PdfName[] array = keyNames;
			foreach (PdfName key in array)
			{
				PdfItem pdfItem = pdfDictionary.Elements[key];
				Debug.Assert(pdfItem != null, "A dictionary element cannot be null.");
				if (pdfItem is PdfReference pdfReference)
				{
					if (pdfReference.Document != owner)
					{
						PdfReference pdfReference2 = iot[pdfReference.ObjectID];
						Debug.Assert(pdfReference2 != null);
						Debug.Assert(pdfReference2.Document == owner);
						pdfDictionary.Elements[key] = pdfReference2;
					}
				}
				else if (pdfItem is PdfObject value2)
				{
					FixUpObject(iot, owner, value2);
				}
				else
				{
					DebugCheckNonObjects(pdfItem);
				}
			}
		}
		else if (value is PdfArray pdfArray)
		{
			if (pdfArray.Owner == null)
			{
				pdfArray.Document = owner;
			}
			else
			{
				Debug.Assert(pdfArray.Owner == owner);
			}
			int count = pdfArray.Elements.Count;
			for (int j = 0; j < count; j++)
			{
				PdfItem pdfItem2 = pdfArray.Elements[j];
				Debug.Assert(pdfItem2 != null, "An array element cannot be null.");
				if (pdfItem2 is PdfReference pdfReference3)
				{
					if (pdfReference3.Document != owner)
					{
						Debug.Assert(pdfReference3.Document == iot.ExternalDocument);
						PdfReference pdfReference4 = iot[pdfReference3.ObjectID];
						Debug.Assert(pdfReference4 != null);
						Debug.Assert(pdfReference4.Document == owner);
						pdfArray.Elements[j] = pdfReference4;
					}
				}
				else if (pdfItem2 is PdfObject value3)
				{
					FixUpObject(iot, owner, value3);
				}
				else
				{
					DebugCheckNonObjects(pdfItem2);
				}
			}
		}
		else if (value is PdfNameObject || value is PdfStringObject || value is PdfBooleanObject || value is PdfIntegerObject || value is PdfNumberObject)
		{
			Debug.Assert(value.IsIndirect);
			Debug.Assert(value.Owner == owner);
		}
		else
		{
			Debug.Assert(condition: false, "Should not come here. Object is neither a dictionary nor an array.");
		}
	}

	[Conditional("DEBUG")]
	private static void DebugCheckNonObjects(PdfItem item)
	{
		if (!(item is PdfName) && !(item is PdfBoolean) && !(item is PdfInteger) && !(item is PdfNumber) && !(item is PdfString) && !(item is PdfRectangle) && !(item is PdfNull))
		{
			Type type = item.GetType();
			Debug.Assert(type != null, $"CheckNonObjects: Add {type.Name} to the list.");
		}
	}
}
