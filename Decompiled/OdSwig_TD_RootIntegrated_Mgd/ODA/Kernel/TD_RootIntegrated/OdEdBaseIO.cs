using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdEdBaseIO : OdRxObject
{
	public delegate IntPtr SwigDelegateOdEdBaseIO_0(IntPtr pClass);

	public delegate IntPtr SwigDelegateOdEdBaseIO_1();

	public delegate void SwigDelegateOdEdBaseIO_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseIO_3([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pTracker);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseIO_4([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdEdBaseIO_5([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate void SwigDelegateOdEdBaseIO_6([MarshalAs(UnmanagedType.LPWStr)] string string_);

	public delegate IntPtr SwigDelegateOdEdBaseIO_7([MarshalAs(UnmanagedType.LPWStr)] string prompt, int arg1, IntPtr arg2);

	public delegate IntPtr SwigDelegateOdEdBaseIO_8([MarshalAs(UnmanagedType.LPWStr)] string prompt, int arg1);

	public delegate IntPtr SwigDelegateOdEdBaseIO_9([MarshalAs(UnmanagedType.LPWStr)] string prompt);

	public delegate uint SwigDelegateOdEdBaseIO_10();

	public delegate void SwigDelegateOdEdBaseIO_11([MarshalAs(UnmanagedType.LPWStr)] string errmsg);

	public delegate bool SwigDelegateOdEdBaseIO_12();

	public enum MouseEventFlags
	{
		kLeftButtonIsDown = 1,
		kRightButtonIsDown = 2,
		kShiftIsDown = 4,
		kControlIsDown = 8,
		kMiddleButtonIsDown = 0x10
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdEdBaseIO_0 swigDelegate0;

	private SwigDelegateOdEdBaseIO_1 swigDelegate1;

	private SwigDelegateOdEdBaseIO_2 swigDelegate2;

	private SwigDelegateOdEdBaseIO_3 swigDelegate3;

	private SwigDelegateOdEdBaseIO_4 swigDelegate4;

	private SwigDelegateOdEdBaseIO_5 swigDelegate5;

	private SwigDelegateOdEdBaseIO_6 swigDelegate6;

	private SwigDelegateOdEdBaseIO_7 swigDelegate7;

	private SwigDelegateOdEdBaseIO_8 swigDelegate8;

	private SwigDelegateOdEdBaseIO_9 swigDelegate9;

	private SwigDelegateOdEdBaseIO_10 swigDelegate10;

	private SwigDelegateOdEdBaseIO_11 swigDelegate11;

	private SwigDelegateOdEdBaseIO_12 swigDelegate12;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(OdEdStringTracker)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[3]
	{
		typeof(string),
		typeof(int),
		typeof(OdEdPointTracker)
	};

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(string),
		typeof(int)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes12 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdEdBaseIO(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdEdBaseIO obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdEdBaseIO(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdEdBaseIO()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdEdBaseIO(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public virtual string getString(string prompt, int options, OdEdStringTracker pTracker)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getString__SWIG_0(swigCPtr, prompt, options, OdEdStringTracker.getCPtr(pTracker));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getString(string prompt, int options)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getString__SWIG_1(swigCPtr, prompt, options);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getString(string prompt)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getString__SWIG_2(swigCPtr, prompt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void putString(string string_)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_putString(swigCPtr, string_);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGePoint3d getPoint(string prompt, int arg1, OdEdPointTracker arg2)
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("getPoint", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getPointSwigExplicitOdEdBaseIO__SWIG_0(swigCPtr, prompt, arg1, OdEdPointTracker.getCPtr(arg2)) : TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getPoint__SWIG_0(swigCPtr, prompt, arg1, OdEdPointTracker.getCPtr(arg2)), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPoint(string prompt, int arg1)
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("getPoint", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getPointSwigExplicitOdEdBaseIO__SWIG_1(swigCPtr, prompt, arg1) : TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getPoint__SWIG_1(swigCPtr, prompt, arg1), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGePoint3d getPoint(string prompt)
	{
		OdGePoint3d result = new OdGePoint3d(SwigDerivedClassHasMethod("getPoint", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getPointSwigExplicitOdEdBaseIO__SWIG_2(swigCPtr, prompt) : TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getPoint__SWIG_2(swigCPtr, prompt), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getKeyState()
	{
		uint result = (SwigDerivedClassHasMethod("getKeyState", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getKeyStateSwigExplicitOdEdBaseIO(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getKeyState(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void putError(string errmsg)
	{
		if (SwigDerivedClassHasMethod("putError", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_putErrorSwigExplicitOdEdBaseIO(swigCPtr, errmsg);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_putError(swigCPtr, errmsg);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool interactive()
	{
		bool result = (SwigDerivedClassHasMethod("interactive", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_interactiveSwigExplicitOdEdBaseIO(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_interactive(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetString__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetString__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgetString__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("putString", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodputString;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetPoint__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetPoint__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getPoint", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetPoint__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getKeyState", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetKeyState;
		}
		if (SwigDerivedClassHasMethod("putError", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodputError;
		}
		if (SwigDerivedClassHasMethod("interactive", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodinteractive;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdEdBaseIO_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdEdBaseIO));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options, IntPtr pTracker)
	{
		return getString(prompt, options, Helpers.GetRXObject<OdEdStringTracker>(pTracker, bOwn: false, bTryAddToTransaction: false));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int options)
	{
		return getString(prompt, options);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetString__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return getString(prompt);
	}

	private void SwigDirectorMethodputString([MarshalAs(UnmanagedType.LPWStr)] string string_)
	{
		try
		{
			putString(string_);
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

	private IntPtr SwigDirectorMethodgetPoint__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string prompt, int arg1, IntPtr arg2)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getPoint(prompt, arg1, Helpers.GetRXObject<OdEdPointTracker>(arg2, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private IntPtr SwigDirectorMethodgetPoint__SWIG_1([MarshalAs(UnmanagedType.LPWStr)] string prompt, int arg1)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getPoint(prompt, arg1)).Handle;
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

	private IntPtr SwigDirectorMethodgetPoint__SWIG_2([MarshalAs(UnmanagedType.LPWStr)] string prompt)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(getPoint(prompt)).Handle;
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

	private uint SwigDirectorMethodgetKeyState()
	{
		return getKeyState();
	}

	private void SwigDirectorMethodputError([MarshalAs(UnmanagedType.LPWStr)] string errmsg)
	{
		try
		{
			putError(errmsg);
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

	private bool SwigDirectorMethodinteractive()
	{
		return interactive();
	}
}
