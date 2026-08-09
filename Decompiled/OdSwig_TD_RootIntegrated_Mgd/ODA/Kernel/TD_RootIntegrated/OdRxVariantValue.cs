using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxVariantValue : OdRxVariant
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxVariantValue(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxVariantValue_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxVariantValue obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	public OdRxVariantValue(IntPtr value)
		: this((IntPtr.Size == 4) ? TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_8(value.ToInt32()) : TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_10(value.ToInt64()), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	~OdRxVariantValue()
	{
		Dispose(disposing: false);
	}

	public new void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected new virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxVariantValue(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public void assign(OdRxVariant pVariant)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxVariantValue_assign(swigCPtr, OdRxVariant.getCPtr(pVariant));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(OdRxObject pObject)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_0(OdRxObject.getCPtr(pObject)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(OdRxVariant pVariant)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_1(OdRxVariant.getCPtr(pVariant)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(bool value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_2(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(byte value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_3(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(sbyte value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_4(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(ushort value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_5(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(short value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_6(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(uint value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_7(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(int value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_8(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(ulong value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_9(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(long value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_10(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(double value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_11(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(string value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_12(value), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(OdStringArray value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_13(OdStringArray.getCPtr(value)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(OdRxObjectPtrArray value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_14(OdRxObjectPtrArray.getCPtr(value)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(OdDoubleArray value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_15(OdDoubleArray.getCPtr(value).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxVariantValue(OdUInt64Array value)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdRxVariantValue__SWIG_16(OdUInt64Array.getCPtr(value).Handle), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int AsInt32()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdRxVariantValue_AsInt32__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public long AsInt64()
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdRxVariantValue_AsInt64__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double AsDouble()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdRxVariantValue_AsDouble__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string AsString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxVariantValue_AsString__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
