#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Internal;

internal class ThreadLocalStorage
{
	private readonly Dictionary<string, PdfDocument.DocumentHandle> _importedDocuments;

	public PdfDocument[] Documents
	{
		get
		{
			List<PdfDocument> list = new List<PdfDocument>();
			foreach (PdfDocument.DocumentHandle value in _importedDocuments.Values)
			{
				if (value.IsAlive)
				{
					list.Add(value.Target);
				}
			}
			return list.ToArray();
		}
	}

	public ThreadLocalStorage()
	{
		_importedDocuments = new Dictionary<string, PdfDocument.DocumentHandle>(StringComparer.OrdinalIgnoreCase);
	}

	public void AddDocument(string path, PdfDocument document)
	{
		_importedDocuments.Add(path, document.Handle);
	}

	public void RemoveDocument(string path)
	{
		_importedDocuments.Remove(path);
	}

	public PdfDocument GetDocument(string path)
	{
		Debug.Assert(path.StartsWith("*") || Path.IsPathRooted(path), "Path must be full qualified.");
		PdfDocument pdfDocument = null;
		if (_importedDocuments.TryGetValue(path, out var value))
		{
			pdfDocument = value.Target;
			if (pdfDocument == null)
			{
				RemoveDocument(path);
			}
		}
		if (pdfDocument == null)
		{
			pdfDocument = PdfReader.Open(path, PdfDocumentOpenMode.Import);
			_importedDocuments.Add(path, pdfDocument.Handle);
		}
		return pdfDocument;
	}

	public void DetachDocument(PdfDocument.DocumentHandle handle)
	{
		if (handle.IsAlive)
		{
			foreach (string key in _importedDocuments.Keys)
			{
				if (_importedDocuments[key] == handle)
				{
					_importedDocuments.Remove(key);
					break;
				}
			}
		}
		bool flag = true;
		while (flag)
		{
			flag = false;
			foreach (string key2 in _importedDocuments.Keys)
			{
				if (!_importedDocuments[key2].IsAlive)
				{
					_importedDocuments.Remove(key2);
					flag = true;
					break;
				}
			}
		}
	}
}
