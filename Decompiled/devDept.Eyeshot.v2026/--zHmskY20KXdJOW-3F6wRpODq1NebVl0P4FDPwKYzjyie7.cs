using System;
using System.Collections.Generic;
using devDept.Geometry;

internal class _0023_003DzHmskY20KXdJOW_00243F6wRpODq1NebVl0P4FDPwKYzjyie7
{
	private Dictionary<int, List<int>> _0023_003Dz8_0024KDPiCJqBZt = new Dictionary<int, List<int>>();

	private List<int> _0023_003DzGPK830chCq_Ua_YfQQ_003D_003D = new List<int>();

	protected IList<Point3D> _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D;

	protected IList<IndexTriangle> _0023_003DzZ4_EMwmky47mEQrs2A_003D_003D;

	protected IList<IndexLine> _0023_003DzU4XYawo_003D;

	public _0023_003DzHmskY20KXdJOW_00243F6wRpODq1NebVl0P4FDPwKYzjyie7(IList<Point3D> _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, IList<IndexTriangle> _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D, IList<IndexLine> _0023_003DzU3hosSAzkxO7)
	{
		_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D;
		_0023_003DzZ4_EMwmky47mEQrs2A_003D_003D = _0023_003DzJjA_gLscEShC_0024fCWrA_003D_003D;
		_0023_003DzU4XYawo_003D = _0023_003DzU3hosSAzkxO7;
	}

	protected virtual bool _0023_003Dzos6gs0HqIF2n(int _0023_003Dz77g161c_003D)
	{
		if (_0023_003DzGPK830chCq_Ua_YfQQ_003D_003D.BinarySearch(_0023_003Dz77g161c_003D) >= 0)
		{
			return false;
		}
		_0023_003DzGPK830chCq_Ua_YfQQ_003D_003D.Add(_0023_003Dz77g161c_003D);
		_0023_003DzGPK830chCq_Ua_YfQQ_003D_003D.Sort();
		return true;
	}

	protected virtual bool _0023_003DzkxOPXCxD16i7(int _0023_003DzFj_0024IqDQ_003D, int _0023_003DzjdeMMkk_003D)
	{
		int key;
		int item;
		if (_0023_003DzFj_0024IqDQ_003D < _0023_003DzjdeMMkk_003D)
		{
			key = _0023_003DzFj_0024IqDQ_003D;
			item = _0023_003DzjdeMMkk_003D;
		}
		else
		{
			key = _0023_003DzjdeMMkk_003D;
			item = _0023_003DzFj_0024IqDQ_003D;
		}
		if (_0023_003Dz8_0024KDPiCJqBZt.ContainsKey(key))
		{
			if (_0023_003Dz8_0024KDPiCJqBZt[key].Contains(item))
			{
				return false;
			}
			_0023_003Dz8_0024KDPiCJqBZt[key].Add(item);
		}
		else
		{
			List<int> list = new List<int>();
			list.Add(item);
			_0023_003Dz8_0024KDPiCJqBZt.Add(key, list);
		}
		return true;
	}

