using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxThreadPoolService : OdRxModule
{
	public delegate IntPtr SwigDelegateOdRxThreadPoolService_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_1();

	public delegate void SwigDelegateOdRxThreadPoolService_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_3();

	public delegate void SwigDelegateOdRxThreadPoolService_4();

	public delegate void SwigDelegateOdRxThreadPoolService_5();

	public delegate void SwigDelegateOdRxThreadPoolService_6();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdRxThreadPoolService_7();

	public delegate int SwigDelegateOdRxThreadPoolService_8();

	public delegate int SwigDelegateOdRxThreadPoolService_9();

	public delegate int SwigDelegateOdRxThreadPoolService_10();

	public delegate int SwigDelegateOdRxThreadPoolService_11();

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_12();

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_13(uint nThreadAttributes, uint nFlags);

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_14(uint nThreadAttributes);

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_15();

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_16(uint nThreadAttributes, int numThreads, uint nFlags);

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_17(uint nThreadAttributes, int numThreads);

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_18(uint nThreadAttributes);

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_19();

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_20();

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_21();

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_22();

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_23();

	public delegate void SwigDelegateOdRxThreadPoolService_24(IntPtr mtFunc, IntPtr pArg);

	public delegate void SwigDelegateOdRxThreadPoolService_25(uint nThreads, IntPtr aThreads, uint nThreadAttribs);

	public delegate void SwigDelegateOdRxThreadPoolService_26(uint nThreads, IntPtr aThreads);

	public delegate void SwigDelegateOdRxThreadPoolService_27(uint nThreads, IntPtr aThreads);

	public delegate void SwigDelegateOdRxThreadPoolService_28();

	public delegate void SwigDelegateOdRxThreadPoolService_29();

	public delegate void SwigDelegateOdRxThreadPoolService_30(IntPtr execFunc);

	public delegate IntPtr SwigDelegateOdRxThreadPoolService_31();

	public delegate uint SwigDelegateOdRxThreadPoolService_32();

	public delegate uint SwigDelegateOdRxThreadPoolService_33();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRxThreadPoolService_0 swigDelegate0;

	private SwigDelegateOdRxThreadPoolService_1 swigDelegate1;

	private SwigDelegateOdRxThreadPoolService_2 swigDelegate2;

	private SwigDelegateOdRxThreadPoolService_3 swigDelegate3;

	private SwigDelegateOdRxThreadPoolService_4 swigDelegate4;

	private SwigDelegateOdRxThreadPoolService_5 swigDelegate5;

	private SwigDelegateOdRxThreadPoolService_6 swigDelegate6;

	private SwigDelegateOdRxThreadPoolService_7 swigDelegate7;

	private SwigDelegateOdRxThreadPoolService_8 swigDelegate8;

	private SwigDelegateOdRxThreadPoolService_9 swigDelegate9;

	private SwigDelegateOdRxThreadPoolService_10 swigDelegate10;

	private SwigDelegateOdRxThreadPoolService_11 swigDelegate11;

	private SwigDelegateOdRxThreadPoolService_12 swigDelegate12;

	private SwigDelegateOdRxThreadPoolService_13 swigDelegate13;

	private SwigDelegateOdRxThreadPoolService_14 swigDelegate14;

	private SwigDelegateOdRxThreadPoolService_15 swigDelegate15;

	private SwigDelegateOdRxThreadPoolService_16 swigDelegate16;

	private SwigDelegateOdRxThreadPoolService_17 swigDelegate17;

	private SwigDelegateOdRxThreadPoolService_18 swigDelegate18;

	private SwigDelegateOdRxThreadPoolService_19 swigDelegate19;

	private SwigDelegateOdRxThreadPoolService_20 swigDelegate20;

	private SwigDelegateOdRxThreadPoolService_21 swigDelegate21;

	private SwigDelegateOdRxThreadPoolService_22 swigDelegate22;

	private SwigDelegateOdRxThreadPoolService_23 swigDelegate23;

	private SwigDelegateOdRxThreadPoolService_24 swigDelegate24;

	private SwigDelegateOdRxThreadPoolService_25 swigDelegate25;

	private SwigDelegateOdRxThreadPoolService_26 swigDelegate26;

	private SwigDelegateOdRxThreadPoolService_27 swigDelegate27;

	private SwigDelegateOdRxThreadPoolService_28 swigDelegate28;

	private SwigDelegateOdRxThreadPoolService_29 swigDelegate29;

	private SwigDelegateOdRxThreadPoolService_30 swigDelegate30;

	private SwigDelegateOdRxThreadPoolService_31 swigDelegate31;

	private SwigDelegateOdRxThreadPoolService_32 swigDelegate32;

	private SwigDelegateOdRxThreadPoolService_33 swigDelegate33;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[3]
	{
		typeof(uint),
		typeof(int),
		typeof(uint)
	};

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(uint),
		typeof(int)
	};

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[2]
	{
		typeof(TD_RootIntegrated_Globals.MainThreadFuncDelegate),
		typeof(IntPtr)
	};

	private static Type[] swigMethodTypes25 = new Type[3]
	{
		typeof(uint),
		typeof(uint[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes26 = new Type[2]
	{
		typeof(uint),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes27 = new Type[2]
	{
		typeof(uint),
		typeof(uint[])
	};

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[1] { typeof(TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate) };

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxThreadPoolService(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxThreadPoolService obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxThreadPoolService(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxThreadPoolService cast(OdRxObject pObj)
	{
		OdRxThreadPoolService rXObject = Helpers.GetRXObject<OdRxThreadPoolService>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_isASwigExplicitOdRxThreadPoolService(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_queryXSwigExplicitOdRxThreadPoolService(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxThreadPoolService createObject()
	{
		OdRxThreadPoolService rXObject = Helpers.GetRXObject<OdRxThreadPoolService>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int numCPUs()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_numCPUs(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int numPhysicalCores()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_numPhysicalCores(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int numThreads()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_numThreads(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int numFreeThreads()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_numFreeThreads(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdApcThread newThread()
	{
		OdApcThread rXObject = Helpers.GetRXObject<OdApcThread>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newThread(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcQueue newSTQueue(uint nThreadAttributes, uint nFlags)
	{
		OdApcQueue rXObject = Helpers.GetRXObject<OdApcQueue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newSTQueue__SWIG_0(swigCPtr, nThreadAttributes, nFlags), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcQueue newSTQueue(uint nThreadAttributes)
	{
		OdApcQueue rXObject = Helpers.GetRXObject<OdApcQueue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newSTQueue__SWIG_1(swigCPtr, nThreadAttributes), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcQueue newSTQueue()
	{
		OdApcQueue rXObject = Helpers.GetRXObject<OdApcQueue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newSTQueue__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcQueue newMTQueue(uint nThreadAttributes, int numThreads, uint nFlags)
	{
		OdApcQueue rXObject = Helpers.GetRXObject<OdApcQueue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newMTQueue__SWIG_0(swigCPtr, nThreadAttributes, numThreads, nFlags), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcQueue newMTQueue(uint nThreadAttributes, int numThreads)
	{
		OdApcQueue rXObject = Helpers.GetRXObject<OdApcQueue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newMTQueue__SWIG_1(swigCPtr, nThreadAttributes, numThreads), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcQueue newMTQueue(uint nThreadAttributes)
	{
		OdApcQueue rXObject = Helpers.GetRXObject<OdApcQueue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newMTQueue__SWIG_2(swigCPtr, nThreadAttributes), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcQueue newMTQueue()
	{
		OdApcQueue rXObject = Helpers.GetRXObject<OdApcQueue>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newMTQueue__SWIG_3(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcObjectPool newObjectPool()
	{
		OdApcObjectPool rXObject = Helpers.GetRXObject<OdApcObjectPool>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newObjectPool(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcEvent newEvent()
	{
		OdApcEvent rXObject = Helpers.GetRXObject<OdApcEvent>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newEvent(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcGateway newGateway()
	{
		OdApcGateway rXObject = Helpers.GetRXObject<OdApcGateway>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newGateway(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdApcLoopedGateway newLoopedGateway()
	{
		OdApcLoopedGateway rXObject = Helpers.GetRXObject<OdApcLoopedGateway>(TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_newLoopedGateway(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void executeMainThreadAction(TD_RootIntegrated_Globals.MainThreadFuncDelegate mtFunc, IntPtr pArg)
	{
		TD_RootIntegrated_Globals.MainThreadFuncDelegateNative mainThreadFuncDelegateNative = null;
		if (mtFunc != null)
		{
			mainThreadFuncDelegateNative = delegate(IntPtr arg1)
			{
				mtFunc(arg1);
			};
		}
		IntPtr jarg = ((mtFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(mainThreadFuncDelegateNative));
		DelegateHolder.Add(mainThreadFuncDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_executeMainThreadAction(swigCPtr, jarg, pArg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void registerExternalThreads(uint nThreads, uint[] aThreads, uint nThreadAttribs)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_registerExternalThreads__SWIG_0(swigCPtr, nThreads, Helpers.MarshalUInt32FixedArray(aThreads), nThreadAttribs);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void registerExternalThreads(uint nThreads, uint[] aThreads)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_registerExternalThreads__SWIG_1(swigCPtr, nThreads, Helpers.MarshalUInt32FixedArray(aThreads));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void unregisterExternalThreads(uint nThreads, uint[] aThreads)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_unregisterExternalThreads(swigCPtr, nThreads, Helpers.MarshalUInt32FixedArray(aThreads));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalThreadStart()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_externalThreadStart(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void externalThreadStop()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_externalThreadStop(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setExternalMainThreadFunc(TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate execFunc)
	{
		TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative executeMainThreadFuncDelegateNative = null;
		if (execFunc != null)
		{
			executeMainThreadFuncDelegateNative = delegate(TD_RootIntegrated_Globals.MainThreadFuncDelegateNative _func, IntPtr _arg)
			{
				TD_RootIntegrated_Globals.MainThreadFuncDelegate func = null;
				if (_func != null)
				{
					func = delegate(IntPtr __arg)
					{
						_func(__arg);
					};
				}
				execFunc(func, _arg);
			};
		}
		IntPtr jarg = ((execFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(executeMainThreadFuncDelegateNative));
		DelegateHolder.Add(executeMainThreadFuncDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_setExternalMainThreadFunc(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate getExternalMainThreadFunc()
	{
		IntPtr nativeCallback = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_getExternalMainThreadFunc(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate result = null;
		if (nativeCallback != IntPtr.Zero)
		{
			result = delegate(TD_RootIntegrated_Globals.MainThreadFuncDelegate _func, IntPtr _arg)
			{
				TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative obj = Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative)) as TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative;
				TD_RootIntegrated_Globals.MainThreadFuncDelegate func_csharpTemp = _func;
				TD_RootIntegrated_Globals.MainThreadFuncDelegateNative func = null;
				if (func_csharpTemp != null)
				{
					func = delegate(IntPtr __arg)
					{
						func_csharpTemp(__arg);
					};
				}
				obj(func, _arg);
			};
		}
		return result;
	}

	public virtual uint getMainThreadId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_getMainThreadId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getCurrentThreadId()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_getCurrentThreadId(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isMainThread()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_isMainThread(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxThreadPoolService()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxThreadPoolService(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxThreadPoolService) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("queryX", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodqueryX;
		}
		if (SwigDerivedClassHasMethod("isA", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodisA;
		}
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcopyFrom;
		}
		if (SwigDerivedClassHasMethod("sysData", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsysData;
		}
		if (SwigDerivedClassHasMethod("deleteModule", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddeleteModule;
		}
		if (SwigDerivedClassHasMethod("initApp", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodinitApp;
		}
		if (SwigDerivedClassHasMethod("uninitApp", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethoduninitApp;
		}
		if (SwigDerivedClassHasMethod("moduleName", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodmoduleName;
		}
		if (SwigDerivedClassHasMethod("numCPUs", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodnumCPUs;
		}
		if (SwigDerivedClassHasMethod("numPhysicalCores", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodnumPhysicalCores;
		}
		if (SwigDerivedClassHasMethod("numThreads", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodnumThreads;
		}
		if (SwigDerivedClassHasMethod("numFreeThreads", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodnumFreeThreads;
		}
		if (SwigDerivedClassHasMethod("newThread", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodnewThread;
		}
		if (SwigDerivedClassHasMethod("newSTQueue", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodnewSTQueue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("newSTQueue", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodnewSTQueue__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("newSTQueue", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodnewSTQueue__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("newMTQueue", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodnewMTQueue__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("newMTQueue", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodnewMTQueue__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("newMTQueue", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodnewMTQueue__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("newMTQueue", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodnewMTQueue__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("newObjectPool", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodnewObjectPool;
		}
		if (SwigDerivedClassHasMethod("newEvent", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodnewEvent;
		}
		if (SwigDerivedClassHasMethod("newGateway", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodnewGateway;
		}
		if (SwigDerivedClassHasMethod("newLoopedGateway", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodnewLoopedGateway;
		}
		if (SwigDerivedClassHasMethod("executeMainThreadAction", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodexecuteMainThreadAction;
		}
		if (SwigDerivedClassHasMethod("registerExternalThreads", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodregisterExternalThreads__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("registerExternalThreads", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodregisterExternalThreads__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("unregisterExternalThreads", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodunregisterExternalThreads;
		}
		if (SwigDerivedClassHasMethod("externalThreadStart", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodexternalThreadStart;
		}
		if (SwigDerivedClassHasMethod("externalThreadStop", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodexternalThreadStop;
		}
		if (SwigDerivedClassHasMethod("setExternalMainThreadFunc", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodsetExternalMainThreadFunc;
		}
		if (SwigDerivedClassHasMethod("getExternalMainThreadFunc", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodgetExternalMainThreadFunc;
		}
		if (SwigDerivedClassHasMethod("getMainThreadId", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodgetMainThreadId;
		}
		if (SwigDerivedClassHasMethod("getCurrentThreadId", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodgetCurrentThreadId;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxThreadPoolService_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxThreadPoolService));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodsysData()
	{
		return sysData();
	}

	private void SwigDirectorMethoddeleteModule()
	{
		try
		{
			deleteModule();
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodinitApp()
	{
		try
		{
			initApp();
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoduninitApp()
	{
		try
		{
			uninitApp();
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodmoduleName()
	{
		return moduleName();
	}

	private int SwigDirectorMethodnumCPUs()
	{
		return numCPUs();
	}

	private int SwigDirectorMethodnumPhysicalCores()
	{
		return numPhysicalCores();
	}

	private int SwigDirectorMethodnumThreads()
	{
		return numThreads();
	}

	private int SwigDirectorMethodnumFreeThreads()
	{
		return numFreeThreads();
	}

	private IntPtr SwigDirectorMethodnewThread()
	{
		return OdApcThread.getCPtr(newThread()).Handle;
	}

	private IntPtr SwigDirectorMethodnewSTQueue__SWIG_0(uint nThreadAttributes, uint nFlags)
	{
		return OdApcQueue.getCPtr(newSTQueue(nThreadAttributes, nFlags)).Handle;
	}

	private IntPtr SwigDirectorMethodnewSTQueue__SWIG_1(uint nThreadAttributes)
	{
		return OdApcQueue.getCPtr(newSTQueue(nThreadAttributes)).Handle;
	}

	private IntPtr SwigDirectorMethodnewSTQueue__SWIG_2()
	{
		return OdApcQueue.getCPtr(newSTQueue()).Handle;
	}

	private IntPtr SwigDirectorMethodnewMTQueue__SWIG_0(uint nThreadAttributes, int numThreads, uint nFlags)
	{
		return OdApcQueue.getCPtr(newMTQueue(nThreadAttributes, numThreads, nFlags)).Handle;
	}

	private IntPtr SwigDirectorMethodnewMTQueue__SWIG_1(uint nThreadAttributes, int numThreads)
	{
		return OdApcQueue.getCPtr(newMTQueue(nThreadAttributes, numThreads)).Handle;
	}

	private IntPtr SwigDirectorMethodnewMTQueue__SWIG_2(uint nThreadAttributes)
	{
		return OdApcQueue.getCPtr(newMTQueue(nThreadAttributes)).Handle;
	}

	private IntPtr SwigDirectorMethodnewMTQueue__SWIG_3()
	{
		return OdApcQueue.getCPtr(newMTQueue()).Handle;
	}

	private IntPtr SwigDirectorMethodnewObjectPool()
	{
		return OdApcObjectPool.getCPtr(newObjectPool()).Handle;
	}

	private IntPtr SwigDirectorMethodnewEvent()
	{
		return OdApcEvent.getCPtr(newEvent()).Handle;
	}

	private IntPtr SwigDirectorMethodnewGateway()
	{
		return OdApcGateway.getCPtr(newGateway()).Handle;
	}

	private IntPtr SwigDirectorMethodnewLoopedGateway()
	{
		return OdApcLoopedGateway.getCPtr(newLoopedGateway()).Handle;
	}

	private void SwigDirectorMethodexecuteMainThreadAction(IntPtr mtFunc, IntPtr pArg)
	{
		try
		{
			executeMainThreadAction(((Func<TD_RootIntegrated_Globals.MainThreadFuncDelegate>)delegate
			{
				IntPtr nativeCallback = mtFunc;
				TD_RootIntegrated_Globals.MainThreadFuncDelegate result = null;
				if (nativeCallback != IntPtr.Zero)
				{
					result = delegate(IntPtr arg1)
					{
						(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.MainThreadFuncDelegateNative)) as TD_RootIntegrated_Globals.MainThreadFuncDelegateNative)(arg1);
					};
				}
				return result;
			})(), pArg);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodregisterExternalThreads__SWIG_0(uint nThreads, IntPtr aThreads, uint nThreadAttribs)
	{
		try
		{
			registerExternalThreads(nThreads, Helpers.UnMarshalUInt32FixedArray(aThreads), nThreadAttribs);
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodregisterExternalThreads__SWIG_1(uint nThreads, IntPtr aThreads)
	{
		try
		{
			registerExternalThreads(nThreads, Helpers.UnMarshalUInt32FixedArray(aThreads));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodunregisterExternalThreads(uint nThreads, IntPtr aThreads)
	{
		try
		{
			unregisterExternalThreads(nThreads, Helpers.UnMarshalUInt32FixedArray(aThreads));
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodexternalThreadStart()
	{
		try
		{
			externalThreadStart();
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodexternalThreadStop()
	{
		try
		{
			externalThreadStop();
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetExternalMainThreadFunc(IntPtr execFunc)
	{
		try
		{
			setExternalMainThreadFunc(((Func<TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate>)delegate
			{
				IntPtr nativeCallback = execFunc;
				TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate result = null;
				if (nativeCallback != IntPtr.Zero)
				{
					result = delegate(TD_RootIntegrated_Globals.MainThreadFuncDelegate _func, IntPtr _arg)
					{
						TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative obj = Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative)) as TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegateNative;
						TD_RootIntegrated_Globals.MainThreadFuncDelegate func_csharpTemp = _func;
						TD_RootIntegrated_Globals.MainThreadFuncDelegateNative func = null;
						if (func_csharpTemp != null)
						{
							func = delegate(IntPtr __arg)
							{
								func_csharpTemp(__arg);
							};
						}
						obj(func, _arg);
					};
				}
				return result;
			})());
		}
		catch (OdEdEmptyInput err)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_RootIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodgetExternalMainThreadFunc()
	{
		return ((Func<IntPtr>)delegate
		{
			TD_RootIntegrated_Globals.ExecuteMainThreadFuncDelegate externalMainThreadFunc = getExternalMainThreadFunc();
			IntPtr result = ((externalMainThreadFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(externalMainThreadFunc));
			DelegateHolder.Add(externalMainThreadFunc);
			return result;
		})();
	}

	private uint SwigDirectorMethodgetMainThreadId()
	{
		return getMainThreadId();
	}

	private uint SwigDirectorMethodgetCurrentThreadId()
	{
		return getCurrentThreadId();
	}
}
