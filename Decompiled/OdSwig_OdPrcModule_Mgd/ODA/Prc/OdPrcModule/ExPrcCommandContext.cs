using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class ExPrcCommandContext : OdPrcCommandContext
{
	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public ExPrcCommandContext(IntPtr cPtr, bool cMemoryOwn)
		: base(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(ExPrcCommandContext obj)
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
					OdPrcModule_GlobalsPINVOKE.delete_ExPrcCommandContext(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public static OdPrcCommandContext createObject(OdEdBaseIO pIOStream, OdPrcFile pDb)
	{
		OdPrcCommandContext rXObject = Helpers.GetRXObject<OdPrcCommandContext>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_createObject__SWIG_0(OdEdBaseIO.getCPtr(pIOStream), OdPrcFile.getCPtr(pDb)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcCommandContext createObject(OdEdBaseIO pIOStream, OdRxObject pRxDb)
	{
		OdPrcCommandContext rXObject = Helpers.GetRXObject<OdPrcCommandContext>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_createObject__SWIG_1(OdEdBaseIO.getCPtr(pIOStream), OdRxObject.getCPtr(pRxDb)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdPrcCommandContext createObject(OdEdBaseIO pIOStream)
	{
		OdPrcCommandContext rXObject = Helpers.GetRXObject<OdPrcCommandContext>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_createObject__SWIG_2(OdEdBaseIO.getCPtr(pIOStream)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdRxObject baseDatabase()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_baseDatabase(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdEdUserIO userIO()
	{
		OdEdUserIO rXObject = Helpers.GetRXObject<OdEdUserIO>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_userIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual OdEdFunctionIO funcIO()
	{
		OdEdFunctionIO rXObject = Helpers.GetRXObject<OdEdFunctionIO>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_funcIO(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setParam(OdRxObject pParamObj)
	{
		OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_setParam(swigCPtr, OdRxObject.getCPtr(pParamObj));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject param()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_param(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setResult(OdRxObject pResultObj)
	{
		OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_setResult(swigCPtr, OdRxObject.getCPtr(pResultObj));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject result()
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_result(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new virtual void setArbitraryData(string fileName, OdRxObject pDataObj)
	{
		OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_setArbitraryData(swigCPtr, fileName, OdRxObject.getCPtr(pDataObj));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public new virtual OdRxObject arbitraryData(string fileName)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_arbitraryData(swigCPtr, fileName), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdSelectionSet previousSelection()
	{
		OdSelectionSet rXObject = Helpers.GetRXObject<OdSelectionSet>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_previousSelection(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void setPreviousSelection(OdSelectionSet pSSet)
	{
		OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_setPreviousSelection(swigCPtr, OdSelectionSet.getCPtr(pSSet));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdUnitsFormatter baseFormatter()
	{
		OdUnitsFormatter rXObject = Helpers.GetRXObject<OdUnitsFormatter>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_baseFormatter(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void putString(string string_)
	{
		OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_putString(swigCPtr, string_);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual int getInt(string prompt, int options, int defVal, string keywords, OdEdIntegerTracker pTracker)
	{
		int num = OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getInt(swigCPtr, prompt, options, defVal, keywords, OdEdIntegerTracker.getCPtr(pTracker));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getReal(string prompt, int options, double defVal, string keywordList, OdEdRealTracker pTracker)
	{
		double num = OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getReal(swigCPtr, prompt, options, defVal, keywordList, OdEdRealTracker.getCPtr(pTracker));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual string getString(string prompt, int options, string pDefVal, string keywords, OdEdStringTracker pTracker)
	{
		string text = OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getString(swigCPtr, prompt, options, pDefVal, keywords, OdEdStringTracker.getCPtr(pTracker));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual int getKeyword(string prompt, string keywords, int defRes, int options, OdEdIntegerTracker pTracker)
	{
		int num = OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getKeyword(swigCPtr, prompt, keywords, defRes, options, OdEdIntegerTracker.getCPtr(pTracker));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual double getAngle(string prompt, int options, double defVal, string keywords, OdEdRealTracker pTracker)
	{
		double num = OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getAngle(swigCPtr, prompt, options, defVal, keywords, OdEdRealTracker.getCPtr(pTracker));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual OdGePoint3d getLASTPOINT()
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getLASTPOINT(swigCPtr), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odGePoint3d;
	}

	public virtual void setLASTPOINT(OdGePoint3d val)
	{
		OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_setLASTPOINT(swigCPtr, OdGePoint3d.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdEdPointDefTracker createRubberBand(OdGePoint3d base_, OdGsModel pModel)
	{
		OdEdPointDefTracker rXObject = Helpers.GetRXObject<OdEdPointDefTracker>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_createRubberBand__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(base_), OdGsModel.getCPtr(pModel)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRubberBand(OdGePoint3d base_)
	{
		OdEdPointDefTracker rXObject = Helpers.GetRXObject<OdEdPointDefTracker>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_createRubberBand__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(base_)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRectFrame(OdGePoint3d base_, OdGsModel pModel)
	{
		OdEdPointDefTracker rXObject = Helpers.GetRXObject<OdEdPointDefTracker>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_createRectFrame__SWIG_0(swigCPtr, OdGePoint3d.getCPtr(base_), OdGsModel.getCPtr(pModel)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdEdPointDefTracker createRectFrame(OdGePoint3d base_)
	{
		OdEdPointDefTracker rXObject = Helpers.GetRXObject<OdEdPointDefTracker>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_createRectFrame__SWIG_1(swigCPtr, OdGePoint3d.getCPtr(base_)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdGePoint3d getPoint(string prompt, int options, OdGePoint3d pDefVal, string keywords, OdEdPointTracker pTracker)
	{
		OdGePoint3d odGePoint3d = new OdGePoint3d(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getPoint(swigCPtr, prompt, options, OdGePoint3d.getCPtr(pDefVal), keywords, OdEdPointTracker.getCPtr(pTracker)), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odGePoint3d;
	}

	public virtual double getDist(string prompt, int options, double defVal, string keywords, OdEdRealTracker pTracker)
	{
		double num = OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getDist(swigCPtr, prompt, options, defVal, keywords, OdEdRealTracker.getCPtr(pTracker));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return num;
	}

	public virtual string getFilePath(string prompt, int options, string dialogCaption, string defExt, string fileName, string filter, string keywords, OdEdStringTracker pTracker)
	{
		string text = OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getFilePath(swigCPtr, prompt, options, dialogCaption, defExt, fileName, filter, keywords, OdEdStringTracker.getCPtr(pTracker));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return text;
	}

	public virtual OdCmColorBase getCmColor(string sPrompt, int options, OdCmColorBase pDefVal, string sKeywords, OdEdColorTracker pTracker)
	{
		OdCmColorBase odCmColorBase = Helpers.GetObject<OdCmColorBase>(OdPrcModule_GlobalsPINVOKE.ExPrcCommandContext_getCmColor(swigCPtr, sPrompt, options, OdCmColorBase.getCPtr(pDefVal), sKeywords, OdEdColorTracker.getCPtr(pTracker)), bOwn: true, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return odCmColorBase;
	}
}
