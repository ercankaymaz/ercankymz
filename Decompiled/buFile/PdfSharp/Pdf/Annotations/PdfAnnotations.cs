#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.Advanced;

namespace PdfSharp.Pdf.Annotations;

public sealed class PdfAnnotations : PdfArray
{
	private class AnnotationsIterator : IEnumerator<PdfItem>, IDisposable, IEnumerator
	{
		private readonly PdfAnnotations _annotations;

		private int _index;

		public PdfItem Current => _annotations[_index];

		object IEnumerator.Current => Current;

		public AnnotationsIterator(PdfAnnotations annotations)
		{
			_annotations = annotations;
			_index = -1;
		}

		public bool MoveNext()
		{
			return ++_index < _annotations.Count;
		}

		public void Reset()
		{
			_index = -1;
		}

		public void Dispose()
		{
		}
	}

	private PdfPage _page;

	public int Count => base.Elements.Count;

	public PdfAnnotation this[int index]
	{
		get
		{
			PdfItem pdfItem = base.Elements[index];
			PdfReference pdfReference;
			PdfDictionary pdfDictionary;
			if ((pdfReference = pdfItem as PdfReference) != null)
			{
				Debug.Assert(pdfReference.Value is PdfDictionary, "Reference to dictionary expected.");
				pdfDictionary = (PdfDictionary)pdfReference.Value;
			}
			else
			{
				Debug.Assert(pdfItem is PdfDictionary, "Dictionary expected.");
				pdfDictionary = (PdfDictionary)pdfItem;
			}
			PdfAnnotation pdfAnnotation = pdfDictionary as PdfAnnotation;
			if (pdfAnnotation == null)
			{
				pdfAnnotation = new PdfGenericAnnotation(pdfDictionary);
				if (pdfReference == null)
				{
					base.Elements[index] = pdfAnnotation;
				}
			}
			return pdfAnnotation;
		}
	}

	internal PdfPage Page
	{
		get
		{
			return _page;
		}
		set
		{
			_page = value;
		}
	}

	internal PdfAnnotations(PdfDocument document)
		: base(document)
	{
	}

	internal PdfAnnotations(PdfArray array)
		: base(array)
	{
	}

	public void Add(PdfAnnotation annotation)
	{
		annotation.Document = Owner;
		Owner._irefTable.Add(annotation);
		base.Elements.Add(annotation.Reference);
	}

	public void Remove(PdfAnnotation annotation)
	{
		if (annotation.Owner != Owner)
		{
			throw new InvalidOperationException("The annotation does not belong to this document.");
		}
		Owner.Internals.RemoveObject(annotation);
		base.Elements.Remove(annotation.Reference);
	}

	public void Clear()
	{
		for (int num = Count - 1; num >= 0; num--)
		{
			Page.Annotations.Remove(_page.Annotations[num]);
		}
	}

	internal static void FixImportedAnnotation(PdfPage page)
	{
		PdfArray array = page.Elements.GetArray("/Annots");
		if (array == null)
		{
			return;
		}
		int count = array.Elements.Count;
		for (int i = 0; i < count; i++)
		{
			PdfDictionary dictionary = array.Elements.GetDictionary(i);
			if (dictionary != null && dictionary.Elements.ContainsKey("/P"))
			{
				dictionary.Elements["/P"] = page.Reference;
			}
		}
	}

	public override IEnumerator<PdfItem> GetEnumerator()
	{
		return new AnnotationsIterator(this);
	}
}
