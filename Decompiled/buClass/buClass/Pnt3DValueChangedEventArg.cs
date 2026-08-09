namespace buClass;

public class Pnt3DValueChangedEventArg
{
	public Pnt3D Point = new Pnt3D();

	public double X = 0.0;

	public double Y = 0.0;

	public double Z = 0.0;

	public AxesEnableXYZ Enable = new AxesEnableXYZ();

	public override string ToString()
	{
		return "X : " + Point.X + " , Y : " + Point.Y + " , Z : " + Point.Z;
	}
}
