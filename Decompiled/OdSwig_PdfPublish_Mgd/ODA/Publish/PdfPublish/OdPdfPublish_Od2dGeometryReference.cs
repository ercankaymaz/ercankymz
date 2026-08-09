using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_Od2dGeometryReference : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_Od2dGeometryReference_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_Od2dGeometryReference_1();

	public delegate void SwigDelegateOdPdfPublish_Od2dGeometryReference_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_Od2dGeometryReference_3();

	public delegate bool SwigDelegateOdPdfPublish_Od2dGeometryReference_4();

	public delegate void SwigDelegateOdPdfPublish_Od2dGeometryReference_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_Od2dGeometryReference_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_Od2dGeometryReference_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_Od2dGeometryReference_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_Od2dGeometryReference_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_Od2dGeometryReference_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_Od2dGeometryReference_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_Od2dGeometryReference(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_Od2dGeometryReference obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_Od2dGeometryReference(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_Od2dGeometryReference()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_Od2dGeometryReference(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_Od2dGeometryReference) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_Od2dGeometryReference cast(OdRxObject pObj)
	{
		OdPdfPublish_Od2dGeometryReference rXObject = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryReference>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_isASwigExplicitOdPdfPublish_Od2dGeometryReference(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_queryXSwigExplicitOdPdfPublish_Od2dGeometryReference(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_Od2dGeometryReference createObject()
	{
		OdPdfPublish_Od2dGeometryReference rXObject = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryReference>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setBorder(bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setBorder(swigCPtr, state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBorderColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setBorderColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorder(out bool state)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getBorder(swigCPtr, out state);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getBorderColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getBorderColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTransform(OdGeMatrix2d xfm)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setTransform(swigCPtr, OdGeMatrix2d.getCPtr(xfm));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTransform(OdGeMatrix2d xfm)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getTransform(swigCPtr, OdGeMatrix2d.getCPtr(xfm));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setGeometryBlock(OdPdfPublish_Od2dGeometryBlock block)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setGeometryBlock(swigCPtr, OdPdfPublish_Od2dGeometryBlock.getCPtr(block));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getGeometryBlock(ref OdPdfPublish_Od2dGeometryBlock block)
	{
		IntPtr jarg = ((block == null) ? IntPtr.Zero : OdPdfPublish_Od2dGeometryBlock.getCPtr(block).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getGeometryBlock(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				block = null;
			}
			else if (jarg != intPtr)
			{
				block = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryBlock>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void setScale(double scale)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setScale(swigCPtr, scale);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getScale(out double scale)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getScale(swigCPtr, out scale);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRotation(double rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setRotation__SWIG_0(swigCPtr, rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRotation()
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setRotation__SWIG_1(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getRotation(out double rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getRotation(swigCPtr, out rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTranslation(OdGeVector2d vec)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setTranslation(swigCPtr, OdGeVector2d.getCPtr(vec).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTranslation(OdGeVector2d vec)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getTranslation(swigCPtr, OdGeVector2d.getCPtr(vec).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setLayer(OdPdfPublish_Od2dGeometryLayer layer)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_setLayer(swigCPtr, OdPdfPublish_Od2dGeometryLayer.getCPtr(layer));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLayer(ref OdPdfPublish_Od2dGeometryLayer layer)
	{
		IntPtr jarg = ((layer == null) ? IntPtr.Zero : OdPdfPublish_Od2dGeometryLayer.getCPtr(layer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getLayer(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				layer = null;
			}
			else if (jarg != intPtr)
			{
				layer = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryLayer>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryReference_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_Od2dGeometryReference));
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
