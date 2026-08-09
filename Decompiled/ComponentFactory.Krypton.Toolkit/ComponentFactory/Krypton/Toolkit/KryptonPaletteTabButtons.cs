#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTabButtons : Storage
{
	private KryptonPaletteTabButton _tabCommon;

	private KryptonPaletteTabButton _tabHighProfile;

	private KryptonPaletteTabButton _tabStandardProfile;

	private KryptonPaletteTabButton _tabLowProfile;

	private KryptonPaletteTabButton _tabDock;

	private KryptonPaletteTabButton _tabDockAutoHidden;

	private KryptonPaletteTabButton _tabOneNote;

	private KryptonPaletteTabButton _tabCustom1;

	private KryptonPaletteTabButton _tabCustom2;

	private KryptonPaletteTabButton _tabCustom3;

	public override bool IsDefault => _tabCommon.IsDefault && _tabHighProfile.IsDefault && _tabStandardProfile.IsDefault && _tabLowProfile.IsDefault && _tabDock.IsDefault && _tabDockAutoHidden.IsDefault && _tabOneNote.IsDefault && _tabCustom1.IsDefault && _tabCustom2.IsDefault && _tabCustom3.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabCommon => _tabCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining High Profile appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabHighProfile => _tabHighProfile;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Standard Profile appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabStandardProfile => _tabStandardProfile;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining LowProfile appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabLowProfile => _tabLowProfile;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Dock appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabDock => _tabDock;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Dock AutoHidden appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabDockAutoHidden => _tabDockAutoHidden;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining OneNote appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabOneNote => _tabOneNote;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Custom1 appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabCustom1 => _tabCustom1;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Custom2 appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabCustom2 => _tabCustom2;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining Custom3 appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTabButton TabCustom3 => _tabCustom3;

	internal KryptonPaletteTabButtons(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_tabCommon = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabHighProfile, PaletteBorderStyle.TabHighProfile, PaletteContentStyle.TabHighProfile, needPaint);
		_tabHighProfile = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabHighProfile, PaletteBorderStyle.TabHighProfile, PaletteContentStyle.TabHighProfile, needPaint);
		_tabStandardProfile = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabStandardProfile, PaletteBorderStyle.TabStandardProfile, PaletteContentStyle.TabStandardProfile, needPaint);
		_tabLowProfile = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabLowProfile, PaletteBorderStyle.TabLowProfile, PaletteContentStyle.TabLowProfile, needPaint);
		_tabDock = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabDock, PaletteBorderStyle.TabDock, PaletteContentStyle.TabDock, needPaint);
		_tabDockAutoHidden = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabDockAutoHidden, PaletteBorderStyle.TabDockAutoHidden, PaletteContentStyle.TabDockAutoHidden, needPaint);
		_tabOneNote = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabOneNote, PaletteBorderStyle.TabOneNote, PaletteContentStyle.TabOneNote, needPaint);
		_tabCustom1 = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabCustom1, PaletteBorderStyle.TabCustom1, PaletteContentStyle.TabCustom1, needPaint);
		_tabCustom2 = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabCustom2, PaletteBorderStyle.TabCustom2, PaletteContentStyle.TabCustom2, needPaint);
		_tabCustom3 = new KryptonPaletteTabButton(redirector, PaletteBackStyle.TabCustom3, PaletteBorderStyle.TabCustom3, PaletteContentStyle.TabCustom3, needPaint);
		PaletteRedirectTriple redirector2 = new PaletteRedirectTriple(redirector, _tabCommon.StateDisabled, _tabCommon.StateNormal, _tabCommon.StatePressed, _tabCommon.StateTracking, _tabCommon.StateSelected, _tabCommon.OverrideFocus);
		_tabHighProfile.SetRedirector(redirector2);
		_tabStandardProfile.SetRedirector(redirector2);
		_tabLowProfile.SetRedirector(redirector2);
		_tabDock.SetRedirector(redirector2);
		_tabDockAutoHidden.SetRedirector(redirector2);
		_tabOneNote.SetRedirector(redirector2);
		_tabCustom1.SetRedirector(redirector2);
		_tabCustom2.SetRedirector(redirector2);
		_tabCustom3.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.BackStyle = PaletteBackStyle.TabHighProfile;
		common.StateCommon.BorderStyle = PaletteBorderStyle.TabHighProfile;
		common.StateCommon.ContentStyle = PaletteContentStyle.TabHighProfile;
		_tabHighProfile.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.TabStandardProfile;
		common.StateCommon.BorderStyle = PaletteBorderStyle.TabStandardProfile;
		common.StateCommon.ContentStyle = PaletteContentStyle.TabStandardProfile;
		_tabStandardProfile.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.TabLowProfile;
		common.StateCommon.BorderStyle = PaletteBorderStyle.TabLowProfile;
		common.StateCommon.ContentStyle = PaletteContentStyle.TabLowProfile;
		_tabLowProfile.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.TabDock;
		common.StateCommon.BorderStyle = PaletteBorderStyle.TabDock;
		common.StateCommon.ContentStyle = PaletteContentStyle.TabDock;
		_tabDock.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.TabDockAutoHidden;
		common.StateCommon.BorderStyle = PaletteBorderStyle.TabDockAutoHidden;
		common.StateCommon.ContentStyle = PaletteContentStyle.TabDockAutoHidden;
		_tabDockAutoHidden.PopulateFromBase();
		common.StateCommon.BackStyle = PaletteBackStyle.TabOneNote;
		common.StateCommon.BorderStyle = PaletteBorderStyle.TabOneNote;
		common.StateCommon.ContentStyle = PaletteContentStyle.TabOneNote;
		_tabOneNote.PopulateFromBase();
	}

	private bool ShouldSerializeTabCommon()
	{
		return !_tabCommon.IsDefault;
	}

	private bool ShouldSerializeTabHighProfile()
	{
		return !_tabHighProfile.IsDefault;
	}

	private bool ShouldSerializeTabStandardProfile()
	{
		return !_tabStandardProfile.IsDefault;
	}

	private bool ShouldSerializeTabLowProfile()
	{
		return !_tabLowProfile.IsDefault;
	}

	private bool ShouldSerializeTabDock()
	{
		return !_tabDock.IsDefault;
	}

	private bool ShouldSerializeTabDockAutoHidden()
	{
		return !_tabDockAutoHidden.IsDefault;
	}

	private bool ShouldSerializeTabOneNote()
	{
		return !_tabOneNote.IsDefault;
	}

	private bool ShouldSerializeTabCustom1()
	{
		return !_tabCustom1.IsDefault;
	}

	private bool ShouldSerializeTabCustom2()
	{
		return !_tabCustom2.IsDefault;
	}

	private bool ShouldSerializeTabCustom3()
	{
		return !_tabCustom3.IsDefault;
	}
}
