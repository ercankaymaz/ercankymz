// Decompiled with JetBrains decompiler
// Type: buMotion.buMotionMessageLang
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buClass;
using System;

#nullable disable
namespace buMotion;

[Serializable]
public class buMotionMessageLang : buSerilization
{
  public string DriveSetFollowError;
  public string DriveSetNegativeCurrentError;
  public string DriveSetPositiveCurrentError;
  public string DriveSetAnalogOutError;
  public string DriveSetAnalogInputError;
  public string DriveSetVelocityLoopKPError;
  public string DriveSetVelocityLoopKIError;
  public string DriveSetVelocityLoopFFError;
  public string DriveSetPositionLoopKPError;
  public string DriveSetPositionLoopKIError;
  public string DenumeratorZero;
  public string NumeratorZero;
  public static byte f0001B6;
  public string DoYoutoTurnDefault;
  public string DoYouWanttoDeleteFile;
  public string FileisLoading;
  public string FileisLoaded;
  public string YourLevelNotEnoughtThisOperation;
  public string DoYouWanttoClearAll;
  public string PasswordError;
  public string DoYouWanttoRemove;
  public string DoYouWanttoRemoveAll;
  public string GCodeLineNumberHigherthenMaxLimit;
  public string ExitFromPRogram;
  public string ValueIncorrectFormat;
  public string DoYouWanttoDelete;
  public string DoYouWanttoUpdate;
  public string ThisToolExist;
  public string YouCantChangeParameterBeforeLoad;
  public string NoSelectedEntities;
  public string DoYouWanttoRemoveTool;
  public string DoYouWanttoUpdateTool;
  public string NoSelectedPoint;
  public string DoyouWanttoSavetoFile;
  public string DoYouWanttoClearList;
  public string DoYouWanttoSaveList;
  public string DoYouWanttoRemoveAllEx;
  public string DoYouWanttoRemoveEx;
  public string XAxisValueGreatThanLimitDoYouWanttoContinue;
  public string XAxisValueLowerThanLimitDoYouWanttoContinue;
  public string YAxisValueGreatThanLimitDoYouWanttoContinue;
  public string YAxisValueLowerThanLimitDoYouWanttoContinue;
  public string DoYouWanttoStartFromMiddlePoint;
  public string ThereisAnotherOperationforThisIDDoYouWanttoRemoveThem;
  public string NoDefinedIPAddressforController;
  public string AxisValueisHigherThanLimit;
  public string AxisValueisLowerThanLimit;
  public string DoYouWanttoClearTable;
  public string DoYouWanttoDeleteItem;
  public string DoYouWanttoAddItem;
  public string FileZMinValueLowerThanMachineMinValue;
  public string FileAMinValueLowerThanMachineMinValue;
  public string FileZMaxValueGreaterThanMachineMinValue;
  public string FileAMaxValueGreaterThanMachineMinValue;
  public string FileBMinValueLowerThanMachineMinValue;
  public string FileCMinValueLowerThanMachineMinValue;
  public string FileBMaxValueGreaterThanMachineMinValue;
  public string FileCMaxValueGreaterThanMachineMinValue;
  public string DoYouWanttoMakeThisOperation;
  public string YouMustSelectPattern;
  public string YouMustSelectSingleBlock;
  public string ReportHasBeenSentSuccesful;
  public string ReportSendError;

  public abstract void m000085();
}
