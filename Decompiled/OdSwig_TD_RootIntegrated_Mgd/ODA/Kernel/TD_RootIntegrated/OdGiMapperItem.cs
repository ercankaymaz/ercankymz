using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiMapperItem : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiMapperItem_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiMapperItem_1();

	public delegate void SwigDelegateOdGiMapperItem_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiMapperItem_3(IntPtr traitsData);

	public delegate void SwigDelegateOdGiMapperItem_4(IntPtr traitsData, IntPtr tm);

	public delegate void SwigDelegateOdGiMapperItem_5(IntPtr pMapper, IntPtr traitsData);

	public delegate void SwigDelegateOdGiMapperItem_6(IntPtr pMapper, IntPtr traitsData, IntPtr tm);

	public delegate IntPtr SwigDelegateOdGiMapperItem_7();

	public delegate IntPtr SwigDelegateOdGiMapperItem_8();

	public delegate void SwigDelegateOdGiMapperItem_9(IntPtr traitsData, IntPtr pMaterial);

	public delegate void SwigDelegateOdGiMapperItem_10(IntPtr traitsData);

	public delegate void SwigDelegateOdGiMapperItem_11(IntPtr traitsData, IntPtr tm, IntPtr pMaterial);

	public delegate void SwigDelegateOdGiMapperItem_12(IntPtr traitsData, IntPtr tm);

	public delegate void SwigDelegateOdGiMapperItem_13(IntPtr pMapper, IntPtr traitsData, IntPtr pMaterial);

	public delegate void SwigDelegateOdGiMapperItem_14(IntPtr pMapper, IntPtr traitsData);

	public delegate void SwigDelegateOdGiMapperItem_15(IntPtr pMapper, IntPtr traitsData, IntPtr tm, IntPtr pMaterial);

	public delegate void SwigDelegateOdGiMapperItem_16(IntPtr pMapper, IntPtr traitsData, IntPtr tm);

	public delegate void SwigDelegateOdGiMapperItem_17(IntPtr mtm, bool recomputeTransforms);

	public delegate void SwigDelegateOdGiMapperItem_18(IntPtr mtm);

	public delegate void SwigDelegateOdGiMapperItem_19(IntPtr otm, bool recomputeTransforms);

	public delegate void SwigDelegateOdGiMapperItem_20(IntPtr otm);

	public delegate void SwigDelegateOdGiMapperItem_21(int nCount, IntPtr pPoints, bool recomputeTransforms);

	public delegate void SwigDelegateOdGiMapperItem_22(int nCount, IntPtr pPoints);

	public delegate void SwigDelegateOdGiMapperItem_23(IntPtr exts, bool recomputeTransforms);

	public delegate void SwigDelegateOdGiMapperItem_24(IntPtr exts);

	public delegate void SwigDelegateOdGiMapperItem_25(IntPtr dtm, bool recomputeTransforms);

	public delegate void SwigDelegateOdGiMapperItem_26(IntPtr dtm);

	public delegate bool SwigDelegateOdGiMapperItem_27(IntPtr pMaterial);

	public delegate bool SwigDelegateOdGiMapperItem_28(IntPtr pMaterial, IntPtr tm);

	public delegate bool SwigDelegateOdGiMapperItem_29(IntPtr pMapper, IntPtr pMaterial);

	public delegate bool SwigDelegateOdGiMapperItem_30(IntPtr pMapper, IntPtr pMaterial, IntPtr tm);

	public delegate bool SwigDelegateOdGiMapperItem_31(IntPtr tm);

	public delegate bool SwigDelegateOdGiMapperItem_32();

	public delegate bool SwigDelegateOdGiMapperItem_33();

	public delegate bool SwigDelegateOdGiMapperItem_34();

	public delegate bool SwigDelegateOdGiMapperItem_35();

	public delegate bool SwigDelegateOdGiMapperItem_36();

	public delegate void SwigDelegateOdGiMapperItem_37(int nCount, IntPtr pPoints);

	public delegate void SwigDelegateOdGiMapperItem_38(IntPtr exts);

	public delegate void SwigDelegateOdGiMapperItem_39(IntPtr tm, bool bVertexDependantOnly);

	public delegate void SwigDelegateOdGiMapperItem_40(IntPtr tm);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiMapperItem_0 swigDelegate0;

	private SwigDelegateOdGiMapperItem_1 swigDelegate1;

	private SwigDelegateOdGiMapperItem_2 swigDelegate2;

	private SwigDelegateOdGiMapperItem_3 swigDelegate3;

	private SwigDelegateOdGiMapperItem_4 swigDelegate4;

	private SwigDelegateOdGiMapperItem_5 swigDelegate5;

	private SwigDelegateOdGiMapperItem_6 swigDelegate6;

	private SwigDelegateOdGiMapperItem_7 swigDelegate7;

	private SwigDelegateOdGiMapperItem_8 swigDelegate8;

	private SwigDelegateOdGiMapperItem_9 swigDelegate9;

	private SwigDelegateOdGiMapperItem_10 swigDelegate10;

	private SwigDelegateOdGiMapperItem_11 swigDelegate11;

	private SwigDelegateOdGiMapperItem_12 swigDelegate12;

	private SwigDelegateOdGiMapperItem_13 swigDelegate13;

	private SwigDelegateOdGiMapperItem_14 swigDelegate14;

	private SwigDelegateOdGiMapperItem_15 swigDelegate15;

	private SwigDelegateOdGiMapperItem_16 swigDelegate16;

	private SwigDelegateOdGiMapperItem_17 swigDelegate17;

	private SwigDelegateOdGiMapperItem_18 swigDelegate18;

	private SwigDelegateOdGiMapperItem_19 swigDelegate19;

	private SwigDelegateOdGiMapperItem_20 swigDelegate20;

	private SwigDelegateOdGiMapperItem_21 swigDelegate21;

	private SwigDelegateOdGiMapperItem_22 swigDelegate22;

	private SwigDelegateOdGiMapperItem_23 swigDelegate23;

	private SwigDelegateOdGiMapperItem_24 swigDelegate24;

	private SwigDelegateOdGiMapperItem_25 swigDelegate25;

	private SwigDelegateOdGiMapperItem_26 swigDelegate26;

	private SwigDelegateOdGiMapperItem_27 swigDelegate27;

	private SwigDelegateOdGiMapperItem_28 swigDelegate28;

	private SwigDelegateOdGiMapperItem_29 swigDelegate29;

	private SwigDelegateOdGiMapperItem_30 swigDelegate30;

	private SwigDelegateOdGiMapperItem_31 swigDelegate31;

	private SwigDelegateOdGiMapperItem_32 swigDelegate32;

	private SwigDelegateOdGiMapperItem_33 swigDelegate33;

	private SwigDelegateOdGiMapperItem_34 swigDelegate34;

	private SwigDelegateOdGiMapperItem_35 swigDelegate35;

	private SwigDelegateOdGiMapperItem_36 swigDelegate36;

	private SwigDelegateOdGiMapperItem_37 swigDelegate37;

	private SwigDelegateOdGiMapperItem_38 swigDelegate38;

	private SwigDelegateOdGiMapperItem_39 swigDelegate39;

	private SwigDelegateOdGiMapperItem_40 swigDelegate40;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdGiMaterialTraitsData) };

	private static Type[] swigMethodTypes4 = new Type[2]
	{
		typeof(OdGiMaterialTraitsData),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes5 = new Type[2]
	{
		typeof(OdGiMapper),
		typeof(OdGiMaterialTraitsData)
	};

	private static Type[] swigMethodTypes6 = new Type[3]
	{
		typeof(OdGiMapper),
		typeof(OdGiMaterialTraitsData),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[2]
	{
		typeof(OdGiMaterialTraitsData),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdGiMaterialTraitsData) };

	private static Type[] swigMethodTypes11 = new Type[3]
	{
		typeof(OdGiMaterialTraitsData),
		typeof(OdGeMatrix3d),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes12 = new Type[2]
	{
		typeof(OdGiMaterialTraitsData),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes13 = new Type[3]
	{
		typeof(OdGiMapper),
		typeof(OdGiMaterialTraitsData),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes14 = new Type[2]
	{
		typeof(OdGiMapper),
		typeof(OdGiMaterialTraitsData)
	};

	private static Type[] swigMethodTypes15 = new Type[4]
	{
		typeof(OdGiMapper),
		typeof(OdGiMaterialTraitsData),
		typeof(OdGeMatrix3d),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes16 = new Type[3]
	{
		typeof(OdGiMapper),
		typeof(OdGiMaterialTraitsData),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes17 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes18 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes19 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes20 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes21 = new Type[3]
	{
		typeof(int),
		typeof(OdGePoint3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes22 = new Type[2]
	{
		typeof(int),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes23 = new Type[2]
	{
		typeof(OdGeExtents3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes25 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(OdDbStub),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes29 = new Type[2]
	{
		typeof(OdGiMapper),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes30 = new Type[3]
	{
		typeof(OdGiMapper),
		typeof(OdDbStub),
		typeof(OdGeMatrix3d)
	};

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(OdGeMatrix3d) };

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[0];

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[0];

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[2]
	{
		typeof(int),
		typeof(OdGePoint3d)
	};

	private static Type[] swigMethodTypes38 = new Type[1] { typeof(OdGeExtents3d) };

	private static Type[] swigMethodTypes39 = new Type[2]
	{
		typeof(OdGeMatrix3d),
		typeof(bool)
	};

	private static Type[] swigMethodTypes40 = new Type[1] { typeof(OdGeMatrix3d) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiMapperItem(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiMapperItem obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiMapperItem(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiMapperItem cast(OdRxObject pObj)
	{
		OdGiMapperItem rXObject = Helpers.GetRXObject<OdGiMapperItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isASwigExplicitOdGiMapperItem(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_queryXSwigExplicitOdGiMapperItem(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiMapperItem createObject()
	{
		OdGiMapperItem rXObject = Helpers.GetRXObject<OdGiMapperItem>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setDiffuseMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setDiffuseMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDiffuseMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setDiffuseMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDiffuseMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setDiffuseMapper__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDiffuseMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setDiffuseMapper__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiMapperItemEntry diffuseMapper()
	{
		OdGiMapperItemEntry rXObject = Helpers.GetRXObject<OdGiMapperItemEntry>(TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_diffuseMapper__SWIG_0(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setMapper(OdGiMaterialTraitsData traitsData, OdDbStub pMaterial)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setMapper__SWIG_0(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setMapper__SWIG_1(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm, OdDbStub pMaterial)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setMapper__SWIG_2(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm), OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setMapper__SWIG_3(swigCPtr, OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdDbStub pMaterial)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setMapper__SWIG_4(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setMapper__SWIG_5(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm, OdDbStub pMaterial)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setMapper__SWIG_6(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm), OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMapper(OdGiMapper pMapper, OdGiMaterialTraitsData traitsData, OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setMapper__SWIG_7(swigCPtr, OdGiMapper.getCPtr(pMapper), OdGiMaterialTraitsData.getCPtr(traitsData), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setModelTransform(OdGeMatrix3d mtm, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setModelTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(mtm), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setModelTransform(OdGeMatrix3d mtm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setModelTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(mtm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setObjectTransform(OdGeMatrix3d otm, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setObjectTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(otm), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setObjectTransform(OdGeMatrix3d otm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setObjectTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(otm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setObjectTransform(int nCount, OdGePoint3d pPoints, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setObjectTransform__SWIG_2(swigCPtr, nCount, OdGePoint3d.getCPtr(pPoints), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setObjectTransform(int nCount, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setObjectTransform__SWIG_3(swigCPtr, nCount, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setObjectTransform(OdGeExtents3d exts, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setObjectTransform__SWIG_4(swigCPtr, OdGeExtents3d.getCPtr(exts), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setObjectTransform(OdGeExtents3d exts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setObjectTransform__SWIG_5(swigCPtr, OdGeExtents3d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviceTransform(OdGeMatrix3d dtm, bool recomputeTransforms)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setDeviceTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(dtm), recomputeTransforms);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDeviceTransform(OdGeMatrix3d dtm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setDeviceTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(dtm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool isLastProcValid(OdDbStub pMaterial)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isLastProcValid__SWIG_0(swigCPtr, OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLastProcValid(OdDbStub pMaterial, OdGeMatrix3d tm)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isLastProcValid__SWIG_1(swigCPtr, OdDbStub.getCPtr(pMaterial), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLastProcValid(OdGiMapper pMapper, OdDbStub pMaterial)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isLastProcValid__SWIG_2(swigCPtr, OdGiMapper.getCPtr(pMapper), OdDbStub.getCPtr(pMaterial));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLastProcValid(OdGiMapper pMapper, OdDbStub pMaterial, OdGeMatrix3d tm)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isLastProcValid__SWIG_3(swigCPtr, OdGiMapper.getCPtr(pMapper), OdDbStub.getCPtr(pMaterial), OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isLastProcValid(OdGeMatrix3d tm)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isLastProcValid__SWIG_4(swigCPtr, OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isEntityMapper()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isEntityMapper(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isObjectMatrixNeed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isObjectMatrixNeed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isModelMatrixNeed()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isModelMatrixNeed(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isDependsFromObjectMatrix()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isDependsFromObjectMatrix(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool isVertexTransformRequired()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_isVertexTransformRequired(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setVertexTransform(int nCount, OdGePoint3d pPoints)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setVertexTransform__SWIG_0(swigCPtr, nCount, OdGePoint3d.getCPtr(pPoints));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setVertexTransform(OdGeExtents3d exts)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setVertexTransform__SWIG_1(swigCPtr, OdGeExtents3d.getCPtr(exts));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setInputTransform(OdGeMatrix3d tm, bool bVertexDependantOnly)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setInputTransform__SWIG_0(swigCPtr, OdGeMatrix3d.getCPtr(tm), bVertexDependantOnly);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setInputTransform(OdGeMatrix3d tm)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_setInputTransform__SWIG_1(swigCPtr, OdGeMatrix3d.getCPtr(tm));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiMapperItem()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiMapperItem(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiMapperItem) != GetType();
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
		if (SwigDerivedClassHasMethod("setDiffuseMapper", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetDiffuseMapper__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDiffuseMapper", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodsetDiffuseMapper__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setDiffuseMapper", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetDiffuseMapper__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setDiffuseMapper", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetDiffuseMapper__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("diffuseMapper", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethoddiffuseMapper__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("diffuseMapper", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethoddiffuseMapper__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetMapper__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetMapper__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetMapper__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetMapper__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetMapper__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetMapper__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetMapper__SWIG_6;
		}
		if (SwigDerivedClassHasMethod("setMapper", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetMapper__SWIG_7;
		}
		if (SwigDerivedClassHasMethod("setModelTransform", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetModelTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setModelTransform", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodsetModelTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetObjectTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodsetObjectTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetObjectTransform__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetObjectTransform__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetObjectTransform__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("setObjectTransform", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodsetObjectTransform__SWIG_5;
		}
		if (SwigDerivedClassHasMethod("setDeviceTransform", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetDeviceTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setDeviceTransform", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetDeviceTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isLastProcValid", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodisLastProcValid__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("isLastProcValid", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodisLastProcValid__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("isLastProcValid", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodisLastProcValid__SWIG_2;
		}
		if (SwigDerivedClassHasMethod("isLastProcValid", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodisLastProcValid__SWIG_3;
		}
		if (SwigDerivedClassHasMethod("isLastProcValid", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodisLastProcValid__SWIG_4;
		}
		if (SwigDerivedClassHasMethod("isEntityMapper", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodisEntityMapper;
		}
		if (SwigDerivedClassHasMethod("isObjectMatrixNeed", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodisObjectMatrixNeed;
		}
		if (SwigDerivedClassHasMethod("isModelMatrixNeed", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodisModelMatrixNeed;
		}
		if (SwigDerivedClassHasMethod("isDependsFromObjectMatrix", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodisDependsFromObjectMatrix;
		}
		if (SwigDerivedClassHasMethod("isVertexTransformRequired", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodisVertexTransformRequired;
		}
		if (SwigDerivedClassHasMethod("setVertexTransform", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodsetVertexTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setVertexTransform", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodsetVertexTransform__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setInputTransform", swigMethodTypes39))
		{
			swigDelegate39 = SwigDirectorMethodsetInputTransform__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setInputTransform", swigMethodTypes40))
		{
			swigDelegate40 = SwigDirectorMethodsetInputTransform__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiMapperItem_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38, swigDelegate39, swigDelegate40);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiMapperItem));
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

	private void SwigDirectorMethodsetDiffuseMapper__SWIG_0(IntPtr traitsData)
	{
		try
		{
			setDiffuseMapper(new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDiffuseMapper__SWIG_1(IntPtr traitsData, IntPtr tm)
	{
		try
		{
			setDiffuseMapper(new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDiffuseMapper__SWIG_2(IntPtr pMapper, IntPtr traitsData)
	{
		try
		{
			setDiffuseMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false), new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDiffuseMapper__SWIG_3(IntPtr pMapper, IntPtr traitsData, IntPtr tm)
	{
		try
		{
			setDiffuseMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false), new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethoddiffuseMapper__SWIG_0()
	{
		return OdGiMapperItemEntry.getCPtr(diffuseMapper()).Handle;
	}

	private IntPtr SwigDirectorMethoddiffuseMapper__SWIG_1()
	{
		return OdGiMapperItemEntry.getCPtr(diffuseMapper()).Handle;
	}

	private void SwigDirectorMethodsetMapper__SWIG_0(IntPtr traitsData, IntPtr pMaterial)
	{
		try
		{
			setMapper(new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false), (pMaterial == IntPtr.Zero) ? null : new OdDbStub(pMaterial, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_1(IntPtr traitsData)
	{
		try
		{
			setMapper(new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_2(IntPtr traitsData, IntPtr tm, IntPtr pMaterial)
	{
		try
		{
			setMapper(new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false), (pMaterial == IntPtr.Zero) ? null : new OdDbStub(pMaterial, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_3(IntPtr traitsData, IntPtr tm)
	{
		try
		{
			setMapper(new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_4(IntPtr pMapper, IntPtr traitsData, IntPtr pMaterial)
	{
		try
		{
			setMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false), new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false), (pMaterial == IntPtr.Zero) ? null : new OdDbStub(pMaterial, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_5(IntPtr pMapper, IntPtr traitsData)
	{
		try
		{
			setMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false), new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_6(IntPtr pMapper, IntPtr traitsData, IntPtr tm, IntPtr pMaterial)
	{
		try
		{
			setMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false), new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false), (pMaterial == IntPtr.Zero) ? null : new OdDbStub(pMaterial, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetMapper__SWIG_7(IntPtr pMapper, IntPtr traitsData, IntPtr tm)
	{
		try
		{
			setMapper((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false), new OdGiMaterialTraitsData(traitsData, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetModelTransform__SWIG_0(IntPtr mtm, bool recomputeTransforms)
	{
		try
		{
			setModelTransform(new OdGeMatrix3d(mtm, cMemoryOwn: false), recomputeTransforms);
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

	private void SwigDirectorMethodsetModelTransform__SWIG_1(IntPtr mtm)
	{
		try
		{
			setModelTransform(new OdGeMatrix3d(mtm, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_0(IntPtr otm, bool recomputeTransforms)
	{
		try
		{
			setObjectTransform(new OdGeMatrix3d(otm, cMemoryOwn: false), recomputeTransforms);
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_1(IntPtr otm)
	{
		try
		{
			setObjectTransform(new OdGeMatrix3d(otm, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_2(int nCount, IntPtr pPoints, bool recomputeTransforms)
	{
		try
		{
			setObjectTransform(nCount, (pPoints == IntPtr.Zero) ? null : new OdGePoint3d(pPoints, cMemoryOwn: false), recomputeTransforms);
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_3(int nCount, IntPtr pPoints)
	{
		try
		{
			setObjectTransform(nCount, (pPoints == IntPtr.Zero) ? null : new OdGePoint3d(pPoints, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_4(IntPtr exts, bool recomputeTransforms)
	{
		try
		{
			setObjectTransform(new OdGeExtents3d(exts, cMemoryOwn: false), recomputeTransforms);
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

	private void SwigDirectorMethodsetObjectTransform__SWIG_5(IntPtr exts)
	{
		try
		{
			setObjectTransform(new OdGeExtents3d(exts, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetDeviceTransform__SWIG_0(IntPtr dtm, bool recomputeTransforms)
	{
		try
		{
			setDeviceTransform(new OdGeMatrix3d(dtm, cMemoryOwn: false), recomputeTransforms);
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

	private void SwigDirectorMethodsetDeviceTransform__SWIG_1(IntPtr dtm)
	{
		try
		{
			setDeviceTransform(new OdGeMatrix3d(dtm, cMemoryOwn: false));
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

	private bool SwigDirectorMethodisLastProcValid__SWIG_0(IntPtr pMaterial)
	{
		return isLastProcValid((pMaterial == IntPtr.Zero) ? null : new OdDbStub(pMaterial, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisLastProcValid__SWIG_1(IntPtr pMaterial, IntPtr tm)
	{
		return isLastProcValid((pMaterial == IntPtr.Zero) ? null : new OdDbStub(pMaterial, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisLastProcValid__SWIG_2(IntPtr pMapper, IntPtr pMaterial)
	{
		return isLastProcValid((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false), (pMaterial == IntPtr.Zero) ? null : new OdDbStub(pMaterial, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisLastProcValid__SWIG_3(IntPtr pMapper, IntPtr pMaterial, IntPtr tm)
	{
		return isLastProcValid((pMapper == IntPtr.Zero) ? null : new OdGiMapper(pMapper, cMemoryOwn: false), (pMaterial == IntPtr.Zero) ? null : new OdDbStub(pMaterial, cMemoryOwn: false), new OdGeMatrix3d(tm, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisLastProcValid__SWIG_4(IntPtr tm)
	{
		return isLastProcValid(new OdGeMatrix3d(tm, cMemoryOwn: false));
	}

	private bool SwigDirectorMethodisEntityMapper()
	{
		return isEntityMapper();
	}

	private bool SwigDirectorMethodisObjectMatrixNeed()
	{
		return isObjectMatrixNeed();
	}

	private bool SwigDirectorMethodisModelMatrixNeed()
	{
		return isModelMatrixNeed();
	}

	private bool SwigDirectorMethodisDependsFromObjectMatrix()
	{
		return isDependsFromObjectMatrix();
	}

	private bool SwigDirectorMethodisVertexTransformRequired()
	{
		return isVertexTransformRequired();
	}

	private void SwigDirectorMethodsetVertexTransform__SWIG_0(int nCount, IntPtr pPoints)
	{
		try
		{
			setVertexTransform(nCount, (pPoints == IntPtr.Zero) ? null : new OdGePoint3d(pPoints, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetVertexTransform__SWIG_1(IntPtr exts)
	{
		try
		{
			setVertexTransform(new OdGeExtents3d(exts, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetInputTransform__SWIG_0(IntPtr tm, bool bVertexDependantOnly)
	{
		try
		{
			setInputTransform(new OdGeMatrix3d(tm, cMemoryOwn: false), bVertexDependantOnly);
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

	private void SwigDirectorMethodsetInputTransform__SWIG_1(IntPtr tm)
	{
		try
		{
			setInputTransform(new OdGeMatrix3d(tm, cMemoryOwn: false));
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
