using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiLayerTraits : OdGiDrawableTraits
{
	public delegate IntPtr SwigDelegateOdGiLayerTraits_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiLayerTraits_1();

	public delegate void SwigDelegateOdGiLayerTraits_2(IntPtr pSource);

	public delegate IntPtr SwigDelegateOdGiLayerTraits_3();

	public delegate int SwigDelegateOdGiLayerTraits_4();

	public delegate IntPtr SwigDelegateOdGiLayerTraits_5();

	public delegate int SwigDelegateOdGiLayerTraits_6();

	public delegate IntPtr SwigDelegateOdGiLayerTraits_7();

	public delegate IntPtr SwigDelegateOdGiLayerTraits_8();

	public delegate IntPtr SwigDelegateOdGiLayerTraits_9();

	public delegate void SwigDelegateOdGiLayerTraits_10(IntPtr color);

	public delegate void SwigDelegateOdGiLayerTraits_11(int lineweight);

	public delegate void SwigDelegateOdGiLayerTraits_12(IntPtr pLinetypeId);

	public delegate void SwigDelegateOdGiLayerTraits_13(int plotStyleNameType, IntPtr pPlotStyleNameId);

	public delegate void SwigDelegateOdGiLayerTraits_14(int plotStyleNameType);

	public delegate void SwigDelegateOdGiLayerTraits_15(IntPtr pMaterialId);

	public delegate void SwigDelegateOdGiLayerTraits_16(IntPtr transparency);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiLayerTraits_0 swigDelegate0;

	private SwigDelegateOdGiLayerTraits_1 swigDelegate1;

	private SwigDelegateOdGiLayerTraits_2 swigDelegate2;

	private SwigDelegateOdGiLayerTraits_3 swigDelegate3;

	private SwigDelegateOdGiLayerTraits_4 swigDelegate4;

	private SwigDelegateOdGiLayerTraits_5 swigDelegate5;

	private SwigDelegateOdGiLayerTraits_6 swigDelegate6;

	private SwigDelegateOdGiLayerTraits_7 swigDelegate7;

	private SwigDelegateOdGiLayerTraits_8 swigDelegate8;

	private SwigDelegateOdGiLayerTraits_9 swigDelegate9;

	private SwigDelegateOdGiLayerTraits_10 swigDelegate10;

	private SwigDelegateOdGiLayerTraits_11 swigDelegate11;

	private SwigDelegateOdGiLayerTraits_12 swigDelegate12;

	private SwigDelegateOdGiLayerTraits_13 swigDelegate13;

	private SwigDelegateOdGiLayerTraits_14 swigDelegate14;

	private SwigDelegateOdGiLayerTraits_15 swigDelegate15;

	private SwigDelegateOdGiLayerTraits_16 swigDelegate16;

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

	private static Type[] swigMethodTypes10 = new Type[1] { typeof(OdCmEntityColor) };

	private static Type[] swigMethodTypes11 = new Type[1] { typeof(LineWeight) };

	private static Type[] swigMethodTypes12 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes13 = new Type[2]
	{
		typeof(PlotStyleNameType),
		typeof(OdDbStub)
	};

	private static Type[] swigMethodTypes14 = new Type[1] { typeof(PlotStyleNameType) };

	private static Type[] swigMethodTypes15 = new Type[1] { typeof(OdDbStub) };

	private static Type[] swigMethodTypes16 = new Type[1] { typeof(OdCmTransparency) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiLayerTraits(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiLayerTraits obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiLayerTraits(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiLayerTraits cast(OdRxObject pObj)
	{
		OdGiLayerTraits rXObject = Helpers.GetRXObject<OdGiLayerTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_isASwigExplicitOdGiLayerTraits(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_queryXSwigExplicitOdGiLayerTraits(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdGiLayerTraits createObject()
	{
		OdGiLayerTraits rXObject = Helpers.GetRXObject<OdGiLayerTraits>(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdCmEntityColor color()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_color(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual LineWeight lineweight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_lineweight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public virtual OdDbStub linetype()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_linetype(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual PlotStyleNameType plotStyleNameType()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_plotStyleNameType(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (PlotStyleNameType)result;
	}

	public virtual OdDbStub plotStyleNameId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_plotStyleNameId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdDbStub materialId()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_materialId(swigCPtr);
		OdDbStub result = ((intPtr == IntPtr.Zero) ? null : new OdDbStub(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdCmTransparency transparency()
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_transparency(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual void setColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_setColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLineweight(LineWeight lineweight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_setLineweight(swigCPtr, (int)lineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setLinetype(OdDbStub pLinetypeId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_setLinetype(swigCPtr, OdDbStub.getCPtr(pLinetypeId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType, OdDbStub pPlotStyleNameId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_setPlotStyleName__SWIG_0(swigCPtr, (int)plotStyleNameType, OdDbStub.getCPtr(pPlotStyleNameId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setPlotStyleName(PlotStyleNameType plotStyleNameType)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_setPlotStyleName__SWIG_1(swigCPtr, (int)plotStyleNameType);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setMaterial(OdDbStub pMaterialId)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_setMaterial(swigCPtr, OdDbStub.getCPtr(pMaterialId));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void setTransparency(OdCmTransparency transparency)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_setTransparency(swigCPtr, OdCmTransparency.getCPtr(transparency));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdGiLayerTraits()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiLayerTraits(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiLayerTraits) != GetType();
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
		if (SwigDerivedClassHasMethod("color", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodcolor;
		}
		if (SwigDerivedClassHasMethod("lineweight", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodlineweight;
		}
		if (SwigDerivedClassHasMethod("linetype", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodlinetype;
		}
		if (SwigDerivedClassHasMethod("plotStyleNameType", swigMethodTypes6))
		{
			swigDelegate6 = SwigDirectorMethodplotStyleNameType;
		}
		if (SwigDerivedClassHasMethod("plotStyleNameId", swigMethodTypes7))
		{
			swigDelegate7 = SwigDirectorMethodplotStyleNameId;
		}
		if (SwigDerivedClassHasMethod("materialId", swigMethodTypes8))
		{
			swigDelegate8 = SwigDirectorMethodmaterialId;
		}
		if (SwigDerivedClassHasMethod("transparency", swigMethodTypes9))
		{
			swigDelegate9 = SwigDirectorMethodtransparency;
		}
		if (SwigDerivedClassHasMethod("setColor", swigMethodTypes10))
		{
			swigDelegate10 = SwigDirectorMethodsetColor;
		}
		if (SwigDerivedClassHasMethod("setLineweight", swigMethodTypes11))
		{
			swigDelegate11 = SwigDirectorMethodsetLineweight;
		}
		if (SwigDerivedClassHasMethod("setLinetype", swigMethodTypes12))
		{
			swigDelegate12 = SwigDirectorMethodsetLinetype;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes13))
		{
			swigDelegate13 = SwigDirectorMethodsetPlotStyleName__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("setPlotStyleName", swigMethodTypes14))
		{
			swigDelegate14 = SwigDirectorMethodsetPlotStyleName__SWIG_1;
		}
		if (SwigDerivedClassHasMethod("setMaterial", swigMethodTypes15))
		{
			swigDelegate15 = SwigDirectorMethodsetMaterial;
		}
		if (SwigDerivedClassHasMethod("setTransparency", swigMethodTypes16))
		{
			swigDelegate16 = SwigDirectorMethodsetTransparency;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiLayerTraits_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5, swigDelegate6, swigDelegate7, swigDelegate8, swigDelegate9, swigDelegate10, swigDelegate11, swigDelegate12, swigDelegate13, swigDelegate14, swigDelegate15, swigDelegate16);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiLayerTraits));
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

	private IntPtr SwigDirectorMethodcolor()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmEntityColor.getCPtr(color()).Handle;
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

	private int SwigDirectorMethodlineweight()
	{
		return (int)lineweight();
	}

	private IntPtr SwigDirectorMethodlinetype()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(linetype()).Handle;
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

	private int SwigDirectorMethodplotStyleNameType()
	{
		return (int)plotStyleNameType();
	}

	private IntPtr SwigDirectorMethodplotStyleNameId()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdDbStub.getCPtr(plotStyleNameId()).Handle;
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

	private IntPtr SwigDirectorMethodtransparency()
	{
		return ((Func<IntPtr>)delegate
		{
			try
			{
				return OdCmTransparency.getCPtr(transparency()).Handle;
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

	private void SwigDirectorMethodsetColor(IntPtr color)
	{
		try
		{
			setColor(new OdCmEntityColor(color, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetLineweight(int lineweight)
	{
		try
		{
			setLineweight((LineWeight)lineweight);
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

	private void SwigDirectorMethodsetLinetype(IntPtr pLinetypeId)
	{
		try
		{
			setLinetype((pLinetypeId == IntPtr.Zero) ? null : new OdDbStub(pLinetypeId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetPlotStyleName__SWIG_0(int plotStyleNameType, IntPtr pPlotStyleNameId)
	{
		try
		{
			setPlotStyleName((PlotStyleNameType)plotStyleNameType, (pPlotStyleNameId == IntPtr.Zero) ? null : new OdDbStub(pPlotStyleNameId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetPlotStyleName__SWIG_1(int plotStyleNameType)
	{
		try
		{
			setPlotStyleName((PlotStyleNameType)plotStyleNameType);
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

	private void SwigDirectorMethodsetMaterial(IntPtr pMaterialId)
	{
		try
		{
			setMaterial((pMaterialId == IntPtr.Zero) ? null : new OdDbStub(pMaterialId, cMemoryOwn: false));
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

	private void SwigDirectorMethodsetTransparency(IntPtr transparency)
	{
		try
		{
			setTransparency(new OdCmTransparency(transparency, cMemoryOwn: false));
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
