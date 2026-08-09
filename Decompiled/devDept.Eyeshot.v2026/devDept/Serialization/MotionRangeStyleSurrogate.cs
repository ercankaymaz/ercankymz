using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

internal class MotionRangeStyleSurrogate : Surrogate<PrintSimulationMesh.MotionRangeStyle>
{
	public PrintSimulationMesh.MotionRange Range;

	public string ColorName;

	public MotionRangeStyleSurrogate(PrintSimulationMesh.MotionRangeStyle mr)
		: base(mr)
	{
	}

	protected override PrintSimulationMesh.MotionRangeStyle ConvertToObject()
	{
		return new PrintSimulationMesh.MotionRangeStyle(this);
	}

	protected override void CopyDataToObject(PrintSimulationMesh.MotionRangeStyle obj)
	{
	}

	protected override void CopyDataFromObject(PrintSimulationMesh.MotionRangeStyle mr)
	{
		Range = mr.Range;
		ColorName = mr.ColorName;
	}

	public static implicit operator PrintSimulationMesh.MotionRangeStyle(MotionRangeStyleSurrogate surrogate)
	{
		return surrogate.ConvertToObject();
	}

	public static implicit operator MotionRangeStyleSurrogate(PrintSimulationMesh.MotionRangeStyle source)
	{
		return source._0023_003Dz_0024xHo97pGU7zE();
	}
}
