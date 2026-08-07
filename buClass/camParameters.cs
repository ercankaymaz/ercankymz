// Decompiled with JetBrains decompiler
// Type: buClass.camParameters
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;

#nullable disable
namespace buClass;

[Serializable]
public class camParameters : buSerilization
{
  public camOptions Options = new camOptions();
  public camOperation Operations = new camOperation();
  public camDistances Distances = new camDistances();
  public camStep Steps = new camStep();
  public camSpeeds Speeds = new camSpeeds();
  public camOffset Offsets = new camOffset();
  public camPocket Pockets = new camPocket();
  public camStrategy Strategy = new camStrategy();
  public camHole Hole = new camHole();
  public camMaterial Material = new camMaterial();
  public LeadIn LeadIn = new LeadIn();
  public LeadOut LeadOut = new LeadOut();
  public camHatch Hatch = new camHatch();
  public camDrill Drill = new camDrill();

  public camParameters()
  {
  }

  public camParameters(
    camDistances distance,
    camSpeeds speeds,
    camStep steps,
    camOffset offsets,
    camOperation operations,
    camOptions options,
    camStrategy strategy,
    camPocket pocket,
    LeadIn leadin,
    LeadOut leadout,
    camHole hole,
    camMaterial material,
    camHatch hatch)
  {
    this.Distances = new camDistances(distance);
    this.Speeds = new camSpeeds(speeds);
    this.Steps = new camStep(steps);
    this.Offsets = new camOffset(offsets);
    this.Operations = new camOperation(operations);
    this.Options = new camOptions(options);
    this.Strategy = new camStrategy(strategy);
    this.Pockets = new camPocket(pocket);
    this.LeadOut = new LeadOut(leadout);
    this.LeadIn = new LeadIn(leadin);
    this.Hole = new camHole(hole);
    this.Material = new camMaterial(material);
    this.Hatch = new camHatch(hatch);
  }

  public camParameters(camParameters parameters)
  {
    this.Distances = new camDistances(parameters.Distances);
    this.Options = new camOptions(parameters.Options);
    this.Operations = new camOperation(parameters.Operations);
    this.Steps = new camStep(parameters.Steps);
    this.Speeds = new camSpeeds(parameters.Speeds);
    this.Offsets = new camOffset(parameters.Offsets);
    this.Pockets = new camPocket(parameters.Pockets);
    this.Strategy = new camStrategy(parameters.Strategy);
    this.LeadIn = new LeadIn(parameters.LeadIn);
    this.LeadOut = new LeadOut(parameters.LeadOut);
    this.Hole = new camHole(parameters.Hole);
    this.Material = new camMaterial(parameters.Material);
    this.Hatch = new camHatch(parameters.Hatch);
    this.Drill = new camDrill(parameters.Drill);
  }

  public static void Copy(
    camParameters parameters,
    ref camDistances distance,
    ref camSpeeds speeds,
    ref camStep steps,
    ref camOffset offsets,
    ref camOperation operations,
    ref camOptions options,
    ref camStrategy strategy,
    ref camPocket pocket,
    ref LeadIn leadin,
    ref LeadOut leadout,
    ref camHole hole,
    ref camHatch hatch)
  {
    distance = new camDistances(parameters.Distances);
    options = new camOptions(parameters.Options);
    operations = new camOperation(parameters.Operations);
    steps = new camStep(parameters.Steps);
    speeds = new camSpeeds(parameters.Speeds);
    offsets = new camOffset(parameters.Offsets);
    pocket = new camPocket(parameters.Pockets);
    strategy = new camStrategy(parameters.Strategy);
    leadin = new LeadIn(parameters.LeadIn);
    leadout = new LeadOut(parameters.LeadOut);
    hole = new camHole(parameters.Hole);
    hatch = new camHatch(parameters.Hatch);
  }

  public static void Decode(ArrayList AL, string Char, ref camParameters Par)
  {
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Distances);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Operations);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.LeadIn);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.LeadOut);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Offsets);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Steps);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Speeds);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Options);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Strategy);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Pockets);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Hole);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.Hatch);
  }

  public static void ToDef(
    camParameters Par,
    ref ArrayList AL,
    string Char,
    int Space,
    SerilizationMode DefMode)
  {
    AL.AddRange((ICollection) Par.Distances.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Operations.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.LeadIn.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.LeadOut.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Offsets.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Steps.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Speeds.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Options.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Strategy.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Pockets.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Hole.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.Hatch.ToDefAll(Char, Space, SerilizationMode.MultiLine));
  }
}
