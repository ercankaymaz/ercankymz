using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdCADReference : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdCADReference_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdCADReference_1();

	public delegate void SwigDelegateOdPdfPublish_OdCADReference_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdCADReference_3();

	public delegate bool SwigDelegateOdPdfPublish_OdCADReference_4();

	public delegate void SwigDelegateOdPdfPublish_OdCADReference_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdCADReference_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdCADReference_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdCADReference_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdCADReference_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdCADReference_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdCADReference_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdCADReference(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdCADReference obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdCADReference(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdCADReference()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdCADReference(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdCADReference) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdCADReference cast(OdRxObject pObj)
	{
		OdPdfPublish_OdCADReference rXObject = Helpers.GetRXObject<OdPdfPublish_OdCADReference>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_isASwigExplicitOdPdfPublish_OdCADReference(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_queryXSwigExplicitOdPdfPublish_OdCADReference(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdCADReference createObject()
	{
		OdPdfPublish_OdCADReference rXObject = Helpers.GetRXObject<OdPdfPublish_OdCADReference>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setCADDefinition(OdPdfPublish_OdCADDefinition cad_definition)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setCADDefinition(swigCPtr, OdPdfPublish_OdCADDefinition.getCPtr(cad_definition));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorder(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setBorder(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setBorderColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderWidth(ushort width)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setBorderWidth(swigCPtr, width);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRotation(double rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setRotation(swigCPtr, rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setClipBoundary(OdPdfPublish_Page_PaperUnits units, OdGePoint2dArray clipBoundary)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setClipBoundary(swigCPtr, (int)units, OdGePoint2dArray.getCPtr(clipBoundary).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setClipBoundaryBorder(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setClipBoundaryBorder(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setClipBoundaryBorderColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setClipBoundaryBorderColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setClipBoundaryBorderWidth(ushort width)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setClipBoundaryBorderWidth(swigCPtr, width);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransform(OdGeMatrix2d xfm)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setTransform(swigCPtr, OdGeMatrix2d.getCPtr(xfm));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setScale(double scale)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setScale(swigCPtr, scale);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTranslation(OdGeVector2d vec)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setTranslation(swigCPtr, OdGeVector2d.getCPtr(vec).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setEnableBookmarks(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setEnableBookmarks(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCADReferenceName(string name)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_setCADReferenceName(swigCPtr, name);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCADDefinition(ref OdPdfPublish_OdCADDefinition cad_definition)
	{
		IntPtr jarg = ((cad_definition == null) ? IntPtr.Zero : OdPdfPublish_OdCADDefinition.getCPtr(cad_definition).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getCADDefinition(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				cad_definition = null;
			}
			else if (jarg != intPtr)
			{
				cad_definition = Helpers.GetRXObject<OdPdfPublish_OdCADDefinition>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getBorder(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getBorder(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getBorderColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderWidth(out ushort width)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getBorderWidth(swigCPtr, out width);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getRotation(out double rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getRotation(swigCPtr, out rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClipBoundary(out OdPdfPublish_Page_PaperUnits units, OdGePoint2dArray clipBoundary)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getClipBoundary(swigCPtr, out units, OdGePoint2dArray.getCPtr(clipBoundary).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClipBoundaryBorder(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getClipBoundaryBorder(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClipBoundaryBorderColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getClipBoundaryBorderColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getClipBoundaryBorderWidth(out ushort width)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getClipBoundaryBorderWidth(swigCPtr, out width);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTransform(OdGeMatrix2d xfm)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getTransform(swigCPtr, OdGeMatrix2d.getCPtr(xfm));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getScale(out double scale)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getScale(swigCPtr, out scale);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTranslation(OdGeVector2d vec)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getTranslation(swigCPtr, OdGeVector2d.getCPtr(vec).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getEnableBookmarks(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getEnableBookmarks(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCADReferenceName(ref string name)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(name);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getCADReferenceName(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				name = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_getRealClassName(ptr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
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
		if (SwigDerivedClassHasMethod("isEmpty", swigMethodTypes3))
		{
			swigDelegate3 = SwigDirectorMethodisEmpty;
		}
		if (SwigDerivedClassHasMethod("isValid", swigMethodTypes4))
		{
			swigDelegate4 = SwigDirectorMethodisValid;
		}
		if (SwigDerivedClassHasMethod("clear", swigMethodTypes5))
		{
			swigDelegate5 = SwigDirectorMethodclear;
		}
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdCADReference_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdCADReference));
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
			PdfPublish_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PdfPublish_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PdfPublish_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PdfPublish_Globals.throw_native_exception_string(ex.ToString());
		}
	}

	private bool SwigDirectorMethodisEmpty()
	{
		return isEmpty();
	}

	private bool SwigDirectorMethodisValid()
	{
		return isValid();
	}

	private void SwigDirectorMethodclear()
	{
		try
		{
			clear();
		}
		catch (OdEdEmptyInput err)
		{
			PdfPublish_Globals.throw_native_OdError(err);
		}
		catch (OdEdOtherInput err2)
		{
			PdfPublish_Globals.throw_native_OdError(err2);
		}
		catch (OdError err3)
		{
			PdfPublish_Globals.throw_native_OdError(err3);
		}
		catch (Exception ex)
		{
			PdfPublish_Globals.throw_native_exception_string(ex.ToString());
		}
	}
}
