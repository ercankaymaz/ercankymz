// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfPages
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Annotations;
using PdfSharp.Pdf.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("(PageCount={Count})")]
public sealed class PdfPages : PdfDictionary, IEnumerable<PdfPage>, IEnumerable
{
  private PdfArray _pagesArray;

  internal PdfPages(PdfDocument document)
    : base(document)
  {
    this.Elements.SetName("/Type", "/Pages");
    this.Elements["/Count"] = (PdfItem) new PdfInteger(0);
  }

  internal PdfPages(PdfDictionary dictionary)
    : base(dictionary)
  {
  }

  public int Count => this.PagesArray.Elements.Count;

  public PdfPage this[int index]
  {
    get
    {
      if ((index < 0 ? 1 : (index >= this.Count ? 1 : 0)) != 0)
        throw new ArgumentOutOfRangeException(nameof (index), (object) index, PSSR.PageIndexOutOfRange);
      PdfDictionary dict = (PdfDictionary) ((PdfReference) this.PagesArray.Elements[index]).Value;
      if (!(dict is PdfPage))
        dict = (PdfDictionary) new PdfPage(dict);
      return (PdfPage) dict;
    }
  }

  internal PdfPage FindPage(PdfObjectID id)
  {
    PdfPage page = (PdfPage) null;
    foreach (PdfItem pages in this.PagesArray)
    {
      if (pages is PdfReference pdfReference && (!(pdfReference.Value is PdfDictionary dict) ? 0 : (dict.ObjectID == id ? 1 : 0)) != 0)
      {
        if (!(dict is PdfPage pdfPage))
          pdfPage = new PdfPage(dict);
        page = pdfPage;
        break;
      }
    }
    return page;
  }

  public PdfPage Add()
  {
    PdfPage page = new PdfPage();
    this.Insert(this.Count, page);
    return page;
  }

  public PdfPage Add(PdfPage page) => this.Insert(this.Count, page);

  public PdfPage Insert(int index)
  {
    PdfPage page = new PdfPage();
    this.Insert(index, page);
    return page;
  }

  public PdfPage Insert(int index, PdfPage page)
  {
    if (page == null)
      throw new ArgumentNullException(nameof (page));
    PdfPage pdfPage1;
    if (page.Owner == this.Owner)
    {
      int count = this.Count;
      for (int index1 = 0; index1 < count; ++index1)
      {
        if (this[index1] == page)
          throw new InvalidOperationException(PSSR.MultiplePageInsert);
      }
      this.Owner._irefTable.Add((PdfObject) page);
      Debug.Assert(page.Owner == this.Owner);
      this.PagesArray.Elements.Insert(index, (PdfItem) page.Reference);
      this.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
      pdfPage1 = page;
    }
    else
    {
      if (page.Owner == null)
      {
        page.Document = this.Owner;
        this.Owner._irefTable.Add((PdfObject) page);
        Debug.Assert(page.Owner == this.Owner);
        this.PagesArray.Elements.Insert(index, (PdfItem) page.Reference);
        this.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
      }
      else
      {
        PdfPage pdfPage2 = page;
        page = this.ImportExternalPage(pdfPage2);
        this.Owner._irefTable.Add((PdfObject) page);
        this.Owner.FormTable.GetImportedObjectTable(pdfPage2).Add(pdfPage2.ObjectID, page.Reference);
        this.PagesArray.Elements.Insert(index, (PdfItem) page.Reference);
        this.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
        PdfAnnotations.FixImportedAnnotation(page);
      }
      if (this.Owner.Settings.TrimMargins.AreSet)
        page.TrimMargins = this.Owner.Settings.TrimMargins;
      pdfPage1 = page;
    }
    return pdfPage1;
  }

