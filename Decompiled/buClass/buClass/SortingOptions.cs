using System;

namespace buClass;

[Serializable]
public class SortingOptions : buSerilization
{
	public double Resolution = 0.001;

	public bool UsePlane = false;

	public bool UseCamSelectedProps = true;

	public bool UseEntitySelectedProps = false;

	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D EndPoint = new Pnt3D();

	public Pnt3D StopPoint = new Pnt3D();

	public bool UseStopPoint = false;

	public bool AlwaysUseZeroPointAfterJump = false;

	public bool If2PointAtFirstPointUseSecondOne = false;

	public SortingIntersectionRulesType IntersectionRules = SortingIntersectionRulesType.LowerIndex;

	public SortingNextGroupFindRulesType NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;

	public bool AngleLimitation = false;

	public double AngleMinLimit = -360.0;

	public double AngleMaxLimit = 360.0;
}
