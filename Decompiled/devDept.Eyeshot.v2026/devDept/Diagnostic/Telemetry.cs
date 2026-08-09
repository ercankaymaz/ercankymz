using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace devDept.Diagnostic;

internal sealed class Telemetry
{
	internal sealed class _0023_003Dz9Bj6EjJvYJuU
	{
		private Dictionary<string, moduleType> _0023_003DzUke3oJurbU95waReV6VjlG0_003D = new Dictionary<string, moduleType>();

		private DateTime _0023_003DzUU2IiRnxinoAmJHENg_003D_003D = DateTime.UtcNow;

		public Dictionary<string, moduleType> UsedModules
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzUke3oJurbU95waReV6VjlG0_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzUke3oJurbU95waReV6VjlG0_003D = value;
			}
		}

		public DateTime Timestamp
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzUU2IiRnxinoAmJHENg_003D_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzUU2IiRnxinoAmJHENg_003D_003D = value;
			}
		}

		public _0023_003Dz9Bj6EjJvYJuU _0023_003Dzx9P_oXY_003D()
		{
			return new _0023_003Dz9Bj6EjJvYJuU
			{
				UsedModules = new Dictionary<string, moduleType>(UsedModules),
				Timestamp = Timestamp
			};
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzIBkuNZHw0EG7EHrhLbV2tPo_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<bool> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public List<_0023_003Dz9Bj6EjJvYJuU> _0023_003Dzp_mr_0024tw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Telemetry _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<HttpResponseMessage> _0023_003DzpVK748zcYJ8u;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<string> _0023_003DzFYvRpuzB_RuY;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			Telemetry telemetry = _0023_003DzopRx0_MBcTQs;
			bool result2;
			try
			{
				_0023_003DzyaZM0fcnOx9L2G97aj67s9Q_003D _0023_003DzPzO_0024GUk_003D = default(_0023_003DzyaZM0fcnOx9L2G97aj67s9Q_003D);
				if ((uint)num > 1u)
				{
					_0023_003DzPzO_0024GUk_003D = new _0023_003DzyaZM0fcnOx9L2G97aj67s9Q_003D
					{
						UserId = LicenseManager._0023_003DzVxSaKTNQNphX()._0023_003DznILHHJI_003D.UserId,
						DebugSessions = _0023_003Dzp_mr_0024tw_003D
					};
				}
				try
				{
					TaskAwaiter<string> awaiter;
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _0023_003DzFYvRpuzB_RuY;
							_0023_003DzFYvRpuzB_RuY = default(TaskAwaiter<string>);
							num = (_0023_003DzU7pGb3X7Zp4G = -1);
							goto IL_0193;
						}
						awaiter2 = LicenseManager._0023_003DzVxSaKTNQNphX()._0023_003DzsOVX16AYJFuX(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950527), _0023_003DzPzO_0024GUk_003D, _0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003Dzz0Mvjc0_grWZ).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_0023_003DzU7pGb3X7Zp4G = 0);
							_0023_003DzpVK748zcYJ8u = awaiter2;
							_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = _0023_003DzpVK748zcYJ8u;
						_0023_003DzpVK748zcYJ8u = default(TaskAwaiter<HttpResponseMessage>);
						num = (_0023_003DzU7pGb3X7Zp4G = -1);
					}
					HttpResponseMessage result = awaiter2.GetResult();
					if (result == null)
					{
						LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950475), TraceLevel.Warning, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
						result2 = false;
					}
					else
					{
						if (result.IsSuccessStatusCode)
						{
							awaiter = result.Content.ReadAsStringAsync().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0023_003DzU7pGb3X7Zp4G = 1);
								_0023_003DzFYvRpuzB_RuY = awaiter;
								_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
							goto IL_0193;
						}
						LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzjCTEXAAs0lMnVaKotjhoG0s_003D._0023_003DzOBa6BJcXRxw_0024(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950403), new object[4]
						{
							_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950637),
							Environment.NewLine,
							result.StatusCode,
							result.ReasonPhrase
						}), TraceLevel.Warning, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
						result2 = false;
					}
					goto end_IL_000e;
					IL_0193:
					_0023_003DziOsugyY_003D _0023_003DziOsugyY_003D2 = JsonSerializer.Deserialize<_0023_003DziOsugyY_003D>(awaiter.GetResult());
					if (telemetry._0023_003DzhQscM0s_003D.FlushDueTime != _0023_003DziOsugyY_003D2.FlushDueTime)
					{
						telemetry._0023_003Dz3gj_0Awq_ts0.Change(_0023_003DziOsugyY_003D2._0023_003DzYyV43KHqYoXg(), _0023_003DziOsugyY_003D2._0023_003DzK2h3RtSqFgO7());
					}
					telemetry._0023_003DzhQscM0s_003D = _0023_003DziOsugyY_003D2;
					_0023_003DznDrCbLbkmOfmjM7YAGUCSTVkDIf8._0023_003DzJ70BiKY_003D(JsonSerializer.Serialize(telemetry._0023_003DzhQscM0s_003D), _0023_003Dz_gp9fKB9g8WS, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950607), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950552));
				}
				catch (Exception _0023_003DzSQYc_0024aE_003D)
				{
					LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950541), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
					result2 = false;
					goto end_IL_000e;
				}
				result2 = true;
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				_0023_003DzU7pGb3X7Zp4G = -2;
				_0023_003DzCodHnSRJkAEg.SetException(exception);
				return;
			}
			_0023_003DzU7pGb3X7Zp4G = -2;
			_0023_003DzCodHnSRJkAEg.SetResult(result2);
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

	internal sealed class _0023_003DziOsugyY_003D
	{
		private int _0023_003DzjtVZXoGL2bKKg0oI_PVkpvw_003D;

		private int _0023_003DzqL5BMkye_0024QtQOIGRJwzos4Q_003D;

		private bool _0023_003DzcO8A_cwp9Qj3NvrBhQ_003D_003D;

		private int _0023_003DzBQL4oyMpe4iSNixACDg49Ys_003D = 10;

		private int _0023_003DzcHBtRKCNvRA832ZD6bfmms4_003D = 10;

		public int MaxStoredSessions
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzjtVZXoGL2bKKg0oI_PVkpvw_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzjtVZXoGL2bKKg0oI_PVkpvw_003D = value;
			}
		}

		public int MaxRetentionDays
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzqL5BMkye_0024QtQOIGRJwzos4Q_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzqL5BMkye_0024QtQOIGRJwzos4Q_003D = value;
			}
		}

		public bool Enabled
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzcO8A_cwp9Qj3NvrBhQ_003D_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzcO8A_cwp9Qj3NvrBhQ_003D_003D = value;
			}
		}

		public int FlushDueTime
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzBQL4oyMpe4iSNixACDg49Ys_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzBQL4oyMpe4iSNixACDg49Ys_003D = value;
			}
		}

		public int FlushPeriod
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzcHBtRKCNvRA832ZD6bfmms4_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzcHBtRKCNvRA832ZD6bfmms4_003D = value;
			}
		}

		internal TimeSpan _0023_003DzYyV43KHqYoXg()
		{
			return TimeSpan.FromSeconds(FlushDueTime);
		}

		internal TimeSpan _0023_003DzK2h3RtSqFgO7()
		{
			return TimeSpan.FromSeconds(FlushPeriod);
		}
	}

	private sealed class _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D
	{
		public _0023_003Dz9Bj6EjJvYJuU _0023_003DzNmJqeUAy1Cw_0024;

		internal bool _0023_003DzhMTz8jET7N3FUmxBNA_003D_003D(_0023_003Dz9Bj6EjJvYJuU _0023_003DzBJFJHwk_003D)
		{
			return _0023_003DzBJFJHwk_003D.Timestamp.Equals(_0023_003DzNmJqeUAy1Cw_0024.Timestamp);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003DzjefVfItmu5h4g5cVhw_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Telemetry _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private List<_0023_003Dz9Bj6EjJvYJuU> _0023_003DzmlQ0GaULcwGEr0QysA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<bool> _0023_003DzpVK748zcYJ8u;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private FileStream _0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzFYvRpuzB_RuY;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			Telemetry telemetry = _0023_003DzopRx0_MBcTQs;
			try
			{
				if ((uint)num <= 3u)
				{
					goto IL_0211;
				}
				_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2 = new _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D();
				_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzNmJqeUAy1Cw_0024 = null;
				object _0023_003DzzOB9U9w_003D = Telemetry._0023_003DzzOB9U9w_003D;
				bool lockTaken = false;
				try
				{
					Monitor.Enter(_0023_003DzzOB9U9w_003D, ref lockTaken);
					if (!telemetry._0023_003DzL0q90J4pnW1bcrLgpw_003D_003D)
					{
						try
						{
							if (telemetry._0023_003DzhQscM0s_003D.Enabled)
							{
								if (telemetry._0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer || telemetry._0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Blink)
								{
									string key = telemetry._0023_003Dz1vqhXyApLSci.ToString();
									if (!telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.ContainsKey(key))
									{
										telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.Add(key, moduleType.Generic);
									}
								}
								else if (!telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.ContainsKey(Logger.TargetFramework))
								{
									telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.Add(Logger.TargetFramework, moduleType.TargetFramework);
									LicenseManager._0023_003DzNrvBEfk_003D(typeof(Telemetry), out var _, out var _, out var _, out var _0023_003DzQ3hPewo_003D, out var _, out var _);
									telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950866) + _0023_003DzQ3hPewo_003D.Major, moduleType.Generic);
									if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzIbv67eg_003D())
									{
										telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950855), moduleType.Platform);
									}
									else if (!(bool)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "jSf)Xq\"aba", null))
									{
										telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950833), moduleType.Platform);
									}
								}
								if (telemetry.ProgressiveDrawing && !telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.ContainsKey(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950847)))
								{
									telemetry._0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950847), moduleType.Graphics);
								}
								_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzNmJqeUAy1Cw_0024 = telemetry._0023_003DzMWsh5fuhD_sE._0023_003Dzx9P_oXY_003D();
							}
							telemetry._0023_003DzL0q90J4pnW1bcrLgpw_003D_003D = true;
						}
						catch (Exception _0023_003DzSQYc_0024aE_003D)
						{
							LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950810), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
							telemetry._0023_003Dz_00245gUm2U_003D();
						}
						goto IL_0211;
					}
				}
				finally
				{
					if (num < 0 && lockTaken)
					{
						Monitor.Exit(_0023_003DzzOB9U9w_003D);
					}
				}
				goto end_IL_000e;
				IL_0211:
				try
				{
					TaskAwaiter<bool> awaiter;
					if (num == 0)
					{
						awaiter = _0023_003DzpVK748zcYJ8u;
						_0023_003DzpVK748zcYJ8u = default(TaskAwaiter<bool>);
						num = (_0023_003DzU7pGb3X7Zp4G = -1);
						goto IL_028f;
					}
					if ((uint)(num - 1) > 2u)
					{
						_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D = new List<_0023_003Dz9Bj6EjJvYJuU>();
						if (!telemetry._0023_003DzhQscM0s_003D.Enabled)
						{
							awaiter = telemetry._0023_003Dzv4oQmd8wNJ9j(_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0023_003DzU7pGb3X7Zp4G = 0);
								_0023_003DzpVK748zcYJ8u = awaiter;
								_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
							goto IL_028f;
						}
						_0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D = File.Open(_0023_003Dz73w9k4aZdks_0024, FileMode.OpenOrCreate, FileAccess.ReadWrite);
					}
					try
					{
						TaskAwaiter awaiter2;
						string s;
						byte[] bytes;
						DateTime timestamp;
						switch (num)
						{
						default:
						{
							byte[] array = new byte[_0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D.Length];
							if (_0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D.Read(array, 0, array.Length) <= 0)
							{
								goto IL_0338;
							}
							string json = Encoding.UTF8.GetString(array);
							_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D = JsonSerializer.Deserialize<List<_0023_003Dz9Bj6EjJvYJuU>>(json);
							int num2 = _0023_003DzmlQ0GaULcwGEr0QysA_003D_003D.RemoveAll(_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzhMTz8jET7N3FUmxBNA_003D_003D);
							if (!telemetry._0023_003DzNOUdKNFmZf6a || num2 != 0)
							{
								goto IL_0338;
							}
							telemetry._0023_003Dz_00245gUm2U_003D();
							goto end_IL_0211;
						}
						case 1:
							awaiter = _0023_003DzpVK748zcYJ8u;
							_0023_003DzpVK748zcYJ8u = default(TaskAwaiter<bool>);
							num = (_0023_003DzU7pGb3X7Zp4G = -1);
							goto IL_03f3;
						case 2:
							awaiter2 = _0023_003DzFYvRpuzB_RuY;
							_0023_003DzFYvRpuzB_RuY = default(TaskAwaiter);
							num = (_0023_003DzU7pGb3X7Zp4G = -1);
							goto IL_04b3;
						case 3:
							{
								awaiter2 = _0023_003DzFYvRpuzB_RuY;
								_0023_003DzFYvRpuzB_RuY = default(TaskAwaiter);
								num = (_0023_003DzU7pGb3X7Zp4G = -1);
								break;
							}
							IL_04b3:
							awaiter2.GetResult();
							awaiter2 = _0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D.FlushAsync().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0023_003DzU7pGb3X7Zp4G = 3);
								_0023_003DzFYvRpuzB_RuY = awaiter2;
								_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
								return;
							}
							break;
							IL_03f3:
							if (awaiter.GetResult())
							{
								_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D.Clear();
								telemetry._0023_003Dz_00245gUm2U_003D();
							}
							goto IL_040d;
							IL_040d:
							s = JsonSerializer.Serialize(_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D, new JsonSerializerOptions
							{
								WriteIndented = true
							});
							bytes = Encoding.UTF8.GetBytes(s);
							_0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D.SetLength(0L);
							_0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D.Seek(0L, SeekOrigin.Begin);
							awaiter2 = _0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D.WriteAsync(bytes, 0, bytes.Length).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0023_003DzU7pGb3X7Zp4G = 2);
								_0023_003DzFYvRpuzB_RuY = awaiter2;
								_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
								return;
							}
							goto IL_04b3;
							IL_0338:
							_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D.Add(_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzNmJqeUAy1Cw_0024);
							timestamp = _0023_003DzmlQ0GaULcwGEr0QysA_003D_003D[0].Timestamp;
							if (_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D.Count > telemetry._0023_003DzhQscM0s_003D.MaxStoredSessions || DateTime.UtcNow - timestamp >= TimeSpan.FromDays(telemetry._0023_003DzhQscM0s_003D.MaxRetentionDays))
							{
								awaiter = telemetry._0023_003Dzv4oQmd8wNJ9j(_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0023_003DzU7pGb3X7Zp4G = 1);
									_0023_003DzpVK748zcYJ8u = awaiter;
									_0023_003DzCodHnSRJkAEg.AwaitUnsafeOnCompleted(ref awaiter, ref this);
									return;
								}
								goto IL_03f3;
							}
							goto IL_040d;
						}
						awaiter2.GetResult();
						telemetry._0023_003DzNOUdKNFmZf6a = true;
						if (telemetry._0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer || telemetry._0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Blink)
						{
							telemetry._0023_003Dz_00245gUm2U_003D();
						}
					}
					finally
					{
						if (num < 0 && _0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D != null)
						{
							((IDisposable)_0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D).Dispose();
						}
					}
					_0023_003DzlIIaYcFxX7_LzU8RfA_003D_003D = null;
					File.SetAttributes(_0023_003Dz73w9k4aZdks_0024, File.GetAttributes(_0023_003Dz73w9k4aZdks_0024) | FileAttributes.Hidden);
					_0023_003DzmlQ0GaULcwGEr0QysA_003D_003D = null;
					goto end_IL_0211;
					IL_028f:
					awaiter.GetResult();
					end_IL_0211:;
				}
				catch (UnauthorizedAccessException)
				{
				}
				catch (Exception _0023_003DzSQYc_0024aE_003D2)
				{
					LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950810), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D2, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
					telemetry._0023_003Dz_00245gUm2U_003D();
				}
				finally
				{
					if (num < 0)
					{
						_0023_003DzzOB9U9w_003D = Telemetry._0023_003DzzOB9U9w_003D;
						lockTaken = false;
						try
						{
							Monitor.Enter(_0023_003DzzOB9U9w_003D, ref lockTaken);
							telemetry._0023_003DzL0q90J4pnW1bcrLgpw_003D_003D = false;
						}
						finally
						{
							if (num < 0 && lockTaken)
							{
								Monitor.Exit(_0023_003DzzOB9U9w_003D);
							}
						}
					}
				}
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

	public enum moduleType : byte
	{
		Generic,
		TargetFramework,
		Platform,
		Workspace,
		Renderer,
		Translators,
		WorkUnit,
		Booleans,
		Graphics
	}

	private static readonly string _0023_003Dz_gp9fKB9g8WS = Path.Combine(_0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003DzQikYzgdxy8cu, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951253));

	private static readonly string _0023_003Dz73w9k4aZdks_0024 = Path.Combine(_0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003DzQikYzgdxy8cu, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951244));

	private static readonly object _0023_003DzzOB9U9w_003D = new object();

	private _0023_003Dz9Bj6EjJvYJuU _0023_003DzMWsh5fuhD_sE;

	private _0023_003DziOsugyY_003D _0023_003DzhQscM0s_003D = new _0023_003DziOsugyY_003D();

	private Timer _0023_003Dz3gj_0Awq_ts0;

	private _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003Dz1vqhXyApLSci;

	public bool ProgressiveDrawing;

	private static Telemetry _0023_003DzJzigAJs_003D;

	private bool _0023_003DzL0q90J4pnW1bcrLgpw_003D_003D;

	private bool _0023_003DzNOUdKNFmZf6a;

	public bool CollectData
	{
		get
		{
			if (_0023_003DzhQscM0s_003D.Enabled)
			{
				return _0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.None;
			}
			return false;
		}
	}

	public static Telemetry Instance
	{
		get
		{
			if (_0023_003DzJzigAJs_003D == null)
			{
				lock (_0023_003DzzOB9U9w_003D)
				{
					_0023_003DzJzigAJs_003D = new Telemetry();
				}
			}
			return _0023_003DzJzigAJs_003D;
		}
	}

	internal void _0023_003Dz_0024Jquo8Y_003D(_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D _0023_003DzkhmDvZM_003D)
	{
		try
		{
			lock (_0023_003DzzOB9U9w_003D)
			{
				_0023_003DzMWsh5fuhD_sE = new _0023_003Dz9Bj6EjJvYJuU();
				_0023_003Dz1vqhXyApLSci = _0023_003DzkhmDvZM_003D;
				if (File.Exists(_0023_003Dz_gp9fKB9g8WS))
				{
					string text = _0023_003DznDrCbLbkmOfmjM7YAGUCSTVkDIf8._0023_003DzGk_IP20_003D(_0023_003Dz_gp9fKB9g8WS, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950607), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950552));
					if (!string.IsNullOrEmpty(text))
					{
						_0023_003DzhQscM0s_003D = JsonSerializer.Deserialize<_0023_003DziOsugyY_003D>(text);
					}
				}
				_0023_003Dz3gj_0Awq_ts0 = new Timer(_0023_003Dz1oHiDd2rxTiB, null, _0023_003DzhQscM0s_003D._0023_003DzYyV43KHqYoXg(), _0023_003DzhQscM0s_003D._0023_003DzK2h3RtSqFgO7());
				AppDomain.CurrentDomain.ProcessExit += delegate
				{
					// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
					// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
					_0023_003Dz3gj_0Awq_ts0?.Dispose();
					AppDomain.CurrentDomain.ProcessExit -= _0023_003DzievV_0024Jkydk1j;
					AppDomain.CurrentDomain.DomainUnload -= _0023_003DzievV_0024Jkydk1j;
					_0023_003DzXYLQJgM_003D();
				};
				AppDomain.CurrentDomain.DomainUnload += delegate
				{
					// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
					// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
					_0023_003Dz3gj_0Awq_ts0?.Dispose();
					AppDomain.CurrentDomain.ProcessExit -= _0023_003DzievV_0024Jkydk1j;
					AppDomain.CurrentDomain.DomainUnload -= _0023_003DzievV_0024Jkydk1j;
					_0023_003DzXYLQJgM_003D();
				};
			}
		}
		catch (Exception _0023_003DzSQYc_0024aE_003D)
		{
			LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951202), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
		}
	}

	private void _0023_003Dz_00245gUm2U_003D()
	{
		_0023_003DzhQscM0s_003D.Enabled = false;
		_0023_003Dz3gj_0Awq_ts0.Dispose();
		AppDomain.CurrentDomain.ProcessExit -= delegate
		{
			// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
			// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
			_0023_003Dz3gj_0Awq_ts0?.Dispose();
			AppDomain.CurrentDomain.ProcessExit -= _0023_003DzievV_0024Jkydk1j;
			AppDomain.CurrentDomain.DomainUnload -= _0023_003DzievV_0024Jkydk1j;
			_0023_003DzXYLQJgM_003D();
		};
		AppDomain.CurrentDomain.DomainUnload -= delegate
		{
			// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
			// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
			_0023_003Dz3gj_0Awq_ts0?.Dispose();
			AppDomain.CurrentDomain.ProcessExit -= _0023_003DzievV_0024Jkydk1j;
			AppDomain.CurrentDomain.DomainUnload -= _0023_003DzievV_0024Jkydk1j;
			_0023_003DzXYLQJgM_003D();
		};
	}

	public void AddUsage(object _0023_003DzUd5nM0E_003D, moduleType _0023_003DzEKSHIVc_003D)
	{
		try
		{
			if (CollectData)
			{
				Type type = _0023_003DzUd5nM0E_003D.GetType();
				Type type2 = _0023_003DzTuyoFIWfV4NTvJwoVw_003D_003D(type);
				string _0023_003DzKdxg4Us_003D = ((type2 != null) ? type2.Name : type.Name);
				AddUsage(_0023_003DzKdxg4Us_003D, _0023_003DzEKSHIVc_003D);
			}
		}
		catch (Exception _0023_003DzSQYc_0024aE_003D)
		{
			LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951198), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
		}
	}

	private Type? _0023_003DzTuyoFIWfV4NTvJwoVw_003D_003D(Type _0023_003DzEKSHIVc_003D)
	{
		Type type = _0023_003DzEKSHIVc_003D;
		while (type != null)
		{
			string text = type.Namespace?.ToLower() ?? string.Empty;
			if (text.StartsWith(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951402)) && !text.Contains(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951384)))
			{
				return type;
			}
			type = type.BaseType;
		}
		return null;
	}

	public void AddUsage(string _0023_003DzKdxg4Us_003D, moduleType _0023_003DzEKSHIVc_003D)
	{
		try
		{
			if (!CollectData)
			{
				return;
			}
			lock (_0023_003DzzOB9U9w_003D)
			{
				if (!_0023_003DzMWsh5fuhD_sE.UsedModules.ContainsKey(_0023_003DzKdxg4Us_003D))
				{
					_0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzKdxg4Us_003D, _0023_003DzEKSHIVc_003D);
				}
			}
		}
		catch (Exception _0023_003DzSQYc_0024aE_003D)
		{
			LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951198), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
		}
	}

	private void _0023_003DzXYLQJgM_003D()
	{
		_0023_003Dzwno5pWA_003D().ConfigureAwait(continueOnCapturedContext: false).GetAwaiter().GetResult();
	}

	private async Task _0023_003Dzwno5pWA_003D()
	{
		_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2 = new _0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D();
		_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzNmJqeUAy1Cw_0024 = null;
		lock (_0023_003DzzOB9U9w_003D)
		{
			if (_0023_003DzL0q90J4pnW1bcrLgpw_003D_003D)
			{
				return;
			}
			try
			{
				if (_0023_003DzhQscM0s_003D.Enabled)
				{
					if (_0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer || _0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Blink)
					{
						string key = _0023_003Dz1vqhXyApLSci.ToString();
						if (!_0023_003DzMWsh5fuhD_sE.UsedModules.ContainsKey(key))
						{
							_0023_003DzMWsh5fuhD_sE.UsedModules.Add(key, moduleType.Generic);
						}
					}
					else if (!_0023_003DzMWsh5fuhD_sE.UsedModules.ContainsKey(Logger.TargetFramework))
					{
						_0023_003DzMWsh5fuhD_sE.UsedModules.Add(Logger.TargetFramework, moduleType.TargetFramework);
						LicenseManager._0023_003DzNrvBEfk_003D(typeof(Telemetry), out var _, out var _, out var _, out var _0023_003DzQ3hPewo_003D, out var _, out var _);
						_0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950866) + _0023_003DzQ3hPewo_003D.Major, moduleType.Generic);
						if (_0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzIbv67eg_003D())
						{
							_0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950855), moduleType.Platform);
						}
						else if (!(bool)_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzrXgUYL0XH6cHIwqkUbl2jAY_003D(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "jSf)Xq\"aba", null))
						{
							_0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950833), moduleType.Platform);
						}
					}
					if (ProgressiveDrawing && !_0023_003DzMWsh5fuhD_sE.UsedModules.ContainsKey(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950847)))
					{
						_0023_003DzMWsh5fuhD_sE.UsedModules.Add(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950847), moduleType.Graphics);
					}
					_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzNmJqeUAy1Cw_0024 = _0023_003DzMWsh5fuhD_sE._0023_003Dzx9P_oXY_003D();
				}
				_0023_003DzL0q90J4pnW1bcrLgpw_003D_003D = true;
			}
			catch (Exception _0023_003DzSQYc_0024aE_003D)
			{
				LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950810), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
				_0023_003Dz_00245gUm2U_003D();
			}
		}
		try
		{
			List<_0023_003Dz9Bj6EjJvYJuU> list = new List<_0023_003Dz9Bj6EjJvYJuU>();
			if (!_0023_003DzhQscM0s_003D.Enabled)
			{
				await _0023_003Dzv4oQmd8wNJ9j(list);
				return;
			}
			using (FileStream fileStream = File.Open(_0023_003Dz73w9k4aZdks_0024, FileMode.OpenOrCreate, FileAccess.ReadWrite))
			{
				byte[] array = new byte[fileStream.Length];
				if (fileStream.Read(array, 0, array.Length) > 0)
				{
					string json = Encoding.UTF8.GetString(array);
					list = JsonSerializer.Deserialize<List<_0023_003Dz9Bj6EjJvYJuU>>(json);
					int num = list.RemoveAll(_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzhMTz8jET7N3FUmxBNA_003D_003D);
					if (_0023_003DzNOUdKNFmZf6a && num == 0)
					{
						_0023_003Dz_00245gUm2U_003D();
						return;
					}
				}
				list.Add(_0023_003DziUAqZ_0024oA2VEcJB8H9znUj5w_003D2._0023_003DzNmJqeUAy1Cw_0024);
				DateTime timestamp = list[0].Timestamp;
				if ((list.Count > _0023_003DzhQscM0s_003D.MaxStoredSessions || DateTime.UtcNow - timestamp >= TimeSpan.FromDays(_0023_003DzhQscM0s_003D.MaxRetentionDays)) && await _0023_003Dzv4oQmd8wNJ9j(list))
				{
					list.Clear();
					_0023_003Dz_00245gUm2U_003D();
				}
				string s = JsonSerializer.Serialize(list, new JsonSerializerOptions
				{
					WriteIndented = true
				});
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				fileStream.SetLength(0L);
				fileStream.Seek(0L, SeekOrigin.Begin);
				await fileStream.WriteAsync(bytes, 0, bytes.Length);
				await fileStream.FlushAsync();
				_0023_003DzNOUdKNFmZf6a = true;
				if (_0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Designer || _0023_003Dz1vqhXyApLSci == _0023_003DzL5JZABBRO4QXL_EoM4_0024gfz7D67r3._0023_003DzkhmDvZM_003D.Blink)
				{
					_0023_003Dz_00245gUm2U_003D();
				}
			}
			File.SetAttributes(_0023_003Dz73w9k4aZdks_0024, File.GetAttributes(_0023_003Dz73w9k4aZdks_0024) | FileAttributes.Hidden);
		}
		catch (UnauthorizedAccessException)
		{
		}
		catch (Exception _0023_003DzSQYc_0024aE_003D2)
		{
			LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950810), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D2, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
			_0023_003Dz_00245gUm2U_003D();
		}
		finally
		{
			lock (_0023_003DzzOB9U9w_003D)
			{
				_0023_003DzL0q90J4pnW1bcrLgpw_003D_003D = false;
			}
		}
	}

	private async Task<bool> _0023_003Dzv4oQmd8wNJ9j(List<_0023_003Dz9Bj6EjJvYJuU> _0023_003Dzp_mr_0024tw_003D)
	{
		_0023_003DzyaZM0fcnOx9L2G97aj67s9Q_003D _0023_003DzPzO_0024GUk_003D = new _0023_003DzyaZM0fcnOx9L2G97aj67s9Q_003D
		{
			UserId = LicenseManager._0023_003DzVxSaKTNQNphX()._0023_003DznILHHJI_003D.UserId,
			DebugSessions = _0023_003Dzp_mr_0024tw_003D
		};
		try
		{
			HttpResponseMessage val = await LicenseManager._0023_003DzVxSaKTNQNphX()._0023_003DzsOVX16AYJFuX(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950527), _0023_003DzPzO_0024GUk_003D, _0023_003DzfHYlPNd3F9yRTZs3MQ_003D_003D._0023_003Dzz0Mvjc0_grWZ);
			if (val == null)
			{
				LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950475), TraceLevel.Warning, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
				return false;
			}
			if (!val.IsSuccessStatusCode)
			{
				LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzjCTEXAAs0lMnVaKotjhoG0s_003D._0023_003DzOBa6BJcXRxw_0024(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950403), new object[4]
				{
					_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950637),
					Environment.NewLine,
					val.StatusCode,
					val.ReasonPhrase
				}), TraceLevel.Warning, null, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
				return false;
			}
			_0023_003DziOsugyY_003D _0023_003DziOsugyY_003D2 = JsonSerializer.Deserialize<_0023_003DziOsugyY_003D>(await val.Content.ReadAsStringAsync());
			if (_0023_003DzhQscM0s_003D.FlushDueTime != _0023_003DziOsugyY_003D2.FlushDueTime)
			{
				_0023_003Dz3gj_0Awq_ts0.Change(_0023_003DziOsugyY_003D2._0023_003DzYyV43KHqYoXg(), _0023_003DziOsugyY_003D2._0023_003DzK2h3RtSqFgO7());
			}
			_0023_003DzhQscM0s_003D = _0023_003DziOsugyY_003D2;
			_0023_003DznDrCbLbkmOfmjM7YAGUCSTVkDIf8._0023_003DzJ70BiKY_003D(JsonSerializer.Serialize(_0023_003DzhQscM0s_003D), _0023_003Dz_gp9fKB9g8WS, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950607), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950552));
		}
		catch (Exception _0023_003DzSQYc_0024aE_003D)
		{
			LicenseManager._0023_003Dzkbdl2RNkTQTU(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302950541), TraceLevel.Warning, _0023_003DzSQYc_0024aE_003D, _0023_003DzHmsOmLY94V0f: false, Array.Empty<object>());
			return false;
		}
		return true;
	}

	private void _0023_003Dz1oHiDd2rxTiB(object _0023_003DzOurSKYw_003D)
	{
		_0023_003Dzwno5pWA_003D();
	}

	private void _0023_003DzievV_0024Jkydk1j(object _0023_003Dz9VjL5i0_003D, EventArgs _0023_003DzbfrNXYE_003D)
	{
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		// Found self-referencing delegate construction. Abort transformation to avoid stack overflow.
		_0023_003Dz3gj_0Awq_ts0?.Dispose();
		AppDomain.CurrentDomain.ProcessExit -= _0023_003DzievV_0024Jkydk1j;
		AppDomain.CurrentDomain.DomainUnload -= _0023_003DzievV_0024Jkydk1j;
		_0023_003DzXYLQJgM_003D();
	}
}
