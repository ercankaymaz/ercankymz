using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using ODA.Prc.OdPrcModule;
using ODA.Publish.PdfPublish;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class Write3DPDF : WriteDatabase
{
	public enum renderMode
	{
		Default,
		Solid,
		SolidWireframe,
		SolidOutline,
		BoundingBox,
		Transparent,
		TransparentWireframe,
		TransparentBoundingBox,
		TransparentBoundingBoxOutline,
		Illustration,
		ShadedIllustration,
		Wireframe,
		ShadedWireframe,
		HiddenWireframe,
		Vertices,
		ShadedVertices
	}

	public enum standardFontsType
	{
		TimesRoman,
		Helvetica,
		Courier,
		Symbol,
		TimesBold,
		HelveticaBold,
		CourierBold,
		ZapfDingbats,
		TimesItalic,
		HelveticaOblique,
		CourierOblique,
		TimesBoldItalic,
		HelveticaBoldOblique,
		CourierBoldOblique
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzTDedq_3ZtjtKptAdFWaOdjQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Rectangle _0023_003DzuJdKoiuzNuZxuxNcPS_dhIU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dz2XlLmdeXwOiqKk8beDXebobc_lOB;

	protected bool transparentBackground;

	protected int borderWidth;

	protected renderMode renderingMode;

	protected bool toolbarVisibility;

	protected bool modelTreeVisibility;

	protected string javaScript;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OdPdfPublish_OdDocument _0023_003DzJdH8xssMTzlu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OdStreamBuf _0023_003DzZ1m4TPg6sQDZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OdGeExtents3d _0023_003DzupkmNcwZ0KZs;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<OdPdfPublish_OdPage> _0023_003Dzc_00243h2W0_003D = new List<OdPdfPublish_OdPage>();

	protected Size paperSize
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTDedq_3ZtjtKptAdFWaOdjQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzTDedq_3ZtjtKptAdFWaOdjQ_003D = value;
		}
	}

	protected Rectangle viewRect
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzuJdKoiuzNuZxuxNcPS_dhIU_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzuJdKoiuzNuZxuxNcPS_dhIU_003D = value;
		}
	}

	protected Color backGroundColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz2XlLmdeXwOiqKk8beDXebobc_lOB;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz2XlLmdeXwOiqKk8beDXebobc_lOB = value;
		}
	}

	public Write3DPDF(Write3DPdfParams writeParams, string filePath)
		: base(writeParams, filePath)
	{
		_0023_003DzqNFgFJPR60_B(writeParams);
	}

	public Write3DPDF(Write3DPdfParams writeParams, Stream stream)
		: base(writeParams, stream)
	{
		_0023_003DzqNFgFJPR60_B(writeParams);
	}

	private void _0023_003DzqNFgFJPR60_B(Write3DPdfParams _0023_003DzPE_0024Wv_0024xbODq9)
	{
		paperSize = _0023_003DzPE_0024Wv_0024xbODq9.PaperSize;
		viewRect = _0023_003DzPE_0024Wv_0024xbODq9.ViewRect;
		backGroundColor = _0023_003DzPE_0024Wv_0024xbODq9.BackGroundColor;
		transparentBackground = _0023_003DzPE_0024Wv_0024xbODq9.TransparentBackground;
		borderWidth = _0023_003DzPE_0024Wv_0024xbODq9.ViewBorderWidth;
		renderingMode = _0023_003DzPE_0024Wv_0024xbODq9.RenderMode;
		toolbarVisibility = _0023_003DzPE_0024Wv_0024xbODq9.ToolbarVisibility;
		modelTreeVisibility = _0023_003DzPE_0024Wv_0024xbODq9.ModelTreeVisibility;
		javaScript = _0023_003DzPE_0024Wv_0024xbODq9.JavaScript;
		saveGeometry = _0023_003DzPE_0024Wv_0024xbODq9.SaveGeometry;
		aciColors = false;
	}

	private static void _0023_003Dze9ZcOBNgIydX(OdGeBoundBlock3d _0023_003DzAUdlYedTL0ya, IViewport _0023_003Dzl6kX9CI_003D, out OdGePoint3d _0023_003DzicL7YNxZORWZ, out OdGePoint3d _0023_003DzHLo3KEMAC8Tq, out OdGeVector3d _0023_003DzoER1DbPDwQWJ, out OdPdfPublish_Camera_Projection _0023_003DzU4u8BTk_003D, out double _0023_003DztcBx5wY_003D, out double _0023_003DzJU20Pp4_003D, out double _0023_003DzjXqsbbho2mf8, out double _0023_003DzuqRwuzQ_003D)
	{
		if (_0023_003Dzl6kX9CI_003D == null)
		{
			_0023_003DzU4u8BTk_003D = OdPdfPublish_Camera_Projection.kOrthographic;
			_0023_003DzuqRwuzQ_003D = 0.8;
			_0023_003DzjXqsbbho2mf8 = 0.0;
			_0023_003DzicL7YNxZORWZ = new OdGePoint3d(-0.9061268174850141, -0.3753290882162658, 0.1950955308899371);
			_0023_003DzHLo3KEMAC8Tq = OdGePoint3d.kOrigin;
			_0023_003DzoER1DbPDwQWJ = new OdGeVector3d(0.1802448331954261, 0.07465966969910483, 0.9807842442794306);
		}
		else
		{
			Camera camera = _0023_003Dzl6kX9CI_003D.Camera;
			_0023_003DzU4u8BTk_003D = ((camera.ProjectionMode == projectionType.Perspective) ? OdPdfPublish_Camera_Projection.kPerspective : OdPdfPublish_Camera_Projection.kOrthographic);
			_0023_003DzuqRwuzQ_003D = camera.ZoomFactor;
			_0023_003DzjXqsbbho2mf8 = 0.0;
			camera.GetFrame(out var origin, out var _, out var camY, out var _);
			_0023_003DzicL7YNxZORWZ = _0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzbhysZL9VFmRcYmsohA_003D_003D(origin);
			_0023_003DzHLo3KEMAC8Tq = _0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzbhysZL9VFmRcYmsohA_003D_003D(camera.Target);
			_0023_003DzoER1DbPDwQWJ = _0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(camY);
		}
		_0023_003DzP0swCxEqiM2e(_0023_003DzAUdlYedTL0ya, ref _0023_003DzicL7YNxZORWZ, ref _0023_003DzHLo3KEMAC8Tq, ref _0023_003DzoER1DbPDwQWJ, _0023_003DzU4u8BTk_003D, out _0023_003DztcBx5wY_003D, out _0023_003DzJU20Pp4_003D);
	}

	private static void _0023_003DzP0swCxEqiM2e(OdGeBoundBlock3d _0023_003DzAUdlYedTL0ya, ref OdGePoint3d _0023_003DzicL7YNxZORWZ, ref OdGePoint3d _0023_003DzHLo3KEMAC8Tq, ref OdGeVector3d _0023_003DzoER1DbPDwQWJ, OdPdfPublish_Camera_Projection _0023_003DzU4u8BTk_003D, out double _0023_003DztcBx5wY_003D, out double _0023_003DzJU20Pp4_003D)
	{
		if (_0023_003DzU4u8BTk_003D != OdPdfPublish_Camera_Projection.kPerspective && !_0023_003DzAUdlYedTL0ya.isBox())
		{
			_0023_003DzAUdlYedTL0ya.setToBox(toBox: true);
		}
		OdGePoint3d odGePoint3d = _0023_003DzAUdlYedTL0ya.center();
		OdGeVector3d odGeVector3d = _0023_003DzicL7YNxZORWZ - _0023_003DzHLo3KEMAC8Tq;
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		OdGeVector3d odGeVector3d2 = _0023_003DzoER1DbPDwQWJ;
		odGeVector3d2.normalize();
		OdGeVector3d odGeVector3d3 = (_0023_003DzicL7YNxZORWZ - _0023_003DzHLo3KEMAC8Tq).normalize();
		OdGeVector3d xAxis = odGeVector3d2.crossProduct(odGeVector3d3);
		odGeMatrix3d.setCoordSystem(odGePoint3d, xAxis, odGeVector3d2, odGeVector3d3);
		_0023_003DzAUdlYedTL0ya.transformBy(odGeMatrix3d);
		OdGePoint3d odGePoint3d2 = _0023_003DzAUdlYedTL0ya.minPoint();
		OdGePoint3d odGePoint3d3 = _0023_003DzAUdlYedTL0ya.maxPoint();
		double num = 0.0;
		if (_0023_003DzU4u8BTk_003D == OdPdfPublish_Camera_Projection.kPerspective)
		{
			OdGePoint3d odGePoint3d4 = odGePoint3d;
			OdGeVector3d odGeVector3d4 = _0023_003DzoER1DbPDwQWJ.normal();
			OdGeVector3d vect = (_0023_003DzicL7YNxZORWZ - _0023_003DzHLo3KEMAC8Tq).normalize();
			OdGeVector3d vect2 = odGeVector3d4.crossProduct(vect);
			OdGeVector3d odGeVector3d5 = new OdGeVector3d(odGePoint3d3.x - odGePoint3d2.x, 0.0, 0.0);
			OdGeVector3d odGeVector3d6 = new OdGeVector3d(0.0, odGePoint3d3.y - odGePoint3d2.y, 0.0);
			OdGeVector3d odGeVector3d7 = new OdGeVector3d(0.0, 0.0, odGePoint3d3.z - odGePoint3d2.z);
			OdGePoint3d[] array = new OdGePoint3d[8]
			{
				odGePoint3d2,
				odGePoint3d2 + odGeVector3d5,
				odGePoint3d2 + odGeVector3d6,
				odGePoint3d2 + odGeVector3d7,
				odGePoint3d3,
				odGePoint3d3 - odGeVector3d5,
				odGePoint3d3 - odGeVector3d6,
				odGePoint3d3 - odGeVector3d7
			};
			OdGeExtents2d odGeExtents2d = new OdGeExtents2d();
			for (int i = 0; i < 8; i++)
			{
				odGeExtents2d.addPoint(new OdGePoint2d((array[i] - odGePoint3d4).dotProduct(vect2), (array[i] - odGePoint3d4).dotProduct(odGeVector3d4)));
			}
			_ = odGeExtents2d.minPoint() + odGeExtents2d.maxPoint().Sub(odGeExtents2d.minPoint()).Mul(0.5);
			_0023_003DztcBx5wY_003D = 2.0 * (odGeExtents2d.maxPoint().x - odGeExtents2d.minPoint().x);
			_0023_003DzJU20Pp4_003D = 2.0 * (odGeExtents2d.maxPoint().y - odGeExtents2d.minPoint().y);
			num = Math.Max(_0023_003DztcBx5wY_003D / 2.0, _0023_003DzJU20Pp4_003D / 2.0) / Math.Tan(Math.PI / 6.0);
		}
		else
		{
			_0023_003DztcBx5wY_003D = Math.Abs(odGePoint3d3.x - odGePoint3d2.x);
			_0023_003DzJU20Pp4_003D = Math.Abs(odGePoint3d3.y - odGePoint3d2.y);
			num = odGePoint3d.distanceTo(_0023_003DzAUdlYedTL0ya.maxPoint());
		}
		odGeVector3d *= num;
		_0023_003DzicL7YNxZORWZ = odGePoint3d + odGeVector3d;
		_0023_003DzHLo3KEMAC8Tq = odGePoint3d;
	}

	protected override void WriteFile(OdDbDatabase pDb)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		_0023_003DzrEK3CUvFSVRj(pDb);
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003DzrEK3CUvFSVRj(OdDbDatabase _0023_003DzR8GRspk_003D)
	{
		_0023_003DzZ1m4TPg6sQDZ = _0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D._0023_003Dz_P5boncdw1JJ(_0023_003DzR8GRspk_003D, log);
		if (_0023_003DzZ1m4TPg6sQDZ == null)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517444));
		}
		TD_RootIntegrated_Globals.odrxDynamicLinker().loadApp(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517556), silent: false);
		if (TD_RootIntegrated_Globals.odrxDynamicLinker().loadApp(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517950)) == null)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517509));
		}
		OdPrcHostAppServices odPrcHostAppServices = new OdPrcHostAppServices();
		OdPrcFile pPRCFile = odPrcHostAppServices.readFile(_0023_003DzZ1m4TPg6sQDZ);
		_0023_003DzupkmNcwZ0KZs = OdPrcModule_Globals.OdPrcExtentsCalculator_calculateExtents(pPRCFile);
		if (!_0023_003DzupkmNcwZ0KZs.isValidExtents())
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517603));
		}
		OdPdfPublish_OdFile odPdfPublish_OdFile = OdPdfPublish_OdFile.createObject();
		if (odPdfPublish_OdFile == null)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517570));
		}
		_0023_003DzGMYc12E_003D(odPrcHostAppServices);
		if (base.Stream != null)
		{
			OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
			OdResult odResult = (OdResult)odPdfPublish_OdFile.exportPdf(_0023_003DzJdH8xssMTzlu, odMemoryStream);
			if (odResult != OdResult.eOk)
			{
				odMemoryStream.Dispose();
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517673) + odResult);
			}
			int num = (int)odMemoryStream.length();
			OdUInt8Array odUInt8Array = new OdUInt8Array(num);
			odMemoryStream.getBytesByNum(odUInt8Array, 0uL, (uint)num);
			base.Stream.Write(odUInt8Array.ToArray(), 0, num);
		}
		else
		{
			if (!string.Equals(Path.GetExtension(base.FilePath), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517691), StringComparison.InvariantCultureIgnoreCase))
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527533));
			}
			OdResult odResult2 = (OdResult)odPdfPublish_OdFile.exportPdf(_0023_003DzJdH8xssMTzlu, base.FilePath);
			if (odResult2 != OdResult.eOk)
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517646) + base.FilePath + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517656) + odResult2);
			}
		}
	}

	private void _0023_003DzGMYc12E_003D(OdPrcHostAppServices _0023_003DzBwRHPGM_003D)
	{
		_0023_003DzJdH8xssMTzlu = OdPdfPublish_OdDocument.createObject();
		_0023_003DzJdH8xssMTzlu.setHostServices(_0023_003DzBwRHPGM_003D);
		_0023_003DzJdH8xssMTzlu.setInformation(string.Empty, author, string.Empty, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518248));
		BuildDocument();
	}

	protected virtual void BuildDocument()
	{
		int pageIndex = AddPage(paperSize.Width, paperSize.Height);
		AddDesign(pageIndex, viewRect, backGroundColor, transparentBackground, borderWidth, renderingMode, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518232), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355518232), toolbarVisibility, modelTreeVisibility);
	}

	protected int AddPage(double width, double height)
	{
		OdPdfPublish_OdPage odPdfPublish_OdPage = OdPdfPublish_OdPage.createObject();
		odPdfPublish_OdPage.setOrientation(OdPdfPublish_Page_Orientation.kPortrait);
		odPdfPublish_OdPage.setPaperSize(OdPdfPublish_Page_PaperUnits.kPixels, width, height);
		_0023_003DzJdH8xssMTzlu.addPage(odPdfPublish_OdPage);
		_0023_003Dzc_00243h2W0_003D.Add(odPdfPublish_OdPage);
		return _0023_003Dzc_00243h2W0_003D.Count - 1;
	}

	[Obsolete]
	protected void AddDesign(int pageIndex, Rectangle viewRectangle, Color bkgColor, bool transparentBkg, int borderW, bool toolbarVis, renderMode renderMode, string externalName, string internalName)
	{
		AddDesign(pageIndex, viewRectangle, bkgColor, transparentBkg, borderW, renderMode, externalName, internalName, toolbarVis, modelTreeVis: false);
	}

	protected void AddDesign(int pageIndex, Rectangle viewRectangle, Color bkgColor, bool transparentBkg, int borderW, renderMode renderMode, string externalName, string internalName, bool toolbarVis, bool modelTreeVis)
	{
		OdPdfPublish_OdCADModel odPdfPublish_OdCADModel = OdPdfPublish_OdCADModel.createObject();
		odPdfPublish_OdCADModel.setSource(_0023_003DzZ1m4TPg6sQDZ);
		OdPdfPublish_OdAnnotation odPdfPublish_OdAnnotation = OdPdfPublish_OdAnnotation.createObject();
		odPdfPublish_OdAnnotation.setSource(odPdfPublish_OdCADModel);
		odPdfPublish_OdAnnotation.setTransparentBackground(transparentBkg);
		odPdfPublish_OdAnnotation.setBorderWidth((ushort)borderW);
		odPdfPublish_OdAnnotation.setToolbarVisibility(toolbarVis);
		odPdfPublish_OdAnnotation.setModelTreeVisibility(modelTreeVis);
		OdGsDCRect location = new OdGsDCRect(viewRectangle.X, viewRectangle.X + viewRectangle.Width, viewRectangle.Y, viewRectangle.Y + viewRectangle.Height);
		_0023_003Dzc_00243h2W0_003D[pageIndex].addAnnotation(odPdfPublish_OdAnnotation, location);
		OdPdfPublish_OdArtwork odPdfPublish_OdArtwork = OdPdfPublish_OdArtwork.createObject();
		_0023_003DzvGl6HUo_003D(odPdfPublish_OdArtwork, externalName, internalName, _0023_003DzupkmNcwZ0KZs, _0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D._0023_003DzFQTHtoywbw5wDdGm5A_003D_003D(renderMode), OdPdfPublish_Lighting_Mode.kCADOptimized, _0023_003DzmvQSiy0_003D: true, bkgColor);
		if (!string.IsNullOrEmpty(javaScript))
		{
			odPdfPublish_OdArtwork.setJavaScript(javaScript);
		}
		odPdfPublish_OdAnnotation.setArtwork(odPdfPublish_OdArtwork);
	}

	protected void AddFrame(int pageIndex, Point2D bottomLeft, Point2D topRight, Color color, double thickness = 2.0)
	{
		OdPdfPublish_Od2dGeometryBlock odPdfPublish_Od2dGeometryBlock = OdPdfPublish_Od2dGeometryBlock.createObject();
		odPdfPublish_Od2dGeometryBlock.setOrigin(new OdGePoint2d(0.0, 0.0));
		odPdfPublish_Od2dGeometryBlock.putLineWeight(thickness);
		odPdfPublish_Od2dGeometryBlock.putColor(_0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D._0023_003DzjqETceR7vIUU(color));
		OdGePoint2dArray odGePoint2dArray = new OdGePoint2dArray();
		odGePoint2dArray.Add(new OdGePoint2d(bottomLeft.X, bottomLeft.Y));
		odGePoint2dArray.Add(new OdGePoint2d(bottomLeft.X, topRight.Y));
		odGePoint2dArray.Add(new OdGePoint2d(topRight.X, topRight.Y));
		odGePoint2dArray.Add(new OdGePoint2d(topRight.X, bottomLeft.Y));
		odGePoint2dArray.Add(new OdGePoint2d(bottomLeft.X, bottomLeft.Y));
		odPdfPublish_Od2dGeometryBlock.addLine(odGePoint2dArray);
		OdPdfPublish_Od2dGeometryReference odPdfPublish_Od2dGeometryReference = OdPdfPublish_Od2dGeometryReference.createObject();
		odPdfPublish_Od2dGeometryReference.setGeometryBlock(odPdfPublish_Od2dGeometryBlock);
		_0023_003Dzc_00243h2W0_003D[pageIndex].add2dGeometry(odPdfPublish_Od2dGeometryReference);
	}

	protected void AddLine(int pageIndex, Point2D startPoint, Point2D endPoint, Color color, double thickness = 2.0)
	{
		OdPdfPublish_Od2dGeometryBlock odPdfPublish_Od2dGeometryBlock = OdPdfPublish_Od2dGeometryBlock.createObject();
		odPdfPublish_Od2dGeometryBlock.setOrigin(new OdGePoint2d(0.0, 0.0));
		odPdfPublish_Od2dGeometryBlock.putLineWeight(thickness);
		odPdfPublish_Od2dGeometryBlock.putColor(_0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D._0023_003DzjqETceR7vIUU(color));
		OdGePoint2dArray odGePoint2dArray = new OdGePoint2dArray();
		odGePoint2dArray.Add(new OdGePoint2d(startPoint.X, startPoint.Y));
		odGePoint2dArray.Add(new OdGePoint2d(endPoint.X, endPoint.Y));
		odPdfPublish_Od2dGeometryBlock.addLine(odGePoint2dArray);
		OdPdfPublish_Od2dGeometryReference odPdfPublish_Od2dGeometryReference = OdPdfPublish_Od2dGeometryReference.createObject();
		odPdfPublish_Od2dGeometryReference.setGeometryBlock(odPdfPublish_Od2dGeometryBlock);
		_0023_003Dzc_00243h2W0_003D[pageIndex].add2dGeometry(odPdfPublish_Od2dGeometryReference);
	}

	protected void AddText(int pageIndex, string textString, Rectangle boundingRect, Color color, string fontName, int fontSize = 10, double rotation = 0.0)
	{
		_0023_003DzQZqhLpg8IZVZ(pageIndex, textString, boundingRect, color, fontSize, rotation, fontName, standardFontsType.TimesRoman);
	}

	protected void AddText(int pageIndex, string textString, Rectangle boundingRect, Color color, standardFontsType fontType = standardFontsType.TimesRoman, int fontSize = 10, double rotation = 0.0)
	{
		_0023_003DzQZqhLpg8IZVZ(pageIndex, textString, boundingRect, color, fontSize, rotation, null, fontType);
	}

	private void _0023_003DzQZqhLpg8IZVZ(int _0023_003DzItE8JWM_003D, string _0023_003DznhuxS9c_003D, Rectangle _0023_003DzwpUopQ_0024vJD1K, Color _0023_003DzJBUBFWA_003D, int _0023_003DzbfXFbYs_003D, double _0023_003DzAYx9Z5A_003D, string _0023_003DzL8Hxpzo_003D, standardFontsType _0023_003Dz79KTAug_003D)
	{
		OdPdfPublish_OdText odPdfPublish_OdText = OdPdfPublish_OdText.createObject();
		odPdfPublish_OdText.setSize((ushort)_0023_003DzbfXFbYs_003D);
		odPdfPublish_OdText.setColor(_0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D._0023_003DzjqETceR7vIUU(_0023_003DzJBUBFWA_003D));
		odPdfPublish_OdText.setText(_0023_003DznhuxS9c_003D);
		if (!string.IsNullOrEmpty(_0023_003DzL8Hxpzo_003D))
		{
			odPdfPublish_OdText.setFont(_0023_003DzL8Hxpzo_003D, OdPdfPublish_Text_FontStyle.kRegular);
		}
		else
		{
			odPdfPublish_OdText.setFont(_0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D._0023_003DzkzBsNEVGRvhlwydz7g_003D_003D(_0023_003Dz79KTAug_003D));
		}
		_0023_003Dzc_00243h2W0_003D[_0023_003DzItE8JWM_003D].addText(odPdfPublish_OdText, new OdGsDCRect(_0023_003DzwpUopQ_0024vJD1K.Left, _0023_003DzwpUopQ_0024vJD1K.Right, _0023_003DzwpUopQ_0024vJD1K.Top, _0023_003DzwpUopQ_0024vJD1K.Bottom), _0023_003DzAYx9Z5A_003D);
	}

	protected void AddImage(int pageIndex, Image image, Rectangle boundingRect, double rotation = 0.0)
	{
		string tempFileName = Path.GetTempFileName();
		image.Save(tempFileName);
		OdPdfPublish_OdImage odPdfPublish_OdImage = OdPdfPublish_OdImage.createObject();
		odPdfPublish_OdImage.setFile(tempFileName);
		OdGsDCRect location = new OdGsDCRect(boundingRect.Left, boundingRect.Right, boundingRect.Top, boundingRect.Bottom);
		_0023_003Dzc_00243h2W0_003D[pageIndex].addImage(odPdfPublish_OdImage, location, rotation);
		File.Delete(tempFileName);
	}

	private void _0023_003DzvGl6HUo_003D(OdPdfPublish_OdArtwork _0023_003DzB2gTJNkbMmKtvCj_0024zg_003D_003D, string _0023_003Dzbor6tYo_003D, string _0023_003DzFffjQ7g_003D, OdGeExtents3d _0023_003DzX68MDSWERAFX, OdPdfPublish_Rendering_Mode _0023_003Dzfm3laNc_003D, OdPdfPublish_Lighting_Mode _0023_003Dz_0024E0u__0024I_003D, bool _0023_003DzmvQSiy0_003D, Color _0023_003Dz6ggAdckA81_X)
	{
		_0023_003Dze9ZcOBNgIydX(new OdGeBoundBlock3d(_0023_003DzX68MDSWERAFX.minPoint(), _0023_003DzX68MDSWERAFX.maxPoint()), viewport, out var _0023_003DzicL7YNxZORWZ, out var _0023_003DzHLo3KEMAC8Tq, out var _0023_003DzoER1DbPDwQWJ, out var _0023_003DzU4u8BTk_003D, out var _0023_003DztcBx5wY_003D, out var _0023_003DzJU20Pp4_003D, out var _0023_003DzjXqsbbho2mf, out var _0023_003DzuqRwuzQ_003D);
		OdPdfPublish_OdCamera odPdfPublish_OdCamera = OdPdfPublish_OdCamera.createObject();
		odPdfPublish_OdCamera.setPosition(_0023_003DzicL7YNxZORWZ);
		odPdfPublish_OdCamera.setTarget(_0023_003DzHLo3KEMAC8Tq);
		odPdfPublish_OdCamera.setUpVector(_0023_003DzoER1DbPDwQWJ);
		odPdfPublish_OdCamera.setField(_0023_003DztcBx5wY_003D, _0023_003DzJU20Pp4_003D);
		odPdfPublish_OdCamera.setProjection(_0023_003DzU4u8BTk_003D);
		odPdfPublish_OdCamera.zoom(_0023_003DzuqRwuzQ_003D);
		if (_0023_003DzjXqsbbho2mf > 0.0)
		{
			odPdfPublish_OdCamera.roll(_0023_003DzjXqsbbho2mf);
		}
		OdPdfPublish_OdView odPdfPublish_OdView = OdPdfPublish_OdView.createObject();
		odPdfPublish_OdView.setCamera(odPdfPublish_OdCamera);
		odPdfPublish_OdView.setExternalName(_0023_003Dzbor6tYo_003D);
		odPdfPublish_OdView.setInternalName(_0023_003DzFffjQ7g_003D);
		odPdfPublish_OdView.setDefault(_0023_003DzmvQSiy0_003D);
		odPdfPublish_OdView.setBackgroundColor(_0023_003DzcpOi08oBX3Ee2bUuQGcv7BTfDKgJjg8oErd9b8y_yFERdKaJOEts0dA_003D._0023_003DzjqETceR7vIUU(_0023_003Dz6ggAdckA81_X));
		odPdfPublish_OdView.setLighting(_0023_003Dz_0024E0u__0024I_003D);
		odPdfPublish_OdView.setRendering(_0023_003Dzfm3laNc_003D);
		_0023_003DzB2gTJNkbMmKtvCj_0024zg_003D_003D.addView(odPdfPublish_OdView);
	}
}
