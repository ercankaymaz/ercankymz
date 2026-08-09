using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbParameterInterface : OdRxObject
{
	public delegate IntPtr SwigDelegateOdDbParameterInterface_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdDbParameterInterface_1();

	public delegate void SwigDelegateOdDbParameterInterface_2(IntPtr pSource);

	public delegate int SwigDelegateOdDbParameterInterface_3();

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbParameterInterface_4();

	public delegate void SwigDelegateOdDbParameterInterface_5([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	public delegate bool SwigDelegateOdDbParameterInterface_6([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	public delegate bool SwigDelegateOdDbParameterInterface_7([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbParameterInterface_8(bool arg0, IntPtr arg1);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbParameterInterface_9();

	public delegate int SwigDelegateOdDbParameterInterface_10([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdDbParameterInterface_11();

	public delegate void SwigDelegateOdDbParameterInterface_12([MarshalAs(UnmanagedType.LPWStr)] string arg0);

	public delegate IntPtr SwigDelegateOdDbParameterInterface_13();

	public delegate int SwigDelegateOdDbParameterInterface_14(IntPtr arg0);

	public delegate IntPtr SwigDelegateOdDbParameterInterface_15();

	public delegate bool SwigDelegateOdDbParameterInterface_16();

	public delegate int SwigDelegateOdDbParameterInterface_17();

	public delegate bool SwigDelegateOdDbParameterInterface_18();

	public delegate bool SwigDelegateOdDbParameterInterface_19();

	public delegate bool SwigDelegateOdDbParameterInterface_20();

	public delegate IntPtr SwigDelegateOdDbParameterInterface_21();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbParameterInterface_0 swigDelegate0;

	private SwigDelegateOdDbParameterInterface_1 swigDelegate1;

	private SwigDelegateOdDbParameterInterface_2 swigDelegate2;

	private SwigDelegateOdDbParameterInterface_3 swigDelegate3;

	private SwigDelegateOdDbParameterInterface_4 swigDelegate4;

	private SwigDelegateOdDbParameterInterface_5 swigDelegate5;

	private SwigDelegateOdDbParameterInterface_6 swigDelegate6;

	private SwigDelegateOdDbParameterInterface_7 swigDelegate7;

	private SwigDelegateOdDbParameterInterface_8 swigDelegate8;

	private SwigDelegateOdDbParameterInterface_9 swigDelegate9;

	private SwigDelegateOdDbParameterInterface_10 swigDelegate10;

	private SwigDelegateOdDbParameterInterface_11 swigDelegate11;

	private SwigDelegateOdDbParameterInterface_12 swigDelegate12;

	private SwigDelegateOdDbParameterInterface_13 swigDelegate13;

	private SwigDelegateOdDbParameterInterface_14 swigDelegate14;

	private SwigDelegateOdDbParameterInterface_15 swigDelegate15;

	private SwigDelegateOdDbParameterInterface_16 swigDelegate16;

	private SwigDelegateOdDbParameterInterface_17 swigDelegate17;

	private SwigDelegateOdDbParameterInterface_18 swigDelegate18;

	private SwigDelegateOdDbParameterInterface_19 swigDelegate19;

	private SwigDelegateOdDbParameterInterface_20 swigDelegate20;

	private SwigDelegateOdDbParameterInterface_21 swigDelegate21;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(bool).MakeByRefType(),
		typeof(OdDbEvalVariant).MakeByRefType()
	};

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbEvalVariant) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbParameterInterface(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbParameterInterface obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbParameterInterface(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdDbParameterInterface cast(OdRxObject pObj)
	{
		OdDbParameterInterface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParameterInterface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_isASwigExplicitOdDbParameterInterface(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_queryXSwigExplicitOdDbParameterInterface(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbParameterInterface createObject()
	{
		OdDbParameterInterface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParameterInterface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual int valueId()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_valueId(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getName()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getName(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setName(string arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_setName(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isNameValid(string arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_isNameValid(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isNameUnique(string arg0)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_isNameUnique(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string getExpression(out bool arg0, ref OdDbEvalVariant arg1)
	{
		IntPtr jarg = ((arg1 == null) ? IntPtr.Zero : OdDbEvalVariant.getCPtr(arg1).Handle);
		IntPtr intPtr = jarg;
		try
		{
			string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getExpression__SWIG_0(swigCPtr, out arg0, ref jarg);
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
				arg1 = null;
			}
			if (jarg != intPtr)
			{
				arg1 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual string getExpression()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getExpression__SWIG_1(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setExpression(string arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_setExpression(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual string getDescription()
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getDescription(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setDescription(string arg0)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_setDescription(swigCPtr, arg0);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdDbEvalVariant getValue()
	{
		OdDbEvalVariant result = new OdDbEvalVariant(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getValue(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdResult setValue(OdDbEvalVariant arg0)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_setValue(swigCPtr, OdDbEvalVariant.getCPtr(arg0));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdResult)result;
	}

	public virtual OdDbParameterValueSet getValueSet()
	{
		OdDbParameterValueSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParameterValueSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getValueSet(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool getIsReadOnly()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getIsReadOnly(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual DwgDataType getDataType()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getDataType(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (DwgDataType)result;
	}

	public virtual bool isUsedInExpression()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_isUsedInExpression(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isAngular()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_isAngular(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isRuntimeInterface()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_isRuntimeInterface(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbObject parameterObject()
	{
		OdDbObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_parameterObject(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbParameterInterface parameterInterface(OdDbObject obj, string name, bool isRuntimeInterface)
	{
		OdDbParameterInterface rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbParameterInterface>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_parameterInterface(OdDbObject.getCPtr(obj), name, isRuntimeInterface), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_getRealClassName(ptr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdDbParameterInterface()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbParameterInterface(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbParameterInterface) != GetType();
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
		if (SwigDerivedClassHasMethod("valueId", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodvalueId;
		}
		if (SwigDerivedClassHasMethod("getName", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgetName;
		}
		if (SwigDerivedClassHasMethod("setName", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetName;
		}
		if (SwigDerivedClassHasMethod("isNameValid", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodisNameValid;
		}
		if (SwigDerivedClassHasMethod("isNameUnique", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodisNameUnique;
		}
		if (SwigDerivedClassHasMethod("getExpression", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgetExpression__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getExpression", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodgetExpression__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setExpression", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetExpression;
		}
		if (SwigDerivedClassHasMethod("getDescription", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodgetDescription;
		}
		if (SwigDerivedClassHasMethod("setDescription", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetDescription;
		}
		if (SwigDerivedClassHasMethod("getValue", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodgetValue;
		}
		if (SwigDerivedClassHasMethod("setValue", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetValue;
		}
		if (SwigDerivedClassHasMethod("getValueSet", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodgetValueSet;
		}
		if (SwigDerivedClassHasMethod("getIsReadOnly", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodgetIsReadOnly;
		}
		if (SwigDerivedClassHasMethod("getDataType", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodgetDataType;
		}
		if (SwigDerivedClassHasMethod("isUsedInExpression", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodisUsedInExpression;
		}
		if (SwigDerivedClassHasMethod("isAngular", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodisAngular;
		}
		if (SwigDerivedClassHasMethod("isRuntimeInterface", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodisRuntimeInterface;
		}
		if (SwigDerivedClassHasMethod("parameterObject", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodparameterObject;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbParameterInterface_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbParameterInterface));
	}

	private IntPtr SwigDirectorMethodqueryX(IntPtr protocolClass)
	{
		return OdRxObject.getCPtr(queryX(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxClass>(protocolClass, bOwn: false, bTryAddToTransaction: false))).Handle;
	}

	private IntPtr SwigDirectorMethodisA()
	{
		return OdRxClass.getCPtr(isA()).Handle;
	}

	private void SwigDirectorMethodcopyFrom(IntPtr pSource)
	{
		try
		{
			copyFrom(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(pSource, bOwn: false, bTryAddToTransaction: false));
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

	private int SwigDirectorMethodvalueId()
	{
		return valueId();
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetName()
	{
		return getName();
	}

	private void SwigDirectorMethodsetName([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		try
		{
			setName(arg0);
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

	private bool SwigDirectorMethodisNameValid([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		return isNameValid(arg0);
	}

	private bool SwigDirectorMethodisNameUnique([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		return isNameUnique(arg0);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetExpression__SWIG_0(bool arg0, IntPtr arg1)
	{
		OdSwigDirectorHelper.director_UnpackData(arg1, out var pOriginalObject, out var pFunction);
		OdDbEvalVariant arg2 = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(pOriginalObject, bOwn: false, bTryAddToTransaction: true);
		try
		{
			return getExpression(out arg0, ref arg2);
		}
		finally
		{
			IntPtr handle = OdDbEvalVariant.getCPtr(arg2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(arg1);
		}
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetExpression__SWIG_1()
	{
		return getExpression();
	}

	private int SwigDirectorMethodsetExpression([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		return (int)setExpression(arg0);
	}

	[return: MarshalAs(UnmanagedType.LPWStr)]
	private string SwigDirectorMethodgetDescription()
	{
		return getDescription();
	}

	private void SwigDirectorMethodsetDescription([MarshalAs(UnmanagedType.LPWStr)] string arg0)
	{
		try
		{
			setDescription(arg0);
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

	private IntPtr SwigDirectorMethodgetValue()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbEvalVariant.getCPtr(getValue()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				TD_DbCoreIntegrated_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				TD_DbCoreIntegrated_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private int SwigDirectorMethodsetValue(IntPtr arg0)
	{
		return (int)setValue(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbEvalVariant>(arg0, bOwn: false, bTryAddToTransaction: false));
	}

	private IntPtr SwigDirectorMethodgetValueSet()
	{
		return OdDbParameterValueSet.getCPtr(getValueSet()).Handle;
	}

	private bool SwigDirectorMethodgetIsReadOnly()
	{
		return getIsReadOnly();
	}

	private int SwigDirectorMethodgetDataType()
	{
		return (int)getDataType();
	}

	private bool SwigDirectorMethodisUsedInExpression()
	{
		return isUsedInExpression();
	}

	private bool SwigDirectorMethodisAngular()
	{
		return isAngular();
	}

	private bool SwigDirectorMethodisRuntimeInterface()
	{
		return isRuntimeInterface();
	}

	private IntPtr SwigDirectorMethodparameterObject()
	{
		return OdDbObject.getCPtr(parameterObject()).Handle;
	}
}
