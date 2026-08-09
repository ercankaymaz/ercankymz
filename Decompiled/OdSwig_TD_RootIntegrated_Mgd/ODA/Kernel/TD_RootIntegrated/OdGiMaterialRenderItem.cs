using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMaterialRenderItem : OdGiMaterialItem
{
	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_1();

	public delegate void SwigDelegateOdGiMaterialRenderItem_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_3();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_4();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_5();

	public delegate void SwigDelegateOdGiMaterialRenderItem_6();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_7();

	public delegate uint SwigDelegateOdGiMaterialRenderItem_8(string pOrder, bool bCheckAny);

	public delegate uint SwigDelegateOdGiMaterialRenderItem_9(string pOrder);

	public delegate uint SwigDelegateOdGiMaterialRenderItem_10();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_11();

	public delegate void SwigDelegateOdGiMaterialRenderItem_12(IntPtr data);

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_13();

	public delegate void SwigDelegateOdGiMaterialRenderItem_14(IntPtr matId);

	public delegate void SwigDelegateOdGiMaterialRenderItem_15();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_16(IntPtr matId);

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_17();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_18();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_19();

	public delegate void SwigDelegateOdGiMaterialRenderItem_20();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_21();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_22();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_23();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_24();

	public delegate void SwigDelegateOdGiMaterialRenderItem_25();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_26();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_27();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_28();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_29();

	public delegate void SwigDelegateOdGiMaterialRenderItem_30();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_31();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_32();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_33();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_34();

	public delegate void SwigDelegateOdGiMaterialRenderItem_35();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_36();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_37();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_38();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_39();

	public delegate void SwigDelegateOdGiMaterialRenderItem_40();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_41();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_42();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_43();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_44();

	public delegate void SwigDelegateOdGiMaterialRenderItem_45();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_46();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_47();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_48();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_49();

	public delegate void SwigDelegateOdGiMaterialRenderItem_50();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_51();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_52();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_53();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_54();

	public delegate void SwigDelegateOdGiMaterialRenderItem_55();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_56();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_57();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_58();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_59();

	public delegate void SwigDelegateOdGiMaterialRenderItem_60();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_61();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_62();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_63();

	public delegate IntPtr SwigDelegateOdGiMaterialRenderItem_64();

	public delegate void SwigDelegateOdGiMaterialRenderItem_65();

	public delegate bool SwigDelegateOdGiMaterialRenderItem_66();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMaterialRenderItem_0 swigDelegate0;

	private SwigDelegateOdGiMaterialRenderItem_1 swigDelegate1;

	private SwigDelegateOdGiMaterialRenderItem_2 swigDelegate2;

	private SwigDelegateOdGiMaterialRenderItem_3 swigDelegate3;

	private SwigDelegateOdGiMaterialRenderItem_4 swigDelegate4;

	private SwigDelegateOdGiMaterialRenderItem_5 swigDelegate5;

	private SwigDelegateOdGiMaterialRenderItem_6 swigDelegate6;

	private SwigDelegateOdGiMaterialRenderItem_7 swigDelegate7;

	private SwigDelegateOdGiMaterialRenderItem_8 swigDelegate8;

	private SwigDelegateOdGiMaterialRenderItem_9 swigDelegate9;

	private SwigDelegateOdGiMaterialRenderItem_10 swigDelegate10;

	private SwigDelegateOdGiMaterialRenderItem_11 swigDelegate11;

	private SwigDelegateOdGiMaterialRenderItem_12 swigDelegate12;

	private SwigDelegateOdGiMaterialRenderItem_13 swigDelegate13;

	private SwigDelegateOdGiMaterialRenderItem_14 swigDelegate14;

	private SwigDelegateOdGiMaterialRenderItem_15 swigDelegate15;

	private SwigDelegateOdGiMaterialRenderItem_16 swigDelegate16;

	private SwigDelegateOdGiMaterialRenderItem_17 swigDelegate17;

	private SwigDelegateOdGiMaterialRenderItem_18 swigDelegate18;

	private SwigDelegateOdGiMaterialRenderItem_19 swigDelegate19;

	private SwigDelegateOdGiMaterialRenderItem_20 swigDelegate20;

	private SwigDelegateOdGiMaterialRenderItem_21 swigDelegate21;

	private SwigDelegateOdGiMaterialRenderItem_22 swigDelegate22;

	private SwigDelegateOdGiMaterialRenderItem_23 swigDelegate23;

	private SwigDelegateOdGiMaterialRenderItem_24 swigDelegate24;

	private SwigDelegateOdGiMaterialRenderItem_25 swigDelegate25;

	private SwigDelegateOdGiMaterialRenderItem_26 swigDelegate26;

	private SwigDelegateOdGiMaterialRenderItem_27 swigDelegate27;

	private SwigDelegateOdGiMaterialRenderItem_28 swigDelegate28;

	private SwigDelegateOdGiMaterialRenderItem_29 swigDelegate29;

	private SwigDelegateOdGiMaterialRenderItem_30 swigDelegate30;

	private SwigDelegateOdGiMaterialRenderItem_31 swigDelegate31;

	private SwigDelegateOdGiMaterialRenderItem_32 swigDelegate32;

	private SwigDelegateOdGiMaterialRenderItem_33 swigDelegate33;

	private SwigDelegateOdGiMaterialRenderItem_34 swigDelegate34;

	private SwigDelegateOdGiMaterialRenderItem_35 swigDelegate35;

	private SwigDelegateOdGiMaterialRenderItem_36 swigDelegate36;

	private SwigDelegateOdGiMaterialRenderItem_37 swigDelegate37;

	private SwigDelegateOdGiMaterialRenderItem_38 swigDelegate38;

	private SwigDelegateOdGiMaterialRenderItem_39 swigDelegate39;

	private SwigDelegateOdGiMaterialRenderItem_40 swigDelegate40;

	private SwigDelegateOdGiMaterialRenderItem_41 swigDelegate41;

	private SwigDelegateOdGiMaterialRenderItem_42 swigDelegate42;

	private SwigDelegateOdGiMaterialRenderItem_43 swigDelegate43;

	private SwigDelegateOdGiMaterialRenderItem_44 swigDelegate44;

	private SwigDelegateOdGiMaterialRenderItem_45 swigDelegate45;

	private SwigDelegateOdGiMaterialRenderItem_46 swigDelegate46;

	private SwigDelegateOdGiMaterialRenderItem_47 swigDelegate47;

	private SwigDelegateOdGiMaterialRenderItem_48 swigDelegate48;

	private SwigDelegateOdGiMaterialRenderItem_49 swigDelegate49;

	private SwigDelegateOdGiMaterialRenderItem_50 swigDelegate50;

	private SwigDelegateOdGiMaterialRenderItem_51 swigDelegate51;

	private SwigDelegateOdGiMaterialRenderItem_52 swigDelegate52;

	private SwigDelegateOdGiMaterialRenderItem_53 swigDelegate53;

	private SwigDelegateOdGiMaterialRenderItem_54 swigDelegate54;

	private SwigDelegateOdGiMaterialRenderItem_55 swigDelegate55;

	private SwigDelegateOdGiMaterialRenderItem_56 swigDelegate56;

	private SwigDelegateOdGiMaterialRenderItem_57 swigDelegate57;

	private SwigDelegateOdGiMaterialRenderItem_58 swigDelegate58;

	private SwigDelegateOdGiMaterialRenderItem_59 swigDelegate59;

	private SwigDelegateOdGiMaterialRenderItem_60 swigDelegate60;

	private SwigDelegateOdGiMaterialRenderItem_61 swigDelegate61;

	private SwigDelegateOdGiMaterialRenderItem_62 swigDelegate62;

	private SwigDelegateOdGiMaterialRenderItem_63 swigDelegate63;

	private SwigDelegateOdGiMaterialRenderItem_64 swigDelegate64;

	private SwigDelegateOdGiMaterialRenderItem_65 swigDelegate65;

	private SwigDelegateOdGiMaterialRenderItem_66 swigDelegate66;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[2]
	{
		typeof(string),
		typeof(bool)
	};

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[0];

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[0];

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[0];

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[0];

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[0];

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[0];

	private static Type[] swigMethodTypes38 = new Type[0];

	private static Type[] swigMethodTypes39 = new Type[0];

	private static Type[] swigMethodTypes40 = new Type[0];

	private static Type[] swigMethodTypes41 = new Type[0];

	private static Type[] swigMethodTypes42 = new Type[0];

	private static Type[] swigMethodTypes43 = new Type[0];

	private static Type[] swigMethodTypes44 = new Type[0];

	private static Type[] swigMethodTypes45 = new Type[0];

	private static Type[] swigMethodTypes46 = new Type[0];

	private static Type[] swigMethodTypes47 = new Type[0];

	private static Type[] swigMethodTypes48 = new Type[0];

	private static Type[] swigMethodTypes49 = new Type[0];

	private static Type[] swigMethodTypes50 = new Type[0];

	private static Type[] swigMethodTypes51 = new Type[0];

	private static Type[] swigMethodTypes52 = new Type[0];

	private static Type[] swigMethodTypes53 = new Type[0];

	private static Type[] swigMethodTypes54 = new Type[0];

	private static Type[] swigMethodTypes55 = new Type[0];

	private static Type[] swigMethodTypes56 = new Type[0];

	private static Type[] swigMethodTypes57 = new Type[0];

	private static Type[] swigMethodTypes58 = new Type[0];

	private static Type[] swigMethodTypes59 = new Type[0];

	private static Type[] swigMethodTypes60 = new Type[0];

	private static Type[] swigMethodTypes61 = new Type[0];

	private static Type[] swigMethodTypes62 = new Type[0];

	private static Type[] swigMethodTypes63 = new Type[0];

	private static Type[] swigMethodTypes64 = new Type[0];

	private static Type[] swigMethodTypes65 = new Type[0];

	private static Type[] swigMethodTypes66 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMaterialRenderItem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMaterialRenderItem obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMaterialRenderItem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMaterialRenderItem cast(OdRxObject pObj)
	{
		OdGiMaterialRenderItem rXObject = Helpers.GetRXObject<OdGiMaterialRenderItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_isASwigExplicitOdGiMaterialRenderItem(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_queryXSwigExplicitOdGiMaterialRenderItem(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiMaterialRenderItem createObject()
	{
		OdGiMaterialRenderItem rXObject = Helpers.GetRXObject<OdGiMaterialRenderItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry specularTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_specularTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createSpecularTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createSpecularTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeSpecularTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeSpecularTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveSpecularTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveSpecularTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry reflectionTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_reflectionTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createReflectionTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createReflectionTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeReflectionTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeReflectionTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveReflectionTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveReflectionTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry opacityTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_opacityTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createOpacityTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createOpacityTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeOpacityTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeOpacityTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveOpacityTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveOpacityTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry bumpTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_bumpTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createBumpTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createBumpTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeBumpTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeBumpTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveBumpTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveBumpTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry refractionTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_refractionTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createRefractionTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createRefractionTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeRefractionTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeRefractionTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveRefractionTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveRefractionTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry normalMapTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_normalMapTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createNormalMapTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createNormalMapTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeNormalMapTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeNormalMapTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveNormalMapTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveNormalMapTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry emissionTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_emissionTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createEmissionTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createEmissionTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeEmissionTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeEmissionTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveEmissionTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveEmissionTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry roughnessTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_roughnessTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createRoughnessTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createRoughnessTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeRoughnessTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeRoughnessTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveRoughnessTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveRoughnessTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry cutoutsTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_cutoutsTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createCutoutsTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createCutoutsTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeCutoutsTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeCutoutsTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveCutoutsTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveCutoutsTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdGiMaterialTextureEntry environmentTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_environmentTexture__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGiMaterialTextureEntry createEnvironmentTexture()
	{
		OdGiMaterialTextureEntry rXObject = Helpers.GetRXObject<OdGiMaterialTextureEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_createEnvironmentTexture(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void removeEnvironmentTexture()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_removeEnvironmentTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool haveEnvironmentTexture()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_haveEnvironmentTexture(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMaterialRenderItem()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMaterialRenderItem(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMaterialRenderItem) != GetType();
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
		if (SwigDerivedClassHasMethod("diffuseTexture", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddiffuseTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("diffuseTexture", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethoddiffuseTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createDiffuseTexture", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodcreateDiffuseTexture;
		}
		if (SwigDerivedClassHasMethod("removeDiffuseTexture", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodremoveDiffuseTexture;
		}
		if (SwigDerivedClassHasMethod("haveDiffuseTexture", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodhaveDiffuseTexture;
		}
		if (SwigDerivedClassHasMethod("checkTexturesEnabled", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodcheckTexturesEnabled__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("checkTexturesEnabled", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodcheckTexturesEnabled__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("checkTexturesEnabled", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodcheckTexturesEnabled__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("cachedData", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodcachedData;
		}
		if (SwigDerivedClassHasMethod("setCachedData", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetCachedData;
		}
		if (SwigDerivedClassHasMethod("materialId", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodmaterialId;
		}
		if (SwigDerivedClassHasMethod("setMaterialId", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetMaterialId__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMaterialId", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetMaterialId__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isMaterialIdValid", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodisMaterialIdValid;
		}
		if (SwigDerivedClassHasMethod("specularTexture", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodspecularTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("specularTexture", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodspecularTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createSpecularTexture", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodcreateSpecularTexture;
		}
		if (SwigDerivedClassHasMethod("removeSpecularTexture", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodremoveSpecularTexture;
		}
		if (SwigDerivedClassHasMethod("haveSpecularTexture", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodhaveSpecularTexture;
		}
		if (SwigDerivedClassHasMethod("reflectionTexture", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodreflectionTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("reflectionTexture", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodreflectionTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createReflectionTexture", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodcreateReflectionTexture;
		}
		if (SwigDerivedClassHasMethod("removeReflectionTexture", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodremoveReflectionTexture;
		}
		if (SwigDerivedClassHasMethod("haveReflectionTexture", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodhaveReflectionTexture;
		}
		if (SwigDerivedClassHasMethod("opacityTexture", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodopacityTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("opacityTexture", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodopacityTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createOpacityTexture", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodcreateOpacityTexture;
		}
		if (SwigDerivedClassHasMethod("removeOpacityTexture", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodremoveOpacityTexture;
		}
		if (SwigDerivedClassHasMethod("haveOpacityTexture", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodhaveOpacityTexture;
		}
		if (SwigDerivedClassHasMethod("bumpTexture", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodbumpTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("bumpTexture", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodbumpTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createBumpTexture", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodcreateBumpTexture;
		}
		if (SwigDerivedClassHasMethod("removeBumpTexture", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodremoveBumpTexture;
		}
		if (SwigDerivedClassHasMethod("haveBumpTexture", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodhaveBumpTexture;
		}
		if (SwigDerivedClassHasMethod("refractionTexture", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodrefractionTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("refractionTexture", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodrefractionTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createRefractionTexture", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodcreateRefractionTexture;
		}
		if (SwigDerivedClassHasMethod("removeRefractionTexture", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodremoveRefractionTexture;
		}
		if (SwigDerivedClassHasMethod("haveRefractionTexture", swigMethodTypes41))
		{
			swigDelegate41 = SwigDirectorMethodhaveRefractionTexture;
		}
		if (SwigDerivedClassHasMethod("normalMapTexture", swigMethodTypes42))
		{
			swigDelegate42 = SwigDirectorMethodnormalMapTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("normalMapTexture", swigMethodTypes43))
		{
			swigDelegate43 = SwigDirectorMethodnormalMapTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createNormalMapTexture", swigMethodTypes44))
		{
			swigDelegate44 = SwigDirectorMethodcreateNormalMapTexture;
		}
		if (SwigDerivedClassHasMethod("removeNormalMapTexture", swigMethodTypes45))
		{
			swigDelegate45 = SwigDirectorMethodremoveNormalMapTexture;
		}
		if (SwigDerivedClassHasMethod("haveNormalMapTexture", swigMethodTypes46))
		{
			swigDelegate46 = SwigDirectorMethodhaveNormalMapTexture;
		}
		if (SwigDerivedClassHasMethod("emissionTexture", swigMethodTypes47))
		{
			swigDelegate47 = SwigDirectorMethodemissionTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("emissionTexture", swigMethodTypes48))
		{
			swigDelegate48 = SwigDirectorMethodemissionTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createEmissionTexture", swigMethodTypes49))
		{
			swigDelegate49 = SwigDirectorMethodcreateEmissionTexture;
		}
		if (SwigDerivedClassHasMethod("removeEmissionTexture", swigMethodTypes50))
		{
			swigDelegate50 = SwigDirectorMethodremoveEmissionTexture;
		}
		if (SwigDerivedClassHasMethod("haveEmissionTexture", swigMethodTypes51))
		{
			swigDelegate51 = SwigDirectorMethodhaveEmissionTexture;
		}
		if (SwigDerivedClassHasMethod("roughnessTexture", swigMethodTypes52))
		{
			swigDelegate52 = SwigDirectorMethodroughnessTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("roughnessTexture", swigMethodTypes53))
		{
			swigDelegate53 = SwigDirectorMethodroughnessTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createRoughnessTexture", swigMethodTypes54))
		{
			swigDelegate54 = SwigDirectorMethodcreateRoughnessTexture;
		}
		if (SwigDerivedClassHasMethod("removeRoughnessTexture", swigMethodTypes55))
		{
			swigDelegate55 = SwigDirectorMethodremoveRoughnessTexture;
		}
		if (SwigDerivedClassHasMethod("haveRoughnessTexture", swigMethodTypes56))
		{
			swigDelegate56 = SwigDirectorMethodhaveRoughnessTexture;
		}
		if (SwigDerivedClassHasMethod("cutoutsTexture", swigMethodTypes57))
		{
			swigDelegate57 = SwigDirectorMethodcutoutsTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("cutoutsTexture", swigMethodTypes58))
		{
			swigDelegate58 = SwigDirectorMethodcutoutsTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createCutoutsTexture", swigMethodTypes59))
		{
			swigDelegate59 = SwigDirectorMethodcreateCutoutsTexture;
		}
		if (SwigDerivedClassHasMethod("removeCutoutsTexture", swigMethodTypes60))
		{
			swigDelegate60 = SwigDirectorMethodremoveCutoutsTexture;
		}
		if (SwigDerivedClassHasMethod("haveCutoutsTexture", swigMethodTypes61))
		{
			swigDelegate61 = SwigDirectorMethodhaveCutoutsTexture;
		}
		if (SwigDerivedClassHasMethod("environmentTexture", swigMethodTypes62))
		{
			swigDelegate62 = SwigDirectorMethodenvironmentTexture__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("environmentTexture", swigMethodTypes63))
		{
			swigDelegate63 = SwigDirectorMethodenvironmentTexture__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("createEnvironmentTexture", swigMethodTypes64))
		{
			swigDelegate64 = SwigDirectorMethodcreateEnvironmentTexture;
		}
		if (SwigDerivedClassHasMethod("removeEnvironmentTexture", swigMethodTypes65))
		{
			swigDelegate65 = SwigDirectorMethodremoveEnvironmentTexture;
		}
		if (SwigDerivedClassHasMethod("haveEnvironmentTexture", swigMethodTypes66))
		{
			swigDelegate66 = SwigDirectorMethodhaveEnvironmentTexture;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMaterialRenderItem_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40, swigDelegate41, swigDelegate42, swigDelegate43, swigDelegate44, swigDelegate45, swigDelegate46, swigDelegate47, swigDelegate48, swigDelegate49, swigDelegate50, swigDelegate51, swigDelegate52, swigDelegate53, swigDelegate54, swigDelegate55, swigDelegate56, swigDelegate57, swigDelegate58, swigDelegate59, swigDelegate60, swigDelegate61, swigDelegate62, swigDelegate63, swigDelegate64, swigDelegate65, swigDelegate66);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMaterialRenderItem));
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

	private IntPtr SwigDirectorMethoddiffuseTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(diffuseTexture()).Handle;
	}

	private IntPtr SwigDirectorMethoddiffuseTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(diffuseTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateDiffuseTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createDiffuseTexture()).Handle;
	}

	private void SwigDirectorMethodremoveDiffuseTexture()
	{
		try
		{
			removeDiffuseTexture();
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

	private bool SwigDirectorMethodhaveDiffuseTexture()
	{
		return haveDiffuseTexture();
	}

	private uint SwigDirectorMethodcheckTexturesEnabled__SWIG_0(string pOrder, bool bCheckAny)
	{
		return checkTexturesEnabled(pOrder, bCheckAny);
	}

	private uint SwigDirectorMethodcheckTexturesEnabled__SWIG_1(string pOrder)
	{
		return checkTexturesEnabled(pOrder);
	}

	private uint SwigDirectorMethodcheckTexturesEnabled__SWIG_2()
	{
		return checkTexturesEnabled();
	}

	private IntPtr SwigDirectorMethodcachedData()
	{
		return OdRxObject.getCPtr(cachedData()).Handle;
	}

	private void SwigDirectorMethodsetCachedData(IntPtr data)
	{
		try
		{
			setCachedData(Helpers.GetRXObject<OdRxObject>(data, bOwn: true, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodmaterialId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(materialId()).Handle;
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

	private void SwigDirectorMethodsetMaterialId__SWIG_0(IntPtr matId)
	{
		try
		{
			setMaterialId((matId == IntPtr.Zero) ? null : new OdDbStub(matId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMaterialId__SWIG_1()
	{
		try
		{
			setMaterialId();
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

	private bool SwigDirectorMethodisMaterialIdValid(IntPtr matId)
	{
		return isMaterialIdValid((matId == IntPtr.Zero) ? null : new OdDbStub(matId, cMemoryOwn: false));
	}

	private IntPtr SwigDirectorMethodspecularTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(specularTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodspecularTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(specularTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateSpecularTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createSpecularTexture()).Handle;
	}

	private void SwigDirectorMethodremoveSpecularTexture()
	{
		try
		{
			removeSpecularTexture();
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

	private bool SwigDirectorMethodhaveSpecularTexture()
	{
		return haveSpecularTexture();
	}

	private IntPtr SwigDirectorMethodreflectionTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(reflectionTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodreflectionTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(reflectionTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateReflectionTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createReflectionTexture()).Handle;
	}

	private void SwigDirectorMethodremoveReflectionTexture()
	{
		try
		{
			removeReflectionTexture();
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

	private bool SwigDirectorMethodhaveReflectionTexture()
	{
		return haveReflectionTexture();
	}

	private IntPtr SwigDirectorMethodopacityTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(opacityTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodopacityTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(opacityTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateOpacityTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createOpacityTexture()).Handle;
	}

	private void SwigDirectorMethodremoveOpacityTexture()
	{
		try
		{
			removeOpacityTexture();
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

	private bool SwigDirectorMethodhaveOpacityTexture()
	{
		return haveOpacityTexture();
	}

	private IntPtr SwigDirectorMethodbumpTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(bumpTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodbumpTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(bumpTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateBumpTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createBumpTexture()).Handle;
	}

	private void SwigDirectorMethodremoveBumpTexture()
	{
		try
		{
			removeBumpTexture();
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

	private bool SwigDirectorMethodhaveBumpTexture()
	{
		return haveBumpTexture();
	}

	private IntPtr SwigDirectorMethodrefractionTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(refractionTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodrefractionTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(refractionTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateRefractionTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createRefractionTexture()).Handle;
	}

	private void SwigDirectorMethodremoveRefractionTexture()
	{
		try
		{
			removeRefractionTexture();
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

	private bool SwigDirectorMethodhaveRefractionTexture()
	{
		return haveRefractionTexture();
	}

	private IntPtr SwigDirectorMethodnormalMapTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(normalMapTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodnormalMapTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(normalMapTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateNormalMapTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createNormalMapTexture()).Handle;
	}

	private void SwigDirectorMethodremoveNormalMapTexture()
	{
		try
		{
			removeNormalMapTexture();
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

	private bool SwigDirectorMethodhaveNormalMapTexture()
	{
		return haveNormalMapTexture();
	}

	private IntPtr SwigDirectorMethodemissionTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(emissionTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodemissionTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(emissionTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateEmissionTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createEmissionTexture()).Handle;
	}

	private void SwigDirectorMethodremoveEmissionTexture()
	{
		try
		{
			removeEmissionTexture();
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

	private bool SwigDirectorMethodhaveEmissionTexture()
	{
		return haveEmissionTexture();
	}

	private IntPtr SwigDirectorMethodroughnessTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(roughnessTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodroughnessTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(roughnessTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateRoughnessTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createRoughnessTexture()).Handle;
	}

	private void SwigDirectorMethodremoveRoughnessTexture()
	{
		try
		{
			removeRoughnessTexture();
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

	private bool SwigDirectorMethodhaveRoughnessTexture()
	{
		return haveRoughnessTexture();
	}

	private IntPtr SwigDirectorMethodcutoutsTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(cutoutsTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcutoutsTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(cutoutsTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateCutoutsTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createCutoutsTexture()).Handle;
	}

	private void SwigDirectorMethodremoveCutoutsTexture()
	{
		try
		{
			removeCutoutsTexture();
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

	private bool SwigDirectorMethodhaveCutoutsTexture()
	{
		return haveCutoutsTexture();
	}

	private IntPtr SwigDirectorMethodenvironmentTexture__SWIG_0()
	{
		return OdGiMaterialTextureEntry.getCPtr(environmentTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodenvironmentTexture__SWIG_1()
	{
		return OdGiMaterialTextureEntry.getCPtr(environmentTexture()).Handle;
	}

	private IntPtr SwigDirectorMethodcreateEnvironmentTexture()
	{
		return OdGiMaterialTextureEntry.getCPtr(createEnvironmentTexture()).Handle;
	}

	private void SwigDirectorMethodremoveEnvironmentTexture()
	{
		try
		{
			removeEnvironmentTexture();
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

	private bool SwigDirectorMethodhaveEnvironmentTexture()
	{
		return haveEnvironmentTexture();
	}
}
