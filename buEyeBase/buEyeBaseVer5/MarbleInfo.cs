// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.MarbleInfo
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
public class MarbleInfo : buSerilization5
{
  public double Width;
  public double Depth;
  public double HeadRadius;
  public int Side;
  public int Degree;
  public entitySplineType CurveType;
  public Point3D BasePoint;
  public static byte f0004B8;
  public List<string> Commands = new List<string>();
  public int EntityIndex = -1;
  public static byte f0004BB;
  public List<double> DepthLevel;
  public List<buEntity> AnalyseEntities;
  public static byte f0004BE;
  public double DefaultDepth;
  public List<SewingVertex> Vertex;
  public double StitchLengt;
  public double HeadSpeed;
  public int StartStitchCount;
  public int EndStitchCount;
  public SewingAddStitchType StartStitchType;
  public SewingAddStitchType EndStitchType;

  public MarbleInfo()
  {
  }

  public MarbleInfo(EditorCustomData data)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
    if (!(this != null & CopiedClass != null))
      return;
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
    for (int index = 0; index <= ((MarbleInfo) data).Commands.Count - 1; ++index)
      this.Commands.Add(((MarbleInfo) data).Commands[index]);
  }

  public override string ToString()
  {
    string str1 = this.EntityIndex.ToString() + ": ";
    if (this.Commands.Count > 0)
    {
      string str2 = "";
      for (int index = 0; index <= this.Commands.Count - 1; ++index)
      {
        if (index > 0)
          str2 = " , ";
        str1 = str1 + str2 + this.Commands[index];
      }
    }
    return str1;
  }

  public abstract void m0001D3();

  public MarbleInfo()
  {
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    this.DepthLevel = new List<double>();
    this.AnalyseEntities = new List<buEntity>();
  }
}
