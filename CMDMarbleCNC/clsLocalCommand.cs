// Decompiled with JetBrains decompiler
// Type: MarbleCNC.clsLocalCommand
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using buCadCamResVer5;
using buClass;
using buEyeBaseVer5;
using buMarble;
using buMotion;
using System;
using System.Threading;

#nullable disable
namespace MarbleCNC;

public class clsLocalCommand
{
  public static void Exit()
  {
    try
    {
      clsAppMarbleVars.cmdMarble.DisposeAll();
      buEyeShotFunctions.DisposeAll();
      clsInit.appMarble.DisposeAll();
      if (!AppBool.Connected)
      {
        if (clsItem.threadCommunication != null && clsItem.threadCommunication.IsAlive)
          clsItem.threadCommunication.Abort();
        Environment.Exit(0);
      }
      else
      {
        if (CodesysMachine.CommType == CommunicationType.PlcHandler)
        {
          clsAppMarbleVars.cMachine.miscVar.ThreadEnable = false;
          Thread.Sleep(1000);
          clsItem.threadCommunication.Abort();
        }
        if (CodesysMachine.CommType == CommunicationType.OPCUA)
        {
          clsAppMarbleVars.cMachine.miscVar.ThreadEnable = false;
          Thread.Sleep(1000);
          clsItem.threadCommunication.Abort();
        }
        clsItem.FrmIntro.CloseProgram();
      }
    }
    catch (Exception ex)
    {
    }
  }
}
