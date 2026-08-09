using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiWebLightTraits : OdGiPointLightTraits
{
	public delegate IntPtr SwigDelegateOdGiWebLightTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_1();

	public delegate void SwigDelegateOdGiWebLightTraits_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiWebLightTraits_3(bool on);

	public delegate bool SwigDelegateOdGiWebLightTraits_4();

	public delegate void SwigDelegateOdGiWebLightTraits_5(double inten);

	public delegate double SwigDelegateOdGiWebLightTraits_6();

	public delegate void SwigDelegateOdGiWebLightTraits_7(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_8();

	public delegate void SwigDelegateOdGiWebLightTraits_9(IntPtr params_);

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_10();

	public delegate void SwigDelegateOdGiWebLightTraits_11(IntPtr pos);

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_12();

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_13();

	public delegate void SwigDelegateOdGiWebLightTraits_14(IntPtr atten);

	public delegate void SwigDelegateOdGiWebLightTraits_15(double fIntensity);

	public delegate double SwigDelegateOdGiWebLightTraits_16();

	public delegate void SwigDelegateOdGiWebLightTraits_17(IntPtr color);

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_18();

	public delegate void SwigDelegateOdGiWebLightTraits_19(bool bTarget);

	public delegate bool SwigDelegateOdGiWebLightTraits_20();

	public delegate void SwigDelegateOdGiWebLightTraits_21(IntPtr loc);

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_22();

	public delegate void SwigDelegateOdGiWebLightTraits_23(bool bHemisphere);

	public delegate bool SwigDelegateOdGiWebLightTraits_24();

	public delegate void SwigDelegateOdGiWebLightTraits_25([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	public delegate string SwigDelegateOdGiWebLightTraits_26();

	public delegate void SwigDelegateOdGiWebLightTraits_27(IntPtr pWebStream);

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_28();

	public delegate void SwigDelegateOdGiWebLightTraits_29(IntPtr fRot);

	public delegate IntPtr SwigDelegateOdGiWebLightTraits_30();

	public delegate void SwigDelegateOdGiWebLightTraits_31(double fFlux);

	public delegate double SwigDelegateOdGiWebLightTraits_32();

	public delegate void SwigDelegateOdGiWebLightTraits_33(int type);

	public delegate int SwigDelegateOdGiWebLightTraits_34();

	public delegate void SwigDelegateOdGiWebLightTraits_35(int sym);

	public delegate int SwigDelegateOdGiWebLightTraits_36();

	public delegate void SwigDelegateOdGiWebLightTraits_37(bool bFlag);

	public delegate bool SwigDelegateOdGiWebLightTraits_38();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiWebLightTraits_0 swigDelegate0;

	private SwigDelegateOdGiWebLightTraits_1 swigDelegate1;

	private SwigDelegateOdGiWebLightTraits_2 swigDelegate2;

	private SwigDelegateOdGiWebLightTraits_3 swigDelegate3;

	private SwigDelegateOdGiWebLightTraits_4 swigDelegate4;

	private SwigDelegateOdGiWebLightTraits_5 swigDelegate5;

	private SwigDelegateOdGiWebLightTraits_6 swigDelegate6;

	private SwigDelegateOdGiWebLightTraits_7 swigDelegate7;

	private SwigDelegateOdGiWebLightTraits_8 swigDelegate8;

	private SwigDelegateOdGiWebLightTraits_9 swigDelegate9;

	private SwigDelegateOdGiWebLightTraits_10 swigDelegate10;

	private SwigDelegateOdGiWebLightTraits_11 swigDelegate11;

	private SwigDelegateOdGiWebLightTraits_12 swigDelegate12;

	private SwigDelegateOdGiWebLightTraits_13 swigDelegate13;

	private SwigDelegateOdGiWebLightTraits_14 swigDelegate14;

	private SwigDelegateOdGiWebLightTraits_15 swigDelegate15;

	private SwigDelegateOdGiWebLightTraits_16 swigDelegate16;

	private SwigDelegateOdGiWebLightTraits_17 swigDelegate17;

	private SwigDelegateOdGiWebLightTraits_18 swigDelegate18;

	private SwigDelegateOdGiWebLightTraits_19 swigDelegate19;

	private SwigDelegateOdGiWebLightTraits_20 swigDelegate20;

	private SwigDelegateOdGiWebLightTraits_21 swigDelegate21;

	private SwigDelegateOdGiWebLightTraits_22 swigDelegate22;

	private SwigDelegateOdGiWebLightTraits_23 swigDelegate23;

	private SwigDelegateOdGiWebLightTraits_24 swigDelegate24;

	private SwigDelegateOdGiWebLightTraits_25 swigDelegate25;

	private SwigDelegateOdGiWebLightTraits_26 swigDelegate26;

	private SwigDelegateOdGiWebLightTraits_27 swigDelegate27;

	private SwigDelegateOdGiWebLightTraits_28 swigDelegate28;

	private SwigDelegateOdGiWebLightTraits_29 swigDelegate29;

	private SwigDelegateOdGiWebLightTraits_30 swigDelegate30;

	private SwigDelegateOdGiWebLightTraits_31 swigDelegate31;

	private SwigDelegateOdGiWebLightTraits_32 swigDelegate32;

	private SwigDelegateOdGiWebLightTraits_33 swigDelegate33;

	private SwigDelegateOdGiWebLightTraits_34 swigDelegate34;

	private SwigDelegateOdGiWebLightTraits_35 swigDelegate35;

	private SwigDelegateOdGiWebLightTraits_36 swigDelegate36;

	private SwigDelegateOdGiWebLightTraits_37 swigDelegate37;

	private SwigDelegateOdGiWebLightTraits_38 swigDelegate38;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes6 = new Type[0];

	private static Type[] swigMethodTypes7 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes8 = new Type[0];

	private static Type[] swigMethodTypes9 = new Type[1] { typeof(OdGiShadowParameters) };

	private static Type[] swigMethodTypes10 = new Type[0];

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes12 = new Type[0];

	private static Type[] swigMethodTypes13 = new Type[0];

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(OdGiLightAttenuation) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes16 = new Type[0];

	private static Type[] swigMethodTypes17 = new Type[1] { typeof(OdGiColorRGB) };

	private static Type[] swigMethodTypes18 = new Type[0];

	private static Type[] swigMethodTypes19 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes20 = new Type[0];

	private static Type[] swigMethodTypes21 = new Type[1] { typeof(OdGePoint3d) };

	private static Type[] swigMethodTypes22 = new Type[0];

	private static Type[] swigMethodTypes23 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes24 = new Type[0];

	private static Type[] swigMethodTypes25 = new Type[1] { typeof(string) };

	private static Type[] swigMethodTypes26 = new Type[0];

	private static Type[] swigMethodTypes27 = new Type[1] { typeof(OdStreamBuf).MakeByRefType() };

	private static Type[] swigMethodTypes28 = new Type[0];

	private static Type[] swigMethodTypes29 = new Type[1] { typeof(OdGeVector3d) };

	private static Type[] swigMethodTypes30 = new Type[0];

	private static Type[] swigMethodTypes31 = new Type[1] { typeof(double) };

	private static Type[] swigMethodTypes32 = new Type[0];

	private static Type[] swigMethodTypes33 = new Type[1] { typeof(OdGiWebLightTraits_WebFileType) };

	private static Type[] swigMethodTypes34 = new Type[0];

	private static Type[] swigMethodTypes35 = new Type[1] { typeof(OdGiWebLightTraits_WebSymmetry) };

	private static Type[] swigMethodTypes36 = new Type[0];

	private static Type[] swigMethodTypes37 = new Type[1] { typeof(bool) };

	private static Type[] swigMethodTypes38 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiWebLightTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiWebLightTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiWebLightTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiWebLightTraits cast(OdRxObject pObj)
	{
		OdGiWebLightTraits rXObject = Helpers.GetRXObject<OdGiWebLightTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_isASwigExplicitOdGiWebLightTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_queryXSwigExplicitOdGiWebLightTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiWebLightTraits createObject()
	{
		OdGiWebLightTraits rXObject = Helpers.GetRXObject<OdGiWebLightTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setWebFile(string fileName)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_setWebFile(swigCPtr, fileName);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual string webFile()
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_webFile(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setWebFileStream(ref OdStreamBuf pWebStream)
	{
		IntPtr jarg = ((pWebStream == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(pWebStream).Handle);
		IntPtr intPtr = jarg;
		try
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_setWebFileStream(swigCPtr, ref jarg);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pWebStream = null;
			}
			else if (jarg != intPtr)
			{
				pWebStream = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public virtual OdStreamBuf webFileStream()
	{
		OdStreamBuf rXObject = Helpers.GetRXObject<OdStreamBuf>(TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_webFileStream(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setWebRotation(OdGeVector3d fRot)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_setWebRotation(swigCPtr, OdGeVector3d.getCPtr(fRot));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGeVector3d webRotation()
	{
		OdGeVector3d result = new OdGeVector3d(TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_webRotation(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setWebFlux(double fFlux)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_setWebFlux(swigCPtr, fFlux);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual double webFlux()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_webFlux(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setWebFileType(OdGiWebLightTraits_WebFileType type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_setWebFileType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiWebLightTraits_WebFileType webFileType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_webFileType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiWebLightTraits_WebFileType)result;
	}

	public virtual void setWebSymmetry(OdGiWebLightTraits_WebSymmetry sym)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_setWebSymmetry(swigCPtr, (int)sym);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiWebLightTraits_WebSymmetry webSymmetry()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_webSymmetry(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiWebLightTraits_WebSymmetry)result;
	}

	public virtual void setWebHorzAng90to270(bool bFlag)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_setWebHorzAng90to270(swigCPtr, bFlag);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool webHorzAng90to270()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_webHorzAng90to270(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiWebLightTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiWebLightTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiWebLightTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("setOn", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsetOn;
		}
		if (SwigDerivedClassHasMethod("isOn", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisOn;
		}
		if (SwigDerivedClassHasMethod("setIntensity", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodsetIntensity;
		}
		if (SwigDerivedClassHasMethod("intensity", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodintensity;
		}
		if (SwigDerivedClassHasMethod("setLightColor", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodsetLightColor;
		}
		if (SwigDerivedClassHasMethod("lightColor", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodlightColor;
		}
		if (SwigDerivedClassHasMethod("setShadowParameters", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodsetShadowParameters;
		}
		if (SwigDerivedClassHasMethod("shadowParameters", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodshadowParameters;
		}
		if (SwigDerivedClassHasMethod("setPosition", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetPosition;
		}
		if (SwigDerivedClassHasMethod("position", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodposition;
		}
		if (SwigDerivedClassHasMethod("lightAttenuation", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodlightAttenuation;
		}
		if (SwigDerivedClassHasMethod("setAttenuation", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetAttenuation;
		}
		if (SwigDerivedClassHasMethod("setPhysicalIntensity", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetPhysicalIntensity;
		}
		if (SwigDerivedClassHasMethod("physicalIntensity", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodphysicalIntensity;
		}
		if (SwigDerivedClassHasMethod("setLampColor", swigMethodTypes17))
		{
			swigDelegate17 = SwigDirectorMethodsetLampColor;
		}
		if (SwigDerivedClassHasMethod("lampColor", swigMethodTypes18))
		{
			swigDelegate18 = SwigDirectorMethodlampColor;
		}
		if (SwigDerivedClassHasMethod("setHasTarget", swigMethodTypes19))
		{
			swigDelegate19 = SwigDirectorMethodsetHasTarget;
		}
		if (SwigDerivedClassHasMethod("hasTarget", swigMethodTypes20))
		{
			swigDelegate20 = SwigDirectorMethodhasTarget;
		}
		if (SwigDerivedClassHasMethod("setTargetLocation", swigMethodTypes21))
		{
			swigDelegate21 = SwigDirectorMethodsetTargetLocation;
		}
		if (SwigDerivedClassHasMethod("targetLocation", swigMethodTypes22))
		{
			swigDelegate22 = SwigDirectorMethodtargetLocation;
		}
		if (SwigDerivedClassHasMethod("setHemisphericalDistribution", swigMethodTypes23))
		{
			swigDelegate23 = SwigDirectorMethodsetHemisphericalDistribution;
		}
		if (SwigDerivedClassHasMethod("hemisphericalDistribution", swigMethodTypes24))
		{
			swigDelegate24 = SwigDirectorMethodhemisphericalDistribution;
		}
		if (SwigDerivedClassHasMethod("setWebFile", swigMethodTypes25))
		{
			swigDelegate25 = SwigDirectorMethodsetWebFile;
		}
		if (SwigDerivedClassHasMethod("webFile", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodwebFile;
		}
		if (SwigDerivedClassHasMethod("setWebFileStream", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodsetWebFileStream;
		}
		if (SwigDerivedClassHasMethod("webFileStream", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodwebFileStream;
		}
		if (SwigDerivedClassHasMethod("setWebRotation", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodsetWebRotation;
		}
		if (SwigDerivedClassHasMethod("webRotation", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodwebRotation;
		}
		if (SwigDerivedClassHasMethod("setWebFlux", swigMethodTypes31))
		{
			swigDelegate31 = SwigDirectorMethodsetWebFlux;
		}
		if (SwigDerivedClassHasMethod("webFlux", swigMethodTypes32))
		{
			swigDelegate32 = SwigDirectorMethodwebFlux;
		}
		if (SwigDerivedClassHasMethod("setWebFileType", swigMethodTypes33))
		{
			swigDelegate33 = SwigDirectorMethodsetWebFileType;
		}
		if (SwigDerivedClassHasMethod("webFileType", swigMethodTypes34))
		{
			swigDelegate34 = SwigDirectorMethodwebFileType;
		}
		if (SwigDerivedClassHasMethod("setWebSymmetry", swigMethodTypes35))
		{
			swigDelegate35 = SwigDirectorMethodsetWebSymmetry;
		}
		if (SwigDerivedClassHasMethod("webSymmetry", swigMethodTypes36))
		{
			swigDelegate36 = SwigDirectorMethodwebSymmetry;
		}
		if (SwigDerivedClassHasMethod("setWebHorzAng90to270", swigMethodTypes37))
		{
			swigDelegate37 = SwigDirectorMethodsetWebHorzAng90to270;
		}
		if (SwigDerivedClassHasMethod("webHorzAng90to270", swigMethodTypes38))
		{
			swigDelegate38 = SwigDirectorMethodwebHorzAng90to270;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiWebLightTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30, swigDelegate31, swigDelegate32, swigDelegate33, swigDelegate34, swigDelegate35, swigDelegate36, swigDelegate37, swigDelegate38);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiWebLightTraits));
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

	private void SwigDirectorMethodsetOn(bool on)
	{
		try
		{
			setOn(on);
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

	private bool SwigDirectorMethodisOn()
	{
		return isOn();
	}

	private void SwigDirectorMethodsetIntensity(double inten)
	{
		try
		{
			setIntensity(inten);
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

	private double SwigDirectorMethodintensity()
	{
		return intensity();
	}

	private void SwigDirectorMethodsetLightColor(IntPtr color)
	{
		try
		{
			setLightColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlightColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(lightColor()).Handle;
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

	private void SwigDirectorMethodsetShadowParameters(IntPtr params_)
	{
		try
		{
			setShadowParameters(new OdGiShadowParameters(params_, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodshadowParameters()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiShadowParameters.getCPtr(shadowParameters()).Handle;
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

	private void SwigDirectorMethodsetPosition(IntPtr pos)
	{
		try
		{
			setPosition(new OdGePoint3d(pos, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodposition()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(position()).Handle;
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

	private IntPtr SwigDirectorMethodlightAttenuation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiLightAttenuation.getCPtr(lightAttenuation()).Handle;
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

	private void SwigDirectorMethodsetAttenuation(IntPtr atten)
	{
		try
		{
			setAttenuation(new OdGiLightAttenuation(atten, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetPhysicalIntensity(double fIntensity)
	{
		try
		{
			setPhysicalIntensity(fIntensity);
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

	private double SwigDirectorMethodphysicalIntensity()
	{
		return physicalIntensity();
	}

	private void SwigDirectorMethodsetLampColor(IntPtr color)
	{
		try
		{
			setLampColor(new OdGiColorRGB(color, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodlampColor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGiColorRGB.getCPtr(lampColor()).Handle;
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

	private void SwigDirectorMethodsetHasTarget(bool bTarget)
	{
		try
		{
			setHasTarget(bTarget);
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

	private bool SwigDirectorMethodhasTarget()
	{
		return hasTarget();
	}

	private void SwigDirectorMethodsetTargetLocation(IntPtr loc)
	{
		try
		{
			setTargetLocation(new OdGePoint3d(loc, cMemoryOwn: false));
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

	private IntPtr SwigDirectorMethodtargetLocation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGePoint3d.getCPtr(targetLocation()).Handle;
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

	private void SwigDirectorMethodsetHemisphericalDistribution(bool bHemisphere)
	{
		try
		{
			setHemisphericalDistribution(bHemisphere);
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

	private bool SwigDirectorMethodhemisphericalDistribution()
	{
		return hemisphericalDistribution();
	}

	private void SwigDirectorMethodsetWebFile([MarshalAs(UnmanagedType.LPWStr)] string fileName)
	{
		try
		{
			setWebFile(fileName);
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
	private string SwigDirectorMethodwebFile()
	{
		return webFile();
	}

	private void SwigDirectorMethodsetWebFileStream(IntPtr pWebStream)
	{
		OdSwigDirectorHelper.director_UnpackData(pWebStream, out var pOriginalObject, out var pFunction);
		OdStreamBuf pWebStream2 = Helpers.GetRXObject<OdStreamBuf>(pOriginalObject, bOwn: true, bTryAddToTransaction: true);
		try
		{
			setWebFileStream(ref pWebStream2);
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
		finally
		{
			IntPtr handle = OdStreamBuf.getCPtr(pWebStream2).Handle;
			if (pOriginalObject != handle)
			{
				OdSwigDirectorHelper.director_callUpdateFunction(pFunction, handle);
			}
			OdSwigDirectorHelper.director_freeData(pWebStream);
		}
	}

	private IntPtr SwigDirectorMethodwebFileStream()
	{
		return OdStreamBuf.getCPtr(webFileStream()).Handle;
	}

	private void SwigDirectorMethodsetWebRotation(IntPtr fRot)
	{
		try
		{
			setWebRotation(new OdGeVector3d(fRot, cMemoryOwn: true));
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

	private IntPtr SwigDirectorMethodwebRotation()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdGeVector3d.getCPtr(webRotation()).Handle;
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

	private void SwigDirectorMethodsetWebFlux(double fFlux)
	{
		try
		{
			setWebFlux(fFlux);
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

	private double SwigDirectorMethodwebFlux()
	{
		return webFlux();
	}

	private void SwigDirectorMethodsetWebFileType(int type)
	{
		try
		{
			setWebFileType((OdGiWebLightTraits_WebFileType)type);
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

	private int SwigDirectorMethodwebFileType()
	{
		return (int)webFileType();
	}

	private void SwigDirectorMethodsetWebSymmetry(int sym)
	{
		try
		{
			setWebSymmetry((OdGiWebLightTraits_WebSymmetry)sym);
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

	private int SwigDirectorMethodwebSymmetry()
	{
		return (int)webSymmetry();
	}

	private void SwigDirectorMethodsetWebHorzAng90to270(bool bFlag)
	{
		try
		{
			setWebHorzAng90to270(bFlag);
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

	private bool SwigDirectorMethodwebHorzAng90to270()
	{
		return webHorzAng90to270();
	}
}
