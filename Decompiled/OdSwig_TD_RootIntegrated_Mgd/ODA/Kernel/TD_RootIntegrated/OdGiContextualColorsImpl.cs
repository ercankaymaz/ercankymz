using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiContextualColorsImpl : OdGiContextualColors
{
	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_1();

	public delegate void SwigDelegateOdGiContextualColorsImpl_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_3();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_4();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_5();

	public delegate bool SwigDelegateOdGiContextualColorsImpl_6();

	public delegate bool SwigDelegateOdGiContextualColorsImpl_7();

	public delegate bool SwigDelegateOdGiContextualColorsImpl_8();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_9();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_10();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_11();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_12();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_13();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_14();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_15();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_16();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_17();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_18();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_19();

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_20();

	public delegate void SwigDelegateOdGiContextualColorsImpl_21(uint nFlags, bool bSet);

	public delegate void SwigDelegateOdGiContextualColorsImpl_22(uint nFlags);

	public delegate bool SwigDelegateOdGiContextualColorsImpl_23(uint nFlags);

	public delegate IntPtr SwigDelegateOdGiContextualColorsImpl_24(int arg0);

	public delegate bool SwigDelegateOdGiContextualColorsImpl_25(int arg0);

	public delegate void SwigDelegateOdGiContextualColorsImpl_26(int type);

	public delegate int SwigDelegateOdGiContextualColorsImpl_27();

	public delegate void SwigDelegateOdGiContextualColorsImpl_28(int type, IntPtr color);

	public delegate void SwigDelegateOdGiContextualColorsImpl_29(int type, bool bSet);

	public delegate void SwigDelegateOdGiContextualColorsImpl_30();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiContextualColorsImpl_0 swigDelegate0;

	private SwigDelegateOdGiContextualColorsImpl_1 swigDelegate1;

	private SwigDelegateOdGiContextualColorsImpl_2 swigDelegate2;

	private SwigDelegateOdGiContextualColorsImpl_3 swigDelegate3;

	private SwigDelegateOdGiContextualColorsImpl_4 swigDelegate4;

	private SwigDelegateOdGiContextualColorsImpl_5 swigDelegate5;

	private SwigDelegateOdGiContextualColorsImpl_6 swigDelegate6;

	private SwigDelegateOdGiContextualColorsImpl_7 swigDelegate7;

	private SwigDelegateOdGiContextualColorsImpl_8 swigDelegate8;

	private SwigDelegateOdGiContextualColorsImpl_9 swigDelegate9;

	private SwigDelegateOdGiContextualColorsImpl_10 swigDelegate10;

	private SwigDelegateOdGiContextualColorsImpl_11 swigDelegate11;

	private SwigDelegateOdGiContextualColorsImpl_12 swigDelegate12;

	private SwigDelegateOdGiContextualColorsImpl_13 swigDelegate13;

	private SwigDelegateOdGiContextualColorsImpl_14 swigDelegate14;

	private SwigDelegateOdGiContextualColorsImpl_15 swigDelegate15;

	private SwigDelegateOdGiContextualColorsImpl_16 swigDelegate16;

	private SwigDelegateOdGiContextualColorsImpl_17 swigDelegate17;

	private SwigDelegateOdGiContextualColorsImpl_18 swigDelegate18;

	private SwigDelegateOdGiContextualColorsImpl_19 swigDelegate19;

	private SwigDelegateOdGiContextualColorsImpl_20 swigDelegate20;

	private SwigDelegateOdGiContextualColorsImpl_21 swigDelegate21;

	private SwigDelegateOdGiContextualColorsImpl_22 swigDelegate22;

	private SwigDelegateOdGiContextualColorsImpl_23 swigDelegate23;

	private SwigDelegateOdGiContextualColorsImpl_24 swigDelegate24;

	private SwigDelegateOdGiContextualColorsImpl_25 swigDelegate25;

	private SwigDelegateOdGiContextualColorsImpl_26 swigDelegate26;

	private SwigDelegateOdGiContextualColorsImpl_27 swigDelegate27;

	private SwigDelegateOdGiContextualColorsImpl_28 swigDelegate28;

	private SwigDelegateOdGiContextualColorsImpl_29 swigDelegate29;

	private SwigDelegateOdGiContextualColorsImpl_30 swigDelegate30;

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

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdGiContextualColorsImpl_VisualType) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[2]
	{
		typeof(OdGiContextualColors_ColorType),
		typeof(OdCmEntityColor)
	};

	private static Type[] swigMethodTypes29 = new Type[2]
	{
		typeof(OdGiContextualColors_ColorTint),
		typeof(bool)
	};

	private static Type[] swigMethodTypes30 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiContextualColorsImpl(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiContextualColorsImpl obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiContextualColorsImpl(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiContextualColorsImpl cast(OdRxObject pObj)
	{
		OdGiContextualColorsImpl rXObject = Helpers.GetRXObject<OdGiContextualColorsImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_isASwigExplicitOdGiContextualColorsImpl(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_queryXSwigExplicitOdGiContextualColorsImpl(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiContextualColorsImpl createObject()
	{
		OdGiContextualColorsImpl rXObject = Helpers.GetRXObject<OdGiContextualColorsImpl>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setVisualType(OdGiContextualColorsImpl_VisualType type)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_setVisualType(swigCPtr, (int)type);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiContextualColorsImpl_VisualType visualType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_visualType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdGiContextualColorsImpl_VisualType)result;
	}

	public virtual void setContextualColor(OdGiContextualColors_ColorType type, OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_setContextualColor__SWIG_0(swigCPtr, (int)type, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setContextualColor(OdGiContextualColors_ColorType type, uint color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_setContextualColor__SWIG_1(swigCPtr, (int)type, color);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setContextualColorTint(OdGiContextualColors_ColorTint type, bool bSet)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_setContextualColorTint(swigCPtr, (int)type, bSet);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setDefaultForType()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_setDefaultForType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiContextualColorsImpl()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiContextualColorsImpl(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiContextualColorsImpl) != GetType();
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
		if (SwigDerivedClassHasMethod("setVisualType", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetVisualType;
		}
		if (SwigDerivedClassHasMethod("visualType", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodvisualType;
		}
		if (SwigDerivedClassHasMethod("setContextualColor", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodsetContextualColor__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setContextualColorTint", swigMethodTypes29))
		{
			swigDelegate29 = SwigDirectorMethodsetContextualColorTint;
		}
		if (SwigDerivedClassHasMethod("setDefaultForType", swigMethodTypes30))
		{
			swigDelegate30 = SwigDirectorMethodsetDefaultForType;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsImpl_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28, swigDelegate29, swigDelegate30);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiContextualColorsImpl));
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

	private void SwigDirectorMethodsetVisualType(int type)
	{
		try
		{
			setVisualType((OdGiContextualColorsImpl_VisualType)type);
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

	private int SwigDirectorMethodvisualType()
	{
		return (int)visualType();
	}

	private void SwigDirectorMethodsetContextualColor__SWIG_0(int type, IntPtr color)
	{
		try
		{
			setContextualColor((OdGiContextualColors_ColorType)type, new OdCmEntityColor(color, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetContextualColorTint(int type, bool bSet)
	{
		try
		{
			setContextualColorTint((OdGiContextualColors_ColorTint)type, bSet);
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

	private void SwigDirectorMethodsetDefaultForType()
	{
		try
		{
			setDefaultForType();
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
