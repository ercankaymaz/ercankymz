#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteComboBoxRedirect : Storage
{
	private PaletteDoubleRedirect _dropBackRedirect;

	private PaletteTripleRedirect _itemRedirect;

	private PaletteInputControlTripleRedirect _comboBoxRedirect;

	[Browsable(false)]
	public override bool IsDefault => ComboBox.IsDefault && Item.IsDefault && DropBack.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining combo box appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteInputControlTripleRedirect ComboBox => _comboBoxRedirect;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining item appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTripleRedirect Item => _itemRedirect;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining dropdown background appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteBack DropBack => _dropBackRedirect.Back;

	public PaletteComboBoxRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_itemRedirect = new PaletteTripleRedirect(redirect, PaletteBackStyle.ButtonListItem, PaletteBorderStyle.ButtonListItem, PaletteContentStyle.ButtonListItem, NeedPaint);
		_comboBoxRedirect = new PaletteInputControlTripleRedirect(redirect, PaletteBackStyle.InputControlStandalone, PaletteBorderStyle.InputControlStandalone, PaletteContentStyle.InputControlStandalone, NeedPaint);
		_dropBackRedirect = new PaletteDoubleRedirect(redirect, PaletteBackStyle.ControlClient, PaletteBorderStyle.ButtonStandalone, NeedPaint);
	}

	public virtual void SetRedirector(PaletteRedirect redirect)
	{
		_itemRedirect.SetRedirector(redirect);
		_comboBoxRedirect.SetRedirector(redirect);
		_dropBackRedirect.SetRedirector(redirect);
	}

	public void SetStyles(InputControlStyle style)
	{
		_comboBoxRedirect.SetStyles(style);
	}

	public void SetStyles(ButtonStyle style)
	{
		_itemRedirect.SetStyles(style);
	}

	public void SetStyles(PaletteBackStyle style)
	{
		_dropBackRedirect.SetStyles(style, PaletteBorderStyle.ButtonStandalone);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_comboBoxRedirect.PopulateFromBase(state);
		_itemRedirect.PopulateFromBase(state);
		_dropBackRedirect.PopulateFromBase(state);
	}

	private bool ShouldSerializeComboBox()
	{
		return !_comboBoxRedirect.IsDefault;
	}

	private bool ShouldSerializeItem()
	{
		return !_itemRedirect.IsDefault;
	}

	private bool ShouldSerializeDropBack()
	{
		return !_dropBackRedirect.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
