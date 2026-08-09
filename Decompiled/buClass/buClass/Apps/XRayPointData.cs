namespace buClass.Apps;

public class XRayPointData : buSerilization
{
	public double X = 0.0;

	public double Y = 0.0;

	public double Z = 0.0;

	public double A = 0.0;

	public double C = 0.0;

	public XRayData XRay = new XRayData();

	public bool Enable = true;

	public XRayPointData()
	{
	}

	public XRayPointData(double x, double y, double z, bool enable, XRayData xray)
	{
		X = x;
		Y = y;
		Z = z;
		Enable = enable;
		XRay = new XRayData(xray);
	}

	public XRayPointData(double x, double y, double z, double a, double c, bool enable, XRayData xray)
	{
		X = x;
		Y = y;
		Z = z;
		A = a;
		C = c;
		Enable = enable;
		XRay = new XRayData(xray);
	}

	public XRayPointData(XRayPointData data)
	{
		X = data.X;
		Y = data.Y;
		Z = data.Z;
		C = data.C;
		A = data.A;
		Enable = data.Enable;
		XRay = new XRayData(data.XRay);
	}
}
