// Decompiled with JetBrains decompiler
// Type: buClass.UserFiles.buCad.setDisplay
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System.Drawing;
using System.Reflection;

#nullable disable
namespace buClass.UserFiles.buCad;

public class setDisplay : buSerilization
{
  public Color ColorViewportBottom = Color.FromArgb(67, 71, 82);
  public Color ColorViewportTop = Color.FromArgb(34, 35, 41);
  public Color ColorViewportIntermediate = Color.White;
  public Color ColorListboxBackColor = Color.LightGray;
  public drawPropertiesType displayDynamicDrawing = new drawPropertiesType(Color.Black, 1f, new drawingPattern());
  public bool CalculateVisibleEntitiesBorder = false;
  public bool ShowHighLightOsnapTogether = true;
  public bool ShowHighLight = true;
  public bool ShowFatWireframes = false;
  public bool ShowGuideLines = false;
  public bool CamSelectedFatDrawEnable = true;
  public double CamSelectedFatDrawAdditionalThickness = 2.0;
  public bool FatWireframesAsMesh = false;
  public bool FatWireframeAsMeshSingleLineMode = false;
  public drawPropertiesType displayHighLight = new drawPropertiesType(Color.Yellow, 2f, new drawingPattern());
  public double OsnapSize = 12.0;
  public double PointerSize = 25.0;
  public double EntityCatchScreenPersentage = 2.0;
  public drawPropertiesType displayPointer = new drawPropertiesType(Color.Cyan, 3f, new drawingPattern());
  public drawPropertiesType displayOsnap = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());
  public SolidItemDisplay displaySolidQuadItems = new SolidItemDisplay(Color.Gray, 100, Color.DimGray, 200);
  public SolidItemDisplay displayPlaneQuadItems = new SolidItemDisplay(Color.Gray, 150, Color.DimGray, 200);
  public drawPropertiesType displaySortArrow = new drawPropertiesType(Color.Green, 1f, new drawingPattern());
  public drawPropertiesType displayCircle = new drawPropertiesType(Color.Red, 1f, new drawingPattern());
  public double DrawCircleSize = 20.0;
  public Ruler TopRuler = new Ruler(true);
  public Ruler LeftRuler = new Ruler(true);
  public Ruler RightRuler = new Ruler(false);
  public Ruler BottomRuler = new Ruler(false);
  public drawPropertiesType displayAskMeEntities = new drawPropertiesType(Color.Blue, 2f, new drawingPattern());
  public drawPropertiesType displayAskMeEntitiesSelected = new drawPropertiesType(Color.Gold, 2f, new drawingPattern());
  public drawPropertiesType displaySortedEntities = new drawPropertiesType(Color.Red, 2f, new drawingPattern());
  public drawPropertiesType displaySortedUpperEntities = new drawPropertiesType(Color.Green, 2f, new drawingPattern());
  public drawPropertiesType displayGuideLines = new drawPropertiesType(Color.Gray, 1f, new drawingPattern());
  public drawPropertiesType displayDynamicArrowLineDrawing = new drawPropertiesType(Color.Red, 1f, new drawingPattern());
  public drawPropertiesType pointerLineColor = new drawPropertiesType(Color.Red, 2f, new drawingPattern(), (int) byte.MaxValue);
  public bool pointerLineVisible = true;
  public bool pointerArrowVisible = true;
  public drawPropertiesType pointerArrowColor = new drawPropertiesType(Color.Red, 2f, new drawingPattern(), 150);
  public double pointerArrowLength = 20.0;
  public double pointerArrowHeadLength = 5.0;
  public double pointerArrowHeadRadius = 2.5;
  public double pointerArrowBodyRadius = 1.0;
  public int Transperancy = (int) byte.MaxValue;
  public double SmallSizeRatioMoving = 0.0;
  public bool TransperancyOverwrite = true;
  public bool ToolPreviewDrawHolder = true;
  public bool ToolPreviewDrawArbor = true;
  public bool ShowSelectedEntitiesPoint = true;
  public bool ShowSelectedEntitiesMovePoint = true;
  public bool ShowSelectedEntitiesTipPoint = true;

  public setDisplay()
  {
  }

  public setDisplay(setDisplay data)
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
