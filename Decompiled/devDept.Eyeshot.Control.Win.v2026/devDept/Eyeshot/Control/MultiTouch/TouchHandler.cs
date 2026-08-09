using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using devDept.Diagnostic;
using devDept.Eyeshot.Control.MultiTouch.Interop;

namespace devDept.Eyeshot.Control.MultiTouch;

public class TouchHandler : Handler
{
	private sealed class _0023_003DzIqnL3BxT661HiAmz0g_003D_003D : IEnumerable<TouchEventArgs>, IEnumerable, IEnumerator<TouchEventArgs>, IDisposable, IEnumerator
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003Dz0FVSO5LFyxyq;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TouchEventArgs _0023_003Dzn0gRlKh1Xs_0024z;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzhK4Sd_0024VE_xDr_0024T_0024T2w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IntPtr _0023_003DzuFliAOA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr _0023_003DzYm3nVSJjwBeKZdRiaQ_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private IntPtr _0023_003DzNAnADu0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IntPtr _0023_003DzYrGjBqW6s9zFoJS3Bg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _0023_003Dz4l1xEQk_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public float _0023_003Dzi8MkQNH3qftCej2Nuw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _0023_003Dz9Bea6Z0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public float _0023_003DzHX7zgFD2d7zOumKy3A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public TouchHandler _0023_003DzKdgtcDsi34jL;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzwPV0MsImQeY_1ksz6A_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private TOUCHINPUT[] _0023_003DzzH6eWPGuaDhIwZiF1w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _0023_003Dz7r25wI8lkERu7qc9UA_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private float _0023_003DzNdcufE7b6zqLqvxluw_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private int _0023_003DzfctcX3w4dNyi;