  public void InsertRange(int index, PdfDocument document, int startIndex, int pageCount)
  {
    if (document == null)
      throw new ArgumentNullException(nameof (document));
    if ((index < 0 ? 1 : (index > this.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (index), "Argument 'index' out of range.");
    int pageCount1 = document.PageCount;
    if ((startIndex < 0 ? 1 : (startIndex + pageCount > pageCount1 ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (startIndex), "Argument 'startIndex' out of range.");
    PdfPage[] newPages = pageCount <= pageCount1 ? new PdfPage[pageCount] : throw new ArgumentOutOfRangeException(nameof (pageCount), "Argument 'pageCount' out of range.");
    PdfPage[] impPages = new PdfPage[pageCount];
    int index1 = 0;
    int index2 = index;
    for (int index3 = startIndex; index3 < startIndex + pageCount; ++index3)
    {
      PdfPage page = document.Pages[index3];
      PdfPage pdfPage = this.ImportExternalPage(page);
      newPages[index1] = pdfPage;
      impPages[index1] = page;
      this.Owner._irefTable.Add((PdfObject) pdfPage);
      this.Owner.FormTable.GetImportedObjectTable(page).Add(page.ObjectID, pdfPage.Reference);
      this.PagesArray.Elements.Insert(index2, (PdfItem) pdfPage.Reference);
      if (this.Owner.Settings.TrimMargins.AreSet)
        pdfPage.TrimMargins = this.Owner.Settings.TrimMargins;
      ++index1;
      ++index2;
    }
    this.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
    int index4 = 0;
    for (int index5 = startIndex; index5 < startIndex + pageCount; ++index5)
    {
      PdfPage page = document.Pages[index5];
      PdfPage pdfPage = newPages[index4];
      PdfArray array = page.Elements.GetArray("/Annots");
      if (array != null)
      {
        PdfAnnotations pdfAnnotations = new PdfAnnotations(this.Owner);
        int count = array.Elements.Count;
        for (int index6 = 0; index6 < count; ++index6)
        {
          PdfDictionary dictionary = array.Elements.GetDictionary(index6);
          if (dictionary != null && dictionary.Elements.GetString("/Subtype") == "/Link")
          {
            bool flag = false;
            PdfLinkAnnotation annotation = new PdfLinkAnnotation(this.Owner);
            foreach (PdfName keyName in dictionary.Elements.KeyNames)
            {
              switch (keyName.Value)
              {
                case "/BS":
                  annotation.Elements.Add("/BS", (PdfItem) new PdfLiteral("<</W 0>>"));
                  break;
                case "/F":
                  PdfItem pdfItem1 = dictionary.Elements.GetValue("/F");
                  Debug.Assert(pdfItem1 is PdfInteger);
                  annotation.Elements.Add("/F", pdfItem1.Clone());
                  break;
                case "/Rect":
                  PdfItem pdfItem2 = dictionary.Elements.GetValue("/Rect");
                  Debug.Assert(pdfItem2 is PdfArray);
                  annotation.Elements.Add("/Rect", pdfItem2.Clone());
                  break;
                case "/StructParent":
                  PdfItem pdfItem3 = dictionary.Elements.GetValue("/StructParent");
                  Debug.Assert(pdfItem3 is PdfInteger);
                  annotation.Elements.Add("/StructParent", pdfItem3.Clone());
                  break;
                case "/Dest":
                  if ((!(dictionary.Elements.GetValue("/Dest").Clone() is PdfArray pdfArray) ? 0 : (pdfArray.Elements.Count == 5 ? 1 : 0)) != 0 && pdfArray.Elements[0] is PdfReference element)
                  {
                    PdfReference pdfReference = PdfPages.RemapReference(newPages, impPages, element);
                    if (pdfReference != null)
                    {
                      pdfArray.Elements[0] = (PdfItem) pdfReference;
                      annotation.Elements.Add("/Dest", (PdfItem) pdfArray);
                      flag = true;
                      break;
                    }
                    break;
                  }
                  break;
              }
            }
            if (flag)
              pdfAnnotations.Add((PdfAnnotation) annotation);
          }
        }
        if (pdfAnnotations.Count > 0)
          pdfPage.Elements.Add("/Annots", (PdfItem) pdfAnnotations);
      }
      ++index4;
    }
  }

  public void InsertRange(int index, PdfDocument document)
  {
    if (document == null)
      throw new ArgumentNullException(nameof (document));
    this.InsertRange(index, document, 0, document.PageCount);
  }

  public void InsertRange(int index, PdfDocument document, int startIndex)
  {
    if (document == null)
      throw new ArgumentNullException(nameof (document));
    this.InsertRange(index, document, startIndex, document.PageCount - startIndex);
  }

  public void Remove(PdfPage page)
  {
    this.PagesArray.Elements.Remove((PdfItem) page.Reference);
    this.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
  }

  public void RemoveAt(int index)
  {
    this.PagesArray.Elements.RemoveAt(index);
    this.Elements.SetInteger("/Count", this.PagesArray.Elements.Count);
  }

  public void MovePage(int oldIndex, int newIndex)
  {
    if ((oldIndex < 0 ? 1 : (oldIndex >= this.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (oldIndex));
    if ((newIndex < 0 ? 1 : (newIndex >= this.Count ? 1 : 0)) != 0)
      throw new ArgumentOutOfRangeException(nameof (newIndex));
    if (oldIndex == newIndex)
      return;
    PdfReference element = (PdfReference) this._pagesArray.Elements[oldIndex];
    this._pagesArray.Elements.RemoveAt(oldIndex);
    this._pagesArray.Elements.Insert(newIndex, (PdfItem) element);
  }

  private PdfPage ImportExternalPage(PdfPage importPage)
  {
    if (importPage.Owner._openMode != PdfDocumentOpenMode.Import)
      throw new InvalidOperationException("A PDF document must be opened with PdfDocumentOpenMode.Import to import pages from it.");
    PdfPage page = new PdfPage(this._document);
    this.CloneElement(page, importPage, "/Resources", false);
    this.CloneElement(page, importPage, "/Contents", false);
    this.CloneElement(page, importPage, "/MediaBox", true);
    this.CloneElement(page, importPage, "/CropBox", true);
    this.CloneElement(page, importPage, "/Rotate", true);
    this.CloneElement(page, importPage, "/BleedBox", true);
    this.CloneElement(page, importPage, "/TrimBox", true);
    this.CloneElement(page, importPage, "/ArtBox", true);
    this.CloneElement(page, importPage, "/Annots", false);
    return page;
  }

  private void CloneElement(PdfPage page, PdfPage importPage, string key, bool deepcopy)
  {
    Debug.Assert(page != null);
    Debug.Assert(page.Owner == this._document);
    Debug.Assert(importPage.Owner != null);
    Debug.Assert(importPage.Owner != this._document);
    PdfItem element = importPage.Elements[key];
    if (element == null)
      return;
    PdfImportedObjectTable importedObjectTable = (PdfImportedObjectTable) null;
    if (!deepcopy)
      importedObjectTable = this.Owner.FormTable.GetImportedObjectTable(importPage);
    if (element is PdfReference)
      element = (PdfItem) ((PdfReference) element).Value;
    if (element is PdfObject)
    {
      PdfObject externalObject = (PdfObject) element;
      PdfObject pdfObject;
      if (deepcopy)
      {
        Debug.Assert(externalObject.Owner != null, "See 'else' case for details");
        pdfObject = PdfObject.DeepCopyClosure(this._document, externalObject);
      }
      else
      {
        if (externalObject.Owner == null)
          externalObject.Document = importPage.Owner;
        pdfObject = PdfObject.ImportClosure(importedObjectTable, page.Owner, externalObject);
      }
      if (pdfObject.Reference == null)
        page.Elements[key] = (PdfItem) pdfObject;
      else
        page.Elements[key] = (PdfItem) pdfObject.Reference;
    }
    else
      page.Elements[key] = element.Clone();
  }

  private static PdfReference RemapReference(
    PdfPage[] newPages,
    PdfPage[] impPages,
    PdfReference iref)
  {
    PdfReference pdfReference;
    for (int index = 0; index < newPages.Length; ++index)
    {
      if (impPages[index].Reference == iref)
      {
        pdfReference = newPages[index].Reference;
        goto label_6;
      }
    }
    pdfReference = (PdfReference) null;
label_6:
    return pdfReference;
  }

  public PdfArray PagesArray
  {
    get
    {
      if (this._pagesArray == null)
        this._pagesArray = (PdfArray) this.Elements.GetValue("/Kids", VCF.Create);
      return this._pagesArray;
    }
  }

  internal void FlattenPageTree()
  {
    PdfPage.InheritedValues values = new PdfPage.InheritedValues();
    PdfPage.InheritValues((PdfDictionary) this, ref values);
    PdfDictionary[] kids = this.GetKids(this.Reference, values, (PdfDictionary) null);
    PdfArray pdfArray = new PdfArray(this.Owner);
    foreach (PdfDictionary pdfDictionary in kids)
    {
      pdfDictionary.Elements["/Parent"] = (PdfItem) this.Reference;
      pdfArray.Elements.Add((PdfItem) pdfDictionary.Reference);
    }
    this.Elements.SetName("/Type", "/Pages");
    this.Elements.SetValue("/Kids", (PdfItem) pdfArray);
    this.Elements.SetInteger("/Count", pdfArray.Elements.Count);
  }

  private PdfDictionary[] GetKids(
    PdfReference iref,
    PdfPage.InheritedValues values,
    PdfDictionary parent)
  {
    PdfDictionary pdfDictionary = (PdfDictionary) iref.Value;
    string name = pdfDictionary.Elements.GetName("/Type");
    PdfDictionary[] kids;
    if (name == "/Page")
    {
      PdfPage.InheritValues(pdfDictionary, values);
      kids = new PdfDictionary[1]{ pdfDictionary };
    }
    else if (string.IsNullOrEmpty(name))
    {
      PdfPage.InheritValues(pdfDictionary, values);
      kids = new PdfDictionary[1]{ pdfDictionary };
    }
    else
    {
      Debug.Assert(pdfDictionary.Elements.GetName("/Type") == "/Pages");
      PdfPage.InheritValues(pdfDictionary, ref values);
      List<PdfDictionary> pdfDictionaryList = new List<PdfDictionary>();
      if (!(pdfDictionary.Elements["/Kids"] is PdfArray element1) && pdfDictionary.Elements["/Kids"] is PdfReference element2)
        element1 = element2.Value as PdfArray;
      foreach (PdfReference iref1 in element1)
        pdfDictionaryList.AddRange((IEnumerable<PdfDictionary>) this.GetKids(iref1, values, pdfDictionary));
      Debug.Assert(pdfDictionaryList.Count == pdfDictionary.Elements.GetInteger("/Count"));
      kids = pdfDictionaryList.ToArray();
    }
    return kids;
  }

  internal override void PrepareForSave()
  {
    int count = this._pagesArray.Elements.Count;
    for (int index = 0; index < count; ++index)
      this[index].PrepareForSave();
  }

  public IEnumerator<PdfPage> GetEnumerator()
  {
    return (IEnumerator<PdfPage>) new PdfPages.PdfPagesEnumerator(this);
  }

  internal override DictionaryMeta Meta => PdfPages.Keys.Meta;

  private class PdfPagesEnumerator : IEnumerator<PdfPage>, IDisposable, IEnumerator
  {
    private PdfPage _currentElement;
    private int _index;
    private readonly PdfPages _list;

    internal PdfPagesEnumerator(PdfPages list)
    {
      this._list = list;
      this._index = -1;
    }

    public bool MoveNext()
    {
      bool flag;
      if (this._index < this._list.Count - 1)
      {
        ++this._index;
        this._currentElement = this._list[this._index];
        flag = true;
      }
      else
      {
        this._index = this._list.Count;
        flag = false;
      }
      return flag;
    }

    public void Reset()
    {
      this._currentElement = (PdfPage) null;
      this._index = -1;
    }

    object IEnumerator.Current => (object) this.Current;

    public PdfPage Current
    {
      get
      {
        if ((this._index == -1 ? 1 : (this._index >= this._list.Count ? 1 : 0)) != 0)
          throw new InvalidOperationException(PSSR.ListEnumCurrentOutOfRange);
        return this._currentElement;
      }
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

    public static DictionaryMeta Meta
    {
      get
      {
        return PdfPages.Keys._meta ?? (PdfPages.Keys._meta = KeysBase.CreateMeta(typeof (PdfPages.Keys)));
      }
    }
  }
}
