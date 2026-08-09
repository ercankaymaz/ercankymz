using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFAbstractObject : IDisposable
{
	public delegate bool SwigDelegateTD_PDF_PDFAbstractObject_0(int objType);

	public delegate int SwigDelegateTD_PDF_PDFAbstractObject_1();

	public delegate void SwigDelegateTD_PDF_PDFAbstractObject_2();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateTD_PDF_PDFAbstractObject_0 swigDelegate0;

	private SwigDelegateTD_PDF_PDFAbstractObject_1 swigDelegate1;

	private SwigDelegateTD_PDF_PDFAbstractObject_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(TD_PDF_PDFTypeId) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFAbstractObject(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFAbstractObject obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFAbstractObject()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFAbstractObject(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool isKindOf(TD_PDF_PDFTypeId objType)
	{
		bool result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFAbstractObject_isKindOf(swigCPtr, (int)objType);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual TD_PDF_PDFTypeId type()
	{
		int result = TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFAbstractObject_type(swigCPtr);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_PDF_PDFTypeId)result;
	}

	protected TD_PDF_PDFAbstractObject()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFAbstractObject(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(TD_PDF_PDFAbstractObject) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected virtual void InitObject()
	{
		if (SwigDerivedClassHasMethod("InitObject", swigMethodTypes2))
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFAbstractObject_InitObjectSwigExplicitTD_PDF_PDFAbstractObject(swigCPtr);
		}
		else
		{
			TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFAbstractObject_InitObject(swigCPtr);
		}
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("isKindOf", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodisKindOf;
		}
		if (SwigDerivedClassHasMethod("type", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("InitObject", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodInitObject;
		}
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFAbstractObject_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(TD_PDF_PDFAbstractObject));
	}

	private bool SwigDirectorMethodisKindOf(int objType)
	{
		return isKindOf((TD_PDF_PDFTypeId)objType);
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private void SwigDirectorMethodInitObject()
	{
		try
		{
			InitObject();
		}
		catch (OdEdEmptyInput err)
		{
			TD_PDFToolkit_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_PDFToolkit_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_PDFToolkit_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_PDFToolkit_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
