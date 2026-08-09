using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Control;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(Drawing))]
[Description("Provides the ability to generate 2D drawing from 3D models.")]
[Designer("devDept.Eyeshot.Designer.DrawingControlDesigner, devDept.Eyeshot.Control.Win.v2026.Design")]
public class Drawing : Workspace, IDrawing, IWorkspace
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz_0024fiHgTWokd11dmJsnA_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dz0FVSO5LFyxyq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzFUVSvBsTIB9Y;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Drawing _0023_003DzKdgtcDsi34jL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Design _0023_003DzFjK2_0024i0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzjeeRzKJ_0024VtsG;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003Dz9ZxzSZcDWPjZ;

		private void MoveNext()
		{
			int num = _0023_003Dz0FVSO5LFyxyq;
			Drawing drawing = _0023_003DzKdgtcDsi34jL;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					ViewBuilderEx workUnit = drawing._0023_003DzAwol7ztT6JBX(_0023_003DzFjK2_0024i0_003D, _0023_003DzjeeRzKJ_0024VtsG);
					awaiter = drawing.DoWorkAsync(workUnit).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003Dz0FVSO5LFyxyq = 0);
						_0023_003Dz9ZxzSZcDWPjZ = awaiter;
						_0023_003DzFUVSvBsTIB9Y.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003Dz9ZxzSZcDWPjZ;
					_0023_003Dz9ZxzSZcDWPjZ = default(TaskAwaiter);
					num = (_0023_003Dz0FVSO5LFyxyq = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003Dz0FVSO5LFyxyq = -2;
				_0023_003DzFUVSvBsTIB9Y.SetException(exception);
				return;
			}
			_0023_003Dz0FVSO5LFyxyq = -2;
			_0023_003DzFUVSvBsTIB9Y.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			_0023_003DzFUVSvBsTIB9Y.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003DzVzjxMe0_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003DzVzjxMe0_003D);
		}
	}

	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<Entity, bool> _0023_003Dz2PCuzLiqido0sCmhOQ_003D_003D;

		public static Func<Entity, bool> _0023_003DzUYzD9BGkywRQzZtzlg_003D_003D;

		public static Func<BlockReference, bool> _0023_003DzI3VsAL0W3O6hXyczFA_003D_003D;

		internal bool _0023_003DzCG2YMeFsFK_0024oxKdW04PNh7U_003D(Entity _0023_003Dz8GBMuoM_003D)
		{
			if (_0023_003Dz8GBMuoM_003D is VectorView vectorView)
			{
				return vectorView.inScope;
			}
			return false;
		}

		internal bool _0023_003DzxdF4fAQIGRMjSpqGpP56SyIJV_00249h(Entity _0023_003DztJCl_0024mM_003D)
		{
			if (_0023_003DztJCl_0024mM_003D is VectorView vectorView)
			{
				return vectorView.inScope;
			}
			return false;
		}

		internal bool _0023_003DznUv4oF6mIpLP1X7cCho6s6k_003D(BlockReference _0023_003Dz8GBMuoM_003D)
		{
			return _0023_003Dz8GBMuoM_003D is devDept.Eyeshot.Entities.View;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzZxEtupA3qIX5 = _0023_003DzqTHswNvgqrfk7EyJbQ_003D_003D();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003Dz8am334bIiRrgT1deXQ_003D_003D = 0.5f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003DzaOkEd2_0024V1Xvs = 0.15f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzwroBZWvtuJV36u_zPfkGSCQ_003D = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589071);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz1x_0024i6elA3ro9r_0024MJbPdBmoc_003D;

	public new DrawingDocument Document => (DrawingDocument)base.Document;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	internal Viewport _0023_003DzA4XKvZjCk7rt
	{
		get
		{
			return _0023_003DzipBYly6zFKAp();
		}
		set
		{
			if (base._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
			{
				base._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Add(value);
			}
			else
			{
				base._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D[0] = value;
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public double ZoomFactor => _0023_003DzA4XKvZjCk7rt.Camera.ZoomFactor;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public ZoomSettings Zoom
	{
		get
		{
			return _0023_003DzA4XKvZjCk7rt.Zoom;
		}
		set
		{
			_0023_003DzA4XKvZjCk7rt.Zoom = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public PanSettings Pan
	{
		get
		{
			return _0023_003DzA4XKvZjCk7rt.Pan;
		}
		set
		{
			_0023_003DzA4XKvZjCk7rt.Pan = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public float LineWeightFactor
	{
		get
		{
			return _0023_003DzQmbl9PzBp44d;
		}
		set
		{
			_0023_003DzQmbl9PzBp44d = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new BackgroundSettings Background => _0023_003DzA4XKvZjCk7rt.Background;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ToolBar ToolBar => _0023_003DzA4XKvZjCk7rt.ToolBar;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new ToolBar[] ToolBars => _0023_003DzA4XKvZjCk7rt.ToolBars;

	[Category("User Interface")]
	[Description("The paper color.")]
	public Color PaperColor
	{
		get
		{
			return _0023_003DzZxEtupA3qIX5;
		}
		set
		{
			_0023_003DzZxEtupA3qIX5 = value;
			if (IsDesignMode())
			{
				_0023_003Dz3tGL3rg_003D();
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SilhouettesLayerName
	{
		get
		{
			return Document.SilhouettesLayerName;
		}
		set
		{
			Document.SilhouettesLayerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string EdgesLayerName
	{
		get
		{
			return Document.EdgesLayerName;
		}
		set
		{
			Document.EdgesLayerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string WiresLayerName
	{
		get
		{
			return Document.WiresLayerName;
		}
		set
		{
			Document.WiresLayerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string HiddenSilhouettesLayerName
	{
		get
		{
			return Document.HiddenSilhouettesLayerName;
		}
		set
		{
			Document.HiddenSilhouettesLayerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string HiddenEdgesLayerName
	{
		get
		{
			return Document.HiddenEdgesLayerName;
		}
		set
		{
			Document.HiddenEdgesLayerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string HiddenWiresLayerName
	{
		get
		{
			return Document.HiddenWiresLayerName;
		}
		set
		{
			Document.HiddenWiresLayerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SectionsLayerName
	{
		get
		{
			return Document.SectionsLayerName;
		}
		set
		{
			Document.SectionsLayerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string CenterlinesLayerName
	{
		get
		{
			return Document.CenterlinesLayerName;
		}
		set
		{
			Document.CenterlinesLayerName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string HiddenSegmentsLineTypeName
	{
		get
		{
			return Document.HiddenSegmentsLineTypeName;
		}
		set
		{
			Document.HiddenSegmentsLineTypeName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string CenterlinesLineTypeName
	{
		get
		{
			return Document.CenterlinesLineTypeName;
		}
		set
		{
			Document.CenterlinesLineTypeName = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string ViewBuilderText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzwroBZWvtuJV36u_zPfkGSCQ_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzwroBZWvtuJV36u_zPfkGSCQ_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string ViewBuilderSuffix
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz1x_0024i6elA3ro9r_0024MJbPdBmoc_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz1x_0024i6elA3ro9r_0024MJbPdBmoc_003D = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public SheetKeyedCollection Sheets
	{
		get
		{
			return Document.Sheets;
		}
		set
		{
			Document.Sheets = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Sheet ActiveSheet
	{
		get
		{
			return Document.ActiveSheet;
		}
		set
		{
			Document.ActiveSheet = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int ActiveSheetIndex
	{
		get
		{
			return Document.ActiveSheetIndex;
		}
		set
		{
			Document.ActiveSheetIndex = value;
		}
	}

	public Drawing()
	{
		_0023_003DzA4XKvZjCk7rt = GetDefaultViewport();
		LineWeightFactor = 5f;
		base.CompileWires = false;
		base.Selection.Color = Color.OrangeRed;
	}

	private protected override void _0023_003Dz6iZ1ZQQ_003D()
	{
		_0023_003Dzjgaq1UhfISUG(new DrawingDocument());
	}

	public void LoadDocument(DrawingDocument drawingDocument)
	{
		_0023_003Dzjgaq1UhfISUG(drawingDocument);
	}

	public DrawingDocument UnloadDocument()
	{
		DrawingDocument document = Document;
		_0023_003Dz6iZ1ZQQ_003D();
		return document;
	}

	private static Color _0023_003DzqTHswNvgqrfk7EyJbQ_003D_003D()
	{
		return Color.FromArgb(234, 234, 221);
	}

	private bool ShouldSerializePaperColor()
	{
		return PaperColor != _0023_003DzqTHswNvgqrfk7EyJbQ_003D_003D();
	}

	internal void ResetPaperColor()
	{
		PaperColor = _0023_003DzqTHswNvgqrfk7EyJbQ_003D_003D();
	}

	private ViewBuilderEx _0023_003DzAwol7ztT6JBX(Design _0023_003DzFjK2_0024i0_003D, bool _0023_003DzjeeRzKJ_0024VtsG)
	{
		return new ViewBuilderEx(_0023_003DzFjK2_0024i0_003D, this, _0023_003DzjeeRzKJ_0024VtsG)
		{
			addToDrawing = true
		};
	}

	public void Rebuild(Design design, bool changedOnly = true)
	{
		ViewBuilderEx viewBuilderEx = _0023_003DzAwol7ztT6JBX(design, changedOnly);
		viewBuilderEx.DoWork();
		viewBuilderEx.AddTo(Document);
	}

	public async Task RebuildAsync(Design design, bool changedOnly = true)
	{
		ViewBuilderEx workUnit = _0023_003DzAwol7ztT6JBX(design, changedOnly);
		await DoWorkAsync(workUnit);
	}

	public override void InitializeViewports()
	{
		if (!_0023_003DzlNGYbbA_003D && base._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
		{
			base._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Add(GetDefaultViewport());
		}
		_0023_003DzxMjXttTc5JNkWQh7J4z9LEwPvett();
	}

	protected override Viewport GetDefaultViewport()
	{
		Viewport viewport = new Viewport();
		viewport.DisplayMode = displayType.Flat;
		base._0023_003Dzipe8ch4_003D.ShowEdges = false;
		viewport.Camera.ProjectionMode = projectionType.Orthographic;
		viewport.Rotate.Enabled = false;
		viewport.Background.StyleMode = backgroundStyleType.Solid;
		viewport.Background.TopColor = Color.DarkGray;
		viewport.Grid.Visible = false;
		if (viewport.ViewCubeIcon != null)
		{
			viewport.ViewCubeIcon.Visible = false;
		}
		if (viewport.CoordinateSystemIcon != null)
		{
			viewport.CoordinateSystemIcon.Visible = false;
		}
		if (viewport.OriginSymbol != null)
		{
			viewport.OriginSymbol.Visible = false;
		}
		ToolBarButton[] buttons = new ToolBarButton[4]
		{
			ToolBar._0023_003DzeGIXhgrati7e(),
			ToolBar._0023_003Dzz2Z6Ps2Iz3Hf(),
			ToolBar._0023_003Dzwnx4pVr7dYod(),
			ToolBar._0023_003DzXRi8cpoFZN11jyMG3g_003D_003D()
		};
		ToolBar toolBar = new ToolBar(ToolBar.positionType.HorizontalTopCenter, visible: true, buttons);
		viewport.ToolBars[0] = toolBar;
		return viewport;
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		base._0023_003Dzipe8ch4_003D.SilhouettesDrawingMode = silhouettesDrawingType.Never;
		base._0023_003Dzipe8ch4_003D.EdgeThickness = 1f;
		if (!_0023_003DzoJ3C7DgwDQct)
		{
			SetView(viewType.Top);
		}
	}

	public void AddDefaultLayersAndLineTypes()
	{
		Document.AddDefaultLayersAndLineTypes();
	}

	public void AddDefaultLineTypes()
	{
		Document.AddDefaultLineTypes();
	}

	internal override void _0023_003DzxMjXttTc5JNkWQh7J4z9LEwPvett()
	{
		if (Math.Min(_0023_003Dz0P1LCYH__O4t(), _0023_003DzNwtRJ3cLTrAy()) > 2)
		{
			_0023_003DzA4XKvZjCk7rt.Location = new System.Drawing.Point(0, 0);
			_0023_003DzA4XKvZjCk7rt.Size = base.Size;
			if (IsDesignMode() && _0023_003DzmNZD0Zs_003D != null)
			{
				ZoomFit();
			}
		}
	}

	internal override void _0023_003Dz__ogbSIFtpdK()
	{
		if (ActiveSheet == null || !base.IsOpenRootLevel)
		{
			base._0023_003DzK3OaHhra7VrS.OverrideSceneExtents = false;
		}
		else
		{
			base._0023_003DzK3OaHhra7VrS.OverrideSceneExtents = true;
			Interval interval = new Interval(-10.0, 10.0);
			base._0023_003DzK3OaHhra7VrS.Min = new Point3D(0.0, 0.0, interval.Low);
			base._0023_003DzK3OaHhra7VrS.Max = new Point3D(ActiveSheet.Width, ActiveSheet.Height, interval.High);
		}
		base._0023_003Dz__ogbSIFtpdK();
	}

	public void CopyTo(Workspace destination, bool replaceRootBlock = true, bool skipSheets = false, bool keepTessellation = false)
	{
		_0023_003DzcEouqDajTDte9AV8Ig_003D_003D(destination);
		Document.CopyTo(destination.Document, replaceRootBlock, skipSheets, keepTessellation);
	}

	public void PrintPreview(Size printPreviewDlgClientSize, bool allSheets = false)
	{
		_0023_003DzRQFxRLfAGxNs(_0023_003Dz5PV35Pc_003D: true, printPreviewDlgClientSize, allSheets ? Sheets : null);
	}

	public void PrintPreview(Size printPreviewDlgClientSize, IList<Sheet> sheets)
	{
		_0023_003DzRQFxRLfAGxNs(_0023_003Dz5PV35Pc_003D: true, printPreviewDlgClientSize, sheets);
	}

	public void Print(bool allSheets = false)
	{
		_0023_003DzRQFxRLfAGxNs(_0023_003Dz5PV35Pc_003D: false, default(Size), allSheets ? Sheets : null);
	}

	public void Print(IList<Sheet> sheets)
	{
		_0023_003DzRQFxRLfAGxNs(_0023_003Dz5PV35Pc_003D: false, default(Size), sheets);
	}

	internal void _0023_003DzRQFxRLfAGxNs(bool _0023_003Dz5PV35Pc_003D, Size _0023_003Dzx2Qdu8dSb6VBSAVPJQ_003D_003D, IList<Sheet> _0023_003DzK5c4ja2Uzt1i)
	{
		if (_0023_003DzK5c4ja2Uzt1i == null || _0023_003DzK5c4ja2Uzt1i.Count < 2)
		{
			_0023_003Dzws3VyglDjXPb(_0023_003Dzx2Qdu8dSb6VBSAVPJQ_003D_003D, _0023_003Dz5PV35Pc_003D, _0023_003DzWrfLNCo_003D: false);
			return;
		}
		_0023_003DzbdLgm9c_003D._0023_003DzVWilOEkLyDxl = true;
		PageSetup(allowMargins: true, showDialog: false, 0);
		Sheet activeSheet = ActiveSheet;
		_0023_003DzbdLgm9c_003D._0023_003DzA3ipzoQ5sbsK = false;
		foreach (Sheet item in _0023_003DzK5c4ja2Uzt1i)
		{
			ActiveSheet = item;
			UpdateBoundingBox();
			_0023_003DzbdLgm9c_003D._0023_003DzA3ipzoQ5sbsK = _0023_003DzbdLgm9c_003D._0023_003Dzuw7Bx3c_003D == _0023_003DzK5c4ja2Uzt1i.Count - 1;
			_0023_003Dzws3VyglDjXPb(_0023_003Dzx2Qdu8dSb6VBSAVPJQ_003D_003D, _0023_003Dz5PV35Pc_003D, _0023_003DzWrfLNCo_003D: false);
			_0023_003DzbdLgm9c_003D._0023_003Dzuw7Bx3c_003D++;
		}
		_0023_003DzbdLgm9c_003D.hKxLbCvKjVpI4dvqv3tjvDsUbXA();
		ActiveSheet = activeSheet;
		UpdateBoundingBox();
	}

	internal override void _0023_003Dzws3VyglDjXPb(Size _0023_003Dzx2Qdu8dSb6VBSAVPJQ_003D_003D, bool _0023_003Dz8Sjn85TIry34, bool _0023_003DzWrfLNCo_003D)
	{
		_0023_003Dz6uL_0024EozYGt7t7F45Ag_003D_003D();
		SaveView(out var saved);
		ZoomFit();
		HiddenLinesViewSettingsEx viewSettings = new HiddenLinesViewSettingsEx(_0023_003DzA4XKvZjCk7rt, this, (!_0023_003DzWrfLNCo_003D) ? hiddenLinesViewType.Window : hiddenLinesViewType.Extents)
		{
			KeepEntityLineWeight = true,
			KeepEntityColor = true,
			FillTexts = true,
			FillRegions = true
		};
		double orthographicScale = ((!_0023_003DzWrfLNCo_003D) ? 1 : 0);
		HiddenLinesViewOnPaper hiddenLinesViewOnPaper = ((!_0023_003Dz8Sjn85TIry34) ? new HiddenLinesViewOnPaper(viewSettings, orthographicScale) : new HiddenLinesViewOnPaperPreview(viewSettings, _0023_003Dzx2Qdu8dSb6VBSAVPJQ_003D_003D, orthographicScale));
		hiddenLinesViewOnPaper.Units = ActiveSheet.Units;
		hiddenLinesViewOnPaper.LineWeightUnits = lineWeightPrintingUnitsType.Millimeters;
		hiddenLinesViewOnPaper.DoWork();
		RestoreView(saved);
	}

	public virtual void SaveFile(string filePath, Design design, FileSerializer fileSerializer = null)
	{
		Document.SaveFile(filePath, design.Document, fileSerializer);
	}

	public virtual void SaveFile(Stream stream, Design design, FileSerializer fileSerializer = null)
	{
		Document.SaveFile(stream, design.Document, fileSerializer);
	}

	public virtual void OpenFile(string filePath, Design design, FileSerializer fileSerializer = null)
	{
		Document.OpenFile(filePath, design.Document, fileSerializer);
	}

	public virtual void OpenFile(Stream stream, Design design, FileSerializer fileSerializer = null)
	{
		Document.OpenFile(stream, design.Document, fileSerializer);
	}

	protected override void OnKeyDown(KeyEventArgs e)
	{
		if (base._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count > 0 && e.KeyData == base.ShortcutKeys.DeleteSelection)
		{
			List<VectorView> list = new List<VectorView>();
			if (_0023_003DzOkc2vqPEJ3pN(base.Entities, new Stack<BlockReference>(), list))
			{
				RegenParams data = new RegenParams(base.Entities);
				CompileParams data2 = new CompileParams(this);
				foreach (VectorView item in list)
				{
					item.Regen(data);
					item.Compile(data2);
				}
			}
		}
		base.OnKeyDown(e);
	}

	internal bool _0023_003DzOkc2vqPEJ3pN(IList<Entity> _0023_003DzKntKeC8_003D, Stack<BlockReference> _0023_003Dzbq3BJR0_003D, IList<VectorView> _0023_003DzD9_00241CY24Mbya)
	{
		bool flag = false;
		for (int num = _0023_003DzKntKeC8_003D.Count - 1; num >= 0; num--)
		{
			Entity entity = _0023_003DzKntKeC8_003D[num];
			if (entity.IsSelected(_0023_003Dzbq3BJR0_003D, selectionStatusType.Permanent))
			{
				_0023_003DzKntKeC8_003D.RemoveAt(num);
				flag = true;
			}
			else if (entity is BlockReference blockReference)
			{
				_0023_003Dzbq3BJR0_003D.Push(blockReference);
				bool flag2 = _0023_003DzOkc2vqPEJ3pN(base.Blocks[blockReference.BlockName].Entities, _0023_003Dzbq3BJR0_003D, _0023_003DzD9_00241CY24Mbya);
				if (flag2 && blockReference is VectorView vectorView)
				{
					vectorView.selectedHdlSegments.Clear();
					_0023_003DzD9_00241CY24Mbya.Add(vectorView);
				}
				flag = flag || flag2;
				_0023_003Dzbq3BJR0_003D.Pop();
			}
		}
		return flag;
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		_0023_003DzyKe_w2ZMKMPn(e.Location);
		_0023_003DzrB4UDXgwpQK0();
		base.OnMouseMove(e);
	}

	private void _0023_003DzrB4UDXgwpQK0()
	{
		if (base.Entities.Any((Entity _0023_003Dz8GBMuoM_003D) => _0023_003Dz8GBMuoM_003D is VectorView vectorView && vectorView.inScope))
		{
			if (base._0023_003DznugYzyWkU3Do != assemblySelectionType.Leaf)
			{
				base._0023_003DznugYzyWkU3Do = assemblySelectionType.Leaf;
			}
		}
		else if (base._0023_003DznugYzyWkU3Do != assemblySelectionType.Branch)
		{
			base._0023_003DznugYzyWkU3Do = assemblySelectionType.Branch;
		}
	}

	private void _0023_003DzyKe_w2ZMKMPn(System.Drawing.Point _0023_003DzUbpRylvVcgm7)
	{
		if (!ScreenToPlane(_0023_003DzUbpRylvVcgm7, Plane.XY, out var intPoint))
		{
			return;
		}
		foreach (Entity entity in base.Entities)
		{
			if (entity is VectorView vectorView)
			{
				bool flag = Utility.PointInRect(intPoint, vectorView.boundingFrameVertices[0], vectorView.boundingFrameVertices[2]);
				if (flag != vectorView.inScope)
				{
					_0023_003DzA4XKvZjCk7rt.Camera.ZBufferData.ResetCapturedView();
				}
				vectorView.inScope = flag;
			}
		}
	}

	internal void _0023_003DzhXHsF9Hmeau3m_pM3g_003D_003D(Rectangle _0023_003DzCiKS5oMdHowF, bool _0023_003Dz_bIfLEkNPFmB, bool _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, bool _0023_003DzUsW18wvfQQpu, ref SelectedItem[] _0023_003Dzz8hA2KsjwaLa)
	{
		if (base._0023_003DznugYzyWkU3Do == assemblySelectionType.Branch)
		{
			if (_0023_003Dzz8hA2KsjwaLa.Length != 0 && _0023_003Dzz8hA2KsjwaLa[0].Item is VectorView vectorView)
			{
				_0023_003DzXVHxU6dYdxpX(_0023_003DzA4XKvZjCk7rt, _0023_003DzCiKS5oMdHowF, _0023_003Dz_bIfLEkNPFmB, new Entity[1] { vectorView }, (_0023_003DzhFBmu_0024RpnRJ7)8, _0023_003DzjXgsro9VxnewpJ8vl_0024FXCSo_003D, _0023_003DzAai34pBQWjIKyoZ60A_003D_003D: false, _0023_003DzCq_00248LrgCN_f9: true, out _0023_003Dzz8hA2KsjwaLa);
			}
			return;
		}
		if (!_0023_003DzUsW18wvfQQpu)
		{
			SelectedItem[] array = _0023_003Dzz8hA2KsjwaLa;
			foreach (SelectedItem selectedItem in array)
			{
				if (selectedItem.Parents.Count > 0 && selectedItem.Parents.Peek() is VectorView vectorView2)
				{
					Entity entity = selectedItem.Item as Entity;
					if (!base.Blocks[vectorView2.BlockName].Entities.Skip(vectorView2.hdlCount).Contains(entity))
					{
						vectorView2.selectedHdlSegments.Add(entity);
					}
				}
			}
		}
		Entity[] array2 = base.Entities.Where((Entity _0023_003DztJCl_0024mM_003D) => _0023_003DztJCl_0024mM_003D is VectorView vectorView3 && vectorView3.inScope).ToArray();
		if (_0023_003DzUsW18wvfQQpu || _0023_003Dzz8hA2KsjwaLa.Length == 0)
		{
			int num = _0023_003Dzz8hA2KsjwaLa.Length;
			Array.Resize(ref _0023_003Dzz8hA2KsjwaLa, num + array2.Length);
			for (int num2 = 0; num2 < array2.Length; num2++)
			{
				SelectedItem selectedItem2 = new SelectedItem(array2[num2]);
				_0023_003Dzz8hA2KsjwaLa[num + num2] = selectedItem2;
			}
		}
	}

	protected override void Draw3D(DrawSceneParams myParams)
	{
		IList<Entity> entities = myParams.Entities;
		if (myParams.RenderContext.Shaders != null)
		{
			foreach (KeyValuePair<shaderType, IShaderTechnique> shader in myParams.RenderContext.Shaders)
			{
				shader.Value.UpdatedInFrame = false;
			}
		}
		Viewport viewport = (Viewport)myParams.Viewport;
		if (_0023_003DzjC4hA2I_003D.isFsaaAvailable)
		{
			_0023_003DzmNZD0Zs_003D.EnableMultisample(_0023_003DzjC4hA2I_003D.AntiAliasing);
		}
		_0023_003DzmNZD0Zs_003D.SetMatrices(null, null);
		viewport.Camera.SetupModelViewProjection(myParams.ZoomRect, setGraphics: true, shadowPass: false, reflection: false, myParams.CameraEyePos, applySceneTransformation: false);
		myParams.ShaderParams = _0023_003DzdfzPZ4BvPfHu(myParams);
		myParams.RenderContext.GetShaderAndEnable(myParams.ShaderParams);
		_0023_003DzmNZD0Zs_003D.UpdateShaders(myParams.ShaderParams);
		viewport._0023_003DzdzRS8TI_003D();
		viewport.Camera.SetProjectionMatrixType(Camera.projectionMatrixType.Standard);
		viewport.Camera.SetupModelView(setGraphics: true, reflection: false, myParams.CameraEyePos, applySceneTransformation: true);
		_0023_003DzXS86eTnj2Efz(_0023_003DzdWWqz40ROLb5Pp383A_003D_003D(_0023_003DzPEEjwoPxhT6e(viewport), myParams.Entities), new FrustumParams(viewport._0023_003DzLK0OwXvAsOsnI9nS_0024Q_003D_003D(_0023_003DzPHqp5dQ_003D: false), this, myParams.Blocks), myParams.Simplify, myParams.isProgressiveDrawing);
		_0023_003DzmNZD0Zs_003D.PushModelView();
		viewport._0023_003DzEoxSq3a9jDkF(myParams.ViewFrame);
		_0023_003DzmNZD0Zs_003D.ClearDepthStencil(myParams.ClearDepthBuffer, stencilBuffer: false, 0);
		_0023_003DzmNZD0Zs_003D.UpdateConstantBufferPerFrame(myParams.ShaderParams);
		_0023_003DzmNZD0Zs_003D.ProcessLightAttributes(shadowPass: false, reflection: false);
		if (ActiveSheet != null && base.IsOpenRootLevel)
		{
			Transformation transform = new Translation(0.0, 0.0, -1.0);
			if (base.CurrentBlockReference != null)
			{
				transform *= viewport.Camera.SceneTransformationInverted;
			}
			_0023_003DzmNZD0Zs_003D.PushModelView();
			_0023_003DzmNZD0Zs_003D.MultMatrixModelView(transform);
			_0023_003Dz70RjsyLYj8P9(_0023_003DzmNZD0Zs_003D);
			_0023_003DzmNZD0Zs_003D.PopModelView();
		}
		_0023_003DzhRqqkpB6YTs_0024_ozB2HRP_0024mU_003D(myParams, myParams.ZBufferOnly, (_0023_003DzARfd93yYb38F)3);
		if (!myParams.isProgressiveDrawing || myParams.isLastBatch)
		{
			((Viewport)myParams.Viewport)._0023_003Dz1aD3FvrMPVZvq2oC0g_003D_003D((Grid._0023_003Dzp2xC_56LDhr6)1, myParams.PlanarReflections, _0023_003DzNwtRJ3cLTrAy());
		}
		_0023_003DzmNZD0Zs_003D.CloseTexture(force: true);
		if (_0023_003DzjC4hA2I_003D.isFsaaAvailable && _0023_003DzjC4hA2I_003D.AntiAliasing)
		{
			_0023_003DzmNZD0Zs_003D.EnableMultisample(enable: false);
		}
		if (!myParams.PlanarReflections)
		{
			_0023_003Dzemj_0024cuX1Dkz_KyAnyw_003D_003D(myParams);
		}
		if (base._0023_003DzK3OaHhra7VrS.Visible)
		{
			_0023_003DzmNZD0Zs_003D.PushModelView();
			Point3D _0023_003Dze4TpmVqI26AF = _0023_003Dz6CMmzY6fHGlL._0023_003Dze4TpmVqI26AF;
			Point3D _0023_003DzD4HjvLi8HsVr = _0023_003Dz6CMmzY6fHGlL._0023_003DzD4HjvLi8HsVr;
			_0023_003DzmNZD0Zs_003D.SetMatrices(viewport.Camera.ProjectionMatrix, viewport.Camera.ModelViewMatrix);
			_0023_003DzmNZD0Zs_003D.TranslateMatrixModelView(_0023_003Dze4TpmVqI26AF.X, _0023_003Dze4TpmVqI26AF.Y, _0023_003Dze4TpmVqI26AF.Z);
			base._0023_003DzK3OaHhra7VrS.Draw(viewport, myParams.RenderContext, myParams.DrawScale, Point3D.Origin, new Point3D(_0023_003DzD4HjvLi8HsVr.X - _0023_003Dze4TpmVqI26AF.X, _0023_003DzD4HjvLi8HsVr.Y - _0023_003Dze4TpmVqI26AF.Y, _0023_003DzD4HjvLi8HsVr.Z - _0023_003Dze4TpmVqI26AF.Z));
			_0023_003DzmNZD0Zs_003D.PopModelView();
		}
		_0023_003DzmNZD0Zs_003D.PopModelView();
		_0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
		myParams.Entities = entities;
	}

	protected override bool PropagateAttributesAndProcessBlockReferenceForSelection(DrawEntitiesParams myParams, Entity ent, GfxAttributesWire originalAttributes, WorkspaceDrawForSelectionCallback callBack)
	{
		((GfxAttributesWire)myParams.DrawParams.Attributes).AssignColorAndLineWeight(originalAttributes);
		if (ent.IsPolygonal())
		{
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		}
		else
		{
			switch (ent.GetPrimitiveTypeForWireframe(myParams.DrawParams))
			{
			case shaderPrimitiveType.Polygon:
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
				break;
			case shaderPrimitiveType.Point:
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLightsThickPoints);
				break;
			default:
				_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLightsThickLines);
				break;
			}
		}
		DrawForSelectionParams drawForSelectionParams = (DrawForSelectionParams)myParams.DrawParams;
		if (myParams.SelectInScope)
		{
			if (myParams.InScope && ((!drawForSelectionParams.LeafSelection && drawForSelectionParams.Parents.Count == _0023_003Dzkm9D6jYtZW1j.Count) || (drawForSelectionParams.LeafSelection && !(ent is BlockReference))))
			{
				SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedItem>(drawForSelectionParams, ent);
			}
		}
		else if (!drawForSelectionParams.InternalSelection && ((!drawForSelectionParams.LeafSelection && drawForSelectionParams.Parents.Count == 0) || (drawForSelectionParams.LeafSelection && !(ent is BlockReference))))
		{
			SetColorDrawForSelectionAndUpdateIdItemsMap<SelectedItem>(drawForSelectionParams, ent);
		}
		if (ent is BlockReference blockReference)
		{
			blockReference.DrawForSelection(myParams, callBack);
			return false;
		}
		((GfxAttributesWire)drawForSelectionParams.Attributes).PropagateColorAndLineWeight(ent, base.Layers.GetItemFast(ent.LayerName));
		ent.SetLineWeight(_0023_003DzmNZD0Zs_003D, ((GfxAttributesWire)drawForSelectionParams.Attributes).LineWeight);
		return true;
	}

	private void _0023_003Dz70RjsyLYj8P9(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		Point3D[] vertices = new Point3D[4]
		{
			new Point3D(0.0, 0.0, -1.0),
			new Point3D(ActiveSheet.Width, 0.0, -1.0),
			new Point3D(ActiveSheet.Width, ActiveSheet.Height, -1.0),
			new Point3D(0.0, ActiveSheet.Height, -1.0)
		};
		_0023_003DzmNZD0Zs_003D.SetColorWireframe(_0023_003DzZxEtupA3qIX5);
		_0023_003DzmNZD0Zs_003D.DrawQuads(vertices, new Vector3D[1] { Vector3D.AxisZ });
	}

	internal override void _0023_003DzEqBQ2waUAbQ7(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024, Entity _0023_003DztJCl_0024mM_003D, ref bool _0023_003DzAYcbN5Y_003D)
	{
		DrawParams drawParams = _0023_003DzCBM7XJK4_5H_0024.DrawParams;
		bool _0023_003Dzl7FZ5_su2I_0024n = (drawParams.Parents.Count <= 0 || !drawParams.Parents.Any(_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DznUv4oF6mIpLP1X7cCho6s6k_003D)) && drawParams.ParentSelected;
		bool _0023_003DzXluM0iA_003D = _0023_003DzlT_tPDs_003D(_0023_003Dzl7FZ5_su2I_0024n, drawParams, _0023_003DztJCl_0024mM_003D);
		drawParams.Selected = (_0023_003DzAYcbN5Y_003D = _0023_003DzJIOQOs_0024rX_pgqV_uZQ_003D_003D(_0023_003DzXluM0iA_003D, drawParams));
		_0023_003DzCBM7XJK4_5H_0024.selectionFound |= drawParams.Selected;
	}

	private bool _0023_003DzXvD0RKuXdFn8(DrawEntitiesParams _0023_003DzCBM7XJK4_5H_0024)
	{
		if (_0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Count > 0)
		{
			if (_0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Peek() is VectorView)
			{
				return true;
			}
			if (_0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Count > 1)
			{
				BlockReference item = _0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Peek();
				_0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Pop();
				BlockReference blockReference = _0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Peek();
				_0023_003DzCBM7XJK4_5H_0024.DrawParams.Parents.Push(item);
				return blockReference is VectorView;
			}
		}
		return false;
	}
}
