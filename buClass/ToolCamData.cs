// Decompiled with JetBrains decompiler
// Type: buClass.ToolCamData
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class ToolCamData : buSerilization
{
  public double DepthConstant = 1.0;
  public int DepthSliceCount = 2;
  public CamDepthType DepthType = CamDepthType.Constant;
  public double Stepover = 0.0;
  public double Cutover = 0.0;
  public double OperationHeight = 0.0;
  public double AreaClearanceSpeed = 100.0;
  public double FinishSpeed = 100.0;
  public double RetractSpeed = 100.0;
  public double FeedSpeed = 100.0;
  public double PlungeSpeed = 30.0;
  public double SpindleSpeed = 10000.0;
  public double OperationHeigthForSecond = 0.0;
  public double ExtraOffset = 0.0;
  public double SafeDistance = 100.0;
  public bool Air = false;
  public bool Water = false;
  public bool Oil = false;
  public bool InnerCooling = false;
  public bool FeedFromTool = false;
  public bool DistanceFromTool = false;
  public bool DepthFromTool = false;
  public bool CutOverrideFromTool = true;
  public ArrayList AirText = new ArrayList();
  public ArrayList OilText = new ArrayList();
  public ArrayList WaterText = new ArrayList();
  public ArrayList InnerCoolText = new ArrayList();
  public Pnt6D SimMoveOffset = new Pnt6D();
  public ClockDirectionType SpindleDirection = ClockDirectionType.CW;

  public ToolCamData()
  {
  }

  public ToolCamData(ToolCamData cam)
  {
    object CopiedClass = new object();
    buSerilization.CopyClass((object) cam, ref CopiedClass);
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
    return $"Feed: {this.FeedSpeed.ToString()} - PlungeSpeed: {this.PlungeSpeed.ToString()} - SpindleSpeed: {this.SpindleSpeed.ToString()} - SpindleDir: {this.SpindleDirection.ToString()}";
  }
}
