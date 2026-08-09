using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbHyperlink : IDisposable
{
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHyperlink_0();

	public delegate void SwigDelegateOdDbHyperlink_1([MarshalAs(UnmanagedType.LPWStr)] string name);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHyperlink_2();

	public delegate void SwigDelegateOdDbHyperlink_3([MarshalAs(UnmanagedType.LPWStr)] string description);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHyperlink_4();

	public delegate void SwigDelegateOdDbHyperlink_5([MarshalAs(UnmanagedType.LPWStr)] string subLocation);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbHyperlink_6();

	public delegate bool SwigDelegateOdDbHyperlink_7();

	public delegate int SwigDelegateOdDbHyperlink_8();

	public delegate int SwigDelegateOdDbHyperlink_9();

	public delegate void SwigDelegateOdDbHyperlink_10(int lFlags);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdDbHyperlink_0 swigDelegate0;

	private SwigDelegateOdDbHyperlink_1 swigDelegate1;

	private SwigDelegateOdDbHyperlink_2 swigDelegate2;

	private SwigDelegateOdDbHyperlink_3 swigDelegate3;

	private SwigDelegateOdDbHyperlink_4 swigDelegate4;

	private SwigDelegateOdDbHyperlink_5 swigDelegate5;

	private SwigDelegateOdDbHyperlink_6 swigDelegate6;

	private SwigDelegateOdDbHyperlink_7 swigDelegate7;

	private SwigDelegateOdDbHyperlink_8 swigDelegate8;

	private SwigDelegateOdDbHyperlink_9 swigDelegate9;

	private SwigDelegateOdDbHyperlink_10 swigDelegate10;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(int) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbHyperlink(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbHyperlink obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbHyperlink()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbHyperlink(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbHyperlink()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbHyperlink(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbHyperlink) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual string name()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_name(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setName(string name)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_setName(swigCPtr, name);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string description()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_description(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDescription(string description)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_setDescription(swigCPtr, description);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string subLocation()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_subLocation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSubLocation(string subLocation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_setSubLocation(swigCPtr, subLocation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string getDisplayString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_getDisplayString(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isOutermostContainer()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_isOutermostContainer(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getNestedLevel()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_getNestedLevel(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int flags()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_flags(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setFlags(int lFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_setFlags(swigCPtr, lFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("name", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodname;
		}
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("description", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethoddescription;
		}
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetDescription;
		}
		if (SwigDerivedClassHasMethod("subLocation", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsubLocation;
		}
		if (SwigDerivedClassHasMethod("setSubLocation", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetSubLocation;
		}
		if (SwigDerivedClassHasMethod("getDisplayString", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetDisplayString;
		}
		if (SwigDerivedClassHasMethod("isOutermostContainer", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisOutermostContainer;
		}
		if (SwigDerivedClassHasMethod("getNestedLevel", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetNestedLevel;
		}
		if (SwigDerivedClassHasMethod("flags", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodflags;
		}
		if (SwigDerivedClassHasMethod("setFlags", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetFlags;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbHyperlink_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbHyperlink));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodname()
	{
		return name();
	}

	private void SwigDirectorMethodsetName([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		try
		{
			setName(name);
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
	private string SwigDirectorMethoddescription()
	{
		return description();
	}

	private void SwigDirectorMethodsetDescription([MarshalAs(UnmanagedType.LPWStr)] string description)
	{
		try
		{
			setDescription(description);
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
	private string SwigDirectorMethodsubLocation()
	{
		return subLocation();
	}

	private void SwigDirectorMethodsetSubLocation([MarshalAs(UnmanagedType.LPWStr)] string subLocation)
	{
		try
		{
			setSubLocation(subLocation);
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
	private string SwigDirectorMethodgetDisplayString()
	{
		return getDisplayString();
	}

	private bool SwigDirectorMethodisOutermostContainer()
	{
		return isOutermostContainer();
	}

	private int SwigDirectorMethodgetNestedLevel()
	{
		return getNestedLevel();
	}

	private int SwigDirectorMethodflags()
	{
		return flags();
	}

	private void SwigDirectorMethodsetFlags(int lFlags)
	{
		try
		{
			setFlags(lFlags);
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
