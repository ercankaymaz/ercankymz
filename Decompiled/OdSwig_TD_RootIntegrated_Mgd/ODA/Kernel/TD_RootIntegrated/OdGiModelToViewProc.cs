using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiModelToViewProc : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiModelToViewProc_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_1();

	public delegate void SwigDelegateOdGiModelToViewProc_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiModelToViewProc_3(IntPtr pDrawCtx);

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_4();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_5();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_6();

	public delegate void SwigDelegateOdGiModelToViewProc_7(IntPtr xMat);

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_8();

	public delegate void SwigDelegateOdGiModelToViewProc_9(IntPtr target, IntPtr xVector, IntPtr upVector, IntPtr eyeVector);

	public delegate void SwigDelegateOdGiModelToViewProc_10(IntPtr xMat);

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_11();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_12();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_13();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_14();

	public delegate void SwigDelegateOdGiModelToViewProc_15(IntPtr xMat);

	public delegate void SwigDelegateOdGiModelToViewProc_16();

	public delegate bool SwigDelegateOdGiModelToViewProc_17();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_18();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_19();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_20();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_21();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_22();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_23();

	public delegate void SwigDelegateOdGiModelToViewProc_24(IntPtr pBoundary);

	public delegate void SwigDelegateOdGiModelToViewProc_25(IntPtr pBoundary, IntPtr pClipInfo);

	public delegate void SwigDelegateOdGiModelToViewProc_26();

	public delegate bool SwigDelegateOdGiModelToViewProc_27();

	public delegate bool SwigDelegateOdGiModelToViewProc_28();

	public delegate void SwigDelegateOdGiModelToViewProc_29();

	public delegate int SwigDelegateOdGiModelToViewProc_30(bool bSectioning, bool bClear);

	public delegate int SwigDelegateOdGiModelToViewProc_31(bool bSectioning);

	public delegate int SwigDelegateOdGiModelToViewProc_32();

	public delegate void SwigDelegateOdGiModelToViewProc_33(IntPtr worldDev);

	public delegate void SwigDelegateOdGiModelToViewProc_34(IntPtr deviations);

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_35();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_36();

	public delegate IntPtr SwigDelegateOdGiModelToViewProc_37();

	public delegate void SwigDelegateOdGiModelToViewProc_38(int newClipCS);

	public delegate int SwigDelegateOdGiModelToViewProc_39();

	public delegate void SwigDelegateOdGiModelToViewProc_40(bool bEnable);

	public delegate void SwigDelegateOdGiModelToViewProc_41();

	public delegate bool SwigDelegateOdGiModelToViewProc_42();

	public delegate void SwigDelegateOdGiModelToViewProc_43([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	public delegate void SwigDelegateOdGiModelToViewProc_44();

	public delegate bool SwigDelegateOdGiModelToViewProc_45();

	public delegate void SwigDelegateOdGiModelToViewProc_46(bool bEnable);

	public delegate bool SwigDelegateOdGiModelToViewProc_47();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiModelToViewProc_0 swigDelegate0;

	private SwigDelegateOdGiModelToViewProc_1 swigDelegate1;

	private SwigDelegateOdGiModelToViewProc_2 swigDelegate2;

	private SwigDelegateOdGiModelToViewProc_3 swigDelegate3;

	private SwigDelegateOdGiModelToViewProc_4 swigDelegate4;

	private SwigDelegateOdGiModelToViewProc_5 swigDelegate5;

	private SwigDelegateOdGiModelToViewProc_6 swigDelegate6;

	private SwigDelegateOdGiModelToViewProc_7 swigDelegate7;

	private SwigDelegateOdGiModelToViewProc_8 swigDelegate8;

	private SwigDelegateOdGiModelToViewProc_9 swigDelegate9;

	private SwigDelegateOdGiModelToViewProc_10 swigDelegate10;

	private SwigDelegateOdGiModelToViewProc_11 swigDelegate11;

	private SwigDelegateOdGiModelToViewProc_12 swigDelegate12;

	private SwigDelegateOdGiModelToViewProc_13 swigDelegate13;

	private SwigDelegateOdGiModelToViewProc_14 swigDelegate14;

	private SwigDelegateOdGiModelToViewProc_15 swigDelegate15;

	private SwigDelegateOdGiModelToViewProc_16 swigDelegate16;

	private SwigDelegateOdGiModelToViewProc_17 swigDelegate17;

	private SwigDelegateOdGiModelToViewProc_18 swigDelegate18;

	private SwigDelegateOdGiModelToViewProc_19 swigDelegate19;

	private SwigDelegateOdGiModelToViewProc_20 swigDelegate20;

	private SwigDelegateOdGiModelToViewProc_21 swigDelegate21;

	private SwigDelegateOdGiModelToViewProc_22 swigDelegate22;

	private SwigDelegateOdGiModelToViewProc_23 swigDelegate23;

	private SwigDelegateOdGiModelToViewProc_24 swigDelegate24;

	private SwigDelegateOdGiModelToViewProc_25 swigDelegate25;

	private SwigDelegateOdGiModelToViewProc_26 swigDelegate26;

	private SwigDelegateOdGiModelToViewProc_27 swigDelegate27;

	private SwigDelegateOdGiModelToViewProc_28 swigDelegate28;

	private SwigDelegateOdGiModelToViewProc_29 swigDelegate29;

	private SwigDelegateOdGiModelToViewProc_30 swigDelegate30;

	private SwigDelegateOdGiModelToViewProc_31 swigDelegate31;

	private SwigDelegateOdGiModelToViewProc_32 swigDelegate32;

	private SwigDelegateOdGiModelToViewProc_33 swigDelegate33;

	private SwigDelegateOdGiModelToViewProc_34 swigDelegate34;

	private SwigDelegateOdGiModelToViewProc_35 swigDelegate35;

	private SwigDelegateOdGiModelToViewProc_36 swigDelegate36;

	private SwigDelegateOdGiModelToViewProc_37 swigDelegate37;

	private SwigDelegateOdGiModelToViewProc_38 swigDelegate38;

	private SwigDelegateOdGiModelToViewProc_39 swigDelegate39;

	private SwigDelegateOdGiModelToViewProc_40 swigDelegate40;

	private SwigDelegateOdGiModelToViewProc_41 swigDelegate41;

	private SwigDelegateOdGiModelToViewProc_42 swigDelegate42;

	private SwigDelegateOdGiModelToViewProc_43 swigDelegate43;

	private SwigDelegateOdGiModelToViewProc_44 swigDelegate44;

	private SwigDelegateOdGiModelToViewProc_45 swigDelegate45;

	private SwigDelegateOdGiModelToViewProc_46 swigDelegate46;

	private SwigDelegateOdGiModelToViewProc_47 swigDelegate47;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiConveyorContext) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[4]
	{
		typeof(OdGePoint3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d),
		typeof(OdGeVector3d)
	};

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGiClipBoundary) };

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdGiClipBoundary),
		typeof(OdGiAbstractClipBoundary)
	};

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[2]
	{
		typeof(bool),
		typeof(bool)
	};

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdGiDeviation) };

	private static Type[] swigMethodTypes34 = new Type[1] { typeof(OdDoubleArray) };

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdGiModelToViewProc_ClippingCS) };

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes44 = new Type[0];

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes47 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiModelToViewProc(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiModelToViewProc obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiModelToViewProc(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdGiModelToViewProc()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiModelToViewProc(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiModelToViewProc) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdGiModelToViewProc cast(OdRxObject pObj)
	{
		OdGiModelToViewProc rXObject = Helpers.GetRXObject<OdGiModelToViewProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_isASwigExplicitOdGiModelToViewProc(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_queryXSwigExplicitOdGiModelToViewProc(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiModelToViewProc createObject()
	{
		OdGiModelToViewProc rXObject = Helpers.GetRXObject<OdGiModelToViewProc>(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDrawContext(OdGiConveyorContext pDrawCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_setDrawContext(swigCPtr, pDrawCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiConveyorInput modelInput()
	{
		OdGiConveyorInput_Internal result = new OdGiConveyorInput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_modelInput(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorInput eyeInput()
	{
		OdGiConveyorInput_Internal result = new OdGiConveyorInput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_eyeInput(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiConveyorOutput output()
	{
		OdGiConveyorOutput_Internal result = new OdGiConveyorOutput_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_output(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setEyeToOutputTransform(OdGeMatrix3d xMat)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_setEyeToOutputTransform(swigCPtr, OdGeMatrix3d.getCPtr(xMat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d eyeToOutputTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_eyeToOutputTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setView(OdGePoint3d target, OdGeVector3d xVector, OdGeVector3d upVector, OdGeVector3d eyeVector)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_setView(swigCPtr, OdGePoint3d.getCPtr(target), OdGeVector3d.getCPtr(xVector), OdGeVector3d.getCPtr(upVector), OdGeVector3d.getCPtr(eyeVector));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setWorldToEyeTransform(OdGeMatrix3d xMat)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_setWorldToEyeTransform(swigCPtr, OdGeMatrix3d.getCPtr(xMat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeMatrix3d worldToEyeTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_worldToEyeTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d eyeToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_eyeToWorldTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d modelToEyeTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_modelToEyeTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d eyeToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_eyeToModelTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void pushModelTransform(OdGeMatrix3d xMat)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_pushModelTransform(swigCPtr, OdGeMatrix3d.getCPtr(xMat));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void popModelTransform()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_popModelTransform(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isEmptyModelMatrixStack()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_isEmptyModelMatrixStack(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d modelToWorldTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_modelToWorldTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGeMatrix3d worldToModelTransform()
	{
		OdGeMatrix3d result = new OdGeMatrix3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_worldToModelTransform(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiXform getModelToEyeXform()
	{
		OdGiXform rXObject = Helpers.GetRXObject<OdGiXform>(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_getModelToEyeXform__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiXform getEyeToModelXform()
	{
		OdGiXform rXObject = Helpers.GetRXObject<OdGiXform>(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_getEyeToModelXform__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void pushClipBoundary(OdGiClipBoundary pBoundary)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_pushClipBoundary__SWIG_0(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void pushClipBoundary(OdGiClipBoundary pBoundary, OdGiAbstractClipBoundary pClipInfo)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_pushClipBoundary__SWIG_1(swigCPtr, OdGiClipBoundary.getCPtr(pBoundary), OdGiAbstractClipBoundary.getCPtr(pClipInfo));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void popClipBoundary()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_popClipBoundary(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isClipping()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_isClipping(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEmptyClipSet()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_isEmptyClipSet(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void initGeometryClipStatus()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_initGeometryClipStatus(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getGeometryClipStatus(bool bSectioning, bool bClear)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_getGeometryClipStatus__SWIG_0(swigCPtr, bSectioning, bClear);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getGeometryClipStatus(bool bSectioning)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_getGeometryClipStatus__SWIG_1(swigCPtr, bSectioning);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual int getGeometryClipStatus()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_getGeometryClipStatus__SWIG_2(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setWorldDeviation(OdGiDeviation worldDev)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_setWorldDeviation__SWIG_0(swigCPtr, worldDev.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setWorldDeviation(OdDoubleArray deviations)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_setWorldDeviation__SWIG_1(swigCPtr, OdDoubleArray.getCPtr(deviations).Handle);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiDeviation worldDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_worldDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation modelDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_modelDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiDeviation eyeDeviation()
	{
		OdGiDeviation_Internal result = new OdGiDeviation_Internal(TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_eyeDeviation(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setClippingSpace(OdGiModelToViewProc_ClippingCS newClipCS)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_setClippingSpace(swigCPtr, (int)newClipCS);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiModelToViewProc_ClippingCS currentClippingSpace()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_currentClippingSpace(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiModelToViewProc_ClippingCS)result;
	}

	public virtual void enableAnalyticCurvesClipping(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_enableAnalyticCurvesClipping__SWIG_0(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void enableAnalyticCurvesClipping()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_enableAnalyticCurvesClipping__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isAnalyticCurvesClippingEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_isAnalyticCurvesClippingEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void enableClippingDebugLog(string fileName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_enableClippingDebugLog(swigCPtr, fileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void disableClippingDebugLog()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_disableClippingDebugLog(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isClippingDebugLogEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_isClippingDebugLogEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void switchSectioning(bool bEnable)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_switchSectioning(swigCPtr, bEnable);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isSectioningEnabled()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_isSectioningEnabled(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("setDrawContext", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetDrawContext;
		}
		if (SwigDerivedClassHasMethod("modelInput", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodmodelInput;
		}
		if (SwigDerivedClassHasMethod("eyeInput", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodeyeInput;
		}
		if (SwigDerivedClassHasMethod("output", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodoutput;
		}
		if (SwigDerivedClassHasMethod("setEyeToOutputTransform", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetEyeToOutputTransform;
		}
		if (SwigDerivedClassHasMethod("eyeToOutputTransform", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodeyeToOutputTransform;
		}
		if (SwigDerivedClassHasMethod("setView", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetView;
		}
		if (SwigDerivedClassHasMethod("setWorldToEyeTransform", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetWorldToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("worldToEyeTransform", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodworldToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("eyeToWorldTransform", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodeyeToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("modelToEyeTransform", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodmodelToEyeTransform;
		}
		if (SwigDerivedClassHasMethod("eyeToModelTransform", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodeyeToModelTransform;
		}
		if (SwigDerivedClassHasMethod("pushModelTransform", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodpushModelTransform;
		}
		if (SwigDerivedClassHasMethod("popModelTransform", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodpopModelTransform;
		}
		if (SwigDerivedClassHasMethod("isEmptyModelMatrixStack", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodisEmptyModelMatrixStack;
		}
		if (SwigDerivedClassHasMethod("modelToWorldTransform", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodmodelToWorldTransform;
		}
		if (SwigDerivedClassHasMethod("worldToModelTransform", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodworldToModelTransform;
		}
		if (SwigDerivedClassHasMethod("getModelToEyeXform", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodgetModelToEyeXform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getModelToEyeXform", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodgetModelToEyeXform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getEyeToModelXform", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodgetEyeToModelXform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getEyeToModelXform", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodgetEyeToModelXform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodpushClipBoundary__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("pushClipBoundary", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodpushClipBoundary__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("popClipBoundary", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodpopClipBoundary;
		}
		if (SwigDerivedClassHasMethod("isClipping", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodisClipping;
		}
		if (SwigDerivedClassHasMethod("isEmptyClipSet", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodisEmptyClipSet;
		}
		if (SwigDerivedClassHasMethod("initGeometryClipStatus", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodinitGeometryClipStatus;
		}
		if (SwigDerivedClassHasMethod("getGeometryClipStatus", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodgetGeometryClipStatus__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("getGeometryClipStatus", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodgetGeometryClipStatus__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("getGeometryClipStatus", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodgetGeometryClipStatus__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setWorldDeviation", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodsetWorldDeviation__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setWorldDeviation", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodsetWorldDeviation__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("worldDeviation", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodworldDeviation;
		}
		if (SwigDerivedClassHasMethod("modelDeviation", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodmodelDeviation;
		}
		if (SwigDerivedClassHasMethod("eyeDeviation", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodeyeDeviation;
		}
		if (SwigDerivedClassHasMethod("setClippingSpace", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodsetClippingSpace;
		}
		if (SwigDerivedClassHasMethod("currentClippingSpace", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodcurrentClippingSpace;
		}
		if (SwigDerivedClassHasMethod("enableAnalyticCurvesClipping", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodenableAnalyticCurvesClipping__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("enableAnalyticCurvesClipping", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodenableAnalyticCurvesClipping__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isAnalyticCurvesClippingEnabled", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodisAnalyticCurvesClippingEnabled;
		}
		if (SwigDerivedClassHasMethod("enableClippingDebugLog", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodenableClippingDebugLog;
		}
		if (SwigDerivedClassHasMethod("disableClippingDebugLog", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethoddisableClippingDebugLog;
		}
		if (SwigDerivedClassHasMethod("isClippingDebugLogEnabled", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodisClippingDebugLogEnabled;
		}
		if (SwigDerivedClassHasMethod("switchSectioning", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodswitchSectioning;
		}
		if (SwigDerivedClassHasMethod("isSectioningEnabled", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodisSectioningEnabled;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiModelToViewProc_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiModelToViewProc));
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

	private void SwigDirectorMethodsetDrawContext(IntPtr pDrawCtx)
	{
		try
		{
			setDrawContext(new OdGiConveyorContext_Internal(pDrawCtx, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodmodelInput()
	{
		return modelInput().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodeyeInput()
	{
		return eyeInput().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodoutput()
	{
		return output().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetEyeToOutputTransform(IntPtr xMat)
	{
		try
		{
			setEyeToOutputTransform(new OdGeMatrix3d(xMat, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodeyeToOutputTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(eyeToOutputTransform()).Handle;
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

	private void SwigDirectorMethodsetView(IntPtr target, IntPtr xVector, IntPtr upVector, IntPtr eyeVector)
	{
		try
		{
			setView(new OdGePoint3d(target, cMemoryOwn: false), new OdGeVector3d(xVector, cMemoryOwn: false), new OdGeVector3d(upVector, cMemoryOwn: false), new OdGeVector3d(eyeVector, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetWorldToEyeTransform(IntPtr xMat)
	{
		try
		{
			setWorldToEyeTransform(new OdGeMatrix3d(xMat, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodworldToEyeTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(worldToEyeTransform()).Handle;
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

	private IntPtr SwigDirectorMethodeyeToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(eyeToWorldTransform()).Handle;
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

	private IntPtr SwigDirectorMethodmodelToEyeTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(modelToEyeTransform()).Handle;
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

	private IntPtr SwigDirectorMethodeyeToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(eyeToModelTransform()).Handle;
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

	private void SwigDirectorMethodpushModelTransform(IntPtr xMat)
	{
		try
		{
			pushModelTransform(new OdGeMatrix3d(xMat, cMemoryOwn: false));
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

	private void SwigDirectorMethodpopModelTransform()
	{
		try
		{
			popModelTransform();
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

	private bool SwigDirectorMethodisEmptyModelMatrixStack()
	{
		return isEmptyModelMatrixStack();
	}

	private IntPtr SwigDirectorMethodmodelToWorldTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(modelToWorldTransform()).Handle;
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

	private IntPtr SwigDirectorMethodworldToModelTransform()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeMatrix3d.getCPtr(worldToModelTransform()).Handle;
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

	private IntPtr SwigDirectorMethodgetModelToEyeXform__SWIG_0()
	{
		return OdGiXform.getCPtr(getModelToEyeXform()).Handle;
	}

	private IntPtr SwigDirectorMethodgetModelToEyeXform__SWIG_1()
	{
		return OdGiXform.getCPtr(getModelToEyeXform()).Handle;
	}

	private IntPtr SwigDirectorMethodgetEyeToModelXform__SWIG_0()
	{
		return OdGiXform.getCPtr(getEyeToModelXform()).Handle;
	}

	private IntPtr SwigDirectorMethodgetEyeToModelXform__SWIG_1()
	{
		return OdGiXform.getCPtr(getEyeToModelXform()).Handle;
	}

	private void SwigDirectorMethodpushClipBoundary__SWIG_0(IntPtr pBoundary)
	{
		try
		{
			pushClipBoundary((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false));
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

	private void SwigDirectorMethodpushClipBoundary__SWIG_1(IntPtr pBoundary, IntPtr pClipInfo)
	{
		try
		{
			pushClipBoundary((pBoundary == IntPtr.Zero) ? null : new OdGiClipBoundary(pBoundary, cMemoryOwn: false), (pClipInfo == IntPtr.Zero) ? null : new OdGiAbstractClipBoundary(pClipInfo, cMemoryOwn: false));
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

	private void SwigDirectorMethodpopClipBoundary()
	{
		try
		{
			popClipBoundary();
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

	private bool SwigDirectorMethodisClipping()
	{
		return isClipping();
	}

	private bool SwigDirectorMethodisEmptyClipSet()
	{
		return isEmptyClipSet();
	}

	private void SwigDirectorMethodinitGeometryClipStatus()
	{
		try
		{
			initGeometryClipStatus();
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

	private int SwigDirectorMethodgetGeometryClipStatus__SWIG_0(bool bSectioning, bool bClear)
	{
		return getGeometryClipStatus(bSectioning, bClear);
	}

	private int SwigDirectorMethodgetGeometryClipStatus__SWIG_1(bool bSectioning)
	{
		return getGeometryClipStatus(bSectioning);
	}

	private int SwigDirectorMethodgetGeometryClipStatus__SWIG_2()
	{
		return getGeometryClipStatus();
	}

	private void SwigDirectorMethodsetWorldDeviation__SWIG_0(IntPtr worldDev)
	{
		try
		{
			setWorldDeviation(new OdGiDeviation_Internal(worldDev, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetWorldDeviation__SWIG_1(IntPtr deviations)
	{
		try
		{
			setWorldDeviation(new OdDoubleArray(deviations, cMemoryOwn: true));
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

	private IntPtr SwigDirectorMethodworldDeviation()
	{
		return worldDeviation().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodmodelDeviation()
	{
		return modelDeviation().GetInterfaceCPtr().Handle;
	}

	private IntPtr SwigDirectorMethodeyeDeviation()
	{
		return eyeDeviation().GetInterfaceCPtr().Handle;
	}

	private void SwigDirectorMethodsetClippingSpace(int newClipCS)
	{
		try
		{
			setClippingSpace((OdGiModelToViewProc_ClippingCS)newClipCS);
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

	private int SwigDirectorMethodcurrentClippingSpace()
	{
		return (int)currentClippingSpace();
	}

	private void SwigDirectorMethodenableAnalyticCurvesClipping__SWIG_0(bool bEnable)
	{
		try
		{
			enableAnalyticCurvesClipping(bEnable);
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

	private void SwigDirectorMethodenableAnalyticCurvesClipping__SWIG_1()
	{
		try
		{
			enableAnalyticCurvesClipping();
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

	private bool SwigDirectorMethodisAnalyticCurvesClippingEnabled()
	{
		return isAnalyticCurvesClippingEnabled();
	}

	private void SwigDirectorMethodenableClippingDebugLog([MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		try
		{
			enableClippingDebugLog(fileName);
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

	private void SwigDirectorMethoddisableClippingDebugLog()
	{
		try
		{
			disableClippingDebugLog();
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

	private bool SwigDirectorMethodisClippingDebugLogEnabled()
	{
		return isClippingDebugLogEnabled();
	}

	private void SwigDirectorMethodswitchSectioning(bool bEnable)
	{
		try
		{
			switchSectioning(bEnable);
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

	private bool SwigDirectorMethodisSectioningEnabled()
	{
		return isSectioningEnabled();
	}
}
