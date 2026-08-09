using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxSpecifiedValueType : OdRxValueType
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxSpecifiedValueType(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxSpecifiedValueType obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxSpecifiedValueType(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdRxSpecifiedValueType(OdRxValueType underlyingValueType, string typePath)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxSpecifiedValueType(OdRxValueType.getCPtr(underlyingValueType), typePath), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxValueType underlyingValueType()
	{
		OdRxValueType rXObject = Helpers.GetRXObject<OdRxValueType>(TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_underlyingValueType(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override IOdRxNonBlittableType nonBlittable()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_nonBlittable(swigCPtr);
		IOdRxNonBlittableType result = ((intPtr == IntPtr.Zero) ? null : new IOdRxNonBlittableType(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override IOdRxEnumeration enumeration()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_enumeration(swigCPtr);
		IOdRxEnumeration result = ((intPtr == IntPtr.Zero) ? null : new IOdRxEnumeration(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override IOdRxReferenceType reference()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_reference(swigCPtr);
		IOdRxReferenceType result = ((intPtr == IntPtr.Zero) ? null : new IOdRxReferenceType(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override IOdRxObjectValue rxObjectValue()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_rxObjectValue(swigCPtr);
		IOdRxObjectValue result = ((intPtr == IntPtr.Zero) ? null : new IOdRxObjectValue(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string subToString(IntPtr instance, OdRxValueType_StringFormat format)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_subToString(swigCPtr, instance, (int)format);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool subEqualTo(IntPtr a, IntPtr b)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_subEqualTo(swigCPtr, a, b);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override OdRxValue createValue()
	{
		return new OdRxValue(TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_createValue(swigCPtr), cMemoryOwn: false);
	}

	public string typePath()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_typePath(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsEqual(OdRxSpecifiedValueType rhs)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_IsEqual(swigCPtr, getCPtr(rhs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdRxSpecifiedValueType rhs)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_IsNotEqual(swigCPtr, getCPtr(rhs));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxSpecifiedValueType_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
