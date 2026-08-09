using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSectionGeometryMap : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiSectionGeometryMap_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiSectionGeometryMap_1();

	public delegate void SwigDelegateOdGiSectionGeometryMap_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiSectionGeometryMap_3(IntPtr section, IntPtr path, IntPtr drawable, IntPtr tf);

	public delegate void SwigDelegateOdGiSectionGeometryMap_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiSectionGeometryMap_0 swigDelegate0;

	private SwigDelegateOdGiSectionGeometryMap_1 swigDelegate1;

	private SwigDelegateOdGiSectionGeometryMap_2 swigDelegate2;

	private SwigDelegateOdGiSectionGeometryMap_3 swigDelegate3;

	private SwigDelegateOdGiSectionGeometryMap_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[4]
	{
		typeof(OdGiDrawable).MakeByRefType(),
		typeof(OdGiPathNode),
		typeof(OdGiDrawable),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSectionGeometryMap(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSectionGeometryMap obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSectionGeometryMap(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiSectionGeometryMap cast(OdRxObject pObj)
	{
		OdGiSectionGeometryMap rXObject = Helpers.GetRXObject<OdGiSectionGeometryMap>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_isASwigExplicitOdGiSectionGeometryMap(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_queryXSwigExplicitOdGiSectionGeometryMap(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiSectionGeometryMap createObject()
	{
		OdGiSectionGeometryMap rXObject = Helpers.GetRXObject<OdGiSectionGeometryMap>(TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiSectionGeometry getAt(ref OdGiDrawable section, OdGiPathNode path, OdGiDrawable drawable, OdGeMatrix3d tf)
	{
		IntPtr jarg = ((section == null) ? IntPtr.Zero : OdGiDrawable.getCPtr(section).Handle);
		IntPtr intPtr = jarg;
		try
		{
			IntPtr intPtr2 = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_getAt(swigCPtr, ref jarg, OdGiPathNode.getCPtr(path), OdGiDrawable.getCPtr(drawable), OdGeMatrix3d.getCPtr(tf));
			OdGiSectionGeometry result = ((intPtr2 == IntPtr.Zero) ? null : new OdGiSectionGeometry(intPtr2, cMemoryOwn: false));
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

	public virtual void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiSectionGeometryMap()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSectionGeometryMap(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiSectionGeometryMap) != GetType();
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
		if (SwigDerivedClassHasMethod("getAt", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetAt;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodclear;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSectionGeometryMap_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiSectionGeometryMap));
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

	private IntPtr SwigDirectorMethodgetAt(IntPtr section, IntPtr path, IntPtr drawable, IntPtr tf)
	{
		OdSwigDirectorHelper.director_UnpackData(section, out var pOriginalObject, out var pFunction);
		OdGiDrawable p_section = Helpers.GetRXObject<OdGiDrawable>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return ((Func<IntPtr>)delegate
			{
				try
				{
					return OdGiSectionGeometry.getCPtr(getAt(ref p_section, (path == IntPtr.Zero) ? null : new OdGiPathNode(path, cMemoryOwn: false), Helpers.GetRXObject<OdGiDrawable>(drawable, bOwn: false, bTryAddToTransaction: false), new OdGeMatrix3d(tf, cMemoryOwn: false))).Handle;
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
			IntPtr handle = OdGiDrawable.getCPtr(p_section).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(section);
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
}
