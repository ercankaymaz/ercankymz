using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_Dwf7Import;

public class TD_DWF_IMPORT_OdDwfImport : OdRxObject
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public TD_DWF_IMPORT_OdDwfImport(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_Dwf7Import_GlobalsPINVOKE.TD_DWF_IMPORT_OdDwfImport_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(TD_DWF_IMPORT_OdDwfImport obj)
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
					TD_Dwf7Import_GlobalsPINVOKE.delete_TD_DWF_IMPORT_OdDwfImport(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public virtual TD_DWF_IMPORT_OdDwfImport_ImportResult import(ref string pWarnings)
	{
		IntPtr jarg = Marshal.StringToCoTaskMemUni(pWarnings);
		IntPtr intPtr = jarg;
		try
		{
			int result = TD_Dwf7Import_GlobalsPINVOKE.TD_DWF_IMPORT_OdDwfImport_import__SWIG_0(swigCPtr, ref jarg);
			if (TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return (TD_DWF_IMPORT_OdDwfImport_ImportResult)result;
		}
		finally
		{
			if (jarg != intPtr)
			{
				pWarnings = Marshal.PtrToStringUni(jarg);
			}
		}
	}

	public virtual TD_DWF_IMPORT_OdDwfImport_ImportResult import()
	{
		int result = TD_Dwf7Import_GlobalsPINVOKE.TD_DWF_IMPORT_OdDwfImport_import__SWIG_1(swigCPtr);
		if (TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return (TD_DWF_IMPORT_OdDwfImport_ImportResult)result;
	}

	public virtual OdRxDictionary properties()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_Dwf7Import_GlobalsPINVOKE.TD_DWF_IMPORT_OdDwfImport_properties(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_Dwf7Import_GlobalsPINVOKE.TD_DWF_IMPORT_OdDwfImport_getRealClassName(ptr);
		if (TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_Dwf7Import_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
