// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Line2D
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class Line2D : buSerilization5
{
  public bool IsVertical;
  public DimensionType Type;

  public abstract void m0001ED();

  public Line2D()
  {
    ((EntityInfo) this).PunterizType = SewingPunterizType.MinLeft;
    ((EntityInfo) this).PunterizMethod = SewingPunterizMethod.StitchThenPunteriz;
    ((EntityInfo) this).Length = 10.0;
    ((EntityInfo) this).Width = 2.0;
    ((EntityInfo) this).Height = 4.0;
    ((EntityInfo) this).Angle = 0.0;
    ((EntityInfo) this).Count = 5;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public Line2D(SewingPunteriz data)
  {
    ((EntityInfo) this).PunterizType = SewingPunterizType.MinLeft;
    ((EntityInfo) this).PunterizMethod = SewingPunterizMethod.StitchThenPunteriz;
    ((EntityInfo) this).Length = 10.0;
    ((EntityInfo) this).Width = 2.0;
    ((EntityInfo) this).Height = 4.0;
    ((EntityInfo) this).Angle = 0.0;
    ((EntityInfo) this).Count = 5;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null) || !(this.GetType() == CopiedClass.GetType()))
      return;
    FieldInfo[] fields = this.GetType().GetFields();
    if (fields == null)
      return;
    for (int index = 0; index <= fields.Length - 1; ++index)
    {
      string name = fields[index].Name;
      object obj = fields[index].GetValue(CopiedClass);
      fields[index].SetValue((object) this, obj);
    }
  }

  public override string ToString()
  {
    return $"{((EntityInfo) this).PunterizType.ToString()} ; Length: {((EntityInfo) this).Length.ToString("f3")} ; Width: {((EntityInfo) this).Width.ToString("f3")} ; Count: {((EntityInfo) this).Count.ToString("f3")}";
  }

  public abstract void m0001F1();

  public Line2D()
  {
    // ISSUE: unable to decompile the method.
  }

  public Line2D(MarbleInfo data)
  {
    // ISSUE: unable to decompile the method.
  }

  public ArrayList ToDef(int Space)
  {
    return new ArrayList()
    {
      (object) (buImage5.SpaceChar(Space) + buSerilization5.ClassToString((object) this))
    };
  }

  public static void Decode(List<string> SL, ref MarbleInfo Sewing)
  {
    try
    {
      if (SL.Count < 1)
        return;
      Sewing = (MarbleInfo) new Line2D();
      object ObjPar = (object) Sewing;
      buSerilization5.StringToClass(ref ObjPar, SL[0]);
    }
    catch (Exception ex)
    {
    }
  }

  public override string ToString()
  {
    // ISSUE: unable to decompile the method.
  }

  public abstract void m0001F7();
}
