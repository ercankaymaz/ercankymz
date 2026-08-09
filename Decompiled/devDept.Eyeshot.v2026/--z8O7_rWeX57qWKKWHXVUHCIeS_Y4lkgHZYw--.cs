using System.Collections.Generic;
using System.Linq;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;

internal static class _0023_003Dz8O7_rWeX57qWKKWHXVUHCIeS_Y4lkgHZYw_003D_003D
{
	private sealed class _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D
	{
		public Vector3D _0023_003DzgNguvTg_003D;

		public Vector3D _0023_003DzSkv4vYM_003D;

		public Vector3D _0023_003DzYKrEGCI_003D;

		public Vector3D _0023_003DzjMyoFdQ_003D;

		internal Vector3D _0023_003DziGCG7jxT5lCLqJThJBfbFio_003D(Vector3D _0023_003DzMlCq3wk_003D)
		{
			return _0023_003DzgNguvTg_003D + _0023_003DzSkv4vYM_003D * _0023_003DzMlCq3wk_003D.X + _0023_003DzYKrEGCI_003D * _0023_003DzMlCq3wk_003D.Y + _0023_003DzjMyoFdQ_003D * _0023_003DzMlCq3wk_003D.Z;
		}
	}

	private sealed class _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D
	{
		public Vector3D _0023_003DzgNguvTg_003D;

		public Vector3D _0023_003DzSkv4vYM_003D;

		public Vector3D _0023_003DzYKrEGCI_003D;

		public Vector3D _0023_003DzjMyoFdQ_003D;

		internal Vector3D _0023_003DzgBnCdZ_0024BwbOPWaUdQNLXMaw_003D(Vector3D _0023_003DzMlCq3wk_003D)
		{
			Vector3D u = _0023_003DzMlCq3wk_003D - _0023_003DzgNguvTg_003D;
			return new Vector3D(Vector3D.Dot(u, _0023_003DzSkv4vYM_003D), Vector3D.Dot(u, _0023_003DzYKrEGCI_003D), Vector3D.Dot(u, _0023_003DzjMyoFdQ_003D));
		}
	}

