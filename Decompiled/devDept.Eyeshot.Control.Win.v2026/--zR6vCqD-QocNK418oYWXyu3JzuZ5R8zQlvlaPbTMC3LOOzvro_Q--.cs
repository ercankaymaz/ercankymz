using System;
using System.Linq;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Control.Mouse3D;
using devDept.Geometry;

internal sealed class _0023_003DzR6vCqD_0024QocNK418oYWXyu3JzuZ5R8zQlvlaPbTMC3LOOzvro_Q_003D_003D
{
	private sealed class _0023_003DzPK24kRtBITGlDr1Wjyf9Opw_003D
	{
		private Workspace _0023_003DzMZJX_0024FJ5BkH8;

		private bool _0023_003Dzu_l0TmVlvPbg;

		public _0023_003DzPK24kRtBITGlDr1Wjyf9Opw_003D(Workspace _0023_003Dzm1Aquqk_003D)
		{
			_0023_003DzMZJX_0024FJ5BkH8 = _0023_003Dzm1Aquqk_003D;
			_0023_003Dzu_l0TmVlvPbg = false;
		}

		public void _0023_003DzHjfFC64_003D(float[] _0023_003DzEnWtr1c_003D)
		{
			_0023_003Dzu_l0TmVlvPbg = 0.0 != (double)_0023_003DzEnWtr1c_003D[0] || 0.0 != (double)_0023_003DzEnWtr1c_003D[1] || 0.0 != (double)_0023_003DzEnWtr1c_003D[2] || 0.0 != (double)_0023_003DzEnWtr1c_003D[3] || 0.0 != (double)_0023_003DzEnWtr1c_003D[4] || 0.0 != (double)_0023_003DzEnWtr1c_003D[5];
			float[] array = (float[])_0023_003DzEnWtr1c_003D.Clone();
			if (!_0023_003DzMZJX_0024FJ5BkH8.Mouse3D.Enabled)
			{
				return;
			}
			if (!_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Rotate.Enabled)
			{
				array[3] = (array[4] = (array[5] = 0f));
			}
			if (_0023_003DzMZJX_0024FJ5BkH8.Mouse3D.SingleAxisFilter)
			{
				int num = 0;
				for (int i = 1; i < 6; i++)
				{
					if (Math.Abs(array[i]) > Math.Abs(array[num]))
					{
						array[num] = 0f;
						num = i;
					}
					else
					{
						array[i] = 0f;
					}
				}
			}
			_0023_003Dz99Ac7lA_003D(array);
			_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().AdjustNearAndFarPlanes();
		}

		public bool _0023_003Dzkmf1h86px6fX()
		{
			return _0023_003Dzu_l0TmVlvPbg;
		}

		public double[] _0023_003Dzpd4LDfaObgvX()
		{
			Point3D centerOfRotation = _0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.centerOfRotation;
			return new double[4]
			{
				centerOfRotation[0],
				centerOfRotation[1],
				centerOfRotation[2],
				1.0
			};
		}

		public void _0023_003Dzq7yG9fhKYgpL(double[] _0023_003DzvyGjKCAeW7Zj)
		{
			_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.centerOfRotation = new Point3D(_0023_003DzvyGjKCAeW7Zj);
		}

