// Decompiled with JetBrains decompiler
// Type: buClass.ExplodeEventVar
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ExplodeEventVar : buSerilization
{
  public bool PolylineToLine = true;
  public bool CircleToArc = false;
  public bool CircleToPolyline = true;
  public bool ArcToPolyline = true;
  public bool EllipseToPolyline = true;
  public bool ArcEllipseToPolyline = true;
  public bool CurveToPolyline = true;
  public bool CurveToControlPoints = false;
  public bool UnGroup = true;
  public bool CompositeCurveToEntity = false;
  public bool BlockReferanceToEntity = false;
  public static List<string> Captions = new List<string>();

  public ExplodeEventVar()
  {
  }

  public ExplodeEventVar(ExplodeEventVar data)
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
