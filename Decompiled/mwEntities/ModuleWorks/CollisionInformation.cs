using System;

namespace ModuleWorks;

[Serializable]
public struct CollisionInformation
{
	public int FirstId { get; set; }

	public int SecondId { get; set; }

	public double LeftMargin { get; set; }

	public double RightMargin { get; set; }

	public string FirstCollidingComponent { get; set; }

	public string SecondCollidingComponent { get; set; }

	public Vectord WitnessPoint { get; private set; }

	public CollisionInformation(int firstId, int secondId, double leftMargin, double rightMargin, Vectord witnessPoint)
	{
		this = default(CollisionInformation);
		FirstId = firstId;
		SecondId = secondId;
		LeftMargin = leftMargin;
		RightMargin = rightMargin;
		WitnessPoint = witnessPoint;
		string firstCollidingComponent = (SecondCollidingComponent = string.Empty);
		FirstCollidingComponent = firstCollidingComponent;
	}

	public CollisionInformation(int firstId, int secondId, double leftMargin, double rightMargin, string firstCollidingComponent, string secondCollidingComponent, Vectord witnessPoint)
	{
		this = default(CollisionInformation);
		FirstId = firstId;
		SecondId = secondId;
		LeftMargin = leftMargin;
		RightMargin = rightMargin;
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
