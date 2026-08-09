using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiContextualColorsRedir : OdGiContextualColors
{
	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_1();

	public delegate void SwigDelegateOdGiContextualColorsRedir_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_3();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_4();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_5();

	public delegate bool SwigDelegateOdGiContextualColorsRedir_6();

	public delegate bool SwigDelegateOdGiContextualColorsRedir_7();

	public delegate bool SwigDelegateOdGiContextualColorsRedir_8();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_9();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_10();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_11();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_12();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_13();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_14();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_15();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_16();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_17();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_18();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_19();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_20();

	public delegate void SwigDelegateOdGiContextualColorsRedir_21(uint nFlags, bool bSet);

	public delegate void SwigDelegateOdGiContextualColorsRedir_22(uint nFlags);

	public delegate bool SwigDelegateOdGiContextualColorsRedir_23(uint nFlags);

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_24(int arg0);

	public delegate bool SwigDelegateOdGiContextualColorsRedir_25(int arg0);

	public delegate void SwigDelegateOdGiContextualColorsRedir_26(IntPtr pObj);

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_27();

	public delegate IntPtr SwigDelegateOdGiContextualColorsRedir_28();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiContextualColorsRedir_0 swigDelegate0;

	private SwigDelegateOdGiContextualColorsRedir_1 swigDelegate1;

	private SwigDelegateOdGiContextualColorsRedir_2 swigDelegate2;

	private SwigDelegateOdGiContextualColorsRedir_3 swigDelegate3;

	private SwigDelegateOdGiContextualColorsRedir_4 swigDelegate4;

	private SwigDelegateOdGiContextualColorsRedir_5 swigDelegate5;

	private SwigDelegateOdGiContextualColorsRedir_6 swigDelegate6;

	private SwigDelegateOdGiContextualColorsRedir_7 swigDelegate7;

	private SwigDelegateOdGiContextualColorsRedir_8 swigDelegate8;

	private SwigDelegateOdGiContextualColorsRedir_9 swigDelegate9;

	private SwigDelegateOdGiContextualColorsRedir_10 swigDelegate10;

	private SwigDelegateOdGiContextualColorsRedir_11 swigDelegate11;

	private SwigDelegateOdGiContextualColorsRedir_12 swigDelegate12;

	private SwigDelegateOdGiContextualColorsRedir_13 swigDelegate13;

	private SwigDelegateOdGiContextualColorsRedir_14 swigDelegate14;

	private SwigDelegateOdGiContextualColorsRedir_15 swigDelegate15;

	private SwigDelegateOdGiContextualColorsRedir_16 swigDelegate16;

	private SwigDelegateOdGiContextualColorsRedir_17 swigDelegate17;

	private SwigDelegateOdGiContextualColorsRedir_18 swigDelegate18;

	private SwigDelegateOdGiContextualColorsRedir_19 swigDelegate19;

	private SwigDelegateOdGiContextualColorsRedir_20 swigDelegate20;

	private SwigDelegateOdGiContextualColorsRedir_21 swigDelegate21;

	private SwigDelegateOdGiContextualColorsRedir_22 swigDelegate22;

	private SwigDelegateOdGiContextualColorsRedir_23 swigDelegate23;

	private SwigDelegateOdGiContextualColorsRedir_24 swigDelegate24;

	private SwigDelegateOdGiContextualColorsRedir_25 swigDelegate25;

	private SwigDelegateOdGiContextualColorsRedir_26 swigDelegate26;

	private SwigDelegateOdGiContextualColorsRedir_27 swigDelegate27;

	private SwigDelegateOdGiContextualColorsRedir_28 swigDelegate28;

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

	private static Type[] swigMethodTypes26 = new Type[1] { typeof(OdGiContextualColors) };

	private static Type[] swigMethodTypes27 = new Type[0];

	private static Type[] swigMethodTypes28 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiContextualColorsRedir(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiContextualColorsRedir obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiContextualColorsRedir(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiContextualColorsRedir cast(OdRxObject pObj)
	{
		OdGiContextualColorsRedir rXObject = Helpers.GetRXObject<OdGiContextualColorsRedir>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_isASwigExplicitOdGiContextualColorsRedir(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_queryXSwigExplicitOdGiContextualColorsRedir(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiContextualColorsRedir createObject()
	{
		OdGiContextualColorsRedir rXObject = Helpers.GetRXObject<OdGiContextualColorsRedir>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setRedirectionObject(OdGiContextualColors pObj)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_setRedirectionObject(swigCPtr, OdGiContextualColors.getCPtr(pObj));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdGiContextualColors redirectionObject()
	{
		OdGiContextualColors rXObject = Helpers.GetRXObject<OdGiContextualColors>(TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_redirectionObject__SWIG_0(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiContextualColorsRedir()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiContextualColorsRedir(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiContextualColorsRedir) != GetType();
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
		if (SwigDerivedClassHasMethod("setRedirectionObject", swigMethodTypes26))
		{
			swigDelegate26 = SwigDirectorMethodsetRedirectionObject;
		}
		if (SwigDerivedClassHasMethod("redirectionObject", swigMethodTypes27))
		{
			swigDelegate27 = SwigDirectorMethodredirectionObject__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("redirectionObject", swigMethodTypes28))
		{
			swigDelegate28 = SwigDirectorMethodredirectionObject__SWIG_1;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiContextualColorsRedir_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16, swigDelegate17, swigDelegate18, swigDelegate19, swigDelegate20, swigDelegate21, swigDelegate22, swigDelegate23, swigDelegate24, swigDelegate25, swigDelegate26, swigDelegate27, swigDelegate28);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiContextualColorsRedir));
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

	private void SwigDirectorMethodsetRedirectionObject(IntPtr pObj)
	{
		try
		{
			setRedirectionObject(Helpers.GetRXObject<OdGiContextualColors>(pObj, bOwn: false, bTryAddToTransaction: false));
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

	private IntPtr SwigDirectorMethodredirectionObject__SWIG_0()
	{
		return OdGiContextualColors.getCPtr(redirectionObject()).Handle;
	}

	private IntPtr SwigDirectorMethodredirectionObject__SWIG_1()
	{
		return OdGiContextualColors.getCPtr(redirectionObject()).Handle;
	}
}
