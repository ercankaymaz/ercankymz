using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Setup
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Transformation _0023_003DzoAj2Rl9rKafIe4ahgQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Transformation _0023_003DzylonwpI_003D;

	internal Plane Plane;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stock _0023_003DzuS2gpoXwUHMF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly linearUnitsType _0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dztp4Ps1G34YhULwwl1w_003D_003D;

	public Transformation Transformation
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzoAj2Rl9rKafIe4ahgQ_003D_003D;
		}
	}

	public linearUnitsType Units
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D;
		}
	}

	public Stock Stock
	{
		get
		{
			return _0023_003DzuS2gpoXwUHMF;
		}
		set
		{
			_0023_003DzuS2gpoXwUHMF = value;
			if (_0023_003DzuS2gpoXwUHMF != null)
			{
				_0023_003DzC88fK_14IU6Z(_0023_003DzuS2gpoXwUHMF.Plane);
				Stock.Setup = this;
			}
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dztp4Ps1G34YhULwwl1w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dztp4Ps1G34YhULwwl1w_003D_003D = value;
		}
	}

	public Setup(string name, linearUnitsType units, Plane workPln)
		: this(name, units, workPln, null)
	{
	}

	public Setup(string name, linearUnitsType units, Plane workPln, Stock stock)
	{
		Name = name;
		_0023_003DzYgMj3fzgkvQU3G5hkg_003D_003D = units;
		Plane = workPln;
		_0023_003DzoAj2Rl9rKafIe4ahgQ_003D_003D = new Align3D(Plane.XY, workPln);
		_0023_003DzylonwpI_003D = new Align3D(workPln, Plane.XY);
		if (stock != null)
		{
			_0023_003DzC88fK_14IU6Z(stock.Plane);
			_0023_003DzuS2gpoXwUHMF = stock;
			_0023_003DzuS2gpoXwUHMF.Setup = this;
		}
	}

	internal void _0023_003DzC88fK_14IU6Z(Plane _0023_003Dzpyw2kZk_003D)
	{
		if (!Vector3D.AreCoincident(_0023_003Dzpyw2kZk_003D.AxisZ, Plane.AxisZ))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996468));
		}
	}

	public double WorldToWork(double zh)
	{
		Point3D point3D = Plane.Origin + Plane.AxisZ * zh;
		point3D.TransformBy(_0023_003DzylonwpI_003D);
		return point3D.Z;
	}

	public double WorkToWorld(double zh)
	{
		Point3D point3D = Plane.Origin + Plane.AxisZ * zh;
		point3D.TransformBy(Transformation);
		return point3D.Z;
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982076), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), Name, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951311), Units, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974845), Plane);
	}
}
