#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteCheckButtons : Storage
{
	private KryptonPaletteCheckButton _buttonCommon;

	private KryptonPaletteCheckButton _buttonStandalone;

	private KryptonPaletteCheckButton _buttonAlternate;

	private KryptonPaletteCheckButton _buttonLowProfile;

	private KryptonPaletteCheckButton _buttonButtonSpec;

	private KryptonPaletteCheckButton _buttonBreadCrumb;

	private KryptonPaletteCheckButton _buttonCalendarDay;

	private KryptonPaletteCheckButton _buttonCluster;

	private KryptonPaletteCheckButton _buttonGallery;

	private KryptonPaletteCheckButton _buttonNavigatorStack;

	private KryptonPaletteCheckButton _buttonNavigatorOverflow;

	private KryptonPaletteCheckButton _buttonNavigatorMini;

	private KryptonPaletteCheckButton _buttonInputControl;

	private KryptonPaletteCheckButton _buttonListItem;

	private KryptonPaletteCheckButton _buttonForm;

	private KryptonPaletteCheckButton _buttonFormClose;

	private KryptonPaletteCheckButton _buttonCommand;

	private KryptonPaletteCheckButton _buttonCustom1;

	private KryptonPaletteCheckButton _buttonCustom2;

	private KryptonPaletteCheckButton _buttonCustom3;

	public override bool IsDefault => _buttonCommon.IsDefault && _buttonStandalone.IsDefault && _buttonAlternate.IsDefault && _buttonLowProfile.IsDefault && _buttonButtonSpec.IsDefault && _buttonBreadCrumb.IsDefault && _buttonCalendarDay.IsDefault && _buttonCluster.IsDefault && _buttonGallery.IsDefault && _buttonNavigatorStack.IsDefault && _buttonNavigatorOverflow.IsDefault && _buttonNavigatorMini.IsDefault && _buttonInputControl.IsDefault && _buttonListItem.IsDefault && _buttonForm.IsDefault && _buttonFormClose.IsDefault && _buttonCommand.IsDefault && _buttonCustom1.IsDefault && _buttonCustom2.IsDefault && _buttonCustom3.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common inherited button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonCommon => _buttonCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Standalone appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonStandalone => _buttonStandalone;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Alternate appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonAlternate => _buttonAlternate;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining LowProfile appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonLowProfile => _buttonLowProfile;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonSpec appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonButtonSpec => _buttonButtonSpec;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining BreadCrumb appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonBreadCrumb => _buttonBreadCrumb;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining CalendarDay appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonCalendarDay => _buttonCalendarDay;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonCluster appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonCluster => _buttonCluster;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonGallery appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonGallery => _buttonGallery;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonNavigatorStack appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonNavigatorStack => _buttonNavigatorStack;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonNavigatorOverflow appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonNavigatorOverflow => _buttonNavigatorOverflow;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonNavigatorMini appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonNavigatorMini => _buttonNavigatorMini;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonInputControl appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonInputControl => _buttonInputControl;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonListItem appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonListItem => _buttonListItem;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonForm appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonForm => _buttonForm;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonFormClose appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonFormClose => _buttonFormClose;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining ButtonCommand appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonCommand => _buttonCommand;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Custom1 appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonCustom1 => _buttonCustom1;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Custom2 appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonCustom2 => _buttonCustom2;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Custom3 appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteCheckButton ButtonCustom3 => _buttonCustom3;

	internal KryptonPaletteCheckButtons(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_buttonCommon = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, needPaint);
		_buttonStandalone = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonStandalone, PaletteBorderStyle.ButtonStandalone, PaletteContentStyle.ButtonStandalone, needPaint);
		_buttonAlternate = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonAlternate, PaletteBorderStyle.ButtonAlternate, PaletteContentStyle.ButtonAlternate, needPaint);
		_buttonLowProfile = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonLowProfile, PaletteBorderStyle.ButtonLowProfile, PaletteContentStyle.ButtonLowProfile, needPaint);
		_buttonButtonSpec = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonButtonSpec, PaletteBorderStyle.ButtonButtonSpec, PaletteContentStyle.ButtonButtonSpec, needPaint);
		_buttonBreadCrumb = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonBreadCrumb, PaletteBorderStyle.ButtonBreadCrumb, PaletteContentStyle.ButtonBreadCrumb, needPaint);
		_buttonCalendarDay = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonCalendarDay, PaletteBorderStyle.ButtonCalendarDay, PaletteContentStyle.ButtonCalendarDay, needPaint);
		_buttonCluster = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonCluster, PaletteBorderStyle.ButtonCluster, PaletteContentStyle.ButtonCluster, needPaint);
		_buttonGallery = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonGallery, PaletteBorderStyle.ButtonGallery, PaletteContentStyle.ButtonGallery, needPaint);
		_buttonNavigatorStack = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonNavigatorStack, PaletteBorderStyle.ButtonNavigatorStack, PaletteContentStyle.ButtonNavigatorStack, needPaint);
		_buttonNavigatorOverflow = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonNavigatorOverflow, PaletteBorderStyle.ButtonNavigatorOverflow, PaletteContentStyle.ButtonNavigatorOverflow, needPaint);
		_buttonNavigatorMini = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonNavigatorMini, PaletteBorderStyle.ButtonNavigatorMini, PaletteContentStyle.ButtonNavigatorMini, needPaint);
		_buttonInputControl = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonInputControl, PaletteBorderStyle.ButtonInputControl, PaletteContentStyle.ButtonInputControl, needPaint);
		_buttonListItem = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonListItem, PaletteBorderStyle.ButtonListItem, PaletteContentStyle.ButtonListItem, needPaint);
		_buttonForm = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonForm, PaletteBorderStyle.ButtonForm, PaletteContentStyle.ButtonForm, needPaint);
		_buttonFormClose = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonFormClose, PaletteBorderStyle.ButtonFormClose, PaletteContentStyle.ButtonFormClose, needPaint);
		_buttonCommand = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonCommand, PaletteBorderStyle.ButtonCommand, PaletteContentStyle.ButtonCommand, needPaint);
		_buttonCustom1 = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonCustom1, PaletteBorderStyle.ButtonCustom1, PaletteContentStyle.ButtonCustom1, needPaint);
		_buttonCustom2 = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonCustom2, PaletteBorderStyle.ButtonCustom2, PaletteContentStyle.ButtonCustom2, needPaint);
		_buttonCustom3 = new KryptonPaletteCheckButton(redirector, PaletteBackStyle.ButtonCustom3, PaletteBorderStyle.ButtonCustom3, PaletteContentStyle.ButtonCustom3, needPaint);
		PaletteRedirectTriple redirector2 = new PaletteRedirectTriple(redirector, _buttonCommon.StateDisabled, _buttonCommon.StateNormal, _buttonCommon.StatePressed, _buttonCommon.StateTracking, _buttonCommon.StateCheckedNormal, _buttonCommon.StateCheckedPressed, _buttonCommon.StateCheckedTracking, _buttonCommon.OverrideFocus, _buttonCommon.OverrideDefault);
		_buttonStandalone.SetRedirector(redirector2);
		_buttonAlternate.SetRedirector(redirector2);
		_buttonLowProfile.SetRedirector(redirector2);
		_buttonButtonSpec.SetRedirector(redirector2);
		_buttonBreadCrumb.SetRedirector(redirector2);
		_buttonCalendarDay.SetRedirector(redirector2);
		_buttonCluster.SetRedirector(redirector2);
		_buttonGallery.SetRedirector(redirector2);
		_buttonNavigatorStack.SetRedirector(redirector2);
		_buttonNavigatorOverflow.SetRedirector(redirector2);
		_buttonNavigatorMini.SetRedirector(redirector2);
		_buttonInputControl.SetRedirector(redirector2);
		_buttonListItem.SetRedirector(redirector2);
		_buttonForm.SetRedirector(redirector2);
		_buttonFormClose.SetRedirector(redirector2);
		_buttonCommand.SetRedirector(redirector2);
		_buttonCustom1.SetRedirector(redirector2);
		_buttonCustom2.SetRedirector(redirector2);
		_buttonCustom3.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonStandalone;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonStandalone;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonStandalone;
		_buttonStandalone.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonAlternate;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonAlternate;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonAlternate;
		_buttonAlternate.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonLowProfile;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonLowProfile;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonLowProfile;
		_buttonLowProfile.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonButtonSpec;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonButtonSpec;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonButtonSpec;
		_buttonButtonSpec.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonBreadCrumb;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonBreadCrumb;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonBreadCrumb;
		_buttonBreadCrumb.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonCalendarDay;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonCalendarDay;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonCalendarDay;
		_buttonCalendarDay.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonNavigatorStack;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonNavigatorStack;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonNavigatorStack;
		_buttonNavigatorStack.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonNavigatorOverflow;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonNavigatorOverflow;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonNavigatorOverflow;
		_buttonNavigatorOverflow.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonNavigatorMini;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonNavigatorMini;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonNavigatorMini;
		_buttonNavigatorMini.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonInputControl;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonInputControl;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonInputControl;
		_buttonInputControl.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonListItem;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonListItem;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonListItem;
		_buttonListItem.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonForm;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonForm;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonForm;
		_buttonForm.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonFormClose;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonFormClose;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonFormClose;
		_buttonFormClose.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonCommand;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonCommand;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonCommand;
		_buttonCommand.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonCluster;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonCluster;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonCluster;
		_buttonCluster.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.ButtonGallery;
		common.StateCommon.BorderStyle = PaletteBorderStyle.ButtonGallery;
		common.StateCommon.ContentStyle = PaletteContentStyle.ButtonGallery;
		_buttonGallery.PopulateFromBase();
	}

	private bool ShouldSerializeButtonCommon()
	{
		return !_buttonCommon.IsDefault;
	}

	private bool ShouldSerializeButtonStandalone()
	{
		return !_buttonStandalone.IsDefault;
	}

	private bool ShouldSerializeButtonAlternate()
	{
		return !_buttonAlternate.IsDefault;
	}

	private bool ShouldSerializeButtonLowProfile()
	{
		return !_buttonLowProfile.IsDefault;
	}

	private bool ShouldSerializeButtonButtonSpec()
	{
		return !_buttonButtonSpec.IsDefault;
	}

	private bool ShouldSerializeButtonBreadCrumb()
	{
		return !_buttonBreadCrumb.IsDefault;
	}

	private bool ShouldSerializeButtonCalendarDay()
	{
		return !_buttonCalendarDay.IsDefault;
	}

	private bool ShouldSerializeButtonCluster()
	{
		return !_buttonCluster.IsDefault;
	}

	private bool ShouldSerializeButtonGallery()
	{
		return !_buttonGallery.IsDefault;
	}

	private bool ShouldSerializeButtonNavigatorStack()
	{
		return !_buttonNavigatorStack.IsDefault;
	}

	private bool ShouldSerializeButtonNavigatorOverflow()
	{
		return !_buttonNavigatorOverflow.IsDefault;
	}

	private bool ShouldSerializeButtonNavigatorMini()
	{
		return !_buttonNavigatorMini.IsDefault;
	}

	private bool ShouldSerializeButtonInputControl()
	{
		return !_buttonInputControl.IsDefault;
	}

	private bool ShouldSerializeButtonListItem()
	{
		return !_buttonListItem.IsDefault;
	}

	private bool ShouldSerializeButtonForm()
	{
		return !_buttonForm.IsDefault;
	}

	private bool ShouldSerializeButtonFormClose()
	{
		return !_buttonFormClose.IsDefault;
	}

	private bool ShouldSerializeButtonCommand()
	{
		return !_buttonCommand.IsDefault;
	}

	private bool ShouldSerializeButtonCustom1()
	{
		return !_buttonCustom1.IsDefault;
	}

	private bool ShouldSerializeButtonCustom2()
	{
		return !_buttonCustom2.IsDefault;
	}

	private bool ShouldSerializeButtonCustom3()
	{
		return !_buttonCustom3.IsDefault;
	}
}
