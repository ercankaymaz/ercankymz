#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonDataGridView), "ToolboxBitmaps.KryptonDataGridView.bmp")]
[DesignerCategory("code")]
[Description("Display rows and columns of data if a grid you can customize.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonDataGridView : DataGridView
{
	private class ColumnHeaderCache : Dictionary<int, bool>
	{
	}

	private class RowHeaderCache : Dictionary<int, Rectangle>
	{
	}

	private class ToolTipContent : IContentValues
	{
		private string _toolTipText;

		public ToolTipContent(string toolTipText)
		{
			_toolTipText = toolTipText;
		}

		public Image GetImage(PaletteState state)
		{
			return null;
		}

		public Color GetImageTransparentColor(PaletteState state)
		{
			return Color.Empty;
		}

		public string GetShortText()
		{
			return _toolTipText;
		}

		public string GetLongText()
		{
			return string.Empty;
		}
	}

	private static readonly Point _nullCell = new Point(-2, -2);

	private static PropertyInfo _piRTL;

	private static PropertyInfo _piCML;

	private static PropertyInfo _piCG;

	private static MethodInfo _miPTB;

	private static MethodInfo _miGCI;

	private static MethodInfo _miGTTT;

	private static MethodInfo _miGET;

	private static MethodInfo _miATT;

	private static MethodInfo _miGPW;

	private static MethodInfo _miGPH;

	private static FieldInfo _fiLayout;

	private static FieldInfo _fiColumnHeaders;

	private static FieldInfo _fiRowHeaders;

	private static FieldInfo _fiColumnHeadersVisible;

	private static FieldInfo _fiRowHeadersVisible;

	private bool _refresh;

	private bool _refreshAll;

	private bool _layoutDirty;

	private bool _paintTransparent;

	private bool _evalTransparent;

	private Size _lastLayoutSize;

	private IPalette _localPalette;

	private IPalette _palette;

	private IRenderer _renderer;

	private PaletteMode _paletteMode;

	private ViewDrawPanel _drawPanel;

	private ViewManager _viewManager;

	private NeedPaintHandler _needPaintDelegate;

	private SimpleCall _refreshCall;

	private PaletteRedirect _redirector;

	private PaletteDataGridViewRedirect _stateCommon;

	private PaletteDataGridViewAll _stateDisabled;

	private PaletteDataGridViewAll _stateNormal;

	private PaletteDataGridViewHeaders _stateTracking;

	private PaletteDataGridViewHeaders _statePressed;

	private PaletteDataGridViewCells _stateSelected;

	private DataGridViewStyles _gridSyles;

	private Font _columnFont;

	private Font _rowFont;

	private Font _dataCellFont;

	private Padding _columnPadding;

	private Padding _rowPadding;

	private Padding _dataCellPadding;

	private DataGridViewContentAlignment _columnAlign;

	private DataGridViewContentAlignment _rowAlign;

	private DataGridViewContentAlignment _dataCellAlign;

	private Color _columnBackColor;

	private Color _rowBackColor;

	private Color _dataCellBackColor;

	private Color _columnForeColor;

	private Color _rowForeColor;

	private Color _dataCellForeColor;

	private Color _columnSelBackColor;

	private Color _rowSelBackColor;

	private Color _dataCellSelBackColor;

	private Color _columnSelForeColor;

	private Color _rowSelForeColor;

	private Color _dataCellSelForeColor;

	private ShortTextValue _shortTextValue;

	private VisualPopupToolTip _visualPopupToolTip;

	private PaletteBorderInheritForced _borderForced;

	private PaletteDataGridViewBackInherit _backInherit;

	private PaletteDataGridViewContentInherit _contentInherit;

	private ColumnHeaderCache _columnCache;

	private RowHeaderCache _rowCache;

	private Point _cellOver;

	private Point _cellDown;

	private Timer _showTimer;

	private bool _hideOuterBorders;

	private bool _showCellToolTips;

	private string _toolTipText;

	private byte _oldLocation;

	private DataGridViewCell _oldCell;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Color BackgroundColor
	{
		get
		{
			return base.BackgroundColor;
		}
		set
		{
			base.BackgroundColor = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new BorderStyle BorderStyle
	{
		get
		{
			return base.BorderStyle;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataGridViewCellBorderStyle CellBorderStyle
	{
		get
		{
			return base.CellBorderStyle;
		}
		set
		{
			base.CellBorderStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
	{
		get
		{
			return base.ColumnHeadersBorderStyle;
		}
		set
		{
			base.ColumnHeadersBorderStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataGridViewCellStyle ColumnHeadersDefaultCellStyle
	{
		get
		{
			return base.ColumnHeadersDefaultCellStyle;
		}
		set
		{
			base.ColumnHeadersDefaultCellStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataGridViewCellStyle DefaultCellStyle
	{
		get
		{
			return base.DefaultCellStyle;
		}
		set
		{
			base.DefaultCellStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new bool EnableHeadersVisualStyles
	{
		get
		{
			return base.EnableHeadersVisualStyles;
		}
		set
		{
			base.EnableHeadersVisualStyles = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Color GridColor
	{
		get
		{
			return base.GridColor;
		}
		set
		{
			base.GridColor = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataGridViewHeaderBorderStyle RowHeadersBorderStyle
	{
		get
		{
			return base.RowHeadersBorderStyle;
		}
		set
		{
			base.RowHeadersBorderStyle = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataGridViewCellStyle RowHeadersDefaultCellStyle
	{
		get
		{
			return base.RowHeadersDefaultCellStyle;
		}
		set
		{
			base.RowHeadersDefaultCellStyle = value;
		}
	}

	public new bool ShowCellToolTips
	{
		get
		{
			return _showCellToolTips;
		}
		set
		{
			_showCellToolTips = value;
		}
	}

	[Category("Visuals")]
	[Description("Determine if the outer borders of the grid cells are drawn.")]
	[DefaultValue(false)]
	public bool HideOuterBorders
	{
		get
		{
			return _hideOuterBorders;
		}
		set
		{
			if (value != _hideOuterBorders)
			{
				_hideOuterBorders = value;
				PerformNeedPaint(needLayout: false);
			}
		}
	}

	[Category("Visuals")]
	[Description("Palette applied to drawing.")]
	public PaletteMode PaletteMode
	{
		[DebuggerStepThrough]
		get
		{
			return _paletteMode;
		}
		set
		{
			if (_paletteMode != value)
			{
				if (value != PaletteMode.Custom)
				{
					_paletteMode = value;
					_localPalette = null;
					SetPalette(KryptonManager.GetPaletteForMode(_paletteMode));
					OnPaletteChanged(EventArgs.Empty);
					PerformLayout();
				}
			}
		}
	}

	[Category("Visuals")]
	[Description("Custom palette applied to drawing.")]
	[DefaultValue(null)]
	public IPalette Palette
	{
		[DebuggerStepThrough]
		get
		{
			return _localPalette;
		}
		set
		{
			if (_localPalette != value)
			{
				IPalette localPalette = _localPalette;
				SetPalette(value);
				if (value == null)
				{
					_paletteMode = PaletteMode.Global;
					_localPalette = null;
					SetPalette(KryptonManager.GetPaletteForMode(_paletteMode));
				}
				else
				{
					_localPalette = value;
					_paletteMode = PaletteMode.Custom;
				}
				if (localPalette != _localPalette)
				{
					OnPaletteChanged(EventArgs.Empty);
					PerformLayout();
				}
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IRenderer Renderer
	{
		[DebuggerStepThrough]
		get
		{
			return _renderer;
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common data grid view appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled data grid view appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewAll StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal data grid view appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewAll StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Overrides for defining tracking data grid view appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewHeaders StateTracking => _stateTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed data grid view appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewHeaders StatePressed => _statePressed;

	[Category("Visuals")]
	[Description("Overrides for defining selected data grid view appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDataGridViewCells StateSelected => _stateSelected;

	[Category("Visuals")]
	[Description("Set of grid styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public DataGridViewStyles GridStyles => _gridSyles;

	protected ViewManager ViewManager
	{
		[DebuggerStepThrough]
		get
		{
			return _viewManager;
		}
		set
		{
			_viewManager = value;
		}
	}

	protected NeedPaintHandler NeedPaintDelegate
	{
		[DebuggerStepThrough]
		get
		{
			return _needPaintDelegate;
		}
	}

	protected bool NeedTransparentPaint
	{
		get
		{
			if (_evalTransparent)
			{
				_paintTransparent = EvalTransparentPaint();
				_evalTransparent = false;
			}
			return _paintTransparent;
		}
	}

	protected virtual bool EvalInvokePaint => false;

	protected virtual Control TransparentParent => base.Parent;

	internal PaletteRedirect Redirector
	{
		[DebuggerStepThrough]
		get
		{
			return _redirector;
		}
	}

	internal bool RightToLeftInternal
	{
		get
		{
			if (_piRTL == null)
			{
				_piRTL = typeof(DataGridView).GetProperty("RightToLeftInternal", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			}
			return (bool)_piRTL.GetValue(this, null);
		}
	}

	private Graphics CachedGraphics
	{
		get
		{
			if (_piCG == null)
			{
				_piCG = typeof(DataGridView).GetProperty("CachedGraphics", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			}
			return (Graphics)_piCG.GetValue(this, null);
		}
	}

	[Category("Property Changed")]
	[Description("Occurs when the value of the Palette property is changed.")]
	public event EventHandler PaletteChanged;

	public KryptonDataGridView()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, value: true);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		DoubleBuffered = true;
		SetupVisuals();
		SetupViewAndStates();
		SetupDefaults();
		SetupSyncCellStyles();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_showTimer != null)
			{
				_showTimer.Stop();
				_showTimer.Tick -= OnTimerTick;
				_showTimer.Dispose();
				_showTimer = null;
			}
			if (_palette != null)
			{
				_palette.PalettePaint -= OnNeedResyncPaint;
				_palette.ButtonSpecChanged -= OnButtonSpecChanged;
			}
			KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
			SystemEvents.UserPreferenceChanged -= OnUserPreferenceChanged;
			ViewManager.Dispose();
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializePaletteMode()
	{
		return PaletteMode != PaletteMode.Global;
	}

	public void ResetPaletteMode()
	{
		PaletteMode = PaletteMode.Global;
	}

	public void ResetPalette()
	{
		PaletteMode = PaletteMode.Global;
	}

	private bool ShouldSerializeStateCommon()
	{
		return !_stateCommon.IsDefault;
	}

	private bool ShouldSerializeStateDisabled()
	{
		return !_stateDisabled.IsDefault;
	}

	private bool ShouldSerializeStateNormal()
	{
		return !_stateNormal.IsDefault;
	}

	private bool ShouldSerializeStateTracking()
	{
		return !_stateTracking.IsDefault;
	}

	private bool ShouldSerializeStatePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeStateSelected()
	{
		return !_stateSelected.IsDefault;
	}

	public void PerformNeedPaint(bool needLayout)
	{
		OnNeedPaint(this, new NeedLayoutEventArgs(needLayout));
	}

	public virtual PaletteState GetCellTriple(DataGridViewElementStates state, int rowIndex, int columnIndex, out IPaletteBack paletteBack, out IPaletteBorder paletteBorder, out IPaletteContent paletteContent)
	{
		PaletteState paletteState;
		if (!base.Enabled)
		{
			paletteState = PaletteState.Disabled;
		}
		else
		{
			paletteState = PaletteState.Normal;
			if ((state & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
			{
				paletteState = PaletteState.CheckedNormal;
			}
			else if (rowIndex < 0 || columnIndex < 0)
			{
				Point point = new Point(columnIndex, rowIndex);
				if (point.Equals(_cellDown))
				{
					if (point.Equals(_cellOver))
					{
						paletteState = PaletteState.Pressed;
					}
				}
				else if (point.Equals(_cellOver))
				{
					paletteState = PaletteState.Tracking;
				}
			}
		}
		if (rowIndex >= 0 && columnIndex >= 0)
		{
			switch (paletteState)
			{
			default:
				paletteBack = StateNormal.DataCell.Back;
				paletteBorder = StateNormal.DataCell.Border;
				paletteContent = StateNormal.DataCell.Content;
				break;
			case PaletteState.Disabled:
				paletteBack = StateDisabled.DataCell.Back;
				paletteBorder = StateDisabled.DataCell.Border;
				paletteContent = StateDisabled.DataCell.Content;
				break;
			case PaletteState.CheckedNormal:
				paletteBack = StateSelected.DataCell.Back;
				paletteBorder = StateSelected.DataCell.Border;
				paletteContent = StateSelected.DataCell.Content;
				break;
			}
		}
		else if (rowIndex < 0)
		{
			switch (paletteState)
			{
			default:
				paletteBack = StateNormal.HeaderColumn.Back;
				paletteBorder = StateNormal.HeaderColumn.Border;
				paletteContent = StateNormal.HeaderColumn.Content;
				break;
			case PaletteState.Disabled:
				paletteBack = StateDisabled.HeaderColumn.Back;
				paletteBorder = StateDisabled.HeaderColumn.Border;
				paletteContent = StateDisabled.HeaderColumn.Content;
				break;
			case PaletteState.Tracking:
				paletteBack = StateTracking.HeaderColumn.Back;
				paletteBorder = StateTracking.HeaderColumn.Border;
				paletteContent = StateTracking.HeaderColumn.Content;
				break;
			case PaletteState.Pressed:
				paletteBack = StatePressed.HeaderColumn.Back;
				paletteBorder = StatePressed.HeaderColumn.Border;
				paletteContent = StatePressed.HeaderColumn.Content;
				break;
			case PaletteState.CheckedNormal:
				paletteBack = StateSelected.HeaderColumn.Back;
				paletteBorder = StateSelected.HeaderColumn.Border;
				paletteContent = StateSelected.HeaderColumn.Content;
				break;
			}
		}
		else
		{
			switch (paletteState)
			{
			default:
				paletteBack = StateNormal.HeaderRow.Back;
				paletteBorder = StateNormal.HeaderRow.Border;
				paletteContent = StateNormal.HeaderRow.Content;
				break;
			case PaletteState.Disabled:
				paletteBack = StateDisabled.HeaderRow.Back;
				paletteBorder = StateDisabled.HeaderRow.Border;
				paletteContent = StateDisabled.HeaderRow.Content;
				break;
			case PaletteState.Tracking:
				paletteBack = StateTracking.HeaderRow.Back;
				paletteBorder = StateTracking.HeaderRow.Border;
				paletteContent = StateTracking.HeaderRow.Content;
				break;
			case PaletteState.Pressed:
				paletteBack = StatePressed.HeaderRow.Back;
				paletteBorder = StatePressed.HeaderRow.Border;
				paletteContent = StatePressed.HeaderRow.Content;
				break;
			case PaletteState.CheckedNormal:
				paletteBack = StateSelected.HeaderRow.Back;
				paletteBorder = StateSelected.HeaderRow.Border;
				paletteContent = StateSelected.HeaderRow.Content;
				break;
			}
		}
		return paletteState;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public ViewManager GetViewManager()
	{
		return _viewManager;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public IPalette GetResolvedPalette()
	{
		return _palette;
	}

	protected void OnNeedResyncPaint(object sender, NeedLayoutEventArgs e)
	{
		SyncCellStylesWithPalette();
		OnNeedPaint(sender, e);
	}

	protected void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		_evalTransparent = true;
		if (e.NeedLayout)
		{
			_layoutDirty = true;
		}
		if (base.IsHandleCreated && (!_refreshAll || !e.InvalidRect.IsEmpty))
		{
			if (e.InvalidRect.IsEmpty)
			{
				_refreshAll = true;
				Invalidate();
			}
			else
			{
				Invalidate(e.InvalidRect);
			}
			if (!_refresh && EvalInvokePaint)
			{
				BeginInvoke(_refreshCall);
			}
			_refresh = true;
		}
	}

	protected virtual void OnPaletteChanged(EventArgs e)
	{
		Redirector.Target = _palette;
		OnNeedPaint(Palette, new NeedLayoutEventArgs(needLayout: true));
		if (this.PaletteChanged != null)
		{
			this.PaletteChanged(this, e);
		}
	}

	protected virtual bool EvalTransparentPaint()
	{
		if (ViewManager != null)
		{
			return ViewManager.EvalTransparentPaint(_renderer);
		}
		return false;
	}

	protected virtual void OnButtonSpecChanged(object sender, EventArgs e)
	{
		Debug.Assert(e != null);
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
	}

	protected override void OnPaintBackground(PaintEventArgs pevent)
	{
	}

	protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
	{
		_cellOver = new Point(e.ColumnIndex, e.RowIndex);
		base.OnCellMouseEnter(e);
	}

	protected override void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
	{
		DataGridViewCell cellInternal = GetCellInternal(e.ColumnIndex, e.RowIndex);
		byte b = CurrentMouseLocation(cellInternal);
		if (cellInternal is DataGridViewRowHeaderCell && _oldCell == cellInternal)
		{
			b = _oldLocation;
		}
		base.OnCellMouseMove(e);
		byte b2 = UpdateLocationForRowErrors(e, cellInternal, CurrentMouseLocation(cellInternal));
		if (cellInternal is DataGridViewRowHeaderCell)
		{
			_oldLocation = b2;
			_oldCell = cellInternal;
		}
		else
		{
			_oldCell = null;
		}
		switch (b)
		{
		case 0:
			if (b2 != 1)
			{
				CellErrorAreaMouseEnterInternal(cellInternal);
			}
			CellDataAreaMouseEnterInternal(cellInternal);
			break;
		case 1:
			if (b2 == 2)
			{
				CellAreaMouseLeaveInternal();
				CellErrorAreaMouseEnterInternal(cellInternal);
			}
			break;
		case 2:
			if (b2 == 1)
			{
				CellAreaMouseLeaveInternal();
				CellDataAreaMouseEnterInternal(cellInternal);
			}
			break;
		}
	}

	protected override void OnCellMouseLeave(DataGridViewCellEventArgs e)
	{
		byte b = CurrentMouseLocation(GetCellInternal(e.ColumnIndex, e.RowIndex));
		byte b2 = b;
		if ((uint)(b2 - 1) <= 1u)
		{
			CellAreaMouseLeaveInternal();
		}
		_cellOver = _nullCell;
		base.OnCellMouseLeave(e);
	}

	protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
	{
		_cellDown = new Point(e.ColumnIndex, e.RowIndex);
		if (_cellDown.X == -1 || _cellDown.Y == -1)
		{
			DoubleBuffered = false;
		}
		base.OnCellMouseDown(e);
	}

	protected override void OnCellMouseUp(DataGridViewCellMouseEventArgs e)
	{
		_cellDown = _nullCell;
		if (!DoubleBuffered)
		{
			DoubleBuffered = true;
		}
		base.OnCellMouseUp(e);
	}

	protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
	{
		CellAreaMouseLeaveInternal();
		base.OnEditingControlShowing(e);
	}

	protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
	{
		IPaletteBack paletteBack;
		IPaletteBorder paletteBorder;
		IPaletteContent paletteContent;
		PaletteState cellTriple = GetCellTriple(e.State, e.RowIndex, e.ColumnIndex, out paletteBack, out paletteBorder, out paletteContent);
		try
		{
			int num = _contentInherit.GetContentShortTextFont(cellTriple).Height;
		}
		catch
		{
			SyncCellStylesWithPalette();
		}
		bool rightToLeftInternal = RightToLeftInternal;
		Rectangle rectangle = new Rectangle(0, 0, e.CellBounds.Width, e.CellBounds.Height);
		using (Bitmap image = new Bitmap(e.CellBounds.Width, e.CellBounds.Height, e.Graphics))
		{
			using Graphics graphics = Graphics.FromImage(image);
			using RenderContext context = new RenderContext(this, graphics, rectangle, _renderer);
			_borderForced.SetInherit(paletteBorder);
			_borderForced.MaxBorderEdges = GetCellMaxBorderEdges(e.CellBounds, e.ColumnIndex, e.RowIndex);
			Padding borderRawPadding = _renderer.RenderStandardBorder.GetBorderRawPadding(_borderForced, cellTriple, VisualOrientation.Top);
			GraphicsPath backPath = _renderer.RenderStandardBorder.GetBackPath(context, rectangle, _borderForced, VisualOrientation.Top, cellTriple);
			Rectangle rect = CommonHelper.ApplyPadding(VisualOrientation.Top, rectangle, borderRawPadding);
			_backInherit.SetInherit(paletteBack, e.CellStyle);
			IDisposable disposable = _renderer.RenderStandardBack.DrawBack(context, rect, backPath, _backInherit, VisualOrientation.Top, cellTriple, null);
			if (disposable != null)
			{
				disposable.Dispose();
				disposable = null;
			}
			_renderer.RenderStandardBorder.DrawBorder(context, rectangle, _borderForced, VisualOrientation.Top, cellTriple);
			backPath.Dispose();
			if (e.RowIndex == -1 && e.ColumnIndex >= 0)
			{
				if (base.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection != SortOrder.None)
				{
					rectangle = _renderer.RenderGlyph.DrawGridSortGlyph(context, base.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection, rectangle, paletteContent, cellTriple, rightToLeftInternal);
				}
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex == -1)
			{
				GridRowGlyph gridRowGlyph = GridRowGlyph.None;
				if (base.CurrentCellAddress.Y == e.RowIndex)
				{
					gridRowGlyph = (base.VirtualMode ? ((base.IsCurrentRowDirty && base.ShowEditingIcon) ? GridRowGlyph.Pencil : ((base.NewRowIndex != e.RowIndex) ? GridRowGlyph.Arrow : GridRowGlyph.ArrowStar)) : ((base.IsCurrentCellDirty && base.ShowEditingIcon) ? GridRowGlyph.Pencil : ((base.NewRowIndex != e.RowIndex) ? GridRowGlyph.Arrow : GridRowGlyph.ArrowStar)));
				}
				else if (base.NewRowIndex == e.RowIndex)
				{
					gridRowGlyph = GridRowGlyph.Star;
				}
				if (gridRowGlyph != GridRowGlyph.None)
				{
					rectangle = _renderer.RenderGlyph.DrawGridRowGlyph(context, gridRowGlyph, rectangle, paletteContent, cellTriple, rightToLeftInternal);
				}
				if (base.ShowRowErrors && !string.IsNullOrEmpty(base.Rows[e.RowIndex].ErrorText))
				{
					Rectangle rectangle2 = rectangle;
					rectangle = _renderer.RenderGlyph.DrawGridErrorGlyph(context, rectangle, cellTriple, rightToLeftInternal);
					Rectangle value = new Rectangle(rectangle.Right + 1, rectangle.Top, rectangle2.Width - rectangle.Width, rectangle.Height);
					if (_rowCache.ContainsKey(e.RowIndex))
					{
						_rowCache[e.RowIndex] = value;
					}
					else
					{
						_rowCache.Add(e.RowIndex, value);
					}
				}
				else if (_rowCache.ContainsKey(e.RowIndex))
				{
					_rowCache.Remove(e.RowIndex);
				}
			}
			else if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && base.ShowCellErrors && !string.IsNullOrEmpty(base.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText))
			{
				rectangle = _renderer.RenderGlyph.DrawGridErrorGlyph(context, rectangle, cellTriple, rightToLeftInternal);
			}
			if ((e.PaintParts & DataGridViewPaintParts.ContentForeground) == DataGridViewPaintParts.ContentForeground || (e.PaintParts & DataGridViewPaintParts.ContentBackground) == DataGridViewPaintParts.ContentBackground)
			{
				if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
				{
					e.Graphics.DrawImage(image, e.CellBounds.Location);
					e.Paint(e.ClipBounds, e.PaintParts & (DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.ContentForeground));
				}
				else
				{
					_contentInherit.SetInherit(paletteContent, e.CellStyle);
					if (e.FormattedValue != null)
					{
						_shortTextValue.ShortText = e.FormattedValue.ToString();
						using ViewLayoutContext context2 = new ViewLayoutContext(this, _renderer);
						if (e.RowIndex == -1 && e.ColumnIndex != -1)
						{
							Size contentPreferredSize = _renderer.RenderStandardContent.GetContentPreferredSize(context2, _contentInherit, _shortTextValue, VisualOrientation.Top, cellTriple, composition: false);
							bool value2 = contentPreferredSize.Width <= rectangle.Width && contentPreferredSize.Height <= rectangle.Height;
							if (_columnCache.ContainsKey(e.ColumnIndex))
							{
								_columnCache[e.ColumnIndex] = value2;
							}
							else
							{
								_columnCache.Add(e.ColumnIndex, value2);
							}
						}
						using IDisposable memento = _renderer.RenderStandardContent.LayoutContent(context2, rectangle, _contentInherit, _shortTextValue, VisualOrientation.Top, cellTriple, composition: false);
						_renderer.RenderStandardContent.DrawContent(context, rectangle, _contentInherit, memento, VisualOrientation.Top, cellTriple, composition: false, allowFocusRect: true);
					}
					e.Graphics.DrawImage(image, e.CellBounds.Location);
				}
			}
			else
			{
				e.Graphics.DrawImage(image, e.CellBounds.Location);
			}
		}
		if ((e.PaintParts & DataGridViewPaintParts.Focus) == DataGridViewPaintParts.Focus && ShowFocusCues && Focused && e.ColumnIndex >= 0 && e.RowIndex >= 0 && base.CurrentCellAddress.X == e.ColumnIndex && base.CurrentCellAddress.Y == e.RowIndex)
		{
			Rectangle cellBounds = e.CellBounds;
			cellBounds.Width--;
			cellBounds.Height--;
			if (rightToLeftInternal)
			{
				cellBounds.X++;
			}
			ControlPaint.DrawFocusRectangle(e.Graphics, cellBounds, Color.Empty, paletteContent.GetContentShortTextColor1(cellTriple));
		}
		e.Handled = true;
		base.OnCellPainting(e);
	}

	protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			if (_layoutDirty && !base.Size.Equals(_lastLayoutSize))
			{
				ViewManagerLayout();
			}
			PaintTransparentBackground(graphics, clipBounds);
			using (RenderContext context = new RenderContext(this, graphics, clipBounds, Renderer))
			{
				ViewManager.Paint(context);
			}
			_refresh = false;
			_refreshAll = false;
		}
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		_drawPanel.SetPalettes(base.Enabled ? _stateNormal.Background : _stateDisabled.Background);
		_drawPanel.Enabled = base.Enabled;
		OnNeedResyncPaint(this, new NeedLayoutEventArgs(needLayout: true));
		base.OnEnabledChanged(e);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		ViewManagerLayout();
		base.OnLayout(levent);
	}

	internal void SyncStyles()
	{
		_stateCommon.SetGridStyles(_gridSyles.StyleColumn, _gridSyles.StyleRow, _gridSyles.StyleDataCells);
		_stateCommon.BackStyle = _gridSyles.StyleBackground;
		SyncCellStylesWithPalette();
	}

	private void SetupVisuals()
	{
		_refreshCall = OnPerformRefresh;
		_needPaintDelegate = OnNeedResyncPaint;
		_layoutDirty = true;
		_evalTransparent = true;
		_lastLayoutSize = Size.Empty;
		_localPalette = null;
		SetPalette(KryptonManager.CurrentGlobalPalette);
		_paletteMode = PaletteMode.Global;
		_redirector = new PaletteRedirect(_palette);
		KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;
		SystemEvents.UserPreferenceChanged += OnUserPreferenceChanged;
	}

	private void SetupViewAndStates()
	{
		_stateCommon = new PaletteDataGridViewRedirect(_redirector, NeedPaintDelegate);
		_stateDisabled = new PaletteDataGridViewAll(_stateCommon, NeedPaintDelegate);
		_stateNormal = new PaletteDataGridViewAll(_stateCommon, NeedPaintDelegate);
		_stateTracking = new PaletteDataGridViewHeaders(_stateCommon, NeedPaintDelegate);
		_statePressed = new PaletteDataGridViewHeaders(_stateCommon, NeedPaintDelegate);
		_stateSelected = new PaletteDataGridViewCells(_stateCommon, NeedPaintDelegate);
		_drawPanel = new ViewDrawPanel(_stateNormal.Background);
		ViewManager = new ViewManager(this, _drawPanel);
	}

	private void SetupDefaults()
	{
		_shortTextValue = new ShortTextValue();
		_borderForced = new PaletteBorderInheritForced(null);
		_backInherit = new PaletteDataGridViewBackInherit();
		_contentInherit = new PaletteDataGridViewContentInherit();
		_gridSyles = new DataGridViewStyles(this);
		_columnCache = new ColumnHeaderCache();
		_rowCache = new RowHeaderCache();
		_showTimer = new Timer();
		_showTimer.Interval = 500;
		_showTimer.Tick += OnTimerTick;
		_cellDown = _nullCell;
		_cellOver = _nullCell;
		_hideOuterBorders = false;
		_showCellToolTips = true;
		base.BorderStyle = BorderStyle.None;
		base.ShowCellToolTips = false;
	}

	private void SetupSyncCellStyles()
	{
		_columnFont = ColumnHeadersDefaultCellStyle.Font;
		_rowFont = RowHeadersDefaultCellStyle.Font;
		_dataCellFont = DefaultCellStyle.Font;
		_columnPadding = ColumnHeadersDefaultCellStyle.Padding;
		_rowPadding = RowHeadersDefaultCellStyle.Padding;
		_dataCellPadding = DefaultCellStyle.Padding;
		_columnAlign = ColumnHeadersDefaultCellStyle.Alignment;
		_rowAlign = RowHeadersDefaultCellStyle.Alignment;
		_dataCellAlign = DefaultCellStyle.Alignment;
		_columnBackColor = ColumnHeadersDefaultCellStyle.BackColor;
		_columnForeColor = ColumnHeadersDefaultCellStyle.ForeColor;
		_columnSelBackColor = ColumnHeadersDefaultCellStyle.SelectionBackColor;
		_columnSelForeColor = ColumnHeadersDefaultCellStyle.SelectionForeColor;
		_rowBackColor = RowHeadersDefaultCellStyle.BackColor;
		_rowForeColor = RowHeadersDefaultCellStyle.ForeColor;
		_rowSelBackColor = RowHeadersDefaultCellStyle.SelectionBackColor;
		_rowSelForeColor = RowHeadersDefaultCellStyle.SelectionForeColor;
		_dataCellBackColor = DefaultCellStyle.BackColor;
		_dataCellForeColor = DefaultCellStyle.ForeColor;
		_dataCellSelBackColor = DefaultCellStyle.SelectionBackColor;
		_dataCellSelForeColor = DefaultCellStyle.SelectionForeColor;
		SyncCellStylesWithPalette();
		StateCommon.HeaderColumn.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateCommon.HeaderRow.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateCommon.DataCell.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateNormal.HeaderColumn.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateNormal.HeaderRow.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateNormal.DataCell.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateSelected.HeaderColumn.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateSelected.HeaderRow.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateSelected.DataCell.Content.SyncPropertyChanged += OnSyncPropertyChanged;
		StateNormal.HeaderColumn.Back.PropertyChanged += OnSyncBackPropertyChanged;
		StateNormal.HeaderRow.Back.PropertyChanged += OnSyncBackPropertyChanged;
		StateNormal.DataCell.Back.PropertyChanged += OnSyncBackPropertyChanged;
		StateSelected.HeaderColumn.Back.PropertyChanged += OnSyncBackPropertyChanged;
		StateSelected.HeaderRow.Back.PropertyChanged += OnSyncBackPropertyChanged;
		StateSelected.DataCell.Back.PropertyChanged += OnSyncBackPropertyChanged;
	}

	private void SyncCellStylesWithPalette()
	{
		if (StateCommon != null)
		{
			SyncFontCellStylesWithPalette();
			SyncPaddingCellStylesWithPalette();
			SyncAlignmentCellStylesWithPalette();
			SyncBackColorCellStylesWithPalette();
			SyncSelBackColorCellStylesWithPalette();
			SyncForeColorCellStylesWithPalette();
			SyncSelForeColorCellStylesWithPalette();
		}
	}

	private void SyncFontCellStylesWithPalette()
	{
		PaletteState paletteState = ((!base.Enabled) ? PaletteState.Disabled : PaletteState.Normal);
		if (ColumnHeadersDefaultCellStyle.Font == null || ColumnHeadersDefaultCellStyle.Font.Equals(_columnFont))
		{
			_columnFont = StateCommon.HeaderColumn.Content.Font;
			if (_columnFont == null)
			{
				_columnFont = StateCommon.HeaderColumn.Content.GetContentShortTextFont(paletteState);
			}
			ColumnHeadersDefaultCellStyle.Font = _columnFont;
		}
		if (RowHeadersDefaultCellStyle.Font == null || RowHeadersDefaultCellStyle.Font.Equals(_rowFont))
		{
			_rowFont = StateCommon.HeaderRow.Content.Font;
			if (_rowFont == null)
			{
				_rowFont = StateCommon.HeaderRow.Content.GetContentShortTextFont(paletteState);
			}
			RowHeadersDefaultCellStyle.Font = _rowFont;
		}
		if (DefaultCellStyle.Font == null || DefaultCellStyle.Font.Equals(_dataCellFont))
		{
			_dataCellFont = StateCommon.DataCell.Content.Font;
			if (_dataCellFont == null)
			{
				_dataCellFont = StateCommon.DataCell.Content.GetContentShortTextFont(paletteState);
			}
			DefaultCellStyle.Font = _dataCellFont;
		}
	}

	private void SyncPaddingCellStylesWithPalette()
	{
		PaletteState paletteState = ((!base.Enabled) ? PaletteState.Disabled : PaletteState.Normal);
		if (ColumnHeadersDefaultCellStyle.Padding.Equals(_columnPadding))
		{
			_columnPadding = StateCommon.HeaderColumn.Content.Padding;
			if (_columnPadding.Equals(CommonHelper.InheritPadding))
			{
				_columnPadding = StateCommon.HeaderColumn.Content.GetContentPadding(paletteState);
			}
			ColumnHeadersDefaultCellStyle.Padding = _columnPadding;
		}
		if (RowHeadersDefaultCellStyle.Padding.Equals(_rowPadding))
		{
			_rowPadding = StateCommon.HeaderRow.Content.Padding;
			if (_rowPadding.Equals(CommonHelper.InheritPadding))
			{
				_rowPadding = StateCommon.HeaderRow.Content.GetContentPadding(paletteState);
			}
			RowHeadersDefaultCellStyle.Padding = _rowPadding;
		}
		if (DefaultCellStyle.Padding.Equals(_dataCellPadding))
		{
			_dataCellPadding = StateCommon.DataCell.Content.Padding;
			if (_dataCellPadding.Equals(CommonHelper.InheritPadding))
			{
				_dataCellPadding = StateCommon.DataCell.Content.GetContentPadding(paletteState);
			}
			DefaultCellStyle.Padding = _dataCellPadding;
		}
	}

	private void SyncAlignmentCellStylesWithPalette()
	{
		PaletteState paletteState = ((!base.Enabled) ? PaletteState.Disabled : PaletteState.Normal);
		if (ColumnHeadersDefaultCellStyle.Alignment == _columnAlign)
		{
			PaletteRelativeAlign paletteRelativeAlign = StateCommon.HeaderColumn.Content.TextH;
			PaletteRelativeAlign paletteRelativeAlign2 = StateCommon.HeaderColumn.Content.TextV;
			if (paletteRelativeAlign == PaletteRelativeAlign.Inherit)
			{
				paletteRelativeAlign = StateCommon.HeaderColumn.Content.GetContentShortTextH(paletteState);
			}
			if (paletteRelativeAlign2 == PaletteRelativeAlign.Inherit)
			{
				paletteRelativeAlign2 = StateCommon.HeaderColumn.Content.GetContentShortTextV(paletteState);
			}
			_columnAlign = RelativeToAlign(paletteRelativeAlign, paletteRelativeAlign2);
			ColumnHeadersDefaultCellStyle.Alignment = _columnAlign;
		}
		if (RowHeadersDefaultCellStyle.Alignment == _rowAlign)
		{
			PaletteRelativeAlign paletteRelativeAlign3 = StateCommon.HeaderRow.Content.TextH;
			PaletteRelativeAlign paletteRelativeAlign4 = StateCommon.HeaderRow.Content.TextV;
			if (paletteRelativeAlign3 == PaletteRelativeAlign.Inherit)
			{
				paletteRelativeAlign3 = StateCommon.HeaderRow.Content.GetContentShortTextH(paletteState);
			}
			if (paletteRelativeAlign4 == PaletteRelativeAlign.Inherit)
			{
				paletteRelativeAlign4 = StateCommon.HeaderRow.Content.GetContentShortTextV(paletteState);
			}
			_rowAlign = RelativeToAlign(paletteRelativeAlign3, paletteRelativeAlign4);
			RowHeadersDefaultCellStyle.Alignment = _rowAlign;
		}
		if (DefaultCellStyle.Alignment == _dataCellAlign)
		{
			PaletteRelativeAlign paletteRelativeAlign5 = StateCommon.DataCell.Content.TextH;
			PaletteRelativeAlign paletteRelativeAlign6 = StateCommon.DataCell.Content.TextV;
			if (paletteRelativeAlign5 == PaletteRelativeAlign.Inherit)
			{
				paletteRelativeAlign5 = StateCommon.DataCell.Content.GetContentShortTextH(paletteState);
			}
			if (paletteRelativeAlign6 == PaletteRelativeAlign.Inherit)
			{
				paletteRelativeAlign6 = StateCommon.DataCell.Content.GetContentShortTextV(paletteState);
			}
			_dataCellAlign = RelativeToAlign(paletteRelativeAlign5, paletteRelativeAlign6);
			DefaultCellStyle.Alignment = _dataCellAlign;
		}
	}

	private void SyncBackColorCellStylesWithPalette()
	{
		PaletteState paletteState = ((!base.Enabled) ? PaletteState.Disabled : PaletteState.Normal);
		if (ColumnHeadersDefaultCellStyle.BackColor == Color.Empty || ColumnHeadersDefaultCellStyle.BackColor == _columnBackColor)
		{
			_columnBackColor = StateNormal.HeaderColumn.Back.Color1;
			if (_columnBackColor == Color.Empty)
			{
				_columnBackColor = StateNormal.HeaderColumn.Back.GetBackColor1(paletteState);
			}
			ColumnHeadersDefaultCellStyle.BackColor = _columnBackColor;
		}
		if (RowHeadersDefaultCellStyle.BackColor == Color.Empty || RowHeadersDefaultCellStyle.BackColor == _rowBackColor)
		{
			_rowBackColor = StateNormal.HeaderRow.Back.Color1;
			if (_rowBackColor == Color.Empty)
			{
				_rowBackColor = StateNormal.HeaderRow.Back.GetBackColor1(paletteState);
			}
			RowHeadersDefaultCellStyle.BackColor = _rowBackColor;
		}
		if (DefaultCellStyle.BackColor == Color.Empty || DefaultCellStyle.BackColor == _dataCellBackColor)
		{
			_dataCellBackColor = StateNormal.DataCell.Back.Color1;
			if (_dataCellBackColor == Color.Empty)
			{
				_dataCellBackColor = StateNormal.DataCell.Back.GetBackColor1(paletteState);
			}
			DefaultCellStyle.BackColor = _dataCellBackColor;
		}
	}

	private void SyncSelBackColorCellStylesWithPalette()
	{
		PaletteState paletteState = ((!base.Enabled) ? PaletteState.Disabled : PaletteState.CheckedNormal);
		if (ColumnHeadersDefaultCellStyle.SelectionBackColor == Color.Empty || ColumnHeadersDefaultCellStyle.SelectionBackColor == _columnSelBackColor)
		{
			_columnSelBackColor = StateSelected.HeaderColumn.Back.Color1;
			if (_columnSelBackColor == Color.Empty)
			{
				_columnSelBackColor = StateSelected.HeaderColumn.Back.GetBackColor1(paletteState);
			}
			ColumnHeadersDefaultCellStyle.SelectionBackColor = _columnSelBackColor;
		}
		if (RowHeadersDefaultCellStyle.SelectionBackColor == Color.Empty || RowHeadersDefaultCellStyle.SelectionBackColor == _rowSelBackColor)
		{
			_rowSelBackColor = StateSelected.HeaderRow.Back.Color1;
			if (_rowSelBackColor == Color.Empty)
			{
				_rowSelBackColor = StateSelected.HeaderRow.Back.GetBackColor1(paletteState);
			}
			RowHeadersDefaultCellStyle.SelectionBackColor = _rowSelBackColor;
		}
		if (DefaultCellStyle.SelectionBackColor == Color.Empty || DefaultCellStyle.SelectionBackColor == _dataCellSelBackColor)
		{
			_dataCellSelBackColor = StateSelected.DataCell.Back.Color1;
			if (_dataCellSelBackColor == Color.Empty)
			{
				_dataCellSelBackColor = StateSelected.DataCell.Back.GetBackColor1(paletteState);
			}
			DefaultCellStyle.SelectionBackColor = _dataCellSelBackColor;
		}
	}

	private void SyncForeColorCellStylesWithPalette()
	{
		PaletteState paletteState = ((!base.Enabled) ? PaletteState.Disabled : PaletteState.Normal);
		if (ColumnHeadersDefaultCellStyle.ForeColor == Color.Empty || ColumnHeadersDefaultCellStyle.ForeColor == _columnForeColor)
		{
			_columnForeColor = StateNormal.HeaderColumn.Content.Color1;
			if (_columnForeColor == Color.Empty)
			{
				_columnForeColor = StateNormal.HeaderColumn.Content.GetContentShortTextColor1(paletteState);
			}
			ColumnHeadersDefaultCellStyle.ForeColor = _columnForeColor;
		}
		if (RowHeadersDefaultCellStyle.ForeColor == Color.Empty || RowHeadersDefaultCellStyle.ForeColor == _rowForeColor)
		{
			_rowForeColor = StateNormal.HeaderRow.Content.Color1;
			if (_rowForeColor == Color.Empty)
			{
				_rowForeColor = StateNormal.HeaderRow.Content.GetContentShortTextColor1(paletteState);
			}
			RowHeadersDefaultCellStyle.ForeColor = _rowForeColor;
		}
		if (DefaultCellStyle.ForeColor == Color.Empty || DefaultCellStyle.ForeColor == _dataCellForeColor)
		{
			_dataCellForeColor = StateNormal.DataCell.Content.Color1;
			if (_dataCellForeColor == Color.Empty)
			{
				_dataCellForeColor = StateNormal.DataCell.Content.GetContentShortTextColor1(paletteState);
			}
			DefaultCellStyle.ForeColor = _dataCellForeColor;
		}
	}

	private void SyncSelForeColorCellStylesWithPalette()
	{
		PaletteState paletteState = ((!base.Enabled) ? PaletteState.Disabled : PaletteState.CheckedNormal);
		if (ColumnHeadersDefaultCellStyle.SelectionForeColor == Color.Empty || ColumnHeadersDefaultCellStyle.SelectionForeColor == _columnSelForeColor)
		{
			_columnSelForeColor = StateSelected.HeaderColumn.Content.Color1;
			if (_columnSelForeColor == Color.Empty)
			{
				_columnSelForeColor = StateSelected.HeaderColumn.Content.GetContentShortTextColor1(paletteState);
			}
			ColumnHeadersDefaultCellStyle.SelectionForeColor = _columnSelForeColor;
		}
		if (RowHeadersDefaultCellStyle.SelectionForeColor == Color.Empty || RowHeadersDefaultCellStyle.SelectionForeColor == _rowSelForeColor)
		{
			_rowSelForeColor = StateSelected.HeaderRow.Content.Color1;
			if (_rowSelForeColor == Color.Empty)
			{
				_rowSelForeColor = StateSelected.HeaderRow.Content.GetContentShortTextColor1(paletteState);
			}
			RowHeadersDefaultCellStyle.SelectionForeColor = _rowSelForeColor;
		}
		if (DefaultCellStyle.SelectionForeColor == Color.Empty || DefaultCellStyle.SelectionForeColor == _dataCellSelForeColor)
		{
			_dataCellSelForeColor = StateSelected.DataCell.Content.Color1;
			if (_dataCellSelForeColor == Color.Empty)
			{
				_dataCellSelForeColor = StateSelected.DataCell.Content.GetContentShortTextColor1(paletteState);
			}
			DefaultCellStyle.SelectionForeColor = _dataCellSelForeColor;
		}
	}

	private byte UpdateLocationForRowErrors(DataGridViewCellMouseEventArgs e, DataGridViewCell cell, byte location)
	{
		if (cell is DataGridViewRowHeaderCell && location == 1 && _rowCache.ContainsKey(e.RowIndex) && _rowCache[e.RowIndex].Contains(new Point(e.X, e.Y)))
		{
			location = 2;
		}
		return location;
	}

	private DataGridViewContentAlignment RelativeToAlign(PaletteRelativeAlign textH, PaletteRelativeAlign textV)
	{
		switch (textH)
		{
		case PaletteRelativeAlign.Near:
			switch (textV)
			{
			case PaletteRelativeAlign.Near:
				return DataGridViewContentAlignment.TopLeft;
			case PaletteRelativeAlign.Center:
				return DataGridViewContentAlignment.MiddleLeft;
			case PaletteRelativeAlign.Far:
				return DataGridViewContentAlignment.BottomLeft;
			}
			break;
		case PaletteRelativeAlign.Center:
			switch (textV)
			{
			case PaletteRelativeAlign.Near:
				return DataGridViewContentAlignment.TopCenter;
			case PaletteRelativeAlign.Center:
				return DataGridViewContentAlignment.MiddleCenter;
			case PaletteRelativeAlign.Far:
				return DataGridViewContentAlignment.BottomCenter;
			}
			break;
		case PaletteRelativeAlign.Far:
			switch (textV)
			{
			case PaletteRelativeAlign.Near:
				return DataGridViewContentAlignment.TopRight;
			case PaletteRelativeAlign.Center:
				return DataGridViewContentAlignment.MiddleRight;
			case PaletteRelativeAlign.Far:
				return DataGridViewContentAlignment.BottomRight;
			}
			break;
		}
		Debug.Assert(condition: false);
		return DataGridViewContentAlignment.MiddleLeft;
	}

	private PaletteDrawBorders GetCellMaxBorderEdges(Rectangle cellBounds, int column, int row)
	{
		PaletteDrawBorders paletteDrawBorders = (PaletteDrawBorders)(2 | (RightToLeftInternal ? 4 : 8));
		if (!HideOuterBorders && (row == -1 || (row == 0 && !base.ColumnHeadersVisible)))
		{
			paletteDrawBorders |= PaletteDrawBorders.Top;
		}
		if (!HideOuterBorders && (column == -1 || (column == 0 && !base.RowHeadersVisible)))
		{
			paletteDrawBorders = (PaletteDrawBorders)((int)paletteDrawBorders | (RightToLeftInternal ? 8 : 4));
		}
		if (HideOuterBorders)
		{
			if (RightToLeftInternal)
			{
				if (cellBounds.Left == 0)
				{
					paletteDrawBorders &= ~PaletteDrawBorders.Left;
				}
			}
			else if (cellBounds.Right == base.Width)
			{
				paletteDrawBorders &= ~PaletteDrawBorders.Right;
			}
			if (cellBounds.Bottom == base.Height)
			{
				paletteDrawBorders &= ~PaletteDrawBorders.Bottom;
			}
		}
		return paletteDrawBorders;
	}

	private void ViewManagerLayout()
	{
		if (!base.IsDisposed && ViewManager != null)
		{
			int num = 5;
			do
			{
				_layoutDirty = false;
				ViewManager.Layout(_renderer);
			}
			while (_layoutDirty && num-- > 0);
			_lastLayoutSize = base.Size;
		}
	}

	private void CellDataAreaMouseEnterInternal(DataGridViewCell cell)
	{
		Point currentCellAddress = base.CurrentCellAddress;
		if (cell.RowIndex >= 0 && cell.ColumnIndex == -1)
		{
			return;
		}
		if (ShowCellToolTips && (currentCellAddress.X == -1 || currentCellAddress.X != cell.ColumnIndex || currentCellAddress.Y != cell.RowIndex || base.EditingControl == null))
		{
			_toolTipText = GetToolTipText(cell, cell.RowIndex);
			if (string.IsNullOrEmpty(_toolTipText) && cell.FormattedValueType == typeof(string))
			{
				if (cell.RowIndex != -1 && cell.OwningColumn != null)
				{
					if (cell.OwningColumn.Width < GetCellPreferredWidth(cell) || cell.OwningRow.Height < GetCellPreferredHeight(cell))
					{
						string text = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Display) as string;
						if (!string.IsNullOrEmpty(text))
						{
							_toolTipText = TruncateToolTipText(text);
						}
					}
				}
				else if (cell.RowIndex == -1 && cell.ColumnIndex != -1 && _columnCache.ContainsKey(cell.ColumnIndex) && !_columnCache[cell.ColumnIndex])
				{
					try
					{
						string text2 = cell.GetEditedFormattedValue(cell.RowIndex, DataGridViewDataErrorContexts.Display) as string;
						if (!string.IsNullOrEmpty(text2))
						{
							_toolTipText = TruncateToolTipText(text2);
						}
					}
					catch
					{
					}
				}
			}
			if (_showTimer != null)
			{
				_showTimer.Stop();
				_showTimer.Start();
			}
		}
		else
		{
			CellAreaMouseLeaveInternal();
		}
	}

	private void CellErrorAreaMouseEnterInternal(DataGridViewCell cell)
	{
		_toolTipText = GetErrorText(cell, cell.RowIndex);
		if (_showTimer != null)
		{
			_showTimer.Stop();
			_showTimer.Start();
		}
	}

	private void CellAreaMouseLeaveInternal()
	{
		if (_showTimer != null)
		{
			_showTimer.Stop();
		}
		if (_visualPopupToolTip != null)
		{
			VisualPopupManager.Singleton.EndPopupTracking(_visualPopupToolTip);
		}
	}

	private void OnVisualPopupToolTipDisposed(object sender, EventArgs e)
	{
		VisualPopupToolTip visualPopupToolTip = (VisualPopupToolTip)sender;
		visualPopupToolTip.Disposed -= OnVisualPopupToolTipDisposed;
		_visualPopupToolTip = null;
	}

	private void OnTimerTick(object sender, EventArgs e)
	{
		if (_showTimer == null)
		{
			return;
		}
		_showTimer.Stop();
		if (!string.IsNullOrEmpty(_toolTipText))
		{
			DismissBaseToolTips();
			if (_visualPopupToolTip != null)
			{
				_visualPopupToolTip.Dispose();
			}
			_visualPopupToolTip = new VisualPopupToolTip(Redirector, new ToolTipContent(_toolTipText), Renderer, PaletteBackStyle.ControlToolTip, PaletteBorderStyle.ControlToolTip, PaletteContentStyle.LabelToolTip);
			_visualPopupToolTip.Disposed += OnVisualPopupToolTipDisposed;
			_visualPopupToolTip.ShowCalculatingSize(Control.MousePosition);
		}
	}

	private void CacheAccessToLayout()
	{
		if (_fiLayout == null)
		{
			_fiLayout = typeof(DataGridView).GetField("layout", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			Type type = _fiLayout.GetValue(this).GetType();
			_fiColumnHeaders = type.GetField("ColumnHeaders");
			_fiRowHeaders = type.GetField("RowHeaders");
			_fiColumnHeadersVisible = type.GetField("ColumnHeadersVisible");
			_fiRowHeadersVisible = type.GetField("RowHeadersVisible");
		}
	}

	private DataGridViewCell GetCellInternal(int column, int row)
	{
		if (_miGCI == null)
		{
			_miGCI = typeof(DataGridView).GetMethod("GetCellInternal", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		return (DataGridViewCell)_miGCI.Invoke(this, new object[2] { column, row });
	}

	private string GetToolTipText(DataGridViewCell cell, int row)
	{
		if (_miGTTT == null)
		{
			_miGTTT = typeof(DataGridViewCell).GetMethod("GetToolTipText", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		try
		{
			return (string)_miGTTT.Invoke(cell, new object[1] { row });
		}
		catch
		{
			return string.Empty;
		}
	}

	private string GetErrorText(DataGridViewCell cell, int row)
	{
		if (_miGET == null)
		{
			_miGET = typeof(DataGridViewCell).GetMethod("GetErrorText", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		try
		{
			return (string)_miGET.Invoke(cell, new object[1] { row });
		}
		catch
		{
			return string.Empty;
		}
	}

	private byte CurrentMouseLocation(DataGridViewCell cell)
	{
		if (_piCML == null)
		{
			_piCML = typeof(DataGridViewCell).GetProperty("CurrentMouseLocation", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		return (byte)_piCML.GetValue(cell, null);
	}

	private int GetCellPreferredWidth(DataGridViewCell cell)
	{
		if (_miGPW == null)
		{
			_miGPW = typeof(DataGridViewCell).GetMethod("GetPreferredWidth", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		return (int)_miGPW.Invoke(cell, new object[2]
		{
			cell.RowIndex,
			cell.OwningRow.Height
		});
	}

	private int GetCellPreferredHeight(DataGridViewCell cell)
	{
		if (_miGPH == null)
		{
			_miGPH = typeof(DataGridViewCell).GetMethod("GetPreferredHeight", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		return (int)_miGPH.Invoke(cell, new object[2]
		{
			cell.RowIndex,
			cell.OwningColumn.Width
		});
	}

	private string DismissBaseToolTips()
	{
		if (_miATT == null)
		{
			_miATT = typeof(DataGridView).GetMethod("ActivateToolTip", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
		}
		return (string)_miATT.Invoke(this, new object[4]
		{
			false,
			string.Empty,
			-1,
			-1
		});
	}

	private string TruncateToolTipText(string toolTipText)
	{
		if (toolTipText.Length > 288)
		{
			StringBuilder stringBuilder = new StringBuilder(toolTipText.Substring(0, 256), 259);
			stringBuilder.Append("...");
			return stringBuilder.ToString();
		}
		return toolTipText;
	}

	private Rectangle GetBackgroundClipRect()
	{
		Rectangle empty = Rectangle.Empty;
		CacheAccessToLayout();
		object value = _fiLayout.GetValue(this);
		Rectangle rectangle = (Rectangle)_fiColumnHeaders.GetValue(value);
		Rectangle rectangle2 = (Rectangle)_fiRowHeaders.GetValue(value);
		bool flag = (bool)_fiColumnHeadersVisible.GetValue(value);
		bool flag2 = (bool)_fiRowHeadersVisible.GetValue(value);
		int columnsWidth = base.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
		int num = base.Rows.GetRowsHeight(DataGridViewElementStates.Visible);
		if (flag)
		{
			num += rectangle.Height;
		}
		columnsWidth = ((!flag2) ? (columnsWidth + 1) : (columnsWidth + rectangle2.Width));
		if (base.Rows.Count > 0 && base.Columns.Count > 0)
		{
			empty.Height = num;
			empty.Width = columnsWidth;
			empty.Y -= base.VerticalScrollingOffset;
			empty.X -= base.HorizontalScrollingOffset;
			if (RightToLeft == RightToLeft.Yes)
			{
				empty.X = base.Width - columnsWidth + base.HorizontalScrollingOffset;
			}
		}
		return empty;
	}

	private void SetPalette(IPalette palette)
	{
		if (palette != _palette)
		{
			if (_palette != null)
			{
				_palette.PalettePaint -= OnNeedResyncPaint;
				_palette.ButtonSpecChanged -= OnButtonSpecChanged;
			}
			_palette = palette;
			_renderer = _palette.GetRenderer();
			if (_palette != null)
			{
				_palette.PalettePaint += OnNeedResyncPaint;
				_palette.ButtonSpecChanged += OnButtonSpecChanged;
			}
			SyncCellStylesWithPalette();
		}
	}

	private void PaintTransparentBackground(Graphics g, Rectangle clipRect)
	{
		Control transparentParent = TransparentParent;
		if (transparentParent != null && NeedTransparentPaint)
		{
			if (_miPTB == null)
			{
				_miPTB = typeof(Control).GetMethod("PaintTransparentBackground", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, CallingConventions.HasThis, new Type[3]
				{
					typeof(PaintEventArgs),
					typeof(Rectangle),
					typeof(Region)
				}, null);
			}
			_miPTB.Invoke(this, new object[3]
			{
				new PaintEventArgs(g, clipRect),
				base.ClientRectangle,
				null
			});
		}
	}

	private void OnPerformRefresh()
	{
		if (_refresh)
		{
			Refresh();
			if (_layoutDirty)
			{
				PerformLayout();
				Refresh();
			}
			_refresh = false;
			_refreshAll = false;
		}
	}

	private void OnGlobalPaletteChanged(object sender, EventArgs e)
	{
		if (PaletteMode == PaletteMode.Global)
		{
			_localPalette = null;
			SetPalette(KryptonManager.CurrentGlobalPalette);
			Redirector.Target = _palette;
			SyncCellStylesWithPalette();
			OnNeedPaint(Palette, new NeedLayoutEventArgs(needLayout: true));
		}
	}

	private void OnUserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
	{
		OnNeedResyncPaint(Palette, new NeedLayoutEventArgs(needLayout: true));
	}

	private void OnSyncPropertyChanged(object sender, EventArgs e)
	{
		SyncCellStylesWithPalette();
	}

	private void OnSyncBackPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Color1")
		{
			SyncCellStylesWithPalette();
		}
	}
}
