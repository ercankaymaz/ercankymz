using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_PDFToolkit;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public interface PRCExportParams : PDFExportBaseParams
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	new HandleRef GetInterfaceCPtr();

	void setPRCMode(TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport flags);

	TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport getPRCMode();

	OdPrcContextForPdfExport getPRCContext();

	void setPRCContext(OdRxObject pContext);

	bool hasPrcBrepCompression(out PDF3D_ENUMS_PRCCompressionLevel compressionLev);

	bool hasPrcTessellationCompression();

	void setPRCCompression(PDF3D_ENUMS_PRCCompressionLevel compressionLevel, bool bCompressBrep, bool bCompressTessellation);

	PDF3D_ENUMS_PrcExportColorComponentBehavior getPrcExportAmbientColorBehavior();

	void setPrcExportAmbientColorBehavior(PDF3D_ENUMS_PrcExportColorComponentBehavior value);
}
