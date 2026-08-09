using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiRasterImageFileTexture : OdGiImageFileTexture
{
	public delegate IntPtr SwigDelegateOdGiRasterImageFileTexture_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiRasterImageFileTexture_1();

	public delegate void SwigDelegateOdGiRasterImageFileTexture_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiRasterImageFileTexture_3([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiRasterImageFileTexture_4();

	public delegate void SwigDelegateOdGiRasterImageFileTexture_5(IntPtr pRasterImage);

	public delegate IntPtr SwigDelegateOdGiRasterImageFileTexture_6();

	public delegate void SwigDelegateOdGiRasterImageFileTexture_7(IntPtr pRasterImage);

	public delegate IntPtr SwigDelegateOdGiRasterImageFileTexture_8();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiRasterImageFileTexture_0 swigDelegate0;

	private SwigDelegateOdGiRasterImageFileTexture_1 swigDelegate1;

	private SwigDelegateOdGiRasterImageFileTexture_2 swigDelegate2;

	private SwigDelegateOdGiRasterImageFileTexture_3 swigDelegate3;

	private SwigDelegateOdGiRasterImageFileTexture_4 swigDelegate4;

	private SwigDelegateOdGiRasterImageFileTexture_5 swigDelegate5;

	private SwigDelegateOdGiRasterImageFileTexture_6 swigDelegate6;

	private SwigDelegateOdGiRasterImageFileTexture_7 swigDelegate7;

	private SwigDelegateOdGiRasterImageFileTexture_8 swigDelegate8;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(OdGiRasterImage) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGiRasterImageTexture) };

	private static Type[] swigMethodTypes8 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiRasterImageFileTexture(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiRasterImageFileTexture obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiRasterImageFileTexture(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiRasterImageFileTexture cast(OdRxObject pObj)
	{
		OdGiRasterImageFileTexture rXObject = Helpers.GetRXObject<OdGiRasterImageFileTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_isASwigExplicitOdGiRasterImageFileTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_queryXSwigExplicitOdGiRasterImageFileTexture(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setRasterImage(OdGiRasterImage pRasterImage)
	{
		if (SwigDerivedClassHasMethod("setRasterImage", swigMethodTypes5))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_setRasterImageSwigExplicitOdGiRasterImageFileTexture(swigCPtr, OdGiRasterImage.getCPtr(pRasterImage));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_setRasterImage(swigCPtr, OdGiRasterImage.getCPtr(pRasterImage));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiRasterImage rasterImage()
	{
		OdGiRasterImage rXObject = Helpers.GetRXObject<OdGiRasterImage>(SwigDerivedClassHasMethod("rasterImage", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_rasterImageSwigExplicitOdGiRasterImageFileTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_rasterImage(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setRasterImageTexture(OdGiRasterImageTexture pRasterImage)
	{
		if (SwigDerivedClassHasMethod("setRasterImageTexture", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_setRasterImageTextureSwigExplicitOdGiRasterImageFileTexture(swigCPtr, OdGiRasterImageTexture.getCPtr(pRasterImage));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_setRasterImageTexture(swigCPtr, OdGiRasterImageTexture.getCPtr(pRasterImage));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiRasterImageTexture rasterImageTexture()
	{
		OdGiRasterImageTexture rXObject = Helpers.GetRXObject<OdGiRasterImageTexture>(SwigDerivedClassHasMethod("rasterImageTexture", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_rasterImageTextureSwigExplicitOdGiRasterImageFileTexture(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_rasterImageTexture(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override bool IsEqual(OdGiMaterialTexture texture)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_IsEqual(swigCPtr, OdGiMaterialTexture.getCPtr(texture));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiRasterImageFileTexture Assign(OdGiRasterImageFileTexture texture)
	{
		OdGiRasterImageFileTexture rXObject = Helpers.GetRXObject<OdGiRasterImageFileTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_Assign(swigCPtr, getCPtr(texture)), bOwn: false, bTryAddToTransaction: true);
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
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_copyFromSwigExplicitOdGiRasterImageFileTexture(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiRasterImageFileTexture createObject()
	{
		OdGiRasterImageFileTexture rXObject = Helpers.GetRXObject<OdGiRasterImageFileTexture>(TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiRasterImageFileTexture()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiRasterImageFileTexture(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiRasterImageFileTexture) != GetType();
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
		if (SwigDerivedClassHasMethod("setSourceFileName", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetSourceFileName;
		}
		if (SwigDerivedClassHasMethod("sourceFileName", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsourceFileName;
		}
		if (SwigDerivedClassHasMethod("setRasterImage", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetRasterImage;
		}
		if (SwigDerivedClassHasMethod("rasterImage", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodrasterImage;
		}
		if (SwigDerivedClassHasMethod("setRasterImageTexture", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetRasterImageTexture;
		}
		if (SwigDerivedClassHasMethod("rasterImageTexture", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodrasterImageTexture;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiRasterImageFileTexture_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiRasterImageFileTexture));
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

	private void SwigDirectorMethodsetSourceFileName([MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		try
		{
			setSourceFileName(fileName);
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
	private string SwigDirectorMethodsourceFileName()
	{
		return sourceFileName();
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

	private void SwigDirectorMethodsetRasterImageTexture(IntPtr pRasterImage)
	{
		try
		{
			setRasterImageTexture(Helpers.GetRXObject<OdGiRasterImageTexture>(pRasterImage, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodrasterImageTexture()
	{
		return OdGiRasterImageTexture.getCPtr(rasterImageTexture()).Handle;
	}
}
