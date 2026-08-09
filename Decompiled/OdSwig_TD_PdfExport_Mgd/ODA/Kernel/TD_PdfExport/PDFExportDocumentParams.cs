using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_PdfExport;

public interface PDFExportDocumentParams
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	HandleRef GetInterfaceCPtr();

	void setVersion(OdPDF_PDFFormatVersions version);

	OdPDF_PDFFormatVersions version();

	void setArchived(TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDF_A_mode mode);

	TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDF_A_mode archived();

	void setPageParams(OdArray_OdGsPageParams_OdObjectsAllocator pageParams);

	OdArray_OdGsPageParams_OdObjectsAllocator pageParams();

	void setTitle(string sTitle);

	string title();

	void setAuthor(string sAuthor);

	string author();

	void setSubject(string sSubject);

	string subject();

	void setKeywords(string sKeywords);

	string keywords();

	void setCreator(string sCreator);

	string creator();

	void setProducer(string sProducer);

	string producer();

	void setUserPassword(string sUserPassword);

	string userPassword();

	void setOwnerPassword(string sOwnerPassword);

	string ownerPassword();

	void setAccessPermissionFlags(TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags flags);

	TD_PDF_2D_EXPORT_PDFExportDocumentParams_PDFAccessPermissionsFlags accessPermissionFlags();

	void addWatermark(TD_PDF_2D_EXPORT_Watermark wm);

	OdArray_TD_PDF_2D_EXPORT_Watermark_OdObjectsAllocator watermarks();

	void clearWatermarks();
}
