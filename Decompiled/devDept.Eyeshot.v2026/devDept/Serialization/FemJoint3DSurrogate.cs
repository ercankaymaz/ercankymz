using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemJoint3DSurrogate : FemJoint2DSurrogate
{
	public FemJoint3DSurrogate(Joint3D joint3D)
		: base(joint3D)
	{
	}

	protected override Element ConvertToObject()
	{
		double[,] matrixRotation = Rotation.ToArray() as double[,];
		Joint3D joint3D = new Joint3D(Connection[0], Connection[1], matrixRotation, Stiffness);
		CopyDataToObject(joint3D);
		return joint3D;
	}
}
