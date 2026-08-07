// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setMainForm
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setMainForm : buSerilization
{
  public int panelExplorerWidth = 300;
  public DockVisible panelExplorerVisible = DockVisible.Visible;
  public int panelRightWidth = 250;
  public DockVisible panelRightVisible = DockVisible.Visible;
  public int panelBottomHeight = 250;
  public DockVisible panelBottomVisible = DockVisible.Visible;
  public int SplitterLeft1YPos = 323;
  public int SplitterLeft2YPos = 603;
  public bool ShowSecondStatusBar = false;

  public setMainForm()
  {
  }

  public setMainForm(setMainForm data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields != null)
    {
      for (int index = 0; index <= fields.Length - 1; ++index)
      {
        string name = fields[index].Name;
        object obj = fields[index].GetValue(CopiedClass);
        fields[index].SetValue((object) this, obj);
      }
    }
  }
}
