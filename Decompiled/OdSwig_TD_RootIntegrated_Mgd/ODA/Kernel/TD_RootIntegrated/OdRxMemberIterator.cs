using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxMemberIterator : IDisposable
{
	public delegate bool SwigDelegateOdRxMemberIterator_0();

	public delegate bool SwigDelegateOdRxMemberIterator_1();

	public delegate IntPtr SwigDelegateOdRxMemberIterator_2();

	public delegate IntPtr SwigDelegateOdRxMemberIterator_3([MarshalAs(UnmanagedType.LPWStr)] string name);

	public delegate ulong SwigDelegateOdRxMemberIterator_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdRxMemberIterator_0 swigDelegate0;

	private SwigDelegateOdRxMemberIterator_1 swigDelegate1;

	private SwigDelegateOdRxMemberIterator_2 swigDelegate2;

	private SwigDelegateOdRxMemberIterator_3 swigDelegate3;

	private SwigDelegateOdRxMemberIterator_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxMemberIterator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxMemberIterator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxMemberIterator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxMemberIterator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool done()
	{
		bool result = (SwigDerivedClassHasMethod("done", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_doneSwigExplicitOdRxMemberIterator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_done(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool next()
	{
		bool result = (SwigDerivedClassHasMethod("next", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_nextSwigExplicitOdRxMemberIterator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_next(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxMember current()
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(SwigDerivedClassHasMethod("current", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_currentSwigExplicitOdRxMemberIterator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_current(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxMember find(string name)
	{
		OdRxMember rXObject = Helpers.GetRXObject<OdRxMember>(SwigDerivedClassHasMethod("find", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_findSwigExplicitOdRxMemberIterator(swigCPtr, name) : TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_find(swigCPtr, name), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual ulong size()
	{
		ulong result = (SwigDerivedClassHasMethod("size", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_sizeSwigExplicitOdRxMemberIterator(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_size(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected OdRxMemberIterator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxMemberIterator(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRxMemberIterator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("done", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethoddone;
		}
		if (SwigDerivedClassHasMethod("next", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodnext;
		}
		if (SwigDerivedClassHasMethod("current", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodcurrent;
		}
		if (SwigDerivedClassHasMethod("find", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodfind;
		}
		if (SwigDerivedClassHasMethod("size", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsize;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRxMemberIterator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRxMemberIterator));
	}

	private bool SwigDirectorMethoddone()
	{
		return done();
	}

	private bool SwigDirectorMethodnext()
	{
		return next();
	}

	private IntPtr SwigDirectorMethodcurrent()
	{
		return OdRxMember.getCPtr(current()).Handle;
	}

	private IntPtr SwigDirectorMethodfind([MarshalAs(UnmanagedType.LPWStr)] string name)
	{
		return OdRxMember.getCPtr(find(name)).Handle;
	}

	private ulong SwigDirectorMethodsize()
	{
		return size();
	}
}
