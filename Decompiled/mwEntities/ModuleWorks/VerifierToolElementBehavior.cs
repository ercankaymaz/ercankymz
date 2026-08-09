using System;

namespace ModuleWorks;

[Serializable]
public struct VerifierToolElementBehavior
{
	public bool RemovesMaterial { get; set; }

	public bool IsCollisionChecked { get; set; }

	public bool RapidCollisionReportSuppressed { get; set; }

	public bool SimulateHoles { get; set; }

	public bool SimulateThicknessInTurning { get; set; }

	public bool IsSafetyDistanceChecked { get; set; }

	public bool AddMaterial { get; set; }

	public VerifierToolElementBehavior(bool removesMaterial, bool isCollisionChecked, bool rapidCollisionReportSuppressed, bool simulateHoles, bool simulateThicknessInTurning, bool isSafetyDistanceChecked)
		: this(removesMaterial, isCollisionChecked, rapidCollisionReportSuppressed, simulateHoles, simulateThicknessInTurning, isSafetyDistanceChecked, addMaterial: false)
	{
	}

	public VerifierToolElementBehavior(bool removesMaterial, bool isCollisionChecked, bool rapidCollisionReportSuppressed, bool simulateHoles, bool simulateThicknessInTurning, bool isSafetyDistanceChecked, bool addMaterial)
	{
		this = default(VerifierToolElementBehavior);
		RemovesMaterial = removesMaterial;
		IsCollisionChecked = isCollisionChecked;
		RapidCollisionReportSuppressed = rapidCollisionReportSuppressed;
		SimulateHoles = simulateHoles;
		SimulateThicknessInTurning = simulateThicknessInTurning;
		IsSafetyDistanceChecked = isSafetyDistanceChecked;
		AddMaterial = addMaterial;
	}

	public static bool operator ==(VerifierToolElementBehavior a, VerifierToolElementBehavior b)
	{
		if (a.RemovesMaterial == b.RemovesMaterial && a.IsCollisionChecked == b.IsCollisionChecked && a.RapidCollisionReportSuppressed == b.RapidCollisionReportSuppressed && a.SimulateHoles == b.SimulateHoles && a.SimulateThicknessInTurning == b.SimulateThicknessInTurning && a.IsSafetyDistanceChecked == b.IsSafetyDistanceChecked)
		{
			return a.AddMaterial == b.AddMaterial;
		}
		return false;
	}

	public static bool operator !=(VerifierToolElementBehavior a, VerifierToolElementBehavior b)
	{
		return !(a == b);
	}

	public override bool Equals(object obj)
	{
		if (obj is VerifierToolElementBehavior)
		{
			return this == (VerifierToolElementBehavior)obj;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return RemovesMaterial.GetHashCode() | IsCollisionChecked.GetHashCode() | RapidCollisionReportSuppressed.GetHashCode() | SimulateHoles.GetHashCode() | SimulateThicknessInTurning.GetHashCode() | IsSafetyDistanceChecked.GetHashCode() | AddMaterial.GetHashCode();
	}
}
