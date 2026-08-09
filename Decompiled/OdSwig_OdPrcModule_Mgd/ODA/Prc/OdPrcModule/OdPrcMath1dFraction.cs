using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcMath1dFraction : OdPrcMath1d
{
	public delegate IntPtr SwigDelegateOdPrcMath1dFraction_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcMath1dFraction_1();

	public delegate void SwigDelegateOdPrcMath1dFraction_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcMath1dFraction_3(IntPtr pStream);

	public delegate void SwigDelegateOdPrcMath1dFraction_4(IntPtr pStream);

	public delegate uint SwigDelegateOdPrcMath1dFraction_5();

	public delegate double SwigDelegateOdPrcMath1dFraction_6(double dParam);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcMath1dFraction_0 swigDelegate0;

	private SwigDelegateOdPrcMath1dFraction_1 swigDelegate1;

	private SwigDelegateOdPrcMath1dFraction_2 swigDelegate2;

	private SwigDelegateOdPrcMath1dFraction_3 swigDelegate3;

	private SwigDelegateOdPrcMath1dFraction_4 swigDelegate4;

	private SwigDelegateOdPrcMath1dFraction_5 swigDelegate5;

	private SwigDelegateOdPrcMath1dFraction_6 swigDelegate6;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(double) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcMath1dFraction(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcMath1dFraction obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcMath1dFraction(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcMath1dFraction()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcMath1dFraction(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcMath1dFraction) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override uint prcType()
	{
		uint result = (SwigDerivedClassHasMethod("prcType", swigMethodTypes5) ? OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_prcTypeSwigExplicitOdPrcMath1dFraction(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_prcType(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcMath1dFraction cast(OdRxObject pObj)
	{
		OdPrcMath1dFraction rXObject = Helpers.GetRXObject<OdPrcMath1dFraction>(OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_isASwigExplicitOdPrcMath1dFraction(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_queryXSwigExplicitOdPrcMath1dFraction(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcMath1dFraction createObject()
	{
		OdPrcMath1dFraction rXObject = Helpers.GetRXObject<OdPrcMath1dFraction>(OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void prcOut(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes3))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_prcOutSwigExplicitOdPrcMath1dFraction(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void prcIn(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes4))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_prcInSwigExplicitOdPrcMath1dFraction(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResult setNumerator(OdPrcMath1d value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_setNumerator(swigCPtr, OdPrcMath1d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcMath1d numerator()
	{
		OdPrcMath1d rXObject = Helpers.GetRXObject<OdPrcMath1d>(OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_numerator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResult setDenominator(OdPrcMath1d value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_setDenominator(swigCPtr, OdPrcMath1d.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public OdPrcMath1d denominator()
	{
		OdPrcMath1d rXObject = Helpers.GetRXObject<OdPrcMath1d>(OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_denominator(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override double evaluate(double dParam)
	{
		double result = (SwigDerivedClassHasMethod("evaluate", swigMethodTypes6) ? OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_evaluateSwigExplicitOdPrcMath1dFraction(swigCPtr, dParam) : OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_evaluate(swigCPtr, dParam));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodprcOut;
		}
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodprcIn;
		}
		if (SwigDerivedClassHasMethod("prcType", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodprcType;
		}
		if (SwigDerivedClassHasMethod("evaluate", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodevaluate;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcMath1dFraction_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcMath1dFraction));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcOut(IntPtr pStream)
	{
		try
		{
			prcOut(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodprcIn(IntPtr pStream)
	{
		try
		{
			prcIn(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodprcType()
	{
		return prcType();
	}

	private double SwigDirectorMethodevaluate(double dParam)
	{
		return evaluate(dParam);
	}
}
