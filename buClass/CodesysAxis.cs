// Decompiled with JetBrains decompiler
// Type: buClass.CodesysAxis
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buClass;

[Serializable]
public class CodesysAxis : buSerilization
{
  public CodesysAxSets Sets = new CodesysAxSets();
  public CodesysAxMoves Moves = new CodesysAxMoves();
  public CodesysAxJogs Jogs = new CodesysAxJogs();
  public CodesysAxHomings Homings = new CodesysAxHomings();
  public CodesysAxTest Test = new CodesysAxTest();
  public CodesysAxBase Base = new CodesysAxBase();
  public CodesysAxGear Gear = new CodesysAxGear();
  public CodesysAxCnc Cnc = new CodesysAxCnc();
  public CodesysAxMisc MiscSet = new CodesysAxMisc();
  public CodesysAxRuntime Runtime = new CodesysAxRuntime();
  public CodesysAxStrings Strings = new CodesysAxStrings();
  public CodesysAxTemps Temps = new CodesysAxTemps();
  public static List<string> Captions = new List<string>();

  public CodesysAxis()
  {
  }

  public CodesysAxis(CodesysAxis data)
  {
    this.Sets = new CodesysAxSets(data.Sets);
    this.Moves = new CodesysAxMoves(data.Moves);
    this.Jogs = new CodesysAxJogs(data.Jogs);
    this.Test = new CodesysAxTest(data.Test);
    this.Homings = new CodesysAxHomings(data.Homings);
    this.Base = new CodesysAxBase(data.Base);
    this.Gear = new CodesysAxGear(data.Gear);
    this.Cnc = new CodesysAxCnc(data.Cnc);
    this.MiscSet = new CodesysAxMisc(data.MiscSet);
    this.Runtime = new CodesysAxRuntime(data.Runtime);
    this.Strings = new CodesysAxStrings(data.Strings);
    this.Temps = new CodesysAxTemps(data.Temps);
  }

  public static void ConvertFromInchToMm(ref CodesysAxis Data, int Round)
  {
    double num = 25.4;
    if (Data.Base.baseRotaryAxis)
      return;
    Data.Homings.homingOffset = Math.Round(Data.Homings.homingOffset * num, Round);
    Data.Homings.homingSetPosition = Math.Round(Data.Homings.homingSetPosition * num, Round);
    Data.Homings.homingAcc = Math.Round(Data.Homings.homingAcc * num, Round);
    Data.Homings.homingDec = Math.Round(Data.Homings.homingDec * num, Round);
    Data.Homings.homingFastVelocity = Math.Round(Data.Homings.homingFastVelocity * num, Round);
    Data.Homings.homingJerk = Math.Round(Data.Homings.homingJerk * num, Round);
    Data.Homings.homingSlowVelocity = Math.Round(Data.Homings.homingSlowVelocity * num, Round);
    Data.MiscSet.TestPosition1 = Math.Round(Data.MiscSet.TestPosition1 * num, Round);
    Data.MiscSet.TestPosition2 = Math.Round(Data.MiscSet.TestPosition1 * num, Round);
    Data.MiscSet.TestReleativePosition = Math.Round(Data.MiscSet.TestReleativePosition * num, Round);
    Data.Test.testPosition1 = Math.Round(Data.Test.testPosition1 * num, Round);
    Data.Test.testPosition2 = Math.Round(Data.Test.testPosition2 * num, Round);
    Data.Test.testIncrementalPosition = Math.Round(Data.Test.testIncrementalPosition * num, Round);
    Data.Test.testJogVelocity = Math.Round(Data.Test.testJogVelocity * num, Round);
    Data.Test.testMoveVelocity = Math.Round(Data.Test.testMoveVelocity * num, Round);
    Data.Sets.setDataLimitNegative = Math.Round(Data.Sets.setDataLimitNegative * num, Round);
    Data.Sets.setDataLimitPositive = Math.Round(Data.Sets.setDataLimitPositive * num, Round);
    Data.Sets.setParkPosition = Math.Round(Data.Sets.setParkPosition * num, Round);
    Data.Sets.setPositionDoneLimit = Math.Round(Data.Sets.setPositionDoneLimit * num, Round);
    Data.Sets.setSoftLimitErrorMaxDistance = Math.Round(Data.Sets.setSoftLimitErrorMaxDistance * num, Round);
    Data.Sets.setSoftLimitNegative = Math.Round(Data.Sets.setSoftLimitNegative * num, Round);
    Data.Sets.setSoftLimitPositive = Math.Round(Data.Sets.setSoftLimitPositive * num, Round);
    Data.Sets.setUnit = Math.Round(Data.Sets.setUnit * num, Round);
    Data.Sets.setEmergencyDec = Math.Round(Data.Sets.setEmergencyDec * num, Round);
    Data.Sets.setMaxAcc = Math.Round(Data.Sets.setMaxAcc * num, Round);
    Data.Sets.setMaxDec = Math.Round(Data.Sets.setMaxDec * num, Round);
    Data.Sets.setMaxJerk = Math.Round(Data.Sets.setMaxJerk * num, Round);
    Data.Sets.setMaxVelocity = Math.Round(Data.Sets.setMaxVelocity * num, Round);
    Data.Sets.setSoftLimitErrorDec = Math.Round(Data.Sets.setSoftLimitErrorDec * num, Round);
    Data.Moves.moveAcc = Math.Round(Data.Moves.moveAcc * num, Round);
    Data.Moves.moveDec = Math.Round(Data.Moves.moveDec * num, Round);
    Data.Moves.moveJerk = Math.Round(Data.Moves.moveJerk * num, Round);
    Data.Moves.moveVelocity = Math.Round(Data.Moves.moveVelocity * num, Round);
    Data.Jogs.jogAcc = Math.Round(Data.Jogs.jogAcc * num, Round);
    Data.Jogs.jogDec = Math.Round(Data.Jogs.jogDec * num, Round);
    Data.Jogs.jogJerk = Math.Round(Data.Jogs.jogJerk * num, Round);
    Data.Jogs.jogVelocity = Math.Round(Data.Jogs.jogVelocity * num, Round);
    Data.Cnc.cncMaxAccDec = Math.Round(Data.Cnc.cncMaxAccDec * num, Round);
    Data.Cnc.cncMaxDifferance = Math.Round(Data.Cnc.cncMaxDifferance * num, Round);
    Data.Cnc.cncMaxFeed = Math.Round(Data.Cnc.cncMaxFeed * num, Round);
  }

