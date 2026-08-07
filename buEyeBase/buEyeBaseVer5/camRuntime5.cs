// Decompiled with JetBrains decompiler
// Type: buEyeBaseVer5.camRuntime5
// Assembly: buEyeBase, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: B5B7A040-6595-420F-97D2-D0DA226BD1F1
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buEyeBase.dll

using System;

#nullable disable
namespace buEyeBaseVer5;

[Serializable]
public class camRuntime5 : buSerilization5
{
  public camHole5 Hole;
  public camMaterial5 Material;
  public LeadIn5 LeadIn;

  public camRuntime5(
    camDistances5 distance,
    camSpeeds5 speeds,
    camStep5 steps,
    camOffset5 offsets,
    camOperation5 operations,
    camOptions5 options,
    camStrategy5 strategy,
    camPocket5 pocket,
    LeadIn5 leadin,
    LeadOut5 leadout,
    camHole5 hole,
    camMaterial5 material,
    camHatch5 hatch,
    camRotary5 rotary)
  {
    ((camParameters5) this).Options = (camOptions5) new camHatch5();
    ((camParameters5) this).Operations = (camOperation5) new camRotary5();
    ((camParameters5) this).Distances = (camDistances5) new camMaterial5();
    ((camParameters5) this).Steps = (camStep5) new camSpeedsEnable();
    ((camParameters5) this).Speeds = (camSpeeds5) new camDistances5();
    ((camParameters5) this).Offsets = (camOffset5) new camSpeeds5();
    ((camParameters5) this).Pockets = (camPocket5) new camOptions5();
    ((camParameters5) this).Strategy = (camStrategy5) new LeadIn5();
    ((camParameters5) this).Rotary = (camRotary5) new camStrategy5();
    this.Hole = (camHole5) new camDrill5();
    this.Material = (camMaterial5) new camPocket5();
    this.LeadIn = (LeadIn5) new camResult();
    ((camOffset5) this).LeadOut = (LeadOut5) new CamEntitiesToGEntities();
    ((camOffset5) this).Hatch = (camHatch5) new camNotch5();
    ((camOffset5) this).Drill = (camDrill5) new camOperation5();
    ((camOffset5) this).Notch = (camNotch5) new LeadOut5();
    ((camOffset5) this).Runtime = (camRuntime5) new camStep5();
    ((camOffset5) this).Sorting = (SortSettings) new ShapeRuntimeData();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    ((camParameters5) this).Distances = (camDistances5) new camDrill5(distance);
    ((camParameters5) this).Speeds = (camSpeeds5) new camDistances5(speeds);
    ((camParameters5) this).Steps = (camStep5) new camSpeedsEnable(steps);
    ((camParameters5) this).Offsets = (camOffset5) new camSpeeds5(offsets);
    ((camParameters5) this).Operations = (camOperation5) new camHatch5(operations);
    ((camParameters5) this).Options = (camOptions5) new camStrategy5(options);
    ((camParameters5) this).Strategy = (camStrategy5) new LeadIn5(strategy);
    ((camParameters5) this).Pockets = (camPocket5) new camOptions5(pocket);
    ((camOffset5) this).LeadOut = (LeadOut5) new CamEntitiesToEntitiesOption(leadout);
    this.LeadIn = (LeadIn5) new CamEntitiesToEntities(leadin);
    this.Hole = (camHole5) new camPocket5(hole);
    this.Material = (camMaterial5) new camOperation5(material);
    ((camOffset5) this).Hatch = (camHatch5) new LeadIn5(hatch);
    ((camParameters5) this).Rotary = (camRotary5) new camStrategy5(rotary);
  }

