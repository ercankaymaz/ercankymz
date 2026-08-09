namespace buClass.Apps;

public class XRayData : buSerilization
{
	public double Kv = 100.0;

	public double Ma = 5.0;

	public double Time = 100.0;

	public double Frames = 64.0;

	public double Rot = 0.0;

	public double FlipH = 0.0;

	public double FlipV = 0.0;

	public double GreyC = 0.0;

	public double GreyW = 0.0;

	public double Left = 35.0;

	public double Top = 35.0;

	public double Right = 35.0;

	public double Bottom = 35.0;

	public double GrayAuto = 2.0;

	public bool XRay = false;

	public bool Image = false;

	public bool Video = false;

	public XRayFocus Focus = XRayFocus.Small;

	public double Radius = 0.0;

	public ClockDirectionType ArcDirection = ClockDirectionType.CW;

	public double FeedVel = 2000.0;

	public XRayData()
	{
	}

	public XRayData(XRayData data)
	{
		Bottom = data.Bottom;
		FlipH = data.FlipH;
		FlipV = data.FlipV;
		Focus = data.Focus;
		Frames = data.Frames;
		GreyC = data.GreyC;
		GreyW = data.GreyW;
		Image = data.Image;
		Kv = data.Kv;
		Left = data.Left;
		Ma = data.Ma;
		Right = data.Right;
		Rot = data.Rot;
		Time = data.Time;
		Top = data.Top;
		Video = data.Video;
		XRay = data.XRay;
		Radius = data.Radius;
		FeedVel = data.FeedVel;
	}

	public override string ToString()
	{
		return "Kv = " + Kv + " , Ma : " + Ma;
	}
}
