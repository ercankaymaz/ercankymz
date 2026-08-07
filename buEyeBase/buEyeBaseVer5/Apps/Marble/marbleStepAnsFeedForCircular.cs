// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.Marble.marbleStepAnsFeedForCircular
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buCore;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleStepAnsFeedForCircular : buSerilization5
{
  public bool ShowOutsideAngleText;
  public bool ShowSlatAngleText;
  public bool ShowAngleSolid;
  public bool ShowChamferSolid;
  public bool CollapseAs3DOnMain;

  public DialogResult SaveHorVerItems(
    marbleCuttingItems[] ItemsHor,
    marbleCuttingItems[] ItemsVer,
    double HorizontalLength,
    double VerticalLength)
  {
    SaveFileDialog saveFileDialog = new SaveFileDialog();
    saveFileDialog.InitialDirectory = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathItems;
    saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
    saveFileDialog.FilterIndex = 1;
    DialogResult dialogResult = saveFileDialog.ShowDialog();
    if (dialogResult == DialogResult.OK)
    {
      ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathItems = buFile.GetPath(saveFileDialog.FileName);
      ArrayList StringList = new ArrayList();
      int num = 0;
      if (ItemsHor != null)
      {
        StringList.Add((object) "<HorizontalMarbleCuttingItems>");
        for (int index = 0; index <= ItemsHor.Length - 1; ++index)
        {
          if (((marbleCountertopMainData) ItemsHor[index]).Length > 0.1 & ((marbleCountertopMainData) ItemsHor[index]).Count > 0)
          {
            StringList.AddRange((ICollection) ItemsHor[index].ToDefAll("", 2, (SerilizationMode5) 1));
            ++num;
          }
        }
        StringList.Add((object) "</HorizontalMarbleCuttingItems>");
        StringList.Add((object) "<HorizontalMarbleCuttingItemsLength>");
        StringList.Add((object) ("  " + HorizontalLength.ToString()));
        StringList.Add((object) "</HorizontalMarbleCuttingItemsLength>");
      }
      if (ItemsVer != null)
      {
        StringList.Add((object) "<VerticalMarbleCuttingItems>");
        for (int index = 0; index <= ItemsVer.Length - 1; ++index)
        {
          if (((marbleCountertopMainData) ItemsVer[index]).Length > 0.1 & ((marbleCountertopMainData) ItemsHor[index]).Count > 0)
          {
            StringList.AddRange((ICollection) ItemsVer[index].ToDefAll("", 2, (SerilizationMode5) 1));
            ++num;
          }
        }
        StringList.Add((object) "</VerticalMarbleCuttingItems>");
        StringList.Add((object) "<VerticalMarbleCuttingItemsLength>");
        StringList.Add((object) ("  " + VerticalLength.ToString()));
        StringList.Add((object) "</VerticalMarbleCuttingItemsLength>");
      }
      if (StringList.Count > 0 & num > 0)
        buFile.SaveToFile(StringList, saveFileDialog.FileName);
      else
        buNumeric5.MessageBoxWarning(buLangTranslate.preSentencesMarble.ThereIsNoItemtoSave);
    }
    return dialogResult;
  }

  public DialogResult OpenHorVerItems(
    ref marbleCuttingItems[] ItemsHor,
    ref marbleCuttingItems[] ItemsVer,
    ref double HorizontalLength,
    ref double VerticalLength)
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.InitialDirectory = ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathItems;
    openFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
    openFileDialog.FilterIndex = 1;
    openFileDialog.Multiselect = false;
    DialogResult dialogResult = openFileDialog.ShowDialog();
    if (dialogResult == DialogResult.OK)
    {
      ArrayList StringList = new ArrayList();
      ((MarbleCountertopSettings) MarbleRuntimeSettings.varMarbleRunSettings).pathItems = buFile.GetPath(openFileDialog.FileName);
      buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
      List<List<string>> CalcList1 = new List<List<string>>();
      List<List<string>> CalcList2 = new List<List<string>>();
      for (int index = 0; index <= ItemsHor.Length - 1; ++index)
        ItemsHor[index] = (marbleCuttingItems) new \u0007.\u0001();
      for (int index = 0; index <= ItemsVer.Length - 1; ++index)
        ItemsVer[index] = (marbleCuttingItems) new \u0007.\u0001();
      List<string> CalcList3 = new List<string>();
      buString.ListToSpecificList("<HorizontalMarbleCuttingItems>", "</HorizontalMarbleCuttingItems>", true, StringList, ref CalcList3);
      if (CalcList3.Count > 0)
      {
        buString.ListToSpecificList("<marbleCuttingItems>", "</marbleCuttingItems>", true, CalcList3, ref CalcList1);
        for (int index = 0; index <= CalcList1.Count - 1; ++index)
        {
          marbleCuttingItems marbleCuttingItems = (marbleCuttingItems) new \u0007.\u0001();
          buSerilization5.Decode(CalcList1[index], "", (SerilizationMode5) 1, (object) marbleCuttingItems);
          ((marbleCountertopMainData) ItemsHor[index]).Length = ((marbleCountertopMainData) marbleCuttingItems).Length;
          ((marbleCountertopMainData) ItemsHor[index]).Count = ((marbleCountertopMainData) marbleCuttingItems).Count;
          ((marbleCountertopMainData) ItemsHor[index]).StartAngle = ((marbleCountertopMainData) marbleCuttingItems).StartAngle;
          ((marbleCountertopMainData) ItemsHor[index]).EndAngle = ((marbleCountertopMainData) marbleCuttingItems).EndAngle;
        }
      }
      List<string> CalcList4 = new List<string>();
      buString.ListToSpecificList("<HorizontalMarbleCuttingItemsLength>", "</HorizontalMarbleCuttingItemsLength>", false, StringList, ref CalcList4);
      if ((CalcList4.Count <= 0 ? 0 : (buFile5.IsNumeric(CalcList4[0]) ? 1 : 0)) != 0)
        HorizontalLength = Convert.ToDouble(CalcList4[0]);
      List<string> CalcList5 = new List<string>();
      buString.ListToSpecificList("<VerticalMarbleCuttingItems>", "</VerticalMarbleCuttingItems>", true, StringList, ref CalcList5);
      if (CalcList5.Count > 0)
      {
        buString.ListToSpecificList("<marbleCuttingItems>", "</marbleCuttingItems>", true, CalcList5, ref CalcList2);
        for (int index = 0; index <= CalcList2.Count - 1; ++index)
        {
          marbleCuttingItems marbleCuttingItems = (marbleCuttingItems) new \u0007.\u0001();
          buSerilization5.Decode(CalcList2[index], "", (SerilizationMode5) 1, (object) marbleCuttingItems);
          ((marbleCountertopMainData) ItemsVer[index]).Length = ((marbleCountertopMainData) marbleCuttingItems).Length;
          ((marbleCountertopMainData) ItemsVer[index]).Count = ((marbleCountertopMainData) marbleCuttingItems).Count;
          ((marbleCountertopMainData) ItemsVer[index]).StartAngle = ((marbleCountertopMainData) marbleCuttingItems).StartAngle;
          ((marbleCountertopMainData) ItemsVer[index]).EndAngle = ((marbleCountertopMainData) marbleCuttingItems).EndAngle;
        }
      }
      List<string> CalcList6 = new List<string>();
      buString.ListToSpecificList("<VerticalMarbleCuttingItemsLength>", "</VerticalMarbleCuttingItemsLength>", false, StringList, ref CalcList6);
      if ((CalcList6.Count <= 0 ? 0 : (buFile5.IsNumeric(CalcList6[0]) ? 1 : 0)) != 0)
        VerticalLength = Convert.ToDouble(CalcList6[0]);
      CalcList6.Clear();
    }
    return dialogResult;
  }

  public void CreateEdgeEntity(
    buEntity entCurve,
    double OffsetDistance,
    double ExtrudeDistance,
    bool Selectable,
    int Index,
    string OutsideInside,
    ref buEntity entityEdge)
  {
    buEntity buEntity = entCurve;
    List<Point3D> OffsetedPoints = new List<Point3D>();
    if (((CustomDataSurrogate) entCurve).Vertices.Count <= 0)
      return;
    Region region;
    if (((F_AnalyseResult) buCall.\u0001).IsClosed(((CustomDataSurrogate) buEntity).Vertices))
    {
      buCall.\u0001.OffsetContour(((CustomDataSurrogate) buEntity).Vertices, OffsetDistance, OffsetCornerType.Line, CamOpenContourType.Center, Plane.XY, 0.0, ref OffsetedPoints);
      region = new Region((IList<ICurve>) new List<ICurve>()
      {
        (ICurve) new LinearPath((ICollection<Point3D>) OffsetedPoints),
        (ICurve) new LinearPath((ICollection<Point3D>) ((CustomDataSurrogate) buEntity).Vertices)
      });
    }
    else
    {
      buCall.\u0001.OffsetOpenContour(((CustomDataSurrogate) buEntity).Vertices, OffsetDistance, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints);
      region = new Region((ICurve) new LinearPath((ICollection<Point3D>) OffsetedPoints));
    }
    if (region == null)
      return;
    Mesh another = region.ExtrudeAsMesh(ExtrudeDistance, 0.1, Mesh.natureType.RichSmooth);
    entityEdge = (buEntity) new buShapeFreeLines(another);
    ((DirectionArrowSetting) ((CustomData) entityEdge).Info).Selectable = Selectable;
    ((CustomData) entityEdge).Marble = (MarbleInfo) new Line2D();
    ((AnalyseEntitiesSetting) ((CustomData) entityEdge).Info).EntityIndex = 0;
    ((AnalyseEntitiesSetting) ((CustomData) entityEdge).Info).EntitySubIndex = 0;
    ((AnalyseEntitiesSetting) ((CustomData) entityEdge).Info).RefIndex = Index;
    ((EntityDataSet) ((CustomData) entityEdge).Info).Tags = "Edge";
    ((EntityDataSet) ((CustomData) entityEdge).Info).Data = OutsideInside;
  }

  public void CreateEmptyItem(ref MarbleItem Item)
  {
    Item = (MarbleItem) new marbleCountertopPocketData();
    ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).GroupEntities = new List<buEntitiesGroup>();
    ((MarbleScreenCaptureSettings) Item).EntGroup = new buEntitiesGroup();
    ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).SourceEntities = new List<buEntity>();
    ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).DrawWireEntities = new List<buEntity>();
    ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).EdgeEntities = new List<buEntity>();
    ((MarbleMachineSimultionSettings) ((MarbleScreenCaptureSettings) Item).ItemEntities).ExtensionEntities = new List<buEntity>();
  }

  public bool GetEntityCommand(
    string refWord,
    ref string Cmd,
    ref int ItemID,
    ref int EdgeIndex,
    ref int EntityOutsideIndex,
    ref int EntityInsideIndex,
    ref int EntityInsideSubIndex,
    ref string Info,
    ref string Aux)
  {
    string[] strArray = refWord.Split(';');
    bool entityCommand;
    if ((strArray == null ? 0 : (strArray.Length >= 7 ? 1 : 0)) != 0)
    {
      Cmd = strArray[0];
      ItemID = Convert.ToInt32(strArray[1]);
      EdgeIndex = Convert.ToInt32(strArray[2]);
      EntityOutsideIndex = Convert.ToInt32(strArray[3]);
      EntityInsideIndex = Convert.ToInt32(strArray[4]);
      EntityInsideSubIndex = Convert.ToInt32(strArray[5]);
      Info = strArray[6];
      Aux = strArray[7];
      entityCommand = true;
    }
    else
      entityCommand = false;
    return entityCommand;
  }
}
