using System;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonPaletteActionList : DesignerActionList
{
	private KryptonPalette _palette;

	private IComponentChangeService _service;

	public KryptonPaletteActionList(KryptonPaletteDesigner owner)
		: base(owner.Component)
	{
		_palette = owner.Component as KryptonPalette;
		_service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		if (_palette != null)
		{
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb("Reset to Defaults", OnResetClick), "Actions"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb("Populate from Base", OnPopulateClick), "Actions"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb("Import from Xml file...", OnImportClick), "Actions"));
			designerActionItemCollection.Add(new KryptonDesignerActionItem(new DesignerVerb("Export to Xml file...", OnExportClick), "Actions"));
		}
		return designerActionItemCollection;
	}

	private void OnResetClick(object sender, EventArgs e)
	{
		if (_palette != null && MessageBox.Show("Are you sure you want to reset the palette?", "Palette Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			_palette.ResetToDefaults(silent: false);
			_service.OnComponentChanged(_palette, null, null, null);
		}
	}

	private void OnPopulateClick(object sender, EventArgs e)
	{
		if (_palette != null && MessageBox.Show("Are you sure you want to populate from the base?", "Populate From Base", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
		{
			_palette.PopulateFromBase(silent: false);
			_service.OnComponentChanged(_palette, null, null, null);
		}
	}

	private void OnImportClick(object sender, EventArgs e)
	{
		if (_palette != null)
		{
			_palette.Import();
			_service.OnComponentChanged(_palette, null, null, null);
		}
	}

	private void OnExportClick(object sender, EventArgs e)
	{
		if (_palette != null)
		{
			_palette.Export();
		}
	}
}
