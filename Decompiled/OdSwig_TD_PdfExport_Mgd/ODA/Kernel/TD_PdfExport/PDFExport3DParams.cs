using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_PDFToolkit;

namespace ODA.Kernel.TD_PdfExport;

public interface PDFExport3DParams : PRCExportParams, PDFExportBaseParams
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	new HandleRef GetInterfaceCPtr();

	bool hasPrcBackground();

	uint getPrcBackground();

	void setPrcBackground(uint bacgr);

	void clearPrcBackground();

	PDF3D_ENUMS_PRCRenderingMode getPrcRenderingMode();

	void setPrcRenderingMode(PDF3D_ENUMS_PRCRenderingMode renderMode);
}
