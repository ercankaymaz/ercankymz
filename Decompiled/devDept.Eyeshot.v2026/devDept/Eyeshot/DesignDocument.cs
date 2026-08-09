using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Meshing;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

public class DesignDocument : Document
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzAqGMckS8kR_00240jj5V3A_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Stream _0023_003DzdLqTRfo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzqCbQjE_0024V12fc;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DesignDocument _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DrawingDocument _0023_003Dzu9im1ZQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			DesignDocument _0023_003DzYwIE4oHHd7Xy = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = Document._0023_003DzQRSCQfCaOAvS(new ReadFile(_0023_003DzdLqTRfo_003D, _0023_003DzqCbQjE_0024V12fc), _0023_003DzYwIE4oHHd7Xy, _0023_003Dzu9im1ZQ_003D).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzH6BWLiE4h15NCcN7eA_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<BlockReference> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DesignDocument _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzQZpgnjI_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			DesignDocument designDocument = _0023_003DzopRx0_MBcTQs;
			BlockReference result;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					designDocument._0023_003Dz8zfvlaholBKP(_0023_003DzQZpgnjI_003D);
					awaiter = designDocument.Entities._0023_003DzxBIitsjI3JjNuLxSbQ_003D_003D(designDocument.Entities, _0023_003DzZcrk_0024oE_003D, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
				}
				awaiter.GetResult();
				if ((designDocument.workspace != null) & _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
				{
					designDocument.Entities.SelectAll();
					result = designDocument.workspace.RemoveJittering();
				}
				else
				{
					result = null;
				}
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult(result);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzT0gyX_0024EBvDjy9QP2Sw_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Stream _0023_003DzdLqTRfo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DesignDocument _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DrawingDocument _0023_003DzY8C49ueFTJMU;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public contentType _0023_003DzB5M5dYA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzqCbQjE_0024V12fc;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			DesignDocument _0023_003DzYwIE4oHHd7Xy = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = Document._0023_003DzMw_yAWQaLtwK(_0023_003DzdLqTRfo_003D, null, _0023_003DzYwIE4oHHd7Xy, _0023_003DzY8C49ueFTJMU, _0023_003DzB5M5dYA_003D, _0023_003DzqCbQjE_0024V12fc).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dzdzdi_eguyaB_00243_0024DyJg_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003Dzg5oC_Hs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DesignDocument _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DrawingDocument _0023_003DzY8C49ueFTJMU;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public contentType _0023_003DzB5M5dYA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzqCbQjE_0024V12fc;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			DesignDocument _0023_003DzYwIE4oHHd7Xy = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = Document._0023_003DzMw_yAWQaLtwK(null, _0023_003Dzg5oC_Hs_003D, _0023_003DzYwIE4oHHd7Xy, _0023_003DzY8C49ueFTJMU, _0023_003DzB5M5dYA_003D, _0023_003DzqCbQjE_0024V12fc).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzwipFAYbG03HvJjxKLg_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003Dzg5oC_Hs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public FileSerializer _0023_003DzqCbQjE_0024V12fc;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DesignDocument _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DrawingDocument _0023_003Dzu9im1ZQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			DesignDocument _0023_003DzYwIE4oHHd7Xy = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = Document._0023_003DzQRSCQfCaOAvS(new ReadMultiFile(_0023_003Dzg5oC_Hs_003D, _0023_003DzqCbQjE_0024V12fc), _0023_003DzYwIE4oHHd7Xy, _0023_003Dzu9im1ZQ_003D).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				else
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
				}
				awaiter.GetResult();
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			_0023_003DzCodHnSRJkAEg.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine _0023_003Dzr6YfHDQ_003D)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(_0023_003Dzr6YfHDQ_003D);
		}
	}

	public new MaterialKeyedCollection Materials
	{
		get
		{
			return base.Materials;
		}
		set
		{
			base.Materials = value;
		}
	}

	public new linearUnitsType Units
	{
		get
		{
			return base.Units;
		}
		set
		{
			base.Units = value;
		}
	}

	private static bool _0023_003DzcbWpI_002468KH8l(Brep _0023_003DzGb8kdyZ1x5nj, out Brep _0023_003DzuKnPTqCgHBzs)
	{
		_0023_003DzuKnPTqCgHBzs = null;
		if (_0023_003DzGb8kdyZ1x5nj.IsClosed)
		{
			_0023_003DzuKnPTqCgHBzs = (Brep)_0023_003DzGb8kdyZ1x5nj.Clone();
			_0023_003DzuKnPTqCgHBzs.FixTopology();
			return true;
		}
		return false;
	}

	private static List<Mesher> _0023_003DzYmG_002418ZNgRSzyUugXA_003D_003D(Block _0023_003Dz3Ftsho0_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, double _0023_003Dz14lzA48_003D, bool _0023_003DzFwalihjMriJGyFaGGg_003D_003D, HashSet<string> _0023_003DzhI_0024j0dSYksnE)
	{
		List<Mesher> list = new List<Mesher>();
		foreach (Entity entity in _0023_003Dz3Ftsho0_003D.Entities)
		{
			Mesher mesher = null;
			Brep _0023_003DzuKnPTqCgHBzs;
			if (entity is BlockReference blockReference && _0023_003DzhI_0024j0dSYksnE.Add(blockReference.BlockName))
			{
				list.AddRange(_0023_003DzYmG_002418ZNgRSzyUugXA_003D_003D(_0023_003DzJO1FWlQ_003D[blockReference.BlockName], _0023_003DzJO1FWlQ_003D, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, _0023_003Dz14lzA48_003D, _0023_003DzFwalihjMriJGyFaGGg_003D_003D, _0023_003DzhI_0024j0dSYksnE));
			}
			else if (entity is Brep _0023_003DzGb8kdyZ1x5nj && _0023_003DzcbWpI_002468KH8l(_0023_003DzGb8kdyZ1x5nj, out _0023_003DzuKnPTqCgHBzs))
			{
				double size = ((_0023_003Dz14lzA48_003D == 0.0) ? VolumeMesher.EstimateSizeByNumber(5000, _0023_003DzuKnPTqCgHBzs) : _0023_003Dz14lzA48_003D);
				mesher = new VolumeMesher(_0023_003DzuKnPTqCgHBzs, size, _0023_003DzFwalihjMriJGyFaGGg_003D_003D, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
			}
			else if (entity is Surface surface)
			{
				double elementSize = ((_0023_003Dz14lzA48_003D == 0.0) ? SurfaceMesher.EstimateSizeByNumber(500, surface) : _0023_003Dz14lzA48_003D);
				mesher = new SurfaceMesher(surface, elementSize, _0023_003DzFwalihjMriJGyFaGGg_003D_003D, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
			}
			else if (entity is Region region)
			{
				double elementSize2 = ((_0023_003Dz14lzA48_003D == 0.0) ? PlaneMesher.EstimateSizeByNumber(500, region) : _0023_003Dz14lzA48_003D);
				mesher = new PlaneMesher(region, elementSize2, null, null, _0023_003DzFwalihjMriJGyFaGGg_003D_003D, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
			}
			else if (entity is Solid { IsClosed: not false } solid)
			{
				mesher = new VolumeMesher(solid.ConvertToMesh(), _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
			}
			else if (entity is Mesh { IsClosed: not false } mesh)
			{
				mesher = new VolumeMesher(mesh, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
			}
			else if (entity is ICurve curve)
			{
				double size2 = ((_0023_003Dz14lzA48_003D == 0.0) ? CurveMesher.EstimateSizeByNumber(10, curve) : _0023_003Dz14lzA48_003D);
				mesher = new CurveMesher(curve, size2, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D);
			}
			if (mesher != null)
			{
				mesher.BlockName = _0023_003Dz3Ftsho0_003D.Name;
				list.Add(mesher);
			}
		}
		return list;
	}

	public Mesher[] GetMeshers(double size = 0.0, bool quadratic = false)
	{
		return GetMeshers(_0023_003DzLnvwYhzuV1KC(), base.Blocks, Materials, size, quadratic);
	}

	public Mesher[] GetMeshers(Brep brep, double size, bool quadratic, double maxGradation, double shapeQualityWeight, bool computeEdgeQuality)
	{
		if (size == 0.0)
		{
			size = VolumeMesher.EstimateSizeByNumber(5000, brep);
		}
		return GetMeshers(brep, Enumerable.Repeat(size, brep.Vertices.Length).ToArray(), quadratic, maxGradation, shapeQualityWeight, computeEdgeQuality);
	}

	public Mesher[] GetMeshers(Brep brep, double[] sizeOnVertices, bool quadratic, double maxGradation, double shapeQualityWeight, bool computeEdgeQuality)
	{
		if (_0023_003DzcbWpI_002468KH8l(brep, out var _0023_003DzuKnPTqCgHBzs))
		{
			VolumeMesher volumeMesher = new VolumeMesher(_0023_003DzuKnPTqCgHBzs, sizeOnVertices, quadratic, Materials)
			{
				BlockName = _0023_003DzLnvwYhzuV1KC().Name,
				MaxGradation = maxGradation,
				ShapeQualityWeight = shapeQualityWeight,
				ComputeEdgeQuality = computeEdgeQuality
			};
			return new VolumeMesher[1] { volumeMesher };
		}
		throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953664), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953647));
	}

	public Mesher[] GetMeshers(Block current, BlockKeyedCollection blocks, MaterialKeyedCollection materials, double size, bool quadratic)
	{
		HashSet<string> _0023_003DzhI_0024j0dSYksnE = new HashSet<string>();
		return _0023_003DzYmG_002418ZNgRSzyUugXA_003D_003D(current, blocks, materials, size, quadratic, _0023_003DzhI_0024j0dSYksnE).ToArray();
	}

	private static Solidifier[] _0023_003Dzn3ssXR8_003D(BlockKeyedCollection _0023_003DzJO1FWlQ_003D, Block _0023_003Dz3Ftsho0_003D, HashSet<string> _0023_003DzhI_0024j0dSYksnE, double _0023_003Dzm0CYiiE_003D)
	{
		List<Solidifier> list = new List<Solidifier>(_0023_003Dz3Ftsho0_003D.Entities.Count);
		List<Surface> list2 = new List<Surface>();
		foreach (Entity entity in _0023_003Dz3Ftsho0_003D.Entities)
		{
			if (entity is BlockReference blockReference && _0023_003DzhI_0024j0dSYksnE.Add(blockReference.BlockName))
			{
				list.AddRange(_0023_003Dzn3ssXR8_003D(_0023_003DzJO1FWlQ_003D, _0023_003DzJO1FWlQ_003D[blockReference.BlockName], _0023_003DzhI_0024j0dSYksnE, _0023_003Dzm0CYiiE_003D));
			}
			else if (entity is Surface item)
			{
				list2.Add(item);
			}
		}
		if (list2.Count > 0)
		{
			list.Add(new Solidifier(list2, _0023_003Dzm0CYiiE_003D)
			{
				BlockName = _0023_003Dz3Ftsho0_003D.Name
			});
		}
		return list.ToArray();
	}

	public Solidifier[] GetSolidifiers(IList<Surface> surfaces, double tol = 0.0)
	{
		return new Solidifier[1]
		{
			new Solidifier(surfaces, tol)
		};
	}

	public Solidifier[] GetSolidifiers(double tol = 0.0)
	{
		return GetSolidifiers(_0023_003DzLnvwYhzuV1KC(), base.Blocks, tol);
	}

	public Solidifier[] GetSolidifiers(Block current, BlockKeyedCollection blocks, double tol = 0.0)
	{
		HashSet<string> _0023_003DzhI_0024j0dSYksnE = new HashSet<string>();
		return _0023_003Dzn3ssXR8_003D(blocks, current, _0023_003DzhI_0024j0dSYksnE, tol);
	}

	public virtual void SaveFile(string filePath, DrawingDocument drawingDoc = null, contentType contentType = contentType.GeometryAndTessellation, FileSerializer fileSerializer = null)
	{
		Document._0023_003DzRiqmF0HlYfrG(null, filePath, this, drawingDoc, contentType, fileSerializer);
	}

	public virtual async Task SaveFileAsync(string filePath, DrawingDocument drawingDoc = null, contentType contentType = contentType.GeometryAndTessellation, FileSerializer fileSerializer = null)
	{
		await Document._0023_003DzMw_yAWQaLtwK(null, filePath, this, drawingDoc, contentType, fileSerializer);
	}

	public virtual void SaveFile(Stream stream, DrawingDocument drawingDoc = null, contentType contentType = contentType.GeometryAndTessellation, FileSerializer fileSerializer = null)
	{
		Document._0023_003DzRiqmF0HlYfrG(stream, null, this, drawingDoc, contentType, fileSerializer);
	}

	public virtual async Task SaveFileAsync(Stream stream, DrawingDocument drawingDoc = null, contentType contentType = contentType.GeometryAndTessellation, FileSerializer fileSerializer = null)
	{
		await Document._0023_003DzMw_yAWQaLtwK(stream, null, this, drawingDoc, contentType, fileSerializer);
	}

	public virtual void OpenFile(string filePath, DrawingDocument drawing = null, FileSerializer fileSerializer = null)
	{
		Document._0023_003DzEnNVXbF4jXkn(new ReadMultiFile(filePath, fileSerializer), this, drawing);
	}

	public virtual async Task OpenFileAsync(string filePath, DrawingDocument drawing = null, FileSerializer fileSerializer = null)
	{
		await Document._0023_003DzQRSCQfCaOAvS(new ReadMultiFile(filePath, fileSerializer), this, drawing);
	}

	public virtual void OpenFile(Stream stream, DrawingDocument drawing = null, FileSerializer fileSerializer = null)
	{
		Document._0023_003DzEnNVXbF4jXkn(new ReadFile(stream, fileSerializer), this, drawing);
	}

	public virtual async Task OpenFileAsync(Stream stream, DrawingDocument drawing = null, FileSerializer fileSerializer = null)
	{
		await Document._0023_003DzQRSCQfCaOAvS(new ReadFile(stream, fileSerializer), this, drawing);
	}

	internal BlockReference _0023_003Dz3nSNv4s_003D(ReadFileAsync _0023_003DzQZpgnjI_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
	{
		_0023_003Dz8zfvlaholBKP(_0023_003DzQZpgnjI_003D);
		base.Entities._0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(base.Entities, _0023_003DzZcrk_0024oE_003D);
		if (workspace != null && _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
		{
			base.Entities.SelectAll();
			return workspace.RemoveJittering();
		}
		return null;
	}

	internal async Task<BlockReference> _0023_003DzSX5GAf0_003D(ReadFileAsync _0023_003DzQZpgnjI_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
	{
		_0023_003Dz8zfvlaholBKP(_0023_003DzQZpgnjI_003D);
		await base.Entities._0023_003DzxBIitsjI3JjNuLxSbQ_003D_003D(base.Entities, _0023_003DzZcrk_0024oE_003D, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0);
		if (workspace != null && _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D)
		{
			base.Entities.SelectAll();
			return workspace.RemoveJittering();
		}
		return null;
	}

	private void _0023_003Dz8zfvlaholBKP(ReadFileAsync _0023_003DzQZpgnjI_003D)
	{
		Clear();
		base.Blocks.ClearInternal(_0023_003DzVDbVnWQyuPCb: false);
		_0023_003DztOK9RejsWMws(_0023_003DzQZpgnjI_003D, conflictPolicy.Overwrite, _0023_003DzKE_FpisulC8D: true);
		base.Blocks._0023_003DzsEhiJowLp1sN(_0023_003DzQZpgnjI_003D.Blocks.RootBlockName);
		workspace?.InitializeRootBlock();
	}
}
