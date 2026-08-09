using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdFieldValue : OdValue
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdFieldValue(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdFieldValue obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdFieldValue(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdFieldValue cast(OdRxObject pObj)
	{
		OdFieldValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFieldValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdFieldValue createObject()
	{
		OdFieldValue rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdFieldValue>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdFieldValue()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(OdFieldValue value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_1(getCPtr(value)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(string value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_2(value), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(int value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_3(value), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(double value)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_4(value), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(long date)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_5(date), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(double x, double y)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_6(x, y), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(double x, double y, double z)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_7(x, y, z), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(OdDbObjectId objectId)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_8(OdDbObjectId.getCPtr(objectId)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(OdResBuf resBuf)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_9(OdResBuf.getCPtr(resBuf)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(IntPtr buffer, int bufferSize)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_10(buffer, bufferSize), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(OdGePoint3d p)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_11(OdGePoint3d.getCPtr(p)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdFieldValue(OdGeVector3d p)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdFieldValue__SWIG_12(OdGeVector3d.getCPtr(p)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new bool get(ref string value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(value);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_0(swigCPtr, ref jarg);
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

	public new bool get(out int value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_1(swigCPtr, out value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool get(out double value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_2(swigCPtr, out value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool get(out long date)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_3(swigCPtr, out date);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool get(out double x, out double y)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_4(swigCPtr, out x, out y);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool get(out double x, out double y, out double z)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_5(swigCPtr, out x, out y, out z);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool get(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_6(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool get(ref OdResBuf resBuf)
	{
		IntPtr jarg = ((resBuf == null) ? IntPtr.Zero : OdResBuf.getCPtr(resBuf).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_7(swigCPtr, ref jarg);
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

	public new bool get(out byte[] pBuf)
	{
		IntPtr jarg = IntPtr.Zero;
		try
		{
			bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_8(swigCPtr, out jarg);
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

	public new bool get(OdTimeStamp time)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_0_9(swigCPtr, OdTimeStamp.getCPtr(time));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool get(OdGePoint3d p)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(p));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool get(OdGeVector3d p)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_get__SWIG_2(swigCPtr, OdGeVector3d.getCPtr(p));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(OdValue value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_0(swigCPtr, OdValue.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(string value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_1(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(int value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_2(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(double value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_3(swigCPtr, value);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(long date)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_4(swigCPtr, date);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(double x, double y)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_5(swigCPtr, x, y);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(double x, double y, double z)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_6(swigCPtr, x, y, z);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(OdDbObjectId objectId)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_7(swigCPtr, OdDbObjectId.getCPtr(objectId));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(OdResBuf resBuf)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_8(swigCPtr, OdResBuf.getCPtr(resBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(OdDbEvalVariant ev)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_9(swigCPtr, OdDbEvalVariant.getCPtr(ev));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(IntPtr buffer, int bufferSize)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_10(swigCPtr, buffer, bufferSize);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new bool set(OdTimeStamp time)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_0_11(swigCPtr, OdTimeStamp.getCPtr(time));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(OdGePoint3d p)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(p));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool set(OdGeVector3d p)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_set__SWIG_2(swigCPtr, OdGeVector3d.getCPtr(p));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint flags()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_flags(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdFieldValue_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
