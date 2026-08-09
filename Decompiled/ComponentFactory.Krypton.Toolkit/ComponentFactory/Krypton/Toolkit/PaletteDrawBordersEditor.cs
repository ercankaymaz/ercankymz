using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class PaletteDrawBordersEditor : UITypeEditor
{
	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		if (context != null && context.Instance != null)
		{
			return UITypeEditorEditStyle.DropDown;
		}
		return base.GetEditStyle(context);
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (context != null && provider != null && value != null)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService != null)
			{
				PaletteDrawBordersSelector paletteDrawBordersSelector = new PaletteDrawBordersSelector();
				paletteDrawBordersSelector.Value = (PaletteDrawBorders)value;
				windowsFormsEditorService.DropDownControl(paletteDrawBordersSelector);
				return paletteDrawBordersSelector.Value;
			}
		}
		return base.EditValue(context, provider, value);
	}
}
