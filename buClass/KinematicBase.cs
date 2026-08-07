// Decompiled with JetBrains decompiler
// Type: buClass.KinematicBase
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class KinematicBase : buSerilization
{
  public Pnt3D OffsetXYZ = new Pnt3D();
  public OrientationAngle OffsetABC = new OrientationAngle();
  public Pnt3D RotateCenterOffsetOfA = new Pnt3D();
  public Pnt3D RotateCenterOffsetOfB = new Pnt3D();
  public Pnt3D RotateCenterOffsetOfC = new Pnt3D();
  public Pnt3D MovePartRuntimeOffset = new Pnt3D();
  public KinemeticType Type = KinemeticType.CartezianXYZ_3Axis;
  public List<KinematicItem> Items = new List<KinematicItem>();
  public string Name = "Kinematic";
  public string FileName = "";
  public static List<string> Captions = new List<string>();

  public KinematicBase()
  {
  }

  public KinematicBase(KinematicBase data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
    {
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
    this.Items.Clear();
    for (int index = 0; index <= data.Items.Count - 1; ++index)
      this.Items.Add(new KinematicItem(data.Items[index]));
  }

  public override string ToString() => "Type: " + this.Type.ToString();
}
