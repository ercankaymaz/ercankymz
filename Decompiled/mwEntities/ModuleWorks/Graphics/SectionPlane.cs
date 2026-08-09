using System;

namespace ModuleWorks.Graphics;

[Serializable]
public struct SectionPlane
{
	public Vectorf NormalDirection { get; set; }

	public float Shift { get; set; }

	public SectionPlane(Vectorf normalDirection, float shift)
	{
		this = default(SectionPlane);
		NormalDirection = normalDirection;
		Shift = shift;
	}

	public override bool Equals(object obj)
	{
		SectionPlane sectionPlane = (SectionPlane)obj;
		if (NormalDirection.Equals(sectionPlane.NormalDirection))
		{
			return Shift.Equals(sectionPlane.Shift);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return NormalDirection.GetHashCode() & Shift.GetHashCode();
	}
}
