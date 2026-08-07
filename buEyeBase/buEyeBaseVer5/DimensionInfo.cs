// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.DimensionInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class DimensionInfo : buSerilization5
{
  public bool isStitchDrawing;
  public int ID;
  public int Style;
  public static byte f0004CA;
  public List<SewingCode> Codes;
  public Point3D Point;
  public double DeltaX;
  public double DeltaY;
  public double FootHeight;
  public double Speed;
  public SewingPunteriz Punterez;
  public static byte f0004D2;
  public string Explanation;
  public SewingCodes Codes;
  public double Data1;

  public DimensionInfo(SketchAnalyseData data)
  {
    ((MarbleInfo) this).DepthLevel = (List<double>) null;
    ((MarbleInfo) this).AnalyseEntities = (List<buEntity>) null;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
    ((MarbleInfo) this).DepthLevel = new List<double>();
    ((MarbleInfo) this).AnalyseEntities = new List<buEntity>();
    if (this.GetType() == CopiedClass.GetType())
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
    for (int index = 0; index <= ((MarbleInfo) data).DepthLevel.Count - 1; ++index)
      ((MarbleInfo) this).DepthLevel.Add(((MarbleInfo) data).DepthLevel[index]);
    for (int index = 0; index <= ((MarbleInfo) data).AnalyseEntities.Count - 1; ++index)
      ((MarbleInfo) this).AnalyseEntities.Add(buAngularDim.Copy(((MarbleInfo) data).AnalyseEntities[index]));
  }

  public override string ToString()
  {
    int count = ((MarbleInfo) this).AnalyseEntities.Count;
    string str1 = count.ToString();
    count = ((MarbleInfo) this).DepthLevel.Count;
    string str2 = count.ToString();
    return $"Ent: {str1}- Depth: {str2}";
  }

  public abstract void m0001D7();

  public DimensionInfo()
  {
    ((MarbleInfo) this).DefaultDepth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public DimensionInfo(double defaultDepth)
  {
    ((MarbleInfo) this).DefaultDepth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((MarbleInfo) this).DefaultDepth = defaultDepth;
  }

  public DimensionInfo(SketchAnalyseSetData data)
  {
    ((MarbleInfo) this).DefaultDepth = 0.0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
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
}
