using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdValue : OdStaticRxObject_OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdValue(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdValue obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdValue(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public static explicit operator string(OdValue v)
	{
		return v.AsString();
	}

	public static explicit operator int(OdValue v)
	{
		return v.AsInt32();
	}

	public static explicit operator long(OdValue v)
	{
		return v.AsInt64();
	}

	public static explicit operator OdDbObjectId(OdValue v)
	{
		return v.AsObjectId();
	}

	public static explicit operator double(OdValue v)
	{
		return v.AsDouble();
	}

	public new static OdValue cast(OdRxObject pObj)
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdValue createObject()
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdValue()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(OdValue value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_1(getCPtr(value)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(string value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_2(value), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(int value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_3(value), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(double value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_4(value), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(long date)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_5(date), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(double x, double y)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_6(x, y), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(double x, double y, double z)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_7(x, y, z), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(OdDbObjectId objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_8(OdDbObjectId.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(OdResBuf resBuf)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_9(OdResBuf.getCPtr(resBuf)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(OdDbEvalVariant resBuf)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_10(OdDbEvalVariant.getCPtr(resBuf)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(OdTimeStamp time)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_11(OdTimeStamp.getCPtr(time)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdValue(IntPtr buffer, int bufferSize)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdValue__SWIG_12(buffer, bufferSize), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool reset()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_reset__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdValue_DataType dataType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_dataType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdValue_DataType)result;
	}

	public bool isValid()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_isValid(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string AsString()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_AsString(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int AsInt32()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_AsInt32(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double AsDouble()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_AsDouble(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public long AsInt64()
	{
		long result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_AsInt64(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbObjectId AsObjectId()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_AsObjectId(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdValue Assign(OdValue value)
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_Assign__SWIG_0(swigCPtr, getCPtr(value)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdValue Assign(string value)
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_Assign__SWIG_1(swigCPtr, value), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdValue Assign(int value)
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_Assign__SWIG_2(swigCPtr, value), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdValue Assign(double value)
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_Assign__SWIG_3(swigCPtr, value), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdValue Assign(long date)
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_Assign__SWIG_4(swigCPtr, date), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdValue Assign(OdDbObjectId objectId)
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_Assign__SWIG_5(swigCPtr, OdDbObjectId.getCPtr(objectId)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdValue Assign(OdResBuf resBuf)
	{
		OdValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_Assign__SWIG_6(swigCPtr, OdResBuf.getCPtr(resBuf)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool get(ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_0(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				value = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public bool get(out int value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_1(swigCPtr, out value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool get(out double value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_2(swigCPtr, out value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool get(out long date)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_3(swigCPtr, out date);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool get(out double x, out double y)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_4(swigCPtr, out x, out y);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool get(out double x, out double y, out double z)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_5(swigCPtr, out x, out y, out z);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool get(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_6(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool get(ref OdResBuf resBuf)
	{
		IntPtr jarg = ((resBuf == null) ? IntPtr.Zero : OdResBuf.getCPtr(resBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_7(swigCPtr, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				resBuf = null;
			}
			else if (jarg != intPtr)
			{
				resBuf = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public bool get(out byte[] pBuf)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_8(swigCPtr, out jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			pBuf = Helpers.UnmarshalByteArray(jarg);
		}
	}

	public bool get(OdTimeStamp time)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_get__SWIG_9(swigCPtr, OdTimeStamp.getCPtr(time));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(OdValue value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_0(swigCPtr, getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(string value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_1(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(int value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_2(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(double value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_3(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(long date)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_4(swigCPtr, date);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(double x, double y)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_5(swigCPtr, x, y);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(double x, double y, double z)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_6(swigCPtr, x, y, z);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_7(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(OdResBuf resBuf)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_8(swigCPtr, OdResBuf.getCPtr(resBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(OdDbEvalVariant ev)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_9(swigCPtr, OdDbEvalVariant.getCPtr(ev));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(IntPtr buffer, int bufferSize)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_10(swigCPtr, buffer, bufferSize);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(OdTimeStamp time)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_set__SWIG_11(swigCPtr, OdTimeStamp.getCPtr(time));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool reset(OdValue_DataType nDataType)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_reset__SWIG_1(swigCPtr, (int)nDataType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool resetValue()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_resetValue(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdValue_UnitType unitType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_unitType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdValue_UnitType)result;
	}

	public void setUnitType(OdValue_UnitType nUnitType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_setUnitType(swigCPtr, (int)nUnitType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string getFormat()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_getFormat(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setFormat(string pszFormat)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_setFormat(swigCPtr, pszFormat);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public string format(OdDbDatabase pDb)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_format__SWIG_0(swigCPtr, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string format()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_format__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string format(OdValue_FormatOption nOption, OdDbDatabase pDb)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_format__SWIG_2(swigCPtr, (int)nOption, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string format(OdValue_FormatOption nOption)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_format__SWIG_3(swigCPtr, (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string format(string pszFormat, OdValue_FormatOption nOption, OdDbDatabase pDb)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_format__SWIG_4(swigCPtr, pszFormat, (int)nOption, OdDbDatabase.getCPtr(pDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string format(string pszFormat, OdValue_FormatOption nOption)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_format__SWIG_5(swigCPtr, pszFormat, (int)nOption);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool format(string pszFormat, ref string pszValue, OdDbDatabase pDb)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pszValue);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_format__SWIG_6(swigCPtr, pszFormat, ref jarg, OdDbDatabase.getCPtr(pDb));
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				pszValue = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public bool format(string pszFormat, ref string pszValue)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pszValue);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_format__SWIG_7(swigCPtr, pszFormat, ref jarg);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				pszValue = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public bool convertTo(OdValue_DataType nDataType, OdValue_UnitType nUnitType)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_convertTo__SWIG_0(swigCPtr, (int)nDataType, (int)nUnitType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool convertTo(OdValue_DataType nDataType, OdValue_UnitType nUnitType, bool bResetIfIncompatible)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_convertTo__SWIG_1(swigCPtr, (int)nDataType, (int)nUnitType, bResetIfIncompatible);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult dwgInFields(OdDbDwgFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_dwgInFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void dwgOutFields(OdDbDwgFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_dwgOutFields(swigCPtr, OdDbDwgFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdResult dxfInFields(OdDbDxfFiler pFiler)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_dxfInFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual void dxfOutFields(OdDbDxfFiler pFiler)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_dxfOutFields(swigCPtr, OdDbDxfFiler.getCPtr(pFiler));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdValue_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
