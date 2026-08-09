using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSectionGeometryManager : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiSectionGeometryManager_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSectionGeometryManager_1();

	public delegate void SwigDelegateOdGiSectionGeometryManager_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiSectionGeometryManager_3(IntPtr layoutId, IntPtr sectionSettingsId);

	public delegate IntPtr SwigDelegateOdGiSectionGeometryManager_4(IntPtr pDb, IntPtr visualStyleId, IntPtr points, IntPtr verticalDir, IntPtr dTop, IntPtr dBottom);

	public delegate IntPtr SwigDelegateOdGiSectionGeometryManager_5(IntPtr pDb, IntPtr visualStyleId, IntPtr points, IntPtr verticalDir, IntPtr dTop);

	public delegate IntPtr SwigDelegateOdGiSectionGeometryManager_6(IntPtr pDb, IntPtr visualStyleId, IntPtr points, IntPtr verticalDir);

	public delegate bool SwigDelegateOdGiSectionGeometryManager_7(IntPtr pDrawable);

	public delegate bool SwigDelegateOdGiSectionGeometryManager_8(IntPtr section, IntPtr drawable, IntPtr xform, IntPtr geom, bool bHasForeground);

	public delegate IntPtr SwigDelegateOdGiSectionGeometryManager_9();

	public delegate int SwigDelegateOdGiSectionGeometryManager_10(IntPtr pDrawable, IntPtr ext);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiSectionGeometryManager_0 swigDelegate0;

	private SwigDelegateOdGiSectionGeometryManager_1 swigDelegate1;

	private SwigDelegateOdGiSectionGeometryManager_2 swigDelegate2;

	private SwigDelegateOdGiSectionGeometryManager_3 swigDelegate3;

	private SwigDelegateOdGiSectionGeometryManager_4 swigDelegate4;

	private SwigDelegateOdGiSectionGeometryManager_5 swigDelegate5;

	private SwigDelegateOdGiSectionGeometryManager_6 swigDelegate6;

	private SwigDelegateOdGiSectionGeometryManager_7 swigDelegate7;

	private SwigDelegateOdGiSectionGeometryManager_8 swigDelegate8;

	private SwigDelegateOdGiSectionGeometryManager_9 swigDelegate9;

	private SwigDelegateOdGiSectionGeometryManager_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdDbStub).MakeByRefType()
	};

	private static Type[] swigMethodTypes4 = new Type[6]
	{
		typeof(OdRxObject),
		typeof(OdDbStub),
		typeof(OdGePoint3dArray),
		typeof(OdGeVector3d),
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes5 = new Type[5]
	{
		typeof(OdRxObject),
		typeof(OdDbStub),
		typeof(OdGePoint3dArray),
		typeof(OdGeVector3d),
		typeof(double)
	};

	private static Type[] swigMethodTypes6 = new Type[4]
	{
		typeof(OdRxObject),
		typeof(OdDbStub),
		typeof(OdGePoint3dArray),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiDrawable) };

	private static Type[] swigMethodTypes8 = new Type[5]
	{
		typeof(OdGiDrawable).MakeByRefType(),
		typeof(OdGiDrawable),
		typeof(OdGeMatrix3d),
		typeof(OdGiSectionGeometry),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[2]
	{
		typeof(OdGiDrawable),
		typeof(OdGeExtents3d)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSectionGeometryManager(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSectionGeometryManager obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSectionGeometryManager(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiSectionGeometryManager cast(OdRxObject pObj)
	{
		OdGiSectionGeometryManager rXObject = Helpers.GetRXObject<OdGiSectionGeometryManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_isASwigExplicitOdGiSectionGeometryManager(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_queryXSwigExplicitOdGiSectionGeometryManager(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiSectionGeometryManager createObject()
	{
		OdGiSectionGeometryManager rXObject = Helpers.GetRXObject<OdGiSectionGeometryManager>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub getLiveSection(OdDbStub layoutId, out OdDbStub sectionSettingsId)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_getLiveSection(swigCPtr, OdDbStub.getCPtr(layoutId), out jarg);
			OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
			currentTransaction?.AddObject(Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, bIsWrapperOwnNativeObject: true));
			sectionSettingsId = Helpers.odCreateObjectInternal<OdDbStub>(typeof(OdDbStub), jarg, currentTransaction == null);
		}
	}

	public virtual OdGiDrawable createLiveSection(OdRxObject pDb, OdDbStub visualStyleId, OdGePoint3dArray points, OdGeVector3d verticalDir, double dTop, double dBottom)
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_createLiveSection__SWIG_0(swigCPtr, OdRxObject.getCPtr(pDb), OdDbStub.getCPtr(visualStyleId), OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(verticalDir), dTop, dBottom), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiDrawable createLiveSection(OdRxObject pDb, OdDbStub visualStyleId, OdGePoint3dArray points, OdGeVector3d verticalDir, double dTop)
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_createLiveSection__SWIG_1(swigCPtr, OdRxObject.getCPtr(pDb), OdDbStub.getCPtr(visualStyleId), OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(verticalDir), dTop), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiDrawable createLiveSection(OdRxObject pDb, OdDbStub visualStyleId, OdGePoint3dArray points, OdGeVector3d verticalDir)
	{
		OdGiDrawable rXObject = Helpers.GetRXObject<OdGiDrawable>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_createLiveSection__SWIG_2(swigCPtr, OdRxObject.getCPtr(pDb), OdDbStub.getCPtr(visualStyleId), OdGePoint3dArray.getCPtr(points), OdGeVector3d.getCPtr(verticalDir)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isLiveSection(OdGiDrawable pDrawable)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_isLiveSection(swigCPtr, OdGiDrawable.getCPtr(pDrawable));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool generateSectionGeometry(ref OdGiDrawable section, OdGiDrawable drawable, OdGeMatrix3d xform, OdGiSectionGeometry geom, bool bHasForeground)
	{
		IntPtr jarg = ((section == null) ? IntPtr.Zero : OdGiDrawable.getCPtr(section).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_generateSectionGeometry(swigCPtr, ref jarg, OdGiDrawable.getCPtr(drawable), OdGeMatrix3d.getCPtr(xform), OdGiSectionGeometry.getCPtr(geom), bHasForeground);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				section = null;
			}
			if (jarg != intPtr)
			{
				section = Helpers.GetRXObject<OdGiDrawable>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdGiSectionGeometryMap createSectionGeometryMap()
	{
		OdGiSectionGeometryMap rXObject = Helpers.GetRXObject<OdGiSectionGeometryMap>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_createSectionGeometryMap(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int classifyExtentsRelativelySection(OdGiDrawable pDrawable, OdGeExtents3d ext)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_classifyExtentsRelativelySection(swigCPtr, OdGiDrawable.getCPtr(pDrawable), OdGeExtents3d.getCPtr(ext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSectionGeometryManager()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSectionGeometryManager(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiSectionGeometryManager) != GetType();
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
		if (SwigDerivedClassHasMethod("getLiveSection", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetLiveSection;
		}
		if (SwigDerivedClassHasMethod("createLiveSection", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodcreateLiveSection__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("createLiveSection", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreateLiveSection__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createLiveSection", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcreateLiveSection__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("isLiveSection", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisLiveSection;
		}
		if (SwigDerivedClassHasMethod("generateSectionGeometry", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgenerateSectionGeometry;
		}
		if (SwigDerivedClassHasMethod("createSectionGeometryMap", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcreateSectionGeometryMap;
		}
		if (SwigDerivedClassHasMethod("classifyExtentsRelativelySection", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodclassifyExtentsRelativelySection;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryManager_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSectionGeometryManager));
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

	private IntPtr SwigDirectorMethodgetLiveSection(IntPtr layoutId, IntPtr sectionSettingsId)
	{
		OdDbStub tmp_sectionSettingsId = new OdDbStub(sectionSettingsId, cMemoryOwn: true);
		try
		{
			return ((Func<IntPtr>)delegate
			{
				try
				{
					return OdDbStub.getCPtr(getLiveSection((layoutId == IntPtr.Zero) ? null : new OdDbStub(layoutId, cMemoryOwn: false), out tmp_sectionSettingsId)).Handle;
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
		finally
		{
			sectionSettingsId = OdDbStub.getCPtr(tmp_sectionSettingsId).Handle;
		}
	}

	private IntPtr SwigDirectorMethodcreateLiveSection__SWIG_0(IntPtr pDb, IntPtr visualStyleId, IntPtr points, IntPtr verticalDir, IntPtr dTop, IntPtr dBottom)
	{
		double dTop2;
		if (dTop != IntPtr.Zero)
		{
			byte[] array = new byte[8];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Marshal.ReadByte(dTop, i);
			}
			dTop2 = BitConverter.ToDouble(array, 0);
		}
		else
		{
			dTop2 = 0.0;
		}
		double dBottom2;
		if (dBottom != IntPtr.Zero)
		{
			byte[] array2 = new byte[8];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = Marshal.ReadByte(dBottom, j);
			}
			dBottom2 = BitConverter.ToDouble(array2, 0);
		}
		else
		{
			dBottom2 = 0.0;
		}
		return OdGiDrawable.getCPtr(createLiveSection(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), (visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: false), new OdGeVector3d(verticalDir, cMemoryOwn: false), dTop2, dBottom2)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateLiveSection__SWIG_1(IntPtr pDb, IntPtr visualStyleId, IntPtr points, IntPtr verticalDir, IntPtr dTop)
	{
		double dTop2;
		if (dTop != IntPtr.Zero)
		{
			byte[] array = new byte[8];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Marshal.ReadByte(dTop, i);
			}
			dTop2 = BitConverter.ToDouble(array, 0);
		}
		else
		{
			dTop2 = 0.0;
		}
		return OdGiDrawable.getCPtr(createLiveSection(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), (visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: false), new OdGeVector3d(verticalDir, cMemoryOwn: false), dTop2)).Handle;
	}

	private IntPtr SwigDirectorMethodcreateLiveSection__SWIG_2(IntPtr pDb, IntPtr visualStyleId, IntPtr points, IntPtr verticalDir)
	{
		return OdGiDrawable.getCPtr(createLiveSection(Helpers.GetRXObject<OdRxObject>(pDb, bOwn: false, bTryAddToTransaction: false), (visualStyleId == IntPtr.Zero) ? null : new OdDbStub(visualStyleId, cMemoryOwn: false), new OdGePoint3dArray(points, cMemoryOwn: false), new OdGeVector3d(verticalDir, cMemoryOwn: false))).Handle;
	}

	private bool SwigDirectorMethodisLiveSection(IntPtr pDrawable)
	{
		return isLiveSection(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodgenerateSectionGeometry(IntPtr section, IntPtr drawable, IntPtr xform, IntPtr geom, bool bHasForeground)
	{
		OdSwigDirectorHelper.director_UnpackData(section, out var pOriginalObject, out var pFunction);
		OdGiDrawable section2 = Helpers.GetRXObject<OdGiDrawable>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return generateSectionGeometry(ref section2, Helpers.GetRXObject<OdGiDrawable>(drawable, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(xform, cMemoryOwn: false), new OdGiSectionGeometry(geom, cMemoryOwn: false), bHasForeground);
		}
		finally
		{
			IntPtr handle = OdGiDrawable.getCPtr(section2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(section);
		}
	}

	private IntPtr SwigDirectorMethodcreateSectionGeometryMap()
	{
		return OdGiSectionGeometryMap.getCPtr(createSectionGeometryMap()).Handle;
	}

	private int SwigDirectorMethodclassifyExtentsRelativelySection(IntPtr pDrawable, IntPtr ext)
	{
		return classifyExtentsRelativelySection(Helpers.GetRXObject<OdGiDrawable>(pDrawable, bOwn: false, bTryAddToTransaction: false), new OdGeExtents3d(ext, cMemoryOwn: false));
	}
}
