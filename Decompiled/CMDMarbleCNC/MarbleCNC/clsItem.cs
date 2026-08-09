using System.Threading;
using System.Windows.Forms;
using buControls.Forms.buControlForms.Test;
using buEyeBaseVer5.Forms.Password;
using buEyeBaseVer5.Forms.Vision;

namespace MarbleCNC;

public class clsItem
{
	public static F_Intro FrmIntro = new F_Intro();

	public static F_Menu FrmMenu = new F_Menu();

	public static F_MenuSettings FrmMenuSettings = new F_MenuSettings();

	public static F_AdminSettings FrmMenuAdminSettings = new F_AdminSettings();

	public static F_Machine1 FrmMach1 = null;

	public static F_Machine2 FrmMach2 = null;

	public static F_Machine3_Milling FrmMach3Milling = null;

	public static F_PasswordV1 FrmPassword = new F_PasswordV1();

	public static F_CameraLive FrmCameraLive = new F_CameraLive();

	public static F_TestAll FrmTestAll = new F_TestAll();

	public static System.Windows.Forms.Timer timGeneral = new System.Windows.Forms.Timer();

	public static System.Windows.Forms.Timer timWarning = new System.Windows.Forms.Timer();

	public static Thread threadCommunication = null;
}
