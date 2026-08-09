using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdDbLibraryInfo : IDisposable
{
	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLibraryInfo_0();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLibraryInfo_1();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLibraryInfo_2();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLibraryInfo_3();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbLibraryInfo_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdDbLibraryInfo_0 swigDelegate0;

	private SwigDelegateOdDbLibraryInfo_1 swigDelegate1;

	private SwigDelegateOdDbLibraryInfo_2 swigDelegate2;

	private SwigDelegateOdDbLibraryInfo_3 swigDelegate3;

	private SwigDelegateOdDbLibraryInfo_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbLibraryInfo(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbLibraryInfo obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbLibraryInfo()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdDbLibraryInfo(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual string getLibName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbLibraryInfo_getLibName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getLibVersion()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbLibraryInfo_getLibVersion(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getCompanyName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbLibraryInfo_getCompanyName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getCopyright()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbLibraryInfo_getCopyright(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getBuildComments()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdDbLibraryInfo_getBuildComments(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbLibraryInfo()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdDbLibraryInfo(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbLibraryInfo) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("getLibName", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodgetLibName;
		}
		if (SwigDerivedClassHasMethod("getLibVersion", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodgetLibVersion;
		}
		if (SwigDerivedClassHasMethod("getCompanyName", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetCompanyName;
		}
		if (SwigDerivedClassHasMethod("getCopyright", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetCopyright;
		}
		if (SwigDerivedClassHasMethod("getBuildComments", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetBuildComments;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdDbLibraryInfo_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbLibraryInfo));
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetLibName()
	{
		return getLibName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetLibVersion()
	{
		return getLibVersion();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetCompanyName()
	{
		return getCompanyName();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetCopyright()
	{
		return getCopyright();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetBuildComments()
	{
		return getBuildComments();
	}
}