		private void _0023_003Dzc_0024YfsPlXBLGE(float[] _0023_003DzwJX1WcPTuBxj)
		{
			double[] array = new double[4]
			{
				_0023_003DzwJX1WcPTuBxj[0],
				_0023_003DzwJX1WcPTuBxj[1],
				_0023_003DzwJX1WcPTuBxj[2],
				1.0
			};
			double[] array2 = new double[4]
			{
				_0023_003DzwJX1WcPTuBxj[3],
				_0023_003DzwJX1WcPTuBxj[4],
				_0023_003DzwJX1WcPTuBxj[5],
				1.0
			};
			array2[0] *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView / 2.0));
			array2[1] *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView / 2.0));
			array[0] *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView / 2.0));
			array[1] *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView / 2.0));
			if (_0023_003DzMZJX_0024FJ5BkH8.Mouse3D.LockHorizon)
			{
				array2 = _0023_003Dz39veecdTWDS1G7dtAw_003D_003D(array2);
			}
			Transformation transformation = _0023_003DzAFXtcw3uk_pq(new Vector3D(array2));
			_0023_003Dzt4fJYr0_003D(transformation, new Vector3D(array));
			Vector3D _0023_003DzzRaskB_00243uPOQ;
			Vector3D _0023_003DzoqgctgRhDmC;
			Vector3D _0023_003Dz_0024llOZEdbyJnQ;
			Transformation cameraTransform = _0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.GetCameraTransform(out _0023_003DzzRaskB_00243uPOQ, out _0023_003DzoqgctgRhDmC, out _0023_003Dz_0024llOZEdbyJnQ, _0023_003Dz8_0BNKGtqVk_0024: false);
			cameraTransform *= transformation;
			_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.SetSceneTransformation(cameraTransform);
			if (_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.ProjectionMode != projectionType.Perspective)
			{
				_0023_003Dz3jmlI7U9O6rE(array[0]);
			}
		}

		private double[] _0023_003DzyB7YPoE_003D(Transformation _0023_003Dz7mKSiLg_003D)
		{
			return new double[4]
			{
				_0023_003Dz7mKSiLg_003D[0, 3],
				_0023_003Dz7mKSiLg_003D[1, 3],
				_0023_003Dz7mKSiLg_003D[2, 3],
				_0023_003Dz7mKSiLg_003D[3, 3]
			};
		}

		private Transformation _0023_003DzAFXtcw3uk_pq(Vector3D _0023_003DzfZZZs54_003D)
		{
			Vector3D vector3D = (Vector3D)_0023_003DzfZZZs54_003D.Clone();
			vector3D.Normalize();
			return _0023_003DzAFXtcw3uk_pq(_0023_003DzfZZZs54_003D.Length, vector3D);
		}

		private Transformation _0023_003DzAFXtcw3uk_pq(double _0023_003DzuiltSgU_003D, Vector3D _0023_003DzfZZZs54_003D)
		{
			if (Math.Abs(_0023_003DzuiltSgU_003D) < 1E-05)
			{
				return new Identity();
			}
			double x = _0023_003DzfZZZs54_003D.X;
			double y = _0023_003DzfZZZs54_003D.Y;
			double z = _0023_003DzfZZZs54_003D.Z;
			double num = Math.Cos(_0023_003DzuiltSgU_003D);
			double num2 = Math.Sin(_0023_003DzuiltSgU_003D);
			double num3 = 1.0 - num;
			return new Transformation(new double[4, 4]
			{
				{
					x * x * num3 + num,
					x * y * num3 - z * num2,
					x * z * num3 + y * num2,
					0.0
				},
				{
					y * x * num3 + z * num2,
					y * y * num3 + num,
					y * z * num3 - x * num2,
					0.0
				},
				{
					z * x * num3 - y * num2,
					z * y * num3 + x * num2,
					z * z * num3 + num,
					0.0
				},
				{ 0.0, 0.0, 0.0, 1.0 }
			});
		}

		private void _0023_003Dzt4fJYr0_003D(Transformation _0023_003Dz7mKSiLg_003D, Vector3D _0023_003Dz3kjjQlQ_003D)
		{
			_0023_003Dz7mKSiLg_003D[0, 3] = _0023_003Dz3kjjQlQ_003D.X;
			_0023_003Dz7mKSiLg_003D[1, 3] = _0023_003Dz3kjjQlQ_003D.Y;
			_0023_003Dz7mKSiLg_003D[2, 3] = _0023_003Dz3kjjQlQ_003D.Z;
		}

		private void _0023_003Dz_S2peTp8WzA8ILr57Q_003D_003D(float[] _0023_003DzwJX1WcPTuBxj)
		{
			double[] array = new double[4]
			{
				_0023_003DzwJX1WcPTuBxj[0],
				0f - _0023_003DzwJX1WcPTuBxj[1],
				_0023_003DzwJX1WcPTuBxj[2],
				1.0
			};
			double[] array2 = new double[4]
			{
				0.0,
				0f - _0023_003DzwJX1WcPTuBxj[4],
				_0023_003DzwJX1WcPTuBxj[5],
				1.0
			};
			array2[0] *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView) / 2.0);
			array2[1] *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView) / 2.0);
			array[0] *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView) / 2.0);
			array[1] *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView) / 2.0);
			Transformation transformation = _0023_003DzMttzWEnrvvnLf7Z8tQ_003D_003D();
			((Transformation)transformation.Clone()).Invert();
			Vector3D vector3D = new Vector3D(transformation[2, 0], transformation[2, 1], transformation[2, 2]);
			if (vector3D.Z < 0.0)
			{
				vector3D.Negate();
			}
			Vector3D vector3D2 = new Vector3D(1.0, 0.0, 0.0);
			Vector3D vector3D3 = Vector3D.Cross(vector3D2, vector3D);
			Transformation transformation2 = new Transformation(new double[16]
			{
				vector3D2.X, vector3D3.X, vector3D.X, 0.0, vector3D2.Y, vector3D3.Y, vector3D.Y, 0.0, vector3D2.Z, vector3D3.Z,
				vector3D.Z, 0.0, 0.0, 0.0, 0.0, 1.0
			});
			double[] v = Matrix.Multiply4x(transformation2.Matrix, array2);
			double[] array3 = Matrix.Multiply4x(transformation2.Matrix, array);
			double num = _0023_003Dz706b7LR_0024NKBB();
			array3 = new double[4]
			{
				num * array3[0],
				num * array3[1],
				num * array3[2],
				array3[3]
			};
			Transformation transformation3 = _0023_003DzAFXtcw3uk_pq(new Vector3D(v));
			_0023_003Dzt4fJYr0_003D(transformation3, new Vector3D(array3));
			transformation *= transformation3;
			_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.UpdateTarget(transformation);
			if (_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.ProjectionMode != projectionType.Perspective)
			{
				_0023_003Dz3jmlI7U9O6rE(array3[0]);
			}
		}

		private void _0023_003Dzd0dFZMYdMEot(float[] _0023_003DzwJX1WcPTuBxj)
		{
			float[] array = new float[6];
			for (int i = 0; i < 6; i++)
			{
				array[i] = 0f - _0023_003DzwJX1WcPTuBxj[i];
			}
			_0023_003Dz99Ac7lA_003D(array);
		}

		private void _0023_003Dz99Ac7lA_003D(float[] _0023_003DzwJX1WcPTuBxj)
		{
			Vector3D vector3D = new Vector3D(0f - _0023_003DzwJX1WcPTuBxj[0], 0f - _0023_003DzwJX1WcPTuBxj[1], 0f - _0023_003DzwJX1WcPTuBxj[2]);
			Vector3D vector3D2 = new Vector3D(0f - _0023_003DzwJX1WcPTuBxj[3], 0f - _0023_003DzwJX1WcPTuBxj[4], 0f - _0023_003DzwJX1WcPTuBxj[5]);
			vector3D.X *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView) / 2.0);
			vector3D.Y *= Math.Tan(Utility.DegToRad(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.HorizontalAngleOfView) / 2.0);
			Transformation transformation = _0023_003DzMttzWEnrvvnLf7Z8tQ_003D_003D();
			double[] _0023_003DzPl96w9ZVhc_0024q = _0023_003DzyB7YPoE_003D(transformation);
			Transformation obj = (Transformation)transformation.Clone();
			obj.Invert();
			double[] _0023_003Dz3kjjQlQ_003D = Matrix.Multiply4x((((Transformation)(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.SceneTransformation?.Clone())) ?? new Identity()).Matrix, _0023_003Dzpd4LDfaObgvX());
			double[] array = Matrix.Multiply4x(b: _0023_003Dzdom3TnV_0024lCec(_0023_003Dz3kjjQlQ_003D, _0023_003DzPl96w9ZVhc_0024q), a: _0023_003DzYC9_0024vzE_003D(obj));
			Identity identity = new Identity();
			_0023_003Dzt4fJYr0_003D(identity, new Vector3D(array[0], array[1], array[2]));
			vector3D *= _0023_003DzCpE4TZ4xM2eU(new Vector3D(array[0], array[1], array[2]).Length);
			if (_0023_003DzMZJX_0024FJ5BkH8.Mouse3D.LockHorizon)
			{
				vector3D2 = new Vector3D(_0023_003Dz39veecdTWDS1G7dtAw_003D_003D(new double[4]
				{
					vector3D2[0],
					vector3D2[1],
					vector3D2[2],
					1.0
				}));
			}
			Transformation transformation2 = _0023_003DzAFXtcw3uk_pq(vector3D2);
			_0023_003Dzt4fJYr0_003D(transformation2, vector3D);
			Transformation transformation3 = (Transformation)identity.Clone();
			transformation3.Invert();
			transformation2 = identity * transformation2 * transformation3;
			transformation *= transformation2;
			_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.UpdateTarget(transformation);
			if (_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.ProjectionMode != projectionType.Perspective)
			{
				_0023_003Dz3jmlI7U9O6rE(vector3D[0]);
			}
		}

		private Transformation _0023_003DzMttzWEnrvvnLf7Z8tQ_003D_003D()
		{
			_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.Rotation.ToMatrixInverse(out var matrix);
			Point3D location = _0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.Location;
			return new Transformation(matrix)
			{
				[0, 3] = location.X,
				[1, 3] = location.Y,
				[2, 3] = location.Z,
				[3, 3] = 1.0
			};
		}

		private double[] _0023_003Dzdom3TnV_0024lCec(double[] _0023_003Dz3kjjQlQ_003D, double[] _0023_003DzPl96w9ZVhc_0024q)
		{
			double[] array = (double[])_0023_003Dz3kjjQlQ_003D.Clone();
			if (array[3] != _0023_003DzPl96w9ZVhc_0024q[3])
			{
				array[0] = array[0] * _0023_003DzPl96w9ZVhc_0024q[3] - _0023_003DzPl96w9ZVhc_0024q[0] * array[3];
				array[1] = array[1] * _0023_003DzPl96w9ZVhc_0024q[3] - _0023_003DzPl96w9ZVhc_0024q[1] * array[3];
				array[2] = array[2] * _0023_003DzPl96w9ZVhc_0024q[3] - _0023_003DzPl96w9ZVhc_0024q[2] * array[3];
			}
			else
			{
				array[0] -= _0023_003DzPl96w9ZVhc_0024q[0];
				array[1] -= _0023_003DzPl96w9ZVhc_0024q[1];
				array[2] -= _0023_003DzPl96w9ZVhc_0024q[2];
			}
			array[3] *= _0023_003DzPl96w9ZVhc_0024q[3];
			return array;
		}

		private static double[,] _0023_003DzYC9_0024vzE_003D(Transformation _0023_003Dz7mKSiLg_003D)
		{
			double[,] array = new double[4, 4];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					array[i, j] = _0023_003Dz7mKSiLg_003D[i, j];
				}
			}
			array[3, 3] = 1.0;
			return array;
		}

		private double _0023_003Dz706b7LR_0024NKBB()
		{
			if (_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.ProjectionMode == projectionType.Perspective)
			{
				return Math.Min(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.Distance, _0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.FocalLength);
			}
			return _0023_003DzCpE4TZ4xM2eU(_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.Distance);
		}

		private void _0023_003Dz3jmlI7U9O6rE(double _0023_003DzOw5tB9c_003D)
		{
			_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.ZoomFactor *= 1.0 - 0.005 * _0023_003DzOw5tB9c_003D * _0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.ZoomFactor;
		}

		private double _0023_003DzCpE4TZ4xM2eU(double _0023_003Dzup_6nx8_003D)
		{
			if (_0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.ProjectionMode != projectionType.Perspective)
			{
				_0023_003Dzup_6nx8_003D = 2000.0 / _0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.ZoomFactor;
			}
			if (0.0 > _0023_003Dzup_6nx8_003D)
			{
				_0023_003Dzup_6nx8_003D = 0.0 - _0023_003Dzup_6nx8_003D;
			}
			if (_0023_003Dzup_6nx8_003D < _0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.Near)
			{
				_0023_003Dzup_6nx8_003D = _0023_003DzMZJX_0024FJ5BkH8._0023_003DzipBYly6zFKAp().Camera.Near;
			}
			return _0023_003Dzup_6nx8_003D;
		}

		public void _0023_003DzXis_6XIWOgeaY5Yu6A_003D_003D(double[] _0023_003DzvyGjKCAeW7Zj, Transformation _0023_003Dzm1Aquqk_003D)
		{
			if (Math.Abs(Math.Atan2(0.0 - _0023_003Dzm1Aquqk_003D[2, 0], Math.Sqrt(_0023_003Dzm1Aquqk_003D[2, 1] * _0023_003Dzm1Aquqk_003D[2, 1] + _0023_003Dzm1Aquqk_003D[2, 2] * _0023_003Dzm1Aquqk_003D[2, 2]))) > 1E-05)
			{
				double[,] array = Matrix.Inverse4(_0023_003Dzm1Aquqk_003D.Matrix);
				double[] array2 = Matrix.Multiply4x(array, _0023_003DzvyGjKCAeW7Zj);
				Vector3D vector3D = new Vector3D(0.0, array[1, 2], array[2, 2]);
				if (vector3D.Length < 1E-05)
				{
					vector3D.Z = 1.0;
				}
				vector3D.Normalize();
				Vector3D vector3D2 = new Vector3D(array[0, 1], array[1, 1], array[2, 1]);
				vector3D2.Normalize();
				Vector3D vector3D3 = Vector3D.Cross(vector3D2, vector3D);
				if (vector3D3.Length < 1E-05)
				{
					vector3D3 = new Vector3D(1.0, 0.0, 0.0);
				}
				else
				{
					vector3D3.Normalize();
				}
				vector3D2 = Vector3D.Cross(vector3D, vector3D3);
				array[0, 0] = vector3D3.X;
				array[1, 0] = vector3D3.Y;
				array[2, 0] = vector3D3.Z;
				array[0, 1] = vector3D2.X;
				array[1, 1] = vector3D2.Y;
				array[2, 1] = vector3D2.Z;
				array[0, 2] = vector3D.X;
				array[1, 2] = vector3D.Y;
				array[2, 2] = vector3D.Z;
				double[] array3 = Matrix.Multiply4x(array, _0023_003DzvyGjKCAeW7Zj.ToArray());
				array[0, 3] += array2[0] - array3[0];
				array[1, 3] += array2[1] - array3[1];
				array[2, 3] += array2[2] - array3[2];
				_0023_003Dzm1Aquqk_003D.Matrix = Matrix.Inverse4(array);
			}
		}

		private double[] _0023_003Dz39veecdTWDS1G7dtAw_003D_003D(double[] _0023_003DzvVs9ut3dI3sEUDh83w_003D_003D)
		{
			Vector3D v = new Vector3D(_0023_003DzvVs9ut3dI3sEUDh83w_003D_003D);
			Transformation transformation = _0023_003DzMttzWEnrvvnLf7Z8tQ_003D_003D();
			transformation.Invert();
			Vector3D vector3D = new Vector3D(transformation[0, 2], transformation[1, 2], transformation[2, 2]);
			Vector3D vector3D2 = new Vector3D(0.0, 1.0, 0.0);
			if (Math.Abs(vector3D.X) > 1E-05)
			{
				vector3D2 = Vector3D.Cross(vector3D, new Vector3D(1.0, 0.0, 1.0));
			}
			(new Quaternion(vector3D, Vector3D.Dot(vector3D, v)) * new Quaternion(vector3D2, Vector3D.Dot(vector3D2, v))).ToAxisAngle(out var rotAxis, out var rotAngleInDegrees);
			Vector3D vector3D3 = rotAxis * rotAngleInDegrees;
			return new double[4]
			{
				vector3D3[0],
				vector3D3[1],
				vector3D3[2],
				1.0
			};
		}
	}

	private float[] _0023_003DzEbpyAfkkkieNvNUiZl5GPXE_003D;

	private _0023_003DzPK24kRtBITGlDr1Wjyf9Opw_003D _0023_003DzB4j7eFicX_Cw;

	public _0023_003DzR6vCqD_0024QocNK418oYWXyu3JzuZ5R8zQlvlaPbTMC3LOOzvro_Q_003D_003D(Workspace _0023_003DzU0f5_qE_003D)
	{
		_0023_003DzB4j7eFicX_Cw = new _0023_003DzPK24kRtBITGlDr1Wjyf9Opw_003D(_0023_003DzU0f5_qE_003D);
	}

	public void _0023_003DzHjfFC64_003D(float[] _0023_003DzwJX1WcPTuBxj)
	{
		_0023_003DzB4j7eFicX_Cw._0023_003DzHjfFC64_003D(tdx._0023_003DzxbaFJ7Rfcr9BMZS9ZgZ5wfxa02VkPJfq_0024A_003D_003D(new float[6], _0023_003DzwJX1WcPTuBxj));
	}

	public float[] _0023_003DzsAZWUCanUTQA()
	{
		return _0023_003DzEbpyAfkkkieNvNUiZl5GPXE_003D;
	}

	public void _0023_003Dzdw6w2wq0WfPU(float[] _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzEbpyAfkkkieNvNUiZl5GPXE_003D = _0023_003DzsLHxXyo_003D;
	}

	public void _0023_003Dzq7yG9fhKYgpL(double[] _0023_003DzvyGjKCAeW7Zj)
	{
		_0023_003DzB4j7eFicX_Cw._0023_003Dzq7yG9fhKYgpL(_0023_003DzvyGjKCAeW7Zj);
	}

	public double[] _0023_003Dzpd4LDfaObgvX()
	{
		return _0023_003DzB4j7eFicX_Cw._0023_003Dzpd4LDfaObgvX();
	}

	public bool _0023_003DzzDEYSbA_003D()
	{
		return _0023_003DzB4j7eFicX_Cw._0023_003Dzkmf1h86px6fX();
	}

	public void _0023_003DzXis_6XIWOgeaY5Yu6A_003D_003D(Point3D _0023_003DzvyGjKCAeW7Zj, Quaternion _0023_003Dzm1Aquqk_003D)
	{
		_0023_003Dzm1Aquqk_003D.ToMatrix(out var matrix);
		Transformation transformation = new Transformation(matrix);
		_0023_003DzB4j7eFicX_Cw._0023_003DzXis_6XIWOgeaY5Yu6A_003D_003D(new double[4] { _0023_003DzvyGjKCAeW7Zj.X, _0023_003DzvyGjKCAeW7Zj.Y, _0023_003DzvyGjKCAeW7Zj.Z, 1.0 }, transformation);
		Quaternion quaternion = Camera.ToQuaternion(transformation);
		_0023_003Dzm1Aquqk_003D.W = quaternion.W;
		_0023_003Dzm1Aquqk_003D.X = quaternion.X;
		_0023_003Dzm1Aquqk_003D.Y = quaternion.Y;
		_0023_003Dzm1Aquqk_003D.Z = quaternion.Z;
	}
}
