using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class Tool : EndMill
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzS2fd7A17GwriBlfHj1QR3Y8_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point2D[] _0023_003DzQ4Tdus_0024oQGKUia4wwG4m6B8_003D = new Point2D[18]
	{
		new Point2D(20.0, 0.0),
		new Point2D(25.0, 4.0),
		new Point2D(25.0, 25.0),
		new Point2D(20.0, 25.0),
		new Point2D(20.0, 30.0),
		new Point2D(23.0, 33.0),
		new Point2D(23.0, 43.0),
		new Point2D(24.0, 44.0),
		new Point2D(31.0, 44.0),
		new Point2D(32.0, 45.0),
		new Point2D(32.0, 48.0),
		new Point2D(28.0, 50.0),
		new Point2D(28.0, 53.0),
		new Point2D(32.0, 55.0),
		new Point2D(32.0, 58.0),
		new Point2D(31.0, 59.0),
		new Point2D(25.0, 59.0),
		new Point2D(25.0, 64.0)
	};

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003Dzg3ulPZe4NSHXNIU_00243w_003D_003D = Color.FromArgb(102, 102, 102);

	public double CollisionRadius
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzS2fd7A17GwriBlfHj1QR3Y8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzS2fd7A17GwriBlfHj1QR3Y8_003D = value;
		}
	}

	public Point2D[] HolderProfile
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzQ4Tdus_0024oQGKUia4wwG4m6B8_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzQ4Tdus_0024oQGKUia4wwG4m6B8_003D = value;
		}
	}

	public Color HolderColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzg3ulPZe4NSHXNIU_00243w_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzg3ulPZe4NSHXNIU_00243w_003D_003D = value;
		}
	}

	public Tool(double diameter, double cornerRadius, int number = 0)
		: base(diameter, cornerRadius, number)
	{
	}

	public Tool(double diameter, double cornerRadius, Point2D[] holderProfile, int number = 0)
		: this(diameter, cornerRadius, diameter * 2.0, diameter * 3.0, holderProfile, number)
	{
	}

	public Tool(double diameter, double cornerRadius, double fluteLength, double shaftLength, int number = 0)
		: base(diameter, cornerRadius, fluteLength, shaftLength, number)
	{
	}

	public Tool(double diameter, double cornerRadius, double fluteLength, double shaftLength, Point2D[] holderProfile, int number = 0)
		: base(diameter, cornerRadius, fluteLength, shaftLength, number)
	{
		HolderProfile = holderProfile;
	}

	public Tool(double d, double alpha, double r, double beta, double h, double shaftLength, int number = 0)
		: base(d, alpha, r, beta, h, shaftLength, number)
	{
	}

	public Tool(double d, double alpha, double r, double beta, double h, double shaftLength, Point2D[] holderProfile, int number = 0)
		: base(d, alpha, r, beta, h, shaftLength, number)
	{
		HolderProfile = holderProfile;
	}

	protected Tool(Tool another)
		: base(another)
	{
		if (HolderProfile != null)
		{
			HolderProfile = new Point2D[another.HolderProfile.Length];
			for (int i = 0; i < another.HolderProfile.Length; i++)
			{
				HolderProfile[i] = (Point2D)another.HolderProfile[i].Clone();
			}
		}
		HolderColor = another.HolderColor;
	}

	public override object Clone()
	{
		return new Tool(this);
	}

	public override string ToString()
	{
		string text = base.ToString();
		if (CollisionRadius > 0.0)
		{
			text = text + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996746) + CollisionRadius;
		}
		return text;
	}

	protected override void AddSectionMeshes(double length, double shaft, int slices, List<Mesh> mList)
	{
		base.AddSectionMeshes(length, shaft, slices, mList);
		int count = mList.Count;
		mList.RemoveAt(count - 1);
		mList.AddRange(_0023_003DzLdXnUj0S1s_00245(base.Diameter / 2.0, shaft, 36, HolderProfile, HolderColor));
	}

	private static Mesh[] _0023_003DzLdXnUj0S1s_00245(double _0023_003DzEGKj_0024SNUUihi, double _0023_003DzlgU3lJk0TqKB, int _0023_003DzAPBIJmvn5i5Q, Point2D[] _0023_003Dzvnn6I5tLCTf_0024UyHU3w_003D_003D, Color _0023_003Dz8_0024lfaYW6TRIu)
	{
		Point2D[] array = new Point2D[_0023_003Dzvnn6I5tLCTf_0024UyHU3w_003D_003D.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new Point2D(_0023_003Dzvnn6I5tLCTf_0024UyHU3w_003D_003D[i].X, _0023_003Dzvnn6I5tLCTf_0024UyHU3w_003D_003D[i].Y + _0023_003DzlgU3lJk0TqKB);
		}
		Mesh mesh = new Line(_0023_003DzEGKj_0024SNUUihi, _0023_003DzlgU3lJk0TqKB, array[0].X, array[0].Y).RevolveAsMesh(0.0, Math.PI * 2.0, Vector3D.AxisY, Point3D.Origin, _0023_003DzAPBIJmvn5i5Q, 0.0, Mesh.natureType.ColorSmooth);
		EndMill.SetTriangleColor(mesh.Triangles, _0023_003Dz8_0024lfaYW6TRIu);
		Mesh mesh2 = new LinearPath(Plane.XY, array).RevolveAsMesh(0.0, Math.PI * 2.0, Vector3D.AxisY, Point3D.Origin, _0023_003DzAPBIJmvn5i5Q, 0.0, Mesh.natureType.ColorSmooth);
		EndMill.SetTriangleColor(mesh2.Triangles, _0023_003Dz8_0024lfaYW6TRIu);
		int num = _0023_003Dzvnn6I5tLCTf_0024UyHU3w_003D_003D.Length - 1;
		Mesh mesh3 = new Line(array[num].X, array[num].Y, 0.0, array[num].Y).RevolveAsMesh(0.0, Math.PI * 2.0, Vector3D.AxisY, Point3D.Origin, _0023_003DzAPBIJmvn5i5Q, 0.0, Mesh.natureType.ColorSmooth);
		EndMill.SetTriangleColor(mesh3.Triangles, _0023_003Dz8_0024lfaYW6TRIu);
		return new Mesh[3] { mesh, mesh2, mesh3 };
	}

	internal override bool _0023_003DzUpi18zaCZLvO(ref SimulationStock._0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, double _0023_003DzUIfKDS0_003D, double _0023_003DzWBM5jB4_003D, double _0023_003DzEM_vSEo_003D, out double _0023_003DzId5C3LA_003D, out bool _0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D)
	{
		_0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D = false;
		bool num = base._0023_003DzUpi18zaCZLvO(ref _0023_003DzPo_ODtE_003D, _0023_003DzUIfKDS0_003D, _0023_003DzWBM5jB4_003D, _0023_003DzEM_vSEo_003D, out _0023_003DzId5C3LA_003D, out _0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D);
		if (!num)
		{
			_0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D = _0023_003DzT0ssX_0024Ir9NtL(ref _0023_003DzPo_ODtE_003D, _0023_003DzUIfKDS0_003D, _0023_003DzWBM5jB4_003D, _0023_003DzEM_vSEo_003D, out _0023_003DzId5C3LA_003D);
		}
		return num | _0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D;
	}

	private bool _0023_003DzT0ssX_0024Ir9NtL(ref SimulationStock._0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, double _0023_003DzUIfKDS0_003D, double _0023_003DzWBM5jB4_003D, double _0023_003DzEM_vSEo_003D, out double _0023_003DzjP0PkZ4_003D)
	{
		_0023_003DzjP0PkZ4_003D = 0.0;
		if (_0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D < 1E-12)
		{
			double num = _0023_003DzUIfKDS0_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X;
			double num2 = _0023_003DzWBM5jB4_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y;
			if (num * num + num2 * num2 > CollisionRadius * CollisionRadius)
			{
				return false;
			}
			_0023_003DzjP0PkZ4_003D = _0023_003DzPo_ODtE_003D._0023_003DzDNpeQO0_003D.Z + base.ShaftLength;
			return _0023_003DzjP0PkZ4_003D < _0023_003DzEM_vSEo_003D;
		}
		if (double.IsInfinity(_0023_003DzPo_ODtE_003D._0023_003DzuwH5j5s_003D))
		{
			return false;
		}
		_0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D.X = _0023_003DzUIfKDS0_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X;
		_0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D.Y = _0023_003DzWBM5jB4_003D - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y;
		_0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D.Z = 0.0;
		double num3 = Vector3D.Dot(_0023_003DzPo_ODtE_003D._0023_003DziP9fFuA_003D, _0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D);
		double num4 = Vector3D.Dot(_0023_003DzPo_ODtE_003D._0023_003Dz61IPlm0_003D, _0023_003DzPo_ODtE_003D._0023_003DzWWgGxds_003D);
		if (Math.Abs(num3) > CollisionRadius || (num4 < 0.0 && num3 * num3 + num4 * num4 > CollisionRadius * CollisionRadius) || (num4 > _0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D && num3 * num3 + (_0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D - num4) * (_0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D - num4) > CollisionRadius * CollisionRadius))
		{
			return false;
		}
		double num5 = 0.0;
		num5 = (double)((_0023_003DzPo_ODtE_003D._0023_003DzuwH5j5s_003D >= 0.0) ? 1 : (-1)) * Math.Sqrt(CollisionRadius * CollisionRadius - num3 * num3);
		if (num4 <= num5)
		{
			_0023_003DzjP0PkZ4_003D = _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z + base.ShaftLength;
		}
		else if (num5 < num4 && num4 < num5 + _0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D)
		{
			_0023_003DzjP0PkZ4_003D = _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Z + base.ShaftLength + _0023_003DzPo_ODtE_003D._0023_003DzuwH5j5s_003D * (num4 - num5);
		}
		else
		{
			_0023_003DzjP0PkZ4_003D = _0023_003DzPo_ODtE_003D._0023_003DzDNpeQO0_003D.Z + base.ShaftLength;
		}
		return _0023_003DzjP0PkZ4_003D < _0023_003DzEM_vSEo_003D;
	}
}
