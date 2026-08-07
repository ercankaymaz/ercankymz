// Decompiled with JetBrains decompiler
// Type: buClass.LineerHatchVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class LineerHatchVar : buSerilization
{
  public double Distance = 10.0;
  public double OffsetOutter = 2.0;
  public double OffsetInner = 2.0;
  public double Angle = 0.0;
  public double ConnectionLimitAngle = -1.0;
  public double LengthFilter = 2.0;
  public double OffsetCheckFilter = 2.0;
  public HatchType Type = HatchType.Horizontal;
  public VerticalDirectionType VerticalMoveDirection = VerticalDirectionType.DownToUp;
  public HorizontalDirectionType HorizontalMoveDirection = HorizontalDirectionType.LeftToRight;
  public HatchSortType Sort = HatchSortType.ByClosestLength;
  public HatchAreaType AreaType = HatchAreaType.Region;
  public bool SingleDirection = false;
  public int TargetLayerIndex = 0;
  public static List<string> Captions = new List<string>();

  public LineerHatchVar()
  {
  }

  public LineerHatchVar(LineerHatchVar data)
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
