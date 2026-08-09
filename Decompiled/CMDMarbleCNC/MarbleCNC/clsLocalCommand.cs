using System;
using System.Threading;
using buCadCamResVer5;
using buClass;
using buEyeBaseVer5;
using buMarble;
using buMotion;

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
				{
					clsItem.threadCommunication.Abort();
				}
				Environment.Exit(0);
				return;
			}
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
		catch (Exception)
		{
		}
	}
}
