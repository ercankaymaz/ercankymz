// Decompiled with JetBrains decompiler
// Type: buClass.camParametersEnable
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections;

#nullable disable
namespace buClass;

[Serializable]
public class camParametersEnable : buSerilization
{
  public camOptionsEnable OptionsEnable = new camOptionsEnable();
  public camOperationEnable OperationsEnable = new camOperationEnable();
  public camDistanceEnable DistancesEnable = new camDistanceEnable();
  public camStepEnable StepsEnable = new camStepEnable();
  public camSpeedsEnable SpeedsEnable = new camSpeedsEnable();
  public camOffsetEnable OffsetsEnable = new camOffsetEnable();
  public camPocketEnable PocketsEnable = new camPocketEnable();
  public LeadInOutEnable LeadInOutEnable = new LeadInOutEnable();

  public camParametersEnable()
  {
  }

  public camParametersEnable(
    camOptionsEnable optionenable,
    camOperationEnable operationenable,
    camDistanceEnable distanceenable,
    camStepEnable stepenable,
    camSpeedsEnable speedenable,
    camOffsetEnable offsetenable,
    camPocketEnable pocketenable,
    LeadInOutEnable leadinoutenable)
  {
    this.OptionsEnable = new camOptionsEnable(optionenable);
    this.OperationsEnable = new camOperationEnable(operationenable);
    this.DistancesEnable = new camDistanceEnable(distanceenable);
    this.StepsEnable = new camStepEnable(stepenable);
    this.SpeedsEnable = new camSpeedsEnable(speedenable);
    this.OffsetsEnable = new camOffsetEnable(offsetenable);
    this.PocketsEnable = new camPocketEnable(pocketenable);
    this.LeadInOutEnable = new LeadInOutEnable(leadinoutenable);
  }

  public camParametersEnable(camParametersEnable parameters)
  {
    this.DistancesEnable = new camDistanceEnable(parameters.DistancesEnable);
    this.LeadInOutEnable = new LeadInOutEnable(parameters.LeadInOutEnable);
    this.OffsetsEnable = new camOffsetEnable(parameters.OffsetsEnable);
    this.OperationsEnable = new camOperationEnable(parameters.OperationsEnable);
    this.OptionsEnable = new camOptionsEnable(parameters.OptionsEnable);
    this.PocketsEnable = new camPocketEnable(parameters.PocketsEnable);
    this.SpeedsEnable = new camSpeedsEnable(parameters.SpeedsEnable);
    this.StepsEnable = new camStepEnable(parameters.StepsEnable);
  }

  public static void Decode(ArrayList AL, string Char, ref camParametersEnable Par)
  {
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.DistancesEnable);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.LeadInOutEnable);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.OffsetsEnable);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.OperationsEnable);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.OptionsEnable);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.PocketsEnable);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.SpeedsEnable);
    buSerilization.Decode(AL, Char, SerilizationMode.MultiLine, (object) Par.StepsEnable);
  }

  public static void ToDef(
    camParametersEnable Par,
    ref ArrayList AL,
    string Char,
    int Space,
    SerilizationMode DefMode)
  {
    AL.AddRange((ICollection) Par.DistancesEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.LeadInOutEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.OffsetsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.OperationsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.OptionsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.PocketsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.SpeedsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
    AL.AddRange((ICollection) Par.StepsEnable.ToDefAll(Char, Space, SerilizationMode.MultiLine));
  }
}
