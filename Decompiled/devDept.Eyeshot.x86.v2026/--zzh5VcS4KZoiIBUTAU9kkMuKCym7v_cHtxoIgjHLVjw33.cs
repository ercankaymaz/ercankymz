using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using devDept;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

internal static class _0023_003Dzzh5VcS4KZoiIBUTAU9kkMuKCym7v_cHtxoIgjHLVjw33
{
	[Serializable]
	private sealed class _0023_003DzE18LVS0_003D
	{
		public static readonly _0023_003DzE18LVS0_003D _0023_003Dz8VglJ9E_003D = new _0023_003DzE18LVS0_003D();

		public static Func<Point3D, OdGePoint3d> _0023_003DzZVpSMCSjNRqGsYtrJg_003D_003D;

		internal OdGePoint3d _0023_003DztG_HSYbfPjCGa6__0024LX1DMRnmNJlp(Point3D _0023_003Dzzkz90iI_003D)
		{
			return _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003Dzzkz90iI_003D);
		}
	}

	private static class _0023_003Dzf4WsBy0_003D
	{
		public static _0023_003Dzzm_0024t9TEJc8vr _0023_003DzHvynt9GD8Yr_ToM01w_003D_003D;

		public static _0023_003Dzzm_0024t9TEJc8vr _0023_003DzulLt7jh66AM0x9J1aw_003D_003D;

		public static _0023_003Dzzm_0024t9TEJc8vr _0023_003Dz8_0024o_G8lBt6mQ_0024TVcLg_003D_003D;
	}

	private delegate void _0023_003Dzzm_0024t9TEJc8vr(Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt, IList<Entity> _0023_003DzLpVMKc8_003D);

	internal static void _0023_003DzwlUm98KZEubL(Entity _0023_003DzjTcg784i19JxIS9Fng_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		if (!_0023_003DzwzL57J6ueMIu._0023_003Dzr4B1w_OXMWkt().Contains(_0023_003DzjTcg784i19JxIS9Fng_003D_003D.LayerName))
		{
			return;
		}
		if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is LinearEntity)
		{
			_0023_003Dz7yKDATk1CBAt((LinearEntity)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is devDept.Eyeshot.Entities.Point)
		{
			_0023_003Dz18cV0SI_003D((devDept.Eyeshot.Entities.Point)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Line)
		{
			_0023_003DzciVu7bQ_003D((Line)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Arc)
		{
			_0023_003DzBKhXeJg_003D((Arc)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Circle)
		{
			_0023_003Dz_OdgruSMTWwD((Circle)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is EllipticalArc)
		{
			_0023_003Dz_9lflYepeE16jfUAOQvN_JQ_003D((EllipticalArc)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Ellipse)
		{
			_0023_003DznRcf4rY_003D((Ellipse)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is AngularDim)
		{
			_0023_003DzHha4fwLZ64SM71Of_0024A_003D_003D((AngularDim)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is devDept.Eyeshot.Entities.Attribute)
		{
			_0023_003DzzckLrOA_003D((devDept.Eyeshot.Entities.Attribute)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Bar)
		{
			_0023_003DzCv4VMLs_003D((Bar)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is View)
		{
			_0023_003Dz4vZmerk_003D((View)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is BlockReference)
		{
			_0023_003Dzl_VkX7SZLPW5((BlockReference)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is CompositeCurve)
		{
			_0023_003DzTLJK0fn7_aX5((CompositeCurve)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is DiametricDim)
		{
			_0023_003Dzy9aFngHYp1QUItiBhw_003D_003D((DiametricDim)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Joint)
		{
			_0023_003DzvzvL0fG52umE((Joint)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is LinearDim)
		{
			_0023_003DzIVTRXIpMRvS5((LinearDim)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is OrdinateDim)
		{
			_0023_003DzvUT_0024V6H9vxfnhDy4zg_003D_003D((OrdinateDim)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Leader)
		{
			_0023_003Dz620imCc_003D((Leader)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is LinearPath)
		{
			_0023_003DzD29Tx6vepLac((LinearPath)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is MultilineText)
		{
			_0023_003DzNxpW0UnxBdY0((MultilineText)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Ole2Frame)
		{
			_0023_003DzBYY5Py55Mbci((Ole2Frame)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Picture)
		{
			_0023_003DzTpzkeCo_003D((Picture)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is PointCloud)
		{
			_0023_003DzcJM3N6wHISuW((PointCloud)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is FastPointCloud)
		{
			_0023_003DzcJM3N6wHISuW(((FastPointCloud)_0023_003DzjTcg784i19JxIS9Fng_003D_003D).ConvertToPointCloud(), _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Quad)
		{
			_0023_003Dz_btzQJc_003D((Quad)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is RadialDim)
		{
			_0023_003DznWaOm9_QnBlt((RadialDim)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Hatch)
		{
			_0023_003Dzbqgi89Q_003D((Hatch)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is devDept.Eyeshot.Entities.Region)
		{
			_0023_003DzGFGcFtc_003D((devDept.Eyeshot.Entities.Region)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Balloon balloon)
		{
			Entity[] array = balloon.Explode();
			for (int i = 0; i < array.Length; i++)
			{
				_0023_003DzwlUm98KZEubL(array[i], _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			}
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is SectionLine sectionLine)
		{
			Entity[] array = sectionLine.Explode(_0023_003DzwzL57J6ueMIu._0023_003Dzr4B1w_OXMWkt());
			for (int i = 0; i < array.Length; i++)
			{
				_0023_003DzwlUm98KZEubL(array[i], _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			}
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Text)
		{
			_0023_003Dzf6onOAA_003D((Text)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Table)
		{
			_0023_003DzHL1Tv7g_003D((Table)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Triangle)
		{
			_0023_003DzFdkhqi0_003D((Triangle)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is SketchEntity)
		{
			_0023_003DzthVD4lEKLDMi((SketchEntity)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is FemMesh)
		{
			_0023_003DzGTQiltzhkZt3((FemMesh)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Mesh)
		{
			_0023_003DzF0K9Edc_003D((Mesh)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Curve)
		{
			_0023_003DzXftVuQY_003D((Curve)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Solid)
		{
			_0023_003DzZ3AvXfI_003D((Solid)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Brep)
		{
			_0023_003DzC92S9PtGQjOP((Brep)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
		else if (_0023_003DzjTcg784i19JxIS9Fng_003D_003D is Surface)
		{
			_0023_003DzbbsUqVw_003D((Surface)_0023_003DzjTcg784i19JxIS9Fng_003D_003D, _0023_003DzwzL57J6ueMIu);
		}
	}

	public static void _0023_003DzZ3AvXfI_003D(Solid _0023_003Dzlvv6QsQNw3PR, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		for (int i = 0; i < _0023_003Dzlvv6QsQNw3PR.Portions.Count; i++)
		{
			Solid.Portion portion = _0023_003Dzlvv6QsQNw3PR.Portions[i];
			if (!_0023_003Dzlvv6QsQNw3PR.UseInnerColors)
			{
				portion.CopyAttributes(_0023_003Dzlvv6QsQNw3PR);
			}
			Point3D[] vertices = portion.PackVertices();
			_0023_003DzF0K9Edc_003D(portion, _0023_003DzwzL57J6ueMIu);
			portion._vertices = vertices;
		}
	}

	public static void _0023_003Dz18cV0SI_003D(devDept.Eyeshot.Entities.Point _0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbPoint odDbPoint = OdDbPoint.createObject();
		odDbPoint.setPosition(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D));
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbPoint);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D, odDbPoint, _0023_003DzwzL57J6ueMIu);
	}

	internal static OdGePoint3d _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(devDept.Eyeshot.Entities.Point _0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D)
	{
		return new OdGePoint3d(_0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D.Vertices[0].X, _0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D.Vertices[0].Y, _0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D.Vertices[0].Z);
	}

	public static OdGePoint3d _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(Point3D _0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D)
	{
		return new OdGePoint3d(_0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D.X, _0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D.Y, _0023_003DzvGQluJZCwMR_0024P37PxA_003D_003D.Z);
	}

	public static OdGeVector3d _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(Vector3D _0023_003DzhnqkcjPazV5Lm0o5hQ_003D_003D)
	{
		return new OdGeVector3d(_0023_003DzhnqkcjPazV5Lm0o5hQ_003D_003D.X, _0023_003DzhnqkcjPazV5Lm0o5hQ_003D_003D.Y, _0023_003DzhnqkcjPazV5Lm0o5hQ_003D_003D.Z);
	}

	public static OdGePlane _0023_003DzaSRNkR7Ee8BuMye9CQ_003D_003D(Plane _0023_003DzEB7lYL5TAc41V6iYgg_003D_003D)
	{
		return new OdGePlane(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzEB7lYL5TAc41V6iYgg_003D_003D.Origin), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(_0023_003DzEB7lYL5TAc41V6iYgg_003D_003D.AxisX), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(_0023_003DzEB7lYL5TAc41V6iYgg_003D_003D.AxisY));
	}

	public static void _0023_003DzciVu7bQ_003D(Line _0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbLine odDbLine = OdDbLine.createObject();
		odDbLine.setStartPoint(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.StartPoint));
		odDbLine.setEndPoint(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.EndPoint));
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbLine);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D, odDbLine, _0023_003DzwzL57J6ueMIu);
		if (_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.AutodeskProperties != null)
		{
			odDbLine.setThickness(_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.AutodeskProperties.Thickness);
			if (_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.AutodeskProperties.ExtrusionDir != null)
			{
				odDbLine.setNormal(_0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.AutodeskProperties.ExtrusionDir));
			}
		}
	}

	public static void _0023_003Dz7yKDATk1CBAt(LinearEntity _0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbXline odDbXline = OdDbXline.createObject();
		odDbXline.setBasePoint(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.Vertices[0]));
		odDbXline.setUnitDir(new OdGeVector3d(_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.Direction.X * _0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.SymbolSize, _0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.Direction.Y * _0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.SymbolSize, _0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.Direction.Z * _0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D.SymbolSize));
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbXline);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzXJo7l6XLAnwOjYi_0024Yw_003D_003D, odDbXline, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DzBKhXeJg_003D(Arc _0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		if (_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.AngleInDegrees > 359.999999)
		{
			Circle circle = new Circle(_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.Plane, _0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.Center, _0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.Radius);
			circle.CopyAttributes(_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D);
			_0023_003Dz_OdgruSMTWwD(circle, _0023_003DzwzL57J6ueMIu);
			return;
		}
		OdDbArc odDbArc = OdDbArc.createObject();
		odDbArc.setCenter(OdGePoint3d.kOrigin);
		odDbArc.setRadius(_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.Radius);
		odDbArc.setStartAngle(_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.Domain.t0);
		odDbArc.setEndAngle(_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.Domain.t1);
		odDbArc.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D));
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbArc);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D, odDbArc, _0023_003DzwzL57J6ueMIu);
		if (_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.AutodeskProperties != null)
		{
			odDbArc.setThickness(_0023_003DzPaei8Ga_0024tQfpDq9ejw_003D_003D.AutodeskProperties.Thickness);
		}
	}

	public static void _0023_003Dz_OdgruSMTWwD(Circle _0023_003Dzz_0024hLFck9bXmliahA1TSWLWA_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbCircle odDbCircle = OdDbCircle.createObject();
		odDbCircle.setCenter(OdGePoint3d.kOrigin);
		odDbCircle.setNormal(OdGeVector3d.kZAxis);
		odDbCircle.setRadius(_0023_003Dzz_0024hLFck9bXmliahA1TSWLWA_003D.Radius);
		odDbCircle.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003Dzz_0024hLFck9bXmliahA1TSWLWA_003D));
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbCircle);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dzz_0024hLFck9bXmliahA1TSWLWA_003D, odDbCircle, _0023_003DzwzL57J6ueMIu);
		if (_0023_003Dzz_0024hLFck9bXmliahA1TSWLWA_003D.AutodeskProperties != null)
		{
			odDbCircle.setThickness(_0023_003Dzz_0024hLFck9bXmliahA1TSWLWA_003D.AutodeskProperties.Thickness);
		}
	}

	public static void _0023_003Dz_9lflYepeE16jfUAOQvN_JQ_003D(EllipticalArc _0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbEllipse odDbEllipse = _0023_003Dzm6jnFLtti99v(_0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D);
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbEllipse);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D, odDbEllipse, _0023_003DzwzL57J6ueMIu);
	}

	internal static OdDbEllipse _0023_003Dzm6jnFLtti99v(EllipticalArc _0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D)
	{
		_0023_003DzmJzUu6REc7PoP4ImSQ_003D_003D(_0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D, out var _0023_003DzukG7FObRdJDX, out var _0023_003DzjhgI95u1EtVEXZ_3uA_003D_003D, out var _0023_003Dzweihh6mAUr8U);
		EllipticalArc.GetIntervalOfAngles(_0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D.RadiusX, _0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D.RadiusY, _0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D.Domain.t0 + _0023_003Dzweihh6mAUr8U, _0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D.Domain.t1 + _0023_003Dzweihh6mAUr8U, out var startAngleInRadians, out var endAngleInRadians);
		if (startAngleInRadians < 0.0)
		{
			startAngleInRadians += Math.PI * 2.0;
			endAngleInRadians += Math.PI * 2.0;
		}
		if (startAngleInRadians > Math.PI * 2.0)
		{
			startAngleInRadians -= Math.PI * 2.0;
			endAngleInRadians -= Math.PI * 2.0;
		}
		if (endAngleInRadians - startAngleInRadians > Math.PI * 2.0)
		{
			endAngleInRadians = startAngleInRadians + Math.PI * 2.0;
		}
		OdDbEllipse odDbEllipse = OdDbEllipse.createObject();
		odDbEllipse.set(OdGePoint3d.kOrigin, OdGeVector3d.kZAxis, _0023_003DzukG7FObRdJDX, _0023_003DzjhgI95u1EtVEXZ_3uA_003D_003D, startAngleInRadians, endAngleInRadians);
		odDbEllipse.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzgKjvaGCAw3ynSPy_22BUyAA_003D));
		return odDbEllipse;
	}

	public static void _0023_003DznRcf4rY_003D(Ellipse _0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		_0023_003DzmJzUu6REc7PoP4ImSQ_003D_003D(_0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D, out var _0023_003DzukG7FObRdJDX, out var _0023_003DzjhgI95u1EtVEXZ_3uA_003D_003D, out var _);
		OdDbEllipse odDbEllipse = OdDbEllipse.createObject();
		odDbEllipse.set(OdGePoint3d.kOrigin, OdGeVector3d.kZAxis, _0023_003DzukG7FObRdJDX, _0023_003DzjhgI95u1EtVEXZ_3uA_003D_003D, 0.0, Math.PI * 2.0);
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbEllipse);
		odDbEllipse.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D));
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D, odDbEllipse, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DzmJzUu6REc7PoP4ImSQ_003D_003D(Ellipse _0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D, out OdGeVector3d _0023_003DzukG7FObRdJDX, out double _0023_003DzjhgI95u1EtVEXZ_3uA_003D_003D, out double _0023_003Dzweihh6mAUr8U)
	{
		_0023_003Dzweihh6mAUr8U = 0.0;
		if (_0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D.RadiusX >= _0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D.RadiusY)
		{
			_0023_003DzukG7FObRdJDX = new OdGeVector3d(_0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D.RadiusX, 0.0, 0.0);
			_0023_003DzjhgI95u1EtVEXZ_3uA_003D_003D = _0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D.RadiusY / _0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D.RadiusX;
		}
		else
		{
			_0023_003DzukG7FObRdJDX = new OdGeVector3d(0.0, _0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D.RadiusY, 0.0);
			_0023_003DzjhgI95u1EtVEXZ_3uA_003D_003D = _0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D.RadiusX / _0023_003DzJ0dRji15_0024jZnLxF5Ow_003D_003D.RadiusY;
			_0023_003Dzweihh6mAUr8U = -Math.PI / 2.0;
		}
	}

	private static short _0023_003DzPUXlDWjgVWq7(AngularDim _0023_003DzadqLWg0fxGf5)
	{
		return _0023_003DzadqLWg0fxGf5.AngleFormat switch
		{
			angleFormatType.DecimalDegrees => 0, 
			angleFormatType.DegMinSec => 1, 
			angleFormatType.Gradians => 2, 
			angleFormatType.Radians => 3, 
			_ => 0, 
		};
	}

	public static void _0023_003DzHha4fwLZ64SM71Of_0024A_003D_003D(AngularDim _0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDb3PointAngularDimension odDb3PointAngularDimension = OdDb3PointAngularDimension.createObject();
		odDb3PointAngularDimension.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDb3PointAngularDimension);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E, odDb3PointAngularDimension, _0023_003DzwzL57J6ueMIu);
		_0023_003DzeQC5jDvf_ai36PQXoEMKcGM_003D(_0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E, out var _0023_003DzUHF18g1gP3eB, out var _0023_003Dzu3SAHjB14ZQG, out var _0023_003DzSrfQwRi7jSDc, out var _0023_003DzcC5SphyVRIZX);
		odDb3PointAngularDimension.setCenterPoint(new OdGePoint3d());
		odDb3PointAngularDimension.setXLine1Point(new OdGePoint3d(_0023_003DzUHF18g1gP3eB.X, _0023_003DzUHF18g1gP3eB.Y, 0.0));
		odDb3PointAngularDimension.setXLine2Point(new OdGePoint3d(_0023_003Dzu3SAHjB14ZQG.X, _0023_003Dzu3SAHjB14ZQG.Y, 0.0));
		odDb3PointAngularDimension.setArcPoint(new OdGePoint3d(_0023_003DzSrfQwRi7jSDc.X, _0023_003DzSrfQwRi7jSDc.Y, 0.0));
		odDb3PointAngularDimension.setTextPosition(new OdGePoint3d(_0023_003DzcC5SphyVRIZX.X, _0023_003DzcC5SphyVRIZX.Y, 0.0));
		odDb3PointAngularDimension.setDimaunit(_0023_003DzPUXlDWjgVWq7(_0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E));
		odDb3PointAngularDimension.setDimexo(Math.Max(0.0, _0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E.ExtLineOffset));
		odDb3PointAngularDimension.setDimexe(_0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E.ExtLineExt);
		odDb3PointAngularDimension.setDimse1(!_0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E.ShowExtLine1);
		odDb3PointAngularDimension.setDimse2(!_0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E.ShowExtLine2);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzfUoNhZH0qjiX(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh(), odDb3PointAngularDimension, _0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E.LeftArrowhead, _0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E.RightArrowhead, _0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E.ArrowsLocation);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzVEPQ9BWhB6LpsppsyE_7s5k_003D(_0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E, odDb3PointAngularDimension, _0023_003DzwzL57J6ueMIu);
		if (_0023_003DzFtA82Mzy7cUNv8DEotGjMgOvLu7E.ExtLineOffset < 0.0)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531494));
		}
	}

	private static void _0023_003DzeQC5jDvf_ai36PQXoEMKcGM_003D(AngularDim _0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D, out Point3D _0023_003DzUHF18g1gP3eB, out Point3D _0023_003Dzu3SAHjB14ZQG, out Point3D _0023_003DzSrfQwRi7jSDc, out Point3D _0023_003DzcC5SphyVRIZX)
	{
		if (_0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.Vertices == null)
		{
			_0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.RegenInternal(new RegenParams(0.0));
		}
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.Plane, Plane.XY);
		_0023_003DzUHF18g1gP3eB = transformation * _0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.ExtLine1;
		_0023_003Dzu3SAHjB14ZQG = transformation * _0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.ExtLine2;
		Arc arc = new Arc(Plane.XY, Point3D.Origin, _0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.Radius, _0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.StartAngle, _0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.EndAngle);
		_0023_003DzSrfQwRi7jSDc = arc.MidPoint;
		_0023_003DzcC5SphyVRIZX = transformation * _0023_003DzH2kN3ZSWHzFNRDYNbQ_003D_003D.DimLinePosition;
	}

	public static void _0023_003DzzckLrOA_003D(devDept.Eyeshot.Entities.Attribute _0023_003DzdiVPQAQ3LebPOx35_A_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbAttributeDefinition odDbAttributeDefinition = OdDbAttributeDefinition.createObject();
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbAttributeDefinition);
		odDbAttributeDefinition.setPosition(OdGePoint3d.kOrigin);
		odDbAttributeDefinition.setTag(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Tag);
		odDbAttributeDefinition.setTextString(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Value);
		odDbAttributeDefinition.setPrompt(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Prompt);
		odDbAttributeDefinition.setHeight(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Height);
		odDbAttributeDefinition.setInvisible(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Invisible);
		odDbAttributeDefinition.setConstant(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Constant);
		odDbAttributeDefinition.setVerifiable(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Verify);
		odDbAttributeDefinition.setPreset(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Preset);
		odDbAttributeDefinition.mirrorInX(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Backward);
		odDbAttributeDefinition.mirrorInY(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.UpsideDown);
		odDbAttributeDefinition.setWidthFactor(_0023_003DzsjHGnhaUpbgq(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.WidthFactor, _0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.StyleName, _0023_003DzwzL57J6ueMIu._0023_003Dz_0024FFVZEHAUJk7()));
		WriteDatabase._0023_003DzGEpHBqC_0024YQsF4qanzQ_003D_003D(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.Alignment, out var _0023_003Dzyzhw7idDjuhZ, out var _0023_003Dzi2NDvcXD_0024G);
		odDbAttributeDefinition.setHorizontalMode(_0023_003Dzyzhw7idDjuhZ);
		odDbAttributeDefinition.setVerticalMode(_0023_003Dzi2NDvcXD_0024G);
		odDbAttributeDefinition.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D));
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D, odDbAttributeDefinition, _0023_003DzwzL57J6ueMIu);
		odDbAttributeDefinition.setTextStyle(_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38[string.IsNullOrEmpty(_0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.StyleName) ? _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531415) : _0023_003DzdiVPQAQ3LebPOx35_A_003D_003D.StyleName]);
	}

	public static void _0023_003DzCv4VMLs_003D(Bar _0023_003DzT9rJOkueu_GTNOww1w_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		WriteDatabase._0023_003Dzp_0024lg_JOQ5rrz(_0023_003DzT9rJOkueu_GTNOww1w_003D_003D, _0023_003DzT9rJOkueu_GTNOww1w_003D_003D.Vertices, _0023_003DzT9rJOkueu_GTNOww1w_003D_003D.Triangles, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003Dz4vZmerk_003D(View _0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		if (_0023_003DzwzL57J6ueMIu._0023_003Dz4MwBDBTtsrsJj4VGiw_003D_003D || _0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D is SectionView)
		{
			_0023_003Dzl_VkX7SZLPW5(_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D, _0023_003DzwzL57J6ueMIu);
			return;
		}
		OdDbViewport odDbViewport = OdDbViewport.createObject();
		odDbViewport.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbViewport);
		if (_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.AutodeskProperties == null)
		{
			AutodeskProperties.visualStyleType visualStyleMode = _0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.visualStyleMode;
			_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.AutodeskProperties = new AutodeskProperties
			{
				VisualStyleMode = visualStyleMode
			};
		}
		if (_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.AutodeskProperties.XData != null)
		{
			_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.AutodeskProperties.XData = null;
		}
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D, odDbViewport, _0023_003DzwzL57J6ueMIu);
		OdDbObjectId at = ((OdDbDictionary)_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh().getVisualStyleDictionaryId().openObject()).getAt(_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.visualStyleMode.GetDisplayName());
		odDbViewport.setVisualStyle(at);
		Camera camera = (Camera)_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.Camera.Clone();
		if (_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.WindowCenter != null)
		{
			camera.Target = _0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.WindowCenter;
		}
		if (camera.ProjectionMode == projectionType.Perspective)
		{
			odDbViewport.setPerspectiveOn();
		}
		else
		{
			odDbViewport.setPerspectiveOff();
		}
		camera.GetFrame(out var _, out var _, out var camY, out var camZ);
		camZ *= camera.Distance;
		odDbViewport.setViewDirection(new OdGeVector3d(camZ.X, camZ.Y, camZ.Z));
		odDbViewport.setLensLength(camera.FocalLength);
		odDbViewport.setViewTarget(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(camera.Target));
		Transformation.AutocadOCS(camZ, out var _, out var yAxis);
		double num = Utility.VectorsAngle(yAxis, camY, camZ);
		if (num < 0.0)
		{
			num += 360.0;
		}
		odDbViewport.setTwistAngle(Utility.DegToRad(num));
		odDbViewport.setWidth(_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.Width);
		odDbViewport.setHeight(_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.Height);
		odDbViewport.setCenterPoint(new OdGePoint3d(_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.X, _0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.Y, 0.0));
		double linearUnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(_0023_003DzwzL57J6ueMIu._0023_003DzDAi5BZ1ecRzR, _0023_003DzwzL57J6ueMIu._0023_003Dz_gnOOU92zK_s().Units);
		odDbViewport.setCustomScale(_0023_003Dz0p_UJ6NGdAO7062_0024Yg_003D_003D.Scale * linearUnitsConversionFactor);
	}

	public static void _0023_003Dzl_VkX7SZLPW5(BlockReference _0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		Transformation fullTransformation = _0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.GetFullTransformation(_0023_003DzwzL57J6ueMIu._0023_003DzXOYNmXUz4Tcl());
		double scaleFactorX = _0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.GetScaleFactorX();
		double scaleFactorY = _0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.GetScaleFactorY();
		double scaleFactorZ = _0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.GetScaleFactorZ();
		OdDbObjectId blockTableRecord = WriteDatabase._0023_003DzwVzVXv8_003D(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh(), WriteFileAsync.RemoveInvalidChars(_0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.BlockName.Trim()));
		OdDbBlockReference odDbBlockReference = OdDbBlockReference.createObject();
		odDbBlockReference.setPosition(OdGePoint3d.kOrigin);
		odDbBlockReference.setBlockTableRecord(blockTableRecord);
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbBlockReference);
		OdGeMatrix3d odGeMatrix3d = new OdGeMatrix3d();
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				odGeMatrix3d[i, j] = fullTransformation[i, j];
			}
		}
		if (!odGeMatrix3d.isScaledOrtho())
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517736));
		}
		odDbBlockReference.setBlockTransform(odGeMatrix3d);
		_0023_003DzlamAiJw_003D(_0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D, _0023_003DzwzL57J6ueMIu, odDbBlockReference, fullTransformation, scaleFactorX, scaleFactorY, scaleFactorZ);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D, odDbBlockReference, _0023_003DzwzL57J6ueMIu);
		if (_0023_003DzwzL57J6ueMIu._0023_003DzXOYNmXUz4Tcl()[_0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.BlockName].ExportMode != autodeskExportType.Embedded)
		{
			odDbBlockReference.setBlockTableRecord(_0023_003DzwzL57J6ueMIu._0023_003DzN6p3ohvSmsu4()[_0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.BlockName]._0023_003DzuaKKESU_003D);
		}
	}

	private static void _0023_003DzlamAiJw_003D(BlockReference _0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, OdDbBlockReference _0023_003Dz_0024DSWU_Ys9QKE, Transformation _0023_003Dzt5wnIQo_003D, double _0023_003DzAZbTv8c_003D, double _0023_003Dzka_0024MewY_003D, double _0023_003DzmCLSQbg_003D)
	{
		if (_0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.Attributes.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<string, AttributeReference> attribute in _0023_003Dz0j5kP55mm2ej6wmnIg_003D_003D.Attributes)
		{
			AttributeReference value = attribute.Value;
			OdDbAttribute odDbAttribute = OdDbAttribute.createObject();
			odDbAttribute.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
			_0023_003Dz_0024DSWU_Ys9QKE.appendAttribute(odDbAttribute);
			string text = attribute.Key;
			if (text.Contains(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532163)))
			{
				text = text.Substring(0, text.IndexOf(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532163)));
			}
			odDbAttribute.setTag(text);
			odDbAttribute.setTextString(value.Value);
			odDbAttribute.setHeight(value.Height * Math.Abs(_0023_003Dzka_0024MewY_003D));
			odDbAttribute.setInvisible(value.Invisible);
			odDbAttribute.mirrorInX(value.Backward);
			odDbAttribute.mirrorInY(value.UpsideDown);
			double num = _0023_003DzsjHGnhaUpbgq(value.WidthFactor, value.StyleName, _0023_003DzwzL57J6ueMIu._0023_003Dz_0024FFVZEHAUJk7());
			odDbAttribute.setWidthFactor(num * _0023_003DzAZbTv8c_003D / _0023_003Dzka_0024MewY_003D);
			WriteDatabase._0023_003DzGEpHBqC_0024YQsF4qanzQ_003D_003D(value.Alignment, out var _0023_003Dzyzhw7idDjuhZ, out var _0023_003Dzi2NDvcXD_0024G);
			odDbAttribute.setHorizontalMode(_0023_003Dzyzhw7idDjuhZ);
			odDbAttribute.setVerticalMode(_0023_003Dzi2NDvcXD_0024G);
			Plane plane = value.Plane;
			Transformation transformation = new Transformation(plane.Origin, plane.AxisX, plane.AxisY, plane.AxisZ);
			transformation = _0023_003Dzt5wnIQo_003D * transformation;
			transformation[0, 0] /= _0023_003DzAZbTv8c_003D;
			transformation[1, 0] /= _0023_003DzAZbTv8c_003D;
			transformation[2, 0] /= _0023_003DzAZbTv8c_003D;
			transformation[0, 1] /= _0023_003Dzka_0024MewY_003D;
			transformation[1, 1] /= _0023_003Dzka_0024MewY_003D;
			transformation[2, 1] /= _0023_003Dzka_0024MewY_003D;
			transformation[0, 2] /= _0023_003DzmCLSQbg_003D;
			transformation[1, 2] /= _0023_003DzmCLSQbg_003D;
			transformation[2, 2] /= _0023_003DzmCLSQbg_003D;
			Plane xY = Plane.XY;
			xY.TransformBy(transformation);
			odDbAttribute.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(xY));
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(value, odDbAttribute, _0023_003DzwzL57J6ueMIu);
			odDbAttribute.setTextStyle(_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38[string.IsNullOrEmpty(value.StyleName) ? _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531415) : value.StyleName]);
		}
	}

	private static double _0023_003DzsjHGnhaUpbgq(double _0023_003Dz_5NSVV5FjWsK, string _0023_003DzkrK9jgU_003D, TextStyleKeyedCollection _0023_003Dz7ip8s1p1cPxO)
	{
		if (_0023_003Dz_5NSVV5FjWsK == -1.0)
		{
			if (_0023_003DzkrK9jgU_003D == null)
			{
				return _0023_003Dz7ip8s1p1cPxO[0].WidthFactor;
			}
			return _0023_003Dz7ip8s1p1cPxO[_0023_003DzkrK9jgU_003D].WidthFactor;
		}
		return _0023_003Dz_5NSVV5FjWsK;
	}

	public static void _0023_003DzthVD4lEKLDMi(SketchEntity _0023_003DzW2QLSAZrByGhlFUQ9F7pfpk_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		Entity[] array = _0023_003DzW2QLSAZrByGhlFUQ9F7pfpk_003D.Explode();
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003DzwlUm98KZEubL(array[i], _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
		}
	}

	public static void _0023_003DzTLJK0fn7_aX5(CompositeCurve _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		double num = 1E-09;
		if (_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.BoxMin != null)
		{
			num *= _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.BoxSize.Diagonal;
		}
		Plane plane;
		bool flag = _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.IsPlanar(num, out plane);
		bool flag2 = _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList.Count != 1;
		if (flag2)
		{
			foreach (ICurve curve2 in _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList)
			{
				if (!(curve2 is Line) && !(curve2 is Arc))
				{
					flag2 = false;
					break;
				}
			}
		}
		if (flag && Vector3D.AreParallel(plane.AxisZ, Vector3D.AxisZ) && flag2)
		{
			Transformation transformation = new Transformation();
			transformation.Rotation(plane, Plane.XY);
			int num2 = (_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.IsClosed ? _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList.Count : (_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList.Count + 1));
			OdDbPolyline odDbPolyline = OdDbPolyline.createObject();
			odDbPolyline.reset(reuse: false, (uint)(_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList.Count + 1));
			_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbPolyline);
			Point3D point3D = transformation * _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList[0].StartPoint;
			odDbPolyline.addVertexAt(0u, new OdGePoint2d(point3D[0], point3D[1]), 0.0, 0.0, 0.0);
			for (int i = 1; i < num2; i++)
			{
				ICurve curve = _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList[i - 1];
				Point3D point3D2 = transformation * curve.EndPoint;
				odDbPolyline.addVertexAt((uint)i, new OdGePoint2d(point3D2[0], point3D2[1]), 0.0, 0.0, 0.0);
			}
			for (int j = 0; j < _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList.Count; j++)
			{
				if (_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.CurveList[j] is Arc arc)
				{
					double num3 = Math.Tan(arc.AngleInRadians / 4.0);
					if (Vector3D.AreCoincident(arc.Plane.AxisZ, plane.AxisZ))
					{
						odDbPolyline.setBulgeAt((uint)j, num3);
					}
					else
					{
						odDbPolyline.setBulgeAt((uint)j, 0.0 - num3);
					}
				}
			}
			OdGeMatrix3d xfm = _0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(plane);
			odDbPolyline.transformBy(xfm);
			odDbPolyline.setClosed(_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.IsClosed);
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D, odDbPolyline, _0023_003DzwzL57J6ueMIu);
			if (_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.AutodeskProperties != null)
			{
				odDbPolyline.setThickness(_0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.AutodeskProperties.Thickness);
			}
		}
		else
		{
			Entity[] array = _0023_003DzOy7jejNpjt2w0HPlXQ_003D_003D.Explode();
			for (int k = 0; k < array.Length; k++)
			{
				_0023_003DzwlUm98KZEubL(array[k], _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
			}
		}
	}

	public static void _0023_003Dzy9aFngHYp1QUItiBhw_003D_003D(DiametricDim _0023_003DzMuTuFOew3YPQSlcfQigLLPo_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbDiametricDimension odDbDiametricDimension = OdDbDiametricDimension.createObject();
		odDbDiametricDimension.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbDiametricDimension);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzMuTuFOew3YPQSlcfQigLLPo_003D, odDbDiametricDimension, _0023_003DzwzL57J6ueMIu);
		_0023_003DzNR0aBFCkzitPYUkIIA_003D_003D(_0023_003DzMuTuFOew3YPQSlcfQigLLPo_003D, _0023_003Dz7A7nCdeCG4G1qK7WxQ_003D_003D: true, out var _0023_003DzrIurElzSeNjeygQRsA_003D_003D, out var _0023_003DzcC5SphyVRIZX);
		odDbDiametricDimension.setChordPoint(new OdGePoint3d(_0023_003DzrIurElzSeNjeygQRsA_003D_003D.X, _0023_003DzrIurElzSeNjeygQRsA_003D_003D.Y, 0.0));
		odDbDiametricDimension.setFarChordPoint(new OdGePoint3d(0.0 - _0023_003DzrIurElzSeNjeygQRsA_003D_003D.X, 0.0 - _0023_003DzrIurElzSeNjeygQRsA_003D_003D.Y, 0.0));
		odDbDiametricDimension.setLeaderLength(0.0);
		odDbDiametricDimension.setTextPosition(new OdGePoint3d(_0023_003DzcC5SphyVRIZX.X, _0023_003DzcC5SphyVRIZX.Y, 0.0));
		odDbDiametricDimension.setDimcen(_0023_003DzMuTuFOew3YPQSlcfQigLLPo_003D.CenterMarkSize);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzfUoNhZH0qjiX(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh(), odDbDiametricDimension, _0023_003DzMuTuFOew3YPQSlcfQigLLPo_003D.LeftArrowhead, _0023_003DzMuTuFOew3YPQSlcfQigLLPo_003D.RightArrowhead, _0023_003DzMuTuFOew3YPQSlcfQigLLPo_003D.ArrowsLocation);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzVEPQ9BWhB6LpsppsyE_7s5k_003D(_0023_003DzMuTuFOew3YPQSlcfQigLLPo_003D, odDbDiametricDimension, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DzvzvL0fG52umE(Joint _0023_003DzcLof1FVAIRn2kiBE6h0vu2U_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		WriteDatabase._0023_003Dzp_0024lg_JOQ5rrz(_0023_003DzcLof1FVAIRn2kiBE6h0vu2U_003D, _0023_003DzcLof1FVAIRn2kiBE6h0vu2U_003D.Vertices, _0023_003DzcLof1FVAIRn2kiBE6h0vu2U_003D.Triangles, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DzIVTRXIpMRvS5(LinearDim _0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbRotatedDimension odDbRotatedDimension = OdDbRotatedDimension.createObject();
		odDbRotatedDimension.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbRotatedDimension);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D, odDbRotatedDimension, _0023_003DzwzL57J6ueMIu);
		odDbRotatedDimension.setRotation(0.0);
		_0023_003Dz3vZo5hd1cNtyL_0024PKuw_003D_003D(_0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D, out var _0023_003DzUHF18g1gP3eB, out var _0023_003Dzu3SAHjB14ZQG, out var _0023_003Dz_wzOG0JGsbOE, out var _0023_003DzcC5SphyVRIZX);
		odDbRotatedDimension.setXLine1Point(new OdGePoint3d(_0023_003DzUHF18g1gP3eB.X, _0023_003DzUHF18g1gP3eB.Y, 0.0));
		odDbRotatedDimension.setXLine2Point(new OdGePoint3d(_0023_003Dzu3SAHjB14ZQG.X, _0023_003Dzu3SAHjB14ZQG.Y, 0.0));
		odDbRotatedDimension.setDimLinePoint(new OdGePoint3d(_0023_003Dz_wzOG0JGsbOE.X, _0023_003Dz_wzOG0JGsbOE.Y, 0.0));
		odDbRotatedDimension.setTextPosition(new OdGePoint3d(_0023_003DzcC5SphyVRIZX.X, _0023_003DzcC5SphyVRIZX.Y, 0.0));
		odDbRotatedDimension.setDimexo(Math.Max(0.0, _0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D.ExtLineOffset));
		odDbRotatedDimension.setDimexe(_0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D.ExtLineExt);
		odDbRotatedDimension.setDimse1(!_0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D.ShowExtLine1);
		odDbRotatedDimension.setDimse2(!_0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D.ShowExtLine2);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzfUoNhZH0qjiX(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh(), odDbRotatedDimension, _0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D.LeftArrowhead, _0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D.RightArrowhead, _0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D.ArrowsLocation);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzVEPQ9BWhB6LpsppsyE_7s5k_003D(_0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D, odDbRotatedDimension, _0023_003DzwzL57J6ueMIu);
		if (_0023_003Dzkt8_0024Cn50CunmQ6Iovw_003D_003D.ExtLineOffset < 0.0)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531494));
		}
	}

	private static void _0023_003Dz3vZo5hd1cNtyL_0024PKuw_003D_003D(LinearDim _0023_003DzEwztpXQXfEMfSONeIg_003D_003D, out Point3D _0023_003DzUHF18g1gP3eB, out Point3D _0023_003Dzu3SAHjB14ZQG, out Point3D _0023_003Dz_wzOG0JGsbOE, out Point3D _0023_003DzcC5SphyVRIZX)
	{
		if (_0023_003DzEwztpXQXfEMfSONeIg_003D_003D.Vertices == null)
		{
			_0023_003DzEwztpXQXfEMfSONeIg_003D_003D.RegenInternal(new RegenParams(0.0));
		}
		_0023_003DzUHF18g1gP3eB = Point3D.Origin;
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003DzEwztpXQXfEMfSONeIg_003D_003D.Plane, Plane.XY);
		_0023_003Dzu3SAHjB14ZQG = transformation * _0023_003DzEwztpXQXfEMfSONeIg_003D_003D.ExtLine2;
		_0023_003Dz_wzOG0JGsbOE = transformation * _0023_003DzEwztpXQXfEMfSONeIg_003D_003D.Vertices[3];
		_0023_003DzcC5SphyVRIZX = transformation * _0023_003DzEwztpXQXfEMfSONeIg_003D_003D.DimLinePosition;
	}

	public static void _0023_003DzvUT_0024V6H9vxfnhDy4zg_003D_003D(OrdinateDim _0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbOrdinateDimension odDbOrdinateDimension = OdDbOrdinateDimension.createObject();
		odDbOrdinateDimension.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbOrdinateDimension);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu, odDbOrdinateDimension, _0023_003DzwzL57J6ueMIu);
		if (_0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu.IsVertical)
		{
			odDbOrdinateDimension.useXAxis();
		}
		else
		{
			odDbOrdinateDimension.useYAxis();
		}
		_0023_003DzfyBYcNRDBEjR1eSVZ9VBKE4_003D(_0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu, out var _0023_003DzuaZouY0_003D, out var _0023_003DzUHF18g1gP3eB, out var _0023_003Dzu3SAHjB14ZQG, out var _0023_003DzcC5SphyVRIZX);
		odDbOrdinateDimension.setOrigin(new OdGePoint3d(_0023_003DzuaZouY0_003D.X, _0023_003DzuaZouY0_003D.Y, 0.0));
		odDbOrdinateDimension.setDefiningPoint(new OdGePoint3d(_0023_003DzUHF18g1gP3eB.X, _0023_003DzUHF18g1gP3eB.Y, 0.0));
		odDbOrdinateDimension.setLeaderEndPoint(new OdGePoint3d(_0023_003Dzu3SAHjB14ZQG.X, _0023_003Dzu3SAHjB14ZQG.Y, 0.0));
		odDbOrdinateDimension.setTextPosition(new OdGePoint3d(_0023_003DzcC5SphyVRIZX.X, _0023_003DzcC5SphyVRIZX.Y, 0.0));
		odDbOrdinateDimension.setDimexo(Math.Max(0.0, _0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu.ExtLineOffset));
		Transformation.AutocadOCS(_0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu.Plane.AxisZ, out var xAxis, out var yAxis);
		double horizontalRotation = Vector3D.AngleBetween(new Plane(Point3D.Origin, xAxis, yAxis).AxisX, _0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu.Plane.AxisX);
		odDbOrdinateDimension.setHorizontalRotation(horizontalRotation);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzVEPQ9BWhB6LpsppsyE_7s5k_003D(_0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu, odDbOrdinateDimension, _0023_003DzwzL57J6ueMIu);
		if (_0023_003DzORcNKuAlqrbmqpMYF178YAg_kREu.ExtLineOffset < 0.0)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531494));
		}
	}

	private static void _0023_003DzfyBYcNRDBEjR1eSVZ9VBKE4_003D(OrdinateDim _0023_003Dzp8MfghL6NuPo0yijYw_003D_003D, out Point3D _0023_003DzuaZouY0_003D, out Point3D _0023_003DzUHF18g1gP3eB, out Point3D _0023_003Dzu3SAHjB14ZQG, out Point3D _0023_003DzcC5SphyVRIZX)
	{
		if (_0023_003Dzp8MfghL6NuPo0yijYw_003D_003D.Vertices == null)
		{
			_0023_003Dzp8MfghL6NuPo0yijYw_003D_003D.RegenInternal(new RegenParams(0.0));
		}
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003Dzp8MfghL6NuPo0yijYw_003D_003D.Plane, Plane.XY);
		_0023_003DzuaZouY0_003D = transformation * _0023_003Dzp8MfghL6NuPo0yijYw_003D_003D.Origin;
		_0023_003Dzu3SAHjB14ZQG = transformation * _0023_003Dzp8MfghL6NuPo0yijYw_003D_003D.LeaderEndPoint;
		_0023_003DzUHF18g1gP3eB = transformation * _0023_003Dzp8MfghL6NuPo0yijYw_003D_003D.DefiningPoint;
		_0023_003DzcC5SphyVRIZX = transformation * _0023_003Dzp8MfghL6NuPo0yijYw_003D_003D.DimLinePosition;
	}

	public static void _0023_003Dz620imCc_003D(Leader _0023_003DzI1pFydoAKvlWtTeu7g_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbLeader odDbLeader = OdDbLeader.createObject();
		odDbLeader.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbLeader);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D, odDbLeader, _0023_003DzwzL57J6ueMIu);
		if (_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D.Vertices == null)
		{
			_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D.Regen(0.0);
		}
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D.Plane, Plane.XY);
		Point3D[] vertices = _0023_003DzI1pFydoAKvlWtTeu7g_003D_003D.Vertices;
		foreach (Point3D point3D in vertices)
		{
			Point3D point3D2 = transformation * point3D;
			odDbLeader.appendVertex(new OdGePoint3d(point3D2.X, point3D2.Y, point3D2.Z));
		}
		odDbLeader.setDimldrblk(ReadAutodesk._0023_003DzCpMAPMCSIWkbPePIPnwPrXvcxGji(_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D.Arrowhead));
		odDbLeader.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D));
		odDbLeader.setDimscale(_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D.Scale);
		odDbLeader.setDimasz(_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D.ArrowheadSize);
		if (!_0023_003DzI1pFydoAKvlWtTeu7g_003D_003D.ShowArrowHead)
		{
			odDbLeader.disableArrowHead();
		}
	}

	public static void _0023_003DzD29Tx6vepLac(LinearPath _0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		int num = (_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.IsClosed ? (_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.Vertices.Length - 1) : _0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.Vertices.Length);
		if (_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.IsPlanar(1E-06, out var plane) && Vector3D.AreParallel(plane.AxisZ, Vector3D.AxisZ) && (_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.AutodeskProperties == null || _0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.AutodeskProperties.ExtrusionDir == null || Vector3D.AreParallel(Vector3D.AxisZ, _0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.AutodeskProperties.ExtrusionDir)))
		{
			OdDbPolyline odDbPolyline = OdDbPolyline.createObject();
			odDbPolyline.reset(reuse: false, (uint)num);
			_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbPolyline);
			double z = _0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.Vertices[0].Z;
			odDbPolyline.setElevation(z);
			Vector3D axisZ = Vector3D.AxisZ;
			Plane plane2 = ReadAutodesk._0023_003DzH0a_I2VUM1u4(axisZ.ToArray());
			odDbPolyline.setNormal(new OdGeVector3d(axisZ.X, axisZ.Y, axisZ.Z));
			odDbPolyline.setConstantWidth(_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.GlobalWidth);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				Point2D point2D = plane2.Project(_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.Vertices[num2]);
				OdGePoint2d point2d = new OdGePoint2d(point2D.X, point2D.Y);
				odDbPolyline.addVertexAt(num2, point2d, 0.0, 0.0, 0.0);
			}
			odDbPolyline.setClosed(_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.IsClosed);
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D, odDbPolyline, _0023_003DzwzL57J6ueMIu);
			if (_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.AutodeskProperties != null)
			{
				odDbPolyline.setThickness(_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.AutodeskProperties.Thickness);
			}
		}
		else
		{
			OdDb3dPolyline odDb3dPolyline = OdDb3dPolyline.createObject();
			_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDb3dPolyline);
			odDb3dPolyline.setPolyType(OdDb_Poly3dType.k3dSimplePoly);
			for (int i = 0; i < num; i++)
			{
				OdDb3dPolylineVertex odDb3dPolylineVertex = OdDb3dPolylineVertex.createObject();
				odDb3dPolylineVertex.setPosition(new OdGePoint3d(_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.Vertices[i].X, _0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.Vertices[i].Y, _0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.Vertices[i].Z));
				odDb3dPolyline.appendVertex(odDb3dPolylineVertex);
			}
			if (_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D.IsClosed)
			{
				odDb3dPolyline.makeClosed();
			}
			else
			{
				odDb3dPolyline.makeOpen();
			}
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzjkckuXOPHfs_0024xnj4XA_003D_003D, odDb3dPolyline, _0023_003DzwzL57J6ueMIu);
		}
	}

	public static OdGeCurve2d _0023_003DzX9s2QIi2V8n0Rao_0024mIdPI0s_003D(Transformation _0023_003DzA9AWm4_sg3f1)
	{
		throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517809));
	}

	public static void _0023_003DzNxpW0UnxBdY0(MultilineText _0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbMText odDbMText = OdDbMText.createObject();
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbMText);
		odDbMText.setContents(_0023_003Dzufagje5qLRhYDA59_0024w_003D_003D(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.TextString, _0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.WidthFactors, _0023_003DzwzL57J6ueMIu._0023_003DzLBMQhl8GsJK7(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.StyleName).WidthFactor));
		double num = _0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.LineSpaceDistance / _0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.Height * 3.0 / 5.0;
		bool num2 = num < 0.25 || num > 4.0;
		odDbMText.setTextHeight(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.Height);
		if (!num2)
		{
			odDbMText.setLineSpacingFactor(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.LineSpaceDistance / _0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.Height * 3.0 / 5.0);
		}
		odDbMText.setWidth(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.RectWidth);
		odDbMText.setHeight(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.RectHeight);
		odDbMText.setLocation(OdGePoint3d.kOrigin);
		odDbMText.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D));
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D, odDbMText, _0023_003DzwzL57J6ueMIu);
		odDbMText.setTextStyle(_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38[string.IsNullOrEmpty(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.StyleName) ? _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531415) : _0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.StyleName]);
		odDbMText.setAttachment(WriteDatabase._0023_003DzGEpHBqC_0024YQsF4qanzQ_003D_003D(_0023_003Dz0uVMEZvcasaHdKuPZQ_003D_003D.Alignment, out var _, out var _));
		if (num2)
		{
			throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517778));
		}
	}

	private static string _0023_003Dzufagje5qLRhYDA59_0024w_003D_003D(string _0023_003DznhuxS9c_003D, double[] _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D, double _0023_003DzwTNkq7H9kfQv)
	{
		string newLine = Environment.NewLine;
		double num = _0023_003DzwTNkq7H9kfQv;
		if (_0023_003DzTVQPgYS29BHqNSYpYg_003D_003D != null && _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D[0] != -1.0 && _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D[0] != _0023_003DzwTNkq7H9kfQv)
		{
			num = _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D[0];
			_0023_003DznhuxS9c_003D = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517841) + _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D[0].ToString(CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517926) + _0023_003DznhuxS9c_003D;
		}
		int num2 = 1;
		while (true)
		{
			int num3 = _0023_003DznhuxS9c_003D.IndexOf(newLine);
			if (num3 < 0)
			{
				break;
			}
			string text = _0023_003DznhuxS9c_003D.Substring(0, num3);
			string text2 = _0023_003DznhuxS9c_003D.Substring(num3 + newLine.Length, _0023_003DznhuxS9c_003D.Length - num3 - newLine.Length);
			if (_0023_003DzTVQPgYS29BHqNSYpYg_003D_003D != null && _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D.Length > num2)
			{
				double num4 = ((_0023_003DzTVQPgYS29BHqNSYpYg_003D_003D[num2] == -1.0) ? _0023_003DzwTNkq7H9kfQv : _0023_003DzTVQPgYS29BHqNSYpYg_003D_003D[num2]);
				if (num4 != num)
				{
					num = num4;
					text2 = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517841) + num4.ToString(CultureInfo.InvariantCulture.NumberFormat) + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517926) + text2;
				}
			}
			num2++;
			_0023_003DznhuxS9c_003D = text + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355532147) + text2;
		}
		return _0023_003DznhuxS9c_003D;
	}

	public static void _0023_003DzBYY5Py55Mbci(Ole2Frame _0023_003DzCtXwFSIj3rKNhX197Q_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbOle2Frame odDbOle2Frame = OdDbOle2Frame.createObject();
		OdRectangle3d odRectangle3d = new OdRectangle3d();
		Plane plane = _0023_003DzCtXwFSIj3rKNhX197Q_003D_003D.Plane;
		Vector3D vector3D = _0023_003DzCtXwFSIj3rKNhX197Q_003D_003D.Plane.AxisX * _0023_003DzCtXwFSIj3rKNhX197Q_003D_003D.Width;
		Vector3D vector3D2 = _0023_003DzCtXwFSIj3rKNhX197Q_003D_003D.Plane.AxisY * _0023_003DzCtXwFSIj3rKNhX197Q_003D_003D.Height;
		odRectangle3d.lowLeft = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(plane.Origin);
		odRectangle3d.upRight = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(plane.Origin + vector3D + vector3D2);
		odRectangle3d.upLeft = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(plane.Origin + vector3D2);
		odRectangle3d.lowRight = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(plane.Origin + vector3D);
		odDbOle2Frame.setPosition(odRectangle3d);
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			OdMemoryStream odMemoryStream = OdMemoryStream.createNew();
			using (Bitmap bitmap = _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003Dzgx309QbPrd02(_0023_003DzCtXwFSIj3rKNhX197Q_003D_003D.Image))
			{
				bitmap.Save(memoryStream, ImageFormat.Png);
			}
			memoryStream.Position = 0L;
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003Dz_0024Ri82GA5O_VX(memoryStream, odMemoryStream);
			odMemoryStream.rewind();
			OdGiRasterImage pImage = ((OdRxRasterServices)TD_RootIntegrated_Globals.odrxDynamicLinker().loadApp(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517950))).loadRasterImage(odMemoryStream);
			odDbOle2Frame.getItemHandler().embedRaster(pImage);
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbOle2Frame);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzCtXwFSIj3rKNhX197Q_003D_003D, odDbOle2Frame, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DzTpzkeCo_003D(Picture _0023_003Dzlijf3034KicTxkmguw_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		using Bitmap bitmap = _0023_003Dz0UqjDJRVjznU032ZobZyG6sRUxOwSxYhJCJ1_WxsRxkgAkSSjABO220_003D._0023_003Dzgx309QbPrd02(_0023_003Dzlijf3034KicTxkmguw_003D_003D.Image);
		string text = _0023_003Dzlijf3034KicTxkmguw_003D_003D.FilePath;
		if (string.IsNullOrEmpty(text))
		{
			text = _0023_003DzwzL57J6ueMIu._0023_003DzxE6pBeCcqhBAmtKm3A_003D_003D() + _0023_003DzwzL57J6ueMIu._0023_003DzsGX1y6oLSiDGWFx2aw_003D_003D++ + _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517897);
		}
		if (!File.Exists(text))
		{
			try
			{
				bitmap?.Save(text);
			}
			catch (Exception)
			{
			}
		}
		OdDbDictionary obj = (OdDbDictionary)_0023_003DzwzL57J6ueMIu._0023_003DzK_0024xRe1S_rqh9().openObject(OdDb_OpenMode.kForWrite);
		OdDbRasterImageDef odDbRasterImageDef = OdDbRasterImageDef.createObject();
		OdDbObjectId imageDefId = obj.setAt(text, odDbRasterImageDef);
		odDbRasterImageDef.setSourceFileName(text);
		OdGiRasterImage pImage = OdGiRasterImageDesc.createObject((uint)bitmap.Width, (uint)bitmap.Height, OdGiRasterImage_Units.kInch);
		odDbRasterImageDef.setImage(pImage, modifyDatabase: true);
		OdDbRasterImage odDbRasterImage = OdDbRasterImage.createObject();
		odDbRasterImage.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbRasterImage);
		odDbRasterImage.setImageDefId(imageDefId);
		Vector3D vector3D = _0023_003Dzlijf3034KicTxkmguw_003D_003D.Plane.AxisX * _0023_003Dzlijf3034KicTxkmguw_003D_003D.Width;
		Vector3D vector3D2 = _0023_003Dzlijf3034KicTxkmguw_003D_003D.Plane.AxisY * _0023_003Dzlijf3034KicTxkmguw_003D_003D.Height;
		odDbRasterImage.setOrientation(new OdGePoint3d(_0023_003Dzlijf3034KicTxkmguw_003D_003D.Plane.Origin.X, _0023_003Dzlijf3034KicTxkmguw_003D_003D.Plane.Origin.Y, _0023_003Dzlijf3034KicTxkmguw_003D_003D.Plane.Origin.Z), new OdGeVector3d(vector3D.X, vector3D.Y, vector3D.Z), new OdGeVector3d(vector3D2.X, vector3D2.Y, vector3D2.Z));
		odDbRasterImage.setDisplayOpt(OdDbRasterImage_ImageDisplayOpt.kShow | OdDbRasterImage_ImageDisplayOpt.kShowUnAligned | OdDbRasterImage_ImageDisplayOpt.kTransparent, value: true);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dzlijf3034KicTxkmguw_003D_003D, odDbRasterImage, _0023_003DzwzL57J6ueMIu);
		if (_0023_003Dzlijf3034KicTxkmguw_003D_003D.ClippingBoundary != null)
		{
			_0023_003DzWOo7mZMzDhLm(_0023_003Dzlijf3034KicTxkmguw_003D_003D, odDbRasterImage);
		}
	}

	private static void _0023_003DzWOo7mZMzDhLm(Picture _0023_003Dzlijf3034KicTxkmguw_003D_003D, OdDbRasterImage _0023_003Dzhw3ncSA_003D)
	{
		List<Point2D> list = _0023_003Dzlijf3034KicTxkmguw_003D_003D.ClippingBoundary.Points.ToList();
		List<Point3D> list2 = new List<Point3D>();
		foreach (Point2D item in list)
		{
			list2.Add(_0023_003Dzlijf3034KicTxkmguw_003D_003D.Plane.PointAt(item));
		}
		OdGeMatrix3d pixelToModelTransform = _0023_003Dzhw3ncSA_003D.getPixelToModelTransform();
		pixelToModelTransform.invert();
		OdGePoint2dArray odGePoint2dArray = new OdGePoint2dArray();
		foreach (Point3D item2 in list2)
		{
			OdGePoint3d odGePoint3d = new OdGePoint3d(item2.X, item2.Y, item2.Z);
			odGePoint3d = pixelToModelTransform * odGePoint3d;
			odGePoint2dArray.Add(new OdGePoint2d(odGePoint3d.x, odGePoint3d.y));
		}
		_0023_003Dzhw3ncSA_003D.setClipBoundary(odGePoint2dArray);
	}

	public static void _0023_003DzcJM3N6wHISuW(PointCloud _0023_003DzSxfdNONfBsWklOV6lA_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		int num = 0;
		bool flag = false;
		string text = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517916) + num;
		OdDbBlockTable odDbBlockTable = (OdDbBlockTable)_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh().getBlockTableId().openObject(OdDb_OpenMode.kForWrite);
		OdDbSymbolTableIterator odDbSymbolTableIterator = odDbBlockTable.newIterator();
		while (true)
		{
			odDbSymbolTableIterator.start(atBeginning: true);
			while (!odDbSymbolTableIterator.done())
			{
				if (((OdDbBlockTableRecord)odDbSymbolTableIterator.getRecord(OdDb_OpenMode.kForRead)).getName() == text)
				{
					flag = true;
					break;
				}
				odDbSymbolTableIterator.step();
			}
			if (!flag)
			{
				break;
			}
			num++;
			text = _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517916) + num;
			flag = false;
		}
		OdDbBlockTableRecord odDbBlockTableRecord = OdDbBlockTableRecord.createObject();
		odDbBlockTableRecord.setName(text);
		odDbBlockTableRecord.setOrigin(new OdGePoint3d(_0023_003DzSxfdNONfBsWklOV6lA_003D_003D.Vertices[0].X, _0023_003DzSxfdNONfBsWklOV6lA_003D_003D.Vertices[0].Y, _0023_003DzSxfdNONfBsWklOV6lA_003D_003D.Vertices[0].Z));
		odDbBlockTable.add(odDbBlockTableRecord);
		Point3D[] vertices = _0023_003DzSxfdNONfBsWklOV6lA_003D_003D.Vertices;
		foreach (Point3D point3D in vertices)
		{
			OdDbPoint odDbPoint = OdDbPoint.createObject();
			odDbPoint.setPosition(new OdGePoint3d(point3D.X, point3D.Y, point3D.Z));
			odDbBlockTableRecord.appendOdDbEntity(odDbPoint);
			switch (_0023_003DzSxfdNONfBsWklOV6lA_003D_003D.Nature)
			{
			case PointCloud.natureType.Plain:
			{
				OdCmColor odCmColor = new OdCmColor(OdCmEntityColor_ColorMethod.kByBlock);
				odCmColor.setColorIndex(0);
				odDbPoint.setColor(odCmColor);
				break;
			}
			case PointCloud.natureType.Multicolor:
				odDbPoint.setColor(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DztRLzArIqOrBK0lmTPw_003D_003D(((PointRGB)point3D).R, ((PointRGB)point3D).G, ((PointRGB)point3D).B, _0023_003DzwzL57J6ueMIu._0023_003DzujvIJ3_tyt6U(), _0023_003DzwzL57J6ueMIu._0023_003DzFVrp9CCbpZz_0024()));
				break;
			}
			switch (_0023_003DzSxfdNONfBsWklOV6lA_003D_003D.LineWeightMethod)
			{
			case colorMethodType.byLayer:
				odDbPoint.setLineWeight(LineWeight.kLnWtByLayer);
				break;
			case colorMethodType.byEntity:
				odDbPoint.setLineWeight(WriteDatabase._0023_003Dz6rzgaSHBY5QMk_0024oC226vguvdkkCP(_0023_003DzSxfdNONfBsWklOV6lA_003D_003D.LineWeight, _0023_003DzwzL57J6ueMIu._0023_003Dz_GNl1_0024oPxrrc()));
				break;
			case colorMethodType.byParent:
				odDbPoint.setLineWeight(LineWeight.kLnWtByBlock);
				break;
			}
		}
		OdDbBlockReference odDbBlockReference = OdDbBlockReference.createObject();
		odDbBlockReference.setPosition(new OdGePoint3d(_0023_003DzSxfdNONfBsWklOV6lA_003D_003D.Vertices[0].X, _0023_003DzSxfdNONfBsWklOV6lA_003D_003D.Vertices[0].Y, _0023_003DzSxfdNONfBsWklOV6lA_003D_003D.Vertices[0].Z));
		odDbBlockReference.setBlockTableRecord(odDbBlockTableRecord.objectId());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbBlockReference);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzSxfdNONfBsWklOV6lA_003D_003D, odDbBlockReference, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003Dz_btzQJc_003D(Quad _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbFace odDbFace = OdDbFace.createObject();
		odDbFace.setVertexAt(0, new OdGePoint3d(_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[0].X, _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[0].Y, _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[0].Z));
		odDbFace.setVertexAt(1, new OdGePoint3d(_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[1].X, _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[1].Y, _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[1].Z));
		odDbFace.setVertexAt(2, new OdGePoint3d(_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[2].X, _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[2].Y, _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[2].Z));
		odDbFace.setVertexAt(3, new OdGePoint3d(_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[3].X, _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[3].Y, _0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.Vertices[3].Z));
		if ((_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.VisibleEdgeFlag & 1) != 0)
		{
			odDbFace.makeEdgeVisibleAt(0);
		}
		else
		{
			odDbFace.makeEdgeInvisibleAt(0);
		}
		if ((_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.VisibleEdgeFlag & 2) != 0)
		{
			odDbFace.makeEdgeVisibleAt(1);
		}
		else
		{
			odDbFace.makeEdgeInvisibleAt(1);
		}
		if ((_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.VisibleEdgeFlag & 4) != 0)
		{
			odDbFace.makeEdgeVisibleAt(2);
		}
		else
		{
			odDbFace.makeEdgeInvisibleAt(2);
		}
		if ((_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D.VisibleEdgeFlag & 8) != 0)
		{
			odDbFace.makeEdgeVisibleAt(3);
		}
		else
		{
			odDbFace.makeEdgeInvisibleAt(3);
		}
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbFace);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzhNYnyHMt8DOyidZb4A_003D_003D, odDbFace, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DznWaOm9_QnBlt(RadialDim _0023_003DznW5GE0_0024DFe351YjtAg_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbRadialDimension odDbRadialDimension = OdDbRadialDimension.createObject();
		odDbRadialDimension.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbRadialDimension);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DznW5GE0_0024DFe351YjtAg_003D_003D, odDbRadialDimension, _0023_003DzwzL57J6ueMIu);
		_0023_003DzNR0aBFCkzitPYUkIIA_003D_003D(_0023_003DznW5GE0_0024DFe351YjtAg_003D_003D, _0023_003Dz7A7nCdeCG4G1qK7WxQ_003D_003D: false, out var _0023_003DzrIurElzSeNjeygQRsA_003D_003D, out var _0023_003DzcC5SphyVRIZX);
		odDbRadialDimension.setCenter(OdGePoint3d.kOrigin);
		odDbRadialDimension.setChordPoint(new OdGePoint3d(_0023_003DzrIurElzSeNjeygQRsA_003D_003D.X, _0023_003DzrIurElzSeNjeygQRsA_003D_003D.Y, 0.0));
		odDbRadialDimension.setLeaderLength(0.0);
		odDbRadialDimension.setTextPosition(new OdGePoint3d(_0023_003DzcC5SphyVRIZX.X, _0023_003DzcC5SphyVRIZX.Y, 0.0));
		odDbRadialDimension.setDimcen(_0023_003DznW5GE0_0024DFe351YjtAg_003D_003D.CenterMarkSize);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzfUoNhZH0qjiX(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh(), odDbRadialDimension, _0023_003DznW5GE0_0024DFe351YjtAg_003D_003D.Arrowhead, _0023_003DznW5GE0_0024DFe351YjtAg_003D_003D.Arrowhead, _0023_003DznW5GE0_0024DFe351YjtAg_003D_003D.ArrowsLocation);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzVEPQ9BWhB6LpsppsyE_7s5k_003D(_0023_003DznW5GE0_0024DFe351YjtAg_003D_003D, odDbRadialDimension, _0023_003DzwzL57J6ueMIu);
	}

	private static void _0023_003DzNR0aBFCkzitPYUkIIA_003D_003D(RadialDim _0023_003DzyOFx3mmJVHz3fhUoDQ_003D_003D, bool _0023_003Dz7A7nCdeCG4G1qK7WxQ_003D_003D, out Point3D _0023_003DzrIurElzSeNjeygQRsA_003D_003D, out Point3D _0023_003DzcC5SphyVRIZX)
	{
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003DzyOFx3mmJVHz3fhUoDQ_003D_003D.Plane, Plane.XY);
		_0023_003DzcC5SphyVRIZX = transformation * _0023_003DzyOFx3mmJVHz3fhUoDQ_003D_003D.DimLinePosition;
		Point3D point3D = transformation * _0023_003DzyOFx3mmJVHz3fhUoDQ_003D_003D.DimLinePosition;
		double num = Math.Atan2(x: point3D.X, y: point3D.Y);
		if (num < 0.0)
		{
			num += Math.PI * 2.0;
		}
		double num2 = _0023_003DzyOFx3mmJVHz3fhUoDQ_003D_003D.Distance;
		if (_0023_003Dz7A7nCdeCG4G1qK7WxQ_003D_003D)
		{
			num2 /= 2.0;
		}
		_0023_003DzrIurElzSeNjeygQRsA_003D_003D = new Point3D(num2 * Math.Cos(num), num2 * Math.Sin(num));
	}

	public static void _0023_003DzGFGcFtc_003D(devDept.Eyeshot.Entities.Region _0023_003DzabRcWwcumYVnxarr9Q_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		if (_0023_003DzwzL57J6ueMIu._0023_003Dzhf6uXz_0024l6dpO)
		{
			OdRxObject odRxObject = _0023_003DzLE9SnlA_003D(_0023_003DzabRcWwcumYVnxarr9Q_003D_003D.ConvertToSurface().ConvertToBrep(), _0023_003DzwzL57J6ueMIu);
			if (odRxObject != null)
			{
				OdDbRegion odDbRegion = OdDbRegion.createObject();
				odDbRegion.setBody(OdRxObject.getCPtr(odRxObject).Handle);
				odDbRegion.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
				_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbRegion);
				_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzabRcWwcumYVnxarr9Q_003D_003D, odDbRegion, _0023_003DzwzL57J6ueMIu);
			}
		}
		else
		{
			WriteDatabase._0023_003Dzp_0024lg_JOQ5rrz(_0023_003DzabRcWwcumYVnxarr9Q_003D_003D, _0023_003DzabRcWwcumYVnxarr9Q_003D_003D.Vertices, _0023_003DzabRcWwcumYVnxarr9Q_003D_003D.Triangles, _0023_003DzwzL57J6ueMIu);
		}
	}

	public static void _0023_003Dzf6onOAA_003D(Text _0023_003DzwoM5BItqUr456WVQvQ_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbText odDbText = OdDbText.createObject();
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbText);
		odDbText.setTextString(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D.TextString);
		odDbText.setPosition(OdGePoint3d.kOrigin);
		odDbText.setWidthFactor(_0023_003DzsjHGnhaUpbgq(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D.WidthFactor, _0023_003DzwoM5BItqUr456WVQvQ_003D_003D.StyleName, _0023_003DzwzL57J6ueMIu._0023_003Dz_0024FFVZEHAUJk7()));
		odDbText.setHeight(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D.Height);
		WriteDatabase._0023_003DzGEpHBqC_0024YQsF4qanzQ_003D_003D(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D.Alignment, out var _0023_003Dzyzhw7idDjuhZ, out var _0023_003Dzi2NDvcXD_0024G);
		odDbText.setHorizontalMode(_0023_003Dzyzhw7idDjuhZ);
		odDbText.setVerticalMode(_0023_003Dzi2NDvcXD_0024G);
		odDbText.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D));
		odDbText.mirrorInX(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D.Backward);
		odDbText.mirrorInY(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D.UpsideDown);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D, odDbText, _0023_003DzwzL57J6ueMIu);
		odDbText.setTextStyle(_0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38[string.IsNullOrEmpty(_0023_003DzwoM5BItqUr456WVQvQ_003D_003D.StyleName) ? _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531415) : _0023_003DzwoM5BItqUr456WVQvQ_003D_003D.StyleName]);
	}

	public static void _0023_003DzHL1Tv7g_003D(Table _0023_003DzTg9ne00a53tu, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbTable odDbTable = OdDbTable.createObject();
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbTable);
		odDbTable.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		odDbTable.setNumRows((uint)_0023_003DzTg9ne00a53tu.RowsNum);
		odDbTable.setNumColumns((uint)_0023_003DzTg9ne00a53tu.ColumnsNum);
		odDbTable.setPosition(OdGePoint3d.kOrigin);
		odDbTable.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzTg9ne00a53tu));
		odDbTable.setFlowDirection((_0023_003DzTg9ne00a53tu.Direction != Table.flowDirection.Down) ? OdDb_FlowDirection.kBtoT : OdDb_FlowDirection.kTtoB);
		for (uint num = 0u; num < _0023_003DzTg9ne00a53tu.RowsNum; num++)
		{
			odDbTable.setRowHeight(num, _0023_003DzTg9ne00a53tu.RowsHeights[num]);
		}
		for (uint num2 = 0u; num2 < _0023_003DzTg9ne00a53tu.ColumnsNum; num2++)
		{
			odDbTable.setColumnWidth(num2, _0023_003DzTg9ne00a53tu.ColumnsWidths[num2]);
		}
		odDbTable.setHorzCellMargin(_0023_003DzTg9ne00a53tu.HorCellMargin);
		odDbTable.setVertCellMargin(_0023_003DzTg9ne00a53tu.VerCellMargin);
		for (int i = 0; i < _0023_003DzTg9ne00a53tu.RowsNum; i++)
		{
			for (int j = 0; j < _0023_003DzTg9ne00a53tu.ColumnsNum; j++)
			{
				odDbTable.setTextString((uint)i, (uint)j, _0023_003DzTg9ne00a53tu.GetTextString(i, j));
				odDbTable.setTextHeight((uint)i, (uint)j, _0023_003DzTg9ne00a53tu.GetTextHeight(i, j));
				odDbTable.setTextStyle((uint)i, (uint)j, _0023_003DzwzL57J6ueMIu._0023_003Dz4c0qJg8waJ38[string.IsNullOrEmpty(_0023_003DzTg9ne00a53tu.GetStyleName(i, j)) ? _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355531415) : _0023_003DzTg9ne00a53tu.GetStyleName(i, j)]);
				odDbTable.setAlignment((uint)i, (uint)j, WriteDatabase._0023_003DzCZ9Tx9YR6Cws(_0023_003DzTg9ne00a53tu.GetAlignment(i, j)));
				if (_0023_003DzTg9ne00a53tu.IsMerged(i, j) && !odDbTable.isMergedCell((uint)i, (uint)j))
				{
					_0023_003DzTg9ne00a53tu.MergeRange(i, j, out var minRow, out var minCol, out var maxRow, out var maxCol);
					odDbTable.mergeCells((uint)minRow, (uint)maxRow, (uint)minCol, (uint)maxCol);
				}
			}
		}
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzTg9ne00a53tu, odDbTable, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DzFdkhqi0_003D(Triangle _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbFace odDbFace = OdDbFace.createObject();
		odDbFace.setVertexAt(0, new OdGePoint3d(_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[0].X, _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[0].Y, _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[0].Z));
		odDbFace.setVertexAt(1, new OdGePoint3d(_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[1].X, _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[1].Y, _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[1].Z));
		odDbFace.setVertexAt(2, new OdGePoint3d(_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[2].X, _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[2].Y, _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[2].Z));
		odDbFace.setVertexAt(3, new OdGePoint3d(_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[2].X, _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[2].Y, _0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.Vertices[2].Z));
		if ((_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.VisibleEdgeFlag & 1) != 0)
		{
			odDbFace.makeEdgeVisibleAt(0);
		}
		else
		{
			odDbFace.makeEdgeInvisibleAt(0);
		}
		if ((_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.VisibleEdgeFlag & 2) != 0)
		{
			odDbFace.makeEdgeVisibleAt(1);
		}
		else
		{
			odDbFace.makeEdgeInvisibleAt(1);
		}
		if ((_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.VisibleEdgeFlag & 4) != 0)
		{
			odDbFace.makeEdgeVisibleAt(2);
		}
		else
		{
			odDbFace.makeEdgeInvisibleAt(2);
		}
		if ((_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D.VisibleEdgeFlag & 4) != 0)
		{
			odDbFace.makeEdgeVisibleAt(3);
		}
		else
		{
			odDbFace.makeEdgeInvisibleAt(3);
		}
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbFace);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dz3VfymRb3fNCHwBCrYg_003D_003D, odDbFace, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DzGTQiltzhkZt3(FemMesh _0023_003Dz1hz5kjuy8m3HQxofisYHbFk_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		_0023_003DzwlUm98KZEubL(_0023_003Dz1hz5kjuy8m3HQxofisYHbFk_003D.ConvertToMesh(includeDisplacements: false), _0023_003DzwzL57J6ueMIu, _0023_003DzIzeJ4Qs_003D, _0023_003Dz_0024cU8x9g_003D);
	}

	public static void _0023_003DzF0K9Edc_003D(Mesh _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		if (_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices == null || _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices.Length == 0 || _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles == null || _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles.Length == 0)
		{
			return;
		}
		OdDbSubDMesh odDbSubDMesh = OdDbSubDMesh.createObject();
		if (_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords == null || ((_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.MeshNature != Mesh.natureType.RichPlain || ((RichTriangle)_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles[0]).T1 == -1) && (_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.MeshNature != Mesh.natureType.RichSmooth || ((RichSmoothTriangle)_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles[0]).T1 == -1)))
		{
			if (_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.MeshNature == Mesh.natureType.ColorPlain || _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.MeshNature == Mesh.natureType.ColorSmooth)
			{
				OdGePoint3dArray odGePoint3dArray = OdGePoint3dArray.Repeat(OdGePoint3d.kOrigin, _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles.Length * 3);
				OdInt32Array odInt32Array = OdInt32Array.Repeat(0, _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles.Length * 4);
				OdCmEntityColorArray odCmEntityColorArray = OdCmEntityColorArray.Repeat(new OdCmEntityColor(0, 0, 0), _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles.Length * 3);
				int num = 0;
				int num2 = 0;
				if (_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.MeshNature == Mesh.natureType.ColorPlain)
				{
					IndexTriangle[] triangles = _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles;
					for (int i = 0; i < triangles.Length; i++)
					{
						ColorTriangle colorTriangle = (ColorTriangle)triangles[i];
						odInt32Array[num2++] = 3;
						odInt32Array[num2++] = num;
						odInt32Array[num2++] = num + 1;
						odInt32Array[num2++] = num + 2;
						odGePoint3dArray[num] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[colorTriangle.V1]);
						odCmEntityColorArray[num++] = new OdCmEntityColor(colorTriangle.R, colorTriangle.G, colorTriangle.B);
						odGePoint3dArray[num] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[colorTriangle.V2]);
						odCmEntityColorArray[num++] = new OdCmEntityColor(colorTriangle.R, colorTriangle.G, colorTriangle.B);
						odGePoint3dArray[num] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[colorTriangle.V3]);
						odCmEntityColorArray[num++] = new OdCmEntityColor(colorTriangle.R, colorTriangle.G, colorTriangle.B);
					}
				}
				else
				{
					IndexTriangle[] triangles = _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles;
					for (int i = 0; i < triangles.Length; i++)
					{
						ColorSmoothTriangle colorSmoothTriangle = (ColorSmoothTriangle)triangles[i];
						odInt32Array[num2++] = 3;
						odInt32Array[num2++] = num;
						odInt32Array[num2++] = num + 1;
						odInt32Array[num2++] = num + 2;
						odGePoint3dArray[num] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[colorSmoothTriangle.V1]);
						odCmEntityColorArray[num++] = new OdCmEntityColor(colorSmoothTriangle.R, colorSmoothTriangle.G, colorSmoothTriangle.B);
						odGePoint3dArray[num] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[colorSmoothTriangle.V2]);
						odCmEntityColorArray[num++] = new OdCmEntityColor(colorSmoothTriangle.R, colorSmoothTriangle.G, colorSmoothTriangle.B);
						odGePoint3dArray[num] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[colorSmoothTriangle.V3]);
						odCmEntityColorArray[num++] = new OdCmEntityColor(colorSmoothTriangle.R, colorSmoothTriangle.G, colorSmoothTriangle.B);
					}
				}
				odDbSubDMesh.setSubDMesh(odGePoint3dArray, odInt32Array, 0);
				odDbSubDMesh.setVertexColorArray(odCmEntityColorArray);
			}
			else
			{
				OdGePoint3dArray odGePoint3dArray2 = OdGePoint3dArray.Repeat(OdGePoint3d.kOrigin, _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices.Length);
				for (int j = 0; j < _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices.Length; j++)
				{
					odGePoint3dArray2[j] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[j]);
				}
				OdInt32Array odInt32Array2 = OdInt32Array.Repeat(0, _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles.Length * 4);
				int num3 = 0;
				IndexTriangle[] triangles = _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles;
				foreach (IndexTriangle indexTriangle in triangles)
				{
					odInt32Array2[num3++] = 3;
					odInt32Array2[num3++] = indexTriangle.V1;
					odInt32Array2[num3++] = indexTriangle.V2;
					odInt32Array2[num3++] = indexTriangle.V3;
				}
				odDbSubDMesh.setSubDMesh(odGePoint3dArray2, odInt32Array2, 0);
				if (_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.MeshNature == Mesh.natureType.MulticolorPlain || _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.MeshNature == Mesh.natureType.MulticolorSmooth)
				{
					OdCmEntityColorArray odCmEntityColorArray2 = OdCmEntityColorArray.Repeat(new OdCmEntityColor(0, 0, 0), _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices.Length);
					for (int k = 0; k < _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices.Length; k++)
					{
						PointRGB pointRGB = _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[k] as PointRGB;
						odCmEntityColorArray2[k] = new OdCmEntityColor(pointRGB.R, pointRGB.G, pointRGB.B);
					}
					odDbSubDMesh.setVertexColorArray(odCmEntityColorArray2);
				}
			}
		}
		else
		{
			OdGePoint3dArray odGePoint3dArray3 = OdGePoint3dArray.Repeat(OdGePoint3d.kOrigin, _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles.Length * 3);
			OdInt32Array odInt32Array3 = OdInt32Array.Repeat(0, _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles.Length * 4);
			OdGePoint3dArray odGePoint3dArray4 = OdGePoint3dArray.Repeat(OdGePoint3d.kOrigin, _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles.Length * 3);
			int num4 = 0;
			int num5 = 0;
			if (_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.MeshNature == Mesh.natureType.RichPlain)
			{
				IndexTriangle[] triangles = _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles;
				for (int i = 0; i < triangles.Length; i++)
				{
					RichTriangle richTriangle = (RichTriangle)triangles[i];
					odInt32Array3[num5++] = 3;
					odInt32Array3[num5++] = num4;
					odInt32Array3[num5++] = num4 + 1;
					odInt32Array3[num5++] = num4 + 2;
					odGePoint3dArray3[num4] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[richTriangle.V1]);
					odGePoint3dArray4[num4++] = new OdGePoint3d(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richTriangle.T1].X, 0f - _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richTriangle.T1].Y, 0.0);
					odGePoint3dArray3[num4] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[richTriangle.V2]);
					odGePoint3dArray4[num4++] = new OdGePoint3d(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richTriangle.T2].X, 0f - _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richTriangle.T2].Y, 0.0);
					odGePoint3dArray3[num4] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[richTriangle.V3]);
					odGePoint3dArray4[num4++] = new OdGePoint3d(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richTriangle.T3].X, 0f - _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richTriangle.T3].Y, 0.0);
				}
			}
			else
			{
				IndexTriangle[] triangles = _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Triangles;
				for (int i = 0; i < triangles.Length; i++)
				{
					RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)triangles[i];
					odInt32Array3[num5++] = 3;
					odInt32Array3[num5++] = num4;
					odInt32Array3[num5++] = num4 + 1;
					odInt32Array3[num5++] = num4 + 2;
					odGePoint3dArray3[num4] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[richSmoothTriangle.V1]);
					odGePoint3dArray4[num4++] = new OdGePoint3d(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richSmoothTriangle.T1].X, 0f - _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richSmoothTriangle.T1].Y, 0.0);
					odGePoint3dArray3[num4] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[richSmoothTriangle.V2]);
					odGePoint3dArray4[num4++] = new OdGePoint3d(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richSmoothTriangle.T2].X, 0f - _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richSmoothTriangle.T2].Y, 0.0);
					odGePoint3dArray3[num4] = _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.Vertices[richSmoothTriangle.V3]);
					odGePoint3dArray4[num4++] = new OdGePoint3d(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richSmoothTriangle.T3].X, 0f - _0023_003DzMdbu3szfRDGgIdpInQ_003D_003D.TextureCoords[richSmoothTriangle.T3].Y, 0.0);
				}
			}
			odDbSubDMesh.setSubDMesh(odGePoint3dArray3, odInt32Array3, 0);
			odDbSubDMesh.setVertexTextureArray(odGePoint3dArray4);
		}
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbSubDMesh);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzMdbu3szfRDGgIdpInQ_003D_003D, odDbSubDMesh, _0023_003DzwzL57J6ueMIu);
	}

	public static void _0023_003DzXftVuQY_003D(Curve _0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbSpline odDbSpline = _0023_003DznePMAOoALItB(_0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D);
		if (_0023_003DzwzL57J6ueMIu._0023_003Dz1iDsSuYGoT3xz1G6CQ_003D_003D)
		{
			odDbSpline.setType(OdDbSpline_SplineType.kFitPoints);
		}
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D, odDbSpline, _0023_003DzwzL57J6ueMIu);
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbSpline);
	}

	public static OdDbSpline _0023_003DznePMAOoALItB(Curve _0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D)
	{
		OdGePoint3dArray odGePoint3dArray = new OdGePoint3dArray(_0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.ControlPoints.Length);
		OdDoubleArray odDoubleArray = new OdDoubleArray(_0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.ControlPoints.Length);
		for (int i = 0; i < _0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.ControlPoints.Length; i++)
		{
			Point4D point4D = _0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.ControlPoints[i];
			double w = point4D.W;
			odGePoint3dArray.Add(new OdGePoint3d(point4D.X / w, point4D.Y / w, point4D.Z / w));
			odDoubleArray.Add(w);
		}
		OdDoubleArray odDoubleArray2 = new OdDoubleArray(_0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.KnotVector);
		OdDbSpline odDbSpline = OdDbSpline.createObject();
		double num = _0023_003DziX5N9BwbH_Uie7M5Ig_003D_003D(odDoubleArray2, _0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.Degree);
		odDbSpline.setNurbsData(knotTol: Math.Min(1E-09, num * 0.11), degree: _0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.Degree, rational: _0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.IsRational, closed: _0023_003Dz3chZSyvUK7h1a8MeMQ_003D_003D.IsClosed, periodic: false, controlPoints: odGePoint3dArray, knots: odDoubleArray2, weights: odDoubleArray, controlPtTol: 1E-09);
		return odDbSpline;
	}

	private static double _0023_003DziX5N9BwbH_Uie7M5Ig_003D_003D(OdDoubleArray _0023_003DzWvuQui4uqobe, int _0023_003DzHdXT5FuCqbdBi0PsaQ_003D_003D)
	{
		double num = double.MaxValue;
		int num2 = _0023_003DzWvuQui4uqobe.Count - _0023_003DzHdXT5FuCqbdBi0PsaQ_003D_003D;
		for (int i = _0023_003DzHdXT5FuCqbdBi0PsaQ_003D_003D; i < num2 - 1; i++)
		{
			double num3 = _0023_003DzWvuQui4uqobe[i];
			double num4 = _0023_003DzWvuQui4uqobe[i + 1];
			if (num3 != num4 && num4 - num3 < num)
			{
				num = num4 - num3;
			}
		}
		return num;
	}

	public static void _0023_003DzogJby4P2KJD0yDuA1gh5gHY_003D(Brep _0023_003Dz5mlnaEE_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzIzeJ4Qs_003D, CancellationToken _0023_003Dz_0024cU8x9g_003D)
	{
		Surface[] array = _0023_003Dz5mlnaEE_003D.ConvertToSurfaces();
		for (int i = 0; i < array.Length; i++)
		{
			_0023_003DzbbsUqVw_003D(array[i], _0023_003DzwzL57J6ueMIu);
		}
	}

	public static void _0023_003DzC92S9PtGQjOP(Brep _0023_003DzN4OvCljLe81t, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		if (!_0023_003DzwzL57J6ueMIu._0023_003Dzhf6uXz_0024l6dpO)
		{
			_0023_003DzF0K9Edc_003D(_0023_003DzN4OvCljLe81t.ConvertToMesh(), _0023_003DzwzL57J6ueMIu);
			return;
		}
		OdRxObject odRxObject = _0023_003DzLE9SnlA_003D(_0023_003DzN4OvCljLe81t, _0023_003DzwzL57J6ueMIu);
		if (odRxObject != null)
		{
			OdDb3dSolid odDb3dSolid = OdDb3dSolid.createObject();
			odDb3dSolid.setBody(OdRxObject.getCPtr(odRxObject).Handle);
			odDb3dSolid.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
			_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDb3dSolid);
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzN4OvCljLe81t, odDb3dSolid, _0023_003DzwzL57J6ueMIu);
		}
	}

	private static OdRxObject _0023_003DzLE9SnlA_003D(Brep _0023_003DzN4OvCljLe81t, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdRxObject odRxObject = null;
		OdBrepBuilder odBrepBuilder = new OdBrepBuilder();
		try
		{
			OdDbHostAppServices odDbHostAppServices = _0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh().appServices();
			BrepType bbType = (_0023_003DzN4OvCljLe81t.IsClosed ? BrepType.kSolid : BrepType.kOpenShell);
			odDbHostAppServices.BrepBuilder(odBrepBuilder, bbType);
			uint complexId = odBrepBuilder.addComplex();
			uint[] array = new uint[_0023_003DzN4OvCljLe81t.Edges.Length];
			for (int i = 0; i < _0023_003DzN4OvCljLe81t.Edges.Length; i++)
			{
				OdGeCurve3d odGeCurve3d = _0023_003DzVd06aGA_YONM(_0023_003DzN4OvCljLe81t.Edges[i].Curve);
				GC.SuppressFinalize(odGeCurve3d);
				array[i] = odBrepBuilder.addEdge(odGeCurve3d);
			}
			_0023_003DzN4OvCljLe81t.Rebuild(0.0, soft: true);
			uint num = odBrepBuilder.addShell(complexId);
			for (int j = 0; j < _0023_003DzN4OvCljLe81t.Faces.Length; j++)
			{
				_0023_003Dz4FIwYbA_003D(_0023_003DzN4OvCljLe81t, _0023_003DzN4OvCljLe81t.Faces[j], odBrepBuilder, num, array);
			}
			odBrepBuilder.finishShell(num);
			for (int k = 0; k < _0023_003DzN4OvCljLe81t.Inners.Length; k++)
			{
				Brep.Face[] array2 = _0023_003DzN4OvCljLe81t.Inners[k];
				num = odBrepBuilder.addShell(complexId);
				for (int l = 0; l < array2.Length; l++)
				{
					_0023_003Dz4FIwYbA_003D(_0023_003DzN4OvCljLe81t, array2[l], odBrepBuilder, num, array);
				}
				odBrepBuilder.finishShell(num);
			}
			odBrepBuilder.finishComplex(complexId);
			odBrepBuilder.enableValidator(bEnable: false);
			return odBrepBuilder.finish();
		}
		finally
		{
			((IDisposable)odBrepBuilder).Dispose();
		}
	}

	private static void _0023_003Dz4FIwYbA_003D(Brep _0023_003DzN4OvCljLe81t, Brep.Face _0023_003Dz_fXSZgFEGKvR, OdBrepBuilder _0023_003DzAO8PC6P_iC6DFBnLqQ_003D_003D, uint _0023_003Dzm_0024hmsNw_003D, uint[] _0023_003DzErfyJNR_0024cBz8)
	{
		bool _0023_003Dz3IC2S4ZFN5X8_0024Hs8Mg_003D_003D;
		Surface _0023_003DzVUeVoMA6ouGB;
		OdGeSurface odGeSurface = _0023_003Dz2maR2N3hL44t(_0023_003Dz_fXSZgFEGKvR, out _0023_003Dz3IC2S4ZFN5X8_0024Hs8Mg_003D_003D, out _0023_003DzVUeVoMA6ouGB);
		if (odGeSurface == null)
		{
			return;
		}
		GC.SuppressFinalize(odGeSurface);
		OdBrepBuilder_EntityDirection faceDirection = OdBrepBuilder_EntityDirection.kForward;
		if (!_0023_003Dz3IC2S4ZFN5X8_0024Hs8Mg_003D_003D)
		{
			faceDirection = ((!_0023_003Dz_fXSZgFEGKvR.Sense) ? OdBrepBuilder_EntityDirection.kReversed : OdBrepBuilder_EntityDirection.kForward);
		}
		uint faceId = _0023_003DzAO8PC6P_iC6DFBnLqQ_003D_003D.addFace(odGeSurface, faceDirection, _0023_003Dzm_0024hmsNw_003D);
		for (int i = 0; i < _0023_003Dz_fXSZgFEGKvR.Loops.Length; i++)
		{
			Brep.Loop obj = _0023_003Dz_fXSZgFEGKvR.Loops[i];
			uint loopId = _0023_003DzAO8PC6P_iC6DFBnLqQ_003D_003D.addLoop(faceId);
			Brep.OrientedEdge[] array = obj.Segments;
			bool sense = obj.Sense;
			if (!sense)
			{
				Brep.OrientedEdge[] array2 = new Brep.OrientedEdge[array.Length];
				Array.Copy(array, array2, array.Length);
				Array.Reverse(array2);
				array = array2;
			}
			if (_0023_003Dz3IC2S4ZFN5X8_0024Hs8Mg_003D_003D && _0023_003DzX1UbHMniT8A_m_0024cafQ_003D_003D(_0023_003DzN4OvCljLe81t, new Surface[1] { _0023_003DzVUeVoMA6ouGB }, _0023_003Dz_fXSZgFEGKvR.Sense, i, array, sense, out var _0023_003DzlNbzynB_nMqc, out var _0023_003Dz22h3lQvNNW_w))
			{
				int num = _0023_003Dz22h3lQvNNW_w;
				for (int j = 0; j < array.Length; j++)
				{
					Brep.OrientedEdge orientedEdge = array[j];
					TrimCurve trimCurve = (TrimCurve)_0023_003DzlNbzynB_nMqc[num];
					while (trimCurve.EdgeIndex == -1)
					{
						num = (num + 1) % _0023_003DzlNbzynB_nMqc.Length;
						trimCurve = (TrimCurve)_0023_003DzlNbzynB_nMqc[num];
					}
					bool flag = sense == array[j].Sense;
					OdBrepBuilder_EntityDirection codgeDirection = ((!flag) ? OdBrepBuilder_EntityDirection.kReversed : OdBrepBuilder_EntityDirection.kForward);
					OdGeNurbCurve2d pParCur = _0023_003DzVikhjflOf6hTa85JQCZAj_0024k_003D(trimCurve, flag);
					_0023_003DzAO8PC6P_iC6DFBnLqQ_003D_003D.addCoedge(loopId, _0023_003DzErfyJNR_0024cBz8[orientedEdge.CurveIndex], codgeDirection, pParCur);
					num = (num + 1) % _0023_003DzlNbzynB_nMqc.Length;
				}
			}
			else
			{
				for (int k = 0; k < array.Length; k++)
				{
					OdBrepBuilder_EntityDirection codgeDirection2 = ((sense != array[k].Sense) ? OdBrepBuilder_EntityDirection.kReversed : OdBrepBuilder_EntityDirection.kForward);
					_0023_003DzAO8PC6P_iC6DFBnLqQ_003D_003D.addCoedge(loopId, _0023_003DzErfyJNR_0024cBz8[array[k].CurveIndex], codgeDirection2);
				}
			}
			_0023_003DzAO8PC6P_iC6DFBnLqQ_003D_003D.finishLoop(loopId);
		}
		_0023_003DzAO8PC6P_iC6DFBnLqQ_003D_003D.finishFace(faceId);
	}

	private static bool _0023_003DzX1UbHMniT8A_m_0024cafQ_003D_003D(Brep _0023_003DzN4OvCljLe81t, Surface[] _0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D, bool _0023_003Dz1ny9JWx_0024Z2Qs, int _0023_003DzPqe3X00_003D, Brep.OrientedEdge[] _0023_003DzkospZzhpWzK7, bool _0023_003DzxIcrdl1Cx3QE, out ICurve[] _0023_003DzlNbzynB_nMqc, out int _0023_003Dz22h3lQvNNW_w)
	{
		_0023_003DzlNbzynB_nMqc = null;
		_0023_003Dz22h3lQvNNW_w = -1;
		if (_0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D == null || _0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D.Length != 1)
		{
			return false;
		}
		devDept.Eyeshot.Entities.Region region = (devDept.Eyeshot.Entities.Region)_0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D[0].Trimming.Clone();
		int count = region.ContourList.Count;
		for (int i = 0; i < count; i++)
		{
			if (_0023_003Dz22h3lQvNNW_w >= 0)
			{
				break;
			}
			_0023_003DzlNbzynB_nMqc = region.ContourList[(_0023_003DzPqe3X00_003D + i) % count].GetIndividualCurves();
			_0023_003Dz22h3lQvNNW_w = _0023_003DzvVynZ0iQgKBi(_0023_003DzN4OvCljLe81t, _0023_003DzlNbzynB_nMqc, _0023_003DzkospZzhpWzK7, _0023_003DzxIcrdl1Cx3QE);
		}
		if (_0023_003Dz22h3lQvNNW_w < 0)
		{
			return false;
		}
		_0023_003Dzv6x0wSLelixTn6lpLOy0ACdmvesi(_0023_003DzlNbzynB_nMqc, _0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D[0], _0023_003Dz1ny9JWx_0024Z2Qs);
		return true;
	}

	private static void _0023_003Dzv6x0wSLelixTn6lpLOy0ACdmvesi(ICurve[] _0023_003DzMiCmVZLDYu69, Surface _0023_003DzJI7CflwHoIG1, bool _0023_003Dz1ny9JWx_0024Z2Qs)
	{
		if (!(_0023_003DzJI7CflwHoIG1 is ToroidalSurface) && !(_0023_003DzJI7CflwHoIG1 is SphericalSurface) && !(_0023_003DzJI7CflwHoIG1 is ConicalSurface) && _0023_003DzJI7CflwHoIG1 is CylindricalSurface cylindricalSurface)
		{
			Transformation xform = new Mirror(new Plane(Point3D.Origin, new Vector3D(1.0, -1.0, 0.0)));
			if (Vector3D.Dot(((Line)cylindricalSurface.Generatrix).StartTangent, cylindricalSurface.Axis) < 0.0)
			{
				Mirror mirror = new Mirror(Plane.ZX);
				xform *= (Transformation)mirror;
			}
			for (int i = 0; i < _0023_003DzMiCmVZLDYu69.Length; i++)
			{
				TrimCurve obj = (TrimCurve)_0023_003DzMiCmVZLDYu69[i];
				obj.Scale(Point3D.Origin, 1.0, 1.0 / cylindricalSurface.Radius);
				obj.TransformBy(xform);
			}
		}
	}

	private static int _0023_003DzvVynZ0iQgKBi(Brep _0023_003DzN4OvCljLe81t, ICurve[] _0023_003DzlNbzynB_nMqc, Brep.OrientedEdge[] _0023_003DzkospZzhpWzK7, bool _0023_003DzxIcrdl1Cx3QE)
	{
		int curveIndex = _0023_003DzkospZzhpWzK7[0].CurveIndex;
		int result = -1;
		for (int i = 0; i < _0023_003DzlNbzynB_nMqc.Length; i++)
		{
			ICurve curve = _0023_003DzlNbzynB_nMqc[i];
			if (curve.EdgeIndex == curveIndex)
			{
				if (_0023_003DzN4OvCljLe81t.Edges[curveIndex].Parents.Length <= 1 || _0023_003DzN4OvCljLe81t.Edges[curveIndex].Parents[0] != _0023_003DzN4OvCljLe81t.Edges[curveIndex].Parents[1])
				{
					result = i;
					break;
				}
				ICurve curve2 = _0023_003DzN4OvCljLe81t.Edges[curveIndex].Curve;
				ICurve edge = ((TrimCurve)curve).Edge;
				bool flag = ((!curve2.IsClosed) ? Point3D.AreEqual(curve2.StartPoint, edge.StartPoint, curve2.Domain.Length) : Vector3D.AreCoincident(curve2.StartTangent, edge.StartTangent));
				if (flag == (_0023_003DzxIcrdl1Cx3QE == _0023_003DzkospZzhpWzK7[0].Sense))
				{
					result = i;
					break;
				}
			}
		}
		return result;
	}

	private static OdGeNurbCurve2d _0023_003DzVikhjflOf6hTa85JQCZAj_0024k_003D(TrimCurve _0023_003DzPsHQ3sY_003D, bool _0023_003DzvolsHOo_003D)
	{
		if (!_0023_003DzvolsHOo_003D)
		{
			_0023_003DzPsHQ3sY_003D = (TrimCurve)_0023_003DzPsHQ3sY_003D.Clone();
			_0023_003DzPsHQ3sY_003D.Reverse();
		}
		OdGePoint2dArray odGePoint2dArray = new OdGePoint2dArray();
		OdDoubleArray odDoubleArray = new OdDoubleArray();
		for (int i = 0; i < _0023_003DzPsHQ3sY_003D.ControlPoints.Length; i++)
		{
			Point4D point4D = _0023_003DzPsHQ3sY_003D.ControlPoints[i];
			odGePoint2dArray.Add(new OdGePoint2d(point4D.X / point4D.W, point4D.Y / point4D.W));
			odDoubleArray.Add(point4D.W);
		}
		OdGeKnotVector odGeKnotVector = new OdGeKnotVector();
		double[] array = new double[_0023_003DzPsHQ3sY_003D.KnotVector.Length];
		Array.Copy(_0023_003DzPsHQ3sY_003D.KnotVector, array, _0023_003DzPsHQ3sY_003D.KnotVector.Length);
		array.Offset(0.0 - _0023_003DzPsHQ3sY_003D.Domain.Low);
		array.Scale(_0023_003DzPsHQ3sY_003D.Edge.Domain.Length / _0023_003DzPsHQ3sY_003D.Domain.Length);
		array.Offset(_0023_003DzPsHQ3sY_003D.Edge.Domain.Low);
		for (int j = 0; j < array.Length; j++)
		{
			odGeKnotVector.append(array[j]);
		}
		OdGeNurbCurve2d odGeNurbCurve2d = new OdGeNurbCurve2d(_0023_003DzPsHQ3sY_003D.Degree, odGeKnotVector, odGePoint2dArray, odDoubleArray, isPeriodic: false);
		GC.SuppressFinalize(odGeNurbCurve2d);
		return odGeNurbCurve2d;
	}

	public static OdGeSurface _0023_003Dz2maR2N3hL44t(Brep.Face _0023_003Dz_fXSZgFEGKvR, out bool _0023_003Dz3IC2S4ZFN5X8_0024Hs8Mg_003D_003D, out Surface _0023_003DzVUeVoMA6ouGB)
	{
		_0023_003Dz3IC2S4ZFN5X8_0024Hs8Mg_003D_003D = false;
		_0023_003DzVUeVoMA6ouGB = null;
		AnalyticSurf surface = _0023_003Dz_fXSZgFEGKvR.Surface;
		if (!(surface is ConicalSurf { Radius: var radius } conicalSurf))
		{
			if (!(surface is SphericalSurf sphericalSurf))
			{
				if (!(surface is CylindricalSurf cylindricalSurf))
				{
					if (!(surface is TabulatedSurf tabulatedSurf))
					{
						if (!(surface is RevolvedSurf) && !(surface is NurbsSurf))
						{
							if (!(surface is ToroidalSurf toroidalSurf))
							{
								if (surface is PlanarSurf planarSurf)
								{
									return _0023_003DzaSRNkR7Ee8BuMye9CQ_003D_003D(planarSurf.Plane);
								}
								return null;
							}
							return new OdGeTorus(toroidalSurf.MajorRadius, toroidalSurf.MinorRadius, _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(toroidalSurf.Plane.Origin), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(toroidalSurf.Plane.AxisZ));
						}
						_0023_003Dz3IC2S4ZFN5X8_0024Hs8Mg_003D_003D = true;
						return _0023_003Dz5_gCQ6aC_n8I2g6F4A_003D_003D(_0023_003Dz_fXSZgFEGKvR.Parametric, out _0023_003DzVUeVoMA6ouGB);
					}
					Vector3D vector3D = (Vector3D)tabulatedSurf.Generatrix.Clone();
					vector3D.Normalize();
					if (tabulatedSurf.Directrix is Circle circle)
					{
						if (Vector3D.AreCoincident(vector3D, circle.Plane.AxisZ))
						{
							return new OdGeCylinder(circle.Radius, _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(circle.Center), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(vector3D));
						}
						if (Vector3D.AreOpposite(vector3D, circle.Plane.AxisZ))
						{
							OdGeCylinder odGeCylinder = new OdGeCylinder(circle.Radius, _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(circle.Center), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(vector3D));
							odGeCylinder.setIsOuterNormal(isOuterNormal: false);
							return odGeCylinder;
						}
					}
					if (Utility.IsLine(tabulatedSurf.Directrix))
					{
						return _0023_003DzaSRNkR7Ee8BuMye9CQ_003D_003D(new Plane(tabulatedSurf.Directrix.StartPoint, tabulatedSurf.Directrix.StartTangent, vector3D));
					}
					_0023_003Dz3IC2S4ZFN5X8_0024Hs8Mg_003D_003D = true;
					return _0023_003Dz5_gCQ6aC_n8I2g6F4A_003D_003D(_0023_003Dz_fXSZgFEGKvR.Parametric, out _0023_003DzVUeVoMA6ouGB);
				}
				return new OdGeCylinder(cylindricalSurf.Radius, _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(cylindricalSurf.Plane.Origin), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(cylindricalSurf.Plane.AxisZ), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(cylindricalSurf.Plane.AxisX), new OdGeInterval(0.0, 50.0), 0.0, Math.PI * 2.0);
			}
			return new OdGeSphere(sphericalSurf.Radius, _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(sphericalSurf.Plane.Origin), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(sphericalSurf.Plane.AxisZ), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(sphericalSurf.Plane.AxisX), 0.0, Math.PI * 2.0, -Math.PI / 2.0, Math.PI / 2.0);
		}
		Point3D origin = conicalSurf.Plane.Origin;
		if (radius == 0.0)
		{
			if (_0023_003Dz_fXSZgFEGKvR.Parametric == null || _0023_003Dz_fXSZgFEGKvR.Parametric.Length == 0)
			{
				return null;
			}
			ConicalSurface obj = (ConicalSurface)_0023_003Dz_fXSZgFEGKvR.Parametric[0];
			radius = obj.Radius;
			origin = obj.Plane.Origin;
		}
		return new OdGeCone(Math.Cos(conicalSurf.HalfAngle), Math.Sin(conicalSurf.HalfAngle), _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(origin), radius, _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(conicalSurf.Plane.AxisZ));
	}

	private static OdGeSurface _0023_003Dz5_gCQ6aC_n8I2g6F4A_003D_003D(Surface[] _0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D, out Surface _0023_003DzDVlYjp3Ov677CIbp3g_003D_003D)
	{
		_0023_003DzDVlYjp3Ov677CIbp3g_003D_003D = null;
		if (_0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D != null && _0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D.Length != 0)
		{
			Surface surface = _0023_003Dz7xMFcHzh_v3qOZDDhw_003D_003D[0];
			_0023_003DzDVlYjp3Ov677CIbp3g_003D_003D = surface.GetGeneric();
			return _0023_003Dz5_gCQ6aC_n8I2g6F4A_003D_003D(new NurbsSurf(_0023_003DzDVlYjp3Ov677CIbp3g_003D_003D.DegreeU, _0023_003DzDVlYjp3Ov677CIbp3g_003D_003D.KnotVectorU, _0023_003DzDVlYjp3Ov677CIbp3g_003D_003D.DegreeV, _0023_003DzDVlYjp3Ov677CIbp3g_003D_003D.KnotVectorV, _0023_003DzDVlYjp3Ov677CIbp3g_003D_003D.ControlPoints));
		}
		return null;
	}

	public static OdGeNurbSurface _0023_003Dz5_gCQ6aC_n8I2g6F4A_003D_003D(NurbsSurf _0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D)
	{
		OdGePoint3dArray odGePoint3dArray = new OdGePoint3dArray();
		OdDoubleArray odDoubleArray = new OdDoubleArray();
		int length = _0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.ControlPoints.GetLength(0);
		int length2 = _0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.ControlPoints.GetLength(1);
		for (int i = 0; i < length; i++)
		{
			for (int j = 0; j < length2; j++)
			{
				Point4D point4D = _0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.ControlPoints[i, j];
				odGePoint3dArray.Add(new OdGePoint3d(point4D.X / point4D.W, point4D.Y / point4D.W, point4D.Z / point4D.W));
				odDoubleArray.Add(point4D.W);
			}
		}
		OdGeKnotVector odGeKnotVector = new OdGeKnotVector();
		for (int k = 0; k < _0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.KnotVectorU.Length; k++)
		{
			odGeKnotVector.append(_0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.KnotVectorU[k]);
		}
		OdGeKnotVector odGeKnotVector2 = new OdGeKnotVector();
		for (int l = 0; l < _0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.KnotVectorV.Length; l++)
		{
			odGeKnotVector2.append(_0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.KnotVectorV[l]);
		}
		OdGeNurbSurface odGeNurbSurface = new OdGeNurbSurface();
		odGeNurbSurface.set(_0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.DegreeU, _0023_003DzPQYqoPkBLAGHkE8JIg_003D_003D.DegreeV, 17, 17, length, length2, odGePoint3dArray, odDoubleArray, odGeKnotVector, odGeKnotVector2);
		GC.SuppressFinalize(odGeNurbSurface);
		return odGeNurbSurface;
	}

	public static OdGeCurve3d _0023_003DzVd06aGA_YONM(ICurve _0023_003Dzxm7lq28_003D)
	{
		if (!(_0023_003Dzxm7lq28_003D is Arc arc))
		{
			if (!(_0023_003Dzxm7lq28_003D is Circle circle))
			{
				if (!(_0023_003Dzxm7lq28_003D is Curve curve))
				{
					if (!(_0023_003Dzxm7lq28_003D is EllipticalArc ellipticalArc))
					{
						if (!(_0023_003Dzxm7lq28_003D is Ellipse ellipse))
						{
							if (!(_0023_003Dzxm7lq28_003D is Line line))
							{
								if (!(_0023_003Dzxm7lq28_003D is CompositeCurve compositeCurve))
								{
									if (_0023_003Dzxm7lq28_003D is LinearPath linearPath)
									{
										return new OdGePolyline3d(new OdGePoint3dArray(linearPath.Vertices.Select((Point3D _0023_003Dzzkz90iI_003D) => _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(_0023_003Dzzkz90iI_003D)).ToArray()));
									}
									return null;
								}
								return _0023_003DzVd06aGA_YONM(compositeCurve.GetNurbsForm());
							}
							return new OdGeLineSeg3d(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(line.StartPoint), _0023_003DzbhysZL9VFmRcYmsohA_003D_003D(line.EndPoint));
						}
						return new OdGeEllipArc3d(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(ellipse.Center), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(ellipse.Plane.AxisX), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(ellipse.Plane.AxisY), ellipse.RadiusX, ellipse.RadiusY, 0.0, Math.PI * 2.0);
					}
					return new OdGeEllipArc3d(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(ellipticalArc.Center), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(ellipticalArc.Plane.AxisX), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(ellipticalArc.Plane.AxisY), ellipticalArc.RadiusX, ellipticalArc.RadiusY, ellipticalArc.Domain.Low, ellipticalArc.Domain.High);
				}
				OdGePoint3dArray odGePoint3dArray = new OdGePoint3dArray(curve.ControlPoints.Length);
				OdDoubleArray odDoubleArray = new OdDoubleArray(curve.ControlPoints.Length);
				for (int num = 0; num < curve.ControlPoints.Length; num++)
				{
					Point4D point4D = curve.ControlPoints[num];
					double w = point4D.W;
					odGePoint3dArray.Add(new OdGePoint3d(point4D.X / w, point4D.Y / w, point4D.Z / w));
					odDoubleArray.Add(w);
				}
				OdGeKnotVector odGeKnotVector = new OdGeKnotVector();
				for (int num2 = 0; num2 < curve.KnotVector.Length; num2++)
				{
					odGeKnotVector.append(curve.KnotVector[num2]);
				}
				return new OdGeNurbCurve3d(curve.Degree, odGeKnotVector, odGePoint3dArray, odDoubleArray, isPeriodic: false);
			}
			return new OdGeEllipArc3d(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(circle.Center), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(circle.Plane.AxisX), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(circle.Plane.AxisY), circle.Radius, circle.Radius, 0.0, Math.PI * 2.0);
		}
		return new OdGeEllipArc3d(_0023_003DzbhysZL9VFmRcYmsohA_003D_003D(arc.Center), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(arc.Plane.AxisX), _0023_003DzFKZRDbRK983DUwiTvQ_003D_003D(arc.Plane.AxisY), arc.Radius, arc.Radius, arc.Domain.Low, arc.Domain.High);
	}

	public static void _0023_003DzbbsUqVw_003D(Surface _0023_003DzvUHnuBlma4eL4ZXh_0024g_003D_003D, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		if (!_0023_003DzwzL57J6ueMIu._0023_003Dzhf6uXz_0024l6dpO)
		{
			_0023_003DzF0K9Edc_003D(_0023_003DzvUHnuBlma4eL4ZXh_0024g_003D_003D.ConvertToMesh(), _0023_003DzwzL57J6ueMIu);
			return;
		}
		OdRxObject odRxObject = _0023_003DzLE9SnlA_003D(_0023_003DzvUHnuBlma4eL4ZXh_0024g_003D_003D.ConvertToBrep(), _0023_003DzwzL57J6ueMIu);
		if (odRxObject != null)
		{
			OdDbSurface odDbSurface = OdDbSurface.createObject();
			odDbSurface.setBody(OdRxObject.getCPtr(odRxObject).Handle);
			odDbSurface.setDatabaseDefaults(_0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
			_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbSurface);
			_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzvUHnuBlma4eL4ZXh_0024g_003D_003D, odDbSurface, _0023_003DzwzL57J6ueMIu);
		}
	}

	private static IList<Entity> _0023_003DzQwvc7eZm6bj7_0024WPPVA_003D_003D(CompositeCurve _0023_003Dze4h6Ud8_003D)
	{
		List<Entity> list = new List<Entity>();
		Entity[] array = _0023_003Dze4h6Ud8_003D.Explode();
		foreach (Entity entity in array)
		{
			if (entity is CompositeCurve _0023_003Dze4h6Ud8_003D2)
			{
				list.AddRange(_0023_003DzQwvc7eZm6bj7_0024WPPVA_003D_003D(_0023_003Dze4h6Ud8_003D2));
			}
			else
			{
				list.Add(entity);
			}
		}
		return list;
	}

	private static void _0023_003Dz62WbaGfxC_0024Wq(Transformation _0023_003Dzixve3yE_003D, OdArray_OdGeCurve2d__p_OdObjectsAllocator _0023_003Dzn_l0R8cXPUy4, ICurve _0023_003DzINDBoqS9DTqw)
	{
		if (!((!(_0023_003DzINDBoqS9DTqw is Arc { Domain: { High: var high }, Domain: var domain2 })) ? ((!(_0023_003DzINDBoqS9DTqw is Circle { Domain: { High: var high2 }, Domain: var domain4 })) ? (_0023_003DzINDBoqS9DTqw.StartPoint == _0023_003DzINDBoqS9DTqw.EndPoint) : (high2 - domain4.Low - Math.PI * 2.0 < 1E-06)) : (high - domain2.Low - Math.PI * 2.0 < 1E-06)))
		{
			OdGeCurve2d val = new OdGeCurve2d(OdGeEntity2d.getCPtr(_0023_003DzX9s2QIi2V8n0Rao_0024mIdPI0s_003D(_0023_003Dzixve3yE_003D, _0023_003DzINDBoqS9DTqw.EndPoint, _0023_003DzINDBoqS9DTqw.StartPoint).copy()).Handle, cMemoryOwn: false);
			_0023_003Dzn_l0R8cXPUy4.Add(val);
		}
	}

	public static string _0023_003DzhLvZ3_00245VjPWh(Block _0023_003DzXd9oZggYYoXtTAteHA_003D_003D, string _0023_003DzyTMhpZk_003D, string _0023_003Dzxaw56Ac_003D, string _0023_003Dzb7I0m7A_003D)
	{
		if (_0023_003DzXd9oZggYYoXtTAteHA_003D_003D.FilePath != null && _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.FilePath.EndsWith(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517483), StringComparison.InvariantCultureIgnoreCase))
		{
			return _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.FilePath;
		}
		return _0023_003DzyTMhpZk_003D + _0023_003Dzxaw56Ac_003D + _0023_003Dzb7I0m7A_003D;
	}

	public static void _0023_003DzgJEJwi0_003D(Block _0023_003DzXd9oZggYYoXtTAteHA_003D_003D, Dictionary<string, string> _0023_003DzfzI8lTwK6mEA, string _0023_003Dzl71fdKt0StRM, string _0023_003DzryxhWHI7gZWb, autodeskVersionType _0023_003Dz2lUs5iI_003D, string _0023_003Dzr8rfJIs_003D, double _0023_003DzgAG3_0024qr8f0qqs6z5vQ_003D_003D, LayerKeyedCollection _0023_003Dz68IvW_AooqDP, BlockKeyedCollection _0023_003DzFyBLmv3KS6Nt, TextStyleKeyedCollection _0023_003Dzc3aLSLYhP84G, LineTypeKeyedCollection _0023_003Dziw5fCBSsasyX, MaterialKeyedCollection _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, attributeReferenceVisibilityType _0023_003DzptDEYWRLdwXY, bool _0023_003Dz_sf9dBZZ1poK)
	{
		if (_0023_003DzXd9oZggYYoXtTAteHA_003D_003D.ExportMode != autodeskExportType.ExternalReferenceOverwrite)
		{
			return;
		}
		int length = _0023_003Dzl71fdKt0StRM.Length;
		string _0023_003Dz0EA0NeSD2dKB = _0023_003Dzl71fdKt0StRM.Substring(0, length - 1);
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		Dictionary<string, string> _0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D = new Dictionary<string, string>();
		Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
		Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
		Dictionary<string, string> dictionary5 = new Dictionary<string, string>();
		Dictionary<string, string> dictionary6 = new Dictionary<string, string>();
		LayerKeyedCollection layerKeyedCollection = WriteDatabase._0023_003DzBBXKkG65XrJN(_0023_003Dz0EA0NeSD2dKB, _0023_003Dzl71fdKt0StRM, _0023_003Dz68IvW_AooqDP, _0023_003DzFyBLmv3KS6Nt, _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.Entities, out _0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D);
		List<Entity> list = new List<Entity>();
		for (int i = 0; i < _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.Entities.Count; i++)
		{
			Entity entity = (Entity)_0023_003DzXd9oZggYYoXtTAteHA_003D_003D.Entities[i].Clone();
			entity.Translate(0.0 - _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.BasePoint.X, 0.0 - _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.BasePoint.Y, 0.0 - _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.BasePoint.Z);
			list.Add(entity);
		}
		BlockKeyedCollection _0023_003Dz1yl8n3yUTC6e = WriteDatabase._0023_003DzobR8DJrUi6Yu(_0023_003DzXd9oZggYYoXtTAteHA_003D_003D, _0023_003Dz0EA0NeSD2dKB, _0023_003DzFyBLmv3KS6Nt, _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.Entities, _0023_003DzEoO49dsZOP0E: false);
		_0023_003DzgM3wuVHwaGA_0024(_0023_003Dz1yl8n3yUTC6e, length, dictionary, dictionary2);
		TextStyleKeyedCollection _0023_003DzdwXUAt55V94f = WriteDatabase._0023_003Dz3WHYiTYwY2ClnmiJ6A_003D_003D<TextStyleKeyedCollection, TextStyle>(_0023_003Dz0EA0NeSD2dKB, _0023_003Dzl71fdKt0StRM, _0023_003Dzc3aLSLYhP84G);
		_0023_003DzgM3wuVHwaGA_0024(_0023_003DzdwXUAt55V94f, length, dictionary3, dictionary4);
		LineTypeKeyedCollection _0023_003DzpQDP4NbryDRj = WriteDatabase._0023_003Dz3WHYiTYwY2ClnmiJ6A_003D_003D<LineTypeKeyedCollection, LineType>(_0023_003Dz0EA0NeSD2dKB, _0023_003Dzl71fdKt0StRM, _0023_003Dziw5fCBSsasyX);
		_0023_003DzgM3wuVHwaGA_0024(_0023_003DzpQDP4NbryDRj, length, dictionary5, dictionary6);
		_0023_003DzgwDaPsjWeg6K(list, ref _0023_003Dz1yl8n3yUTC6e, layerKeyedCollection, ref _0023_003DzdwXUAt55V94f, ref _0023_003DzpQDP4NbryDRj, dictionary, _0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D, dictionary3, dictionary5);
		WriteAutodesk writeAutodesk = new WriteAutodesk(_0023_003DzryxhWHI7gZWb, _0023_003Dz2lUs5iI_003D, _0023_003Dzr8rfJIs_003D, _0023_003DzgAG3_0024qr8f0qqs6z5vQ_003D_003D, _0023_003Dz_sf9dBZZ1poK);
		writeAutodesk._0023_003DzIe4F3qbVyQHL(_0023_003DzFyBLmv3KS6Nt);
		try
		{
			writeAutodesk._0023_003DzLnLXrn_6XxxZp534uQ_003D_003D(_0023_003DzfzI8lTwK6mEA, _0023_003Dz0EA0NeSD2dKB, list, layerKeyedCollection, _0023_003Dz1yl8n3yUTC6e, _0023_003DzdwXUAt55V94f, _0023_003DzpQDP4NbryDRj, _0023_003DzN0ZWdMqGnIFK8BemCQ_003D_003D, _0023_003DzXd9oZggYYoXtTAteHA_003D_003D.Units, _0023_003DzptDEYWRLdwXY, null, default(CancellationToken));
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally
		{
			_0023_003DzgwDaPsjWeg6K(list, ref _0023_003Dz1yl8n3yUTC6e, layerKeyedCollection, ref _0023_003DzdwXUAt55V94f, ref _0023_003DzpQDP4NbryDRj, dictionary2, _0023_003DzTlTnTeqJ2Uw23WbwGA_003D_003D, dictionary4, dictionary6);
		}
	}

	private static void _0023_003DzgwDaPsjWeg6K(List<Entity> _0023_003Dz29mwgg0FBLPP, ref BlockKeyedCollection _0023_003Dz1yl8n3yUTC6e, IList<Layer> _0023_003DzxyKqJGqsMOpmzMxskw_003D_003D, ref TextStyleKeyedCollection _0023_003DzdwXUAt55V94f, ref LineTypeKeyedCollection _0023_003DzpQDP4NbryDRj, Dictionary<string, string> _0023_003DzBIYoIKGttB1b1KQWZQ_003D_003D, Dictionary<string, string> _0023_003DzLyLuRYDYEv7wETYtHA_003D_003D, Dictionary<string, string> _0023_003DzRLzw7L1s6xvwXcNHUA_003D_003D, Dictionary<string, string> _0023_003DzSbqvODoRaVjpG9o05w_003D_003D)
	{
		EntityList.ReplaceBlockNames(_0023_003DzBIYoIKGttB1b1KQWZQ_003D_003D, _0023_003Dz29mwgg0FBLPP, ref _0023_003Dz1yl8n3yUTC6e);
		_0023_003DzascFzBjr24XZ<LayerKeyedCollection, Layer>(_0023_003DzLyLuRYDYEv7wETYtHA_003D_003D, _0023_003Dz29mwgg0FBLPP, _0023_003Dz1yl8n3yUTC6e, ReadAutodesk._0023_003Dzj1sOdnkOR22w);
		_0023_003DzascFzBjr24XZ<TextStyleKeyedCollection, TextStyle>(_0023_003DzRLzw7L1s6xvwXcNHUA_003D_003D, _0023_003Dz29mwgg0FBLPP, _0023_003Dz1yl8n3yUTC6e, ReadAutodesk._0023_003DzKXsL4qSp01z9, ref _0023_003DzdwXUAt55V94f);
		_0023_003DzascFzBjr24XZ<LineTypeKeyedCollection, LineType>(_0023_003DzSbqvODoRaVjpG9o05w_003D_003D, _0023_003Dz29mwgg0FBLPP, _0023_003Dz1yl8n3yUTC6e, ReadAutodesk._0023_003DzR8LczVNo1gKC, ref _0023_003DzpQDP4NbryDRj);
		foreach (Layer item in _0023_003DzxyKqJGqsMOpmzMxskw_003D_003D)
		{
			if (!string.IsNullOrEmpty(item.LineTypeName))
			{
				item.LineTypeName = _0023_003DzSbqvODoRaVjpG9o05w_003D_003D[item.LineTypeName];
			}
		}
	}

	private static void _0023_003DzgM3wuVHwaGA_0024<T>(EyeshotKeyedCollection<T> _0023_003DzD0sjgmA_003D, int _0023_003DzLFx303PIOrae, Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt, Dictionary<string, string> _0023_003Dz33M7GXSBrO2K) where T : IKeyedCollectionItem<T>
	{
		foreach (T item in _0023_003DzD0sjgmA_003D)
		{
			string key = item.GetKey();
			if (key.Length > _0023_003DzLFx303PIOrae)
			{
				string text = key.Substring(_0023_003DzLFx303PIOrae);
				_0023_003Dzv7XKd3qNFbVt.Add(key, text);
				_0023_003Dz33M7GXSBrO2K.Add(text, key);
			}
		}
	}

	private static void _0023_003DzgM3wuVHwaGA_0024<T>(Dictionary<string, T> _0023_003DzreyZB2ivYDOp, int _0023_003DzLFx303PIOrae, Dictionary<string, string> _0023_003Dzv7XKd3qNFbVt, Dictionary<string, string> _0023_003Dz33M7GXSBrO2K) where T : class
	{
		foreach (KeyValuePair<string, T> item in _0023_003DzreyZB2ivYDOp)
		{
			if (item.Key.Length > _0023_003DzLFx303PIOrae)
			{
				string text = item.Key.Substring(_0023_003DzLFx303PIOrae);
				_0023_003Dzv7XKd3qNFbVt.Add(item.Key, text);
				_0023_003Dz33M7GXSBrO2K.Add(text, item.Key);
			}
		}
	}

	private static void _0023_003DzascFzBjr24XZ<T, Q>(Dictionary<string, string> _0023_003Dz1qdCSU2Cqo4h, IList<Entity> _0023_003DzLpVMKc8_003D, BlockKeyedCollection _0023_003DziXS7DNI_003D, _0023_003Dzzm_0024t9TEJc8vr _0023_003DzajKN3SChDs3_0024) where T : EyeshotKeyedCollection<Q>, new() where Q : IKeyedCollectionItem<Q>
	{
		_0023_003DzajKN3SChDs3_0024(_0023_003Dz1qdCSU2Cqo4h, _0023_003DzLpVMKc8_003D);
		if (_0023_003DziXS7DNI_003D == null)
		{
			return;
		}
		foreach (Block item in _0023_003DziXS7DNI_003D)
		{
			if (item.ExportMode == autodeskExportType.Embedded)
			{
				_0023_003DzajKN3SChDs3_0024(_0023_003Dz1qdCSU2Cqo4h, item.Entities);
			}
		}
	}

	private static void _0023_003DzascFzBjr24XZ<T, Q>(Dictionary<string, string> _0023_003Dz1qdCSU2Cqo4h, IList<Entity> _0023_003DzLpVMKc8_003D, BlockKeyedCollection _0023_003DziXS7DNI_003D, _0023_003Dzzm_0024t9TEJc8vr _0023_003DzajKN3SChDs3_0024, ref T _0023_003DzD0sjgmA_003D) where T : EyeshotKeyedCollection<Q>, new() where Q : IKeyedCollectionItem<Q>
	{
		_0023_003DzascFzBjr24XZ<T, Q>(_0023_003Dz1qdCSU2Cqo4h, _0023_003DzLpVMKc8_003D, _0023_003DziXS7DNI_003D, _0023_003DzajKN3SChDs3_0024);
		if (_0023_003DzD0sjgmA_003D == null)
		{
			return;
		}
		T val = new T();
		foreach (Q item2 in _0023_003DzD0sjgmA_003D)
		{
			string key = item2.GetKey();
			if (_0023_003Dz1qdCSU2Cqo4h.ContainsKey(key))
			{
				Q item = (Q)item2.Clone();
				item.SetKey(_0023_003Dz1qdCSU2Cqo4h[key]);
				val.Add(item);
			}
			else
			{
				val.Add(item2);
			}
		}
		_0023_003DzD0sjgmA_003D = val;
	}

	public static void _0023_003Dzbqgi89Q_003D(Hatch _0023_003DzpJpy5bxGThDy, WriteDatabase._0023_003DzKyfEzVn70e7f _0023_003DzwzL57J6ueMIu)
	{
		OdDbHatch odDbHatch = _0023_003DzNd2C_0024Jyd6x3N(_0023_003DzpJpy5bxGThDy, _0023_003DzwzL57J6ueMIu._0023_003DzbXRspLkELXCh());
		_0023_003DzwzL57J6ueMIu._0023_003DzZqUFYw1FQIHO().appendOdDbEntity(odDbHatch);
		_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzDJGXEx72FcYc4Bhhew_003D_003D(_0023_003DzpJpy5bxGThDy, odDbHatch, _0023_003DzwzL57J6ueMIu);
	}

	public static OdDbHatch _0023_003DzNd2C_0024Jyd6x3N(Hatch _0023_003DzpJpy5bxGThDy, OdDbDatabase _0023_003DzR8GRspk_003D)
	{
		OdDbHatch odDbHatch = OdDbHatch.createObject();
		odDbHatch.setDatabaseDefaults(_0023_003DzR8GRspk_003D);
		odDbHatch.setPatternSpace(_0023_003DzpJpy5bxGThDy.PatternSpacing);
		odDbHatch.setPatternScale(_0023_003DzpJpy5bxGThDy.PatternScale);
		odDbHatch.setPatternAngle(_0023_003DzpJpy5bxGThDy.PatternAngle);
		odDbHatch.setOriginPoint(new OdGePoint2d(_0023_003DzpJpy5bxGThDy.PatternOrigin.X, _0023_003DzpJpy5bxGThDy.PatternOrigin.Y));
		odDbHatch.setPatternDouble(_0023_003DzpJpy5bxGThDy.PatternDouble);
		OdDbHatch_HatchPatternType patType = ((!_0023_003DzpJpy5bxGThDy.IsUserDefinedPattern) ? (WriteDatabase._0023_003Dz6qjGZbgwhBed.Contains(_0023_003DzpJpy5bxGThDy.PatternName) ? OdDbHatch_HatchPatternType.kPreDefined : OdDbHatch_HatchPatternType.kCustomDefined) : OdDbHatch_HatchPatternType.kUserDefined);
		odDbHatch.setPattern(patType, _0023_003DzpJpy5bxGThDy.PatternName);
		odDbHatch.setAssociative(isAssociative: false);
		odDbHatch.setHatchStyle(OdDbHatch_HatchStyle.kNormal);
		Transformation transformation = new Transformation();
		transformation.Rotation(_0023_003DzpJpy5bxGThDy.Plane, Plane.XY);
		for (int i = 0; i < _0023_003DzpJpy5bxGThDy.ContourList.Count; i++)
		{
			if (_0023_003DzpJpy5bxGThDy.ContourList[i] is CompositeCurve _0023_003Dze4h6Ud8_003D)
			{
				int loopType = 0;
				OdArray_OdGeCurve2d__p_OdObjectsAllocator odArray_OdGeCurve2d__p_OdObjectsAllocator = new OdArray_OdGeCurve2d__p_OdObjectsAllocator();
				foreach (Entity item in _0023_003DzQwvc7eZm6bj7_0024WPPVA_003D_003D(_0023_003Dze4h6Ud8_003D))
				{
					if (item is LinearPath)
					{
						LinearPath linearPath = (LinearPath)item;
						for (int j = 0; j < linearPath.Vertices.Length - 1; j++)
						{
							OdGeCurve2d val = new OdGeCurve2d(OdGeEntity2d.getCPtr(_0023_003DzX9s2QIi2V8n0Rao_0024mIdPI0s_003D(transformation, linearPath.Vertices[j], linearPath.Vertices[j + 1]).copy()).Handle, cMemoryOwn: false);
							odArray_OdGeCurve2d__p_OdObjectsAllocator.Add(val);
						}
					}
					else
					{
						OdGeCurve2d val2 = new OdGeCurve2d(OdGeEntity2d.getCPtr(_0023_003DzX9s2QIi2V8n0Rao_0024mIdPI0s_003D((ICurve)item, transformation).copy()).Handle, cMemoryOwn: false);
						odArray_OdGeCurve2d__p_OdObjectsAllocator.Add(val2);
					}
				}
				_0023_003Dz62WbaGfxC_0024Wq(transformation, odArray_OdGeCurve2d__p_OdObjectsAllocator, _0023_003DzpJpy5bxGThDy.ContourList[i]);
				odDbHatch.appendLoop(loopType, odArray_OdGeCurve2d__p_OdObjectsAllocator);
			}
			else if (_0023_003DzpJpy5bxGThDy.ContourList[i] is LinearPath)
			{
				LinearPath linearPath2 = (LinearPath)_0023_003DzpJpy5bxGThDy.ContourList[i];
				int loopType = 3;
				OdGePoint2dArray odGePoint2dArray = new OdGePoint2dArray();
				OdDoubleArray odDoubleArray = new OdDoubleArray();
				for (int k = 0; k < linearPath2.Vertices.Length; k++)
				{
					Point3D point3D = transformation * linearPath2.Vertices[k];
					odGePoint2dArray.Add(new OdGePoint2d(point3D.X, point3D.Y));
					odDoubleArray.Add(0.0);
				}
				if (linearPath2.Vertices[linearPath2.Vertices.Length - 1] != linearPath2.Vertices[0])
				{
					Point3D point3D2 = transformation * linearPath2.Vertices[0];
					odGePoint2dArray.Add(new OdGePoint2d(point3D2.X, point3D2.Y));
					odDoubleArray.Add(0.0);
				}
				odDbHatch.appendLoop(loopType, odGePoint2dArray, odDoubleArray);
			}
			else
			{
				int loopType = 0;
				OdArray_OdGeCurve2d__p_OdObjectsAllocator odArray_OdGeCurve2d__p_OdObjectsAllocator2 = new OdArray_OdGeCurve2d__p_OdObjectsAllocator();
				OdGeCurve2d val3 = new OdGeCurve2d(OdGeEntity2d.getCPtr(_0023_003DzX9s2QIi2V8n0Rao_0024mIdPI0s_003D(_0023_003DzpJpy5bxGThDy.ContourList[i], transformation).copy()).Handle, cMemoryOwn: false);
				odArray_OdGeCurve2d__p_OdObjectsAllocator2.Add(val3);
				_0023_003Dz62WbaGfxC_0024Wq(transformation, odArray_OdGeCurve2d__p_OdObjectsAllocator2, _0023_003DzpJpy5bxGThDy.ContourList[i]);
				odDbHatch.appendLoop(loopType, odArray_OdGeCurve2d__p_OdObjectsAllocator2);
			}
		}
		odDbHatch.transformBy(_0023_003Dz0jZKhUmYjzCh3P8SS5iOuWt6GBd8XX7tfqSmVI_0024uhyDrHBQWCQ_003D_003D._0023_003DzYFVWlzSSG2ILFnF0uNYYSSaVffW1(_0023_003DzpJpy5bxGThDy));
		odDbHatch.regeneratePattern();
		return odDbHatch;
	}

	private static OdGeCurve2d _0023_003DzX9s2QIi2V8n0Rao_0024mIdPI0s_003D(ICurve _0023_003Dzvyf_UNM_003D, Transformation _0023_003DzA9AWm4_sg3f1)
	{
		if (_0023_003Dzvyf_UNM_003D is Arc _0023_003Dz4pj2nl0_003D)
		{
			return _0023_003Dz1_00240F8fNqyGMZFgOQujYJpv8_003D(_0023_003Dz4pj2nl0_003D, _0023_003DzA9AWm4_sg3f1);
		}
		if (_0023_003Dzvyf_UNM_003D is Circle _0023_003DzPQURur9m_0024WmE)
		{
			return _0023_003DzemVeDu62TSuhBg_0024yEpzPSqN52GAK(_0023_003DzPQURur9m_0024WmE, _0023_003DzA9AWm4_sg3f1);
		}
		if (_0023_003Dzvyf_UNM_003D is Line _0023_003DzKWFuW5I_003D)
		{
			return _0023_003Dz_WX1XAxho4W_Sy83_ar6bAk_003D(_0023_003DzKWFuW5I_003D, _0023_003DzA9AWm4_sg3f1);
		}
		if (_0023_003Dzvyf_UNM_003D is Ellipse _0023_003Dzvyf_UNM_003D2)
		{
			return _0023_003DzfTpE4N2PWhfrw3Vjdkf8aMl6CDvpGP1Mmg5eJJ0_003D(_0023_003Dzvyf_UNM_003D2, _0023_003DzA9AWm4_sg3f1);
		}
		if (_0023_003Dzvyf_UNM_003D is Curve _0023_003DzINDBoqS9DTqw)
		{
			return _0023_003DzKlblg0Q5JUckDyWTRQyUYsc_003D(_0023_003DzINDBoqS9DTqw, _0023_003DzA9AWm4_sg3f1);
		}
		throw new EyeshotException(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355517473));
	}

	private static OdGeCurve2d _0023_003DzKlblg0Q5JUckDyWTRQyUYsc_003D(Curve _0023_003DzINDBoqS9DTqw, Transformation _0023_003DzA9AWm4_sg3f1)
	{
		OdGeKnotVector odGeKnotVector = new OdGeKnotVector();
		double[] knotVector = _0023_003DzINDBoqS9DTqw.KnotVector;
		foreach (double knot in knotVector)
		{
			odGeKnotVector.append(knot);
		}
		OdGePoint2dArray odGePoint2dArray = new OdGePoint2dArray(_0023_003DzINDBoqS9DTqw.ControlPoints.Length);
		OdDoubleArray odDoubleArray = new OdDoubleArray(_0023_003DzINDBoqS9DTqw.ControlPoints.Length);
		for (int j = 0; j < _0023_003DzINDBoqS9DTqw.ControlPoints.Length; j++)
		{
			Point4D point4D = _0023_003DzINDBoqS9DTqw.ControlPoints[j];
			double w = point4D.W;
			Point2D point2D = new Point2D(point4D.X / w, point4D.Y / w);
			point2D.TransformBy(_0023_003DzA9AWm4_sg3f1);
			odGePoint2dArray.Add(new OdGePoint2d(point2D.X, point2D.Y));
			odDoubleArray.Add(w);
		}
		if (_0023_003DzINDBoqS9DTqw.IsRational)
		{
			return new OdGeNurbCurve2d(_0023_003DzINDBoqS9DTqw.Degree, odGeKnotVector, odGePoint2dArray, odDoubleArray, isPeriodic: false);
		}
		return new OdGeNurbCurve2d(_0023_003DzINDBoqS9DTqw.Degree, odGeKnotVector, odGePoint2dArray, isPeriodic: false);
	}

	public static OdGeCurve2d _0023_003Dz_WX1XAxho4W_Sy83_ar6bAk_003D(Line _0023_003DzKWFuW5I_003D, Transformation _0023_003DzA9AWm4_sg3f1)
	{
		return _0023_003DzX9s2QIi2V8n0Rao_0024mIdPI0s_003D(_0023_003DzA9AWm4_sg3f1, _0023_003DzKWFuW5I_003D.StartPoint, _0023_003DzKWFuW5I_003D.EndPoint);
	}

	internal static OdGeCurve2d _0023_003DzX9s2QIi2V8n0Rao_0024mIdPI0s_003D(Transformation _0023_003DzA9AWm4_sg3f1, Point3D _0023_003DzK5QzjgY_003D, Point3D _0023_003Dz1kuWxrU_003D)
	{
		Point3D point3D = _0023_003DzA9AWm4_sg3f1 * _0023_003DzK5QzjgY_003D;
		Point3D point3D2 = _0023_003DzA9AWm4_sg3f1 * _0023_003Dz1kuWxrU_003D;
		return new OdGeLineSeg2d(new OdGePoint2d(point3D.X, point3D.Y), new OdGePoint2d(point3D2.X, point3D2.Y));
	}

	public static OdGeCurve2d _0023_003Dz1_00240F8fNqyGMZFgOQujYJpv8_003D(Arc _0023_003Dz4pj2nl0_003D, Transformation _0023_003DzA9AWm4_sg3f1)
	{
		if (_0023_003Dz4pj2nl0_003D.Domain.Length > 6.283184307179586)
		{
			return _0023_003DzemVeDu62TSuhBg_0024yEpzPSqN52GAK(new Circle(_0023_003Dz4pj2nl0_003D.Plane, _0023_003Dz4pj2nl0_003D.Center, _0023_003Dz4pj2nl0_003D.Radius), _0023_003DzA9AWm4_sg3f1);
		}
		Point3D point3D = _0023_003DzA9AWm4_sg3f1 * _0023_003Dz4pj2nl0_003D.StartPoint;
		Point3D point3D2 = _0023_003DzA9AWm4_sg3f1 * _0023_003Dz4pj2nl0_003D.EndPoint;
		Point3D point3D3 = _0023_003DzA9AWm4_sg3f1 * _0023_003Dz4pj2nl0_003D.PointAt(_0023_003Dz4pj2nl0_003D.Domain.Mid);
		return new OdGeCircArc2d(new OdGePoint2d(point3D.X, point3D.Y), new OdGePoint2d(point3D3.X, point3D3.Y), new OdGePoint2d(point3D2.X, point3D2.Y));
	}

	public static OdGeCurve2d _0023_003DzemVeDu62TSuhBg_0024yEpzPSqN52GAK(Circle _0023_003DzPQURur9m_0024WmE, Transformation _0023_003DzA9AWm4_sg3f1)
	{
		OdGeCircArc2d odGeCircArc2d = new OdGeCircArc2d();
		Point3D point3D = _0023_003DzA9AWm4_sg3f1 * _0023_003DzPQURur9m_0024WmE.Center;
		odGeCircArc2d.setCenter(new OdGePoint2d(point3D.X, point3D.Y));
		odGeCircArc2d.setRadius(_0023_003DzPQURur9m_0024WmE.Radius);
		odGeCircArc2d.setAngles(0.0, Math.PI * 2.0);
		return odGeCircArc2d;
	}

	public static OdGeCurve2d _0023_003DzfTpE4N2PWhfrw3Vjdkf8aMl6CDvpGP1Mmg5eJJ0_003D(Ellipse _0023_003Dzvyf_UNM_003D, Transformation _0023_003DzA9AWm4_sg3f1)
	{
		Point3D point3D = _0023_003DzA9AWm4_sg3f1 * _0023_003Dzvyf_UNM_003D.Center;
		Vector3D vector3D = _0023_003DzA9AWm4_sg3f1 * _0023_003Dzvyf_UNM_003D.Plane.AxisX;
		Vector3D vector3D2 = _0023_003DzA9AWm4_sg3f1 * _0023_003Dzvyf_UNM_003D.Plane.AxisY;
		return new OdGeEllipArc2d(new OdGePoint2d(point3D.X, point3D.Y), new OdGeVector2d(vector3D.X, vector3D.Y), new OdGeVector2d(vector3D2.X, vector3D2.Y), _0023_003Dzvyf_UNM_003D.RadiusX, _0023_003Dzvyf_UNM_003D.RadiusY, _0023_003Dzvyf_UNM_003D.Domain.t0, _0023_003Dzvyf_UNM_003D.Domain.t1);
	}
}
