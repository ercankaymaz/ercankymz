#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced;

public sealed class PdfContents : PdfArray
{
	private class PdfPageContentEnumerator : IEnumerator<PdfContent>, IDisposable, IEnumerator
	{
		private PdfContent _currentElement;

		private int _index;

		private readonly PdfContents _contents;

		object IEnumerator.Current => Current;

		public PdfContent Current
		{
			get
			{
				if (_index == -1 || _index >= _contents.Elements.Count)
				{
					throw new InvalidOperationException(PSSR.ListEnumCurrentOutOfRange);
				}
				return _currentElement;
			}
		}

		internal PdfPageContentEnumerator(PdfContents list)
		{
			_contents = list;
			_index = -1;
		}

		public bool MoveNext()
		{
			if (_index < _contents.Elements.Count - 1)
			{
				_index++;
				_currentElement = (PdfContent)((PdfReference)_contents.Elements[_index]).Value;
				return true;
			}
			_index = _contents.Elements.Count;
			return false;
		}

		public void Reset()
		{
			_currentElement = null;
			_index = -1;
		}

		public void Dispose()
		{
		}
	}

	private bool _modified;

	public PdfContents(PdfDocument document)
		: base(document)
	{
	}

	internal PdfContents(PdfArray array)
		: base(array)
	{
		int count = base.Elements.Count;
		for (int i = 0; i < count; i++)
		{
			PdfItem pdfItem = base.Elements[i];
			if (pdfItem is PdfReference pdfReference && pdfReference.Value is PdfDictionary)
			{
				new PdfContent((PdfDictionary)pdfReference.Value);
				continue;
			}
			throw new InvalidOperationException("Unexpected item in a content stream array.");
		}
	}

	public PdfContent AppendContent()
	{
		Debug.Assert(Owner != null);
		SetModified();
		PdfContent pdfContent = new PdfContent(Owner);
		Owner._irefTable.Add(pdfContent);
		Debug.Assert(pdfContent.Reference != null);
		base.Elements.Add(pdfContent.Reference);
		return pdfContent;
	}

	public PdfContent PrependContent()
	{
		Debug.Assert(Owner != null);
		SetModified();
		PdfContent pdfContent = new PdfContent(Owner);
		Owner._irefTable.Add(pdfContent);
		Debug.Assert(pdfContent.Reference != null);
		base.Elements.Insert(0, pdfContent.Reference);
		return pdfContent;
	}

	public PdfContent CreateSingleContent()
	{
		byte[] array = new byte[0];
		foreach (PdfItem element in base.Elements)
		{
			PdfDictionary pdfDictionary = (PdfDictionary)((PdfReference)element).Value;
			byte[] array2 = array;
			byte[] unfilteredValue = pdfDictionary.Stream.UnfilteredValue;
			array = new byte[array2.Length + unfilteredValue.Length + 1];
			array2.CopyTo(array, 0);
			array[array2.Length] = 10;
			unfilteredValue.CopyTo(array, array2.Length + 1);
		}
		PdfContent pdfContent = new PdfContent(Owner);
		pdfContent.Stream = new PdfDictionary.PdfStream(array, pdfContent);
		return pdfContent;
	}

	public PdfContent ReplaceContent(CSequence cseq)
	{
		if (cseq == null)
		{
			throw new ArgumentNullException("cseq");
		}
		return ReplaceContent(cseq.ToContent());
	}

	private PdfContent ReplaceContent(byte[] contentBytes)
	{
		Debug.Assert(Owner != null);
		PdfContent pdfContent = new PdfContent(Owner);
		pdfContent.CreateStream(contentBytes);
		Owner._irefTable.Add(pdfContent);
		base.Elements.Clear();
		base.Elements.Add(pdfContent.Reference);
		return pdfContent;
	}

	private void SetModified()
	{
		if (_modified)
		{
			return;
		}
		_modified = true;
		int count = base.Elements.Count;
		if (count == 1)
		{
			PdfContent pdfContent = (PdfContent)((PdfReference)base.Elements[0]).Value;
			pdfContent.PreserveGraphicsState();
		}
		else if (count > 1)
		{
			PdfContent pdfContent2 = (PdfContent)((PdfReference)base.Elements[0]).Value;
			if (pdfContent2 != null && pdfContent2.Stream != null)
			{
				int length = pdfContent2.Stream.Length;
				byte[] array = new byte[length + 2];
				array[0] = 113;
				array[1] = 10;
				Array.Copy(pdfContent2.Stream.Value, 0, array, 2, length);
				pdfContent2.Stream.Value = array;
				pdfContent2.Elements.SetInteger("/Length", length + 2);
			}
			pdfContent2 = (PdfContent)((PdfReference)base.Elements[count - 1]).Value;
			if (pdfContent2 != null && pdfContent2.Stream != null)
			{
				int length = pdfContent2.Stream.Length;
				byte[] array = new byte[length + 3];
				Array.Copy(pdfContent2.Stream.Value, 0, array, 0, length);
				array[length] = 32;
				array[length + 1] = 81;
				array[length + 2] = 10;
				pdfContent2.Stream.Value = array;
				pdfContent2.Elements.SetInteger("/Length", length + 3);
			}
		}
	}

	internal override void WriteObject(PdfWriter writer)
	{
		if (base.Elements.Count == 1)
		{
			base.Elements[0].WriteObject(writer);
		}
		else
		{
			base.WriteObject(writer);
		}
	}

	public new IEnumerator<PdfContent> GetEnumerator()
	{
		return new PdfPageContentEnumerator(this);
	}
}
