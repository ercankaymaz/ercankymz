#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

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

	internal bool IsUnderConstruction
	{
		get
		{
			return _isUnderConstruction;
		}
		set
		{
			_isUnderConstruction = value;
		}
	}

	public PdfReference this[PdfObjectID objectID]
	{
		get
		{
			ObjectTable.TryGetValue(objectID, out var value);
			return value;
		}
	}

	internal PdfObjectID[] AllObjectIDs
	{
		get
		{
			ICollection keys = ObjectTable.Keys;
			PdfObjectID[] array = new PdfObjectID[keys.Count];
			keys.CopyTo(array, 0);
			return array;
		}
	}

	internal PdfReference[] AllReferences
	{
		get
		{
			Dictionary<PdfObjectID, PdfReference>.ValueCollection values = ObjectTable.Values;
			List<PdfReference> list = new List<PdfReference>(values);
			list.Sort(PdfReference.Comparer);
			PdfReference[] array = new PdfReference[values.Count];
			list.CopyTo(array, 0);
			return array;
		}
	}

	public PdfReference DeadObject
	{
		get
		{
			if (_deadObject == null)
			{
				_deadObject = new PdfDictionary(_document);
				Add(_deadObject);
				_deadObject.Elements.Add("/DeadObjectCount", new PdfInteger());
			}
			return _deadObject.Reference;
		}
	}

	public PdfCrossReferenceTable(PdfDocument document)
	{
		_document = document;
	}

	public void Add(PdfReference iref)
	{
		if (iref.ObjectID.ObjectNumber == 948)
		{
			GetType();
		}
		if (iref.ObjectID.IsEmpty)
		{
			iref.ObjectID = new PdfObjectID(GetNewObjectNumber());
		}
		if (ObjectTable.ContainsKey(iref.ObjectID))
		{
			throw new InvalidOperationException("Object already in table.");
		}
		ObjectTable.Add(iref.ObjectID, iref);
	}

	public void Add(PdfObject value)
	{
		if (value.Owner == null)
		{
			value.Document = _document;
		}
		else
		{
			Debug.Assert(value.Owner == _document);
		}
		if (value.ObjectID.IsEmpty)
		{
			value.SetObjectID(GetNewObjectNumber(), 0);
		}
		if (ObjectTable.ContainsKey(value.ObjectID))
		{
			throw new InvalidOperationException("Object already in table.");
		}
		ObjectTable.Add(value.ObjectID, value.Reference);
	}

	public void Remove(PdfReference iref)
	{
		ObjectTable.Remove(iref.ObjectID);
	}

	public bool Contains(PdfObjectID objectID)
	{
		return ObjectTable.ContainsKey(objectID);
	}

	public int GetNewObjectNumber()
	{
		return ++_maxObjectNumber;
	}

	internal void WriteObject(PdfWriter writer)
	{
		writer.WriteRaw("xref\n");
		PdfReference[] allReferences = AllReferences;
		int num = allReferences.Length;
		writer.WriteRaw($"0 {num + 1}\n");
		writer.WriteRaw(string.Format("{0:0000000000} {1:00000} {2} \n", 0, 65535, "f"));
		for (int i = 0; i < num; i++)
		{
			PdfReference pdfReference = allReferences[i];
			writer.WriteRaw(string.Format("{0:0000000000} {1:00000} {2} \n", pdfReference.Position, pdfReference.GenerationNumber, "n"));
		}
	}

	internal void HandleOrphanedReferences()
	{
	}

	internal int Compact()
	{
		int count = ObjectTable.Count;
		PdfReference[] array = TransitiveClosure(_document._trailer);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (PdfObjectID key2 in ObjectTable.Keys)
		{
			dictionary.Add(key2.ObjectNumber, 0);
		}
		dictionary.Clear();
		foreach (PdfReference value in ObjectTable.Values)
		{
			dictionary.Add(value.ObjectNumber, 0);
		}
		Dictionary<PdfReference, int> dictionary2 = new Dictionary<PdfReference, int>();
		PdfReference[] array2 = array;
		foreach (PdfReference key in array2)
		{
			dictionary2.Add(key, 0);
		}
		foreach (PdfReference value2 in ObjectTable.Values)
		{
			if (!dictionary2.ContainsKey(value2))
			{
				value2.GetType();
			}
		}
		foreach (PdfReference value3 in ObjectTable.Values)
		{
			if (value3.Value == null)
			{
				GetType();
			}
			Debug.Assert(value3.Value != null);
		}
		PdfReference[] array3 = array;
		foreach (PdfReference pdfReference in array3)
		{
			if (!ObjectTable.ContainsKey(pdfReference.ObjectID))
			{
				GetType();
			}
			Debug.Assert(ObjectTable.ContainsKey(pdfReference.ObjectID));
			if (pdfReference.Value == null)
			{
				GetType();
			}
			Debug.Assert(pdfReference.Value != null);
		}
		_maxObjectNumber = 0;
		ObjectTable.Clear();
		PdfReference[] array4 = array;
		foreach (PdfReference pdfReference2 in array4)
		{
			if (!ObjectTable.ContainsKey(pdfReference2.ObjectID))
			{
				ObjectTable.Add(pdfReference2.ObjectID, pdfReference2);
				_maxObjectNumber = Math.Max(_maxObjectNumber, pdfReference2.ObjectNumber);
			}
		}
		return count - ObjectTable.Count;
	}

	internal void Renumber()
	{
		PdfReference[] allReferences = AllReferences;
		ObjectTable.Clear();
		int num = allReferences.Length;
		for (int i = 0; i < num; i++)
		{
			PdfReference pdfReference = allReferences[i];
			pdfReference.ObjectID = new PdfObjectID(i + 1);
			ObjectTable.Add(pdfReference.ObjectID, pdfReference);
		}
		_maxObjectNumber = num;
	}

	[Conditional("DEBUG_")]
	public void CheckConsistence()
	{
		Dictionary<PdfReference, object> dictionary = new Dictionary<PdfReference, object>();
		foreach (PdfReference value in ObjectTable.Values)
		{
			Debug.Assert(!dictionary.ContainsKey(value), "Duplicate iref.");
			Debug.Assert(value.Value != null);
			dictionary.Add(value, null);
		}
		Dictionary<PdfObjectID, object> dictionary2 = new Dictionary<PdfObjectID, object>();
		foreach (PdfReference value2 in ObjectTable.Values)
		{
			Debug.Assert(!dictionary2.ContainsKey(value2.ObjectID), "Duplicate iref.");
			dictionary2.Add(value2.ObjectID, null);
		}
		ICollection values = ObjectTable.Values;
		int count = values.Count;
		PdfReference[] array = new PdfReference[count];
		values.CopyTo(array, 0);
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < count; j++)
			{
				if (i != j)
				{
					Debug.Assert(array[i].Document == _document);
					Debug.Assert(array[i] != array[j]);
					Debug.Assert(array[i] != array[j]);
					Debug.Assert(array[i].Value != array[j].Value);
					Debug.Assert(!object.Equals(array[i].ObjectID, array[j].Value.ObjectID));
					Debug.Assert(array[i].ObjectNumber != array[j].Value.ObjectNumber);
					Debug.Assert(array[i].Document == array[j].Document);
					GetType();
				}
			}
		}
	}

	public PdfReference[] TransitiveClosure(PdfObject pdfObject)
	{
		return TransitiveClosure(pdfObject, 32767);
	}

	public PdfReference[] TransitiveClosure(PdfObject pdfObject, int depth)
	{
		Dictionary<PdfItem, object> dictionary = new Dictionary<PdfItem, object>();
		_overflow = new Dictionary<PdfItem, object>();
		TransitiveClosureImplementation(dictionary, pdfObject);
		while (_overflow.Count > 0)
		{
			PdfObject[] array = new PdfObject[_overflow.Count];
			Dictionary<PdfItem, object>.KeyCollection keys = _overflow.Keys;
			PdfItem[] array2 = array;
			keys.CopyTo(array2, 0);
			_overflow = new Dictionary<PdfItem, object>();
			foreach (PdfObject pdfObject2 in array)
			{
				TransitiveClosureImplementation(dictionary, pdfObject2);
			}
		}
		ICollection keys2 = dictionary.Keys;
		int count = keys2.Count;
		PdfReference[] array3 = new PdfReference[count];
		keys2.CopyTo(array3, 0);
		return array3;
	}

	private void TransitiveClosureImplementation(Dictionary<PdfItem, object> objects, PdfObject pdfObject)
	{
		try
		{
			_nestingLevel++;
			if (_nestingLevel >= 1000)
			{
				if (!_overflow.ContainsKey(pdfObject))
				{
					_overflow.Add(pdfObject, null);
				}
				return;
			}
			IEnumerable enumerable = null;
			if (pdfObject is PdfDictionary pdfDictionary)
			{
				enumerable = pdfDictionary.Elements.Values;
			}
			else if (pdfObject is PdfArray pdfArray)
			{
				enumerable = pdfArray.Elements;
			}
			else
			{
				Debug.Assert(condition: false, "Should not come here.");
			}
			if (enumerable == null)
			{
				return;
			}
			foreach (PdfItem item in enumerable)
			{
				PdfReference pdfReference = item as PdfReference;
				if (pdfReference != null)
				{
					if (pdfReference.Document != _document)
					{
						GetType();
						Debug.WriteLine($"Bad iref: {pdfReference.ObjectID.ToString()}");
					}
					Debug.Assert(pdfReference.Document == _document || pdfReference.Document == null, "External object detected!");
					if (objects.ContainsKey(pdfReference))
					{
						continue;
					}
					PdfObject value = pdfReference.Value;
					if (pdfReference.Document != null)
					{
						if (value == null)
						{
							pdfReference = ObjectTable[pdfReference.ObjectID];
							Debug.Assert(pdfReference.Value != null);
							value = pdfReference.Value;
						}
						Debug.Assert(pdfReference.Document == _document);
						objects.Add(pdfReference, null);
						if (value is PdfArray || value is PdfDictionary)
						{
							TransitiveClosureImplementation(objects, value);
						}
					}
				}
				else if (item is PdfObject pdfObject2 && (pdfObject2 is PdfDictionary || pdfObject2 is PdfArray))
				{
					TransitiveClosureImplementation(objects, pdfObject2);
				}
			}
		}
		finally
		{
			_nestingLevel--;
		}
	}
}
