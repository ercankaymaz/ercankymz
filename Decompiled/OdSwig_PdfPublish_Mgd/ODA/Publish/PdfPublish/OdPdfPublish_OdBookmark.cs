using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdBookmark : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdBookmark_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdBookmark_1();

	public delegate void SwigDelegateOdPdfPublish_OdBookmark_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdBookmark_3();

	public delegate bool SwigDelegateOdPdfPublish_OdBookmark_4();

	public delegate void SwigDelegateOdPdfPublish_OdBookmark_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdBookmark_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdBookmark_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdBookmark_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdBookmark_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdBookmark_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdBookmark_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdBookmark(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdBookmark obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdBookmark(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdBookmark()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdBookmark(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdBookmark) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdBookmark cast(OdRxObject pObj)
	{
		OdPdfPublish_OdBookmark rXObject = Helpers.GetRXObject<OdPdfPublish_OdBookmark>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_isASwigExplicitOdPdfPublish_OdBookmark(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_queryXSwigExplicitOdPdfPublish_OdBookmark(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdBookmark createObject()
	{
		OdPdfPublish_OdBookmark rXObject = Helpers.GetRXObject<OdPdfPublish_OdBookmark>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setTitle(string title)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_setTitle(swigCPtr, title);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setPage(OdPdfPublish_OdPage page)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_setPage(swigCPtr, OdPdfPublish_OdPage.getCPtr(page));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setBookmarkType(OdPdfPublish_Bookmarks_BookmarkType type)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_setBookmarkType(swigCPtr, (int)type);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextStyle(OdPdfPublish_Text_FontStyle style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_setTextStyle(swigCPtr, (int)style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setTextColor(uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_setTextColor(swigCPtr, color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendChild(OdPdfPublish_OdBookmark child)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_appendChild(swigCPtr, getCPtr(child));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setChildren(OdPdfPublish_OdBookmarkPtrArray children)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_setChildren(swigCPtr, OdPdfPublish_OdBookmarkPtrArray.getCPtr(children));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setParametrs(OdDoubleValuesArray params_)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_setParametrs(swigCPtr, OdDoubleValuesArray.getCPtr(params_));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTitle(ref string title)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(title);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_getTitle(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				title = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getPage(ref OdPdfPublish_OdPage page)
	{
		IntPtr jarg = ((page == null) ? IntPtr.Zero : OdPdfPublish_OdPage.getCPtr(page).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_getPage(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				page = null;
			}
			else if (jarg != intPtr)
			{
				page = Helpers.GetRXObject<OdPdfPublish_OdPage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getBookmarkType(out OdPdfPublish_Bookmarks_BookmarkType type)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_getBookmarkType(swigCPtr, out type);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextStyle(out OdPdfPublish_Text_FontStyle style)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_getTextStyle(swigCPtr, out style);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getTextColor(out uint color)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_getTextColor(swigCPtr, out color);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getChildren(OdPdfPublish_OdBookmarkPtrArray children)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_getChildren(swigCPtr, OdPdfPublish_OdBookmarkPtrArray.getCPtr(children));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getParametrs(OdDoubleValuesArray params_)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_getParametrs(swigCPtr, OdDoubleValuesArray.getCPtr(params_));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdBookmark_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdBookmark));
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