  public camRuntime5(camParameters5 parameters)
  {
    ((camParameters5) this).Options = (camOptions5) new camHatch5();
    ((camParameters5) this).Operations = (camOperation5) new camRotary5();
    ((camParameters5) this).Distances = (camDistances5) new camMaterial5();
    ((camParameters5) this).Steps = (camStep5) new camSpeedsEnable();
    ((camParameters5) this).Speeds = (camSpeeds5) new camDistances5();
    ((camParameters5) this).Offsets = (camOffset5) new camSpeeds5();
    ((camParameters5) this).Pockets = (camPocket5) new camOptions5();
    ((camParameters5) this).Strategy = (camStrategy5) new LeadIn5();
    ((camParameters5) this).Rotary = (camRotary5) new camStrategy5();
    this.Hole = (camHole5) new camDrill5();
    this.Material = (camMaterial5) new camPocket5();
    this.LeadIn = (LeadIn5) new camResult();
    ((camOffset5) this).LeadOut = (LeadOut5) new CamEntitiesToGEntities();
    ((camOffset5) this).Hatch = (camHatch5) new camNotch5();
    ((camOffset5) this).Drill = (camDrill5) new camOperation5();
    ((camOffset5) this).Notch = (camNotch5) new LeadOut5();
    ((camOffset5) this).Runtime = (camRuntime5) new camStep5();
    ((camOffset5) this).Sorting = (SortSettings) new ShapeRuntimeData();
    // ISSUE: explicit constructor call
    ((pageInfo) this).\u002Ector();
    if (parameters == null)
      return;
    ((camParameters5) this).Distances = (camDistances5) new camDrill5(parameters.Distances);
    ((camParameters5) this).Options = (camOptions5) new camStrategy5(parameters.Options);
    ((camParameters5) this).Operations = (camOperation5) new camHatch5(parameters.Operations);
    ((camParameters5) this).Steps = (camStep5) new camSpeedsEnable(parameters.Steps);
    ((camParameters5) this).Speeds = (camSpeeds5) new camDistances5(parameters.Speeds);
    ((camParameters5) this).Offsets = (camOffset5) new camSpeeds5(parameters.Offsets);
    ((camParameters5) this).Pockets = (camPocket5) new camOptions5(parameters.Pockets);
    ((camParameters5) this).Strategy = (camStrategy5) new LeadIn5(parameters.Strategy);
    this.LeadIn = (LeadIn5) new CamEntitiesToEntities(((camRuntime5) parameters).LeadIn);
    ((camOffset5) this).LeadOut = (LeadOut5) new CamEntitiesToEntitiesOption(((camOffset5) parameters).LeadOut);
    this.Hole = (camHole5) new camPocket5(((camRuntime5) parameters).Hole);
    this.Material = (camMaterial5) new camOperation5(((camRuntime5) parameters).Material);
    ((camOffset5) this).Hatch = (camHatch5) new LeadIn5(((camOffset5) parameters).Hatch);
    ((camOffset5) this).Drill = (camDrill5) new camOperation5(((camOffset5) parameters).Drill);
    ((camOffset5) this).Sorting = (SortSettings) new ShapeRuntimeData(((camOffset5) parameters).Sorting);
    ((camOffset5) this).Runtime = (camRuntime5) new camStep5(((camOffset5) parameters).Runtime);
    ((camOffset5) this).Notch = (camNotch5) new LeadOut5(((camOffset5) parameters).Notch);
    ((camParameters5) this).Rotary = (camRotary5) new camStrategy5(parameters.Rotary);
  }

  public static void Copy(
    camParameters5 parameters,
    ref camDistances5 distance,
    ref camSpeeds5 speeds,
    ref camStep5 steps,
    ref camOffset5 offsets,
    ref camOperation5 operations,
    ref camOptions5 options,
    ref camStrategy5 strategy,
    ref camPocket5 pocket,
    ref LeadIn5 leadin,
    ref LeadOut5 leadout,
    ref camHole5 hole,
    ref camHatch5 hatch,
    ref camRotary5 rotary)
  {
    distance = (camDistances5) new camDrill5(parameters.Distances);
    options = (camOptions5) new camStrategy5(parameters.Options);
    operations = (camOperation5) new camHatch5(parameters.Operations);
    steps = (camStep5) new camSpeedsEnable(parameters.Steps);
    speeds = (camSpeeds5) new camDistances5(parameters.Speeds);
    offsets = (camOffset5) new camSpeeds5(parameters.Offsets);
    pocket = (camPocket5) new camOptions5(parameters.Pockets);
    strategy = (camStrategy5) new LeadIn5(parameters.Strategy);
    leadin = (LeadIn5) new CamEntitiesToEntities(((camRuntime5) parameters).LeadIn);
    leadout = (LeadOut5) new CamEntitiesToEntitiesOption(((camOffset5) parameters).LeadOut);
    hole = (camHole5) new camPocket5(((camRuntime5) parameters).Hole);
    hatch = (camHatch5) new LeadIn5(((camOffset5) parameters).Hatch);
    rotary = (camRotary5) new camStrategy5(parameters.Rotary);
  }
}
