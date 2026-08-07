// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Security.PdfSecuritySettings
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf.Security;

public sealed class PdfSecuritySettings
{
  private readonly PdfDocument _document;
  internal bool _hasOwnerPermissions = true;
  private PdfDocumentSecurityLevel _documentSecurityLevel;

  internal PdfSecuritySettings(PdfDocument document) => this._document = document;

  public bool HasOwnerPermissions => this._hasOwnerPermissions;

  public PdfDocumentSecurityLevel DocumentSecurityLevel
  {
    get => this._documentSecurityLevel;
    set => this._documentSecurityLevel = value;
  }

  public string UserPassword
  {
    set => this.SecurityHandler.UserPassword = value;
  }

  public string OwnerPassword
  {
    set => this.SecurityHandler.OwnerPassword = value;
  }

  internal bool CanSave(ref string message)
  {
    bool flag;
    if (this._documentSecurityLevel != 0 && (!string.IsNullOrEmpty(this.SecurityHandler._userPassword) ? 0 : (string.IsNullOrEmpty(this.SecurityHandler._ownerPassword) ? 1 : 0)) != 0)
    {
      message = PSSR.UserOrOwnerPasswordRequired;
      flag = false;
    }
    else
      flag = true;
    return flag;
  }

  public bool PermitPrint
  {
    get => (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitPrint) != 0;
    set
    {
      PdfUserAccessPermission permission = this.SecurityHandler.Permission;
      this.SecurityHandler.Permission = !value ? permission & ~PdfUserAccessPermission.PermitPrint : permission | PdfUserAccessPermission.PermitPrint;
    }
  }

  public bool PermitModifyDocument
  {
    get => (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitModifyDocument) != 0;
    set
    {
      PdfUserAccessPermission permission = this.SecurityHandler.Permission;
      this.SecurityHandler.Permission = !value ? permission & ~PdfUserAccessPermission.PermitModifyDocument : permission | PdfUserAccessPermission.PermitModifyDocument;
    }
  }

  public bool PermitExtractContent
  {
    get => (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitExtractContent) != 0;
    set
    {
      PdfUserAccessPermission permission = this.SecurityHandler.Permission;
      this.SecurityHandler.Permission = !value ? permission & ~PdfUserAccessPermission.PermitExtractContent : permission | PdfUserAccessPermission.PermitExtractContent;
    }
  }

  public bool PermitAnnotations
  {
    get => (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitAnnotations) != 0;
    set
    {
      PdfUserAccessPermission permission = this.SecurityHandler.Permission;
      this.SecurityHandler.Permission = !value ? permission & ~PdfUserAccessPermission.PermitAnnotations : permission | PdfUserAccessPermission.PermitAnnotations;
    }
  }

  public bool PermitFormsFill
  {
    get => (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitFormsFill) != 0;
    set
    {
      PdfUserAccessPermission permission = this.SecurityHandler.Permission;
      this.SecurityHandler.Permission = !value ? permission & ~PdfUserAccessPermission.PermitFormsFill : permission | PdfUserAccessPermission.PermitFormsFill;
    }
  }

  public bool PermitAccessibilityExtractContent
  {
    get
    {
      return (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitAccessibilityExtractContent) != 0;
    }
    set
    {
      PdfUserAccessPermission permission = this.SecurityHandler.Permission;
      this.SecurityHandler.Permission = !value ? permission & ~PdfUserAccessPermission.PermitAccessibilityExtractContent : permission | PdfUserAccessPermission.PermitAccessibilityExtractContent;
    }
  }

  public bool PermitAssembleDocument
  {
    get => (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitAssembleDocument) != 0;
    set
    {
      PdfUserAccessPermission permission = this.SecurityHandler.Permission;
      this.SecurityHandler.Permission = !value ? permission & ~PdfUserAccessPermission.PermitAssembleDocument : permission | PdfUserAccessPermission.PermitAssembleDocument;
    }
  }

  public bool PermitFullQualityPrint
  {
    get => (this.SecurityHandler.Permission & PdfUserAccessPermission.PermitFullQualityPrint) != 0;
    set
    {
      PdfUserAccessPermission permission = this.SecurityHandler.Permission;
      this.SecurityHandler.Permission = !value ? permission & ~PdfUserAccessPermission.PermitFullQualityPrint : permission | PdfUserAccessPermission.PermitFullQualityPrint;
    }
  }

  internal PdfStandardSecurityHandler SecurityHandler => this._document._trailer.SecurityHandler;
}
