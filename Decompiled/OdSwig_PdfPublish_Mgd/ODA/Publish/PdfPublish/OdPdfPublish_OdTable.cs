using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdTable : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdTable_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdTable_1();

	public delegate void SwigDelegateOdPdfPublish_OdTable_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdTable_3();

	public delegate bool SwigDelegateOdPdfPublish_OdTable_4();

	public delegate void SwigDelegateOdPdfPublish_OdTable_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdTable_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdTable_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdTable_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdTable_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdTable_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdTable_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdTable(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdTable obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdTable(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdTable()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdTable(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdTable) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdTable cast(OdRxObject pObj)
	{
		OdPdfPublish_OdTable rXObject = Helpers.GetRXObject<OdPdfPublish_OdTable>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_isASwigExplicitOdPdfPublish_OdTable(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_queryXSwigExplicitOdPdfPublish_OdTable(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdTable createObject()
	{
		OdPdfPublish_OdTable rXObject = Helpers.GetRXObject<OdPdfPublish_OdTable>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setLink(uint row, uint column, OdPdfPublish_OdLink link)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_setLink(swigCPtr, row, column, OdPdfPublish_OdLink.getCPtr(link));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setText(uint row, uint column, OdPdfPublish_OdText text, double rotation, OdPdfPublish_Table_TextAlignment alignment)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_setText__SWIG_0(swigCPtr, row, column, OdPdfPublish_OdText.getCPtr(text), rotation, (int)alignment);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setText(uint row, uint column, OdPdfPublish_OdText text, double rotation)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_setText__SWIG_1(swigCPtr, row, column, OdPdfPublish_OdText.getCPtr(text), rotation);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setText(uint row, uint column, OdPdfPublish_OdText text)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_setText__SWIG_2(swigCPtr, row, column, OdPdfPublish_OdText.getCPtr(text));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextMargins(uint left, uint right, uint bottom, uint top)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_setTextMargins(swigCPtr, left, right, bottom, top);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setButton(uint row, uint column, OdPdfPublish_OdButton button)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_setButton(swigCPtr, row, column, OdPdfPublish_OdButton.getCPtr(button));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextField(uint row, uint column, OdPdfPublish_OdTextField text_field)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_setTextField(swigCPtr, row, column, OdPdfPublish_OdTextField.getCPtr(text_field));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getLink(uint row, uint column, ref OdPdfPublish_OdLink link)
	{
		IntPtr jarg = ((link == null) ? IntPtr.Zero : OdPdfPublish_OdLink.getCPtr(link).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_getLink(swigCPtr, row, column, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				link = null;
			}
			else if (jarg != intPtr)
			{
				link = Helpers.GetRXObject<OdPdfPublish_OdLink>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getText(uint row, uint column, ref OdPdfPublish_OdText text, out double rotation, out OdPdfPublish_Table_TextAlignment alignment)
	{
		IntPtr jarg = ((text == null) ? IntPtr.Zero : OdPdfPublish_OdText.getCPtr(text).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_getText(swigCPtr, row, column, ref jarg, out rotation, out alignment);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				text = null;
			}
			else if (jarg != intPtr)
			{
				text = Helpers.GetRXObject<OdPdfPublish_OdText>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getTextMargins(out uint left, out uint right, out uint bottom, out uint top)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_getTextMargins(swigCPtr, out left, out right, out bottom, out top);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getButton(uint row, uint column, ref OdPdfPublish_OdButton button)
	{
		IntPtr jarg = ((button == null) ? IntPtr.Zero : OdPdfPublish_OdButton.getCPtr(button).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_getButton(swigCPtr, row, column, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				button = null;
			}
			else if (jarg != intPtr)
			{
				button = Helpers.GetRXObject<OdPdfPublish_OdButton>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getTextField(uint row, uint column, ref OdPdfPublish_OdTextField text_field)
	{
		IntPtr jarg = ((text_field == null) ? IntPtr.Zero : OdPdfPublish_OdTextField.getCPtr(text_field).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_getTextField(swigCPtr, row, column, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				text_field = null;
			}
			else if (jarg != intPtr)
			{
				text_field = Helpers.GetRXObject<OdPdfPublish_OdTextField>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdTable_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdTable));
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
