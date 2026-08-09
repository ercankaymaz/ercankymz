using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdStreamBuf : OdRxObject
{
	public delegate IntPtr SwigDelegateOdStreamBuf_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdStreamBuf_1();

	public delegate void SwigDelegateOdStreamBuf_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdStreamBuf_3();

	public delegate bool SwigDelegateOdStreamBuf_4();

	public delegate ulong SwigDelegateOdStreamBuf_5();

	public delegate ulong SwigDelegateOdStreamBuf_6();

	public delegate void SwigDelegateOdStreamBuf_7();

	public delegate void SwigDelegateOdStreamBuf_8();

	public delegate ulong SwigDelegateOdStreamBuf_9(long offset, int seekType);

	public delegate byte SwigDelegateOdStreamBuf_10();

	public delegate void SwigDelegateOdStreamBuf_11(byte value);

	public delegate void SwigDelegateOdStreamBuf_12(IntPtr buffer);

	public delegate void SwigDelegateOdStreamBuf_13(IntPtr pDestination, ulong sourceStart, ulong sourceEnd);

	public delegate void SwigDelegateOdStreamBuf_14(IntPtr pDestination, ulong sourceStart);

	public delegate void SwigDelegateOdStreamBuf_15(IntPtr pDestination);

	public delegate uint SwigDelegateOdStreamBuf_16();

	public delegate int SwigDelegateOdStreamBuf_17();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdStreamBuf_0 swigDelegate0;

	private SwigDelegateOdStreamBuf_1 swigDelegate1;

	private SwigDelegateOdStreamBuf_2 swigDelegate2;

	private SwigDelegateOdStreamBuf_3 swigDelegate3;

	private SwigDelegateOdStreamBuf_4 swigDelegate4;

	private SwigDelegateOdStreamBuf_5 swigDelegate5;

	private SwigDelegateOdStreamBuf_6 swigDelegate6;

	private SwigDelegateOdStreamBuf_7 swigDelegate7;

	private SwigDelegateOdStreamBuf_8 swigDelegate8;

	private SwigDelegateOdStreamBuf_9 swigDelegate9;

	private SwigDelegateOdStreamBuf_10 swigDelegate10;

	private SwigDelegateOdStreamBuf_11 swigDelegate11;

	private SwigDelegateOdStreamBuf_12 swigDelegate12;

	private SwigDelegateOdStreamBuf_13 swigDelegate13;

	private SwigDelegateOdStreamBuf_14 swigDelegate14;

	private SwigDelegateOdStreamBuf_15 swigDelegate15;

	private SwigDelegateOdStreamBuf_16 swigDelegate16;

	private SwigDelegateOdStreamBuf_17 swigDelegate17;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdStreamBuf(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdStreamBuf obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdStreamBuf(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdStreamBuf()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdStreamBuf(), cMemoryOwn: true)
	{
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
	}

	public new static OdStreamBuf cast(OdRxObject pObj)
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_isASwigExplicitOdStreamBuf(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_queryXSwigExplicitOdStreamBuf(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdStreamBuf createObject()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string fileName()
	{
		string result = (SwigDerivedClassHasMethod("fileName", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_fileNameSwigExplicitOdStreamBuf(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_fileName(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEof()
	{
		bool result = (SwigDerivedClassHasMethod("isEof", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_isEofSwigExplicitOdStreamBuf(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_isEof(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong tell()
	{
		ulong result = (SwigDerivedClassHasMethod("tell", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_tellSwigExplicitOdStreamBuf(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_tell(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual ulong length()
	{
		ulong result = (SwigDerivedClassHasMethod("length", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_lengthSwigExplicitOdStreamBuf(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_length(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void truncate()
	{
		if (SwigDerivedClassHasMethod("truncate", swigMethodTypes7))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_truncateSwigExplicitOdStreamBuf(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_truncate(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void rewind()
	{
		if (SwigDerivedClassHasMethod("rewind", swigMethodTypes8))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_rewindSwigExplicitOdStreamBuf(swigCPtr);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_rewind(swigCPtr);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ulong seek(long offset, OdDb_FilerSeekType seekType)
	{
		ulong result = (SwigDerivedClassHasMethod("seek", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_seekSwigExplicitOdStreamBuf(swigCPtr, offset, (int)seekType) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_seek(swigCPtr, offset, (int)seekType));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual byte getByte()
	{
		byte result = (SwigDerivedClassHasMethod("getByte", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_getByteSwigExplicitOdStreamBuf(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_getByte(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void getBytes(IntPtr buffer, uint numBytes)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_getBytes(swigCPtr, buffer, numBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void putByte(byte value)
	{
		if (SwigDerivedClassHasMethod("putByte", swigMethodTypes11))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_putByteSwigExplicitOdStreamBuf(swigCPtr, value);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_putByte(swigCPtr, value);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void putBytes(byte[] buffer)
	{
		IntPtr intPtr = Helpers.MarshalbyteFixedArray(buffer);
		try
		{
			if (SwigDerivedClassHasMethod("putBytes", swigMethodTypes12))
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_putBytesSwigExplicitOdStreamBuf(swigCPtr, intPtr);
			}
			else
			{
				TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_putBytes(swigCPtr, intPtr);
			}
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

	public virtual void copyDataTo(OdStreamBuf pDestination, ulong sourceStart, ulong sourceEnd)
	{
		if (SwigDerivedClassHasMethod("copyDataTo", swigMethodTypes13))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_copyDataToSwigExplicitOdStreamBuf__SWIG_0(swigCPtr, getCPtr(pDestination), sourceStart, sourceEnd);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_copyDataTo__SWIG_0(swigCPtr, getCPtr(pDestination), sourceStart, sourceEnd);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void copyDataTo(OdStreamBuf pDestination, ulong sourceStart)
	{
		if (SwigDerivedClassHasMethod("copyDataTo", swigMethodTypes14))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_copyDataToSwigExplicitOdStreamBuf__SWIG_1(swigCPtr, getCPtr(pDestination), sourceStart);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_copyDataTo__SWIG_1(swigCPtr, getCPtr(pDestination), sourceStart);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void copyDataTo(OdStreamBuf pDestination)
	{
		if (SwigDerivedClassHasMethod("copyDataTo", swigMethodTypes15))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_copyDataToSwigExplicitOdStreamBuf__SWIG_2(swigCPtr, getCPtr(pDestination));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_copyDataTo__SWIG_2(swigCPtr, getCPtr(pDestination));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual uint getShareMode()
	{
		uint result = (SwigDerivedClassHasMethod("getShareMode", swigMethodTypes16) ? TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_getShareModeSwigExplicitOdStreamBuf__SWIG_0(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_getShareMode__SWIG_0(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint getBytesByNum(OdUInt8Array data, ulong startPos, uint numBytes)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_getBytesByNum(swigCPtr, OdUInt8Array.getCPtr(data).Handle, startPos, numBytes);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_getRealClassName(ptr);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdStreamBuf_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdStreamBuf));
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
}
