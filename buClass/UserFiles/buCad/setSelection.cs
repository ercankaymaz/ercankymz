// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setSelection
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setSelection : buSerilization
{
  public DynamicalSelectionType DynamicSelection = DynamicalSelectionType.Entity;
  public MinMaxType DynamicSelectionDistanceType = MinMaxType.Min;
  public int SelectionTransparancy = 100;
  public Color colorSelectionLeftToRight = Color.DarkBlue;
  public drawPropertiesType displaySelectionLeftToRightBorder = new drawPropertiesType(Color.DarkBlue, 1f, new drawingPattern());
  public Color colorSelectionRightToLeft = Color.DarkRed;
  public drawPropertiesType displaySelectionRightToLeftBorder = new drawPropertiesType(Color.DarkRed, 1f, new drawingPattern());
  public bool ShowHighLight = true;
  public drawPropertiesType displayHighLight = new drawPropertiesType(Color.Yellow, 2f, new drawingPattern());
  public drawPropertiesType displaySelectedEntity = new drawPropertiesType(Color.DeepSkyBlue, 1f, new drawingPattern());
  public double SelectionBoxSize = 12.0;
  public drawPropertiesType displaySelectionBox = new drawPropertiesType(Color.Blue, 2f, new drawingPattern());
  public drawPropertiesType displaySelectionBoxControlSelected = new drawPropertiesType(Color.Red, 2f, new drawingPattern());
  public drawPropertiesType displaySelectionBoxMove = new drawPropertiesType(Color.BlueViolet, 2f, new drawingPattern());
  public drawPropertiesType displaySelectionBoxBoxSize = new drawPropertiesType(Color.AliceBlue, 2f, new drawingPattern());
  public bool ShowBoxSizeBoxes = false;
  public bool Enable3DPointsWithMouseClick = true;
  public bool ShowAllBoxes = true;
  public bool SmartSelection = false;
  public double SelectionResolution = 0.01;
  public double CompareResolution = 0.01;
  public bool UseSelectedEntityLayerForChainEntities = true;
  public bool DontUseRectangleSelection = false;
  public bool DontSelectGroupItem = false;
  public int MinVeeticeCount = 0;
  public bool OnlyClosedShapes = false;
  public double MinSingleEntityLength = 0.0;
  public bool ClearSelectionWhenPressEmptySpace = false;
  public bool MoveEntityWhenClickAlreadySelected = false;
  public bool SelectInternalEntitiesWhenClick = false;

  public setSelection()
  {
  }

  public setSelection(setSelection data)
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
