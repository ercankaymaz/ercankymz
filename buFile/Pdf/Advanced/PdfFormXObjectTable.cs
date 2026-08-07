// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfFormXObjectTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal sealed class PdfFormXObjectTable(PdfDocument document) : PdfResourceTable(document)
{
  private readonly Dictionary<PdfFormXObjectTable.Selector, PdfImportedObjectTable> _forms = new Dictionary<PdfFormXObjectTable.Selector, PdfImportedObjectTable>();

  public PdfFormXObject GetForm(XForm form)
  {
    PdfFormXObject form1;
    if (form._pdfForm != null)
    {
      Debug.Assert(form.IsTemplate, "An XPdfForm must not have a PdfFormXObject.");
      if (form._pdfForm.Owner == this.Owner)
      {
        form1 = form._pdfForm;
        goto label_11;
      }
      form._pdfForm = (PdfFormXObject) null;
    }
    if (form is XPdfForm form2)
    {
      PdfFormXObjectTable.Selector key = new PdfFormXObjectTable.Selector(form);
      PdfImportedObjectTable importedObjectTable;
      if (!this._forms.TryGetValue(key, out importedObjectTable))
      {
        importedObjectTable = new PdfImportedObjectTable(this.Owner, form2.ExternalDocument);
        this._forms[key] = importedObjectTable;
      }
      PdfFormXObject xObject = importedObjectTable.GetXObject(form2.PageNumber);
      if (xObject == null)
      {
        xObject = new PdfFormXObject(this.Owner, importedObjectTable, form2);
        importedObjectTable.SetXObject(form2.PageNumber, xObject);
      }
      form1 = xObject;
    }
    else
    {
      Debug.Assert(form.GetType() == typeof (XForm));
      form._pdfForm = new PdfFormXObject(this.Owner, form);
      form1 = form._pdfForm;
    }
label_11:
    return form1;
  }

  public PdfImportedObjectTable GetImportedObjectTable(PdfPage page)
  {
    PdfFormXObjectTable.Selector key = new PdfFormXObjectTable.Selector(page);
    PdfImportedObjectTable importedObjectTable;
    if (!this._forms.TryGetValue(key, out importedObjectTable))
    {
      importedObjectTable = new PdfImportedObjectTable(this.Owner, page.Owner);
      this._forms[key] = importedObjectTable;
    }
    return importedObjectTable;
  }

  public PdfImportedObjectTable GetImportedObjectTable(PdfDocument document)
  {
    PdfFormXObjectTable.Selector key = document != null ? new PdfFormXObjectTable.Selector(document) : throw new ArgumentNullException(nameof (document));
    PdfImportedObjectTable importedObjectTable;
    if (!this._forms.TryGetValue(key, out importedObjectTable))
    {
      importedObjectTable = new PdfImportedObjectTable(this.Owner, document);
      this._forms[key] = importedObjectTable;
    }
    return importedObjectTable;
  }

  public void DetachDocument(PdfDocument.DocumentHandle handle)
  {
    if (handle.IsAlive)
    {
      foreach (PdfFormXObjectTable.Selector key in this._forms.Keys)
      {
        PdfImportedObjectTable form = this._forms[key];
        if ((form.ExternalDocument == null ? 0 : (form.ExternalDocument.Handle == handle ? 1 : 0)) != 0)
        {
          this._forms.Remove(key);
          break;
        }
      }
    }
    bool flag = true;
    while (flag)
    {
      flag = false;
      foreach (PdfFormXObjectTable.Selector key in this._forms.Keys)
      {
        if (this._forms[key].ExternalDocument == null)
        {
          this._forms.Remove(key);
          flag = true;
          break;
        }
      }
    }
  }

  public class Selector
  {
    private string _path;

    public Selector(XForm form) => this._path = form._path.ToLowerInvariant();

    public Selector(PdfPage page)
    {
      this._path = "*" + page.Owner.Guid.ToString("B");
      this._path = this._path.ToLowerInvariant();
    }

    public Selector(PdfDocument document)
    {
      this._path = "*" + document.Guid.ToString("B");
      this._path = this._path.ToLowerInvariant();
    }

    public string Path
    {
      get => this._path;
      set => this._path = value;
    }

    public override bool Equals(object obj)
    {
      return obj is PdfFormXObjectTable.Selector selector && this._path == selector._path;
    }

    public override int GetHashCode() => this._path.GetHashCode();
  }
}
