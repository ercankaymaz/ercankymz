// Decompiled with JetBrains decompiler
// Type: ns1.Class21
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using buMutliTextbox;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

#nullable disable
namespace ns1;

internal sealed class Class21 : UITypeEditor
{
  virtual UITypeEditorEditStyle UITypeEditor.GetEditStyle(ITypeDescriptorContext context)
  {
    return UITypeEditorEditStyle.Modal;
  }

  virtual object UITypeEditor.EditValue(
    ITypeDescriptorContext context,
    System.IServiceProvider provider,
    object value)
  {
    if ((provider == null ? 0 : ((IWindowsFormsEditorService) provider.GetService(typeof (IWindowsFormsEditorService)) != null ? 1 : 0)) != 0)
    {
      HotkeysEditorForm hotkeysEditorForm = new HotkeysEditorForm(HotkeysMapping.Parse(value as string));
      if (hotkeysEditorForm.ShowDialog() == DialogResult.OK)
        value = (object) hotkeysEditorForm.GetHotkeys().ToString();
    }
    return value;
  }
}
