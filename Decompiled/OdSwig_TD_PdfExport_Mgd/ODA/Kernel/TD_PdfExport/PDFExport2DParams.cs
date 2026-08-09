using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PdfExport;

public interface PDFExport2DParams : PDFExportBaseParams
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	new HandleRef GetInterfaceCPtr();

	void setExportFlags(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags flags);

	TD_PDF_2D_EXPORT_PDFExport2DParams_PDFExportFlags exportFlags();

	void setSearchableTextType(TD_PDF_2D_EXPORT_PDFExport2DParams_SearchableTextType type);

	TD_PDF_2D_EXPORT_PDFExport2DParams_SearchableTextType searchableTextType();

	void setColorPolicy(TD_PDF_2D_EXPORT_PDFExport2DParams_ColorPolicy policy);

	TD_PDF_2D_EXPORT_PDFExport2DParams_ColorPolicy colorPolicy();

	void setBackground(uint background);

	uint background();

	void setPalette(uint[] pPalette);

	uint[] palette();

	void setGeomDPI(ushort dpi);

	ushort getGeomDPI();

	void setHatchDPI(ushort dpi);

	ushort hatchDPI();

	void setColorImagesDPI(ushort dpi);

	ushort colorImagesDPI();

	void setBWImagesDPI(ushort dpi);

	ushort bwImagesDPI();

	void setSolidHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType type);

	TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType solidHatchesExportType();

	void setGradientHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType type);

	TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType gradientHatchesExportType();

	void setOtherHatchesExportType(TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType arg0);

	TD_PDF_2D_EXPORT_PDFExport2DParams_ExportHatchesType otherHatchesExportType();

	bool imageCropping();

	void setImageCropping(bool bEnable);

	ushort dctQuality();

	void setDCTQuality(ushort quality);

	bool monoImagesAsMask();

	void setMonoImagesAsMask(bool bAsMask);

	bool get720DPIMode();

	void set720DPIMode(bool bMode);

	bool useViewExtents();

	void setUseViewExtents(bool bViewExtents);

	bool dctCompression();

	void setDCTCompression(bool bEnable);

	bool dctCompressionShadedViewports();

	void setDCTCompressionShadedViewports(bool bEnable);

	bool upscaleImages();

	void setUpscaleImages(bool bEnable);

	void setTransparentShadedVpBg(bool bEnable);

	bool transparentShadedVpBg();

	void setForceDisableGsDevice(bool bDisable);

	bool forceDisableGsDevice();

	void setShadedVpExportMode(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFShadedViewportExportMode mode);

	TD_PDF_2D_EXPORT_PDFExport2DParams_PDFShadedViewportExportMode shadedVpExportMode();

	bool export2XObject();

	bool useGsCache();

	void setUseGsCache(bool bEnable);

	bool isParallelVectorization();

	void setParallelVectorization(bool bOn);

	void setUsePdfBlocks(bool bOn);

	bool isUsePdfBlocks();

	void setXrefsAsPdfBlocks(bool bOn);

	bool isXrefsAsPdfBlocks();

	bool searchableTextAsHiddenText();

	bool searchableTextInRenderedViews();

	void setSearchableTextAsHiddenText(bool bOn);

	void setSearchableTextInRenderedViews(bool bOn);

	bool isTTFTextAsGeometry();

	bool isSHXTextAsGeometry();

	void enableBookmarks(bool bEnable);

	bool bookmarksEnabled();

	OdStringArray layoutNames();

	void setLayoutNames(OdStringArray layoutNames);

	void setMeasuringType(TD_PDF_2D_EXPORT_PDFExport2DParams_PDFMeasuringType type);

	TD_PDF_2D_EXPORT_PDFExport2DParams_PDFMeasuringType measuringType();
}
