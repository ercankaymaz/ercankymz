using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiIBLBackgroundTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiIBLBackgroundTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiIBLBackgroundTraits_1();

	public delegate void SwigDelegateOdGiIBLBackgroundTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiIBLBackgroundTraits_3(bool bEnable);

	public delegate bool SwigDelegateOdGiIBLBackgroundTraits_4();

	public delegate void SwigDelegateOdGiIBLBackgroundTraits_5([MarshalAs(UnmanagedType.LPWStr)] string filename);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiIBLBackgroundTraits_6();

	public delegate void SwigDelegateOdGiIBLBackgroundTraits_7(double rotation);

	public delegate double SwigDelegateOdGiIBLBackgroundTraits_8();

	public delegate void SwigDelegateOdGiIBLBackgroundTraits_9(bool bDisplay);

	public delegate bool SwigDelegateOdGiIBLBackgroundTraits_10();

	public delegate void SwigDelegateOdGiIBLBackgroundTraits_11(IntPtr bgId);

	public delegate IntPtr SwigDelegateOdGiIBLBackgroundTraits_12();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiIBLBackgroundTraits_0 swigDelegate0;

	private SwigDelegateOdGiIBLBackgroundTraits_1 swigDelegate1;

	private SwigDelegateOdGiIBLBackgroundTraits_2 swigDelegate2;

	private SwigDelegateOdGiIBLBackgroundTraits_3 swigDelegate3;

	private SwigDelegateOdGiIBLBackgroundTraits_4 swigDelegate4;

	private SwigDelegateOdGiIBLBackgroundTraits_5 swigDelegate5;

	private SwigDelegateOdGiIBLBackgroundTraits_6 swigDelegate6;

	private SwigDelegateOdGiIBLBackgroundTraits_7 swigDelegate7;

	private SwigDelegateOdGiIBLBackgroundTraits_8 swigDelegate8;

	private SwigDelegateOdGiIBLBackgroundTraits_9 swigDelegate9;

	private SwigDelegateOdGiIBLBackgroundTraits_10 swigDelegate10;

	private SwigDelegateOdGiIBLBackgroundTraits_11 swigDelegate11;

	private SwigDelegateOdGiIBLBackgroundTraits_12 swigDelegate12;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes12 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiIBLBackgroundTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiIBLBackgroundTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiIBLBackgroundTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiIBLBackgroundTraits cast(OdRxObject pObj)
	{
		OdGiIBLBackgroundTraits rXObject = Helpers.GetRXObject<OdGiIBLBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_isASwigExplicitOdGiIBLBackgroundTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_queryXSwigExplicitOdGiIBLBackgroundTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiIBLBackgroundTraits createObject()
	{
		OdGiIBLBackgroundTraits rXObject = Helpers.GetRXObject<OdGiIBLBackgroundTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setEnable(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_setEnable(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool enable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_enable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setIBLImageName(string filename)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_setIBLImageName(swigCPtr, filename);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string IBLImageName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_IBLImageName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setRotation(double rotation)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_setRotation(swigCPtr, rotation);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double rotation()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_rotation(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDisplayImage(bool bDisplay)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_setDisplayImage(swigCPtr, bDisplay);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool displayImage()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_displayImage(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setSecondaryBackground(OdDbStub bgId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_setSecondaryBackground(swigCPtr, OdDbStub.getCPtr(bgId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbStub secondaryBackground()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_secondaryBackground(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiIBLBackgroundTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiIBLBackgroundTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiIBLBackgroundTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setEnable", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetEnable;
		}
		if (SwigDerivedClassHasMethod("enable", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodenable;
		}
		if (SwigDerivedClassHasMethod("setIBLImageName", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetIBLImageName;
		}
		if (SwigDerivedClassHasMethod("IBLImageName", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodIBLImageName;
		}
		if (SwigDerivedClassHasMethod("setRotation", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetRotation;
		}
		if (SwigDerivedClassHasMethod("rotation", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodrotation;
		}
		if (SwigDerivedClassHasMethod("setDisplayImage", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetDisplayImage;
		}
		if (SwigDerivedClassHasMethod("displayImage", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethoddisplayImage;
		}
		if (SwigDerivedClassHasMethod("setSecondaryBackground", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetSecondaryBackground;
		}
		if (SwigDerivedClassHasMethod("secondaryBackground", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsecondaryBackground;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiIBLBackgroundTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiIBLBackgroundTraits));
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

	private void SwigDirectorMethodsetEnable(bool bEnable)
	{
		try
		{
			setEnable(bEnable);
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

	private bool SwigDirectorMethodenable()
	{
		return enable();
	}

	private void SwigDirectorMethodsetIBLImageName([MarshalAs(UnmanagedType.LPWStr)] string filename)
	{
		try
		{
			setIBLImageName(filename);
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
	private string SwigDirectorMethodIBLImageName()
	{
		return IBLImageName();
	}

	private void SwigDirectorMethodsetRotation(double rotation)
	{
		try
		{
			setRotation(rotation);
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

	private double SwigDirectorMethodrotation()
	{
		return rotation();
	}

	private void SwigDirectorMethodsetDisplayImage(bool bDisplay)
	{
		try
		{
			setDisplayImage(bDisplay);
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

	private bool SwigDirectorMethoddisplayImage()
	{
		return displayImage();
	}

	private void SwigDirectorMethodsetSecondaryBackground(IntPtr bgId)
	{
		try
		{
			setSecondaryBackground((bgId == IntPtr.Zero) ? null : new OdDbStub(bgId, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodsecondaryBackground()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(secondaryBackground()).Handle;
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
}
