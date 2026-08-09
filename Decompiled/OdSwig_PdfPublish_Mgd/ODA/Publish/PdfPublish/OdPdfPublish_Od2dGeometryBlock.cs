using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_Od2dGeometryBlock : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_Od2dGeometryBlock_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_Od2dGeometryBlock_1();

	public delegate void SwigDelegateOdPdfPublish_Od2dGeometryBlock_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_Od2dGeometryBlock_3();

	public delegate bool SwigDelegateOdPdfPublish_Od2dGeometryBlock_4();

	public delegate void SwigDelegateOdPdfPublish_Od2dGeometryBlock_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_Od2dGeometryBlock_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_Od2dGeometryBlock_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_Od2dGeometryBlock_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_Od2dGeometryBlock_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_Od2dGeometryBlock_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_Od2dGeometryBlock_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_Od2dGeometryBlock(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_Od2dGeometryBlock obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_Od2dGeometryBlock(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_Od2dGeometryBlock()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_Od2dGeometryBlock(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_Od2dGeometryBlock) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_Od2dGeometryBlock cast(OdRxObject pObj)
	{
		OdPdfPublish_Od2dGeometryBlock rXObject = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryBlock>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_isASwigExplicitOdPdfPublish_Od2dGeometryBlock(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_queryXSwigExplicitOdPdfPublish_Od2dGeometryBlock(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_Od2dGeometryBlock createObject()
	{
		OdPdfPublish_Od2dGeometryBlock rXObject = Helpers.GetRXObject<OdPdfPublish_Od2dGeometryBlock>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setOrigin(OdGePoint2d origin)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_setOrigin(swigCPtr, OdGePoint2d.getCPtr(origin));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLine(OdGePoint2dArray points)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_0(swigCPtr, OdGePoint2dArray.getCPtr(points).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLine(OdGePoint2d start, OdGePoint2d end)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_1(swigCPtr, OdGePoint2d.getCPtr(start), OdGePoint2d.getCPtr(end));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addLine(uint nPoints, OdGePoint2d pPoints)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addLine__SWIG_2(swigCPtr, nPoints, OdGePoint2d.getCPtr(pPoints));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addCircle(OdGeCircArc2d circle)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addCircle(swigCPtr, OdGeCircArc2d.getCPtr(circle));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addEllipse(OdGeEllipArc2d ellipse)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addEllipse(swigCPtr, OdGeEllipArc2d.getCPtr(ellipse));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addCurve(OdGeNurbCurve2d nurb)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addCurve(swigCPtr, OdGeNurbCurve2d.getCPtr(nurb));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void putColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_putColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void putTilingPattern(ref OdPdfPublish_OdTilingPattern pattern)
	{
		IntPtr jarg = ((pattern == null) ? IntPtr.Zero : OdPdfPublish_OdTilingPattern.getCPtr(pattern).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_putTilingPattern(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pattern = null;
			}
			else if (jarg != intPtr)
			{
				pattern = Helpers.GetRXObject<OdPdfPublish_OdTilingPattern>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void putLineWeight(double lw)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_putLineWeight(swigCPtr, lw);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void putLineCap(OdPdfPublish_Geometry_PDFLineCap lineCap)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_putLineCap(swigCPtr, (int)lineCap);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void putLineJoin(OdPdfPublish_Geometry_PDFLineJoin lineJoin)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_putLineJoin(swigCPtr, (int)lineJoin);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void putTransform(OdGeMatrix2d transform)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_putTransform(swigCPtr, OdGeMatrix2d.getCPtr(transform));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void startContour()
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_startContour(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void finishContour(OdPdfPublish_Geometry_PDFFinishRule rule)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_finishContour(swigCPtr, (int)rule);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addText(OdPdfPublish_OdText text, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addText(swigCPtr, OdPdfPublish_OdText.getCPtr(text), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addImage(OdPdfPublish_OdImage image, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addImage(swigCPtr, OdPdfPublish_OdImage.getCPtr(image), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addGeometryReference(OdPdfPublish_Od2dGeometryReference reference, OdGsDCRect location)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_addGeometryReference(swigCPtr, OdPdfPublish_Od2dGeometryReference.getCPtr(reference), OdGsDCRect.getCPtr(location));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void startLayer(ref OdPdfPublish_Od2dGeometryLayer layer)
	{
		IntPtr jarg = ((layer == null) ? IntPtr.Zero : OdPdfPublish_Od2dGeometryLayer.getCPtr(layer).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_startLayer(swigCPtr, ref jarg);
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

	public void finishLayer()
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_finishLayer(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_Od2dGeometryBlock_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_Od2dGeometryBlock));
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
