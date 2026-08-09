using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcCategory1LineStyle : OdPrcReferencedBase
{
	public delegate IntPtr SwigDelegateOdPrcCategory1LineStyle_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPrcCategory1LineStyle_1();

	public delegate void SwigDelegateOdPrcCategory1LineStyle_2(IntPtr pSource);

	public delegate int SwigDelegateOdPrcCategory1LineStyle_3();

	public delegate bool SwigDelegateOdPrcCategory1LineStyle_4();

	public delegate IntPtr SwigDelegateOdPrcCategory1LineStyle_5();

	public delegate void SwigDelegateOdPrcCategory1LineStyle_6(IntPtr pGsNode);

	public delegate IntPtr SwigDelegateOdPrcCategory1LineStyle_7();

	public delegate uint SwigDelegateOdPrcCategory1LineStyle_8(IntPtr traits);

	public delegate bool SwigDelegateOdPrcCategory1LineStyle_9(IntPtr wd);

	public delegate void SwigDelegateOdPrcCategory1LineStyle_10(IntPtr vd);

	public delegate uint SwigDelegateOdPrcCategory1LineStyle_11(IntPtr vd);

	public delegate uint SwigDelegateOdPrcCategory1LineStyle_12();

	public delegate void SwigDelegateOdPrcCategory1LineStyle_13(IntPtr pStream);

	public delegate void SwigDelegateOdPrcCategory1LineStyle_14(IntPtr pStream);

	public delegate uint SwigDelegateOdPrcCategory1LineStyle_15();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPrcCategory1LineStyle_0 swigDelegate0;

	private SwigDelegateOdPrcCategory1LineStyle_1 swigDelegate1;

	private SwigDelegateOdPrcCategory1LineStyle_2 swigDelegate2;

	private SwigDelegateOdPrcCategory1LineStyle_3 swigDelegate3;

	private SwigDelegateOdPrcCategory1LineStyle_4 swigDelegate4;

	private SwigDelegateOdPrcCategory1LineStyle_5 swigDelegate5;

	private SwigDelegateOdPrcCategory1LineStyle_6 swigDelegate6;

	private SwigDelegateOdPrcCategory1LineStyle_7 swigDelegate7;

	private SwigDelegateOdPrcCategory1LineStyle_8 swigDelegate8;

	private SwigDelegateOdPrcCategory1LineStyle_9 swigDelegate9;

	private SwigDelegateOdPrcCategory1LineStyle_10 swigDelegate10;

	private SwigDelegateOdPrcCategory1LineStyle_11 swigDelegate11;

	private SwigDelegateOdPrcCategory1LineStyle_12 swigDelegate12;

	private SwigDelegateOdPrcCategory1LineStyle_13 swigDelegate13;

	private SwigDelegateOdPrcCategory1LineStyle_14 swigDelegate14;

	private SwigDelegateOdPrcCategory1LineStyle_15 swigDelegate15;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[1] { typeof(OdGsCache) };

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[1] { typeof(OdGiDrawableTraits) };

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGiWorldDraw) };

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdGiViewportDraw) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGiViewportDraw) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdPrcCompressedFiler) };

	private static Type[] swigMethodTypes15 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPrcCategory1LineStyle(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcCategory1LineStyle obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcCategory1LineStyle(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPrcCategory1LineStyle()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcCategory1LineStyle(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPrcCategory1LineStyle) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public override uint prcType()
	{
		uint result = (SwigDerivedClassHasMethod("prcType", swigMethodTypes15) ? OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_prcTypeSwigExplicitOdPrcCategory1LineStyle(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_prcType(swigCPtr));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdPrcCategory1LineStyle cast(OdRxObject pObj)
	{
		OdPrcCategory1LineStyle rXObject = Helpers.GetRXObject<OdPrcCategory1LineStyle>(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_desc(), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_isASwigExplicitOdPrcCategory1LineStyle(swigCPtr) : OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_queryXSwigExplicitOdPrcCategory1LineStyle(swigCPtr, OdRxClass.getCPtr(protocolClass)) : OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPrcCategory1LineStyle createObject()
	{
		OdPrcCategory1LineStyle rXObject = Helpers.GetRXObject<OdPrcCategory1LineStyle>(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override void prcOut(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes13))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_prcOutSwigExplicitOdPrcCategory1LineStyle(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_prcOut(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void prcIn(OdPrcCompressedFiler pStream)
	{
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes14))
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_prcInSwigExplicitOdPrcCategory1LineStyle(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		else
		{
			OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_prcIn(swigCPtr, OdPrcCompressedFiler.getCPtr(pStream));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLineWidth(double line_width)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setLineWidth(swigCPtr, line_width);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double lineWidth()
	{
		double result = OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_lineWidth(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColor(OdPrcColorIndex colorIndex)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setColor__SWIG_0(swigCPtr, OdPrcColorIndex.getCPtr(colorIndex));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColor()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setColor__SWIG_1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColor(double r, double g, double b, bool preventDuplication)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setColor__SWIG_2(swigCPtr, r, g, b, preventDuplication);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColor(double r, double g, double b)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setColor__SWIG_3(swigCPtr, r, g, b);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColor(OdPrcRgbColor color, bool preventDuplication)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setColor__SWIG_4(swigCPtr, OdPrcRgbColor.getCPtr(color), preventDuplication);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setColor(OdPrcRgbColor color)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setColor__SWIG_5(swigCPtr, OdPrcRgbColor.getCPtr(color));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcColorIndex getColor()
	{
		OdPrcColorIndex result = new OdPrcColorIndex(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getColor(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdCmEntityColor getTrueColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getTrueColor(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPictureIdx(uint idx_picture)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setPictureIdx(swigCPtr, idx_picture);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint getPictureIdx()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getPictureIdx(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setMaterialID(OdPrcObjectId materialID)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setMaterialID(swigCPtr, OdPrcObjectId.getCPtr(materialID));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId getMaterialID()
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getMaterialID(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearMaterialID()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_clearMaterialID(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLinePatternID(OdPrcObjectId patternID)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setLinePatternID(swigCPtr, OdPrcObjectId.getCPtr(patternID));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcObjectId getLinePatternID()
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getLinePatternID(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clearLinePatternID()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_clearLinePatternID(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransparency(sbyte transparency)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setTransparency(swigCPtr, transparency);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearTransparency()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_clearTransparency(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAdditionalData1(sbyte additional_data_1)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setAdditionalData1(swigCPtr, additional_data_1);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearAdditionalData1()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_clearAdditionalData1(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAdditionalData2(sbyte additional_data_2)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setAdditionalData2(swigCPtr, additional_data_2);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearAdditionalData2()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_clearAdditionalData2(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAdditionalData3(sbyte additional_data_3)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_setAdditionalData3(swigCPtr, additional_data_3);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearAdditionalData3()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_clearAdditionalData3(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getTransparency(out sbyte transparency)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getTransparency(swigCPtr, out transparency);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getAdditionalData1(out sbyte data)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getAdditionalData1(swigCPtr, out data);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getAdditionalData2(out sbyte data)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getAdditionalData2(swigCPtr, out data);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getAdditionalData3(out sbyte data)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getAdditionalData3(swigCPtr, out data);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static OdPrcObjectId createByColor(double r, double g, double b, ref OdPrcFileStructure postToFileStructure, bool preventColorDuplication)
	{
		IntPtr jarg = ((postToFileStructure == null) ? IntPtr.Zero : OdPrcFileStructure.getCPtr(postToFileStructure).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_createByColor__SWIG_0(r, g, b, ref jarg, preventColorDuplication), cMemoryOwn: true);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				postToFileStructure = null;
			}
			if (jarg != intPtr)
			{
				postToFileStructure = Helpers.GetRXObject<OdPrcFileStructure>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdPrcObjectId createByColor(double r, double g, double b, ref OdPrcFileStructure postToFileStructure)
	{
		IntPtr jarg = ((postToFileStructure == null) ? IntPtr.Zero : OdPrcFileStructure.getCPtr(postToFileStructure).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_createByColor__SWIG_1(r, g, b, ref jarg), cMemoryOwn: true);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				postToFileStructure = null;
			}
			if (jarg != intPtr)
			{
				postToFileStructure = Helpers.GetRXObject<OdPrcFileStructure>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdPrcObjectId createByMaterial(OdPrcObjectId materialId, ref OdPrcFileStructure postToFileStructure)
	{
		IntPtr jarg = ((postToFileStructure == null) ? IntPtr.Zero : OdPrcFileStructure.getCPtr(postToFileStructure).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_createByMaterial__SWIG_0(OdPrcObjectId.getCPtr(materialId), ref jarg), cMemoryOwn: true);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				postToFileStructure = null;
			}
			if (jarg != intPtr)
			{
				postToFileStructure = Helpers.GetRXObject<OdPrcFileStructure>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public static OdPrcObjectId createByMaterial(OdGiMaterialTraits pTraits, OdCmEntityColor pColor, OdCmTransparency pTransparency, OdRxObject pDb, ref OdPrcFileStructure fileStructure)
	{
		IntPtr jarg = ((fileStructure == null) ? IntPtr.Zero : OdPrcFileStructure.getCPtr(fileStructure).Handle);
		IntPtr intPtr = jarg;
		try
		{
			OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_createByMaterial__SWIG_1(OdGiMaterialTraits.getCPtr(pTraits), OdCmEntityColor.getCPtr(pColor), OdCmTransparency.getCPtr(pTransparency), OdRxObject.getCPtr(pDb), ref jarg), cMemoryOwn: true);
			if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				fileStructure = null;
			}
			if (jarg != intPtr)
			{
				fileStructure = Helpers.GetRXObject<OdPrcFileStructure>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected override uint subSetAttributes(OdGiDrawableTraits traits)
	{
		uint result = (SwigDerivedClassHasMethod("subSetAttributes", swigMethodTypes8) ? OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_subSetAttributesSwigExplicitOdPrcCategory1LineStyle(swigCPtr, OdGiDrawableTraits.getCPtr(traits)) : OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_subSetAttributes(swigCPtr, OdGiDrawableTraits.getCPtr(traits)));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_getRealClassName(ptr);
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
		if (SwigDerivedClassHasMethod("drawableType", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethoddrawableType;
		}
		if (SwigDerivedClassHasMethod("isPersistent", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisPersistent;
		}
		if (SwigDerivedClassHasMethod("id", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodid;
		}
		if (SwigDerivedClassHasMethod("setGsNode", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodsetGsNode;
		}
		if (SwigDerivedClassHasMethod("gsNode", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgsNode;
		}
		if (SwigDerivedClassHasMethod("subSetAttributes", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodsubSetAttributes;
		}
		if (SwigDerivedClassHasMethod("subWorldDraw", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsubWorldDraw;
		}
		if (SwigDerivedClassHasMethod("subViewportDraw", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsubViewportDraw;
		}
		if (SwigDerivedClassHasMethod("subViewportDrawLogicalFlags", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsubViewportDrawLogicalFlags;
		}
		if (SwigDerivedClassHasMethod("subRegenSupportFlags", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsubRegenSupportFlags;
		}
		if (SwigDerivedClassHasMethod("prcOut", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodprcOut;
		}
		if (SwigDerivedClassHasMethod("prcIn", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodprcIn;
		}
		if (SwigDerivedClassHasMethod("prcType", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodprcType;
		}
		OdPrcModule_GlobalsPINVOKE.OdPrcCategory1LineStyle_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPrcCategory1LineStyle));
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

	private int SwigDirectorMethoddrawableType()
	{
		return (int)drawableType();
	}

	private bool SwigDirectorMethodisPersistent()
	{
		return isPersistent();
	}

	private IntPtr SwigDirectorMethodid()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(id()).Handle;
			}
			catch (OdEdEmptyInput odEdEmptyInput)
			{
				OdPrcModule_Globals.throw_native_OdError(odEdEmptyInput);
				throw odEdEmptyInput;
			}
			catch (OdEdOtherInput odEdOtherInput)
			{
				OdPrcModule_Globals.throw_native_OdError(odEdOtherInput);
				throw odEdOtherInput;
			}
			catch (OdError odError)
			{
				OdPrcModule_Globals.throw_native_OdError(odError);
				throw odError;
			}
			catch (Exception ex)
			{
				OdPrcModule_Globals.throw_native_exception_string(ex.ToString());
				throw ex;
			}
		})();
	}

	private void SwigDirectorMethodsetGsNode(IntPtr pGsNode)
	{
		try
		{
			setGsNode(Helpers.GetRXObject<OdGsCache>(pGsNode, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodgsNode()
	{
		return OdGsCache.getCPtr(gsNode()).Handle;
	}

	private uint SwigDirectorMethodsubSetAttributes(IntPtr traits)
	{
		return subSetAttributes(Helpers.GetRXObject<OdGiDrawableTraits>(traits, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodsubWorldDraw(IntPtr wd)
	{
		return subWorldDraw(Helpers.GetRXObject<OdGiWorldDraw>(wd, bOwn: false, bTryAddToTransaction: false));
	}

	private void SwigDirectorMethodsubViewportDraw(IntPtr vd)
	{
		try
		{
			subViewportDraw(Helpers.GetRXObject<OdGiViewportDraw>(vd, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodsubViewportDrawLogicalFlags(IntPtr vd)
	{
		return subViewportDrawLogicalFlags(Helpers.GetRXObject<OdGiViewportDraw>(vd, bOwn: false, bTryAddToTransaction: false));
	}

	private uint SwigDirectorMethodsubRegenSupportFlags()
	{
		return subRegenSupportFlags();
	}

	private void SwigDirectorMethodprcOut(IntPtr pStream)
	{
		try
		{
			prcOut(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
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

	private void SwigDirectorMethodprcIn(IntPtr pStream)
	{
		try
		{
			prcIn(Helpers.GetRXObject<OdPrcCompressedFiler>(pStream, bOwn: false, bTryAddToTransaction: false));
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

	private uint SwigDirectorMethodprcType()
	{
		return prcType();
	}
}
