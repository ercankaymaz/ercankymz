using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class ViewBuilder : WorkUnit, IDisposable
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<View, int> _0023_003DzrPVY8PGol6nwTtu1xA_003D_003D;

		internal int _0023_003DzxLcCOOIrOUNB_jsaFCtzbgk_003D(View _0023_003DzUBZd570_003D)
		{
			return (_0023_003DzUBZd570_003D is SectionView) ? 1 : 0;
		}
	}

	private sealed class _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D
	{
		public View _0023_003Dzc24p_0024Tg_003D;

		internal bool _0023_003Dz2e2_00241p0JWcNfaqLq8Q_003D_003D(KeyValuePair<Sheet, IList<View>> _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Value.Contains(_0023_003Dzc24p_0024Tg_003D);
		}
	}

	private protected const double FRAME_OFFSET_FACTOR = 0.15;

	private protected DesignDocument _designDoc;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private linearUnitsType _0023_003DzJ3cGkzHGBfIi;

	private protected Camera _camera;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003Dz2lq8BfwXq6Ul;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<Sheet, IList<View>> _0023_003DztV1x61wQ3GuXxQXC6XmcJAY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<View, Block> _0023_003DzTjAKxCt022fi8DnwaDS_HAU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzpCzV25LjxoE7QNAwS4NnDWo_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653020);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzAFLPR3aqAeRupWVZijTxzpc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzpxW3PVv5YfK7;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string[] _0023_003DzMVsN0UtdeR2F = new string[7];

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzxtKcdCRDFBKy1UGzrfk3ENA_003D;

	internal bool addToDrawing;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HiddenLinesViewSettings _0023_003Dzh0xwD3g2SaiB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HiddenLinesView _0023_003Dz_0024Lwx_XDbamku;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IProgress<ProgressChangedEventArgs> _0023_003DzsWnj47U_003D;

	public Dictionary<Sheet, IList<View>> SheetsViews
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DztV1x61wQ3GuXxQXC6XmcJAY_003D;
		}
	}

	internal Dictionary<View, Block> viewsBlocks
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTjAKxCt022fi8DnwaDS_HAU_003D;
		}
		[CompilerGenerated]
		private set
		{
			_0023_003DzTjAKxCt022fi8DnwaDS_HAU_003D = value;
		}
	}

	public string BuildingViewText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzpCzV25LjxoE7QNAwS4NnDWo_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzpCzV25LjxoE7QNAwS4NnDWo_003D = value;
		}
	}

	public string BuildingViewSuffix
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzAFLPR3aqAeRupWVZijTxzpc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzAFLPR3aqAeRupWVZijTxzpc_003D = value;
		}
	}

	public ViewBuilder(DesignDocument design, DrawingDocument drawing, bool changedOnly = false)
	{
		Dictionary<Sheet, IList<View>> dictionary = new Dictionary<Sheet, IList<View>>();
		foreach (Sheet sheet in drawing.Sheets)
		{
			List<View> list = new List<View>();
			foreach (Entity entity in sheet.Entities)
			{
				if (entity is View view)
				{
					bool flag = drawing.Blocks != null && drawing.Blocks.Contains(view.BlockName);
					if (!changedOnly || view.HasChanged || !flag)
					{
						list.Add(view);
					}
				}
			}
			dictionary.Add(sheet, list);
		}
		_0023_003DztGdcVOA_003D(design, drawing, dictionary);
	}

	public ViewBuilder(DesignDocument design, DrawingDocument drawing, View view, Sheet sheet)
		: this(design, drawing, new Dictionary<Sheet, IList<View>> { 
		{
			sheet,
			new List<View> { view }
		} })
	{
	}

	internal ViewBuilder(DesignDocument _0023_003DzDh_00246Paw_003D, DrawingDocument _0023_003Dzu9im1ZQ_003D, Dictionary<Sheet, IList<View>> _0023_003DzIEQU9zyAQyeaj4sflA_003D_003D)
	{
		_0023_003DztGdcVOA_003D(_0023_003DzDh_00246Paw_003D, _0023_003Dzu9im1ZQ_003D, _0023_003DzIEQU9zyAQyeaj4sflA_003D_003D);
	}

	private void _0023_003DztGdcVOA_003D(DesignDocument _0023_003DzDh_00246Paw_003D, DrawingDocument _0023_003Dzu9im1ZQ_003D, Dictionary<Sheet, IList<View>> _0023_003DzIEQU9zyAQyeaj4sflA_003D_003D)
	{
		_designDoc = _0023_003DzDh_00246Paw_003D;
		_0023_003DzJ3cGkzHGBfIi = _0023_003DzDh_00246Paw_003D.Units;
		_0023_003Dz2lq8BfwXq6Ul = _0023_003Dzu9im1ZQ_003D.Blocks;
		_0023_003DzN4fsd1mReWtq(_0023_003DzIEQU9zyAQyeaj4sflA_003D_003D);
		_0023_003DzMVsN0UtdeR2F[0] = _0023_003Dzu9im1ZQ_003D.SilhouettesLayerName;
		_0023_003DzMVsN0UtdeR2F[1] = _0023_003Dzu9im1ZQ_003D.EdgesLayerName;
		_0023_003DzMVsN0UtdeR2F[2] = _0023_003Dzu9im1ZQ_003D.WiresLayerName;
		_0023_003DzMVsN0UtdeR2F[3] = _0023_003Dzu9im1ZQ_003D.HiddenSilhouettesLayerName;
		_0023_003DzMVsN0UtdeR2F[4] = _0023_003Dzu9im1ZQ_003D.HiddenEdgesLayerName;
		_0023_003DzMVsN0UtdeR2F[5] = _0023_003Dzu9im1ZQ_003D.HiddenWiresLayerName;
		_0023_003DzMVsN0UtdeR2F[6] = _0023_003Dzu9im1ZQ_003D.SectionsLayerName;
		_0023_003DzxtKcdCRDFBKy1UGzrfk3ENA_003D = _0023_003Dzu9im1ZQ_003D.CenterlinesLayerName;
	}

	private void _0023_003DzN4fsd1mReWtq(Dictionary<Sheet, IList<View>> _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DztV1x61wQ3GuXxQXC6XmcJAY_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public bool Contains(View view)
	{
		_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D CS_0024_003C_003E8__locals2 = new _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D();
		CS_0024_003C_003E8__locals2._0023_003Dzc24p_0024Tg_003D = view;
		return SheetsViews.Count((KeyValuePair<Sheet, IList<View>> _0023_003DzBJFJHwk_003D) => _0023_003DzBJFJHwk_003D.Value.Contains(CS_0024_003C_003E8__locals2._0023_003Dzc24p_0024Tg_003D)) > 0;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		viewsBlocks = new Dictionary<View, Block>();
		_0023_003DzsWnj47U_003D = progress;
		foreach (KeyValuePair<Sheet, IList<View>> sheetsView in SheetsViews)
		{
			Sheet key = sheetsView.Key;
			foreach (View item in sheetsView.Value.OrderBy(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzxLcCOOIrOUNB_jsaFCtzbgk_003D).ToList())
			{
				_0023_003DzpxW3PVv5YfK7 = BuildingViewText + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + (BuildingViewSuffix ?? item.BlockName);
				UpdateProgress(0.0, 100.0, _0023_003DzpxW3PVv5YfK7, progress);
				Block block = _0023_003DzZEMF8AsXSqaM(item, key, progress, ct);
				viewsBlocks.Add(item, block);
				item._0023_003DzDaxeAiK9rC4V(block == null);
				if (Cancelled(ct))
				{
					break;
				}
				UpdateProgressTo100(_0023_003DzpxW3PVv5YfK7, progress);
			}
			if (Cancelled(ct))
			{
				break;
			}
		}
	}

	public override void WorkCompleted(object sender)
	{
		IWorkspace workspace;
		Document document = GetDocument(sender, out workspace);
		if (addToDrawing && document is DrawingDocument drawing)
		{
			AddTo(drawing);
		}
		base.WorkCompleted(sender);
	}

	private Block _0023_003DzZEMF8AsXSqaM(View _0023_003Dzc24p_0024Tg_003D, Sheet _0023_003Dzow3wazApPFf_0024, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (_0023_003Dzc24p_0024Tg_003D is RasterView _0023_003Dzc24p_0024Tg_003D2)
		{
			return DoWorkRaster(_0023_003Dzc24p_0024Tg_003D2, _0023_003Dzow3wazApPFf_0024);
		}
		return DoWorkVector((VectorView)_0023_003Dzc24p_0024Tg_003D, _0023_003Dzow3wazApPFf_0024, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
	}

	private void _0023_003DzsjMAI0Rq_0024mnT(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		UpdateProgress(_0023_003DzbfrNXYE_003D.Progress, 100.0, _0023_003DzbfrNXYE_003D.Text, _0023_003DzsWnj47U_003D);
	}

	private protected virtual Block DoWorkVector(VectorView _0023_003DzImuTX10_003D, Sheet _0023_003Dzow3wazApPFf_0024, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (!InitializeCameraAndUpdateView(_0023_003DzImuTX10_003D, _0023_003Dzow3wazApPFf_0024))
		{
			return null;
		}
		hiddenLinesViewType viewMode;
		if (!_0023_003DzImuTX10_003D.Window.IsEmpty)
		{
			_0023_003DzImuTX10_003D.viewportSize = new Size((int)Math.Round(_0023_003DzImuTX10_003D.Window.Width), (int)Math.Round(_0023_003DzImuTX10_003D.Window.Height));
			_camera.UpdateSize(_0023_003DzImuTX10_003D.viewportSize);
			_camera.RecomputeViewport(_0023_003DzImuTX10_003D.viewportSize);
			viewMode = hiddenLinesViewType.Window;
		}
		else
		{
			viewMode = hiddenLinesViewType.Viewport;
		}
		_camera.Target = _0023_003DzImuTX10_003D.WindowCenter;
		_0023_003Dzh0xwD3g2SaiB = new HiddenLinesViewSettings(_camera, _designDoc, viewMode, _0023_003DzImuTX10_003D.viewportSize);
		_0023_003Dzh0xwD3g2SaiB.EntitiesToHide = _0023_003DzImuTX10_003D.EntitiesToHide;
		_0023_003Dzh0xwD3g2SaiB.KeepHiddenSegments = true;
		_0023_003Dzh0xwD3g2SaiB.FillTexts = _0023_003DzImuTX10_003D.FillTexts;
		_0023_003Dzh0xwD3g2SaiB.ForceTextsAsTriangles = true;
		_0023_003Dzh0xwD3g2SaiB.FontAccuracy = _0023_003DzImuTX10_003D.FontAccuracy;
		_0023_003Dzh0xwD3g2SaiB.IgnoreTransparency = _0023_003DzImuTX10_003D.IgnoreTransparency;
		_0023_003Dzh0xwD3g2SaiB.FillRegions = _0023_003DzImuTX10_003D.FillRegions;
		_0023_003Dzh0xwD3g2SaiB.KeepEntityColor = _0023_003DzImuTX10_003D.KeepEntityColor;
		_0023_003Dzh0xwD3g2SaiB.TreatWhiteAsBlack = _0023_003DzImuTX10_003D.TreatWhiteAsBlack;
		_0023_003Dzh0xwD3g2SaiB._0023_003DzPOJsk28mpsMNtfD8Bw_003D_003D((_0023_003DzImuTX10_003D is SectionView sectionView) ? sectionView.SectionPlane : null);
		_0023_003Dz_0024Lwx_XDbamku = new HiddenLinesView(_0023_003Dzh0xwD3g2SaiB);
		_0023_003Dz_0024Lwx_XDbamku.ComputingVisibilityText = _0023_003DzpxW3PVv5YfK7;
		_0023_003Dz_0024Lwx_XDbamku.ComputingSilhouettesText = _0023_003DzpxW3PVv5YfK7;
		_0023_003Dz_0024Lwx_XDbamku.RemovingOverlappingLinesText = _0023_003DzpxW3PVv5YfK7;
		_0023_003Dz_0024Lwx_XDbamku.ComputingCirclesText = _0023_003DzpxW3PVv5YfK7;
		_0023_003Dz_0024Lwx_XDbamku.ProgressChanged += delegate(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
		{
			UpdateProgress(_0023_003DzbfrNXYE_003D.Progress, 100.0, _0023_003DzbfrNXYE_003D.Text, _0023_003DzsWnj47U_003D);
		};
		_0023_003Dz_0024Lwx_XDbamku.DoWork(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		_0023_003Dz_0024Lwx_XDbamku.ProgressChanged -= delegate(object _0023_003Dz9VjL5i0_003D, ProgressChangedEventArgs _0023_003DzbfrNXYE_003D)
		{
			UpdateProgress(_0023_003DzbfrNXYE_003D.Progress, 100.0, _0023_003DzbfrNXYE_003D.Text, _0023_003DzsWnj47U_003D);
		};
		if (!string.IsNullOrEmpty(_0023_003Dz_0024Lwx_XDbamku.Log))
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653001) + _0023_003DzImuTX10_003D.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302652985) + Environment.NewLine + _0023_003Dz_0024Lwx_XDbamku.Log);
		}
		Block result = (Cancelled(_0023_003Dzjvn7P10_003D) ? null : _0023_003Dzbg_p6G2dKDUh(_0023_003DzImuTX10_003D, _0023_003Dzow3wazApPFf_0024, _0023_003Dzjvn7P10_003D));
		_0023_003Dzh0xwD3g2SaiB = null;
		_0023_003Dz_0024Lwx_XDbamku = null;
		return result;
	}

	internal bool InitializeCameraAndUpdateView(View _0023_003Dzc24p_0024Tg_003D, Sheet _0023_003Dzow3wazApPFf_0024)
	{
		if (_0023_003Dzc24p_0024Tg_003D is SectionView sectionView && sectionView.SectionPlane == null)
		{
			if (sectionView.ParentView.originTranslation == null)
			{
				string value = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302652970) + sectionView.ParentView.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302652959) + sectionView.BlockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290);
				log.AppendLine(value);
				return false;
			}
			_0023_003Dzk3WyY1gjDldJ(sectionView, _0023_003Dzow3wazApPFf_0024);
		}
		_camera = (Camera)_0023_003Dzc24p_0024Tg_003D.Camera.Clone();
		if (_0023_003Dzc24p_0024Tg_003D.ViewType != viewType.Other)
		{
			ApplyOrientationModeRotation(_camera);
		}
		_camera.RecomputeViewport(_0023_003Dzc24p_0024Tg_003D.viewportSize);
		_camera.UpdateMatrices(_0023_003DzgEkZi75Aakl3: false);
		if (_0023_003Dzc24p_0024Tg_003D.WindowCenter == null)
		{
			_0023_003Dz1tJCuWhilBK7(_0023_003Dzc24p_0024Tg_003D, _0023_003Dzow3wazApPFf_0024);
		}
		return true;
	}

	private void _0023_003Dz1tJCuWhilBK7(View _0023_003Dzc24p_0024Tg_003D, Sheet _0023_003Dzow3wazApPFf_0024)
	{
		int[] array = HiddenLinesViewSettings._0023_003DziNJ_4d0rqJ74(_0023_003Dzc24p_0024Tg_003D.viewportSize);
		if (!_0023_003Dzc24p_0024Tg_003D.Window.IsEmpty)
		{
			float width = _0023_003Dzc24p_0024Tg_003D.Window.Width;
			float height = _0023_003Dzc24p_0024Tg_003D.Window.Height;
			if (width == (float)_0023_003Dzc24p_0024Tg_003D.viewportSize.Width && height == (float)_0023_003Dzc24p_0024Tg_003D.viewportSize.Height)
			{
				_0023_003Dzc24p_0024Tg_003D.WindowCenter = (Point3D)_camera.Target.Clone();
			}
			else
			{
				_camera.GetFrame(out var origin, out var camX, out var camY, out var _);
				Plane plane = new Plane(origin, camX, camY);
				System.Drawing.Point mousePos = new System.Drawing.Point((int)Math.Round(_0023_003Dzc24p_0024Tg_003D.Window.X + width / 2f), (int)Math.Round(_0023_003Dzc24p_0024Tg_003D.Window.Y + height / 2f));
				_camera.ScreenToPlane(mousePos, plane.Equation, _0023_003Dzc24p_0024Tg_003D.viewportSize.Height, array, out var intPoint);
				_0023_003Dzc24p_0024Tg_003D.WindowCenter = intPoint;
				PointF location = new PointF((float)_0023_003Dzc24p_0024Tg_003D.viewportSize.Width / 2f - width / 2f, (float)_0023_003Dzc24p_0024Tg_003D.viewportSize.Height / 2f - height / 2f);
				_0023_003Dzc24p_0024Tg_003D._0023_003DzBZEKdN8_003D(new RectangleF(location, _0023_003Dzc24p_0024Tg_003D.Window.Size));
			}
			double num = ((_camera.ProjectionMode == projectionType.Orthographic) ? _camera.ComputeScreenToWorldFactor(_camera.renderContext, array) : 1.0);
			double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(_designDoc.Units, _0023_003Dzow3wazApPFf_0024.Units);
			_0023_003Dzc24p_0024Tg_003D._0023_003DzUBcyrssJEGAK((double)width * num * _0023_003Dzc24p_0024Tg_003D.Scale * linearUnitsConversionFactor);
			_0023_003Dzc24p_0024Tg_003D._0023_003DzBEcDMzq6J80l((double)height * num * _0023_003Dzc24p_0024Tg_003D.Scale * linearUnitsConversionFactor);
		}
		else
		{
			if (_0023_003Dzc24p_0024Tg_003D._0023_003Dz83DhkJo5tfYe() || _0023_003Dzc24p_0024Tg_003D is SectionView)
			{
				_camera.UpdateBoundingBox(array, _designDoc.Entities, _designDoc, _0023_003Dz9rsu4TwhLBvn: false);
				_camera.Target = (Point3D)_camera.centerOfRotation.Clone();
				_0023_003Dzc24p_0024Tg_003D.WindowCenter = _camera.Target;
			}
			else
			{
				_0023_003Dzc24p_0024Tg_003D.WindowCenter = _0023_003Dzc24p_0024Tg_003D.Camera.Target;
			}
			if (_0023_003Dzc24p_0024Tg_003D.Width > 0.0 && _0023_003Dzc24p_0024Tg_003D.Height > 0.0)
			{
				double linearUnitsConversionFactor2 = Utility.GetLinearUnitsConversionFactor(_designDoc.Units, _0023_003Dzow3wazApPFf_0024.Units);
				double num2 = ((_camera.ProjectionMode == projectionType.Orthographic) ? _camera.ComputeScreenToWorldFactor(_camera.renderContext, array) : 1.0);
				double num3 = _0023_003Dzc24p_0024Tg_003D.Width / (_0023_003Dzc24p_0024Tg_003D.Scale * linearUnitsConversionFactor2 * num2);
				double num4 = _0023_003Dzc24p_0024Tg_003D.Height / (_0023_003Dzc24p_0024Tg_003D.Scale * linearUnitsConversionFactor2 * num2);
				_0023_003Dzc24p_0024Tg_003D._0023_003DzBZEKdN8_003D(new RectangleF(new PointF(0f, 0f), new SizeF((float)num3, (float)num4)));
			}
			else
			{
				_0023_003DzgFrIKhYgP86s(_0023_003Dzc24p_0024Tg_003D, _0023_003Dzow3wazApPFf_0024, array);
			}
		}
	}

	private void _0023_003DzgFrIKhYgP86s(View _0023_003Dzc24p_0024Tg_003D, Sheet _0023_003Dzow3wazApPFf_0024, int[] _0023_003DzqDFBISpCePlj)
	{
		double num;
		double num2;
		if (_camera.ProjectionMode == projectionType.Perspective)
		{
			num = _0023_003Dzc24p_0024Tg_003D.viewportSize.Width;
			num2 = _0023_003Dzc24p_0024Tg_003D.viewportSize.Height;
		}
		else
		{
			_camera.UpdateBoundingBox(_0023_003DzqDFBISpCePlj, _designDoc.Entities, _designDoc, _0023_003Dz9rsu4TwhLBvn: false);
			Point3D projectedMin = _camera.projectedMin;
			Point3D projectedMax = _camera.projectedMax;
			num = projectedMax.X - projectedMin.X;
			num2 = projectedMax.Y - projectedMin.Y;
		}
		double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(_designDoc.Units, _0023_003Dzow3wazApPFf_0024.Units);
		num *= _0023_003Dzc24p_0024Tg_003D.Scale * linearUnitsConversionFactor;
		num2 *= _0023_003Dzc24p_0024Tg_003D.Scale * linearUnitsConversionFactor;
		double num3 = 0.15 * Math.Max(num, num2);
		_0023_003Dzc24p_0024Tg_003D._0023_003DzUBcyrssJEGAK(num + num3);
		_0023_003Dzc24p_0024Tg_003D._0023_003DzBEcDMzq6J80l(num2 + num3);
	}

	private void _0023_003Dzk3WyY1gjDldJ(SectionView _0023_003Dz1kd00FA_003D, Sheet _0023_003Dzow3wazApPFf_0024)
	{
		VectorView parentView = _0023_003Dz1kd00FA_003D.ParentView;
		parentView.Camera.GetFrame(out var origin, out var camX, out var camY, out var camZ);
		Plane plane = new Plane(origin, camX, camY);
		Transformation transformation = (Transformation)parentView.Transformation.Clone();
		transformation.Invert();
		Point2D[] _0023_003DzrdSL0CI_003D = new Point2D[3]
		{
			transformation * _0023_003Dz1kd00FA_003D.SectionLine.P0,
			transformation * _0023_003Dz1kd00FA_003D.SectionLine.P1,
			transformation * _0023_003Dz1kd00FA_003D.InsertionPoint
		};
		Point3D[] array = parentView._0023_003DzEe14bmJJRgPE(_0023_003DzrdSL0CI_003D);
		Segment3D segment3D = new Segment3D(array[0], array[1]);
		double t = segment3D.Project(array[2]);
		Vector3D b = new Vector3D(segment3D.PointAt(t), array[2]);
		Vector3D vector3D = Vector3D.Cross(camZ, b);
		vector3D.Normalize();
		if (_0023_003Dzow3wazApPFf_0024.AngleProjectionMode == angleProjectionType.FirstAngle)
		{
			vector3D.Negate();
		}
		plane.Rotate(Math.PI / 2.0, vector3D);
		plane.Origin = array[0];
		_0023_003Dz1kd00FA_003D._0023_003DztGdcVOA_003D(plane, parentView.Scale);
	}

	private protected virtual void ApplyOrientationModeRotation(Camera _0023_003Dz10qtbIGWAWjL)
	{
	}

	private Block _0023_003Dzbg_p6G2dKDUh(VectorView _0023_003DzImuTX10_003D, Sheet _0023_003Dzow3wazApPFf_0024, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		Block block = new Block(_0023_003DzImuTX10_003D.BlockName);
		double num = ((_camera.ProjectionMode == projectionType.Orthographic) ? _0023_003Dzh0xwD3g2SaiB.ViewToWorldConversion() : 1.0);
		double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(_0023_003DzJ3cGkzHGBfIi, _0023_003Dzow3wazApPFf_0024.Units);
		double num2 = num * linearUnitsConversionFactor;
		float _0023_003DzCJ_GAlyQBtZp = (float)Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, _0023_003Dzow3wazApPFf_0024.Units);
		Translation translation = new Translation((0.0 - num2) * (double)_0023_003DzImuTX10_003D.viewportSize.Width / 2.0, (0.0 - num2) * (double)_0023_003DzImuTX10_003D.viewportSize.Height / 2.0);
		_0023_003DzKNMpdHcfFd_0024g(block, _0023_003Dz_0024Lwx_XDbamku.Silhouettes, translation, num2, _0023_003DzCJ_GAlyQBtZp, _0023_003DzMVsN0UtdeR2F[0], _0023_003DzImuTX10_003D.KeepEntityColor, _0023_003DzSZ0NwQM_003D: false, 0);
		if (Cancelled(_0023_003Dzjvn7P10_003D))
		{
			return null;
		}
		_0023_003DzKNMpdHcfFd_0024g(block, _0023_003Dz_0024Lwx_XDbamku.Edges, translation, num2, _0023_003DzCJ_GAlyQBtZp, _0023_003DzMVsN0UtdeR2F[1], _0023_003DzImuTX10_003D.KeepEntityColor, _0023_003DzSZ0NwQM_003D: false, 0);
		if (Cancelled(_0023_003Dzjvn7P10_003D))
		{
			return null;
		}
		_0023_003DzKNMpdHcfFd_0024g(block, _0023_003Dz_0024Lwx_XDbamku.Wires, translation, num2, _0023_003DzCJ_GAlyQBtZp, _0023_003DzMVsN0UtdeR2F[2], _0023_003DzImuTX10_003D.KeepEntityColor, _0023_003DzSZ0NwQM_003D: false, 0);
		if (Cancelled(_0023_003Dzjvn7P10_003D))
		{
			return null;
		}
		if (_0023_003DzImuTX10_003D.HiddenSegments)
		{
			_0023_003DzKNMpdHcfFd_0024g(block, _0023_003Dz_0024Lwx_XDbamku.HiddenSilhouettes, translation, num2, _0023_003DzCJ_GAlyQBtZp, _0023_003DzMVsN0UtdeR2F[3], _0023_003DzImuTX10_003D.KeepEntityColor, _0023_003DzSZ0NwQM_003D: false, 0);
			if (Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return null;
			}
			_0023_003DzKNMpdHcfFd_0024g(block, _0023_003Dz_0024Lwx_XDbamku.HiddenEdges, translation, num2, _0023_003DzCJ_GAlyQBtZp, _0023_003DzMVsN0UtdeR2F[4], _0023_003DzImuTX10_003D.KeepEntityColor, _0023_003DzSZ0NwQM_003D: false, 0);
			if (Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return null;
			}
			_0023_003DzKNMpdHcfFd_0024g(block, _0023_003Dz_0024Lwx_XDbamku.HiddenWires, translation, num2, _0023_003DzCJ_GAlyQBtZp, _0023_003DzMVsN0UtdeR2F[5], _0023_003DzImuTX10_003D.KeepEntityColor, _0023_003DzSZ0NwQM_003D: false, 0);
			if (Cancelled(_0023_003Dzjvn7P10_003D))
			{
				return null;
			}
		}
		_0023_003DzImuTX10_003D.hiddenSilho2D = _0023_003Dz_0024Lwx_XDbamku.HiddenSilhouettes;
		_0023_003DzImuTX10_003D.hiddenEdges2D = _0023_003Dz_0024Lwx_XDbamku.HiddenEdges;
		_0023_003DzImuTX10_003D.hiddenWires2D = _0023_003Dz_0024Lwx_XDbamku.HiddenWires;
		_0023_003DzImuTX10_003D.segmentsScaleFactor = num2;
		_0023_003DzImuTX10_003D.originTranslation = translation;
		_0023_003DzE9M054202hkK(block, translation, num2, _0023_003DzMVsN0UtdeR2F[2], _0023_003DzImuTX10_003D.KeepEntityColor);
		_0023_003DzOxPRBtc_003D(block, translation, num2, _0023_003DzMVsN0UtdeR2F[6], _0023_003DzImuTX10_003D.KeepEntityColor, (float)(Utility.GetLinearUnitsConversionFactor(linearUnitsType.Inches, _0023_003Dzow3wazApPFf_0024.Units) / _0023_003DzImuTX10_003D.Scale * 0.7));
		_0023_003Dz2lq8BfwXq6Ul.TryGetValue(block.Name, out var value);
		if (value != null)
		{
			block.Entities.AddRange(value.Entities.Where((Entity _0023_003DzBJFJHwk_003D) => !_0023_003DzMVsN0UtdeR2F.Contains(_0023_003DzBJFJHwk_003D.LayerName) && !(_0023_003DzBJFJHwk_003D is Picture)).ToList());
		}
		return block;
	}

	internal static int _0023_003DzKNMpdHcfFd_0024g(Block _0023_003DzLeyHB00_003D, IList<HiddenLinesView.HdlCurve> _0023_003DzTftW4PL7HjPF9BhfLg_003D_003D, Translation _0023_003Dz6MhNZc70CItnxxqGuw_003D_003D, double _0023_003DzcLSLSwAYCRot, float _0023_003DzCJ_GAlyQBtZp, string _0023_003DzaROjBYA_003D, bool _0023_003Dzvpb_0024zRv_0024YJ53, bool _0023_003DzSZ0NwQM_003D, int _0023_003DzAddCv_o_003D)
	{
		if (_0023_003DzTftW4PL7HjPF9BhfLg_003D_003D == null)
		{
			return 0;
		}
		List<Entity> list = new List<Entity>(_0023_003DzTftW4PL7HjPF9BhfLg_003D_003D.Count);
		int num = 0;
		for (int i = 0; i < _0023_003DzTftW4PL7HjPF9BhfLg_003D_003D.Count; i++)
		{
			HiddenLinesView.HdlCurve hdlCurve = _0023_003DzTftW4PL7HjPF9BhfLg_003D_003D[i];
			Entity entity;
			if (hdlCurve is HiddenLinesView.HdlPoint hdlPoint)
			{
				Point3D point3D = new Point3D(hdlPoint.Vertex.X, hdlPoint.Vertex.Y, 0.0) * _0023_003DzcLSLSwAYCRot;
				point3D.TransformBy(_0023_003Dz6MhNZc70CItnxxqGuw_003D_003D);
				entity = new devDept.Eyeshot.Entities.Point(point3D);
			}
			else if (hdlCurve is HiddenLinesView.HdlLinearPath hdlLinearPath)
			{
				int num2 = hdlLinearPath.Vertices.Length;
				Point3D[] array = new Point3D[num2];
				for (int j = 0; j < num2; j++)
				{
					Point3D point3D2 = new Point3D(hdlLinearPath.Vertices[j].X, hdlLinearPath.Vertices[j].Y, 0.0) * _0023_003DzcLSLSwAYCRot;
					point3D2.TransformBy(_0023_003Dz6MhNZc70CItnxxqGuw_003D_003D);
					array[j] = point3D2;
				}
				entity = new LinearPath(array);
			}
			else if (hdlCurve is HiddenLinesView.HdlSpline hdlSpline)
			{
				Transformation xform = _0023_003Dz6MhNZc70CItnxxqGuw_003D_003D * new Scaling(_0023_003DzcLSLSwAYCRot);
				Point4D[] controlPoints = hdlSpline.ControlPoints;
				for (int k = 0; k < controlPoints.Length; k++)
				{
					controlPoints[k].TransformBy(xform);
				}
				entity = new Curve(hdlSpline.Degree, hdlSpline.KnotVector, hdlSpline.ControlPoints, checkKnotsAndCtrlPts: false);
			}
			else if (hdlCurve is HiddenLinesView.HdlEllipticalArc hdlEllipticalArc)
			{
				entity = new EllipticalArc(hdlEllipticalArc.Plane, hdlEllipticalArc.RadiusX, hdlEllipticalArc.RadiusY, hdlEllipticalArc.Angle.t0, hdlEllipticalArc.Angle.t1);
				entity.TransformBy(_0023_003Dz6MhNZc70CItnxxqGuw_003D_003D * new Scaling(_0023_003DzcLSLSwAYCRot));
			}
			else
			{
				HiddenLinesView.HdlArc hdlArc = (HiddenLinesView.HdlArc)hdlCurve;
				if (hdlArc.Radius == 0.0)
				{
					continue;
				}
				Point2D point2D = hdlArc.Center * _0023_003DzcLSLSwAYCRot;
				point2D.TransformBy(_0023_003Dz6MhNZc70CItnxxqGuw_003D_003D);
				entity = new Arc(Plane.XY, point2D, hdlArc.Radius * _0023_003DzcLSLSwAYCRot, hdlArc.Angle.t0, hdlArc.Angle.t1);
			}
			((ICurve)entity).EdgeIndex = hdlCurve.EdgeIndex;
			Entity entity2 = entity;
			colorMethodType lineTypeMethod = (entity.LineWeightMethod = colorMethodType.byLayer);
			entity2.LineTypeMethod = lineTypeMethod;
			entity.LayerName = _0023_003DzaROjBYA_003D;
			entity.LineTypeScale = _0023_003DzCJ_GAlyQBtZp;
			entity.EntityData = new AssemblyLeaf(hdlCurve.Entity, hdlCurve.Parents);
			if (_0023_003Dzvpb_0024zRv_0024YJ53)
			{
				entity.Color = hdlCurve.Attributes.Color;
				entity.ColorMethod = colorMethodType.byEntity;
			}
			entity.PrintOrder = hdlCurve.Entity.PrintOrder;
			num++;
			list.Add(entity);
		}
		if (_0023_003DzSZ0NwQM_003D)
		{
			_0023_003DzLeyHB00_003D.Entities.InsertRange(_0023_003DzAddCv_o_003D, list);
		}
		else
		{
			_0023_003DzLeyHB00_003D.Entities.AddRange(list);
		}
		return num;
	}

	private void _0023_003DzE9M054202hkK(Block _0023_003DzLeyHB00_003D, Translation _0023_003Dz6MhNZc70CItnxxqGuw_003D_003D, double _0023_003DzcLSLSwAYCRot, string _0023_003DzaROjBYA_003D, bool _0023_003Dzvpb_0024zRv_0024YJ53)
	{
		HiddenLinesView.HdlMesh[] meshes = _0023_003Dz_0024Lwx_XDbamku.Meshes;
		if (meshes == null)
		{
			return;
		}
		Transformation xform = _0023_003Dz6MhNZc70CItnxxqGuw_003D_003D * new Scaling(_0023_003DzcLSLSwAYCRot);
		Mesh[] array = new Mesh[meshes.Length];
		for (int i = 0; i < meshes.Length; i++)
		{
			HiddenLinesView.HdlMesh hdlMesh = meshes[i];
			Mesh mesh = hdlMesh.Mesh;
			mesh.TransformBy(xform);
			colorMethodType lineTypeMethod = (mesh.LineWeightMethod = colorMethodType.byLayer);
			mesh.LineTypeMethod = lineTypeMethod;
			mesh.LayerName = _0023_003DzaROjBYA_003D;
			mesh.EntityData = new AssemblyLeaf(hdlMesh.Entity, hdlMesh.Parents);
			if (_0023_003Dzvpb_0024zRv_0024YJ53)
			{
				mesh.ColorMethod = colorMethodType.byEntity;
			}
			mesh.PrintOrder = hdlMesh.Entity.PrintOrder;
			array[i] = mesh;
		}
		_0023_003DzLeyHB00_003D.Entities.AddRange(array);
	}

	private void _0023_003DzOxPRBtc_003D(Block _0023_003DzLeyHB00_003D, Translation _0023_003Dz6MhNZc70CItnxxqGuw_003D_003D, double _0023_003DzcLSLSwAYCRot, string _0023_003DzaROjBYA_003D, bool _0023_003Dzvpb_0024zRv_0024YJ53, float _0023_003DzyczfaXpdgfhi)
	{
		HiddenLinesView.HdlSection[] sections = _0023_003Dz_0024Lwx_XDbamku.Sections;
		if (sections == null)
		{
			return;
		}
		Transformation xform = _0023_003Dz6MhNZc70CItnxxqGuw_003D_003D * new Scaling(_0023_003DzcLSLSwAYCRot);
		Hatch[] array = new Hatch[sections.Length];
		for (int i = 0; i < sections.Length; i++)
		{
			HiddenLinesView.HdlSection hdlSection = sections[i];
			Hatch hatch = hdlSection.Hatch;
			hatch.TransformBy(xform);
			hatch.PatternScale = _0023_003DzyczfaXpdgfhi;
			colorMethodType lineTypeMethod = (hatch.LineWeightMethod = colorMethodType.byLayer);
			hatch.LineTypeMethod = lineTypeMethod;
			hatch.LayerName = _0023_003DzaROjBYA_003D;
			hatch.EntityData = new AssemblyLeaf(hdlSection.Entity, hdlSection.Parents);
			if (_0023_003Dzvpb_0024zRv_0024YJ53)
			{
				hatch.ColorMethod = colorMethodType.byEntity;
			}
			hatch.PrintOrder = hdlSection.Entity.PrintOrder;
			array[i] = hatch;
		}
		_0023_003DzLeyHB00_003D.Entities.AddRange(array);
	}

	private protected virtual Block DoWorkRaster(RasterView _0023_003Dzc24p_0024Tg_003D, Sheet _0023_003Dzow3wazApPFf_0024)
	{
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653161));
		return _0023_003Dzc24p_0024Tg_003D.GetPlaceHolderBlock(_0023_003DzMVsN0UtdeR2F[2], _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302653081));
	}

	public void AddTo(DrawingDocument drawing)
	{
		drawing.workspace?.RenderContext?.MakeCurrent();
		List<Block> list = new List<Block>();
		List<Entity> list2 = new List<Entity>();
		bool flag = false;
		foreach (KeyValuePair<Sheet, IList<View>> sheetsView in SheetsViews)
		{
			Sheet key = sheetsView.Key;
			foreach (View item in sheetsView.Value)
			{
				viewsBlocks.TryGetValue(item, out var value);
				bool flag2 = false;
				if (value != null)
				{
					if (drawing.Blocks.Contains(value.Name))
					{
						Block block = drawing.Blocks[value.Name];
						foreach (Entity entity in block.Entities)
						{
							entity.Dispose();
						}
						block.Entities.Clear();
						block.Entities.AddRange(value.Entities);
						block.BasePoint = value.BasePoint;
						flag2 = true;
					}
					else
					{
						list.Add(value);
					}
					if (key == drawing.ActiveSheet)
					{
						if (drawing.Entities.Contains(item))
						{
							if (flag2)
							{
								flag = true;
							}
						}
						else
						{
							list2.Add(item);
						}
					}
					else if (!key.Entities.Contains(item))
					{
						key.Entities.Add(item);
					}
				}
				else if (!drawing.Blocks.Contains(item.BlockName))
				{
					key.Entities.Remove(item);
				}
			}
		}
		drawing.Blocks.AddRange(list);
		if (flag)
		{
			drawing.Entities.Regen();
		}
		drawing.Entities.AddRange(list2);
	}

	public virtual void Dispose()
	{
		_camera?.Dispose();
		viewsBlocks.Clear();
		viewsBlocks = null;
	}

	private bool _0023_003DzrRJEe8ZHD0reTD9_0024A2_00242vGM_003D(Entity _0023_003DzBJFJHwk_003D)
	{
		if (!_0023_003DzMVsN0UtdeR2F.Contains(_0023_003DzBJFJHwk_003D.LayerName))
		{
			return !(_0023_003DzBJFJHwk_003D is Picture);
		}
		return false;
	}
}
