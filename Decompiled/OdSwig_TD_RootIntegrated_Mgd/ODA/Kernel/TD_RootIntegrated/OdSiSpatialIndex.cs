using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdSiSpatialIndex : OdRxObject
{
	public delegate IntPtr SwigDelegateOdSiSpatialIndex_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdSiSpatialIndex_1();

	public delegate void SwigDelegateOdSiSpatialIndex_2(IntPtr pSource);

	public delegate void SwigDelegateOdSiSpatialIndex_3(IntPtr entity);

	public delegate bool SwigDelegateOdSiSpatialIndex_4(IntPtr entity);

	public delegate void SwigDelegateOdSiSpatialIndex_5(IntPtr shape, IntPtr visitor);

	public delegate void SwigDelegateOdSiSpatialIndex_6();

	public delegate void SwigDelegateOdSiSpatialIndex_7(byte maxDepth);

	public delegate void SwigDelegateOdSiSpatialIndex_8(byte maxCount);

	public delegate bool SwigDelegateOdSiSpatialIndex_9(IntPtr extents);

	public delegate uint SwigDelegateOdSiSpatialIndex_10();

	public delegate uint SwigDelegateOdSiSpatialIndex_11();

	public delegate IntPtr SwigDelegateOdSiSpatialIndex_12();

	public delegate void SwigDelegateOdSiSpatialIndex_13(IntPtr tol);

	public delegate bool SwigDelegateOdSiSpatialIndex_14();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdSiSpatialIndex_0 swigDelegate0;

	private SwigDelegateOdSiSpatialIndex_1 swigDelegate1;

	private SwigDelegateOdSiSpatialIndex_2 swigDelegate2;

	private SwigDelegateOdSiSpatialIndex_3 swigDelegate3;

	private SwigDelegateOdSiSpatialIndex_4 swigDelegate4;

	private SwigDelegateOdSiSpatialIndex_5 swigDelegate5;

	private SwigDelegateOdSiSpatialIndex_6 swigDelegate6;

	private SwigDelegateOdSiSpatialIndex_7 swigDelegate7;

	private SwigDelegateOdSiSpatialIndex_8 swigDelegate8;

	private SwigDelegateOdSiSpatialIndex_9 swigDelegate9;

	private SwigDelegateOdSiSpatialIndex_10 swigDelegate10;

	private SwigDelegateOdSiSpatialIndex_11 swigDelegate11;

	private SwigDelegateOdSiSpatialIndex_12 swigDelegate12;

	private SwigDelegateOdSiSpatialIndex_13 swigDelegate13;

	private SwigDelegateOdSiSpatialIndex_14 swigDelegate14;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdSiEntity) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdSiEntity) };

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdSiShape),
		typeof(OdSiVisitor)
	};

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdGeTol) };

	private static Type[] swigMethodTypes14 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdSiSpatialIndex(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdSiSpatialIndex obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdSiSpatialIndex(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdSiSpatialIndex cast(OdRxObject pObj)
	{
		OdSiSpatialIndex rXObject = Helpers.GetRXObject<OdSiSpatialIndex>(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_isASwigExplicitOdSiSpatialIndex(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_queryXSwigExplicitOdSiSpatialIndex(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdSiSpatialIndex createObject()
	{
		OdSiSpatialIndex rXObject = Helpers.GetRXObject<OdSiSpatialIndex>(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdSiSpatialIndex createObject(uint flags, uint initialNumEntity, uint maxDepth, uint maxCount, double eps)
	{
		OdSiSpatialIndex rXObject = Helpers.GetRXObject<OdSiSpatialIndex>(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_createObject__SWIG_1(flags, initialNumEntity, maxDepth, maxCount, eps), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdSiSpatialIndex createObject(uint flags, uint initialNumEntity, uint maxDepth, uint maxCount)
	{
		OdSiSpatialIndex rXObject = Helpers.GetRXObject<OdSiSpatialIndex>(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_createObject__SWIG_2(flags, initialNumEntity, maxDepth, maxCount), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdSiSpatialIndex createObject(uint flags, uint initialNumEntity, uint maxDepth)
	{
		OdSiSpatialIndex rXObject = Helpers.GetRXObject<OdSiSpatialIndex>(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_createObject__SWIG_3(flags, initialNumEntity, maxDepth), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdSiSpatialIndex createObject(uint flags, uint initialNumEntity)
	{
		OdSiSpatialIndex rXObject = Helpers.GetRXObject<OdSiSpatialIndex>(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_createObject__SWIG_4(flags, initialNumEntity), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void insert(OdSiEntity entity)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_insert(swigCPtr, entity.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool remove(OdSiEntity entity)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_remove(swigCPtr, entity.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void query(OdSiShape shape, OdSiVisitor visitor)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_query(swigCPtr, shape.GetInterfaceCPtr(), OdSiVisitor.getCPtr(visitor));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMaxTreeDepth(byte maxDepth)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_setMaxTreeDepth(swigCPtr, maxDepth);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMaxNodeSize(byte maxCount)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_setMaxNodeSize(swigCPtr, maxCount);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool Extents(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_Extents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint maxTreeDepth()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_maxTreeDepth(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint maxNodeSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_maxNodeSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeTol tolerance()
	{
		OdGeTol result = new OdGeTol(TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_tolerance(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setTolerance(OdGeTol tol)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_setTolerance(swigCPtr, OdGeTol.getCPtr(tol));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isInitialized()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_isInitialized(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdSiSpatialIndex()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdSiSpatialIndex(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdSiSpatialIndex) != GetType();
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
		if (SwigDerivedClassHasMethod("insert", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinsert;
		}
		if (SwigDerivedClassHasMethod("remove", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodremove;
		}
		if (SwigDerivedClassHasMethod("query", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodquery;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodclear;
		}
		if (SwigDerivedClassHasMethod("setMaxTreeDepth", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetMaxTreeDepth;
		}
		if (SwigDerivedClassHasMethod("setMaxNodeSize", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetMaxNodeSize;
		}
		if (SwigDerivedClassHasMethod("Extents", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodExtents;
		}
		if (SwigDerivedClassHasMethod("maxTreeDepth", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodmaxTreeDepth;
		}
		if (SwigDerivedClassHasMethod("maxNodeSize", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodmaxNodeSize;
		}
		if (SwigDerivedClassHasMethod("tolerance", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodtolerance;
		}
		if (SwigDerivedClassHasMethod("setTolerance", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetTolerance;
		}
		if (SwigDerivedClassHasMethod("isInitialized", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodisInitialized;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdSiSpatialIndex_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdSiSpatialIndex));
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

	private void SwigDirectorMethodinsert(IntPtr entity)
	{
		try
		{
			insert(new OdSiEntityImpl(entity, cMemoryOwn: false));
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

	private bool SwigDirectorMethodremove(IntPtr entity)
	{
		return remove(new OdSiEntityImpl(entity, cMemoryOwn: false));
	}

	private void SwigDirectorMethodquery(IntPtr shape, IntPtr visitor)
	{
		try
		{
			query(new OdSiShapeImpl(shape, cMemoryOwn: false), new OdSiVisitor(visitor, cMemoryOwn: false));
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

	private void SwigDirectorMethodclear()
	{
		try
		{
			clear();
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

	private void SwigDirectorMethodsetMaxTreeDepth(byte maxDepth)
	{
		try
		{
			setMaxTreeDepth(maxDepth);
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

	private void SwigDirectorMethodsetMaxNodeSize(byte maxCount)
	{
		try
		{
			setMaxNodeSize(maxCount);
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

	private bool SwigDirectorMethodExtents(IntPtr extents)
	{
		return Extents(new OdGeExtents3d(extents, cMemoryOwn: false));
	}

	private uint SwigDirectorMethodmaxTreeDepth()
	{
		return maxTreeDepth();
	}

	private uint SwigDirectorMethodmaxNodeSize()
	{
		return maxNodeSize();
	}

	private IntPtr SwigDirectorMethodtolerance()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeTol.getCPtr(tolerance()).Handle;
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

	private void SwigDirectorMethodsetTolerance(IntPtr tol)
	{
		try
		{
			setTolerance(new OdGeTol(tol, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisInitialized()
	{
		return isInitialized();
	}
}
