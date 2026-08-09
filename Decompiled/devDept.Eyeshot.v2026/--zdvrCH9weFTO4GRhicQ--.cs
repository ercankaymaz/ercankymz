using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using devDept;
using devDept.Diagnostic;
using devDept.Eyeshot;

internal sealed class _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz4m4fgYVSFvqTF4c2xaCdawk_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public HttpResponseMessage _0023_003DzNKCdx0E_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<string> _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			object[] array = new object[1] { this };
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
			Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
			try
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DziDLVpbY_003D, "Xo/1uq\"ad[", array);
			}
			finally
			{
				this = (_0023_003Dz4m4fgYVSFvqTF4c2xaCdawk_003D)array[0];
			}
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

		private static void MoveNext(ref TaskAwaiter<string> P_0, ref _0023_003Dz4m4fgYVSFvqTF4c2xaCdawk_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}

		private static void MoveNext_1(ref TaskAwaiter<string> P_0, ref _0023_003Dz4m4fgYVSFvqTF4c2xaCdawk_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz607qp4vRmIzK9Ild4g_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<string> _0023_003DzpVK748zcYJ8u;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzFYvRpuzB_RuY;

		private void MoveNext()
		{
			object[] array = new object[1] { this };
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
			Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
			try
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DziDLVpbY_003D, "'`@t1q\"ad?", array);
			}
			finally
			{
				this = (_0023_003Dz607qp4vRmIzK9Ild4g_003D_003D)array[0];
			}
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

		private static void MoveNext(ref TaskAwaiter<string> P_0, ref _0023_003Dz607qp4vRmIzK9Ild4g_003D_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}

		private static void MoveNext_1(ref TaskAwaiter P_0, ref _0023_003Dz607qp4vRmIzK9Ild4g_003D_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzRQuQq_alNdwyQ5rqwYNO9ZA_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D2 = _0023_003DzopRx0_MBcTQs;
			try
			{
				ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D2._0023_003DzMcajpiz2q_0024J4(_0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003DzStoeVn2VpW0BM4IHHA_003D_003D).ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
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
					_0023_003DzpVK748zcYJ8u = default(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter);
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
	private struct _0023_003DzW99i8mjcIr3zI7i_0024mQ_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			object[] array = new object[1] { this };
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
			Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
			try
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DziDLVpbY_003D, "J,K<Gq\"adA", array);
			}
			finally
			{
				this = (_0023_003DzW99i8mjcIr3zI7i_0024mQ_003D_003D)array[0];
			}
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

		private static void MoveNext(ref TaskAwaiter P_0, ref _0023_003DzW99i8mjcIr3zI7i_0024mQ_003D_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzWyZMrivm6UKODGmxhw_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public TimeSpan _0023_003Dz2955ZiU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			object[] array = new object[1] { this };
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
			Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
			try
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DziDLVpbY_003D, "Gl@XAq\"aas", array);
			}
			finally
			{
				this = (_0023_003DzWyZMrivm6UKODGmxhw_003D_003D)array[0];
			}
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

		private static void MoveNext(ref TaskAwaiter P_0, ref _0023_003DzWyZMrivm6UKODGmxhw_003D_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzgYlaw4SP65pLODT96oSoWSY_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzB4Jecd3_0024sY1Ht5Gp1w_003D_003D _0023_003DzwY9ClXw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public TimeSpan _0023_003Dz2955ZiU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<HttpResponseMessage> _0023_003DzpVK748zcYJ8u;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzFYvRpuzB_RuY;

		private void MoveNext()
		{
			object[] array = new object[1] { this };
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
			Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
			try
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DziDLVpbY_003D, "h#76Pq\"aai", array);
			}
			finally
			{
				this = (_0023_003DzgYlaw4SP65pLODT96oSoWSY_003D)array[0];
			}
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

		private static void MoveNext(ref TaskAwaiter<HttpResponseMessage> P_0, ref _0023_003DzgYlaw4SP65pLODT96oSoWSY_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}

		private static void MoveNext_1(ref TaskAwaiter P_0, ref _0023_003DzgYlaw4SP65pLODT96oSoWSY_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dzmuai6OtfgvQkJ5_D57Lwkfo21DHU : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			_0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D2 = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D2._0023_003DzMcajpiz2q_0024J4(_0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003Dzz0Mvjc0_grWZ).GetAwaiter();
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
	private struct _0023_003DzuPuCAOwAD3YXOjUAIt7_0024yIo_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<HttpResponseMessage> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public object _0023_003DzPzO_0024GUk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public TimeSpan _0023_003Dz2955ZiU_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzyFrwTGo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private CancellationTokenSource _0023_003DzvqDoMPbFjzhSuhyWig_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<HttpResponseMessage> _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			object[] array = new object[1] { this };
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
			Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
			try
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DziDLVpbY_003D, "T)ATfq\"adF", array);
			}
			finally
			{
				this = (_0023_003DzuPuCAOwAD3YXOjUAIt7_0024yIo_003D)array[0];
			}
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

		private static void MoveNext(ref TaskAwaiter<HttpResponseMessage> P_0, ref _0023_003DzuPuCAOwAD3YXOjUAIt7_0024yIo_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzvvBd1NKaotcCbCmHMAS9xmI_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<(bool, string)> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			object[] array = new object[1] { this };
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
			Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
			try
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DziDLVpbY_003D, "DuBV7q\"ad:", array);
			}
			finally
			{
				this = (_0023_003DzvvBd1NKaotcCbCmHMAS9xmI_003D)array[0];
			}
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

		private static void MoveNext(ref TaskAwaiter P_0, ref _0023_003DzvvBd1NKaotcCbCmHMAS9xmI_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	internal _0023_003DzMKple5Nl3xAL1lAn4w_003D_003D _0023_003DzL3IiFd8_003D;

	internal _0023_003DzC0zhPw9QIi_0024mN1u_lR51_0024UOKfQIK _0023_003DzkA80KD6PorAu;

	internal _0023_003Dz_YFI2oFu8dE8oKN2_0024Q_003D_003D _0023_003DzFj4vJcs_003D;

	internal _0023_003DzF8Q6vodq_S1Tcb6EzbqNrqE_003D _0023_003Dz9hTiIif4vuWw;

	internal _0023_003DzPo1j9mwna32V8cwmxA_003D_003D _0023_003DzAiPLl4w_003D;

	private static readonly object _0023_003DzCR5A0nGy_BIL;

	private Timer _0023_003DzkXlmnO_cDtIy;

	private int _0023_003Dz8iYj2iqT3kfY = 1;

	private bool _0023_003DzKj3W1hruFCrkxgTmyQ_003D_003D;

	internal static double _0023_003Dzjyaz_Vfaky9X;

	internal static double _0023_003DzxhnLabVjXjPg;

	internal static double _0023_003DzheSR8QM7q9ya;

	internal static double _0023_003DzSNemwQo_003D;

	internal bool _0023_003DzOd03fkAka8Gw;

	internal _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D;

	internal static readonly IntPtr _0023_003DzjGfxH8bdpIan;

	private static readonly HttpClient _0023_003DzUUvZcjx_tyjE;

	internal _0023_003DzErN3qAnXEgfhBMq3zg_003D_003D _0023_003DznILHHJI_003D;

	internal bool _0023_003DzVsfGJKJPF4WZg9zSLw_003D_003D;

	internal DateTime? _0023_003Dz1VDDix4kmFUt;

	private bool _0023_003DzBSTyCC0tbHg5;

	private readonly object _0023_003DzBH8JpJIFptrT = new object();

	internal static readonly object _0023_003DzhN4I1qxmLXKQ;

	static _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		_0023_003DzCR5A0nGy_BIL = new object();
		_0023_003DzjGfxH8bdpIan = (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D() ? Process.GetCurrentProcess().Handle : IntPtr.Zero);
		_0023_003DzUUvZcjx_tyjE = new HttpClient
		{
			Timeout = _0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003Dzz0Mvjc0_grWZ
		};
		_0023_003DzhN4I1qxmLXKQ = new object();
		licenseType.None.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302968747));
		licenseType.Trial.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665213));
		licenseType.Fem.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665176));
		licenseType.Ultimate.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665154));
		licenseType.Pro.SetDisplayName(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665167));
	}

	public _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D()
	{
		Logger.Instance.WriteHeader();
		_0023_003DzI0sNHiP50DLiKv1mVw_003D_003D();
	}

	internal licenseType _0023_003DzMZ_0024XelK_0024SxLq()
	{
		if (_0023_003DzkA80KD6PorAu == _0023_003DzC0zhPw9QIi_0024mN1u_lR51_0024UOKfQIK.Runtime)
		{
			return licenseType.Fem;
		}
		return _0023_003DzZXc9y0yoQoevHOVpPw_003D_003D();
	}

	internal licenseType _0023_003DzZXc9y0yoQoevHOVpPw_003D_003D()
	{
		return _0023_003DzL3IiFd8_003D switch
		{
			(_0023_003DzMKple5Nl3xAL1lAn4w_003D_003D)1 => licenseType.Pro, 
			(_0023_003DzMKple5Nl3xAL1lAn4w_003D_003D)2 => licenseType.Ultimate, 
			(_0023_003DzMKple5Nl3xAL1lAn4w_003D_003D)3 => licenseType.Fem, 
			_ => licenseType.None, 
		};
	}

	[DllImport("kernel32.dll", EntryPoint = "CheckRemoteDebuggerPresent", ExactSpelling = true, SetLastError = true)]
	private protected static extern bool _0023_003Dzw3k1rs2fa8njP0nLLQ_003D_003D(IntPtr _0023_003Dz_0024V_0024IO70_003D, ref bool _0023_003DzWNyLoL7UU_AJ);

	private void _0023_003DzI0sNHiP50DLiKv1mVw_003D_003D()
	{
		if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D() && _0023_003DzkXlmnO_cDtIy == null)
		{
			_0023_003DzKj3W1hruFCrkxgTmyQ_003D_003D = true;
			_0023_003DzkXlmnO_cDtIy = new Timer(_0023_003DzcOSgvcclIqq0M3zDIg_003D_003D, null, 0, new Random().Next(3000, 30000));
		}
	}

	private void _0023_003DzKJPSsjBwBZQ9hScRxg_003D_003D()
	{
		if (_0023_003Dz8iYj2iqT3kfY++ < 3)
		{
			return;
		}
		lock (_0023_003DzCR5A0nGy_BIL)
		{
			if (_0023_003DzkXlmnO_cDtIy != null)
			{
				_0023_003DzkXlmnO_cDtIy.Dispose();
				_0023_003DzkXlmnO_cDtIy = null;
			}
		}
	}

	private void _0023_003DzcOSgvcclIqq0M3zDIg_003D_003D(object _0023_003DzDVQ8830_003D)
	{
		if (_0023_003DzKj3W1hruFCrkxgTmyQ_003D_003D)
		{
			_0023_003DzKj3W1hruFCrkxgTmyQ_003D_003D = false;
			return;
		}
		bool _0023_003DzWNyLoL7UU_AJ = false;
		_0023_003Dzw3k1rs2fa8njP0nLLQ_003D_003D(Process.GetCurrentProcess().Handle, ref _0023_003DzWNyLoL7UU_AJ);
		if (!Debugger.IsAttached && _0023_003DzWNyLoL7UU_AJ)
		{
			string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665124);
			LicenseManager._0023_003Dzkbdl2RNkTQTU(text, TraceLevel.Error, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
			throw new InvalidProgramException(text);
		}
		_0023_003DzKJPSsjBwBZQ9hScRxg_003D_003D();
	}

	internal static double _0023_003DzlJWrRIfhGoKn(string _0023_003DzPzO_0024GUk_003D)
	{
		return double.Parse(_0023_003DzPzO_0024GUk_003D, NumberStyles.Float, CultureInfo.InvariantCulture);
	}

	private static void _0023_003DzqcRQBaUgBLBN(IDictionary _0023_003Dz9lrNnXY_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dza3BieSHRZK7Z()))
		{
			_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664702), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dza3BieSHRZK7Z());
			_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664829), bool.FalseString);
		}
		else
		{
			_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664702), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzbGvrdyt7by7T());
			_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664829), bool.TrueString);
		}
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664813), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzicLNfd33jEjb());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664799), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dzlm7c5zkiTFZY().ToString());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664760), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzeTIsp4Ooi8lL() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzfbXOzDxH6Z_0024a());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664750), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dz4yWVTg1plnOc());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664735), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzpGG_0024Ipk_003D());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664715), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzFOoE2Be_Yg2w());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664959), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzWYJYcM4y_dd7());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664918), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dz3pCX6JkY44Lf());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664904), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzSkIfvE5iHtmEVbByYQ_003D_003D());
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664893), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzxqZyt2yBlJt7Y7E6kA_003D_003D());
		List<string> list = _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzoaVOmA4wI3ru();
		if (list != null)
		{
			_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664853), list.Count.ToString());
			for (int i = 0; i < list.Count; i++)
			{
				_ = list[i];
				_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664841), i), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dzzw_0024WpbQpVUwL()[i]);
				_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665576), i), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003Dzfpx0mEVA8L3N()[i]);
				_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665567), i), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzHpy4vdxlCEjF()[i]);
				_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665528), i), _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzTxhd_mFqONca()[i]);
			}
		}
		List<string[]> list2 = _0023_003DzG_qjOUV5KbpIFu9FX9yjVAs_003D._0023_003DzEtoW85hrfAy0();
		_0023_003Dz9lrNnXY_003D.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665492), list2.Count.ToString());
		for (int j = 0; j < list2.Count; j++)
		{
			_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665487), j), list2[j][0]);
			_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665698), j), list2[j][1]);
			_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665681), j), list2[j][2]);
			_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665673), j), list2[j][3]);
			_0023_003Dz9lrNnXY_003D.Add(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665634), j), list2[j][4]);
		}
	}

	internal double[] _0023_003DzZlI0LIdia4d3()
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { this };
		return (double[])_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "55kK\\q\"ab$", _0023_003DzAvn2b38_003D);
	}

	internal void _0023_003DzekDmzQY_003D()
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { this };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "1B%4Pq\"aco", _0023_003DzAvn2b38_003D);
	}

	[AsyncStateMachine(typeof(_0023_003DzWyZMrivm6UKODGmxhw_003D_003D))]
	internal Task _0023_003DzMcajpiz2q_0024J4(TimeSpan _0023_003Dz2955ZiU_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[2] { this, _0023_003Dz2955ZiU_003D };
		return (Task)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "5lL]^q\"aan", _0023_003DzAvn2b38_003D);
	}

	[AsyncStateMachine(typeof(_0023_003DzgYlaw4SP65pLODT96oSoWSY_003D))]
	private Task _0023_003DzgKh9KaiaQL7k(_0023_003DzB4Jecd3_0024sY1Ht5Gp1w_003D_003D _0023_003DzwY9ClXw_003D, TimeSpan _0023_003Dz2955ZiU_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[3] { this, _0023_003DzwY9ClXw_003D, _0023_003Dz2955ZiU_003D };
		return (Task)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "%fQD,q\"aap", _0023_003DzAvn2b38_003D);
	}

	[AsyncStateMachine(typeof(_0023_003Dz4m4fgYVSFvqTF4c2xaCdawk_003D))]
	private Task _0023_003Dz2y5_Fg6LPGol(HttpResponseMessage _0023_003DzNKCdx0E_003D, _0023_003DzB4Jecd3_0024sY1Ht5Gp1w_003D_003D _0023_003DzwY9ClXw_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[3] { this, _0023_003DzNKCdx0E_003D, _0023_003DzwY9ClXw_003D };
		return (Task)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "o)/Leq\"ada", _0023_003DzAvn2b38_003D);
	}

	[AsyncStateMachine(typeof(_0023_003DzuPuCAOwAD3YXOjUAIt7_0024yIo_003D))]
	internal Task<HttpResponseMessage> _0023_003DzsOVX16AYJFuX(string _0023_003DzyFrwTGo_003D, object _0023_003DzPzO_0024GUk_003D, TimeSpan _0023_003Dz2955ZiU_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[4] { this, _0023_003DzyFrwTGo_003D, _0023_003DzPzO_0024GUk_003D, _0023_003Dz2955ZiU_003D };
		return (Task<HttpResponseMessage>)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), ">l=U$q\"adM", _0023_003DzAvn2b38_003D);
	}

	[AsyncStateMachine(typeof(_0023_003Dz607qp4vRmIzK9Ild4g_003D_003D))]
	internal Task _0023_003DzmKBNpMk_003D()
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { this };
		return (Task)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "o)/Leq\"adI", _0023_003DzAvn2b38_003D);
	}

	[AsyncStateMachine(typeof(_0023_003DzW99i8mjcIr3zI7i_0024mQ_003D_003D))]
	internal Task _0023_003DzGE1bEKg_003D()
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { this };
		return (Task)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "If03Fq\"adB", _0023_003DzAvn2b38_003D);
	}

	[AsyncStateMachine(typeof(_0023_003DzvvBd1NKaotcCbCmHMAS9xmI_003D))]
	internal Task<(bool isActivated, string serverMessage)> _0023_003DziEichs0YFfWA()
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { this };
		return (Task<(bool, string)>)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "XSi(tq\"ad;", _0023_003DzAvn2b38_003D);
	}

	internal void _0023_003DzMWui6vpkYA_q()
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { this };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "oDS[gq\"acb", _0023_003DzAvn2b38_003D);
	}

	internal void _0023_003DzIAQgbGwrH0Tf()
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { this };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "T`+liq\"ab.", _0023_003DzAvn2b38_003D);
	}

	internal bool _0023_003DzGvwLaHyYAeYU(bool _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D, out bool _0023_003DzXIeyF7xwEI7t)
	{
		object[] array = new object[3] { this, _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D, _0023_003DzXIeyF7xwEI7t };
		_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
		Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
		try
		{
			return (bool)_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DziDLVpbY_003D, ",Q7WAq\"acZ", array);
		}
		finally
		{
			_0023_003DzXIeyF7xwEI7t = (bool)array[2];
		}
	}

	private async Task _0023_003DzFh1TdrhM747O3t_q7aglNEk_003D()
	{
		await _0023_003DzMcajpiz2q_0024J4(_0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003DzStoeVn2VpW0BM4IHHA_003D_003D).ConfigureAwait(continueOnCapturedContext: false);
	}

	internal async Task _0023_003Dzpbq2r4kkm9aFl_0024rtZ1AJVAY_003D()
	{
		await _0023_003DzMcajpiz2q_0024J4(_0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003Dzz0Mvjc0_grWZ);
	}

	private static void _0023_003DzMcajpiz2q_0024J4_1(ref _0023_003DzWyZMrivm6UKODGmxhw_003D_003D P_0)
	{
		P_0._0023_003DzCodHnSRJkAEg.Start(ref P_0);
	}

	private static void _0023_003DzgKh9KaiaQL7k(ref _0023_003DzgYlaw4SP65pLODT96oSoWSY_003D P_0)
	{
		P_0._0023_003DzCodHnSRJkAEg.Start(ref P_0);
	}

	private static void _0023_003Dz2y5_Fg6LPGol(ref _0023_003Dz4m4fgYVSFvqTF4c2xaCdawk_003D P_0)
	{
		P_0._0023_003DzCodHnSRJkAEg.Start(ref P_0);
	}

	private static void _0023_003DzsOVX16AYJFuX(ref _0023_003DzuPuCAOwAD3YXOjUAIt7_0024yIo_003D P_0)
	{
		P_0._0023_003DzCodHnSRJkAEg.Start(ref P_0);
	}

	private static void _0023_003DzmKBNpMk_003D(ref _0023_003Dz607qp4vRmIzK9Ild4g_003D_003D P_0)
	{
		P_0._0023_003DzCodHnSRJkAEg.Start(ref P_0);
	}

	private static void _0023_003DzGE1bEKg_003D(ref _0023_003DzW99i8mjcIr3zI7i_0024mQ_003D_003D P_0)
	{
		P_0._0023_003DzCodHnSRJkAEg.Start(ref P_0);
	}

	private static void _0023_003DziEichs0YFfWA(ref _0023_003DzvvBd1NKaotcCbCmHMAS9xmI_003D P_0)
	{
		P_0._0023_003DzCodHnSRJkAEg.Start(ref P_0);
	}
}
