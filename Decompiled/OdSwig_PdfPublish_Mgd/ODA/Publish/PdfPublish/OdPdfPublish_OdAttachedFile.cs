using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Publish.PdfPublish;

public class OdPdfPublish_OdAttachedFile : OdPdfPublish_OdObject
{
	public delegate IntPtr SwigDelegateOdPdfPublish_OdAttachedFile_0(IntPtr protocolClass);

	public delegate IntPtr SwigDelegateOdPdfPublish_OdAttachedFile_1();

	public delegate void SwigDelegateOdPdfPublish_OdAttachedFile_2(IntPtr pSource);

	public delegate bool SwigDelegateOdPdfPublish_OdAttachedFile_3();

	public delegate bool SwigDelegateOdPdfPublish_OdAttachedFile_4();

	public delegate void SwigDelegateOdPdfPublish_OdAttachedFile_5();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdPdfPublish_OdAttachedFile_0 swigDelegate0;

	private SwigDelegateOdPdfPublish_OdAttachedFile_1 swigDelegate1;

	private SwigDelegateOdPdfPublish_OdAttachedFile_2 swigDelegate2;

	private SwigDelegateOdPdfPublish_OdAttachedFile_3 swigDelegate3;

	private SwigDelegateOdPdfPublish_OdAttachedFile_4 swigDelegate4;

	private SwigDelegateOdPdfPublish_OdAttachedFile_5 swigDelegate5;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdRxClass) };

	private static Type[] swigMethodTypes1 = new Type[0];

	private static Type[] swigMethodTypes2 = new Type[1] { typeof(OdRxObject) };

	private static Type[] swigMethodTypes3 = new Type[0];

	private static Type[] swigMethodTypes4 = new Type[0];

	private static Type[] swigMethodTypes5 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdPdfPublish_OdAttachedFile(IntPtr cPtr, bool cMemoryOwn)
		: base(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPdfPublish_OdAttachedFile obj)
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
					PdfPublish_GlobalsPINVOKE.delete_OdPdfPublish_OdAttachedFile(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	protected OdPdfPublish_OdAttachedFile()
		: this(PdfPublish_GlobalsPINVOKE.new_OdPdfPublish_OdAttachedFile(), cMemoryOwn: true)
	{
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdPdfPublish_OdAttachedFile) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public new static OdPdfPublish_OdAttachedFile cast(OdRxObject pObj)
	{
		OdPdfPublish_OdAttachedFile rXObject = Helpers.GetRXObject<OdPdfPublish_OdAttachedFile>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_desc(), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(SwigDerivedClassHasMethod("isA", swigMethodTypes1) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_isASwigExplicitOdPdfPublish_OdAttachedFile(swigCPtr) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(SwigDerivedClassHasMethod("queryX", swigMethodTypes0) ? PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_queryXSwigExplicitOdPdfPublish_OdAttachedFile(swigCPtr, OdRxClass.getCPtr(protocolClass)) : PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdPdfPublish_OdAttachedFile createObject()
	{
		OdPdfPublish_OdAttachedFile rXObject = Helpers.GetRXObject<OdPdfPublish_OdAttachedFile>(PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setName(string name)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_setName(swigCPtr, name);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setDescription(string description)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_setDescription(swigCPtr, description);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCreationDate(OdTimeStamp creation_date)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_setCreationDate(swigCPtr, OdTimeStamp.getCPtr(creation_date));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setModDate(OdTimeStamp mod_date)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_setModDate(swigCPtr, OdTimeStamp.getCPtr(mod_date));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setThumb(OdPdfPublish_OdImage pImage)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_setThumb(swigCPtr, OdPdfPublish_OdImage.getCPtr(pImage));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addTextCollectionItem(string name, string item)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_addTextCollectionItem(swigCPtr, name, item);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addDateCollectionItem(string name, OdTimeStamp date)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_addDateCollectionItem(swigCPtr, name, OdTimeStamp.getCPtr(date));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addNumberCollectionItem(string name, double number)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_addNumberCollectionItem(swigCPtr, name, number);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFile(string filename)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_setFile(swigCPtr, filename);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setFileStream(ref OdStreamBuf file)
	{
		IntPtr jarg = ((file == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(file).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_setFileStream(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				file = null;
			}
			else if (jarg != intPtr)
			{
				file = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getName(ref string name)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(name);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getName(swigCPtr, ref jarg);
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

	public void getDescription(ref string description)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(description);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getDescription(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				description = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getCreationDate(OdTimeStamp creation_date)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getCreationDate(swigCPtr, OdTimeStamp.getCPtr(creation_date));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getModDate(OdTimeStamp mod_date)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getModDate(swigCPtr, OdTimeStamp.getCPtr(mod_date));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getThumb(ref OdPdfPublish_OdImage pOutImage)
	{
		IntPtr jarg = ((pOutImage == null) ? IntPtr.Zero : OdPdfPublish_OdImage.getCPtr(pOutImage).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getThumb(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				pOutImage = null;
			}
			else if (jarg != intPtr)
			{
				pOutImage = Helpers.GetRXObject<OdPdfPublish_OdImage>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	public void getTextCollectionItems(OdStringArray names, OdStringArray items)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getTextCollectionItems(swigCPtr, OdStringArray.getCPtr(names).Handle, OdStringArray.getCPtr(items).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getDateCollectionItems(OdStringArray names, OdArray_OdTimeStamp_OdObjectsAllocator dates)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getDateCollectionItems(swigCPtr, OdStringArray.getCPtr(names).Handle, OdArray_OdTimeStamp_OdObjectsAllocator.getCPtr(dates));
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getNumberCollectionItems(OdStringArray names, OdDoubleArray numbers)
	{
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getNumberCollectionItems(swigCPtr, OdStringArray.getCPtr(names).Handle, OdDoubleArray.getCPtr(numbers).Handle);
		if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getFile(ref string out_filename)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(out_filename);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getFile(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg != intPtr)
			{
				out_filename = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public void getFileStream(ref OdStreamBuf file)
	{
		IntPtr jarg = ((file == null) ? IntPtr.Zero : OdStreamBuf.getCPtr(file).Handle);
		IntPtr intPtr = jarg;
		try
		{
			PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getFileStream(swigCPtr, ref jarg);
			if (PdfPublish_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw PdfPublish_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}
		finally
		{
			if (jarg == IntPtr.Zero)
			{
				file = null;
			}
			else if (jarg != intPtr)
			{
				file = Helpers.GetRXObject<OdStreamBuf>(jarg, bOwn: true, bTryAddToTransaction: true);
			}
		}
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_getRealClassName(ptr);
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
		PdfPublish_GlobalsPINVOKE.OdPdfPublish_OdAttachedFile_director_connect(swigCPtr, swigDelegate0, swigDelegate1, swigDelegate2, swigDelegate3, swigDelegate4, swigDelegate5);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdPdfPublish_OdAttachedFile));
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
