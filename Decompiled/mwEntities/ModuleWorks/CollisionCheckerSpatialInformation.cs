using System;

namespace ModuleWorks;

[Serializable]
public class CollisionCheckerSpatialInformation
{
	public double Distance { get; private set; }

	public Vectord WitnessPoint1 { get; private set; }

	public Vectord WitnessPoint2 { get; private set; }

	public CollisionCheckerSpatialInformation(double distance, Vectord witnessPoint1, Vectord witnessPoint2)
	{
		Distance = distance;
		WitnessPoint1 = witnessPoint1;
		WitnessPoint2 = witnessPoint2;
	}
}
