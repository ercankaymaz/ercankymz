// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.TextBoxUITypeEditor
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#nullable disable
namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class TextBoxUITypeEditor : 
  DevAgeTextBoxButton,
  System.IServiceProvider,
  IWindowsFormsEditorService,
  ITypeDescriptorContext
{
  internal IContainer icontainer_0 = (IContainer) null;
  private UITypeEditor uitypeEditor_0;
  private DropDown dropDown_0 = (DropDown) null;

  public TextBoxUITypeEditor() => this.icontainer_0 = (IContainer) new System.ComponentModel.Container();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.icontainer_0 != null)
      this.icontainer_0.Dispose();
    base.Dispose(disposing);
  }

  public override void ShowDialog()
  {
    try
    {
      this.OnDialogOpen(EventArgs.Empty);
      if (this.uitypeEditor_0 != null)
      {
        UITypeEditorEditStyle editStyle = this.uitypeEditor_0.GetEditStyle();
        if ((editStyle == UITypeEditorEditStyle.DropDown ? 1 : (editStyle == UITypeEditorEditStyle.Modal ? 1 : 0)) != 0)
        {
          object convertedValue;
          if (!this.IsValidValue(out convertedValue))
            convertedValue = this.Validator == null ? (object) null : this.Validator.DefaultValue;
          this.Value = this.uitypeEditor_0.EditValue((ITypeDescriptorContext) this, (System.IServiceProvider) this, convertedValue);
        }
      }
      this.OnDialogClosed(EventArgs.Empty);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, "Error");
    }
  }

  [DefaultValue(null)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public UITypeEditor UITypeEditor
  {
    get => this.uitypeEditor_0;
    set => this.uitypeEditor_0 = value;
  }

  protected override void ApplyValidatorRules()
  {
    base.ApplyValidatorRules();
    if ((this.uitypeEditor_0 != null ? 0 : (this.Validator != null ? 1 : 0)) == 0)
      return;
    object editor = TypeDescriptor.GetEditor(this.Validator.ValueType, typeof (UITypeEditor));
    if (!(editor is UITypeEditor))
      return;
    this.uitypeEditor_0 = (UITypeEditor) editor;
  }

  object System.IServiceProvider.GetService(System.Type serviceType)
  {
    return !(serviceType == typeof (IWindowsFormsEditorService)) ? (object) null : (object) this;
  }

  public virtual void CloseDropDown()
  {
    if (this.dropDown_0 == null)
      return;
    this.dropDown_0.CloseDropDown();
  }

  public virtual void DropDownControl(Control control)
  {
    using (this.dropDown_0 = new DropDown(control, (Control) this, this.ParentForm))
    {
      this.dropDown_0.DropDownFlags = DropDownFlags.CloseOnEscape;
      this.dropDown_0.ShowDropDown();
      this.dropDown_0.Close();
    }
    this.dropDown_0 = (DropDown) null;
  }

  public virtual DialogResult ShowDialog(Form dialog) => dialog.ShowDialog((IWin32Window) this);

  void ITypeDescriptorContext.OnComponentChanged()
  {
  }

  IContainer ITypeDescriptorContext.Container => this.Container;

  bool ITypeDescriptorContext.OnComponentChanging() => true;

  object ITypeDescriptorContext.Instance => this.Value;

  PropertyDescriptor ITypeDescriptorContext.PropertyDescriptor => (PropertyDescriptor) null;
}
