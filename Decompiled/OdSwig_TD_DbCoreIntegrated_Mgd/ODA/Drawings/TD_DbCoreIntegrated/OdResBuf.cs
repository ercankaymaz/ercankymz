using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdResBuf : OdRxObject
{
	public class Data : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		public bool Bool
		{
			get
			{
				bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Bool_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Bool_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public short Int16
		{
			get
			{
				short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Int16_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Int16_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public int Int32
		{
			get
			{
				int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Int32_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Int32_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public long Int64
		{
			get
			{
				long result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Int64_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Int64_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public double Double
		{
			get
			{
				double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Double_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Double_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public IntPtr Pointer
		{
			get
			{
				IntPtr result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Pointer_get(swigCPtr);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Pointer_set(swigCPtr, value);
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		public byte[] Bytes
		{
			get
			{
				byte[] result = ODA.Kernel.TD_RootIntegrated.Helpers.UnMarshalbyteFixedArray(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Bytes_get(swigCPtr));
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
				return result;
			}
			set
			{
				TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_Data_Bytes_set(swigCPtr, ODA.Kernel.TD_RootIntegrated.Helpers.MarshalbyteFixedArray(value));
				if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
				{
					throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
				}
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Data(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Data obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Data()
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
						TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdResBuf_Data(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public Data()
			: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdResBuf_Data(), cMemoryOwn: true)
		{
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
	}

	public delegate IntPtr SwigDelegateOdResBuf_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdResBuf_1();

	public delegate void SwigDelegateOdResBuf_2(IntPtr pRb);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdResBuf_0 swigDelegate0;

	private SwigDelegateOdResBuf_1 swigDelegate1;

	private SwigDelegateOdResBuf_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdResBuf(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdResBuf obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdResBuf(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdResBuf cast(OdRxObject pObj)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_isASwigExplicitOdResBuf(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_queryXSwigExplicitOdResBuf(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf createObject()
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject pRb)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_copyFromSwigExplicitOdResBuf(swigCPtr, OdRxObject.getCPtr(pRb));
		}
		else
		{
			TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_copyFrom(swigCPtr, OdRxObject.getCPtr(pRb));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool IsEqual(OdResBuf Rb)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_IsEqual(swigCPtr, getCPtr(Rb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool IsNotEqual(OdResBuf Rb)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_IsNotEqual(swigCPtr, getCPtr(Rb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int restype()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_restype(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRestype(int resType)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setRestype(swigCPtr, resType);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResBuf next()
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_next(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResBuf last()
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_last(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResBuf insert(OdResBuf pRb)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_insert(swigCPtr, getCPtr(pRb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdResBuf setNext(OdResBuf pRb)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setNext(swigCPtr, getCPtr(pRb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public string getString()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getString(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setString(string sValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setString(swigCPtr, sValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getBool()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getBool(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBool(bool bValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setBool(swigCPtr, bValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public sbyte getInt8()
	{
		sbyte result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getInt8(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInt8(sbyte iValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setInt8(swigCPtr, iValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public short getInt16()
	{
		short result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getInt16(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInt16(short iValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setInt16(swigCPtr, iValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int getInt32()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getInt32(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInt32(int iValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setInt32(swigCPtr, iValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public long getInt64()
	{
		long result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getInt64(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setInt64(long iValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setInt64(swigCPtr, iValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double getDouble()
	{
		double result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getDouble(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDouble(double realValue)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setDouble(swigCPtr, realValue);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint2d getPoint2d()
	{
		OdGePoint2d result = new OdGePoint2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getPoint2d(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPoint2d(OdGePoint2d gePoint)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setPoint2d(swigCPtr, OdGePoint2d.getCPtr(gePoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGePoint3d getPoint3d()
	{
		OdGePoint3d result = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getPoint3d(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPoint3d(OdGePoint3d gePoint)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setPoint3d(swigCPtr, OdGePoint3d.getCPtr(gePoint));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector2d getVector2d()
	{
		OdGeVector2d result = new OdGeVector2d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getVector2d(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVector2d(OdGeVector2d geVector)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setVector2d(swigCPtr, OdGeVector2d.getCPtr(geVector).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGeVector3d getVector3d()
	{
		OdGeVector3d result = new OdGeVector3d(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getVector3d(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setVector3d(OdGeVector3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setVector3d(swigCPtr, OdGeVector3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdBinaryData getBinaryChunk()
	{
		OdBinaryData result = new OdBinaryData(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getBinaryChunk(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setBinaryChunk(OdBinaryData bChunk)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setBinaryChunk(swigCPtr, OdBinaryData.getCPtr(bChunk).Handle);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmColor getColor()
	{
		OdCmColor result = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getColor(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColor(OdCmColor cmColor)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setColor(swigCPtr, OdCmColor.getCPtr(cmColor));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdResBuf getResBuf()
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getResBuf(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setResBuf(OdResBuf pResBuf)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setResBuf(swigCPtr, getCPtr(pResBuf));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbHandle getHandle()
	{
		OdDbHandle result = new OdDbHandle(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getHandle(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setHandle(OdDbHandle vHandle)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setHandle(swigCPtr, OdDbHandle.getCPtr(vHandle));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId getEntName()
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getEntName(swigCPtr), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setObjectId(OdDbObjectId idObject)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setObjectId(swigCPtr, OdDbObjectId.getCPtr(idObject));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbObjectId getObjectId(OdDbDatabase pDb)
	{
		OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getObjectId(swigCPtr, OdDbDatabase.getCPtr(pDb)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbSelectionSet getPickSet()
	{
		OdDbSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getPickSet(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setPickSet(OdDbSelectionSet pSSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setPickSet(swigCPtr, OdDbSelectionSet.getCPtr(pSSet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdResBuf newRb(int resType)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_0(resType), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb()
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, bool resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_2(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, sbyte resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_3(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, byte resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_4(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, short resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_5(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, ushort resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_6(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, int resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_7(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, uint resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_8(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, long resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_9(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, ulong resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_10(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, double resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_11(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, OdGePoint2d resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_12(resType, OdGePoint2d.getCPtr(resVal)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, OdGePoint3d resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_13(resType, OdGePoint3d.getCPtr(resVal)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, OdGeVector2d resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_14(resType, OdGeVector2d.getCPtr(resVal).Handle), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, OdGeVector3d resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_15(resType, OdGeVector3d.getCPtr(resVal)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, string resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_16(resType, resVal), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, OdCmColor resVal)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_17(resType, OdCmColor.getCPtr(resVal)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, OdDbObjectId id)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_18(resType, OdDbObjectId.getCPtr(id)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, OdDbSelectionSet pSSet)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_19(resType, OdDbSelectionSet.getCPtr(pSSet)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdResBuf newRb(int resType, OdResBuf pNestedRb)
	{
		OdResBuf rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdResBuf>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_newRb__SWIG_20(resType, getCPtr(pNestedRb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static void setAssertIndexByNewRb(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_setAssertIndexByNewRb(index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected OdResBuf()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdResBuf(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdResBuf) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdResBuf_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdResBuf));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pRb)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pRb, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			TD_DbCoreIntegrated_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
