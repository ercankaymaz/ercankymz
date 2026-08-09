using System.Diagnostics;
using System.Runtime.InteropServices;

namespace devDept.Geometry;

public class TriangleTriangleIntersectionConverted
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003DzF6aJl54_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003DzffqPLNQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector3D _0023_003Dz5Azd7L8_003D;
	}

	public static int tri_tri_overlap_test_3d(Point3D p1, Point3D q1, Point3D r1, Point3D p2, Point3D q2, Point3D r2, out bool onlyTouch)
	{
		onlyTouch = false;
		_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D _0023_003DzzgMoCDNum9Tu = default(_0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D);
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = new Vector3D();
		_0023_003DzzgMoCDNum9Tu._0023_003Dz5Azd7L8_003D = new Vector3D();
		_0023_003DzzgMoCDNum9Tu._0023_003DzF6aJl54_003D = new Vector3D();
		Vector3D vector3D = new Vector3D();
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = Vector3D.Subtract(p2, r2);
		_0023_003DzzgMoCDNum9Tu._0023_003Dz5Azd7L8_003D = Vector3D.Subtract(q2, r2);
		vector3D = Vector3D.Cross(_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D, _0023_003DzzgMoCDNum9Tu._0023_003Dz5Azd7L8_003D);
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = Vector3D.Subtract(p1, r2);
		double num = Vector3D.Dot(_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D, vector3D);
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = (_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = Vector3D.Subtract(q1, r2));
		double num2 = Vector3D.Dot(_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D, vector3D);
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = (_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = Vector3D.Subtract(r2, r2));
		double num3 = Vector3D.Dot(_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D, vector3D);
		if (num * num2 > 0.0 && num * num3 > 0.0)
		{
			return 0;
		}
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = Vector3D.Subtract(q1, p1);
		_0023_003DzzgMoCDNum9Tu._0023_003Dz5Azd7L8_003D = Vector3D.Subtract(r1, p1);
		_0023_003DzzgMoCDNum9Tu._0023_003DzF6aJl54_003D = Vector3D.Cross(_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D, _0023_003DzzgMoCDNum9Tu._0023_003Dz5Azd7L8_003D);
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = Vector3D.Subtract(p2, r1);
		double num4 = Vector3D.Dot(_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D, _0023_003DzzgMoCDNum9Tu._0023_003DzF6aJl54_003D);
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = Vector3D.Subtract(q2, r1);
		double num5 = Vector3D.Dot(_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D, _0023_003DzzgMoCDNum9Tu._0023_003DzF6aJl54_003D);
		_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D = Vector3D.Subtract(r2, r1);
		double num6 = Vector3D.Dot(_0023_003DzzgMoCDNum9Tu._0023_003DzffqPLNQ_003D, _0023_003DzzgMoCDNum9Tu._0023_003DzF6aJl54_003D);
		if (num4 * num5 > 0.0 && num4 * num6 > 0.0)
		{
			return 0;
		}
		if (num > 0.0)
		{
			if (num2 > 0.0)
			{
				return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(r1, p1, q1, p2, r2, q2, num4, num6, num5, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
			}
			if (num3 > 0.0)
			{
				return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(q1, r1, p1, p2, r2, q2, num4, num6, num5, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
			}
			return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(p1, q1, r1, p2, q2, r2, num4, num5, num6, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (num < 0.0)
		{
			if (num2 < 0.0)
			{
				return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(r1, p1, q1, p2, q2, r2, num4, num5, num6, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
			}
			if (num3 < 0.0)
			{
				return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(q1, r1, p1, p2, q2, r2, num4, num5, num6, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
			}
			return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(p1, q1, r1, p2, r2, q2, num4, num6, num5, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (num2 < 0.0)
		{
			if (num3 >= 0.0)
			{
				return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(q1, r1, p1, p2, r2, q2, num4, num6, num5, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
			}
			return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(p1, q1, r1, p2, q2, r2, num4, num5, num6, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (num2 > 0.0)
		{
			if (num3 > 0.0)
			{
				return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(p1, q1, r1, p2, r2, q2, num4, num6, num5, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
			}
			return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(q1, r1, p1, p2, q2, r2, num4, num5, num6, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (num3 > 0.0)
		{
			return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(r1, p1, q1, p2, q2, r2, num4, num5, num6, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (num3 < 0.0)
		{
			return _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(r1, p1, q1, p2, r2, q2, num4, num6, num5, out onlyTouch, ref _0023_003DzzgMoCDNum9Tu);
		}
		onlyTouch = true;
		return _0023_003DzFPxlneVyN3jCywfxBc_0024QBuP62Yf3(p1, q1, r1, p2, q2, r2, _0023_003DzzgMoCDNum9Tu._0023_003DzF6aJl54_003D);
	}

	private static int _0023_003DzFPxlneVyN3jCywfxBc_0024QBuP62Yf3(Point3D _0023_003DzFj_0024IqDQ_003D, Point3D _0023_003Dz7ZE84gQ_003D, Point3D _0023_003Dzkzf4gQ0_003D, Point3D _0023_003DzjdeMMkk_003D, Point3D _0023_003DzYENOV_Q_003D, Point3D _0023_003DzKjjcAoU_003D, Vector3D _0023_003DzvZ8n5LJ1K2kp)
	{
		Point2D point2D = new Point2D();
		Point2D point2D2 = new Point2D();
		Point2D point2D3 = new Point2D();
		Point2D point2D4 = new Point2D();
		Point2D point2D5 = new Point2D();
		Point2D point2D6 = new Point2D();
		double num = ((_0023_003DzvZ8n5LJ1K2kp.X < 0.0) ? (0.0 - _0023_003DzvZ8n5LJ1K2kp[0]) : _0023_003DzvZ8n5LJ1K2kp[0]);
		double num2 = ((_0023_003DzvZ8n5LJ1K2kp[1] < 0.0) ? (0.0 - _0023_003DzvZ8n5LJ1K2kp[1]) : _0023_003DzvZ8n5LJ1K2kp[1]);
		double num3 = ((_0023_003DzvZ8n5LJ1K2kp[2] < 0.0) ? (0.0 - _0023_003DzvZ8n5LJ1K2kp[2]) : _0023_003DzvZ8n5LJ1K2kp[2]);
		if (num > num3 && num >= num2)
		{
			point2D.X = _0023_003Dz7ZE84gQ_003D.Z;
			point2D.Y = _0023_003Dz7ZE84gQ_003D.Y;
			point2D2.X = _0023_003DzFj_0024IqDQ_003D.Z;
			point2D2.Y = _0023_003DzFj_0024IqDQ_003D.Y;
			point2D3.X = _0023_003Dzkzf4gQ0_003D.Z;
			point2D3.Y = _0023_003Dzkzf4gQ0_003D.Y;
			point2D4.X = _0023_003DzYENOV_Q_003D.Z;
			point2D4.Y = _0023_003DzYENOV_Q_003D.Y;
			point2D5.X = _0023_003DzjdeMMkk_003D.Z;
			point2D5.Y = _0023_003DzjdeMMkk_003D.Y;
			point2D6.X = _0023_003DzKjjcAoU_003D.Z;
			point2D6.Y = _0023_003DzKjjcAoU_003D.Y;
		}
		else if (num2 > num3 && num2 >= num)
		{
			point2D.X = _0023_003Dz7ZE84gQ_003D.X;
			point2D.Y = _0023_003Dz7ZE84gQ_003D.Z;
			point2D2.X = _0023_003DzFj_0024IqDQ_003D.X;
			point2D2.Y = _0023_003DzFj_0024IqDQ_003D.Z;
			point2D3.X = _0023_003Dzkzf4gQ0_003D.X;
			point2D3.Y = _0023_003Dzkzf4gQ0_003D.Z;
			point2D4.X = _0023_003DzYENOV_Q_003D.X;
			point2D4.Y = _0023_003DzYENOV_Q_003D.Z;
			point2D5.X = _0023_003DzjdeMMkk_003D.X;
			point2D5.Y = _0023_003DzjdeMMkk_003D.Z;
			point2D6.X = _0023_003DzKjjcAoU_003D.X;
			point2D6.Y = _0023_003DzKjjcAoU_003D.Z;
		}
		else
		{
			point2D.X = _0023_003DzFj_0024IqDQ_003D.X;
			point2D.Y = _0023_003DzFj_0024IqDQ_003D.Y;
			point2D2.X = _0023_003Dz7ZE84gQ_003D.X;
			point2D2.Y = _0023_003Dz7ZE84gQ_003D.Y;
			point2D3.X = _0023_003Dzkzf4gQ0_003D.X;
			point2D3.Y = _0023_003Dzkzf4gQ0_003D.Y;
			point2D4.X = _0023_003DzjdeMMkk_003D.X;
			point2D4.Y = _0023_003DzjdeMMkk_003D.Y;
			point2D5.X = _0023_003DzYENOV_Q_003D.X;
			point2D5.Y = _0023_003DzYENOV_Q_003D.Y;
			point2D6.X = _0023_003DzKjjcAoU_003D.X;
			point2D6.Y = _0023_003DzKjjcAoU_003D.Y;
		}
		bool _0023_003DzNYdKxh_oRaFj;
		return _0023_003DzpXXk8tq7xSyebLEBb9MlKYasHVp4EWxuXg_003D_003D(point2D, point2D2, point2D3, point2D4, point2D5, point2D6, out _0023_003DzNYdKxh_oRaFj);
	}

	private static double _0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(Point2D _0023_003DzjbqS1qE_003D, Point2D _0023_003Dz1v6oPQk_003D, Point2D _0023_003Dzt_m8zV0_003D)
	{
		return (_0023_003DzjbqS1qE_003D.X - _0023_003Dzt_m8zV0_003D.X) * (_0023_003Dz1v6oPQk_003D.Y - _0023_003Dzt_m8zV0_003D.Y) - (_0023_003DzjbqS1qE_003D.Y - _0023_003Dzt_m8zV0_003D.Y) * (_0023_003Dz1v6oPQk_003D.X - _0023_003Dzt_m8zV0_003D.X);
	}

	private static int _0023_003DzCQV_G5OeWhUs4BMtha0T6_0024Tpnu4FGDPh5g_003D_003D(Point2D _0023_003DzZFWF0AM_003D, Point2D _0023_003DzfWhMsW4_003D, Point2D _0023_003DzALKvlmM_003D, Point2D _0023_003Dz_fdaZUE_003D, Point2D _0023_003DzTvN2_0024gY_003D, Point2D _0023_003DzAx1hkrk_003D)
	{
		if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzAx1hkrk_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzfWhMsW4_003D) >= 0.0)
		{
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzAx1hkrk_003D, _0023_003DzTvN2_0024gY_003D, _0023_003DzfWhMsW4_003D) <= 0.0)
			{
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzfWhMsW4_003D) > 0.0)
				{
					if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003DzTvN2_0024gY_003D, _0023_003DzfWhMsW4_003D) <= 0.0)
					{
						return 1;
					}
					return 0;
				}
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzALKvlmM_003D) >= 0.0)
				{
					if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzfWhMsW4_003D, _0023_003DzALKvlmM_003D, _0023_003Dz_fdaZUE_003D) >= 0.0)
					{
						return 1;
					}
					return 0;
				}
				return 0;
			}
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003DzTvN2_0024gY_003D, _0023_003DzfWhMsW4_003D) <= 0.0)
			{
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzAx1hkrk_003D, _0023_003DzTvN2_0024gY_003D, _0023_003DzALKvlmM_003D) <= 0.0)
				{
					if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzfWhMsW4_003D, _0023_003DzALKvlmM_003D, _0023_003DzTvN2_0024gY_003D) >= 0.0)
					{
						return 1;
					}
					return 0;
				}
				return 0;
			}
			return 0;
		}
		if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzAx1hkrk_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzALKvlmM_003D) >= 0.0)
		{
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzfWhMsW4_003D, _0023_003DzALKvlmM_003D, _0023_003DzAx1hkrk_003D) >= 0.0)
			{
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzALKvlmM_003D) >= 0.0)
				{
					return 1;
				}
				return 0;
			}
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzfWhMsW4_003D, _0023_003DzALKvlmM_003D, _0023_003DzTvN2_0024gY_003D) >= 0.0)
			{
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzAx1hkrk_003D, _0023_003DzALKvlmM_003D, _0023_003DzTvN2_0024gY_003D) >= 0.0)
				{
					return 1;
				}
				return 0;
			}
			return 0;
		}
		return 0;
	}

	private static int _0023_003DzLozO3AkCprtczmOLYSjSL0WR9j_0024vJAxgTQ_003D_003D(Point2D _0023_003DzZFWF0AM_003D, Point2D _0023_003DzfWhMsW4_003D, Point2D _0023_003DzALKvlmM_003D, Point2D _0023_003Dz_fdaZUE_003D, Point2D _0023_003DzTvN2_0024gY_003D, Point2D _0023_003DzAx1hkrk_003D)
	{
		if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzAx1hkrk_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzfWhMsW4_003D) >= 0.0)
		{
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzfWhMsW4_003D) >= 0.0)
			{
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003DzfWhMsW4_003D, _0023_003DzAx1hkrk_003D) >= 0.0)
				{
					return 1;
				}
				return 0;
			}
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzfWhMsW4_003D, _0023_003DzALKvlmM_003D, _0023_003Dz_fdaZUE_003D) >= 0.0)
			{
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzALKvlmM_003D, _0023_003DzZFWF0AM_003D, _0023_003Dz_fdaZUE_003D) >= 0.0)
				{
					return 1;
				}
				return 0;
			}
			return 0;
		}
		if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzAx1hkrk_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzALKvlmM_003D) >= 0.0)
		{
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003Dz_fdaZUE_003D, _0023_003DzALKvlmM_003D) >= 0.0)
			{
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzZFWF0AM_003D, _0023_003DzALKvlmM_003D, _0023_003DzAx1hkrk_003D) >= 0.0)
				{
					return 1;
				}
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzfWhMsW4_003D, _0023_003DzALKvlmM_003D, _0023_003DzAx1hkrk_003D) >= 0.0)
				{
					return 1;
				}
				return 0;
			}
			return 0;
		}
		return 0;
	}

	private static int _0023_003Dzw6PzEA1_0024JPBpyhS1FYiZmWEJuJC9eSRUamdxxcc_003D(Point2D _0023_003DzFj_0024IqDQ_003D, Point2D _0023_003Dz7ZE84gQ_003D, Point2D _0023_003Dzkzf4gQ0_003D, Point2D _0023_003DzjdeMMkk_003D, Point2D _0023_003DzYENOV_Q_003D, Point2D _0023_003DzKjjcAoU_003D)
	{
		if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzFj_0024IqDQ_003D) >= 0.0)
		{
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D, _0023_003DzFj_0024IqDQ_003D) >= 0.0)
			{
				if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzKjjcAoU_003D, _0023_003DzjdeMMkk_003D, _0023_003DzFj_0024IqDQ_003D) >= 0.0)
				{
					return 1;
				}
				return _0023_003DzLozO3AkCprtczmOLYSjSL0WR9j_0024vJAxgTQ_003D_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D);
			}
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzKjjcAoU_003D, _0023_003DzjdeMMkk_003D, _0023_003DzFj_0024IqDQ_003D) >= 0.0)
			{
				return _0023_003DzLozO3AkCprtczmOLYSjSL0WR9j_0024vJAxgTQ_003D_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003DzKjjcAoU_003D, _0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D);
			}
			return _0023_003DzCQV_G5OeWhUs4BMtha0T6_0024Tpnu4FGDPh5g_003D_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D);
		}
		if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D, _0023_003DzFj_0024IqDQ_003D) >= 0.0)
		{
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzKjjcAoU_003D, _0023_003DzjdeMMkk_003D, _0023_003DzFj_0024IqDQ_003D) >= 0.0)
			{
				return _0023_003DzLozO3AkCprtczmOLYSjSL0WR9j_0024vJAxgTQ_003D_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D, _0023_003DzjdeMMkk_003D);
			}
			return _0023_003DzCQV_G5OeWhUs4BMtha0T6_0024Tpnu4FGDPh5g_003D_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D, _0023_003DzjdeMMkk_003D);
		}
		return _0023_003DzCQV_G5OeWhUs4BMtha0T6_0024Tpnu4FGDPh5g_003D_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003DzKjjcAoU_003D, _0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D);
	}

	internal static int _0023_003DzpXXk8tq7xSyebLEBb9MlKYasHVp4EWxuXg_003D_003D(Point2D _0023_003DzFj_0024IqDQ_003D, Point2D _0023_003Dz7ZE84gQ_003D, Point2D _0023_003Dzkzf4gQ0_003D, Point2D _0023_003DzjdeMMkk_003D, Point2D _0023_003DzYENOV_Q_003D, Point2D _0023_003DzKjjcAoU_003D, out bool _0023_003DzNYdKxh_oRaFj)
	{
		_0023_003DzNYdKxh_oRaFj = false;
		if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D) < 0.0)
		{
			if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D) < 0.0)
			{
				return _0023_003Dzw6PzEA1_0024JPBpyhS1FYiZmWEJuJC9eSRUamdxxcc_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003Dz7ZE84gQ_003D, _0023_003DzjdeMMkk_003D, _0023_003DzKjjcAoU_003D, _0023_003DzYENOV_Q_003D);
			}
			return _0023_003Dzw6PzEA1_0024JPBpyhS1FYiZmWEJuJC9eSRUamdxxcc_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003Dz7ZE84gQ_003D, _0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D);
		}
		if (_0023_003DzwXC6_rFKjZpOxOBd5w_003D_003D(_0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D) < 0.0)
		{
			return _0023_003Dzw6PzEA1_0024JPBpyhS1FYiZmWEJuJC9eSRUamdxxcc_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003DzjdeMMkk_003D, _0023_003DzKjjcAoU_003D, _0023_003DzYENOV_Q_003D);
		}
		return _0023_003Dzw6PzEA1_0024JPBpyhS1FYiZmWEJuJC9eSRUamdxxcc_003D(_0023_003DzFj_0024IqDQ_003D, _0023_003Dz7ZE84gQ_003D, _0023_003Dzkzf4gQ0_003D, _0023_003DzjdeMMkk_003D, _0023_003DzYENOV_Q_003D, _0023_003DzKjjcAoU_003D);
	}

	internal static int _0023_003DqXbm9Uo2KvpydrNHP_jsATvLa2vmbCMK_DEcMFLbiSzN403Xb5YgFZk95SQKKde_Y(Point3D _0023_003DzrMBu8RQ_003D, Point3D _0023_003Dz3BgymYo_003D, Point3D _0023_003DzsK_kLJQ_003D, Point3D _0023_003DzoCXTP_0024c_003D, Point3D _0023_003DzjRk5a6g_003D, Point3D _0023_003Dzpdw6Uh4_003D, double _0023_003Dz8Bbx9T_0024Dkdn3, double _0023_003DzhDLkJGhHNA3f, double _0023_003DzRnQJPCQNJVgH, out bool _0023_003DzTRgz8u1_0024RDlmGNhgLQ_003D_003D, ref _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D _0023_003DzzgMoCDNum9Tu)
	{
		_0023_003DzTRgz8u1_0024RDlmGNhgLQ_003D_003D = false;
		if (_0023_003Dz8Bbx9T_0024Dkdn3 > 0.0)
		{
			if (_0023_003DzhDLkJGhHNA3f > 0.0)
			{
				return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003DzsK_kLJQ_003D, _0023_003Dz3BgymYo_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, ref _0023_003DzzgMoCDNum9Tu);
			}
			if (_0023_003DzRnQJPCQNJVgH > 0.0)
			{
				return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003DzsK_kLJQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzoCXTP_0024c_003D, ref _0023_003DzzgMoCDNum9Tu);
			}
			return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzsK_kLJQ_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (_0023_003Dz8Bbx9T_0024Dkdn3 < 0.0)
		{
			if (_0023_003DzhDLkJGhHNA3f < 0.0)
			{
				return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzsK_kLJQ_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, ref _0023_003DzzgMoCDNum9Tu);
			}
			if (_0023_003DzRnQJPCQNJVgH < 0.0)
			{
				return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzsK_kLJQ_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzoCXTP_0024c_003D, ref _0023_003DzzgMoCDNum9Tu);
			}
			return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003DzsK_kLJQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (_0023_003DzhDLkJGhHNA3f < 0.0)
		{
			if (_0023_003DzRnQJPCQNJVgH >= 0.0)
			{
				return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003DzsK_kLJQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzoCXTP_0024c_003D, ref _0023_003DzzgMoCDNum9Tu);
			}
			return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzsK_kLJQ_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (_0023_003DzhDLkJGhHNA3f > 0.0)
		{
			if (_0023_003DzRnQJPCQNJVgH > 0.0)
			{
				_0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003DzsK_kLJQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, ref _0023_003DzzgMoCDNum9Tu);
			}
			else
			{
				_0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzsK_kLJQ_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzoCXTP_0024c_003D, ref _0023_003DzzgMoCDNum9Tu);
			}
			return 0;
		}
		if (_0023_003DzRnQJPCQNJVgH > 0.0)
		{
			return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzsK_kLJQ_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, ref _0023_003DzzgMoCDNum9Tu);
		}
		if (_0023_003DzRnQJPCQNJVgH < 0.0)
		{
			return _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(_0023_003DzrMBu8RQ_003D, _0023_003DzsK_kLJQ_003D, _0023_003Dz3BgymYo_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, ref _0023_003DzzgMoCDNum9Tu);
		}
		_0023_003DzTRgz8u1_0024RDlmGNhgLQ_003D_003D = true;
		return _0023_003DzFPxlneVyN3jCywfxBc_0024QBuP62Yf3(_0023_003DzrMBu8RQ_003D, _0023_003Dz3BgymYo_003D, _0023_003DzsK_kLJQ_003D, _0023_003DzoCXTP_0024c_003D, _0023_003DzjRk5a6g_003D, _0023_003Dzpdw6Uh4_003D, _0023_003DzzgMoCDNum9Tu._0023_003DzF6aJl54_003D);
	}

	internal static int _0023_003Dqwl_r8e0tjytFkiOordMdHgIDJngjo1XtgtRqhYRzBu5Oz0LKiB1IZP6XbZOqkhdo(Point3D _0023_003DzrMBu8RQ_003D, Point3D _0023_003Dz3BgymYo_003D, Point3D _0023_003DzsK_kLJQ_003D, Point3D _0023_003DzoCXTP_0024c_003D, Point3D _0023_003DzjRk5a6g_003D, Point3D _0023_003Dzpdw6Uh4_003D, ref _0023_003DzJ0wy9bhjemv3bnsTuw_003D_003D _0023_003DzcNm9spY_003D)
	{
		_0023_003DzcNm9spY_003D._0023_003DzffqPLNQ_003D = Vector3D.Subtract(_0023_003DzoCXTP_0024c_003D, _0023_003Dz3BgymYo_003D);
		_0023_003DzcNm9spY_003D._0023_003Dz5Azd7L8_003D = Vector3D.Subtract(_0023_003DzrMBu8RQ_003D, _0023_003Dz3BgymYo_003D);
		_0023_003DzcNm9spY_003D._0023_003DzF6aJl54_003D = Vector3D.Cross(_0023_003DzcNm9spY_003D._0023_003DzffqPLNQ_003D, _0023_003DzcNm9spY_003D._0023_003Dz5Azd7L8_003D);
		_0023_003DzcNm9spY_003D._0023_003DzffqPLNQ_003D = Vector3D.Subtract(_0023_003DzjRk5a6g_003D, _0023_003Dz3BgymYo_003D);
		if (Vector3D.Dot(_0023_003DzcNm9spY_003D._0023_003DzffqPLNQ_003D, _0023_003DzcNm9spY_003D._0023_003DzF6aJl54_003D) > 0.0)
		{
			return 0;
		}
		_0023_003DzcNm9spY_003D._0023_003DzffqPLNQ_003D = Vector3D.Subtract(_0023_003DzoCXTP_0024c_003D, _0023_003DzrMBu8RQ_003D);
		_0023_003DzcNm9spY_003D._0023_003Dz5Azd7L8_003D = Vector3D.Subtract(_0023_003DzsK_kLJQ_003D, _0023_003DzrMBu8RQ_003D);
		_0023_003DzcNm9spY_003D._0023_003DzF6aJl54_003D = Vector3D.Cross(_0023_003DzcNm9spY_003D._0023_003DzffqPLNQ_003D, _0023_003DzcNm9spY_003D._0023_003Dz5Azd7L8_003D);
		_0023_003DzcNm9spY_003D._0023_003DzffqPLNQ_003D = Vector3D.Subtract(_0023_003Dzpdw6Uh4_003D, _0023_003DzrMBu8RQ_003D);
		if (Vector3D.Dot(_0023_003DzcNm9spY_003D._0023_003DzffqPLNQ_003D, _0023_003DzcNm9spY_003D._0023_003DzF6aJl54_003D) > 0.0)
		{
			return 0;
		}
		return 1;
	}
}
