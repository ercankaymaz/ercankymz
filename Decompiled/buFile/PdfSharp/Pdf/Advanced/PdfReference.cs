#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced;

[DebuggerDisplay("iref({ObjectNumber}, {GenerationNumber})")]
public sealed class PdfReference : PdfItem
{
	internal class PdfReferenceComparer : IComparer<PdfReference>
	{
		public int Compare(PdfReference x, PdfReference y)
		{
			if (x != null)
			{
				if (y != null)
				{
					return x._objectID.CompareTo(y._objectID);
				}
				return -1;
			}
			if (y != null)
			{
				return 1;
			}
			return 0;
		}
	}

	private PdfObjectID _objectID;

	private int _position;

	private PdfObject _value;

	private PdfDocument _document;

	public PdfObjectID ObjectID
	{
		get
		{
			return _objectID;
		}
		set
		{
			if (!(_objectID == value))
			{
				_objectID = value;
				if (Document == null)
				{
				}
			}
		}
	}

	public int ObjectNumber => _objectID.ObjectNumber;

	public int GenerationNumber => _objectID.GenerationNumber;

	public int Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public PdfObject Value
	{
		get
		{
			return _value;
		}
		set
		{
			Debug.Assert(value != null, "The value of a PdfReference must never be null.");
			Debug.Assert(value.Reference == null || value.Reference == this, "The reference of the value must be null or this.");
			_value = value;
			value.Reference = this;
		}
	}

	public PdfDocument Document
	{
		get
		{
			return _document;
		}
		set
		{
			_document = value;
		}
	}

	internal static PdfReferenceComparer Comparer => new PdfReferenceComparer();

	public PdfReference(PdfObject pdfObject)
	{
		if (pdfObject.Reference != null)
		{
			throw new InvalidOperationException("Must not create iref for an object that already has one.");
		}
		_value = pdfObject;
		pdfObject.Reference = this;
	}

	public PdfReference(PdfObjectID objectID, int position)
	{
		_objectID = objectID;
		_position = position;
	}

	internal void WriteXRefEnty(PdfWriter writer)
	{
		string rawString = $"{_position:0000000000} {_objectID.GenerationNumber:00000} n\n";
		writer.WriteRaw(rawString);
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.Write(this);
	}

	internal void SetObject(PdfObject value)
	{
		_value = value;
	}

	public override string ToString()
	{
		PdfObjectID objectID = _objectID;
		return objectID.ToString() + " R";
	}
}
