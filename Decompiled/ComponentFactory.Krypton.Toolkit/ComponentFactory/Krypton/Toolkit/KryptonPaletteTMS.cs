#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteTMS : Storage
{
	private KryptonInternalKCT _internalKCT;

	private KryptonPaletteTMSButton _paletteButton;

	private KryptonPaletteTMSGrip _paletteGrip;

	private KryptonPaletteTMSMenu _paletteMenu;

	private KryptonPaletteTMSMenuStrip _paletteMenuStrip;

	private KryptonPaletteTMSRafting _paletteRafting;

	private KryptonPaletteTMSSeparator _paletteSeparator;

	private KryptonPaletteTMSStatusStrip _paletteStatusStrip;

	private KryptonPaletteTMSToolStrip _paletteToolStrip;

	public override bool IsDefault => _internalKCT.IsDefault && _paletteButton.IsDefault && _paletteGrip.IsDefault && _paletteMenu.IsDefault && _paletteRafting.IsDefault && _paletteMenuStrip.IsDefault && _paletteSeparator.IsDefault && _paletteStatusStrip.IsDefault && _paletteToolStrip.IsDefault;

	[KryptonPersist]
	[Category("ToolMenuStatus")]
	[Description("Button specific colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMSButton Button => _paletteButton;

	[KryptonPersist]
	[Category("ToolMenuStatus")]
	[Description("Grip specific colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMSGrip Grip => _paletteGrip;

	[KryptonPersist]
	[Category("ToolMenuStatus")]
	[Description("Menu specific colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMSMenu Menu => _paletteMenu;

	[KryptonPersist]
	[Category("ToolMenuStatus")]
	[Description("Rafting specific colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMSRafting Rafting => _paletteRafting;

	[KryptonPersist]
	[Category("ToolMenuStatus")]
	[Description("MenuStrip specific colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMSMenuStrip MenuStrip => _paletteMenuStrip;

	[KryptonPersist]
	[Category("ToolMenuStatus")]
	[Description("Separator specific colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMSSeparator Separator => _paletteSeparator;

	[KryptonPersist]
	[Category("ToolMenuStatus")]
	[Description("StatusStrip specific colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMSStatusStrip StatusStrip => _paletteStatusStrip;

	[KryptonPersist]
	[Category("ToolMenuStatus")]
	[Description("ToolStrip specific colors.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public KryptonPaletteTMSToolStrip ToolStrip => _paletteToolStrip;

	[KryptonPersist(false)]
	[Category("ToolMenuStatus")]
	[Description("Should rendering use rounded or square edges.")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	public InheritBool UseRoundedEdges
	{
		get
		{
			return InternalKCT.InternalUseRoundedEdges;
		}
		set
		{
			InternalKCT.InternalUseRoundedEdges = value;
			PerformNeedPaint(needLayout: false);
		}
	}

	internal KryptonColorTable BaseKCT
	{
		get
		{
			return InternalKCT.BaseKCT;
		}
		set
		{
			InternalKCT.BaseKCT = value;
		}
	}

	internal KryptonInternalKCT InternalKCT => _internalKCT;

	internal KryptonPaletteTMS(IPalette palette, KryptonColorTable baseKCT, NeedPaintHandler needPaint)
	{
		Debug.Assert(baseKCT != null);
		_internalKCT = new KryptonInternalKCT(baseKCT, palette);
		_paletteButton = new KryptonPaletteTMSButton(_internalKCT, needPaint);
		_paletteGrip = new KryptonPaletteTMSGrip(_internalKCT, needPaint);
		_paletteMenu = new KryptonPaletteTMSMenu(_internalKCT, needPaint);
		_paletteMenuStrip = new KryptonPaletteTMSMenuStrip(_internalKCT, needPaint);
		_paletteRafting = new KryptonPaletteTMSRafting(_internalKCT, needPaint);
		_paletteSeparator = new KryptonPaletteTMSSeparator(_internalKCT, needPaint);
		_paletteStatusStrip = new KryptonPaletteTMSStatusStrip(_internalKCT, needPaint);
		_paletteToolStrip = new KryptonPaletteTMSToolStrip(_internalKCT, needPaint);
	}

	public void PopulateFromBase()
	{
		Button.PopulateFromBase();
		Grip.PopulateFromBase();
		Menu.PopulateFromBase();
		Rafting.PopulateFromBase();
		MenuStrip.PopulateFromBase();
		Separator.PopulateFromBase();
		StatusStrip.PopulateFromBase();
		ToolStrip.PopulateFromBase();
		UseRoundedEdges = InternalKCT.UseRoundedEdges;
	}

	private bool ShouldSerializeButton()
	{
		return !_paletteButton.IsDefault;
	}

	private bool ShouldSerializeGrip()
	{
		return !_paletteGrip.IsDefault;
	}

	private bool ShouldSerializeMenu()
	{
		return !_paletteMenu.IsDefault;
	}

	private bool ShouldSerializeRafting()
	{
		return !_paletteRafting.IsDefault;
	}

	private bool ShouldSerializeMenuStrip()
	{
		return !_paletteMenuStrip.IsDefault;
	}

	private bool ShouldSerializeSeparator()
	{
		return !_paletteSeparator.IsDefault;
	}

	private bool ShouldSerializeStatusStrip()
	{
		return !_paletteStatusStrip.IsDefault;
	}

	private bool ShouldSerializeToolStrip()
	{
		return !_paletteToolStrip.IsDefault;
	}

	public void ResetUseRoundedEdges()
	{
		UseRoundedEdges = InheritBool.Inherit;
	}
}
