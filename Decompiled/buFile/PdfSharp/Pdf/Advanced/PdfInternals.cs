using System;
using System.IO;
using System.Text;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced;

public class PdfInternals
{
	private readonly PdfDocument _document;

	public string CustomValueKey = "/PdfSharp.CustomValue";

	public string FirstDocumentID
	{
		get
		{
			return _document._trailer.GetDocumentID(0);
		}
		set
		{
			_document._trailer.SetDocumentID(0, value);
		}
	}

	public Guid FirstDocumentGuid => GuidFromString(_document._trailer.GetDocumentID(0));

	public string SecondDocumentID
	{
		get
		{
			return _document._trailer.GetDocumentID(1);
		}
		set
		{
			_document._trailer.SetDocumentID(1, value);
		}
	}

	public Guid SecondDocumentGuid => GuidFromString(_document._trailer.GetDocumentID(0));

	public PdfCatalog Catalog => _document.Catalog;

	public PdfExtGStateTable ExtGStateTable => _document.ExtGStateTable;

	[Obsolete("Use GetAllObjects.")]
	public PdfObject[] AllObjects => GetAllObjects();

	internal PdfInternals(PdfDocument document)
	{
		_document = document;
	}

	private Guid GuidFromString(string id)
	{
		if (id == null || id.Length != 16)
		{
			return Guid.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 16; i++)
		{
			stringBuilder.AppendFormat("{0:X2}", (byte)id[i]);
		}
		return new Guid(stringBuilder.ToString());
	}

	public PdfObject GetObject(PdfObjectID objectID)
	{
		return _document._irefTable[objectID].Value;
	}

	public PdfObject MapExternalObject(PdfObject externalObject)
	{
		PdfFormXObjectTable formTable = _document.FormTable;
		PdfImportedObjectTable importedObjectTable = formTable.GetImportedObjectTable(externalObject.Owner);
		return importedObjectTable[externalObject.ObjectID]?.Value;
	}

	public static PdfReference GetReference(PdfObject obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		return obj.Reference;
	}

	public static PdfObjectID GetObjectID(PdfObject obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		return obj.ObjectID;
	}

	public static int GetObjectNumber(PdfObject obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		return obj.ObjectNumber;
	}

	public static int GenerationNumber(PdfObject obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		return obj.GenerationNumber;
	}

	public PdfObject[] GetAllObjects()
	{
		PdfReference[] allReferences = _document._irefTable.AllReferences;
		int num = allReferences.Length;
		PdfObject[] array = new PdfObject[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = allReferences[i].Value;
		}
		return array;
	}

	public T CreateIndirectObject<T>() where T : PdfObject
	{
		T val = Activator.CreateInstance<T>();
		_document._irefTable.Add(val);
		return val;
	}

	public void AddObject(PdfObject obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		if (obj.Owner == null)
		{
			obj.Document = _document;
		}
		else if (obj.Owner != _document)
		{
			throw new InvalidOperationException("Object does not belong to this document.");
		}
		_document._irefTable.Add(obj);
	}

	public void RemoveObject(PdfObject obj)
	{
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		if (obj.Reference == null)
		{
			throw new InvalidOperationException("Only indirect objects can be removed.");
		}
		if (obj.Owner != _document)
		{
			throw new InvalidOperationException("Object does not belong to this document.");
		}
		_document._irefTable.Remove(obj.Reference);
	}

	public PdfObject[] GetClosure(PdfObject obj)
	{
		return GetClosure(obj, int.MaxValue);
	}

	public PdfObject[] GetClosure(PdfObject obj, int depth)
	{
		PdfReference[] array = _document._irefTable.TransitiveClosure(obj, depth);
		int num = array.Length + 1;
		PdfObject[] array2 = new PdfObject[num];
		array2[0] = obj;
		for (int i = 1; i < num; i++)
		{
			array2[i] = array[i - 1].Value;
		}
		return array2;
	}

	public void WriteObject(Stream stream, PdfItem item)
	{
		PdfWriter pdfWriter = new PdfWriter(stream, null);
		pdfWriter.Options = PdfWriterOptions.OmitStream;
		item.WriteObject(pdfWriter);
	}
}
