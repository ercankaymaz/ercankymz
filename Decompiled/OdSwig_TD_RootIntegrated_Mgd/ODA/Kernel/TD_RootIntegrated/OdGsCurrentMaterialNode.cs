using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsCurrentMaterialNode : IDisposable
{
	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsCurrentMaterialNode(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsCurrentMaterialNode obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsCurrentMaterialNode()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsCurrentMaterialNode(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGsCurrentMaterialNode(OdGsMaterialNode pCurrentNode)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCurrentMaterialNode__SWIG_0(OdGsMaterialNode.getCPtr(pCurrentNode)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsCurrentMaterialNode()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsCurrentMaterialNode__SWIG_1(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsMaterialNode currentNode()
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsCurrentMaterialNode_currentNode(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void setCurrentNode(OdGsMaterialNode pNode)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCurrentMaterialNode_setCurrentNode__SWIG_0(swigCPtr, OdGsMaterialNode.getCPtr(pNode));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void setCurrentNode()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsCurrentMaterialNode_setCurrentNode__SWIG_1(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsMaterialNode setMaterial(OdGsMaterialCache pCache, OdGsBaseVectorizer view, OdDbStub mtl, bool bDontReinit)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsCurrentMaterialNode_setMaterial__SWIG_0(swigCPtr, OdGsMaterialCache.getCPtr(pCache), OdGsBaseVectorizer.getCPtr(view), OdDbStub.getCPtr(mtl), bDontReinit), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsMaterialNode setMaterial(OdGsMaterialCache pCache, OdGsBaseVectorizer view, OdDbStub mtl)
	{
		OdGsMaterialNode rXObject = Helpers.GetRXObject<OdGsMaterialNode>(TD_RootIntegrated_GlobalsPINVOKE.OdGsCurrentMaterialNode_setMaterial__SWIG_1(swigCPtr, OdGsMaterialCache.getCPtr(pCache), OdGsBaseVectorizer.getCPtr(view), OdDbStub.getCPtr(mtl)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}
}
