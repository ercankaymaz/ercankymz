using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdVariant : IDisposable
{
	public class TypeFactory : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TypeFactory(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(TypeFactory obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~TypeFactory()
		{
			Dispose(disposing: false);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			lock (this)
			{
				if (swigCPtr.Handle != IntPtr.Zero)
				{
					if (swigCMemOwn)
					{
						swigCMemOwn = false;
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdVariant_TypeFactory(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public virtual void construct(IntPtr pData)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdVariant_TypeFactory_construct(swigCPtr, pData);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void destroy(IntPtr pData)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdVariant_TypeFactory_destroy(swigCPtr, pData);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate void SwigDelegateOdVariant_0(int newType, int type, IntPtr data);

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdVariant_0 swigDelegate0;

	private static Type[] swigMethodTypes0 = new Type[3]
	{
		typeof(int),
		typeof(int).MakeByRefType(),
		typeof(IntPtr)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdVariant(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdVariant obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdVariant()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdVariant(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	protected virtual void setVarType(int newType, out int type, IntPtr data)
	{
		if (SwigDerivedClassHasMethod("setVarType", swigMethodTypes0))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setVarTypeSwigExplicitOdVariant(swigCPtr, newType, out type, data);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setVarType(swigCPtr, newType, out type, data);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static TypeFactory typeFactory(int type)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_typeFactory(type);
		TypeFactory result = ((intPtr == IntPtr.Zero) ? null : new TypeFactory(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private static IntPtr SwigConstructOdVariant(object val)
	{
		IntPtr intPtr = Helpers.MarshalVariant(val);
		try
		{
			return TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_1(intPtr);
		}
		finally
		{
			Helpers.FreeVariant(intPtr);
		}
	}

	public OdVariant(object val)
		: this(SwigConstructOdVariant(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant Assign(object val)
	{
		IntPtr intPtr = Helpers.MarshalVariant(val);
		try
		{
			OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_Assign(swigCPtr, intPtr), cMemoryOwn: false);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			Helpers.FreeVariant(intPtr);
		}
	}

	public int varType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_varType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant_Type type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdVariant_Type)result;
	}

	public bool isArray()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_isArray(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isByRef()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_isByRef(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant(string val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_2(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(OdRxObject val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_3(OdRxObject.getCPtr(val)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(bool val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_4(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(sbyte val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_5(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(byte val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_6(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(short val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_7(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(ushort val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_8(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(int val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_9(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(uint val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_10(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(long val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_11(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(ulong val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_12(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdVariant(double val)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdVariant__SWIG_13(val), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public string getString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getString(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string getAnsiString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getAnsiString(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObject getRxObjectPtr()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getRxObjectPtr(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool getBool()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getBool(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public sbyte getInt8()
	{
		sbyte result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt8(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte getUInt8()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt8(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public short getInt16()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt16(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort getUInt16()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt16(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int getInt32()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt32(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint getUInt32()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt32(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public long getInt64()
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ulong getUInt64()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt64(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public IntPtr getIntPtr()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getIntPtr(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double getDouble()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getDouble(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdStringArray getStringArray()
	{
		OdStringArray result = new OdStringArray(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getStringArray(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObjectPtrArray getRxObjectPtrArray()
	{
		OdRxObjectPtrArray result = Helpers.GetObject<OdRxObjectPtrArray>(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getRxObjectPtrArray(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBoolArray getBoolArray()
	{
		OdBoolArray result = new OdBoolArray(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getBoolArray(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt8Array getInt8Array()
	{
		OdInt8Array result = new OdInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt8Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array getUInt8Array()
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt8Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt16Array getInt16Array()
	{
		OdInt16Array result = new OdInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt16Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt16Array getUInt16Array()
	{
		OdUInt16Array result = new OdUInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt16Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt32Array getInt32Array()
	{
		OdInt32Array result = new OdInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt32Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt32Array getUInt32Array()
	{
		OdUInt32Array result = new OdUInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt32Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt64Array getInt64Array()
	{
		OdInt64Array result = new OdInt64Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt64Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt64Array getUInt64Array()
	{
		OdUInt64Array result = new OdUInt64Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt64Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDoubleArray getDoubleArray()
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getDoubleArray(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdStringArray asStringArray()
	{
		OdStringArray result = new OdStringArray(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asStringArray(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObjectPtrArray asRxObjectPtrArray()
	{
		OdRxObjectPtrArray result = Helpers.GetObject<OdRxObjectPtrArray>(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asRxObjectPtrArray(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBoolArray asBoolArray()
	{
		OdBoolArray result = new OdBoolArray(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asBoolArray(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt8Array asInt8Array()
	{
		OdInt8Array result = new OdInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asInt8Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array asUInt8Array()
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asUInt8Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt16Array asInt16Array()
	{
		OdInt16Array result = new OdInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asInt16Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt16Array asUInt16Array()
	{
		OdUInt16Array result = new OdUInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asUInt16Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt32Array asInt32Array()
	{
		OdInt32Array result = new OdInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asInt32Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt32Array asUInt32Array()
	{
		OdUInt32Array result = new OdUInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asUInt32Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt64Array asInt64Array()
	{
		OdInt64Array result = new OdInt64Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asInt64Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt64Array asUInt64Array()
	{
		OdUInt64Array result = new OdUInt64Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asUInt64Array(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDoubleArray asDoubleArray()
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_asDoubleArray(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdStringArray getStringArrayPtr()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getStringArrayPtr(swigCPtr);
		OdStringArray result = ((intPtr == IntPtr.Zero) ? null : new OdStringArray(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxObjectPtrArray getRxObjectPtrArrayPtr()
	{
		OdRxObjectPtrArray result = Helpers.GetObject<OdRxObjectPtrArray>(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getRxObjectPtrArrayPtr(swigCPtr), bOwn: false, bTryAddToTransaction: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdBoolArray getBoolArrayPtr()
	{
		OdBoolArray result = new OdBoolArray(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getBoolArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt8Array getInt8ArrayPtr()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt8ArrayPtr(swigCPtr);
		OdInt8Array result = ((intPtr == IntPtr.Zero) ? null : new OdInt8Array(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt8Array getUInt8ArrayPtr()
	{
		OdUInt8Array result = new OdUInt8Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt8ArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt16Array getInt16ArrayPtr()
	{
		OdInt16Array result = new OdInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt16ArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt16Array getUInt16ArrayPtr()
	{
		OdUInt16Array result = new OdUInt16Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt16ArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt32Array getInt32ArrayPtr()
	{
		OdInt32Array result = new OdInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt32ArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt32Array getUInt32ArrayPtr()
	{
		OdUInt32Array result = new OdUInt32Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt32ArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdInt64Array getInt64ArrayPtr()
	{
		OdInt64Array result = new OdInt64Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getInt64ArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdUInt64Array getUInt64ArrayPtr()
	{
		OdUInt64Array result = new OdUInt64Array(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getUInt64ArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDoubleArray getDoubleArrayPtr()
	{
		OdDoubleArray result = new OdDoubleArray(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_getDoubleArrayPtr(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setString(string val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setString(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setAnsiString(string val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setAnsiString(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setRxObjectPtr(OdRxObject val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setRxObjectPtr(swigCPtr, OdRxObject.getCPtr(val)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setBool(bool val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setBool(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt8(sbyte val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt8(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt8(byte val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt8(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt16(short val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt16(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt16(ushort val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt16(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt32(int val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt32(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt32(uint val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt32(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt64(long val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt64(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt64(ulong val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt64(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setIntPtr(IntPtr val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setIntPtr(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setDouble(double val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setDouble(swigCPtr, val), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setStringArray(OdStringArray val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setStringArray(swigCPtr, OdStringArray.getCPtr(val)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setRxObjectPtrArray(OdRxObjectPtrArray val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setRxObjectPtrArray(swigCPtr, OdRxObjectPtrArray.getCPtr(val)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setBoolArray(OdBoolArray val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setBoolArray(swigCPtr, OdBoolArray.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt8Array(OdInt8Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt8Array(swigCPtr, OdInt8Array.getCPtr(val)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt8Array(OdUInt8Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt8Array(swigCPtr, OdUInt8Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt16Array(OdInt16Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt16Array(swigCPtr, OdInt16Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt16Array(OdUInt16Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt16Array(swigCPtr, OdUInt16Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt32Array(OdInt32Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt32Array(swigCPtr, OdInt32Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt32Array(OdUInt32Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt32Array(swigCPtr, OdUInt32Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt64Array(OdInt64Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt64Array(swigCPtr, OdInt64Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt64Array(OdUInt64Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt64Array(swigCPtr, OdUInt64Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setDoubleArray(OdDoubleArray val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setDoubleArray(swigCPtr, OdDoubleArray.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setStringArrayPtr(OdStringArray val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setStringArrayPtr(swigCPtr, OdStringArray.getCPtr(val)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setRxObjectPtrArrayPtr(OdRxObjectPtrArray val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setRxObjectPtrArrayPtr(swigCPtr, OdRxObjectPtrArray.getCPtr(val)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setBoolArrayPtr(OdBoolArray val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setBoolArrayPtr(swigCPtr, OdBoolArray.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt8ArrayPtr(OdInt8Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt8ArrayPtr(swigCPtr, OdInt8Array.getCPtr(val)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt8ArrayPtr(OdUInt8Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt8ArrayPtr(swigCPtr, OdUInt8Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt16ArrayPtr(OdInt16Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt16ArrayPtr(swigCPtr, OdInt16Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt16ArrayPtr(OdUInt16Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt16ArrayPtr(swigCPtr, OdUInt16Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt32ArrayPtr(OdInt32Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt32ArrayPtr(swigCPtr, OdInt32Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt32ArrayPtr(OdUInt32Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt32ArrayPtr(swigCPtr, OdUInt32Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setInt64ArrayPtr(OdInt64Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setInt64ArrayPtr(swigCPtr, OdInt64Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setUInt64ArrayPtr(OdUInt64Array val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setUInt64ArrayPtr(swigCPtr, OdUInt64Array.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdVariant setDoubleArrayPtr(OdDoubleArray val)
	{
		OdVariant result = new OdVariant(TD_RootIntegrated_GlobalsPINVOKE.OdVariant_setDoubleArrayPtr(swigCPtr, OdDoubleArray.getCPtr(val).Handle), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("setVarType", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodsetVarType;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdVariant_director_connect(swigCPtr, swigDelegate0);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdVariant));
	}

	private void SwigDirectorMethodsetVarType(int newType, int type, IntPtr data)
	{
		try
		{
			setVarType(newType, out type, data);
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
}