	public static Transformation _0023_003Dz7d5lgPw_003D(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return new Identity();
		}
		return new Align3D(Plane.XY, new Plane(new Point3D(_0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D().ToArray()), _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D(), _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D()));
	}

	public static ExpVector _0023_003DzKyvCwHrKUJHX(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, ExpVector _0023_003DzMlCq3wk_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzMlCq3wk_003D;
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D() + (ExpVector)_0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D() * _0023_003DzMlCq3wk_003D.x + (ExpVector)_0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D() * _0023_003DzMlCq3wk_003D.y + (ExpVector)_0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D() * _0023_003DzMlCq3wk_003D.z;
	}

	public static Vector3D _0023_003DzKyvCwHrKUJHX(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, Vector3D _0023_003DzMlCq3wk_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzMlCq3wk_003D;
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D() + _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D() * _0023_003DzMlCq3wk_003D.X + _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D() * _0023_003DzMlCq3wk_003D.Y + _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D() * _0023_003DzMlCq3wk_003D.Z;
	}

	public static Vector3D _0023_003DzQx9o0QDGKAFCfeNqSw_003D_003D(this Plane _0023_003Dzrgqz890sj_0024X9, ExpVector _0023_003DzCJkr8nY_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return new Vector3D(_0023_003DzCJkr8nY_003D.x.value, _0023_003DzCJkr8nY_003D.y.value, _0023_003DzCJkr8nY_003D.z.value);
		}
		return _0023_003Dzrgqz890sj_0024X9.AxisX * _0023_003DzCJkr8nY_003D.x.value + _0023_003Dzrgqz890sj_0024X9.AxisY * _0023_003DzCJkr8nY_003D.y.value + _0023_003Dzrgqz890sj_0024X9.AxisZ * _0023_003DzCJkr8nY_003D.z.value;
	}

	public static ExpVector _0023_003DzQx9o0QDGKAFCfeNqSw_003D_003D(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, ExpVector _0023_003DzCJkr8nY_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzCJkr8nY_003D;
		}
		return (ExpVector)_0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D() * _0023_003DzCJkr8nY_003D.x + (ExpVector)_0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D() * _0023_003DzCJkr8nY_003D.y + (ExpVector)_0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D() * _0023_003DzCJkr8nY_003D.z;
	}

	public static Vector3D _0023_003DzQx9o0QDGKAFCfeNqSw_003D_003D(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, Vector3D _0023_003DzCJkr8nY_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzCJkr8nY_003D;
		}
		return _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D() * _0023_003DzCJkr8nY_003D.X + _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D() * _0023_003DzCJkr8nY_003D.Y + _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D() * _0023_003DzCJkr8nY_003D.Z;
	}

	public static IEnumerable<Vector3D> _0023_003DzKyvCwHrKUJHX(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, IEnumerable<Vector3D> _0023_003DzrdSL0CI_003D)
	{
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2 = new _0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D();
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzrdSL0CI_003D;
		}
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzSkv4vYM_003D = _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D();
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzYKrEGCI_003D = _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D();
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzjMyoFdQ_003D = _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D();
		_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DzgNguvTg_003D = _0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D();
		return _0023_003DzrdSL0CI_003D.Select(_0023_003Dz6PSpej0vqJsoh9YkAA_003D_003D2._0023_003DziGCG7jxT5lCLqJThJBfbFio_003D);
	}

	public static ExpVector _0023_003DzUEEs1tMn0naq(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, ExpVector _0023_003DzMlCq3wk_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzMlCq3wk_003D;
		}
		ExpVector expVector = new ExpVector(0.0, 0.0, 0.0);
		ExpVector _0023_003DzjbqS1qE_003D = _0023_003DzMlCq3wk_003D - _0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D();
		expVector.x = ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D());
		expVector.y = ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D());
		expVector.z = ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzjbqS1qE_003D, _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D());
		return expVector;
	}

	public static Vector3D _0023_003DzUEEs1tMn0naq(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, Vector3D _0023_003DzMlCq3wk_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzMlCq3wk_003D;
		}
		Vector3D vector3D = new Vector3D(0.0, 0.0, 0.0);
		Vector3D u = _0023_003DzMlCq3wk_003D - _0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D();
		vector3D.X = Vector3D.Dot(u, _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D());
		vector3D.Y = Vector3D.Dot(u, _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D());
		vector3D.Z = Vector3D.Dot(u, _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D());
		return vector3D;
	}

	public static ExpVector _0023_003DzVstW_0024UycJxNGceLNLQ_003D_003D(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, ExpVector _0023_003DzCJkr8nY_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzCJkr8nY_003D;
		}
		return new ExpVector(0.0, 0.0, 0.0)
		{
			x = ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzCJkr8nY_003D, _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D()),
			y = ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzCJkr8nY_003D, _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D()),
			z = ExpVector._0023_003DzBWYOAtM_003D(_0023_003DzCJkr8nY_003D, _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D())
		};
	}

	public static Vector3D _0023_003DzVstW_0024UycJxNGceLNLQ_003D_003D(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, Vector3D _0023_003DzCJkr8nY_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzCJkr8nY_003D;
		}
		return new Vector3D(0.0, 0.0, 0.0)
		{
			X = Vector3D.Dot(_0023_003DzCJkr8nY_003D, _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D()),
			Y = Vector3D.Dot(_0023_003DzCJkr8nY_003D, _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D()),
			Z = Vector3D.Dot(_0023_003DzCJkr8nY_003D, _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D())
		};
	}

	public static Vector3D _0023_003Dzr2vS35aBVpn3(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, Vector3D _0023_003DzXULhp_00248_003D)
	{
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzXULhp_00248_003D;
		}
		Vector3D u = _0023_003DzXULhp_00248_003D - _0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D();
		double num = Vector3D.Dot(u, _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D());
		double num2 = Vector3D.Dot(u, _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D());
		return _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D() * num + _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D() * num2 + _0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D();
	}

	public static IEnumerable<Vector3D> _0023_003DzUEEs1tMn0naq(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dzrgqz890sj_0024X9, IEnumerable<Vector3D> _0023_003DzrdSL0CI_003D)
	{
		_0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D CS_0024_003C_003E8__locals8 = new _0023_003DzvfW21QWtGQPvLi57_W1rnfc_003D();
		if (_0023_003Dzrgqz890sj_0024X9 == null)
		{
			return _0023_003DzrdSL0CI_003D;
		}
		CS_0024_003C_003E8__locals8._0023_003DzSkv4vYM_003D = _0023_003Dzrgqz890sj_0024X9._0023_003DzGpzuFag_003D();
		CS_0024_003C_003E8__locals8._0023_003DzYKrEGCI_003D = _0023_003Dzrgqz890sj_0024X9._0023_003Dz2JFkIIQ_003D();
		CS_0024_003C_003E8__locals8._0023_003DzjMyoFdQ_003D = _0023_003Dzrgqz890sj_0024X9._0023_003DzhuTGsQI_003D();
		CS_0024_003C_003E8__locals8._0023_003DzgNguvTg_003D = _0023_003Dzrgqz890sj_0024X9._0023_003Dzq6RyJlc_003D();
		return _0023_003DzrdSL0CI_003D.Select(delegate(Vector3D _0023_003DzMlCq3wk_003D)
		{
			Vector3D u = _0023_003DzMlCq3wk_003D - CS_0024_003C_003E8__locals8._0023_003DzgNguvTg_003D;
			return new Vector3D(Vector3D.Dot(u, CS_0024_003C_003E8__locals8._0023_003DzSkv4vYM_003D), Vector3D.Dot(u, CS_0024_003C_003E8__locals8._0023_003DzYKrEGCI_003D), Vector3D.Dot(u, CS_0024_003C_003E8__locals8._0023_003DzjMyoFdQ_003D));
		});
	}

	public static ExpVector _0023_003Dz1binOM8_003D(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dz8SEdsjQ_003D, ExpVector _0023_003DzMlCq3wk_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003DzKV5V6WI_003D)
	{
		return _0023_003Dz8SEdsjQ_003D._0023_003DzUEEs1tMn0naq(_0023_003DzKV5V6WI_003D._0023_003DzKyvCwHrKUJHX(_0023_003DzMlCq3wk_003D));
	}

	public static Vector3D _0023_003Dz1binOM8_003D(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dz8SEdsjQ_003D, Vector3D _0023_003DzMlCq3wk_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003DzKV5V6WI_003D)
	{
		return _0023_003Dz8SEdsjQ_003D._0023_003DzUEEs1tMn0naq(_0023_003DzKV5V6WI_003D._0023_003DzKyvCwHrKUJHX(_0023_003DzMlCq3wk_003D));
	}

	public static IEnumerable<Vector3D> _0023_003Dz1binOM8_003D(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dz8SEdsjQ_003D, IEnumerable<Vector3D> _0023_003DzrdSL0CI_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003DzKV5V6WI_003D)
	{
		return _0023_003Dz8SEdsjQ_003D._0023_003DzUEEs1tMn0naq(_0023_003DzKV5V6WI_003D._0023_003DzKyvCwHrKUJHX(_0023_003DzrdSL0CI_003D));
	}

	public static ExpVector _0023_003DzSXhMXWF129li(this _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003Dz8SEdsjQ_003D, ExpVector _0023_003DzMlCq3wk_003D, _0023_003Dz1ZToPswoQiy814KiXxNxm3r82t5BvlVbsA_003D_003D _0023_003DzKV5V6WI_003D)
	{
		return _0023_003Dz8SEdsjQ_003D._0023_003DzVstW_0024UycJxNGceLNLQ_003D_003D(_0023_003DzKV5V6WI_003D._0023_003DzQx9o0QDGKAFCfeNqSw_003D_003D(_0023_003DzMlCq3wk_003D));
	}
}
