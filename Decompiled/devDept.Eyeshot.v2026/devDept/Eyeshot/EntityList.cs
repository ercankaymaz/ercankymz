using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class EntityList : EyeshotDisposableCollection<Entity>, ISelectable
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz_0024JTE_9LDGeJKa4b5lsH83s4_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IList<Entity> _0023_003Dzv7xH9gk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D _0023_003DzToHGjyY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzjhyg1Go_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenParams _0023_003DzkY6mqyuPEDLn;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Regeneration _0023_003Dz5_0024ZNPweTIV1dK1fs_0024Q_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_00cf;
				}
				if (num == 1)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_0139;
				}
				if (_0023_003Dzv7xH9gk_003D.Count != 0)
				{
					_0023_003Dz5_0024ZNPweTIV1dK1fs_0024Q_003D_003D = entityList._0023_003Dzy5DAe2h96zh10bO1FmzFatw_003D(_0023_003Dzv7xH9gk_003D, entityList._0023_003DzLeyHB00_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D, _0023_003DzToHGjyY_003D, _0023_003Dzjhyg1Go_003D, _0023_003DzkY6mqyuPEDLn);
					if (entityList._0023_003Dzo60vEkkaRGxX() != null)
					{
						awaiter = entityList._0023_003Dzo60vEkkaRGxX().DoWorkAsync(new global::_0023_003Dz59HJ4yStYPkbzfhacP1yQy8_003D<WorkUnit>(_0023_003Dz5_0024ZNPweTIV1dK1fs_0024Q_003D_003D)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0023_003DzU7pGb3X7Zp4G = 0);
							_0023_003DzpVK748zcYJ8u = awaiter;
							_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
						goto IL_00cf;
					}
					awaiter = _0023_003Dz5_0024ZNPweTIV1dK1fs_0024Q_003D_003D.DoWorkAsync().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 1);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_0139;
				}
				goto end_IL_000e;
				IL_0139:
				awaiter.GetResult();
				_0023_003Dz5_0024ZNPweTIV1dK1fs_0024Q_003D_003D.WorkCompleted(entityList.Document);
				goto end_IL_000e;
				IL_00cf:
				awaiter.GetResult();
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003Dz5_0024ZNPweTIV1dK1fs_0024Q_003D_003D = null;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003Dz5_0024ZNPweTIV1dK1fs_0024Q_003D_003D = null;
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
	private struct _0023_003Dz34aeaOZXglWxfAf17Ivw8Cc_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_007f;
				}
				if (entityList._0023_003Dz5LunQb_j4_00244nmKuyhw_003D_003D())
				{
					awaiter = entityList._0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(entityList.baseList, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0, null).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_007f;
				}
				goto end_IL_000e;
				IL_007f:
				awaiter.GetResult();
				end_IL_000e:;
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
	private struct _0023_003Dz5t3lkyqmo42y6YlrKvMiXMU_003D<_0023_003DzWWgGxds_003D> : IAsyncStateMachine where _0023_003DzWWgGxds_003D : Entity
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<_0023_003DzWWgGxds_003D> _0023_003DzcrILBXg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Color _0023_003Dz1MMYB1g_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					entityList._0023_003Dz49fNrkVagQGU(_0023_003DzcrILBXg_003D, _0023_003Dz1MMYB1g_003D);
					awaiter = entityList.AddRangeAsync(_0023_003DzcrILBXg_003D).GetAwaiter();
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
	private struct _0023_003Dz7_qKxjiIWtHJT7TRvjE_0024DXY_003D<_0023_003DzWWgGxds_003D> : IAsyncStateMachine where _0023_003DzWWgGxds_003D : Entity
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<_0023_003DzWWgGxds_003D> _0023_003DzcrILBXg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzaROjBYA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					entityList._0023_003Dz14k1SiZTyF0i(_0023_003DzcrILBXg_003D, _0023_003DzaROjBYA_003D);
					awaiter = entityList.AddRangeAsync(_0023_003DzcrILBXg_003D).GetAwaiter();
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
	private struct _0023_003DzABghB5ElqzyphYI0uw_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Entity _0023_003Dz9j7EUB0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Color _0023_003Dz1MMYB1g_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					entityList._0023_003Dz1drjrR4_003D(_0023_003Dz9j7EUB0_003D, _0023_003Dz1MMYB1g_003D);
					awaiter = entityList.AddAsync(_0023_003Dz9j7EUB0_003D).GetAwaiter();
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

	private sealed class _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D
	{
		public HashSet<Entity> _0023_003Dzgx_XqE36Q_W7;

		internal bool _0023_003Dz8es9C7qdzLQe(Entity _0023_003DzbfrNXYE_003D)
		{
			return _0023_003Dzgx_XqE36Q_W7.Contains(_0023_003DzbfrNXYE_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzOZoulO_bBjxO8zbdew_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Entity _0023_003Dz9j7EUB0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzaROjBYA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					entityList._0023_003DzRbCjfzYnMque(_0023_003Dz9j7EUB0_003D, _0023_003DzaROjBYA_003D);
					awaiter = entityList.AddAsync(_0023_003Dz9j7EUB0_003D).GetAwaiter();
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
	private struct _0023_003DzRuzFJ0Xvto4vLb8g1w_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<Entity> _0023_003DzcrILBXg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_0098;
				}
				if (_0023_003DzcrILBXg_003D is IList<Entity> _0023_003Dzv7xH9gk_003D && entityList._0023_003Dz_W2t55LS28X8(_0023_003Dzv7xH9gk_003D))
				{
					entityList._0023_003Dz_hpEX5QR2_0024km(_0023_003DzcrILBXg_003D);
					entityList._0023_003Dz10xO6jmZZfus(_0023_003Dzv7xH9gk_003D);
					awaiter = entityList._0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(_0023_003Dzv7xH9gk_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)1, 0, null).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_0098;
				}
				goto end_IL_000e;
				IL_0098:
				awaiter.GetResult();
				end_IL_000e:;
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
	private struct _0023_003DzU7zy4uepVLVkEZBdtyzrivw_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<Entity> _0023_003DzcrILBXg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzyzK8swU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_00b1;
				}
				if (_0023_003DzcrILBXg_003D is IList<Entity> list && entityList._0023_003Dz_W2t55LS28X8(list))
				{
					entityList._0023_003Dz_hpEX5QR2_0024km(_0023_003DzcrILBXg_003D);
					entityList.baseList.InsertRange(_0023_003DzyzK8swU_003D, list);
					awaiter = entityList._0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(list, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)2, _0023_003DzyzK8swU_003D, null).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00b1;
				}
				goto end_IL_000e;
				IL_00b1:
				awaiter.GetResult();
				end_IL_000e:;
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
	private struct _0023_003DzUiUBtQrnnnhvwo0fxlV19CUVX6GL : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IList<Entity> _0023_003DzcrILBXg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D _0023_003DzToHGjyY_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzjhyg1Go_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_008a;
				}
				if (entityList._0023_003Dz_W2t55LS28X8(_0023_003DzcrILBXg_003D))
				{
					awaiter = entityList._0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(_0023_003DzcrILBXg_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, _0023_003DzToHGjyY_003D, _0023_003Dzjhyg1Go_003D, null).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_008a;
				}
				goto end_IL_000e;
				IL_008a:
				awaiter.GetResult();
				end_IL_000e:;
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
	private struct _0023_003DzWQ6tyx1Rbe1mQfOxqkFcM0y8r4GwkDzxLQ_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz6pajdGM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_0097;
				}
				if (entityList._0023_003Dz5LunQb_j4_00244nmKuyhw_003D_003D())
				{
					RegenParams _0023_003DzkY6mqyuPEDLn = new RegenParams(_0023_003Dz8Z3KdXqI6yz07POiOA_003D_003D, _0023_003Dz6pajdGM_003D, entityList.Document);
					awaiter = entityList._0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(entityList.baseList, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: true, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0, _0023_003DzkY6mqyuPEDLn).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_0097;
				}
				goto end_IL_000e;
				IL_0097:
				awaiter.GetResult();
				end_IL_000e:;
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
	private struct _0023_003Dz_1FP0Nt8lxnn6095_0024w_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Entity _0023_003Dz9j7EUB0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzaROjBYA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Color _0023_003Dz1MMYB1g_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					entityList._0023_003DzRbCjfzYnMque(_0023_003Dz9j7EUB0_003D, _0023_003DzaROjBYA_003D);
					entityList._0023_003Dz1drjrR4_003D(_0023_003Dz9j7EUB0_003D, _0023_003Dz1MMYB1g_003D);
					awaiter = entityList.AddAsync(_0023_003Dz9j7EUB0_003D).GetAwaiter();
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
	private struct _0023_003Dzj1Xrsz4hpWK2Q2Lgu4XMcywC1kfP04iy_0024Q_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					entityList.Document.UpdateBoundingBox();
					RegenParams visualRefinement = entityList.Document.GetVisualRefinement();
					awaiter = entityList.RegenAllCurvedAsync(visualRefinement.Deviation, visualRefinement.Angle, _0023_003DzZcrk_0024oE_003D).GetAwaiter();
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
	private struct _0023_003DzlsDepe1etr9s0CAe0A_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Entity _0023_003DzUBZd570_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_00a7;
				}
				if (entityList._0023_003Dz_W2t55LS28X8(_0023_003DzUBZd570_003D))
				{
					entityList._0023_003DzQfuT2WLxU8Wb(_0023_003DzUBZd570_003D);
					entityList._0023_003Dz6o91qlpB3dZY(_0023_003DzUBZd570_003D);
					awaiter = entityList._0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(new List<Entity>(1) { _0023_003DzUBZd570_003D }, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0, null).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00a7;
				}
				goto end_IL_000e;
				IL_00a7:
				awaiter.GetResult();
				end_IL_000e:;
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
	private struct _0023_003DzoqBzCoP_0024VZ1_0024q2m_0024Sw_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Entity _0023_003DzUBZd570_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzyzK8swU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num == 0)
				{
					awaiter = _0023_003DzpVK748zcYJ8u;
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
					goto IL_00bc;
				}
				if (entityList._0023_003Dz_W2t55LS28X8(_0023_003DzUBZd570_003D))
				{
					entityList._0023_003DzQfuT2WLxU8Wb(_0023_003DzUBZd570_003D);
					entityList._0023_003DzsHOPLaXVRRYt(_0023_003DzyzK8swU_003D, _0023_003DzUBZd570_003D, _0023_003DzZcrk_0024oE_003D);
					awaiter = entityList._0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(new List<Entity>(1) { _0023_003DzUBZd570_003D }, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)2, _0023_003DzyzK8swU_003D, null).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0023_003DzU7pGb3X7Zp4G = 0);
						_0023_003DzpVK748zcYJ8u = awaiter;
						_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_00bc;
				}
				goto end_IL_000e;
				IL_00bc:
				awaiter.GetResult();
				end_IL_000e:;
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
	private struct _0023_003DzrlBaE0_GTO_5gMqxGaB1sWU_003D<_0023_003DzWWgGxds_003D> : IAsyncStateMachine where _0023_003DzWWgGxds_003D : Entity
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public EntityList _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<_0023_003DzWWgGxds_003D> _0023_003DzcrILBXg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzaROjBYA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Color _0023_003Dz1MMYB1g_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			EntityList entityList = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					entityList._0023_003Dzm9WI5LkFXEn_fk_hig_003D_003D(_0023_003DzcrILBXg_003D, _0023_003DzaROjBYA_003D, _0023_003Dz1MMYB1g_003D);
					awaiter = entityList.AddRangeAsync(_0023_003DzcrILBXg_003D).GetAwaiter();
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

	[DataContract]
	internal class DataForCopyAndPaste
	{
		[DataMember(Order = 1)]
		internal readonly List<Entity> Entities;

		[DataMember(Order = 2)]
		internal readonly List<Block> Blocks;

		[DataMember(Order = 3)]
		internal readonly List<Layer> Layers;

		[DataMember(Order = 4)]
		internal readonly List<Material> Materials;

		[DataMember(Order = 5)]
		internal readonly List<TextStyle> TextStyles;

		[DataMember(Order = 6)]
		internal readonly List<LineType> LineTypes;

		[DataMember(Order = 7)]
		internal readonly List<HatchPattern> HatchPatterns;

		[DataMember(Order = 8)]
		internal readonly Dictionary<Constraint, int[]> Constraints;

		[DataMember(Order = 9)]
		internal readonly Dictionary<Entity, SketchCurve> SketchEntities;

		public DataForCopyAndPaste()
		{
			Entities = new List<Entity>();
			Blocks = new List<Block>();
			Layers = new List<Layer>();
			Materials = new List<Material>();
			TextStyles = new List<TextStyle>();
			LineTypes = new List<LineType>();
			HatchPatterns = new List<HatchPattern>();
			Constraints = new Dictionary<Constraint, int[]>();
			SketchEntities = new Dictionary<Entity, SketchCurve>();
		}
	}

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Block _0023_003DzLeyHB00_003D;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point3D _0023_003Dzw6MTIExa9FCQ;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Point3D _0023_003Dzs_rNF1nafbip;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal double _0023_003DzcrVECsKc78F_0024;

	internal long regenTime;

	private bool invalidBBox;

	private Dictionary<Type, int> _entityTypes;

	private int _statsEntityCount;

	private int _statsVertexCount;

	private int _statsTriangleCount;

	public override Entity this[int index]
	{
		get
		{
			return baseList[index];
		}
		set
		{
			if (base.Document != null)
			{
				_0023_003DznvxBzE3KPAch(value, null);
				Entity entity = baseList[index];
				entity.Dispose();
				_0023_003DzvCwTlYsGALPj(entity);
				_0023_003DzTBzg02M_003D(entity);
			}
			baseList[index] = value;
		}
	}

	public double BoxOffset => _0023_003DzcrVECsKc78F_0024;

	public Point3D BoxMin => _0023_003Dzw6MTIExa9FCQ;

	public Point3D BoxMax => _0023_003Dzs_rNF1nafbip;

	public Size3D BoxSize
	{
		get
		{
			Point3D point3D = _0023_003Dzs_rNF1nafbip - _0023_003Dzw6MTIExa9FCQ;
			return new Size3D(point3D.X, point3D.Y, point3D.Z);
		}
	}

	public int MaxCandidates
	{
		get
		{
			return BspSettings.MAX_CANDIDATES;
		}
		set
		{
			BspSettings.MAX_CANDIDATES = value;
			if (BspSettings.MAX_CANDIDATES <= 0)
			{
				BspSettings.MAX_CANDIDATES = 1;
			}
		}
	}

	public bool FrontFacingOnly
	{
		get
		{
			return BspSettings.frontFacingOnly;
		}
		set
		{
			BspSettings.frontFacingOnly = value;
		}
	}

	internal override void SetDocument(Document _0023_003DzoPlwCJA_003D)
	{
		base.SetDocument(_0023_003DzoPlwCJA_003D);
		_0023_003Dzw6MTIExa9FCQ = Point3D.MaxValue;
		_0023_003Dzs_rNF1nafbip = Point3D.MinValue;
		if (_0023_003DzoPlwCJA_003D != null)
		{
			_0023_003DzoPlwCJA_003D.isBoundingBoxDirty = true;
			_0023_003Dz_hpEX5QR2_0024km(baseList);
		}
		else
		{
			_0023_003DzoHeLgXXPaLwn();
		}
	}

	internal void _0023_003DzLG09JoU_003D(Block _0023_003Dz46K6wrkwzJcK)
	{
		_0023_003DzLeyHB00_003D = _0023_003Dz46K6wrkwzJcK;
	}

	private BlockKeyedCollection _0023_003DzlxKBCJ2zobwv()
	{
		if (base.Document == null)
		{
			return null;
		}
		if (_0023_003Dzo60vEkkaRGxX() == null)
		{
			return base.Document.Blocks;
		}
		return _0023_003Dzo60vEkkaRGxX().GetAllBlocks();
	}

	private void _0023_003DzQfuT2WLxU8Wb(Entity _0023_003DzUBZd570_003D)
	{
		if (base.Document != null)
		{
			_0023_003DzUBZd570_003D.VisibleChanged += _0023_003DzdAVlEJKfQ0Ln;
		}
	}

	private void _0023_003DzvCwTlYsGALPj(Entity _0023_003DzUBZd570_003D)
	{
		_0023_003DzUBZd570_003D.VisibleChanged -= _0023_003DzdAVlEJKfQ0Ln;
	}

	internal void _0023_003DzoHeLgXXPaLwn()
	{
		BlockKeyedCollection blockKeyedCollection = _0023_003DzlxKBCJ2zobwv();
		foreach (Entity @base in baseList)
		{
			if (@base is BlockReference blockReference)
			{
				blockKeyedCollection?[blockReference.BlockName].referencesToMe.Remove(blockReference);
			}
			_0023_003DzvCwTlYsGALPj(@base);
		}
	}

	internal void _0023_003Dz_hpEX5QR2_0024km(IEnumerable<Entity> _0023_003DzcDEsV8s_003D)
	{
		if (base.Document == null)
		{
			return;
		}
		foreach (Entity item in _0023_003DzcDEsV8s_003D)
		{
			_0023_003DzQfuT2WLxU8Wb(item);
		}
	}

	internal void _0023_003DzdAVlEJKfQ0Ln(object _0023_003Dz9VjL5i0_003D, VisibleChangedEventArgs _0023_003DzbfrNXYE_003D)
	{
		if (base.Document == null)
		{
			return;
		}
		ParallelConveHull.Instance.Stop();
		if (_0023_003DzLeyHB00_003D.referencesToMe.Count > 0)
		{
			foreach (BlockReference item in _0023_003DzLeyHB00_003D.referencesToMe)
			{
				item.transformedEntityBoxes.Remove((Entity)_0023_003Dz9VjL5i0_003D);
			}
		}
		_0023_003DzLeyHB00_003D.zoomFitConvexHull = null;
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			_0023_003Dzo60vEkkaRGxX().UpdateVisibleSelection();
			_0023_003Dzo60vEkkaRGxX().DestroyFlattenedTree(clearFlattenRepresentation: true);
		}
	}

	private protected override void _0023_003DznvxBzE3KPAch(Entity _0023_003DzPzO_0024GUk_003D, RegenOptions _0023_003DzZcrk_0024oE_003D = null)
	{
		_0023_003DzQfuT2WLxU8Wb(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(_0023_003DzPzO_0024GUk_003D, _0023_003DzZcrk_0024oE_003D);
	}

	private void _0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(Entity _0023_003DzPzO_0024GUk_003D, RegenOptions _0023_003DzZcrk_0024oE_003D)
	{
		if (_0023_003Dz_W2t55LS28X8(_0023_003DzPzO_0024GUk_003D))
		{
			_0023_003DzqOJmyFUuwZyA(new List<Entity>(1) { _0023_003DzPzO_0024GUk_003D }, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, null);
		}
	}

	private bool _0023_003Dz_W2t55LS28X8(Entity _0023_003DzPzO_0024GUk_003D)
	{
		if (base.Document == null || base.Document.Blocks.isOffline)
		{
			return false;
		}
		ParallelConveHull.Instance.Stop();
		base.Document.Layers.CheckAndFixDefaultLayerName(_0023_003DzPzO_0024GUk_003D);
		base.Document.TextStyles._0023_003Dzzv3gdukD06Co7c8MLQ_003D_003D(_0023_003DzPzO_0024GUk_003D, null);
		_0023_003DzSTF_0024BjQOhtuV(_0023_003DzPzO_0024GUk_003D, new HashSet<string>());
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().IsRenderingContextValid())
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
		}
		_0023_003Dz_oWOLd4zlEbL(_0023_003DzPzO_0024GUk_003D);
		_0023_003DzxcndDxKhGKf8(_0023_003DzPzO_0024GUk_003D, _0023_003DzlxKBCJ2zobwv());
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			_0023_003Dzo60vEkkaRGxX().ResetNeededConvexHull();
		}
		CombineBoundingBox(_0023_003DzPzO_0024GUk_003D);
		return true;
	}

	private protected override void _0023_003Dz5MnY2mTEV4BM(IList<Entity> _0023_003DzcrILBXg_003D, RegenOptions _0023_003DzZcrk_0024oE_003D = null)
	{
		_0023_003Dz_hpEX5QR2_0024km(_0023_003DzcrILBXg_003D);
		_0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(_0023_003DzcrILBXg_003D, null);
	}

	internal void _0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(IList<Entity> _0023_003DzcrILBXg_003D, RegenOptions _0023_003DzZcrk_0024oE_003D)
	{
		if (_0023_003Dz_W2t55LS28X8(_0023_003DzcrILBXg_003D))
		{
			_0023_003DzqOJmyFUuwZyA(_0023_003DzcrILBXg_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, null);
		}
	}

	internal async Task _0023_003DzxBIitsjI3JjNuLxSbQ_003D_003D(IList<Entity> _0023_003DzcrILBXg_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, _0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D _0023_003DzToHGjyY_003D, int _0023_003Dzjhyg1Go_003D)
	{
		if (_0023_003Dz_W2t55LS28X8(_0023_003DzcrILBXg_003D))
		{
			await _0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(_0023_003DzcrILBXg_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, _0023_003DzToHGjyY_003D, _0023_003Dzjhyg1Go_003D, null);
		}
	}

	private bool _0023_003Dz_W2t55LS28X8(IList<Entity> _0023_003DzcrILBXg_003D)
	{
		if (base.Document == null || base.Document.Blocks.isOffline)
		{
			return false;
		}
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().IsRenderingContextValid())
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
		}
		bool value = base.Document.Layers != null && base.Document.Layers._0023_003DzswaTj8gEDyWc();
		bool value2 = base.Document.TextStyles != null && base.Document.TextStyles._0023_003DzOU5UUm8kRh6c();
		HashSet<string> _0023_003DzIUtOi3ah5yj = new HashSet<string>();
		foreach (Entity item in _0023_003DzcrILBXg_003D)
		{
			base.Document.Layers?.CheckAndFixDefaultLayerName(item, value);
			base.Document.TextStyles?._0023_003Dzzv3gdukD06Co7c8MLQ_003D_003D(item, value2);
			_0023_003Dz_oWOLd4zlEbL(item);
			_0023_003DzSTF_0024BjQOhtuV(item, _0023_003DzIUtOi3ah5yj);
		}
		_0023_003DzGh7ktZe_00242KjhIy__gw_003D_003D(_0023_003DzcrILBXg_003D, _0023_003DzlxKBCJ2zobwv());
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			_0023_003Dzo60vEkkaRGxX().ResetNeededConvexHull();
		}
		CombineBoundingBox(_0023_003DzcrILBXg_003D);
		return true;
	}

	private void _0023_003DzTBzg02M_003D(Entity _0023_003DzUBZd570_003D)
	{
		foreach (BlockReference item in _0023_003DzLeyHB00_003D.referencesToMe)
		{
			item.transformedEntityBoxes.Remove(_0023_003DzUBZd570_003D);
			item.isBlockDirty = true;
		}
		if (_0023_003DzUBZd570_003D is BlockReference blockReference)
		{
			base.Document.Blocks[blockReference.BlockName].referencesToMe.Remove(blockReference);
		}
	}

	private void _0023_003Dz_oWOLd4zlEbL(Entity _0023_003Dz9j7EUB0_003D)
	{
		if (_0023_003Dz9j7EUB0_003D is BlockReference blockReference)
		{
			HashSet<string> _0023_003Dz4XghYRm_00245p6Y = new HashSet<string> { _0023_003DzLeyHB00_003D.Name };
			base.Document.Blocks[blockReference.BlockName]._0023_003DzMRs_0024OEWhjDS6(blockReference.BlockName, _0023_003Dz4XghYRm_00245p6Y, base.Document.Blocks);
		}
	}

	private void _0023_003DzSTF_0024BjQOhtuV(Entity _0023_003Dz9j7EUB0_003D, HashSet<string> _0023_003DzIUtOi3ah5yj9)
	{
		_0023_003DzSTF_0024BjQOhtuV(_0023_003Dz9j7EUB0_003D, _0023_003Dz9j7EUB0_003D.LayerName, _0023_003DzIUtOi3ah5yj9);
	}

	private void _0023_003DzSTF_0024BjQOhtuV(Entity _0023_003Dz9j7EUB0_003D, string _0023_003DzaROjBYA_003D, HashSet<string> _0023_003DzIUtOi3ah5yj9)
	{
		if (base.Document == null)
		{
			return;
		}
		if (!base.Document.Layers.CheckItemKey(_0023_003DzaROjBYA_003D))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983671) + _0023_003DzaROjBYA_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983640) + _0023_003Dz9j7EUB0_003D.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983619));
		}
		if (_0023_003Dz9j7EUB0_003D is ICurve)
		{
			string lineTypeName = _0023_003Dz9j7EUB0_003D.LineTypeName;
			if (lineTypeName != null && !base.Document.LineTypes.CheckItemKey(lineTypeName))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983574) + lineTypeName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983640) + _0023_003Dz9j7EUB0_003D.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983619));
			}
		}
		else if (_0023_003Dz9j7EUB0_003D is Text { StyleName: var styleName })
		{
			if (!string.IsNullOrEmpty(styleName) && !base.Document.TextStyles.CheckItemKey(styleName))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983288) + styleName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983640) + _0023_003Dz9j7EUB0_003D.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983619));
			}
		}
		else if (_0023_003Dz9j7EUB0_003D is Table table)
		{
			for (int i = 0; i < table.RowsNum; i++)
			{
				for (int j = 0; j < table.ColumnsNum; j++)
				{
					string styleName2 = table.GetStyleName(i, j);
					if (!string.IsNullOrEmpty(styleName2) && !base.Document.TextStyles.CheckItemKey(styleName2))
					{
						throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983288) + styleName2 + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983640) + _0023_003Dz9j7EUB0_003D.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983619));
					}
				}
			}
		}
		else if (_0023_003Dz9j7EUB0_003D is Hatch { PatternName: var patternName } hatch)
		{
			if (!hatch.IsUserDefinedPattern && patternName != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485) && !base.Document.HatchPatterns.CheckItemKey(patternName))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983257) + patternName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983640) + _0023_003Dz9j7EUB0_003D.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983619));
			}
		}
		else
		{
			if (_0023_003Dz9j7EUB0_003D is BlockReference { BlockName: var blockName })
			{
				if (string.IsNullOrEmpty(blockName) || !base.Document.Blocks.CheckItemKey(blockName))
				{
					throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983231) + blockName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983640) + _0023_003Dz9j7EUB0_003D.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983619));
				}
				if (!_0023_003DzIUtOi3ah5yj9.Add(blockName))
				{
					return;
				}
				{
					foreach (Entity entity in base.Document.Blocks[blockName].Entities)
					{
						_0023_003DzSTF_0024BjQOhtuV(entity, _0023_003DzIUtOi3ah5yj9);
					}
					return;
				}
			}
			string materialName = _0023_003Dz9j7EUB0_003D.MaterialName;
			if (!string.IsNullOrEmpty(materialName) && !base.Document.Materials.CheckItemKey(materialName))
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983193) + materialName + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983640) + _0023_003Dz9j7EUB0_003D.GetType().Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983619));
			}
		}
	}

	public override bool Remove(Entity entity)
	{
		for (int i = 0; i < baseList.Count; i++)
		{
			if (entity == baseList[i])
			{
				RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	public override void RemoveAt(int index)
	{
		if (base.Document != null)
		{
			_0023_003Dzy_U_9AErvRNX(index);
		}
		baseList.RemoveAt(index);
	}

	private void _0023_003Dzy_U_9AErvRNX(int _0023_003DzyzK8swU_003D)
	{
		Entity entity = baseList[_0023_003DzyzK8swU_003D];
		_0023_003DzvCwTlYsGALPj(entity);
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().RenderContext != null)
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
			_0023_003DzLeyHB00_003D._0023_003DzKoGQhbVaqLRx(_0023_003DzyzK8swU_003D);
			_0023_003DzTBzg02M_003D(entity);
			entity.Dispose();
		}
		if (base.Document != null)
		{
			base.Document.isBoundingBoxDirty = true;
		}
	}

	public override void RemoveRange(int index, int count)
	{
		if (base.Document != null)
		{
			for (int num = index + count - 1; num >= index; num--)
			{
				_0023_003Dzy_U_9AErvRNX(num);
			}
		}
		baseList.RemoveRange(index, count);
	}

	public override int RemoveAll(Predicate<Entity> match)
	{
		if (base.Document != null)
		{
			HashSet<Entity> hashSet = FindAll(match).ToHashSet();
			int num = hashSet.Count;
			int num2 = base.Count - 1;
			while (num2 >= 0 && num > 0)
			{
				if (hashSet.Contains(this[num2]))
				{
					_0023_003Dzy_U_9AErvRNX(num2);
					num--;
				}
				num2--;
			}
		}
		return baseList.RemoveAll(match);
	}

	public void Remove(IEnumerable<Entity> entities)
	{
		_0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D2 = new _0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D();
		_0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D2._0023_003Dzgx_XqE36Q_W7 = ((entities is HashSet<Entity> hashSet) ? hashSet : entities.ToHashSet());
		RemoveAll(_0023_003DzKon_0024MHsqE_0024l9Pan3G75hxD8_003D2._0023_003Dz8es9C7qdzLQe);
	}

	internal bool RemoveNoDispose(Entity _0023_003Dz9j7EUB0_003D)
	{
		for (int i = 0; i < baseList.Count; i++)
		{
			if (_0023_003Dz9j7EUB0_003D == baseList[i])
			{
				RemoveAtNoDispose(i);
				return true;
			}
		}
		return false;
	}

	internal void RemoveAtNoDispose(int _0023_003DzyzK8swU_003D)
	{
		if (base.Document != null)
		{
			Entity _0023_003DzUBZd570_003D = baseList[_0023_003DzyzK8swU_003D];
			_0023_003DzvCwTlYsGALPj(_0023_003DzUBZd570_003D);
			_0023_003DzTBzg02M_003D(_0023_003DzUBZd570_003D);
			base.Document.isBoundingBoxDirty = true;
		}
		baseList.RemoveAt(_0023_003DzyzK8swU_003D);
	}

	internal void ClearNoDispose()
	{
		if (base.Document != null)
		{
			_0023_003DzoHeLgXXPaLwn();
			foreach (BlockReference item in _0023_003DzLeyHB00_003D.referencesToMe)
			{
				item.transformedEntityBoxes.Clear();
				item.isBlockDirty = true;
			}
		}
		baseList.Clear();
	}

	public override void Insert(int index, Entity entity)
	{
		base.Insert(index, entity);
		_0023_003DzLeyHB00_003D?._0023_003Dzs81As7NRhdUK(index, 1);
	}

	public override async Task InsertRangeAsync(int index, IEnumerable<Entity> collection, RegenOptions ro = null)
	{
		if (collection is IList<Entity> list && _0023_003Dz_W2t55LS28X8(list))
		{
			_0023_003Dz_hpEX5QR2_0024km(collection);
			baseList.InsertRange(index, list);
			await _0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(list, ro, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)2, index, null);
		}
	}

	public void Insert(double x, double y, double z, string blockName, double angleInRadians)
	{
		if (!base.Document.Blocks.Contains(blockName))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983419));
		}
		BlockReference item = new BlockReference(x, y, z, blockName, angleInRadians);
		Add(item);
	}

	public override async Task InsertAsync(int index, Entity item, RegenOptions ro = null)
	{
		if (_0023_003Dz_W2t55LS28X8(item))
		{
			_0023_003DzQfuT2WLxU8Wb(item);
			_0023_003DzsHOPLaXVRRYt(index, item, ro);
			await _0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(new List<Entity>(1) { item }, ro, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)2, index, null);
		}
	}

	public override void InsertRange(int index, IEnumerable<Entity> collection)
	{
		int count = baseList.Count;
		base.InsertRange(index, collection);
		_0023_003DzLeyHB00_003D?._0023_003Dzs81As7NRhdUK(index, baseList.Count - count);
	}

	public override void Clear()
	{
		_0023_003Dzw6MTIExa9FCQ = Point3D.MaxValue;
		_0023_003Dzs_rNF1nafbip = Point3D.MinValue;
		_0023_003DzLeyHB00_003D?.Groups?.Clear();
		if (base.Document != null)
		{
			if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().ObjectManipulator != null)
			{
				_0023_003Dzo60vEkkaRGxX().ObjectManipulator.Cancel();
			}
			base.Document.isBoundingBoxDirty = true;
			_0023_003DzoHeLgXXPaLwn();
			if (_0023_003DzLeyHB00_003D != null)
			{
				foreach (BlockReference item in _0023_003DzLeyHB00_003D.referencesToMe)
				{
					item.transformedEntityBoxes.Clear();
					item.isBlockDirty = true;
				}
			}
		}
		base.Clear();
	}

	protected void CombineBoundingBox(Entity ent)
	{
		CombineBoundingBox(new Entity[1] { ent });
	}

	protected void CombineBoundingBox(IList<Entity> collection)
	{
		if (base.Document == null || !Regeneration._0023_003Dz6HH5XmGI_ZT8oAhODOuRNLk_003D(collection, base.Document.Blocks))
		{
			return;
		}
		if (invalidBBox)
		{
			_0023_003Dzw6MTIExa9FCQ = Point3D.MaxValue;
			_0023_003Dzs_rNF1nafbip = Point3D.MinValue;
			invalidBBox = false;
		}
		else if (_0023_003Dzw6MTIExa9FCQ == Point3D.MaxValue && base.Count > 0)
		{
			List<Entity> list = new List<Entity>(baseList);
			list.AddRange(collection);
			collection = list;
		}
		Dictionary<string, Point3D[]> _0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D = new Dictionary<string, Point3D[]>();
		foreach (Entity item in collection)
		{
			if (!base.Document.Layers[item.LayerName].Visible || !item.Visible)
			{
				continue;
			}
			Point3D[] array = item._0023_003DzMHGsUs_0024dF1onGPMzUA_003D_003D(base.Document.Blocks, base.Document.Layers, _0023_003DzUhW4aEj3QiQ72vNRgA_003D_003D);
			foreach (Point3D point3D in array)
			{
				if (point3D.X < _0023_003Dzw6MTIExa9FCQ.X)
				{
					_0023_003Dzw6MTIExa9FCQ.X = point3D.X;
				}
				if (point3D.X > _0023_003Dzs_rNF1nafbip.X)
				{
					_0023_003Dzs_rNF1nafbip.X = point3D.X;
				}
				if (point3D.Y < _0023_003Dzw6MTIExa9FCQ.Y)
				{
					_0023_003Dzw6MTIExa9FCQ.Y = point3D.Y;
				}
				if (point3D.Y > _0023_003Dzs_rNF1nafbip.Y)
				{
					_0023_003Dzs_rNF1nafbip.Y = point3D.Y;
				}
				if (point3D.Z < _0023_003Dzw6MTIExa9FCQ.Z)
				{
					_0023_003Dzw6MTIExa9FCQ.Z = point3D.Z;
				}
				if (point3D.Z > _0023_003Dzs_rNF1nafbip.Z)
				{
					_0023_003Dzs_rNF1nafbip.Z = point3D.Z;
				}
			}
		}
		if (_0023_003DzLeyHB00_003D != base.Document.RootBlock)
		{
			EntityList entities = base.Document.RootBlock.Entities;
			if (entities.invalidBBox)
			{
				entities._0023_003Dzw6MTIExa9FCQ = Point3D.MaxValue;
				entities._0023_003Dzs_rNF1nafbip = Point3D.MinValue;
				entities.invalidBBox = false;
			}
			Utility.UpdateMinMaxQuick(_0023_003Dzw6MTIExa9FCQ, entities._0023_003Dzw6MTIExa9FCQ, entities._0023_003Dzs_rNF1nafbip);
			Utility.UpdateMinMaxQuick(_0023_003Dzs_rNF1nafbip, entities._0023_003Dzw6MTIExa9FCQ, entities._0023_003Dzs_rNF1nafbip);
		}
		base.Document.isBoundingBoxDirty = true;
	}

	public void Regen(RegenOptions ro = null)
	{
		if (_0023_003Dz5LunQb_j4_00244nmKuyhw_003D_003D())
		{
			_0023_003DzqOJmyFUuwZyA(baseList, ro, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, null);
		}
	}

	public async Task RegenAsync(RegenOptions ro = null)
	{
		if (_0023_003Dz5LunQb_j4_00244nmKuyhw_003D_003D())
		{
			await _0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(baseList, ro, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0, null);
		}
	}

	private bool _0023_003Dz5LunQb_j4_00244nmKuyhw_003D_003D()
	{
		if (base.Document == null)
		{
			return false;
		}
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			foreach (IViewport viewport in _0023_003Dzo60vEkkaRGxX().Viewports)
			{
				viewport.Camera.ZBufferData.ResetCapturedView();
			}
		}
		_0023_003DzwKw7out1Wc_qZ0PKW_VXjgZOPo59g52tvCdKm_4_003D();
		if (_0023_003Dzo60vEkkaRGxX() != null)
		{
			_0023_003Dzo60vEkkaRGxX().ResetNeededConvexHull();
			_0023_003Dzo60vEkkaRGxX().RenderContext?.MakeCurrent();
		}
		return true;
	}

	private void _0023_003DzxcndDxKhGKf8(Entity _0023_003Dzs_0024uS8LA_003D, BlockKeyedCollection _0023_003DznAF4fNkMjAgi)
	{
		if (_0023_003Dzs_0024uS8LA_003D is BlockReference item)
		{
			_0023_003DznAF4fNkMjAgi[((BlockReference)_0023_003Dzs_0024uS8LA_003D).BlockName].referencesToMe.Add(item);
		}
	}

	private void _0023_003DzGh7ktZe_00242KjhIy__gw_003D_003D(IEnumerable<Entity> _0023_003DzyIjeB1Bf2138, BlockKeyedCollection _0023_003DznAF4fNkMjAgi)
	{
		foreach (Entity item in _0023_003DzyIjeB1Bf2138)
		{
			_0023_003DzxcndDxKhGKf8(item, _0023_003DznAF4fNkMjAgi);
		}
	}

	internal void _0023_003DzwKw7out1Wc_qZ0PKW_VXjgZOPo59g52tvCdKm_4_003D()
	{
		foreach (Block item in _0023_003DzlxKBCJ2zobwv())
		{
			item.regenerated = false;
		}
	}

	internal void _0023_003DzqOJmyFUuwZyA(IList<Entity> _0023_003Dzv7xH9gk_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, bool _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D, RegenParams _0023_003DzkY6mqyuPEDLn)
	{
		if (_0023_003Dzv7xH9gk_003D.Count != 0)
		{
			Regeneration regeneration = _0023_003Dzy5DAe2h96zh10bO1FmzFatw_003D(_0023_003Dzv7xH9gk_003D, _0023_003DzLeyHB00_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0, _0023_003DzkY6mqyuPEDLn);
			if (_0023_003Dzo60vEkkaRGxX() != null)
			{
				ICursorContainer prev = _0023_003Dzo60vEkkaRGxX().SetWaitCursor();
				_0023_003Dzo60vEkkaRGxX().DoWork(regeneration);
				_0023_003Dzo60vEkkaRGxX().RestoreCursor(prev);
			}
			else
			{
				regeneration.DoWork();
				regeneration.WorkCompleted(base.Document);
			}
		}
	}

	private async Task _0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, RegenOptions _0023_003DzZcrk_0024oE_003D, bool _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D, _0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D _0023_003DzToHGjyY_003D, int _0023_003Dzjhyg1Go_003D, RegenParams _0023_003DzkY6mqyuPEDLn)
	{
		if (_0023_003Dzv7xH9gk_003D.Count != 0)
		{
			Regeneration regeneration = _0023_003Dzy5DAe2h96zh10bO1FmzFatw_003D(_0023_003Dzv7xH9gk_003D, _0023_003DzLeyHB00_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D, _0023_003DzToHGjyY_003D, _0023_003Dzjhyg1Go_003D, _0023_003DzkY6mqyuPEDLn);
			if (_0023_003Dzo60vEkkaRGxX() != null)
			{
				await _0023_003Dzo60vEkkaRGxX().DoWorkAsync(new global::_0023_003Dz59HJ4yStYPkbzfhacP1yQy8_003D<WorkUnit>(regeneration));
				return;
			}
			await regeneration.DoWorkAsync();
			regeneration.WorkCompleted(base.Document);
		}
	}

	private Regeneration _0023_003Dzy5DAe2h96zh10bO1FmzFatw_003D(IList<Entity> _0023_003Dzv7xH9gk_003D, Block _0023_003Dz8O9WEppYBXsu, RegenOptions _0023_003DzZcrk_0024oE_003D, bool _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D, _0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D _0023_003DzToHGjyY_003D, int _0023_003Dzjhyg1Go_003D, RegenParams _0023_003DzkY6mqyuPEDLn)
	{
		if (_0023_003DzkY6mqyuPEDLn == null)
		{
			_0023_003DzkY6mqyuPEDLn = new RegenParams(this)
			{
				SkipTexts = (_0023_003Dzo60vEkkaRGxX() == null)
			};
		}
		regenTime = 0L;
		if (_0023_003DzZcrk_0024oE_003D != null)
		{
			return new Regeneration(_0023_003Dzv7xH9gk_003D, _0023_003Dz8O9WEppYBXsu, base.Document.Blocks, _0023_003Dzo60vEkkaRGxX()?.ParentBlocks, _0023_003DzkY6mqyuPEDLn, _0023_003DzZcrk_0024oE_003D.ProgressBarText, _0023_003DzZcrk_0024oE_003D.PreProcessSilhouettes, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D, _0023_003DzToHGjyY_003D, _0023_003Dzjhyg1Go_003D);
		}
		return new Regeneration(_0023_003Dzv7xH9gk_003D, _0023_003Dz8O9WEppYBXsu, base.Document.Blocks, _0023_003Dzo60vEkkaRGxX()?.ParentBlocks, _0023_003DzkY6mqyuPEDLn, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D);
	}

	public void RegenAllCurved(RegenOptions ro = null)
	{
		base.Document.UpdateBoundingBox();
		RegenParams visualRefinement = base.Document.GetVisualRefinement();
		RegenAllCurved(visualRefinement.Deviation, visualRefinement.Angle, ro);
	}

	public void RegenAllCurved(double deviation, double angle = Math.PI / 6.0, RegenOptions ro = null)
	{
		if (_0023_003Dz5LunQb_j4_00244nmKuyhw_003D_003D())
		{
			RegenParams _0023_003DzkY6mqyuPEDLn = new RegenParams(deviation, angle, base.Document);
			_0023_003DzqOJmyFUuwZyA(baseList, ro, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: true, _0023_003DzkY6mqyuPEDLn);
		}
	}

	public async Task RegenAllCurvedAsync(RegenOptions ro = null)
	{
		base.Document.UpdateBoundingBox();
		RegenParams visualRefinement = base.Document.GetVisualRefinement();
		await RegenAllCurvedAsync(visualRefinement.Deviation, visualRefinement.Angle, ro);
	}

	public async Task RegenAllCurvedAsync(double deviation, double angle = Math.PI / 6.0, RegenOptions ro = null)
	{
		if (_0023_003Dz5LunQb_j4_00244nmKuyhw_003D_003D())
		{
			RegenParams _0023_003DzkY6mqyuPEDLn = new RegenParams(deviation, angle, base.Document);
			await _0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(baseList, ro, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: true, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0, _0023_003DzkY6mqyuPEDLn);
		}
	}

	public void UpdateBoundingBox()
	{
		if (base.Document != null)
		{
			_0023_003Dzw6MTIExa9FCQ = Point3D.MaxValue;
			_0023_003Dzs_rNF1nafbip = Point3D.MinValue;
			int count = base.Count;
			invalidBBox = false;
			ParallelConveHull.Instance.Stop();
			Utility._0023_003DzEtuso7_p35ZOEjCHBg_003D_003D(this, new TraversalParams(base.Document), out _0023_003Dzw6MTIExa9FCQ, out _0023_003Dzs_rNF1nafbip, out _0023_003DzcrVECsKc78F_0024, out var _0023_003DzZkSIjE9P7t5u);
			if (count == 0 || _0023_003DzZkSIjE9P7t5u || Utility.InvalidOGLPoint(_0023_003Dzw6MTIExa9FCQ) || Utility.InvalidOGLPoint(_0023_003Dzs_rNF1nafbip))
			{
				Utility.ResetBBox(out _0023_003Dzw6MTIExa9FCQ, out _0023_003Dzs_rNF1nafbip);
				invalidBBox = true;
			}
			else if (base.Document.workspace != null && base.Document.workspace.ZoomFitMode != zoomFitType.Standard)
			{
				ParallelConveHull.Instance.CreateAndStart(base.Document.workspace);
			}
			if (Point3D.DistanceSquared(_0023_003Dzw6MTIExa9FCQ, _0023_003Dzs_rNF1nafbip) == 0.0)
			{
				_0023_003Dzs_rNF1nafbip = _0023_003Dzw6MTIExa9FCQ + new Point3D(1.0, 1.0, 1.0);
			}
		}
	}

	private bool _0023_003DzyO9VAy9rvFdW(int _0023_003DzOadj594_003D)
	{
		if (base.Document == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983389));
		}
		return base.Document.Layers.CheckItemIndex(_0023_003DzOadj594_003D);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void _0023_003DzRbCjfzYnMque(Entity _0023_003Dz9j7EUB0_003D, string _0023_003DzaROjBYA_003D)
	{
		_0023_003DzSTF_0024BjQOhtuV(_0023_003Dz9j7EUB0_003D, _0023_003DzaROjBYA_003D, new HashSet<string>());
		_0023_003Dz9j7EUB0_003D.LayerName = _0023_003DzaROjBYA_003D;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void _0023_003Dz1drjrR4_003D(Entity _0023_003Dz9j7EUB0_003D, Color _0023_003Dz1MMYB1g_003D)
	{
		_0023_003Dz9j7EUB0_003D.ColorMethod = colorMethodType.byEntity;
		_0023_003Dz9j7EUB0_003D.Color = _0023_003Dz1MMYB1g_003D;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void _0023_003Dz49fNrkVagQGU<T>(IEnumerable<T> _0023_003DzcrILBXg_003D, Color _0023_003Dz1MMYB1g_003D) where T : Entity
	{
		IList<T> list = _0023_003DzcrILBXg_003D as IList<T>;
		if (list == null)
		{
			list = _0023_003DzcrILBXg_003D.ToList();
		}
		foreach (T item in list)
		{
			item.ColorMethod = colorMethodType.byEntity;
			item.Color = _0023_003Dz1MMYB1g_003D;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void _0023_003Dz14k1SiZTyF0i<T>(IEnumerable<T> _0023_003DzcrILBXg_003D, string _0023_003DzaROjBYA_003D) where T : Entity
	{
		IList<T> list = _0023_003DzcrILBXg_003D as IList<T>;
		if (list == null)
		{
			list = _0023_003DzcrILBXg_003D.ToList();
		}
		if (base.Document == null)
		{
			return;
		}
		if (!base.Document.Layers.CheckItemKey(_0023_003DzaROjBYA_003D))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984001) + _0023_003DzaROjBYA_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983995));
		}
		foreach (T item in list)
		{
			item.LayerName = _0023_003DzaROjBYA_003D;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void _0023_003Dzm9WI5LkFXEn_fk_hig_003D_003D<T>(IEnumerable<T> _0023_003DzcrILBXg_003D, string _0023_003DzaROjBYA_003D, Color _0023_003Dz1MMYB1g_003D) where T : Entity
	{
		IList<T> list = _0023_003DzcrILBXg_003D as IList<T>;
		if (list == null)
		{
			list = _0023_003DzcrILBXg_003D.ToList();
		}
		if (base.Document == null)
		{
			return;
		}
		if (!base.Document.Layers.CheckItemKey(_0023_003DzaROjBYA_003D))
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984001) + _0023_003DzaROjBYA_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983995));
		}
		foreach (T item in list)
		{
			item.LayerName = _0023_003DzaROjBYA_003D;
			item.ColorMethod = colorMethodType.byEntity;
			item.Color = _0023_003Dz1MMYB1g_003D;
		}
	}

	public void Add(Entity entity, string layerName)
	{
		_0023_003DzRbCjfzYnMque(entity, layerName);
		Add(entity);
	}

	public async Task AddAsync(Entity entity, string layerName)
	{
		_0023_003DzRbCjfzYnMque(entity, layerName);
		await AddAsync(entity);
	}

	public void Add(Entity entity, string layerName, Color color)
	{
		_0023_003DzRbCjfzYnMque(entity, layerName);
		_0023_003Dz1drjrR4_003D(entity, color);
		Add(entity);
	}

	public async Task AddAsync(Entity entity, string layerName, Color color)
	{
		_0023_003DzRbCjfzYnMque(entity, layerName);
		_0023_003Dz1drjrR4_003D(entity, color);
		await AddAsync(entity);
	}

	public void Add(Entity entity, Color color)
	{
		_0023_003Dz1drjrR4_003D(entity, color);
		Add(entity);
	}

	public async Task AddAsync(Entity entity, Color color)
	{
		_0023_003Dz1drjrR4_003D(entity, color);
		await AddAsync(entity);
	}

	public override async Task AddAsync(Entity item, RegenOptions ro = null)
	{
		if (_0023_003Dz_W2t55LS28X8(item))
		{
			_0023_003DzQfuT2WLxU8Wb(item);
			_0023_003Dz6o91qlpB3dZY(item);
			await _0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(new List<Entity>(1) { item }, ro, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)0, 0, null);
		}
	}

	public override async Task AddRangeAsync(IEnumerable<Entity> collection, RegenOptions ro = null)
	{
		if (collection is IList<Entity> list && _0023_003Dz_W2t55LS28X8(list))
		{
			_0023_003Dz_hpEX5QR2_0024km(collection);
			_0023_003Dz10xO6jmZZfus(list);
			await _0023_003DzYgpzadgBiGwcWMmvBQ_003D_003D(list, ro, _0023_003DzbPbTyJBgBacq0wSHVA_003D_003D: false, (_0023_003DzlvcTzRDO3KSlmsnRkDxEK40P0DoCz3avhw_003D_003D)1, 0, null);
		}
	}

	public void AddRange<T>(IEnumerable<T> collection, string layerName) where T : Entity
	{
		_0023_003Dz14k1SiZTyF0i(collection, layerName);
		AddRange(collection);
	}

	public async Task AddRangeAsync<T>(IEnumerable<T> collection, string layerName) where T : Entity
	{
		_0023_003Dz14k1SiZTyF0i(collection, layerName);
		await AddRangeAsync(collection);
	}

	public void AddRange<T>(IEnumerable<T> collection, string layerName, Color color) where T : Entity
	{
		_0023_003Dzm9WI5LkFXEn_fk_hig_003D_003D(collection, layerName, color);
		AddRange(collection);
	}

	public async Task AddRangeAsync<T>(IEnumerable<T> collection, string layerName, Color color) where T : Entity
	{
		_0023_003Dzm9WI5LkFXEn_fk_hig_003D_003D(collection, layerName, color);
		await AddRangeAsync(collection);
	}

	public void AddRange<T>(IEnumerable<T> collection, Color color) where T : Entity
	{
		_0023_003Dz49fNrkVagQGU(collection, color);
		AddRange(collection);
	}

	public async Task AddRangeAsync<T>(IEnumerable<T> collection, Color color) where T : Entity
	{
		_0023_003Dz49fNrkVagQGU(collection, color);
		await AddRangeAsync(collection);
	}

	private void _0023_003DzU38cTtk_003D(Color _0023_003Dz1MMYB1g_003D)
	{
		if (_0023_003Dz1MMYB1g_003D.IsEmpty)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302979687), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983939));
		}
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dz1MMYB1g_003D == _0023_003Dzo60vEkkaRGxX().Selection.Color)
		{
			throw new ArgumentException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302983952), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984154));
		}
	}

	public void CopySelection()
	{
		_0023_003DzvUfUQYpU87Iv(_0023_003DzyEyDDeg_003D: false);
	}

	private bool _0023_003DzU_H5ubMROsWkOrRkBg_003D_003D(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		if (base.Document.workspace != null && base.Document.workspace is IDesign { CurrentSketch: not null } design)
		{
			return design.CurrentSketch._0023_003DzWyepPf1e8IHzxbfCCfJq3d4_003D(_0023_003Dzs_0024uS8LA_003D);
		}
		return false;
	}

	private void _0023_003DzvUfUQYpU87Iv(bool _0023_003DzyEyDDeg_003D)
	{
		DataForCopyAndPaste dataForCopyAndPaste = new DataForCopyAndPaste();
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		HashSet<string> hashSet3 = new HashSet<string>();
		HashSet<string> hashSet4 = new HashSet<string>();
		HashSet<string> hashSet5 = new HashSet<string>();
		HashSet<string> hashSet6 = new HashSet<string>();
		HashSet<Entity> hashSet7 = new HashSet<Entity>();
		IDesign design = base.Document.workspace as IDesign;
		if (base.Document.workspace != null && design?.CurrentSketch != null)
		{
			hashSet7 = design.CurrentSketch._0023_003DzwsXIprMtQcFW(dataForCopyAndPaste, hashSet2, hashSet3, hashSet4, hashSet5, hashSet6, _0023_003DzyEyDDeg_003D);
		}
		List<int> list = new List<int>();
		for (int i = 0; i < baseList.Count; i++)
		{
			Entity entity = baseList[i];
			if (!entity.Selected || _0023_003DzU_H5ubMROsWkOrRkBg_003D_003D(entity))
			{
				continue;
			}
			dataForCopyAndPaste.Entities.Add(entity);
			if (entity is BlockReference)
			{
				BlockReference blockReference = (BlockReference)entity;
				if (!hashSet.Contains(blockReference.BlockName))
				{
					hashSet.Add(blockReference.BlockName);
					_0023_003DzXqNV8Mtu9zDa(base.Document.Blocks[blockReference.BlockName].Entities, hashSet, hashSet2, hashSet3, hashSet4, hashSet5, hashSet6);
				}
			}
			FillCollectionToCopy(entity, hashSet2, hashSet3, hashSet4, hashSet5, hashSet6);
			if (_0023_003DzyEyDDeg_003D && !hashSet7.Contains(entity))
			{
				list.Add(i);
			}
		}
		foreach (string item in hashSet)
		{
			dataForCopyAndPaste.Blocks.Add(base.Document.Blocks[item]);
		}
		foreach (string item2 in hashSet2)
		{
			Layer layer = base.Document.Layers[item2];
			if (!string.IsNullOrEmpty(layer.LineTypeName))
			{
				hashSet5.Add(layer.LineTypeName);
			}
			if (!string.IsNullOrEmpty(layer.MaterialName))
			{
				hashSet3.Add(layer.MaterialName);
			}
			dataForCopyAndPaste.Layers.Add(layer);
		}
		foreach (string item3 in hashSet3)
		{
			dataForCopyAndPaste.Materials.Add(base.Document.Materials[item3]);
		}
		foreach (string item4 in hashSet4)
		{
			dataForCopyAndPaste.TextStyles.Add(base.Document.TextStyles[item4]);
		}
		foreach (string item5 in hashSet5)
		{
			dataForCopyAndPaste.LineTypes.Add(base.Document.LineTypes[item5]);
		}
		foreach (string item6 in hashSet6)
		{
			dataForCopyAndPaste.HatchPatterns.Add(base.Document.HatchPatterns[item6]);
		}
		if (dataForCopyAndPaste.Entities.Count <= 0 && dataForCopyAndPaste.SketchEntities.Count <= 0)
		{
			return;
		}
		_0023_003Dzo60vEkkaRGxX()?.SetClipboardData(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984131), _0023_003DzA8byjAU_003D(dataForCopyAndPaste, _0023_003Dzo60vEkkaRGxX().FileSerializerForExtendedFormat));
		if (!_0023_003DzyEyDDeg_003D)
		{
			return;
		}
		for (int num = list.Count - 1; num >= 0; num--)
		{
			int index = list[num];
			RemoveAt(index);
		}
		if (_0023_003DzyEyDDeg_003D && design != null)
		{
			foreach (Entity item7 in hashSet7)
			{
				design.CurrentSketch.DeleteEntity(item7);
			}
			if (design.CurrentSketch != null)
			{
				design.CurrentSketch.UpdateAndInvalidate();
			}
		}
		base.Document.UpdateBoundingBox();
	}

	internal static void FillCollectionToCopy(Entity _0023_003Dzs_0024uS8LA_003D, HashSet<string> _0023_003DzWCQYTKrbaNoRwVTuzg_003D_003D, HashSet<string> _0023_003Dz78J4Ufc4fQIHwfRoh_0024mMuMc_003D, HashSet<string> _0023_003DzLZoMS553KlT3, HashSet<string> _0023_003DzNThOv6NyRUeS, HashSet<string> _0023_003Dzu4VhVrORkoJFj2c_0g_003D_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003Dzs_0024uS8LA_003D.LayerName) && !_0023_003DzWCQYTKrbaNoRwVTuzg_003D_003D.Contains(_0023_003Dzs_0024uS8LA_003D.LayerName))
		{
			_0023_003DzWCQYTKrbaNoRwVTuzg_003D_003D.Add(_0023_003Dzs_0024uS8LA_003D.LayerName);
		}
		if (!string.IsNullOrEmpty(_0023_003Dzs_0024uS8LA_003D.MaterialName) && !_0023_003Dz78J4Ufc4fQIHwfRoh_0024mMuMc_003D.Contains(_0023_003Dzs_0024uS8LA_003D.MaterialName))
		{
			_0023_003Dz78J4Ufc4fQIHwfRoh_0024mMuMc_003D.Add(_0023_003Dzs_0024uS8LA_003D.MaterialName);
		}
		if (_0023_003Dzs_0024uS8LA_003D is Text text)
		{
			if (!string.IsNullOrEmpty(text.StyleName) && !_0023_003DzLZoMS553KlT3.Contains(text.StyleName))
			{
				_0023_003DzLZoMS553KlT3.Add(text.StyleName);
			}
		}
		else if (_0023_003Dzs_0024uS8LA_003D is Table table)
		{
			for (int i = 0; i < table.RowsNum; i++)
			{
				for (int j = 0; j < table.ColumnsNum; j++)
				{
					string styleName = table.GetStyleName(i, j);
					if (!string.IsNullOrEmpty(styleName) && !_0023_003DzLZoMS553KlT3.Contains(styleName))
					{
						_0023_003DzLZoMS553KlT3.Add(styleName);
					}
				}
			}
		}
		if (!string.IsNullOrEmpty(_0023_003Dzs_0024uS8LA_003D.LineTypeName) && !_0023_003DzNThOv6NyRUeS.Contains(_0023_003Dzs_0024uS8LA_003D.LineTypeName))
		{
			_0023_003DzNThOv6NyRUeS.Add(_0023_003Dzs_0024uS8LA_003D.LineTypeName);
		}
		if (_0023_003Dzs_0024uS8LA_003D is Hatch { IsUserDefinedPattern: false } hatch && hatch.PatternName != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485) && !_0023_003Dzu4VhVrORkoJFj2c_0g_003D_003D.Contains(hatch.PatternName))
		{
			_0023_003Dzu4VhVrORkoJFj2c_0g_003D_003D.Add(hatch.PatternName);
		}
	}

	private void _0023_003DzXqNV8Mtu9zDa(EntityList _0023_003DzyIjeB1Bf2138, HashSet<string> _0023_003Dz1osqH1iP1skK, HashSet<string> _0023_003DzWCQYTKrbaNoRwVTuzg_003D_003D, HashSet<string> _0023_003Dz78J4Ufc4fQIHwfRoh_0024mMuMc_003D, HashSet<string> _0023_003DzLZoMS553KlT3, HashSet<string> _0023_003DzA3_0024EZ731xRIG, HashSet<string> _0023_003Dzu4VhVrORkoJFj2c_0g_003D_003D)
	{
		foreach (Entity item in _0023_003DzyIjeB1Bf2138)
		{
			if (item is BlockReference)
			{
				BlockReference blockReference = (BlockReference)item;
				if (!_0023_003Dz1osqH1iP1skK.Contains(blockReference.BlockName))
				{
					_0023_003Dz1osqH1iP1skK.Add(blockReference.BlockName);
					_0023_003DzXqNV8Mtu9zDa(base.Document.Blocks[blockReference.BlockName].Entities, _0023_003Dz1osqH1iP1skK, _0023_003DzWCQYTKrbaNoRwVTuzg_003D_003D, _0023_003Dz78J4Ufc4fQIHwfRoh_0024mMuMc_003D, _0023_003DzLZoMS553KlT3, _0023_003DzA3_0024EZ731xRIG, _0023_003Dzu4VhVrORkoJFj2c_0g_003D_003D);
				}
			}
			FillCollectionToCopy(item, _0023_003DzWCQYTKrbaNoRwVTuzg_003D_003D, _0023_003Dz78J4Ufc4fQIHwfRoh_0024mMuMc_003D, _0023_003DzLZoMS553KlT3, _0023_003DzA3_0024EZ731xRIG, _0023_003Dzu4VhVrORkoJFj2c_0g_003D_003D);
		}
	}

	public void CutSelection()
	{
		_0023_003DzvUfUQYpU87Iv(_0023_003DzyEyDDeg_003D: true);
	}

	public bool IsClipboardDataAvailable()
	{
		if (_0023_003Dzo60vEkkaRGxX() == null)
		{
			return false;
		}
		return _0023_003Dzo60vEkkaRGxX().GetClipboardData(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984131)) != null;
	}

	public virtual void Paste()
	{
		if (_0023_003Dzo60vEkkaRGxX() == null)
		{
			return;
		}
		object clipboardData = _0023_003Dzo60vEkkaRGxX().GetClipboardData(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984131));
		if (clipboardData == null)
		{
			return;
		}
		DataForCopyAndPaste dataForCopyAndPaste = _0023_003DzsNB9RHzxjSDJ((byte[])clipboardData, _0023_003Dzo60vEkkaRGxX().FileSerializerForExtendedFormat);
		foreach (Material material in dataForCopyAndPaste.Materials)
		{
			if (!_0023_003Dzo60vEkkaRGxX().Materials.Contains(material))
			{
				_0023_003Dzo60vEkkaRGxX().Materials.Add(material);
			}
		}
		foreach (TextStyle textStyle in dataForCopyAndPaste.TextStyles)
		{
			if (!base.Document.TextStyles.Contains(textStyle))
			{
				base.Document.TextStyles.Add(textStyle);
			}
		}
		foreach (LineType lineType in dataForCopyAndPaste.LineTypes)
		{
			if (!base.Document.LineTypes.Contains(lineType))
			{
				base.Document.LineTypes.Add(lineType);
			}
		}
		foreach (HatchPattern hatchPattern in dataForCopyAndPaste.HatchPatterns)
		{
			if (!base.Document.HatchPatterns.Contains(hatchPattern))
			{
				base.Document.HatchPatterns.Add(hatchPattern);
			}
		}
		foreach (Layer layer in dataForCopyAndPaste.Layers)
		{
			if (!base.Document.Layers.Contains(layer))
			{
				base.Document.Layers.Add(layer);
			}
		}
		foreach (Block block in dataForCopyAndPaste.Blocks)
		{
			if (!base.Document.Blocks.Contains(block))
			{
				base.Document.Blocks.Add(block);
			}
		}
		if (base.Document.workspace is IDesign design)
		{
			design.CurrentSketch?._0023_003DzI0UvCG0_003D(dataForCopyAndPaste);
		}
		else if (dataForCopyAndPaste.SketchEntities.Count > 0)
		{
			foreach (KeyValuePair<Entity, SketchCurve> sketchEntity in dataForCopyAndPaste.SketchEntities)
			{
				Add(sketchEntity.Key);
			}
		}
		AddRange(dataForCopyAndPaste.Entities);
		UpdateBoundingBox();
	}

	private protected byte[] _0023_003DzA8byjAU_003D(DataForCopyAndPaste _0023_003DzgYOSqzol2y8l, Type _0023_003DzflYIIMycQjkG)
	{
		MemoryStream memoryStream = new MemoryStream();
		try
		{
			FileSerializer fileSerializer = FileSerializer._0023_003DzXUqKaIQ_003D(_0023_003DzflYIIMycQjkG);
			fileSerializer._0023_003DzGCOeuIuJS_gt = true;
			FileHeader _0023_003Dz8Vwa6Pc_003D = new FileHeader(contentType.GeometryAndTessellation, serializationType.WithLengthPrefix);
			try
			{
				fileSerializer.WriteHeader(_0023_003Dz8Vwa6Pc_003D, memoryStream);
				fileSerializer.WriteSingleObject(memoryStream, _0023_003DzgYOSqzol2y8l);
			}
			finally
			{
				fileSerializer.ResetCacheForLengthPrefix();
			}
			return memoryStream.ToArray();
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	private protected DataForCopyAndPaste _0023_003DzsNB9RHzxjSDJ(byte[] _0023_003DzQDTEaDqhfZ8G, Type _0023_003DzflYIIMycQjkG)
	{
		MemoryStream memoryStream = new MemoryStream(_0023_003DzQDTEaDqhfZ8G);
		try
		{
			FileSerializer fileSerializer = FileSerializer._0023_003DzXUqKaIQ_003D(_0023_003DzflYIIMycQjkG);
			fileSerializer._0023_003DzGCOeuIuJS_gt = true;
			try
			{
				fileSerializer.ReadHeader(memoryStream);
				long _0023_003DzVRsIQq4_003D;
				return fileSerializer.ReadSingleObject<DataForCopyAndPaste>(memoryStream, out _0023_003DzVRsIQq4_003D);
			}
			finally
			{
				fileSerializer.ResetCacheForLengthPrefix();
			}
		}
		finally
		{
			((IDisposable)memoryStream).Dispose();
		}
	}

	internal void _0023_003DzJW4Y0uY_003D(string _0023_003DzaROjBYA_003D)
	{
		for (int num = baseList.Count - 1; num >= 0; num--)
		{
			Entity entity = baseList[num];
			if (entity.LayerName == _0023_003DzaROjBYA_003D)
			{
				RemoveAt(num);
			}
			else
			{
				_0023_003DzrBeU_f_Ge5Om(_0023_003DzaROjBYA_003D, entity);
			}
		}
	}

	internal static void _0023_003DzrBeU_f_Ge5Om(string _0023_003DzaROjBYA_003D, Entity _0023_003Dzs_0024uS8LA_003D)
	{
		if (_0023_003Dzs_0024uS8LA_003D is BlockReference)
		{
			_0023_003Dz6TDrW2QTaT_0024P((BlockReference)_0023_003Dzs_0024uS8LA_003D, _0023_003DzaROjBYA_003D);
		}
	}

	private static void _0023_003Dz6TDrW2QTaT_0024P(BlockReference _0023_003Dz5I3b_GM_003D, string _0023_003DzaROjBYA_003D)
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, AttributeReference> attribute in _0023_003Dz5I3b_GM_003D.Attributes)
		{
			if (attribute.Value.LayerName == _0023_003DzaROjBYA_003D)
			{
				list.Add(attribute.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			_0023_003Dz5I3b_GM_003D.Attributes.Remove(list[i]);
		}
	}

	public void Translate(Vector3D dv)
	{
		foreach (Entity @base in baseList)
		{
			@base.Translate(dv.X, dv.Y, dv.Z);
		}
	}

	public void Translate(double dx, double dy, double dz = 0.0)
	{
		foreach (Entity @base in baseList)
		{
			@base.Translate(dx, dy, dz);
		}
	}

	public void Rotate(double angleInRadians, Vector3D axis)
	{
		foreach (Entity @base in baseList)
		{
			@base.Rotate(angleInRadians, axis, Point3D.Origin);
		}
	}

	public virtual void Rotate(double angleInRadians, Vector3D axis, Point3D center)
	{
		foreach (Entity @base in baseList)
		{
			@base.Rotate(angleInRadians, axis, center);
		}
	}

	public void Rotate(double angleInRadians, Point3D axisStart, Point3D axisEnd)
	{
		foreach (Entity @base in baseList)
		{
			@base.Rotate(angleInRadians, Vector3D.Subtract(axisEnd, axisStart), axisStart);
		}
	}

	public void Scale(Point3D fixedPoint, double factor)
	{
		foreach (Entity @base in baseList)
		{
			@base.Scale(fixedPoint, factor, factor, factor);
		}
	}

	public virtual void Scale(Point3D fixedPoint, double sx, double sy, double sz = 1.0)
	{
		foreach (Entity @base in baseList)
		{
			@base.Scale(fixedPoint, sx, sy, sz);
		}
	}

	public void Scale(double sx, double sy, double sz = 1.0)
	{
		foreach (Entity @base in baseList)
		{
			@base.Scale(Point3D.Origin, sx, sy, sz);
		}
	}

	public void Scale(double factor)
	{
		foreach (Entity @base in baseList)
		{
			@base.Scale(Point3D.Origin, factor, factor, factor);
		}
	}

	public void Scale(Vector3D sv)
	{
		foreach (Entity @base in baseList)
		{
			@base.Scale(Point3D.Origin, sv.X, sv.Y, sv.Z);
		}
	}

	public void ClearSelection()
	{
		SelectionChangedEventArgs e = new SelectionChangedEventArgs();
		foreach (Block block in base.Document.Blocks)
		{
			SelectionChangedEventArgs e2 = ClearSelectedItemInternal(block.Entities);
			e.AddedItems.AddRange(e2.AddedItems);
			e.RemovedItems.AddRange(e2.RemovedItems);
		}
		if (e.AddedItems.Count > 0 || e.RemovedItems.Count > 0)
		{
			_0023_003Dzo60vEkkaRGxX()?.FireSelectionChanged(e);
		}
	}

	internal static SelectionChangedEventArgs ClearSelectedItemInternal<T>(IList<T> _0023_003DzcrILBXg_003D) where T : ISelectableItem
	{
		List<SelectedItem> list = new List<SelectedItem>();
		for (int i = 0; i < _0023_003DzcrILBXg_003D.Count; i++)
		{
			T val = _0023_003DzcrILBXg_003D[i];
			if (val.Selected)
			{
				list.Add(new SelectedItem(null, val));
				val.Selected = false;
			}
			if (!(val is Entity entity))
			{
				continue;
			}
			if (entity.IsAnyInstanceSelected())
			{
				for (int j = 0; j < entity.InstanceSelectionInfo.Count; j++)
				{
					if (entity.InstanceSelectionInfo[j].SelectionInfo.Selected)
					{
						list.Add(new SelectedItem(entity.InstanceSelectionInfo[j].Parents, entity));
					}
				}
				entity.ClearSelectionForAllInstances();
			}
			if (entity is IFaceSelectable)
			{
				IFaceSelectable faceSelectable = (IFaceSelectable)entity;
				List<SelectionInfoSubItems> list2 = null;
				List<SelectionInfoSubItemsArray> list3 = null;
				if (faceSelectable is Mesh)
				{
					list2 = ((Mesh)faceSelectable).FacesSelectionInfo;
				}
				else if (faceSelectable is Brep)
				{
					list2 = ((Brep)faceSelectable).FacesSelectionInfo;
					list3 = ((Brep)faceSelectable).InnerFacesSelectionInfo;
				}
				else if (faceSelectable is Solid)
				{
					list2 = ((Solid)faceSelectable).FacesSelectionInfo;
				}
				if (list2 != null)
				{
					for (int k = 0; k < list2.Count; k++)
					{
						SelectionInfoSubItems selectionInfoSubItems = list2[k];
						for (int l = 0; l < selectionInfoSubItems.SubItems.Length; l++)
						{
							if (selectionInfoSubItems.SubItems[l].Selected)
							{
								list.Add(new SelectedFace(selectionInfoSubItems.Parents, entity, l));
							}
						}
					}
				}
				if (list3 != null)
				{
					for (int m = 0; m < list3.Count; m++)
					{
						SelectionInfoSubItemsArray selectionInfoSubItemsArray = list3[m];
						for (int n = 0; n < selectionInfoSubItemsArray.SubItems.GetLength(0); n++)
						{
							SelectionInfo[] array = selectionInfoSubItemsArray.SubItems[n];
							for (int num = 0; num < array.Length; num++)
							{
								if (array[num].Selected)
								{
									list.Add(new SelectedFace(selectionInfoSubItemsArray.Parents, entity, num)
									{
										ShellIndex = n + 1
									});
								}
							}
						}
					}
				}
				faceSelectable.ClearFacesSelectionForAllInstances();
				if (entity is Brep)
				{
					Brep brep = entity as Brep;
					if (brep.IsAnyEdgeSelected())
					{
						List<SelectionInfoSubItems> edgesSelectionInfo = brep.EdgesSelectionInfo;
						for (int num2 = 0; num2 < edgesSelectionInfo.Count; num2++)
						{
							SelectionInfoSubItems selectionInfoSubItems2 = edgesSelectionInfo[num2];
							for (int num3 = 0; num3 < selectionInfoSubItems2.SubItems.Length; num3++)
							{
								if (selectionInfoSubItems2.SubItems[num3].Selected)
								{
									list.Add(new SelectedEdge(selectionInfoSubItems2.Parents, entity, num3));
								}
							}
						}
						brep.ClearEdgesSelectionForAllInstances();
					}
					if (brep.IsAnyVertexSelected())
					{
						List<SelectionInfoSubItems> verticesSelectionInfo = brep.VerticesSelectionInfo;
						for (int num4 = 0; num4 < verticesSelectionInfo.Count; num4++)
						{
							SelectionInfoSubItems selectionInfoSubItems3 = verticesSelectionInfo[num4];
							for (int num5 = 0; num5 < selectionInfoSubItems3.SubItems.Length; num5++)
							{
								if (selectionInfoSubItems3.SubItems[num5].Selected)
								{
									list.Add(new SelectedVertex(selectionInfoSubItems3.Parents, entity, num5));
								}
							}
						}
						brep.ClearVerticesSelectionForAllInstances();
					}
				}
			}
			if (entity is ISelectableSubItems selectableSubItems)
			{
				selectableSubItems.SelectionMode = selectionFilterType.Entity;
			}
		}
		return new SelectionChangedEventArgs(null, list);
	}

	public void SelectAll()
	{
		List<SelectedItem> list = new List<SelectedItem>();
		for (int i = 0; i < baseList.Count; i++)
		{
			Entity entity = baseList[i];
			if (entity.IsSelectable(base.Document.Layers))
			{
				_0023_003Dz2d_0024ZIhioLmWX(entity);
				if (!entity.Selected)
				{
					entity.Selected = true;
					list.Add(new SelectedItem(entity));
				}
			}
		}
		if (list.Count > 0)
		{
			_0023_003Dzo60vEkkaRGxX()?.FireSelectionChanged(new SelectionChangedEventArgs(list, null));
		}
	}

	private static void _0023_003Dz2d_0024ZIhioLmWX(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		if (_0023_003Dzs_0024uS8LA_003D is IFaceSelectable)
		{
			((IFaceSelectable)_0023_003Dzs_0024uS8LA_003D).ClearFacesSelection();
			if (_0023_003Dzs_0024uS8LA_003D is Brep)
			{
				Brep obj = (Brep)_0023_003Dzs_0024uS8LA_003D;
				obj.ClearVerticesSelection(selectionStatusType.Permanent);
				obj.ClearEdgesSelection(selectionStatusType.Permanent);
				((ISelectableSubItems)_0023_003Dzs_0024uS8LA_003D).SelectionMode = selectionFilterType.Entity;
			}
		}
	}

	public void InvertSelection()
	{
		List<SelectedItem> list = new List<SelectedItem>(baseList.Count);
		List<SelectedItem> list2 = new List<SelectedItem>(baseList.Count);
		for (int i = 0; i < baseList.Count; i++)
		{
			Entity entity = baseList[i];
			if (entity.Selected)
			{
				list2.Add(new SelectedItem(entity));
				entity.Selected = false;
				_0023_003Dz2d_0024ZIhioLmWX(entity);
			}
			else if (entity.IsSelectable(base.Document.Layers))
			{
				list.Add(new SelectedItem(entity));
				entity.Selected = true;
				_0023_003Dz2d_0024ZIhioLmWX(entity);
			}
		}
		if (list.Count > 0 || list2.Count > 0)
		{
			_0023_003Dzo60vEkkaRGxX()?.FireSelectionChanged(new SelectionChangedEventArgs(list, list2));
		}
	}

	public void DeleteSelected()
	{
		_0023_003Dzo60vEkkaRGxX()?.ResetNeededConvexHull();
		for (int num = base.Count - 1; num >= 0; num--)
		{
			if (baseList[num].Selected)
			{
				RemoveAt(num);
			}
		}
	}

	public Dictionary<Type, int> GetStats()
	{
		int entitiesCount;
		int verticesCount;
		int trianglesCount;
		return GetStats(null, out entitiesCount, out verticesCount, out trianglesCount);
	}

	public Dictionary<Type, int> GetStats(BlockKeyedCollection blocks, out int entitiesCount, out int verticesCount, out int trianglesCount)
	{
		_entityTypes = Utility.GetEntitiesStats(this, blocks, out entitiesCount, out verticesCount, out trianglesCount);
		_statsEntityCount = entitiesCount;
		_statsVertexCount = verticesCount;
		_statsTriangleCount = trianglesCount;
		return _entityTypes;
	}

	public string GetStats(BlockKeyedCollection blocks, bool showTotals, bool showBlocksDetails = false)
	{
		return Utility.GetEntitiesStats(this, blocks, showTotals, showBlocksDetails);
	}

	public string GetStats(bool showTotals, bool showBlocksDetails = false, bool showCollectionsItems = false)
	{
		return Utility.GetEntitiesStats(this, base.Document?.Layers, base.Document?.Blocks, base.Document?.Materials, base.Document?.TextStyles, base.Document?.LineTypes, base.Document?.HatchPatterns, showTotals, showBlocksDetails, showCollectionsItems);
	}

	internal void InitializeGraphicsResources()
	{
		_0023_003DzAAz9i8ykGhX8XL_0024gHw_003D_003D(baseList, null);
	}

	private List<string> _0023_003DztIIn5EOx9OhQ()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		_0023_003DzXYJVVZUE8y67(this, dictionary);
		List<string> list = new List<string>();
		foreach (Block block in base.Document.Blocks)
		{
			if (!dictionary.ContainsKey(block.Name))
			{
				list.Add(block.Name);
			}
		}
		return list;
	}

	private void _0023_003DzXYJVVZUE8y67(EntityList _0023_003Dzv7xH9gk_003D, Dictionary<string, string> _0023_003Dz4h9wyBFRUaiU)
	{
		foreach (Entity item in _0023_003Dzv7xH9gk_003D)
		{
			if (item is BlockReference blockReference && !_0023_003Dz4h9wyBFRUaiU.ContainsKey(blockReference.BlockName))
			{
				_0023_003Dz4h9wyBFRUaiU.Add(blockReference.BlockName, null);
				_0023_003DzXYJVVZUE8y67(base.Document.Blocks[blockReference.BlockName].Entities, _0023_003Dz4h9wyBFRUaiU);
			}
		}
	}

	public Entity[] Explode(BlockReference br, bool resolveByParent = true, bool keepTessellation = false, bool burst = false)
	{
		if (base.Document == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984100));
		}
		return br.Explode(base.Document.Blocks, resolveByParent, keepTessellation, base.Document, burst);
	}

	public Entity[] Explode(bool keepTessellation = false, bool burst = false)
	{
		List<Entity> list = new List<Entity>(baseList.Count);
		_0023_003Dz2F8yUBptgcf9waOMZQ_003D_003D(baseList, list, keepTessellation, burst);
		Clear();
		return list.ToArray();
	}

	private void _0023_003Dz2F8yUBptgcf9waOMZQ_003D_003D(IList<Entity> _0023_003DzWc9WmS8VMsuA, IList<Entity> _0023_003DzAe1F9bR5b4VeMczcig_003D_003D, bool _0023_003Dzu9oxwJ_zKlMt, bool _0023_003DzRammOI8NOXga)
	{
		foreach (Entity item in _0023_003DzWc9WmS8VMsuA)
		{
			if (item is BlockReference)
			{
				Entity[] _0023_003DzWc9WmS8VMsuA2 = Explode((BlockReference)item, resolveByParent: true, _0023_003Dzu9oxwJ_zKlMt, _0023_003DzRammOI8NOXga);
				_0023_003Dz2F8yUBptgcf9waOMZQ_003D_003D(_0023_003DzWc9WmS8VMsuA2, _0023_003DzAe1F9bR5b4VeMczcig_003D_003D, _0023_003Dzu9oxwJ_zKlMt, _0023_003DzRammOI8NOXga);
			}
			else
			{
				_0023_003DzAe1F9bR5b4VeMczcig_003D_003D.Add(item);
			}
		}
	}

	public LinearPath[] ConvertToLinearPaths(Text text, double deviation)
	{
		if (_0023_003Dzo60vEkkaRGxX() == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984100));
		}
		return text.ConvertToLinearPaths(deviation, _0023_003Dzo60vEkkaRGxX());
	}

	public void ConvertToLinearPaths(Text text, double deviation, out LinearPath[] outers, out LinearPath[][] inners)
	{
		if (_0023_003Dzo60vEkkaRGxX() == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302984100));
		}
		text.ConvertToLinearPaths(deviation, _0023_003Dzo60vEkkaRGxX(), out outers, out inners);
	}

	public static void ReplaceBlockNames(Dictionary<string, string> blockNamesMapping, IList<Entity> entities, ref BlockKeyedCollection blocks)
	{
		ReplaceBlockNames<Block>(blockNamesMapping, entities, ref blocks);
	}

	public static void ReplaceBlockNames<T>(Dictionary<string, string> blockNamesMapping, IList<Entity> entities, ref BlockKeyedCollection blocks) where T : Block
	{
		AdjustBlockReferenceBlockNames(blockNamesMapping, entities);
		if (blocks == null)
		{
			return;
		}
		BlockKeyedCollection blockKeyedCollection = new BlockKeyedCollection();
		foreach (Block block in blocks)
		{
			if (blockNamesMapping.ContainsKey(block.Name))
			{
				block.Name = blockNamesMapping[block.Name];
			}
			blockKeyedCollection.Add(block);
			AdjustBlockReferenceBlockNames(blockNamesMapping, block.Entities);
		}
		blocks = blockKeyedCollection;
	}

	public static void AdjustBlockReferenceBlockNames(Dictionary<string, string> blockNamesMapping, IList<Entity> entities)
	{
		if (entities == null)
		{
			return;
		}
		foreach (Entity entity in entities)
		{
			if (entity is BlockReference)
			{
				BlockReference blockReference = (BlockReference)entity;
				if (blockNamesMapping.ContainsKey(blockReference.BlockName))
				{
					blockReference.BlockName = blockNamesMapping[blockReference.BlockName];
				}
			}
		}
	}

	[Obsolete("Use Document.SynchronizeAttributes() method instead.")]
	public void SynchronizeAttributes(string blockName)
	{
		base.Document.SynchronizeAttributes(blockName);
	}

	[Obsolete("Use Document.SynchronizeAttributes() method instead.")]
	public void SynchronizeAttributes(IList<BlockReference> blockReferences)
	{
		base.Document.SynchronizeAttributes(blockReferences);
	}

	public void WriteCSharp(string filePath)
	{
		Entity[] array = Explode();
		int num = 0;
		StreamWriter streamWriter = new StreamWriter(filePath);
		try
		{
			Entity[] array2 = array;
			foreach (Entity entity in array2)
			{
				if (entity is LinearPath linearPath)
				{
					linearPath.WriteCSharp(streamWriter, num++);
				}
				else if (entity is Curve curve)
				{
					curve.WriteCSharp(streamWriter, num++);
				}
			}
		}
		finally
		{
			((IDisposable)streamWriter).Dispose();
		}
	}

	[DebuggerHidden]
	private Task _0023_003DzsHOPLaXVRRYt(int _0023_003DzyzK8swU_003D, Entity _0023_003DzUBZd570_003D, RegenOptions _0023_003DzZcrk_0024oE_003D)
	{
		return base.InsertAsync(_0023_003DzyzK8swU_003D, _0023_003DzUBZd570_003D, _0023_003DzZcrk_0024oE_003D);
	}

	[DebuggerHidden]
	private void _0023_003Dz6o91qlpB3dZY(Entity _0023_003DzUBZd570_003D)
	{
		Add(_0023_003DzUBZd570_003D);
	}

	[DebuggerHidden]
	private void _0023_003Dz10xO6jmZZfus(IEnumerable<Entity> _0023_003DzcrILBXg_003D)
	{
		AddRange(_0023_003DzcrILBXg_003D);
	}
}
