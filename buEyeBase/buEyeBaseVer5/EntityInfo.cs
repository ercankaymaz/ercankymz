// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.EntityInfo
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.Apps.Marble;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class EntityInfo : buSerilization5
{
  public double Data2;
  public double Data3;
  public double Data4;
  public double Data5;
  public static byte f0004DA;
  public SewingPunterizType PunterizType;
  public SewingPunterizMethod PunterizMethod;
  public double Length;
  public double Width;
  public double Height;
  public double Angle;
  public int Count;
  public static byte f0004E2;
  public double ExtraAngleA;
  public double Angle;
  public double Depth;
  public double CuttingSpeed;
  public double CuttingStep;
  public int indexShape;
  public int indexEdge;
  public int ItemID;
  public int CommandID;
  public bool Trimmed;
  public bool isInside;
  public bool isConcave;
  public double TrimDistance;
  public double SlatWidth;
  public double SlatStartAngle;
  public double SlatEndAngle;
  public CamSequence Sequence;
  public StartEndBothNoneType TrimSide;
  public MarbleToolType ToolType;
  public MarbleCommandsEntity Command;
  public CamOpenContourType OffsetType;
  public marbleCollapsePars Collapse;
  public static byte f0004F9;
  public string Chars;
  public string Explanation;

  public override string ToString() => ((MarbleInfo) this).DefaultDepth.ToString();

  public EntityInfo()
  {
    ((MarbleInfo) this).Vertex = new List<SewingVertex>();
    ((MarbleInfo) this).StitchLengt = 3.3;
    ((MarbleInfo) this).HeadSpeed = 2000.0;
    ((MarbleInfo) this).StartStitchCount = 0;
    ((MarbleInfo) this).EndStitchCount = 0;
    ((MarbleInfo) this).StartStitchType = SewingAddStitchType.None;
    ((MarbleInfo) this).EndStitchType = SewingAddStitchType.None;
    ((DimensionInfo) this).isStitchDrawing = true;
    ((DimensionInfo) this).ID = -1;
    ((DimensionInfo) this).Style = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public EntityInfo(SewingInfo data)
  {
    ((MarbleInfo) this).Vertex = new List<SewingVertex>();
    ((MarbleInfo) this).StitchLengt = 3.3;
    ((MarbleInfo) this).HeadSpeed = 2000.0;
    ((MarbleInfo) this).StartStitchCount = 0;
    ((MarbleInfo) this).EndStitchCount = 0;
    ((MarbleInfo) this).StartStitchType = SewingAddStitchType.None;
    ((MarbleInfo) this).EndStitchType = SewingAddStitchType.None;
    ((DimensionInfo) this).isStitchDrawing = true;
    ((DimensionInfo) this).ID = -1;
    ((DimensionInfo) this).Style = 0;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
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
    ((MarbleInfo) this).Vertex.Clear();
    for (int index = 0; index <= ((MarbleInfo) data).Vertex.Count - 1; ++index)
      ((MarbleInfo) this).Vertex.Add((SewingVertex) new Rectangle2D(((MarbleInfo) data).Vertex[index]));
  }
}
