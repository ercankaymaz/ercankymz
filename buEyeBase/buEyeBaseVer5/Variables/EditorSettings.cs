// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.Variables.EditorSettings
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using buClass;
using buEyeBaseVer5.buEntities;
using buEyeBaseVer5.Forms;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

#nullable disable
namespace buEyeBaseVer5.Variables;

[Serializable]
public class EditorSettings : buSerilization5
{
  public List<LayerBase5> FoundLayers;
  internal Cf2FileProperties FoundBridgeProperties;
  public static byte f0009B1;
  public GCodeChars Chars;
  public GCodeSetting5 Settings;
  public GCodeResult5 Result;
  public AxesEnableWithUVW DecodeAxes;
  public List<buEntity> EntitiesG1;
  public List<buEntity> EntitiesG0;
  public List<buEntity> EntitiesPlunge;
  public List<buEntity> EntitiesLeave;
  public List<Entity> Entitiesolid;
  public List<string> GCodeLines;
  public List<GCodePoint5> Coordinates;
  public Pnt9D MaxCoordinates;
  public Pnt9D MinCoordinates;
  public List<buFile5.GCodeAssingmentArgs> Assingment;
  public static byte f0009C0;
  public string Base;
  public string Change;
  public static byte f0009C3;
  public double Devider;
  public static byte f0009C5;
  public static byte f0009C6;
  public static byte f0009C7;
  public static readonly buFile5.\u003C\u003Ec \u003C\u003E9;
  public static Func<string, string> \u003C\u003E9__17_0;
  public string \u0001;
  public string \u0001;
  public int \u0001;
  public AsyncTaskMethodBuilder<ReadFileAsync> \u0001;
  public Design \u0001;
  public string \u0001;
  public buFile5 \u0001;
  private ReadFileAsync \u0001;
  private BlockReference \u0001;
  private TaskAwaiter \u0001;
  public int \u0001;
  public AsyncVoidMethodBuilder \u0001;
  public Design \u0001;
  public string \u0001;
  public buFile5 \u0001;

  public bool GetLayerPropertiesFromName(
    List<LayerBase5> Layers,
    string LayerName,
    ref LayerProperties Props)
  {
    // ISSUE: variable of a compiler-generated type
    buVector5.\u0001 obj = (buVector5.\u0001) new F_Move();
    ((F_CutterMachineSettings) obj).\u0001 = LayerName;
    int index = Layers.FindIndex(new Predicate<LayerBase5>(((F_Move) obj).\u0001));
    bool propertiesFromName;
    if (index >= 0)
    {
      Props.Color = ((DevideEventFormVars) Layers[index]).LayerColor;
      Props.Thickness = (double) ((DevideEventFormVars) Layers[index]).LayerThickness;
      Props.isLock = ((ScaleEventFormVars) Layers[index]).Lock;
      Props.isVisible = ((ScaleEventFormVars) Layers[index]).Enable;
      propertiesFromName = true;
    }
    else
      propertiesFromName = false;
    return propertiesFromName;
  }

  public bool GetLayerFromName(List<LayerBase5> Layers, string LayerName, ref LayerBase5 Layer)
  {
    // ISSUE: variable of a compiler-generated type
    buVector5.\u0002 obj = (buVector5.\u0002) new F_Move();
    ((F_CutterMachineSettings) obj).\u0001 = LayerName;
    int index = Layers.FindIndex(new Predicate<LayerBase5>(((F_Move) obj).\u0001));
    bool layerFromName;
    if (index >= 0)
    {
      Layer = (LayerBase5) new EditorCustomData(Layers[index]);
      layerFromName = true;
    }
    else
      layerFromName = false;
    return layerFromName;
  }
}
