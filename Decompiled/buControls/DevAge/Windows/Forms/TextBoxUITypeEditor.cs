using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class TextBoxUITypeEditor : DevAgeTextBoxButton, IServiceProvider, IWindowsFormsEditorService, ITypeDescriptorContext
{
	internal IContainer icontainer_0 = null;

	private UITypeEditor uitypeEditor_0;

	private DropDown dropDown_0 = null;

	[DefaultValue(null)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public UITypeEditor UITypeEditor
	{
		get
		{
			return uitypeEditor_0;
		}
		set
		{
			uitypeEditor_0 = value;
		}
	}

	IContainer ITypeDescriptorContext.Container => base.Container;

	object ITypeDescriptorContext.Instance => base.Value;

	PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor => null;

	public TextBoxUITypeEditor()
	{
		icontainer_0 = new Container();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	public override void ShowDialog()
	{
		try
		{
			OnDialogOpen(EventArgs.Empty);
			if (uitypeEditor_0 != null)
			{
				UITypeEditorEditStyle editStyle = uitypeEditor_0.GetEditStyle();
				if (editStyle == UITypeEditorEditStyle.DropDown || editStyle == UITypeEditorEditStyle.Modal)
				{
					if (!IsValidValue(out var convertedValue))
					{
						convertedValue = ((base.Validator != null) ? base.Validator.DefaultValue : null);
					}
					object value = uitypeEditor_0.EditValue(this, this, convertedValue);
					base.Value = value;
				}
			}
			OnDialogClosed(EventArgs.Empty);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Error");
		}
	}

	protected override void ApplyValidatorRules()
	{
		base.ApplyValidatorRules();
		if (uitypeEditor_0 == null && base.Validator != null)
		{
			object editor = TypeDescriptor.GetEditor(base.Validator.ValueType, typeof(UITypeEditor));
			if (editor is UITypeEditor)
			{
				uitypeEditor_0 = (UITypeEditor)editor;
			}
		}
	}

	object IServiceProvider.GetService(Type serviceType)
	{
		if (!(serviceType == typeof(IWindowsFormsEditorService)))
		{
			return null;
		}
		return this;
	}

	public virtual void CloseDropDown()
	{
		if (dropDown_0 != null)
		{
			dropDown_0.CloseDropDown();
		}
	}

	public virtual void DropDownControl(Control control)
	{
		using (dropDown_0 = new DropDown(control, this, base.ParentForm))
		{
			dropDown_0.DropDownFlags = DropDownFlags.CloseOnEscape;
			dropDown_0.ShowDropDown();
			dropDown_0.Close();
		}
		dropDown_0 = null;
	}

	public virtual DialogResult ShowDialog(Form dialog)
	{
		return dialog.ShowDialog(this);
	}

	void ITypeDescriptorContext.OnComponentChanged()
	{
	}

	bool ITypeDescriptorContext.OnComponentChanging()
	{
		return true;
	}
}
