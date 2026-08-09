using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using buMutliTextbox;

namespace ns21;

internal sealed class Class58 : UITypeEditor
{
	UITypeEditorEditStyle UITypeEditor.GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.Modal;
	}

	object UITypeEditor.EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (provider != null && (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService)) != null)
		{
			HotkeysEditorForm hotkeysEditorForm = new HotkeysEditorForm(HotkeysMapping.Parse(value as string));
			if (hotkeysEditorForm.ShowDialog() == DialogResult.OK)
			{
				value = hotkeysEditorForm.GetHotkeys().ToString();
			}
		}
		return value;
	}
}
