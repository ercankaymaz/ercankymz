using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdFileDependencyManager : OdRxObject
{
	public delegate IntPtr SwigDelegateOdFileDependencyManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdFileDependencyManager_1();

	public delegate void SwigDelegateOdFileDependencyManager_2(IntPtr pSource);

	public delegate uint SwigDelegateOdFileDependencyManager_3([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, bool affectsGraphics, bool noIncrement);

	public delegate uint SwigDelegateOdFileDependencyManager_4([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, bool affectsGraphics);

	public delegate uint SwigDelegateOdFileDependencyManager_5([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName);

	public delegate int SwigDelegateOdFileDependencyManager_6([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, IntPtr fileInfo, bool useCachedInfo);

	public delegate int SwigDelegateOdFileDependencyManager_7([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, IntPtr fileInfo);

	public delegate int SwigDelegateOdFileDependencyManager_8(uint fdlIndex, IntPtr fileInfo, bool useCachedInfo);

	public delegate int SwigDelegateOdFileDependencyManager_9(uint fdlIndex, IntPtr fileInfo);

	public delegate int SwigDelegateOdFileDependencyManager_10([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName);

	public delegate int SwigDelegateOdFileDependencyManager_11(uint index);

	public delegate int SwigDelegateOdFileDependencyManager_12([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, bool forceRemove);

	public delegate int SwigDelegateOdFileDependencyManager_13([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName);

	public delegate int SwigDelegateOdFileDependencyManager_14(uint fdlIndex, bool forceRemove);

	public delegate int SwigDelegateOdFileDependencyManager_15(uint fdlIndex);

	public delegate uint SwigDelegateOdFileDependencyManager_16();

	public delegate void SwigDelegateOdFileDependencyManager_17([MarshalAs(UnmanagedType.LPWStr)] string feature, bool modifiedOnly, bool affectsGraphicsOnly, bool walkXRefTree);

	public delegate void SwigDelegateOdFileDependencyManager_18([MarshalAs(UnmanagedType.LPWStr)] string feature, bool modifiedOnly, bool affectsGraphicsOnly);

	public delegate void SwigDelegateOdFileDependencyManager_19([MarshalAs(UnmanagedType.LPWStr)] string feature, bool modifiedOnly);

	public delegate void SwigDelegateOdFileDependencyManager_20([MarshalAs(UnmanagedType.LPWStr)] string feature);

	public delegate void SwigDelegateOdFileDependencyManager_21();

	public delegate uint SwigDelegateOdFileDependencyManager_22();

	public delegate void SwigDelegateOdFileDependencyManager_23(IntPtr features);

	public delegate void SwigDelegateOdFileDependencyManager_24();

	public delegate void SwigDelegateOdFileDependencyManager_25();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdFileDependencyManager_0 swigDelegate0;

	private SwigDelegateOdFileDependencyManager_1 swigDelegate1;

	private SwigDelegateOdFileDependencyManager_2 swigDelegate2;

	private SwigDelegateOdFileDependencyManager_3 swigDelegate3;

	private SwigDelegateOdFileDependencyManager_4 swigDelegate4;

	private SwigDelegateOdFileDependencyManager_5 swigDelegate5;

	private SwigDelegateOdFileDependencyManager_6 swigDelegate6;

	private SwigDelegateOdFileDependencyManager_7 swigDelegate7;

	private SwigDelegateOdFileDependencyManager_8 swigDelegate8;

	private SwigDelegateOdFileDependencyManager_9 swigDelegate9;

	private SwigDelegateOdFileDependencyManager_10 swigDelegate10;

	private SwigDelegateOdFileDependencyManager_11 swigDelegate11;

	private SwigDelegateOdFileDependencyManager_12 swigDelegate12;

	private SwigDelegateOdFileDependencyManager_13 swigDelegate13;

	private SwigDelegateOdFileDependencyManager_14 swigDelegate14;

	private SwigDelegateOdFileDependencyManager_15 swigDelegate15;

	private SwigDelegateOdFileDependencyManager_16 swigDelegate16;

	private SwigDelegateOdFileDependencyManager_17 swigDelegate17;

	private SwigDelegateOdFileDependencyManager_18 swigDelegate18;

	private SwigDelegateOdFileDependencyManager_19 swigDelegate19;

	private SwigDelegateOdFileDependencyManager_20 swigDelegate20;

	private SwigDelegateOdFileDependencyManager_21 swigDelegate21;

	private SwigDelegateOdFileDependencyManager_22 swigDelegate22;

	private SwigDelegateOdFileDependencyManager_23 swigDelegate23;

	private SwigDelegateOdFileDependencyManager_24 swigDelegate24;

	private SwigDelegateOdFileDependencyManager_25 swigDelegate25;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(string),
		typeof(string),
		typeof(OdFileDependencyInfo).MakeByRefType(),
		typeof(bool)
	};

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(OdFileDependencyInfo).MakeByRefType()
	};

	private static Type[] swigMethodTypes8 = new Type[3]
	{
		typeof(uint),
		typeof(OdFileDependencyInfo).MakeByRefType(),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(uint),
		typeof(OdFileDependencyInfo).MakeByRefType()
	};

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes12 = new Type[3]
	{
		typeof(string),
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(string),
		typeof(string)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[4]
	{
		typeof(string),
		typeof(bool),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes18 = new Type[3]
	{
		typeof(string),
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(OdRxDictionary).MakeByRefType() };

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFileDependencyManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFileDependencyManager obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdFileDependencyManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFileDependencyManager cast(OdRxObject pObj)
	{
		OdFileDependencyManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_isASwigExplicitOdFileDependencyManager(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_queryXSwigExplicitOdFileDependencyManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdFileDependencyManager createObject()
	{
		OdFileDependencyManager rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyManager>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdFileDependencyManager()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFileDependencyManager(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdFileDependencyManager) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual uint createEntry(string feature, string fullFileName, bool affectsGraphics, bool noIncrement)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_createEntry__SWIG_0(swigCPtr, feature, fullFileName, affectsGraphics, noIncrement);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint createEntry(string feature, string fullFileName, bool affectsGraphics)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_createEntry__SWIG_1(swigCPtr, feature, fullFileName, affectsGraphics);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint createEntry(string feature, string fullFileName)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_createEntry__SWIG_2(swigCPtr, feature, fullFileName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult getEntry(string feature, string fullFileName, ref OdFileDependencyInfo fileInfo, bool useCachedInfo)
	{
		IntPtr jarg = ((fileInfo == null) ? IntPtr.Zero : OdFileDependencyInfo.getCPtr(fileInfo).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_getEntry__SWIG_0(swigCPtr, feature, fullFileName, ref jarg, useCachedInfo);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				fileInfo = null;
			}
			else if (jarg != intPtr)
			{
				fileInfo = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyInfo>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getEntry(string feature, string fullFileName, ref OdFileDependencyInfo fileInfo)
	{
		IntPtr jarg = ((fileInfo == null) ? IntPtr.Zero : OdFileDependencyInfo.getCPtr(fileInfo).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_getEntry__SWIG_1(swigCPtr, feature, fullFileName, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				fileInfo = null;
			}
			else if (jarg != intPtr)
			{
				fileInfo = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyInfo>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getEntry(uint fdlIndex, ref OdFileDependencyInfo fileInfo, bool useCachedInfo)
	{
		IntPtr jarg = ((fileInfo == null) ? IntPtr.Zero : OdFileDependencyInfo.getCPtr(fileInfo).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_getEntry__SWIG_2(swigCPtr, fdlIndex, ref jarg, useCachedInfo);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				fileInfo = null;
			}
			else if (jarg != intPtr)
			{
				fileInfo = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyInfo>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult getEntry(uint fdlIndex, ref OdFileDependencyInfo fileInfo)
	{
		IntPtr jarg = ((fileInfo == null) ? IntPtr.Zero : OdFileDependencyInfo.getCPtr(fileInfo).Handle);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_getEntry__SWIG_3(swigCPtr, fdlIndex, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (OdResult)result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				fileInfo = null;
			}
			else if (jarg != intPtr)
			{
				fileInfo = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyInfo>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdResult updateEntry(string feature, string fullFileName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_updateEntry__SWIG_0(swigCPtr, feature, fullFileName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult updateEntry(uint index)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_updateEntry__SWIG_1(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult eraseEntry(string feature, string fullFileName, bool forceRemove)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_eraseEntry__SWIG_0(swigCPtr, feature, fullFileName, forceRemove);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult eraseEntry(string feature, string fullFileName)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_eraseEntry__SWIG_1(swigCPtr, feature, fullFileName);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult eraseEntry(uint fdlIndex, bool forceRemove)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_eraseEntry__SWIG_2(swigCPtr, fdlIndex, forceRemove);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult eraseEntry(uint fdlIndex)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_eraseEntry__SWIG_3(swigCPtr, fdlIndex);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual uint countEntries()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_countEntries(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void iteratorInitialize(string feature, bool modifiedOnly, bool affectsGraphicsOnly, bool walkXRefTree)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_iteratorInitialize__SWIG_0(swigCPtr, feature, modifiedOnly, affectsGraphicsOnly, walkXRefTree);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void iteratorInitialize(string feature, bool modifiedOnly, bool affectsGraphicsOnly)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_iteratorInitialize__SWIG_1(swigCPtr, feature, modifiedOnly, affectsGraphicsOnly);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void iteratorInitialize(string feature, bool modifiedOnly)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_iteratorInitialize__SWIG_2(swigCPtr, feature, modifiedOnly);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void iteratorInitialize(string feature)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_iteratorInitialize__SWIG_3(swigCPtr, feature);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void iteratorInitialize()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_iteratorInitialize__SWIG_4(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint iteratorNext()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_iteratorNext(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getFeatures(ref OdRxDictionary features)
	{
		IntPtr jarg = ((features == null) ? IntPtr.Zero : OdRxDictionary.getCPtr(features).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_getFeatures(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				features = null;
			}
			else if (jarg != intPtr)
			{
				features = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxDictionary>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual void clearXRefEntries()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_clearXRefEntries(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void iteratorUnInitialize()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_iteratorUnInitialize(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		if (SwigDerivedClassHasMethod("createEntry", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcreateEntry__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createEntry", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcreateEntry__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createEntry", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreateEntry__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getEntry", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetEntry__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getEntry", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetEntry__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getEntry", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetEntry__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getEntry", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetEntry__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("updateEntry", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodupdateEntry__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("updateEntry", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodupdateEntry__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("eraseEntry", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethoderaseEntry__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("eraseEntry", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethoderaseEntry__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("eraseEntry", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethoderaseEntry__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("eraseEntry", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethoderaseEntry__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("countEntries", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodcountEntries;
		}
		if (SwigDerivedClassHasMethod("iteratorInitialize", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethoditeratorInitialize__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("iteratorInitialize", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethoditeratorInitialize__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("iteratorInitialize", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethoditeratorInitialize__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("iteratorInitialize", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethoditeratorInitialize__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("iteratorInitialize", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethoditeratorInitialize__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("iteratorNext", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethoditeratorNext;
		}
		if (SwigDerivedClassHasMethod("getFeatures", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodgetFeatures;
		}
		if (SwigDerivedClassHasMethod("clearXRefEntries", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodclearXRefEntries;
		}
		if (SwigDerivedClassHasMethod("iteratorUnInitialize", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethoditeratorUnInitialize;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdFileDependencyManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdFileDependencyManager));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodcreateEntry__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, bool affectsGraphics, bool noIncrement)
	{
		return createEntry(feature, fullFileName, affectsGraphics, noIncrement);
	}

	private uint SwigDirectorMethodcreateEntry__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, bool affectsGraphics)
	{
		return createEntry(feature, fullFileName, affectsGraphics);
	}

	private uint SwigDirectorMethodcreateEntry__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName)
	{
		return createEntry(feature, fullFileName);
	}

	private int SwigDirectorMethodgetEntry__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, IntPtr fileInfo, bool useCachedInfo)
	{
		OdSwigDirectorHelper.director_UnpackData(fileInfo, out var pOriginalObject, out var pFunction);
		OdFileDependencyInfo fileInfo2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyInfo>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getEntry(feature, fullFileName, ref fileInfo2, useCachedInfo);
		}
		finally
		{
			IntPtr handle = OdFileDependencyInfo.getCPtr(fileInfo2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(fileInfo);
		}
	}

	private int SwigDirectorMethodgetEntry__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, IntPtr fileInfo)
	{
		OdSwigDirectorHelper.director_UnpackData(fileInfo, out var pOriginalObject, out var pFunction);
		OdFileDependencyInfo fileInfo2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyInfo>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getEntry(feature, fullFileName, ref fileInfo2);
		}
		finally
		{
			IntPtr handle = OdFileDependencyInfo.getCPtr(fileInfo2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(fileInfo);
		}
	}

	private int SwigDirectorMethodgetEntry__SWIG_2(uint fdlIndex, IntPtr fileInfo, bool useCachedInfo)
	{
		OdSwigDirectorHelper.director_UnpackData(fileInfo, out var pOriginalObject, out var pFunction);
		OdFileDependencyInfo fileInfo2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyInfo>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getEntry(fdlIndex, ref fileInfo2, useCachedInfo);
		}
		finally
		{
			IntPtr handle = OdFileDependencyInfo.getCPtr(fileInfo2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(fileInfo);
		}
	}

	private int SwigDirectorMethodgetEntry__SWIG_3(uint fdlIndex, IntPtr fileInfo)
	{
		OdSwigDirectorHelper.director_UnpackData(fileInfo, out var pOriginalObject, out var pFunction);
		OdFileDependencyInfo fileInfo2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFileDependencyInfo>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			return (int)getEntry(fdlIndex, ref fileInfo2);
		}
		finally
		{
			IntPtr handle = OdFileDependencyInfo.getCPtr(fileInfo2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(fileInfo);
		}
	}

	private int SwigDirectorMethodupdateEntry__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName)
	{
		return (int)updateEntry(feature, fullFileName);
	}

	private int SwigDirectorMethodupdateEntry__SWIG_1(uint index)
	{
		return (int)updateEntry(index);
	}

	private int SwigDirectorMethoderaseEntry__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName, bool forceRemove)
	{
		return (int)eraseEntry(feature, fullFileName, forceRemove);
	}

	private int SwigDirectorMethoderaseEntry__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string feature, [MarshalAs(UnmanagedType.LPWStr)] string fullFileName)
	{
		return (int)eraseEntry(feature, fullFileName);
	}

	private int SwigDirectorMethoderaseEntry__SWIG_2(uint fdlIndex, bool forceRemove)
	{
		return (int)eraseEntry(fdlIndex, forceRemove);
	}

	private int SwigDirectorMethoderaseEntry__SWIG_3(uint fdlIndex)
	{
		return (int)eraseEntry(fdlIndex);
	}

	private uint SwigDirectorMethodcountEntries()
	{
		return countEntries();
	}

	private void SwigDirectorMethoditeratorInitialize__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string feature, bool modifiedOnly, bool affectsGraphicsOnly, bool walkXRefTree)
	{
		try
		{
			iteratorInitialize(feature, modifiedOnly, affectsGraphicsOnly, walkXRefTree);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoditeratorInitialize__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string feature, bool modifiedOnly, bool affectsGraphicsOnly)
	{
		try
		{
			iteratorInitialize(feature, modifiedOnly, affectsGraphicsOnly);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoditeratorInitialize__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string feature, bool modifiedOnly)
	{
		try
		{
			iteratorInitialize(feature, modifiedOnly);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoditeratorInitialize__SWIG_3([MarshalAs(UnmanagedType.LPWStr)] string feature)
	{
		try
		{
			iteratorInitialize(feature);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoditeratorInitialize__SWIG_4()
	{
		try
		{
			iteratorInitialize();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethoditeratorNext()
	{
		return iteratorNext();
	}

	private void SwigDirectorMethodgetFeatures(IntPtr features)
	{
		OdSwigDirectorHelper.director_UnpackData(features, out var pOriginalObject, out var pFunction);
		OdRxDictionary features2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxDictionary>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			getFeatures(ref features2);
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
		finally
		{
			IntPtr handle = OdRxDictionary.getCPtr(features2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(features);
		}
	}

	private void SwigDirectorMethodclearXRefEntries()
	{
		try
		{
			clearXRefEntries();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethoditeratorUnInitialize()
	{
		try
		{
			iteratorUnInitialize();
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
