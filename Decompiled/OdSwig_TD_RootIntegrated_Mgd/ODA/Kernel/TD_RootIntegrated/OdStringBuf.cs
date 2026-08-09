using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdStringBuf : OdRxObject
{
	public delegate IntPtr SwigDelegateOdStringBuf_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdStringBuf_1();

	public delegate void SwigDelegateOdStringBuf_2(IntPtr pSource);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdStringBuf_3();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdStringBuf_0 swigDelegate0;

	private SwigDelegateOdStringBuf_1 swigDelegate1;

	private SwigDelegateOdStringBuf_2 swigDelegate2;

	private SwigDelegateOdStringBuf_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdStringBuf(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdStringBuf obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdStringBuf(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public void init(OdStreamBuf pIo, OdStringBuf_CharFormat cf)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_init__SWIG_0(swigCPtr, OdStreamBuf.getCPtr(pIo), (int)cf);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void init(OdStreamBuf pIo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_init__SWIG_1(swigCPtr, OdStreamBuf.getCPtr(pIo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new static OdStringBuf cast(OdRxObject pObj)
	{
		OdStringBuf rXObject = Helpers.GetRXObject<OdStringBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_isASwigExplicitOdStringBuf(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_queryXSwigExplicitOdStringBuf(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual string getString()
	{
		string result = (SwigDerivedClassHasMethod("getString", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_getStringSwigExplicitOdStringBuf(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_getString(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdStreamBuf getIOPtr()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_getIOPtr(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdStringBuf_CharFormat getCharFormat()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_getCharFormat(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdStringBuf_CharFormat)result;
	}

	public static uint GetUnicodeHeaderForType(OdStringBuf_CharFormat type)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_GetUnicodeHeaderForType((int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static long GetUnicodeHeaderSizeForType(OdStringBuf_CharFormat type)
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_GetUnicodeHeaderSizeForType((int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static long GetUnicodeBitSizeForType(OdStringBuf_CharFormat type)
	{
		long result = TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_GetUnicodeBitSizeForType((int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void DefaultingType(out OdStringBuf_CharFormat type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_DefaultingType(out type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void DefaultUTF16Type(out OdStringBuf_CharFormat type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_DefaultUTF16Type(out type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void DefaultUTF32Type(out OdStringBuf_CharFormat type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_DefaultUTF32Type(out type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void WriteUnicodeHeader(OdStringBuf_CharFormat type, ref OdStreamBuf io)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteUnicodeHeader((int)type, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteString(OdStringBuf_CharFormat type, ref OdStreamBuf io, string text)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteString((int)type, ref jarg, text);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteNL(OdStringBuf_CharFormat type, ref OdStreamBuf io, bool use_odc)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteNL__SWIG_0((int)type, ref jarg, use_odc);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteNL(OdStringBuf_CharFormat type, ref OdStreamBuf io)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteNL__SWIG_1((int)type, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteSpace(OdStringBuf_CharFormat type, ref OdStreamBuf io, bool use_odc)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteSpace__SWIG_0((int)type, ref jarg, use_odc);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteSpace(OdStringBuf_CharFormat type, ref OdStreamBuf io)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteSpace__SWIG_1((int)type, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteTab(OdStringBuf_CharFormat type, ref OdStreamBuf io, bool use_odc)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteTab__SWIG_0((int)type, ref jarg, use_odc);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteTab(OdStringBuf_CharFormat type, ref OdStreamBuf io)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteTab__SWIG_1((int)type, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteOdInt8(OdStringBuf_CharFormat type, ref OdStreamBuf io, sbyte var)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteOdInt8((int)type, ref jarg, var);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteOdUInt8(OdStringBuf_CharFormat type, ref OdStreamBuf io, byte var)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteOdUInt8((int)type, ref jarg, var);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteOdInt16(OdStringBuf_CharFormat type, ref OdStreamBuf io, short var)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteOdInt16((int)type, ref jarg, var);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteOdUInt16(OdStringBuf_CharFormat type, ref OdStreamBuf io, ushort var)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteOdUInt16((int)type, ref jarg, var);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteOdInt32(OdStringBuf_CharFormat type, ref OdStreamBuf io, int var)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteOdInt32((int)type, ref jarg, var);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteOdUInt32(OdStringBuf_CharFormat type, ref OdStreamBuf io, uint var)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteOdUInt32((int)type, ref jarg, var);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteOdFloat(OdStringBuf_CharFormat type, ref OdStreamBuf io, float var)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteOdFloat((int)type, ref jarg, var);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static void WriteOdDouble(OdStringBuf_CharFormat type, ref OdStreamBuf io, double var)
	{
		IntPtr jarg = ((io == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(io).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_WriteOdDouble((int)type, ref jarg, var);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				io = null;
			}
			if (jarg != intPtr)
			{
				io = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdStringBuf createObject()
	{
		OdStringBuf rXObject = Helpers.GetRXObject<OdStringBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("getString", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgetString;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdStringBuf_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdStringBuf));
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
	private string SwigDirectorMethodgetString()
	{
		return getString();
	}
}
