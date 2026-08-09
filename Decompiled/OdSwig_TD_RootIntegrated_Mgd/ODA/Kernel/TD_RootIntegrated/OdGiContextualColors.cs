using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiContextualColors : OdRxObject
{
	public delegate IntPtr SwigDelegateOdGiContextualColors_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiContextualColors_1();

	public delegate void SwigDelegateOdGiContextualColors_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiContextualColors_3();

	public delegate IntPtr SwigDelegateOdGiContextualColors_4();

	public delegate IntPtr SwigDelegateOdGiContextualColors_5();

	public delegate bool SwigDelegateOdGiContextualColors_6();

	public delegate bool SwigDelegateOdGiContextualColors_7();

	public delegate bool SwigDelegateOdGiContextualColors_8();

	public delegate IntPtr SwigDelegateOdGiContextualColors_9();

	public delegate IntPtr SwigDelegateOdGiContextualColors_10();

	public delegate IntPtr SwigDelegateOdGiContextualColors_11();

	public delegate IntPtr SwigDelegateOdGiContextualColors_12();

	public delegate IntPtr SwigDelegateOdGiContextualColors_13();

	public delegate IntPtr SwigDelegateOdGiContextualColors_14();

	public delegate IntPtr SwigDelegateOdGiContextualColors_15();

	public delegate IntPtr SwigDelegateOdGiContextualColors_16();

	public delegate IntPtr SwigDelegateOdGiContextualColors_17();

	public delegate IntPtr SwigDelegateOdGiContextualColors_18();

	public delegate IntPtr SwigDelegateOdGiContextualColors_19();

	public delegate IntPtr SwigDelegateOdGiContextualColors_20();

	public delegate void SwigDelegateOdGiContextualColors_21(uint nFlags, bool bSet);

	public delegate void SwigDelegateOdGiContextualColors_22(uint nFlags);

	public delegate bool SwigDelegateOdGiContextualColors_23(uint nFlags);

	public delegate IntPtr SwigDelegateOdGiContextualColors_24(int arg0);

	public delegate bool SwigDelegateOdGiContextualColors_25(int arg0);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiContextualColors_0 swigDelegate0;

	private SwigDelegateOdGiContextualColors_1 swigDelegate1;

	private SwigDelegateOdGiContextualColors_2 swigDelegate2;

	private SwigDelegateOdGiContextualColors_3 swigDelegate3;

	private SwigDelegateOdGiContextualColors_4 swigDelegate4;

	private SwigDelegateOdGiContextualColors_5 swigDelegate5;

	private SwigDelegateOdGiContextualColors_6 swigDelegate6;

	private SwigDelegateOdGiContextualColors_7 swigDelegate7;

	private SwigDelegateOdGiContextualColors_8 swigDelegate8;

	private SwigDelegateOdGiContextualColors_9 swigDelegate9;

	private SwigDelegateOdGiContextualColors_10 swigDelegate10;

	private SwigDelegateOdGiContextualColors_11 swigDelegate11;

	private SwigDelegateOdGiContextualColors_12 swigDelegate12;

	private SwigDelegateOdGiContextualColors_13 swigDelegate13;

	private SwigDelegateOdGiContextualColors_14 swigDelegate14;

	private SwigDelegateOdGiContextualColors_15 swigDelegate15;

	private SwigDelegateOdGiContextualColors_16 swigDelegate16;

	private SwigDelegateOdGiContextualColors_17 swigDelegate17;

	private SwigDelegateOdGiContextualColors_18 swigDelegate18;

	private SwigDelegateOdGiContextualColors_19 swigDelegate19;

	private SwigDelegateOdGiContextualColors_20 swigDelegate20;

	private SwigDelegateOdGiContextualColors_21 swigDelegate21;

	private SwigDelegateOdGiContextualColors_22 swigDelegate22;

	private SwigDelegateOdGiContextualColors_23 swigDelegate23;

	private SwigDelegateOdGiContextualColors_24 swigDelegate24;

	private SwigDelegateOdGiContextualColors_25 swigDelegate25;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[0];

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[0];

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[0];

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[0];

	private static Type[] swigMethodTypes15 = new Type[0];

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[0];

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[0];

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[2]
	{
		typeof(uint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes22 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(uint) };

	private static Type[] swigMethodTypes24 = new Type[1] { typeof(OdGiContextualColors_ColorType) };

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(OdGiContextualColors_ColorTint) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiContextualColors(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiContextualColors obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiContextualColors(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiContextualColors cast(OdRxObject pObj)
	{
		OdGiContextualColors rXObject = Helpers.GetRXObject<OdGiContextualColors>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_isASwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_queryXSwigExplicitOdGiContextualColors(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiContextualColors createObject()
	{
		OdGiContextualColors rXObject = Helpers.GetRXObject<OdGiContextualColors>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdCmEntityColor gridMajorLines()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("gridMajorLines", swigMethodTypes3) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridMajorLinesSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridMajorLines(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor gridMinorLines()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("gridMinorLines", swigMethodTypes4) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridMinorLinesSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridMinorLines(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor gridAxisLines()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("gridAxisLines", swigMethodTypes5) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridAxisLinesSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridAxisLines(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool gridMajorLineTintXYZ()
	{
		bool result = (SwigDerivedClassHasMethod("gridMajorLineTintXYZ", swigMethodTypes6) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridMajorLineTintXYZSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridMajorLineTintXYZ(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool gridMinorLineTintXYZ()
	{
		bool result = (SwigDerivedClassHasMethod("gridMinorLineTintXYZ", swigMethodTypes7) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridMinorLineTintXYZSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridMinorLineTintXYZ(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool gridAxisLineTintXYZ()
	{
		bool result = (SwigDerivedClassHasMethod("gridAxisLineTintXYZ", swigMethodTypes8) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridAxisLineTintXYZSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_gridAxisLineTintXYZ(swigCPtr));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor lightGlyphs()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("lightGlyphs", swigMethodTypes9) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightGlyphsSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightGlyphs(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor lightHotspot()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("lightHotspot", swigMethodTypes10) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightHotspotSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightHotspot(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor lightFalloff()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("lightFalloff", swigMethodTypes11) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightFalloffSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightFalloff(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor lightStartLimit()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("lightStartLimit", swigMethodTypes12) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightStartLimitSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightStartLimit(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor lightEndLimit()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("lightEndLimit", swigMethodTypes13) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightEndLimitSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightEndLimit(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor lightShapeColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("lightShapeColor", swigMethodTypes14) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightShapeColorSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightShapeColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor lightDistanceColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("lightDistanceColor", swigMethodTypes15) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightDistanceColorSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_lightDistanceColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor webMeshColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("webMeshColor", swigMethodTypes16) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_webMeshColorSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_webMeshColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor webMeshMissingColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("webMeshMissingColor", swigMethodTypes17) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_webMeshMissingColorSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_webMeshMissingColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor cameraGlyphs()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("cameraGlyphs", swigMethodTypes18) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_cameraGlyphsSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_cameraGlyphs(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor cameraFrustrum()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("cameraFrustrum", swigMethodTypes19) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_cameraFrustrumSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_cameraFrustrum(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor cameraClipping()
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("cameraClipping", swigMethodTypes20) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_cameraClippingSwigExplicitOdGiContextualColors(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_cameraClipping(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setContextFlags(uint nFlags, bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_setContextFlags__SWIG_0(swigCPtr, nFlags, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setContextFlags(uint nFlags)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_setContextFlags__SWIG_1(swigCPtr, nFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool flagsSet(uint nFlags)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_flagsSet(swigCPtr, nFlags);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmEntityColor contextualColor(OdGiContextualColors_ColorType arg0)
	{
		OdCmEntityColor result = new OdCmEntityColor(SwigDerivedClassHasMethod("contextualColor", swigMethodTypes24) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_contextualColorSwigExplicitOdGiContextualColors(swigCPtr, (int)arg0) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_contextualColor(swigCPtr, (int)arg0), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool contextualColorTint(OdGiContextualColors_ColorTint arg0)
	{
		bool result = (SwigDerivedClassHasMethod("contextualColorTint", swigMethodTypes25) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_contextualColorTintSwigExplicitOdGiContextualColors(swigCPtr, (int)arg0) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_contextualColorTint(swigCPtr, (int)arg0));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiContextualColors()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiContextualColors(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiContextualColors) != GetType();
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
		if (SwigDerivedClassHasMethod("gridMajorLines", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodgridMajorLines;
		}
		if (SwigDerivedClassHasMethod("gridMinorLines", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodgridMinorLines;
		}
		if (SwigDerivedClassHasMethod("gridAxisLines", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodgridAxisLines;
		}
		if (SwigDerivedClassHasMethod("gridMajorLineTintXYZ", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodgridMajorLineTintXYZ;
		}
		if (SwigDerivedClassHasMethod("gridMinorLineTintXYZ", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodgridMinorLineTintXYZ;
		}
		if (SwigDerivedClassHasMethod("gridAxisLineTintXYZ", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodgridAxisLineTintXYZ;
		}
		if (SwigDerivedClassHasMethod("lightGlyphs", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodlightGlyphs;
		}
		if (SwigDerivedClassHasMethod("lightHotspot", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodlightHotspot;
		}
		if (SwigDerivedClassHasMethod("lightFalloff", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodlightFalloff;
		}
		if (SwigDerivedClassHasMethod("lightStartLimit", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodlightStartLimit;
		}
		if (SwigDerivedClassHasMethod("lightEndLimit", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodlightEndLimit;
		}
		if (SwigDerivedClassHasMethod("lightShapeColor", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodlightShapeColor;
		}
		if (SwigDerivedClassHasMethod("lightDistanceColor", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodlightDistanceColor;
		}
		if (SwigDerivedClassHasMethod("webMeshColor", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodwebMeshColor;
		}
		if (SwigDerivedClassHasMethod("webMeshMissingColor", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodwebMeshMissingColor;
		}
		if (SwigDerivedClassHasMethod("cameraGlyphs", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodcameraGlyphs;
		}
		if (SwigDerivedClassHasMethod("cameraFrustrum", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodcameraFrustrum;
		}
		if (SwigDerivedClassHasMethod("cameraClipping", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodcameraClipping;
		}
		if (SwigDerivedClassHasMethod("setContextFlags", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetContextFlags__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setContextFlags", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodsetContextFlags__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("flagsSet", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodflagsSet;
		}
		if (SwigDerivedClassHasMethod("contextualColor", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodcontextualColor;
		}
		if (SwigDerivedClassHasMethod("contextualColorTint", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodcontextualColorTint;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColors_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiContextualColors));
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

	private IntPtr SwigDirectorMethodgridMajorLines()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(gridMajorLines()).Handle;
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

	private IntPtr SwigDirectorMethodgridMinorLines()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(gridMinorLines()).Handle;
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

	private IntPtr SwigDirectorMethodgridAxisLines()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(gridAxisLines()).Handle;
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

	private bool SwigDirectorMethodgridMajorLineTintXYZ()
	{
		return gridMajorLineTintXYZ();
	}

	private bool SwigDirectorMethodgridMinorLineTintXYZ()
	{
		return gridMinorLineTintXYZ();
	}

	private bool SwigDirectorMethodgridAxisLineTintXYZ()
	{
		return gridAxisLineTintXYZ();
	}

	private IntPtr SwigDirectorMethodlightGlyphs()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightGlyphs()).Handle;
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

	private IntPtr SwigDirectorMethodlightHotspot()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightHotspot()).Handle;
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

	private IntPtr SwigDirectorMethodlightFalloff()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightFalloff()).Handle;
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

	private IntPtr SwigDirectorMethodlightStartLimit()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightStartLimit()).Handle;
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

	private IntPtr SwigDirectorMethodlightEndLimit()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightEndLimit()).Handle;
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

	private IntPtr SwigDirectorMethodlightShapeColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightShapeColor()).Handle;
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

	private IntPtr SwigDirectorMethodlightDistanceColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightDistanceColor()).Handle;
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

	private IntPtr SwigDirectorMethodwebMeshColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(webMeshColor()).Handle;
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

	private IntPtr SwigDirectorMethodwebMeshMissingColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(webMeshMissingColor()).Handle;
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

	private IntPtr SwigDirectorMethodcameraGlyphs()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(cameraGlyphs()).Handle;
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

	private IntPtr SwigDirectorMethodcameraFrustrum()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(cameraFrustrum()).Handle;
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

	private IntPtr SwigDirectorMethodcameraClipping()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(cameraClipping()).Handle;
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

	private void SwigDirectorMethodsetContextFlags__SWIG_0(uint nFlags, bool bSet)
	{
		try
		{
			setContextFlags(nFlags, bSet);
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

	private void SwigDirectorMethodsetContextFlags__SWIG_1(uint nFlags)
	{
		try
		{
			setContextFlags(nFlags);
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

	private bool SwigDirectorMethodflagsSet(uint nFlags)
	{
		return flagsSet(nFlags);
	}

	private IntPtr SwigDirectorMethodcontextualColor(int arg0)
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(contextualColor((OdGiContextualColors_ColorType)arg0)).Handle;
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

	private bool SwigDirectorMethodcontextualColorTint(int arg0)
	{
		return contextualColorTint((OdGiContextualColors_ColorTint)arg0);
	}
}