  public static void ConvertFromMmToInch(ref CodesysAxis Data, int Round)
  {
    double num = 5.0 / (double) sbyte.MaxValue;
    if (Data.Base.baseRotaryAxis)
      return;
    Data.Homings.homingOffset = Math.Round(Data.Homings.homingOffset * num, Round);
    Data.Homings.homingSetPosition = Math.Round(Data.Homings.homingSetPosition * num, Round);
    Data.Homings.homingAcc = Math.Round(Data.Homings.homingAcc * num, Round);
    Data.Homings.homingDec = Math.Round(Data.Homings.homingDec * num, Round);
    Data.Homings.homingFastVelocity = Math.Round(Data.Homings.homingFastVelocity * num, Round);
    Data.Homings.homingJerk = Math.Round(Data.Homings.homingJerk * num, Round);
    Data.Homings.homingSlowVelocity = Math.Round(Data.Homings.homingSlowVelocity * num, Round);
    Data.MiscSet.TestPosition1 = Math.Round(Data.MiscSet.TestPosition1 * num, Round);
    Data.MiscSet.TestPosition2 = Math.Round(Data.MiscSet.TestPosition1 * num, Round);
    Data.MiscSet.TestReleativePosition = Math.Round(Data.MiscSet.TestReleativePosition * num, Round);
    Data.Test.testPosition1 = Math.Round(Data.Test.testPosition1 * num, Round);
    Data.Test.testPosition2 = Math.Round(Data.Test.testPosition2 * num, Round);
    Data.Test.testIncrementalPosition = Math.Round(Data.Test.testIncrementalPosition * num, Round);
    Data.Test.testJogVelocity = Math.Round(Data.Test.testJogVelocity * num, Round);
    Data.Test.testMoveVelocity = Math.Round(Data.Test.testMoveVelocity * num, Round);
    Data.Sets.setDataLimitNegative = Math.Round(Data.Sets.setDataLimitNegative * num, Round);
    Data.Sets.setDataLimitPositive = Math.Round(Data.Sets.setDataLimitPositive * num, Round);
    Data.Sets.setParkPosition = Math.Round(Data.Sets.setParkPosition * num, Round);
    Data.Sets.setPositionDoneLimit = Math.Round(Data.Sets.setPositionDoneLimit * num, Round);
    Data.Sets.setSoftLimitErrorMaxDistance = Math.Round(Data.Sets.setSoftLimitErrorMaxDistance * num, Round);
    Data.Sets.setSoftLimitNegative = Math.Round(Data.Sets.setSoftLimitNegative * num, Round);
    Data.Sets.setSoftLimitPositive = Math.Round(Data.Sets.setSoftLimitPositive * num, Round);
    Data.Sets.setUnit = Math.Round(Data.Sets.setUnit * num, Round);
    Data.Sets.setEmergencyDec = Math.Round(Data.Sets.setEmergencyDec * num, Round);
    Data.Sets.setMaxAcc = Math.Round(Data.Sets.setMaxAcc * num, Round);
    Data.Sets.setMaxDec = Math.Round(Data.Sets.setMaxDec * num, Round);
    Data.Sets.setMaxJerk = Math.Round(Data.Sets.setMaxJerk * num, Round);
    Data.Sets.setMaxVelocity = Math.Round(Data.Sets.setMaxVelocity * num, Round);
    Data.Sets.setSoftLimitErrorDec = Math.Round(Data.Sets.setSoftLimitErrorDec * num, Round);
    Data.Moves.moveAcc = Math.Round(Data.Moves.moveAcc * num, Round);
    Data.Moves.moveDec = Math.Round(Data.Moves.moveDec * num, Round);
    Data.Moves.moveJerk = Math.Round(Data.Moves.moveJerk * num, Round);
    Data.Moves.moveVelocity = Math.Round(Data.Moves.moveVelocity * num, Round);
    Data.Jogs.jogAcc = Math.Round(Data.Jogs.jogAcc * num, Round);
    Data.Jogs.jogDec = Math.Round(Data.Jogs.jogDec * num, Round);
    Data.Jogs.jogJerk = Math.Round(Data.Jogs.jogJerk * num, Round);
    Data.Jogs.jogVelocity = Math.Round(Data.Jogs.jogVelocity * num, Round);
    Data.Cnc.cncMaxAccDec = Math.Round(Data.Cnc.cncMaxAccDec * num, Round);
    Data.Cnc.cncMaxDifferance = Math.Round(Data.Cnc.cncMaxDifferance * num, Round);
    Data.Cnc.cncMaxFeed = Math.Round(Data.Cnc.cncMaxFeed * num, Round);
  }
}
