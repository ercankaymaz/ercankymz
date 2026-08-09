#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

[DebuggerDisplay("(PageCount={Count})")]
public sealed class PdfPages : PdfDictionary, IEnumerable<PdfPage>, IEnumerable
{
	private class PdfPagesEnumerator : IEnumerator<PdfPage>, IDisposable, IEnumerator
	{
		private PdfPage _currentElement;

		private int _index;

		private readonly PdfPages _list;

		object IEnumerator.Current => Current;

		public PdfPage Current
		{
			get
			{
				if (_index == -1 || _index >= _list.Count)
				{
					throw new InvalidOperationException(PSSR.ListEnumCurrentOutOfRange);
				}
				return _currentElement;
			}
		}

		internal PdfPagesEnumerator(PdfPages list)
		{
			_list = list;
			_index = -1;
		}

		public bool MoveNext()
		{
			if (_index < _list.Count - 1)
			{
				_index++;
				_currentElement = _list[_index];
				return true;
			}
			_index = _list.Count;
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

	internal sealed class Keys : PdfPage.InheritablePageKeys
	{
		[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "Pages")]
		public const string Type = "/Type";

		[KeyInfo(KeyType.Dictionary | KeyType.Required)]
		public const string Parent = "/Parent";

		[KeyInfo(KeyType.Array | KeyType.Required)]
		public const string Kids = "/Kids";

		[KeyInfo(KeyType.Integer | KeyType.Required)]
		public const string Count = "/Count";

		private static DictionaryMeta _meta;

		public static DictionaryMeta Meta => _meta ?? (_meta = KeysBase.CreateMeta(typeof(Keys)));
	}

	private PdfArray _pagesArray;

	public int Count => PagesArray.Elements.Count;

