#define DEBUG
using System;
using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Pdf;

[DebuggerDisplay("{DebuggerDisplay}")]
public struct PdfObjectID : IComparable
{
	private readonly int _objectNumber;

	private readonly ushort _generationNumber;

	public int ObjectNumber => _objectNumber;

	public int GenerationNumber => _generationNumber;

	public bool IsEmpty => _objectNumber == 0;

	public static PdfObjectID Empty => default(PdfObjectID);

	internal string DebuggerDisplay => $"id=({ToString()})";

	public PdfObjectID(int objectNumber)
	{
		Debug.Assert(objectNumber >= 1, "Object number out of range.");
		_objectNumber = objectNumber;
		_generationNumber = 0;
	}

	public PdfObjectID(int objectNumber, int generationNumber)
	{
		Debug.Assert(objectNumber >= 1, "Object number out of range.");
		_objectNumber = objectNumber;
		_generationNumber = (ushort)generationNumber;
	}

	public override bool Equals(object obj)
	{
		if (obj is PdfObjectID pdfObjectID && _objectNumber == pdfObjectID._objectNumber)
		{
			return _generationNumber == pdfObjectID._generationNumber;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _objectNumber ^ _generationNumber;
	}

	public static bool operator ==(PdfObjectID left, PdfObjectID right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(PdfObjectID left, PdfObjectID right)
	{
		return !left.Equals(right);
	}

	public override string ToString()
	{
		return _objectNumber.ToString(CultureInfo.InvariantCulture) + " " + _generationNumber.ToString(CultureInfo.InvariantCulture);
	}

	public int CompareTo(object obj)
	{
		if (obj is PdfObjectID pdfObjectID)
		{
			if (_objectNumber == pdfObjectID._objectNumber)
			{
				return _generationNumber - pdfObjectID._generationNumber;
			}
			return _objectNumber - pdfObjectID._objectNumber;
		}
		return 1;
	}
}