	public int _0023_003Dz3WVjyBfqduu95gCh_0024A_003D_003D(Segment3D _0023_003DzPpF_0024Cv0_003D, Point3D _0023_003DzlY77YgY_003D, Utility._0023_003DzwhtOFTk_003D _0023_003DzxuJqjrs_003D)
	{
		int result = 0;
		List<Point3D> list = new List<Point3D>();
		double x = _0023_003DzlY77YgY_003D.X;
		double y = _0023_003DzlY77YgY_003D.Y;
		double z = _0023_003DzlY77YgY_003D.Z;
		for (int i = 0; i < _0023_003DzZ4_EMwmky47mEQrs2A_003D_003D.Count; i++)
		{
			IndexTriangle indexTriangle = _0023_003DzZ4_EMwmky47mEQrs2A_003D_003D[i];
			Point3D point3D = _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[indexTriangle.V1];
			Point3D point3D2 = _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[indexTriangle.V2];
			Point3D point3D3 = _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[indexTriangle.V3];
			if (!_0023_003DzlyEWxFRiYAShKjbtIAZPsUs_003D(point3D, point3D2, point3D3, x, y, z, _0023_003DzxuJqjrs_003D) || !_0023_003DzPpF_0024Cv0_003D.IntersectWith(point3D, point3D2, point3D3, ray: true, out var intPoint, out var s, out var t) || !_0023_003DzKFbHLoN7zaeyNuq2mg_003D_003D(s, t, indexTriangle) || list.Contains(intPoint))
			{
				continue;
			}
			list.Add(intPoint);
			Vector3D vector3D = new Vector3D(point3D, point3D2, point3D3);
			if (Math.Abs(new Vector3D(_0023_003DzPpF_0024Cv0_003D.P0, _0023_003DzPpF_0024Cv0_003D.P1) * vector3D) < 0.001)
			{
				return -1;
			}
			if (_0023_003DzU4XYawo_003D == null)
			{
				continue;
			}
			foreach (IndexLine item in _0023_003DzU4XYawo_003D)
			{
				Segment3D segment3D = new Segment3D(_0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[item.V1], _0023_003DzNKR_cAYoR2aGDUGpng_003D_003D[item.V2]);
				double t2 = segment3D.ClosestPointTo(intPoint);
				Point3D b = segment3D.PointAt(t2);
				if (intPoint.DistanceTo(b) < Utility._0023_003DzxhnLabVjXjPg)
				{
					return -1;
				}
			}
		}
		if (list.Count % 2 != 0)
		{
			result = 1;
		}
		return result;
	}

	private bool _0023_003DzlyEWxFRiYAShKjbtIAZPsUs_003D(Point3D _0023_003DzQW_0024hBdI_003D, Point3D _0023_003DzCmn_5Z0_003D, Point3D _0023_003DzqePf_00244c_003D, double _0023_003DzUIfKDS0_003D, double _0023_003DzWBM5jB4_003D, double _0023_003DzEM_vSEo_003D, Utility._0023_003DzwhtOFTk_003D _0023_003DzwhtOFTk_003D)
	{
		bool flag = false;
		switch (_0023_003DzwhtOFTk_003D)
		{
		case (Utility._0023_003DzwhtOFTk_003D)0:
			flag = (_0023_003DzQW_0024hBdI_003D.Z > _0023_003DzEM_vSEo_003D && _0023_003DzCmn_5Z0_003D.Z > _0023_003DzEM_vSEo_003D && _0023_003DzqePf_00244c_003D.Z > _0023_003DzEM_vSEo_003D) || (_0023_003DzQW_0024hBdI_003D.Y > _0023_003DzWBM5jB4_003D && _0023_003DzCmn_5Z0_003D.Y > _0023_003DzWBM5jB4_003D && _0023_003DzqePf_00244c_003D.Y > _0023_003DzWBM5jB4_003D) || (_0023_003DzQW_0024hBdI_003D.Z < _0023_003DzEM_vSEo_003D && _0023_003DzCmn_5Z0_003D.Z < _0023_003DzEM_vSEo_003D && _0023_003DzqePf_00244c_003D.Z < _0023_003DzEM_vSEo_003D) || (_0023_003DzQW_0024hBdI_003D.Y < _0023_003DzWBM5jB4_003D && _0023_003DzCmn_5Z0_003D.Y < _0023_003DzWBM5jB4_003D && _0023_003DzqePf_00244c_003D.Y < _0023_003DzWBM5jB4_003D);
			break;
		case (Utility._0023_003DzwhtOFTk_003D)1:
			flag = (_0023_003DzQW_0024hBdI_003D.Z > _0023_003DzEM_vSEo_003D && _0023_003DzCmn_5Z0_003D.Z > _0023_003DzEM_vSEo_003D && _0023_003DzqePf_00244c_003D.Z > _0023_003DzEM_vSEo_003D) || (_0023_003DzQW_0024hBdI_003D.X > _0023_003DzUIfKDS0_003D && _0023_003DzCmn_5Z0_003D.X > _0023_003DzUIfKDS0_003D && _0023_003DzqePf_00244c_003D.X > _0023_003DzUIfKDS0_003D) || (_0023_003DzQW_0024hBdI_003D.Z < _0023_003DzEM_vSEo_003D && _0023_003DzCmn_5Z0_003D.Z < _0023_003DzEM_vSEo_003D && _0023_003DzqePf_00244c_003D.Z < _0023_003DzEM_vSEo_003D) || (_0023_003DzQW_0024hBdI_003D.X < _0023_003DzUIfKDS0_003D && _0023_003DzCmn_5Z0_003D.X < _0023_003DzUIfKDS0_003D && _0023_003DzqePf_00244c_003D.X < _0023_003DzUIfKDS0_003D);
			break;
		case (Utility._0023_003DzwhtOFTk_003D)2:
			flag = (_0023_003DzQW_0024hBdI_003D.Y > _0023_003DzWBM5jB4_003D && _0023_003DzCmn_5Z0_003D.Y > _0023_003DzWBM5jB4_003D && _0023_003DzqePf_00244c_003D.Y > _0023_003DzWBM5jB4_003D) || (_0023_003DzQW_0024hBdI_003D.X > _0023_003DzUIfKDS0_003D && _0023_003DzCmn_5Z0_003D.X > _0023_003DzUIfKDS0_003D && _0023_003DzqePf_00244c_003D.X > _0023_003DzUIfKDS0_003D) || (_0023_003DzQW_0024hBdI_003D.Y < _0023_003DzWBM5jB4_003D && _0023_003DzCmn_5Z0_003D.Y < _0023_003DzWBM5jB4_003D && _0023_003DzqePf_00244c_003D.Y < _0023_003DzWBM5jB4_003D) || (_0023_003DzQW_0024hBdI_003D.X < _0023_003DzUIfKDS0_003D && _0023_003DzCmn_5Z0_003D.X < _0023_003DzUIfKDS0_003D && _0023_003DzqePf_00244c_003D.X < _0023_003DzUIfKDS0_003D);
			break;
		}
		if (flag)
		{
			return false;
		}
		return true;
	}

