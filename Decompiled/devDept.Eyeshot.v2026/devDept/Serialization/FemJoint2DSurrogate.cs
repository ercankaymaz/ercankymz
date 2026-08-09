using devDept.Eyeshot.Fem;

namespace devDept.Serialization;

public class FemJoint2DSurrogate : FemElementSurrogate
{
	public ProtoArray<double> Rotation;

	public double[] Stiffness;

	public FemJoint2DSurrogate(Joint2D joint2D)
		: base(joint2D)
	{
	}

	protected override Element ConvertToObject()
	{
		double[,] matrixRotation = Rotation.ToArray() as double[,];
		Joint2D joint2D = new Joint2D(Connection[0], Connection[1], matrixRotation, Stiffness);
		CopyDataToObject(joint2D);
		return joint2D;
	}

	protected override void CopyDataFromObject(Element element)
	{
		Joint2D joint2D = (Joint2D)element;
		Rotation = joint2D.rot.ToProtoArray<double>();
		Stiffness = joint2D.Stiffness;
	}
}
