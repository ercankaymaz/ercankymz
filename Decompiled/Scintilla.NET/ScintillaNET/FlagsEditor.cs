using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms.Design;

namespace ScintillaNET;

internal class FlagsEditor : UITypeEditor
{
	public override bool IsDropDownResizable => true;

	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.DropDown;
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (value is Enum value2 && context.PropertyDescriptor.Attributes.OfType<FlagsAttribute>().Any())
		{
			IWindowsFormsEditorService obj = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			FlagsEditorControl flagsEditorControl = new FlagsEditorControl(obj, value2);
			obj.DropDownControl(flagsEditorControl);
			return flagsEditorControl.Value;
		}
		return base.EditValue(context, provider, value);
	}
}
