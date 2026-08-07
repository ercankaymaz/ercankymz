// Decompiled with JetBrains decompiler
// Type: buClass.PatternActions
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class PatternActions : buSerilization
{
  public CodeUsing AirDistance = new CodeUsing();
  public CodeUsing SafeDistance = new CodeUsing();
  public CodeUsing MoveToG53 = new CodeUsing();
  public CodeUsing MoveUpIncremental = new CodeUsing();
  public CodeUsing MoveOneStepUp = new CodeUsing();
  public CodeUsing MoveFirstPoint = new CodeUsing();

  public PatternActions()
  {
  }

  public PatternActions(PatternActions data)
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

  public PatternActions(
    bool air,
    bool safe,
    bool moveg53,
    bool moveupincremental,
    bool moveonestepup,
    bool movefirstpoint)
  {
    this.AirDistance.Enable = air;
    this.SafeDistance.Enable = safe;
    this.MoveToG53.Enable = moveg53;
    this.MoveUpIncremental.Enable = moveupincremental;
    this.MoveOneStepUp.Enable = moveonestepup;
    this.MoveFirstPoint.Enable = movefirstpoint;
  }
}
