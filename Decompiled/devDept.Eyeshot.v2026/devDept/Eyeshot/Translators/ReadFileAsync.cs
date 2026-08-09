using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public abstract class ReadFileAsync : WorkUnit
{
	[StructLayout(LayoutKind.Auto)]
	private struct _0023_003Dz1fDkf0hPHiFogTx_UA_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<BlockReference> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Document _0023_003DzoPlwCJA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public conflictPolicy _0023_003DzkDT_0024HYsJqA7X;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzhP_0024tv07jE_0024LS;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003DzJPR4E5ZNOD6H;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DznkMU43c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<BlockReference> _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			ReadFileAsync _0023_003DzQZpgnjI_003D = _0023_003DzopRx0_MBcTQs;
			BlockReference result;
			try
			{
				TaskAwaiter<BlockReference> awaiter;
				if (num != 0)
				{
					awaiter = _0023_003DzoPlwCJA_003D._0023_003DzVsWbKGE_003D(_0023_003DzQZpgnjI_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS, _0023_003DzJPR4E5ZNOD6H, _0023_003DznkMU43c_003D, _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D).GetAwaiter();
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
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter<BlockReference>);
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
	private struct _0023_003DzJENLrvK3j2NGZH0GBg_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IWorkspace _0023_003DzImQx0os_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public conflictPolicy _0023_003DzkDT_0024HYsJqA7X;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzhP_0024tv07jE_0024LS;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			ReadFileAsync readFileAsync = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = readFileAsync.AppendToAsync(_0023_003DzImQx0os_003D.Document, _0023_003DzZcrk_0024oE_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS).GetAwaiter();
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
	private struct _0023_003DzMM8urnvwkunBchRzqQ_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<BlockReference> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IDesign _0023_003DzDh_00246Paw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<BlockReference> _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			ReadFileAsync readFileAsync = _0023_003DzopRx0_MBcTQs;
			BlockReference result;
			try
			{
				TaskAwaiter<BlockReference> awaiter;
				if (num != 0)
				{
					awaiter = readFileAsync.OpenToAsync(_0023_003DzDh_00246Paw_003D.Document, _0023_003DzZcrk_0024oE_003D, _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D).GetAwaiter();
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
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter<BlockReference>);
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
	private struct _0023_003DzgI80D0z4I49fzIhlOA_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Document _0023_003DzoPlwCJA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public conflictPolicy _0023_003DzkDT_0024HYsJqA7X;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzhP_0024tv07jE_0024LS;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			ReadFileAsync _0023_003DzQZpgnjI_003D = _0023_003DzopRx0_MBcTQs;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = _0023_003DzoPlwCJA_003D._0023_003DzYIDN7QA_003D(_0023_003DzQZpgnjI_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS).GetAwaiter();
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
	private struct _0023_003DzqquOgyc_GqYaqBhLlQ_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<BlockReference> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IWorkspace _0023_003DzImQx0os_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public conflictPolicy _0023_003DzkDT_0024HYsJqA7X;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzhP_0024tv07jE_0024LS;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003DzJPR4E5ZNOD6H;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003DznkMU43c_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<BlockReference> _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			ReadFileAsync readFileAsync = _0023_003DzopRx0_MBcTQs;
			BlockReference result;
			try
			{
				TaskAwaiter<BlockReference> awaiter;
				if (num != 0)
				{
					awaiter = readFileAsync.InsertToAsync(_0023_003DzImQx0os_003D.Document, _0023_003DzZcrk_0024oE_003D, _0023_003DzkDT_0024HYsJqA7X, _0023_003DzhP_0024tv07jE_0024LS, _0023_003DzJPR4E5ZNOD6H, _0023_003DznkMU43c_003D, _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D).GetAwaiter();
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
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter<BlockReference>);
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
	private struct _0023_003DztgFVT0jt6uBbzZyr8g_003D_003D : IAsyncStateMachine
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzU7pGb3X7Zp4G;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public AsyncTaskMethodBuilder<BlockReference> _0023_003DzCodHnSRJkAEg;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public DesignDocument _0023_003DzYwIE4oHHd7Xy;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ReadFileAsync _0023_003DzopRx0_MBcTQs;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public RegenOptions _0023_003DzZcrk_0024oE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TaskAwaiter<BlockReference> _0023_003DzpVK748zcYJ8u;

		private void MoveNext()
		{
			int num = _0023_003DzU7pGb3X7Zp4G;
			ReadFileAsync _0023_003DzQZpgnjI_003D = _0023_003DzopRx0_MBcTQs;
			BlockReference result;
			try
			{
				TaskAwaiter<BlockReference> awaiter;
				if (num != 0)
				{
					awaiter = _0023_003DzYwIE4oHHd7Xy._0023_003DzSX5GAf0_003D(_0023_003DzQZpgnjI_003D, _0023_003DzZcrk_0024oE_003D, _0023_003DzX8G_L_R17HfAlC2QNg_003D_003D).GetAwaiter();
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
					_0023_003DzpVK748zcYJ8u = default(TaskAwaiter<BlockReference>);
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

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzyspGdg5MRFvGNXLH3A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz3kO3_F7sTTz8pw9PBQ_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004598);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzfJYxoF_0024xUaa73_ZaHA_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004586);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzR5MJfhx7biL8VFxz6GlDFc4_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004569);

	protected bool readFileCloseStream;

	protected static Color DEFAULT_COLOR = Color.Beige;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Stream _0023_003Dz770nwb_XN3uIVdXDXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BlockKeyedCollection _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = new BlockKeyedCollection(StringComparer.CurrentCultureIgnoreCase);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzONqArkE1_0024qVq1UVdNP3dFZs_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004275);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dzthm2Q35IG0_e_DHakg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzyBRP4053wGoTJUgRTg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzNppV7PGGh11D1Kjj1A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DateTime _0023_003DzUU2IiRnxinoAmJHENg_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzoNW7eOW4PyZcp660qGUUrPQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static string _0023_003DzZEKtB5M1I4vABrH53Opsgm4_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302928178);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LayerKeyedCollection _0023_003DzSolg7xy8nvImQawkYg_003D_003D = new LayerKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialKeyedCollection _0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B = new MaterialKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private LineTypeKeyedCollection _0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D = new LineTypeKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private HatchPatternKeyedCollection _0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D = new HatchPatternKeyedCollection();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private TextStyleKeyedCollection _0023_003DzOdpS5s330wsiSi_tbQ_003D_003D = new TextStyleKeyedCollection();

	public abstract supportedLinearUnitsType SupportedLinearUnitsType { get; }

	public string Path
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyspGdg5MRFvGNXLH3A_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzyspGdg5MRFvGNXLH3A_003D_003D = value;
		}
	}

	public string ReadingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3kO3_F7sTTz8pw9PBQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3kO3_F7sTTz8pw9PBQ_003D_003D = value;
		}
	}

	public string ParsingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfJYxoF_0024xUaa73_ZaHA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzfJYxoF_0024xUaa73_ZaHA_003D_003D = value;
		}
	}

	public string ParsingEntitiesText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzR5MJfhx7biL8VFxz6GlDFc4_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzR5MJfhx7biL8VFxz6GlDFc4_003D = value;
		}
	}

	public EntityList Entities => Blocks.RootBlock.Entities;

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzMAwxuaPlkGJ_BdB1Tg_003D_003D = value;
		}
	}

	public bool Result
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzhunUpMU3pDJqcavGrA_003D_003D = value;
		}
	}

	public Stream Stream
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz770nwb_XN3uIVdXDXQ_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003Dz770nwb_XN3uIVdXDXQ_003D_003D = value;
		}
	}

	public BlockKeyedCollection Blocks
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzF97WMq_0024wP8gY4FUd3g_003D_003D = value;
		}
	}

	public string ParsingBlocksText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzONqArkE1_0024qVq1UVdNP3dFZs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzONqArkE1_0024qVq1UVdNP3dFZs_003D = value;
		}
	}

	public linearUnitsType Units
	{
		get
		{
			return Blocks.RootBlock.Units;
		}
		protected set
		{
			Blocks.RootBlock.Units = value;
		}
	}

	public string Author
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzthm2Q35IG0_e_DHakg_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003Dzthm2Q35IG0_e_DHakg_003D_003D = value;
		}
	}

	public string Organization
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzyBRP4053wGoTJUgRTg_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzyBRP4053wGoTJUgRTg_003D_003D = value;
		}
	}

	public string OriginatingSystem
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzWmRFJUwQumqOA7mR0ncjhIo_003D = value;
		}
	}

	public string FileName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzNppV7PGGh11D1Kjj1A_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzNppV7PGGh11D1Kjj1A_003D_003D = value;
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
		protected set
		{
			_0023_003DzUU2IiRnxinoAmJHENg_003D_003D = value;
		}
	}

	public string PreProcessor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzoNW7eOW4PyZcp660qGUUrPQ_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzoNW7eOW4PyZcp660qGUUrPQ_003D = value;
		}
	}

	public LayerKeyedCollection Layers
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzSolg7xy8nvImQawkYg_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzSolg7xy8nvImQawkYg_003D_003D = value;
		}
	}

	public MaterialKeyedCollection Materials
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003Dz3LjsdFNpuYbi3t4cdInWH3BVys6B = value;
		}
	}

	public LineTypeKeyedCollection LineTypes
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzDuFrfh82AJ9_0024N05F5w_003D_003D = value;
		}
	}

	public HatchPatternKeyedCollection HatchPatterns
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzvIp358N6rMgkJ7PYLL0OJ9c_003D = value;
		}
	}

	public TextStyleKeyedCollection TextStyles
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOdpS5s330wsiSi_tbQ_003D_003D;
		}
		[CompilerGenerated]
		protected set
		{
			_0023_003DzOdpS5s330wsiSi_tbQ_003D_003D = value;
		}
	}

	protected ReadFileAsync(string filePath)
		: this(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
	{
		Path = System.IO.Path.GetDirectoryName(filePath);
		FilePath = _0023_003DzHg_0024BPP4dJ1M_YPc_0024U3Hw5iGNjzzwMvEg8YR8GcmF6Kn6._0023_003Dzz6JDud_0024u1ojF(filePath, _0023_003Dzmyw8uNw_003D: true);
		readFileCloseStream = true;
	}

	protected ReadFileAsync(Stream s)
	{
		Stream = s;
		Blocks._0023_003Dz2tUjc04_003D();
	}

	private protected ReadFileAsync()
	{
	}

	public void RotateEverythingAroundX(double angleInRadians = Math.PI / 2.0)
	{
		foreach (Entity entity in Entities)
		{
			entity.Rotate(angleInRadians, Vector3D.AxisX);
		}
	}

	public void FillAllCollectionsData(IWorkspace workspace, conflictPolicy conflictPolicy = conflictPolicy.Rename)
	{
		FillAllCollectionsData(workspace.Document, conflictPolicy);
	}

	public void FillAllCollectionsData(Document document, conflictPolicy conflictPolicy = conflictPolicy.Rename)
	{
		document._0023_003DzAA7nAE5oH2H3(this, conflictPolicy, _0023_003DzKE_FpisulC8D: false);
	}

	public void FillCollection<T>(EyeshotKeyedCollection<T> dest, conflictPolicy conflictPolicy = conflictPolicy.Rename) where T : IKeyedCollectionItem<T>
	{
		FillCollection(dest, conflictPolicy, out var _);
	}

	public void FillCollection<T>(EyeshotKeyedCollection<T> dest, conflictPolicy conflictPolicy, out Dictionary<string, string> oldNewMapping) where T : IKeyedCollectionItem<T>
	{
		Type typeFromHandle = typeof(T);
		EyeshotKeyedCollection<T> _0023_003DzqjMrmuo_003D;
		if (typeFromHandle == typeof(Block))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)Blocks;
		}
		else if (typeFromHandle == typeof(Layer))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)Layers;
		}
		else if (typeFromHandle == typeof(TextStyle))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)TextStyles;
		}
		else if (typeFromHandle == typeof(HatchPattern))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)HatchPatterns;
		}
		else if (typeFromHandle == typeof(LineType))
		{
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)LineTypes;
		}
		else
		{
			if (!(typeFromHandle == typeof(Material)))
			{
				throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303004267) + typeFromHandle.Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302908290));
			}
			_0023_003DzqjMrmuo_003D = (EyeshotKeyedCollection<T>)(object)Materials;
		}
		Document._0023_003DzBlcGo_o_003D(_0023_003DzqjMrmuo_003D, dest, conflictPolicy, out oldNewMapping, null);
	}

	public override void WorkCancelled(object sender)
	{
		base.WorkCancelled(sender);
		CloseStream();
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		base.DoWork(progress, ct);
		CloseStream();
	}

	protected internal virtual void CloseStream()
	{
		if (readFileCloseStream && Stream != null)
		{
			Stream.Close();
		}
	}

	public virtual void ImportSettings(IWorkspace workspace)
	{
		ImportSettings(workspace.Document);
	}

	public virtual void ImportSettings(Document document)
	{
	}

	public BlockReference OpenTo(IDesign design, RegenOptions ro = null, bool removeJittering = false)
	{
		return OpenTo(design.Document, ro, removeJittering);
	}

	public BlockReference OpenTo(DesignDocument designDoc, RegenOptions ro = null, bool removeJittering = false)
	{
		return designDoc._0023_003Dz3nSNv4s_003D(this, ro, removeJittering);
	}

	public async Task<BlockReference> OpenToAsync(IDesign design, RegenOptions ro = null, bool removeJittering = false)
	{
		return await OpenToAsync(design.Document, ro, removeJittering);
	}

	public async Task<BlockReference> OpenToAsync(DesignDocument designDoc, RegenOptions ro = null, bool removeJittering = false)
	{
		return await designDoc._0023_003DzSX5GAf0_003D(this, ro, removeJittering);
	}

	public BlockReference InsertTo(IWorkspace workspace, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true, Point3D insPoint = null, string blockName = null, bool removeJittering = false)
	{
		return InsertTo(workspace.Document, ro, conflictPolicy, scaleByUnits, insPoint, blockName, removeJittering);
	}

	public BlockReference InsertTo(Document document, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true, Point3D insPoint = null, string blockName = null, bool removeJittering = false)
	{
		return document._0023_003DzwVFSvec_003D(this, ro, conflictPolicy, scaleByUnits, insPoint, blockName, removeJittering);
	}

	public async Task<BlockReference> InsertToAsync(IWorkspace workspace, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true, Point3D insPoint = null, string blockName = null, bool removeJittering = false)
	{
		return await InsertToAsync(workspace.Document, ro, conflictPolicy, scaleByUnits, insPoint, blockName, removeJittering);
	}

	public async Task<BlockReference> InsertToAsync(Document document, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true, Point3D insPoint = null, string blockName = null, bool removeJittering = false)
	{
		return await document._0023_003DzVsWbKGE_003D(this, ro, conflictPolicy, scaleByUnits, insPoint, blockName, removeJittering);
	}

	public void AppendTo(IWorkspace workspace, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true)
	{
		AppendTo(workspace.Document, ro, conflictPolicy, scaleByUnits);
	}

	public void AppendTo(Document document, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true)
	{
		document._0023_003DzVpMLeQA_003D(this, ro, conflictPolicy, scaleByUnits);
	}

	public async Task AppendToAsync(IWorkspace workspace, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true)
	{
		await AppendToAsync(workspace.Document, ro, conflictPolicy, scaleByUnits);
	}

	public async Task AppendToAsync(Document document, RegenOptions ro = null, conflictPolicy conflictPolicy = conflictPolicy.Rename, bool scaleByUnits = true)
	{
		await document._0023_003DzYIDN7QA_003D(this, ro, conflictPolicy, scaleByUnits);
	}
}
