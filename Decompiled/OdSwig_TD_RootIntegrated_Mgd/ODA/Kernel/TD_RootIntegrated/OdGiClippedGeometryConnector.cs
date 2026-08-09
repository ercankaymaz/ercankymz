using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiClippedGeometryConnector : OdGiConveyorNode
{
	public delegate IntPtr SwigDelegateOdGiClippedGeometryConnector_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiClippedGeometryConnector_1();

	public delegate void SwigDelegateOdGiClippedGeometryConnector_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiClippedGeometryConnector_3();

	public delegate IntPtr SwigDelegateOdGiClippedGeometryConnector_4();

	public delegate void SwigDelegateOdGiClippedGeometryConnector_5(IntPtr pOutput);

	public delegate IntPtr SwigDelegateOdGiClippedGeometryConnector_6();

	public delegate bool SwigDelegateOdGiClippedGeometryConnector_7();

	public delegate void SwigDelegateOdGiClippedGeometryConnector_8(IntPtr pDrawCtx);

	public delegate void SwigDelegateOdGiClippedGeometryConnector_9(IntPtr pIface);

	public delegate IntPtr SwigDelegateOdGiClippedGeometryConnector_10();

	public delegate void SwigDelegateOdGiClippedGeometryConnector_11(bool bSkip);

	public delegate bool SwigDelegateOdGiClippedGeometryConnector_12();

	public delegate void SwigDelegateOdGiClippedGeometryConnector_13(bool bDisable);

	public delegate bool SwigDelegateOdGiClippedGeometryConnector_14();

	public delegate bool SwigDelegateOdGiClippedGeometryConnector_15();

	public delegate bool SwigDelegateOdGiClippedGeometryConnector_16();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiClippedGeometryConnector_0 swigDelegate0;

	private SwigDelegateOdGiClippedGeometryConnector_1 swigDelegate1;

	private SwigDelegateOdGiClippedGeometryConnector_2 swigDelegate2;

	private SwigDelegateOdGiClippedGeometryConnector_3 swigDelegate3;

	private SwigDelegateOdGiClippedGeometryConnector_4 swigDelegate4;

	private SwigDelegateOdGiClippedGeometryConnector_5 swigDelegate5;

	private SwigDelegateOdGiClippedGeometryConnector_6 swigDelegate6;

	private SwigDelegateOdGiClippedGeometryConnector_7 swigDelegate7;

	private SwigDelegateOdGiClippedGeometryConnector_8 swigDelegate8;

	private SwigDelegateOdGiClippedGeometryConnector_9 swigDelegate9;

	private SwigDelegateOdGiClippedGeometryConnector_10 swigDelegate10;

	private SwigDelegateOdGiClippedGeometryConnector_11 swigDelegate11;

	private SwigDelegateOdGiClippedGeometryConnector_12 swigDelegate12;

	private SwigDelegateOdGiClippedGeometryConnector_13 swigDelegate13;

	private SwigDelegateOdGiClippedGeometryConnector_14 swigDelegate14;

	private SwigDelegateOdGiClippedGeometryConnector_15 swigDelegate15;

	private SwigDelegateOdGiClippedGeometryConnector_16 swigDelegate16;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiClippedGeometryOutput) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiConveyorContext) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGiClippedGeometryOutput.ClippedGeometryOutputInterface) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiClippedGeometryConnector(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiClippedGeometryConnector obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiClippedGeometryConnector(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiClippedGeometryConnector cast(OdRxObject pObj)
	{
		OdGiClippedGeometryConnector rXObject = Helpers.GetRXObject<OdGiClippedGeometryConnector>(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_isASwigExplicitOdGiClippedGeometryConnector(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_queryXSwigExplicitOdGiClippedGeometryConnector(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiClippedGeometryConnector createObject()
	{
		OdGiClippedGeometryConnector rXObject = Helpers.GetRXObject<OdGiClippedGeometryConnector>(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setClippedGeometryOutput(OdGiClippedGeometryOutput pOutput)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_setClippedGeometryOutput(swigCPtr, OdGiClippedGeometryOutput.getCPtr(pOutput));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiClippedGeometryOutput getClippedGeometryOutput()
	{
		OdGiClippedGeometryOutput rXObject = Helpers.GetRXObject<OdGiClippedGeometryOutput>(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_getClippedGeometryOutput(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool hasClippedGeometryOutput()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_hasClippedGeometryOutput(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_setDrawContext(swigCPtr, pDrawCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setExternalClippedGeometryOutputInterface(OdGiClippedGeometryOutput.ClippedGeometryOutputInterface pIface)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_setExternalClippedGeometryOutputInterface(swigCPtr, OdGiClippedGeometryOutput.ClippedGeometryOutputInterface.getCPtr(pIface));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiClippedGeometryOutput.ClippedGeometryOutputInterface clippedGeometryOutputInterface()
	{
		OdGiClippedGeometryOutput.ClippedGeometryOutputInterface result = new OdGiClippedGeometryOutput.ClippedGeometryOutputInterface(TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_clippedGeometryOutputInterface(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setClippedGeometryOutputSkip(bool bSkip)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_setClippedGeometryOutputSkip(swigCPtr, bSkip);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isClippedGeometryOutputSkipping()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_isClippedGeometryOutputSkipping(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void disableGeometryOutput(bool bDisable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_disableGeometryOutput(swigCPtr, bDisable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isGeometryOutputDisabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_isGeometryOutputDisabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isClosedSectionsOutputEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_isClosedSectionsOutputEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isOpenedSectionsOutputEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_isOpenedSectionsOutputEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiClippedGeometryConnector()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiClippedGeometryConnector(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiClippedGeometryConnector) != GetType();
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
		if (SwigDerivedClassHasMethod("setClippedGeometryOutput", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetClippedGeometryOutput;
		}
		if (SwigDerivedClassHasMethod("getClippedGeometryOutput", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetClippedGeometryOutput;
		}
		if (SwigDerivedClassHasMethod("hasClippedGeometryOutput", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodhasClippedGeometryOutput;
		}
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsetDrawContext;
		}
		if (SwigDerivedClassHasMethod("setExternalClippedGeometryOutputInterface", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetExternalClippedGeometryOutputInterface;
		}
		if (SwigDerivedClassHasMethod("clippedGeometryOutputInterface", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodclippedGeometryOutputInterface;
		}
		if (SwigDerivedClassHasMethod("setClippedGeometryOutputSkip", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetClippedGeometryOutputSkip;
		}
		if (SwigDerivedClassHasMethod("isClippedGeometryOutputSkipping", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodisClippedGeometryOutputSkipping;
		}
		if (SwigDerivedClassHasMethod("disableGeometryOutput", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethoddisableGeometryOutput;
		}
		if (SwigDerivedClassHasMethod("isGeometryOutputDisabled", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodisGeometryOutputDisabled;
		}
		if (SwigDerivedClassHasMethod("isClosedSectionsOutputEnabled", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodisClosedSectionsOutputEnabled;
		}
		if (SwigDerivedClassHasMethod("isOpenedSectionsOutputEnabled", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodisOpenedSectionsOutputEnabled;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiClippedGeometryConnector_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiClippedGeometryConnector));
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

	private void SwigDirectorMethodsetClippedGeometryOutput(IntPtr pOutput)
	{
		try
		{
			setClippedGeometryOutput(Helpers.GetRXObject<OdGiClippedGeometryOutput>(pOutput, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgetClippedGeometryOutput()
	{
		return OdGiClippedGeometryOutput.getCPtr(getClippedGeometryOutput()).Handle;
	}

	private bool SwigDirectorMethodhasClippedGeometryOutput()
	{
		return hasClippedGeometryOutput();
	}

	private void SwigDirectorMethodsetDrawContext(IntPtr pDrawCtx)
	{
		try
		{
			setDrawContext(new OdGiConveyorContext_Internal(pDrawCtx, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetExternalClippedGeometryOutputInterface(IntPtr pIface)
	{
		try
		{
			setExternalClippedGeometryOutputInterface((pIface == IntPtr.Zero) ? null : new OdGiClippedGeometryOutput.ClippedGeometryOutputInterface(pIface, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodclippedGeometryOutputInterface()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiClippedGeometryOutput.ClippedGeometryOutputInterface.getCPtr(clippedGeometryOutputInterface()).Handle;
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

	private void SwigDirectorMethodsetClippedGeometryOutputSkip(bool bSkip)
	{
		try
		{
			setClippedGeometryOutputSkip(bSkip);
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

	private bool SwigDirectorMethodisClippedGeometryOutputSkipping()
	{
		return isClippedGeometryOutputSkipping();
	}

	private void SwigDirectorMethoddisableGeometryOutput(bool bDisable)
	{
		try
		{
			disableGeometryOutput(bDisable);
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

	private bool SwigDirectorMethodisGeometryOutputDisabled()
	{
		return isGeometryOutputDisabled();
	}

	private bool SwigDirectorMethodisClosedSectionsOutputEnabled()
	{
		return isClosedSectionsOutputEnabled();
	}

	private bool SwigDirectorMethodisOpenedSectionsOutputEnabled()
	{
		return isOpenedSectionsOutputEnabled();
	}
}
