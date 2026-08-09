using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfImportedObjectTable
{
	private readonly PdfFormXObject[] _xObjects;

	private readonly PdfDocument _owner;

	private readonly PdfDocument.DocumentHandle _externalDocumentHandle;

	private readonly Dictionary<string, PdfReference> _externalIDs = new Dictionary<string, PdfReference>();

	public PdfDocument Owner => _owner;

	public PdfDocument ExternalDocument => _externalDocumentHandle.IsAlive ? _externalDocumentHandle.Target : null;

	public PdfReference this[PdfObjectID externalID] => _externalIDs[externalID.ToString()];

	public PdfImportedObjectTable(PdfDocument owner, PdfDocument externalDocument)
	{
		if (owner == null)
		{
			throw new ArgumentNullException("owner");
		}
		if (externalDocument == null)
		{
			throw new ArgumentNullException("externalDocument");
		}
		_owner = owner;
		_externalDocumentHandle = externalDocument.Handle;
		_xObjects = new PdfFormXObject[externalDocument.PageCount];
	}

	public PdfFormXObject GetXObject(int pageNumber)
	{
		return _xObjects[pageNumber - 1];
	}

	public void SetXObject(int pageNumber, PdfFormXObject xObject)
	{
		_xObjects[pageNumber - 1] = xObject;
	}

	public bool Contains(PdfObjectID externalID)
	{
		return _externalIDs.ContainsKey(externalID.ToString());
	}

	public void Add(PdfObjectID externalID, PdfReference iref)
	{
		_externalIDs[externalID.ToString()] = iref;
	}
}
