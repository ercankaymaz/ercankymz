using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonLinkLabel), "ToolboxBitmaps.KryptonLinkLabel.bmp")]
[DefaultEvent("LinkClicked")]
[DefaultProperty("Text")]
[DefaultBindingProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonLinkLabelDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Displays descriptive information as a hyperlink.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonLinkLabel : KryptonLabel
{
	private PaletteContent _stateVisited;

	private PaletteContent _stateNotVisited;

	private PaletteContent _statePressed;

	private PaletteContent _stateFocus;

	private PaletteContentInheritRedirect _stateVisitedRedirect;

	private PaletteContentInheritRedirect _stateNotVisitedRedirect;

	private PaletteContentInheritRedirect _statePressedRedirect;

	private PaletteContentInheritRedirect _stateFocusRedirect;

	private PaletteContentInheritOverride _overrideVisited;

	private PaletteContentInheritOverride _overrideNotVisited;

	private PaletteContentInheritOverride _overrideFocusNotVisited;

	private PaletteContentInheritOverride _overridePressed;

	private PaletteContentInheritOverride _overridePressedFocus;

	private LinkLabelBehaviorInherit _inheritBehavior;

	private LinkLabelController _controller;

	[Category("Visuals")]
	[Description("Determines the underline behavior of the link label.")]
	public KryptonLinkBehavior LinkBehavior
	{
		get
		{
			return _inheritBehavior.LinkBehavior;
		}
		set
		{
			if (_inheritBehavior.LinkBehavior != value)
			{
				_inheritBehavior.LinkBehavior = value;
				PerformNeedPaint(needLayout: false);
			}
		}
	}

	[Category("Visuals")]
	[Description("Indicates if the hyperlink has been visited already.")]
	[DefaultValue(false)]
	public bool LinkVisited
	{
		get
		{
			return _overrideVisited.Apply;
		}
		set
		{
			if (_overrideVisited.Apply != value)
			{
				_overrideVisited.Apply = value;
				_overrideNotVisited.Apply = !value;
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[Category("Visuals")]
	[Description("Overrides for defining pressed label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverridePressed => _statePressed;

	[Category("Visuals")]
	[Description("Overrides for defining label appearance when it has focus.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideFocus => _stateFocus;

	[Category("Visuals")]
	[Description("Overrides for modifying normal state when label has been visited.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideVisited => _stateVisited;

	[Category("Visuals")]
	[Description("Overrides for modifying normal state when label has not been visited.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContent OverrideNotVisited => _stateNotVisited;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Control Target
	{
		get
		{
			return base.Target;
		}
		set
		{
			base.Target = value;
		}
	}

	[Category("Action")]
	[Description("Occurs when the link is clicked.")]
	public event EventHandler LinkClicked;

	public KryptonLinkLabel()
	{
		SetStyle(ControlStyles.Selectable, value: true);
		base.EnabledTarget = false;
		_stateVisitedRedirect = new PaletteContentInheritRedirect(base.Redirector, PaletteContentStyle.LabelNormalControl);
		_stateNotVisitedRedirect = new PaletteContentInheritRedirect(base.Redirector, PaletteContentStyle.LabelNormalControl);
		_statePressedRedirect = new PaletteContentInheritRedirect(base.Redirector, PaletteContentStyle.LabelNormalControl);
		_stateFocusRedirect = new PaletteContentInheritRedirect(base.Redirector, PaletteContentStyle.LabelNormalControl);
		_stateVisited = new PaletteContent(_stateVisitedRedirect, base.NeedPaintDelegate);
		_stateNotVisited = new PaletteContent(_stateNotVisitedRedirect, base.NeedPaintDelegate);
		_stateFocus = new PaletteContent(_stateFocusRedirect, base.NeedPaintDelegate);
		_statePressed = new PaletteContent(_statePressedRedirect, base.NeedPaintDelegate);
		_inheritBehavior = new LinkLabelBehaviorInherit(base.StateNormal, KryptonLinkBehavior.AlwaysUnderline);
		_overrideVisited = new PaletteContentInheritOverride(_stateVisited, _inheritBehavior, PaletteState.LinkVisitedOverride, apply: false);
		_overrideNotVisited = new PaletteContentInheritOverride(_stateNotVisited, _overrideVisited, PaletteState.LinkNotVisitedOverride, apply: true);
		_overrideFocusNotVisited = new PaletteContentInheritOverride(_stateFocus, _overrideNotVisited, PaletteState.FocusOverride, apply: false);
		_overridePressed = new PaletteContentInheritOverride(_statePressed, _inheritBehavior, PaletteState.LinkPressedOverride, apply: false);
		_overridePressedFocus = new PaletteContentInheritOverride(_stateFocus, _overridePressed, PaletteState.FocusOverride, apply: false);
		_controller = new LinkLabelController(ViewDrawContent, base.StateDisabled, _overrideFocusNotVisited, _overrideFocusNotVisited, _overridePressedFocus, _overridePressed, base.NeedPaintDelegate);
		_controller.Click += OnControllerClick;
		ViewDrawContent.MouseController = _controller;
		ViewDrawContent.KeyController = _controller;
		ViewDrawContent.SourceController = _controller;
		ViewDrawContent.SetPalette(_overrideFocusNotVisited);
	}

	private void ResetLinkBehavior()
	{
		LinkBehavior = KryptonLinkBehavior.AlwaysUnderline;
	}

	private bool ShouldSerializeLinkBehavior()
	{
		return LinkBehavior != KryptonLinkBehavior.AlwaysUnderline;
	}

	private bool ShouldSerializeOverridePressed()
	{
		return !_statePressed.IsDefault;
	}

	private bool ShouldSerializeOverrideFocus()
	{
		return !_stateFocus.IsDefault;
	}

	private bool ShouldSerializeOverrideVisited()
	{
		return !_stateVisited.IsDefault;
	}

	private bool ShouldSerializeOverrideNotVisited()
	{
		return !_stateNotVisited.IsDefault;
	}

	public override void SetFixedState(PaletteState state)
	{
		base.SetFixedState(state);
		_controller.Update(this);
		PerformNeedPaint(needLayout: true);
	}

	protected virtual void OnLinkClicked(LinkClickedEventArgs e)
	{
		if (this.LinkClicked != null)
		{
			this.LinkClicked(this, e);
		}
		if (KryptonCommand != null)
		{
			KryptonCommand.PerformExecute();
		}
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		base.OnEnabledChanged(e);
		_controller.Update(this);
	}

	protected override void OnGotFocus(EventArgs e)
	{
		_overrideFocusNotVisited.Apply = true;
		_overridePressedFocus.Apply = true;
		PerformNeedPaint(needLayout: true);
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		_overrideFocusNotVisited.Apply = false;
		_overridePressedFocus.Apply = false;
		PerformNeedPaint(needLayout: true);
		base.OnLostFocus(e);
	}

	protected override void SetLabelStyle(LabelStyle style)
	{
		base.SetLabelStyle(style);
		PaletteContentStyle style2 = CommonHelper.ContentStyleFromLabelStyle(style);
		_stateVisitedRedirect.Style = style2;
		_stateNotVisitedRedirect.Style = style2;
		_statePressedRedirect.Style = style2;
		_stateFocusRedirect.Style = style2;
	}

	private void OnControllerClick(object sender, MouseEventArgs e)
	{
		OnLinkClicked(new LinkClickedEventArgs(Text));
	}
}