	private bool _0023_003DzKFbHLoN7zaeyNuq2mg_003D_003D(double _0023_003DzuwH5j5s_003D, double _0023_003DzNDQ_E88_003D, IndexTriangle _0023_003DznnnQx3RwjThsBRPB9w_003D_003D)
	{
		if (Math.Abs(_0023_003DzuwH5j5s_003D) <= Utility._0023_003DzheSR8QM7q9ya)
		{
			if (Math.Abs(_0023_003DzNDQ_E88_003D) <= Utility._0023_003DzheSR8QM7q9ya)
			{
				if (!_0023_003Dzos6gs0HqIF2n(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1))
				{
					return false;
				}
			}
			else if (Math.Abs(_0023_003DzNDQ_E88_003D - 1.0) <= Utility._0023_003DzheSR8QM7q9ya)
			{
				if (!_0023_003Dzos6gs0HqIF2n(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3))
				{
					return false;
				}
			}
			else if (!_0023_003DzkxOPXCxD16i7(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3))
			{
				return false;
			}
		}
		else if (Math.Abs(_0023_003DzuwH5j5s_003D - 1.0) <= Utility._0023_003DzheSR8QM7q9ya)
		{
			if (Math.Abs(_0023_003DzNDQ_E88_003D) <= Utility._0023_003DzheSR8QM7q9ya && !_0023_003Dzos6gs0HqIF2n(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2))
			{
				return false;
			}
		}
		else if (Math.Abs(_0023_003DzNDQ_E88_003D) <= Utility._0023_003DzheSR8QM7q9ya)
		{
			if (!_0023_003DzkxOPXCxD16i7(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V1, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2))
			{
				return false;
			}
		}
		else if (Math.Abs(_0023_003DzNDQ_E88_003D + _0023_003DzuwH5j5s_003D - 1.0) <= Utility._0023_003DzheSR8QM7q9ya && !_0023_003DzkxOPXCxD16i7(_0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V2, _0023_003DznnnQx3RwjThsBRPB9w_003D_003D.V3))
		{
			return false;
		}
		return true;
	}
}
