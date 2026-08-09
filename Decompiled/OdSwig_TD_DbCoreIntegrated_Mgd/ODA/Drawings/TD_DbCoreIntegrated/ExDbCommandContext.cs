using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class ExDbCommandContext : OdDbCommandContext
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ExDbCommandContext(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(ExDbCommandContext obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_ExDbCommandContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public static OdDbCommandContext createObject(OdEdBaseIO pIOStream, OdDbDatabase pDb)
	{
		OdDbCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_createObject__SWIG_0(OdEdBaseIO.getCPtr(pIOStream), OdDbDatabase.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbCommandContext createObject(OdEdBaseIO pIOStream, OdRxObject pRxDb)
	{
		OdDbCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_createObject__SWIG_1(OdEdBaseIO.getCPtr(pIOStream), OdRxObject.getCPtr(pRxDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdDbCommandContext createObject(OdEdBaseIO pIOStream)
	{
		OdDbCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_createObject__SWIG_2(OdEdBaseIO.getCPtr(pIOStream)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdRxObject baseDatabase()
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_baseDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void reset(OdEdBaseIO pIOStream, OdRxObject pRxDb)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_reset(swigCPtr, OdEdBaseIO.getCPtr(pIOStream), OdRxObject.getCPtr(pRxDb));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdEdBaseIO baseIO()
	{
		OdEdBaseIO rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdBaseIO>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_baseIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdEdCommandContext cloneObject(OdEdBaseIO pIOStream, OdRxObject pRxDb)
	{
		OdEdCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_cloneObject__SWIG_0(swigCPtr, OdEdBaseIO.getCPtr(pIOStream), OdRxObject.getCPtr(pRxDb)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdEdCommandContext cloneObject(OdEdBaseIO pIOStream)
	{
		OdEdCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_cloneObject__SWIG_1(swigCPtr, OdEdBaseIO.getCPtr(pIOStream)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdEdCommandContext cloneObject()
	{
		OdEdCommandContext rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdCommandContext>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_cloneObject__SWIG_2(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdEdUserIO userIO()
	{
		OdEdUserIO rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdUserIO>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_userIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdEdFunctionIO funcIO()
	{
		OdEdFunctionIO rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdFunctionIO>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_funcIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setParam(OdRxObject pParamObj)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_setParam(swigCPtr, OdRxObject.getCPtr(pParamObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject param()
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_param(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setResult(OdRxObject pResultObj)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_setResult(swigCPtr, OdRxObject.getCPtr(pResultObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject result()
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_result(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void setArbitraryData(string fileName, OdRxObject pDataObj)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_setArbitraryData(swigCPtr, fileName, OdRxObject.getCPtr(pDataObj));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdRxObject arbitraryData(string fileName)
	{
		OdRxObject rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdRxObject>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_arbitraryData(swigCPtr, fileName), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet pickfirst()
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_pickfirst(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setPickfirst(OdSelectionSet pSSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_setPickfirst(swigCPtr, OdSelectionSet.getCPtr(pSSet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdSelectionSet previousSelection()
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_previousSelection(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setPreviousSelection(OdSelectionSet pSSet)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_setPreviousSelection(swigCPtr, OdSelectionSet.getCPtr(pSSet));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdUnitsFormatter baseFormatter()
	{
		OdUnitsFormatter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdUnitsFormatter>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_baseFormatter(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdDbUnitsFormatter formatter()
	{
		OdDbUnitsFormatter rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbUnitsFormatter>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_formatter(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void putString(string string_)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_putString(swigCPtr, string_);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getInt(string prompt, int options, int defVal, string keywords, OdEdIntegerTracker pTracker)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getInt__SWIG_0(swigCPtr, prompt, options, defVal, keywords, OdEdIntegerTracker.getCPtr(pTracker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual int getInt(string prompt, int options, int defVal, string keywords)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getInt__SWIG_1(swigCPtr, prompt, options, defVal, keywords);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual int getInt(string prompt, int options, int defVal)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getInt__SWIG_2(swigCPtr, prompt, options, defVal);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual int getInt(string prompt, int options)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getInt__SWIG_3(swigCPtr, prompt, options);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual int getInt(string prompt)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getInt__SWIG_4(swigCPtr, prompt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getReal(string prompt, int options, double defVal, string keywordList, OdEdRealTracker pTracker)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getReal__SWIG_1(swigCPtr, prompt, options, defVal, keywordList, OdEdRealTracker.getCPtr(pTracker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getReal(string prompt, int options, double defVal, string keywordList)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getReal__SWIG_2(swigCPtr, prompt, options, defVal, keywordList);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getReal(string prompt, int options, double defVal)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getReal__SWIG_3(swigCPtr, prompt, options, defVal);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getReal(string prompt, int options)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getReal__SWIG_4(swigCPtr, prompt, options);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getReal(string prompt)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getReal__SWIG_5(swigCPtr, prompt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual string getString(string prompt, int options, string pDefVal, string keywords, OdEdStringTracker pTracker)
	{
		string text = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getString__SWIG_0(swigCPtr, prompt, options, pDefVal, keywords, OdEdStringTracker.getCPtr(pTracker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual string getString(string prompt, int options, string pDefVal, string keywords)
	{
		string text = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getString__SWIG_1(swigCPtr, prompt, options, pDefVal, keywords);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual string getString(string prompt, int options, string pDefVal)
	{
		string text = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getString__SWIG_2(swigCPtr, prompt, options, pDefVal);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual string getString(string prompt, int options)
	{
		string text = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getString__SWIG_3(swigCPtr, prompt, options);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual string getString(string prompt)
	{
		string text = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getString__SWIG_4(swigCPtr, prompt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual int getKeyword(string prompt, string keywords, int defRes, int options, OdEdIntegerTracker pTracker)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getKeyword__SWIG_0(swigCPtr, prompt, keywords, defRes, options, OdEdIntegerTracker.getCPtr(pTracker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual int getKeyword(string prompt, string keywords, int defRes, int options)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getKeyword__SWIG_1(swigCPtr, prompt, keywords, defRes, options);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual int getKeyword(string prompt, string keywords, int defRes)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getKeyword__SWIG_2(swigCPtr, prompt, keywords, defRes);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual int getKeyword(string prompt, string keywords)
	{
		int num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getKeyword__SWIG_3(swigCPtr, prompt, keywords);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getAngle(string prompt, int options, double defVal, string keywords, OdEdRealTracker pTracker)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getAngle__SWIG_0(swigCPtr, prompt, options, defVal, keywords, OdEdRealTracker.getCPtr(pTracker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getAngle(string prompt, int options, double defVal, string keywords)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getAngle__SWIG_1(swigCPtr, prompt, options, defVal, keywords);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getAngle(string prompt, int options, double defVal)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getAngle__SWIG_2(swigCPtr, prompt, options, defVal);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getAngle(string prompt, int options)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getAngle__SWIG_3(swigCPtr, prompt, options);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getAngle(string prompt)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getAngle__SWIG_4(swigCPtr, prompt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual OdGePoint3d getLASTPOINT()
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getLASTPOINT(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odGePoint3d;
	}

	public virtual void setLASTPOINT(OdGePoint3d val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_setLASTPOINT(swigCPtr, OdGePoint3d.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdEdPointDefTracker createRubberBand(OdGePoint3d base_, OdGsModel pModel)
	{
		OdEdPointDefTracker rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdPointDefTracker>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_createRubberBand__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(base_), OdGsModel.getCPtr(pModel)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRubberBand(OdGePoint3d base_)
	{
		OdEdPointDefTracker rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdPointDefTracker>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_createRubberBand__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(base_)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRectFrame(OdGePoint3d base_, OdGsModel pModel)
	{
		OdEdPointDefTracker rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdPointDefTracker>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_createRectFrame__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(base_), OdGsModel.getCPtr(pModel)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRectFrame(OdGePoint3d base_)
	{
		OdEdPointDefTracker rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdEdPointDefTracker>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_createRectFrame__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(base_)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options, OdGePoint3d pDefVal, string keywords, OdEdPointTracker arg4)
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getPoint__SWIG_0(swigCPtr, prompt, options, OdGePoint3d.getCPtr(pDefVal), keywords, OdEdPointTracker.getCPtr(arg4)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odGePoint3d;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options, OdGePoint3d pDefVal, string keywords)
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getPoint__SWIG_1(swigCPtr, prompt, options, OdGePoint3d.getCPtr(pDefVal), keywords), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odGePoint3d;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options, OdGePoint3d pDefVal)
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getPoint__SWIG_2(swigCPtr, prompt, options, OdGePoint3d.getCPtr(pDefVal)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odGePoint3d;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options)
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getPoint__SWIG_3(swigCPtr, prompt, options), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odGePoint3d;
	}

	public virtual OdGePoint3d getPoint(string prompt)
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getPoint__SWIG_4(swigCPtr, prompt), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odGePoint3d;
	}

	public virtual double getDist(string prompt, int options, double defVal, string keywords, OdEdRealTracker pTracker)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getDist__SWIG_0(swigCPtr, prompt, options, defVal, keywords, OdEdRealTracker.getCPtr(pTracker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getDist(string prompt, int options, double defVal, string keywords)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getDist__SWIG_1(swigCPtr, prompt, options, defVal, keywords);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getDist(string prompt, int options, double defVal)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getDist__SWIG_2(swigCPtr, prompt, options, defVal);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getDist(string prompt, int options)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getDist__SWIG_3(swigCPtr, prompt, options);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getDist(string prompt)
	{
		double num = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getDist__SWIG_4(swigCPtr, prompt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt, string fileName, string filter, string keywords, OdEdStringTracker pTracker)
	{
		string text = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getFilePath__SWIG_0(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter, keywords, OdEdStringTracker.getCPtr(pTracker));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt, string fileName, string filter, string keywords)
	{
		string text = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getFilePath__SWIG_1(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter, keywords);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt, string fileName, string filter)
	{
		string text = TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getFilePath__SWIG_2(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual OdCmColorBase getCmColor(string sPrompt, int options, OdCmColorBase pDefVal, string sKeywords, OdEdColorTracker pTracker)
	{
		OdCmColorBase odCmColorBase = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getCmColor__SWIG_0(swigCPtr, sPrompt, options, OdCmColorBase.getCPtr(pDefVal), sKeywords, OdEdColorTracker.getCPtr(pTracker)), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColorBase;
	}

	public virtual OdCmColorBase getCmColor(string sPrompt, int options, OdCmColorBase pDefVal, string sKeywords)
	{
		OdCmColorBase odCmColorBase = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getCmColor__SWIG_1(swigCPtr, sPrompt, options, OdCmColorBase.getCPtr(pDefVal), sKeywords), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColorBase;
	}

	public virtual OdCmColorBase getCmColor(string sPrompt, int options, OdCmColorBase pDefVal)
	{
		OdCmColorBase odCmColorBase = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getCmColor__SWIG_2(swigCPtr, sPrompt, options, OdCmColorBase.getCPtr(pDefVal)), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColorBase;
	}

	public virtual OdCmColorBase getCmColor(string sPrompt, int options)
	{
		OdCmColorBase odCmColorBase = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getCmColor__SWIG_3(swigCPtr, sPrompt, options), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColorBase;
	}

	public virtual OdCmColorBase getCmColor(string sPrompt)
	{
		OdCmColorBase odCmColorBase = ODA.Kernel.TD_RootIntegrated.Helpers.GetObject<OdCmColorBase>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getCmColor__SWIG_4(swigCPtr, sPrompt), bOwn: true, bTryAddToTransaction: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColorBase;
	}

	public virtual OdCmColor getColor(string prompt, int options, OdCmColor pDefVal, string keywordList, OdEdColorTracker pTracker)
	{
		OdCmColor odCmColor = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getColor__SWIG_0(swigCPtr, prompt, options, OdCmColor.getCPtr(pDefVal), keywordList, OdEdColorTracker.getCPtr(pTracker)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColor;
	}

	public virtual OdCmColor getColor(string prompt, int options, OdCmColor pDefVal, string keywordList)
	{
		OdCmColor odCmColor = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getColor__SWIG_1(swigCPtr, prompt, options, OdCmColor.getCPtr(pDefVal), keywordList), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColor;
	}

	public virtual OdCmColor getColor(string prompt, int options, OdCmColor pDefVal)
	{
		OdCmColor odCmColor = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getColor__SWIG_2(swigCPtr, prompt, options, OdCmColor.getCPtr(pDefVal)), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColor;
	}

	public virtual OdCmColor getColor(string prompt, int options)
	{
		OdCmColor odCmColor = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getColor__SWIG_3(swigCPtr, prompt, options), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColor;
	}

	public virtual OdCmColor getColor(string prompt)
	{
		OdCmColor odCmColor = new OdCmColor(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_getColor__SWIG_4(swigCPtr, prompt), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColor;
	}

	public virtual OdSelectionSet select(string prompt, int options, OdSelectionSet pDefVal, string keywords, OdSSetTracker pTracker, OdGePoint3dArray ptsPointer)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_select__SWIG_0(swigCPtr, prompt, options, OdSelectionSet.getCPtr(pDefVal), keywords, OdSSetTracker.getCPtr(pTracker), OdGePoint3dArray.getCPtr(ptsPointer).Handle), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt, int options, OdSelectionSet pDefVal, string keywords, OdSSetTracker pTracker)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_select__SWIG_1(swigCPtr, prompt, options, OdSelectionSet.getCPtr(pDefVal), keywords, OdSSetTracker.getCPtr(pTracker)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt, int options, OdSelectionSet pDefVal, string keywords)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_select__SWIG_2(swigCPtr, prompt, options, OdSelectionSet.getCPtr(pDefVal), keywords), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt, int options, OdSelectionSet pDefVal)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_select__SWIG_3(swigCPtr, prompt, options, OdSelectionSet.getCPtr(pDefVal)), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt, int options)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_select__SWIG_4(swigCPtr, prompt, options), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select(string prompt)
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_select__SWIG_5(swigCPtr, prompt), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet select()
	{
		OdSelectionSet rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdSelectionSet>(TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_select__SWIG_6(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void highlight(OdSelectionSetIterator pIter, bool bDoIt)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_highlight__SWIG_2(swigCPtr, OdSelectionSetIterator.getCPtr(pIter), bDoIt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdSelectionSetIterator pIter)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_highlight__SWIG_3(swigCPtr, OdSelectionSetIterator.getCPtr(pIter));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdDbBaseFullSubentPath subEntPath, bool bDoIt)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_highlight__SWIG_4(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath), bDoIt);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual void highlight(OdDbBaseFullSubentPath subEntPath)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.ExDbCommandContext_highlight__SWIG_5(swigCPtr, OdDbBaseFullSubentPath.getCPtr(subEntPath));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
