#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfFormXObjectTable(PdfDocument document) : PdfResourceTable(document)
{
	public class Selector
	{
		private string _path;

		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
			}
		}

		public Selector(XForm form)
		{
			_path = form._path.ToLowerInvariant();
		}

		public Selector(PdfPage page)
		{
			PdfDocument owner = page.Owner;
			_path = "*" + owner.Guid.ToString("B");
			_path = _path.ToLowerInvariant();
		}

		public Selector(PdfDocument document)
		{
			_path = "*" + document.Guid.ToString("B");
			_path = _path.ToLowerInvariant();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Selector selector))
			{
				return false;
			}
			return _path == selector._path;
		}

		public override int GetHashCode()
		{
			return _path.GetHashCode();
		}
	}

	private readonly Dictionary<Selector, PdfImportedObjectTable> _forms = new Dictionary<Selector, PdfImportedObjectTable>();

	public PdfFormXObject GetForm(XForm form)
	{
		if (form._pdfForm != null)
		{
			Debug.Assert(form.IsTemplate, "An XPdfForm must not have a PdfFormXObject.");
			if (form._pdfForm.Owner == base.Owner)
			{
				return form._pdfForm;
			}
			form._pdfForm = null;
		}
		if (form is XPdfForm xPdfForm)
		{
			Selector key = new Selector(form);
			if (!_forms.TryGetValue(key, out var value))
			{
				PdfDocument externalDocument = xPdfForm.ExternalDocument;
				value = new PdfImportedObjectTable(base.Owner, externalDocument);
				_forms[key] = value;
			}
			PdfFormXObject pdfFormXObject = value.GetXObject(xPdfForm.PageNumber);
			if (pdfFormXObject == null)
			{
				pdfFormXObject = new PdfFormXObject(base.Owner, value, xPdfForm);
				value.SetXObject(xPdfForm.PageNumber, pdfFormXObject);
			}
			return pdfFormXObject;
		}
		Debug.Assert(form.GetType() == typeof(XForm));
		form._pdfForm = new PdfFormXObject(base.Owner, form);
		return form._pdfForm;
	}

	public PdfImportedObjectTable GetImportedObjectTable(PdfPage page)
	{
		Selector key = new Selector(page);
		if (!_forms.TryGetValue(key, out var value))
		{
			value = new PdfImportedObjectTable(base.Owner, page.Owner);
			_forms[key] = value;
		}
		return value;
	}

	public PdfImportedObjectTable GetImportedObjectTable(PdfDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		Selector key = new Selector(document);
		if (!_forms.TryGetValue(key, out var value))
		{
			value = new PdfImportedObjectTable(base.Owner, document);
			_forms[key] = value;
		}
		return value;
	}

	public void DetachDocument(PdfDocument.DocumentHandle handle)
	{
		if (handle.IsAlive)
		{
			foreach (Selector key in _forms.Keys)
			{
				PdfImportedObjectTable pdfImportedObjectTable = _forms[key];
				if (pdfImportedObjectTable.ExternalDocument != null && pdfImportedObjectTable.ExternalDocument.Handle == handle)
				{
					_forms.Remove(key);
					break;
				}
			}
		}
		bool flag = true;
		while (flag)
		{
			flag = false;
			foreach (Selector key2 in _forms.Keys)
			{
				PdfImportedObjectTable pdfImportedObjectTable2 = _forms[key2];
				if (pdfImportedObjectTable2.ExternalDocument == null)
				{
					_forms.Remove(key2);
					flag = true;
					break;
				}
			}
		}
	}
}
