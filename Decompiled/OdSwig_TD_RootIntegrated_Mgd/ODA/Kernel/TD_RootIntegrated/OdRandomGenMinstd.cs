using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRandomGenMinstd : OdRandomGen
{
	public delegate IntPtr SwigDelegateOdRandomGenMinstd_0();

	public delegate void SwigDelegateOdRandomGenMinstd_1(uint seed);

	public delegate uint SwigDelegateOdRandomGenMinstd_2();

	public delegate void SwigDelegateOdRandomGenMinstd_3(uint high);

	public delegate uint SwigDelegateOdRandomGenMinstd_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdRandomGenMinstd_0 swigDelegate0;

	private SwigDelegateOdRandomGenMinstd_1 swigDelegate1;

	private SwigDelegateOdRandomGenMinstd_2 swigDelegate2;

	private SwigDelegateOdRandomGenMinstd_3 swigDelegate3;

	private SwigDelegateOdRandomGenMinstd_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[0];

	private static Type[] swigMethodTypes1 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(uint).MakeByRefType() };

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRandomGenMinstd(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRandomGenMinstd obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRandomGenMinstd(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdRandomGenMinstd(uint seed)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRandomGenMinstd__SWIG_0(seed), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRandomGenMinstd) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdRandomGenMinstd()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRandomGenMinstd__SWIG_1(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdRandomGenMinstd) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override OdRandomGen clone()
	{
		IntPtr intPtr = (SwigDerivedClassHasMethod("clone", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_cloneSwigExplicitOdRandomGenMinstd(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_clone(swigCPtr));
		OdRandomGenMinstd result = ((intPtr == IntPtr.Zero) ? null : new OdRandomGenMinstd(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void setSeed(uint seed)
	{
		if (SwigDerivedClassHasMethod("setSeed", swigMethodTypes1))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_setSeedSwigExplicitOdRandomGenMinstd(swigCPtr, seed);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_setSeed(swigCPtr, seed);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint getSeed()
	{
		uint result = (SwigDerivedClassHasMethod("getSeed", swigMethodTypes2) ? TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_getSeedSwigExplicitOdRandomGenMinstd(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_getSeed(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void getRange(out uint high)
	{
		if (SwigDerivedClassHasMethod("getRange", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_getRangeSwigExplicitOdRandomGenMinstd(swigCPtr, out high);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_getRange(swigCPtr, out high);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint generate()
	{
		uint result = (SwigDerivedClassHasMethod("generate", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_generateSwigExplicitOdRandomGenMinstd(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_generate(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
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
		TD_RootIntegrated_GlobalsPINVOKE.OdRandomGenMinstd_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdRandomGenMinstd));
	}

	private IntPtr SwigDirectorMethodclone()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdRandomGen.getCPtr(clone()).Handle;
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
