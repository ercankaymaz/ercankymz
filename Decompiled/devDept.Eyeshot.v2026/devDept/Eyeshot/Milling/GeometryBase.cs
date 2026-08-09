using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Milling;

public class GeometryBase
{
	protected double deviation;

	protected double angle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected Dictionary<Transformation, _0023_003DzKk55cj6jfSEjRkcQNUpgwJXs36iIpKD_q7R4mAo_003D> _0023_003Dz0uCq1ns_003D = new Dictionary<Transformation, _0023_003DzKk55cj6jfSEjRkcQNUpgwJXs36iIpKD_q7R4mAo_003D>();

	public GeometryBase()
	{
		bool flag = true;
		object[] array = null;
		array = new object[1] { flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"ac>", array);
	}

	public Point3D GetBoxMin(Setup setup)
	{
		return _0023_003Dz0uCq1ns_003D[setup.Transformation]._0023_003DzDPcjoBJLcqli;
	}

	public Point3D GetBoxMax(Setup setup)
	{
		return _0023_003Dz0uCq1ns_003D[setup.Transformation]._0023_003Dz_0024N_0024yKptW9BoC;
	}

	public Size3D GetBoxSize(Setup setup)
	{
		return new Size3D(GetBoxMin(setup), GetBoxMax(setup));
	}

	public Entity[] GetTessellation(Setup setup, Color color)
	{
		_0023_003DzKk55cj6jfSEjRkcQNUpgwJXs36iIpKD_q7R4mAo_003D _0023_003DzKk55cj6jfSEjRkcQNUpgwJXs36iIpKD_q7R4mAo_003D2 = _0023_003Dz0uCq1ns_003D[setup.Transformation];
		foreach (Entity item in _0023_003DzKk55cj6jfSEjRkcQNUpgwJXs36iIpKD_q7R4mAo_003D2._0023_003DzLXv_WdC_s03R)
		{
			item.ColorMethod = colorMethodType.byEntity;
			item.Color = color;
		}
		return _0023_003DzKk55cj6jfSEjRkcQNUpgwJXs36iIpKD_q7R4mAo_003D2._0023_003DzLXv_WdC_s03R.ToArray();
	}

	internal void _0023_003DztGdcVOA_003D(Setup _0023_003Dz9cS3uG0_003D)
	{
		if (!_0023_003Dz0uCq1ns_003D.ContainsKey(_0023_003Dz9cS3uG0_003D.Transformation))
		{
			_0023_003DzjMq_0024wgdZc_00245l(_0023_003Dz9cS3uG0_003D);
		}
	}

	private protected virtual void _0023_003DzjMq_0024wgdZc_00245l(Setup _0023_003Dz9cS3uG0_003D)
	{
	}
}
