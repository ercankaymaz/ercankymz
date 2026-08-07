// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Apps.SewingSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Apps;

[Serializable]
public class SewingSettings : buSerilization5
{
  public static CollisionDetection _cd;
  public static readonly List<Entity> collidedEntities;
  public static int doneZSteps;
  public static int _entityCollisionIndex;
  public static double _excecutionPipe;
  public static readonly bool _firstOnly;
  public static int _numOfFileBlocks;
  public static int _numOfFileEntities;
  public static int NumberOfSim;
  public static Color _pipeColor;
  public static double _pipeDiameter;
  public static int _pipeRowQuantity;
  public static double _pipeTotalLength;
  public Brep _rev1;
  public static readonly Vector3D _machineTranslation;
  public static double _machineScalingFactor;
  public static int[] machineCollisionEntities;
  public static readonly Color collisionColor;
  public static readonly Color collisionColor2;
  public static Dictionary<Entity, Color> originalColors;
  public static readonly Stopwatch _sw;
  public static int _straightPartCounter;
  public static readonly List<Entity> _surfList;
  public string LayerGeneral;
  public string LayerFoam;
  public string Layer3DPattern;
  public string LayerWirePattern;
  public string LayerSelection;
  public string LayerMark;
  public string LayerDefault;
  public static byte f003CA7;
  [SpecialName]
  public int value__;
  public const PipeBendMoveCommand None = ; // Unable to render the field
  public static List<string> LangWoodStatus;
  public static List<string> LangWoodMessage;
  public static List<string> LangWoodCaptions;
  public static List<string> LangWoodCommands;
  public static WoodTempVars varTemps;
  public static WoodSettings varWoodSettings;
  public static WoodRuntimeSettings varWoodRunSettings;
  public static byte f003CB1;
  public string Name;
  public List<buShape> Items;

  public SewingSettings()
  {
    ((FoamRuntimeSettings) this).layerPanel = "Panel";
    ((FoamRuntimeSettings) this).layerOperation = "Operation";
    ((FoamRuntimeSettings) this).layerGeneral = "General";
    ((FoamRuntimeSettings) this).layerSelected = "Selected";
    ((FoamRuntimeSettings) this).layerCam = "Cam";
    ((FoamRuntimeSettings) this).lastShape = (buShape) null;
    ((FoamCalcVars) this).ViewportRef = ViewportRefType.Main;
    ((FoamCalcVars) this).activePlane = planeBoxNames.Top;
    ((FoamCalcVars) this).selectedDoorIndex = -1;
    ((FoamCalcVars) this).selectedItemIndex = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
  }

  public SewingSettings(DoorTempVars data)
  {
    ((FoamRuntimeSettings) this).layerPanel = "Panel";
    ((FoamRuntimeSettings) this).layerOperation = "Operation";
    ((FoamRuntimeSettings) this).layerGeneral = "General";
    ((FoamRuntimeSettings) this).layerSelected = "Selected";
    ((FoamRuntimeSettings) this).layerCam = "Cam";
    ((FoamRuntimeSettings) this).lastShape = (buShape) null;
    ((FoamCalcVars) this).ViewportRef = ViewportRefType.Main;
    ((FoamCalcVars) this).activePlane = planeBoxNames.Top;
    ((FoamCalcVars) this).selectedDoorIndex = -1;
    ((FoamCalcVars) this).selectedItemIndex = -1;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    object CopiedClass = new object();
    buSerilization.CopyClass((object) data, ref CopiedClass);
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
}
