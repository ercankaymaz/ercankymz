using System.Collections.Generic;
using buCore;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.Apps.PanelCut;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Flexo;

namespace buEyeBaseVer5;

public class buCall
{
	internal static buKinematic buKinematic_0 = null;

	internal static buKinematic5 buKinematic5_0 = null;

	internal static buVector buVector_0 = null;

	internal static buVector5 buVector5_0 = null;

	internal static buCam5 buCam5_0 = null;

	internal static buNestingCalc buNestingCalc_0 = null;

	internal static buCutterCalc buCutterCalc_0 = null;

	internal static buDrillCalc buDrillCalc_0 = null;

	internal static buFlexoCalc buFlexoCalc_0 = null;

	internal static buProfileCalc buProfileCalc_0 = null;

	internal static buSewingCalc buSewingCalc_0 = null;

	internal static buFoamCalc buFoamCalc_0 = null;

	internal static buPipeBendCalc buPipeBendCalc_0 = null;

	internal static buPrinter3D buPrinter3D_0 = null;

	internal static buPanelCutCalc buPanelCutCalc_0 = null;

	internal static buDiamakerCalc buDiamakerCalc_0 = null;

	internal static buDoor buDoor_0 = null;

	internal static buRouter3AX buRouter3AX_0 = null;

	internal static buToolGrindingCalc buToolGrindingCalc_0 = null;

	internal static buMarbleCalc buMarbleCalc_0 = null;

	internal static buRoboticCalc buRoboticCalc_0 = null;

	internal static List<LayerBase5> list_0 = new List<LayerBase5>();

	public buCall()
	{
		buVector_0 = new buVector();
		buKinematic_0 = new buKinematic();
		buVector5_0 = new buVector5();
		buKinematic5_0 = new buKinematic5();
		buNestingCalc_0 = new buNestingCalc();
		buCutterCalc_0 = new buCutterCalc();
		buDrillCalc_0 = new buDrillCalc();
		buFlexoCalc_0 = new buFlexoCalc();
		buProfileCalc_0 = new buProfileCalc();
		buMarbleCalc_0 = new buMarbleCalc();
		buCam5_0 = new buCam5();
		buSewingCalc_0 = new buSewingCalc();
		buFoamCalc_0 = new buFoamCalc();
		buPanelCutCalc_0 = new buPanelCutCalc();
		buPrinter3D_0 = new buPrinter3D();
		buDiamakerCalc_0 = new buDiamakerCalc();
		buDoor_0 = new buDoor();
		buPipeBendCalc_0 = new buPipeBendCalc();
		buRouter3AX_0 = new buRouter3AX();
		buToolGrindingCalc_0 = new buToolGrindingCalc();
		buRoboticCalc_0 = new buRoboticCalc();
	}
}
