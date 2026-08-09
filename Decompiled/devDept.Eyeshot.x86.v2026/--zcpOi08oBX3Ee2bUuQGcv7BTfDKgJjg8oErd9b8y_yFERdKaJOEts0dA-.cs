using System;
using System.Drawing;
using System.Text;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_PdfExport;
using ODA.Kernel.TD_RootIntegrated;
using ODA.Publish.PdfPublish;
using devDept.Eyeshot.Translators;

internal sealed class _0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D
{
	internal static OdStreamBuf _0023_003Dz_P5boncdw1JJ(OdDbDatabase _0023_003DzR8GRspk_003D, StringBuilder _0023_003DztDgXtV5iifi0)
	{
		((OdDbViewportTableRecord)_0023_003DzR8GRspk_003D.activeViewportId().safeOpenObject(OdDb_OpenMode.kForWrite)).setRenderMode(OdDb_RenderMode.kFlatShaded);
		TD_RootIntegrated_Globals.odrxDynamicLinker().loadApp(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531304), silent: false);
		TD_RootIntegrated_Globals.odrxDynamicLinker().loadApp(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531318), silent: false);
		PRCStreamsMap pRCStreamsMap = new PRCStreamsMap();
		TD_PDF_2D_EXPORT_OdPdfExport tD_PDF_2D_EXPORT_OdPdfExport = new TD_PDF_2D_EXPORT_PdfExportModule(OdRxModule.getCPtr(TD_RootIntegrated_Globals.odrxDynamicLinker().loadApp(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531264))).Handle, cMemoryOwn: false).create();
		TD_PDF_2D_EXPORT_PDFExportParams tD_PDF_2D_EXPORT_PDFExportParams = new TD_PDF_2D_EXPORT_PDFExportParams();
		try
		{
			tD_PDF_2D_EXPORT_PDFExportParams.setDatabase(_0023_003DzR8GRspk_003D);
			tD_PDF_2D_EXPORT_PDFExportParams.setPRCContext(_0023_003DzjC80dwowOk6Z_0024kO6h2QSyXPIzAHg());
			tD_PDF_2D_EXPORT_PDFExportParams.setPRCMode(TD_PDF_2D_EXPORT_PRCExportParams_PRCSupport.kAsBrep);
			uint num = tD_PDF_2D_EXPORT_OdPdfExport.exportToPRCStreams(tD_PDF_2D_EXPORT_PDFExportParams, pRCStreamsMap);
			if (num != 0)
			{
				string text = tD_PDF_2D_EXPORT_OdPdfExport.exportPdfErrorCode(num);
				_0023_003DztDgXtV5iifi0.AppendLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531375) + num + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531377) + text);
				return null;
			}
		}
		finally
		{
			((IDisposable)tD_PDF_2D_EXPORT_PDFExportParams).Dispose();
		}
		if (pRCStreamsMap.Count == 0)
		{
			return null;
		}
		OdStreamBuf odStreamBuf = pRCStreamsMap[0u];
		odStreamBuf.rewind();
		return odStreamBuf;
	}

	private static OdRxObject _0023_003DzjC80dwowOk6Z_0024kO6h2QSyXPIzAHg()
	{
		OdRxObject pointer = null;
		OdRxClass odRxClass = OdRxClass.cast(TD_RootIntegrated_Globals.odrxClassDictionary().getAt(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531358)));
		if (odRxClass != null)
		{
			pointer = odRxClass.create();
		}
		return OdRxObject.cast(pointer);
	}

	internal static OdPdfPublish_Rendering_Mode _0023_003DzFQTHtoywbw5wDdGm5A_003D_003D(Write3DPDF.renderMode _0023_003Dzsv_0024nzT7Ums8C)
	{
		return _0023_003Dzsv_0024nzT7Ums8C switch
		{
			Write3DPDF.renderMode.Solid => OdPdfPublish_Rendering_Mode.kSolid, 
			Write3DPDF.renderMode.SolidWireframe => OdPdfPublish_Rendering_Mode.kSolidWireframe, 
			Write3DPDF.renderMode.SolidOutline => OdPdfPublish_Rendering_Mode.kSolidOutline, 
			Write3DPDF.renderMode.BoundingBox => OdPdfPublish_Rendering_Mode.kBoundingBox, 
			Write3DPDF.renderMode.Transparent => OdPdfPublish_Rendering_Mode.kTransparent, 
			Write3DPDF.renderMode.TransparentWireframe => OdPdfPublish_Rendering_Mode.kTransparentWireframe, 
			Write3DPDF.renderMode.TransparentBoundingBox => OdPdfPublish_Rendering_Mode.kTransparentBoundingBox, 
			Write3DPDF.renderMode.TransparentBoundingBoxOutline => OdPdfPublish_Rendering_Mode.kTransparentBoundingBoxOutline, 
			Write3DPDF.renderMode.Illustration => OdPdfPublish_Rendering_Mode.kIllustration, 
			Write3DPDF.renderMode.ShadedIllustration => OdPdfPublish_Rendering_Mode.kShadedIllustration, 
			Write3DPDF.renderMode.Wireframe => OdPdfPublish_Rendering_Mode.kWireframe, 
			Write3DPDF.renderMode.ShadedWireframe => OdPdfPublish_Rendering_Mode.kShadedWireframe, 
			Write3DPDF.renderMode.HiddenWireframe => OdPdfPublish_Rendering_Mode.kHiddenWireframe, 
			Write3DPDF.renderMode.Vertices => OdPdfPublish_Rendering_Mode.kVertices, 
			Write3DPDF.renderMode.ShadedVertices => OdPdfPublish_Rendering_Mode.kShadedVertices, 
			_ => OdPdfPublish_Rendering_Mode.kDefault, 
		};
	}

	internal static OdPdfPublish_Text_StandardFontsType _0023_003DzkzBsNEVGRvhlwydz7g_003D_003D(Write3DPDF.standardFontsType _0023_003Dz79KTAug_003D)
	{
		return _0023_003Dz79KTAug_003D switch
		{
			Write3DPDF.standardFontsType.TimesRoman => OdPdfPublish_Text_StandardFontsType.kTimesRoman, 
			Write3DPDF.standardFontsType.Helvetica => OdPdfPublish_Text_StandardFontsType.kHelvetica, 
			Write3DPDF.standardFontsType.Courier => OdPdfPublish_Text_StandardFontsType.kCourier, 
			Write3DPDF.standardFontsType.Symbol => OdPdfPublish_Text_StandardFontsType.kSymbol, 
			Write3DPDF.standardFontsType.TimesBold => OdPdfPublish_Text_StandardFontsType.kTimesBold, 
			Write3DPDF.standardFontsType.HelveticaBold => OdPdfPublish_Text_StandardFontsType.kHelveticaBold, 
			Write3DPDF.standardFontsType.CourierBold => OdPdfPublish_Text_StandardFontsType.kCourierBold, 
			Write3DPDF.standardFontsType.ZapfDingbats => OdPdfPublish_Text_StandardFontsType.kZapfDingbats, 
			Write3DPDF.standardFontsType.TimesItalic => OdPdfPublish_Text_StandardFontsType.kTimesItalic, 
			Write3DPDF.standardFontsType.HelveticaOblique => OdPdfPublish_Text_StandardFontsType.kHelveticaOblique, 
			Write3DPDF.standardFontsType.CourierOblique => OdPdfPublish_Text_StandardFontsType.kCourierOblique, 
			Write3DPDF.standardFontsType.TimesBoldItalic => OdPdfPublish_Text_StandardFontsType.kTimesBoldItalic, 
			Write3DPDF.standardFontsType.HelveticaBoldOblique => OdPdfPublish_Text_StandardFontsType.kHelveticaBoldOblique, 
			Write3DPDF.standardFontsType.CourierBoldOblique => OdPdfPublish_Text_StandardFontsType.kCourierBoldOblique, 
			_ => OdPdfPublish_Text_StandardFontsType.kTimesRoman, 
		};
	}

	internal static uint _0023_003DzjqETceR7vIUU(Color _0023_003DzJBUBFWA_003D)
	{
		return (uint)(((_0023_003DzJBUBFWA_003D.A << 24) | (_0023_003DzJBUBFWA_003D.B << 16) | (_0023_003DzJBUBFWA_003D.G << 8) | _0023_003DzJBUBFWA_003D.R) & 0xFFFFFFFFu);
	}
}
