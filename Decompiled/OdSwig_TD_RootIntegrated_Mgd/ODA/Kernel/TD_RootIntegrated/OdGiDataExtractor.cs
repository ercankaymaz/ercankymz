using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiDataExtractor : IDisposable
{
	public delegate bool SwigDelegateOdGiDataExtractor_0(byte dataId, ulong localOffset);

	public delegate bool SwigDelegateOdGiDataExtractor_1(byte dataId, ulong localOffset);

	public delegate ulong SwigDelegateOdGiDataExtractor_2();

	public delegate bool SwigDelegateOdGiDataExtractor_3(byte dataId);

	public delegate bool SwigDelegateOdGiDataExtractor_4(byte dataId);

	public delegate bool SwigDelegateOdGiDataExtractor_5(ulong offset);

	public delegate void SwigDelegateOdGiDataExtractor_6(IntPtr buffer, uint numBytes);

	public delegate double SwigDelegateOdGiDataExtractor_7();

	public delegate long SwigDelegateOdGiDataExtractor_8();

	public delegate int SwigDelegateOdGiDataExtractor_9();

	public delegate short SwigDelegateOdGiDataExtractor_10();

	public delegate byte SwigDelegateOdGiDataExtractor_11();

	public delegate bool SwigDelegateOdGiDataExtractor_12();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdGiDataExtractor_0 swigDelegate0;

	private SwigDelegateOdGiDataExtractor_1 swigDelegate1;

	private SwigDelegateOdGiDataExtractor_2 swigDelegate2;

	private SwigDelegateOdGiDataExtractor_3 swigDelegate3;

	private SwigDelegateOdGiDataExtractor_4 swigDelegate4;

	private SwigDelegateOdGiDataExtractor_5 swigDelegate5;

	private SwigDelegateOdGiDataExtractor_6 swigDelegate6;

	private SwigDelegateOdGiDataExtractor_7 swigDelegate7;

	private SwigDelegateOdGiDataExtractor_8 swigDelegate8;

	private SwigDelegateOdGiDataExtractor_9 swigDelegate9;

	private SwigDelegateOdGiDataExtractor_10 swigDelegate10;

	private SwigDelegateOdGiDataExtractor_11 swigDelegate11;

	private SwigDelegateOdGiDataExtractor_12 swigDelegate12;

	private static Type[] swigMethodTypes0 = new Type[2]
	{
		typeof(byte),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes1 = new Type[2]
	{
		typeof(byte),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes2 = new Type[0];

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(ulong) };

	private static Type[] swigMethodTypes6 = new Type[2]
	{
		typeof(IntPtr),
		typeof(uint)
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiDataExtractor(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiDataExtractor obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiDataExtractor()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiDataExtractor(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public virtual bool registerDataBegin(byte dataId, ulong localOffset)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_registerDataBegin(swigCPtr, dataId, localOffset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool registerDataEnd(byte dataId, ulong localOffset)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_registerDataEnd(swigCPtr, dataId, localOffset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong tell()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_tell(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool beginExtraction(byte dataId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_beginExtraction(swigCPtr, dataId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool endExtraction(byte dataId)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_endExtraction(swigCPtr, dataId);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool seekFromLocalOffset(ulong offset)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_seekFromLocalOffset(swigCPtr, offset);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void extractBytes(IntPtr buffer, uint numBytes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractBytes(swigCPtr, buffer, numBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double extractDouble()
	{
		double result = (SwigDerivedClassHasMethod("extractDouble", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractDoubleSwigExplicitOdGiDataExtractor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractDouble(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual long extractInt64()
	{
		long result = (SwigDerivedClassHasMethod("extractInt64", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractInt64SwigExplicitOdGiDataExtractor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractInt64(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int extractInt32()
	{
		int result = (SwigDerivedClassHasMethod("extractInt32", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractInt32SwigExplicitOdGiDataExtractor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractInt32(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual short extractInt16()
	{
		short result = (SwigDerivedClassHasMethod("extractInt16", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractInt16SwigExplicitOdGiDataExtractor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractInt16(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte extractByte()
	{
		byte result = (SwigDerivedClassHasMethod("extractByte", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractByteSwigExplicitOdGiDataExtractor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractByte(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool extractBool()
	{
		bool result = (SwigDerivedClassHasMethod("extractBool", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractBoolSwigExplicitOdGiDataExtractor(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_extractBool(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiDataExtractor()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiDataExtractor(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiDataExtractor) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("registerDataBegin", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodregisterDataBegin;
		}
		if (SwigDerivedClassHasMethod("registerDataEnd", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodregisterDataEnd;
		}
		if (SwigDerivedClassHasMethod("tell", swigMethodTypes2))
		{
			swigDelegate2 = SwigDirectorMethodtell;
		}
		if (SwigDerivedClassHasMethod("beginExtraction", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodbeginExtraction;
		}
		if (SwigDerivedClassHasMethod("endExtraction", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodendExtraction;
		}
		if (SwigDerivedClassHasMethod("seekFromLocalOffset", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodseekFromLocalOffset;
		}
		if (SwigDerivedClassHasMethod("extractBytes", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodextractBytes;
		}
		if (SwigDerivedClassHasMethod("extractDouble", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodextractDouble;
		}
		if (SwigDerivedClassHasMethod("extractInt64", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodextractInt64;
		}
		if (SwigDerivedClassHasMethod("extractInt32", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodextractInt32;
		}
		if (SwigDerivedClassHasMethod("extractInt16", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodextractInt16;
		}
		if (SwigDerivedClassHasMethod("extractByte", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodextractByte;
		}
		if (SwigDerivedClassHasMethod("extractBool", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodextractBool;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiDataExtractor_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiDataExtractor));
	}

	private bool SwigDirectorMethodregisterDataBegin(byte dataId, ulong localOffset)
	{
		return registerDataBegin(dataId, localOffset);
	}

	private bool SwigDirectorMethodregisterDataEnd(byte dataId, ulong localOffset)
	{
		return registerDataEnd(dataId, localOffset);
	}

	private ulong SwigDirectorMethodtell()
	{
		return tell();
	}

	private bool SwigDirectorMethodbeginExtraction(byte dataId)
	{
		return beginExtraction(dataId);
	}

	private bool SwigDirectorMethodendExtraction(byte dataId)
	{
		return endExtraction(dataId);
	}

	private bool SwigDirectorMethodseekFromLocalOffset(ulong offset)
	{
		return seekFromLocalOffset(offset);
	}

	private void SwigDirectorMethodextractBytes(IntPtr buffer, uint numBytes)
	{
		try
		{
			extractBytes(buffer, numBytes);
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

	private double SwigDirectorMethodextractDouble()
	{
		return extractDouble();
	}

	private long SwigDirectorMethodextractInt64()
	{
		return extractInt64();
	}

	private int SwigDirectorMethodextractInt32()
	{
		return extractInt32();
	}

	private short SwigDirectorMethodextractInt16()
	{
		return extractInt16();
	}

	private byte SwigDirectorMethodextractByte()
	{
		return extractByte();
	}

	private bool SwigDirectorMethodextractBool()
	{
		return extractBool();
	}
}