		[DebuggerHidden]
		public _0023_003DzIqnL3BxT661HiAmz0g_003D_003D(int _0023_003Dz0FVSO5LFyxyq)
		{
			this._0023_003Dz0FVSO5LFyxyq = _0023_003Dz0FVSO5LFyxyq;
			_0023_003DzhK4Sd_0024VE_xDr_0024T_0024T2w_003D_003D = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		private void _0023_003DztGebTB5LtngkpFRyVA_003D_003D()
		{
			int num = _0023_003Dz0FVSO5LFyxyq;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_0023_003Dzgzpm002EvoZ_rL1qrg_003D_003D();
				}
			}
			_0023_003DzzH6eWPGuaDhIwZiF1w_003D_003D = null;
			_0023_003Dz0FVSO5LFyxyq = -2;
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=ztGebTB5LtngkpFRyVA==
			this._0023_003DztGebTB5LtngkpFRyVA_003D_003D();
		}

		private bool MoveNext()
		{
			try
			{
				int num = _0023_003Dz0FVSO5LFyxyq;
				TouchHandler touchHandler = _0023_003DzKdgtcDsi34jL;
				switch (num)
				{
				default:
					return false;
				case 0:
					_0023_003Dz0FVSO5LFyxyq = -1;
					_0023_003DzwPV0MsImQeY_1ksz6A_003D_003D = _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzizbxK0cPigbL(_0023_003DzuFliAOA_003D.ToInt32());
					_0023_003DzzH6eWPGuaDhIwZiF1w_003D_003D = new TOUCHINPUT[_0023_003DzwPV0MsImQeY_1ksz6A_003D_003D];
					_0023_003Dz0FVSO5LFyxyq = -3;
					if (!_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzLR17p7FVRk5L(_0023_003DzNAnADu0_003D, _0023_003DzwPV0MsImQeY_1ksz6A_003D_003D, _0023_003DzzH6eWPGuaDhIwZiF1w_003D_003D, Marshal.SizeOf(_0023_003DzzH6eWPGuaDhIwZiF1w_003D_003D[0])))
					{
						string message = _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348587200);
						Logger.Instance.Error(message, null, Array.Empty<object>());
						throw new Exception(message);
					}
					_0023_003Dz7r25wI8lkERu7qc9UA_003D_003D = _0023_003Dz4l1xEQk_003D;
					_0023_003DzNdcufE7b6zqLqvxluw_003D_003D = _0023_003Dz9Bea6Z0_003D;
					_0023_003DzfctcX3w4dNyi = 0;
					break;
				case 1:
					_0023_003Dz0FVSO5LFyxyq = -3;
					_0023_003DzfctcX3w4dNyi++;
					break;
				}
				if (_0023_003DzfctcX3w4dNyi < _0023_003DzwPV0MsImQeY_1ksz6A_003D_003D)
				{
					TouchEventArgs e = new TouchEventArgs(touchHandler._0023_003Dzh7DXocqFKQyn(), _0023_003Dz7r25wI8lkERu7qc9UA_003D_003D, _0023_003DzNdcufE7b6zqLqvxluw_003D_003D, ref _0023_003DzzH6eWPGuaDhIwZiF1w_003D_003D[_0023_003DzfctcX3w4dNyi]);
					_0023_003Dzn0gRlKh1Xs_0024z = e;
					_0023_003Dz0FVSO5LFyxyq = 1;
					return true;
				}
				_0023_003Dzgzpm002EvoZ_rL1qrg_003D_003D();
				return false;
			}
			catch
			{
				//try-fault
				_0023_003DztGebTB5LtngkpFRyVA_003D_003D();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _0023_003Dzgzpm002EvoZ_rL1qrg_003D_003D()
		{
			_0023_003Dz0FVSO5LFyxyq = -1;
			_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzQucVDhM6LxTEPEgZKQ_003D_003D(_0023_003DzNAnADu0_003D);
		}

		[DebuggerHidden]
		private TouchEventArgs _0023_003DzByF0Ds_Avo9fOKIaX0gyAdyGP7otNuVs9_0024l_0024Shl7amvnb2z7_00246I014MYT7_002486pcaIg_003D_003D()
		{
			return _0023_003Dzn0gRlKh1Xs_0024z;
		}

		TouchEventArgs IEnumerator<TouchEventArgs>.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zByF0Ds_Avo9fOKIaX0gyAdyGP7otNuVs9$l$Shl7amvnb2z7$6I014MYT7$86pcaIg==
			return this._0023_003DzByF0Ds_Avo9fOKIaX0gyAdyGP7otNuVs9_0024l_0024Shl7amvnb2z7_00246I014MYT7_002486pcaIg_003D_003D();
		}

		[DebuggerHidden]
		private void _0023_003DzSJDwxsp_0024EPiLsdD2FQ_003D_003D()
		{
			throw new NotSupportedException();
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zSJDwxsp$EPiLsdD2FQ==
			this._0023_003DzSJDwxsp_0024EPiLsdD2FQ_003D_003D();
		}

		[DebuggerHidden]
		private object _0023_003DzmzmoZTP_0024PubEDyNMJew_S2I_003D()
		{
			return _0023_003Dzn0gRlKh1Xs_0024z;
		}

		object IEnumerator.get_Current()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zmzmoZTP$PubEDyNMJew_S2I=
			return this._0023_003DzmzmoZTP_0024PubEDyNMJew_S2I_003D();
		}

		[DebuggerHidden]
		private IEnumerator<TouchEventArgs> _0023_003Dz5Y0bBTs_0024ULkK2ZjgQci6Q_0024ts9zKy6cih9YnDZILCbfkCjA2Zevq_BuZ6ZIqtECDQgw_003D_003D()
		{
			_0023_003DzIqnL3BxT661HiAmz0g_003D_003D _0023_003DzIqnL3BxT661HiAmz0g_003D_003D2;
			if (_0023_003Dz0FVSO5LFyxyq == -2 && _0023_003DzhK4Sd_0024VE_xDr_0024T_0024T2w_003D_003D == Environment.CurrentManagedThreadId)
			{
				_0023_003Dz0FVSO5LFyxyq = 0;
				_0023_003DzIqnL3BxT661HiAmz0g_003D_003D2 = this;
			}
			else
			{
				_0023_003DzIqnL3BxT661HiAmz0g_003D_003D2 = new _0023_003DzIqnL3BxT661HiAmz0g_003D_003D(0);
				_0023_003DzIqnL3BxT661HiAmz0g_003D_003D2._0023_003DzKdgtcDsi34jL = _0023_003DzKdgtcDsi34jL;
			}
			_0023_003DzIqnL3BxT661HiAmz0g_003D_003D2._0023_003DzuFliAOA_003D = _0023_003DzYm3nVSJjwBeKZdRiaQ_003D_003D;
			_0023_003DzIqnL3BxT661HiAmz0g_003D_003D2._0023_003DzNAnADu0_003D = _0023_003DzYrGjBqW6s9zFoJS3Bg_003D_003D;
			_0023_003DzIqnL3BxT661HiAmz0g_003D_003D2._0023_003Dz4l1xEQk_003D = _0023_003Dzi8MkQNH3qftCej2Nuw_003D_003D;
			_0023_003DzIqnL3BxT661HiAmz0g_003D_003D2._0023_003Dz9Bea6Z0_003D = _0023_003DzHX7zgFD2d7zOumKy3A_003D_003D;
			return _0023_003DzIqnL3BxT661HiAmz0g_003D_003D2;
		}

		IEnumerator<TouchEventArgs> IEnumerable<TouchEventArgs>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=z5Y0bBTs$ULkK2ZjgQci6Q$ts9zKy6cih9YnDZILCbfkCjA2Zevq_BuZ6ZIqtECDQgw==
			return this._0023_003Dz5Y0bBTs_0024ULkK2ZjgQci6Q_0024ts9zKy6cih9YnDZILCbfkCjA2Zevq_BuZ6ZIqtECDQgw_003D_003D();
		}

		[DebuggerHidden]
		private IEnumerator _0023_003DzJVmfuxvyPUS91uHSAPj3GTo_003D()
		{
			return _0023_003Dz5Y0bBTs_0024ULkK2ZjgQci6Q_0024ts9zKy6cih9YnDZILCbfkCjA2Zevq_BuZ6ZIqtECDQgw_003D_003D();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in #=zJVmfuxvyPUS91uHSAPj3GTo=
			return this._0023_003DzJVmfuxvyPUS91uHSAPj3GTo_003D();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Workspace _0023_003Dz6YhGl3hahvr6ucgvqA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzAUOGfKta5TnympyyosHNpAiStx_Y;

	protected internal Workspace ParentWF
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz6YhGl3hahvr6ucgvqA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz6YhGl3hahvr6ucgvqA_003D_003D = value;
		}
	}

	public bool DisablePalmRejection
	{
		get
		{
			return _0023_003DzAUOGfKta5TnympyyosHNpAiStx_Y;
		}
		set
		{
			if (_0023_003DzAUOGfKta5TnympyyosHNpAiStx_Y != value)
			{
				_0023_003DzAUOGfKta5TnympyyosHNpAiStx_Y = value;
				if (_0023_003Dzh7DXocqFKQyn().IsHandleCreated)
				{
					_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003Dz42MuSQgUnZyd(_0023_003Dzh7DXocqFKQyn().Handle);
					SetHWndTouchInfo();
				}
			}
		}
	}

	public TouchHandler(IHwndWrapper hWndWrapper)
		: base(hWndWrapper)
	{
	}

	protected override bool SetHWndTouchInfo()
	{
		return _0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzQz7n5NebgFWF(base.ControlHandle, _0023_003DzAUOGfKta5TnympyyosHNpAiStx_Y ? ((_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzvHuFgA27z78J)2u) : ((_0023_003DzirAC6ze4AS4guYNendC5yZ5TMzkXpZGjVJvc00mAPC0v._0023_003DzvHuFgA27z78J)0u));
	}

	[DllImport("user32.dll", EntryPoint = "PostMessage")]
	private static extern bool _0023_003DztclwROA_003D(IntPtr _0023_003DzVg1BG_0024g_003D, uint _0023_003DzWHzRD4k_003D, IntPtr _0023_003DzuFliAOA_003D, IntPtr _0023_003DzNAnADu0_003D);

	[CLSCompliant(false)]
	protected override uint WindowProc(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
	{
		if (msg == 576)
		{
			foreach (TouchEventArgs item in _0023_003DzI7gK8ZY_003D(hWnd, msg, wparam, lparam, base.DpiX, base.DpiY))
			{
				if (ParentWF.MultiTouch.Enabled)
				{
					ParentWF._0023_003Dz9eDJ96xXX4Se(item);
				}
			}
			return 1u;
		}
		return 0u;
	}

	[IteratorStateMachine(typeof(_0023_003DzIqnL3BxT661HiAmz0g_003D_003D))]
	private IEnumerable<TouchEventArgs> _0023_003DzI7gK8ZY_003D(IntPtr _0023_003DzVg1BG_0024g_003D, int _0023_003Dz1xK0BLg_003D, IntPtr _0023_003DzuFliAOA_003D, IntPtr _0023_003DzNAnADu0_003D, float _0023_003Dz4l1xEQk_003D, float _0023_003Dz9Bea6Z0_003D)
	{
		return new _0023_003DzIqnL3BxT661HiAmz0g_003D_003D(-2)
		{
			_0023_003DzKdgtcDsi34jL = this,
			_0023_003DzYm3nVSJjwBeKZdRiaQ_003D_003D = _0023_003DzuFliAOA_003D,
			_0023_003DzYrGjBqW6s9zFoJS3Bg_003D_003D = _0023_003DzNAnADu0_003D,
			_0023_003Dzi8MkQNH3qftCej2Nuw_003D_003D = _0023_003Dz4l1xEQk_003D,
			_0023_003DzHX7zgFD2d7zOumKy3A_003D_003D = _0023_003Dz9Bea6Z0_003D
		};
	}
}
