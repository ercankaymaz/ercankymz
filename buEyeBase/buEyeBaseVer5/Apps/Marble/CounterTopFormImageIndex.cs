// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.CounterTopFormImageIndex
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
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class CounterTopFormImageIndex
{
  public double FinishRapid;
  public double FinishStep;
  public double FinishSurfOffset;
  public double FinishDevideLen;
  public double FinishVerticalDevideLen;
  public double FinishMinZ;
  public double FinishLeadIn;
  public double FinishLeadOut;
  public double FinishTopOffset;
  public double FinishBottomOffset;
  public double FinishInsideOffset;
  public double FinishOutsideOffset;
  public bool FinishEnable;
  public bool FinishZigzagMode;
  public bool FinishPerpendicularA;

  public CounterTopFormImageIndex(MarbleItemExtend data)
  {
    ((MarbleMachineSimultionSettings) this).ExtendPoint = new Point3D();
    ((MarbleMachineSimultionSettings) this).ExtendLength = 0.0;
    ((MarbleMachineSimultionSettings) this).CamID = -1;
    ((MarbleMachineSimultionSettings) this).indexCam = -1;
    ((MarbleMachineSimultionSettings) this).indexWire = -1;
    ((MarbleMachineSimultionSettings) this).indexWireSub = -1;
    ((MarbleMachineSimultionSettings) this).Direction = StartEndType.Start;
    ((MarbleMachineSimultionSettings) this).entityExtend = (buEntity) null;
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
    if (((MarbleMachineSimultionSettings) data).entityExtend == null)
      return;
    buDiametricDim.Copy(((MarbleMachineSimultionSettings) data).entityExtend, ref ((MarbleMachineSimultionSettings) this).entityExtend);
  }

  public static void Add(MarbleItemExtend E, ref List<MarbleItemExtend> refList)
  {
    try
    {
      bool flag = false;
      int index1 = -1;
      for (int index2 = 0; index2 <= refList.Count - 1; ++index2)
      {
        if (buConversion5.EQ(((MarbleMachineSimultionSettings) refList[index2]).ExtendPoint, ((MarbleMachineSimultionSettings) E).ExtendPoint))
          flag = true;
        if (((MarbleMachineSimultionSettings) refList[index2]).indexCam == ((MarbleMachineSimultionSettings) E).indexCam & ((MarbleMachineSimultionSettings) refList[index2]).CamID == ((MarbleMachineSimultionSettings) E).CamID & ((MarbleMachineSimultionSettings) refList[index2]).indexWireSub == ((MarbleMachineSimultionSettings) E).indexWireSub & ((MarbleMachineSimultionSettings) refList[index2]).indexWire == ((MarbleMachineSimultionSettings) E).indexWire & ((MarbleMachineSimultionSettings) refList[index2]).Direction == ((MarbleMachineSimultionSettings) E).Direction)
        {
          flag = true;
          index1 = index2;
        }
      }
      if (!flag)
      {
        refList.Add(E);
      }
      else
      {
        if (!(index1 >= 0 & index1 <= refList.Count - 1))
          return;
        refList[index1] = (MarbleItemExtend) new CounterTopFormImageIndex(E);
      }
    }
    catch (Exception ex)
    {
    }
  }
}
