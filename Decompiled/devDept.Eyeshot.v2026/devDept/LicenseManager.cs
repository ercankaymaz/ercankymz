using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Win32;
using devDept.Diagnostic;
using devDept.Eyeshot;

namespace devDept;

internal sealed class LicenseManager
{
	[Serializable]
	private sealed class _0023_003Dz2IEmqow_003D
	{
		[StructLayout(LayoutKind.Auto)]
		private struct _0023_003DzBXYInXl0lhbWZBujk6S7I74_003D : IAsyncStateMachine
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public int _0023_003DzU7pGb3X7Zp4G;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public AsyncTaskMethodBuilder<(bool, string)> _0023_003DzCodHnSRJkAEg;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private ConfiguredTaskAwaitable<(bool, string)>.ConfiguredTaskAwaiter _0023_003DzpVK748zcYJ8u;

			private void MoveNext()
			{
				int num = _0023_003DzU7pGb3X7Zp4G;
				(bool, string) result;
				try
				{
					ConfiguredTaskAwaitable<(bool, string)>.ConfiguredTaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _0023_003DziEichs0YFfWA().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
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
						_0023_003DzpVK748zcYJ8u = default(ConfiguredTaskAwaitable<(bool, string)>.ConfiguredTaskAwaiter);
						num = (_0023_003DzU7pGb3X7Zp4G = -1);
					}
					result = awaiter.GetResult();
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
		private struct _0023_003DzMmKRqC0sXSNwpPLVudBq14M_003D : IAsyncStateMachine
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public int _0023_003DzU7pGb3X7Zp4G;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _0023_003DzpVK748zcYJ8u;

			private void MoveNext()
			{
				int num = _0023_003DzU7pGb3X7Zp4G;
				try
				{
					ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _0023_003DzmKBNpMk_003D().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
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
		private struct _0023_003DzdzeoCGLgj8lDko_RzjHGkLQ_003D : IAsyncStateMachine
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public int _0023_003DzU7pGb3X7Zp4G;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _0023_003DzpVK748zcYJ8u;

			private void MoveNext()
			{
				int num = _0023_003DzU7pGb3X7Zp4G;
				try
				{
					ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
					if (num != 0)
					{
						awaiter = _0023_003DzGE1bEKg_003D().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter();
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

		public static readonly _0023_003Dz2IEmqow_003D _0023_003DzJ5g3Rwo_003D = new _0023_003Dz2IEmqow_003D();

		public static Func<Task> _0023_003Dz7_WZ05dEvqdpEzItLA_003D_003D;

		public static Func<Task> _0023_003DzsHxObK1zwNUE7tDdHg_003D_003D;

		public static Func<Task<(bool, string)>> _0023_003DzW6VNWCUPEKb1Yg8DZQ_003D_003D;

		public static Action _0023_003Dz4BExgZY4uHZhaB5wjQ_003D_003D;

		internal async Task _0023_003DztY_0024f2dEDEC5Zd_0024QOKg_003D_003D()
		{
			await _0023_003DzmKBNpMk_003D().ConfigureAwait(continueOnCapturedContext: false);
		}

		internal async Task _0023_003DzeOyJMWnXe_xedK_eAA_003D_003D()
		{
			await _0023_003DzGE1bEKg_003D().ConfigureAwait(continueOnCapturedContext: false);
		}

		internal async Task<(bool isActivated, string serverMessage)> _0023_003Dz1GANwOsSAuH5S3QZFV7lCIE_003D()
		{
			return await _0023_003DziEichs0YFfWA().ConfigureAwait(continueOnCapturedContext: false);
		}

		internal void _0023_003Dz2Nog_0024Kmjfa2KqVGIgcLQ1pI_003D()
		{
			Telemetry.Instance._0023_003Dz_0024Jquo8Y_003D(_0023_003DzVxSaKTNQNphX()._0023_003DzkhmDvZM_003D);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz5kQbmRqx_0024jX7SBWlYg_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<(bool, string)> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<(bool, string)> _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			(bool, string) result;
			try
			{
				TaskAwaiter<(bool, string)> awaiter;
				if (num != 0)
				{
					_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Authentication;
					string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D = null;
					string _0023_003DzaCgY2eQ_003D = null;
					string text = null;
					if (_0023_003DzVxSaKTNQNphX() == null)
					{
						_0023_003DzUcMv_pQ_003D(typeof(LicenseManager), out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out _0023_003DzaCgY2eQ_003D, _0023_003Dzwan3TY08r56P: false, _0023_003DzCBmgGLZOgR_0024E: false).ToLower();
						if (_0023_003DzkhmDvZM_003D == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.None)
						{
							if (System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Designtime)
							{
								_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
							}
							else if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzIbv67eg_003D())
							{
								_0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666136), TraceLevel.Info, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
							}
							else
							{
								text = Process.GetCurrentProcess().ProcessName.ToLower();
								if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665849) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665832) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665813) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665805) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665792))
								{
									_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
								}
							}
						}
						_0023_003DzpMYJlxyDQnGm(new _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D
						{
							_0023_003DzkhmDvZM_003D = _0023_003DzkhmDvZM_003D
						});
						_0023_003Dzud1xmejJhJld(_0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D);
						_0023_003DzbwtizZU_003D(_0023_003DzaCgY2eQ_003D);
					}
					awaiter = _0023_003DzVxSaKTNQNphX()._0023_003DziEichs0YFfWA().GetAwaiter();
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
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter<(bool, string)>);
					num = (_0023_003DzU7pGb3X7Zp4G = -1);
				}
				result = awaiter.GetResult();
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
	private struct _0023_003Dze97u4F_0024pRiIuoCJpWA_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Authentication;
					string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D = null;
					string _0023_003DzaCgY2eQ_003D = null;
					string text = null;
					if (_0023_003DzVxSaKTNQNphX() == null)
					{
						_0023_003DzUcMv_pQ_003D(typeof(LicenseManager), out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out _0023_003DzaCgY2eQ_003D, _0023_003Dzwan3TY08r56P: false, _0023_003DzCBmgGLZOgR_0024E: false).ToLower();
						if (_0023_003DzkhmDvZM_003D == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.None)
						{
							if (System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Designtime)
							{
								_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
							}
							else if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzIbv67eg_003D())
							{
								_0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666136), TraceLevel.Info, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
							}
							else
							{
								text = Process.GetCurrentProcess().ProcessName.ToLower();
								if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665849) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665832) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665813) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665805) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665792))
								{
									_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
								}
							}
						}
						_0023_003DzpMYJlxyDQnGm(new _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D
						{
							_0023_003DzkhmDvZM_003D = _0023_003DzkhmDvZM_003D
						});
						_0023_003Dzud1xmejJhJld(_0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D);
						_0023_003DzbwtizZU_003D(_0023_003DzaCgY2eQ_003D);
					}
					awaiter = _0023_003DzVxSaKTNQNphX()._0023_003DzmKBNpMk_003D().GetAwaiter();
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
	private struct _0023_003Dzpc1nk8zqiEdUNRGiSw_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Authentication;
					string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D = null;
					string _0023_003DzaCgY2eQ_003D = null;
					string text = null;
					if (_0023_003DzVxSaKTNQNphX() == null)
					{
						_0023_003DzUcMv_pQ_003D(typeof(LicenseManager), out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out _0023_003DzaCgY2eQ_003D, _0023_003Dzwan3TY08r56P: false, _0023_003DzCBmgGLZOgR_0024E: false).ToLower();
						if (_0023_003DzkhmDvZM_003D == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.None)
						{
							if (System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Designtime)
							{
								_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
							}
							else if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzIbv67eg_003D())
							{
								_0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666136), TraceLevel.Info, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
							}
							else
							{
								text = Process.GetCurrentProcess().ProcessName.ToLower();
								if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665849) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665832) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665813) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665805) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665792))
								{
									_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
								}
							}
						}
						_0023_003DzpMYJlxyDQnGm(new _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D
						{
							_0023_003DzkhmDvZM_003D = _0023_003DzkhmDvZM_003D
						});
						_0023_003Dzud1xmejJhJld(_0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D);
						_0023_003DzbwtizZU_003D(_0023_003DzaCgY2eQ_003D);
					}
					awaiter = _0023_003DzVxSaKTNQNphX()._0023_003DzGE1bEKg_003D().GetAwaiter();
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

	private static _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzngrH5h16gEEJvveW8g_003D_003D;

	private static string _0023_003DzE0yJOJsjeuQxaxxlYg_003D_003D;

	private static string _0023_003Dza4TlrqIxuUenhNLouA_003D_003D;

	private static bool? _0023_003DznkrBaUYweoQ2;

	private static string _0023_003DzAqIm2xOSUef9;

	private static string _0023_003DzPefBHAf0rB2AxeO8GA_003D_003D;

	public static licenseType ProductEdition => _0023_003DzVxSaKTNQNphX()?._0023_003DzMZ_0024XelK_0024SxLq() ?? licenseType.None;

	public static int DaysRemaining
	{
		get
		{
			if (!_0023_003DzfD133uGomGH9().HasValue)
			{
				return 0;
			}
			return (_0023_003DzfD133uGomGH9().Value - DateTime.UtcNow).Days;
		}
	}

	public static bool IsOffline
	{
		get
		{
			_0023_003DzdvrCH9weFTO4GRhicQ_003D_003D obj = _0023_003DzVxSaKTNQNphX();
			if (obj == null)
			{
				return false;
			}
			return obj._0023_003DzFj4vJcs_003D == (_0023_003Dz_YFI2oFu8dE8oKN2_0024Q_003D_003D)10;
		}
	}

	internal static _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzVxSaKTNQNphX()
	{
		return _0023_003DzngrH5h16gEEJvveW8g_003D_003D;
	}

	internal static void _0023_003DzpMYJlxyDQnGm(_0023_003DzdvrCH9weFTO4GRhicQ_003D_003D _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzngrH5h16gEEJvveW8g_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public static async Task _0023_003DzmKBNpMk_003D()
	{
		_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Authentication;
		string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D = null;
		string _0023_003DzaCgY2eQ_003D = null;
		if (_0023_003DzVxSaKTNQNphX() == null)
		{
			_0023_003DzUcMv_pQ_003D(typeof(LicenseManager), out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out _0023_003DzaCgY2eQ_003D, _0023_003Dzwan3TY08r56P: false, _0023_003DzCBmgGLZOgR_0024E: false).ToLower();
			if (_0023_003DzkhmDvZM_003D == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.None)
			{
				if (System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Designtime)
				{
					_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
				}
				else if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzIbv67eg_003D())
				{
					_0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666136), TraceLevel.Info, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
				}
				else
				{
					string text = Process.GetCurrentProcess().ProcessName.ToLower();
					if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665849) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665832) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665813) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665805) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665792))
					{
						_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
					}
				}
			}
			_0023_003DzpMYJlxyDQnGm(new _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D
			{
				_0023_003DzkhmDvZM_003D = _0023_003DzkhmDvZM_003D
			});
			_0023_003Dzud1xmejJhJld(_0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D);
			_0023_003DzbwtizZU_003D(_0023_003DzaCgY2eQ_003D);
		}
		await _0023_003DzVxSaKTNQNphX()._0023_003DzmKBNpMk_003D();
	}

	public static void _0023_003DzCC7U_bA_003D()
	{
		Task.Run(async delegate
		{
			await _0023_003DzmKBNpMk_003D().ConfigureAwait(continueOnCapturedContext: false);
		}).GetAwaiter().GetResult();
	}

	public static async Task _0023_003DzGE1bEKg_003D()
	{
		_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Authentication;
		string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D = null;
		string _0023_003DzaCgY2eQ_003D = null;
		if (_0023_003DzVxSaKTNQNphX() == null)
		{
			_0023_003DzUcMv_pQ_003D(typeof(LicenseManager), out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out _0023_003DzaCgY2eQ_003D, _0023_003Dzwan3TY08r56P: false, _0023_003DzCBmgGLZOgR_0024E: false).ToLower();
			if (_0023_003DzkhmDvZM_003D == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.None)
			{
				if (System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Designtime)
				{
					_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
				}
				else if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzIbv67eg_003D())
				{
					_0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666136), TraceLevel.Info, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
				}
				else
				{
					string text = Process.GetCurrentProcess().ProcessName.ToLower();
					if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665849) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665832) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665813) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665805) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665792))
					{
						_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
					}
				}
			}
			_0023_003DzpMYJlxyDQnGm(new _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D
			{
				_0023_003DzkhmDvZM_003D = _0023_003DzkhmDvZM_003D
			});
			_0023_003Dzud1xmejJhJld(_0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D);
			_0023_003DzbwtizZU_003D(_0023_003DzaCgY2eQ_003D);
		}
		await _0023_003DzVxSaKTNQNphX()._0023_003DzGE1bEKg_003D();
	}

	public static void _0023_003DzgRTma9c_003D()
	{
		Task.Run((Func<Task>)_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003DzeOyJMWnXe_xedK_eAA_003D_003D).GetAwaiter().GetResult();
	}

	public static async Task<(bool isActivated, string serverMessage)> _0023_003DziEichs0YFfWA()
	{
		_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Authentication;
		string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D = null;
		string _0023_003DzaCgY2eQ_003D = null;
		if (_0023_003DzVxSaKTNQNphX() == null)
		{
			_0023_003DzUcMv_pQ_003D(typeof(LicenseManager), out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out _0023_003DzaCgY2eQ_003D, _0023_003Dzwan3TY08r56P: false, _0023_003DzCBmgGLZOgR_0024E: false).ToLower();
			if (_0023_003DzkhmDvZM_003D == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.None)
			{
				if (System.ComponentModel.LicenseManager.UsageMode == LicenseUsageMode.Designtime)
				{
					_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
				}
				else if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzIbv67eg_003D())
				{
					_0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666136), TraceLevel.Info, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
				}
				else
				{
					string text = Process.GetCurrentProcess().ProcessName.ToLower();
					if (text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665849) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665832) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665813) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665805) || text == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665792))
					{
						_0023_003DzkhmDvZM_003D = _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer;
					}
				}
			}
			_0023_003DzpMYJlxyDQnGm(new _0023_003DzdvrCH9weFTO4GRhicQ_003D_003D
			{
				_0023_003DzkhmDvZM_003D = _0023_003DzkhmDvZM_003D
			});
			_0023_003Dzud1xmejJhJld(_0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D);
			_0023_003DzbwtizZU_003D(_0023_003DzaCgY2eQ_003D);
		}
		return await _0023_003DzVxSaKTNQNphX()._0023_003DziEichs0YFfWA();
	}

	public static (bool, string) _0023_003DzE4jFhW3Gku71()
	{
		return Task.Run((Func<Task<(bool, string)>>)_0023_003Dz2IEmqow_003D._0023_003DzJ5g3Rwo_003D._0023_003Dz1GANwOsSAuH5S3QZFV7lCIE_003D).GetAwaiter().GetResult();
	}

	public static void _0023_003DznDrcGthfk_0024Ka(string _0023_003DzyFrwTGo_003D)
	{
		_0023_003DzS_MS0p6oren3RRPhHA_003D_003D._0023_003DznDrcGthfk_0024Ka(_0023_003DzyFrwTGo_003D);
	}

	public static licenseType _0023_003DzO1Dt4ukskLfKcQWvZQ_003D_003D()
	{
		return _0023_003DzVxSaKTNQNphX()._0023_003DzZXc9y0yoQoevHOVpPw_003D_003D();
	}

	public static string _0023_003Dzh2dF7srRj2h7()
	{
		return _0023_003DzE0yJOJsjeuQxaxxlYg_003D_003D;
	}

	internal static void _0023_003Dzud1xmejJhJld(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzE0yJOJsjeuQxaxxlYg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public static string _0023_003Dz1h4NLAk_003D()
	{
		return _0023_003Dza4TlrqIxuUenhNLouA_003D_003D;
	}

	internal static void _0023_003DzbwtizZU_003D(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dza4TlrqIxuUenhNLouA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public static string _0023_003DztPVfjKTJPyK7()
	{
		return _0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?.Email ?? string.Empty;
	}

	public static DateTime? _0023_003DzfD133uGomGH9()
	{
		return _0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?._0023_003DzmOU4Px8vJxCmtlyQVw_003D_003D();
	}

	public static bool _0023_003DzekFDoIdJ70Wo()
	{
		if (_0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?.Status >= 1)
		{
			return _0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?.Status <= 3;
		}
		return false;
	}

	public static bool _0023_003Dz_Sld2XDuI_y7()
	{
		_0023_003DzdvrCH9weFTO4GRhicQ_003D_003D obj = _0023_003DzVxSaKTNQNphX();
		if (obj == null)
		{
			return false;
		}
		return obj._0023_003DzFj4vJcs_003D == (_0023_003Dz_YFI2oFu8dE8oKN2_0024Q_003D_003D)11;
	}

	public static string _0023_003DzKb6QnffM6mqM()
	{
		return _0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?.FirstName ?? string.Empty;
	}

	public static string _0023_003DzNHMdIeGyOzrX()
	{
		return _0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?.LastName ?? string.Empty;
	}

	public static string _0023_003Dzq45qZS14ssL8()
	{
		return _0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?.LicenseId ?? string.Empty;
	}

	public static bool _0023_003DzzNbvrWDaK3moiMwOdw_003D_003D()
	{
		return _0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?.ShowRemainingDays ?? true;
	}

	public static string _0023_003DzXiQBsZ8rzabe()
	{
		return _0023_003DzVxSaKTNQNphX()?._0023_003DznILHHJI_003D?.VerboseMessage ?? string.Empty;
	}

	private static void _0023_003DzIAQgbGwrH0Tf(_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[1] { _0023_003DzkhmDvZM_003D };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "9`=tjq\"ac.", _0023_003DzAvn2b38_003D);
	}

	internal static bool _0023_003DzNa5CwX6M2NAt()
	{
		if (!_0023_003DznkrBaUYweoQ2.HasValue)
		{
			_0023_003DznkrBaUYweoQ2 = false;
			if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D())
			{
				try
				{
					_0023_003Dzy8KkNKUUS9tsKDvUuw_003D_003D(RegistryHive.LocalMachine);
					if (_0023_003DznkrBaUYweoQ2 == false)
					{
						_0023_003Dzy8KkNKUUS9tsKDvUuw_003D_003D(RegistryHive.CurrentUser);
					}
				}
				catch
				{
				}
			}
			if (_0023_003DznkrBaUYweoQ2 == false)
			{
				string value = ConfigurationManager.AppSettings[_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665772)];
				bool result = default(bool);
				if (!string.IsNullOrEmpty(value) && bool.TryParse(value, out result) && result)
				{
					_0023_003DznkrBaUYweoQ2 = true;
					Logger.Instance.TraceSwitch.Level = TraceLevel.Verbose;
				}
			}
		}
		return _0023_003DznkrBaUYweoQ2.Value;
	}

	private static void _0023_003Dzy8KkNKUUS9tsKDvUuw_003D_003D(RegistryHive _0023_003DzsyJLfXn0mVGW)
	{
		try
		{
			using RegistryKey registryKey = RegistryKey.OpenBaseKey(_0023_003DzsyJLfXn0mVGW, RegistryView.Registry64);
			using RegistryKey registryKey2 = registryKey.OpenSubKey(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302943583), writable: false);
			if (registryKey2 != null)
			{
				if (Convert.ToInt32(registryKey2.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665736), -1)) > 0)
				{
					_0023_003DznkrBaUYweoQ2 = true;
				}
				else
				{
					_0023_003DznkrBaUYweoQ2 = false;
				}
			}
			else
			{
				_0023_003DznkrBaUYweoQ2 = false;
			}
		}
		catch
		{
			_0023_003DznkrBaUYweoQ2 = false;
		}
	}

	internal static void _0023_003Dzkbdl2RNkTQTU(string _0023_003DzuahRn9M_003D, TraceLevel _0023_003DzLC4gNyPZPfnJ, Exception _0023_003DzSQYc_0024aE_003D, bool _0023_003DzHmsOmLY94V0f, object[] _0023_003Dz53Cncpw_003D)
	{
		if (_0023_003DzNa5CwX6M2NAt())
		{
			switch (_0023_003DzLC4gNyPZPfnJ)
			{
			case TraceLevel.Error:
				Logger.Instance.Error(_0023_003DzuahRn9M_003D, _0023_003DzSQYc_0024aE_003D, _0023_003Dz53Cncpw_003D);
				break;
			case TraceLevel.Warning:
				Logger.Instance.Warn(_0023_003DzuahRn9M_003D, _0023_003DzSQYc_0024aE_003D, _0023_003Dz53Cncpw_003D);
				break;
			case TraceLevel.Info:
				Logger.Instance.Info(_0023_003DzuahRn9M_003D, _0023_003Dz53Cncpw_003D);
				break;
			case TraceLevel.Verbose:
				Logger.Instance.Trace(_0023_003DzuahRn9M_003D, _0023_003Dz53Cncpw_003D);
				break;
			}
			if (_0023_003DzHmsOmLY94V0f)
			{
				Logger.Instance._0023_003DzFiehT2bxdiSS();
			}
		}
	}

	[AmbientValue(true)]
	private static double[] _0023_003DzZlI0LIdia4d3(byte _0023_003DzjbqS1qE_003D)
	{
		return _0023_003DzVxSaKTNQNphX()?._0023_003DzZlI0LIdia4d3();
	}

	[AmbientValue(true)]
	private static bool[] _0023_003DzcGWjzoM_003D(bool _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D, byte _0023_003Dz1v6oPQk_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[2] { _0023_003Dzrw5fbKX8_lARm8VJvQ_003D_003D, _0023_003Dz1v6oPQk_003D };
		return (bool[])_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "Yl4S$q\"ac!", _0023_003DzAvn2b38_003D);
	}

	[AmbientValue(true)]
	private static bool[] _0023_003Dz5iI0kEzvBIvT(byte _0023_003DzjbqS1qE_003D, byte _0023_003Dz1v6oPQk_003D, byte _0023_003Dzt_m8zV0_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[3] { _0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D, _0023_003Dzt_m8zV0_003D };
		return (bool[])_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "j8JuWq\"abh", _0023_003DzAvn2b38_003D);
	}

	[AmbientValue(true)]
	private static bool[] _0023_003DzNBspI_0024Adzqkt(byte _0023_003DzjbqS1qE_003D, byte _0023_003DzRpXgovo_003D, byte _0023_003Dz5rQzobg_003D, byte _0023_003Dz1v6oPQk_003D, byte _0023_003Dz77g161c_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[5] { _0023_003DzjbqS1qE_003D, _0023_003DzRpXgovo_003D, _0023_003Dz5rQzobg_003D, _0023_003Dz1v6oPQk_003D, _0023_003Dz77g161c_003D };
		return (bool[])_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "T)JZgq\"abg", _0023_003DzAvn2b38_003D);
	}

	[AmbientValue(true)]
	private static void _0023_003DzIAQgbGwrH0Tf(byte _0023_003DzkhmDvZM_003D, byte _0023_003DzRpXgovo_003D, byte _0023_003Dz5rQzobg_003D, byte _0023_003Dz1v6oPQk_003D, byte _0023_003Dz77g161c_003D, byte _0023_003Dz_eY3Y4c_003D)
	{
		object[] _0023_003DzAvn2b38_003D = new object[6] { _0023_003DzkhmDvZM_003D, _0023_003DzRpXgovo_003D, _0023_003Dz5rQzobg_003D, _0023_003Dz1v6oPQk_003D, _0023_003Dz77g161c_003D, _0023_003Dz_eY3Y4c_003D };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "55kK\\q\"abg", _0023_003DzAvn2b38_003D);
	}

	public static Assembly _0023_003DzNrvBEfk_003D(out string _0023_003Dz2t9nEMs_003D, out string _0023_003Dz7krrKyA_003D, out string _0023_003DzI9XLudM_003D, out Version _0023_003DzQ3hPewo_003D, out string _0023_003DzQ8YZULhVjvRB, out string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D)
	{
		return _0023_003DzNrvBEfk_003D(typeof(LicenseManager), out _0023_003Dz2t9nEMs_003D, out _0023_003Dz7krrKyA_003D, out _0023_003DzI9XLudM_003D, out _0023_003DzQ3hPewo_003D, out _0023_003DzQ8YZULhVjvRB, out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D);
	}

	internal static Assembly _0023_003DzNrvBEfk_003D(Type _0023_003DzEKSHIVc_003D, out string _0023_003Dz2t9nEMs_003D, out string _0023_003Dz7krrKyA_003D, out string _0023_003DzI9XLudM_003D, out Version _0023_003DzQ3hPewo_003D, out string _0023_003DzQ8YZULhVjvRB, out string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D)
	{
		Assembly assembly = Assembly.GetAssembly(_0023_003DzEKSHIVc_003D);
		AssemblyName name = assembly.GetName();
		_0023_003DzQ3hPewo_003D = name.Version;
		_0023_003Dz2t9nEMs_003D = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyProductAttribute))).Product;
		_0023_003Dz7krrKyA_003D = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute))).Title;
		_0023_003Dz7krrKyA_003D = _0023_003Dz7krrKyA_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665981), string.Empty);
		_0023_003DzI9XLudM_003D = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute))).Company;
		_0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D = ((AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute))).Copyright;
		_0023_003DzQ8YZULhVjvRB = ProductEdition.ToString();
		return assembly;
	}

	internal static string _0023_003Dzx9n8z_0024w_003D(Type _0023_003DzEKSHIVc_003D, out string _0023_003DzI9XLudM_003D)
	{
		_0023_003DzNrvBEfk_003D(_0023_003DzEKSHIVc_003D, out var _0023_003Dz2t9nEMs_003D, out var _, out _0023_003DzI9XLudM_003D, out var _0023_003DzQ3hPewo_003D, out var _, out var _);
		string text = _0023_003DzQ3hPewo_003D.Major.ToString();
		return _0023_003Dz2t9nEMs_003D + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + text;
	}

	public static string _0023_003DzUcMv_pQ_003D(out string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out string _0023_003DzaCgY2eQ_003D, bool _0023_003Dzwan3TY08r56P, bool _0023_003DzCBmgGLZOgR_0024E)
	{
		return _0023_003DzUcMv_pQ_003D(typeof(LicenseManager), out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out _0023_003DzaCgY2eQ_003D, _0023_003Dzwan3TY08r56P, _0023_003DzCBmgGLZOgR_0024E);
	}

	internal static string _0023_003DzUcMv_pQ_003D(Type _0023_003DzEKSHIVc_003D, out string _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D, out string _0023_003DzaCgY2eQ_003D, bool _0023_003Dzwan3TY08r56P, bool _0023_003DzCBmgGLZOgR_0024E)
	{
		_0023_003DzNrvBEfk_003D(_0023_003DzEKSHIVc_003D, out var _, out var _0023_003Dz7krrKyA_003D, out var _0023_003DzI9XLudM_003D, out var _0023_003DzQ3hPewo_003D, out var _, out _0023_003Dz_M1X3lVHsTLLn3RIbA_003D_003D);
		_0023_003DzaCgY2eQ_003D = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665966), _0023_003DzQ3hPewo_003D.Major, _0023_003DzQ3hPewo_003D.Minor, _0023_003DzQ3hPewo_003D.Build);
		_0023_003Dz7krrKyA_003D = _0023_003Dz7krrKyA_003D.Replace(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665952), string.Empty);
		string text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908656), _0023_003Dz7krrKyA_003D, _0023_003DzQ3hPewo_003D);
		if (_0023_003Dzwan3TY08r56P && !string.IsNullOrEmpty(_0023_003DzI9XLudM_003D))
		{
			text = string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665933), text, _0023_003DzI9XLudM_003D);
		}
		if (_0023_003DzCBmgGLZOgR_0024E)
		{
			text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665890);
		}
		return text;
	}

	internal static RegistryKey _0023_003DzA_00248o1MIdhdodq2ni1A_003D_003D(RegistryKey _0023_003Dz39O_j78_003D, bool _0023_003Dzh7J7S1g_003D)
	{
		if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzZ4RB3Lo_003D())
		{
			try
			{
				RegistryKey registryKey;
				if (_0023_003Dzh7J7S1g_003D)
				{
					registryKey = _0023_003Dz39O_j78_003D.CreateSubKey(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665881));
				}
				else
				{
					registryKey = _0023_003Dz39O_j78_003D.OpenSubKey(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666609));
					if (registryKey == null)
					{
						registryKey = _0023_003Dz39O_j78_003D.OpenSubKey(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302665881));
					}
				}
				return registryKey;
			}
			catch (Exception)
			{
				return null;
			}
		}
		return null;
	}

	internal static string _0023_003DzTgMSIpBTDlWe(string _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzNrvBEfk_003D(typeof(_0023_003DzdvrCH9weFTO4GRhicQ_003D_003D), out var _, out var _, out var _, out var _0023_003DzQ3hPewo_003D, out var _, out var _);
		using RegistryKey registryKey = _0023_003DzA_00248o1MIdhdodq2ni1A_003D_003D(Registry.LocalMachine, _0023_003Dzh7J7S1g_003D: false);
		try
		{
			return (string)registryKey.GetValue(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908656), _0023_003DzPzO_0024GUk_003D, _0023_003DzQ3hPewo_003D.Major));
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	internal static string _0023_003DzU4kvgJYJygkE()
	{
		if (string.IsNullOrEmpty(_0023_003DzAqIm2xOSUef9))
		{
			_0023_003DzAqIm2xOSUef9 = _0023_003DzTgMSIpBTDlWe(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666581));
		}
		return _0023_003DzAqIm2xOSUef9;
	}

	internal static string _0023_003DzASix8JgwQD_n()
	{
		if (string.IsNullOrEmpty(_0023_003DzPefBHAf0rB2AxeO8GA_003D_003D))
		{
			_0023_003DzPefBHAf0rB2AxeO8GA_003D_003D = _0023_003DzTgMSIpBTDlWe(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302666572));
		}
		return _0023_003DzPefBHAf0rB2AxeO8GA_003D_003D;
	}
}
