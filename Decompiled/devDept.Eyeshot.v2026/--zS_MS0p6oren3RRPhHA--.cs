using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using devDept;

internal sealed class _0023_003DzS_MS0p6oren3RRPhHA_003D_003D
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzS4F0Xe3VcCGuj5tT1w_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<string> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DzlHxgwRmDaU4q;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003DzS_MS0p6oren3RRPhHA_003D_003D _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003Dzny7GUCU_0024OJ7E;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _0023_003Dz1m5K8g91api9A0sGLA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private HttpListener _0023_003DzsV_ts2JJ36OHOFftHA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private Task<HttpListenerContext> _0023_003DzpzZlLq3Kst9inAvXXg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<Task> _0023_003DzpVK748zcYJ8u;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<HttpListenerContext> _0023_003DzFYvRpuzB_RuY;

		private void MoveNext()
		{
			object[] array = new object[1] { this };
			_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D _0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2 = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D();
			Stream _0023_003DziDLVpbY_003D = _0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D();
			try
			{
				_0023_003Dq6RsKbEvjyFgbikPCxI_0024iySfRGb_00247pE9aJ62ClYf_Igw_003D2._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DziDLVpbY_003D, ">5eI#q\"ab<", array);
			}
			finally
			{
				this = (_0023_003DzS4F0Xe3VcCGuj5tT1w_003D_003D)array[0];
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

		private static void MoveNext(ref TaskAwaiter<Task> P_0, ref _0023_003DzS4F0Xe3VcCGuj5tT1w_003D_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}

		private static void MoveNext_1(ref TaskAwaiter<HttpListenerContext> P_0, ref _0023_003DzS4F0Xe3VcCGuj5tT1w_003D_003D P_1)
		{
			P_1._0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref P_0, ref P_1);
		}
	}

	private readonly int _0023_003DzzoWCnrs_003D;

	public _0023_003DzS_MS0p6oren3RRPhHA_003D_003D()
	{
		_0023_003DzzoWCnrs_003D = _0023_003Dz_00247ZqDwanLUi4();
	}

	private int _0023_003Dz_00247ZqDwanLUi4()
	{
		TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 0);
		try
		{
			tcpListener.Start();
			return ((IPEndPoint)tcpListener.LocalEndpoint).Port;
		}
		catch (SocketException _0023_003DzSQYc_0024aE_003D)
		{
			LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673001), TraceLevel.Error, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302664317));
		}
		finally
		{
			tcpListener.Stop();
		}
	}

	[AsyncStateMachine(typeof(_0023_003DzS4F0Xe3VcCGuj5tT1w_003D_003D))]
	internal Task<string> _0023_003DzmiaGsYKeVOnT(string _0023_003DzlHxgwRmDaU4q, string _0023_003Dzny7GUCU_0024OJ7E)
	{
		object[] _0023_003DzAvn2b38_003D = new object[3] { this, _0023_003DzlHxgwRmDaU4q, _0023_003Dzny7GUCU_0024OJ7E };
		return (Task<string>)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "df'1Fq\"abL", _0023_003DzAvn2b38_003D);
	}

	internal static void _0023_003DznDrcGthfk_0024Ka(string _0023_003DzyFrwTGo_003D)
	{
		try
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = _0023_003DzyFrwTGo_003D,
				UseShellExecute = true
			});
		}
		catch
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				_0023_003DzyFrwTGo_003D = _0023_003DzyFrwTGo_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302909451), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673104));
				Process.Start(new ProcessStartInfo(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673079), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673057) + _0023_003DzyFrwTGo_003D)
				{
					CreateNoWindow = true
				});
				return;
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				Process.Start(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673041), _0023_003DzyFrwTGo_003D);
				return;
			}
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				Process.Start(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673026), _0023_003DzyFrwTGo_003D);
				return;
			}
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302673035));
		}
	}

	private static void _0023_003DzmiaGsYKeVOnT(ref _0023_003DzS4F0Xe3VcCGuj5tT1w_003D_003D P_0)
	{
		P_0._0023_003DzCodHnSRJkAEg.Start(ref P_0);
	}
}
