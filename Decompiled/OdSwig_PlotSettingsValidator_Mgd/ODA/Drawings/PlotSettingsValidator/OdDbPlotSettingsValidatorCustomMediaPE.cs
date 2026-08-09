using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Drawings.TD_DbCoreIntegrated;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.PlotSettingsValidator;

public class OdDbPlotSettingsValidatorCustomMediaPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_1();

	public delegate void SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_3(IntPtr media);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_4(IntPtr media);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_5([MarshalAs(UnmanagedType.LPWStr)] string canonicalName);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_6([MarshalAs(UnmanagedType.LPWStr)] string canonicalName, IntPtr media);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_7(ushort index, IntPtr media);

	public delegate int SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_8();

	public delegate ushort SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_9();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_0 swigDelegate0;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_1 swigDelegate1;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_2 swigDelegate2;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_3 swigDelegate3;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_4 swigDelegate4;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_5 swigDelegate5;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_6 swigDelegate6;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_7 swigDelegate7;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_8 swigDelegate8;

	private SwigDelegateOdDbPlotSettingsValidatorCustomMediaPE_9 swigDelegate9;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdDbPlotSettingsValidatorPE.psvPaperInfo) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(OdDbPlotSettingsValidatorPE.psvPaperInfo) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(string),
		typeof(OdDbPlotSettingsValidatorPE.psvPaperInfo)
	};

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(ushort),
		typeof(OdDbPlotSettingsValidatorPE.psvPaperInfo)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbPlotSettingsValidatorCustomMediaPE(IntPtr cPtr, bool cMemoryOwn)
		: base(PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbPlotSettingsValidatorCustomMediaPE obj)
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
					PlotSettingsValidator_GlobalsPINVOKE.delete_OdDbPlotSettingsValidatorCustomMediaPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbPlotSettingsValidatorCustomMediaPE cast(OdRxObject pObj)
	{
		OdDbPlotSettingsValidatorCustomMediaPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettingsValidatorCustomMediaPE>(PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_isASwigExplicitOdDbPlotSettingsValidatorCustomMediaPE(swigCPtr) : PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_queryXSwigExplicitOdDbPlotSettingsValidatorCustomMediaPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbPlotSettingsValidatorCustomMediaPE createObject()
	{
		OdDbPlotSettingsValidatorCustomMediaPE rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbPlotSettingsValidatorCustomMediaPE>(PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdResult addMedia(OdDbPlotSettingsValidatorPE.psvPaperInfo media)
	{
		int result = PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_addMedia(swigCPtr, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(media));
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult editMedia(OdDbPlotSettingsValidatorPE.psvPaperInfo media)
	{
		int result = PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_editMedia(swigCPtr, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(media));
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult removeMedia(string canonicalName)
	{
		int result = PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_removeMedia(swigCPtr, canonicalName);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getMedia(string canonicalName, OdDbPlotSettingsValidatorPE.psvPaperInfo media)
	{
		int result = PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_getMedia__SWIG_0(swigCPtr, canonicalName, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(media));
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult getMedia(ushort index, OdDbPlotSettingsValidatorPE.psvPaperInfo media)
	{
		int result = PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_getMedia__SWIG_1(swigCPtr, index, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(media));
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdResult clear()
	{
		int result = PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_clear(swigCPtr);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual ushort size()
	{
		ushort result = PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_size(swigCPtr);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_getRealClassName(ptr);
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbPlotSettingsValidatorCustomMediaPE()
		: this(PlotSettingsValidator_GlobalsPINVOKE.new_OdDbPlotSettingsValidatorCustomMediaPE(), cMemoryOwn: true)
	{
		if (PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PlotSettingsValidator_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbPlotSettingsValidatorCustomMediaPE) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("addMedia", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodaddMedia;
		}
		if (SwigDerivedClassHasMethod("editMedia", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodeditMedia;
		}
		if (SwigDerivedClassHasMethod("removeMedia", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodremoveMedia;
		}
		if (SwigDerivedClassHasMethod("getMedia", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgetMedia__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getMedia", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgetMedia__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodclear;
		}
		if (SwigDerivedClassHasMethod("size", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsize;
		}
		PlotSettingsValidator_GlobalsPINVOKE.OdDbPlotSettingsValidatorCustomMediaPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbPlotSettingsValidatorCustomMediaPE));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			PlotSettingsValidator_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PlotSettingsValidator_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PlotSettingsValidator_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PlotSettingsValidator_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private int SwigDirectorMethodaddMedia(IntPtr media)
	{
		return (int)addMedia(new OdDbPlotSettingsValidatorPE.psvPaperInfo(media, cMemoryOwn: false));
	}

	private int SwigDirectorMethodeditMedia(IntPtr media)
	{
		return (int)editMedia(new OdDbPlotSettingsValidatorPE.psvPaperInfo(media, cMemoryOwn: false));
	}

	private int SwigDirectorMethodremoveMedia([MarshalAs(UnmanagedType.LPWStr)] string canonicalName)
	{
		return (int)removeMedia(canonicalName);
	}

	private int SwigDirectorMethodgetMedia__SWIG_0([MarshalAs(UnmanagedType.LPWStr)] string canonicalName, IntPtr media)
	{
		return (int)getMedia(canonicalName, new OdDbPlotSettingsValidatorPE.psvPaperInfo(media, cMemoryOwn: false));
	}

	private int SwigDirectorMethodgetMedia__SWIG_1(ushort index, IntPtr media)
	{
		return (int)getMedia(index, new OdDbPlotSettingsValidatorPE.psvPaperInfo(media, cMemoryOwn: false));
	}

	private int SwigDirectorMethodclear()
	{
		return (int)clear();
	}

	private ushort SwigDirectorMethodsize()
	{
		return size();
	}
}
