using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcMarkupTessBufMatrix : OdPrcMarkupTessBufBlock
{
	public delegate IntPtr SwigDelegateOdPrcMarkupTessBufMatrix_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcMarkupTessBufMatrix_1();

	public delegate void SwigDelegateOdPrcMarkupTessBufMatrix_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcMarkupTessBufMatrix_0 swigDelegate0;

	private SwigDelegateOdPrcMarkupTessBufMatrix_1 swigDelegate1;

	private SwigDelegateOdPrcMarkupTessBufMatrix_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcMarkupTessBufMatrix(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcMarkupTessBufMatrix obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcMarkupTessBufMatrix(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdPrcMarkupTessBufMatrix cast(OdRxObject pObj)
	{
		OdPrcMarkupTessBufMatrix rXObject = Helpers.GetRXObject<OdPrcMarkupTessBufMatrix>(OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_isASwigExplicitOdPrcMarkupTessBufMatrix(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_queryXSwigExplicitOdPrcMarkupTessBufMatrix(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGeMatrix3d getMatrix()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_getMatrix(swigCPtr), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMatrix(OdGeMatrix3d matr)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_setMatrix(swigCPtr, OdGeMatrix3d.getCPtr(matr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcMarkupTessBufMatrix createObject()
	{
		OdPrcMarkupTessBufMatrix rXObject = Helpers.GetRXObject<OdPrcMarkupTessBufMatrix>(OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdPrcMarkupTessBufMatrix()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcMarkupTessBufMatrix(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcMarkupTessBufMatrix) != GetType();
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
		OdPrcModule_GlobalsPINVOKE.OdPrcMarkupTessBufMatrix_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcMarkupTessBufMatrix));
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
}
