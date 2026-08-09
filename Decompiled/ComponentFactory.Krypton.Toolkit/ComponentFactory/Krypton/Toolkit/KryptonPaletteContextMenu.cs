using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonPaletteContextMenu : Storage
{
	private PaletteContextMenuRedirect _stateCommon;

	private PaletteContextMenuItemState _stateNormal;

	private PaletteContextMenuItemState _stateDisabled;

	private PaletteContextMenuItemStateHighlight _stateHighlight;

	private PaletteContextMenuItemStateChecked _stateChecked;

	public override bool IsDefault => _stateCommon.IsDefault && _stateNormal.IsDefault && _stateDisabled.IsDefault && _stateHighlight.IsDefault && _stateChecked.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining common appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuRedirect StateCommon => _stateCommon;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining disabled appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemState StateDisabled => _stateDisabled;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining normal appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemState StateNormal => _stateNormal;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining highlight appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemStateHighlight StateHighlight => _stateHighlight;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining checked appearance that other states can override.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteContextMenuItemStateChecked StateChecked => _stateChecked;

	internal KryptonPaletteContextMenu(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		_stateCommon = new PaletteContextMenuRedirect(redirect, needPaint);
		_stateNormal = new PaletteContextMenuItemState(_stateCommon);
		_stateDisabled = new PaletteContextMenuItemState(_stateCommon);
		_stateHighlight = new PaletteContextMenuItemStateHighlight(_stateCommon);
		_stateChecked = new PaletteContextMenuItemStateChecked(_stateCommon);
	}

	public void SetRedirector(PaletteRedirect redirect)
	{
		_stateCommon.SetRedirector(redirect);
	}

	public void PopulateFromBase(KryptonPaletteCommon common)
	{
		_stateCommon.PopulateFromBase(common, PaletteState.Normal);
		_stateDisabled.PopulateFromBase(common, PaletteState.Disabled);
		_stateNormal.PopulateFromBase(common, PaletteState.Normal);
		_stateHighlight.PopulateFromBase(common, PaletteState.Tracking);
		_stateChecked.PopulateFromBase(common, PaletteState.CheckedNormal);
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

	private bool ShouldSerializeStateHighlight()
	{
		return !_stateHighlight.IsDefault;
	}

	private bool ShouldSerializeStateChecked()
	{
		return !_stateChecked.IsDefault;
	}
}
