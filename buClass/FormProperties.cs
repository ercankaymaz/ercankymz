// Decompiled with JetBrains decompiler
// Type: buClass.FormProperties
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace buClass;

[Serializable]
public class FormProperties : buSerilization
{
  public bool TopMost = false;
  public bool ReadOnly = false;
  public FormStartPosition FormPosition = FormStartPosition.CenterParent;
  public AutoScaleMode ScaleFromMode = AutoScaleMode.None;
  public DialogResult Result = DialogResult.None;
  public FormCloseModeType FormCloseMode = FormCloseModeType.Dispose;
  public int Width = 0;
  public int Height = 0;
  public bool Inited = false;
  public bool TouchPad = false;
  public bool ShowHelp = true;
  public bool Updated = false;
  public bool VisualUpdated = false;
  public string Message = "";
  public string sClassName = "";

  public FormProperties()
  {
  }

  public FormProperties(FormProperties data)
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

  public FormProperties(
    FormCloseModeType formclosemode,
    AutoScaleMode scalefrommode,
    FormStartPosition formposition,
    bool topmost,
    int width,
    int height)
  {
    this.FormCloseMode = formclosemode;
    this.ScaleFromMode = scalefrommode;
    this.FormPosition = formposition;
    this.TopMost = topmost;
    this.Width = width;
    this.Height = height;
  }
}
