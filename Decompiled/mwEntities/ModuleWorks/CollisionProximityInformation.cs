using System;

namespace ModuleWorks;

[Serializable]
public struct CollisionProximityInformation
{
	public int FirstId { get; set; }

	public int SecondId { get; set; }

	public int ThresholdIndex { get; set; }

	public double Threshold { get; set; }

	public string FirstCollidingComponent { get; set; }

	public string SecondCollidingComponent { get; set; }

	public Vectord WitnessPoint { get; private set; }

	public CollisionProximityInformation(int firstId, int secondId, double threshold, Vectord witnessPoint)
	{
		this = default(CollisionProximityInformation);
		FirstId = firstId;
		SecondId = secondId;
		Threshold = threshold;
		WitnessPoint = witnessPoint;
		string firstCollidingComponent = (SecondCollidingComponent = string.Empty);
		FirstCollidingComponent = firstCollidingComponent;
	}

	public CollisionProximityInformation(int firstId, int secondId, double threshold, int thresholdIndex, string firstCollidingComponent, string secondCollidingComponent, Vectord witnessPoint)
	{
		this = default(CollisionProximityInformation);
		FirstId = firstId;
		SecondId = secondId;
		ThresholdIndex = thresholdIndex;
		Threshold = threshold;
		WitnessPoint = witnessPoint;
		FirstCollidingComponent = firstCollidingComponent;
		SecondCollidingComponent = secondCollidingComponent;
	}

	public bool IsWitnessPointValid()
	{
		if (!double.IsNaN(WitnessPoint.X) && !double.IsNaN(WitnessPoint.Y))
		{
			return !double.IsNaN(WitnessPoint.Z);
		}
		return false;
	}
}
