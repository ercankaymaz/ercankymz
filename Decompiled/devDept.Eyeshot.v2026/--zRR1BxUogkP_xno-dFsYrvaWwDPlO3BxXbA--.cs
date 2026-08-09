using System;
using devDept;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzRR1BxUogkP_xno_0024dFsYrvaWwDPlO3BxXbA_003D_003D
{
	internal sealed class _0023_003Dz4R8nGwfjdYGaRGgkJw_003D_003D : Solid.Portion
	{
		public _0023_003Dz4R8nGwfjdYGaRGgkJw_003D_003D()
		{
			localMin = new Point3D();
			localMax = new Point3D();
		}

		public void _0023_003Dz9D6J0TmP7O8i(Solid.Portion _0023_003DzMlCq3wk_003D)
		{
			_0023_003DzDBrp9S8_003D(_0023_003DzMlCq3wk_003D, this);
		}

		public void _0023_003DzJvr5DC0_003D(Solid.Portion _0023_003DzMlCq3wk_003D)
		{
			_0023_003DzDBrp9S8_003D(this, _0023_003DzMlCq3wk_003D);
		}

		private static void _0023_003DzDBrp9S8_003D(Solid.Portion _0023_003DzqjMrmuo_003D, Solid.Portion _0023_003DzaoQTclc_003D)
		{
			_0023_003DzaoQTclc_003D.Id = _0023_003DzqjMrmuo_003D.Id;
			_0023_003DzaoQTclc_003D.vertexCount = _0023_003DzqjMrmuo_003D.vertexCount;
			_0023_003DzaoQTclc_003D.faceCount = _0023_003DzqjMrmuo_003D.faceCount;
			_0023_003DzaoQTclc_003D.edgeCount = _0023_003DzqjMrmuo_003D.edgeCount;
			_0023_003DzaoQTclc_003D.contourCount = _0023_003DzqjMrmuo_003D.contourCount;
			_0023_003DzaoQTclc_003D.MaxNov = _0023_003DzqjMrmuo_003D.MaxNov;
			_0023_003DzaoQTclc_003D.MaxNoe = _0023_003DzqjMrmuo_003D.MaxNoe;
			_0023_003DzaoQTclc_003D.MaxNof = _0023_003DzqjMrmuo_003D.MaxNof;
			_0023_003DzaoQTclc_003D.MaxNoc = _0023_003DzqjMrmuo_003D.MaxNoc;
			_0023_003DzaoQTclc_003D.novTemp = _0023_003DzqjMrmuo_003D.novTemp;
			_0023_003DzeqouDRQ_003D(ref _0023_003DzaoQTclc_003D._vertices, _0023_003DzqjMrmuo_003D.VertexCount);
			_0023_003DzeqouDRQ_003D(ref _0023_003DzaoQTclc_003D.edgeDatas, _0023_003DzqjMrmuo_003D.edgeCount + 1);
			_0023_003DzeqouDRQ_003D(ref _0023_003DzaoQTclc_003D.faces, _0023_003DzqjMrmuo_003D.FaceCount + 1);
			_0023_003DzeqouDRQ_003D(ref _0023_003DzaoQTclc_003D.cycles, _0023_003DzqjMrmuo_003D.contourCount + 1);
			_0023_003DzeqouDRQ_003D(ref _0023_003DzaoQTclc_003D.planes, _0023_003DzqjMrmuo_003D.FaceCount + 1);
			_0023_003DzeqouDRQ_003D(ref _0023_003DzaoQTclc_003D.user, _0023_003DzqjMrmuo_003D.edgeCount + 1);
			for (int i = 0; i < _0023_003DzqjMrmuo_003D.vertexCount; i++)
			{
				Point3D point3D = _0023_003DzqjMrmuo_003D._vertices[i];
				if (_0023_003DzaoQTclc_003D._vertices[i] == null)
				{
					_0023_003DzaoQTclc_003D._vertices[i] = (Point3D)point3D.Clone();
					continue;
				}
				Point3D point3D2 = _0023_003DzaoQTclc_003D._vertices[i];
				point3D2.X = point3D.X;
				point3D2.Y = point3D.Y;
				point3D2.Z = point3D.Z;
			}
			for (int j = 0; j < _0023_003DzqjMrmuo_003D.faceCount; j++)
			{
				PlaneEquation planeEquation = _0023_003DzqjMrmuo_003D.planes[j];
				if (_0023_003DzaoQTclc_003D.planes[j] == null)
				{
					_0023_003DzaoQTclc_003D.planes[j] = (PlaneEquation)planeEquation.Clone();
					continue;
				}
				PlaneEquation planeEquation2 = _0023_003DzaoQTclc_003D.planes[j];
				planeEquation2.X = planeEquation.X;
				planeEquation2.Y = planeEquation.Y;
				planeEquation2.Z = planeEquation.Z;
				planeEquation2.D = planeEquation.D;
			}
			Array.Copy(_0023_003DzqjMrmuo_003D.edgeDatas, _0023_003DzaoQTclc_003D.edgeDatas, _0023_003DzqjMrmuo_003D.edgeCount + 1);
			Array.Copy(_0023_003DzqjMrmuo_003D.cycles, _0023_003DzaoQTclc_003D.cycles, _0023_003DzqjMrmuo_003D.contourCount + 1);
			Array.Copy(_0023_003DzqjMrmuo_003D.user, _0023_003DzaoQTclc_003D.user, _0023_003DzqjMrmuo_003D.edgeCount + 1);
			Array.Copy(_0023_003DzqjMrmuo_003D.faces, _0023_003DzaoQTclc_003D.faces, _0023_003DzqjMrmuo_003D.faceCount + 1);
			if (_0023_003DzqjMrmuo_003D.localMin != null && _0023_003DzqjMrmuo_003D.localMax != null)
			{
				_0023_003DzaoQTclc_003D.localMin.X = _0023_003DzqjMrmuo_003D.localMin.X;
				_0023_003DzaoQTclc_003D.localMin.Y = _0023_003DzqjMrmuo_003D.localMin.Y;
				_0023_003DzaoQTclc_003D.localMin.Z = _0023_003DzqjMrmuo_003D.localMin.Z;
				_0023_003DzaoQTclc_003D.localMax.X = _0023_003DzqjMrmuo_003D.localMax.X;
				_0023_003DzaoQTclc_003D.localMax.Y = _0023_003DzqjMrmuo_003D.localMax.Y;
				_0023_003DzaoQTclc_003D.localMax.Z = _0023_003DzqjMrmuo_003D.localMax.Z;
			}
		}

		private static void _0023_003DzeqouDRQ_003D<T>(ref T[] _0023_003DzTbDlaOM_003D, int _0023_003DzfTdN3ms_003D)
		{
			if (_0023_003DzTbDlaOM_003D.Length < _0023_003DzfTdN3ms_003D)
			{
				Array.Resize(ref _0023_003DzTbDlaOM_003D, _0023_003DzfTdN3ms_003D);
			}
		}
	}

	private int _0023_003DzRXo3oShW5GqBVJZoSQ_003D_003D;

	private _0023_003Dz4R8nGwfjdYGaRGgkJw_003D_003D[] _0023_003DzR7Gj_M3YiE3sUII_IQ_003D_003D = new _0023_003Dz4R8nGwfjdYGaRGgkJw_003D_003D[50];

	public void _0023_003DzbBhhBAU_003D(Solid _0023_003DzjpT7ebA_003D)
	{
		_0023_003DzRXo3oShW5GqBVJZoSQ_003D_003D = _0023_003DzjpT7ebA_003D.Portions.Count;
		if (_0023_003DzR7Gj_M3YiE3sUII_IQ_003D_003D.Length < _0023_003DzRXo3oShW5GqBVJZoSQ_003D_003D)
		{
			Array.Resize(ref _0023_003DzR7Gj_M3YiE3sUII_IQ_003D_003D, _0023_003DzRXo3oShW5GqBVJZoSQ_003D_003D);
		}
		for (int i = 0; i < _0023_003DzRXo3oShW5GqBVJZoSQ_003D_003D; i++)
		{
			if (_0023_003DzR7Gj_M3YiE3sUII_IQ_003D_003D[i] == null)
			{
				_0023_003DzR7Gj_M3YiE3sUII_IQ_003D_003D[i] = new _0023_003Dz4R8nGwfjdYGaRGgkJw_003D_003D();
			}
			_0023_003DzR7Gj_M3YiE3sUII_IQ_003D_003D[i]._0023_003Dz9D6J0TmP7O8i(_0023_003DzjpT7ebA_003D.Portions[i]);
		}
	}

	public void _0023_003DzJvr5DC0_003D(Solid _0023_003DzjpT7ebA_003D)
	{
		if (_0023_003DzRXo3oShW5GqBVJZoSQ_003D_003D != _0023_003DzjpT7ebA_003D.Portions.Count)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977722));
		}
		for (int i = 0; i < _0023_003DzRXo3oShW5GqBVJZoSQ_003D_003D; i++)
		{
			_0023_003DzR7Gj_M3YiE3sUII_IQ_003D_003D[i]._0023_003DzJvr5DC0_003D(_0023_003DzjpT7ebA_003D.Portions[i]);
		}
	}
}
