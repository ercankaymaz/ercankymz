using System.Collections.Generic;
using System.Runtime.CompilerServices;
using buClass;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.buEntities;

public class buCompositeCurveCam : CompositeCurve
{
	[CompilerGenerated]
	private double double_0 = 200.0;

	[CompilerGenerated]
	private CamMoveType camMoveType_0 = CamMoveType.G0;

	[CompilerGenerated]
	private int int_0 = -1;

	public double DirArrowDistances
	{
		[CompilerGenerated]
		get
		{
			return double_0;
		}
		[CompilerGenerated]
		set
		{
			double_0 = value;
		}
	}

	public CamMoveType MoveType
	{
		[CompilerGenerated]
		get
		{
			return camMoveType_0;
		}
		[CompilerGenerated]
		set
		{
			camMoveType_0 = value;
		}
	}

	public int CamID
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public buCompositeCurveCam(CompositeCurve another)
		: base(another)
	{
		if (another is buCompositeCurveCam)
		{
			MoveType = ((buCompositeCurveCam)another).MoveType;
			DirArrowDistances = ((buCompositeCurveCam)another).DirArrowDistances;
			CamID = ((buCompositeCurveCam)another).CamID;
		}
	}

	public buCompositeCurveCam(IEnumerable<ICurve> curveList)
		: base(curveList)
	{
	}

	public buCompositeCurveCam(params ICurve[] curveList)
		: base(curveList)
	{
	}

	public buCompositeCurveCam(ICurve curve)
		: base(curve)
	{
	}

	public buCompositeCurveCam(IEnumerable<ICurve> curveList, bool sortAndOrient)
		: base(curveList, sortAndOrient)
	{
	}

	public buCompositeCurveCam(IEnumerable<ICurve> curveList, double closureTol)
		: base(curveList, closureTol)
	{
	}

	public buCompositeCurveCam(IEnumerable<ICurve> curveList, double closureTol, bool sortAndOrient)
		: base(curveList, closureTol, sortAndOrient)
	{
	}

	public override string ToString()
	{
		return "CompositeCurveCam : " + base.StartPoint.ToString() + " - " + base.EndPoint.ToString() + " - " + base.CurveList.Count;
	}
}
