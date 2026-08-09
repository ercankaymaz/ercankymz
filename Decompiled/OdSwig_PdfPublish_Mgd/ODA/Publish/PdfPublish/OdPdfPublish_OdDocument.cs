using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdDocument : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdDocument_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdDocument_1();

	public delegate void SwigDelegateOdPdfPublish_OdDocument_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdDocument_3();

	public delegate bool SwigDelegateOdPdfPublish_OdDocument_4();

	public delegate void SwigDelegateOdPdfPublish_OdDocument_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdDocument_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdDocument_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdDocument_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdDocument_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdDocument_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdDocument_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdDocument(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdDocument obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdDocument(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdDocument()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdDocument(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdDocument) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdDocument cast(OdRxObject pObj)
	{
		OdPdfPublish_OdDocument rXObject = Helpers.GetRXObject<OdPdfPublish_OdDocument>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_isASwigExplicitOdPdfPublish_OdDocument(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_queryXSwigExplicitOdPdfPublish_OdDocument(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdDocument createObject()
	{
		OdPdfPublish_OdDocument rXObject = Helpers.GetRXObject<OdPdfPublish_OdDocument>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setVersion(OdPDF_PDFFormatVersions version)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_setVersion(swigCPtr, (int)version);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setInformation(string title, string author, string subject, string creator)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_setInformation(swigCPtr, title, author, subject, creator);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addJavaScript(string name, string source, OdPdfPublish_Source_Type source_type)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_addJavaScript__SWIG_0(swigCPtr, name, source, (int)source_type);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addJavaScript(string name, string source)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_addJavaScript__SWIG_1(swigCPtr, name, source);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addIconImage(string name, OdPdfPublish_OdImage image)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_addIconImage(swigCPtr, name, OdPdfPublish_OdImage.getCPtr(image));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addPage(OdPdfPublish_OdPage page)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_addPage(swigCPtr, OdPdfPublish_OdPage.getCPtr(page));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addAttachment(OdPdfPublish_OdAttachedFile file)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_addAttachment(swigCPtr, OdPdfPublish_OdAttachedFile.getCPtr(file));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCollection(OdPdfPublish_OdCollection collection)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_setCollection(swigCPtr, OdPdfPublish_OdCollection.getCPtr(collection));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setUserPassword(string user_password)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_setUserPassword(swigCPtr, user_password);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setOwnerPassword(string owner_password)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_setOwnerPassword(swigCPtr, owner_password);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setAccessPermissionFlags(OdPdfPublish_AccessPermissions_AccessPermissionsFlags flags)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_setAccessPermissionFlags(swigCPtr, (int)flags);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void appendRootBookmark(OdPdfPublish_OdBookmark bookmark)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_appendRootBookmark(swigCPtr, OdPdfPublish_OdBookmark.getCPtr(bookmark));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setRootBookmarks(OdPdfPublish_OdBookmarkPtrArray bookmarks)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_setRootBookmarks(swigCPtr, OdPdfPublish_OdBookmarkPtrArray.getCPtr(bookmarks));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getVersion(out OdPDF_PDFFormatVersions version)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getVersion(swigCPtr, out version);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getInformation(ref string title, ref string author, ref string subject, ref string creator)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(title);
		IntPtr intPtr = jarg;
		IntPtr jarg2 = Marshal.StringToCoTaskMemUni(author);
		IntPtr intPtr2 = jarg2;
		IntPtr jarg3 = Marshal.StringToCoTaskMemUni(subject);
		IntPtr intPtr3 = jarg3;
		IntPtr jarg4 = Marshal.StringToCoTaskMemUni(creator);
		IntPtr intPtr4 = jarg4;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getInformation(swigCPtr, ref jarg, ref jarg2, ref jarg3, ref jarg4);
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
			if (jarg2 != intPtr2)
			{
				author = Marshal.PtrToStringUni(jarg2);
			}
			if (jarg3 != intPtr3)
			{
				subject = Marshal.PtrToStringUni(jarg3);
			}
			if (jarg4 != intPtr4)
			{
				creator = Marshal.PtrToStringUni(jarg4);
			}
		}
	}

	public void getJavaScripts(OdStringArray names, OdStringArray sources, OdPdfPublish_OdSourceTypeArray source_types)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getJavaScripts(swigCPtr, OdStringArray.getCPtr(names).Handle, OdStringArray.getCPtr(sources).Handle, OdPdfPublish_OdSourceTypeArray.getCPtr(source_types));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getIconImages(OdStringArray names, OdPdfPublish_OdImagePtrArray images)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getIconImages(swigCPtr, OdStringArray.getCPtr(names).Handle, OdPdfPublish_OdImagePtrArray.getCPtr(images));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getPages(OdPdfPublish_OdPagePtrArray pages)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getPages(swigCPtr, OdPdfPublish_OdPagePtrArray.getCPtr(pages));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getAttachments(OdPdfPublish_OdAttachedFilePtrArray files)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getAttachments(swigCPtr, OdPdfPublish_OdAttachedFilePtrArray.getCPtr(files));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getCollection(ref OdPdfPublish_OdCollection collection)
	{
		IntPtr jarg = ((collection == null) ? IntPtr.Zero : OdPdfPublish_OdCollection.getCPtr(collection).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getCollection(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				collection = null;
			}
			else if (jarg != intPtr)
			{
				collection = Helpers.GetRXObject<OdPdfPublish_OdCollection>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getUserPassword(ref string user_password)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(user_password);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getUserPassword(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				user_password = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getOwnerPassword(ref string owner_password)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(owner_password);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getOwnerPassword(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				owner_password = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public OdPdfPublish_AccessPermissions_AccessPermissionsFlags getAccessPermissionFlags()
	{
		int result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getAccessPermissionFlags(swigCPtr);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (OdPdfPublish_AccessPermissions_AccessPermissionsFlags)result;
	}

	public void getRootBookmarks(OdPdfPublish_OdBookmarkPtrArray bookmarks)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getRootBookmarks(swigCPtr, OdPdfPublish_OdBookmarkPtrArray.getCPtr(bookmarks));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setHostServices(OdDbBaseHostAppServices pHostApp)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_setHostServices(swigCPtr, OdDbBaseHostAppServices.getCPtr(pHostApp));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdDbBaseHostAppServices appServices()
	{
		OdDbBaseHostAppServices rXObject = Helpers.GetRXObject<OdDbBaseHostAppServices>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_appServices(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdDocument_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdDocument));
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
