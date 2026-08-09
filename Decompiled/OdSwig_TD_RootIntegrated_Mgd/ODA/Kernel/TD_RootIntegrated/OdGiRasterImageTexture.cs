using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRasterImageTexture : OdGiImageTexture
{
	public delegate IntPtr SwigDelegateOdGiRasterImageTexture_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRasterImageTexture_1();

	public delegate void SwigDelegateOdGiRasterImageTexture_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiRasterImageTexture_3(IntPtr pRasterImage);

	public delegate IntPtr SwigDelegateOdGiRasterImageTexture_4();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRasterImageTexture_0 swigDelegate0;

	private SwigDelegateOdGiRasterImageTexture_1 swigDelegate1;

	private SwigDelegateOdGiRasterImageTexture_2 swigDelegate2;

	private SwigDelegateOdGiRasterImageTexture_3 swigDelegate3;

	private SwigDelegateOdGiRasterImageTexture_4 swigDelegate4;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiRasterImage) };

	private static Type[] swigMethodTypes4 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRasterImageTexture(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRasterImageTexture obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRasterImageTexture(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiRasterImageTexture cast(OdRxObject pObj)
	{
		OdGiRasterImageTexture rXObject = Helpers.GetRXObject<OdGiRasterImageTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_isASwigExplicitOdGiRasterImageTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_queryXSwigExplicitOdGiRasterImageTexture(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setRasterImage(OdGiRasterImage pRasterImage)
	{
		if (SwigDerivedClassHasMethod("setRasterImage", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_setRasterImageSwigExplicitOdGiRasterImageTexture(swigCPtr, OdGiRasterImage.getCPtr(pRasterImage));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_setRasterImage(swigCPtr, OdGiRasterImage.getCPtr(pRasterImage));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiRasterImage rasterImage()
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("rasterImage", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_rasterImageSwigExplicitOdGiRasterImageTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_rasterImage(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool IsEqual(OdGiMaterialTexture texture)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_IsEqual(swigCPtr, OdGiMaterialTexture.getCPtr(texture));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRasterImageTexture Assign(OdGiRasterImageTexture texture)
	{
		OdGiRasterImageTexture rXObject = Helpers.GetRXObject<OdGiRasterImageTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_Assign(swigCPtr, getCPtr(texture)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_copyFromSwigExplicitOdGiRasterImageTexture(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiRasterImageTexture createObject()
	{
		OdGiRasterImageTexture rXObject = Helpers.GetRXObject<OdGiRasterImageTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImageTexture()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRasterImageTexture(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRasterImageTexture) != GetType();
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
		if (SwigDerivedClassHasMethod("setRasterImage", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetRasterImage;
		}
		if (SwigDerivedClassHasMethod("rasterImage", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodrasterImage;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageTexture_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRasterImageTexture));
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

	private void SwigDirectorMethodsetRasterImage(IntPtr pRasterImage)
	{
		try
		{
			setRasterImage(Helpers.GetRXObject<OdGiRasterImage>(pRasterImage, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodrasterImage()
	{
		return OdGiRasterImage.getCPtr(rasterImage()).Handle;
	}
}
