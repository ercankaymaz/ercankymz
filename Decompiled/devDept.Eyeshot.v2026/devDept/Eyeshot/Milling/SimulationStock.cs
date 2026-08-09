using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Milling;

[Serializable]
public class SimulationStock : FastMesh
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<FastMesh, FastMesh> _0023_003DzW6VNWCUPEKb1Yg8DZQ_003D_003D;

		public static Func<FastMesh, FastMesh> _0023_003DzUQ508nGvSDVxH27uYw_003D_003D;

		internal FastMesh _0023_003DzEnOcDsicYApsUF4xdg_003D_003D(FastMesh _0023_003DzGGJSiQk_003D)
		{
			return (FastMesh)_0023_003DzGGJSiQk_003D.CloneWithTessellation();
		}

		internal FastMesh _0023_003Dz1W6pBkgRpGXdJv__mQ_003D_003D(FastMesh _0023_003DzGGJSiQk_003D)
		{
			return (FastMesh)_0023_003DzGGJSiQk_003D.Clone();
		}
	}

	internal readonly struct _0023_003DzB_002497lLiRwQhv
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly bool _0023_003DzBZ3TiCWHDp_0024e;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly Point3D _0023_003DzR58imxw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly Point3D _0023_003DzDNpeQO0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003Dz2s6gjYE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzopgN7_0024i7W_D8;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzqVRNkshAn6f_0024;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly Vector3D _0023_003DzHit7vU4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly Vector3D _0023_003DzMfbogc0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly Vector3D _0023_003Dz61IPlm0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly Vector3D _0023_003DziP9fFuA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzXrexKjY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzuwH5j5s_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003Dz7TFjJCU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzcNpWTdOzVsQA;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003Dz6keJbBDSuyzm;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzYBOcjt4_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003Dz2MpoULk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzxXbuS7U_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzC9RDGCE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003Dzrb4zYpQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzcP220pw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dzx09lyGU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzhKc9RKc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzaeGIvPI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dz8pYr37A_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003Dz7DQzmrTYXnpX;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DzK08qj5msg9Om;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003DziggqGQQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly double _0023_003Dz_MOP_QwhKSbz;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly Vector3D _0023_003DzWWgGxds_003D;

		public _0023_003DzB_002497lLiRwQhv(Point3D _0023_003DzuwH5j5s_003D, Point3D _0023_003DzbfrNXYE_003D, double _0023_003Dzxxb31SXSK4Ly, Point3D _0023_003DzDPcjoBJLcqli, EndMill _0023_003DzCE8nZ10WIX_0024z)
		{
			_0023_003DzWWgGxds_003D = new Vector3D();
			_0023_003DzR58imxw_003D = _0023_003DzuwH5j5s_003D;
			_0023_003DzDNpeQO0_003D = _0023_003DzbfrNXYE_003D;
			double _0023_003DzEGKj_0024SNUUihi = _0023_003DzCE8nZ10WIX_0024z._0023_003DzEGKj_0024SNUUihi;
			_0023_003DzopgN7_0024i7W_D8 = _0023_003DzEGKj_0024SNUUihi * _0023_003DzEGKj_0024SNUUihi;
			_0023_003DzqVRNkshAn6f_0024 = 0.0;
			_0023_003DzBZ3TiCWHDp_0024e = false;
			_0023_003DzHit7vU4_003D = new Vector3D(_0023_003DzuwH5j5s_003D, _0023_003DzbfrNXYE_003D);
			_0023_003Dz2s6gjYE_003D = _0023_003DzHit7vU4_003D.Length;
			_0023_003DzMfbogc0_003D = _0023_003DzHit7vU4_003D / _0023_003Dz2s6gjYE_003D;
			_0023_003DzXrexKjY_003D = Math.Sqrt(_0023_003DzHit7vU4_003D.X * _0023_003DzHit7vU4_003D.X + _0023_003DzHit7vU4_003D.Y * _0023_003DzHit7vU4_003D.Y);
			_0023_003Dz61IPlm0_003D = new Vector3D(_0023_003DzHit7vU4_003D.X / _0023_003DzXrexKjY_003D, _0023_003DzHit7vU4_003D.Y / _0023_003DzXrexKjY_003D, 0.0);
			_0023_003DziP9fFuA_003D = new Vector3D(_0023_003DzHit7vU4_003D.Y / _0023_003DzXrexKjY_003D, (0.0 - _0023_003DzHit7vU4_003D.X) / _0023_003DzXrexKjY_003D, 0.0);
			this._0023_003DzuwH5j5s_003D = _0023_003DzHit7vU4_003D.Z / _0023_003DzXrexKjY_003D;
			_0023_003Dz7TFjJCU_003D = this._0023_003DzuwH5j5s_003D * this._0023_003DzuwH5j5s_003D;
			_0023_003DzcNpWTdOzVsQA = 1.0 + _0023_003Dz7TFjJCU_003D;
			if (_0023_003DzR58imxw_003D.X > _0023_003DzDNpeQO0_003D.X)
			{
				_0023_003DzC9RDGCE_003D = _0023_003DzR58imxw_003D.X + _0023_003DzEGKj_0024SNUUihi;
				_0023_003DzxXbuS7U_003D = _0023_003DzDNpeQO0_003D.X - _0023_003DzEGKj_0024SNUUihi;
			}
			else
			{
				_0023_003DzC9RDGCE_003D = _0023_003DzDNpeQO0_003D.X + _0023_003DzEGKj_0024SNUUihi;
				_0023_003DzxXbuS7U_003D = _0023_003DzR58imxw_003D.X - _0023_003DzEGKj_0024SNUUihi;
			}
			if (_0023_003DzR58imxw_003D.Y > _0023_003DzDNpeQO0_003D.Y)
			{
				_0023_003DzcP220pw_003D = _0023_003DzR58imxw_003D.Y + _0023_003DzEGKj_0024SNUUihi;
				_0023_003Dzrb4zYpQ_003D = _0023_003DzDNpeQO0_003D.Y - _0023_003DzEGKj_0024SNUUihi;
			}
			else
			{
				_0023_003DzcP220pw_003D = _0023_003DzDNpeQO0_003D.Y + _0023_003DzEGKj_0024SNUUihi;
				_0023_003Dzrb4zYpQ_003D = _0023_003DzR58imxw_003D.Y - _0023_003DzEGKj_0024SNUUihi;
			}
			_0023_003Dz6keJbBDSuyzm = _0023_003Dzxxb31SXSK4Ly;
			_0023_003Dzx09lyGU_003D = (int)((_0023_003DzxXbuS7U_003D - _0023_003DzDPcjoBJLcqli.X) / _0023_003Dzxxb31SXSK4Ly);
			_0023_003DzhKc9RKc_003D = (int)((_0023_003DzC9RDGCE_003D - _0023_003DzDPcjoBJLcqli.X) / _0023_003Dzxxb31SXSK4Ly + 1.0);
			_0023_003DzaeGIvPI_003D = (int)((_0023_003Dzrb4zYpQ_003D - _0023_003DzDPcjoBJLcqli.Y) / _0023_003Dzxxb31SXSK4Ly);
			_0023_003Dz8pYr37A_003D = (int)((_0023_003DzcP220pw_003D - _0023_003DzDPcjoBJLcqli.Y) / _0023_003Dzxxb31SXSK4Ly + 1.0);
			if (_0023_003DzaeGIvPI_003D < 0)
			{
				_0023_003DzaeGIvPI_003D = 0;
			}
			if (_0023_003Dzx09lyGU_003D < 0)
			{
				_0023_003Dzx09lyGU_003D = 0;
			}
			_0023_003Dz7DQzmrTYXnpX = (_0023_003DzR58imxw_003D.X + _0023_003DzDNpeQO0_003D.X) / 2.0;
			_0023_003DzK08qj5msg9Om = (_0023_003DzR58imxw_003D.Y + _0023_003DzDNpeQO0_003D.Y) / 2.0;
			_0023_003DziggqGQQ_003D = 0.0;
			_0023_003Dz_MOP_QwhKSbz = 0.0;
			if (_0023_003DzHit7vU4_003D.Y != 0.0 && _0023_003DzHit7vU4_003D.X != 0.0)
			{
				_0023_003DziggqGQQ_003D = _0023_003DzEGKj_0024SNUUihi * _0023_003DzXrexKjY_003D / _0023_003DzHit7vU4_003D.Y;
				_0023_003Dz_MOP_QwhKSbz = _0023_003DzHit7vU4_003D.Y / _0023_003DzHit7vU4_003D.X;
			}
			_0023_003DzYBOcjt4_003D = _0023_003DzCE8nZ10WIX_0024z._0023_003Dz0lybwrA_003D(this._0023_003DzuwH5j5s_003D);
			_0023_003Dz2MpoULk_003D = _0023_003DzCE8nZ10WIX_0024z._0023_003Dzbkpk06c_003D(this._0023_003DzuwH5j5s_003D);
		}

		public _0023_003DzB_002497lLiRwQhv(Point3D _0023_003DzuwH5j5s_003D, Point3D _0023_003DzbfrNXYE_003D, double _0023_003DzEGKj_0024SNUUihi, double _0023_003DzRWO4WWv_0024sFb_0024_0024Z5ZCQ_003D_003D, double _0023_003Dzxxb31SXSK4Ly, Point3D _0023_003DzDPcjoBJLcqli, EndMill _0023_003DzCE8nZ10WIX_0024z)
		{
			_0023_003DzqVRNkshAn6f_0024 = _0023_003DzRWO4WWv_0024sFb_0024_0024Z5ZCQ_003D_003D;
			_0023_003DzBZ3TiCWHDp_0024e = true;
			_0023_003DzWWgGxds_003D = new Vector3D();
			_0023_003DzR58imxw_003D = _0023_003DzuwH5j5s_003D;
			_0023_003DzDNpeQO0_003D = _0023_003DzbfrNXYE_003D;
			_0023_003DzopgN7_0024i7W_D8 = _0023_003DzEGKj_0024SNUUihi * _0023_003DzEGKj_0024SNUUihi;
			_0023_003DzHit7vU4_003D = new Vector3D(_0023_003DzuwH5j5s_003D, _0023_003DzbfrNXYE_003D);
			_0023_003Dz2s6gjYE_003D = _0023_003DzHit7vU4_003D.Length;
			_0023_003DzMfbogc0_003D = _0023_003DzHit7vU4_003D / _0023_003Dz2s6gjYE_003D;
			_0023_003DzXrexKjY_003D = Math.Sqrt(_0023_003DzHit7vU4_003D.X * _0023_003DzHit7vU4_003D.X + _0023_003DzHit7vU4_003D.Y * _0023_003DzHit7vU4_003D.Y);
			_0023_003Dz61IPlm0_003D = new Vector3D(_0023_003DzHit7vU4_003D.X / _0023_003DzXrexKjY_003D, _0023_003DzHit7vU4_003D.Y / _0023_003DzXrexKjY_003D, 0.0);
			_0023_003DziP9fFuA_003D = new Vector3D(_0023_003DzHit7vU4_003D.Y / _0023_003DzXrexKjY_003D, (0.0 - _0023_003DzHit7vU4_003D.X) / _0023_003DzXrexKjY_003D, 0.0);
			this._0023_003DzuwH5j5s_003D = _0023_003DzHit7vU4_003D.Z / _0023_003DzXrexKjY_003D;
			_0023_003Dz7TFjJCU_003D = this._0023_003DzuwH5j5s_003D * this._0023_003DzuwH5j5s_003D;
			_0023_003DzcNpWTdOzVsQA = 1.0 + _0023_003Dz7TFjJCU_003D;
			if (_0023_003DzR58imxw_003D.X > _0023_003DzDNpeQO0_003D.X)
			{
				_0023_003DzC9RDGCE_003D = _0023_003DzR58imxw_003D.X + _0023_003DzqVRNkshAn6f_0024;
				_0023_003DzxXbuS7U_003D = _0023_003DzDNpeQO0_003D.X - _0023_003DzqVRNkshAn6f_0024;
			}
			else
			{
				_0023_003DzC9RDGCE_003D = _0023_003DzDNpeQO0_003D.X + _0023_003DzqVRNkshAn6f_0024;
				_0023_003DzxXbuS7U_003D = _0023_003DzR58imxw_003D.X - _0023_003DzqVRNkshAn6f_0024;
			}
			if (_0023_003DzR58imxw_003D.Y > _0023_003DzDNpeQO0_003D.Y)
			{
				_0023_003DzcP220pw_003D = _0023_003DzR58imxw_003D.Y + _0023_003DzqVRNkshAn6f_0024;
				_0023_003Dzrb4zYpQ_003D = _0023_003DzDNpeQO0_003D.Y - _0023_003DzqVRNkshAn6f_0024;
			}
			else
			{
				_0023_003DzcP220pw_003D = _0023_003DzDNpeQO0_003D.Y + _0023_003DzqVRNkshAn6f_0024;
				_0023_003Dzrb4zYpQ_003D = _0023_003DzR58imxw_003D.Y - _0023_003DzqVRNkshAn6f_0024;
			}
			_0023_003Dz6keJbBDSuyzm = _0023_003Dzxxb31SXSK4Ly;
			_0023_003Dzx09lyGU_003D = (int)((_0023_003DzxXbuS7U_003D - _0023_003DzDPcjoBJLcqli.X) / _0023_003Dzxxb31SXSK4Ly);
			_0023_003DzhKc9RKc_003D = (int)((_0023_003DzC9RDGCE_003D - _0023_003DzDPcjoBJLcqli.X) / _0023_003Dzxxb31SXSK4Ly + 1.0);
			_0023_003DzaeGIvPI_003D = (int)((_0023_003Dzrb4zYpQ_003D - _0023_003DzDPcjoBJLcqli.Y) / _0023_003Dzxxb31SXSK4Ly);
			_0023_003Dz8pYr37A_003D = (int)((_0023_003DzcP220pw_003D - _0023_003DzDPcjoBJLcqli.Y) / _0023_003Dzxxb31SXSK4Ly + 1.0);
			if (_0023_003DzaeGIvPI_003D < 0)
			{
				_0023_003DzaeGIvPI_003D = 0;
			}
			if (_0023_003Dzx09lyGU_003D < 0)
			{
				_0023_003Dzx09lyGU_003D = 0;
			}
			_0023_003Dz7DQzmrTYXnpX = (_0023_003DzR58imxw_003D.X + _0023_003DzDNpeQO0_003D.X) / 2.0;
			_0023_003DzK08qj5msg9Om = (_0023_003DzR58imxw_003D.Y + _0023_003DzDNpeQO0_003D.Y) / 2.0;
			_0023_003DziggqGQQ_003D = 0.0;
			_0023_003Dz_MOP_QwhKSbz = 0.0;
			if (_0023_003DzHit7vU4_003D.Y != 0.0 && _0023_003DzHit7vU4_003D.X != 0.0)
			{
				_0023_003DziggqGQQ_003D = _0023_003DzqVRNkshAn6f_0024 * _0023_003DzXrexKjY_003D / _0023_003DzHit7vU4_003D.Y;
				_0023_003Dz_MOP_QwhKSbz = _0023_003DzHit7vU4_003D.Y / _0023_003DzHit7vU4_003D.X;
			}
			_0023_003DzYBOcjt4_003D = _0023_003DzCE8nZ10WIX_0024z._0023_003Dz0lybwrA_003D(this._0023_003DzuwH5j5s_003D);
			_0023_003Dz2MpoULk_003D = _0023_003DzCE8nZ10WIX_0024z._0023_003Dzbkpk06c_003D(this._0023_003DzuwH5j5s_003D);
		}
	}

	private sealed class _0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c : IEnumerable<int>, IEnumerable, IEnumerator<int>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzezVIuujSK1H9;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzEGKj_0024SNUUihi;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzyIVlKPMtOM2bPzOUMg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzBJFJHwk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzgEhJ3eTBnUub;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public SimulationStock _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dz40R7bAU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzTu_0024tboysWhBu;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzJzXP7WVmLMWWgxghYw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzKJPUPJmpwvVwYCEh9w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzelkUxuqtNL_0024X;

		[DebuggerHidden]
		public _0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c(int _0023_003DzU7pGb3X7Zp4G)
		{
			this._0023_003DzU7pGb3X7Zp4G = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D()
		{
			_0023_003DzU7pGb3X7Zp4G = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zc0uzWO$CiiAh6KSB0g==
			this._0023_003Dzc0uzWO_0024CiiAh6KSB0g_003D_003D();
		}

		private bool MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			SimulationStock simulationStock = _0023_003DzopRx0_MBcTQs;
			switch (num)
			{
			default:
				return false;
			case 0:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzJzXP7WVmLMWWgxghYw_003D_003D = -_0023_003DzEGKj_0024SNUUihi;
				goto IL_0136;
			case 1:
				_0023_003DzU7pGb3X7Zp4G = -1;
				_0023_003DzezVIuujSK1H9 = _0023_003DzelkUxuqtNL_0024X + 3;
				_0023_003DzU7pGb3X7Zp4G = 2;
				return true;
			case 2:
				{
					_0023_003DzU7pGb3X7Zp4G = -1;
					goto IL_0105;
				}
				IL_0136:
				if (_0023_003DzJzXP7WVmLMWWgxghYw_003D_003D < _0023_003DzEGKj_0024SNUUihi)
				{
					_0023_003DzKJPUPJmpwvVwYCEh9w_003D_003D = -_0023_003DzEGKj_0024SNUUihi;
					goto IL_0115;
				}
				return false;
				IL_0105:
				_0023_003DzKJPUPJmpwvVwYCEh9w_003D_003D++;
				goto IL_0115;
				IL_0115:
				if (_0023_003DzKJPUPJmpwvVwYCEh9w_003D_003D < _0023_003DzEGKj_0024SNUUihi)
				{
					if (_0023_003DzBJFJHwk_003D + _0023_003DzKJPUPJmpwvVwYCEh9w_003D_003D >= 0 && _0023_003DzBJFJHwk_003D + _0023_003DzKJPUPJmpwvVwYCEh9w_003D_003D < simulationStock._colCount && _0023_003Dz40R7bAU_003D + _0023_003DzJzXP7WVmLMWWgxghYw_003D_003D >= 0 && _0023_003Dz40R7bAU_003D + _0023_003DzJzXP7WVmLMWWgxghYw_003D_003D < simulationStock._rowCount)
					{
						_0023_003DzelkUxuqtNL_0024X = 3 * ((_0023_003Dz40R7bAU_003D + _0023_003DzJzXP7WVmLMWWgxghYw_003D_003D) * simulationStock._colCount * 2 + (_0023_003DzBJFJHwk_003D + _0023_003DzKJPUPJmpwvVwYCEh9w_003D_003D) * 2);
						_0023_003DzezVIuujSK1H9 = _0023_003DzelkUxuqtNL_0024X;
						_0023_003DzU7pGb3X7Zp4G = 1;
						return true;
					}
					goto IL_0105;
				}
				_0023_003DzJzXP7WVmLMWWgxghYw_003D_003D++;
				goto IL_0136;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private int _0023_003Dz7b7kiIUfW2BP07CJYi08biDf8DOwYb9_cTrkosQ_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		int IEnumerator<int>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=z7b7kiIUfW2BP07CJYi08biDf8DOwYb9_cTrkosQ=
			return this._0023_003Dz7b7kiIUfW2BP07CJYi08biDf8DOwYb9_cTrkosQ_003D();
		}

		[DebuggerHidden]
		private void _0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zrmSvUIWk93$2zIiUzQ==
			this._0023_003DzrmSvUIWk93_00242zIiUzQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D()
		{
			return _0023_003DzezVIuujSK1H9;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zfCYrBzv_gLnXs9JxTTL2gC0=
			return this._0023_003DzfCYrBzv_gLnXs9JxTTL2gC0_003D();
		}

		[DebuggerHidden]
		private IEnumerator<int> _0023_003DzSy9VRJuSBvW2nH3tFNDUhdtNntNafD6xO_0024Yc1xU_003D()
		{
			_0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c _0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c2;
			if (_0023_003DzU7pGb3X7Zp4G == -2 && _0023_003DzE8i0kQxCCLZ6o49r0g_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003DzU7pGb3X7Zp4G = 0;
				_0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c2 = this;
			}
			else
			{
				_0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c2 = new _0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c(0);
				_0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c2._0023_003DzopRx0_MBcTQs = _0023_003DzopRx0_MBcTQs;
			}
			_0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c2._0023_003DzBJFJHwk_003D = _0023_003DzgEhJ3eTBnUub;
			_0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c2._0023_003Dz40R7bAU_003D = _0023_003DzTu_0024tboysWhBu;
			_0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c2._0023_003DzEGKj_0024SNUUihi = _0023_003DzyIVlKPMtOM2bPzOUMg_003D_003D;
			return _0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c2;
		}

		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zSy9VRJuSBvW2nH3tFNDUhdtNntNafD6xO$Yc1xU=
			return this._0023_003DzSy9VRJuSBvW2nH3tFNDUhdtNntNafD6xO_0024Yc1xU_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D()
		{
			return _0023_003DzSy9VRJuSBvW2nH3tFNDUhdtNntNafD6xO_0024Yc1xU_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zxlaRiWMi708Lt8Y54Oqd6Js=
			return this._0023_003DzxlaRiWMi708Lt8Y54Oqd6Js_003D();
		}
	}

	private readonly struct _0023_003DzgKtWFxEU7roE(int _0023_003DzxN8ClGE_003D, int _0023_003Dzfe2zeQMumw_4, float _0023_003DzvAxV_0024Ic_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003DzLJVtPYc_003D = _0023_003Dzfe2zeQMumw_4;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly int _0023_003Dz2pcnim4_003D = _0023_003DzxN8ClGE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public readonly float _0023_003DzxZNBMYc_003D = _0023_003DzvAxV_0024Ic_003D;
	}

	private sealed class _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D
	{
		public SimulationStock _0023_003DzopRx0_MBcTQs;

		public Point3D[] _0023_003DzrdSL0CI_003D;

		public EndMill _0023_003DzdgoGdiQ_003D;

		public bool _0023_003DzhRp3x7D8g_0024M_0024;

		public WorkUnit _0023_003Dz_IUshyU_003D;

		public string _0023_003Dz751t_uo_003D;

		public IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		public int _0023_003Dz8dK2uhU_003D;

		internal void _0023_003Dz1zQo227ukH0_0024GZMeLw_003D_003D(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			List<_0023_003DzgKtWFxEU7roE> list = new List<_0023_003DzgKtWFxEU7roE>();
			_0023_003DzopRx0_MBcTQs._0023_003DzO10UyzcvmoQs(_0023_003DzrdSL0CI_003D[_0023_003Dz437_00244ak_003D - 1], _0023_003DzrdSL0CI_003D[_0023_003Dz437_00244ak_003D], _0023_003DzdgoGdiQ_003D, list);
			if (_0023_003DzhRp3x7D8g_0024M_0024 && !_0023_003Dz_IUshyU_003D.UpdateProgressAndCheckCancelledParallel(_0023_003Dz8dK2uhU_003D, _0023_003Dz751t_uo_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
			byte r = _0023_003DzdgoGdiQ_003D.SimulationColor.R;
			byte g = _0023_003DzdgoGdiQ_003D.SimulationColor.G;
			byte b = _0023_003DzdgoGdiQ_003D.SimulationColor.B;
			for (int i = 0; i < list.Count; i++)
			{
				_0023_003DzgKtWFxEU7roE _0023_003DzgKtWFxEU7roE2 = list[i];
				FastMesh fastMesh = _0023_003DzopRx0_MBcTQs._0023_003DzOcZS3vc_003D(_0023_003DzgKtWFxEU7roE2._0023_003DzLJVtPYc_003D);
				lock (fastMesh.PointArray)
				{
					if (fastMesh.PointArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D] > _0023_003DzgKtWFxEU7roE2._0023_003DzxZNBMYc_003D)
					{
						fastMesh.PointArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D] = _0023_003DzgKtWFxEU7roE2._0023_003DzxZNBMYc_003D;
						if (fastMesh.ColorArray != null)
						{
							fastMesh.ColorArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D - 2] = r;
							fastMesh.ColorArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D - 1] = g;
							fastMesh.ColorArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D] = b;
						}
					}
				}
			}
		}
	}

	internal Point3D workMin;

	internal Point3D workMax;

	private int _rowCount;

	private int _colCount;

	[CompilerGenerated]
	private Transformation _003CTransformation_003Ek__BackingField = new Identity();

	private FastMesh[] _planarFaces;

	internal double GridStep;

	public int RowCount => _rowCount;

	public int ColCount => _colCount;

	internal SimulationStock(int _0023_003DzMT4aJgo_003D, int _0023_003DzspLc47s_003D)
	{
		_rowCount = _0023_003DzMT4aJgo_003D;
		_colCount = _0023_003DzspLc47s_003D;
		_0023_003DzO1QRfLc1l2pY(_0023_003DzPzO_0024GUk_003D: true);
	}

	protected SimulationStock(SimulationStock another, bool keepTessellation = false)
		: base(another, keepTessellation)
	{
		workMin = (Point3D)another.workMin.Clone();
		workMax = (Point3D)another.workMax.Clone();
		_planarFaces = new FastMesh[5];
		Func<FastMesh, FastMesh> func = (keepTessellation ? new Func<FastMesh, FastMesh>(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzEnOcDsicYApsUF4xdg_003D_003D) : new Func<FastMesh, FastMesh>(_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz1W6pBkgRpGXdJv__mQ_003D_003D));
		for (int i = 0; i < 5; i++)
		{
			_planarFaces[i] = func(another._planarFaces[i]);
		}
		_0023_003DznTv6jJyUD3Pu((Transformation)another._0023_003DzxdqexKR7jogJ().Clone());
		_rowCount = another._rowCount;
		_colCount = another._colCount;
		GridStep = another.GridStep;
	}

	protected internal SimulationStock(SimulationStockSurrogate surrogate)
		: base(surrogate)
	{
		if (surrogate.Version < 17)
		{
			FastMesh fastMesh = surrogate.PlanarFaces[4];
			Utility.ComputeBoundingBox(null, fastMesh.PointArray, fastMesh.PointArray.Length, 0, out workMin, out workMax);
			int num = base.PointArray.Length;
			float num2 = (float)workMax.Z;
			for (int i = 2; i < num; i += 3)
			{
				if (base.PointArray[i] > num2)
				{
					num2 = base.PointArray[i];
				}
			}
			workMax.Z = num2;
		}
		else
		{
			workMin = surrogate.WorkMin;
			workMax = surrogate.WorkMax;
		}
	}

	protected SimulationStock(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		_rowCount = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996403));
		_colCount = info.GetInt32(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996387));
		_planarFaces = (FastMesh[])info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996376), typeof(FastMesh[]));
		_0023_003DznTv6jJyUD3Pu((Transformation)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956915), typeof(Transformation)));
		int num = base.PointArray.Length;
		workMin = new Point3D(base.PointArray[0], base.PointArray[1], base.PointArray[2]);
		workMax = new Point3D(base.PointArray[num - 3], base.PointArray[num - 2], base.PointArray[num - 1]);
	}

	internal Transformation _0023_003DzxdqexKR7jogJ()
	{
		return _003CTransformation_003Ek__BackingField;
	}

	internal void _0023_003DznTv6jJyUD3Pu(Transformation _0023_003DzPzO_0024GUk_003D)
	{
		_003CTransformation_003Ek__BackingField = _0023_003DzPzO_0024GUk_003D;
	}

	public override object Clone()
	{
		return new SimulationStock(this);
	}

	public override object CloneWithTessellation()
	{
		return new SimulationStock(this, RegenMode != regenType.RegenAndCompile);
	}

	internal void _0023_003DzcXgJLqmScQn6(int _0023_003DzPzO_0024GUk_003D)
	{
		_rowCount = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzbLGjtcnuU4JQ(int _0023_003DzPzO_0024GUk_003D)
	{
		_colCount = _0023_003DzPzO_0024GUk_003D;
	}

	internal FastMesh[] _0023_003Dz5j0tqfhMCbKvunROsGB6t_I_003D()
	{
		return _planarFaces;
	}

	internal void _0023_003DzjVAq6NRHT43AT0faX93DxDI_003D(FastMesh[] _0023_003DzPzO_0024GUk_003D)
	{
		_planarFaces = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzdMcOIQtkEPFM(bool _0023_003DzeMBeuAQ_003D, int _0023_003Dz90qRVXE_003D, int _0023_003DzvbSuAQQ_003D)
	{
		int num = 3 * (_0023_003Dz90qRVXE_003D * _colCount * 2 + _0023_003DzvbSuAQQ_003D * 2);
		bool flag = base.TriangleArray[num + 3] != base.TriangleArray[num];
		if (_0023_003DzeMBeuAQ_003D && !flag)
		{
			base.TriangleArray[num + 2] = base.TriangleArray[num + 5];
			base.TriangleArray[num + 3] = base.TriangleArray[num + 1];
		}
		else if (!_0023_003DzeMBeuAQ_003D && flag)
		{
			base.TriangleArray[num + 3] = base.TriangleArray[num];
			base.TriangleArray[num + 2] = base.TriangleArray[num + 4];
		}
	}

	private void _0023_003Dz3CQxvV7Ao4_e(ref _0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, int _0023_003DzRwzUIoU_003D, int _0023_003DzO_0024xvpvo_003D, out int _0023_003DzegGaDKc_003D, out int _0023_003Dz0BdigYw_003D, out int _0023_003DzgAxxr7g_003D, out int _0023_003DzHENGGDk_003D)
	{
		_0023_003Dz0BdigYw_003D = ((_0023_003DzPo_ODtE_003D._0023_003Dz8pYr37A_003D - _0023_003DzPo_ODtE_003D._0023_003DzaeGIvPI_003D > _0023_003DzO_0024xvpvo_003D) ? (_0023_003DzO_0024xvpvo_003D - 1) : _0023_003DzPo_ODtE_003D._0023_003Dz8pYr37A_003D);
		_0023_003DzegGaDKc_003D = ((_0023_003DzPo_ODtE_003D._0023_003Dz8pYr37A_003D - _0023_003DzPo_ODtE_003D._0023_003DzaeGIvPI_003D <= _0023_003DzO_0024xvpvo_003D) ? _0023_003DzPo_ODtE_003D._0023_003DzaeGIvPI_003D : 0);
		_0023_003DzHENGGDk_003D = ((_0023_003DzPo_ODtE_003D._0023_003DzhKc9RKc_003D - _0023_003DzPo_ODtE_003D._0023_003Dzx09lyGU_003D > _0023_003DzRwzUIoU_003D) ? (_0023_003DzRwzUIoU_003D - 1) : _0023_003DzPo_ODtE_003D._0023_003DzhKc9RKc_003D);
		_0023_003DzgAxxr7g_003D = ((_0023_003DzPo_ODtE_003D._0023_003DzhKc9RKc_003D - _0023_003DzPo_ODtE_003D._0023_003Dzx09lyGU_003D <= _0023_003DzRwzUIoU_003D) ? _0023_003DzPo_ODtE_003D._0023_003Dzx09lyGU_003D : 0);
	}

	private (int, int, int) _0023_003DzN9Fpb2Gd2Ghg(int _0023_003DzyzK8swU_003D)
	{
		switch (_0023_003DzyzK8swU_003D)
		{
		case 0:
			return (_colCount + 1, _rowCount + 1, 1);
		case 1:
		case 3:
			return (_colCount + 1, 1, 2);
		case 2:
		case 4:
			return (1, _rowCount + 1, 2);
		default:
			return (0, 0, 0);
		}
	}

	private bool _0023_003DzUpi18zaCZLvO(float[] _0023_003DzrH1N0x4_003D, ref _0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D, EndMill _0023_003Dz3u03JZA_003D, int _0023_003Dz437_00244ak_003D, out double _0023_003DzId5C3LA_003D, out bool _0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D)
	{
		_0023_003DzId5C3LA_003D = 0.0;
		_0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D = false;
		double num = _0023_003DzrH1N0x4_003D[_0023_003Dz437_00244ak_003D];
		double num2 = _0023_003DzrH1N0x4_003D[_0023_003Dz437_00244ak_003D + 1];
		double _0023_003DzEM_vSEo_003D = _0023_003DzrH1N0x4_003D[_0023_003Dz437_00244ak_003D + 2];
		if (num < _0023_003DzPo_ODtE_003D._0023_003DzxXbuS7U_003D || num > _0023_003DzPo_ODtE_003D._0023_003DzC9RDGCE_003D || num2 < _0023_003DzPo_ODtE_003D._0023_003Dzrb4zYpQ_003D || num2 > _0023_003DzPo_ODtE_003D._0023_003DzcP220pw_003D)
		{
			return false;
		}
		double num3 = _0023_003DzPo_ODtE_003D._0023_003Dz7DQzmrTYXnpX - num;
		double num4 = _0023_003DzPo_ODtE_003D._0023_003DzK08qj5msg9Om - num2;
		double num5 = (_0023_003DzPo_ODtE_003D._0023_003DzBZ3TiCWHDp_0024e ? _0023_003DzPo_ODtE_003D._0023_003DzqVRNkshAn6f_0024 : _0023_003Dz3u03JZA_003D._0023_003DzEGKj_0024SNUUihi);
		if (num3 * num3 + num4 * num4 > (_0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D + num5) * (_0023_003DzPo_ODtE_003D._0023_003DzXrexKjY_003D + num5))
		{
			return false;
		}
		double num6 = num - _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.X;
		double num7 = _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y + _0023_003DzPo_ODtE_003D._0023_003Dz_MOP_QwhKSbz * (num6 - _0023_003DzPo_ODtE_003D._0023_003DziggqGQQ_003D);
		double num8 = _0023_003DzPo_ODtE_003D._0023_003DzR58imxw_003D.Y + _0023_003DzPo_ODtE_003D._0023_003Dz_MOP_QwhKSbz * (num6 + _0023_003DzPo_ODtE_003D._0023_003DziggqGQQ_003D);
		if (_0023_003DzPo_ODtE_003D._0023_003Dz_MOP_QwhKSbz != 0.0 && (num2 > ((num7 > num8) ? num7 : num8) || num2 < ((num7 < num8) ? num7 : num8)))
		{
			return false;
		}
		return _0023_003Dz3u03JZA_003D._0023_003DzUpi18zaCZLvO(ref _0023_003DzPo_ODtE_003D, num, num2, _0023_003DzEM_vSEo_003D, out _0023_003DzId5C3LA_003D, out _0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D);
	}

	public void Cut(Toolpath.LinearMotion linMotion, EndMill endMill, CompileParams data = null)
	{
		Cut(linMotion.StartPoint, linMotion.EndPoint, endMill, data != null, data != null, data);
	}

	public void Cut(Point3D startPos, Point3D endPos, EndMill endMill, CompileParams data = null)
	{
		Cut(startPos, endPos, endMill, data != null, data != null, data);
	}

	public bool Cut(Point3D startPos, Point3D endPos, EndMill endMill, bool computeDiagonals, bool computeNormals, CompileParams data = null)
	{
		bool result = false;
		if (endPos.Z >= workMax.Z && startPos.Z >= workMax.Z)
		{
			return result;
		}
		_0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D = ((endMill is Tool { CollisionRadius: >0.0 }) ? new _0023_003DzB_002497lLiRwQhv(startPos, endPos, endMill._0023_003DzEGKj_0024SNUUihi, ((Tool)endMill).CollisionRadius, GridStep, workMin, endMill) : new _0023_003DzB_002497lLiRwQhv(startPos, endPos, GridStep, workMin, endMill));
		byte r = endMill.SimulationColor.R;
		byte g = endMill.SimulationColor.G;
		byte b = endMill.SimulationColor.B;
		for (int i = 0; i < 6; i++)
		{
			FastMesh fastMesh = _0023_003DzOcZS3vc_003D(i);
			float[] pointArray = fastMesh.PointArray;
			(int, int, int) tuple = _0023_003DzN9Fpb2Gd2Ghg(i);
			int item = tuple.Item1;
			int item2 = tuple.Item2;
			int num = tuple.Item3 - 1;
			bool flag = pointArray[1] > pointArray[4];
			bool flag2 = pointArray[0] > pointArray[3];
			_0023_003Dz3CQxvV7Ao4_e(ref _0023_003DzPo_ODtE_003D, item, item2, out var _0023_003DzegGaDKc_003D, out var _0023_003Dz0BdigYw_003D, out var _0023_003DzgAxxr7g_003D, out var _0023_003DzHENGGDk_003D);
			List<int> list = new List<int>();
			bool _0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D = false;
			for (int j = _0023_003DzegGaDKc_003D; j <= _0023_003Dz0BdigYw_003D; j++)
			{
				for (int k = _0023_003DzgAxxr7g_003D; k <= _0023_003DzHENGGDk_003D; k++)
				{
					int num2 = (num * item2 * item + (flag ? (item2 - j - 1) : j) * item + (flag2 ? (item - k - 1) : k)) * 3;
					if (num2 < 0 || num2 + 2 >= pointArray.Length)
					{
						continue;
					}
					double _0023_003DzId5C3LA_003D;
					bool num3 = _0023_003DzUpi18zaCZLvO(pointArray, ref _0023_003DzPo_ODtE_003D, endMill, num2, out _0023_003DzId5C3LA_003D, out _0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D);
					if (_0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D)
					{
						result = true;
					}
					if (!num3)
					{
						continue;
					}
					if ((double)pointArray[num2 + 2] > _0023_003DzId5C3LA_003D)
					{
						pointArray[num2 + 2] = (float)_0023_003DzId5C3LA_003D;
						if (i == 0)
						{
							if (computeDiagonals)
							{
								if (j > 0)
								{
									if (k > 0)
									{
										_0023_003Dz_6FuAAdsqd7Fejr_00246apKWzI_003D(j - 1, k - 1, _0023_003Dz1wjrnkk_003D: false);
									}
									if (k < _colCount)
									{
										_0023_003Dz_6FuAAdsqd7Fejr_00246apKWzI_003D(j - 1, k, _0023_003Dz1wjrnkk_003D: false);
									}
								}
								if (j < _rowCount)
								{
									if (k > 0)
									{
										_0023_003Dz_6FuAAdsqd7Fejr_00246apKWzI_003D(j, k - 1, _0023_003Dz1wjrnkk_003D: false);
									}
									if (k < _colCount)
									{
										_0023_003Dz_6FuAAdsqd7Fejr_00246apKWzI_003D(j, k, _0023_003Dz1wjrnkk_003D: false);
									}
								}
							}
							if (_0023_003DznzO_0024H5wCu3wXbNTJgA_003D_003D)
							{
								fastMesh.ColorArray[num2] = byte.MaxValue;
								fastMesh.ColorArray[num2 + 1] = 0;
								fastMesh.ColorArray[num2 + 2] = 0;
							}
							else
							{
								fastMesh.ColorArray[num2] = r;
								fastMesh.ColorArray[num2 + 1] = g;
								fastMesh.ColorArray[num2 + 2] = b;
							}
						}
					}
					if (i == 0 && computeNormals)
					{
						list.Add(num2);
					}
				}
			}
			foreach (int item3 in list)
			{
				int num4 = item3 / 3;
				int num5 = num4 / item;
				int num6 = num4 - num5 * item;
				double num8;
				double num9;
				double num10;
				double num7 = (num8 = (num9 = (num10 = pointArray[item3 + 2])));
				if (num6 > 0)
				{
					num7 = pointArray[item3 + 2 - 3];
				}
				if (num6 < item - 1)
				{
					num8 = pointArray[item3 + 2 + 3];
				}
				if (num5 > 0)
				{
					num9 = pointArray[item3 + 2 - item * 3];
				}
				if (num5 < item2 - 1)
				{
					num10 = pointArray[item3 + 2 + item * 3];
				}
				double num11 = num7 - num8;
				double num12 = num9 - num10;
				double num13 = 2.0 * GridStep;
				double num14 = Math.Sqrt(num11 * num11 + num12 * num12 + num13 * num13);
				base.NormalArray[item3] = (float)(num11 / num14);
				base.NormalArray[item3 + 1] = (float)(num12 / num14);
				base.NormalArray[item3 + 2] = (float)(num13 / num14);
			}
			if (data != null)
			{
				fastMesh.Compile(data);
			}
		}
		return result;
	}

	private void _0023_003DzO10UyzcvmoQs(Point3D _0023_003DzCREyuzFnGFhJ, Point3D _0023_003Dzd0BdYTOO4URZ, EndMill _0023_003DzCE8nZ10WIX_0024z, List<_0023_003DzgKtWFxEU7roE> _0023_003DzOLHnb2M_003D)
	{
		if (_0023_003Dzd0BdYTOO4URZ.Z >= workMax.Z && _0023_003DzCREyuzFnGFhJ.Z >= workMax.Z)
		{
			return;
		}
		_0023_003DzB_002497lLiRwQhv _0023_003DzPo_ODtE_003D = new _0023_003DzB_002497lLiRwQhv(_0023_003DzCREyuzFnGFhJ, _0023_003Dzd0BdYTOO4URZ, GridStep, workMin, _0023_003DzCE8nZ10WIX_0024z);
		for (int i = 0; i < 6; i++)
		{
			float[] pointArray = _0023_003DzOcZS3vc_003D(i).PointArray;
			(int, int, int) tuple = _0023_003DzN9Fpb2Gd2Ghg(i);
			int item = tuple.Item1;
			int item2 = tuple.Item2;
			int num = tuple.Item3 - 1;
			bool flag = pointArray[1] > pointArray[4];
			bool flag2 = pointArray[0] > pointArray[3];
			_0023_003Dz3CQxvV7Ao4_e(ref _0023_003DzPo_ODtE_003D, item, item2, out var _0023_003DzegGaDKc_003D, out var _0023_003Dz0BdigYw_003D, out var _0023_003DzgAxxr7g_003D, out var _0023_003DzHENGGDk_003D);
			for (int j = _0023_003DzegGaDKc_003D; j <= _0023_003Dz0BdigYw_003D; j++)
			{
				for (int k = _0023_003DzgAxxr7g_003D; k <= _0023_003DzHENGGDk_003D; k++)
				{
					int num2 = (num * item2 * item + (flag ? (item2 - j - 1) : j) * item + (flag2 ? (item - k - 1) : k)) * 3;
					if (num2 >= 0 && num2 + 2 < pointArray.Length && _0023_003DzUpi18zaCZLvO(pointArray, ref _0023_003DzPo_ODtE_003D, _0023_003DzCE8nZ10WIX_0024z, num2, out var _0023_003DzId5C3LA_003D, out var _) && (double)pointArray[num2 + 2] > _0023_003DzId5C3LA_003D)
					{
						_0023_003DzOLHnb2M_003D.Add(new _0023_003DzgKtWFxEU7roE(num2 + 2, i, (float)_0023_003DzId5C3LA_003D));
					}
				}
			}
		}
	}

	public void Cut(Point3D[] points, EndMill tool, int from = 0, int to = -1)
	{
		Cut(points, tool, null, null, from, to);
	}

	internal void Cut(Point3D[] _0023_003DzrdSL0CI_003D, EndMill _0023_003DzdgoGdiQ_003D, WorkUnit _0023_003Dz_IUshyU_003D, string _0023_003Dz751t_uo_003D, int _0023_003DzKV5V6WI_003D = 0, int _0023_003Dz8SEdsjQ_003D = -1, IProgress<WorkUnit.ProgressChangedEventArgs> _0023_003DzmHS7frs_003D = null, CancellationToken _0023_003Dzjvn7P10_003D = default(CancellationToken))
	{
		_0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D CS_0024_003C_003E8__locals27 = new _0023_003DzkSH25EoVN_0024Er0815MQX5rXg_003D();
		CS_0024_003C_003E8__locals27._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals27._0023_003DzrdSL0CI_003D = _0023_003DzrdSL0CI_003D;
		CS_0024_003C_003E8__locals27._0023_003DzdgoGdiQ_003D = _0023_003DzdgoGdiQ_003D;
		CS_0024_003C_003E8__locals27._0023_003Dz_IUshyU_003D = _0023_003Dz_IUshyU_003D;
		CS_0024_003C_003E8__locals27._0023_003Dz751t_uo_003D = _0023_003Dz751t_uo_003D;
		CS_0024_003C_003E8__locals27._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		CS_0024_003C_003E8__locals27._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		CS_0024_003C_003E8__locals27._0023_003DzhRp3x7D8g_0024M_0024 = CS_0024_003C_003E8__locals27._0023_003Dz_IUshyU_003D != null && CS_0024_003C_003E8__locals27._0023_003DzmHS7frs_003D != null;
		if (_0023_003Dz8SEdsjQ_003D < 0)
		{
			_0023_003Dz8SEdsjQ_003D = CS_0024_003C_003E8__locals27._0023_003DzrdSL0CI_003D.Length;
		}
		CS_0024_003C_003E8__locals27._0023_003Dz_IUshyU_003D?.ResetProgressParallel();
		CS_0024_003C_003E8__locals27._0023_003Dz8dK2uhU_003D = _0023_003Dz8SEdsjQ_003D - _0023_003DzKV5V6WI_003D - 1;
		Parallel.For(_0023_003DzKV5V6WI_003D + 1, _0023_003Dz8SEdsjQ_003D, delegate(int _0023_003Dz437_00244ak_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			List<_0023_003DzgKtWFxEU7roE> list = new List<_0023_003DzgKtWFxEU7roE>();
			CS_0024_003C_003E8__locals27._0023_003DzopRx0_MBcTQs._0023_003DzO10UyzcvmoQs(CS_0024_003C_003E8__locals27._0023_003DzrdSL0CI_003D[_0023_003Dz437_00244ak_003D - 1], CS_0024_003C_003E8__locals27._0023_003DzrdSL0CI_003D[_0023_003Dz437_00244ak_003D], CS_0024_003C_003E8__locals27._0023_003DzdgoGdiQ_003D, list);
			if (CS_0024_003C_003E8__locals27._0023_003DzhRp3x7D8g_0024M_0024 && !CS_0024_003C_003E8__locals27._0023_003Dz_IUshyU_003D.UpdateProgressAndCheckCancelledParallel(CS_0024_003C_003E8__locals27._0023_003Dz8dK2uhU_003D, CS_0024_003C_003E8__locals27._0023_003Dz751t_uo_003D, CS_0024_003C_003E8__locals27._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals27._0023_003Dzjvn7P10_003D))
			{
				_0023_003DzLdZiL78_003D.Stop();
			}
			byte r = CS_0024_003C_003E8__locals27._0023_003DzdgoGdiQ_003D.SimulationColor.R;
			byte g = CS_0024_003C_003E8__locals27._0023_003DzdgoGdiQ_003D.SimulationColor.G;
			byte b = CS_0024_003C_003E8__locals27._0023_003DzdgoGdiQ_003D.SimulationColor.B;
			for (int i = 0; i < list.Count; i++)
			{
				_0023_003DzgKtWFxEU7roE _0023_003DzgKtWFxEU7roE2 = list[i];
				FastMesh fastMesh = CS_0024_003C_003E8__locals27._0023_003DzopRx0_MBcTQs._0023_003DzOcZS3vc_003D(_0023_003DzgKtWFxEU7roE2._0023_003DzLJVtPYc_003D);
				lock (fastMesh.PointArray)
				{
					if (fastMesh.PointArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D] > _0023_003DzgKtWFxEU7roE2._0023_003DzxZNBMYc_003D)
					{
						fastMesh.PointArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D] = _0023_003DzgKtWFxEU7roE2._0023_003DzxZNBMYc_003D;
						if (fastMesh.ColorArray != null)
						{
							fastMesh.ColorArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D - 2] = r;
							fastMesh.ColorArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D - 1] = g;
							fastMesh.ColorArray[_0023_003DzgKtWFxEU7roE2._0023_003Dz2pcnim4_003D] = b;
						}
					}
				}
			}
		});
	}

	private int _0023_003Dzq91c5t4YKd_s(int _0023_003DzmU5Omyo_003D, int _0023_003DzAty8hZk_003D)
	{
		return 3 * (_colCount + 1) * _0023_003DzAty8hZk_003D + _0023_003DzmU5Omyo_003D * 3;
	}

	private void _0023_003Dz_6FuAAdsqd7Fejr_00246apKWzI_003D(int _0023_003Dz90qRVXE_003D, int _0023_003DzvbSuAQQ_003D, bool _0023_003Dz1wjrnkk_003D)
	{
		int num = _0023_003Dzq91c5t4YKd_s(_0023_003DzvbSuAQQ_003D, _0023_003Dz90qRVXE_003D) + 2;
		int num2 = num + 3;
		int num3 = _0023_003Dzq91c5t4YKd_s(_0023_003DzvbSuAQQ_003D, _0023_003Dz90qRVXE_003D + 1) + 2;
		int num4 = num3 + 3;
		float num5 = base.PointArray[num];
		float num6 = base.PointArray[num2];
		float num7 = base.PointArray[num3];
		bool flag = Math.Abs(base.PointArray[num4] - num5) > Math.Abs(num7 - num6);
		if (flag || !_0023_003Dz1wjrnkk_003D)
		{
			_0023_003DzdMcOIQtkEPFM(flag, _0023_003Dz90qRVXE_003D, _0023_003DzvbSuAQQ_003D);
		}
	}

	internal void _0023_003DzR_IIhqyn5_prcagI0Q_003D_003D(bool _0023_003Dz45thxeUyuKPZ)
	{
		for (int i = 0; i < _rowCount; i++)
		{
			for (int j = 0; j < _colCount; j++)
			{
				_0023_003Dz_6FuAAdsqd7Fejr_00246apKWzI_003D(i, j, _0023_003Dz45thxeUyuKPZ);
			}
		}
	}

	[IteratorStateMachine(typeof(_0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c))]
	private IEnumerable<int> _0023_003DzwZ4XBFhfCbaJGw_Z5pzTYzk_003D(int _0023_003DzBJFJHwk_003D, int _0023_003Dz40R7bAU_003D, int _0023_003DzEGKj_0024SNUUihi)
	{
		return new _0023_003DzSgjO1_0024qzUvhD6wNvKUq4I5B7V9_0024c(-2)
		{
			_0023_003DzopRx0_MBcTQs = this,
			_0023_003DzgEhJ3eTBnUub = _0023_003DzBJFJHwk_003D,
			_0023_003DzTu_0024tboysWhBu = _0023_003Dz40R7bAU_003D,
			_0023_003DzyIVlKPMtOM2bPzOUMg_003D_003D = _0023_003DzEGKj_0024SNUUihi
		};
	}

	public void UpdateNormals()
	{
		for (int i = 0; i <= _colCount; i++)
		{
			for (int j = 0; j <= _rowCount; j++)
			{
				int num = (i + j * (_colCount + 1)) * 3;
				if (workMax != null && (double)base.PointArray[num + 2] == workMax.Z)
				{
					continue;
				}
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				int num5 = 0;
				foreach (int item in _0023_003DzwZ4XBFhfCbaJGw_Z5pzTYzk_003D(i, j, 1))
				{
					int num6 = base.TriangleArray[item] * 3;
					int num7 = base.TriangleArray[item + 1] * 3;
					int num8 = base.TriangleArray[item + 2] * 3;
					if (num6 == num || num7 == num || num8 == num)
					{
						Point3D p = new Point3D(base.PointArray[num6], base.PointArray[num6 + 1], base.PointArray[num6 + 2]);
						Point3D p2 = new Point3D(base.PointArray[num7], base.PointArray[num7 + 1], base.PointArray[num7 + 2]);
						Point3D p3 = new Point3D(base.PointArray[num8], base.PointArray[num8 + 1], base.PointArray[num8 + 2]);
						Vector3D vector3D = new Vector3D(p, p2, p3);
						num2 += vector3D.X;
						num3 += vector3D.Y;
						num4 += vector3D.Z;
						num5++;
					}
				}
				base.NormalArray[num] = (float)(num2 / (double)num5);
				base.NormalArray[num + 1] = (float)(num3 / (double)num5);
				base.NormalArray[num + 2] = (float)(num4 / (double)num5);
			}
		}
	}

	public void Optimize(CompileParams cp = null)
	{
		UpdateNormals();
		_0023_003DzR_IIhqyn5_prcagI0Q_003D_003D(_0023_003Dz45thxeUyuKPZ: false);
		if (cp != null)
		{
			Compile(cp);
		}
	}

	private FastMesh _0023_003DzOcZS3vc_003D(int _0023_003DzyzK8swU_003D)
	{
		if (_0023_003DzyzK8swU_003D == 0)
		{
			return this;
		}
		return _planarFaces[_0023_003DzyzK8swU_003D - 1];
	}

	public override void Dispose()
	{
		base.Dispose();
		FastMesh[] planarFaces = _planarFaces;
		for (int i = 0; i < planarFaces.Length; i++)
		{
			planarFaces[i].Dispose();
		}
	}

	internal void _0023_003DztOrWpXn2GxeGkL7mK1Td_Bg_003D(FastMesh _0023_003Dzz9oPww0_003D, FastMesh _0023_003DznYtQKck_003D, FastMesh _0023_003Dzw0AXpOM_003D, FastMesh _0023_003DzeMBeuAQ_003D, FastMesh _0023_003Dz5F7_i_0024U_003D)
	{
		_planarFaces = new FastMesh[5] { _0023_003Dzz9oPww0_003D, _0023_003DznYtQKck_003D, _0023_003Dzw0AXpOM_003D, _0023_003DzeMBeuAQ_003D, _0023_003Dz5F7_i_0024U_003D };
	}

	internal override bool FindClosestVertex(FindClosestVertexParams _0023_003DzELu0Pss_003D, int _0023_003Dz7xzxLVk_003D)
	{
		FindClosestVertexParams findClosestVertexParams = new FindClosestVertexParams((_0023_003DzELu0Pss_003D.Transformation != null) ? (_0023_003DzELu0Pss_003D.Transformation * _0023_003DzxdqexKR7jogJ()) : _0023_003DzxdqexKR7jogJ(), _0023_003DzELu0Pss_003D.Document.workspace, _0023_003DzELu0Pss_003D.entType, _0023_003DzELu0Pss_003D.mousePos, _0023_003DzELu0Pss_003D.sqrDistance, _0023_003DzELu0Pss_003D.clientWidth, _0023_003DzELu0Pss_003D.clientHeight, _0023_003DzELu0Pss_003D.camera, _0023_003DzELu0Pss_003D.viewFrame);
		bool result = false;
		if (base.FindClosestVertex(findClosestVertexParams, _0023_003Dz7xzxLVk_003D))
		{
			_0023_003DzELu0Pss_003D.ClosestVertex = findClosestVertexParams.ClosestVertex;
			_0023_003DzELu0Pss_003D.ClosestVertex.FaceIndex = 0;
			result = true;
		}
		for (int i = 0; i < 5; i++)
		{
			if (_planarFaces[i].FindClosestVertex(findClosestVertexParams, _0023_003Dz7xzxLVk_003D))
			{
				_0023_003DzELu0Pss_003D.ClosestVertex = findClosestVertexParams.ClosestVertex;
				_0023_003DzELu0Pss_003D.ClosestVertex.FaceIndex = i + 1;
				result = true;
			}
		}
		return result;
	}

	public override void TransformBy(Transformation xform)
	{
		FastMesh[] planarFaces = _planarFaces;
		for (int i = 0; i < planarFaces.Length; i++)
		{
			planarFaces[i].TransformBy(xform);
		}
		workMin.TransformBy(xform);
		workMax.TransformBy(xform);
		base.TransformBy(xform);
	}

	protected internal override void Draw(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(_0023_003DzxdqexKR7jogJ());
		bool forceSetTransform = false;
		Transformation blockRefTransform = null;
		if (data.ShaderParams != null)
		{
			forceSetTransform = data.ShaderParams.ForceSetTransform;
			blockRefTransform = data.ShaderParams.BlockRefTransform;
			data.ShaderParams.ForceSetTransform = true;
			data.ShaderParams.BlockRefTransform *= _0023_003DzxdqexKR7jogJ();
		}
		FastMesh[] planarFaces = _planarFaces;
		foreach (FastMesh fastMesh in planarFaces)
		{
			data.RenderContext.SetColorMaterial(fastMesh.Color);
			fastMesh.SetShader(data);
			data.RenderContext.Draw(fastMesh.drawData);
		}
		SetShader(data);
		if (data.ShaderParams != null)
		{
			data.ShaderParams.BlockRefTransform = blockRefTransform;
			data.ShaderParams.ForceSetTransform = forceSetTransform;
		}
		data.RenderContext.Draw(drawData);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawHiddenLines(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(_0023_003DzxdqexKR7jogJ());
		FastMesh[] planarFaces = _planarFaces;
		foreach (FastMesh fastMesh in planarFaces)
		{
			data.RenderContext.Draw(fastMesh.drawData);
		}
		data.RenderContext.Draw(drawData);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawVertices(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(_0023_003DzxdqexKR7jogJ());
		FastMesh[] planarFaces = _planarFaces;
		for (int i = 0; i < planarFaces.Length; i++)
		{
			planarFaces[i].DrawVertices(data);
		}
		base.DrawVertices(data);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawNormals(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(_0023_003DzxdqexKR7jogJ());
		FastMesh[] planarFaces = _planarFaces;
		for (int i = 0; i < planarFaces.Length; i++)
		{
			planarFaces[i].DrawNormals(data);
		}
		base.DrawNormals(data);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawFlat(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(_0023_003DzxdqexKR7jogJ());
		FastMesh[] planarFaces = _planarFaces;
		foreach (FastMesh fastMesh in planarFaces)
		{
			data.RenderContext.SetColorWireframe(fastMesh.Color);
			data.RenderContext.Draw(fastMesh.drawData);
		}
		data.RenderContext.SetColorWireframe(Color);
		data.RenderContext.Draw(drawData);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawIsocurves(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(_0023_003DzxdqexKR7jogJ());
		FastMesh[] planarFaces = _planarFaces;
		foreach (FastMesh fastMesh in planarFaces)
		{
			data.RenderContext.DrawSelected(fastMesh.drawData, primitiveType.TriangleList);
		}
		base.DrawSelected(data);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawEdges(DrawParams data)
	{
	}

	protected internal override void DrawSilhouettes(DrawSilhouettesParams drawSilhouettesParams)
	{
	}

	protected internal override void DrawSelected(DrawParams data)
	{
		data.RenderContext.PushModelView();
		data.RenderContext.MultMatrixModelView(_0023_003DzxdqexKR7jogJ());
		FastMesh[] planarFaces = _planarFaces;
		for (int i = 0; i < planarFaces.Length; i++)
		{
			planarFaces[i].DrawSelected(data);
		}
		base.DrawSelected(data);
		data.RenderContext.PopModelView();
	}

	protected internal override void DrawForShadow(RenderParams data)
	{
		DrawSelected(data);
	}

	public override void Compile(CompileParams data)
	{
		FastMesh[] planarFaces = _planarFaces;
		for (int i = 0; i < planarFaces.Length; i++)
		{
			planarFaces[i].Compile(data);
		}
		base.Compile(data);
	}

	protected internal override bool ComputeBoundingBox(TraversalParams data, out Point3D boxMin, out Point3D boxMax)
	{
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(workMin, workMax);
		Utility.ComputeBoundingBox(data._0023_003Dz0v5zcfYmTwCF(_0023_003DzxdqexKR7jogJ()), boundingBoxCorners, out boxMin, out boxMax);
		return true;
	}

	protected internal override bool GetAllVertices(TraversalParams data, out IList<float> verticesCoords)
	{
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(workMin, workMax);
		verticesCoords = new float[boundingBoxCorners.Length * 3];
		data.PushTransformation(_0023_003DzxdqexKR7jogJ());
		for (int i = 0; i < boundingBoxCorners.Length; i++)
		{
			Point3D point3D = (Point3D)boundingBoxCorners[i].Clone();
			point3D.TransformBy(data.Transformation);
			verticesCoords[i * 3] = (float)point3D.X;
			verticesCoords[i * 3 + 1] = (float)point3D.Y;
			verticesCoords[i * 3 + 2] = (float)point3D.Z;
		}
		data.PopTransformation();
		return true;
	}

	protected internal override void ComputeOffsetOnCameraAxes(OffsetOnCameraAxesParams data)
	{
		FastMesh fastMesh = _planarFaces[4];
		data.PushTransformation(_0023_003DzxdqexKR7jogJ());
		fastMesh.ComputeOffsetOnCameraAxes(data);
		base.ComputeOffsetOnCameraAxes(data);
		data.PopTransformation();
	}

	public override Mesh[] GetTessellation()
	{
		Mesh[] array = new Mesh[_planarFaces.Length + 1];
		array[0] = base.ConvertToMesh(0.0, 0.0, Mesh.natureType.Plain, weld: false);
		for (int i = 0; i < _planarFaces.Length; i++)
		{
			array[i + 1] = _planarFaces[i].ConvertToMesh(0.0, 0.0, Mesh.natureType.Plain, weld: false);
		}
		return array;
	}

	public override Mesh ConvertToMesh(double deviation, double angleInRadians, Mesh.natureType nature, bool weld)
	{
		Mesh mesh = base.ConvertToMesh(deviation, angleInRadians, nature, weld);
		FastMesh[] planarFaces = _planarFaces;
		for (int i = 0; i < planarFaces.Length; i++)
		{
			Mesh mesh2 = planarFaces[i].ConvertToMesh(deviation, angleInRadians, nature, weld);
			mesh.MergeWith(mesh2, weldNow: false, recomputeEdges: false);
		}
		return mesh;
	}

	public override double GetArea(out Point3D centroid)
	{
		AreaProperties areaProperties = new AreaProperties();
		areaProperties.Add(GetTessellation());
		centroid = areaProperties.Centroid;
		return areaProperties.Area;
	}

	public override double GetVolume(out Point3D centroid)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		centroid = volumeProperties.Centroid;
		return volumeProperties.Volume;
	}

	public override void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ, out double ix, out double iy, out double iz)
	{
		VolumeProperties volumeProperties = new VolumeProperties();
		volumeProperties.Add(GetTessellation());
		volumeProperties.GetPrincipalAxes(volumeProperties.Volume, volumeProperties.Centroid, out axisX, out axisY, out axisZ, out ix, out iy, out iz);
	}

	public override void GetPrincipalAxes(out Vector3D axisX, out Vector3D axisY, out Vector3D axisZ)
	{
		GetPrincipalAxes(out axisX, out axisY, out axisZ, out var _, out var _, out var _);
	}

	public override EntitySurrogate ConvertToSurrogate()
	{
		return new SimulationStockSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996403), _rowCount);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996387), _colCount);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996376), _planarFaces);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956915), _0023_003DzxdqexKR7jogJ());
	}
}
