using System;
using System.Reflection;
using System.Windows.Forms;
using buClass;

namespace buCadCamResVer5.Misc;

public class clsHasp
{
	public static bool InitHsKey(ref string Code)
	{
		try
		{
			string scope = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?> <haspscope/> ";
			TextBox textHistory = new TextBox();
			HaspDemo haspDemo = new HaspDemo(textHistory);
			bool LoginStatus = false;
			string KeyCode = "";
			haspDemo.RunDemo(scope, ref LoginStatus, ref KeyCode);
			if (LoginStatus)
			{
				if (HaspDemo.KeyCode.Length < 27)
				{
					return false;
				}
				Code = HaspDemo.KeyCode;
			}
			return LoginStatus;
		}
		catch (Exception mSException)
		{
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
			return false;
		}
	}
}
