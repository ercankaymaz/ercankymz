using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiHatchPattern : OdGiFill
{
	public delegate IntPtr SwigDelegateOdGiHatchPattern_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdGiHatchPattern_1();

	public delegate void SwigDelegateOdGiHatchPattern_2(IntPtr pSource);

	public delegate void SwigDelegateOdGiHatchPattern_3(IntPtr bytes);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdGiHatchPattern_0 swigDelegate0;

	private SwigDelegateOdGiHatchPattern_1 swigDelegate1;

	private SwigDelegateOdGiHatchPattern_2 swigDelegate2;

	private SwigDelegateOdGiHatchPattern_3 swigDelegate3;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[1] { typeof(OdUInt8Array) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiHatchPattern(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiHatchPattern obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiHatchPattern(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiHatchPattern cast(OdRxObject pObj)
	{
		OdGiHatchPattern rXObject = Helpers.GetRXObject<OdGiHatchPattern>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isASwigExplicitOdGiHatchPattern(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_queryXSwigExplicitOdGiHatchPattern(swigCPtr, OdRxClass.getCPtr(protocolClass)) : TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGiHatchPattern()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiHatchPattern(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdGiHatchPattern) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdHatchPattern patternLines()
	{
		OdHatchPattern result = new OdHatchPattern(TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_patternLines__SWIG_0(swigCPtr), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPatternLines(OdHatchPattern aHatchPattern)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setPatternLines(swigCPtr, OdHatchPattern.getCPtr(aHatchPattern));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override void copyFrom(OdRxObject pSource)
	{
		if (SwigDerivedClassHasMethod("copyFrom", swigMethodTypes2))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_copyFromSwigExplicitOdGiHatchPattern(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_copyFrom(swigCPtr, OdRxObject.getCPtr(pSource));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public override bool IsEqual(OdGiFill fill)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_IsEqual(swigCPtr, OdGiFill.getCPtr(fill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override bool IsNotEqual(OdGiFill fill)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_IsNotEqual(swigCPtr, OdGiFill.getCPtr(fill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public override void saveBytes(OdUInt8Array bytes)
	{
		if (SwigDerivedClassHasMethod("saveBytes", swigMethodTypes3))
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_saveBytesSwigExplicitOdGiHatchPattern(swigCPtr, OdUInt8Array.getCPtr(bytes).Handle);
		}
		else
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_saveBytes(swigCPtr, OdUInt8Array.getCPtr(bytes).Handle);
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDraft()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isDraft(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDraft(bool draft)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setDraft(swigCPtr, draft);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public double patternScale()
	{
		double result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_patternScale(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPatternScale(double scale)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setPatternScale(swigCPtr, scale);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isExternal()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isExternal(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setExternal(bool isExt)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setExternal(swigCPtr, isExt);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmEntityColor getPatternColor()
	{
		OdCmEntityColor result = new OdCmEntityColor(TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_getPatternColor(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPatternColor(OdCmEntityColor color)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setPatternColor(swigCPtr, OdCmEntityColor.getCPtr(color));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public LineWeight getPatternLineWeight()
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_getPatternLineWeight(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (LineWeight)result;
	}

	public void setPatternLineWeight(LineWeight lineweight)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setPatternLineWeight(swigCPtr, (int)lineweight);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdCmTransparency getPatternTransparency()
	{
		OdCmTransparency result = new OdCmTransparency(TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_getPatternTransparency(swigCPtr), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setPatternTransparency(OdCmTransparency transparency)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setPatternTransparency(swigCPtr, OdCmTransparency.getCPtr(transparency));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiHatchPattern getNext()
	{
		OdGiHatchPattern rXObject = Helpers.GetRXObject<OdGiHatchPattern>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_getNext(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setNext(OdGiHatchPattern pNext)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setNext(swigCPtr, getCPtr(pNext));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isAlignedToCenter()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isAlignedToCenter(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setAlignedToCenter(bool aligned)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setAlignedToCenter(swigCPtr, aligned);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setEmpty(bool empty)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setEmpty(swigCPtr, empty);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isSolid()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isSolid(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setSolid(bool solid)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setSolid(swigCPtr, solid);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDisabledBackgroundFill()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isDisabledBackgroundFill(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDisabledBackgroundFill(bool disabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setDisabledBackgroundFill(swigCPtr, disabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDisabledTransparency()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isDisabledTransparency(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDisabledTransparency(bool disabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setDisabledTransparency(swigCPtr, disabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isDisabledBoundary()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_isDisabledBoundary(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setDisabledBoundary(bool disabled)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_setDisabledBoundary(swigCPtr, disabled);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public new static OdGiHatchPattern createObject()
	{
		OdGiHatchPattern rXObject = Helpers.GetRXObject<OdGiHatchPattern>(TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		if (SwigDerivedClassHasMethod("saveBytes", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodsaveBytes;
		}
		TD_RootIntegrated_GlobalsPINVOKE.OdGiHatchPattern_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdGiHatchPattern));
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

	private void SwigDirectorMethodsaveBytes(IntPtr bytes)
	{
		try
		{
			saveBytes(new OdUInt8Array(bytes, cMemoryOwn: true));
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
