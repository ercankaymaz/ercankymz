using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdColorConverterCallback : OdRxObject
{
	public delegate IntPtr SwigDelegateOdColorConverterCallback_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdColorConverterCallback_1();

	public delegate void SwigDelegateOdColorConverterCallback_2(IntPtr pSource);

	public delegate uint SwigDelegateOdColorConverterCallback_3(uint originalColor);

	public delegate bool SwigDelegateOdColorConverterCallback_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdColorConverterCallback_0 swigDelegate0;

	private SwigDelegateOdColorConverterCallback_1 swigDelegate1;

	private SwigDelegateOdColorConverterCallback_2 swigDelegate2;

	private SwigDelegateOdColorConverterCallback_3 swigDelegate3;

	private SwigDelegateOdColorConverterCallback_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdColorConverterCallback(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallback_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdColorConverterCallback obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdColorConverterCallback(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdColorConverterCallback()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdColorConverterCallback(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public virtual uint convert(uint originalColor)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallback_convert(swigCPtr, originalColor);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool convertBackgroundColors()
	{
		bool result = (SwigDerivedClassHasMethod("convertBackgroundColors", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallback_convertBackgroundColorsSwigExplicitOdColorConverterCallback(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallback_convertBackgroundColors(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallback_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("convert", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodconvert;
		}
		if (SwigDerivedClassHasMethod("convertBackgroundColors", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodconvertBackgroundColors;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdColorConverterCallback_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdColorConverterCallback));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr pClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(pClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private uint SwigDirectorMethodconvert(uint originalColor)
	{
		return convert(originalColor);
	}

	private bool SwigDirectorMethodconvertBackgroundColors()
	{
		return convertBackgroundColors();
	}
}
