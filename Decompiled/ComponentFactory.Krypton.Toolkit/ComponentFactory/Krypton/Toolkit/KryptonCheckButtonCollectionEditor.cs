using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonCheckButtonCollectionEditor : UITypeEditor
{
	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		if (context != null && context.Instance != null)
		{
			return UITypeEditorEditStyle.Modal;
		}
		return base.GetEditStyle(context);
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (context != null && context.Instance != null && provider != null)
		{
			IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
			if (windowsFormsEditorService != null)
			{
				KryptonCheckSet checkSet = (KryptonCheckSet)context.Instance;
				KryptonCheckButtonCollectionForm dialog = new KryptonCheckButtonCollectionForm(checkSet);
				if (windowsFormsEditorService.ShowDialog(dialog) == DialogResult.OK)
				{
					context.OnComponentChanged();
				}
			}
		}
		return value;
	}
}
