#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteButtonSpecs : Storage
{
	private KryptonPaletteButtonSpecTyped _common;

	private KryptonPaletteButtonSpecTyped _close;

	private KryptonPaletteButtonSpecTyped _context;

	private KryptonPaletteButtonSpecTyped _next;

	private KryptonPaletteButtonSpecTyped _previous;

	private KryptonPaletteButtonSpecTyped _generic;

	private KryptonPaletteButtonSpecTyped _arrowLeft;

	private KryptonPaletteButtonSpecTyped _arrowRight;

	private KryptonPaletteButtonSpecTyped _arrowUp;

	private KryptonPaletteButtonSpecTyped _arrowDown;

	private KryptonPaletteButtonSpecTyped _dropDown;

	private KryptonPaletteButtonSpecTyped _pinVertical;

	private KryptonPaletteButtonSpecTyped _pinHorizontal;

	private KryptonPaletteButtonSpecTyped _formClose;

	private KryptonPaletteButtonSpecTyped _formMax;

	private KryptonPaletteButtonSpecTyped _formMin;

	private KryptonPaletteButtonSpecTyped _formRestore;

	private KryptonPaletteButtonSpecTyped _pendantClose;

	private KryptonPaletteButtonSpecTyped _pendantMin;

	private KryptonPaletteButtonSpecTyped _pendantRestore;

	private KryptonPaletteButtonSpecTyped _workspaceMaximize;

	private KryptonPaletteButtonSpecTyped _workspaceRestore;

	private KryptonPaletteButtonSpecTyped _ribbonMinimize;

	private KryptonPaletteButtonSpecTyped _ribbonExpand;

	public override bool IsDefault => _common.IsDefault && _generic.IsDefault && _close.IsDefault && _context.IsDefault && _next.IsDefault && _previous.IsDefault && _arrowLeft.IsDefault && _arrowRight.IsDefault && _arrowUp.IsDefault && _arrowDown.IsDefault && _dropDown.IsDefault && _pinVertical.IsDefault && _pinHorizontal.IsDefault && _formClose.IsDefault && _formMax.IsDefault && _formMin.IsDefault && _formRestore.IsDefault && _pendantClose.IsDefault && _pendantMin.IsDefault && _pendantRestore.IsDefault && _workspaceMaximize.IsDefault && _workspaceRestore.IsDefault && _ribbonMinimize.IsDefault && _ribbonExpand.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped Common => _common;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining generic button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped Generic => _generic;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining close button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped Close => _close;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining context button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped Context => _context;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining next button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped Next => _next;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining previous button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped Previous => _previous;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining left arrow button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped ArrowLeft => _arrowLeft;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining right arrow button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped ArrowRight => _arrowRight;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining up arrow button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped ArrowUp => _arrowUp;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining up arrow button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped ArrowDown => _arrowDown;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining drop down button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped DropDown => _dropDown;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pin vertical button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped PinVertical => _pinVertical;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pin horizontal button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped PinHorizontal => _pinHorizontal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining form close button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped FormClose => _formClose;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining form minimize button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped FormMin => _formMin;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining form maximize button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped FormMax => _formMax;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining form restore button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped FormRestore => _formRestore;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pendant close button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped PendantClose => _pendantClose;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pendant minimize button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped PendantMin => _pendantMin;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining pendant restore button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped PendantRestore => _pendantRestore;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining workspace maximize button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped WorkspaceMaximize => _workspaceMaximize;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining workspace restore button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped WorkspaceRestore => _workspaceRestore;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ribbon minimize button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped RibbonMinimize => _ribbonMinimize;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ribbon expand button specifications.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteButtonSpecTyped RibbonExpand => _ribbonExpand;

	public event EventHandler ButtonSpecChanged;

	internal KryptonPaletteButtonSpecs(PaletteRedirect redirector)
	{
		Debug.Assert(redirector != null);
		_common = new KryptonPaletteButtonSpecTyped(redirector);
		_generic = new KryptonPaletteButtonSpecTyped(redirector);
		_close = new KryptonPaletteButtonSpecTyped(redirector);
		_context = new KryptonPaletteButtonSpecTyped(redirector);
		_next = new KryptonPaletteButtonSpecTyped(redirector);
		_previous = new KryptonPaletteButtonSpecTyped(redirector);
		_arrowLeft = new KryptonPaletteButtonSpecTyped(redirector);
		_arrowRight = new KryptonPaletteButtonSpecTyped(redirector);
		_arrowUp = new KryptonPaletteButtonSpecTyped(redirector);
		_arrowDown = new KryptonPaletteButtonSpecTyped(redirector);
		_dropDown = new KryptonPaletteButtonSpecTyped(redirector);
		_pinVertical = new KryptonPaletteButtonSpecTyped(redirector);
		_pinHorizontal = new KryptonPaletteButtonSpecTyped(redirector);
		_formClose = new KryptonPaletteButtonSpecTyped(redirector);
		_formMax = new KryptonPaletteButtonSpecTyped(redirector);
		_formMin = new KryptonPaletteButtonSpecTyped(redirector);
		_formRestore = new KryptonPaletteButtonSpecTyped(redirector);
		_pendantClose = new KryptonPaletteButtonSpecTyped(redirector);
		_pendantMin = new KryptonPaletteButtonSpecTyped(redirector);
		_pendantRestore = new KryptonPaletteButtonSpecTyped(redirector);
		_workspaceMaximize = new KryptonPaletteButtonSpecTyped(redirector);
		_workspaceRestore = new KryptonPaletteButtonSpecTyped(redirector);
		_ribbonMinimize = new KryptonPaletteButtonSpecTyped(redirector);
		_ribbonExpand = new KryptonPaletteButtonSpecTyped(redirector);
		PaletteRedirectButtonSpec redirector2 = new PaletteRedirectButtonSpec(redirector, _common);
		_generic.SetRedirector(redirector2);
		_close.SetRedirector(redirector2);
		_context.SetRedirector(redirector2);
		_next.SetRedirector(redirector2);
		_previous.SetRedirector(redirector2);
		_arrowLeft.SetRedirector(redirector2);
		_arrowRight.SetRedirector(redirector2);
		_arrowUp.SetRedirector(redirector2);
		_arrowDown.SetRedirector(redirector2);
		_dropDown.SetRedirector(redirector2);
		_pinVertical.SetRedirector(redirector2);
		_pinHorizontal.SetRedirector(redirector2);
		_formClose.SetRedirector(redirector2);
		_formMax.SetRedirector(redirector2);
		_formMin.SetRedirector(redirector2);
		_formRestore.SetRedirector(redirector2);
		_pendantClose.SetRedirector(redirector2);
		_pendantMin.SetRedirector(redirector2);
		_pendantRestore.SetRedirector(redirector2);
		_workspaceMaximize.SetRedirector(redirector2);
		_workspaceRestore.SetRedirector(redirector2);
		_ribbonMinimize.SetRedirector(redirector2);
		_ribbonExpand.SetRedirector(redirector2);
		_common.ButtonSpecChanged += OnButtonSpecChanged;
		_generic.ButtonSpecChanged += OnButtonSpecChanged;
		_close.ButtonSpecChanged += OnButtonSpecChanged;
		_context.ButtonSpecChanged += OnButtonSpecChanged;
		_next.ButtonSpecChanged += OnButtonSpecChanged;
		_previous.ButtonSpecChanged += OnButtonSpecChanged;
		_arrowLeft.ButtonSpecChanged += OnButtonSpecChanged;
		_arrowRight.ButtonSpecChanged += OnButtonSpecChanged;
		_arrowUp.ButtonSpecChanged += OnButtonSpecChanged;
		_arrowDown.ButtonSpecChanged += OnButtonSpecChanged;
		_dropDown.ButtonSpecChanged += OnButtonSpecChanged;
		_pinVertical.ButtonSpecChanged += OnButtonSpecChanged;
		_pinHorizontal.ButtonSpecChanged += OnButtonSpecChanged;
		_formClose.ButtonSpecChanged += OnButtonSpecChanged;
		_formMax.ButtonSpecChanged += OnButtonSpecChanged;
		_formMin.ButtonSpecChanged += OnButtonSpecChanged;
		_formRestore.ButtonSpecChanged += OnButtonSpecChanged;
		_pendantClose.ButtonSpecChanged += OnButtonSpecChanged;
		_pendantMin.ButtonSpecChanged += OnButtonSpecChanged;
		_pendantRestore.ButtonSpecChanged += OnButtonSpecChanged;
		_workspaceMaximize.ButtonSpecChanged += OnButtonSpecChanged;
		_workspaceRestore.ButtonSpecChanged += OnButtonSpecChanged;
		_ribbonMinimize.ButtonSpecChanged += OnButtonSpecChanged;
		_ribbonExpand.ButtonSpecChanged += OnButtonSpecChanged;
	}

	public void PopulateFromBase()
	{
		_generic.PopulateFromBase(PaletteButtonSpecStyle.Generic);
		_close.PopulateFromBase(PaletteButtonSpecStyle.Close);
		_context.PopulateFromBase(PaletteButtonSpecStyle.Context);
		_next.PopulateFromBase(PaletteButtonSpecStyle.Next);
		_previous.PopulateFromBase(PaletteButtonSpecStyle.Previous);
		_arrowLeft.PopulateFromBase(PaletteButtonSpecStyle.ArrowLeft);
		_arrowRight.PopulateFromBase(PaletteButtonSpecStyle.ArrowRight);
		_arrowUp.PopulateFromBase(PaletteButtonSpecStyle.ArrowUp);
		_arrowDown.PopulateFromBase(PaletteButtonSpecStyle.ArrowDown);
		_dropDown.PopulateFromBase(PaletteButtonSpecStyle.DropDown);
		_pinVertical.PopulateFromBase(PaletteButtonSpecStyle.PinVertical);
		_pinHorizontal.PopulateFromBase(PaletteButtonSpecStyle.PinHorizontal);
		_formClose.PopulateFromBase(PaletteButtonSpecStyle.FormClose);
		_formMax.PopulateFromBase(PaletteButtonSpecStyle.FormMax);
		_formMin.PopulateFromBase(PaletteButtonSpecStyle.FormMin);
		_formRestore.PopulateFromBase(PaletteButtonSpecStyle.FormRestore);
		_pendantClose.PopulateFromBase(PaletteButtonSpecStyle.PendantClose);
		_pendantRestore.PopulateFromBase(PaletteButtonSpecStyle.PendantRestore);
		_pendantMin.PopulateFromBase(PaletteButtonSpecStyle.PendantMin);
		_pendantRestore.PopulateFromBase(PaletteButtonSpecStyle.PendantRestore);
		_workspaceMaximize.PopulateFromBase(PaletteButtonSpecStyle.WorkspaceMaximize);
		_workspaceRestore.PopulateFromBase(PaletteButtonSpecStyle.WorkspaceRestore);
		_ribbonMinimize.PopulateFromBase(PaletteButtonSpecStyle.RibbonMinimize);
		_ribbonExpand.PopulateFromBase(PaletteButtonSpecStyle.RibbonExpand);
	}

	private bool ShouldSerializeCommon()
	{
		return !_common.IsDefault;
	}

	private bool ShouldSerializeGeneric()
	{
		return !_generic.IsDefault;
	}

	private bool ShouldSerializeClose()
	{
		return !_close.IsDefault;
	}

	private bool ShouldSerializeContext()
	{
		return !_context.IsDefault;
	}

	private bool ShouldSerializeNext()
	{
		return !_next.IsDefault;
	}

	private bool ShouldSerializePrevious()
	{
		return !_previous.IsDefault;
	}

	private bool ShouldSerializeArrowLeft()
	{
		return !_arrowLeft.IsDefault;
	}

	private bool ShouldSerializeArrowRight()
	{
		return !_arrowRight.IsDefault;
	}

	private bool ShouldSerializeArrowUp()
	{
		return !_arrowUp.IsDefault;
	}

	private bool ShouldSerializeArrowDown()
	{
		return !_arrowDown.IsDefault;
	}

	private bool ShouldSerializeDropDown()
	{
		return !_dropDown.IsDefault;
	}

	private bool ShouldSerializePinVertical()
	{
		return !_pinVertical.IsDefault;
	}

	private bool ShouldSerializePinHorizontal()
	{
		return !_pinHorizontal.IsDefault;
	}

	private bool ShouldSerializeFormClose()
	{
		return !_formClose.IsDefault;
	}

	private bool ShouldSerializeFormMin()
	{
		return !_formMin.IsDefault;
	}

	private bool ShouldSerializeFormMax()
	{
		return !_formMax.IsDefault;
	}

	private bool ShouldSerializeFormRestore()
	{
		return !_formRestore.IsDefault;
	}

	private bool ShouldSerializePendantClose()
	{
		return !_pendantClose.IsDefault;
	}

	private bool ShouldSerializePendantMin()
	{
		return !_pendantMin.IsDefault;
	}

	private bool ShouldSerializePendantRestore()
	{
		return !_pendantRestore.IsDefault;
	}

	private bool ShouldSerializeWorkspaceMaximize()
	{
		return !_workspaceMaximize.IsDefault;
	}

	private bool ShouldSerializeWorkspaceRestore()
	{
		return !_workspaceRestore.IsDefault;
	}

	private bool ShouldSerializeRibbonMinimize()
	{
		return !_ribbonMinimize.IsDefault;
	}

	private bool ShouldSerializeRibbonExpand()
	{
		return !_ribbonExpand.IsDefault;
	}

	protected virtual void OnButtonSpecChanged(object sender, EventArgs e)
	{
		if (this.ButtonSpecChanged != null)
		{
			this.ButtonSpecChanged(this, e);
		}
	}
}
