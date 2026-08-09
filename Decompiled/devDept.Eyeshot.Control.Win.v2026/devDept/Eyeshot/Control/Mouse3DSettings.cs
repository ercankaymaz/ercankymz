using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using devDept.Geometry;

namespace devDept.Eyeshot.Control;

public class Mouse3DSettings
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzBzXxVAcjZpzEcYDz5tU_S4k_003D = 1.0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzTVuVINTRvIQHZJ7lwGsWXyOkZCYK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzvkP8a2l4nl69sEq8anF_0024tE4_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private centerOfRotationVisibilityType _0023_003DzeRv_JwpblR0PhMNSXzK4eW2I68eH = centerOfRotationVisibilityType.Never;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Point3D _0023_003DzpFqB565tEkQ5RX9Uhla2Frg_003D = Point3D.Origin;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz7ws7XBZPlYeXUXurwDTNKrd38vnsVGM4bw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly Scaling _0023_003DzwP2jFuCE1CImg85_0024QQ_003D_003D = new Scaling(0.8);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Camera[] _0023_003Dz09S_zoLRQE_7 = new Camera[3];

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Workspace _0023_003Dz_0024pn2eLs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzAguoXsGLUr8WTdnpzg_003D_003D;

	[Description("Indicates whether the movements are enabled.")]
	public bool Enabled
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzZodwbTJUdYATv_00244ymQ_003D_003D = value;
		}
	}

	[Description("The pan speed.")]
	public double SpeedFactor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzBzXxVAcjZpzEcYDz5tU_S4k_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzBzXxVAcjZpzEcYDz5tU_S4k_003D = value;
		}
	}

	[Description("Indicates whether the horizon is locked or not.")]
	public bool LockHorizon
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTVuVINTRvIQHZJ7lwGsWXyOkZCYK;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzTVuVINTRvIQHZJ7lwGsWXyOkZCYK = value;
		}
	}

	[Description("Indicates whether the single axis filter is on or not.")]
	public bool SingleAxisFilter
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvkP8a2l4nl69sEq8anF_0024tE4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzvkP8a2l4nl69sEq8anF_0024tE4_003D = value;
		}
	}

	[Description("Automatic selection for center of rotation.")]
	public bool AutoCenterOfRotation
	{
		get
		{
			return _0023_003DzAguoXsGLUr8WTdnpzg_003D_003D;
		}
		set
		{
			_0023_003DzAguoXsGLUr8WTdnpzg_003D_003D = value;
			if (_0023_003DzAguoXsGLUr8WTdnpzg_003D_003D)
			{
				_0023_003DzYj4VI2UHRHIxWOtXAA_003D_003D(null);
			}
			_0023_003DzBilDqwru8u5B();
		}
	}

	[Description("Center or rotation visibility.")]
	public centerOfRotationVisibilityType CenterOfRotationVisibilityMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeRv_JwpblR0PhMNSXzK4eW2I68eH;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzeRv_JwpblR0PhMNSXzK4eW2I68eH = value;
		}
	}

	public Mouse3DSettings()
	{
		AutoCenterOfRotation = true;
	}

	public bool ShouldSerialize(Mouse3DSettings reference)
	{
		if (Enabled == reference.Enabled && SpeedFactor == reference.SpeedFactor && LockHorizon == reference.LockHorizon && SingleAxisFilter == reference.SingleAxisFilter && SingleAxisFilter == reference.SingleAxisFilter && AutoCenterOfRotation == reference.AutoCenterOfRotation)
		{
			return CenterOfRotationVisibilityMode != reference.CenterOfRotationVisibilityMode;
		}
		return true;
	}

	internal Workspace _0023_003Dz0_0024X6OcgLJhm7()
	{
		return _0023_003Dz_0024pn2eLs_003D;
	}

	internal void _0023_003DzzGq7V_q1ZaaU(Workspace _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz_0024pn2eLs_003D = _0023_003DzsLHxXyo_003D;
		_0023_003DzBilDqwru8u5B();
	}

	internal Point3D _0023_003DzALU0UsIX8u9UjBIQqQ_003D_003D()
	{
		return _0023_003DzpFqB565tEkQ5RX9Uhla2Frg_003D;
	}

	internal void _0023_003DzYj4VI2UHRHIxWOtXAA_003D_003D(Point3D _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzpFqB565tEkQ5RX9Uhla2Frg_003D = _0023_003DzsLHxXyo_003D;
	}

	internal bool _0023_003DzKtY32O6TIGh92V9VOrkpc9c_003D()
	{
		return _0023_003Dz7ws7XBZPlYeXUXurwDTNKrd38vnsVGM4bw_003D_003D;
	}

	internal void _0023_003Dzi8kM_zPm9EeY_4HzUp0xz7A_003D(bool _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz7ws7XBZPlYeXUXurwDTNKrd38vnsVGM4bw_003D_003D = _0023_003DzsLHxXyo_003D;
	}

	internal void _0023_003DzBilDqwru8u5B()
	{
		if (_0023_003Dz0_0024X6OcgLJhm7() != null)
		{
			_0023_003DzI8QnuD_uT7AD(null);
			_0023_003Dzd9xGxp1TOJ8G(null);
		}
	}

	internal bool _0023_003DziBVjds1pKQd9DR73Vw_003D_003D()
	{
		if (_0023_003Dz0_0024X6OcgLJhm7() == null || !_0023_003Dz0_0024X6OcgLJhm7()._0023_003DzCFByznJfli3u() || _0023_003Dz0_0024X6OcgLJhm7()._0023_003DzipBYly6zFKAp() == null)
		{
			return false;
		}
		return CenterOfRotationVisibilityMode switch
		{
			centerOfRotationVisibilityType.Always => true, 
			centerOfRotationVisibilityType.OnMotion => _0023_003Dz0_0024X6OcgLJhm7()._0023_003Dzpm_00240_u0_003D._0023_003DzzDEYSbA_003D(), 
			centerOfRotationVisibilityType.Never => false, 
			_ => throw new NotImplementedException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587791)), 
		};
	}

	internal bool _0023_003Dzd9xGxp1TOJ8G(Viewport _0023_003DzYzWi5Yw_003D, MouseEventArgs _0023_003Dz1SmHC4c_003D)
	{
		if (_0023_003Dz0_0024X6OcgLJhm7() == null || _0023_003Dz1SmHC4c_003D == null || _0023_003Dz1SmHC4c_003D.Button != (MouseButtons)_0023_003DzYzWi5Yw_003D.Rotate.MouseButton.Button || _0023_003Dz0_0024X6OcgLJhm7()._0023_003DzBrC4gBvWiHkA == mouseInputType.Standard)
		{
			return false;
		}
		Point3D point3D = _0023_003Dz0_0024X6OcgLJhm7().ScreenToWorld(_0023_003Dz1SmHC4c_003D.Location);
		if (point3D == null)
		{
			Point3D point3D2 = _0023_003DzALU0UsIX8u9UjBIQqQ_003D_003D();
			_0023_003DzAguoXsGLUr8WTdnpzg_003D_003D = true;
			return _0023_003DzYzWi5Yw_003D.Camera.centerOfRotation != point3D2;
		}
		_0023_003DzAguoXsGLUr8WTdnpzg_003D_003D = false;
		_0023_003DzYj4VI2UHRHIxWOtXAA_003D_003D(point3D);
		return _0023_003Dzd9xGxp1TOJ8G(_0023_003DzYzWi5Yw_003D);
	}

	internal bool _0023_003Dzd9xGxp1TOJ8G(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003Dz0_0024X6OcgLJhm7() == null || _0023_003DzAguoXsGLUr8WTdnpzg_003D_003D || !_0023_003Dz0_0024X6OcgLJhm7()._0023_003DzCFByznJfli3u() || _0023_003Dz0_0024X6OcgLJhm7()._0023_003DzBrC4gBvWiHkA == mouseInputType.Standard)
		{
			return false;
		}
		if (_0023_003DzYzWi5Yw_003D == null)
		{
			_0023_003DzYzWi5Yw_003D = _0023_003Dz0_0024X6OcgLJhm7()._0023_003DzipBYly6zFKAp();
		}
		if (_0023_003DzYzWi5Yw_003D._0023_003Dz6PIi18cHVS03g7KqxAAkgsk_003D())
		{
			return false;
		}
		if (_0023_003DzALU0UsIX8u9UjBIQqQ_003D_003D() == null)
		{
			if (_0023_003Dz0_0024X6OcgLJhm7().Entities.BoxMin == Point3D.MaxValue)
			{
				_0023_003Dz0_0024X6OcgLJhm7().Entities.UpdateBoundingBox();
			}
			_0023_003DzYj4VI2UHRHIxWOtXAA_003D_003D((_0023_003Dz0_0024X6OcgLJhm7().Entities.BoxMin + _0023_003Dz0_0024X6OcgLJhm7().Entities.BoxMax) / 2.0);
			if (_0023_003Dz0_0024X6OcgLJhm7().CurrentTransformation != null)
			{
				_0023_003DzALU0UsIX8u9UjBIQqQ_003D_003D().TransformBy(_0023_003Dz0_0024X6OcgLJhm7().CurrentTransformation);
			}
		}
		if (_0023_003DzALU0UsIX8u9UjBIQqQ_003D_003D() == _0023_003DzYzWi5Yw_003D.Camera.centerOfRotation)
		{
			return false;
		}
		_0023_003DzYzWi5Yw_003D.Camera.centerOfRotation = _0023_003DzALU0UsIX8u9UjBIQqQ_003D_003D();
		return true;
	}

	internal bool _0023_003DzI8QnuD_uT7AD(Viewport _0023_003DzYzWi5Yw_003D)
	{
		if (_0023_003Dz0_0024X6OcgLJhm7() == null || _0023_003Dz0_0024X6OcgLJhm7()._0023_003DzBrC4gBvWiHkA == mouseInputType.Standard)
		{
			return false;
		}
		if (_0023_003DzYzWi5Yw_003D == null)
		{
			if (_0023_003Dz0_0024X6OcgLJhm7()._0023_003DzEBQpoR8nc2jpJk1kuw_003D_003D.Count == 0)
			{
				return false;
			}
			_0023_003DzYzWi5Yw_003D = _0023_003Dz0_0024X6OcgLJhm7()._0023_003DzipBYly6zFKAp();
		}
		if (_0023_003DzYzWi5Yw_003D == null || _0023_003DzYzWi5Yw_003D._0023_003Dz6PIi18cHVS03g7KqxAAkgsk_003D() || !_0023_003DzAguoXsGLUr8WTdnpzg_003D_003D)
		{
			return false;
		}
		if (!_0023_003Dz0_0024X6OcgLJhm7()._0023_003DzCFByznJfli3u())
		{
			return false;
		}
		_0023_003Dz0_0024X6OcgLJhm7().AdjustNearAndFarPlanes();
		PlaneEquation[] frustum = _0023_003DzYzWi5Yw_003D.Camera.GetFrustum(_0023_003DzYzWi5Yw_003D.GetViewFrame(), _0023_003Dz_OlmZyU_003D: false);
		if (frustum == null)
		{
			return false;
		}
		EntityList entities = _0023_003Dz0_0024X6OcgLJhm7().Blocks.RootBlock.Entities;
		Point3D boxMin = entities.BoxMin;
		if (boxMin == Point3D.MaxValue)
		{
			return false;
		}
		Point3D boxMax = entities.BoxMax;
		Utility.GetBoundingBoxTransformed(_0023_003DzwP2jFuCE1CImg85_0024QQ_003D_003D, boxMin, boxMax, out var boxMin2, out var boxMax2);
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(boxMin2, boxMax2);
		bool flag = true;
		for (int i = 0; i < boundingBoxCorners.Length && flag; i++)
		{
			if (!Camera.IsInFrustum(boundingBoxCorners[i], frustum))
			{
				flag = false;
			}
		}
		Point3D point3D;
		if (flag)
		{
			point3D = Point3D.MidPoint(_0023_003Dz0_0024X6OcgLJhm7()._0023_003DzK3OaHhra7VrS._0023_003Dze4TpmVqI26AF, _0023_003Dz0_0024X6OcgLJhm7()._0023_003DzK3OaHhra7VrS._0023_003DzD4HjvLi8HsVr);
		}
		else
		{
			point3D = _0023_003Dz0_0024X6OcgLJhm7().ScreenToWorld(new Point(_0023_003DzYzWi5Yw_003D.Size.Width / 2, _0023_003DzYzWi5Yw_003D.Size.Height / 2));
			if (point3D == null)
			{
				return false;
			}
		}
		_0023_003Dzi8kM_zPm9EeY_4HzUp0xz7A_003D(_0023_003DzsLHxXyo_003D: false);
		if (point3D == _0023_003DzYzWi5Yw_003D.Camera.centerOfRotation)
		{
			return false;
		}
		_0023_003DzYzWi5Yw_003D.Camera.centerOfRotation = point3D;
		return true;
	}

	private static bool _0023_003DzsI28S7_HDT6V(int _0023_003Dz1HcCRuXf1eTz)
	{
		if (0 <= _0023_003Dz1HcCRuXf1eTz)
		{
			return _0023_003Dz1HcCRuXf1eTz < 3;
		}
		return false;
	}

	internal void _0023_003DzURHD1D0a4usl(int _0023_003Dz1HcCRuXf1eTz)
	{
		_0023_003Dz1HcCRuXf1eTz--;
		if (_0023_003Dz0_0024X6OcgLJhm7() != null && _0023_003DzsI28S7_HDT6V(_0023_003Dz1HcCRuXf1eTz))
		{
			_0023_003Dz0_0024X6OcgLJhm7()._0023_003DzipBYly6zFKAp().SaveView(out _0023_003Dz09S_zoLRQE_7[_0023_003Dz1HcCRuXf1eTz]);
		}
	}

	internal void _0023_003Dz7CoHeey1Do36(int _0023_003Dz1HcCRuXf1eTz)
	{
		_0023_003Dz1HcCRuXf1eTz--;
		if (_0023_003Dz0_0024X6OcgLJhm7() != null && _0023_003DzsI28S7_HDT6V(_0023_003Dz1HcCRuXf1eTz))
		{
			Camera camera = _0023_003Dz09S_zoLRQE_7[_0023_003Dz1HcCRuXf1eTz];
			if (camera != null)
			{
				bool animateCamera = _0023_003Dz0_0024X6OcgLJhm7().AnimateCamera;
				_0023_003Dz0_0024X6OcgLJhm7().AnimateCamera = true;
				_0023_003Dz0_0024X6OcgLJhm7()._0023_003DzipBYly6zFKAp().RestoreView(camera);
				_0023_003Dz0_0024X6OcgLJhm7().AnimateCamera = animateCamera;
			}
		}
	}
}
