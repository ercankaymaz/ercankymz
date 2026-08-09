using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsFilerExtensionStreamAccessor : OdGsFilerExtension
{
	public delegate int SwigDelegateOdGsFilerExtensionStreamAccessor_0();

	public delegate void SwigDelegateOdGsFilerExtensionStreamAccessor_1(IntPtr pStream);

	public delegate IntPtr SwigDelegateOdGsFilerExtensionStreamAccessor_2();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGsFilerExtensionStreamAccessor_0 swigDelegate0;

	private SwigDelegateOdGsFilerExtensionStreamAccessor_1 swigDelegate1;

	private SwigDelegateOdGsFilerExtensionStreamAccessor_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes2 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsFilerExtensionStreamAccessor(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionStreamAccessor_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsFilerExtensionStreamAccessor obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsFilerExtensionStreamAccessor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public override OdGsFilerExtension_Type type()
	{
		int result = (SwigDerivedClassHasMethod("type", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionStreamAccessor_typeSwigExplicitOdGsFilerExtensionStreamAccessor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionStreamAccessor_type(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGsFilerExtension_Type)result;
	}

	public static OdGsFilerExtensionStreamAccessor cast(OdGsFilerExtension pExt)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionStreamAccessor_cast__SWIG_0(OdGsFilerExtension.getCPtr(pExt));
		OdGsFilerExtensionStreamAccessor result = ((intPtr == IntPtr.Zero) ? null : new OdGsFilerExtensionStreamAccessor(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setStream(OdStreamBuf pStream)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionStreamAccessor_setStream(swigCPtr, OdStreamBuf.getCPtr(pStream));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdStreamBuf getStream()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionStreamAccessor_getStream(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsFilerExtensionStreamAccessor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsFilerExtensionStreamAccessor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGsFilerExtensionStreamAccessor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("type", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodtype;
		}
		if (SwigDerivedClassHasMethod("setStream", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsetStream;
		}
		if (SwigDerivedClassHasMethod("getStream", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetStream;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGsFilerExtensionStreamAccessor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGsFilerExtensionStreamAccessor));
	}

	private int SwigDirectorMethodtype()
	{
		return (int)type();
	}

	private void SwigDirectorMethodsetStream(IntPtr pStream)
	{
		try
		{
			setStream(Helpers.GetRXObject<OdStreamBuf>(pStream, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgetStream()
	{
		return OdStreamBuf.getCPtr(getStream()).Handle;
	}
}
