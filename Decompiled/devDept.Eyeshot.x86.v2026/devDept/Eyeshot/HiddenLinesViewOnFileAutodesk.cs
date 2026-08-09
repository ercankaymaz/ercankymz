using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class HiddenLinesViewOnFileAutodesk : HiddenLinesView
{
	public string FilePath;

	public float Scale;

	public autodeskVersionType Version;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private linearUnitsType _0023_003Dz3CRc0yI_003D = linearUnitsType.Millimeters;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private lineWeightUnitsType _0023_003DzfWqqg1uc9Gop = lineWeightUnitsType.Millimeters;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzPsRIoAMv9gF55LoKySYFquc_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzCGlwdRrPyP6i = Color.White;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzCETKaMiCj7jI6dHnfNNWEiKuzjFuC_OBLQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003Dz7AwrB_dlOoPv57MVJm4N8B4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzwCVlOY_VtID3rdlRcbDOrUo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzvN7rnwSRxpA4AemtZ_0cYcKt5m5LePNX2g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003Dz6sBFZQ2SlMEhCm__002416pQhUE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Pen _0023_003DzYyQDCVOmDVTtbnID6bxeAtE_003D;

	public linearUnitsType Units
	{
		get
		{
			return _0023_003Dz3CRc0yI_003D;
		}
		set
		{
			_0023_003Dz3CRc0yI_003D = value;
		}
	}

	public lineWeightUnitsType LineWeightUnits
	{
		get
		{
			return _0023_003DzfWqqg1uc9Gop;
		}
		set
		{
			_0023_003DzfWqqg1uc9Gop = value;
		}
	}

	public bool AciColors
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPsRIoAMv9gF55LoKySYFquc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzPsRIoAMv9gF55LoKySYFquc_003D = value;
		}
	}

	public Color ForegroundColor
	{
		get
		{
			return _0023_003DzCGlwdRrPyP6i;
		}
		set
		{
			if (value.ToArgb() != Color.White.ToArgb() && value.ToArgb() != Color.Black.ToArgb())
			{
				throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526864));
			}
			_0023_003DzCGlwdRrPyP6i = value;
		}
	}

	public Pen PenSilhouette
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCETKaMiCj7jI6dHnfNNWEiKuzjFuC_OBLQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzCETKaMiCj7jI6dHnfNNWEiKuzjFuC_OBLQ_003D_003D = value;
		}
	}

	public Pen PenEdge
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz7AwrB_dlOoPv57MVJm4N8B4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz7AwrB_dlOoPv57MVJm4N8B4_003D = value;
		}
	}

	public Pen PenWire
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzwCVlOY_VtID3rdlRcbDOrUo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzwCVlOY_VtID3rdlRcbDOrUo_003D = value;
		}
	}

	public Pen PenHiddenSilhouette
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvN7rnwSRxpA4AemtZ_0cYcKt5m5LePNX2g_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzvN7rnwSRxpA4AemtZ_0cYcKt5m5LePNX2g_003D_003D = value;
		}
	}

	public Pen PenHiddenEdge
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz6sBFZQ2SlMEhCm__002416pQhUE_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz6sBFZQ2SlMEhCm__002416pQhUE_003D = value;
		}
	}

	public Pen PenHiddenWire
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYyQDCVOmDVTtbnID6bxeAtE_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzYyQDCVOmDVTtbnID6bxeAtE_003D = value;
		}
	}

	public HiddenLinesViewOnFileAutodesk(HiddenLinesViewSettings viewSettings, string filePath, autodeskVersionType version, bool aciColors = true)
		: this(viewSettings, filePath, version, 1.0, aciColors)
	{
	}

	public HiddenLinesViewOnFileAutodesk(HiddenLinesViewSettings viewSettings, string filePath, autodeskVersionType version, double scale, bool aciColors = true)
		: this(viewSettings, filePath, version, scale, linearUnitsType.Millimeters, lineWeightUnitsType.Millimeters, aciColors)
	{
	}

	public HiddenLinesViewOnFileAutodesk(HiddenLinesViewSettings viewSettings, string filePath, autodeskVersionType version, double scale, linearUnitsType units = linearUnitsType.Millimeters, lineWeightUnitsType lineWeightUnits = lineWeightUnitsType.Millimeters, bool aciColors = true)
		: base(viewSettings, forceTextsAsTriangles: true)
	{
		Scale = (float)scale;
		Version = version;
		FilePath = filePath;
		Units = units;
		LineWeightUnits = lineWeightUnits;
		AciColors = aciColors;
		_0023_003DzycPk48wMgTwi();
	}

	private void _0023_003DzycPk48wMgTwi()
	{
		if (PenSilhouette == null)
		{
			PenSilhouette = new Pen(Color.Black, 3f);
		}
		if (PenEdge == null)
		{
			PenEdge = new Pen(Color.Black, 1f);
		}
		if (PenWire == null)
		{
			PenWire = new Pen(Color.Black, 1f);
		}
		if (PenHiddenSilhouette == null)
		{
			PenHiddenSilhouette = new Pen(Color.LightGray, 3f);
		}
		if (PenHiddenEdge == null)
		{
			PenHiddenEdge = new Pen(Color.LightGray, 1f);
		}
		if (PenHiddenWire == null)
		{
			PenHiddenWire = new Pen(Color.LightGray, 1f);
		}
	}

	public override void WorkCompleted(object source)
	{
		_0023_003DzLnLXrn_6XxxZp534uQ_003D_003D();
	}

	private void _0023_003DzLnLXrn_6XxxZp534uQ_003D_003D()
	{
		string extension = Path.GetExtension(FilePath);
		if (!string.Equals(extension, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527427), StringComparison.InvariantCultureIgnoreCase) && !string.Equals(extension, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527446), StringComparison.InvariantCultureIgnoreCase))
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527533));
		}
		MemoryTransaction memoryTransaction = MemoryManager.GetMemoryManager().StartTransaction();
		try
		{
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzSothfIG2mlbP();
			ScaleLinesToWorld(Scale);
			ScaleTrianglesToWorld(Scale);
			Autodesk.InitializeServices();
			ExHostAppServices exHostAppServices = new ExHostAppServices();
			memoryTransaction.AddObject(exHostAppServices);
			exHostAppServices.disableOutput(disable: true);
			OdDbDatabase odDbDatabase = exHostAppServices.createDatabase(createDefault: true);
			odDbDatabase.setINSUNITS(WriteDatabase._0023_003DzC_A_00240jSUbYHi0SaUjw_003D_003D(Units));
			CreateAutodeskDatabase(odDbDatabase, AciColors, ForegroundColor);
			if (string.Equals(extension, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527427), StringComparison.InvariantCultureIgnoreCase))
			{
				odDbDatabase.writeFile(FilePath, OdDb_SaveType.kDwg, WriteAutodesk._0023_003DzzeXa96gAc7VcPZ2UkHEbJi0_003D(Version));
			}
			else
			{
				odDbDatabase.writeFile(FilePath, OdDb_SaveType.kDxf, WriteAutodesk._0023_003DzzeXa96gAc7VcPZ2UkHEbJi0_003D(Version), saveThumbnailImage: false, 16);
			}
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			throw new EyeshotException(ex.Message, ex);
		}
		finally
		{
			MemoryManager.GetMemoryManager().StopTransaction(memoryTransaction);
		}
	}

	protected void CreateAutodeskDatabase(OdDbDatabase pDb, bool aciColors, Color foregroundColor)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbObjectId _0023_003DzQ5TPDS0_003D = _0023_003Dzar02DN9N5uWb(pDb, PenSilhouette, aciColors, foregroundColor, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527496));
		OdDbObjectId _0023_003DzQ5TPDS0_003D2 = _0023_003Dzar02DN9N5uWb(pDb, PenEdge, aciColors, foregroundColor, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527510));
		OdDbObjectId _0023_003DzQ5TPDS0_003D3 = _0023_003Dzar02DN9N5uWb(pDb, PenWire, aciColors, foregroundColor, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527594));
		OdDbObjectId _0023_003DzQ5TPDS0_003D4 = OdDbObjectId.kNull;
		OdDbObjectId _0023_003DzQ5TPDS0_003D5 = OdDbObjectId.kNull;
		OdDbObjectId _0023_003DzQ5TPDS0_003D6 = OdDbObjectId.kNull;
		if (HdlViewSettings.KeepHiddenSegments)
		{
			_0023_003DzQ5TPDS0_003D4 = _0023_003Dzar02DN9N5uWb(pDb, PenHiddenSilhouette, aciColors, foregroundColor, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527614));
			_0023_003DzQ5TPDS0_003D5 = _0023_003Dzar02DN9N5uWb(pDb, PenHiddenEdge, aciColors, foregroundColor, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527558));
			_0023_003DzQ5TPDS0_003D6 = _0023_003Dzar02DN9N5uWb(pDb, PenHiddenWire, aciColors, foregroundColor, _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527572));
		}
		GetComputedLines(out var silho, out var edges, out var wires, out var hiddenSilho, out var hiddenEdges, out var hiddenWires, out var _, out var _, out var sections);
		OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv = (OdDbBlockTableRecord)pDb.getModelSpaceId().openObject(OdDb_OpenMode.kForWrite);
		if (HdlViewSettings.KeepHiddenSegments)
		{
			_0023_003Dzs4ikxGMCX7YFhIj_0024Mg_003D_003D(_0023_003Dz1EtocfNGByJv, hiddenSilho, _0023_003DzQ5TPDS0_003D4);
			_0023_003Dzs4ikxGMCX7YFhIj_0024Mg_003D_003D(_0023_003Dz1EtocfNGByJv, hiddenEdges, _0023_003DzQ5TPDS0_003D5);
			_0023_003Dzs4ikxGMCX7YFhIj_0024Mg_003D_003D(_0023_003Dz1EtocfNGByJv, hiddenWires, _0023_003DzQ5TPDS0_003D6);
		}
		_0023_003Dzs4ikxGMCX7YFhIj_0024Mg_003D_003D(_0023_003Dz1EtocfNGByJv, silho, _0023_003DzQ5TPDS0_003D);
		_0023_003Dzs4ikxGMCX7YFhIj_0024Mg_003D_003D(_0023_003Dz1EtocfNGByJv, edges, _0023_003DzQ5TPDS0_003D2);
		_0023_003Dzs4ikxGMCX7YFhIj_0024Mg_003D_003D(_0023_003Dz1EtocfNGByJv, wires, _0023_003DzQ5TPDS0_003D3);
		_0023_003Dz0ioyF66Uwbx1moYkkA_003D_003D(_0023_003Dz1EtocfNGByJv, wireAndTriangleDatas, _0023_003DzQ5TPDS0_003D3);
		_0023_003Dz8jI1OLl2QRVl(_0023_003Dz1EtocfNGByJv, sections, _0023_003DzQ5TPDS0_003D2);
		OdSecurityParams odSecurityParams = new OdSecurityParams();
		pDb.securityParams(odSecurityParams);
		odSecurityParams.password = null;
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private OdDbObjectId _0023_003Dzar02DN9N5uWb(OdDbDatabase _0023_003DzR8GRspk_003D, Pen _0023_003Dz3mFAKeM_003D, bool _0023_003Dz_sf9dBZZ1poK, Color _0023_003DzYh4eDvc_003D, string _0023_003Dz5io_M9_0024S7xvX)
	{
		WriteDatabase._0023_003DzIyc16os_003D(_0023_003DzR8GRspk_003D, _0023_003Dz5io_M9_0024S7xvX, string.Empty, _0023_003Dzg3EMp3qnmaQPMJD62rSY3Q4_003D(_0023_003Dz3mFAKeM_003D, Scale));
		return WriteDatabase._0023_003DzoErE2eM_003D(_0023_003DzR8GRspk_003D, _0023_003Dz5io_M9_0024S7xvX, _0023_003Dz3mFAKeM_003D.Color, _0023_003Dz6Y4jgDI_003D: true, _0023_003Dz5io_M9_0024S7xvX, _0023_003Dz3mFAKeM_003D.Width, _0023_003Dz_sf9dBZZ1poK, _0023_003DzYh4eDvc_003D, LineWeightUnits, OdDbObjectId.kNull, log, _0023_003DzCzVVavI_003D: false, null);
	}

	private float[] _0023_003Dzg3EMp3qnmaQPMJD62rSY3Q4_003D(Pen _0023_003Dz3mFAKeM_003D, float _0023_003DzQgGFpsY_003D)
	{
		if (_0023_003Dz3mFAKeM_003D.DashStyle == DashStyle.Solid)
		{
			return null;
		}
		float[] array = new float[_0023_003Dz3mFAKeM_003D.DashPattern.Length];
		float num = _0023_003DzQgGFpsY_003D;
		for (int i = 0; i < _0023_003Dz3mFAKeM_003D.DashPattern.Length; i++)
		{
			array[i] = _0023_003Dz3mFAKeM_003D.DashPattern[i] * num;
			num *= -1f;
		}
		return array;
	}

	private void _0023_003Dzs4ikxGMCX7YFhIj_0024Mg_003D_003D(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<HdlCurve> _0023_003DzMiCmVZLDYu69, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		if (_0023_003DzMiCmVZLDYu69 == null)
		{
			return;
		}
		if (HdlViewSettings.KeepEntityColor)
		{
			if (HdlViewSettings.KeepEntityLineWeight)
			{
				_0023_003Dzhem71Dd70zvxi9AYosNJci0_003D(_0023_003Dz1EtocfNGByJv, _0023_003DzMiCmVZLDYu69, _0023_003DzQ5TPDS0_003D);
			}
			else
			{
				_0023_003DzgavaSBTNiUiWjOgRzg_003D_003D(_0023_003Dz1EtocfNGByJv, _0023_003DzMiCmVZLDYu69, _0023_003DzQ5TPDS0_003D);
			}
		}
		else if (HdlViewSettings.KeepEntityLineWeight)
		{
			_0023_003DzXMmqsiiJEcAhKPJcyvpVag4_003D(_0023_003Dz1EtocfNGByJv, _0023_003DzMiCmVZLDYu69, _0023_003DzQ5TPDS0_003D);
		}
		else
		{
			_0023_003DzDb8EcEUCuja6R2un_0024A_003D_003D(_0023_003Dz1EtocfNGByJv, _0023_003DzMiCmVZLDYu69, _0023_003DzQ5TPDS0_003D);
		}
	}

	private void _0023_003Dz0ioyF66Uwbx1moYkkA_003D_003D(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<SilhoWireAndTriangleData> _0023_003DzbONi0CI_003D, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		if (_0023_003DzbONi0CI_003D != null)
		{
			if (HdlViewSettings.KeepEntityColor)
			{
				_0023_003DzhVMKUc6CxP1SfWo8FEvxjHc_003D(_0023_003Dz1EtocfNGByJv, _0023_003DzbONi0CI_003D, _0023_003DzQ5TPDS0_003D);
			}
			else
			{
				_0023_003Dzbfx8PcUQM9LbLBR7YNIl66I_003D(_0023_003Dz1EtocfNGByJv, _0023_003DzbONi0CI_003D, _0023_003DzQ5TPDS0_003D);
			}
		}
	}

	private void _0023_003Dz8jI1OLl2QRVl(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<HdlSection> _0023_003DzLXdR2Sk_003D, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		if (_0023_003DzLXdR2Sk_003D.Count <= 0)
		{
			return;
		}
		OdCmColor odCmColor = new OdCmColor(OdCmEntityColor_ColorMethod.kByLayer);
		odCmColor.setColorIndex(256);
		LineWeight lineWeight = LineWeight.kLnWtByLayer;
		foreach (HdlSection item in _0023_003DzLXdR2Sk_003D)
		{
			LineWeight _0023_003Dzq_ABCx2CTIN = (HdlViewSettings.KeepEntityLineWeight ? WriteDatabase._0023_003Dz6rzgaSHBY5QMk_0024oC226vguvdkkCP(item.Attributes.LineWeight, LineWeightUnits) : lineWeight);
			OdCmColor _0023_003DzJBUBFWA_003D = (HdlViewSettings.KeepEntityColor ? _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DztRLzArIqOrBK0lmTPw_003D_003D(item.Attributes.GetColor(), AciColors, ForegroundColor) : odCmColor);
			_0023_003DzuaK8J_EE647q(_0023_003Dz1EtocfNGByJv, _0023_003DzQ5TPDS0_003D, item, _0023_003DzJBUBFWA_003D, _0023_003Dzq_ABCx2CTIN);
		}
	}

	private void _0023_003DzXMmqsiiJEcAhKPJcyvpVag4_003D(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<HdlCurve> _0023_003DzMiCmVZLDYu69, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		OdCmColor odCmColor = new OdCmColor(OdCmEntityColor_ColorMethod.kByLayer);
		odCmColor.setColorIndex(256);
		foreach (HdlCurve item in _0023_003DzMiCmVZLDYu69)
		{
			LineWeight _0023_003Dzq_ABCx2CTIN = WriteDatabase._0023_003Dz6rzgaSHBY5QMk_0024oC226vguvdkkCP(item.Attributes.LineWeight, LineWeightUnits);
			_0023_003DzuaK8J_EE647q(_0023_003Dz1EtocfNGByJv, _0023_003DzQ5TPDS0_003D, item, odCmColor, _0023_003Dzq_ABCx2CTIN);
		}
	}

	private void _0023_003DzgavaSBTNiUiWjOgRzg_003D_003D(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<HdlCurve> _0023_003DzMiCmVZLDYu69, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		foreach (HdlCurve item in _0023_003DzMiCmVZLDYu69)
		{
			OdCmColor _0023_003DzJBUBFWA_003D = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DztRLzArIqOrBK0lmTPw_003D_003D(item.Attributes.GetColor(), AciColors, ForegroundColor);
			_0023_003DzuaK8J_EE647q(_0023_003Dz1EtocfNGByJv, _0023_003DzQ5TPDS0_003D, item, _0023_003DzJBUBFWA_003D, LineWeight.kLnWtByLayer);
		}
	}

	private void _0023_003DzhVMKUc6CxP1SfWo8FEvxjHc_003D(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<SilhoWireAndTriangleData> _0023_003DzbONi0CI_003D, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		foreach (SilhoWireAndTriangleData item in _0023_003DzbONi0CI_003D)
		{
			OdCmColor _0023_003DzJBUBFWA_003D = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DztRLzArIqOrBK0lmTPw_003D_003D(item.Attributes.GetColor(), AciColors, ForegroundColor);
			_0023_003Dzesq9Nu2ORvgD(_0023_003Dz1EtocfNGByJv, item, _0023_003DzQ5TPDS0_003D, _0023_003DzJBUBFWA_003D);
		}
	}

	private void _0023_003Dzbfx8PcUQM9LbLBR7YNIl66I_003D(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<SilhoWireAndTriangleData> _0023_003DzbONi0CI_003D, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		foreach (SilhoWireAndTriangleData item in _0023_003DzbONi0CI_003D)
		{
			OdCmColor odCmColor = new OdCmColor(OdCmEntityColor_ColorMethod.kByLayer);
			odCmColor.setColorIndex(256);
			_0023_003Dzesq9Nu2ORvgD(_0023_003Dz1EtocfNGByJv, item, _0023_003DzQ5TPDS0_003D, odCmColor);
		}
	}

	private static void _0023_003Dzesq9Nu2ORvgD(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, SilhoWireAndTriangleData _0023_003DzDOe3VCY_003D, OdDbObjectId _0023_003DzQ5TPDS0_003D, OdCmColor _0023_003DzJBUBFWA_003D)
	{
		int length = _0023_003DzDOe3VCY_003D.ScreenVertices.GetLength(0);
		if (length <= 32767)
		{
			_0023_003Dz0WggiinpD_0024YJ(_0023_003Dz1EtocfNGByJv, _0023_003DzDOe3VCY_003D, _0023_003DzQ5TPDS0_003D, _0023_003DzJBUBFWA_003D, 0, length);
			return;
		}
		int num = 32766;
		int num2 = (int)Math.Ceiling((double)length / (double)num);
		int num3 = 0;
		int num4 = 0;
		while (num4 < num2 - 1)
		{
			_0023_003Dz0WggiinpD_0024YJ(_0023_003Dz1EtocfNGByJv, _0023_003DzDOe3VCY_003D, _0023_003DzQ5TPDS0_003D, _0023_003DzJBUBFWA_003D, num3, num);
			num4++;
			num3 += num;
		}
		_0023_003Dz0WggiinpD_0024YJ(_0023_003Dz1EtocfNGByJv, _0023_003DzDOe3VCY_003D, _0023_003DzQ5TPDS0_003D, _0023_003DzJBUBFWA_003D, num3, length - num * (num2 - 1));
	}

	private static void _0023_003Dz0WggiinpD_0024YJ(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, SilhoWireAndTriangleData _0023_003DzbONi0CI_003D, OdDbObjectId _0023_003DzQ5TPDS0_003D, OdCmColor _0023_003DzJBUBFWA_003D, int _0023_003DzUbhs2Y1mlPne, int _0023_003Dzb5zhrbs_003D)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbPolyFaceMesh odDbPolyFaceMesh = OdDbPolyFaceMesh.createObject();
		int num = _0023_003DzUbhs2Y1mlPne + _0023_003Dzb5zhrbs_003D;
		for (int i = _0023_003DzUbhs2Y1mlPne; i < num; i++)
		{
			WriteDatabase._0023_003DzEPkG1wlgZgNuz2UqZQ_003D_003D(odDbPolyFaceMesh, _0023_003DzbONi0CI_003D.ScreenVertices[i, 0], _0023_003DzbONi0CI_003D.ScreenVertices[i, 1], 0.0);
		}
		for (int j = 1; j <= _0023_003Dzb5zhrbs_003D; j += 3)
		{
			WriteDatabase._0023_003Dz_MjyAqUwv7sF(odDbPolyFaceMesh, (short)j, (short)(j + 1), (short)(j + 2));
		}
		odDbPolyFaceMesh.setLayer(_0023_003DzQ5TPDS0_003D);
		odDbPolyFaceMesh.setColor(_0023_003DzJBUBFWA_003D);
		_0023_003Dz1EtocfNGByJv.appendOdDbEntity(odDbPolyFaceMesh);
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private void _0023_003Dzhem71Dd70zvxi9AYosNJci0_003D(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<HdlCurve> _0023_003DzMiCmVZLDYu69, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		foreach (HdlCurve item in _0023_003DzMiCmVZLDYu69)
		{
			OdCmColor _0023_003DzJBUBFWA_003D = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DztRLzArIqOrBK0lmTPw_003D_003D(item.Attributes.GetColor(), AciColors, ForegroundColor);
			LineWeight _0023_003Dzq_ABCx2CTIN = WriteDatabase._0023_003Dz6rzgaSHBY5QMk_0024oC226vguvdkkCP(item.Attributes.LineWeight, LineWeightUnits);
			_0023_003DzuaK8J_EE647q(_0023_003Dz1EtocfNGByJv, _0023_003DzQ5TPDS0_003D, item, _0023_003DzJBUBFWA_003D, _0023_003Dzq_ABCx2CTIN);
		}
	}

	private void _0023_003DzDb8EcEUCuja6R2un_0024A_003D_003D(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, IList<HdlCurve> _0023_003DzMiCmVZLDYu69, OdDbObjectId _0023_003DzQ5TPDS0_003D)
	{
		OdCmColor odCmColor = new OdCmColor(OdCmEntityColor_ColorMethod.kByLayer);
		odCmColor.setColorIndex(256);
		foreach (HdlCurve item in _0023_003DzMiCmVZLDYu69)
		{
			_0023_003DzuaK8J_EE647q(_0023_003Dz1EtocfNGByJv, _0023_003DzQ5TPDS0_003D, item, odCmColor, LineWeight.kLnWtByLayer);
		}
	}

	private void _0023_003DzuaK8J_EE647q(OdDbBlockTableRecord _0023_003Dz1EtocfNGByJv, OdDbObjectId _0023_003DzQ5TPDS0_003D, HdlResult _0023_003DzINDBoqS9DTqw, OdCmColor _0023_003DzJBUBFWA_003D, LineWeight _0023_003Dzq_ABCx2CTIN8)
	{
		MemoryTransaction value = MemoryManager.GetMemoryManager().StartTransaction();
		OdDbEntity odDbEntity = null;
		if (!(_0023_003DzINDBoqS9DTqw is HdlLinearPath _0023_003DzL168Avo_003D))
		{
			if (!(_0023_003DzINDBoqS9DTqw is HdlPoint _0023_003DzpaJGiAY_003D))
			{
				if (!(_0023_003DzINDBoqS9DTqw is HdlEllipticalArc _0023_003DzmQoIR3_0024gMWnuMHSy0g_003D_003D))
				{
					if (!(_0023_003DzINDBoqS9DTqw is HdlArc _0023_003Dz4pj2nl0_003D))
					{
						if (!(_0023_003DzINDBoqS9DTqw is HdlSpline _0023_003DzZLU_iqffddqh))
						{
							if (_0023_003DzINDBoqS9DTqw is HdlSection _0023_003Dzmr9lDzo_003D)
							{
								odDbEntity = _0023_003DzNd2C_0024Jyd6x3N(_0023_003Dzmr9lDzo_003D, _0023_003Dz1EtocfNGByJv.database());
							}
						}
						else
						{
							odDbEntity = _0023_003DznePMAOoALItB(_0023_003DzZLU_iqffddqh);
						}
					}
					else
					{
						odDbEntity = _0023_003DzWp0jX7XKKPFd(_0023_003Dz4pj2nl0_003D);
					}
				}
				else
				{
					odDbEntity = _0023_003Dzm6jnFLtti99v(_0023_003DzmQoIR3_0024gMWnuMHSy0g_003D_003D);
				}
			}
			else
			{
				odDbEntity = _0023_003DzpggH7TrFQmvz(_0023_003DzpaJGiAY_003D);
			}
		}
		else
		{
			odDbEntity = _0023_003DzvMEan4Tq9WuUntffxfo6g4U_003D(_0023_003DzL168Avo_003D);
		}
		odDbEntity.setLayer(_0023_003DzQ5TPDS0_003D);
		odDbEntity.setColor(_0023_003DzJBUBFWA_003D);
		odDbEntity.setLineWeight(_0023_003Dzq_ABCx2CTIN8);
		_0023_003Dz1EtocfNGByJv.appendOdDbEntity(odDbEntity);
		MemoryManager.GetMemoryManager().StopTransaction(value);
	}

	private OdDbEntity _0023_003DzpggH7TrFQmvz(HdlPoint _0023_003DzpaJGiAY_003D)
	{
		OdDbPoint odDbPoint = OdDbPoint.createObject();
		odDbPoint.setPosition(new OdGePoint3d(_0023_003DzpaJGiAY_003D.Vertex.X, _0023_003DzpaJGiAY_003D.Vertex.Y, 0.0));
		return odDbPoint;
	}

	private OdDbPolyline _0023_003DzvMEan4Tq9WuUntffxfo6g4U_003D(HdlLinearPath _0023_003DzL168Avo_003D)
	{
		bool flag = _0023_003DzL168Avo_003D.Vertices[0] == _0023_003DzL168Avo_003D.Vertices.Last();
		int num = (flag ? (_0023_003DzL168Avo_003D.Vertices.Length - 1) : _0023_003DzL168Avo_003D.Vertices.Length);
		OdDbPolyline odDbPolyline = OdDbPolyline.createObject();
		odDbPolyline.reset(reuse: false, (uint)num);
		for (uint num2 = 0u; num2 < num; num2++)
		{
			OdGePoint2d point2d = new OdGePoint2d(_0023_003DzL168Avo_003D.Vertices[num2].X, _0023_003DzL168Avo_003D.Vertices[num2].Y);
			odDbPolyline.addVertexAt(num2, point2d, 0.0, 0.0, 0.0);
		}
		odDbPolyline.setClosed(flag);
		return odDbPolyline;
	}

	private OdDbEllipse _0023_003Dzm6jnFLtti99v(HdlEllipticalArc _0023_003DzmQoIR3_0024gMWnuMHSy0g_003D_003D)
	{
		return _0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003Dzm6jnFLtti99v(new EllipticalArc(_0023_003DzmQoIR3_0024gMWnuMHSy0g_003D_003D.Plane, _0023_003DzmQoIR3_0024gMWnuMHSy0g_003D_003D.RadiusX, _0023_003DzmQoIR3_0024gMWnuMHSy0g_003D_003D.RadiusY, _0023_003DzmQoIR3_0024gMWnuMHSy0g_003D_003D.Angle.t0, _0023_003DzmQoIR3_0024gMWnuMHSy0g_003D_003D.Angle.t1));
	}

	private OdDbEntity _0023_003DzWp0jX7XKKPFd(HdlArc _0023_003Dz4pj2nl0_003D)
	{
		if (_0023_003Dz4pj2nl0_003D.Angle.IsTwoPI)
		{
			OdDbCircle odDbCircle = OdDbCircle.createObject();
			odDbCircle.setCenter(new OdGePoint3d(_0023_003Dz4pj2nl0_003D.Center.X, _0023_003Dz4pj2nl0_003D.Center.Y, 0.0));
			odDbCircle.setNormal(OdGeVector3d.kZAxis);
			odDbCircle.setRadius(_0023_003Dz4pj2nl0_003D.Radius);
			return odDbCircle;
		}
		OdDbArc odDbArc = OdDbArc.createObject();
		odDbArc.setCenter(new OdGePoint3d(_0023_003Dz4pj2nl0_003D.Center.X, _0023_003Dz4pj2nl0_003D.Center.Y, 0.0));
		odDbArc.setRadius(_0023_003Dz4pj2nl0_003D.Radius);
		odDbArc.setStartAngle(_0023_003Dz4pj2nl0_003D.Angle.t0);
		odDbArc.setEndAngle(_0023_003Dz4pj2nl0_003D.Angle.t1);
		return odDbArc;
	}

	private OdDbSpline _0023_003DznePMAOoALItB(HdlSpline _0023_003DzZLU_iqffddqh)
	{
		return _0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DznePMAOoALItB(new Curve(_0023_003DzZLU_iqffddqh.Degree, _0023_003DzZLU_iqffddqh.KnotVector, _0023_003DzZLU_iqffddqh.ControlPoints, checkKnotsAndCtrlPts: false));
	}

	private OdDbHatch _0023_003DzNd2C_0024Jyd6x3N(HdlSection _0023_003Dzmr9lDzo_003D, OdDbDatabase _0023_003DzR8GRspk_003D)
	{
		_0023_003Dzmr9lDzo_003D.Hatch.PatternScale = (float)(new Size2D(HdlViewSettings.boxMin, HdlViewSettings.boxMax).Diagonal * HdlViewSettings.ViewToWorldConversion() * (double)Scale * 0.1);
		return _0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33._0023_003DzNd2C_0024Jyd6x3N(_0023_003Dzmr9lDzo_003D.Hatch, _0023_003DzR8GRspk_003D);
	}
}
