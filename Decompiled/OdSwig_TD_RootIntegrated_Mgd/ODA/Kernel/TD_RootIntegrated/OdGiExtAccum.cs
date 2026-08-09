using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiExtAccum : OdGiConveyorNode
{
	public delegate IntPtr SwigDelegateOdGiExtAccum_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiExtAccum_1();

	public delegate void SwigDelegateOdGiExtAccum_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiExtAccum_3();

	public delegate IntPtr SwigDelegateOdGiExtAccum_4();

	public delegate void SwigDelegateOdGiExtAccum_5(IntPtr pDrawContext);

	public delegate void SwigDelegateOdGiExtAccum_6(IntPtr deviations);

	public delegate void SwigDelegateOdGiExtAccum_7(IntPtr pDeviation);

	public delegate IntPtr SwigDelegateOdGiExtAccum_8();

	public delegate bool SwigDelegateOdGiExtAccum_9(IntPtr extents);

	public delegate void SwigDelegateOdGiExtAccum_10(IntPtr newExtents);

	public delegate void SwigDelegateOdGiExtAccum_11();

	public delegate void SwigDelegateOdGiExtAccum_12(IntPtr extents);

	public delegate bool SwigDelegateOdGiExtAccum_13();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiExtAccum_0 swigDelegate0;

	private SwigDelegateOdGiExtAccum_1 swigDelegate1;

	private SwigDelegateOdGiExtAccum_2 swigDelegate2;

	private SwigDelegateOdGiExtAccum_3 swigDelegate3;

	private SwigDelegateOdGiExtAccum_4 swigDelegate4;

	private SwigDelegateOdGiExtAccum_5 swigDelegate5;

	private SwigDelegateOdGiExtAccum_6 swigDelegate6;

	private SwigDelegateOdGiExtAccum_7 swigDelegate7;

	private SwigDelegateOdGiExtAccum_8 swigDelegate8;

	private SwigDelegateOdGiExtAccum_9 swigDelegate9;

	private SwigDelegateOdGiExtAccum_10 swigDelegate10;

	private SwigDelegateOdGiExtAccum_11 swigDelegate11;

	private SwigDelegateOdGiExtAccum_12 swigDelegate12;

	private SwigDelegateOdGiExtAccum_13 swigDelegate13;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiConveyorContext) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdDoubleArray) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiDeviation) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes13 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiExtAccum(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiExtAccum obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiExtAccum(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiExtAccum cast(OdRxObject pObj)
	{
		OdGiExtAccum rXObject = Helpers.GetRXObject<OdGiExtAccum>(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_isASwigExplicitOdGiExtAccum(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_queryXSwigExplicitOdGiExtAccum(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiExtAccum createObject()
	{
		OdGiExtAccum rXObject = Helpers.GetRXObject<OdGiExtAccum>(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawContext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_setDrawContext(swigCPtr, pDrawContext.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_setDeviation__SWIG_0(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviation(OdGiDeviation pDeviation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_setDeviation__SWIG_1(swigCPtr, pDeviation.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiConveyorGeometry geometry()
	{
		OdGiConveyorGeometry_Internal result = new OdGiConveyorGeometry_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_geometry(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool getExtents(OdGeExtents3d extents)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_getExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void resetExtents(OdGeExtents3d newExtents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_resetExtents__SWIG_0(swigCPtr, OdGeExtents3d.getCPtr(newExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void resetExtents()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_resetExtents__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void addExtents(OdGeExtents3d extents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_addExtents(swigCPtr, OdGeExtents3d.getCPtr(extents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool plineContainBulges()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_plineContainBulges(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void textExtents(OdGiConveyorContext pDrawContext, OdGiTextStyle textStyle, string pStr, int nLength, uint raw, OdGePoint3d minExt, OdGePoint3d maxExt, OdGePoint3d pEndPos, OdGeExtents3d pExactExtents)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_textExtents__SWIG_0(pDrawContext.GetInterfaceCPtr(), OdGiTextStyle.getCPtr(textStyle).Handle, pStr, nLength, raw, OdGePoint3d.getCPtr(minExt), OdGePoint3d.getCPtr(maxExt), OdGePoint3d.getCPtr(pEndPos), OdGeExtents3d.getCPtr(pExactExtents));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void textExtents(OdGiConveyorContext pDrawContext, OdGiTextStyle textStyle, string pStr, int nLength, uint raw, OdGePoint3d minExt, OdGePoint3d maxExt, OdGePoint3d pEndPos)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_textExtents__SWIG_1(pDrawContext.GetInterfaceCPtr(), OdGiTextStyle.getCPtr(textStyle).Handle, pStr, nLength, raw, OdGePoint3d.getCPtr(minExt), OdGePoint3d.getCPtr(maxExt), OdGePoint3d.getCPtr(pEndPos));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void textExtents(OdGiConveyorContext pDrawContext, OdGiTextStyle textStyle, string pStr, int nLength, uint raw, OdGePoint3d minExt, OdGePoint3d maxExt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_textExtents__SWIG_2(pDrawContext.GetInterfaceCPtr(), OdGiTextStyle.getCPtr(textStyle).Handle, pStr, nLength, raw, OdGePoint3d.getCPtr(minExt), OdGePoint3d.getCPtr(maxExt));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiExtAccum()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiExtAccum(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiExtAccum) != GetType();
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
		if (SwigDerivedClassHasMethod("input", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodinput;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetDrawContext;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDeviation", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetDeviation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("geometry", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgeometry;
		}
		if (SwigDerivedClassHasMethod("getExtents", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetExtents;
		}
		if (SwigDerivedClassHasMethod("resetExtents", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodresetExtents__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("resetExtents", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodresetExtents__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("addExtents", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodaddExtents;
		}
		if (SwigDerivedClassHasMethod("plineContainBulges", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodplineContainBulges;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiExtAccum_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiExtAccum));
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

	private IntPtr SwigDirectorMethodinput()
	{
		return input().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodoutput()
	{
		return output().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetDrawContext(IntPtr pDrawContext)
	{
		try
		{
			setDrawContext(new OdGiConveyorContext_Internal(pDrawContext, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDeviation__SWIG_0(IntPtr deviations)
	{
		try
		{
			setDeviation(new OdDoubleArray(deviations, cMemoryOwn: true));
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

	private void SwigDirectorMethodsetDeviation__SWIG_1(IntPtr pDeviation)
	{
		try
		{
			setDeviation(new OdGiDeviation_Internal(pDeviation, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodgeometry()
	{
		return geometry().GetInterfaceCPtr().Handle;
	}

	private bool SwigDirectorMethodgetExtents(IntPtr extents)
	{
		return getExtents(new OdGeExtents3d(extents, cMemoryOwn: false));
	}

	private void SwigDirectorMethodresetExtents__SWIG_0(IntPtr newExtents)
	{
		try
		{
			resetExtents(new OdGeExtents3d(newExtents, cMemoryOwn: false));
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

	private void SwigDirectorMethodresetExtents__SWIG_1()
	{
		try
		{
			resetExtents();
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

	private void SwigDirectorMethodaddExtents(IntPtr extents)
	{
		try
		{
			addExtents(new OdGeExtents3d(extents, cMemoryOwn: false));
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

	private bool SwigDirectorMethodplineContainBulges()
	{
		return plineContainBulges();
	}
}
