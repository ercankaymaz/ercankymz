// Decompiled with JetBrains decompiler
// Type: buClass.MouseKeyboardConfigration
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class MouseKeyboardConfigration : buSerilization
{
  public mouseButtons Button = mouseButtons.None;
  public modifierKeys Key = modifierKeys.None;

  public MouseKeyboardConfigration()
  {
  }

  public MouseKeyboardConfigration(mouseButtons Button, modifierKeys Key)
  {
    this.Key = Key;
    this.Button = Button;
  }

  public MouseKeyboardConfigration(MouseKeyboardConfigration data)
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

  public override string ToString()
  {
    return $"Button : {this.Button.ToString()} ;  Key : {this.Key.ToString()}";
  }
}
