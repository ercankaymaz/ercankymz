using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbGraph : IDisposable
{
	public delegate bool SwigDelegateOdDbGraph_0(IntPtr pStart);

	public delegate bool SwigDelegateOdDbGraph_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	private SwigDelegateOdDbGraph_0 swigDelegate0;

	private SwigDelegateOdDbGraph_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdDbGraphNode) };

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbGraph(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbGraph obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbGraph()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbGraph(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbGraph()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbGraph(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbGraph) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDbGraphNode node(int nodeIndex)
	{
		OdDbGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_node(swigCPtr, nodeIndex), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbGraphNode rootNode()
	{
		OdDbGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_rootNode(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public int numNodes()
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_numNodes(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool isEmpty()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_isEmpty(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void addNode(OdDbGraphNode pNode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_addNode(swigCPtr, OdDbGraphNode.getCPtr(pNode));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void addEdge(OdDbGraphNode pFrom, OdDbGraphNode pTo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_addEdge(swigCPtr, OdDbGraphNode.getCPtr(pFrom), OdDbGraphNode.getCPtr(pTo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void delNode(OdDbGraphNode pNode)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_delNode(swigCPtr, OdDbGraphNode.getCPtr(pNode));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void reset()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_reset(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void clearAll(byte flags)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_clearAll(swigCPtr, flags);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void getOutgoing(OdDbGraphNodeArray outgoing)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_getOutgoing(swigCPtr, OdDbGraphNodeArray.getCPtr(outgoing));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool findCycles(OdDbGraphNode pStart)
	{
		bool result = (SwigDerivedClassHasMethod("findCycles", swigMethodTypes0) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_findCyclesSwigExplicitOdDbGraph__SWIG_0(swigCPtr, OdDbGraphNode.getCPtr(pStart)) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_findCycles__SWIG_0(swigCPtr, OdDbGraphNode.getCPtr(pStart)));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool findCycles()
	{
		bool result = (SwigDerivedClassHasMethod("findCycles", swigMethodTypes1) ? TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_findCyclesSwigExplicitOdDbGraph__SWIG_1(swigCPtr) : TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_findCycles__SWIG_1(swigCPtr));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void breakCycleEdge(OdDbGraphNode pFrom, OdDbGraphNode pTo)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_breakCycleEdge(swigCPtr, OdDbGraphNode.getCPtr(pFrom), OdDbGraphNode.getCPtr(pTo));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private void SwigDirectorConnect()
	{
		if (SwigDerivedClassHasMethod("findCycles", swigMethodTypes0))
		{
			swigDelegate0 = SwigDirectorMethodfindCycles__SWIG_0;
		}
		if (SwigDerivedClassHasMethod("findCycles", swigMethodTypes1))
		{
			swigDelegate1 = SwigDirectorMethodfindCycles__SWIG_1;
		}
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbGraph_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbGraph));
	}

	private bool SwigDirectorMethodfindCycles__SWIG_0(IntPtr pStart)
	{
		return findCycles(ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbGraphNode>(pStart, bOwn: false, bTryAddToTransaction: false));
	}

	private bool SwigDirectorMethodfindCycles__SWIG_1()
	{
		return findCycles();
	}
}
