#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonPalette), "ToolboxBitmaps.KryptonPalette.bmp")]
[DefaultEvent("PalettePaint")]
[DefaultProperty("BasePaletteMode")]
[DesignerCategory("code")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonPaletteDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[Description("Customisable palette component.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonPalette : Component, IPalette
{
	private class ImageDictionary : Dictionary<Image, string>
	{
	}

	private class ImageReverseDictionary : Dictionary<string, Image>
	{
	}

	private static readonly int _paletteVersion = 18;

	private int _suspendCount;

	private IRenderer _baseRenderer;

	private RendererMode _baseRenderMode;

	private IPalette _basePalette;

	private PaletteMode _basePaletteMode;

	private InheritBool _allowFormChrome;

	private PaletteRedirect _redirector;

	private PaletteRedirectCommon _redirectCommon;

	private KryptonPaletteCheckButtons _buttons;

	private KryptonPaletteButtonSpecs _buttonSpecs;

	private KryptonPaletteCalendarDay _calendarDay;

	private KryptonPaletteCargo _cargo;

	private KryptonPaletteCommon _common;

	private KryptonPaletteContextMenu _contextMenu;

	private KryptonPaletteControls _controls;

	private PaletteDragDrop _dragDrop;

	private KryptonPaletteForms _forms;

	private KryptonPaletteGrids _grids;

	private KryptonPaletteHeaders _headers;

	private KryptonPaletteHeaderGroup _headerGroup;

	private KryptonPaletteImages _images;

	private KryptonPaletteInputControls _inputControls;

	private KryptonPaletteLabels _labels;

	private KryptonPaletteNavigator _navigator;

	private KryptonPalettePanels _panels;

	private KryptonPaletteRibbon _ribbon;

	private KryptonPaletteSeparators _separators;

	private KryptonPaletteTabButtons _tabs;

	private KryptonPaletteTrackBar _trackBar;

	private KryptonPaletteTMS _toolMenuStatus;

	private NeedPaintHandler _needPaintDelegate;

	private NeedPaintHandler _needTMSPaintDelegate;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Should KryptonForm instances show custom chrome.")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	public InheritBool AllowFormChrome
	{
		get
		{
			return _allowFormChrome;
		}
		set
		{
			if (_allowFormChrome != value)
			{
				_allowFormChrome = value;
				OnAllowFormChromeChanged(this, EventArgs.Empty);
			}
		}
	}

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecs ButtonSpecs => _buttonSpecs;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of button styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButtons ButtonStyles => _buttons;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of the calendar day.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCalendarDay CalendarDay => _calendarDay;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Set of user supplied values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCargo Cargo => _cargo;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common appearance values.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCommon Common => _common;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of control styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteControls ControlStyles => _controls;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of context menus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteContextMenu ContextMenu => _contextMenu;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of drag and drop.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteDragDrop DragDrop => _dragDrop;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of form styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteForms FormStyles => _forms;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining HeaderGroup appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeaderGroup HeaderGroup => _headerGroup;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of header styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeaders HeaderStyles => _headers;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of grid styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteGrids GridStyles => _grids;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining images.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteImages Images => _images;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining input controls.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteInputControls InputControlStyles => _inputControls;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of label styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabels LabelStyles => _labels;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Navigator appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteNavigator Navigator => _navigator;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of panel styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPalettePanels PanelStyles => _panels;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of ribbon.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteRibbon Ribbon => _ribbon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of separator styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteSeparators SeparatorStyles => _separators;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance of tab styles.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButtons TabStyles => _tabs;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining appearance for the track bar.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTrackBar TrackBar => _trackBar;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Colors associated with tool, menu and status strips.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMS ToolMenuStatus => _toolMenuStatus;

	[KryptonPersist(false, false)]
	[Category("Visuals")]
	[Description("Base palette used to inherit from.")]
	[DefaultValue(typeof(PaletteMode), "Office2010Blue")]
	public PaletteMode BasePaletteMode
	{
		get
		{
			return _basePaletteMode;
		}
		set
		{
			if (_basePaletteMode == value)
			{
				return;
			}
			if (value != PaletteMode.Custom)
			{
				PaletteMode basePaletteMode = _basePaletteMode;
				IPalette basePalette = _basePalette;
				_basePaletteMode = value;
				_basePalette = KryptonManager.GetPaletteForMode(_basePaletteMode);
				if (HasCircularReference())
				{
					_basePaletteMode = basePaletteMode;
					_basePalette = basePalette;
					throw new ArgumentOutOfRangeException("value", "Cannot use palette that would create a circular reference");
				}
				_basePalette = basePalette;
				SetPalette(KryptonManager.GetPaletteForMode(_basePaletteMode));
				OnBasePaletteChanged(this, EventArgs.Empty);
				OnBaseRendererChanged(this, EventArgs.Empty);
				OnAllowFormChromeChanged(this, EventArgs.Empty);
				OnButtonSpecChanged(this, EventArgs.Empty);
				OnPalettePaint(this, new PaletteLayoutEventArgs(needLayout: true, needColorTable: true));
			}
		}
	}

	[Category("Visuals")]
	[Description("KryptonPalette used to inherit from.")]
	[DefaultValue(null)]
	public IPalette BasePalette
	{
		get
		{
			return _basePalette;
		}
		set
		{
			if (_basePalette != value)
			{
				PaletteMode basePaletteMode = _basePaletteMode;
				IPalette basePalette = _basePalette;
				_basePaletteMode = ((value == null) ? PaletteMode.Office2010Blue : PaletteMode.Custom);
				_basePalette = value;
				if (HasCircularReference())
				{
					_basePaletteMode = basePaletteMode;
					_basePalette = basePalette;
					throw new ArgumentOutOfRangeException("value", "Cannot use palette that would create a circular reference");
				}
				_basePalette = basePalette;
				IPalette basePalette2 = _basePalette;
				SetPalette(value);
				if (value == null)
				{
					SetPalette(KryptonManager.GetPaletteForMode(_basePaletteMode));
				}
				OnBasePaletteChanged(this, EventArgs.Empty);
				OnBaseRendererChanged(this, EventArgs.Empty);
				OnAllowFormChromeChanged(this, EventArgs.Empty);
				OnButtonSpecChanged(this, EventArgs.Empty);
				OnPalettePaint(this, new PaletteLayoutEventArgs(needLayout: true, needColorTable: true));
			}
		}
	}

	[KryptonPersist(false, false)]
	[Category("Visuals")]
	[Description("Renderer used to inherit from.")]
	[DefaultValue(typeof(RendererMode), "Inherit")]
	public RendererMode BaseRenderMode
	{
		get
		{
			return _baseRenderMode;
		}
		set
		{
			if (_baseRenderMode == value)
			{
				return;
			}
			if (value != RendererMode.Custom)
			{
				_baseRenderMode = value;
				if (value == RendererMode.Inherit)
				{
					_baseRenderer = null;
				}
				else
				{
					_baseRenderer = KryptonManager.GetRendererForMode(_baseRenderMode);
				}
				OnBaseRendererChanged(this, EventArgs.Empty);
				OnButtonSpecChanged(this, EventArgs.Empty);
				OnPalettePaint(this, new PaletteLayoutEventArgs(needLayout: true, needColorTable: true));
			}
		}
	}

	[Category("Visuals")]
	[Description("Custom renderer to be used with this palette.")]
	[DefaultValue(null)]
	public IRenderer BaseRenderer
	{
		get
		{
			return _baseRenderer;
		}
		set
		{
			if (_baseRenderer != value)
			{
				_baseRenderMode = ((value != null) ? RendererMode.Custom : RendererMode.Inherit);
				_baseRenderer = value;
				OnBaseRendererChanged(this, EventArgs.Empty);
				OnButtonSpecChanged(this, EventArgs.Empty);
				OnPalettePaint(this, new PaletteLayoutEventArgs(needLayout: true, needColorTable: true));
			}
		}
	}

	[Browsable(false)]
	public KryptonColorTable ColorTable => _toolMenuStatus.InternalKCT;

	protected NeedPaintHandler NeedPaintDelegate => _needPaintDelegate;

	[Category("Action")]
	[Description("Occurs when a change requires a repaint to reflect the update.")]
	public event EventHandler<PaletteLayoutEventArgs> PalettePaint;

	[Category("Action")]
	[Description("Occurs when the AllowFormChrome setting changes.")]
	public event EventHandler AllowFormChromeChanged;

	[Category("Action")]
	[Description("Occurs when a base palette setting change occurs.")]
	public event EventHandler BasePaletteChanged;

	[Category("Action")]
	[Description("Occurs when a base renderer setting change occurs.")]
	public event EventHandler BaseRendererChanged;

	[Category("Action")]
	[Description("Occurs when a button spec change occurs.")]
	public event EventHandler ButtonSpecChanged;

	public KryptonPalette()
	{
		_needPaintDelegate = OnNeedPaint;
		_needTMSPaintDelegate = OnMenuToolStatusPaint;
		_basePalette = KryptonManager.GetPaletteForMode(PaletteMode.Office2010Blue);
		_basePaletteMode = PaletteMode.Office2010Blue;
		_baseRenderer = null;
		_baseRenderMode = RendererMode.Inherit;
		_redirector = new PaletteRedirect(_basePalette);
		_allowFormChrome = InheritBool.Inherit;
		_common = new KryptonPaletteCommon(_redirector, _needPaintDelegate);
		_redirectCommon = new PaletteRedirectCommon(_redirector, Common.StateDisabled, Common.StateOthers);
		_buttons = new KryptonPaletteCheckButtons(_redirectCommon, _needPaintDelegate);
		_buttonSpecs = new KryptonPaletteButtonSpecs(_redirector);
		_calendarDay = new KryptonPaletteCalendarDay(_redirector, _needPaintDelegate);
		_cargo = new KryptonPaletteCargo(_needPaintDelegate);
		_controls = new KryptonPaletteControls(_redirectCommon, _needPaintDelegate);
		_contextMenu = new KryptonPaletteContextMenu(_redirectCommon, _needPaintDelegate);
		_dragDrop = new PaletteDragDrop(_redirectCommon, _needPaintDelegate);
		_forms = new KryptonPaletteForms(_redirectCommon, _needPaintDelegate);
		_grids = new KryptonPaletteGrids(_redirectCommon, _needPaintDelegate);
		_headers = new KryptonPaletteHeaders(_redirectCommon, _needPaintDelegate);
		_headerGroup = new KryptonPaletteHeaderGroup(_redirector, _needPaintDelegate);
		_images = new KryptonPaletteImages(_redirectCommon, _needPaintDelegate);
		_inputControls = new KryptonPaletteInputControls(_redirectCommon, _needPaintDelegate);
		_labels = new KryptonPaletteLabels(_redirectCommon, _needPaintDelegate);
		_navigator = new KryptonPaletteNavigator(_redirectCommon, _needPaintDelegate);
		_panels = new KryptonPalettePanels(_redirectCommon, _needPaintDelegate);
		_ribbon = new KryptonPaletteRibbon(_redirectCommon, _needPaintDelegate);
		_separators = new KryptonPaletteSeparators(_redirectCommon, _needPaintDelegate);
		_tabs = new KryptonPaletteTabButtons(_redirectCommon, _needPaintDelegate);
		_trackBar = new KryptonPaletteTrackBar(_redirectCommon, _needPaintDelegate);
		_toolMenuStatus = new KryptonPaletteTMS(this, _basePalette.ColorTable, _needTMSPaintDelegate);
		_buttonSpecs.ButtonSpecChanged += OnButtonSpecChanged;
		if (_basePalette != null)
		{
			_basePalette.PalettePaint += OnPalettePaint;
			_basePalette.ButtonSpecChanged += OnButtonSpecChanged;
			_basePalette.BasePaletteChanged += OnBasePaletteChanged;
			_basePalette.BaseRendererChanged += OnBaseRendererChanged;
		}
	}

	public KryptonPalette(IContainer container)
		: this()
	{
		Debug.Assert(container != null);
		if (container == null)
		{
			throw new ArgumentNullException("container");
		}
		container.Add(this);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _basePalette != null)
		{
			_basePalette.PalettePaint -= OnPalettePaint;
			_basePalette.ButtonSpecChanged -= OnButtonSpecChanged;
			_basePalette.BasePaletteChanged -= OnBasePaletteChanged;
			_basePalette.BaseRendererChanged -= OnBaseRendererChanged;
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeAllowFormChrome()
	{
		return AllowFormChrome != InheritBool.Inherit;
	}

	private bool ShouldSerializeButtonSpecs()
	{
		return !_buttonSpecs.IsDefault;
	}

	private bool ShouldSerializeButtons()
	{
		return !_buttons.IsDefault;
	}

	private bool ShouldSerializeCalendarDay()
	{
		return !_calendarDay.IsDefault;
	}

	private bool ShouldSerializeCargo()
	{
		return !_cargo.IsDefault;
	}

	private bool ShouldSerializeCommon()
	{
		return !_common.IsDefault;
	}

	private bool ShouldSerializeControlStyles()
	{
		return !_controls.IsDefault;
	}

	private bool ShouldSerializeContextMenu()
	{
		return !_contextMenu.IsDefault;
	}

	private bool ShouldSerializeDragDrop()
	{
		return !_dragDrop.IsDefault;
	}

	private bool ShouldSerializeFormStyles()
	{
		return !_forms.IsDefault;
	}

	private bool ShouldSerializeHeaderGroup()
	{
		return !_headerGroup.IsDefault;
	}

	private bool ShouldSerializeHeaders()
	{
		return !_headers.IsDefault;
	}

	private bool ShouldSerializeGridStyles()
	{
		return !_grids.IsDefault;
	}

	private bool ShouldSerializeImages()
	{
		return !_images.IsDefault;
	}

	private bool ShouldSerializeInputControls()
	{
		return !_inputControls.IsDefault;
	}

	private bool ShouldSerializeLabels()
	{
		return !_labels.IsDefault;
	}

	private bool ShouldSerializeNavigator()
	{
		return !_navigator.IsDefault;
	}

	private bool ShouldSerializePanels()
	{
		return !_panels.IsDefault;
	}

	private bool ShouldSerializeRibbon()
	{
		return !_ribbon.IsDefault;
	}

	private bool ShouldSerializeSeparators()
	{
		return !_separators.IsDefault;
	}

	private bool ShouldSerializeTabStyles()
	{
		return !_tabs.IsDefault;
	}

	private bool ShouldSerializeTrackBar()
	{
		return !_trackBar.IsDefault;
	}

	private bool ShouldSerializeToolMenuStatus()
	{
		return !_toolMenuStatus.IsDefault;
	}

	public IRenderer GetRenderer()
	{
		return _baseRenderMode switch
		{
			RendererMode.Inherit => _basePalette.GetRenderer(), 
			RendererMode.Custom => _baseRenderer, 
			_ => KryptonManager.GetRendererForMode(_baseRenderMode), 
		};
	}

	public InheritBool GetAllowFormChrome()
	{
		if (AllowFormChrome == InheritBool.Inherit)
		{
			return _basePalette.GetAllowFormChrome();
		}
		return AllowFormChrome;
	}

	public InheritBool GetBackDraw(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackDraw(state);
	}

	public PaletteGraphicsHint GetBackGraphicsHint(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackGraphicsHint(state);
	}

	public Color GetBackColor1(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackColor1(state);
	}

	public Color GetBackColor2(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackColor2(state);
	}

	public PaletteColorStyle GetBackColorStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackColorStyle(state);
	}

	public PaletteRectangleAlign GetBackColorAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackColorAlign(state);
	}

	public float GetBackColorAngle(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackColorAngle(state);
	}

	public Image GetBackImage(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackImage(state);
	}

	public PaletteImageStyle GetBackImageStyle(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackImageStyle(state);
	}

	public PaletteRectangleAlign GetBackImageAlign(PaletteBackStyle style, PaletteState state)
	{
		return GetPaletteBack(style, state).GetBackImageAlign(state);
	}

	public InheritBool GetBorderDraw(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderDraw(state);
	}

	public PaletteDrawBorders GetBorderDrawBorders(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderDrawBorders(state);
	}

	public PaletteGraphicsHint GetBorderGraphicsHint(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderGraphicsHint(state);
	}

	public Color GetBorderColor1(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderColor1(state);
	}

	public Color GetBorderColor2(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderColor2(state);
	}

	public PaletteColorStyle GetBorderColorStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderColorStyle(state);
	}

	public PaletteRectangleAlign GetBorderColorAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderColorAlign(state);
	}

	public float GetBorderColorAngle(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderColorAngle(state);
	}

	public int GetBorderWidth(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderWidth(state);
	}

	public int GetBorderRounding(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderRounding(state);
	}

	public Image GetBorderImage(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderImage(state);
	}

	public PaletteImageStyle GetBorderImageStyle(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderImageStyle(state);
	}

	public PaletteRectangleAlign GetBorderImageAlign(PaletteBorderStyle style, PaletteState state)
	{
		return GetPaletteBorder(style, state).GetBorderImageAlign(state);
	}

	public InheritBool GetContentDraw(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentDraw(state);
	}

	public InheritBool GetContentDrawFocus(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentDrawFocus(state);
	}

	public PaletteRelativeAlign GetContentImageH(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentImageH(state);
	}

	public PaletteRelativeAlign GetContentImageV(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentImageV(state);
	}

	public PaletteImageEffect GetContentImageEffect(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentImageEffect(state);
	}

	public Color GetContentImageColorMap(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentImageColorMap(state);
	}

	public Color GetContentImageColorTo(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentImageColorTo(state);
	}

	public Font GetContentShortTextFont(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextFont(state);
	}

	public Font GetContentShortTextNewFont(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextFont(state);
	}

	public PaletteTextHint GetContentShortTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextHint(state);
	}

	public InheritBool GetContentShortTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextMultiLine(state);
	}

	public PaletteTextTrim GetContentShortTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextTrim(state);
	}

	public PaletteTextHotkeyPrefix GetContentShortTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextPrefix(state);
	}

	public PaletteRelativeAlign GetContentShortTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextH(state);
	}

	public PaletteRelativeAlign GetContentShortTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextV(state);
	}

	public PaletteRelativeAlign GetContentShortTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextMultiLineH(state);
	}

	public Color GetContentShortTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextColor1(state);
	}

	public Color GetContentShortTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextColor2(state);
	}

	public PaletteColorStyle GetContentShortTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextColorStyle(state);
	}

	public PaletteRectangleAlign GetContentShortTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextColorAlign(state);
	}

	public float GetContentShortTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextColorAngle(state);
	}

	public Image GetContentShortTextImage(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextImage(state);
	}

	public PaletteImageStyle GetContentShortTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextImageStyle(state);
	}

	public PaletteRectangleAlign GetContentShortTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentShortTextImageAlign(state);
	}

	public Font GetContentLongTextFont(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextFont(state);
	}

	public Font GetContentLongTextNewFont(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextFont(state);
	}

	public PaletteTextHint GetContentLongTextHint(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextHint(state);
	}

	public PaletteTextHotkeyPrefix GetContentLongTextPrefix(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextPrefix(state);
	}

	public InheritBool GetContentLongTextMultiLine(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextMultiLine(state);
	}

	public PaletteTextTrim GetContentLongTextTrim(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextTrim(state);
	}

	public PaletteRelativeAlign GetContentLongTextH(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextH(state);
	}

	public PaletteRelativeAlign GetContentLongTextV(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextV(state);
	}

	public PaletteRelativeAlign GetContentLongTextMultiLineH(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextMultiLineH(state);
	}

	public Color GetContentLongTextColor1(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextColor1(state);
	}

	public Color GetContentLongTextColor2(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextColor2(state);
	}

	public PaletteColorStyle GetContentLongTextColorStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextColorStyle(state);
	}

	public PaletteRectangleAlign GetContentLongTextColorAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextColorAlign(state);
	}

	public float GetContentLongTextColorAngle(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextColorAngle(state);
	}

	public Image GetContentLongTextImage(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextImage(state);
	}

	public PaletteImageStyle GetContentLongTextImageStyle(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextImageStyle(state);
	}

	public PaletteRectangleAlign GetContentLongTextImageAlign(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentLongTextImageAlign(state);
	}

	public Padding GetContentPadding(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentPadding(state);
	}

	public int GetContentAdjacentGap(PaletteContentStyle style, PaletteState state)
	{
		return GetPaletteContent(style, state).GetContentAdjacentGap(state);
	}

	public int GetMetricInt(PaletteState state, PaletteMetricInt metric)
	{
		switch (metric)
		{
		case PaletteMetricInt.BarButtonEdgeOutside:
		case PaletteMetricInt.BarButtonEdgeInside:
		case PaletteMetricInt.CheckButtonGap:
		case PaletteMetricInt.RibbonTabGap:
			return Navigator.StateCommon.Bar.GetMetricInt(state, metric);
		case PaletteMetricInt.HeaderButtonEdgeInsetPrimary:
			return HeaderStyles.HeaderPrimary.StateCommon.GetMetricInt(state, metric);
		case PaletteMetricInt.HeaderButtonEdgeInsetSecondary:
			return HeaderStyles.HeaderSecondary.StateCommon.GetMetricInt(state, metric);
		case PaletteMetricInt.HeaderButtonEdgeInsetDockInactive:
			return HeaderStyles.HeaderDockInactive.StateCommon.GetMetricInt(state, metric);
		case PaletteMetricInt.HeaderButtonEdgeInsetDockActive:
			return HeaderStyles.HeaderDockActive.StateCommon.GetMetricInt(state, metric);
		case PaletteMetricInt.HeaderButtonEdgeInsetForm:
			return HeaderStyles.HeaderForm.StateCommon.GetMetricInt(state, metric);
		case PaletteMetricInt.HeaderButtonEdgeInsetCustom1:
			return HeaderStyles.HeaderCustom1.StateCommon.GetMetricInt(state, metric);
		case PaletteMetricInt.HeaderButtonEdgeInsetCustom2:
			return HeaderStyles.HeaderCustom2.StateCommon.GetMetricInt(state, metric);
		default:
			return _redirector.GetMetricInt(state, metric);
		}
	}

	public InheritBool GetMetricBool(PaletteState state, PaletteMetricBool metric)
	{
		if (metric == PaletteMetricBool.HeaderGroupOverlay)
		{
			return HeaderGroup.StateCommon.GetMetricBool(state, metric);
		}
		return _redirector.GetMetricBool(state, metric);
	}

	public Padding GetMetricPadding(PaletteState state, PaletteMetricPadding metric)
	{
		Padding inheritPadding = CommonHelper.InheritPadding;
		switch (metric)
		{
		case PaletteMetricPadding.BarPaddingTabs:
		case PaletteMetricPadding.BarPaddingInside:
		case PaletteMetricPadding.BarPaddingOutside:
		case PaletteMetricPadding.BarPaddingOnly:
		case PaletteMetricPadding.BarButtonPadding:
			return Navigator.StateCommon.Bar.GetMetricPadding(state, metric);
		case PaletteMetricPadding.HeaderGroupPaddingPrimary:
		case PaletteMetricPadding.HeaderGroupPaddingSecondary:
		case PaletteMetricPadding.HeaderGroupPaddingDockInactive:
		case PaletteMetricPadding.HeaderGroupPaddingDockActive:
			return HeaderGroup.StateCommon.GetMetricPadding(state, metric);
		case PaletteMetricPadding.HeaderButtonPaddingPrimary:
			return HeaderStyles.HeaderPrimary.StateCommon.GetMetricPadding(state, metric);
		case PaletteMetricPadding.HeaderButtonPaddingSecondary:
			return HeaderStyles.HeaderSecondary.StateCommon.GetMetricPadding(state, metric);
		case PaletteMetricPadding.HeaderButtonPaddingDockInactive:
			return HeaderStyles.HeaderDockInactive.StateCommon.GetMetricPadding(state, metric);
		case PaletteMetricPadding.HeaderButtonPaddingDockActive:
			return HeaderStyles.HeaderDockActive.StateCommon.GetMetricPadding(state, metric);
		case PaletteMetricPadding.HeaderButtonPaddingForm:
			return HeaderStyles.HeaderForm.StateCommon.GetMetricPadding(state, metric);
		case PaletteMetricPadding.HeaderButtonPaddingCustom1:
			return HeaderStyles.HeaderCustom1.StateCommon.GetMetricPadding(state, metric);
		case PaletteMetricPadding.HeaderButtonPaddingCustom2:
			return HeaderStyles.HeaderCustom2.StateCommon.GetMetricPadding(state, metric);
		case PaletteMetricPadding.SeparatorPaddingLowProfile:
			switch (state)
			{
			case PaletteState.Disabled:
				return SeparatorStyles.SeparatorLowProfile.StateDisabled.GetMetricPadding(state, metric);
			case PaletteState.Normal:
				return SeparatorStyles.SeparatorLowProfile.StateNormal.GetMetricPadding(state, metric);
			case PaletteState.Tracking:
				return SeparatorStyles.SeparatorLowProfile.StateTracking.GetMetricPadding(state, metric);
			case PaletteState.Pressed:
				return SeparatorStyles.SeparatorLowProfile.StatePressed.GetMetricPadding(state, metric);
			}
			break;
		case PaletteMetricPadding.SeparatorPaddingHighProfile:
		case PaletteMetricPadding.SeparatorPaddingHighInternalProfile:
			switch (state)
			{
			case PaletteState.Disabled:
				return SeparatorStyles.SeparatorHighProfile.StateDisabled.GetMetricPadding(state, metric);
			case PaletteState.Normal:
				return SeparatorStyles.SeparatorHighProfile.StateNormal.GetMetricPadding(state, metric);
			case PaletteState.Tracking:
				return SeparatorStyles.SeparatorHighProfile.StateTracking.GetMetricPadding(state, metric);
			case PaletteState.Pressed:
				return SeparatorStyles.SeparatorHighProfile.StatePressed.GetMetricPadding(state, metric);
			}
			break;
		case PaletteMetricPadding.SeparatorPaddingCustom1:
			switch (state)
			{
			case PaletteState.Disabled:
				return SeparatorStyles.SeparatorCustom1.StateDisabled.GetMetricPadding(state, metric);
			case PaletteState.Normal:
				return SeparatorStyles.SeparatorCustom1.StateNormal.GetMetricPadding(state, metric);
			case PaletteState.Tracking:
				return SeparatorStyles.SeparatorCustom1.StateTracking.GetMetricPadding(state, metric);
			case PaletteState.Pressed:
				return SeparatorStyles.SeparatorCustom1.StatePressed.GetMetricPadding(state, metric);
			}
			break;
		}
		return _redirector.GetMetricPadding(state, metric);
	}

	public Image GetTreeViewImage(bool expanded)
	{
		Image image = null;
		image = ((!expanded) ? _images.TreeView.Plus : _images.TreeView.Minus);
		if (image == null)
		{
			image = _redirector.GetTreeViewImage(expanded);
		}
		return image;
	}

	public Image GetCheckBoxImage(bool enabled, CheckState checkState, bool tracking, bool pressed)
	{
		Image image = null;
		switch (checkState)
		{
		case CheckState.Unchecked:
			image = (enabled ? ((!pressed) ? ((!tracking) ? _images.CheckBox.UncheckedNormal : _images.CheckBox.UncheckedTracking) : _images.CheckBox.UncheckedPressed) : _images.CheckBox.UncheckedDisabled);
			break;
		case CheckState.Checked:
			image = (enabled ? ((!pressed) ? ((!tracking) ? _images.CheckBox.CheckedNormal : _images.CheckBox.CheckedTracking) : _images.CheckBox.CheckedPressed) : _images.CheckBox.CheckedDisabled);
			break;
		case CheckState.Indeterminate:
			image = (enabled ? ((!pressed) ? ((!tracking) ? _images.CheckBox.IndeterminateNormal : _images.CheckBox.IndeterminateTracking) : _images.CheckBox.IndeterminatePressed) : _images.CheckBox.IndeterminateDisabled);
			break;
		}
		if (image == null)
		{
			image = _images.CheckBox.Common;
		}
		if (image == null)
		{
			return _redirector.GetCheckBoxImage(enabled, checkState, tracking, pressed);
		}
		return image;
	}

	public Image GetRadioButtonImage(bool enabled, bool checkState, bool tracking, bool pressed)
	{
		Image image = null;
		image = ((!checkState) ? ((!enabled) ? _images.RadioButton.UncheckedDisabled : (pressed ? _images.RadioButton.UncheckedPressed : ((!tracking) ? _images.RadioButton.UncheckedNormal : _images.RadioButton.UncheckedTracking))) : ((!enabled) ? _images.RadioButton.CheckedDisabled : (pressed ? _images.RadioButton.CheckedPressed : ((!tracking) ? _images.RadioButton.CheckedNormal : _images.RadioButton.CheckedTracking))));
		if (image == null)
		{
			image = _images.RadioButton.Common;
		}
		if (image == null)
		{
			return _redirector.GetRadioButtonImage(enabled, checkState, tracking, pressed);
		}
		return image;
	}

	public Image GetDropDownButtonImage(PaletteState state)
	{
		Image image = null;
		switch (state)
		{
		case PaletteState.Disabled:
			image = _images.DropDownButton.Disabled;
			break;
		case PaletteState.Normal:
			image = _images.DropDownButton.Normal;
			break;
		case PaletteState.Tracking:
			image = _images.DropDownButton.Tracking;
			break;
		case PaletteState.Pressed:
			image = _images.DropDownButton.Pressed;
			break;
		}
		if (image == null)
		{
			image = _images.DropDownButton.Common;
		}
		if (image == null)
		{
			return _redirector.GetDropDownButtonImage(state);
		}
		return image;
	}

	public Image GetContextMenuCheckedImage()
	{
		Image image = _images.ContextMenu.Checked;
		if (image == null)
		{
			return _redirector.GetContextMenuCheckedImage();
		}
		return image;
	}

	public Image GetContextMenuIndeterminateImage()
	{
		Image indeterminate = _images.ContextMenu.Indeterminate;
		if (indeterminate == null)
		{
			return _redirector.GetContextMenuIndeterminateImage();
		}
		return indeterminate;
	}

	public Image GetContextMenuSubMenuImage()
	{
		Image subMenu = _images.ContextMenu.SubMenu;
		if (subMenu == null)
		{
			return _redirector.GetContextMenuSubMenuImage();
		}
		return subMenu;
	}

	public Image GetGalleryButtonImage(PaletteRibbonGalleryButton button, PaletteState state)
	{
		Image image = null;
		KryptonPaletteImagesGalleryButton kryptonPaletteImagesGalleryButton = null;
		switch (button)
		{
		case PaletteRibbonGalleryButton.Up:
			kryptonPaletteImagesGalleryButton = _images.GalleryButtons.Up;
			break;
		case PaletteRibbonGalleryButton.Down:
			kryptonPaletteImagesGalleryButton = _images.GalleryButtons.Down;
			break;
		case PaletteRibbonGalleryButton.DropDown:
			kryptonPaletteImagesGalleryButton = _images.GalleryButtons.DropDown;
			break;
		}
		switch (state)
		{
		case PaletteState.Disabled:
			image = kryptonPaletteImagesGalleryButton.Disabled;
			break;
		case PaletteState.Normal:
			image = kryptonPaletteImagesGalleryButton.Normal;
			break;
		case PaletteState.Tracking:
			image = kryptonPaletteImagesGalleryButton.Tracking;
			break;
		case PaletteState.Pressed:
			image = kryptonPaletteImagesGalleryButton.Pressed;
			break;
		}
		if (image == null)
		{
			image = kryptonPaletteImagesGalleryButton.Common;
		}
		if (image == null)
		{
			return _redirector.GetGalleryButtonImage(button, state);
		}
		return image;
	}

	public Icon GetButtonSpecIcon(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecIcon(style);
	}

	public Image GetButtonSpecImage(PaletteButtonSpecStyle style, PaletteState state)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecImage(style, state);
	}

	public Color GetButtonSpecImageTransparentColor(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecImageTransparentColor(style);
	}

	public string GetButtonSpecShortText(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecShortText(style);
	}

	public string GetButtonSpecLongText(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecLongText(style);
	}

	public string GetButtonSpecToolTipTitle(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecToolTipTitle(style);
	}

	public Color GetButtonSpecColorMap(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecColorMap(style);
	}

	public PaletteButtonStyle GetButtonSpecStyle(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecStyle(style);
	}

	public HeaderLocation GetButtonSpecLocation(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecLocation(style);
	}

	public PaletteRelativeEdgeAlign GetButtonSpecEdge(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecEdge(style);
	}

	public PaletteButtonOrientation GetButtonSpecOrientation(PaletteButtonSpecStyle style)
	{
		return GetPaletteButtonSpec(style).GetButtonSpecOrientation(style);
	}

	public PaletteRibbonShape GetRibbonShape()
	{
		return GetPaletteRibbonGeneral().GetRibbonShape();
	}

	public virtual PaletteRelativeAlign GetRibbonContextTextAlign(PaletteState state)
	{
		return GetPaletteRibbonGeneral().GetRibbonContextTextAlign(state);
	}

	public Font GetRibbonContextTextFont(PaletteState state)
	{
		return GetPaletteRibbonGeneral().GetRibbonContextTextFont(state);
	}

	public Color GetRibbonContextTextColor(PaletteState state)
	{
		return GetPaletteRibbonGeneral().GetRibbonContextTextColor(state);
	}

	public Color GetRibbonDisabledDark(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonDisabledDark(state);
	}

	public Color GetRibbonDisabledLight(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonDisabledLight(state);
	}

	public Color GetRibbonDropArrowLight(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonDropArrowLight(state);
	}

	public Color GetRibbonDropArrowDark(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonDropArrowDark(state);
	}

	public Color GetRibbonGroupDialogDark(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonGroupDialogDark(state);
	}

	public Color GetRibbonGroupDialogLight(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonGroupDialogLight(state);
	}

	public Color GetRibbonGroupSeparatorDark(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonGroupSeparatorDark(state);
	}

	public Color GetRibbonGroupSeparatorLight(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonGroupSeparatorLight(state);
	}

	public Color GetRibbonMinimizeBarDark(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonMinimizeBarDark(state);
	}

	public Color GetRibbonMinimizeBarLight(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonMinimizeBarLight(state);
	}

	public Font GetRibbonTextFont(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonTextFont(state);
	}

	public PaletteTextHint GetRibbonTextHint(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonTextHint(state);
	}

	public Color GetRibbonTabSeparatorColor(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonTabSeparatorColor(state);
	}

	public virtual Color GetRibbonTabSeparatorContextColor(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonTabSeparatorContextColor(state);
	}

	public Color GetRibbonQATButtonDark(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonQATButtonDark(state);
	}

	public Color GetRibbonQATButtonLight(PaletteState state)
	{
		return GetPaletteRibbonGeneral(state).GetRibbonQATButtonLight(state);
	}

	public PaletteRibbonColorStyle GetRibbonBackColorStyle(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetPaletteRibbonBack(style, state).GetRibbonBackColorStyle(state);
	}

	public Color GetRibbonBackColor1(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetPaletteRibbonBack(style, state).GetRibbonBackColor1(state);
	}

	public Color GetRibbonBackColor2(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetPaletteRibbonBack(style, state).GetRibbonBackColor2(state);
	}

	public Color GetRibbonBackColor3(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetPaletteRibbonBack(style, state).GetRibbonBackColor3(state);
	}

	public Color GetRibbonBackColor4(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetPaletteRibbonBack(style, state).GetRibbonBackColor4(state);
	}

	public Color GetRibbonBackColor5(PaletteRibbonBackStyle style, PaletteState state)
	{
		return GetPaletteRibbonBack(style, state).GetRibbonBackColor5(state);
	}

	public Color GetRibbonTextColor(PaletteRibbonTextStyle style, PaletteState state)
	{
		return GetPaletteRibbonText(style, state).GetRibbonTextColor(state);
	}

	public Color GetElementColor1(PaletteElement element, PaletteState state)
	{
		return GetTrackBar(element, state).GetElementColor1(state);
	}

	public Color GetElementColor2(PaletteElement element, PaletteState state)
	{
		return GetTrackBar(element, state).GetElementColor2(state);
	}

	public Color GetElementColor3(PaletteElement element, PaletteState state)
	{
		return GetTrackBar(element, state).GetElementColor3(state);
	}

	public Color GetElementColor4(PaletteElement element, PaletteState state)
	{
		return GetTrackBar(element, state).GetElementColor4(state);
	}

	public Color GetElementColor5(PaletteElement element, PaletteState state)
	{
		return GetTrackBar(element, state).GetElementColor5(state);
	}

	public PaletteDragFeedback GetDragDropFeedback()
	{
		return _dragDrop.GetDragDropFeedback();
	}

	public Color GetDragDropSolidBack()
	{
		return _dragDrop.GetDragDropSolidBack();
	}

	public Color GetDragDropSolidBorder()
	{
		return _dragDrop.GetDragDropSolidBorder();
	}

	public float GetDragDropSolidOpacity()
	{
		return _dragDrop.GetDragDropSolidOpacity();
	}

	public Color GetDragDropDockBack()
	{
		return _dragDrop.GetDragDropDockBack();
	}

	public Color GetDragDropDockBorder()
	{
		return _dragDrop.GetDragDropDockBorder();
	}

	public Color GetDragDropDockActive()
	{
		return _dragDrop.GetDragDropDockActive();
	}

	public Color GetDragDropDockInactive()
	{
		return _dragDrop.GetDragDropDockInactive();
	}

	public int SuspendUpdates()
	{
		return ++_suspendCount;
	}

	public int ResumeUpdates()
	{
		return ResumeUpdates(updateNow: true);
	}

	public int ResumeUpdates(bool updateNow)
	{
		if (_suspendCount > 0)
		{
			_suspendCount--;
			if (updateNow && _suspendCount == 0)
			{
				OnPalettePaint(this, new PaletteLayoutEventArgs(needLayout: true, needColorTable: true));
				OnButtonSpecChanged(this, EventArgs.Empty);
				OnNeedPaint(this, new NeedLayoutEventArgs(needLayout: true));
			}
		}
		return _suspendCount;
	}

	public void ResetToDefaults(bool silent)
	{
		try
		{
			SuspendUpdates();
			if (silent)
			{
				ResetOperation(null);
				return;
			}
			CommonHelper.PerformOperation(ResetOperation, null);
			MessageBox.Show("Reset of palette is completed.", "Palette Reset", MessageBoxButtons.OK);
		}
		catch (Exception ex)
		{
			if (!silent)
			{
				MessageBox.Show("Reset failed.\n\n Error:" + ex.Message, "Palette Reset", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		finally
		{
			ResumeUpdates();
		}
	}

	public void PopulateFromBase(bool silent)
	{
		try
		{
			SuspendUpdates();
			if (silent)
			{
				PopulateFromBaseOperation(null);
				return;
			}
			CommonHelper.PerformOperation(PopulateFromBaseOperation, null);
			MessageBox.Show("Relevant values have been populated.", "Populate Values", MessageBoxButtons.OK);
		}
		catch (Exception ex)
		{
			if (!silent)
			{
				MessageBox.Show("Reset failed.\n\n Error:" + ex.Message, "Populate Values", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		finally
		{
			ResumeUpdates();
		}
	}

	public string Import()
	{
		using (OpenFileDialog openFileDialog = new OpenFileDialog())
		{
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.DefaultExt = "xml";
			openFileDialog.Filter = "Palette files (*.xml)|*.xml|All files (*.*)|(*.*)";
			openFileDialog.Title = "Load Palette";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				return Import(openFileDialog.FileName, silent: false);
			}
		}
		return string.Empty;
	}

	public string Import(string filename)
	{
		return Import(filename, silent: true);
	}

	public string Import(string filename, bool silent)
	{
		string result = string.Empty;
		try
		{
			SuspendUpdates();
			if (silent)
			{
				result = (string)ImportFromFile(filename);
			}
			else
			{
				result = (string)CommonHelper.PerformOperation(ImportFromFile, filename);
				MessageBox.Show("Import from file '" + filename + "' completed.", "Palette Import", MessageBoxButtons.OK);
			}
		}
		catch (Exception ex)
		{
			if (!silent)
			{
				MessageBox.Show("Import from file '" + filename + "' failed.\n\n Error:" + ex.Message, "Palette Import", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			throw ex;
		}
		finally
		{
			ResumeUpdates();
		}
		return result;
	}

	public void Import(Stream stream)
	{
		Import(stream, silent: true);
	}

	public void Import(Stream stream, bool silent)
	{
		try
		{
			SuspendUpdates();
			if (silent)
			{
				ImportFromStream(stream);
				return;
			}
			CommonHelper.PerformOperation(ImportFromStream, stream);
			MessageBox.Show("Import completed with success.", "Palette Import", MessageBoxButtons.OK);
		}
		catch (Exception ex)
		{
			if (!silent)
			{
				MessageBox.Show("Import has failed.\n\n Error:" + ex.Message, "Palette Import", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			throw ex;
		}
		finally
		{
			ResumeUpdates();
		}
	}

	public void Import(byte[] byteArray)
	{
		Import(byteArray, silent: true);
	}

	public void Import(byte[] byteArray, bool silent)
	{
		try
		{
			SuspendUpdates();
			if (silent)
			{
				ImportFromByteArray(byteArray);
				return;
			}
			CommonHelper.PerformOperation(ImportFromByteArray, byteArray);
			MessageBox.Show("Import completed with success.", "Palette Import", MessageBoxButtons.OK);
		}
		catch (Exception ex)
		{
			if (!silent)
			{
				MessageBox.Show("Import has failed.\n\n Error:" + ex.Message, "Palette Import", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			throw ex;
		}
		finally
		{
			ResumeUpdates();
		}
	}

	public string Export()
	{
		using (SaveFileDialog saveFileDialog = new SaveFileDialog())
		{
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.DefaultExt = "xml";
			saveFileDialog.Filter = "Palette files (*.xml)|*.xml|All files (*.*)|(*.*)";
			saveFileDialog.Title = "Save Palette As";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				return Export(saveFileDialog.FileName, ignoreDefaults: true, silent: false);
			}
		}
		return string.Empty;
	}

	public string Export(string filename, bool ignoreDefaults)
	{
		return Export(filename, ignoreDefaults, silent: true);
	}

	public string Export(string filename, bool ignoreDefaults, bool silent)
	{
		string result = string.Empty;
		try
		{
			SuspendUpdates();
			if (silent)
			{
				result = (string)ExportToFile(new object[2] { filename, ignoreDefaults });
			}
			else
			{
				result = (string)CommonHelper.PerformOperation(ExportToFile, new object[2] { filename, ignoreDefaults });
				MessageBox.Show("Export to file '" + filename + "' completed.", "Palette Export", MessageBoxButtons.OK);
			}
		}
		catch (Exception ex)
		{
			if (!silent)
			{
				MessageBox.Show("Export to file '" + filename + "' failed.\n\n Error:" + ex.Message, "Palette Export", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			throw ex;
		}
		finally
		{
			ResumeUpdates();
		}
		return result;
	}

	public void Export(Stream stream, bool ignoreDefaults)
	{
		Export(stream, ignoreDefaults, silent: true);
	}

	public void Export(Stream stream, bool ignoreDefaults, bool silent)
	{
		try
		{
			SuspendUpdates();
			if (silent)
			{
				ExportToStream(new object[2] { stream, ignoreDefaults });
			}
			else
			{
				CommonHelper.PerformOperation(ExportToStream, new object[2] { stream, ignoreDefaults });
				MessageBox.Show("Export completed with success.", "Palette Export", MessageBoxButtons.OK);
			}
		}
		catch (Exception ex)
		{
			if (!silent)
			{
				MessageBox.Show("Export has failed.\n\n Error:" + ex.Message, "Palette Export", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			throw ex;
		}
		finally
		{
			ResumeUpdates();
		}
	}

	public byte[] Export(bool ignoreDefaults)
	{
		return Export(ignoreDefaults, silent: true);
	}

	public byte[] Export(bool ignoreDefaults, bool silent)
	{
		byte[] result = null;
		try
		{
			SuspendUpdates();
			if (silent)
			{
				result = (byte[])ExportToByteArray(new object[1] { ignoreDefaults });
			}
			else
			{
				result = (byte[])CommonHelper.PerformOperation(ExportToByteArray, new object[1] { ignoreDefaults });
				MessageBox.Show("Export completed with success.", "Palette Export", MessageBoxButtons.OK);
			}
		}
		catch (Exception ex)
		{
			if (!silent)
			{
				MessageBox.Show("Export has failed.\n\n Error:" + ex.Message, "Palette Export", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			throw ex;
		}
		finally
		{
			ResumeUpdates();
		}
		return result;
	}

	private bool ShouldSerializeBasePaletteMode()
	{
		return BasePaletteMode != PaletteMode.Office2010Blue;
	}

	public void ResetBasePaletteMode()
	{
		BasePaletteMode = PaletteMode.Office2010Blue;
	}

	public void ResetBasePalette()
	{
		BasePaletteMode = PaletteMode.Office2010Blue;
	}

	public void ResetBaseRendererMode()
	{
		BaseRenderMode = RendererMode.Inherit;
	}

	protected virtual void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
	{
		if (_suspendCount == 0 && this.PalettePaint != null)
		{
			this.PalettePaint(this, e);
		}
	}

	protected virtual void OnAllowFormChromeChanged(object sender, EventArgs e)
	{
		if (_suspendCount == 0 && this.AllowFormChromeChanged != null)
		{
			this.AllowFormChromeChanged(this, e);
		}
	}

	protected virtual void OnBasePaletteChanged(object sender, EventArgs e)
	{
		if (_suspendCount == 0 && this.BasePaletteChanged != null)
		{
			this.BasePaletteChanged(this, e);
		}
	}

	protected virtual void OnBaseRendererChanged(object sender, EventArgs e)
	{
		if (_suspendCount == 0 && this.BaseRendererChanged != null)
		{
			this.BaseRendererChanged(this, e);
		}
	}

	protected virtual void OnButtonSpecChanged(object sender, EventArgs e)
	{
		if (_suspendCount == 0 && this.ButtonSpecChanged != null)
		{
			this.ButtonSpecChanged(this, e);
		}
	}

	internal bool HasCircularReference()
	{
		Dictionary<IPalette, bool> dictionary = new Dictionary<IPalette, bool>();
		IPalette palette = this;
		while (palette != null)
		{
			if (dictionary.ContainsKey(palette))
			{
				return true;
			}
			dictionary.Add(palette, value: true);
			if (palette is KryptonPalette)
			{
				KryptonPalette kryptonPalette = (KryptonPalette)palette;
				palette = ((kryptonPalette.BasePaletteMode != PaletteMode.Custom) ? ((kryptonPalette.BasePaletteMode != PaletteMode.Global) ? null : KryptonManager.InternalGlobalPalette) : kryptonPalette.BasePalette);
			}
			else
			{
				palette = null;
			}
		}
		return false;
	}

	private object ResetOperation(object parameter)
	{
		ResetObjectToDefault(this, populate: false);
		return null;
	}

	private object PopulateFromBaseOperation(object parameter)
	{
		ResetObjectToDefault(this, populate: true);
		_allowFormChrome = _basePalette.GetAllowFormChrome();
		_buttons.PopulateFromBase(Common);
		_calendarDay.PopulateFromBase();
		_buttonSpecs.PopulateFromBase();
		_controls.PopulateFromBase(Common);
		_contextMenu.PopulateFromBase(Common);
		_dragDrop.PopulateFromBase();
		_forms.PopulateFromBase(Common);
		_grids.PopulateFromBase(Common);
		_headers.PopulateFromBase(Common);
		_headerGroup.PopulateFromBase();
		_images.PopulateFromBase();
		_inputControls.PopulateFromBase(Common);
		_labels.PopulateFromBase(Common);
		_navigator.PopulateFromBase();
		_panels.PopulateFromBase(Common);
		_ribbon.PopulateFromBase();
		_separators.PopulateFromBase(Common);
		_tabs.PopulateFromBase(Common);
		_trackBar.PopulateFromBase();
		_toolMenuStatus.PopulateFromBase();
		return null;
	}

	private object ImportFromFile(object parameter)
	{
		string text = (string)parameter;
		FileInfo fileInfo = new FileInfo(text);
		if (!fileInfo.Exists)
		{
			throw new ArgumentException("Provided file does not exist.");
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(text);
		ImportFromXmlDocument(xmlDocument);
		return text;
	}

	private object ImportFromStream(object parameter)
	{
		Stream stream = (Stream)parameter;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(stream);
		ImportFromXmlDocument(xmlDocument);
		return stream;
	}

	private object ImportFromByteArray(object parameter)
	{
		byte[] buffer = (byte[])parameter;
		MemoryStream memoryStream = new MemoryStream(buffer);
		ImportFromStream(memoryStream);
		memoryStream.Close();
		return null;
	}

	private void ImportFromXmlDocument(XmlDocument doc)
	{
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		try
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			if (!doc.HasChildNodes)
			{
				throw new ArgumentException("Xml document does not have a root element.");
			}
			XmlElement xmlElement = (XmlElement)doc.SelectSingleNode("KryptonPalette");
			if (xmlElement == null)
			{
				throw new ArgumentException("Root element must be called 'KryptonPalette'.");
			}
			if (!xmlElement.HasAttribute("Version"))
			{
				throw new ArgumentException("Root element must have an attribute called 'Version'.");
			}
			int num = int.Parse(xmlElement.GetAttribute("Version"));
			if (num < _paletteVersion)
			{
				throw new ArgumentException("Version '" + num + "' number is incompatible, only version " + _paletteVersion + " or above can be imported.\nUse the PaletteUpgradeTool from the Application tab of the KryptonExplorer to upgrade.");
			}
			XmlElement xmlElement2 = (XmlElement)xmlElement.SelectSingleNode("Properties");
			XmlElement xmlElement3 = (XmlElement)xmlElement.SelectSingleNode("Images");
			if (xmlElement2 == null)
			{
				throw new ArgumentException("Element 'Properties' missing from the 'KryptonPalette'.");
			}
			if (xmlElement3 == null)
			{
				throw new ArgumentException("Element 'Images' missing from the 'KryptonPalette'.");
			}
			ImageReverseDictionary imageCache = new ImageReverseDictionary();
			ImportImagesFromElement(doc, xmlElement3, imageCache);
			ImportObjectFromElement(doc, xmlElement2, imageCache, this);
		}
		finally
		{
			Thread.CurrentThread.CurrentCulture = currentCulture;
		}
	}

	private object ExportToFile(object parameter)
	{
		object[] array = (object[])parameter;
		string text = (string)array[0];
		bool ignoreDefaults = (bool)array[1];
		FileInfo fileInfo = new FileInfo(text);
		if (!fileInfo.Directory.Exists)
		{
			throw new ArgumentException("Provided directory does not exist.");
		}
		XmlDocument xmlDocument = ExportToXmlDocument(ignoreDefaults);
		xmlDocument.Save(text);
		return text;
	}

	private object ExportToStream(object parameter)
	{
		object[] array = (object[])parameter;
		Stream stream = (Stream)array[0];
		bool ignoreDefaults = (bool)array[1];
		XmlDocument xmlDocument = ExportToXmlDocument(ignoreDefaults);
		xmlDocument.Save(stream);
		return stream;
	}

	private object ExportToByteArray(object parameter)
	{
		object[] array = (object[])parameter;
		bool flag = (bool)array[0];
		MemoryStream memoryStream = new MemoryStream();
		ExportToStream(new object[2] { memoryStream, flag });
		memoryStream.Close();
		return memoryStream.GetBuffer();
	}

	private XmlDocument ExportToXmlDocument(bool ignoreDefaults)
	{
		CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
		try
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.AppendChild(xmlDocument.CreateProcessingInstruction("xml", "version=\"1.0\""));
			xmlDocument.AppendChild(xmlDocument.CreateComment("Created by exporting the settings of a KryptonPalette instance."));
			xmlDocument.AppendChild(xmlDocument.CreateComment("For more information about Krypton visit www.ComponentFactory.com"));
			xmlDocument.AppendChild(xmlDocument.CreateComment("WARNING: Modifying this file may render it invalid for importing."));
			XmlElement xmlElement = xmlDocument.CreateElement("KryptonPalette");
			xmlElement.SetAttribute("Version", _paletteVersion.ToString());
			xmlElement.SetAttribute("Generated", DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToShortTimeString());
			xmlDocument.AppendChild(xmlElement);
			XmlElement xmlElement2 = xmlDocument.CreateElement("Properties");
			XmlElement xmlElement3 = xmlDocument.CreateElement("Images");
			xmlElement.AppendChild(xmlElement2);
			xmlElement.AppendChild(xmlElement3);
			ImageDictionary imageCache = new ImageDictionary();
			ExportObjectToElement(xmlDocument, xmlElement2, imageCache, this, ignoreDefaults);
			ExportImagesToElement(xmlDocument, xmlElement3, imageCache);
			return xmlDocument;
		}
		finally
		{
			Thread.CurrentThread.CurrentCulture = currentCulture;
		}
	}

	private void ImportObjectFromElement(XmlDocument doc, XmlElement element, ImageReverseDictionary imageCache, object obj)
	{
		if (obj == null)
		{
			return;
		}
		Type type = obj.GetType();
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			object[] customAttributes = propertyInfo.GetCustomAttributes(inherit: false);
			foreach (object obj2 in customAttributes)
			{
				if (!(obj2 is KryptonPersistAttribute))
				{
					continue;
				}
				KryptonPersistAttribute kryptonPersistAttribute = (KryptonPersistAttribute)obj2;
				XmlElement xmlElement = (XmlElement)element.SelectSingleNode(propertyInfo.Name);
				if (xmlElement == null)
				{
					continue;
				}
				if (kryptonPersistAttribute.Navigate)
				{
					if (propertyInfo.CanRead)
					{
						object value = propertyInfo.GetValue(obj, null);
						ImportObjectFromElement(doc, xmlElement, imageCache, value);
					}
				}
				else
				{
					if (!xmlElement.HasAttribute("Type") || !xmlElement.HasAttribute("Value"))
					{
						continue;
					}
					string attribute = xmlElement.GetAttribute("Type");
					string attribute2 = xmlElement.GetAttribute("Value");
					if (propertyInfo.PropertyType.Equals(typeof(Image)))
					{
						if (attribute2.Length == 0)
						{
							propertyInfo.SetValue(obj, null, null);
						}
						else if (imageCache.ContainsKey(attribute2))
						{
							propertyInfo.SetValue(obj, imageCache[attribute2], null);
						}
						else
						{
							propertyInfo.SetValue(obj, null, null);
						}
						continue;
					}
					object value2 = null;
					if (attribute != "Font" || attribute2 != "(none)")
					{
						TypeConverter converter = TypeDescriptor.GetConverter(StringToType(attribute));
						value2 = converter.ConvertFromInvariantString(attribute2);
					}
					propertyInfo.SetValue(obj, value2, null);
				}
			}
		}
	}

	private void ImportImagesFromElement(XmlDocument doc, XmlElement element, ImageReverseDictionary imageCache)
	{
		XmlNodeList xmlNodeList = element.SelectNodes("Image");
		foreach (XmlNode item in xmlNodeList)
		{
			XmlElement xmlElement = (XmlElement)item;
			if (xmlElement != null && xmlElement.HasAttribute("Name") && xmlElement.ChildNodes.Count == 1 && xmlElement.ChildNodes[0].NodeType == XmlNodeType.CDATA)
			{
				try
				{
					string attribute = xmlElement.GetAttribute("Name");
					XmlCDataSection xmlCDataSection = (XmlCDataSection)xmlElement.ChildNodes[0];
					byte[] buffer = Convert.FromBase64String(xmlCDataSection.Value);
					MemoryStream serializationStream = new MemoryStream(buffer);
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					Image value = (Image)binaryFormatter.Deserialize(serializationStream);
					imageCache.Add(attribute, value);
				}
				catch (SerializationException)
				{
				}
			}
		}
	}

	private void ExportObjectToElement(XmlDocument doc, XmlElement element, ImageDictionary imageCache, object obj, bool ignoreDefaults)
	{
		if (obj == null)
		{
			return;
		}
		Type type = obj.GetType();
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			object[] customAttributes = propertyInfo.GetCustomAttributes(inherit: false);
			foreach (object obj2 in customAttributes)
			{
				if (!(obj2 is KryptonPersistAttribute))
				{
					continue;
				}
				KryptonPersistAttribute kryptonPersistAttribute = (KryptonPersistAttribute)obj2;
				if (kryptonPersistAttribute.Navigate)
				{
					if (!propertyInfo.CanRead)
					{
						continue;
					}
					object obj3 = propertyInfo.GetValue(obj, null);
					if (ignoreDefaults)
					{
						PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(obj3)["IsDefault"];
						if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(bool) && (bool)propertyDescriptor.GetValue(obj3))
						{
							obj3 = null;
						}
					}
					if (obj3 != null)
					{
						XmlElement xmlElement = doc.CreateElement(propertyInfo.Name);
						element.AppendChild(xmlElement);
						ExportObjectToElement(doc, xmlElement, imageCache, obj3, ignoreDefaults);
					}
					continue;
				}
				bool flag = false;
				object value = propertyInfo.GetValue(obj, null);
				if (ignoreDefaults)
				{
					object[] customAttributes2 = propertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), inherit: false);
					if (customAttributes2.Length == 1)
					{
						DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)customAttributes2[0];
						flag = ((defaultValueAttribute.Value != null) ? defaultValueAttribute.Value.Equals(value) : (value == null));
					}
				}
				if (flag)
				{
					continue;
				}
				XmlElement xmlElement2 = doc.CreateElement(propertyInfo.Name);
				element.AppendChild(xmlElement2);
				xmlElement2.SetAttribute("Type", TypeToString(propertyInfo.PropertyType));
				if (propertyInfo.PropertyType.Equals(typeof(Image)))
				{
					if (value == null)
					{
						xmlElement2.SetAttribute("Value", "");
						continue;
					}
					Image key = (Image)value;
					if (imageCache.ContainsKey(key))
					{
						xmlElement2.SetAttribute("Value", imageCache[key]);
						continue;
					}
					string value2 = "ImageCache" + (imageCache.Count + 1);
					imageCache.Add(key, value2);
					xmlElement2.SetAttribute("Value", value2);
				}
				else
				{
					TypeConverter converter = TypeDescriptor.GetConverter(propertyInfo.PropertyType);
					xmlElement2.SetAttribute("Value", converter.ConvertToInvariantString(value));
				}
			}
		}
	}

	private void ExportImagesToElement(XmlDocument doc, XmlElement element, ImageDictionary imageCache)
	{
		foreach (KeyValuePair<Image, string> item in imageCache)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, item.Key);
				string data = Convert.ToBase64String(memoryStream.ToArray());
				XmlElement xmlElement = doc.CreateElement("Image");
				xmlElement.SetAttribute("Name", item.Value);
				element.AppendChild(xmlElement);
				XmlCDataSection newChild = doc.CreateCDataSection(data);
				xmlElement.AppendChild(newChild);
			}
			catch (SerializationException)
			{
			}
		}
	}

	private void ResetObjectToDefault(object obj, bool populate)
	{
		if (obj == null)
		{
			return;
		}
		Type type = obj.GetType();
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			object[] customAttributes = propertyInfo.GetCustomAttributes(inherit: false);
			foreach (object obj2 in customAttributes)
			{
				if (!(obj2 is KryptonPersistAttribute))
				{
					continue;
				}
				KryptonPersistAttribute kryptonPersistAttribute = (KryptonPersistAttribute)obj2;
				if (kryptonPersistAttribute.Navigate)
				{
					if (propertyInfo.CanRead)
					{
						object obj3 = propertyInfo.GetValue(obj, null);
						PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(obj3)["IsDefault"];
						if (propertyDescriptor != null && propertyDescriptor.PropertyType == typeof(bool) && (bool)propertyDescriptor.GetValue(obj3))
						{
							obj3 = null;
						}
						if (obj3 != null)
						{
							ResetObjectToDefault(obj3, populate);
						}
					}
				}
				else
				{
					if (populate && !kryptonPersistAttribute.Populate)
					{
						continue;
					}
					object[] customAttributes2 = propertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), inherit: false);
					if (customAttributes2.Length != 1)
					{
						continue;
					}
					DefaultValueAttribute defaultValueAttribute = (DefaultValueAttribute)customAttributes2[0];
					object value = propertyInfo.GetValue(obj, null);
					if (defaultValueAttribute.Value == null)
					{
						if (value != null)
						{
							propertyInfo.SetValue(obj, null, null);
						}
					}
					else if (!defaultValueAttribute.Value.Equals(value))
					{
						propertyInfo.SetValue(obj, defaultValueAttribute.Value, null);
					}
				}
			}
		}
	}

	private string TypeToString(Type t)
	{
		if (t.Equals(typeof(string)))
		{
			return "String";
		}
		if (t.Equals(typeof(int)))
		{
			return "Int";
		}
		if (t.Equals(typeof(float)))
		{
			return "Single";
		}
		if (t.Equals(typeof(bool)))
		{
			return "Bool";
		}
		if (t.Equals(typeof(Color)))
		{
			return "Color";
		}
		if (t.Equals(typeof(Image)))
		{
			return "Image";
		}
		if (t.Equals(typeof(Font)))
		{
			return "Font";
		}
		if (t.Equals(typeof(Padding)))
		{
			return "Padding";
		}
		if (t.Equals(typeof(InheritBool)))
		{
			return "InheritBool";
		}
		if (t.Equals(typeof(PaletteRectangleAlign)))
		{
			return "PaletteRectangleAlign";
		}
		if (t.Equals(typeof(PaletteRelativeAlign)))
		{
			return "PaletteRelativeAlign";
		}
		if (t.Equals(typeof(PaletteImageEffect)))
		{
			return "PaletteImageEffect";
		}
		if (t.Equals(typeof(PaletteImageStyle)))
		{
			return "PaletteImageStyle";
		}
		if (t.Equals(typeof(PaletteTextHint)))
		{
			return "PaletteTextHint";
		}
		if (t.Equals(typeof(PaletteTextHotkeyPrefix)))
		{
			return "PaletteTextHotkeyPrefix";
		}
		if (t.Equals(typeof(PaletteTextTrim)))
		{
			return "PaletteTextTrim";
		}
		if (t.Equals(typeof(PaletteColorStyle)))
		{
			return "PaletteColorStyle";
		}
		if (t.Equals(typeof(PaletteGraphicsHint)))
		{
			return "PaletteGraphicsHint";
		}
		if (t.Equals(typeof(PaletteMode)))
		{
			return "PaletteMode";
		}
		if (t.Equals(typeof(PaletteButtonStyle)))
		{
			return "PaletteButtonStyle";
		}
		if (t.Equals(typeof(PaletteButtonOrientation)))
		{
			return "PaletteButtonOrientation";
		}
		if (t.Equals(typeof(PaletteRelativeEdgeAlign)))
		{
			return "PaletteRelativeEdgeAlign";
		}
		if (t.Equals(typeof(RendererMode)))
		{
			return "RendererMode";
		}
		if (t.Equals(typeof(PaletteDrawBorders)))
		{
			return "PaletteDrawBorders";
		}
		if (t.Equals(typeof(PaletteContentText)))
		{
			return "PaletteContentText";
		}
		if (t.Equals(typeof(PaletteContentImage)))
		{
			return "PaletteContentImage";
		}
		if (t.Equals(typeof(PaletteDragFeedback)))
		{
			return "PaletteDragFeedback";
		}
		if (t.Equals(typeof(PaletteRibbonShape)))
		{
			return "PaletteRibbonShape";
		}
		throw new ApplicationException("Unrecognised type '" + t.ToString() + "' for export.");
	}

	private Type StringToType(string s)
	{
		return s switch
		{
			"String" => typeof(string), 
			"Int" => typeof(int), 
			"Single" => typeof(float), 
			"Bool" => typeof(bool), 
			"Color" => typeof(Color), 
			"Image" => typeof(Image), 
			"Font" => typeof(Font), 
			"Padding" => typeof(Padding), 
			"InheritBool" => typeof(InheritBool), 
			"PaletteRectangleAlign" => typeof(PaletteRectangleAlign), 
			"PaletteRelativeAlign" => typeof(PaletteRelativeAlign), 
			"PaletteImageEffect" => typeof(PaletteImageEffect), 
			"PaletteImageStyle" => typeof(PaletteImageStyle), 
			"PaletteTextHint" => typeof(PaletteTextHint), 
			"PaletteTextTrim" => typeof(PaletteTextTrim), 
			"PaletteTextHotkeyPrefix" => typeof(PaletteTextHotkeyPrefix), 
			"PaletteColorStyle" => typeof(PaletteColorStyle), 
			"PaletteGraphicsHint" => typeof(PaletteGraphicsHint), 
			"PaletteMode" => typeof(PaletteMode), 
			"PaletteButtonStyle" => typeof(PaletteButtonStyle), 
			"PaletteButtonOrientation" => typeof(PaletteButtonOrientation), 
			"PaletteRelativeEdgeAlign" => typeof(PaletteRelativeEdgeAlign), 
			"RendererMode" => typeof(RendererMode), 
			"PaletteDrawBorders" => typeof(PaletteDrawBorders), 
			"PaletteContentText" => typeof(PaletteContentText), 
			"PaletteContentImage" => typeof(PaletteContentImage), 
			"PaletteDragFeedback" => typeof(PaletteDragFeedback), 
			"PaletteRibbonShape" => typeof(PaletteRibbonShape), 
			_ => throw new ApplicationException("Unrecognised type '" + s + "' for import."), 
		};
	}

	private PaletteElementColor GetTrackBar(PaletteElement element, PaletteState state)
	{
		switch (element)
		{
		case PaletteElement.TrackBarTick:
			switch (state)
			{
			case PaletteState.Normal:
				return _trackBar.StateNormal.Tick;
			case PaletteState.Disabled:
				return _trackBar.StateDisabled.Tick;
			case PaletteState.FocusOverride:
				return _trackBar.OverrideFocus.Tick;
			default:
				Debug.Assert(condition: false);
				return null;
			}
		case PaletteElement.TrackBarTrack:
			switch (state)
			{
			case PaletteState.Normal:
				return _trackBar.StateNormal.Track;
			case PaletteState.Disabled:
				return _trackBar.StateDisabled.Track;
			case PaletteState.FocusOverride:
				return _trackBar.OverrideFocus.Track;
			default:
				Debug.Assert(condition: false);
				return null;
			}
		case PaletteElement.TrackBarPosition:
			switch (state)
			{
			case PaletteState.Normal:
				return _trackBar.StateNormal.Position;
			case PaletteState.Disabled:
				return _trackBar.StateDisabled.Position;
			case PaletteState.Tracking:
				return _trackBar.StateTracking.Position;
			case PaletteState.Pressed:
				return _trackBar.StatePressed.Position;
			case PaletteState.FocusOverride:
				return _trackBar.OverrideFocus.Position;
			default:
				Debug.Assert(condition: false);
				return null;
			}
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonGeneral GetPaletteRibbonGeneral()
	{
		return Ribbon.RibbonGeneral;
	}

	private IPaletteRibbonGeneral GetPaletteRibbonGeneral(PaletteState state)
	{
		return Ribbon.RibbonGeneral;
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(PaletteRibbonBackStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonBackStyle.RibbonAppButton:
			return GetPaletteRibbonBack(Ribbon.RibbonAppButton, state);
		case PaletteRibbonBackStyle.RibbonAppMenuDocs:
			return Ribbon.RibbonAppMenuDocs;
		case PaletteRibbonBackStyle.RibbonAppMenuInner:
			return Ribbon.RibbonAppMenuInner;
		case PaletteRibbonBackStyle.RibbonAppMenuOuter:
			return Ribbon.RibbonAppMenuOuter;
		case PaletteRibbonBackStyle.RibbonGroupArea:
			return GetPaletteRibbonBack(Ribbon.RibbonGroupArea, state);
		case PaletteRibbonBackStyle.RibbonGroupNormalBorder:
			return GetPaletteRibbonBack(Ribbon.RibbonGroupNormalBorder, state);
		case PaletteRibbonBackStyle.RibbonGroupNormalTitle:
			return GetPaletteRibbonBack(Ribbon.RibbonGroupNormalTitle, state);
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBorder:
			return GetPaletteRibbonBack(Ribbon.RibbonGroupCollapsedBorder, state);
		case PaletteRibbonBackStyle.RibbonGroupCollapsedBack:
			return GetPaletteRibbonBack(Ribbon.RibbonGroupCollapsedBack, state);
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBorder:
			return GetPaletteRibbonBack(Ribbon.RibbonGroupCollapsedFrameBorder, state);
		case PaletteRibbonBackStyle.RibbonGroupCollapsedFrameBack:
			return GetPaletteRibbonBack(Ribbon.RibbonGroupCollapsedFrameBack, state);
		case PaletteRibbonBackStyle.RibbonTab:
			return GetPaletteRibbonBack(Ribbon.RibbonTab, state);
		case PaletteRibbonBackStyle.RibbonQATFullbar:
			return Ribbon.RibbonQATFullbar;
		case PaletteRibbonBackStyle.RibbonQATMinibar:
			return GetPaletteRibbonBack(Ribbon.RibbonQATMinibar, state);
		case PaletteRibbonBackStyle.RibbonQATOverflow:
			return Ribbon.RibbonQATOverflow;
		case PaletteRibbonBackStyle.RibbonGalleryBack:
			return Ribbon.RibbonGalleryBack;
		case PaletteRibbonBackStyle.RibbonGalleryBorder:
			return Ribbon.RibbonGalleryBorder;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonTab ribbonTab, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
		case PaletteState.Normal:
			return ribbonTab.StateNormal;
		case PaletteState.Tracking:
		case PaletteState.Pressed:
			return ribbonTab.StateTracking;
		case PaletteState.CheckedNormal:
			return ribbonTab.StateCheckedNormal;
		case PaletteState.CheckedTracking:
		case PaletteState.CheckedPressed:
			return ribbonTab.StateCheckedTracking;
		case PaletteState.ContextTracking:
			return ribbonTab.StateContextTracking;
		case PaletteState.ContextCheckedNormal:
			return ribbonTab.StateContextCheckedNormal;
		case PaletteState.ContextCheckedTracking:
			return ribbonTab.StateContextCheckedTracking;
		case PaletteState.FocusOverride:
			return ribbonTab.OverrideFocus;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonAppButton ribbonAppButton, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonAppButton.StateNormal;
		case PaletteState.Tracking:
			return ribbonAppButton.StateTracking;
		case PaletteState.Pressed:
			return ribbonAppButton.StatePressed;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonGroupArea ribbonGroupArea, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
		case PaletteState.CheckedNormal:
			return ribbonGroupArea.StateCheckedNormal;
		case PaletteState.ContextCheckedNormal:
			return ribbonGroupArea.StateContextCheckedNormal;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonGroupNormalBorder ribbonGroupNormalBorder, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupNormalBorder.StateNormal;
		case PaletteState.Tracking:
			return ribbonGroupNormalBorder.StateTracking;
		case PaletteState.ContextNormal:
			return ribbonGroupNormalBorder.StateContextNormal;
		case PaletteState.ContextTracking:
			return ribbonGroupNormalBorder.StateContextTracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonGroupNormalTitle ribbonGroupNormalTitle, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupNormalTitle.StateNormal;
		case PaletteState.Tracking:
			return ribbonGroupNormalTitle.StateTracking;
		case PaletteState.ContextNormal:
			return ribbonGroupNormalTitle.StateContextNormal;
		case PaletteState.ContextTracking:
			return ribbonGroupNormalTitle.StateContextTracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonGroupCollapsedBorder ribbonGroupCollapsedBorder, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupCollapsedBorder.StateNormal;
		case PaletteState.Tracking:
		case PaletteState.Pressed:
			return ribbonGroupCollapsedBorder.StateTracking;
		case PaletteState.ContextNormal:
			return ribbonGroupCollapsedBorder.StateContextNormal;
		case PaletteState.ContextTracking:
		case PaletteState.ContextPressed:
			return ribbonGroupCollapsedBorder.StateContextTracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonGroupCollapsedBack ribbonGroupCollapsedBack, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupCollapsedBack.StateNormal;
		case PaletteState.Tracking:
		case PaletteState.Pressed:
			return ribbonGroupCollapsedBack.StateTracking;
		case PaletteState.ContextNormal:
			return ribbonGroupCollapsedBack.StateContextNormal;
		case PaletteState.ContextTracking:
		case PaletteState.ContextPressed:
			return ribbonGroupCollapsedBack.StateContextTracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonGroupCollapsedFrameBorder ribbonGroupCollapsedFrameBorder, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupCollapsedFrameBorder.StateNormal;
		case PaletteState.Tracking:
		case PaletteState.Pressed:
			return ribbonGroupCollapsedFrameBorder.StateTracking;
		case PaletteState.ContextNormal:
			return ribbonGroupCollapsedFrameBorder.StateContextNormal;
		case PaletteState.ContextTracking:
		case PaletteState.ContextPressed:
			return ribbonGroupCollapsedFrameBorder.StateContextTracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonGroupCollapsedFrameBack ribbonGroupCollapsedFrameBack, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupCollapsedFrameBack.StateNormal;
		case PaletteState.Tracking:
		case PaletteState.Pressed:
			return ribbonGroupCollapsedFrameBack.StateTracking;
		case PaletteState.ContextNormal:
			return ribbonGroupCollapsedFrameBack.StateContextNormal;
		case PaletteState.ContextTracking:
		case PaletteState.ContextPressed:
			return ribbonGroupCollapsedFrameBack.StateContextTracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonBack GetPaletteRibbonBack(KryptonPaletteRibbonQATMinibar ribbonQATMinibar, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
		case PaletteState.CheckedNormal:
			return ribbonQATMinibar.StateActive;
		case PaletteState.Disabled:
			return ribbonQATMinibar.StateInactive;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonText GetPaletteRibbonText(PaletteRibbonTextStyle style, PaletteState state)
	{
		switch (style)
		{
		case PaletteRibbonTextStyle.RibbonAppMenuDocsEntry:
			return Ribbon.RibbonAppMenuDocsEntry;
		case PaletteRibbonTextStyle.RibbonAppMenuDocsTitle:
			return Ribbon.RibbonAppMenuDocsTitle;
		case PaletteRibbonTextStyle.RibbonGroupCheckBoxText:
			return GetPaletteRibbonText(Ribbon.RibbonGroupCheckBoxText, state);
		case PaletteRibbonTextStyle.RibbonGroupRadioButtonText:
			return GetPaletteRibbonText(Ribbon.RibbonGroupRadioButtonText, state);
		case PaletteRibbonTextStyle.RibbonGroupButtonText:
			return GetPaletteRibbonText(Ribbon.RibbonGroupButtonText, state);
		case PaletteRibbonTextStyle.RibbonGroupLabelText:
			return GetPaletteRibbonText(Ribbon.RibbonGroupLabelText, state);
		case PaletteRibbonTextStyle.RibbonGroupNormalTitle:
			return GetPaletteRibbonText(Ribbon.RibbonGroupNormalTitle, state);
		case PaletteRibbonTextStyle.RibbonGroupCollapsedText:
			return GetPaletteRibbonText(Ribbon.RibbonGroupCollapsedText, state);
		case PaletteRibbonTextStyle.RibbonTab:
			return GetPaletteRibbonText(Ribbon.RibbonTab, state);
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonText GetPaletteRibbonText(KryptonPaletteRibbonTab ribbonTab, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
		case PaletteState.Normal:
			return ribbonTab.StateNormal;
		case PaletteState.Tracking:
		case PaletteState.Pressed:
		case PaletteState.ContextTracking:
			return ribbonTab.StateTracking;
		case PaletteState.CheckedNormal:
		case PaletteState.ContextCheckedNormal:
			return ribbonTab.StateCheckedNormal;
		case PaletteState.CheckedTracking:
		case PaletteState.CheckedPressed:
		case PaletteState.ContextCheckedTracking:
			return ribbonTab.StateCheckedTracking;
		case PaletteState.FocusOverride:
			return ribbonTab.OverrideFocus;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonText GetPaletteRibbonText(KryptonPaletteRibbonGroupNormalTitle ribbonGroupNormalTitle, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupNormalTitle.StateNormal;
		case PaletteState.Tracking:
			return ribbonGroupNormalTitle.StateTracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonText GetPaletteRibbonText(KryptonPaletteRibbonGroupCollapsedText ribbonGroupCollapsedText, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupCollapsedText.StateNormal;
		case PaletteState.Tracking:
			return ribbonGroupCollapsedText.StateTracking;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteRibbonText GetPaletteRibbonText(KryptonPaletteRibbonGroupBaseText ribbonGroupButtonText, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Normal:
			return ribbonGroupButtonText.StateNormal;
		case PaletteState.Disabled:
			return ribbonGroupButtonText.StateDisabled;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteButtonSpec GetPaletteButtonSpec(PaletteButtonSpecStyle style)
	{
		switch (style)
		{
		case PaletteButtonSpecStyle.Generic:
			return ButtonSpecs.Generic;
		case PaletteButtonSpecStyle.Close:
			return ButtonSpecs.Close;
		case PaletteButtonSpecStyle.Context:
			return ButtonSpecs.Context;
		case PaletteButtonSpecStyle.Next:
			return ButtonSpecs.Next;
		case PaletteButtonSpecStyle.Previous:
			return ButtonSpecs.Previous;
		case PaletteButtonSpecStyle.ArrowLeft:
			return ButtonSpecs.ArrowLeft;
		case PaletteButtonSpecStyle.ArrowRight:
			return ButtonSpecs.ArrowRight;
		case PaletteButtonSpecStyle.ArrowUp:
			return ButtonSpecs.ArrowUp;
		case PaletteButtonSpecStyle.ArrowDown:
			return ButtonSpecs.ArrowDown;
		case PaletteButtonSpecStyle.DropDown:
			return ButtonSpecs.DropDown;
		case PaletteButtonSpecStyle.PinVertical:
			return ButtonSpecs.PinVertical;
		case PaletteButtonSpecStyle.PinHorizontal:
			return ButtonSpecs.PinHorizontal;
		case PaletteButtonSpecStyle.FormClose:
			return ButtonSpecs.FormClose;
		case PaletteButtonSpecStyle.FormMin:
			return ButtonSpecs.FormMin;
		case PaletteButtonSpecStyle.FormMax:
			return ButtonSpecs.FormMax;
		case PaletteButtonSpecStyle.FormRestore:
			return ButtonSpecs.FormRestore;
		case PaletteButtonSpecStyle.PendantClose:
			return ButtonSpecs.PendantClose;
		case PaletteButtonSpecStyle.PendantMin:
			return ButtonSpecs.PendantMin;
		case PaletteButtonSpecStyle.PendantRestore:
			return ButtonSpecs.PendantRestore;
		case PaletteButtonSpecStyle.WorkspaceMaximize:
			return ButtonSpecs.WorkspaceMaximize;
		case PaletteButtonSpecStyle.WorkspaceRestore:
			return ButtonSpecs.WorkspaceRestore;
		case PaletteButtonSpecStyle.RibbonMinimize:
			return ButtonSpecs.RibbonMinimize;
		case PaletteButtonSpecStyle.RibbonExpand:
			return ButtonSpecs.RibbonExpand;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteBack GetPaletteBack(PaletteBackStyle style, PaletteState state)
	{
		Common.StateCommon.BackStyle = style;
		switch (style)
		{
		case PaletteBackStyle.ButtonStandalone:
			return GetPaletteBackButton(ButtonStyles.ButtonStandalone, state);
		case PaletteBackStyle.ButtonAlternate:
			return GetPaletteBackButton(ButtonStyles.ButtonAlternate, state);
		case PaletteBackStyle.ButtonLowProfile:
			return GetPaletteBackButton(ButtonStyles.ButtonLowProfile, state);
		case PaletteBackStyle.ButtonButtonSpec:
			return GetPaletteBackButton(ButtonStyles.ButtonButtonSpec, state);
		case PaletteBackStyle.ButtonBreadCrumb:
			return GetPaletteBackButton(ButtonStyles.ButtonBreadCrumb, state);
		case PaletteBackStyle.ButtonCalendarDay:
			return GetPaletteBackCalendarDay(CalendarDay, state);
		case PaletteBackStyle.ButtonCluster:
			return GetPaletteBackButton(ButtonStyles.ButtonCluster, state);
		case PaletteBackStyle.ButtonGallery:
			return GetPaletteBackButton(ButtonStyles.ButtonGallery, state);
		case PaletteBackStyle.ButtonNavigatorStack:
			return GetPaletteBackButton(ButtonStyles.ButtonNavigatorStack, state);
		case PaletteBackStyle.ButtonNavigatorOverflow:
			return GetPaletteBackButton(ButtonStyles.ButtonNavigatorOverflow, state);
		case PaletteBackStyle.ButtonNavigatorMini:
			return GetPaletteBackButton(ButtonStyles.ButtonNavigatorMini, state);
		case PaletteBackStyle.ButtonInputControl:
			return GetPaletteBackButton(ButtonStyles.ButtonInputControl, state);
		case PaletteBackStyle.ButtonListItem:
			return GetPaletteBackButton(ButtonStyles.ButtonListItem, state);
		case PaletteBackStyle.ButtonForm:
			return GetPaletteBackButton(ButtonStyles.ButtonForm, state);
		case PaletteBackStyle.ButtonFormClose:
			return GetPaletteBackButton(ButtonStyles.ButtonFormClose, state);
		case PaletteBackStyle.ButtonCommand:
			return GetPaletteBackButton(ButtonStyles.ButtonCommand, state);
		case PaletteBackStyle.ButtonCustom1:
			return GetPaletteBackButton(ButtonStyles.ButtonCustom1, state);
		case PaletteBackStyle.ButtonCustom2:
			return GetPaletteBackButton(ButtonStyles.ButtonCustom2, state);
		case PaletteBackStyle.ButtonCustom3:
			return GetPaletteBackButton(ButtonStyles.ButtonCustom3, state);
		case PaletteBackStyle.ControlClient:
			return GetPaletteBackControl(ControlStyles.ControlClient, state);
		case PaletteBackStyle.ControlAlternate:
			return GetPaletteBackControl(ControlStyles.ControlAlternate, state);
		case PaletteBackStyle.ControlGroupBox:
			return GetPaletteBackControl(ControlStyles.ControlGroupBox, state);
		case PaletteBackStyle.ControlToolTip:
			return GetPaletteBackControl(ControlStyles.ControlToolTip, state);
		case PaletteBackStyle.ControlRibbon:
			return GetPaletteBackControl(ControlStyles.ControlRibbon, state);
		case PaletteBackStyle.ControlRibbonAppMenu:
			return GetPaletteBackControl(ControlStyles.ControlRibbonAppMenu, state);
		case PaletteBackStyle.ControlCustom1:
			return GetPaletteBackControl(ControlStyles.ControlCustom1, state);
		case PaletteBackStyle.InputControlStandalone:
			return GetPaletteInputControl(InputControlStyles.InputControlStandalone, state).Back;
		case PaletteBackStyle.InputControlRibbon:
			return GetPaletteInputControl(InputControlStyles.InputControlRibbon, state).Back;
		case PaletteBackStyle.InputControlCustom1:
			return GetPaletteInputControl(InputControlStyles.InputControlCustom1, state).Back;
		case PaletteBackStyle.FormMain:
			return GetPaletteBackForm(FormStyles.FormMain, state);
		case PaletteBackStyle.FormCustom1:
			return GetPaletteBackForm(FormStyles.FormCustom1, state);
		case PaletteBackStyle.GridBackgroundList:
			return GetPaletteBackGridBackground(GridStyles.GridList, state);
		case PaletteBackStyle.GridBackgroundSheet:
			return GetPaletteBackGridBackground(GridStyles.GridSheet, state);
		case PaletteBackStyle.GridBackgroundCustom1:
			return GetPaletteBackGridBackground(GridStyles.GridCustom1, state);
		case PaletteBackStyle.GridHeaderColumnList:
			return GetPaletteBackGridHeaderColumn(GridStyles.GridList, state);
		case PaletteBackStyle.GridHeaderColumnSheet:
			return GetPaletteBackGridHeaderColumn(GridStyles.GridSheet, state);
		case PaletteBackStyle.GridHeaderColumnCustom1:
			return GetPaletteBackGridHeaderColumn(GridStyles.GridCustom1, state);
		case PaletteBackStyle.GridHeaderRowList:
			return GetPaletteBackGridHeaderRow(GridStyles.GridList, state);
		case PaletteBackStyle.GridHeaderRowSheet:
			return GetPaletteBackGridHeaderRow(GridStyles.GridSheet, state);
		case PaletteBackStyle.GridHeaderRowCustom1:
			return GetPaletteBackGridHeaderRow(GridStyles.GridCustom1, state);
		case PaletteBackStyle.GridDataCellList:
			return GetPaletteBackGridDataCell(GridStyles.GridList, state);
		case PaletteBackStyle.GridDataCellSheet:
			return GetPaletteBackGridDataCell(GridStyles.GridSheet, state);
		case PaletteBackStyle.GridDataCellCustom1:
			return GetPaletteBackGridDataCell(GridStyles.GridCustom1, state);
		case PaletteBackStyle.HeaderPrimary:
			return GetPaletteBackHeader(HeaderStyles.HeaderPrimary, state);
		case PaletteBackStyle.HeaderSecondary:
			return GetPaletteBackHeader(HeaderStyles.HeaderSecondary, state);
		case PaletteBackStyle.HeaderDockInactive:
			return GetPaletteBackHeader(HeaderStyles.HeaderDockInactive, state);
		case PaletteBackStyle.HeaderDockActive:
			return GetPaletteBackHeader(HeaderStyles.HeaderDockActive, state);
		case PaletteBackStyle.HeaderCalendar:
			return GetPaletteBackHeader(HeaderStyles.HeaderCalendar, state);
		case PaletteBackStyle.HeaderForm:
			return GetPaletteBackHeader(HeaderStyles.HeaderForm, state);
		case PaletteBackStyle.HeaderCustom1:
			return GetPaletteBackHeader(HeaderStyles.HeaderCustom1, state);
		case PaletteBackStyle.HeaderCustom2:
			return GetPaletteBackHeader(HeaderStyles.HeaderCustom2, state);
		case PaletteBackStyle.PanelClient:
			return GetPalettePanel(PanelStyles.PanelClient, state);
		case PaletteBackStyle.PanelAlternate:
			return GetPalettePanel(PanelStyles.PanelAlternate, state);
		case PaletteBackStyle.PanelRibbonInactive:
			return GetPalettePanel(PanelStyles.PanelRibbonInactive, state);
		case PaletteBackStyle.PanelCustom1:
			return GetPalettePanel(PanelStyles.PanelCustom1, state);
		case PaletteBackStyle.SeparatorLowProfile:
			return GetPaletteBackSeparator(SeparatorStyles.SeparatorLowProfile, state);
		case PaletteBackStyle.SeparatorHighProfile:
			return GetPaletteBackSeparator(SeparatorStyles.SeparatorHighProfile, state);
		case PaletteBackStyle.SeparatorHighInternalProfile:
			return GetPaletteBackSeparator(SeparatorStyles.SeparatorHighInternalProfile, state);
		case PaletteBackStyle.SeparatorCustom1:
			return GetPaletteBackSeparator(SeparatorStyles.SeparatorCustom1, state);
		case PaletteBackStyle.TabHighProfile:
			return GetPaletteBackTab(TabStyles.TabHighProfile, state);
		case PaletteBackStyle.TabStandardProfile:
			return GetPaletteBackTab(TabStyles.TabStandardProfile, state);
		case PaletteBackStyle.TabLowProfile:
			return GetPaletteBackTab(TabStyles.TabLowProfile, state);
		case PaletteBackStyle.TabDock:
			return GetPaletteBackTab(TabStyles.TabDock, state);
		case PaletteBackStyle.TabDockAutoHidden:
			return GetPaletteBackTab(TabStyles.TabDockAutoHidden, state);
		case PaletteBackStyle.TabOneNote:
			return GetPaletteBackTab(TabStyles.TabOneNote, state);
		case PaletteBackStyle.TabCustom1:
			return GetPaletteBackTab(TabStyles.TabCustom1, state);
		case PaletteBackStyle.TabCustom2:
			return GetPaletteBackTab(TabStyles.TabCustom2, state);
		case PaletteBackStyle.TabCustom3:
			return GetPaletteBackTab(TabStyles.TabCustom3, state);
		case PaletteBackStyle.ContextMenuOuter:
			return ContextMenu.StateCommon.ControlOuter.Back;
		case PaletteBackStyle.ContextMenuInner:
			return ContextMenu.StateCommon.ControlInner.Back;
		case PaletteBackStyle.ContextMenuHeading:
			return ContextMenu.StateCommon.Heading.Back;
		case PaletteBackStyle.ContextMenuItemHighlight:
			return GetPaletteBackContextMenuItemHighlight(state);
		case PaletteBackStyle.ContextMenuItemImage:
			return GetPaletteBackContextMenuItemImage(state);
		case PaletteBackStyle.ContextMenuItemSplit:
			return GetPaletteBackContextMenuItemSplit(state);
		case PaletteBackStyle.ContextMenuItemImageColumn:
			return ContextMenu.StateCommon.ItemImageColumn.Back;
		case PaletteBackStyle.ContextMenuSeparator:
			return ContextMenu.StateCommon.Separator.Back;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBorder GetPaletteBorder(PaletteBorderStyle style, PaletteState state)
	{
		Common.StateCommon.BorderStyle = style;
		switch (style)
		{
		case PaletteBorderStyle.ButtonStandalone:
			return GetPaletteBorderButton(ButtonStyles.ButtonStandalone, state);
		case PaletteBorderStyle.ButtonAlternate:
			return GetPaletteBorderButton(ButtonStyles.ButtonAlternate, state);
		case PaletteBorderStyle.ButtonLowProfile:
			return GetPaletteBorderButton(ButtonStyles.ButtonLowProfile, state);
		case PaletteBorderStyle.ButtonButtonSpec:
			return GetPaletteBorderButton(ButtonStyles.ButtonButtonSpec, state);
		case PaletteBorderStyle.ButtonBreadCrumb:
			return GetPaletteBorderButton(ButtonStyles.ButtonBreadCrumb, state);
		case PaletteBorderStyle.ButtonCalendarDay:
			return GetPaletteBorderCalendarDay(CalendarDay, state);
		case PaletteBorderStyle.ButtonCluster:
			return GetPaletteBorderButton(ButtonStyles.ButtonCluster, state);
		case PaletteBorderStyle.ButtonGallery:
			return GetPaletteBorderButton(ButtonStyles.ButtonGallery, state);
		case PaletteBorderStyle.ButtonNavigatorStack:
			return GetPaletteBorderButton(ButtonStyles.ButtonNavigatorStack, state);
		case PaletteBorderStyle.ButtonNavigatorOverflow:
			return GetPaletteBorderButton(ButtonStyles.ButtonNavigatorOverflow, state);
		case PaletteBorderStyle.ButtonNavigatorMini:
			return GetPaletteBorderButton(ButtonStyles.ButtonNavigatorMini, state);
		case PaletteBorderStyle.ButtonInputControl:
			return GetPaletteBorderButton(ButtonStyles.ButtonInputControl, state);
		case PaletteBorderStyle.ButtonListItem:
			return GetPaletteBorderButton(ButtonStyles.ButtonListItem, state);
		case PaletteBorderStyle.ButtonForm:
			return GetPaletteBorderButton(ButtonStyles.ButtonForm, state);
		case PaletteBorderStyle.ButtonFormClose:
			return GetPaletteBorderButton(ButtonStyles.ButtonFormClose, state);
		case PaletteBorderStyle.ButtonCommand:
			return GetPaletteBorderButton(ButtonStyles.ButtonCommand, state);
		case PaletteBorderStyle.ButtonCustom1:
			return GetPaletteBorderButton(ButtonStyles.ButtonCustom1, state);
		case PaletteBorderStyle.ButtonCustom2:
			return GetPaletteBorderButton(ButtonStyles.ButtonCustom2, state);
		case PaletteBorderStyle.ButtonCustom3:
			return GetPaletteBorderButton(ButtonStyles.ButtonCustom3, state);
		case PaletteBorderStyle.ControlClient:
			return GetPaletteBorderControl(ControlStyles.ControlClient, state);
		case PaletteBorderStyle.ControlAlternate:
			return GetPaletteBorderControl(ControlStyles.ControlAlternate, state);
		case PaletteBorderStyle.ControlGroupBox:
			return GetPaletteBorderControl(ControlStyles.ControlGroupBox, state);
		case PaletteBorderStyle.ControlToolTip:
			return GetPaletteBorderControl(ControlStyles.ControlToolTip, state);
		case PaletteBorderStyle.ControlRibbon:
			return GetPaletteBorderControl(ControlStyles.ControlRibbon, state);
		case PaletteBorderStyle.ControlRibbonAppMenu:
			return GetPaletteBorderControl(ControlStyles.ControlRibbonAppMenu, state);
		case PaletteBorderStyle.ControlCustom1:
			return GetPaletteBorderControl(ControlStyles.ControlCustom1, state);
		case PaletteBorderStyle.InputControlStandalone:
			return GetPaletteInputControl(InputControlStyles.InputControlStandalone, state).Border;
		case PaletteBorderStyle.InputControlRibbon:
			return GetPaletteInputControl(InputControlStyles.InputControlRibbon, state).Border;
		case PaletteBorderStyle.InputControlCustom1:
			return GetPaletteInputControl(InputControlStyles.InputControlCustom1, state).Border;
		case PaletteBorderStyle.FormMain:
			return GetPaletteBorderForm(FormStyles.FormMain, state);
		case PaletteBorderStyle.FormCustom1:
			return GetPaletteBorderForm(FormStyles.FormCustom1, state);
		case PaletteBorderStyle.GridHeaderColumnList:
			return GetPaletteBorderGridHeaderColumn(GridStyles.GridList, state);
		case PaletteBorderStyle.GridHeaderColumnSheet:
			return GetPaletteBorderGridHeaderColumn(GridStyles.GridSheet, state);
		case PaletteBorderStyle.GridHeaderColumnCustom1:
			return GetPaletteBorderGridHeaderColumn(GridStyles.GridCustom1, state);
		case PaletteBorderStyle.GridHeaderRowList:
			return GetPaletteBorderGridHeaderRow(GridStyles.GridList, state);
		case PaletteBorderStyle.GridHeaderRowSheet:
			return GetPaletteBorderGridHeaderRow(GridStyles.GridSheet, state);
		case PaletteBorderStyle.GridHeaderRowCustom1:
			return GetPaletteBorderGridHeaderRow(GridStyles.GridCustom1, state);
		case PaletteBorderStyle.GridDataCellList:
			return GetPaletteBorderGridDataCell(GridStyles.GridList, state);
		case PaletteBorderStyle.GridDataCellSheet:
			return GetPaletteBorderGridDataCell(GridStyles.GridSheet, state);
		case PaletteBorderStyle.GridDataCellCustom1:
			return GetPaletteBorderGridDataCell(GridStyles.GridCustom1, state);
		case PaletteBorderStyle.HeaderPrimary:
			return GetPaletteBorderHeader(HeaderStyles.HeaderPrimary, state);
		case PaletteBorderStyle.HeaderSecondary:
			return GetPaletteBorderHeader(HeaderStyles.HeaderSecondary, state);
		case PaletteBorderStyle.HeaderDockInactive:
			return GetPaletteBorderHeader(HeaderStyles.HeaderDockInactive, state);
		case PaletteBorderStyle.HeaderDockActive:
			return GetPaletteBorderHeader(HeaderStyles.HeaderDockActive, state);
		case PaletteBorderStyle.HeaderCalendar:
			return GetPaletteBorderHeader(HeaderStyles.HeaderCalendar, state);
		case PaletteBorderStyle.HeaderForm:
			return GetPaletteBorderHeader(HeaderStyles.HeaderForm, state);
		case PaletteBorderStyle.HeaderCustom1:
			return GetPaletteBorderHeader(HeaderStyles.HeaderCustom1, state);
		case PaletteBorderStyle.HeaderCustom2:
			return GetPaletteBorderHeader(HeaderStyles.HeaderCustom2, state);
		case PaletteBorderStyle.SeparatorLowProfile:
			return GetPaletteBorderSeparator(SeparatorStyles.SeparatorLowProfile, state);
		case PaletteBorderStyle.SeparatorHighProfile:
			return GetPaletteBorderSeparator(SeparatorStyles.SeparatorHighProfile, state);
		case PaletteBorderStyle.SeparatorHighInternalProfile:
			return GetPaletteBorderSeparator(SeparatorStyles.SeparatorHighInternalProfile, state);
		case PaletteBorderStyle.SeparatorCustom1:
			return GetPaletteBorderSeparator(SeparatorStyles.SeparatorCustom1, state);
		case PaletteBorderStyle.TabHighProfile:
			return GetPaletteBorderTab(TabStyles.TabHighProfile, state);
		case PaletteBorderStyle.TabStandardProfile:
			return GetPaletteBorderTab(TabStyles.TabStandardProfile, state);
		case PaletteBorderStyle.TabLowProfile:
			return GetPaletteBorderTab(TabStyles.TabLowProfile, state);
		case PaletteBorderStyle.TabDock:
			return GetPaletteBorderTab(TabStyles.TabDock, state);
		case PaletteBorderStyle.TabDockAutoHidden:
			return GetPaletteBorderTab(TabStyles.TabDockAutoHidden, state);
		case PaletteBorderStyle.TabOneNote:
			return GetPaletteBorderTab(TabStyles.TabOneNote, state);
		case PaletteBorderStyle.TabCustom1:
			return GetPaletteBorderTab(TabStyles.TabCustom1, state);
		case PaletteBorderStyle.TabCustom2:
			return GetPaletteBorderTab(TabStyles.TabCustom2, state);
		case PaletteBorderStyle.TabCustom3:
			return GetPaletteBorderTab(TabStyles.TabCustom3, state);
		case PaletteBorderStyle.ContextMenuOuter:
			return ContextMenu.StateCommon.ControlOuter.Border;
		case PaletteBorderStyle.ContextMenuInner:
			return ContextMenu.StateCommon.ControlInner.Border;
		case PaletteBorderStyle.ContextMenuHeading:
			return ContextMenu.StateCommon.Heading.Border;
		case PaletteBorderStyle.ContextMenuItemHighlight:
			return GetPaletteBorderContextMenuItemHighlight(state);
		case PaletteBorderStyle.ContextMenuItemImage:
			return GetPaletteBorderContextMenuItemImage(state);
		case PaletteBorderStyle.ContextMenuItemSplit:
			return GetPaletteBorderContextMenuItemSplit(state);
		case PaletteBorderStyle.ContextMenuItemImageColumn:
			return ContextMenu.StateCommon.ItemImageColumn.Border;
		case PaletteBorderStyle.ContextMenuSeparator:
			return ContextMenu.StateCommon.Separator.Border;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteContent GetPaletteContent(PaletteContentStyle style, PaletteState state)
	{
		Common.StateCommon.ContentStyle = style;
		switch (style)
		{
		case PaletteContentStyle.ButtonStandalone:
			return GetPaletteContentButton(ButtonStyles.ButtonStandalone, state);
		case PaletteContentStyle.ButtonAlternate:
			return GetPaletteContentButton(ButtonStyles.ButtonAlternate, state);
		case PaletteContentStyle.ButtonLowProfile:
			return GetPaletteContentButton(ButtonStyles.ButtonLowProfile, state);
		case PaletteContentStyle.ButtonButtonSpec:
			return GetPaletteContentButton(ButtonStyles.ButtonButtonSpec, state);
		case PaletteContentStyle.ButtonBreadCrumb:
			return GetPaletteContentButton(ButtonStyles.ButtonBreadCrumb, state);
		case PaletteContentStyle.ButtonCalendarDay:
			return GetPaletteContentCalendarDay(CalendarDay, state);
		case PaletteContentStyle.ButtonCluster:
			return GetPaletteContentButton(ButtonStyles.ButtonCluster, state);
		case PaletteContentStyle.ButtonGallery:
			return GetPaletteContentButton(ButtonStyles.ButtonGallery, state);
		case PaletteContentStyle.ButtonNavigatorStack:
			return GetPaletteContentButton(ButtonStyles.ButtonNavigatorStack, state);
		case PaletteContentStyle.ButtonNavigatorOverflow:
			return GetPaletteContentButton(ButtonStyles.ButtonNavigatorOverflow, state);
		case PaletteContentStyle.ButtonNavigatorMini:
			return GetPaletteContentButton(ButtonStyles.ButtonNavigatorMini, state);
		case PaletteContentStyle.ButtonInputControl:
			return GetPaletteContentButton(ButtonStyles.ButtonInputControl, state);
		case PaletteContentStyle.ButtonListItem:
			return GetPaletteContentButton(ButtonStyles.ButtonListItem, state);
		case PaletteContentStyle.ButtonForm:
			return GetPaletteContentButton(ButtonStyles.ButtonForm, state);
		case PaletteContentStyle.ButtonFormClose:
			return GetPaletteContentButton(ButtonStyles.ButtonFormClose, state);
		case PaletteContentStyle.ButtonCommand:
			return GetPaletteContentButton(ButtonStyles.ButtonCommand, state);
		case PaletteContentStyle.ButtonCustom1:
			return GetPaletteContentButton(ButtonStyles.ButtonCustom1, state);
		case PaletteContentStyle.ButtonCustom2:
			return GetPaletteContentButton(ButtonStyles.ButtonCustom2, state);
		case PaletteContentStyle.ButtonCustom3:
			return GetPaletteContentButton(ButtonStyles.ButtonCustom3, state);
		case PaletteContentStyle.GridHeaderColumnList:
			return GetPaletteContentGridHeaderColumn(GridStyles.GridList, state);
		case PaletteContentStyle.GridHeaderColumnSheet:
			return GetPaletteContentGridHeaderColumn(GridStyles.GridSheet, state);
		case PaletteContentStyle.GridHeaderColumnCustom1:
			return GetPaletteContentGridHeaderColumn(GridStyles.GridCustom1, state);
		case PaletteContentStyle.GridHeaderRowList:
			return GetPaletteContentGridHeaderRow(GridStyles.GridList, state);
		case PaletteContentStyle.GridHeaderRowSheet:
			return GetPaletteContentGridHeaderRow(GridStyles.GridSheet, state);
		case PaletteContentStyle.GridHeaderRowCustom1:
			return GetPaletteContentGridHeaderRow(GridStyles.GridCustom1, state);
		case PaletteContentStyle.GridDataCellList:
			return GetPaletteContentGridDataCell(GridStyles.GridList, state);
		case PaletteContentStyle.GridDataCellSheet:
			return GetPaletteContentGridDataCell(GridStyles.GridSheet, state);
		case PaletteContentStyle.GridDataCellCustom1:
			return GetPaletteContentGridDataCell(GridStyles.GridCustom1, state);
		case PaletteContentStyle.HeaderPrimary:
			return GetPaletteContentHeader(HeaderStyles.HeaderPrimary, state);
		case PaletteContentStyle.HeaderSecondary:
			return GetPaletteContentHeader(HeaderStyles.HeaderSecondary, state);
		case PaletteContentStyle.HeaderDockInactive:
			return GetPaletteContentHeader(HeaderStyles.HeaderDockInactive, state);
		case PaletteContentStyle.HeaderDockActive:
			return GetPaletteContentHeader(HeaderStyles.HeaderDockActive, state);
		case PaletteContentStyle.HeaderCalendar:
			return GetPaletteContentHeader(HeaderStyles.HeaderCalendar, state);
		case PaletteContentStyle.HeaderForm:
			return GetPaletteContentHeader(HeaderStyles.HeaderForm, state);
		case PaletteContentStyle.HeaderCustom1:
			return GetPaletteContentHeader(HeaderStyles.HeaderCustom1, state);
		case PaletteContentStyle.HeaderCustom2:
			return GetPaletteContentHeader(HeaderStyles.HeaderCustom2, state);
		case PaletteContentStyle.LabelNormalControl:
			return GetPaletteLabel(LabelStyles.LabelNormalControl, state);
		case PaletteContentStyle.LabelBoldControl:
			return GetPaletteLabel(LabelStyles.LabelBoldControl, state);
		case PaletteContentStyle.LabelItalicControl:
			return GetPaletteLabel(LabelStyles.LabelItalicControl, state);
		case PaletteContentStyle.LabelTitleControl:
			return GetPaletteLabel(LabelStyles.LabelTitleControl, state);
		case PaletteContentStyle.LabelNormalPanel:
			return GetPaletteLabel(LabelStyles.LabelNormalPanel, state);
		case PaletteContentStyle.LabelBoldPanel:
			return GetPaletteLabel(LabelStyles.LabelBoldPanel, state);
		case PaletteContentStyle.LabelItalicPanel:
			return GetPaletteLabel(LabelStyles.LabelItalicPanel, state);
		case PaletteContentStyle.LabelTitlePanel:
			return GetPaletteLabel(LabelStyles.LabelTitlePanel, state);
		case PaletteContentStyle.LabelGroupBoxCaption:
			return GetPaletteLabel(LabelStyles.LabelCaptionPanel, state);
		case PaletteContentStyle.LabelToolTip:
			return GetPaletteLabel(LabelStyles.LabelToolTip, state);
		case PaletteContentStyle.LabelSuperTip:
			return GetPaletteLabel(LabelStyles.LabelSuperTip, state);
		case PaletteContentStyle.LabelKeyTip:
			return GetPaletteLabel(LabelStyles.LabelKeyTip, state);
		case PaletteContentStyle.LabelCustom1:
			return GetPaletteLabel(LabelStyles.LabelCustom1, state);
		case PaletteContentStyle.LabelCustom2:
			return GetPaletteLabel(LabelStyles.LabelCustom2, state);
		case PaletteContentStyle.LabelCustom3:
			return GetPaletteLabel(LabelStyles.LabelCustom3, state);
		case PaletteContentStyle.InputControlStandalone:
			return GetPaletteInputControl(InputControlStyles.InputControlStandalone, state).Content;
		case PaletteContentStyle.InputControlRibbon:
			return GetPaletteInputControl(InputControlStyles.InputControlRibbon, state).Content;
		case PaletteContentStyle.InputControlCustom1:
			return GetPaletteInputControl(InputControlStyles.InputControlCustom1, state).Content;
		case PaletteContentStyle.TabHighProfile:
			return GetPaletteContentTab(TabStyles.TabHighProfile, state);
		case PaletteContentStyle.TabStandardProfile:
			return GetPaletteContentTab(TabStyles.TabStandardProfile, state);
		case PaletteContentStyle.TabLowProfile:
			return GetPaletteContentTab(TabStyles.TabLowProfile, state);
		case PaletteContentStyle.TabDock:
			return GetPaletteContentTab(TabStyles.TabDock, state);
		case PaletteContentStyle.TabDockAutoHidden:
			return GetPaletteContentTab(TabStyles.TabDockAutoHidden, state);
		case PaletteContentStyle.TabOneNote:
			return GetPaletteContentTab(TabStyles.TabOneNote, state);
		case PaletteContentStyle.TabCustom1:
			return GetPaletteContentTab(TabStyles.TabCustom1, state);
		case PaletteContentStyle.TabCustom2:
			return GetPaletteContentTab(TabStyles.TabCustom2, state);
		case PaletteContentStyle.TabCustom3:
			return GetPaletteContentTab(TabStyles.TabCustom3, state);
		case PaletteContentStyle.ContextMenuHeading:
			return ContextMenu.StateCommon.Heading.Content;
		case PaletteContentStyle.ContextMenuItemImage:
			return GetPaletteContentContextMenuItemImage(state);
		case PaletteContentStyle.ContextMenuItemShortcutText:
			return GetPaletteContentContextMenuItemShortcutText(state);
		case PaletteContentStyle.ContextMenuItemTextAlternate:
			return GetPaletteContentContextMenuTextAlternate(state);
		case PaletteContentStyle.ContextMenuItemTextStandard:
			return GetPaletteContentContextMenuItemTextStandard(state);
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteBack GetPaletteBackButton(KryptonPaletteCheckButton button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.NormalDefaultOverride:
			return button.OverrideDefault.Back;
		case PaletteState.FocusOverride:
			return button.OverrideFocus.Back;
		case PaletteState.BoldedOverride:
			return _calendarDay.OverrideBolded.Back;
		case PaletteState.TodayOverride:
			return _calendarDay.OverrideToday.Back;
		default:
		{
			PaletteTriple paletteButton = GetPaletteButton(button, state);
			if (paletteButton != null)
			{
				return paletteButton.Back;
			}
			Debug.Assert(condition: false);
			return null;
		}
		}
	}

	private PaletteBorder GetPaletteBorderButton(KryptonPaletteCheckButton button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.NormalDefaultOverride:
			return button.OverrideDefault.Border;
		case PaletteState.FocusOverride:
			return button.OverrideFocus.Border;
		case PaletteState.BoldedOverride:
			return _calendarDay.OverrideBolded.Border;
		case PaletteState.TodayOverride:
			return _calendarDay.OverrideToday.Border;
		default:
		{
			PaletteTriple paletteButton = GetPaletteButton(button, state);
			if (paletteButton != null)
			{
				return paletteButton.Border;
			}
			Debug.Assert(condition: false);
			return null;
		}
		}
	}

	private PaletteContent GetPaletteContentButton(KryptonPaletteCheckButton button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.NormalDefaultOverride:
			return button.OverrideDefault.Content;
		case PaletteState.FocusOverride:
			return button.OverrideFocus.Content;
		case PaletteState.BoldedOverride:
			return _calendarDay.OverrideBolded.Content;
		case PaletteState.TodayOverride:
			return _calendarDay.OverrideToday.Content;
		default:
		{
			PaletteTriple paletteButton = GetPaletteButton(button, state);
			if (paletteButton != null)
			{
				return paletteButton.Content;
			}
			Debug.Assert(condition: false);
			return null;
		}
		}
	}

	private PaletteTriple GetPaletteButton(KryptonPaletteCheckButton button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return button.StateDisabled;
		case PaletteState.Normal:
			return button.StateNormal;
		case PaletteState.Tracking:
			return button.StateTracking;
		case PaletteState.Pressed:
			return button.StatePressed;
		case PaletteState.CheckedNormal:
			return button.StateCheckedNormal;
		case PaletteState.CheckedTracking:
			return button.StateCheckedTracking;
		case PaletteState.CheckedPressed:
			return button.StateCheckedPressed;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteBack GetPaletteBackCalendarDay(KryptonPaletteCalendarDay button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.FocusOverride:
			return button.OverrideFocus.Back;
		case PaletteState.BoldedOverride:
			return button.OverrideBolded.Back;
		case PaletteState.TodayOverride:
			return button.OverrideToday.Back;
		default:
		{
			PaletteTriple paletteCalendarDay = GetPaletteCalendarDay(button, state);
			if (paletteCalendarDay != null)
			{
				return paletteCalendarDay.Back;
			}
			Debug.Assert(condition: false);
			return null;
		}
		}
	}

	private PaletteBorder GetPaletteBorderCalendarDay(KryptonPaletteCalendarDay button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.FocusOverride:
			return button.OverrideFocus.Border;
		case PaletteState.BoldedOverride:
			return button.OverrideBolded.Border;
		case PaletteState.TodayOverride:
			return button.OverrideToday.Border;
		default:
		{
			PaletteTriple paletteCalendarDay = GetPaletteCalendarDay(button, state);
			if (paletteCalendarDay != null)
			{
				return paletteCalendarDay.Border;
			}
			Debug.Assert(condition: false);
			return null;
		}
		}
	}

	private PaletteContent GetPaletteContentCalendarDay(KryptonPaletteCalendarDay button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.FocusOverride:
			return button.OverrideFocus.Content;
		case PaletteState.BoldedOverride:
			return button.OverrideBolded.Content;
		case PaletteState.TodayOverride:
			return button.OverrideToday.Content;
		default:
		{
			PaletteTriple paletteCalendarDay = GetPaletteCalendarDay(button, state);
			if (paletteCalendarDay != null)
			{
				return paletteCalendarDay.Content;
			}
			Debug.Assert(condition: false);
			return null;
		}
		}
	}

	private PaletteTriple GetPaletteCalendarDay(KryptonPaletteCalendarDay button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return button.StateDisabled;
		case PaletteState.Normal:
		case PaletteState.NormalDefaultOverride:
			return button.StateNormal;
		case PaletteState.Tracking:
			return button.StateTracking;
		case PaletteState.Pressed:
			return button.StatePressed;
		case PaletteState.CheckedNormal:
			return button.StateCheckedNormal;
		case PaletteState.CheckedTracking:
			return button.StateCheckedTracking;
		case PaletteState.CheckedPressed:
			return button.StateCheckedPressed;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteTriple GetPaletteInputControl(KryptonPaletteInputControl inputControl, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return inputControl.StateDisabled;
		case PaletteState.Normal:
			return inputControl.StateNormal;
		case PaletteState.Tracking:
			return inputControl.StateActive;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteBack GetPaletteBackTab(KryptonPaletteTabButton button, PaletteState state)
	{
		if (state == PaletteState.FocusOverride)
		{
			return button.OverrideFocus.Back;
		}
		PaletteTabTriple paletteTab = GetPaletteTab(button, state);
		if (paletteTab != null)
		{
			return paletteTab.Back;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteBorder GetPaletteBorderTab(KryptonPaletteTabButton button, PaletteState state)
	{
		if (state == PaletteState.FocusOverride)
		{
			return button.OverrideFocus.Border;
		}
		PaletteTabTriple paletteTab = GetPaletteTab(button, state);
		if (paletteTab != null)
		{
			return paletteTab.Border;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteContent GetPaletteContentTab(KryptonPaletteTabButton button, PaletteState state)
	{
		if (state == PaletteState.FocusOverride)
		{
			return button.OverrideFocus.Content;
		}
		PaletteTabTriple paletteTab = GetPaletteTab(button, state);
		if (paletteTab != null)
		{
			return paletteTab.Content;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteTabTriple GetPaletteTab(KryptonPaletteTabButton button, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return button.StateDisabled;
		case PaletteState.Normal:
			return button.StateNormal;
		case PaletteState.Tracking:
			return button.StateTracking;
		case PaletteState.Pressed:
			return button.StatePressed;
		case PaletteState.CheckedNormal:
		case PaletteState.CheckedTracking:
		case PaletteState.CheckedPressed:
			return button.StateSelected;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackSeparator(KryptonPaletteSeparator separator, PaletteState state)
	{
		PaletteSeparatorPadding paletteSeparator = GetPaletteSeparator(separator, state);
		if (paletteSeparator != null)
		{
			return paletteSeparator.Back;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteBorder GetPaletteBorderSeparator(KryptonPaletteSeparator separator, PaletteState state)
	{
		PaletteSeparatorPadding paletteSeparator = GetPaletteSeparator(separator, state);
		if (paletteSeparator != null)
		{
			return paletteSeparator.Border;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteSeparatorPadding GetPaletteSeparator(KryptonPaletteSeparator separator, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return separator.StateDisabled;
		case PaletteState.Normal:
			return separator.StateNormal;
		case PaletteState.Tracking:
			return separator.StateTracking;
		case PaletteState.Pressed:
			return separator.StatePressed;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackControl(KryptonPaletteControl control, PaletteState state)
	{
		PaletteDouble paletteControl = GetPaletteControl(control, state);
		if (paletteControl != null)
		{
			return paletteControl.Back;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteBorder GetPaletteBorderControl(KryptonPaletteControl control, PaletteState state)
	{
		PaletteDouble paletteControl = GetPaletteControl(control, state);
		if (paletteControl != null)
		{
			return paletteControl.Border;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteDouble GetPaletteControl(KryptonPaletteControl control, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return control.StateDisabled;
		case PaletteState.Normal:
			return control.StateNormal;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackForm(KryptonPaletteForm form, PaletteState state)
	{
		PaletteDouble paletteForm = GetPaletteForm(form, state);
		if (paletteForm != null)
		{
			return paletteForm.Back;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteBack GetPaletteBackGridBackground(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.Background;
		case PaletteState.Normal:
			return grid.StateNormal.Background;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackGridHeaderColumn(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.HeaderColumn.Back;
		case PaletteState.Normal:
			return grid.StateNormal.HeaderColumn.Back;
		case PaletteState.Tracking:
			return grid.StateTracking.HeaderColumn.Back;
		case PaletteState.Pressed:
			return grid.StatePressed.HeaderColumn.Back;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.HeaderColumn.Back;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackGridHeaderRow(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.HeaderRow.Back;
		case PaletteState.Normal:
			return grid.StateNormal.HeaderRow.Back;
		case PaletteState.Tracking:
			return grid.StateTracking.HeaderRow.Back;
		case PaletteState.Pressed:
			return grid.StatePressed.HeaderRow.Back;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.HeaderRow.Back;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackGridDataCell(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.DataCell.Back;
		case PaletteState.Normal:
			return grid.StateNormal.DataCell.Back;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.DataCell.Back;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBorder GetPaletteBorderGridHeaderColumn(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.HeaderColumn.Border;
		case PaletteState.Normal:
			return grid.StateNormal.HeaderColumn.Border;
		case PaletteState.Tracking:
			return grid.StateTracking.HeaderColumn.Border;
		case PaletteState.Pressed:
			return grid.StatePressed.HeaderColumn.Border;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.HeaderColumn.Border;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBorder GetPaletteBorderGridHeaderRow(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.HeaderRow.Border;
		case PaletteState.Normal:
			return grid.StateNormal.HeaderRow.Border;
		case PaletteState.Tracking:
			return grid.StateTracking.HeaderRow.Border;
		case PaletteState.Pressed:
			return grid.StatePressed.HeaderRow.Border;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.HeaderRow.Border;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBorder GetPaletteBorderGridDataCell(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.DataCell.Border;
		case PaletteState.Normal:
			return grid.StateNormal.DataCell.Border;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.DataCell.Border;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteContent GetPaletteContentGridHeaderColumn(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.HeaderColumn.Content;
		case PaletteState.Normal:
			return grid.StateNormal.HeaderColumn.Content;
		case PaletteState.Tracking:
			return grid.StateTracking.HeaderColumn.Content;
		case PaletteState.Pressed:
			return grid.StatePressed.HeaderColumn.Content;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.HeaderColumn.Content;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteContent GetPaletteContentGridHeaderRow(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.HeaderRow.Content;
		case PaletteState.Normal:
			return grid.StateNormal.HeaderRow.Content;
		case PaletteState.Tracking:
			return grid.StateTracking.HeaderRow.Content;
		case PaletteState.Pressed:
			return grid.StatePressed.HeaderRow.Content;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.HeaderRow.Content;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteContent GetPaletteContentGridDataCell(KryptonPaletteGrid grid, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return grid.StateDisabled.DataCell.Content;
		case PaletteState.Normal:
			return grid.StateNormal.DataCell.Content;
		case PaletteState.CheckedNormal:
			return grid.StateSelected.DataCell.Content;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBorder GetPaletteBorderForm(KryptonPaletteForm form, PaletteState state)
	{
		PaletteDouble paletteForm = GetPaletteForm(form, state);
		if (paletteForm != null)
		{
			return paletteForm.Border;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteDouble GetPaletteForm(KryptonPaletteForm form, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return form.StateInactive;
		case PaletteState.Normal:
			return form.StateActive;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackHeader(KryptonPaletteHeader header, PaletteState state)
	{
		PaletteTriple paletteHeader = GetPaletteHeader(header, state);
		if (paletteHeader != null)
		{
			return paletteHeader.Back;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteBorder GetPaletteBorderHeader(KryptonPaletteHeader header, PaletteState state)
	{
		PaletteTriple paletteHeader = GetPaletteHeader(header, state);
		if (paletteHeader != null)
		{
			return paletteHeader.Border;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteContent GetPaletteContentHeader(KryptonPaletteHeader header, PaletteState state)
	{
		PaletteTriple paletteHeader = GetPaletteHeader(header, state);
		if (paletteHeader != null)
		{
			return paletteHeader.Content;
		}
		Debug.Assert(condition: false);
		return null;
	}

	private PaletteTriple GetPaletteHeader(KryptonPaletteHeader header, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return header.StateDisabled;
		case PaletteState.Normal:
			return header.StateNormal;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPalettePanel(KryptonPalettePanel panel, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return panel.StateDisabled;
		case PaletteState.Normal:
			return panel.StateNormal;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteContent GetPaletteLabel(KryptonPaletteLabel label, PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return label.StateDisabled;
		case PaletteState.Normal:
		case PaletteState.Tracking:
		case PaletteState.Pressed:
			return label.StateNormal;
		case PaletteState.FocusOverride:
			return label.OverrideFocus;
		case PaletteState.LinkVisitedOverride:
			return label.OverrideVisited;
		case PaletteState.LinkNotVisitedOverride:
			return label.OverrideNotVisited;
		case PaletteState.LinkPressedOverride:
			return label.OverridePressed;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackContextMenuItemSplit(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemSplit.Back;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemSplit.Back;
		case PaletteState.Tracking:
			return ContextMenu.StateHighlight.ItemSplit.Back;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackContextMenuItemHighlight(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemHighlight.Back;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemHighlight.Back;
		case PaletteState.Tracking:
			return ContextMenu.StateHighlight.ItemHighlight.Back;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBack GetPaletteBackContextMenuItemImage(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemImage.Back;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemImage.Back;
		case PaletteState.CheckedNormal:
			return ContextMenu.StateChecked.ItemImage.Back;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBorder GetPaletteBorderContextMenuItemHighlight(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemHighlight.Border;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemHighlight.Border;
		case PaletteState.Tracking:
			return ContextMenu.StateHighlight.ItemHighlight.Border;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBorder GetPaletteBorderContextMenuItemSplit(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemSplit.Border;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemSplit.Border;
		case PaletteState.Tracking:
			return ContextMenu.StateHighlight.ItemSplit.Border;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteBorder GetPaletteBorderContextMenuItemImage(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemImage.Border;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemImage.Border;
		case PaletteState.CheckedNormal:
			return ContextMenu.StateChecked.ItemImage.Border;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteContent GetPaletteContentContextMenuItemImage(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemImage.Content;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemImage.Content;
		case PaletteState.CheckedNormal:
			return ContextMenu.StateChecked.ItemImage.Content;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private PaletteContent GetPaletteContentContextMenuItemShortcutText(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemShortcutText;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemShortcutText;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteContent GetPaletteContentContextMenuTextAlternate(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemTextAlternate;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemTextAlternate;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private IPaletteContent GetPaletteContentContextMenuItemTextStandard(PaletteState state)
	{
		switch (state)
		{
		case PaletteState.Disabled:
			return ContextMenu.StateDisabled.ItemTextStandard;
		case PaletteState.Normal:
			return ContextMenu.StateNormal.ItemTextStandard;
		default:
			Debug.Assert(condition: false);
			return null;
		}
	}

	private void OnMenuToolStatusPaint(object sender, NeedLayoutEventArgs e)
	{
		if (_suspendCount == 0)
		{
			OnPalettePaint(this, new PaletteLayoutEventArgs(e.NeedLayout, needColorTable: true));
		}
	}

	private void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (_suspendCount == 0)
		{
			OnPalettePaint(this, new PaletteLayoutEventArgs(e.NeedLayout, needColorTable: false));
		}
	}

	private void SetPalette(IPalette basePalette)
	{
		if (basePalette != _basePalette)
		{
			Debug.Assert(_basePalette != null);
			if (_basePalette != null)
			{
				_basePalette.PalettePaint -= OnPalettePaint;
				_basePalette.ButtonSpecChanged -= OnButtonSpecChanged;
				_basePalette.BasePaletteChanged -= OnBasePaletteChanged;
				_basePalette.BaseRendererChanged -= OnBaseRendererChanged;
			}
			_basePalette = basePalette;
			_redirector.Target = _basePalette;
			_toolMenuStatus.BaseKCT = _basePalette.ColorTable;
			if (_basePalette != null)
			{
				_basePalette.PalettePaint += OnPalettePaint;
				_basePalette.ButtonSpecChanged += OnButtonSpecChanged;
				_basePalette.BasePaletteChanged += OnBasePaletteChanged;
				_basePalette.BaseRendererChanged += OnBaseRendererChanged;
			}
		}
	}
}
