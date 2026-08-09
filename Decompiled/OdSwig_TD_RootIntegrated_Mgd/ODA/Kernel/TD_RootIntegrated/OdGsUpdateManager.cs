using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsUpdateManager : OdRxObject
{
	public class OdGsUpdateManagerElement : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OdGsUpdateManagerElement(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(OdGsUpdateManagerElement obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~OdGsUpdateManagerElement()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsUpdateManager_OdGsUpdateManagerElement(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public OdGsUpdateManagerElement()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsUpdateManager_OdGsUpdateManagerElement(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public byte state(uint vpId)
		{
			byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_OdGsUpdateManagerElement_state(swigCPtr, vpId);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setState(byte state, uint vpId)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_OdGsUpdateManagerElement_setState(swigCPtr, state, vpId);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class UpdateManagerSettings : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdGsUpdateManager_FiltrationType type
		{
			get
			{
				int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_UpdateManagerSettings_type_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return (OdGsUpdateManager_FiltrationType)result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_UpdateManagerSettings_type_set(swigCPtr, (int)value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public ulong nMemoryLimit
		{
			get
			{
				ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_UpdateManagerSettings_nMemoryLimit_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_UpdateManagerSettings_nMemoryLimit_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public ulong nMinMemoryLimit
		{
			get
			{
				ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_UpdateManagerSettings_nMinMemoryLimit_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_UpdateManagerSettings_nMinMemoryLimit_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public ulong nClientCurrentHeapUsage
		{
			get
			{
				ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_UpdateManagerSettings_nClientCurrentHeapUsage_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_UpdateManagerSettings_nClientCurrentHeapUsage_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UpdateManagerSettings(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(UpdateManagerSettings obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~UpdateManagerSettings()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsUpdateManager_UpdateManagerSettings(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public UpdateManagerSettings()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsUpdateManager_UpdateManagerSettings(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdGsUpdateManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGsUpdateManager_1();

	public delegate void SwigDelegateOdGsUpdateManager_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGsUpdateManager_3();

	public delegate void SwigDelegateOdGsUpdateManager_4(IntPtr arg0);

	public delegate void SwigDelegateOdGsUpdateManager_5(uint viewportId, IntPtr pNode, IntPtr pElement);

	public delegate void SwigDelegateOdGsUpdateManager_6(uint viewportId, IntPtr pNode, IntPtr pElement, ulong nLength, IntPtr pView, IntPtr extents, bool bSetZeroWeight);

	public delegate void SwigDelegateOdGsUpdateManager_7(uint viewportId, IntPtr pNode, IntPtr pElement, ulong nLength, IntPtr pView, IntPtr extents);

	public delegate void SwigDelegateOdGsUpdateManager_8(uint viewportId, IntPtr pNode, IntPtr pElement, ulong nLength);

	public delegate void SwigDelegateOdGsUpdateManager_9(IntPtr arg0);

	public delegate void SwigDelegateOdGsUpdateManager_10();

	public delegate void SwigDelegateOdGsUpdateManager_11();

	public delegate void SwigDelegateOdGsUpdateManager_12(uint viewportId, IntPtr pNode, IntPtr pElement);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsUpdateManager_0 swigDelegate0;

	private SwigDelegateOdGsUpdateManager_1 swigDelegate1;

	private SwigDelegateOdGsUpdateManager_2 swigDelegate2;

	private SwigDelegateOdGsUpdateManager_3 swigDelegate3;

	private SwigDelegateOdGsUpdateManager_4 swigDelegate4;

	private SwigDelegateOdGsUpdateManager_5 swigDelegate5;

	private SwigDelegateOdGsUpdateManager_6 swigDelegate6;

	private SwigDelegateOdGsUpdateManager_7 swigDelegate7;

	private SwigDelegateOdGsUpdateManager_8 swigDelegate8;

	private SwigDelegateOdGsUpdateManager_9 swigDelegate9;

	private SwigDelegateOdGsUpdateManager_10 swigDelegate10;

	private SwigDelegateOdGsUpdateManager_11 swigDelegate11;

	private SwigDelegateOdGsUpdateManager_12 swigDelegate12;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(UpdateManagerSettings) };

	private static Type[] swigMethodTypes5 = new Type[3]
	{
		typeof(uint),
		typeof(OdGsEntityNode),
		typeof(OdGsUpdateManagerElement)
	};

	private static Type[] swigMethodTypes6 = new Type[7]
	{
		typeof(uint),
		typeof(OdGsEntityNode),
		typeof(OdGsUpdateManagerElement),
		typeof(ulong),
		typeof(OdGsViewImpl),
		typeof(OdGeExtents3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes7 = new Type[6]
	{
		typeof(uint),
		typeof(OdGsEntityNode),
		typeof(OdGsUpdateManagerElement),
		typeof(ulong),
		typeof(OdGsViewImpl),
		typeof(OdGeExtents3d)
	};

	private static Type[] swigMethodTypes8 = new Type[4]
	{
		typeof(uint),
		typeof(OdGsEntityNode),
		typeof(OdGsUpdateManagerElement),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(TD_RootIntegrated_Globals.UpdateManagerProcessCallbackDelegate) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[3]
	{
		typeof(uint),
		typeof(OdGsEntityNode),
		typeof(OdGsUpdateManagerElement)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsUpdateManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsUpdateManager obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsUpdateManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGsUpdateManager cast(OdRxObject pObj)
	{
		OdGsUpdateManager rXObject = Helpers.GetRXObject<OdGsUpdateManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_isASwigExplicitOdGsUpdateManager(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_queryXSwigExplicitOdGsUpdateManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGsUpdateManager createObject()
	{
		OdGsUpdateManager rXObject = Helpers.GetRXObject<OdGsUpdateManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual UpdateManagerSettings settings()
	{
		UpdateManagerSettings result = new UpdateManagerSettings(TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_settings(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSettings(UpdateManagerSettings arg0)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_setSettings(swigCPtr, UpdateManagerSettings.getCPtr(arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addElement(uint viewportId, OdGsEntityNode pNode, OdGsUpdateManagerElement pElement)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_addElement__SWIG_0(swigCPtr, viewportId, OdGsEntityNode.getCPtr(pNode), OdGsUpdateManagerElement.getCPtr(pElement));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addElement(uint viewportId, OdGsEntityNode pNode, OdGsUpdateManagerElement pElement, ulong nLength, OdGsViewImpl pView, OdGeExtents3d extents, bool bSetZeroWeight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_addElement__SWIG_1(swigCPtr, viewportId, OdGsEntityNode.getCPtr(pNode), OdGsUpdateManagerElement.getCPtr(pElement), nLength, OdGsViewImpl.getCPtr(pView), OdGeExtents3d.getCPtr(extents), bSetZeroWeight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addElement(uint viewportId, OdGsEntityNode pNode, OdGsUpdateManagerElement pElement, ulong nLength, OdGsViewImpl pView, OdGeExtents3d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_addElement__SWIG_2(swigCPtr, viewportId, OdGsEntityNode.getCPtr(pNode), OdGsUpdateManagerElement.getCPtr(pElement), nLength, OdGsViewImpl.getCPtr(pView), OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addPriorityElement(uint viewportId, OdGsEntityNode pNode, OdGsUpdateManagerElement pElement, ulong nLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_addPriorityElement(swigCPtr, viewportId, OdGsEntityNode.getCPtr(pNode), OdGsUpdateManagerElement.getCPtr(pElement), nLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setProcessCallback(TD_RootIntegrated_Globals.UpdateManagerProcessCallbackDelegate arg0)
	{
		TD_RootIntegrated_Globals.UpdateManagerProcessCallbackDelegateNative updateManagerProcessCallbackDelegateNative = null;
		if (arg0 != null)
		{
			updateManagerProcessCallbackDelegateNative = delegate(OdGsUpdateManager_Action action, uint viewportId, IntPtr drawableId, IntPtr pNode, IntPtr pElement)
			{
				arg0(action, viewportId, OdMarshalHelper.PtrToObject<OdDbStub>(drawableId), OdMarshalHelper.PtrToObject<OdGsEntityNode>(pNode), OdMarshalHelper.PtrToObject<OdGsUpdateManagerElement>(pElement));
			};
		}
		IntPtr jarg = ((arg0 == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(updateManagerProcessCallbackDelegateNative));
		DelegateHolder.Add(updateManagerProcessCallbackDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_setProcessCallback(swigCPtr, jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void process()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_process(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void reset()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_reset(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void removeElement(uint viewportId, OdGsEntityNode pNode, OdGsUpdateManagerElement pElement)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_removeElement(swigCPtr, viewportId, OdGsEntityNode.getCPtr(pNode), OdGsUpdateManagerElement.getCPtr(pElement));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGsUpdateManager()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsUpdateManager(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsUpdateManager) != GetType();
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
		if (SwigDerivedClassHasMethod("settings", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsettings;
		}
		if (SwigDerivedClassHasMethod("setSettings", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetSettings;
		}
		if (SwigDerivedClassHasMethod("addElement", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodaddElement__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("addElement", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodaddElement__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("addElement", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodaddElement__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("addPriorityElement", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodaddPriorityElement;
		}
		if (SwigDerivedClassHasMethod("setProcessCallback", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetProcessCallback;
		}
		if (SwigDerivedClassHasMethod("process", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodprocess;
		}
		if (SwigDerivedClassHasMethod("reset", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodreset;
		}
		if (SwigDerivedClassHasMethod("removeElement", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodremoveElement;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsUpdateManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsUpdateManager));
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

	private IntPtr SwigDirectorMethodsettings()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return UpdateManagerSettings.getCPtr(settings()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetSettings(IntPtr arg0)
	{
		try
		{
			setSettings(new UpdateManagerSettings(arg0, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddElement__SWIG_0(uint viewportId, IntPtr pNode, IntPtr pElement)
	{
		try
		{
			addElement(viewportId, Helpers.GetRXObject<OdGsEntityNode>(pNode, bOwn: false, bTryAddToTransaction: false), (pElement == IntPtr.Zero) ? null : new OdGsUpdateManagerElement(pElement, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddElement__SWIG_1(uint viewportId, IntPtr pNode, IntPtr pElement, ulong nLength, IntPtr pView, IntPtr extents, bool bSetZeroWeight)
	{
		try
		{
			addElement(viewportId, Helpers.GetRXObject<OdGsEntityNode>(pNode, bOwn: false, bTryAddToTransaction: false), (pElement == IntPtr.Zero) ? null : new OdGsUpdateManagerElement(pElement, cMemoryOwn: false), nLength, Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false), new OdGeExtents3d(extents, cMemoryOwn: false), bSetZeroWeight);
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

	private void SwigDirectorMethodaddElement__SWIG_2(uint viewportId, IntPtr pNode, IntPtr pElement, ulong nLength, IntPtr pView, IntPtr extents)
	{
		try
		{
			addElement(viewportId, Helpers.GetRXObject<OdGsEntityNode>(pNode, bOwn: false, bTryAddToTransaction: false), (pElement == IntPtr.Zero) ? null : new OdGsUpdateManagerElement(pElement, cMemoryOwn: false), nLength, Helpers.GetRXObject<OdGsViewImpl>(pView, bOwn: false, bTryAddToTransaction: false), new OdGeExtents3d(extents, cMemoryOwn: false));
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

	private void SwigDirectorMethodaddPriorityElement(uint viewportId, IntPtr pNode, IntPtr pElement, ulong nLength)
	{
		try
		{
			addPriorityElement(viewportId, Helpers.GetRXObject<OdGsEntityNode>(pNode, bOwn: false, bTryAddToTransaction: false), (pElement == IntPtr.Zero) ? null : new OdGsUpdateManagerElement(pElement, cMemoryOwn: false), nLength);
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

	private void SwigDirectorMethodsetProcessCallback(IntPtr arg0)
	{
		try
		{
			setProcessCallback(((Func<TD_RootIntegrated_Globals.UpdateManagerProcessCallbackDelegate>)delegate
			{
				IntPtr nativeCallback = arg0;
				TD_RootIntegrated_Globals.UpdateManagerProcessCallbackDelegate result = null;
				if (nativeCallback != IntPtr.Zero)
				{
					result = delegate(OdGsUpdateManager_Action action, uint viewportId, OdDbStub drawableId, OdGsEntityNode pNode, OdGsUpdateManagerElement pElement)
					{
						(Marshal.GetDelegateForFunctionPointer(nativeCallback, typeof(TD_RootIntegrated_Globals.UpdateManagerProcessCallbackDelegateNative)) as TD_RootIntegrated_Globals.UpdateManagerProcessCallbackDelegateNative)(action, viewportId, OdMarshalHelper.ObjectToPtr<OdDbStub>(drawableId), OdMarshalHelper.ObjectToPtr<OdGsEntityNode>(pNode), OdMarshalHelper.ObjectToPtr<OdGsUpdateManagerElement>(pElement));
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

	private void SwigDirectorMethodprocess()
	{
		try
		{
			process();
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

	private void SwigDirectorMethodreset()
	{
		try
		{
			reset();
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

	private void SwigDirectorMethodremoveElement(uint viewportId, IntPtr pNode, IntPtr pElement)
	{
		try
		{
			removeElement(viewportId, Helpers.GetRXObject<OdGsEntityNode>(pNode, bOwn: false, bTryAddToTransaction: false), (pElement == IntPtr.Zero) ? null : new OdGsUpdateManagerElement(pElement, cMemoryOwn: false));
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
}
