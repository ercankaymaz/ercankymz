using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_Dwf7Import;

public class TD_DWF_IMPORT_OdDwfImportModule : OdRxModule
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_DWF_IMPORT_OdDwfImportModule(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_Dwf7Import_GlobalsPINVOKE.TD_DWF_IMPORT_OdDwfImportModule_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_DWF_IMPORT_OdDwfImportModule obj)
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
					TD_Dwf7Import_GlobalsPINVOKE.delete_TD_DWF_IMPORT_OdDwfImportModule(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual TD_DWF_IMPORT_OdDwfImport create()
	{
		TD_DWF_IMPORT_OdDwfImport rXObject = Helpers.GetRXObject<TD_DWF_IMPORT_OdDwfImport>(TD_Dwf7Import_GlobalsPINVOKE.TD_DWF_IMPORT_OdDwfImportModule_create(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_Dwf7Import_GlobalsPINVOKE.TD_DWF_IMPORT_OdDwfImportModule_getRealClassName(ptr);
		if (TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
