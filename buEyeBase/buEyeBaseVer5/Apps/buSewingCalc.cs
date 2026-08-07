// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.buSewingCalc
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

#nullable disable
namespace buEyeBaseVer5.Apps;

public class buSewingCalc
{
  public bool MovePipe;
  public int IndexMove;
  public int RowIndex;
  public PipeBendMoveCommand Command;
  public static byte f003C60;
  public double Diameter;

  public abstract void m001ADA();

  public buSewingCalc()
  {
    ((FoamSettings) this).colorStock = (ColorType) new CircularSpeedReduction(Color.BurlyWood, 150);
    ((FoamSettings) this).colorPlaneTop = (ColorType) new CircularSpeedReduction(Color.DarkOrange, 180);
    ((FoamSettings) this).colorPlaneBottom = (ColorType) new CircularSpeedReduction(Color.LightBlue, 180);
    ((FoamSettings) this).colorPlaneClearance = (ColorType) new CircularSpeedReduction(Color.MediumVioletRed, 180);
    ((FoamSettings) this).colorPlaneRetract = (ColorType) new CircularSpeedReduction(Color.ForestGreen, 180);
    ((FoamSettings) this).colorPlaneText = (ColorType) new CircularSpeedReduction(Color.Black, 200);
    ((FoamSettings) this).colorCamBase = (ColorDrawType) new EdgeFoundArgs(Color.Black, (int) byte.MaxValue, 1.0);
    ((FoamSettings) this).colorCamG1 = (ColorDrawType) new EdgeFoundArgs(Color.Red, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamG0 = (ColorDrawType) new EdgeFoundArgs(Color.Blue, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamPlunge = (ColorDrawType) new EdgeFoundArgs(Color.Lime, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamLeave = (ColorDrawType) new EdgeFoundArgs(Color.Cyan, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamLeadIn = (ColorDrawType) new EdgeFoundArgs(Color.Purple, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamLeadOut = (ColorDrawType) new EdgeFoundArgs(Color.Purple, (int) byte.MaxValue, 2.0);
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buSewingCalc(Router3AXDisplaySettings data)
  {
    ((FoamSettings) this).colorStock = (ColorType) new CircularSpeedReduction(Color.BurlyWood, 150);
    ((FoamSettings) this).colorPlaneTop = (ColorType) new CircularSpeedReduction(Color.DarkOrange, 180);
    ((FoamSettings) this).colorPlaneBottom = (ColorType) new CircularSpeedReduction(Color.LightBlue, 180);
    ((FoamSettings) this).colorPlaneClearance = (ColorType) new CircularSpeedReduction(Color.MediumVioletRed, 180);
    ((FoamSettings) this).colorPlaneRetract = (ColorType) new CircularSpeedReduction(Color.ForestGreen, 180);
    ((FoamSettings) this).colorPlaneText = (ColorType) new CircularSpeedReduction(Color.Black, 200);
    ((FoamSettings) this).colorCamBase = (ColorDrawType) new EdgeFoundArgs(Color.Black, (int) byte.MaxValue, 1.0);
    ((FoamSettings) this).colorCamG1 = (ColorDrawType) new EdgeFoundArgs(Color.Red, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamG0 = (ColorDrawType) new EdgeFoundArgs(Color.Blue, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamPlunge = (ColorDrawType) new EdgeFoundArgs(Color.Lime, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamLeave = (ColorDrawType) new EdgeFoundArgs(Color.Cyan, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamLeadIn = (ColorDrawType) new EdgeFoundArgs(Color.Purple, (int) byte.MaxValue, 2.0);
    ((FoamSettings) this).colorCamLeadOut = (ColorDrawType) new EdgeFoundArgs(Color.Purple, (int) byte.MaxValue, 2.0);
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

  public buSewingCalc()
  {
    ((FoamSettings) this).SelectMode = false;
    ((FoamSettings) this).FromFileKeepRatio = true;
    ((FoamSettings) this).pathFromFile = "C:\\";
    ((FoamSettings) this).MaterialHeight = 800.0;
    ((FoamSettings) this).MaterialWidth = 2000.0;
    ((FoamSettings) this).MaterialDepth = 20.0;
    ((FoamSettings) this).SimStep = 1;
    ((FoamSettings) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands();
    ((FoamSettings) this).SequenceList = new List<string>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buSewingCalc(Router3AXRuntimeSettings data)
  {
    ((FoamSettings) this).SelectMode = false;
    ((FoamSettings) this).FromFileKeepRatio = true;
    ((FoamSettings) this).pathFromFile = "C:\\";
    ((FoamSettings) this).MaterialHeight = 800.0;
    ((FoamSettings) this).MaterialWidth = 2000.0;
    ((FoamSettings) this).MaterialDepth = 20.0;
    ((FoamSettings) this).SimStep = 1;
    ((FoamSettings) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands();
    ((FoamSettings) this).SequenceList = new List<string>();
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
    ((FoamSettings) this).ShapeDataParameters = (ShapeRuntimeData) new hmiUICommands(((FoamSettings) data).ShapeDataParameters);
  }

  public abstract void m001ADF();

  public buSewingCalc()
  {
    ((FoamSettings) this).layerPanel = "Panel";
    ((FoamSettings) this).layerOperation = "Operation";
    ((FoamSettings) this).layerGeneral = "General";
    ((FoamSettings) this).layerSelected = "Selected";
    ((FoamSettings) this).layerCam = "Cam";
    ((FoamSettings) this).layerCamPlane = "CamPlane";
    ((FoamSettings) this).layerWireframe = "Wireframe";
    ((FoamSettings) this).layerSheet = "Sheet";
    ((FoamSettings) this).layerPart = "Part";
    ((FoamSettings) this).layerSolid = "Solid";
    ((FoamSettings) this).ViewportRef = ViewportRefType.Main;
    ((FoamSettings) this).activePlane = planeBoxNames.Top;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }

  public buSewingCalc(Router3AXTempVars data)
  {
    ((FoamSettings) this).layerPanel = "Panel";
    ((FoamSettings) this).layerOperation = "Operation";
    ((FoamSettings) this).layerGeneral = "General";
    ((FoamSettings) this).layerSelected = "Selected";
    ((FoamSettings) this).layerCam = "Cam";
    ((FoamSettings) this).layerCamPlane = "CamPlane";
    ((FoamSettings) this).layerWireframe = "Wireframe";
    ((FoamSettings) this).layerSheet = "Sheet";
    ((FoamSettings) this).layerPart = "Part";
    ((FoamSettings) this).layerSolid = "Solid";
    ((FoamSettings) this).ViewportRef = ViewportRefType.Main;
    ((FoamSettings) this).activePlane = planeBoxNames.Top;
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

  public abstract void m001AE2();

  public buSewingCalc()
  {
    ((FoamRuntimeSettings) this).DrawAll = false;
    ((FoamRuntimeSettings) this).DeleteStock = false;
    ((FoamRuntimeSettings) this).DeleteTool = false;
    ((FoamRuntimeSettings) this).DeletePlane = false;
    ((FoamRuntimeSettings) this).DrawPreview = false;
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
  }
}
