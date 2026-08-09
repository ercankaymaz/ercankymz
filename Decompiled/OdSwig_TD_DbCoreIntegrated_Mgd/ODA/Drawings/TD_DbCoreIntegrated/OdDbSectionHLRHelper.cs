using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbSectionHLRHelper : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbSectionHLRHelper_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbSectionHLRHelper_1();

	public delegate void SwigDelegateOdDbSectionHLRHelper_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdDbSectionHLRHelper_3();

	public delegate int SwigDelegateOdDbSectionHLRHelper_4(IntPtr ptBase, IntPtr vrDir, IntPtr vrUp);

	public delegate IntPtr SwigDelegateOdDbSectionHLRHelper_5();

	public delegate IntPtr SwigDelegateOdDbSectionHLRHelper_6();

	public delegate IntPtr SwigDelegateOdDbSectionHLRHelper_7();

	public delegate bool SwigDelegateOdDbSectionHLRHelper_8();

	public delegate void SwigDelegateOdDbSectionHLRHelper_9(bool bSet);

	public delegate void SwigDelegateOdDbSectionHLRHelper_10(double dAngle);

	public delegate int SwigDelegateOdDbSectionHLRHelper_11(IntPtr arr3dObjects);

	public delegate IntPtr SwigDelegateOdDbSectionHLRHelper_12();

	public delegate IntPtr SwigDelegateOdDbSectionHLRHelper_13();

	public delegate int SwigDelegateOdDbSectionHLRHelper_14(bool bCreateSection, bool bCreateHiddenLines);

	public delegate bool SwigDelegateOdDbSectionHLRHelper_15(IntPtr arrHatches);

	public delegate bool SwigDelegateOdDbSectionHLRHelper_16(IntPtr arrHiddenLines);

	public delegate bool SwigDelegateOdDbSectionHLRHelper_17(IntPtr arrVisibleLines);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbSectionHLRHelper_0 swigDelegate0;

	private SwigDelegateOdDbSectionHLRHelper_1 swigDelegate1;

	private SwigDelegateOdDbSectionHLRHelper_2 swigDelegate2;

	private SwigDelegateOdDbSectionHLRHelper_3 swigDelegate3;

	private SwigDelegateOdDbSectionHLRHelper_4 swigDelegate4;

	private SwigDelegateOdDbSectionHLRHelper_5 swigDelegate5;

	private SwigDelegateOdDbSectionHLRHelper_6 swigDelegate6;

	private SwigDelegateOdDbSectionHLRHelper_7 swigDelegate7;

	private SwigDelegateOdDbSectionHLRHelper_8 swigDelegate8;

	private SwigDelegateOdDbSectionHLRHelper_9 swigDelegate9;

	private SwigDelegateOdDbSectionHLRHelper_10 swigDelegate10;

	private SwigDelegateOdDbSectionHLRHelper_11 swigDelegate11;

	private SwigDelegateOdDbSectionHLRHelper_12 swigDelegate12;

	private SwigDelegateOdDbSectionHLRHelper_13 swigDelegate13;

	private SwigDelegateOdDbSectionHLRHelper_14 swigDelegate14;

	private SwigDelegateOdDbSectionHLRHelper_15 swigDelegate15;

	private SwigDelegateOdDbSectionHLRHelper_16 swigDelegate16;

	private SwigDelegateOdDbSectionHLRHelper_17 swigDelegate17;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[3]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbObjectIdArray) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdRxObjectPtrArray) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdRxObjectPtrArray) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdRxObjectPtrArray) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbSectionHLRHelper(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbSectionHLRHelper obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbSectionHLRHelper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbSectionHLRHelper cast(OdRxObject pObj)
	{
		OdDbSectionHLRHelper rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSectionHLRHelper>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_isASwigExplicitOdDbSectionHLRHelper(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_queryXSwigExplicitOdDbSectionHLRHelper(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbSectionHLRHelper createObject()
	{
		OdDbSectionHLRHelper rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSectionHLRHelper>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbDatabase database()
	{
		OdDbDatabase rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbDatabase>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_database(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult setProjectionPlane(OdGePoint3d ptBase, OdGeVector3d vrDir, OdGeVector3d vrUp)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_setProjectionPlane(swigCPtr, OdGePoint3d.getCPtr(ptBase), OdGeVector3d.getCPtr(vrDir), OdGeVector3d.getCPtr(vrUp));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdGePoint3d projectionBase()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_projectionBase(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d projectionDirection()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_projectionDirection(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeVector3d projectionUp()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_projectionUp(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool includeTangentalEdgesFlag()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_includeTangentalEdgesFlag(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIncludeTangentalEdgesFlag(bool bSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_setIncludeTangentalEdgesFlag(swigCPtr, bSet);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTangentalEdgesAngle(double dAngle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_setTangentalEdgesAngle(swigCPtr, dAngle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult setEntities(OdDbObjectIdArray arr3dObjects)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_setEntities(swigCPtr, OdDbObjectIdArray.getCPtr(arr3dObjects));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdArray_OdDbObjectId_OdObjectsAllocator getEntities()
	{
		OdArray_OdDbObjectId_OdObjectsAllocator result = new OdArray_OdDbObjectId_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_getEntities(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeExtents3d getExtents()
	{
		OdGeExtents3d result = new OdGeExtents3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_getExtents(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult createSectionHLR(bool bCreateSection, bool bCreateHiddenLines)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_createSectionHLR(swigCPtr, bCreateSection, bCreateHiddenLines);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual bool getSectionHatches(OdRxObjectPtrArray arrHatches)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_getSectionHatches(swigCPtr, OdRxObjectPtrArray.getCPtr(arrHatches).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getHiddenLines(OdRxObjectPtrArray arrHiddenLines)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_getHiddenLines(swigCPtr, OdRxObjectPtrArray.getCPtr(arrHiddenLines).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getVisibleLines(OdRxObjectPtrArray arrVisibleLines)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_getVisibleLines(swigCPtr, OdRxObjectPtrArray.getCPtr(arrVisibleLines).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static bool isEntitySupported(OdDbEntity pEntity)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_isEntitySupported(OdDbEntity.getCPtr(pEntity));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdDbSectionHLRHelper createObject(OdDbDatabase pDb)
	{
		OdDbSectionHLRHelper rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSectionHLRHelper>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_createObject__SWIG_1(OdDbDatabase.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static double getDefaultTangentAngle()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_getDefaultTangentAngle();
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbSectionHLRHelper()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbSectionHLRHelper(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbSectionHLRHelper) != GetType();
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
		if (SwigDerivedClassHasMethod("database", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddatabase;
		}
		if (SwigDerivedClassHasMethod("setProjectionPlane", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetProjectionPlane;
		}
		if (SwigDerivedClassHasMethod("projectionBase", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodprojectionBase;
		}
		if (SwigDerivedClassHasMethod("projectionDirection", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodprojectionDirection;
		}
		if (SwigDerivedClassHasMethod("projectionUp", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodprojectionUp;
		}
		if (SwigDerivedClassHasMethod("includeTangentalEdgesFlag", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodincludeTangentalEdgesFlag;
		}
		if (SwigDerivedClassHasMethod("setIncludeTangentalEdgesFlag", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetIncludeTangentalEdgesFlag;
		}
		if (SwigDerivedClassHasMethod("setTangentalEdgesAngle", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetTangentalEdgesAngle;
		}
		if (SwigDerivedClassHasMethod("setEntities", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetEntities;
		}
		if (SwigDerivedClassHasMethod("getEntities", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodgetEntities;
		}
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetExtents;
		}
		if (SwigDerivedClassHasMethod("createSectionHLR", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodcreateSectionHLR;
		}
		if (SwigDerivedClassHasMethod("getSectionHatches", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetSectionHatches;
		}
		if (SwigDerivedClassHasMethod("getHiddenLines", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetHiddenLines;
		}
		if (SwigDerivedClassHasMethod("getVisibleLines", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetVisibleLines;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbSectionHLRHelper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbSectionHLRHelper));
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

	private IntPtr SwigDirectorMethoddatabase()
	{
		return OdDbDatabase.getCPtr(database()).Handle;
	}

	private int SwigDirectorMethodsetProjectionPlane(IntPtr ptBase, IntPtr vrDir, IntPtr vrUp)
	{
		return (int)setProjectionPlane(new OdGePoint3d(ptBase, cMemoryOwn: false), new OdGeVector3d(vrDir, cMemoryOwn: false), new OdGeVector3d(vrUp, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodprojectionBase()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(projectionBase()).Handle;
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

	private IntPtr SwigDirectorMethodprojectionDirection()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(projectionDirection()).Handle;
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

	private IntPtr SwigDirectorMethodprojectionUp()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(projectionUp()).Handle;
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

	private bool SwigDirectorMethodincludeTangentalEdgesFlag()
	{
		return includeTangentalEdgesFlag();
	}

	private void SwigDirectorMethodsetIncludeTangentalEdgesFlag(bool bSet)
	{
		try
		{
			setIncludeTangentalEdgesFlag(bSet);
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

	private void SwigDirectorMethodsetTangentalEdgesAngle(double dAngle)
	{
		try
		{
			setTangentalEdgesAngle(dAngle);
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

	private int SwigDirectorMethodsetEntities(IntPtr arr3dObjects)
	{
		return (int)setEntities(new OdDbObjectIdArray(arr3dObjects, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodgetEntities()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdArray_OdDbObjectId_OdObjectsAllocator.getCPtr(getEntities()).Handle;
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

	private IntPtr SwigDirectorMethodgetExtents()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeExtents3d.getCPtr(getExtents()).Handle;
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

	private int SwigDirectorMethodcreateSectionHLR(bool bCreateSection, bool bCreateHiddenLines)
	{
		return (int)createSectionHLR(bCreateSection, bCreateHiddenLines);
	}

	private bool SwigDirectorMethodgetSectionHatches(IntPtr arrHatches)
	{
		return getSectionHatches(new OdRxObjectPtrArray(arrHatches, cMemoryOwn: true));
	}

	private bool SwigDirectorMethodgetHiddenLines(IntPtr arrHiddenLines)
	{
		return getHiddenLines(new OdRxObjectPtrArray(arrHiddenLines, cMemoryOwn: true));
	}

	private bool SwigDirectorMethodgetVisibleLines(IntPtr arrVisibleLines)
	{
		return getVisibleLines(new OdRxObjectPtrArray(arrVisibleLines, cMemoryOwn: true));
	}
}
