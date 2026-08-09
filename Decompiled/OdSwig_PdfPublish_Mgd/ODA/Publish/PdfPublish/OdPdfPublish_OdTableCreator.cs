using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdTableCreator : OdRxObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdTableCreator_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdTableCreator_1();

	public delegate void SwigDelegateOdPdfPublish_OdTableCreator_2(IntPtr pSource);

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdTableCreator_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdTableCreator_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdTableCreator_2 swigDelegate2;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdTableCreator(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdTableCreator obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdTableCreator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdTableCreator()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdTableCreator(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdTableCreator) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdTableCreator cast(OdRxObject pObj)
	{
		OdPdfPublish_OdTableCreator rXObject = Helpers.GetRXObject<OdPdfPublish_OdTableCreator>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_isASwigExplicitOdPdfPublish_OdTableCreator(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_queryXSwigExplicitOdPdfPublish_OdTableCreator(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPdfPublish_OdTableCreator createObject()
	{
		OdPdfPublish_OdTableCreator rXObject = Helpers.GetRXObject<OdPdfPublish_OdTableCreator>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool isEmpty()
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_isEmpty(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void clear()
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_clear(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isValid()
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_isValid(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setColumnCount(uint column_count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setColumnCount(swigCPtr, column_count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRowCount(uint row_count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setRowCount(swigCPtr, row_count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setParticularColumnWidth(uint col, uint column_width)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setParticularColumnWidth(swigCPtr, col, column_width);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setParticularRowHeight(uint row, uint row_height)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setParticularRowHeight(swigCPtr, row, row_height);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCellFillColor(uint row, uint column, uint fill_color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setCellFillColor(swigCPtr, row, column, fill_color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCellBorderColor(uint row, uint column, uint border_color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setCellBorderColor(swigCPtr, row, column, border_color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCellBorderThickness(uint row, uint column, OdPdfPublish_Border_Thickness border_thickness)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setCellBorderThickness(swigCPtr, row, column, (int)border_thickness);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCellBackgroundImage(uint row, uint column, OdPdfPublish_OdImage background_image)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setCellBackgroundImage(swigCPtr, row, column, OdPdfPublish_OdImage.getCPtr(background_image));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCellTilingPattern(uint row, uint column, OdPdfPublish_OdTilingPattern tiling_pattern)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_setCellTilingPattern(swigCPtr, row, column, OdPdfPublish_OdTilingPattern.getCPtr(tiling_pattern));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getColumnCount(out uint column_count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getColumnCount(swigCPtr, out column_count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getRowCount(out uint row_count)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getRowCount(swigCPtr, out row_count);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool getParticularColumnWidth(uint col, out uint column_width)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getParticularColumnWidth(swigCPtr, col, out column_width);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool getParticularRowHeight(uint row, out uint row_height)
	{
		bool result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getParticularRowHeight(swigCPtr, row, out row_height);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void getCellFillColor(uint row, uint column, out uint fill_color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getCellFillColor(swigCPtr, row, column, out fill_color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCellBorderColor(uint row, uint column, out uint border_color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getCellBorderColor(swigCPtr, row, column, out border_color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCellBorderThickness(uint row, uint column, out OdPdfPublish_Border_Thickness border_thickness)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getCellBorderThickness(swigCPtr, row, column, out border_thickness);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCellBackgroundImage(uint row, uint column, ref OdPdfPublish_OdImage background_image)
	{
		IntPtr jarg = ((background_image == null) ? IntPtr.Zero : OdPdfPublish_OdImage.getCPtr(background_image).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getCellBackgroundImage(swigCPtr, row, column, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				background_image = null;
			}
			else if (jarg != intPtr)
			{
				background_image = Helpers.GetRXObject<OdPdfPublish_OdImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getCellTilingPattern(uint row, uint column, ref OdPdfPublish_OdTilingPattern tiling_pattern)
	{
		IntPtr jarg = ((tiling_pattern == null) ? IntPtr.Zero : OdPdfPublish_OdTilingPattern.getCPtr(tiling_pattern).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getCellTilingPattern(swigCPtr, row, column, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				tiling_pattern = null;
			}
			else if (jarg != intPtr)
			{
				tiling_pattern = Helpers.GetRXObject<OdPdfPublish_OdTilingPattern>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public OdPdfPublish_OdTable createTable()
	{
		OdPdfPublish_OdTable rXObject = Helpers.GetRXObject<OdPdfPublish_OdTable>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_createTable(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTableCreator_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdTableCreator));
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
}
