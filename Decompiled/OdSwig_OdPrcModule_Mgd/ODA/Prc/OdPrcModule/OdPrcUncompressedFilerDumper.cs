using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcUncompressedFilerDumper : OdPrcUncompressedFiler
{
	public delegate IntPtr SwigDelegateOdPrcUncompressedFilerDumper_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcUncompressedFilerDumper_1();

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_2(IntPtr pSource);

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_3(IntPtr pFilerController);

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_4(uint version);

	public delegate uint SwigDelegateOdPrcUncompressedFilerDumper_5();

	public delegate IntPtr SwigDelegateOdPrcUncompressedFilerDumper_6();

	public delegate ulong SwigDelegateOdPrcUncompressedFilerDumper_7(long offset, int seekType);

	public delegate ulong SwigDelegateOdPrcUncompressedFilerDumper_8();

	public delegate ulong SwigDelegateOdPrcUncompressedFilerDumper_9();

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_10(string pBlockName);

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_11(string pArrayName, uint size);

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_12(string pElementName, uint index);

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_13();

	public delegate IntPtr SwigDelegateOdPrcUncompressedFilerDumper_14();

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_15(uint i, string pName);

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_16(uint i);

	public delegate uint SwigDelegateOdPrcUncompressedFilerDumper_17(string pName);

	public delegate uint SwigDelegateOdPrcUncompressedFilerDumper_18();

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_19(IntPtr pBuf, uint size);

	public delegate void SwigDelegateOdPrcUncompressedFilerDumper_20(IntPtr pBuf, uint size);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcUncompressedFilerDumper_0 swigDelegate0;

	private SwigDelegateOdPrcUncompressedFilerDumper_1 swigDelegate1;

	private SwigDelegateOdPrcUncompressedFilerDumper_2 swigDelegate2;

	private SwigDelegateOdPrcUncompressedFilerDumper_3 swigDelegate3;

	private SwigDelegateOdPrcUncompressedFilerDumper_4 swigDelegate4;

	private SwigDelegateOdPrcUncompressedFilerDumper_5 swigDelegate5;

	private SwigDelegateOdPrcUncompressedFilerDumper_6 swigDelegate6;

	private SwigDelegateOdPrcUncompressedFilerDumper_7 swigDelegate7;

	private SwigDelegateOdPrcUncompressedFilerDumper_8 swigDelegate8;

	private SwigDelegateOdPrcUncompressedFilerDumper_9 swigDelegate9;

	private SwigDelegateOdPrcUncompressedFilerDumper_10 swigDelegate10;

	private SwigDelegateOdPrcUncompressedFilerDumper_11 swigDelegate11;

	private SwigDelegateOdPrcUncompressedFilerDumper_12 swigDelegate12;

	private SwigDelegateOdPrcUncompressedFilerDumper_13 swigDelegate13;

	private SwigDelegateOdPrcUncompressedFilerDumper_14 swigDelegate14;

	private SwigDelegateOdPrcUncompressedFilerDumper_15 swigDelegate15;

	private SwigDelegateOdPrcUncompressedFilerDumper_16 swigDelegate16;

	private SwigDelegateOdPrcUncompressedFilerDumper_17 swigDelegate17;

	private SwigDelegateOdPrcUncompressedFilerDumper_18 swigDelegate18;

	private SwigDelegateOdPrcUncompressedFilerDumper_19 swigDelegate19;

	private SwigDelegateOdPrcUncompressedFilerDumper_20 swigDelegate20;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdPrcFilerController) };

	private static Type[] swigMethodTypes4 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[2]
	{
		typeof(long),
		typeof(OdDb_FilerSeekType)
	};

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes11 = new Type[2]
	{
		typeof(string),
		typeof(uint)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(string),
		typeof(uint)
	};

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[2]
	{
		typeof(uint),
		typeof(string)
	};

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(byte[]),
		typeof(uint)
	};

	private static Type[] swigMethodTypes20 = new Type[2]
	{
		typeof(byte[]),
		typeof(uint)
	};

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcUncompressedFilerDumper(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcUncompressedFilerDumper obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcUncompressedFilerDumper(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcUncompressedFilerDumper()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcUncompressedFilerDumper(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcUncompressedFilerDumper) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPrcUncompressedFilerDumper cast(OdRxObject pObj)
	{
		OdPrcUncompressedFilerDumper rXObject = Helpers.GetRXObject<OdPrcUncompressedFilerDumper>(OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_isASwigExplicitOdPrcUncompressedFilerDumper(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_queryXSwigExplicitOdPrcUncompressedFilerDumper(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcUncompressedFilerDumper createObject()
	{
		OdPrcUncompressedFilerDumper rXObject = Helpers.GetRXObject<OdPrcUncompressedFilerDumper>(OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdStreamBuf internalBuffer()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(SwigDerivedClassHasMethod("internalBuffer", swigMethodTypes14) ? OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_internalBufferSwigExplicitOdPrcUncompressedFilerDumper(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_internalBuffer(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setFiler(OdPrcUncompressedFiler pFilerBase)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_setFiler(swigCPtr, OdPrcUncompressedFiler.getCPtr(pFilerBase));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcUncompressedFiler getFiler()
	{
		OdPrcUncompressedFiler rXObject = Helpers.GetRXObject<OdPrcUncompressedFiler>(OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_getFiler(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void writeUncompressedUnsignedInteger(uint i, string pName)
	{
		if (SwigDerivedClassHasMethod("writeUncompressedUnsignedInteger", swigMethodTypes15))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_writeUncompressedUnsignedIntegerSwigExplicitOdPrcUncompressedFilerDumper__SWIG_0(swigCPtr, i, pName);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_writeUncompressedUnsignedInteger__SWIG_0(swigCPtr, i, pName);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeUncompressedUnsignedInteger(uint i)
	{
		if (SwigDerivedClassHasMethod("writeUncompressedUnsignedInteger", swigMethodTypes16))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_writeUncompressedUnsignedIntegerSwigExplicitOdPrcUncompressedFilerDumper__SWIG_1(swigCPtr, i);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_writeUncompressedUnsignedInteger__SWIG_1(swigCPtr, i);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override uint readUncompressedUnsignedInteger(string pName)
	{
		uint result = (SwigDerivedClassHasMethod("readUncompressedUnsignedInteger", swigMethodTypes17) ? OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_readUncompressedUnsignedIntegerSwigExplicitOdPrcUncompressedFilerDumper__SWIG_0(swigCPtr, pName) : OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_readUncompressedUnsignedInteger__SWIG_0(swigCPtr, pName));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override uint readUncompressedUnsignedInteger()
	{
		uint result = (SwigDerivedClassHasMethod("readUncompressedUnsignedInteger", swigMethodTypes18) ? OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_readUncompressedUnsignedIntegerSwigExplicitOdPrcUncompressedFilerDumper__SWIG_1(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_readUncompressedUnsignedInteger__SWIG_1(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void readUncompressedBlock(byte[] pBuf, uint size)
	{
		if (SwigDerivedClassHasMethod("readUncompressedBlock", swigMethodTypes19))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_readUncompressedBlockSwigExplicitOdPrcUncompressedFilerDumper(swigCPtr, Helpers.MarshalbyteFixedArray(pBuf), size);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_readUncompressedBlock(swigCPtr, Helpers.MarshalbyteFixedArray(pBuf), size);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void writeUncompressedBlock(byte[] pBuf, uint size)
	{
		if (SwigDerivedClassHasMethod("writeUncompressedBlock", swigMethodTypes20))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_writeUncompressedBlockSwigExplicitOdPrcUncompressedFilerDumper(swigCPtr, Helpers.MarshalbyteFixedArray(pBuf), size);
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_writeUncompressedBlock(swigCPtr, Helpers.MarshalbyteFixedArray(pBuf), size);
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_getRealClassName(ptr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("setController", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetController;
		}
		if (SwigDerivedClassHasMethod("setVersion", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetVersion;
		}
		if (SwigDerivedClassHasMethod("version", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodversion;
		}
		if (SwigDerivedClassHasMethod("controller", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodcontroller;
		}
		if (SwigDerivedClassHasMethod("seek", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodseek;
		}
		if (SwigDerivedClassHasMethod("tell", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodtell;
		}
		if (SwigDerivedClassHasMethod("length", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodlength;
		}
		if (SwigDerivedClassHasMethod("levelIn", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodlevelIn;
		}
		if (SwigDerivedClassHasMethod("arrayIn", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodarrayIn;
		}
		if (SwigDerivedClassHasMethod("arrayElemIn", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodarrayElemIn;
		}
		if (SwigDerivedClassHasMethod("levelOut", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodlevelOut;
		}
		if (SwigDerivedClassHasMethod("internalBuffer", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodinternalBuffer;
		}
		if (SwigDerivedClassHasMethod("writeUncompressedUnsignedInteger", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodwriteUncompressedUnsignedInteger__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("writeUncompressedUnsignedInteger", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodwriteUncompressedUnsignedInteger__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readUncompressedUnsignedInteger", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodreadUncompressedUnsignedInteger__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("readUncompressedUnsignedInteger", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodreadUncompressedUnsignedInteger__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("readUncompressedBlock", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodreadUncompressedBlock;
		}
		if (SwigDerivedClassHasMethod("writeUncompressedBlock", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodwriteUncompressedBlock;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcUncompressedFilerDumper_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcUncompressedFilerDumper));
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
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetController(IntPtr pFilerController)
	{
		try
		{
			setController(Helpers.GetRXObject<OdPrcFilerController>(pFilerController, bOwn: false, bTryAddToTransaction: false));
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodsetVersion(uint version)
	{
		try
		{
			setVersion(version);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodversion()
	{
		return version();
	}

	private IntPtr SwigDirectorMethodcontroller()
	{
		return OdPrcFilerController.getCPtr(controller()).Handle;
	}

	private ulong SwigDirectorMethodseek(long offset, int seekType)
	{
		return seek(offset, (OdDb_FilerSeekType)seekType);
	}

	private ulong SwigDirectorMethodtell()
	{
		return tell();
	}

	private ulong SwigDirectorMethodlength()
	{
		return length();
	}

	private void SwigDirectorMethodlevelIn(string pBlockName)
	{
		try
		{
			levelIn(pBlockName);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodarrayIn(string pArrayName, uint size)
	{
		try
		{
			arrayIn(pArrayName, size);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodarrayElemIn(string pElementName, uint index)
	{
		try
		{
			arrayElemIn(pElementName, index);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodlevelOut()
	{
		try
		{
			levelOut();
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private IntPtr SwigDirectorMethodinternalBuffer()
	{
		return OdStreamBuf.getCPtr(internalBuffer()).Handle;
	}

	private void SwigDirectorMethodwriteUncompressedUnsignedInteger__SWIG_0(uint i, string pName)
	{
		try
		{
			writeUncompressedUnsignedInteger(i, pName);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwriteUncompressedUnsignedInteger__SWIG_1(uint i)
	{
		try
		{
			writeUncompressedUnsignedInteger(i);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private uint SwigDirectorMethodreadUncompressedUnsignedInteger__SWIG_0(string pName)
	{
		return readUncompressedUnsignedInteger(pName);
	}

	private uint SwigDirectorMethodreadUncompressedUnsignedInteger__SWIG_1()
	{
		return readUncompressedUnsignedInteger();
	}

	private void SwigDirectorMethodreadUncompressedBlock(IntPtr pBuf, uint size)
	{
		try
		{
			readUncompressedBlock(Helpers.UnMarshalbyteFixedArray(pBuf), size);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private void SwigDirectorMethodwriteUncompressedBlock(IntPtr pBuf, uint size)
	{
		try
		{
			writeUncompressedBlock(Helpers.UnMarshalbyteFixedArray(pBuf), size);
		}
		catch (OdEdEmptyInput err)
		{
			OdPrcModule_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			OdPrcModule_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			OdPrcModule_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
