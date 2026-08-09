using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Kernel.TD_PDFToolkit;

public class TD_PDF_PDFIContentCommands4Type3 : IDisposable
{
	public delegate void SwigDelegateTD_PDF_PDFIContentCommands4Type3_0(double wx, double wy);

	public delegate void SwigDelegateTD_PDF_PDFIContentCommands4Type3_1(double wx, double wy, double llx, double lly, double urx, double ury);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateTD_PDF_PDFIContentCommands4Type3_0 swigDelegate0;

	private SwigDelegateTD_PDF_PDFIContentCommands4Type3_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(double),
		typeof(double)
	};

	private static Type[] swigMethodTypes1 = new Type[6]
	{
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double),
		typeof(double)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_PDF_PDFIContentCommands4Type3(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_PDF_PDFIContentCommands4Type3 obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~TD_PDF_PDFIContentCommands4Type3()
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
					TD_PDFToolkit_GlobalsPINVOKE.delete_TD_PDF_PDFIContentCommands4Type3(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual void d0(double wx, double wy)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands4Type3_d0(swigCPtr, wx, wy);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void d1(double wx, double wy, double llx, double lly, double urx, double ury)
	{
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands4Type3_d1(swigCPtr, wx, wy, llx, lly, urx, ury);
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public TD_PDF_PDFIContentCommands4Type3()
		: this(TD_PDFToolkit_GlobalsPINVOKE.new_TD_PDF_PDFIContentCommands4Type3(), cMemoryOwn: true)
	{
		if (TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_PDFToolkit_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(TD_PDF_PDFIContentCommands4Type3) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("d0", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodd0;
		}
		if (SwigDerivedClassHasMethod("d1", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodd1;
		}
		TD_PDFToolkit_GlobalsPINVOKE.TD_PDF_PDFIContentCommands4Type3_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(TD_PDF_PDFIContentCommands4Type3));
	}

	private void SwigDirectorMethodd0(double wx, double wy)
	{
		try
		{
			d0(wx, wy);
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

	private void SwigDirectorMethodd1(double wx, double wy, double llx, double lly, double urx, double ury)
	{
		try
		{
			d1(wx, wy, llx, lly, urx, ury);
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
