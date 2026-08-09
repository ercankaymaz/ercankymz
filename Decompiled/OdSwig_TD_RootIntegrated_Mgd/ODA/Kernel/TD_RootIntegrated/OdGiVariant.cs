using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiVariant : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiVariant_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiVariant_1();

	public delegate void SwigDelegateOdGiVariant_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiVariant_0 swigDelegate0;

	private SwigDelegateOdGiVariant_1 swigDelegate1;

	private SwigDelegateOdGiVariant_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiVariant(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiVariant obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiVariant(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiVariant cast(OdRxObject pObj)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_isASwigExplicitOdGiVariant(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_queryXSwigExplicitOdGiVariant(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiVariant createObject()
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_createObject__SWIG_0(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected OdGiVariant()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiVariant(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiVariant) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public static OdGiVariant createObject(OdGiVariant value)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_createObject__SWIG_1(getCPtr(value)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiVariant createObject(bool value)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_createObject__SWIG_2(value), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiVariant createObject(int value)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_createObject__SWIG_3(value), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiVariant createObject(double value)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_createObject__SWIG_4(value), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiVariant createObject(OdCmEntityColor value)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_createObject__SWIG_5(OdCmEntityColor.getCPtr(value)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiVariant createObject(string value)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_createObject__SWIG_6(value), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool IsEqual(OdGiVariant value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_IsEqual(swigCPtr, getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiVariant Assign(OdGiVariant value)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_Assign(swigCPtr, getCPtr(value)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_copyFromSwigExplicitOdGiVariant(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiVariant_VariantType type()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_type(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiVariant_VariantType)result;
	}

	public void set(bool value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_set__SWIG_0(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(int value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_set__SWIG_1(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(double value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_set__SWIG_2(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(OdCmEntityColor value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_set__SWIG_3(swigCPtr, OdCmEntityColor.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void set(string value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_set__SWIG_4(swigCPtr, value);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool asBoolean()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asBoolean(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int asInt()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asInt(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public double asDouble()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asDouble(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor asColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asColor(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public string asString()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asString(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public float asFloat()
	{
		float result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asFloat(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public sbyte asChar()
	{
		sbyte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asChar(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public byte asUchar()
	{
		byte result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asUchar(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public short asShort()
	{
		short result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asShort(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public ushort asUshort()
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asUshort(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint asUint()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asUint(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int asLong()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asLong(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public uint asUlong()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_asUlong(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getElem(string elem, ref OdGiVariant value)
	{
		IntPtr jarg = ((value == null) ? IntPtr.Zero : getCPtr(value).Handle);
		IntPtr intPtr = jarg;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_getElem__SWIG_0(swigCPtr, elem, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				value = null;
			}
			if (jarg != intPtr)
			{
				value = Helpers.GetRXObject<OdGiVariant>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiVariant getElem(string elem)
	{
		OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_getElem__SWIG_1(swigCPtr, elem), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setElem(string elem, OdGiVariant value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_setElem(swigCPtr, elem, getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void deleteElem(string elem)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_deleteElem(swigCPtr, elem);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public int getElemCount()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_getElemCount(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getElemAt(int nElem, ref string elem, ref OdGiVariant value)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(elem);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = ((value == null) ? IntPtr.Zero : getCPtr(value).Handle);
		IntPtr intPtr2 = jarg2;
		try
		{
			bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_getElemAt__SWIG_0(swigCPtr, nElem, ref jarg, ref jarg2);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				elem = Marshal.PtrToStringUni(jarg);
			}
			if (jarg2 == IntPtr.Zero)
			{
				value = null;
			}
			if (jarg2 != intPtr2)
			{
				value = Helpers.GetRXObject<OdGiVariant>(jarg2, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdGiVariant getElemAt(int nElem, ref string elem)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(elem);
		IntPtr intPtr = jarg;
		try
		{
			OdGiVariant rXObject = Helpers.GetRXObject<OdGiVariant>(TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_getElemAt__SWIG_1(swigCPtr, nElem, ref jarg), bOwn: false, bTryAddToTransaction: true);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return rXObject;
		}
		finally
		{
			if (jarg != intPtr)
			{
				elem = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public static bool isEquivalent(OdGiVariant v1, OdGiVariant v2)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_isEquivalent(getCPtr(v1), getCPtr(v2));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_getRealClassName(ptr);
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
		TD_RootIntegrated_GlobalsPINVOKE.OdGiVariant_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiVariant));
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
}