	public PdfPage this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.PageIndexOutOfRange);
			}
			PdfDictionary pdfDictionary = (PdfDictionary)((PdfReference)PagesArray.Elements[index]).Value;
			if (!(pdfDictionary is PdfPage))
			{
				pdfDictionary = new PdfPage(pdfDictionary);
			}
			return (PdfPage)pdfDictionary;
		}
	}

	public PdfArray PagesArray
	{
		get
		{
			if (_pagesArray == null)
			{
				_pagesArray = (PdfArray)base.Elements.GetValue("/Kids", VCF.Create);
			}
			return _pagesArray;
		}
	}

	internal override DictionaryMeta Meta => Keys.Meta;

	internal PdfPages(PdfDocument document)
		: base(document)
	{
		base.Elements.SetName("/Type", "/Pages");
		base.Elements["/Count"] = new PdfInteger(0);
	}

	internal PdfPages(PdfDictionary dictionary)
		: base(dictionary)
	{
	}

	internal PdfPage FindPage(PdfObjectID id)
	{
		PdfPage result = null;
		foreach (PdfItem item in PagesArray)
		{
			if (item is PdfReference { Value: PdfDictionary value } && value.ObjectID == id)
			{
				result = (value as PdfPage) ?? new PdfPage(value);
				break;
			}
		}
		return result;
	}

	public PdfPage Add()
	{
		PdfPage pdfPage = new PdfPage();
		Insert(Count, pdfPage);
		return pdfPage;
	}

	public PdfPage Add(PdfPage page)
	{
		return Insert(Count, page);
	}

	public PdfPage Insert(int index)
	{
		PdfPage pdfPage = new PdfPage();
		Insert(index, pdfPage);
		return pdfPage;
	}

	public PdfPage Insert(int index, PdfPage page)
	{
		if (page == null)
		{
			throw new ArgumentNullException("page");
		}
		if (page.Owner == Owner)
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				if (this[i] == page)
				{
					throw new InvalidOperationException(PSSR.MultiplePageInsert);
				}
			}
			Owner._irefTable.Add(page);
			Debug.Assert(page.Owner == Owner);
			PagesArray.Elements.Insert(index, page.Reference);
			base.Elements.SetInteger("/Count", PagesArray.Elements.Count);
			return page;
		}
		if (page.Owner == null)
		{
			page.Document = Owner;
			Owner._irefTable.Add(page);
			Debug.Assert(page.Owner == Owner);
			PagesArray.Elements.Insert(index, page.Reference);
			base.Elements.SetInteger("/Count", PagesArray.Elements.Count);
		}
		else
		{
			PdfPage pdfPage = page;
			page = ImportExternalPage(pdfPage);
			Owner._irefTable.Add(page);
			PdfImportedObjectTable importedObjectTable = Owner.FormTable.GetImportedObjectTable(pdfPage);
			importedObjectTable.Add(pdfPage.ObjectID, page.Reference);
			PagesArray.Elements.Insert(index, page.Reference);
			base.Elements.SetInteger("/Count", PagesArray.Elements.Count);
			PdfAnnotations.FixImportedAnnotation(page);
		}
		if (Owner.Settings.TrimMargins.AreSet)
		{
			page.TrimMargins = Owner.Settings.TrimMargins;
		}
		return page;
	}

	public void InsertRange(int index, PdfDocument document, int startIndex, int pageCount)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		if (index < 0 || index > Count)
		{
			throw new ArgumentOutOfRangeException("index", "Argument 'index' out of range.");
		}
		int pageCount2 = document.PageCount;
		if (startIndex < 0 || startIndex + pageCount > pageCount2)
		{
			throw new ArgumentOutOfRangeException("startIndex", "Argument 'startIndex' out of range.");
		}
		if (pageCount > pageCount2)
		{
			throw new ArgumentOutOfRangeException("pageCount", "Argument 'pageCount' out of range.");
		}
		PdfPage[] array = new PdfPage[pageCount];
		PdfPage[] array2 = new PdfPage[pageCount];
		int num = 0;
		int num2 = index;
		for (int i = startIndex; i < startIndex + pageCount; i++)
		{
			PdfPage pdfPage = document.Pages[i];
			PdfPage pdfPage2 = (array[num] = ImportExternalPage(pdfPage));
			array2[num] = pdfPage;
			Owner._irefTable.Add(pdfPage2);
			PdfImportedObjectTable importedObjectTable = Owner.FormTable.GetImportedObjectTable(pdfPage);
			importedObjectTable.Add(pdfPage.ObjectID, pdfPage2.Reference);
			PagesArray.Elements.Insert(num2, pdfPage2.Reference);
			if (Owner.Settings.TrimMargins.AreSet)
			{
				pdfPage2.TrimMargins = Owner.Settings.TrimMargins;
			}
			num++;
			num2++;
		}
		base.Elements.SetInteger("/Count", PagesArray.Elements.Count);
		int num3 = 0;
		for (int j = startIndex; j < startIndex + pageCount; j++)
		{
			PdfPage pdfPage3 = document.Pages[j];
			PdfPage pdfPage4 = array[num3];
			PdfArray array3 = pdfPage3.Elements.GetArray("/Annots");
			if (array3 != null)
			{
				PdfAnnotations pdfAnnotations = new PdfAnnotations(Owner);
				int count = array3.Elements.Count;
				for (int k = 0; k < count; k++)
				{
					PdfDictionary dictionary = array3.Elements.GetDictionary(k);
					if (dictionary == null)
					{
						continue;
					}
					string text = dictionary.Elements.GetString("/Subtype");
					if (!(text == "/Link"))
					{
						continue;
					}
					bool flag = false;
					PdfLinkAnnotation pdfLinkAnnotation = new PdfLinkAnnotation(Owner);
					PdfName[] keyNames = dictionary.Elements.KeyNames;
					PdfName[] array4 = keyNames;
					foreach (PdfName pdfName in array4)
					{
						switch (pdfName.Value)
						{
						case "/BS":
							pdfLinkAnnotation.Elements.Add("/BS", new PdfLiteral("<</W 0>>"));
							break;
						case "/F":
						{
							PdfItem value = dictionary.Elements.GetValue("/F");
							Debug.Assert(value is PdfInteger);
							pdfLinkAnnotation.Elements.Add("/F", value.Clone());
							break;
						}
						case "/Rect":
						{
							PdfItem value = dictionary.Elements.GetValue("/Rect");
							Debug.Assert(value is PdfArray);
							pdfLinkAnnotation.Elements.Add("/Rect", value.Clone());
							break;
						}
						case "/StructParent":
						{
							PdfItem value = dictionary.Elements.GetValue("/StructParent");
							Debug.Assert(value is PdfInteger);
							pdfLinkAnnotation.Elements.Add("/StructParent", value.Clone());
							break;
						}
						case "/Dest":
						{
							PdfItem value = dictionary.Elements.GetValue("/Dest");
							value = value.Clone();
							if (value is PdfArray pdfArray && pdfArray.Elements.Count == 5 && pdfArray.Elements[0] is PdfReference iref)
							{
								PdfReference pdfReference = RemapReference(array, array2, iref);
								if (pdfReference != null)
								{
									pdfArray.Elements[0] = pdfReference;
									pdfLinkAnnotation.Elements.Add("/Dest", pdfArray);
									flag = true;
								}
							}
							break;
						}
						}
					}
					if (flag)
					{
						pdfAnnotations.Add(pdfLinkAnnotation);
					}
				}
				if (pdfAnnotations.Count > 0)
				{
					pdfPage4.Elements.Add("/Annots", pdfAnnotations);
				}
			}
			num3++;
		}
	}

	public void InsertRange(int index, PdfDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		InsertRange(index, document, 0, document.PageCount);
	}

	public void InsertRange(int index, PdfDocument document, int startIndex)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		InsertRange(index, document, startIndex, document.PageCount - startIndex);
	}

	public void Remove(PdfPage page)
	{
		PagesArray.Elements.Remove(page.Reference);
		base.Elements.SetInteger("/Count", PagesArray.Elements.Count);
	}

	public void RemoveAt(int index)
	{
		PagesArray.Elements.RemoveAt(index);
		base.Elements.SetInteger("/Count", PagesArray.Elements.Count);
	}

	public void MovePage(int oldIndex, int newIndex)
	{
		if (oldIndex < 0 || oldIndex >= Count)
		{
			throw new ArgumentOutOfRangeException("oldIndex");
		}
		if (newIndex < 0 || newIndex >= Count)
		{
			throw new ArgumentOutOfRangeException("newIndex");
		}
		if (oldIndex != newIndex)
		{
			PdfReference value = (PdfReference)_pagesArray.Elements[oldIndex];
			_pagesArray.Elements.RemoveAt(oldIndex);
			_pagesArray.Elements.Insert(newIndex, value);
		}
	}

	private PdfPage ImportExternalPage(PdfPage importPage)
	{
		if (importPage.Owner._openMode != PdfDocumentOpenMode.Import)
		{
			throw new InvalidOperationException("A PDF document must be opened with PdfDocumentOpenMode.Import to import pages from it.");
		}
		PdfPage pdfPage = new PdfPage(_document);
		CloneElement(pdfPage, importPage, "/Resources", deepcopy: false);
		CloneElement(pdfPage, importPage, "/Contents", deepcopy: false);
		CloneElement(pdfPage, importPage, "/MediaBox", deepcopy: true);
		CloneElement(pdfPage, importPage, "/CropBox", deepcopy: true);
		CloneElement(pdfPage, importPage, "/Rotate", deepcopy: true);
		CloneElement(pdfPage, importPage, "/BleedBox", deepcopy: true);
		CloneElement(pdfPage, importPage, "/TrimBox", deepcopy: true);
		CloneElement(pdfPage, importPage, "/ArtBox", deepcopy: true);
		CloneElement(pdfPage, importPage, "/Annots", deepcopy: false);
		return pdfPage;
	}

	private void CloneElement(PdfPage page, PdfPage importPage, string key, bool deepcopy)
	{
		Debug.Assert(page != null);
		Debug.Assert(page.Owner == _document);
		Debug.Assert(importPage.Owner != null);
		Debug.Assert(importPage.Owner != _document);
		PdfItem pdfItem = importPage.Elements[key];
		if (pdfItem == null)
		{
			return;
		}
		PdfImportedObjectTable importedObjectTable = null;
		if (!deepcopy)
		{
			importedObjectTable = Owner.FormTable.GetImportedObjectTable(importPage);
		}
		if (pdfItem is PdfReference)
		{
			pdfItem = ((PdfReference)pdfItem).Value;
		}
		if (pdfItem is PdfObject)
		{
			PdfObject pdfObject = (PdfObject)pdfItem;
			if (deepcopy)
			{
				Debug.Assert(pdfObject.Owner != null, "See 'else' case for details");
				pdfObject = PdfObject.DeepCopyClosure(_document, pdfObject);
			}
			else
			{
				if (pdfObject.Owner == null)
				{
					pdfObject.Document = importPage.Owner;
				}
				pdfObject = PdfObject.ImportClosure(importedObjectTable, page.Owner, pdfObject);
			}
			if (pdfObject.Reference == null)
			{
				page.Elements[key] = pdfObject;
			}
			else
			{
				page.Elements[key] = pdfObject.Reference;
			}
		}
		else
		{
			page.Elements[key] = pdfItem.Clone();
		}
	}

	private static PdfReference RemapReference(PdfPage[] newPages, PdfPage[] impPages, PdfReference iref)
	{
		for (int i = 0; i < newPages.Length; i++)
		{
			if (impPages[i].Reference == iref)
			{
				return newPages[i].Reference;
			}
		}
		return null;
	}

	internal void FlattenPageTree()
	{
		PdfPage.InheritedValues values = default(PdfPage.InheritedValues);
		PdfPage.InheritValues(this, ref values);
		PdfDictionary[] kids = GetKids(base.Reference, values, null);
		PdfArray pdfArray = new PdfArray(Owner);
		PdfDictionary[] array = kids;
		foreach (PdfDictionary pdfDictionary in array)
		{
			pdfDictionary.Elements["/Parent"] = base.Reference;
			pdfArray.Elements.Add(pdfDictionary.Reference);
		}
		base.Elements.SetName("/Type", "/Pages");
		base.Elements.SetValue("/Kids", pdfArray);
		base.Elements.SetInteger("/Count", pdfArray.Elements.Count);
	}

	private PdfDictionary[] GetKids(PdfReference iref, PdfPage.InheritedValues values, PdfDictionary parent)
	{
		PdfDictionary pdfDictionary = (PdfDictionary)iref.Value;
		string name = pdfDictionary.Elements.GetName("/Type");
		if (name == "/Page")
		{
			PdfPage.InheritValues(pdfDictionary, values);
			return new PdfDictionary[1] { pdfDictionary };
		}
		if (string.IsNullOrEmpty(name))
		{
			PdfPage.InheritValues(pdfDictionary, values);
			return new PdfDictionary[1] { pdfDictionary };
		}
		Debug.Assert(pdfDictionary.Elements.GetName("/Type") == "/Pages");
		PdfPage.InheritValues(pdfDictionary, ref values);
		List<PdfDictionary> list = new List<PdfDictionary>();
		PdfArray pdfArray = pdfDictionary.Elements["/Kids"] as PdfArray;
		if (pdfArray == null && pdfDictionary.Elements["/Kids"] is PdfReference pdfReference)
		{
			pdfArray = pdfReference.Value as PdfArray;
		}
		foreach (PdfReference item in pdfArray)
		{
			list.AddRange(GetKids(item, values, pdfDictionary));
		}
		int count = list.Count;
		Debug.Assert(count == pdfDictionary.Elements.GetInteger("/Count"));
		return list.ToArray();
	}

	internal override void PrepareForSave()
	{
		int count = _pagesArray.Elements.Count;
		for (int i = 0; i < count; i++)
		{
			PdfPage pdfPage = this[i];
			pdfPage.PrepareForSave();
		}
	}

	public new IEnumerator<PdfPage> GetEnumerator()
	{
		return new PdfPagesEnumerator(this);
	}
}
