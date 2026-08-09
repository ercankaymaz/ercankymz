#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteLabels : Storage
{
	private KryptonPaletteLabel _labelCommon;

	private KryptonPaletteLabel _labelNormalControl;

	private KryptonPaletteLabel _labelBoldControl;

	private KryptonPaletteLabel _labelItalicControl;

	private KryptonPaletteLabel _labelTitleControl;

	private KryptonPaletteLabel _labelNormalPanel;

	private KryptonPaletteLabel _labelBoldPanel;

	private KryptonPaletteLabel _labelItalicPanel;

	private KryptonPaletteLabel _labelTitlePanel;

	private KryptonPaletteLabel _labelCaptionPanel;

	private KryptonPaletteLabel _labelToolTip;

	private KryptonPaletteLabel _labelSuperTip;

	private KryptonPaletteLabel _labelKeyTip;

	private KryptonPaletteLabel _labelCustom1;

	private KryptonPaletteLabel _labelCustom2;

	private KryptonPaletteLabel _labelCustom3;

	public override bool IsDefault => _labelCommon.IsDefault && _labelNormalControl.IsDefault && _labelBoldControl.IsDefault && _labelItalicControl.IsDefault && _labelTitleControl.IsDefault && _labelNormalPanel.IsDefault && _labelBoldPanel.IsDefault && _labelItalicPanel.IsDefault && _labelTitlePanel.IsDefault && _labelCaptionPanel.IsDefault && _labelToolTip.IsDefault && _labelSuperTip.IsDefault && _labelKeyTip.IsDefault && _labelCustom1.IsDefault && _labelCustom2.IsDefault && _labelCustom3.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelCommon => _labelCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal label appearance for use on control style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelNormalControl => _labelNormalControl;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining bold label appearance for use on control style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelBoldControl => _labelBoldControl;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining italic label appearance for use on control style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelItalicControl => _labelItalicControl;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining title label appearance for use on control style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelTitleControl => _labelTitleControl;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal label appearance for use on panel style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelNormalPanel => _labelNormalPanel;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining bold label appearance for use on panel style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelBoldPanel => _labelBoldPanel;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining italic label appearance for use on panel style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelItalicPanel => _labelItalicPanel;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining title label appearance for use on panel style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelTitlePanel => _labelTitlePanel;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining caption label appearance for use on group box style backgrounds.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelCaptionPanel => _labelCaptionPanel;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the tooltip label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelToolTip => _labelToolTip;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the super tooltip label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelSuperTip => _labelSuperTip;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the keytip label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelKeyTip => _labelKeyTip;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the first custom label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelCustom1 => _labelCustom1;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the first second label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelCustom2 => _labelCustom2;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining the third second label appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteLabel LabelCustom3 => _labelCustom3;

	internal KryptonPaletteLabels(PaletteRedirect redirector, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirector != null);
		_labelCommon = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelNormalControl, needPaint);
		_labelNormalControl = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelNormalControl, needPaint);
		_labelBoldControl = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelBoldControl, needPaint);
		_labelItalicControl = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelItalicControl, needPaint);
		_labelTitleControl = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelTitleControl, needPaint);
		_labelNormalPanel = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelNormalPanel, needPaint);
		_labelBoldPanel = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelBoldPanel, needPaint);
		_labelItalicPanel = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelItalicPanel, needPaint);
		_labelTitlePanel = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelTitlePanel, needPaint);
		_labelCaptionPanel = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelGroupBoxCaption, needPaint);
		_labelToolTip = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelToolTip, needPaint);
		_labelSuperTip = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelSuperTip, needPaint);
		_labelKeyTip = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelKeyTip, needPaint);
		_labelCustom1 = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelCustom1, needPaint);
		_labelCustom2 = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelCustom2, needPaint);
		_labelCustom3 = new KryptonPaletteLabel(redirector, PaletteContentStyle.LabelCustom3, needPaint);
		PaletteRedirectContent redirector2 = new PaletteRedirectContent(redirector, _labelCommon.StateDisabled, _labelCommon.StateNormal);
		_labelNormalControl.SetRedirector(redirector2);
		_labelBoldControl.SetRedirector(redirector2);
		_labelItalicControl.SetRedirector(redirector2);
		_labelTitleControl.SetRedirector(redirector2);
		_labelNormalPanel.SetRedirector(redirector2);
		_labelBoldPanel.SetRedirector(redirector2);
		_labelItalicPanel.SetRedirector(redirector2);
		_labelTitlePanel.SetRedirector(redirector2);
		_labelCaptionPanel.SetRedirector(redirector2);
		_labelToolTip.SetRedirector(redirector2);
		_labelSuperTip.SetRedirector(redirector2);
		_labelKeyTip.SetRedirector(redirector2);
		_labelCustom1.SetRedirector(redirector2);
		_labelCustom2.SetRedirector(redirector2);
		_labelCustom3.SetRedirector(redirector2);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelNormalControl;
		_labelNormalControl.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelBoldControl;
		_labelNormalControl.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelItalicControl;
		_labelNormalControl.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelTitleControl;
		_labelTitleControl.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelNormalPanel;
		_labelNormalPanel.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelBoldPanel;
		_labelNormalPanel.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelItalicPanel;
		_labelNormalPanel.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelTitlePanel;
		_labelTitlePanel.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelGroupBoxCaption;
		_labelCaptionPanel.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelToolTip;
		_labelToolTip.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelSuperTip;
		_labelSuperTip.PopulateFromBase();
		common.StateCommon.ContentStyle = PaletteContentStyle.LabelKeyTip;
		_labelKeyTip.PopulateFromBase();
	}

	private bool ShouldSerializeLabelCommon()
	{
		return !_labelCommon.IsDefault;
	}

	private bool ShouldSerializeLabelNormalControl()
	{
		return !_labelNormalControl.IsDefault;
	}

	private bool ShouldSerializeLabelBoldControl()
	{
		return !_labelBoldControl.IsDefault;
	}

	private bool ShouldSerializeLabelItalicControl()
	{
		return !_labelItalicControl.IsDefault;
	}

	private bool ShouldSerializeLabelTitleControl()
	{
		return !_labelTitleControl.IsDefault;
	}

	private bool ShouldSerializeLabelNormalPanel()
	{
		return !_labelNormalPanel.IsDefault;
	}

	private bool ShouldSerializeLabelBoldPanel()
	{
		return !_labelBoldPanel.IsDefault;
	}

	private bool ShouldSerializeLabelItalicPanel()
	{
		return !_labelItalicPanel.IsDefault;
	}

	private bool ShouldSerializeLabelTitlePanel()
	{
		return !_labelTitlePanel.IsDefault;
	}

	private bool ShouldSerializeLabelCaptionPanel()
	{
		return !_labelCaptionPanel.IsDefault;
	}

	private bool ShouldSerializeLabelToolTip()
	{
		return !_labelToolTip.IsDefault;
	}

	private bool ShouldSerializeLabelSuperTip()
	{
		return !_labelSuperTip.IsDefault;
	}

	private bool ShouldSerializeLabelKeyTip()
	{
		return !_labelKeyTip.IsDefault;
	}

	private bool ShouldSerializeLabelCustom1()
	{
		return !_labelCustom1.IsDefault;
	}

	private bool ShouldSerializeLabelCustom2()
	{
		return !_labelCustom2.IsDefault;
	}

	private bool ShouldSerializeLabelCustom3()
	{
		return !_labelCustom3.IsDefault;
	}
}
