using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxValueType : OdStaticRxObject_OdRxClass
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxValueType(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxValueType obj)
	{
		if (!(obj == null))
		{
			return obj.swigCPtr;
		}
		return new HandleRef(null, IntPtr.Zero);
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxValueType(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdRxValueType cast(OdRxObject pObj)
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxValueType createObject()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static void rxInit()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_rxInit__SWIG_0();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new static void rxInit(TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegate appNameChangeFunc)
	{
		TD_RootIntegrated_Globals.AppNameChangeFuncPtrDelegateNative appNameChangeFuncPtrDelegateNative = null;
		if (appNameChangeFunc != null)
		{
			appNameChangeFuncPtrDelegateNative = delegate(IntPtr classObj, IntPtr newAppName, int saveVer)
			{
				string newAppName2 = OdString2StringConvHelper.OdStringToString(newAppName);
				string text = newAppName2;
				try
				{
					appNameChangeFunc(OdMarshalHelper.PtrToObject<OdRxClass>(classObj), ref newAppName2, saveVer);
				}
				finally
				{
					if (text != newAppName2)
					{
						OdString2StringConvHelper.AssignStringToOdString(newAppName, newAppName2);
					}
				}
			};
		}
		IntPtr jarg = ((appNameChangeFunc == null) ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(appNameChangeFuncPtrDelegateNative));
		DelegateHolder.Add(appNameChangeFuncPtrDelegateNative);
		TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_rxInit__SWIG_1(jarg);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new static void rxUninit()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_rxUninit();
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdRxValueType rhs)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_IsEqual(swigCPtr, getCPtr(rhs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdRxValueType rhs)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_IsNotEqual(swigCPtr, getCPtr(rhs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isBlittable()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_isBlittable(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEnum()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_isEnum(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isReference()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_isReference(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isSelect()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_isSelect(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isAggregate()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_isAggregate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IOdRxNonBlittableType nonBlittable()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_nonBlittable(swigCPtr);
		IOdRxNonBlittableType result = ((intPtr == IntPtr.Zero) ? null : new IOdRxNonBlittableType(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IOdRxEnumeration enumeration()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_enumeration(swigCPtr);
		IOdRxEnumeration result = ((intPtr == IntPtr.Zero) ? null : new IOdRxEnumeration(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IOdRxReferenceType reference()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_reference(swigCPtr);
		IOdRxReferenceType result = ((intPtr == IntPtr.Zero) ? null : new IOdRxReferenceType(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual IOdRxObjectValue rxObjectValue()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_rxObjectValue(swigCPtr);
		IOdRxObjectValue result = ((intPtr == IntPtr.Zero) ? null : new IOdRxObjectValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxValue createValue()
	{
		return new OdRxValue(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_createValue(swigCPtr), cMemoryOwn: false);
	}

	public override OdRxObject create()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_create(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool toValueType(OdRxValueType vt, OdRxValue instance, OdRxValue result)
	{
		bool result2 = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_toValueType(swigCPtr, getCPtr(vt), OdRxValue.getCPtr(instance), OdRxValue.getCPtr(result));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result2;
	}

	public virtual bool fromValueType(OdRxValue from, OdRxValue instance)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_fromValueType(swigCPtr, OdRxValue.getCPtr(from), OdRxValue.getCPtr(instance));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string typePath(OdRxValue instance)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_typePath(swigCPtr, OdRxValue.getCPtr(instance));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string toString(IntPtr instance, OdRxValueType_StringFormat format)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_toString__SWIG_0(swigCPtr, instance, (int)format);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string toString(IntPtr instance)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_toString__SWIG_1(swigCPtr, instance);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool equalTo(IntPtr a, IntPtr b)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_equalTo(swigCPtr, a, b);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxValueType_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
