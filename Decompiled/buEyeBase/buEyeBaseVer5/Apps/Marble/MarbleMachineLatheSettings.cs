using buClass;

namespace buEyeBaseVer5.Apps.Marble;

public class MarbleMachineLatheSettings : buSerilization5
{
	public double LatheXOffset = 3600.0;

	public double LatheYOffset = 2500.0;

	public double LatheZOffset = 0.0;

	public double LatheGCodeXOffset = -3600.0;

	public double LatheGCodeYOffset = -2500.0;

	public double LatheGCodeZOffset = 0.0;

	public double LatheLeftRightSideDistance = 3620.0;

	public LeftRightType LathePosition = LeftRightType.Left;
}
