// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleChamferBothSideData
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleChamferBothSideData : buSerilization5
{
  public double RoughStepover;
  public bool RoughEnable;
  public bool RoughZigzagMode;
  public bool RoughPerpendicularA;
  public bool RoughReverseCAngle;
  public bool RoughMoveUpSafeDistance;
  public MarbleCamAreaMode RoughAreaMode;
  public double FinishPlungeFeed;

  public marbleChamferBothSideData()
  {
    ((MarbleProgramSettings) this).Items = new List<MarbleItem>();
    ((MarbleProgramSettings) this).VacuumCuts = (List<MarbleVacuumCut>) null;
    ((MarbleProgramSettings) this).VacuumMaterials = (List<MaterialBase5>) null;
    ((MarbleProgramSettings) this).SimMaterials = (List<List<MaterialBase5>>) null;
    ((MarbleProgramSettings) this).SheetGroup = (buEntitiesGroup) null;
    ((MarbleProgramSettings) this).Operations = new List<MarbleItemOperations>();
    ((MarbleProgramSettings) this).SheetSolidEntities = (List<Entity>) null;
    ((MarbleProgramSettings) this).Cams = new List<camTp>();
    ((MarbleProgramSettings) this).Cam = (camTp) null;
    ((MarbleProgramSettings) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((MarbleProgramSettings) this).SizeOfOperations = (BoxSize5) new SortbuOptions();
    ((MarbleProgramSettings) this).CamCalculated = false;
    ((MarbleProgramSettings) this).isSimulationDone = false;
    ((MarbleProgramSettings) this).isGCodeCreated = false;
    ((MarbleProgramSettings) this).isFileSend = false;
    ((MarbleProgramSettings) this).isSawAvailable = true;
    ((MarbleProgramSettings) this).isMillingAvailable = true;
    ((MarbleProgramSettings) this).isMillingHeadAvailable = true;
    ((MarbleProgramSettings) this).isCommonPathDone = false;
    ((MarbleProgramSettings) this).isWaterJetAvailable = true;
    ((MarbleProgramSettings) this).VacuumSelectedIndex = -1;
    ((MarbleProgramSettings) this).Name = "";
    ((MarbleProgramSettings) this).GCode = "";
    ((MarbleProgramSettings) this).TotalMessages = new List<InfoType>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public marbleChamferBothSideData(MarbleJob data)
  {
    ((MarbleProgramSettings) this).Items = new List<MarbleItem>();
    ((MarbleProgramSettings) this).VacuumCuts = (List<MarbleVacuumCut>) null;
    ((MarbleProgramSettings) this).VacuumMaterials = (List<MaterialBase5>) null;
    ((MarbleProgramSettings) this).SimMaterials = (List<List<MaterialBase5>>) null;
    ((MarbleProgramSettings) this).SheetGroup = (buEntitiesGroup) null;
    ((MarbleProgramSettings) this).Operations = new List<MarbleItemOperations>();
    ((MarbleProgramSettings) this).SheetSolidEntities = (List<Entity>) null;
    ((MarbleProgramSettings) this).Cams = new List<camTp>();
    ((MarbleProgramSettings) this).Cam = (camTp) null;
    ((MarbleProgramSettings) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((MarbleProgramSettings) this).SizeOfOperations = (BoxSize5) new SortbuOptions();
    ((MarbleProgramSettings) this).CamCalculated = false;
    ((MarbleProgramSettings) this).isSimulationDone = false;
    ((MarbleProgramSettings) this).isGCodeCreated = false;
    ((MarbleProgramSettings) this).isFileSend = false;
    ((MarbleProgramSettings) this).isSawAvailable = true;
    ((MarbleProgramSettings) this).isMillingAvailable = true;
    ((MarbleProgramSettings) this).isMillingHeadAvailable = true;
    ((MarbleProgramSettings) this).isCommonPathDone = false;
    ((MarbleProgramSettings) this).isWaterJetAvailable = true;
    ((MarbleProgramSettings) this).VacuumSelectedIndex = -1;
    ((MarbleProgramSettings) this).Name = "";
    ((MarbleProgramSettings) this).GCode = "";
    ((MarbleProgramSettings) this).TotalMessages = new List<InfoType>();
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
    if (((MarbleProgramSettings) data).TotalMessages.Count > 0)
      InfoType.Copy(((MarbleProgramSettings) data).TotalMessages, ref ((MarbleProgramSettings) this).TotalMessages);
    if (((MarbleProgramSettings) data).Material != null)
      ((MarbleProgramSettings) this).Material = (MaterialBase5) new ShapeMultiCenterData(((MarbleProgramSettings) data).Material);
    if (((MarbleProgramSettings) data).SheetGroup != null)
      ((MarbleProgramSettings) this).SheetGroup = new buEntitiesGroup(((MarbleProgramSettings) data).SheetGroup);
    if (((MarbleProgramSettings) data).SheetSolidEntities != null)
    {
      ((MarbleProgramSettings) this).SheetSolidEntities = new List<Entity>();
      buRadialDim.Copy(((MarbleProgramSettings) data).SheetSolidEntities, ref ((MarbleProgramSettings) this).SheetSolidEntities);
    }
    if ((((MarbleProgramSettings) data).VacuumCuts == null ? 0 : (((MarbleProgramSettings) data).VacuumCuts.Count > 0 ? 1 : 0)) != 0)
      DeleteEntitiesType.Copy(((MarbleProgramSettings) data).VacuumCuts, ref ((MarbleProgramSettings) this).VacuumCuts);
    if ((((MarbleProgramSettings) data).VacuumMaterials == null ? 0 : (((MarbleProgramSettings) data).VacuumMaterials.Count > 0 ? 1 : 0)) != 0)
    {
      ((MarbleProgramSettings) this).VacuumMaterials.Clear();
      for (int index = 0; index <= ((MarbleProgramSettings) data).VacuumMaterials.Count - 1; ++index)
        ((MarbleProgramSettings) this).VacuumMaterials.Add((MaterialBase5) new ShapeMultiCenterData(((MarbleProgramSettings) data).VacuumMaterials[index]));
    }
    if (((MarbleProgramSettings) data).Cams != null)
    {
      ((MarbleProgramSettings) this).Cams = new List<camTp>();
      camTpPoint.CopyCam(((MarbleProgramSettings) data).Cams, ref ((MarbleProgramSettings) this).Cams);
    }
    if (((MarbleProgramSettings) data).Cam != null)
      ((MarbleProgramSettings) this).Cam = new camTp(((MarbleProgramSettings) data).Cam);
    for (int index = 0; index <= ((MarbleProgramSettings) data).Items.Count - 1; ++index)
      ((MarbleProgramSettings) this).Items.Add((MarbleItem) new marbleCountertopCornerData(((MarbleProgramSettings) data).Items[index]));
  }

  public override string ToString()
  {
    return "Items: " + ((MarbleProgramSettings) this).Items.Count.ToString();
  }

  public static ArrayList ToDef(MarbleJob refJob, int Space)
  {
    screenInfo.ExceptionalVariables.Clear();
    screenInfo.ExceptionalVariables.Add("GCode");
    screenInfo.ExceptionalVariables.Add("TotalErrorMessages");
    screenInfo.ExceptionalVariables.Add("TotalWarningMessages");
    screenInfo.ExceptionalVariables.Add("Messages");
    screenInfo.ExceptionalVariables.Add("SheetSolidEntities");
    screenInfo.ExceptionalVariables.Add("Cams");
    screenInfo.ExceptionalVariables.Add("SheetGroup");
    screenInfo.ExceptionalVariables.Add("Cam");
    ArrayList def = new ArrayList();
    ArrayList arrayList = new ArrayList();
    arrayList.AddRange((ICollection) refJob.ToDefAll("", Space, (SerilizationMode5) 1));
    if (arrayList.Count > 0)
    {
      string str = arrayList[arrayList.Count - 1].ToString();
      arrayList.RemoveAt(arrayList.Count - 1);
      def.Add(arrayList[0]);
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<MarbleJobBase>"));
      for (int index = 1; index <= arrayList.Count - 1; ++index)
        def.Add((object) (buImage5.SpaceChar(2) + arrayList[index]?.ToString()));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</MarbleJobBase>"));
      if (((MarbleProgramSettings) refJob).SheetGroup != null)
        def.AddRange((ICollection) DimensionGroup.ToDefGroup(((MarbleProgramSettings) refJob).SheetGroup, Space + 2));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "<MarbleOperations>"));
      for (int index = 0; index <= ((MarbleProgramSettings) refJob).Items.Count - 1; ++index)
        def.AddRange((ICollection) marbleCountertopCornerData.ToDef(((MarbleProgramSettings) refJob).Items[index], Space + 4));
      def.Add((object) (buImage5.SpaceChar(Space + 2) + "</MarbleOperations>"));
      def.Add((object) str);
    }
    screenInfo.ExceptionalVariables.Clear();
    return def;
  }
}
