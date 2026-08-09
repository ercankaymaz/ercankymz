using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

internal class MotionRangeSurrogate : Surrogate<PrintSimulationMesh.MotionRange>
{
	public int Start;

	public int End;

	public MotionRangeSurrogate(PrintSimulationMesh.MotionRange mr)
		: base(mr)
	{
	}

	protected override PrintSimulationMesh.MotionRange ConvertToObject()
	{
		return new PrintSimulationMesh.MotionRange(this);
	}

	protected override void CopyDataToObject(PrintSimulationMesh.MotionRange obj)
	{
	}

	protected override void CopyDataFromObject(PrintSimulationMesh.MotionRange mr)
	{
		Start = mr.Start;
		End = mr.End;
	}

	public static implicit operator PrintSimulationMesh.MotionRange(MotionRangeSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator MotionRangeSurrogate(PrintSimulationMesh.MotionRange source)
	{
		return source._0023_003Dz_0024xHo97pGU7zE();
	}
}
