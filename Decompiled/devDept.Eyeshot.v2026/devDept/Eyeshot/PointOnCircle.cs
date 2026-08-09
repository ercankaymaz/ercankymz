namespace devDept.Eyeshot;

public class PointOnCircle
{
	public double X;

	public double Y;

	public double Angle;

	public bool IsEnd;

	public PointOnCircle(double x, double y, double a, bool isEnd)
	{
		X = x;
		Y = y;
		Angle = a;
		IsEnd = isEnd;
	}
}
