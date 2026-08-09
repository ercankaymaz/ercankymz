#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteHeaders : Storage
{
	private KryptonPaletteHeader _headerCommon;

	private KryptonPaletteHeader _headerPrimary;

	private KryptonPaletteHeader _headerSecondary;

	private KryptonPaletteHeader _headerDockInactive;

	private KryptonPaletteHeader _headerDockActive;

	private KryptonPaletteHeader _headerCalendar;

	private KryptonPaletteHeader _headerForm;

	private KryptonPaletteHeader _headerCustom1;

	private KryptonPaletteHeader _headerCustom2;

	public override bool IsDefault => _headerCommon.IsDefault && _headerPrimary.IsDefault && _headerSecondary.IsDefault && _headerDockInactive.IsDefault && _headerDockActive.IsDefault && _headerCalendar.IsDefault && _headerForm.IsDefault && _headerCustom1.IsDefault && _headerCustom2.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderCommon => _headerCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining primary header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderPrimary => _headerPrimary;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining secondary header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderSecondary => _headerSecondary;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining inactive dock header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderDockInactive => _headerDockInactive;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining active dock header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderDockActive => _headerDockActive;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining calendar header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderCalendar => _headerCalendar;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining main form header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderForm => _headerForm;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the first custom header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderCustom1 => _headerCustom1;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the second custom header appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteHeader HeaderCustom2 => _headerCustom2;

	internal KryptonPaletteHeaders(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_headerCommon = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderPrimary, PaletteBorderStyle.HeaderPrimary, PaletteContentStyle.HeaderPrimary, needPaint);
		_headerPrimary = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderPrimary, PaletteBorderStyle.HeaderPrimary, PaletteContentStyle.HeaderPrimary, needPaint);
		_headerSecondary = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderSecondary, PaletteBorderStyle.HeaderSecondary, PaletteContentStyle.HeaderSecondary, needPaint);
		_headerDockInactive = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderDockInactive, PaletteBorderStyle.HeaderDockInactive, PaletteContentStyle.HeaderDockInactive, needPaint);
		_headerDockActive = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderDockActive, PaletteBorderStyle.HeaderDockActive, PaletteContentStyle.HeaderDockActive, needPaint);
		_headerCalendar = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderCalendar, PaletteBorderStyle.HeaderCalendar, PaletteContentStyle.HeaderCalendar, needPaint);
		_headerForm = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderForm, PaletteBorderStyle.HeaderForm, PaletteContentStyle.HeaderForm, needPaint);
		_headerCustom1 = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderCustom1, PaletteBorderStyle.HeaderCustom1, PaletteContentStyle.HeaderCustom1, needPaint);
		_headerCustom2 = new KryptonPaletteHeader(redirector, PaletteBackStyle.HeaderCustom2, PaletteBorderStyle.HeaderCustom2, PaletteContentStyle.HeaderCustom2, needPaint);
		PaletteRedirectTripleMetric redirector2 = new PaletteRedirectTripleMetric(redirector, _headerCommon.StateDisabled, _headerCommon.StateDisabled, _headerCommon.StateNormal, _headerCommon.StateNormal);
		_headerPrimary.SetRedirector(redirector2);
		_headerSecondary.SetRedirector(redirector2);
		_headerDockInactive.SetRedirector(redirector2);
		_headerDockActive.SetRedirector(redirector2);
		_headerCalendar.SetRedirector(redirector2);
		_headerForm.SetRedirector(redirector2);
		_headerCustom1.SetRedirector(redirector2);
		_headerCustom2.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.HeaderPrimary;
		common.StateCommon.BorderStyle = PaletteBorderStyle.HeaderPrimary;
		common.StateCommon.ContentStyle = PaletteContentStyle.HeaderPrimary;
		_headerPrimary.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.HeaderSecondary;
		common.StateCommon.BorderStyle = PaletteBorderStyle.HeaderSecondary;
		common.StateCommon.ContentStyle = PaletteContentStyle.HeaderSecondary;
		_headerSecondary.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.HeaderDockInactive;
		common.StateCommon.BorderStyle = PaletteBorderStyle.HeaderDockInactive;
		common.StateCommon.ContentStyle = PaletteContentStyle.HeaderDockInactive;
		_headerDockInactive.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.HeaderDockActive;
		common.StateCommon.BorderStyle = PaletteBorderStyle.HeaderDockActive;
		common.StateCommon.ContentStyle = PaletteContentStyle.HeaderDockActive;
		_headerDockActive.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.HeaderCalendar;
		common.StateCommon.BorderStyle = PaletteBorderStyle.HeaderCalendar;
		common.StateCommon.ContentStyle = PaletteContentStyle.HeaderCalendar;
		_headerCalendar.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.HeaderForm;
		common.StateCommon.BorderStyle = PaletteBorderStyle.HeaderForm;
		common.StateCommon.ContentStyle = PaletteContentStyle.HeaderForm;
		_headerForm.PopulateFromBase();
	}

	private bool ShouldSerializeHeaderCommon()
	{
		return !_headerCommon.IsDefault;
	}

	private bool ShouldSerializeHeaderPrimary()
	{
		return !_headerPrimary.IsDefault;
	}

	private bool ShouldSerializeHeaderSecondary()
	{
		return !_headerSecondary.IsDefault;
	}

	private bool ShouldSerializeHeaderDockInactive()
	{
		return !_headerDockInactive.IsDefault;
	}

	private bool ShouldSerializeHeaderDockActive()
	{
		return !_headerDockActive.IsDefault;
	}

	private bool ShouldSerializeHeaderCalendar()
	{
		return !_headerCalendar.IsDefault;
	}

	private bool ShouldSerializeHeaderForm()
	{
		return !_headerForm.IsDefault;
	}

	private bool ShouldSerializeHeaderCustom1()
	{
		return !_headerCustom1.IsDefault;
	}

	private bool ShouldSerializeHeaderCustom2()
	{
		return !_headerCustom2.IsDefault;
	}
}
