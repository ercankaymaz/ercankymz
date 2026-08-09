using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiSubEntityTraitsDataSaver : OdGiSubEntityTraitsData
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiSubEntityTraitsDataSaver(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsDataSaver_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiSubEntityTraitsDataSaver obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiSubEntityTraitsDataSaver(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdGiSubEntityTraitsDataSaver()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSubEntityTraitsDataSaver__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiSubEntityTraitsDataSaver(OdGiSubEntityTraitsData from)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSubEntityTraitsDataSaver__SWIG_1(OdGiSubEntityTraitsData.getCPtr(from)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiSubEntityTraitsDataSaver(OdGiSubEntityTraitsDataSaver from)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiSubEntityTraitsDataSaver__SWIG_2(getCPtr(from)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setMapper(OdGiMapper pMapper)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsDataSaver_setMapper(swigCPtr, OdGiMapper.getCPtr(pMapper));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setLineStyleModifiers(OdGiDgLinetypeModifiers pLSMod)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsDataSaver_setLineStyleModifiers(swigCPtr, OdGiDgLinetypeModifiers.getCPtr(pLSMod));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new void setFill(OdGiFill pFill)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsDataSaver_setFill(swigCPtr, OdGiFill.getCPtr(pFill));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiSubEntityTraitsData Assign(OdGiSubEntityTraitsData data)
	{
		OdGiSubEntityTraitsData result = new OdGiSubEntityTraitsData(TD_RootIntegrated_GlobalsPINVOKE.OdGiSubEntityTraitsDataSaver_Assign(swigCPtr, OdGiSubEntityTraitsData.getCPtr(data)), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
