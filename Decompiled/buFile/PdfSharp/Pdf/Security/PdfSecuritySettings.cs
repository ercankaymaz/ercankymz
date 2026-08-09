namespace PdfSharp.Pdf.Security;

public sealed class PdfSecuritySettings
{
	private readonly PdfDocument _document;

	internal bool _hasOwnerPermissions = true;

	private PdfDocumentSecurityLevel _documentSecurityLevel;

	public bool HasOwnerPermissions => _hasOwnerPermissions;

	public PdfDocumentSecurityLevel DocumentSecurityLevel
	{
		get
		{
			return _documentSecurityLevel;
		}
		set
		{
			_documentSecurityLevel = value;
		}
	}

	public string UserPassword
	{
		set
		{
			SecurityHandler.UserPassword = value;
		}
	}

	public string OwnerPassword
	{
		set
		{
			SecurityHandler.OwnerPassword = value;
		}
	}

	public bool PermitPrint
	{
		get
		{
			return (SecurityHandler.Permission & PdfUserAccessPermission.PermitPrint) != 0;
		}
		set
		{
			PdfUserAccessPermission permission = SecurityHandler.Permission;
			permission = ((!value) ? (permission & ~PdfUserAccessPermission.PermitPrint) : (permission | PdfUserAccessPermission.PermitPrint));
			SecurityHandler.Permission = permission;
		}
	}

	public bool PermitModifyDocument
	{
		get
		{
			return (SecurityHandler.Permission & PdfUserAccessPermission.PermitModifyDocument) != 0;
		}
		set
		{
			PdfUserAccessPermission permission = SecurityHandler.Permission;
			permission = ((!value) ? (permission & ~PdfUserAccessPermission.PermitModifyDocument) : (permission | PdfUserAccessPermission.PermitModifyDocument));
			SecurityHandler.Permission = permission;
		}
	}

	public bool PermitExtractContent
	{
		get
		{
			return (SecurityHandler.Permission & PdfUserAccessPermission.PermitExtractContent) != 0;
		}
		set
		{
			PdfUserAccessPermission permission = SecurityHandler.Permission;
			permission = ((!value) ? (permission & ~PdfUserAccessPermission.PermitExtractContent) : (permission | PdfUserAccessPermission.PermitExtractContent));
			SecurityHandler.Permission = permission;
		}
	}

	public bool PermitAnnotations
	{
		get
		{
			return (SecurityHandler.Permission & PdfUserAccessPermission.PermitAnnotations) != 0;
		}
		set
		{
			PdfUserAccessPermission permission = SecurityHandler.Permission;
			permission = ((!value) ? (permission & ~PdfUserAccessPermission.PermitAnnotations) : (permission | PdfUserAccessPermission.PermitAnnotations));
			SecurityHandler.Permission = permission;
		}
	}

	public bool PermitFormsFill
	{
		get
		{
			return (SecurityHandler.Permission & PdfUserAccessPermission.PermitFormsFill) != 0;
		}
		set
		{
			PdfUserAccessPermission permission = SecurityHandler.Permission;
			permission = ((!value) ? (permission & ~PdfUserAccessPermission.PermitFormsFill) : (permission | PdfUserAccessPermission.PermitFormsFill));
			SecurityHandler.Permission = permission;
		}
	}

	public bool PermitAccessibilityExtractContent
	{
		get
		{
			return (SecurityHandler.Permission & PdfUserAccessPermission.PermitAccessibilityExtractContent) != 0;
		}
		set
		{
			PdfUserAccessPermission permission = SecurityHandler.Permission;
			permission = ((!value) ? (permission & ~PdfUserAccessPermission.PermitAccessibilityExtractContent) : (permission | PdfUserAccessPermission.PermitAccessibilityExtractContent));
			SecurityHandler.Permission = permission;
		}
	}

	public bool PermitAssembleDocument
	{
		get
		{
			return (SecurityHandler.Permission & PdfUserAccessPermission.PermitAssembleDocument) != 0;
		}
		set
		{
			PdfUserAccessPermission permission = SecurityHandler.Permission;
			permission = ((!value) ? (permission & ~PdfUserAccessPermission.PermitAssembleDocument) : (permission | PdfUserAccessPermission.PermitAssembleDocument));
			SecurityHandler.Permission = permission;
		}
	}

	public bool PermitFullQualityPrint
	{
		get
		{
			return (SecurityHandler.Permission & PdfUserAccessPermission.PermitFullQualityPrint) != 0;
		}
		set
		{
			PdfUserAccessPermission permission = SecurityHandler.Permission;
			permission = ((!value) ? (permission & ~PdfUserAccessPermission.PermitFullQualityPrint) : (permission | PdfUserAccessPermission.PermitFullQualityPrint));
			SecurityHandler.Permission = permission;
		}
	}

	internal PdfStandardSecurityHandler SecurityHandler => _document._trailer.SecurityHandler;

	internal PdfSecuritySettings(PdfDocument document)
	{
		_document = document;
	}

	internal bool CanSave(ref string message)
	{
		if (_documentSecurityLevel != PdfDocumentSecurityLevel.None && string.IsNullOrEmpty(SecurityHandler._userPassword) && string.IsNullOrEmpty(SecurityHandler._ownerPassword))
		{
			message = PSSR.UserOrOwnerPasswordRequired;
			return false;
		}
		return true;
	}
}
