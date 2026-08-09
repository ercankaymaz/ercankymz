using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal abstract class _0023_003Dz3yTehjY_1ZV5QPm48sNaXQlqR5IV8x_0024WIg_003D_003D : IComparer<Entity>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected Point3D _0023_003DzI12_djkkaDCb;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected displayType _0023_003Dz3XcgwFXUmKuh;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected LayerKeyedCollection _0023_003DzRj39t48_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	protected MaterialKeyedCollection _0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D;

	public _0023_003Dz3yTehjY_1ZV5QPm48sNaXQlqR5IV8x_0024WIg_003D_003D(Point3D _0023_003Dz1444P10Wa9OXHN1_AA_003D_003D, LayerKeyedCollection _0023_003DzjDdbnzc6miMJ, MaterialKeyedCollection _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D)
	{
		_0023_003DzI12_djkkaDCb = _0023_003Dz1444P10Wa9OXHN1_AA_003D_003D;
		_0023_003DzRj39t48_003D = _0023_003DzjDdbnzc6miMJ;
		_0023_003DzBAUfV9t86bF_z_Vm8Q_003D_003D = _0023_003DzJj9xvHlpx6ho6C_0024dOw_003D_003D;
	}

	public abstract int Compare(Entity _0023_003DzJgB4fbA_003D, Entity _0023_003DzvbseIi4_003D);

	protected int _0023_003DzS5KVJ48_003D(Entity _0023_003DzJgB4fbA_003D, Entity _0023_003DzvbseIi4_003D, Color _0023_003Dz5xpCMDI_003D, Color _0023_003Dzt9xe7gk_003D)
	{
		if (_0023_003Dz5xpCMDI_003D.A < byte.MaxValue && _0023_003Dzt9xe7gk_003D.A == byte.MaxValue)
		{
			return 1;
		}
		if (_0023_003Dzt9xe7gk_003D.A < byte.MaxValue && _0023_003Dz5xpCMDI_003D.A == byte.MaxValue)
		{
			return -1;
		}
		if (_0023_003Dz5xpCMDI_003D.A == byte.MaxValue && _0023_003Dzt9xe7gk_003D.A == byte.MaxValue)
		{
			return 0;
		}
		Point3D sphereCenter = _0023_003DzJgB4fbA_003D.sphereCenter;
		Point3D sphereCenter2 = _0023_003DzvbseIi4_003D.sphereCenter;
		Point3D point3D = _0023_003DzI12_djkkaDCb;
		double num = (sphereCenter.X - point3D.X) * (sphereCenter.X - point3D.X) + (sphereCenter.Y - point3D.Y) * (sphereCenter.Y - point3D.Y) + (sphereCenter.Z - point3D.Z) * (sphereCenter.Z - point3D.Z);
		return Math.Sign((sphereCenter2.X - point3D.X) * (sphereCenter2.X - point3D.X) + (sphereCenter2.Y - point3D.Y) * (sphereCenter2.Y - point3D.Y) + (sphereCenter2.Z - point3D.Z) * (sphereCenter2.Z - point3D.Z) - num);
	}

	protected int _0023_003DzS5KVJ48_003D(Entity _0023_003DzJgB4fbA_003D, Entity _0023_003DzvbseIi4_003D, bool _0023_003Dz4xphjcUX9Bu5, bool _0023_003DzVzH2yJczZlWB)
	{
		if (_0023_003Dz4xphjcUX9Bu5 && !_0023_003DzVzH2yJczZlWB)
		{
			return 1;
		}
		if (_0023_003DzVzH2yJczZlWB && !_0023_003Dz4xphjcUX9Bu5)
		{
			return -1;
		}
		if (!_0023_003Dz4xphjcUX9Bu5 && !_0023_003DzVzH2yJczZlWB)
		{
			return 0;
		}
		Point3D sphereCenter = _0023_003DzJgB4fbA_003D.sphereCenter;
		Point3D sphereCenter2 = _0023_003DzvbseIi4_003D.sphereCenter;
		Point3D point3D = _0023_003DzI12_djkkaDCb;
		double num = (sphereCenter.X - point3D.X) * (sphereCenter.X - point3D.X) + (sphereCenter.Y - point3D.Y) * (sphereCenter.Y - point3D.Y) + (sphereCenter.Z - point3D.Z) * (sphereCenter.Z - point3D.Z);
		return Math.Sign((sphereCenter2.X - point3D.X) * (sphereCenter2.X - point3D.X) + (sphereCenter2.Y - point3D.Y) * (sphereCenter2.Y - point3D.Y) + (sphereCenter2.Z - point3D.Z) * (sphereCenter2.Z - point3D.Z) - num);
	}
}
