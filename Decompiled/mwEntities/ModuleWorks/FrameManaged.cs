using System;

namespace ModuleWorks;

[Serializable]
public class FrameManaged
{
	public Vectorf Position { get; set; }

	public QuaternionManaged Orientation { get; set; }

	public FrameManaged()
	{
		Position = new Vectorf();
		Orientation = new QuaternionManaged();
	}

	public FrameManaged(TransformationMatrixManaged matrix)
		: this()
	{
		FromMatrix(this, matrix);
	}

	public void FromMatrix(TransformationMatrixManaged matrix)
	{
		FromMatrix(this, matrix);
	}

	public static void FromMatrix(FrameManaged frame, TransformationMatrixManaged matrix)
	{
		float[] data = matrix.GetData();
		frame.Position.X = data[3];
		frame.Position.Y = data[7];
		frame.Position.Z = data[11];
		frame.Orientation.FromMatrix(matrix);
	}
}
