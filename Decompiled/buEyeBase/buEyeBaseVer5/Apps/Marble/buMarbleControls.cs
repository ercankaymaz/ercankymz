using System.Windows.Forms;
using buControls.Controls;

namespace buEyeBaseVer5.Apps.Marble;

public class buMarbleControls
{
	public static bool Inited;

	public static buSpin spnMaterialThickness;

	public static buSpin spnTargetZ;

	public static buSpin spnForwardStep;

	public static buSpin spnPlungeSpeed;

	public static buSpin spnCuttingSpeed;

	public static TreeView treeJob;

	public static void InitControls()
	{
		spnMaterialThickness = new buSpin();
		spnTargetZ = new buSpin();
		spnForwardStep = new buSpin();
		spnPlungeSpeed = new buSpin();
		spnCuttingSpeed = new buSpin();
	}
}
