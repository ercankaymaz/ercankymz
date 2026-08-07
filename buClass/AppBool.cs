// Decompiled with JetBrains decompiler
// Type: buClass.AppBool
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;

#nullable disable
namespace buClass;

[Serializable]
public class AppBool : buSerilization
{
  public static bool ControlKeyPressed;
  public static bool ShiftKeyPressed;
  public static bool AltKeyPressed;
  public static bool TouchPad;
  public static bool Connected;
  public static bool FileLoading;
  public static bool FileLoaded;
  public static bool Inited;
  public static bool HomingDone;
  public static bool Offline;
  public static bool Canceled;
  public static bool Calculation;
  public static bool Error;
  public static bool Run;
  public static bool Move;
  public static bool Pause;
  public static bool Alarm;
  public static bool LockCommands;
  public static bool SingleStep;
  public static bool UpdateToolData;
  public static bool Enabled;
  public static bool LoopStart;
  public static bool SimulationMode;
  public static bool SimulatedIO;
  public static bool BigFile;
  public static bool Internet;
  public static bool IsFirstRun;
  public static bool ESCPressed;
  public static bool Save;
  public static bool Saving;
  public static bool SavingLog;
  public static bool SavingExceptionLog;
  public static bool CheckingLogSize;
  public static bool SaveByTick;
  public static bool MotionMode;
  public static bool MouseDown;
  public static bool CameraConnected;
  public static bool CommunicationError;
  public static bool DeveloperMode;
  public static bool MachineMode;
  public static bool CollisionAvailable;
  public static bool Started;
  public static bool CameraMakeItReady;
  public static bool CameraCapturing;
  public static bool CameraCaptured;
  public static bool FileCopied;
  public static bool EditMode;
  public static bool ListFilling;
  public static bool TreeExpanding;
  public static bool TreeCollapsing;
  public static bool TreeNodeClicked;
  public static bool MouseDowned;
  public static bool AxesX;
  public static bool AxesY;
  public static bool AxesZ;
  public static bool AxesA;
  public static bool AxesB;
  public static bool AxesC;
  public static bool JogPlus;
  public static bool JogMinus;
  public static bool ToolUpdated;
  public static bool ToolChanged;
  public static bool MousePositionFromMotion;
  public static bool DistanceToGo;
  public static bool FileSettingBroken;
  public static bool VisualUpdateForce;
  public static bool DontWriteParameters;
  public static bool HelpMe;
}
