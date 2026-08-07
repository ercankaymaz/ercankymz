// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.ProfileItem
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using System;
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class ProfileItem : buSerilization5
{
  public const DrillCNCMode Z3NoOffset = ; // Unable to render the field
  public const DrillCNCMode Z1_Z2NoOffset = ; // Unable to render the field
  public const DrillCNCMode Z1_Z3NoOffset = ; // Unable to render the field
  public const DrillCNCMode Z2_Z3NoOffset = ; // Unable to render the field
  public const DrillCNCMode Z1_Z2_Z3NoOffset = ; // Unable to render the field
  public const DrillCNCMode Cut = ; // Unable to render the field
  public const DrillCNCMode Safe = ; // Unable to render the field
  public const DrillCNCMode SafeRapid = ; // Unable to render the field
  public const DrillCNCMode ToolOffset = ; // Unable to render the field
  public const DrillCNCMode ToolSet = ; // Unable to render the field
  public const DrillCNCMode ToolReset = ; // Unable to render the field
  public const DrillCNCMode PressPistonReset = ; // Unable to render the field
  public const DrillCNCMode X1ClamperMove = ; // Unable to render the field
  public const DrillCNCMode X2ClamperMove = ; // Unable to render the field
  public const DrillCNCMode ToolOffsetGCode = ; // Unable to render the field
  public const DrillCNCMode None = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const DrillMoveAddType OnlyMove = ; // Unable to render the field
  public const DrillMoveAddType OnlySimulation = ; // Unable to render the field
  public const DrillMoveAddType BothMoveAndSimulation = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const drillPlaneNames Top = ; // Unable to render the field
  public const drillPlaneNames Bottom = ; // Unable to render the field
  public const drillPlaneNames Left = ; // Unable to render the field
  public const drillPlaneNames Right = ; // Unable to render the field
  public const drillPlaneNames Front = ; // Unable to render the field
  public const drillPlaneNames Back = ; // Unable to render the field
  public const drillPlaneNames LeftRight = ; // Unable to render the field
  [SpecialName]
  public int value__;
  public const drillViewports Main = ; // Unable to render the field
  public const drillViewports Edit = ; // Unable to render the field
  public const drillViewports Simulation = ; // Unable to render the field
  public const drillViewports List = ; // Unable to render the field
  public DrillJob Job;
  [SpecialName]
  public int value__;
  public const DrillMachineType GoUltra2Top1BottomNoAtc = ; // Unable to render the field
  public const DrillMachineType GoWithAtc = ; // Unable to render the field
  public const DrillMachineType GoWithNoAtc = ; // Unable to render the field
  public const DrillMachineType Sirius = ; // Unable to render the field
  public static System.Collections.Generic.List<TuftingSequenceItem> Sorted;
  public static byte f004204;
  public string LayerName;
  public bool Enable;
  public System.Collections.Generic.List<Entity> SortedEntities;
  public static byte f004208;
  public static System.Collections.Generic.List<buNestedResult> NestedAllResults;
  private bool \u0001;
  public static byte f004210;
  public double Width;
  public double Height;
  public double Thickness;
  public int Quantity;
  public string Name;
  public string ItemNo;
  public string SalesNo;
  public string Other;
  public string Aux;

  public void NestedSheetToEntity(
    buNestedSheet Sheet,
    bool isSolid,
    bool OnlyOutterSolid,
    ref System.Collections.Generic.List<Entity> calcEntities,
    ref System.Collections.Generic.List<Entity> UselessEntities)
  {
    calcEntities = new System.Collections.Generic.List<Entity>();
    buDiametricDim.Copy(((ProfileOperationDataNotch) Sheet).EntitiesGroup, ref calcEntities, Solid: true);
  }

  public void GetAllNestedPartFromSheet(
    buNestedSheet Sheet,
    bool isSorted,
    ref System.Collections.Generic.List<System.Collections.Generic.List<Entity>> partEntities,
    ref System.Collections.Generic.List<System.Collections.Generic.List<Entity>> innerEntities,
    ref System.Collections.Generic.List<System.Collections.Generic.List<Entity>> auxEntities)
  {
    partEntities.Clear();
    partEntities = new System.Collections.Generic.List<System.Collections.Generic.List<Entity>>();
    innerEntities.Clear();
    innerEntities = new System.Collections.Generic.List<System.Collections.Generic.List<Entity>>();
    auxEntities.Clear();
    auxEntities = new System.Collections.Generic.List<System.Collections.Generic.List<Entity>>();
    if (!isSorted)
    {
      for (int index = 0; index <= ((ProfileOperationDataNotch) Sheet).Parts.Count - 1; ++index)
      {
        System.Collections.Generic.List<Entity> partEntities1 = new System.Collections.Generic.List<Entity>();
        System.Collections.Generic.List<System.Collections.Generic.List<Entity>> innerEntities1 = new System.Collections.Generic.List<System.Collections.Generic.List<Entity>>();
        System.Collections.Generic.List<System.Collections.Generic.List<Entity>> auxEntities1 = new System.Collections.Generic.List<System.Collections.Generic.List<Entity>>();
        ((ProfileBase) this).NestedPartToEntity(((ProfileOperationDataNotch) Sheet).Parts[index], ref partEntities1, ref innerEntities1, ref auxEntities1);
        buVector5.AddEntities(partEntities1, ref partEntities);
        buVector5.AddEntities(innerEntities1, ref innerEntities);
        buVector5.AddEntities(auxEntities1, ref auxEntities);
      }
    }
    else
    {
      System.Collections.Generic.List<Entity> entityList1 = new System.Collections.Generic.List<Entity>();
      System.Collections.Generic.List<Entity> entityList2 = new System.Collections.Generic.List<Entity>();
      System.Collections.Generic.List<Entity> entityList3 = new System.Collections.Generic.List<Entity>();
      for (int index = 0; index <= ((ProfileOperationDataNotch) Sheet).Parts.Count - 1; ++index)
      {
        System.Collections.Generic.List<Entity> partEntities2 = new System.Collections.Generic.List<Entity>();
        System.Collections.Generic.List<System.Collections.Generic.List<Entity>> innerEntities2 = new System.Collections.Generic.List<System.Collections.Generic.List<Entity>>();
        System.Collections.Generic.List<System.Collections.Generic.List<Entity>> auxEntities2 = new System.Collections.Generic.List<System.Collections.Generic.List<Entity>>();
        ((ProfileBase) this).NestedPartToEntity(((ProfileOperationDataNotch) Sheet).Parts[index], ref partEntities2, ref innerEntities2, ref auxEntities2);
        buVector5.AddEntities(partEntities2, ref entityList1);
        buVector5.AddEntities(innerEntities2, ref entityList2);
        buVector5.AddEntities(auxEntities2, ref entityList3);
      }
      SortSettings Settings = (SortSettings) new ShapeRuntimeData();
      SortResult Result = (SortResult) new CurveToSurfaceSettingsType();
      ((SortbuOptions) ((SortbuFilter) Settings).Option).NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
      if (entityList1.Count > 0)
      {
        System.Collections.Generic.List<Entity> SortedEntities = new System.Collections.Generic.List<Entity>();
        buCall.\u0001.SortEntitiesByRefPoint(((ICurve) entityList1[0]).StartPoint, ref entityList1, Settings, ref SortedEntities, ref Result);
        buCall.\u0001.EntitiesSplitByUpperLine(SortedEntities, ref partEntities);
      }
      if (entityList2.Count > 0)
      {
        System.Collections.Generic.List<Entity> SortedEntities = new System.Collections.Generic.List<Entity>();
        buCall.\u0001.SortEntitiesByRefPoint(((ICurve) entityList2[0]).StartPoint, ref entityList2, Settings, ref SortedEntities, ref Result);
        buCall.\u0001.EntitiesSplitByUpperLine(SortedEntities, ref innerEntities);
      }
      if (entityList3.Count <= 0)
        return;
      System.Collections.Generic.List<Entity> SortedEntities1 = new System.Collections.Generic.List<Entity>();
      buCall.\u0001.SortEntitiesByRefPoint(((ICurve) entityList3[0]).StartPoint, ref entityList3, Settings, ref SortedEntities1, ref Result);
      buCall.\u0001.EntitiesSplitByUpperLine(SortedEntities1, ref auxEntities);
    }
  }

  public void SaveNestedResult(buNestedResult Result, string FileName)
  {
    ArrayList arrayList = new ArrayList();
    ArrayList StringList = new ArrayList();
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.Add((object) "   Nesting Results");
    StringList.Add((object) "------------------------------------------------------------------------");
    StringList.AddRange((ICollection) ProfileOperationData.ToDef(Result, 2));
    buVector5.SaveToFile(StringList, FileName);
  }

  public void GetPartNameAndQuantity(
    System.Collections.Generic.List<buEntity> entText,
    buNestingVar Setting,
    ref int itemQuantity,
    ref string itemName,
    bool isSheet = false)
  {
    if (entText.Count <= 0)
      return;
    string str1 = "";
    string RefWord1 = "";
    string str2 = "";
    string RefWord2 = "";
    if (!isSheet)
    {
      str1 = ((ProfileOperationRoundRectangle) ((ProfileSupportBlock) Setting).PartSettings).AutoPartNameRef;
      RefWord1 = ((ProfileOperationBarrel) ((ProfileSupportBlock) Setting).PartSettings).AutoPartNameEquality;
      str2 = ((ProfileOperationBarrel) ((ProfileSupportBlock) Setting).PartSettings).AutoPartQuantityRef;
      RefWord2 = ((ProfileOperationBarrel) ((ProfileSupportBlock) Setting).PartSettings).AutoPartQuantityEquality;
    }
    for (int index = 0; index <= entText.Count - 1; ++index)
    {
      string RefString = "";
      if (entText[index] is buText)
        RefString = ((\u0015.\u0001) entText[index]).TextString.Trim();
      if (entText[index] is buMultilineText)
        RefString = ((\u0084.\u0001) entText[index]).TextString.Trim();
      if (RefString.Trim().Length > 0)
      {
        if (RefString.IndexOf(str1) >= 0)
        {
          string[] Lines = (string[]) null;
          LockBitmap.SplitStringByRefWord(RefString, RefWord1, ref Lines);
          if ((Lines == null ? 0 : (Lines.Length >= 2 ? 1 : 0)) != 0)
            itemName = Lines[1];
        }
        if (RefString.IndexOf(str2) >= 0)
        {
          string[] Lines = (string[]) null;
          LockBitmap.SplitStringByRefWord(RefString, RefWord2, ref Lines);
          if ((Lines == null ? 0 : (Lines.Length >= 2 ? 1 : 0)) != 0 && buFile5.IsNumeric(Lines[1]))
            itemQuantity = int.Parse(Lines[1]);
        }
      }
      if (itemName.Trim().Length == 0)
        itemName = isSheet ? buLangTranslate.preDef.Sheet : buLangTranslate.preDef.Part;
    }
  }

  public static string SheetItemFormat(buNestedResult Result, string SheetName, int Index)
  {
    try
    {
      return $"{(Index + 1).ToString()}- {SheetName} , {((ProfileOperationDataNotch) ((ProfileOperationData) Result).NestedResultSheets[Index]).Parts.Count.ToString()} {buLangTranslate.preDef.Part}";
    }
    catch (Exception ex)
    {
      string str = "ID:00400009";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static string ResultItemFormat(buNestedResult Result)
  {
    try
    {
      string str1 = ((ProfileOperationData) Result).JobName;
      if (((ProfileOperationData) Result).JobColor.Trim().Length > 0)
        str1 = $"{str1} - {((ProfileOperationData) Result).JobColor}";
      if (((ProfileOperationData) Result).JobExplanation.Trim().Length > 0)
        str1 = $"{str1} - {((ProfileOperationData) Result).JobExplanation}";
      string str2 = $"{str1} = {((ProfileOperationData) Result).NestedResultSheets.Count.ToString()} {AppLanguage.CadCamDynamic[33]} ";
      if (((ProfileOperationData) Result).NotNestedAll)
      {
        string str3 = $"{AppLanguage.CadCamDynamic[94]} -  [{((ProfileOperationData) Result).NestedTotalPartCount.ToString()} / {((ProfileOperationData) Result).OrderedTotalPartCount.ToString()}]";
        str2 += str3;
      }
      if (((ProfileOperationData) Result).Licanse < 1)
        str2 = $"{str2} - {AppLanguage.CadCamDynamic[96 /*0x60*/]}";
      return str2;
    }
    catch (Exception ex)
    {
      string str = "ID:00400010";
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
      return "";
    }
  }

  public static string NestedSheetInfo(
    buNestedResult Result,
    int Index,
    buNestingProgramSettings Settings,
    int LineCount = 0)
  {
    return !((ProfileClamperSettings) Settings).isCutter ? ProfileItemCalc.NestedSheetInfoForCommon(Result, Index, Settings, LineCount) : ProfileItemCalc.NestedSheetInfoForCutter(Result, Index, Settings);
  }
}
