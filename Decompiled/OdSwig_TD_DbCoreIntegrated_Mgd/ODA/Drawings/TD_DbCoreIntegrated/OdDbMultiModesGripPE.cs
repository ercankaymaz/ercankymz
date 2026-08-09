using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbMultiModesGripPE : OdRxObject
{
	public class GripMode : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public uint Mode
		{
			get
			{
				uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_Mode_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_Mode_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string DisplayString
		{
			get
			{
				string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_DisplayString_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_DisplayString_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string ToolTip
		{
			get
			{
				string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_ToolTip_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_ToolTip_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string CLIDisplayString
		{
			get
			{
				string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CLIDisplayString_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CLIDisplayString_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string CLIPromptString
		{
			get
			{
				string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CLIPromptString_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CLIPromptString_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string CLIKeywordList
		{
			get
			{
				string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CLIKeywordList_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CLIKeywordList_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdDbMultiModesGripPE_GripCursorType CursorType
		{
			get
			{
				int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CursorType_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdDbMultiModesGripPE_GripCursorType)result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CursorType_set(swigCPtr, (int)value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public OdDbMultiModesGripPE_GripActionType ActionType
		{
			get
			{
				int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_ActionType_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdDbMultiModesGripPE_GripActionType)result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_ActionType_set(swigCPtr, (int)value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public string CommandString
		{
			get
			{
				string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CommandString_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_GripMode_CommandString_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public GripMode(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(GripMode obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~GripMode()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			lock (this)
			{
				if (swigCPtr.Handle != IntPtr.Zero)
				{
					if (swigCMemOwn)
					{
						swigCMemOwn = false;
						TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbMultiModesGripPE_GripMode(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public GripMode()
			: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbMultiModesGripPE_GripMode(), cMemoryOwn: true)
		{
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdDbMultiModesGripPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbMultiModesGripPE_1();

	public delegate void SwigDelegateOdDbMultiModesGripPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdDbMultiModesGripPE_3(IntPtr pThis, IntPtr pGripData, IntPtr modes, uint curMode);

	public delegate uint SwigDelegateOdDbMultiModesGripPE_4(IntPtr pThis, IntPtr pGripData);

	public delegate IntPtr SwigDelegateOdDbMultiModesGripPE_5(IntPtr pThis, IntPtr pGripData);

	public delegate bool SwigDelegateOdDbMultiModesGripPE_6(IntPtr pThis, IntPtr pGripData, uint newMode);

	public delegate int SwigDelegateOdDbMultiModesGripPE_7(IntPtr pThis, IntPtr pGripData);

	public delegate void SwigDelegateOdDbMultiModesGripPE_8(IntPtr pThis);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbMultiModesGripPE_0 swigDelegate0;

	private SwigDelegateOdDbMultiModesGripPE_1 swigDelegate1;

	private SwigDelegateOdDbMultiModesGripPE_2 swigDelegate2;

	private SwigDelegateOdDbMultiModesGripPE_3 swigDelegate3;

	private SwigDelegateOdDbMultiModesGripPE_4 swigDelegate4;

	private SwigDelegateOdDbMultiModesGripPE_5 swigDelegate5;

	private SwigDelegateOdDbMultiModesGripPE_6 swigDelegate6;

	private SwigDelegateOdDbMultiModesGripPE_7 swigDelegate7;

	private SwigDelegateOdDbMultiModesGripPE_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdDbEntity),
		typeof(OdDbGripData),
		typeof(OdArray_OdDbMultiModesGripPE_GripMode_OdObjectsAllocator),
		typeof(uint).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDbGripData)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDbGripData)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdDbEntity),
		typeof(OdDbGripData),
		typeof(uint)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(OdDbEntity),
		typeof(OdDbGripData)
	};

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdDbEntity) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbMultiModesGripPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbMultiModesGripPE obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbMultiModesGripPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbMultiModesGripPE cast(OdRxObject pObj)
	{
		OdDbMultiModesGripPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMultiModesGripPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_isASwigExplicitOdDbMultiModesGripPE(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_queryXSwigExplicitOdDbMultiModesGripPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbMultiModesGripPE createObject()
	{
		OdDbMultiModesGripPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbMultiModesGripPE>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool getGripModes(OdDbEntity pThis, OdDbGripData pGripData, OdArray_OdDbMultiModesGripPE_GripMode_OdObjectsAllocator modes, out uint curMode)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_getGripModes(swigCPtr, OdDbEntity.getCPtr(pThis), OdDbGripData.getCPtr(pGripData), OdArray_OdDbMultiModesGripPE_GripMode_OdObjectsAllocator.getCPtr(modes), out curMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint mode(OdDbEntity pThis, OdDbGripData pGripData)
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_mode(swigCPtr, OdDbEntity.getCPtr(pThis), OdDbGripData.getCPtr(pGripData));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual GripMode modeEx(OdDbEntity pThis, OdDbGripData pGripData)
	{
		GripMode result = new GripMode(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_modeEx(swigCPtr, OdDbEntity.getCPtr(pThis), OdDbGripData.getCPtr(pGripData)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool setMode(OdDbEntity pThis, OdDbGripData pGripData, uint newMode)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_setMode(swigCPtr, OdDbEntity.getCPtr(pThis), OdDbGripData.getCPtr(pGripData), newMode);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbMultiModesGripPE_GripType gripType(OdDbEntity pThis, OdDbGripData pGripData)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_gripType(swigCPtr, OdDbEntity.getCPtr(pThis), OdDbGripData.getCPtr(pGripData));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdDbMultiModesGripPE_GripType)result;
	}

	public virtual void reset(OdDbEntity pThis)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_reset(swigCPtr, OdDbEntity.getCPtr(pThis));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbMultiModesGripPE()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbMultiModesGripPE(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbMultiModesGripPE) != GetType();
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
		if (SwigDerivedClassHasMethod("getGripModes", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetGripModes;
		}
		if (SwigDerivedClassHasMethod("mode", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodmode;
		}
		if (SwigDerivedClassHasMethod("modeEx", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodmodeEx;
		}
		if (SwigDerivedClassHasMethod("setMode", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetMode;
		}
		if (SwigDerivedClassHasMethod("gripType", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgripType;
		}
		if (SwigDerivedClassHasMethod("reset", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodreset;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbMultiModesGripPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbMultiModesGripPE));
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

	private bool SwigDirectorMethodgetGripModes(IntPtr pThis, IntPtr pGripData, IntPtr modes, uint curMode)
	{
		return getGripModes(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThis, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbGripData>(pGripData, bOwn: false, bTryAddToTransaction: false), new OdArray_OdDbMultiModesGripPE_GripMode_OdObjectsAllocator(modes, cMemoryOwn: false), out curMode);
	}

	private uint SwigDirectorMethodmode(IntPtr pThis, IntPtr pGripData)
	{
		return mode(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThis, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbGripData>(pGripData, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodmodeEx(IntPtr pThis, IntPtr pGripData)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return GripMode.getCPtr(modeEx(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThis, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbGripData>(pGripData, bOwn: false, bTryAddToTransaction: false))).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private bool SwigDirectorMethodsetMode(IntPtr pThis, IntPtr pGripData, uint newMode)
	{
		return setMode(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThis, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbGripData>(pGripData, bOwn: false, bTryAddToTransaction: false), newMode);
	}

	private int SwigDirectorMethodgripType(IntPtr pThis, IntPtr pGripData)
	{
		return (int)gripType(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThis, bOwn: false, bTryAddToTransaction: false), ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdDbGripData>(pGripData, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodreset(IntPtr pThis)
	{
		try
		{
			reset(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEntity>(pThis, bOwn: false, bTryAddToTransaction: false));
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
