using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiProceduralGeneratorPE : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiProceduralGeneratorPE_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiProceduralGeneratorPE_1();

	public delegate void SwigDelegateOdGiProceduralGeneratorPE_2(IntPtr pSource);

	public delegate bool SwigDelegateOdGiProceduralGeneratorPE_3(IntPtr pTexture, IntPtr image, double renderCoef);

	public delegate bool SwigDelegateOdGiProceduralGeneratorPE_4(IntPtr pTexture, IntPtr image);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiProceduralGeneratorPE_0 swigDelegate0;

	private SwigDelegateOdGiProceduralGeneratorPE_1 swigDelegate1;

	private SwigDelegateOdGiProceduralGeneratorPE_2 swigDelegate2;

	private SwigDelegateOdGiProceduralGeneratorPE_3 swigDelegate3;

	private SwigDelegateOdGiProceduralGeneratorPE_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[3]
	{
		typeof(OdGiProceduralTexture),
		typeof(OdGiImageBGRA32),
		typeof(double)
	};

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiProceduralTexture),
		typeof(OdGiImageBGRA32)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiProceduralGeneratorPE(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiProceduralGeneratorPE obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiProceduralGeneratorPE(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiProceduralGeneratorPE cast(OdRxObject pObj)
	{
		OdGiProceduralGeneratorPE rXObject = Helpers.GetRXObject<OdGiProceduralGeneratorPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_isASwigExplicitOdGiProceduralGeneratorPE(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_queryXSwigExplicitOdGiProceduralGeneratorPE(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiProceduralGeneratorPE createObject()
	{
		OdGiProceduralGeneratorPE rXObject = Helpers.GetRXObject<OdGiProceduralGeneratorPE>(TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiProceduralGeneratorPE()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiProceduralGeneratorPE(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiProceduralGeneratorPE) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public virtual bool generateProceduralTexture(OdGiProceduralTexture pTexture, OdGiImageBGRA32 image, double renderCoef)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_generateProceduralTexture__SWIG_0(swigCPtr, OdGiProceduralTexture.getCPtr(pTexture), OdGiImageBGRA32.getCPtr(image), renderCoef);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool generateProceduralTexture(OdGiProceduralTexture pTexture, OdGiImageBGRA32 image)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_generateProceduralTexture__SWIG_1(swigCPtr, OdGiProceduralTexture.getCPtr(pTexture), OdGiImageBGRA32.getCPtr(image));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("generateProceduralTexture", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgenerateProceduralTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("generateProceduralTexture", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgenerateProceduralTexture__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiProceduralGeneratorPE_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiProceduralGeneratorPE));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
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

	private bool SwigDirectorMethodgenerateProceduralTexture__SWIG_0(IntPtr pTexture, IntPtr image, double renderCoef)
	{
		return generateProceduralTexture(Helpers.GetRXObject<OdGiProceduralTexture>(pTexture, bOwn: true, bTryAddToTransaction: false), new OdGiImageBGRA32(image, cMemoryOwn: false), renderCoef);
	}

	private bool SwigDirectorMethodgenerateProceduralTexture__SWIG_1(IntPtr pTexture, IntPtr image)
	{
		return generateProceduralTexture(Helpers.GetRXObject<OdGiProceduralTexture>(pTexture, bOwn: true, bTryAddToTransaction: false), new OdGiImageBGRA32(image, cMemoryOwn: false));
	}
}
