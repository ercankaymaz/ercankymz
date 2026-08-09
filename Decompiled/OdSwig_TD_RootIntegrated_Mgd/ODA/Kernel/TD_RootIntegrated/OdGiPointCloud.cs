using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPointCloud : OdRxObject
{
	public class Components : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdUInt8Array m_component
		{
			get
			{
				IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_Components_m_component_get(swigCPtr);
				OdUInt8Array result = ((intPtr == IntPtr.Zero) ? null : new OdUInt8Array(intPtr, cMemoryOwn: false));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_Components_m_component_set(swigCPtr, OdUInt8Array.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public uint m_nPoints
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_Components_m_nPoints_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_Components_m_nPoints_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Components(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Components obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Components()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloud_Components(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public bool hasComponent(int nComponent)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_Components_hasComponent(swigCPtr, nComponent);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public Components()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPointCloud_Components(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public class ComponentsRaw : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public OdRxObject m_pLockedObject
		{
			get
			{
				OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_m_pLockedObject_get(swigCPtr), bOwn: true, bTryAddToTransaction: true);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return rXObject;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_m_pLockedObject_set(swigCPtr, OdRxObject.getCPtr(value));
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public uint m_nPoints
		{
			get
			{
				uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_m_nPoints_get(swigCPtr);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_m_nPoints_set(swigCPtr, value);
				if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public ComponentsRaw(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(ComponentsRaw obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~ComponentsRaw()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloud_ComponentsRaw(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public bool hasComponent(int nComponent)
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_hasComponent(swigCPtr, nComponent);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw fromComponents(Components comps, uint components, OdRxObject pLockedObject)
		{
			ComponentsRaw result = new ComponentsRaw(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_fromComponents__SWIG_0(swigCPtr, Components.getCPtr(comps), components, OdRxObject.getCPtr(pLockedObject)), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw fromComponents(Components comps, uint components)
		{
			ComponentsRaw result = new ComponentsRaw(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_fromComponents__SWIG_1(swigCPtr, Components.getCPtr(comps), components), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw fromComponents(Components comps)
		{
			ComponentsRaw result = new ComponentsRaw(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_fromComponents__SWIG_2(swigCPtr, Components.getCPtr(comps)), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw construct(IntPtr pPoints, uint nPoints, IntPtr pColors, IntPtr pTransparencies, IntPtr pNormals, OdRxObject pLockedObject)
		{
			ComponentsRaw result = new ComponentsRaw(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_construct__SWIG_0(swigCPtr, pPoints, nPoints, pColors, pTransparencies, pNormals, OdRxObject.getCPtr(pLockedObject)), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw construct(IntPtr pPoints, uint nPoints, IntPtr pColors, IntPtr pTransparencies, IntPtr pNormals)
		{
			ComponentsRaw result = new ComponentsRaw(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_construct__SWIG_1(swigCPtr, pPoints, nPoints, pColors, pTransparencies, pNormals), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw construct(IntPtr pPoints, uint nPoints, IntPtr pColors, IntPtr pTransparencies)
		{
			ComponentsRaw result = new ComponentsRaw(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_construct__SWIG_2(swigCPtr, pPoints, nPoints, pColors, pTransparencies), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw construct(IntPtr pPoints, uint nPoints, IntPtr pColors)
		{
			ComponentsRaw result = new ComponentsRaw(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_construct__SWIG_3(swigCPtr, pPoints, nPoints, pColors), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw construct(IntPtr pPoints, uint nPoints)
		{
			ComponentsRaw result = new ComponentsRaw(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_ComponentsRaw_construct__SWIG_4(swigCPtr, pPoints, nPoints), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public ComponentsRaw()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPointCloud_ComponentsRaw(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdGiPointCloud_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiPointCloud_1();

	public delegate void SwigDelegateOdGiPointCloud_2(IntPtr pSource);

	public delegate uint SwigDelegateOdGiPointCloud_3();

	public delegate uint SwigDelegateOdGiPointCloud_4();

	public delegate uint SwigDelegateOdGiPointCloud_5(int component);

	public delegate uint SwigDelegateOdGiPointCloud_6();

	public delegate IntPtr SwigDelegateOdGiPointCloud_7();

	public delegate int SwigDelegateOdGiPointCloud_8();

	public delegate bool SwigDelegateOdGiPointCloud_9(IntPtr arg0);

	public delegate bool SwigDelegateOdGiPointCloud_10(IntPtr extents, IntPtr pFilter);

	public delegate bool SwigDelegateOdGiPointCloud_11(IntPtr extents);

	public delegate bool SwigDelegateOdGiPointCloud_12(IntPtr pVp1, IntPtr pVp2);

	public delegate bool SwigDelegateOdGiPointCloud_13(IntPtr pReceiver, uint components, uint flags, IntPtr pVp, IntPtr pVpFrom, uint pointSize, IntPtr pExternalScheduler);

	public delegate bool SwigDelegateOdGiPointCloud_14(IntPtr pReceiver, uint components, uint flags, IntPtr pVp, IntPtr pVpFrom, uint pointSize);

	public delegate bool SwigDelegateOdGiPointCloud_15(IntPtr pReceiver, uint components, uint flags, IntPtr pVp, IntPtr pVpFrom);

	public delegate bool SwigDelegateOdGiPointCloud_16(IntPtr pReceiver, uint components, uint flags, IntPtr pVp);

	public delegate bool SwigDelegateOdGiPointCloud_17(IntPtr pReceiver, uint components, uint flags);

	public delegate bool SwigDelegateOdGiPointCloud_18(IntPtr pReceiver, uint components);

	public delegate bool SwigDelegateOdGiPointCloud_19(IntPtr pReceiver);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiPointCloud_0 swigDelegate0;

	private SwigDelegateOdGiPointCloud_1 swigDelegate1;

	private SwigDelegateOdGiPointCloud_2 swigDelegate2;

	private SwigDelegateOdGiPointCloud_3 swigDelegate3;

	private SwigDelegateOdGiPointCloud_4 swigDelegate4;

	private SwigDelegateOdGiPointCloud_5 swigDelegate5;

	private SwigDelegateOdGiPointCloud_6 swigDelegate6;

	private SwigDelegateOdGiPointCloud_7 swigDelegate7;

	private SwigDelegateOdGiPointCloud_8 swigDelegate8;

	private SwigDelegateOdGiPointCloud_9 swigDelegate9;

	private SwigDelegateOdGiPointCloud_10 swigDelegate10;

	private SwigDelegateOdGiPointCloud_11 swigDelegate11;

	private SwigDelegateOdGiPointCloud_12 swigDelegate12;

	private SwigDelegateOdGiPointCloud_13 swigDelegate13;

	private SwigDelegateOdGiPointCloud_14 swigDelegate14;

	private SwigDelegateOdGiPointCloud_15 swigDelegate15;

	private SwigDelegateOdGiPointCloud_16 swigDelegate16;

	private SwigDelegateOdGiPointCloud_17 swigDelegate17;

	private SwigDelegateOdGiPointCloud_18 swigDelegate18;

	private SwigDelegateOdGiPointCloud_19 swigDelegate19;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiPointCloud_Component) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGeBoundBlock3d) };

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGeExtents3d),
		typeof(OdGiPointCloudFilter)
	};

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdGiViewport),
		typeof(OdGiViewport)
	};

	private static Type[] swigMethodTypes13 = new Type[7]
	{
		typeof(OdGiPointCloudReceiver),
		typeof(uint),
		typeof(uint),
		typeof(OdGiViewport),
		typeof(OdGiViewport),
		typeof(uint),
		typeof(OdGiPointCloudScheduler)
	};

	private static Type[] swigMethodTypes14 = new Type[6]
	{
		typeof(OdGiPointCloudReceiver),
		typeof(uint),
		typeof(uint),
		typeof(OdGiViewport),
		typeof(OdGiViewport),
		typeof(uint)
	};

	private static Type[] swigMethodTypes15 = new Type[5]
	{
		typeof(OdGiPointCloudReceiver),
		typeof(uint),
		typeof(uint),
		typeof(OdGiViewport),
		typeof(OdGiViewport)
	};

	private static Type[] swigMethodTypes16 = new Type[4]
	{
		typeof(OdGiPointCloudReceiver),
		typeof(uint),
		typeof(uint),
		typeof(OdGiViewport)
	};

	private static Type[] swigMethodTypes17 = new Type[3]
	{
		typeof(OdGiPointCloudReceiver),
		typeof(uint),
		typeof(uint)
	};

	private static Type[] swigMethodTypes18 = new Type[2]
	{
		typeof(OdGiPointCloudReceiver),
		typeof(uint)
	};

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(OdGiPointCloudReceiver) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiPointCloud(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPointCloud obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPointCloud(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public static uint addDataSizeFlags(ref uint pFlags, OdGiPointCloud_Component component, OdGiPointCloud_DataSize ds)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_addDataSizeFlags(ref pFlags, (int)component, (int)ds);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdGiPointCloud_DataSize getDataSizeFlags(uint flags, OdGiPointCloud_Component component)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_getDataSizeFlags(flags, (int)component);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiPointCloud_DataSize)result;
	}

	public static uint getDefaultDataSizeFlags()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_getDefaultDataSizeFlags();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiPointCloud cast(OdRxObject pObj)
	{
		OdGiPointCloud rXObject = Helpers.GetRXObject<OdGiPointCloud>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_isASwigExplicitOdGiPointCloud(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_queryXSwigExplicitOdGiPointCloud(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiPointCloud createObject()
	{
		OdGiPointCloud rXObject = Helpers.GetRXObject<OdGiPointCloud>(TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint totalPointsCount()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_totalPointsCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint componentsMask()
	{
		uint result = (SwigDerivedClassHasMethod("componentsMask", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_componentsMaskSwigExplicitOdGiPointCloud(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_componentsMask(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint supportFlags(OdGiPointCloud_Component component)
	{
		uint result = (SwigDerivedClassHasMethod("supportFlags", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_supportFlagsSwigExplicitOdGiPointCloud__SWIG_0(swigCPtr, (int)component) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_supportFlags__SWIG_0(swigCPtr, (int)component));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint supportFlags()
	{
		uint result = (SwigDerivedClassHasMethod("supportFlags", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_supportFlagsSwigExplicitOdGiPointCloud__SWIG_1(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_supportFlags__SWIG_1(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d globalTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(SwigDerivedClassHasMethod("globalTransform", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_globalTransformSwigExplicitOdGiPointCloud(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_globalTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int defaultPointSize()
	{
		int result = (SwigDerivedClassHasMethod("defaultPointSize", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_defaultPointSizeSwigExplicitOdGiPointCloud(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_defaultPointSize(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getExtents(OdGeBoundBlock3d arg0)
	{
		bool result = (SwigDerivedClassHasMethod("getExtents", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_getExtentsSwigExplicitOdGiPointCloud(swigCPtr, OdGeBoundBlock3d.getCPtr(arg0)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_getExtents(swigCPtr, OdGeBoundBlock3d.getCPtr(arg0)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool calculateExtents(OdGeExtents3d extents, OdGiPointCloudFilter pFilter)
	{
		bool result = (SwigDerivedClassHasMethod("calculateExtents", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_calculateExtentsSwigExplicitOdGiPointCloud__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extents), OdGiPointCloudFilter.getCPtr(pFilter)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_calculateExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(extents), OdGiPointCloudFilter.getCPtr(pFilter)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool calculateExtents(OdGeExtents3d extents)
	{
		bool result = (SwigDerivedClassHasMethod("calculateExtents", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_calculateExtentsSwigExplicitOdGiPointCloud__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(extents)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_calculateExtents__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(extents)));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isDataCompatible(OdGiViewport pVp1, OdGiViewport pVp2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_isDataCompatible(swigCPtr, OdGiViewport.getCPtr(pVp1), OdGiViewport.getCPtr(pVp2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool updatePointsData(OdGiPointCloudReceiver pReceiver, uint components, uint flags, OdGiViewport pVp, OdGiViewport pVpFrom, uint pointSize, OdGiPointCloudScheduler pExternalScheduler)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_updatePointsData__SWIG_0(swigCPtr, OdGiPointCloudReceiver.getCPtr(pReceiver), components, flags, OdGiViewport.getCPtr(pVp), OdGiViewport.getCPtr(pVpFrom), pointSize, OdGiPointCloudScheduler.getCPtr(pExternalScheduler));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool updatePointsData(OdGiPointCloudReceiver pReceiver, uint components, uint flags, OdGiViewport pVp, OdGiViewport pVpFrom, uint pointSize)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_updatePointsData__SWIG_1(swigCPtr, OdGiPointCloudReceiver.getCPtr(pReceiver), components, flags, OdGiViewport.getCPtr(pVp), OdGiViewport.getCPtr(pVpFrom), pointSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool updatePointsData(OdGiPointCloudReceiver pReceiver, uint components, uint flags, OdGiViewport pVp, OdGiViewport pVpFrom)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_updatePointsData__SWIG_2(swigCPtr, OdGiPointCloudReceiver.getCPtr(pReceiver), components, flags, OdGiViewport.getCPtr(pVp), OdGiViewport.getCPtr(pVpFrom));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool updatePointsData(OdGiPointCloudReceiver pReceiver, uint components, uint flags, OdGiViewport pVp)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_updatePointsData__SWIG_3(swigCPtr, OdGiPointCloudReceiver.getCPtr(pReceiver), components, flags, OdGiViewport.getCPtr(pVp));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool updatePointsData(OdGiPointCloudReceiver pReceiver, uint components, uint flags)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_updatePointsData__SWIG_4(swigCPtr, OdGiPointCloudReceiver.getCPtr(pReceiver), components, flags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool updatePointsData(OdGiPointCloudReceiver pReceiver, uint components)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_updatePointsData__SWIG_5(swigCPtr, OdGiPointCloudReceiver.getCPtr(pReceiver), components);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool updatePointsData(OdGiPointCloudReceiver pReceiver)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_updatePointsData__SWIG_6(swigCPtr, OdGiPointCloudReceiver.getCPtr(pReceiver));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("totalPointsCount", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodtotalPointsCount;
		}
		if (SwigDerivedClassHasMethod("componentsMask", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcomponentsMask;
		}
		if (SwigDerivedClassHasMethod("supportFlags", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsupportFlags__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("supportFlags", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsupportFlags__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("globalTransform", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodglobalTransform;
		}
		if (SwigDerivedClassHasMethod("defaultPointSize", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddefaultPointSize;
		}
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetExtents;
		}
		if (SwigDerivedClassHasMethod("calculateExtents", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcalculateExtents__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("calculateExtents", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcalculateExtents__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isDataCompatible", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodisDataCompatible;
		}
		if (SwigDerivedClassHasMethod("updatePointsData", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodupdatePointsData__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("updatePointsData", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodupdatePointsData__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("updatePointsData", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodupdatePointsData__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("updatePointsData", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodupdatePointsData__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("updatePointsData", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodupdatePointsData__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("updatePointsData", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodupdatePointsData__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("updatePointsData", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodupdatePointsData__SWIG_6;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPointCloud_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiPointCloud));
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

	private uint SwigDirectorMethodtotalPointsCount()
	{
		return totalPointsCount();
	}

	private uint SwigDirectorMethodcomponentsMask()
	{
		return componentsMask();
	}

	private uint SwigDirectorMethodsupportFlags__SWIG_0(int component)
	{
		return supportFlags((OdGiPointCloud_Component)component);
	}

	private uint SwigDirectorMethodsupportFlags__SWIG_1()
	{
		return supportFlags();
	}

	private IntPtr SwigDirectorMethodglobalTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(globalTransform()).Handle;
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

	private int SwigDirectorMethoddefaultPointSize()
	{
		return defaultPointSize();
	}

	private bool SwigDirectorMethodgetExtents(IntPtr arg0)
	{
		return getExtents(new OdGeBoundBlock3d(arg0, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodcalculateExtents__SWIG_0(IntPtr extents, IntPtr pFilter)
	{
		return calculateExtents(new OdGeExtents3d(extents, cMemoryOwn: false), Helpers.GetRXObject<OdGiPointCloudFilter>(pFilter, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodcalculateExtents__SWIG_1(IntPtr extents)
	{
		return calculateExtents(new OdGeExtents3d(extents, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisDataCompatible(IntPtr pVp1, IntPtr pVp2)
	{
		return isDataCompatible(Helpers.GetRXObject<OdGiViewport>(pVp1, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiViewport>(pVp2, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodupdatePointsData__SWIG_0(IntPtr pReceiver, uint components, uint flags, IntPtr pVp, IntPtr pVpFrom, uint pointSize, IntPtr pExternalScheduler)
	{
		return updatePointsData(Helpers.GetRXObject<OdGiPointCloudReceiver>(pReceiver, bOwn: false, bTryAddToTransaction: false), components, flags, Helpers.GetRXObject<OdGiViewport>(pVp, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiViewport>(pVpFrom, bOwn: false, bTryAddToTransaction: false), pointSize, (pExternalScheduler == IntPtr.Zero) ? null : new OdGiPointCloudScheduler(pExternalScheduler, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodupdatePointsData__SWIG_1(IntPtr pReceiver, uint components, uint flags, IntPtr pVp, IntPtr pVpFrom, uint pointSize)
	{
		return updatePointsData(Helpers.GetRXObject<OdGiPointCloudReceiver>(pReceiver, bOwn: false, bTryAddToTransaction: false), components, flags, Helpers.GetRXObject<OdGiViewport>(pVp, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiViewport>(pVpFrom, bOwn: false, bTryAddToTransaction: false), pointSize);
	}

	private bool SwigDirectorMethodupdatePointsData__SWIG_2(IntPtr pReceiver, uint components, uint flags, IntPtr pVp, IntPtr pVpFrom)
	{
		return updatePointsData(Helpers.GetRXObject<OdGiPointCloudReceiver>(pReceiver, bOwn: false, bTryAddToTransaction: false), components, flags, Helpers.GetRXObject<OdGiViewport>(pVp, bOwn: false, bTryAddToTransaction: false), Helpers.GetRXObject<OdGiViewport>(pVpFrom, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodupdatePointsData__SWIG_3(IntPtr pReceiver, uint components, uint flags, IntPtr pVp)
	{
		return updatePointsData(Helpers.GetRXObject<OdGiPointCloudReceiver>(pReceiver, bOwn: false, bTryAddToTransaction: false), components, flags, Helpers.GetRXObject<OdGiViewport>(pVp, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodupdatePointsData__SWIG_4(IntPtr pReceiver, uint components, uint flags)
	{
		return updatePointsData(Helpers.GetRXObject<OdGiPointCloudReceiver>(pReceiver, bOwn: false, bTryAddToTransaction: false), components, flags);
	}

	private bool SwigDirectorMethodupdatePointsData__SWIG_5(IntPtr pReceiver, uint components)
	{
		return updatePointsData(Helpers.GetRXObject<OdGiPointCloudReceiver>(pReceiver, bOwn: false, bTryAddToTransaction: false), components);
	}

	private bool SwigDirectorMethodupdatePointsData__SWIG_6(IntPtr pReceiver)
	{
		return updatePointsData(Helpers.GetRXObject<OdGiPointCloudReceiver>(pReceiver, bOwn: false, bTryAddToTransaction: false));
	}
}
