using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonGroupBox), "ToolboxBitmaps.KryptonGroupBox.bmp")]
[DefaultEvent("Paint")]
[DefaultProperty("ValuesPrimary")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonGroupBoxDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Display frame around a group of related controls with an optional caption.")]
[Docking(DockingBehavior.Ask)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonGroupBox : VisualControlContainment
{
	private LabelStyle _captionStyle;

	private VisualOrientation _captionEdge;

	private ButtonOrientation _captionOrientation;

	private CaptionValues _captionValues;

	private ViewDrawGroupBoxDocker _drawDocker;

	private ViewDrawContent _drawContent;

	private ViewLayoutFill _layoutFill;

	private KryptonGroupPanel _panel;

	private PaletteGroupBoxRedirect _stateCommon;

	private PaletteGroupBox _stateDisabled;

	private PaletteGroupBox _stateNormal;

	private ScreenObscurer _obscurer;

	private EventHandler _removeObscurer;

	private bool _forcedLayout;

	private bool _captionVisible;

	private bool _ignoreLayout;

	private bool _layingOut;

	[Browsable(false)]
	public new string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
			_panel.Name = value + ".Panel";
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			base.AutoSize = value;
		}
	}

	[Browsable(false)]
	[Localizable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	[Category("Layout")]
	[Description("Specifies if the control grows and shrinks to fit the contents exactly.")]
	[DefaultValue(typeof(AutoSizeMode), "GrowAndShrink")]
	public AutoSizeMode AutoSizeMode
	{
		get
		{
			return GetAutoSizeMode();
		}
		set
		{
			if (value != GetAutoSizeMode())
			{
				SetAutoSizeMode(value);
				if (AutoSize)
				{
					PerformNeedPaint(needLayout: true);
				}
			}
		}
	}

	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	public override string Text
	{
		get
		{
			return _captionValues.Heading;
		}
		set
		{
			_captionValues.Heading = value;
		}
	}

	[Localizable(false)]
	[Category("Appearance")]
	[Description("The internal panel that contains group content.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonGroupPanel Panel => _panel;

	[Category("Visuals")]
	[Description("The percentage the caption should overlap the group area.")]
	[TypeConverter(typeof(OpacityConverter))]
	[DefaultValue(0.5)]
	public double CaptionOverlap
	{
		get
		{
			return _drawDocker.CaptionOverlap;
		}
		set
		{
			if (_drawDocker.CaptionOverlap != value)
			{
				value = Math.Max(Math.Min(value, 1.0), 0.0);
				_drawDocker.CaptionOverlap = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Border style.")]
	[DefaultValue(typeof(PaletteBorderStyle), "ControlGroupBox")]
	public PaletteBorderStyle GroupBorderStyle
	{
		get
		{
			return _stateCommon.BorderStyle;
		}
		set
		{
			if (_stateCommon.BorderStyle != value)
			{
				_stateCommon.BorderStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Background style.")]
	[DefaultValue(typeof(PaletteBackStyle), "ControlGroupBox")]
	public PaletteBackStyle GroupBackStyle
	{
		get
		{
			return _stateCommon.BackStyle;
		}
		set
		{
			if (_stateCommon.BackStyle != value)
			{
				_stateCommon.BackStyle = value;
				_panel.PanelBackStyle = value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Caption style.")]
	[DefaultValue(typeof(LabelStyle), "GroupBoxCaption")]
	public LabelStyle CaptionStyle
	{
		get
		{
			return _captionStyle;
		}
		set
		{
			if (_captionStyle != value)
			{
				_captionStyle = value;
				_stateCommon.ContentStyle = CommonHelper.ContentStyleFromLabelStyle(_captionStyle);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Edge position of the caption.")]
	[DefaultValue(typeof(VisualOrientation), "Top")]
	public VisualOrientation CaptionEdge
	{
		get
		{
			return _captionEdge;
		}
		set
		{
			if (_captionEdge == value)
			{
				return;
			}
			_captionEdge = value;
			switch (_captionEdge)
			{
			case VisualOrientation.Top:
				if (_captionOrientation == ButtonOrientation.Auto)
				{
					_drawContent.Orientation = VisualOrientation.Top;
				}
				_drawDocker.SetDock(_drawContent, ViewDockStyle.Top);
				break;
			case VisualOrientation.Bottom:
				if (_captionOrientation == ButtonOrientation.Auto)
				{
					_drawContent.Orientation = VisualOrientation.Top;
				}
				_drawDocker.SetDock(_drawContent, ViewDockStyle.Bottom);
				break;
			case VisualOrientation.Left:
				if (_captionOrientation == ButtonOrientation.Auto)
				{
					_drawContent.Orientation = VisualOrientation.Left;
				}
				_drawDocker.SetDock(_drawContent, ViewDockStyle.Left);
				break;
			case VisualOrientation.Right:
				if (_captionOrientation == ButtonOrientation.Auto)
				{
					_drawContent.Orientation = VisualOrientation.Right;
				}
				_drawDocker.SetDock(_drawContent, ViewDockStyle.Right);
				break;
			}
			PerformNeedPaint(needLayout: true);
		}
	}

	[Category("Visuals")]
	[Description("Orientation of the caption.")]
	[DefaultValue(typeof(ButtonOrientation), "Auto")]
	public ButtonOrientation CaptionOrientation
	{
		get
		{
			return _captionOrientation;
		}
		set
		{
			if (_captionOrientation == value)
			{
				return;
			}
			_captionOrientation = value;
			switch (_captionOrientation)
			{
			case ButtonOrientation.FixedTop:
				_drawContent.Orientation = VisualOrientation.Top;
				break;
			case ButtonOrientation.FixedBottom:
				_drawContent.Orientation = VisualOrientation.Bottom;
				break;
			case ButtonOrientation.FixedLeft:
				_drawContent.Orientation = VisualOrientation.Left;
				break;
			case ButtonOrientation.FixedRight:
				_drawContent.Orientation = VisualOrientation.Right;
				break;
			case ButtonOrientation.Auto:
				switch (_captionEdge)
				{
				case VisualOrientation.Top:
				case VisualOrientation.Bottom:
					_drawContent.Orientation = VisualOrientation.Top;
					break;
				case VisualOrientation.Left:
					_drawContent.Orientation = VisualOrientation.Left;
					break;
				case VisualOrientation.Right:
					_drawContent.Orientation = VisualOrientation.Right;
					break;
				}
				break;
			}
			PerformNeedPaint(needLayout: true);
		}
	}

	[Category("Visuals")]
	[Description("Caption visibility.")]
	[DefaultValue(true)]
	public bool CaptionVisible
	{
		get
		{
			return _captionVisible;
		}
		set
		{
			if (_captionVisible != value)
			{
				_captionVisible = value;
				ReapplyVisible();
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining common header group appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteGroupBoxRedirect StateCommon => _stateCommon;

	[Category("Visuals")]
	[Description("Overrides for defining disabled header group appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteGroupBox StateDisabled => _stateDisabled;

	[Category("Visuals")]
	[Description("Overrides for defining normal header group appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteGroupBox StateNormal => _stateNormal;

	[Category("Visuals")]
	[Description("Caption values")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public CaptionValues Values => _captionValues;

	public override Rectangle DisplayRectangle
	{
		get
		{
			ForceViewLayout();
			return new Rectangle(Panel.Location, Panel.Size);
		}
	}

	public KryptonGroupBox()
	{
		_captionStyle = LabelStyle.GroupBoxCaption;
		_captionEdge = VisualOrientation.Top;
		_captionOrientation = ButtonOrientation.Auto;
		_captionVisible = true;
		_captionValues = new CaptionValues(base.NeedPaintDelegate);
		_captionValues.TextChanged += OnValuesTextChanged;
		_stateCommon = new PaletteGroupBoxRedirect(base.Redirector, base.NeedPaintDelegate);
		_stateDisabled = new PaletteGroupBox(_stateCommon, base.NeedPaintDelegate);
		_stateNormal = new PaletteGroupBox(_stateCommon, base.NeedPaintDelegate);
		_panel = new KryptonGroupPanel(this, _stateCommon, _stateDisabled, _stateNormal, OnGroupPanelPaint);
		_panel.PanelBackStyle = PaletteBackStyle.ControlGroupBox;
		_drawContent = new ViewDrawContent(_stateNormal.Content, _captionValues, VisualOrientation.Top);
		_drawDocker = new ViewDrawGroupBoxDocker(_stateNormal.Back, _stateNormal.Border);
		_layoutFill = new ViewLayoutFill(_panel);
		_drawDocker.Add(_drawContent, ViewDockStyle.Top);
		_drawDocker.Add(_layoutFill, ViewDockStyle.Fill);
		base.ViewManager = new ViewManager(this, _drawDocker);
		AutoSizeMode = AutoSizeMode.GrowAndShrink;
		_removeObscurer = OnRemoveObscurer;
		_ignoreLayout = true;
		((KryptonReadOnlyControls)base.Controls).AddInternal(_panel);
		_ignoreLayout = false;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _obscurer != null)
		{
			try
			{
				_obscurer.Uncover();
				_obscurer.Dispose();
				_obscurer = null;
			}
			catch
			{
			}
		}
		base.Dispose(disposing);
	}

	private bool ShouldSerializeText()
	{
		return false;
	}

	public override void ResetText()
	{
		_captionValues.ResetHeading();
	}

	private void ResetGroupBorderStyle()
	{
		GroupBorderStyle = PaletteBorderStyle.ControlGroupBox;
	}

	private bool ShouldSerializeGroupBorderStyle()
	{
		return GroupBorderStyle != PaletteBorderStyle.ControlGroupBox;
	}

	private void ResetGroupBackStyle()
	{
		GroupBackStyle = PaletteBackStyle.ControlGroupBox;
	}

	private bool ShouldSerializeGroupBackStyle()
	{
		return GroupBackStyle != PaletteBackStyle.ControlGroupBox;
	}

	private void ResetCaptionStyle()
	{
		CaptionStyle = LabelStyle.GroupBoxCaption;
	}

	private bool ShouldSerializeCaptionStyle()
	{
		return CaptionStyle != LabelStyle.GroupBoxCaption;
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

	private bool ShouldSerializeValuesPrimary()
	{
		return !_captionValues.IsDefault;
	}

	public override Size GetPreferredSize(Size proposedSize)
	{
		if (base.ViewManager != null)
		{
			Size preferredSize = base.ViewManager.GetPreferredSize(base.Renderer, proposedSize);
			if (MaximumSize.Width > 0)
			{
				preferredSize.Width = Math.Min(MaximumSize.Width, preferredSize.Width);
			}
			if (MaximumSize.Height > 0)
			{
				preferredSize.Height = Math.Min(MaximumSize.Height, preferredSize.Width);
			}
			if (MinimumSize.Width > 0)
			{
				preferredSize.Width = Math.Max(MinimumSize.Width, preferredSize.Width);
			}
			if (MinimumSize.Height > 0)
			{
				preferredSize.Height = Math.Max(MinimumSize.Height, preferredSize.Height);
			}
			return preferredSize;
		}
		return base.GetPreferredSize(proposedSize);
	}

	public virtual void SetFixedState(PaletteState state)
	{
		_drawDocker.FixedState = state;
		_panel.SetFixedState(state);
	}

	protected void ForceControlLayout()
	{
		if (!base.IsInitialized)
		{
			_forcedLayout = true;
			OnLayout(new LayoutEventArgs(null, null));
			_forcedLayout = false;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override ControlCollection CreateControlsInstance()
	{
		return new KryptonReadOnlyControls(this);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		InvokeLayout();
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		OnLayout(new LayoutEventArgs(null, null));
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		_layingOut = true;
		if (!_ignoreLayout)
		{
			base.OnLayout(levent);
			if (base.IsInitialized || _forcedLayout || (base.DesignMode && _panel != null))
			{
				Rectangle fillRect = _layoutFill.FillRect;
				_panel.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
			}
		}
		_layingOut = false;
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		if (base.Enabled)
		{
			_drawContent.SetPalette(_stateNormal.Content);
			_drawDocker.SetPalettes(_stateNormal.Back, _stateNormal.Border);
		}
		else
		{
			_drawContent.SetPalette(_stateDisabled.Content);
			_drawDocker.SetPalettes(_stateDisabled.Back, _stateNormal.Border);
		}
		_drawContent.Enabled = base.Enabled;
		_drawDocker.Enabled = base.Enabled;
		PerformNeedPaint(needLayout: true);
		base.OnEnabledChanged(e);
	}

	protected override void OnResize(EventArgs e)
	{
		base.OnResize(e);
		ForceControlLayout();
	}

	protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
	{
		if (base.IsInitialized || !e.NeedLayout)
		{
			_panel.PerformNeedPaint(e.NeedLayout);
		}
		else
		{
			ForceControlLayout();
		}
		base.OnNeedPaint(sender, e);
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 70)
		{
			if (_obscurer == null)
			{
				_obscurer = new ScreenObscurer();
			}
			if (!base.IsDisposed && base.IsHandleCreated && !base.DesignMode)
			{
				_obscurer.Cover(this);
			}
			BeginInvoke(_removeObscurer);
		}
		if (m.Msg == 71 && _obscurer != null)
		{
			_obscurer.Uncover();
		}
		base.WndProc(ref m);
	}

	internal Component DesignerComponentFromPoint(Point pt)
	{
		if (base.IsDisposed)
		{
			return null;
		}
		return base.ViewManager.ComponentFromPoint(pt);
	}

	internal void DesignerMouseLeave()
	{
		OnMouseLeave(EventArgs.Empty);
	}

	private void OnRemoveObscurer(object sender, EventArgs e)
	{
		if (_obscurer != null)
		{
			_obscurer.Uncover();
		}
	}

	private void OnValuesTextChanged(object sender, EventArgs e)
	{
		OnTextChanged(EventArgs.Empty);
	}

	private void OnGroupPanelPaint(object sender, NeedLayoutEventArgs e)
	{
		if (e.NeedLayout && !_layingOut && AutoSize)
		{
			PerformNeedPaint(needLayout: true);
		}
	}

	private void ReapplyVisible()
	{
		_drawContent.Visible = _captionVisible;
	}

	private static int PaddingEdgeNeeded(int padding, int client)
	{
		if (padding < client)
		{
			return 0;
		}
		return padding - client;
	}
}
