using System.Collections.Generic;

namespace buClass;

public class StretchEventArg
{
	public Pnt3D BasePoint = new Pnt3D();

	public Pnt3D MinPoint = new Pnt3D();

	public Pnt3D MaxPoint = new Pnt3D();

	public VectorType StretchDirection = VectorType.XVector;

	public double StretchValue = 1.0;

	public double EntityMaxDistance = 0.0;

	public PlusMinus Sign = PlusMinus.Plus;

	public bool ScaleRational = false;

	public bool UseRatioFromXPoint = false;

	public double XRatioPosition = 0.0;

	public bool UseRatioFromYPoint = false;

	public double YRatioPosition = 0.0;

	public List<Pnt3D> SelectedAreaPoints = new List<Pnt3D>();

	public StretchEventArg()
	{
	}

	public StretchEventArg(Pnt3D basePoint, VectorType stretchDirection, double stretchValue, double entityMaxDistance, PlusMinus sign, bool scaleRational, List<Pnt3D> selectedAreaPoints)
	{
		BasePoint = new Pnt3D(basePoint);
		StretchDirection = stretchDirection;
		StretchValue = stretchValue;
		EntityMaxDistance = entityMaxDistance;
		Sign = sign;
		ScaleRational = scaleRational;
		SelectedAreaPoints.Clear();
		Pnt3D.Copy(selectedAreaPoints, ref SelectedAreaPoints);
	}

	public override string ToString()
	{
		return "StretchValue : " + StretchValue;
	}
}
