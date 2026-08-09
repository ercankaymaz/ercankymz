using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdMemoryStream : OdStreamBuf
{
	public delegate IntPtr SwigDelegateOdMemoryStream_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdMemoryStream_1();

	public delegate void SwigDelegateOdMemoryStream_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdMemoryStream_3();

	public delegate bool SwigDelegateOdMemoryStream_4();

	public delegate ulong SwigDelegateOdMemoryStream_5();

	public delegate ulong SwigDelegateOdMemoryStream_6();

	public delegate void SwigDelegateOdMemoryStream_7();

	public delegate void SwigDelegateOdMemoryStream_8();

	public delegate ulong SwigDelegateOdMemoryStream_9(long offset, int seekType);

	public delegate byte SwigDelegateOdMemoryStream_10();

	public delegate void SwigDelegateOdMemoryStream_11(byte value);

	public delegate void SwigDelegateOdMemoryStream_12(IntPtr buffer);

	public delegate void SwigDelegateOdMemoryStream_13(IntPtr pDestination, ulong sourceStart, ulong sourceEnd);

	public delegate void SwigDelegateOdMemoryStream_14(IntPtr pDestination, ulong sourceStart);

	public delegate void SwigDelegateOdMemoryStream_15(IntPtr pDestination);

	public delegate uint SwigDelegateOdMemoryStream_16();

	public delegate int SwigDelegateOdMemoryStream_17();

	public delegate uint SwigDelegateOdMemoryStream_18();

	public delegate void SwigDelegateOdMemoryStream_19(uint pageDataSize);

	public delegate void SwigDelegateOdMemoryStream_20(ulong numBytes);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdMemoryStream_0 swigDelegate0;

	private SwigDelegateOdMemoryStream_1 swigDelegate1;

	private SwigDelegateOdMemoryStream_2 swigDelegate2;

	private SwigDelegateOdMemoryStream_3 swigDelegate3;

	private SwigDelegateOdMemoryStream_4 swigDelegate4;

	private SwigDelegateOdMemoryStream_5 swigDelegate5;

	private SwigDelegateOdMemoryStream_6 swigDelegate6;

	private SwigDelegateOdMemoryStream_7 swigDelegate7;

	private SwigDelegateOdMemoryStream_8 swigDelegate8;

	private SwigDelegateOdMemoryStream_9 swigDelegate9;

	private SwigDelegateOdMemoryStream_10 swigDelegate10;

	private SwigDelegateOdMemoryStream_11 swigDelegate11;

	private SwigDelegateOdMemoryStream_12 swigDelegate12;

	private SwigDelegateOdMemoryStream_13 swigDelegate13;

	private SwigDelegateOdMemoryStream_14 swigDelegate14;

	private SwigDelegateOdMemoryStream_15 swigDelegate15;

	private SwigDelegateOdMemoryStream_16 swigDelegate16;

	private SwigDelegateOdMemoryStream_17 swigDelegate17;

	private SwigDelegateOdMemoryStream_18 swigDelegate18;

	private SwigDelegateOdMemoryStream_19 swigDelegate19;

	private SwigDelegateOdMemoryStream_20 swigDelegate20;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(long),
		typeof(OdDb_FilerSeekType)
	};

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(byte) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(byte[]) };

	private static Type[] swigMethodTypes13 = new Type[3]
	{
		typeof(OdStreamBuf),
		typeof(ulong),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(OdStreamBuf),
		typeof(ulong)
	};

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdStreamBuf) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(ulong) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdMemoryStream(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdMemoryStream obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdMemoryStream(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdMemoryStream()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdMemoryStream(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdMemoryStream) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdMemoryStream cast(OdRxObject pObj)
	{
		OdMemoryStream rXObject = Helpers.GetRXObject<OdMemoryStream>(TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_isASwigExplicitOdMemoryStream(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_queryXSwigExplicitOdMemoryStream(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdMemoryStream createObject()
	{
		OdMemoryStream rXObject = Helpers.GetRXObject<OdMemoryStream>(TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdMemoryStream createNew(uint pageDataSize)
	{
		OdMemoryStream rXObject = Helpers.GetRXObject<OdMemoryStream>(TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_createNew__SWIG_0(pageDataSize), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdMemoryStream createNew()
	{
		OdMemoryStream rXObject = Helpers.GetRXObject<OdMemoryStream>(TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_createNew__SWIG_1(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual uint pageDataSize()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_pageDataSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setPageDataSize(uint pageDataSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_setPageDataSize(swigCPtr, pageDataSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void reserve(ulong numBytes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_reserve(swigCPtr, numBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override string fileName()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_fileName(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool isEof()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_isEof(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ulong tell()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_tell(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override ulong length()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_length(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void truncate()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_truncate(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void rewind()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_rewind(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override ulong seek(long offset, OdDb_FilerSeekType seekType)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_seek(swigCPtr, offset, (int)seekType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override byte getByte()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_getByte(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void putByte(byte value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_putByte(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void putBytes(byte[] buffer)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_putBytes(swigCPtr, intPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public override void copyDataTo(OdStreamBuf pDestination, ulong sourceStart, ulong sourceEnd)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_copyDataTo__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pDestination), sourceStart, sourceEnd);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyDataTo(OdStreamBuf pDestination, ulong sourceStart)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_copyDataTo__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pDestination), sourceStart);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyDataTo(OdStreamBuf pDestination)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_copyDataTo__SWIG_2(swigCPtr, OdStreamBuf.getCPtr(pDestination));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint getShareMode()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_getShareMode(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("fileName", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodfileName;
		}
		if (SwigDerivedClassHasMethod("isEof", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisEof;
		}
		if (SwigDerivedClassHasMethod("tell", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodtell;
		}
		if (SwigDerivedClassHasMethod("length", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodlength;
		}
		if (SwigDerivedClassHasMethod("truncate", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodtruncate;
		}
		if (SwigDerivedClassHasMethod("rewind", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodrewind;
		}
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodseek;
		}
		if (SwigDerivedClassHasMethod("getByte", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodgetByte;
		}
		if (SwigDerivedClassHasMethod("putByte", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodputByte;
		}
		if (SwigDerivedClassHasMethod("putBytes", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodputBytes;
		}
		if (SwigDerivedClassHasMethod("copyDataTo", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodcopyDataTo__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("copyDataTo", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodcopyDataTo__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("copyDataTo", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodcopyDataTo__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("getShareMode", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetShareMode__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getShareMode", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetShareMode__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pageDataSize", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodpageDataSize;
		}
		if (SwigDerivedClassHasMethod("setPageDataSize", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetPageDataSize;
		}
		if (SwigDerivedClassHasMethod("reserve", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodreserve;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdMemoryStream_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdMemoryStream));
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

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodfileName()
	{
		return fileName();
	}

	private bool SwigDirectorMethodisEof()
	{
		return isEof();
	}

	private ulong SwigDirectorMethodtell()
	{
		return tell();
	}

	private ulong SwigDirectorMethodlength()
	{
		return length();
	}

	private void SwigDirectorMethodtruncate()
	{
		try
		{
			truncate();
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

	private void SwigDirectorMethodrewind()
	{
		try
		{
			rewind();
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

	private ulong SwigDirectorMethodseek(long offset, int seekType)
	{
		return seek(offset, (OdDb_FilerSeekType)seekType);
	}

	private byte SwigDirectorMethodgetByte()
	{
		return getByte();
	}

	private void SwigDirectorMethodputByte(byte value)
	{
		try
		{
			putByte(value);
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

	private void SwigDirectorMethodputBytes(IntPtr buffer)
	{
		try
		{
			putBytes(Helpers.UnMarshalbyteFixedArray(buffer));
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

	private void SwigDirectorMethodcopyDataTo__SWIG_0(IntPtr pDestination, ulong sourceStart, ulong sourceEnd)
	{
		try
		{
			copyDataTo(Helpers.GetRXObject<OdStreamBuf>(pDestination, bOwn: false, bTryAddToTransaction: false), sourceStart, sourceEnd);
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

	private void SwigDirectorMethodcopyDataTo__SWIG_1(IntPtr pDestination, ulong sourceStart)
	{
		try
		{
			copyDataTo(Helpers.GetRXObject<OdStreamBuf>(pDestination, bOwn: false, bTryAddToTransaction: false), sourceStart);
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

	private void SwigDirectorMethodcopyDataTo__SWIG_2(IntPtr pDestination)
	{
		try
		{
			copyDataTo(Helpers.GetRXObject<OdStreamBuf>(pDestination, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodgetShareMode__SWIG_0()
	{
		return getShareMode();
	}

	private int SwigDirectorMethodgetShareMode__SWIG_1()
	{
		return (int)getShareMode();
	}

	private uint SwigDirectorMethodpageDataSize()
	{
		return pageDataSize();
	}

	private void SwigDirectorMethodsetPageDataSize(uint pageDataSize)
	{
		try
		{
			setPageDataSize(pageDataSize);
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

	private void SwigDirectorMethodreserve(ulong numBytes)
	{
		try
		{
			reserve(numBytes);
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
