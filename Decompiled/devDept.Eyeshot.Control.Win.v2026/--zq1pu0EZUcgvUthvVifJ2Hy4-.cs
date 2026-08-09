using System;
using System.Collections.Generic;
using System.Drawing;
using SharpDX;
using devDept;
using devDept.Geometry;
using devDept.Graphics;

internal abstract class _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D
{
	private static _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D _0023_003DzDcVkt_MJzDkxyZbOCQ_003D_003D;

	internal static _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D _0023_003DzS21u11g_003D()
	{
		return _0023_003DzDcVkt_MJzDkxyZbOCQ_003D_003D;
	}

	private static void _0023_003DzoGrglms_003D(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzDcVkt_MJzDkxyZbOCQ_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	internal static void _0023_003DzS9sBW50_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (!(_0023_003DzmNZD0Zs_003D is OglRenderContext))
		{
			if (!(_0023_003DzmNZD0Zs_003D is D3DRenderContext))
			{
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348612626));
			}
			_0023_003DzoGrglms_003D(new _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D());
		}
		else
		{
			_0023_003DzoGrglms_003D(new _0023_003DzG0YeAN4EBh8tJ8ZbxfTIdNA_003D());
		}
	}

	internal static float[] _0023_003Dzj1AuNDflFaBs(byte _0023_003DzpGw_0024feA_003D, byte _0023_003DzVC9FBdo_003D, byte _0023_003Dz5PxKZP0_003D)
	{
		return new float[4]
		{
			(float)((double)(int)_0023_003DzpGw_0024feA_003D / 255.0),
			(float)((double)(int)_0023_003DzVC9FBdo_003D / 255.0),
			(float)((double)(int)_0023_003Dz5PxKZP0_003D / 255.0),
			1f
		};
	}

	internal static float[] _0023_003Dzj1AuNDflFaBs(byte _0023_003DzpGw_0024feA_003D, byte _0023_003DzVC9FBdo_003D, byte _0023_003Dz5PxKZP0_003D, byte _0023_003DzivuqTrA_003D)
	{
		return new float[4]
		{
			(float)((double)(int)_0023_003DzpGw_0024feA_003D / 255.0),
			(float)((double)(int)_0023_003DzVC9FBdo_003D / 255.0),
			(float)((double)(int)_0023_003Dz5PxKZP0_003D / 255.0),
			(float)((double)(int)_0023_003DzivuqTrA_003D / 255.0)
		};
	}

	internal static float[] _0023_003Dzj1AuNDflFaBs(System.Drawing.Color _0023_003Dzhpb8QNg_003D)
	{
		return new float[4]
		{
			(float)((double)(int)_0023_003Dzhpb8QNg_003D.R / 255.0),
			(float)((double)(int)_0023_003Dzhpb8QNg_003D.G / 255.0),
			(float)((double)(int)_0023_003Dzhpb8QNg_003D.B / 255.0),
			(float)((double)(int)_0023_003Dzhpb8QNg_003D.A / 255.0)
		};
	}

	internal void _0023_003Dzh9bwYgk_003D(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzfOC0YjY_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003DzfOC0YjY_003D.X;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003DzfOC0YjY_003D.Y;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003DzfOC0YjY_003D.Z;
	}

	internal void _0023_003Dzh9bwYgk_003D(float[] _0023_003Dzt5jpbHs_003D, PointRGB _0023_003DzfOC0YjY_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003DzfOC0YjY_003D.X;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003DzfOC0YjY_003D.Y;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003DzfOC0YjY_003D.Z;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)(int)_0023_003DzfOC0YjY_003D.R / 255f;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)(int)_0023_003DzfOC0YjY_003D.G / 255f;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)(int)_0023_003DzfOC0YjY_003D.B / 255f;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = 1f;
	}

	internal void _0023_003Dz3ar_99lsxuHR(float[] _0023_003Dzt5jpbHs_003D, PointF _0023_003DzfOC0YjY_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = _0023_003DzfOC0YjY_003D.X;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = 1f - _0023_003DzfOC0YjY_003D.Y;
	}

	internal void _0023_003Dzh9bwYgk_003D(float[] _0023_003Dzt5jpbHs_003D, Vector3D _0023_003Dz3kjjQlQ_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003Dz3kjjQlQ_003D.X;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003Dz3kjjQlQ_003D.Y;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003Dz3kjjQlQ_003D.Z;
	}

	internal void _0023_003Dzh9bwYgk_003D(float[] _0023_003Dzt5jpbHs_003D, double _0023_003Dz8GBMuoM_003D, double _0023_003DzJU0R6e0_003D, double _0023_003DzmZWYhFQ_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003Dz8GBMuoM_003D;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003DzJU0R6e0_003D;
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = (float)_0023_003DzmZWYhFQ_003D;
	}

	internal void _0023_003Dzh9bwYgk_003D(float[] _0023_003Dzt5jpbHs_003D, System.Drawing.Color _0023_003DzKni9bTk_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		float[] array = _0023_003Dzj1AuNDflFaBs(_0023_003DzKni9bTk_003D);
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = array[0];
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = array[1];
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = array[2];
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = array[3];
	}

	internal void _0023_003Dzh9bwYgk_003D(float[] _0023_003Dzt5jpbHs_003D, float[] _0023_003DzKni9bTk_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = _0023_003DzKni9bTk_003D[0];
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = _0023_003DzKni9bTk_003D[1];
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = _0023_003DzKni9bTk_003D[2];
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = _0023_003DzKni9bTk_003D[3];
	}

	public float[] _0023_003DztEk3ypKZZaD9(IList<PointRGB> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int _0023_003DzJcO3mNI_003D, int _0023_003DzPH_0024hvqk_003D)
	{
		int num = _0023_003DzJcO3mNI_003D;
		float[] array = new float[_0023_003DzPH_0024hvqk_003D * 7];
		int _0023_003DzPH_0024hvqk_003D2 = 0;
		for (int i = 0; i < _0023_003DzPH_0024hvqk_003D; i++)
		{
			_0023_003Dzh9bwYgk_003D(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num++], ref _0023_003DzPH_0024hvqk_003D2);
		}
		return array;
	}

	public float[] _0023_003DztEk3ypKZZaD9(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int _0023_003DzJcO3mNI_003D, int _0023_003DzPH_0024hvqk_003D)
	{
		int num = _0023_003DzJcO3mNI_003D;
		float[] array = new float[_0023_003DzPH_0024hvqk_003D * 7];
		int _0023_003DzPH_0024hvqk_003D2 = 0;
		for (int i = 0; i < _0023_003DzPH_0024hvqk_003D; i++)
		{
			_0023_003Dzh9bwYgk_003D(array, (PointRGB)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num++], ref _0023_003DzPH_0024hvqk_003D2);
		}
		return array;
	}

	public float[] _0023_003Dzt5OBdcRczGuHRDp_002432bsClw_003D(Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, Vector3D[] _0023_003Dz2pcdJKEqM3of, int _0023_003DzJcO3mNI_003D, int _0023_003DzPH_0024hvqk_003D)
	{
		int num = _0023_003DzJcO3mNI_003D;
		float[] array = new float[_0023_003DzPH_0024hvqk_003D * 6];
		int _0023_003DzPH_0024hvqk_003D2 = 0;
		int num2 = 0;
		while (num2 < _0023_003DzPH_0024hvqk_003D)
		{
			_0023_003Dzh9bwYgk_003D(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num], ref _0023_003DzPH_0024hvqk_003D2);
			_0023_003Dzh9bwYgk_003D(array, _0023_003Dz2pcdJKEqM3of[num], ref _0023_003DzPH_0024hvqk_003D2);
			num2++;
			num++;
		}
		return array;
	}

	public float[] _0023_003DzyOwKSPX1g5Ayz8V7rYO_0024Q7o_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<Vector3D> _0023_003Dz2pcdJKEqM3of, IList<PointF> _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		float[] array = null;
		int count = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count;
		int _0023_003DzPH_0024hvqk_003D = 0;
		if (count > 0)
		{
			RichSmoothTriangle richSmoothTriangle = (RichSmoothTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[0];
			if (_0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D != null && richSmoothTriangle.T1 != -1)
			{
				array = new float[count * 3 * 8];
				for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; i++)
				{
					RichSmoothTriangle richSmoothTriangle2 = (RichSmoothTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
					PointF _0023_003DzW53emIc_003D = _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D[richSmoothTriangle2.T1];
					PointF _0023_003Dzzx_ruqw_003D = _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D[richSmoothTriangle2.T2];
					PointF _0023_003DzvXp00SA_003D = _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D[richSmoothTriangle2.T3];
					_0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richSmoothTriangle2.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richSmoothTriangle2.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richSmoothTriangle2.V3], _0023_003Dz2pcdJKEqM3of[richSmoothTriangle2.N1], _0023_003Dz2pcdJKEqM3of[richSmoothTriangle2.N2], _0023_003Dz2pcdJKEqM3of[richSmoothTriangle2.N3], _0023_003DzW53emIc_003D, _0023_003Dzzx_ruqw_003D, _0023_003DzvXp00SA_003D, ref _0023_003DzPH_0024hvqk_003D);
				}
			}
			else
			{
				array = new float[count * 3 * 6];
				for (int j = 0; j < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; j++)
				{
					RichSmoothTriangle richSmoothTriangle3 = (RichSmoothTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[j];
					_0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richSmoothTriangle3.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richSmoothTriangle3.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richSmoothTriangle3.V3], _0023_003Dz2pcdJKEqM3of[richSmoothTriangle3.N1], _0023_003Dz2pcdJKEqM3of[richSmoothTriangle3.N2], _0023_003Dz2pcdJKEqM3of[richSmoothTriangle3.N3], ref _0023_003DzPH_0024hvqk_003D);
				}
			}
		}
		return array;
	}

	public float[] _0023_003DzyOwKSPX1g5Ayz8V7rYO_0024Q7o_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, float _0023_003Dz_12yiIc_003D, float _0023_003Dzehequ9E_003D, float _0023_003DzuHzN414_003D, float _0023_003DzlpaGCtg_003D, float _0023_003DzvJSXmCpmBdUrfA28fw_003D_003D)
	{
		int count = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] array = new float[count * 3 * 8];
		float[,] a = UtilityEx._0023_003Dz2bKxheQfGiA2(_0023_003Dz_12yiIc_003D, _0023_003Dzehequ9E_003D, _0023_003DzuHzN414_003D, _0023_003DzlpaGCtg_003D, _0023_003DzvJSXmCpmBdUrfA28fw_003D_003D);
		for (int i = 0; i < count; i++)
		{
			IndexTriangle indexTriangle = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			PointNormalUv pointNormalUv = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V1];
			float[] array2 = devDept.Geometry.Matrix.Multiply(a, new float[3]
			{
				(float)pointNormalUv.U,
				(float)pointNormalUv.V,
				1f
			});
			PointF _0023_003DzW53emIc_003D = new PointF(array2[0], array2[1]);
			PointNormalUv pointNormalUv2 = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V2];
			float[] array3 = devDept.Geometry.Matrix.Multiply(a, new float[3]
			{
				(float)pointNormalUv2.U,
				(float)pointNormalUv2.V,
				1f
			});
			PointF _0023_003Dzzx_ruqw_003D = new PointF(array3[0], array3[1]);
			PointNormalUv pointNormalUv3 = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V3];
			float[] array4 = devDept.Geometry.Matrix.Multiply(a, new float[3]
			{
				(float)pointNormalUv3.U,
				(float)pointNormalUv3.V,
				1f
			});
			PointF _0023_003DzvXp00SA_003D = new PointF(array4[0], array4[1]);
			_0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(array, pointNormalUv, pointNormalUv2, pointNormalUv3, pointNormalUv.Normal, pointNormalUv2.Normal, pointNormalUv3.Normal, _0023_003DzW53emIc_003D, _0023_003Dzzx_ruqw_003D, _0023_003DzvXp00SA_003D, ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003DzdWsA7GhCz2yheIwTcdcf_ik_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, float _0023_003Dz_12yiIc_003D, float _0023_003Dzehequ9E_003D, float _0023_003DzuHzN414_003D, float _0023_003DzlpaGCtg_003D, float _0023_003DzvJSXmCpmBdUrfA28fw_003D_003D)
	{
		float[] array = null;
		int count = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count;
		int _0023_003DzPH_0024hvqk_003D = 0;
		if (count > 0)
		{
			array = new float[count * 3 * 8];
			float[,] a = UtilityEx._0023_003Dz2bKxheQfGiA2(_0023_003Dz_12yiIc_003D, _0023_003Dzehequ9E_003D, _0023_003DzuHzN414_003D, _0023_003DzlpaGCtg_003D, _0023_003DzvJSXmCpmBdUrfA28fw_003D_003D);
			for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; i++)
			{
				IndexTriangle indexTriangle = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
				PointNormalUv pointNormalUv = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V1];
				float[] array2 = devDept.Geometry.Matrix.Multiply(a, new float[3]
				{
					(float)pointNormalUv.U,
					(float)pointNormalUv.V,
					1f
				});
				PointF _0023_003DzW53emIc_003D = new PointF(array2[0], array2[1]);
				PointNormalUv pointNormalUv2 = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V2];
				float[] array3 = devDept.Geometry.Matrix.Multiply(a, new float[3]
				{
					(float)pointNormalUv2.U,
					(float)pointNormalUv2.V,
					1f
				});
				PointF _0023_003DzvXp00SA_003D = new PointF(array3[0], array3[1]);
				PointNormalUv pointNormalUv3 = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V3];
				float[] array4 = devDept.Geometry.Matrix.Multiply(a, new float[3]
				{
					(float)pointNormalUv3.U,
					(float)pointNormalUv3.V,
					1f
				});
				PointF _0023_003Dzzx_ruqw_003D = new PointF(array4[0], array4[1]);
				_0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(array, pointNormalUv, pointNormalUv3, pointNormalUv2, pointNormalUv.Normal, pointNormalUv3.Normal, pointNormalUv2.Normal, _0023_003DzW53emIc_003D, _0023_003Dzzx_ruqw_003D, _0023_003DzvXp00SA_003D, ref _0023_003DzPH_0024hvqk_003D);
			}
		}
		return array;
	}

	public float[] _0023_003DzMmiNe4P_GRNtsNvliw_003D_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<Vector3D> _0023_003Dz2pcdJKEqM3of, IList<PointF> _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		int count = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] array = null;
		if (count > 0)
		{
			RichTriangle richTriangle = (RichTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[0];
			if (_0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D != null && richTriangle.T1 != -1)
			{
				array = new float[count * 3 * 8];
				for (int i = 0; i < count; i++)
				{
					RichTriangle richTriangle2 = (RichTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
					PointF _0023_003DzW53emIc_003D = _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D[richTriangle2.T1];
					PointF _0023_003Dzzx_ruqw_003D = _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D[richTriangle2.T2];
					PointF _0023_003DzvXp00SA_003D = _0023_003Dz7FFO_uoPntMcFlzO_Q_003D_003D[richTriangle2.T3];
					_0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richTriangle2.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richTriangle2.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richTriangle2.V3], _0023_003Dz2pcdJKEqM3of[i], _0023_003DzW53emIc_003D, _0023_003Dzzx_ruqw_003D, _0023_003DzvXp00SA_003D, ref _0023_003DzPH_0024hvqk_003D);
				}
			}
			else
			{
				array = new float[count * 3 * 6];
				for (int j = 0; j < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; j++)
				{
					RichTriangle richTriangle3 = (RichTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[j];
					_0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richTriangle3.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richTriangle3.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[richTriangle3.V3], _0023_003Dz2pcdJKEqM3of[j], ref _0023_003DzPH_0024hvqk_003D);
				}
			}
		}
		return array;
	}

	public float[] _0023_003DzQIPF1_0024r2FrrXS2Tvdhmj52YPkFxsfLU1Gg_003D_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<Vector3D> _0023_003Dz2pcdJKEqM3of, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, byte _0023_003DzivuqTrA_003D)
	{
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 10];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; i++)
		{
			SmoothTriangle smoothTriangle = (SmoothTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzxUP3g9Kr0xEF(array, (PointRGB)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[smoothTriangle.V1], (PointRGB)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[smoothTriangle.V2], (PointRGB)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[smoothTriangle.V3], _0023_003Dz2pcdJKEqM3of[smoothTriangle.N1], _0023_003Dz2pcdJKEqM3of[smoothTriangle.N2], _0023_003Dz2pcdJKEqM3of[smoothTriangle.N3], ref _0023_003DzPH_0024hvqk_003D, _0023_003DzivuqTrA_003D);
		}
		return array;
	}

	public float[] _0023_003Dz7CBoPWOPOsyP1uhgsxVj5tM_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, System.Drawing.Color[] _0023_003DzkV8x36YNM2eP)
	{
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 10];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; i++)
		{
			IndexTriangle indexTriangle = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzxUP3g9Kr0xEF(array, (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V1], (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V2], (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V3], _0023_003DzkV8x36YNM2eP, ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003Dzgibj4Xwc8qvk5GE2hjSt_FsO14Yk(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, System.Drawing.Color[] _0023_003DzkV8x36YNM2eP)
	{
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 10];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; i++)
		{
			IndexTriangle indexTriangle = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzxUP3g9Kr0xEF(array, (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V1], (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V3], (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V2], _0023_003DzkV8x36YNM2eP, ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003DzLPWIe7IHYgq5yd2CyOGX7R_JZmFj(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<Vector3D> _0023_003Dz2pcdJKEqM3of, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D, byte _0023_003DzivuqTrA_003D)
	{
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 10];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; i++)
		{
			IndexTriangle indexTriangle = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzxUP3g9Kr0xEF(array, (PointRGB)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V1], (PointRGB)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V2], (PointRGB)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V3], _0023_003Dz2pcdJKEqM3of[i], ref _0023_003DzPH_0024hvqk_003D, _0023_003DzivuqTrA_003D);
		}
		return array;
	}

	public float[] _0023_003DzjSykECD_00240nxKdnrJoQ_003D_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<Vector3D> _0023_003Dz2pcdJKEqM3of, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 10];
		foreach (ColorSmoothTriangle item in _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
		{
			_0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V3], _0023_003Dz2pcdJKEqM3of[item.N1], _0023_003Dz2pcdJKEqM3of[item.N2], _0023_003Dz2pcdJKEqM3of[item.N3], item.R, item.G, item.B, ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003DzVjE0QEIosCCL(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<Vector3D> _0023_003Dz2pcdJKEqM3of, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 10];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count; i++)
		{
			ColorTriangle colorTriangle = (ColorTriangle)_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[colorTriangle.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[colorTriangle.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[colorTriangle.V3], _0023_003Dz2pcdJKEqM3of[i], colorTriangle.R, colorTriangle.G, colorTriangle.B, ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003Dz0Q4yEpOowz76zjKgBA_003D_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<Vector3D> _0023_003Dz2pcdJKEqM3of, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 6];
		foreach (SmoothTriangle item in _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
		{
			_0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V3], _0023_003Dz2pcdJKEqM3of[item.N1], _0023_003Dz2pcdJKEqM3of[item.N2], _0023_003Dz2pcdJKEqM3of[item.N3], ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003DzenPR8YpYXpXc(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 6];
		foreach (IndexTriangle item in _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
		{
			PointNormalUv _0023_003DzeWwrIWU_003D = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V1];
			PointNormalUv _0023_003Dzqpt_0024hO4_003D = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V2];
			PointNormalUv _0023_003DzKkHAOAY_003D = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V3];
			_0023_003DzlWsFipPY6pyL(array, _0023_003DzeWwrIWU_003D, _0023_003Dzqpt_0024hO4_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003Dz8rsrSuGTOynFruGGAA_003D_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] array = new float[_0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count * 3 * 6];
		foreach (IndexTriangle item in _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
		{
			PointNormalUv _0023_003DzeWwrIWU_003D = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V1];
			PointNormalUv _0023_003Dzqpt_0024hO4_003D = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V2];
			PointNormalUv _0023_003DzKkHAOAY_003D = (PointNormalUv)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[item.V3];
			_0023_003DzPHtbYnEXZBzH(array, _0023_003DzeWwrIWU_003D, _0023_003Dzqpt_0024hO4_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003Dz00s0VfKm4rbq(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<Vector3D> _0023_003Dz2pcdJKEqM3of, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		int count = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] array = new float[count * 3 * 6];
		for (int i = 0; i < count; i++)
		{
			IndexTriangle indexTriangle = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V3], _0023_003Dz2pcdJKEqM3of[i], ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public float[] _0023_003Dz00s0VfKm4rbq(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, IList<IndexTriangle> _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D)
	{
		int count = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D.Count;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] array = new float[count * 3 * 3];
		for (int i = 0; i < count; i++)
		{
			IndexTriangle indexTriangle = _0023_003Dzzmih36dAiKNDCev9Mg_003D_003D[i];
			_0023_003DzlWsFipPY6pyL(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V1], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V2], _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[indexTriangle.V3], ref _0023_003DzPH_0024hvqk_003D);
		}
		return array;
	}

	public void _0023_003DzxUP3g9Kr0xEF(float[] _0023_003Dzt5jpbHs_003D, PointRGB _0023_003DzeWwrIWU_003D, PointRGB _0023_003Dzqpt_0024hO4_003D, PointRGB _0023_003DzKkHAOAY_003D, Vector3D _0023_003Dzv_0024Gzcjk_003D, ref int _0023_003DzPH_0024hvqk_003D, byte _0023_003DzivuqTrA_003D)
	{
		_0023_003DzxUP3g9Kr0xEF(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, _0023_003Dzqpt_0024hO4_003D, _0023_003DzKkHAOAY_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003Dzv_0024Gzcjk_003D, ref _0023_003DzPH_0024hvqk_003D, _0023_003DzivuqTrA_003D);
	}

	public void _0023_003DzxUP3g9Kr0xEF(float[] _0023_003Dzt5jpbHs_003D, PointRGB _0023_003DzeWwrIWU_003D, PointRGB _0023_003Dzqpt_0024hO4_003D, PointRGB _0023_003DzKkHAOAY_003D, Vector3D _0023_003DzYWn94JY_003D, Vector3D _0023_003DzkAUEPP0_003D, Vector3D _0023_003DzWwmzTMs_003D, ref int _0023_003DzPH_0024hvqk_003D, byte _0023_003DzivuqTrA_003D)
	{
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, (Point3D)_0023_003DzeWwrIWU_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzYWn94JY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzj1AuNDflFaBs(_0023_003DzeWwrIWU_003D.R, _0023_003DzeWwrIWU_003D.G, _0023_003DzeWwrIWU_003D.B, _0023_003DzivuqTrA_003D), ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, (Point3D)_0023_003Dzqpt_0024hO4_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzkAUEPP0_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzj1AuNDflFaBs(_0023_003Dzqpt_0024hO4_003D.R, _0023_003Dzqpt_0024hO4_003D.G, _0023_003Dzqpt_0024hO4_003D.B, _0023_003DzivuqTrA_003D), ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, (Point3D)_0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzWwmzTMs_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzj1AuNDflFaBs(_0023_003DzKkHAOAY_003D.R, _0023_003DzKkHAOAY_003D.G, _0023_003DzKkHAOAY_003D.B, _0023_003DzivuqTrA_003D), ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzxUP3g9Kr0xEF(float[] _0023_003Dzt5jpbHs_003D, PointNormalUv _0023_003DzeWwrIWU_003D, PointNormalUv _0023_003Dzqpt_0024hO4_003D, PointNormalUv _0023_003DzKkHAOAY_003D, System.Drawing.Color[] _0023_003DzkV8x36YNM2eP, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzv5RXn8xyOwmZdJKXnFnq_0024s8_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, _0023_003DzkV8x36YNM2eP, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzv5RXn8xyOwmZdJKXnFnq_0024s8_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D, _0023_003DzkV8x36YNM2eP, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzv5RXn8xyOwmZdJKXnFnq_0024s8_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D, _0023_003DzkV8x36YNM2eP, ref _0023_003DzPH_0024hvqk_003D);
	}

	private void _0023_003Dzv5RXn8xyOwmZdJKXnFnq_0024s8_003D(float[] _0023_003Dzt5jpbHs_003D, PointNormalUv _0023_003DzfOC0YjY_003D, System.Drawing.Color[] _0023_003DzkV8x36YNM2eP, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzfOC0YjY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzfOC0YjY_003D.Normal, ref _0023_003DzPH_0024hvqk_003D);
		System.Drawing.Color color = _0023_003DzkV8x36YNM2eP[_0023_003DzfOC0YjY_003D.ColorIndex];
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzj1AuNDflFaBs(color.R, color.G, color.B), ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, Vector3D _0023_003Dzv_0024Gzcjk_003D, byte _0023_003DzpGw_0024feA_003D, byte _0023_003DzVC9FBdo_003D, byte _0023_003Dz5PxKZP0_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, _0023_003Dzqpt_0024hO4_003D, _0023_003DzKkHAOAY_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003DzpGw_0024feA_003D, _0023_003DzVC9FBdo_003D, _0023_003Dz5PxKZP0_003D, ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, Vector3D _0023_003DzYWn94JY_003D, Vector3D _0023_003DzkAUEPP0_003D, Vector3D _0023_003DzWwmzTMs_003D, byte _0023_003DzpGw_0024feA_003D, byte _0023_003DzVC9FBdo_003D, byte _0023_003Dz5PxKZP0_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		float[] _0023_003DzKni9bTk_003D = _0023_003Dzj1AuNDflFaBs(_0023_003DzpGw_0024feA_003D, _0023_003DzVC9FBdo_003D, _0023_003Dz5PxKZP0_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzYWn94JY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKni9bTk_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzkAUEPP0_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKni9bTk_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzWwmzTMs_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKni9bTk_003D, ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, Vector3D _0023_003Dzv_0024Gzcjk_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, _0023_003Dzqpt_0024hO4_003D, _0023_003DzKkHAOAY_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003Dzv_0024Gzcjk_003D, ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003DzXapynI9DhqlanITy_00243OWXdE_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, _0023_003Dzqpt_0024hO4_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, Vector3D _0023_003Dzv_0024Gzcjk_003D, PointF _0023_003DzW53emIc_003D, PointF _0023_003Dzzx_ruqw_003D, PointF _0023_003DzvXp00SA_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, _0023_003Dzqpt_0024hO4_003D, _0023_003DzKkHAOAY_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003Dzv_0024Gzcjk_003D, _0023_003DzW53emIc_003D, _0023_003Dzzx_ruqw_003D, _0023_003DzvXp00SA_003D, ref _0023_003DzPH_0024hvqk_003D);
	}

	public abstract void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, Vector3D _0023_003DzYWn94JY_003D, Vector3D _0023_003DzkAUEPP0_003D, Vector3D _0023_003DzWwmzTMs_003D, PointF _0023_003DzW53emIc_003D, PointF _0023_003Dzzx_ruqw_003D, PointF _0023_003DzvXp00SA_003D, ref int _0023_003DzPH_0024hvqk_003D);

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, Vector3D _0023_003DzYWn94JY_003D, Vector3D _0023_003DzkAUEPP0_003D, Vector3D _0023_003DzWwmzTMs_003D, float _0023_003DzW53emIc_003D, float _0023_003Dzzx_ruqw_003D, float _0023_003DzvXp00SA_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzYWn94JY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = _0023_003DzW53emIc_003D;
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzkAUEPP0_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = _0023_003Dzzx_ruqw_003D;
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzWwmzTMs_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzt5jpbHs_003D[_0023_003DzPH_0024hvqk_003D++] = _0023_003DzvXp00SA_003D;
	}

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, Vector3D _0023_003DzYWn94JY_003D, Vector3D _0023_003DzkAUEPP0_003D, Vector3D _0023_003DzWwmzTMs_003D, System.Drawing.Color _0023_003DzV7_0024l52M_003D, System.Drawing.Color _0023_003Dz_0024k81sDg_003D, System.Drawing.Color _0023_003DzMBBx6vo_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzYWn94JY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzV7_0024l52M_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzkAUEPP0_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dz_0024k81sDg_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzWwmzTMs_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzMBBx6vo_003D, ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, Vector3D _0023_003DzYWn94JY_003D, Vector3D _0023_003DzkAUEPP0_003D, Vector3D _0023_003DzWwmzTMs_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzYWn94JY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzkAUEPP0_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzWwmzTMs_003D, ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzXapynI9DhqlanITy_00243OWXdE_003D(float[] _0023_003Dzt5jpbHs_003D, Point3D _0023_003DzeWwrIWU_003D, Point3D _0023_003Dzqpt_0024hO4_003D, Point3D _0023_003DzKkHAOAY_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzlWsFipPY6pyL(float[] _0023_003Dzt5jpbHs_003D, PointNormalUv _0023_003DzeWwrIWU_003D, PointNormalUv _0023_003Dzqpt_0024hO4_003D, PointNormalUv _0023_003DzKkHAOAY_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D.Nx, _0023_003DzeWwrIWU_003D.Ny, _0023_003DzeWwrIWU_003D.Nz, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D.Nx, _0023_003Dzqpt_0024hO4_003D.Ny, _0023_003Dzqpt_0024hO4_003D.Nz, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D.Nx, _0023_003DzKkHAOAY_003D.Ny, _0023_003DzKkHAOAY_003D.Nz, ref _0023_003DzPH_0024hvqk_003D);
	}

	public void _0023_003DzPHtbYnEXZBzH(float[] _0023_003Dzt5jpbHs_003D, PointNormalUv _0023_003DzeWwrIWU_003D, PointNormalUv _0023_003Dzqpt_0024hO4_003D, PointNormalUv _0023_003DzKkHAOAY_003D, ref int _0023_003DzPH_0024hvqk_003D)
	{
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzeWwrIWU_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, 0.0 - _0023_003DzeWwrIWU_003D.Nx, 0.0 - _0023_003DzeWwrIWU_003D.Ny, 0.0 - _0023_003DzeWwrIWU_003D.Nz, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003Dzqpt_0024hO4_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, 0.0 - _0023_003Dzqpt_0024hO4_003D.Nx, 0.0 - _0023_003Dzqpt_0024hO4_003D.Ny, 0.0 - _0023_003Dzqpt_0024hO4_003D.Nz, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzKkHAOAY_003D, ref _0023_003DzPH_0024hvqk_003D);
		_0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, 0.0 - _0023_003DzKkHAOAY_003D.Nx, 0.0 - _0023_003DzKkHAOAY_003D.Ny, 0.0 - _0023_003DzKkHAOAY_003D.Nz, ref _0023_003DzPH_0024hvqk_003D);
	}

	internal float[] _0023_003DzYD8zfIi355st(Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, Vector3D[] _0023_003Dz2pcdJKEqM3of, int _0023_003DzJcO3mNI_003D, int _0023_003DzPH_0024hvqk_003D)
	{
		float[] array = new float[_0023_003DzPH_0024hvqk_003D * 6];
		int num = _0023_003DzJcO3mNI_003D;
		int num2 = _0023_003DzJcO3mNI_003D / 4;
		int _0023_003DzPH_0024hvqk_003D2 = 0;
		int num3 = 0;
		while (num3 < _0023_003DzPH_0024hvqk_003D)
		{
			_0023_003Dzh9bwYgk_003D(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num++], ref _0023_003DzPH_0024hvqk_003D2);
			_0023_003Dzh9bwYgk_003D(array, _0023_003Dz2pcdJKEqM3of[num2], ref _0023_003DzPH_0024hvqk_003D2);
			_0023_003Dzh9bwYgk_003D(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num++], ref _0023_003DzPH_0024hvqk_003D2);
			_0023_003Dzh9bwYgk_003D(array, _0023_003Dz2pcdJKEqM3of[num2], ref _0023_003DzPH_0024hvqk_003D2);
			_0023_003Dzh9bwYgk_003D(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num++], ref _0023_003DzPH_0024hvqk_003D2);
			_0023_003Dzh9bwYgk_003D(array, _0023_003Dz2pcdJKEqM3of[num2], ref _0023_003DzPH_0024hvqk_003D2);
			_0023_003Dzh9bwYgk_003D(array, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num++], ref _0023_003DzPH_0024hvqk_003D2);
			_0023_003Dzh9bwYgk_003D(array, _0023_003Dz2pcdJKEqM3of[num2], ref _0023_003DzPH_0024hvqk_003D2);
			num3 += 4;
			num2++;
		}
		return array;
	}

	internal float[] _0023_003Dzxt_0024C4mfsru6P(IList<IndexLine> _0023_003DzpXOe8Wk17Z9u, Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out int _0023_003DzVKEHOoE_003D)
	{
		int count = _0023_003DzpXOe8Wk17Z9u.Count;
		int num = 2;
		float[] array = new float[count * num * 3];
		int num2 = 0;
		for (int i = 0; i < _0023_003DzpXOe8Wk17Z9u.Count; i++)
		{
			Point3D point3D = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[_0023_003DzpXOe8Wk17Z9u[i].V1];
			array[num2++] = (float)point3D.X;
			array[num2++] = (float)point3D.Y;
			array[num2++] = (float)point3D.Z;
			point3D = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[_0023_003DzpXOe8Wk17Z9u[i].V2];
			array[num2++] = (float)point3D.X;
			array[num2++] = (float)point3D.Y;
			array[num2++] = (float)point3D.Z;
		}
		_0023_003DzVKEHOoE_003D = count * num;
		return array;
	}

	internal float[] _0023_003Dzxt_0024C4mfsru6P(IList<IndexLine> _0023_003DzpXOe8Wk17Z9u, float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, out int _0023_003DzVKEHOoE_003D)
	{
		int count = _0023_003DzpXOe8Wk17Z9u.Count;
		int num = 2;
		float[] array = new float[count * num * 3];
		int num2 = 0;
		for (int i = 0; i < _0023_003DzpXOe8Wk17Z9u.Count; i++)
		{
			int num3 = 3 * _0023_003DzpXOe8Wk17Z9u[i].V1;
			array[num2++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3];
			array[num2++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3 + 1];
			array[num2++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3 + 2];
			num3 = 3 * _0023_003DzpXOe8Wk17Z9u[i].V2;
			array[num2++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3];
			array[num2++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3 + 1];
			array[num2++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3 + 2];
		}
		_0023_003DzVKEHOoE_003D = count * num;
		return array;
	}

	internal float[] _0023_003DzJDIVJsRbg20OVXIybQ_003D_003D(IList<IndexLine> _0023_003DzpXOe8Wk17Z9u, Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, double _0023_003DziZ43wkkSo3SU, int _0023_003DzmrtMJ48_003D, out int _0023_003DzVKEHOoE_003D)
	{
		int count = _0023_003DzpXOe8Wk17Z9u.Count;
		int num = 2;
		float[] array = new float[count * num * 3];
		int num2 = 0;
		for (int i = 0; i < count; i++)
		{
			PointWithDisplacement pointWithDisplacement = (PointWithDisplacement)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[_0023_003DzpXOe8Wk17Z9u[i].V1];
			array[num2++] = pointWithDisplacement.DisplacementX(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num2++] = pointWithDisplacement.DisplacementY(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num2++] = pointWithDisplacement.DisplacementZ(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			pointWithDisplacement = (PointWithDisplacement)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[_0023_003DzpXOe8Wk17Z9u[i].V2];
			array[num2++] = pointWithDisplacement.DisplacementX(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num2++] = pointWithDisplacement.DisplacementY(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num2++] = pointWithDisplacement.DisplacementZ(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
		}
		_0023_003DzVKEHOoE_003D = count * num;
		return array;
	}

	internal float[] _0023_003Dz9AhjvKeUMMns(Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, double _0023_003DziZ43wkkSo3SU, int _0023_003DzmrtMJ48_003D, out int _0023_003DzVKEHOoE_003D)
	{
		int num = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length;
		float[] array = new float[num * 3];
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			PointWithDisplacement pointWithDisplacement = (PointWithDisplacement)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[i];
			array[num2++] = pointWithDisplacement.DisplacementX(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num2++] = pointWithDisplacement.DisplacementY(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num2++] = pointWithDisplacement.DisplacementZ(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
		}
		_0023_003DzVKEHOoE_003D = num;
		return array;
	}

	internal float[] _0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, Vector3D[] _0023_003Dz2pcdJKEqM3of, System.Drawing.Color _0023_003DzmCotMy8_003D, double _0023_003DziZ43wkkSo3SU, int _0023_003DzmrtMJ48_003D, out int _0023_003DzVKEHOoE_003D)
	{
		float[] array = new float[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length * 10];
		int num = 0;
		float[] array2 = _0023_003Dzj1AuNDflFaBs(_0023_003DzmCotMy8_003D);
		for (int i = 0; i < _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length; i++)
		{
			PointWithDisplacement pointWithDisplacement = (PointWithDisplacement)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[i];
			array[num++] = pointWithDisplacement.DisplacementX(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num++] = pointWithDisplacement.DisplacementY(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num++] = pointWithDisplacement.DisplacementZ(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			Vector3D vector3D = _0023_003Dz2pcdJKEqM3of[i];
			array[num++] = (float)vector3D.X;
			array[num++] = (float)vector3D.Y;
			array[num++] = (float)vector3D.Z;
			array[num++] = array2[0];
			array[num++] = array2[1];
			array[num++] = array2[2];
			array[num++] = array2[3];
		}
		_0023_003DzVKEHOoE_003D = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length;
		return array;
	}

	internal float[] _0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, Vector3D[] _0023_003Dz2pcdJKEqM3of, System.Drawing.Color[] _0023_003DzVJOrahxTBhxs, double _0023_003DziZ43wkkSo3SU, int _0023_003DzmrtMJ48_003D, out int _0023_003DzVKEHOoE_003D)
	{
		float[] array = new float[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length * 10];
		int num = 0;
		for (int i = 0; i < _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length; i++)
		{
			float[] array2 = _0023_003Dzj1AuNDflFaBs(_0023_003DzVJOrahxTBhxs[i]);
			PointWithDisplacement pointWithDisplacement = (PointWithDisplacement)_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[i];
			array[num++] = pointWithDisplacement.DisplacementX(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num++] = pointWithDisplacement.DisplacementY(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num++] = pointWithDisplacement.DisplacementZ(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			Vector3D vector3D = _0023_003Dz2pcdJKEqM3of[i];
			array[num++] = (float)vector3D.X;
			array[num++] = (float)vector3D.Y;
			array[num++] = (float)vector3D.Z;
			array[num++] = array2[0];
			array[num++] = array2[1];
			array[num++] = array2[2];
			array[num++] = array2[3];
		}
		_0023_003DzVKEHOoE_003D = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length;
		return array;
	}

	internal float[] _0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(PointWithDisplacement[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, Vector3D[] _0023_003Dz2pcdJKEqM3of, double _0023_003DziZ43wkkSo3SU, int _0023_003DzmrtMJ48_003D, out int _0023_003DzVKEHOoE_003D)
	{
		float[] array = new float[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length * 6];
		int num = 0;
		for (int i = 0; i < _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length; i++)
		{
			PointWithDisplacement pointWithDisplacement = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[i];
			array[num++] = pointWithDisplacement.DisplacementX(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num++] = pointWithDisplacement.DisplacementY(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num++] = pointWithDisplacement.DisplacementZ(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			Vector3D vector3D = _0023_003Dz2pcdJKEqM3of[i];
			array[num++] = (float)vector3D.X;
			array[num++] = (float)vector3D.Y;
			array[num++] = (float)vector3D.Z;
		}
		_0023_003DzVKEHOoE_003D = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length;
		return array;
	}

	internal float[] _0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(PointWithDisplacement[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, Vector3D[] _0023_003Dz2pcdJKEqM3of, float[] _0023_003DzTfU1Gnc08ald10Suyw_003D_003D, double _0023_003DziZ43wkkSo3SU, int _0023_003DzmrtMJ48_003D, out int _0023_003DzVKEHOoE_003D)
	{
		float[] array = new float[_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length * 7];
		int num = 0;
		for (int i = 0; i < _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length; i++)
		{
			PointWithDisplacement pointWithDisplacement = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[i];
			array[num++] = pointWithDisplacement.DisplacementX(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num++] = pointWithDisplacement.DisplacementY(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			array[num++] = pointWithDisplacement.DisplacementZ(_0023_003DziZ43wkkSo3SU, _0023_003DzmrtMJ48_003D);
			Vector3D vector3D = _0023_003Dz2pcdJKEqM3of[i];
			array[num++] = (float)vector3D.X;
			array[num++] = (float)vector3D.Y;
			array[num++] = (float)vector3D.Z;
			array[num++] = _0023_003DzTfU1Gnc08ald10Suyw_003D_003D[i];
		}
		_0023_003DzVKEHOoE_003D = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length;
		return array;
	}

	internal float[] _0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(IList<Point2D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D)
	{
		return _0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, 0, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Count, _0023_003DzN_MOKU7jsa0t: false);
	}

	internal float[] _0023_003DzWzNzXffH54xGqntNgQ_003D_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D)
	{
		return _0023_003DzWzNzXffH54xGqntNgQ_003D_003D(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, 0, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Count, _0023_003DzN_MOKU7jsa0t: false);
	}

	internal float[] _0023_003DzE8czomGZ4WksTGP5mw_003D_003D(IList<PointRGB> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D)
	{
		return _0023_003DzE8czomGZ4WksTGP5mw_003D_003D(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, 0, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Count, _0023_003DzN_MOKU7jsa0t: false);
	}

	internal float[] _0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(IList<Point2D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int _0023_003DzJcO3mNI_003D, int _0023_003DzPH_0024hvqk_003D, bool _0023_003DzN_MOKU7jsa0t)
	{
		float[] array = new float[(_0023_003DzN_MOKU7jsa0t ? (_0023_003DzPH_0024hvqk_003D + 1) : _0023_003DzPH_0024hvqk_003D) * 3];
		int num = 0;
		int num2 = _0023_003DzJcO3mNI_003D;
		for (int i = 0; i < _0023_003DzPH_0024hvqk_003D; i++)
		{
			float[] array2 = _0023_003DzReuCkESVJg_0024q(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num2++].ToArray());
			array[num++] = array2[0];
			array[num++] = array2[1];
			array[num++] = 0f;
		}
		if (_0023_003DzN_MOKU7jsa0t)
		{
			array[num++] = array[0];
			array[num++] = array[1];
			array[num] = 0f;
		}
		return array;
	}

	internal float[] _0023_003DzWzNzXffH54xGqntNgQ_003D_003D(IList<Point3D> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int _0023_003DzJcO3mNI_003D, int _0023_003DzPH_0024hvqk_003D, bool _0023_003DzN_MOKU7jsa0t)
	{
		float[] array = new float[(_0023_003DzN_MOKU7jsa0t ? (_0023_003DzPH_0024hvqk_003D + 1) : _0023_003DzPH_0024hvqk_003D) * 3];
		int num = 0;
		int num2 = _0023_003DzJcO3mNI_003D;
		for (int i = 0; i < _0023_003DzPH_0024hvqk_003D; i++)
		{
			float[] array2 = _0023_003DzReuCkESVJg_0024q(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num2++].ToArray());
			array[num++] = array2[0];
			array[num++] = array2[1];
			array[num++] = array2[2];
		}
		if (_0023_003DzN_MOKU7jsa0t)
		{
			array[num++] = array[0];
			array[num++] = array[1];
			array[num] = array[2];
		}
		return array;
	}

	internal float[] _0023_003DzE8czomGZ4WksTGP5mw_003D_003D(IList<PointRGB> _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int _0023_003DzJcO3mNI_003D, int _0023_003DzPH_0024hvqk_003D, bool _0023_003DzN_MOKU7jsa0t)
	{
		int num = (_0023_003DzN_MOKU7jsa0t ? (_0023_003DzPH_0024hvqk_003D + 1) : _0023_003DzPH_0024hvqk_003D);
		float[] array = _0023_003DzS21u11g_003D()._0023_003DztEk3ypKZZaD9(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003DzJcO3mNI_003D, _0023_003DzPH_0024hvqk_003D);
		if (_0023_003DzN_MOKU7jsa0t)
		{
			int num2 = num - 7;
			array[num2++] = array[0];
			array[num2++] = array[1];
			array[num2++] = array[2];
			array[num2++] = array[3];
			array[num2++] = array[4];
			array[num2++] = array[5];
			array[num2] = array[6];
		}
		return array;
	}

	public static float[] _0023_003DzReuCkESVJg_0024q(double[] _0023_003DzbEASM6g_003D)
	{
		float[] array = new float[_0023_003DzbEASM6g_003D.Length];
		for (int i = 0; i < _0023_003DzbEASM6g_003D.Length; i++)
		{
			array[i] = (float)_0023_003DzbEASM6g_003D[i];
		}
		return array;
	}

	public static double[] _0023_003DzyzZlFbrN8FxQ(float[] _0023_003DzbEASM6g_003D)
	{
		double[] array = new double[_0023_003DzbEASM6g_003D.Length];
		for (int i = 0; i < _0023_003DzbEASM6g_003D.Length; i++)
		{
			array[i] = _0023_003DzbEASM6g_003D[i];
		}
		return array;
	}

	[CLSCompliant(false)]
	internal static ulong _0023_003DzkVysqIoceUqzcj07uw_003D_003D(PointerSize _0023_003DzAC5d24U_003D)
	{
		if (UIntPtr.Size == 8)
		{
			return (ulong)(long)_0023_003DzAC5d24U_003D;
		}
		return (uint)(int)_0023_003DzAC5d24U_003D;
	}
}
