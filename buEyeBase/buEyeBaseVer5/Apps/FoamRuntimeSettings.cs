// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.FoamRuntimeSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamRuntimeSettings : buSerilization5
{
  public bool DrawAll;
  public bool DeleteStock;
  public bool DeleteTool;
  public bool DeletePlane;
  public bool DrawPreview;
  public bool DrawAll;
  public bool CamCreate;
  public int SelectedSheet;
  [SpecialName]
  public int value__;
  public const MachineTableType SingleTable = ; // Unable to render the field
  public const MachineTableType OnlyA = ; // Unable to render the field
  public const MachineTableType OnlyB = ; // Unable to render the field
  public const MachineTableType TableAThenB = ; // Unable to render the field
  public static List<string> LangDoorStatus;
  public static List<string> LangDoorMessage;
  public static List<string> LangDoorCaptions;
  public static List<string> LangDoorCommands;
  public static DoorTempVars varTemps;
  public static DoorSettings varDoorSettings;
  public static DoorRuntimeSettings varDoorRunSettings;
  public static byte f003BEC;
  public string Name;
  public string GCode;
  public List<buShape> Items;
  public List<string> Codes;
  public List<camTp> Cams;
  public List<string> ErrorCodes;
  public MaterialBase5 Material;
  public int TotalCount;
  public int Used;
  public bool isSorted;
  public Entity panelEntity;
  public Entity panelEntity2;
  public static byte f003BF9;
  public bool ShowOperationButton;
  public double ZDownOneTimeLimit;
  public bool GoFirstXYZSameTime;
  public Color colorPanel;
  public Color colorOperation;
  public Color colorOperationDisable;
  public bool UseAngles;
  public bool SelectMode;
  public bool FromFileKeepRatio;
  public string pathFromFile;
  public string pathJob;
  public double MaterialHeight;
  public double MaterialWidth;
  public double MaterialDepth;
  public double Case1Width;
  public double Case1Height;
  public double Case1Depth;
  public double Case2Width;
  public double Case2Height;
  public double Case2Depth;
  public double CaseSpace;
  public double MaterialFrontAngle;
  public double MaterialBackAngle;
  public int SecondToolNo;
  public bool SecondToolEnable;
  public MaterialPurpose MaterailPurpuse;
  public ShapeRuntimeData ShapeDataParameters;
  public static byte f003C15;
  public string layerPanel;
  public string layerOperation;
  public string layerGeneral;
  public string layerSelected;
  public string layerCam;
  public buShape lastShape;

  public FoamRuntimeSettings(Router3AXItem data)
  {
    ((FoamCreatePanelOptions) this).ItemName = "Job";
    ((FoamCreatePanelOptions) this).FileName = "";
    ((FoamEntities) this).FileNameFull = "";
    ((FoamSortGroup) this).Index = -1;
    ((FoamSortGroup) this).isError = false;
    ((FoamSortGroup) this).isGCodeCreated = false;
    ((FoamSortGroup) this).CreatedFromDrawing = false;
    ((FoamSortGroup) this).Material = (MaterialBase5) new ShapeLeadInOut();
    ((FoamActiveBlock) this).TextureName = "";
    ((FoamActiveBlock) this).colorFoam = Color.DarkGray;
    ((FoamActiveBlock) this).Transparency = 120;
    ((FoamSpeeds) this).MinPoint = new Point3D();
    ((FoamSpeeds) this).MaxPoint = new Point3D();
    ((FoamSpeeds) this).Stock = (CamStock) null;
    ((FoamSpeeds) this).GCodeResult = (MachineGCodeExecutionResult) null;
    ((FoamSpeeds) this).CamList = new List<Router3AXCAM>();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    object CopiedClass = new object();
    buSerilization5.CopyClass((object) data, ref CopiedClass);
    if (this != null & CopiedClass != null && this.GetType() == CopiedClass.GetType())
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
    if (((FoamSpeeds) data).GCodeResult != null)
      ((FoamSpeeds) this).GCodeResult = (MachineGCodeExecutionResult) new F_Scale(((FoamSpeeds) data).GCodeResult);
    if (((FoamSpeeds) data).Stock != null)
    {
      ((FoamSpeeds) this).Stock = (CamStock) new ToolBase5();
      ((FoamSpeeds) this).Stock = (CamStock) new ToolBase5(((FoamSpeeds) data).Stock);
    }
    for (int index = 0; index <= ((FoamSpeeds) data).CamList.Count - 1; ++index)
      ((FoamSpeeds) this).CamList.Add((Router3AXCAM) new FoamTempVars(((FoamSpeeds) data).CamList[index]));
  }

  public static ArrayList ToDef(FoamItem refItem, int Space) => new ArrayList();
}
