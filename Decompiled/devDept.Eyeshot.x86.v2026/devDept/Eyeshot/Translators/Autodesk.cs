using System;
using System.Diagnostics;
using System.IO;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;
using devDept.Diagnostic;

namespace devDept.Eyeshot.Translators;

public static class Autodesk
{
	private static class _0023_003Dzf4WsBy0_003D
	{
		public static EventHandler _0023_003DzCKQWIR25UifuWAffKg_003D_003D;
	}

	private sealed class _0023_003DzsgLleiV_0g95UasGog_003D_003D : RxSystemServicesImpl
	{
		public _0023_003DzsgLleiV_0g95UasGog_003D_003D()
		{
			Type typeFromHandle = typeof(Document);
			object[] array = null;
			_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D _0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2 = null;
			Stream stream = null;
			bool flag = false;
			Exception ex = default(Exception);
			array = new object[2] { typeFromHandle, ex };
			_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2 = _0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003DzdzZLZbiwVTg1a0D6OXj_pZ7Vxsm1I1oH6u_0024_fyl4AGtqqQqxXQ_003D_003D();
			stream = _0023_003Dz59lijRsT8LI_0024XHJOQ_0024AIGNJAuo4Gno8YZbyXhC6NbIN90_6Sbg_003D_003D._0023_003Dz9h7prLD836B0_0024F42nFw7qcyRyorkXYYKZ0vX9bIws0q0ILDt6g_003D_003D();
			try
			{
				flag = (bool)_0023_003DqeT0OSI7BQiAkakglgmrHah29R0cJ2sPZGbWEHzx9sWs_003D2._0023_003DzIgKPz5OT94O_zSaBCYnBDdc_003D(stream, "V#C;mq\"ad5", array);
			}
			finally
			{
				ex = (Exception)array[1];
			}
			if (!flag)
			{
				ReadAutodesk._0023_003DzR4ocvc6x1MsH = 10.0;
			}
			TD_RootIntegrated_Globals.odActivate(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527650), _0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527617));
		}

		~_0023_003DzsgLleiV_0g95UasGog_003D_003D()
		{
			FreeServices();
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static object _0023_003DzrjnkDtYP4gq4 = new object();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static _0023_003DzsgLleiV_0g95UasGog_003D_003D _0023_003Dz3XHmKqe09a8A;

	public static void FreeServices()
	{
		if (_0023_003Dz3XHmKqe09a8A == null)
		{
			return;
		}
		_0023_003Dz3XHmKqe09a8A.Dispose();
		_0023_003Dz3XHmKqe09a8A = null;
		MemoryManager.GetMemoryManager().StopAll();
		try
		{
			TD_DbCoreIntegrated_Globals.odUninitialize();
		}
		catch (OdError odError)
		{
			Logger.Instance.Trace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529868) + odError.description());
		}
		finally
		{
			ODA.Kernel.TD_RootIntegrated.Helpers.odUninit();
		}
		Logger.Instance.Trace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529873));
	}

	public static void InitializeServices()
	{
		lock (_0023_003DzrjnkDtYP4gq4)
		{
			if (_0023_003Dz3XHmKqe09a8A == null)
			{
				_0023_003Dz3XHmKqe09a8A = new _0023_003DzsgLleiV_0g95UasGog_003D_003D();
				TD_DbCoreIntegrated_Globals.odInitialize(_0023_003Dz3XHmKqe09a8A);
				Logger.Instance.Trace(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355529926));
				AppDomain.CurrentDomain.ProcessExit += _0023_003DzrehPAWdoz83R;
				AppDomain.CurrentDomain.DomainUnload += _0023_003DzrehPAWdoz83R;
			}
		}
	}

	private static void _0023_003DzrehPAWdoz83R(object _0023_003DzXFtCr_0024w_003D, EventArgs _0023_003DzLaPeX80_003D)
	{
		AppDomain.CurrentDomain.ProcessExit -= _0023_003DzrehPAWdoz83R;
		AppDomain.CurrentDomain.DomainUnload -= _0023_003DzrehPAWdoz83R;
		FreeServices();
	}
}
