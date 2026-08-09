using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRandomGen : IDisposable
{
	public delegate IntPtr SwigDelegateOdRandomGen_0();

	public delegate void SwigDelegateOdRandomGen_1(uint seed);

	public delegate uint SwigDelegateOdRandomGen_2();

	public delegate void SwigDelegateOdRandomGen_3(uint high);

	public delegate uint SwigDelegateOdRandomGen_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdRandomGen_0 swigDelegate0;

	private SwigDelegateOdRandomGen_1 swigDelegate1;

	private SwigDelegateOdRandomGen_2 swigDelegate2;

	private SwigDelegateOdRandomGen_3 swigDelegate3;

	private SwigDelegateOdRandomGen_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(uint).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRandomGen(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRandomGen obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRandomGen()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRandomGen(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual OdRandomGen clone()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRandomGen_clone(swigCPtr);
		OdRandomGen result = ((intPtr == IntPtr.Zero) ? null : new OdRandomGen(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSeed(uint seed)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRandomGen_setSeed(swigCPtr, seed);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getSeed()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRandomGen_getSeed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getRange(out uint high)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRandomGen_getRange(swigCPtr, out high);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint generate()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRandomGen_generate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRandomGen()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRandomGen(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRandomGen) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("clone", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodclone;
		}
		if (SwigDerivedClassHasMethod("setSeed", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodsetSeed;
		}
		if (SwigDerivedClassHasMethod("getSeed", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodgetSeed;
		}
		if (SwigDerivedClassHasMethod("getRange", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetRange;
		}
		if (SwigDerivedClassHasMethod("generate", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgenerate;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdRandomGen_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRandomGen));
	}

	private IntPtr SwigDirectorMethodclone()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return getCPtr(clone()).Handle;
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

	private void SwigDirectorMethodsetSeed(uint seed)
	{
		try
		{
			setSeed(seed);
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

	private uint SwigDirectorMethodgetSeed()
	{
		return getSeed();
	}

	private void SwigDirectorMethodgetRange(uint high)
	{
		try
		{
			getRange(out high);
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

	private uint SwigDirectorMethodgenerate()
	{
		return generate();
	}
}
