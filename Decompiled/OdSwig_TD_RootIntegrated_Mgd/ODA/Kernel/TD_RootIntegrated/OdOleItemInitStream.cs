using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdOleItemInitStream : OdStreamBuf
{
	public delegate IntPtr SwigDelegateOdOleItemInitStream_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdOleItemInitStream_1();

	public delegate void SwigDelegateOdOleItemInitStream_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdOleItemInitStream_3();

	public delegate bool SwigDelegateOdOleItemInitStream_4();

	public delegate ulong SwigDelegateOdOleItemInitStream_5();

	public delegate ulong SwigDelegateOdOleItemInitStream_6();

	public delegate void SwigDelegateOdOleItemInitStream_7();

	public delegate void SwigDelegateOdOleItemInitStream_8();

	public delegate ulong SwigDelegateOdOleItemInitStream_9(long offset, int seekType);

	public delegate byte SwigDelegateOdOleItemInitStream_10();

	public delegate void SwigDelegateOdOleItemInitStream_11(byte value);

	public delegate void SwigDelegateOdOleItemInitStream_12(IntPtr buffer);

	public delegate void SwigDelegateOdOleItemInitStream_13(IntPtr pDestination, ulong sourceStart, ulong sourceEnd);

	public delegate void SwigDelegateOdOleItemInitStream_14(IntPtr pDestination, ulong sourceStart);

	public delegate void SwigDelegateOdOleItemInitStream_15(IntPtr pDestination);

	public delegate uint SwigDelegateOdOleItemInitStream_16();

	public delegate int SwigDelegateOdOleItemInitStream_17();

	public delegate IntPtr SwigDelegateOdOleItemInitStream_18();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdOleItemInitStream_0 swigDelegate0;

	private SwigDelegateOdOleItemInitStream_1 swigDelegate1;

	private SwigDelegateOdOleItemInitStream_2 swigDelegate2;

	private SwigDelegateOdOleItemInitStream_3 swigDelegate3;

	private SwigDelegateOdOleItemInitStream_4 swigDelegate4;

	private SwigDelegateOdOleItemInitStream_5 swigDelegate5;

	private SwigDelegateOdOleItemInitStream_6 swigDelegate6;

	private SwigDelegateOdOleItemInitStream_7 swigDelegate7;

	private SwigDelegateOdOleItemInitStream_8 swigDelegate8;

	private SwigDelegateOdOleItemInitStream_9 swigDelegate9;

	private SwigDelegateOdOleItemInitStream_10 swigDelegate10;

	private SwigDelegateOdOleItemInitStream_11 swigDelegate11;

	private SwigDelegateOdOleItemInitStream_12 swigDelegate12;

	private SwigDelegateOdOleItemInitStream_13 swigDelegate13;

	private SwigDelegateOdOleItemInitStream_14 swigDelegate14;

	private SwigDelegateOdOleItemInitStream_15 swigDelegate15;

	private SwigDelegateOdOleItemInitStream_16 swigDelegate16;

	private SwigDelegateOdOleItemInitStream_17 swigDelegate17;

	private SwigDelegateOdOleItemInitStream_18 swigDelegate18;

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

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdOleItemInitStream(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdOleItemInitStream obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdOleItemInitStream(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdOleItemInitStream cast(OdRxObject pObj)
	{
		OdOleItemInitStream rXObject = Helpers.GetRXObject<OdOleItemInitStream>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_isASwigExplicitOdOleItemInitStream(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_queryXSwigExplicitOdOleItemInitStream(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdOleItemInitStream createObject()
	{
		OdOleItemInitStream rXObject = Helpers.GetRXObject<OdOleItemInitStream>(TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbStub frameId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_frameId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdOleItemInitStream()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdOleItemInitStream(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdOleItemInitStream) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
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
		if (SwigDerivedClassHasMethod("frameId", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodframeId;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdOleItemInitStream_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdOleItemInitStream));
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

	private IntPtr SwigDirectorMethodframeId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(frameId()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}
}
