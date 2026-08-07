// Decompiled with JetBrains decompiler
// Type: buClass.camOffset
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class camOffset : buSerilization
{
  public bool Enable = true;
  public double Offset = 0.0;
  public double AdditionalOffset = 0.0;
  public double FinishOffset = 0.0;
  public int OffsetCount = 1;
  public double OverlapDistance = 0.0;
  public bool AddToolDiameterAsOffset = false;
  public double InCutSafeLength = 0.0;
  public CamClosedContourType ClosedContour = CamClosedContourType.Center;
  public OffsetCornerType Corner = OffsetCornerType.Line;
  public CamOpenContourType OpenContour = CamOpenContourType.Center;
  public CamOpenContourType2 OpenContourOld = CamOpenContourType2.Right;
  public static List<string> Captions = new List<string>();

  public camOffset()
  {
  }

  public camOffset(
    bool enable,
    double offset,
    double addtionalOffset,
    int offsetCount,
    double overlapDistance,
    CamClosedContourType flow,
    OffsetCornerType corner,
    CamOpenContourType2 openContour)
  {
    this.Enable = enable;
    this.Offset = offset;
    this.AdditionalOffset = addtionalOffset;
    this.OffsetCount = offsetCount;
    this.OverlapDistance = overlapDistance;
    this.ClosedContour = flow;
    this.Corner = corner;
    this.OpenContourOld = openContour;
  }

  public camOffset(camOffset offset)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) offset, ref CopiedClass);
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
    return $"{this.Enable.ToString()} , Offset: {this.Offset.ToString()} , Flow: {this.ClosedContour.ToString()} , Open: {this.OpenContourOld.ToString()}";
  }
}
