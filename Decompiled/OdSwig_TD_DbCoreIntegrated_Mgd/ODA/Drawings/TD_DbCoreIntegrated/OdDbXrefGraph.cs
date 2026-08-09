using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbXrefGraph : OdDbGraph
{
	public delegate bool SwigDelegateOdDbXrefGraph_0(IntPtr pStart);

	public delegate bool SwigDelegateOdDbXrefGraph_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbXrefGraph_0 swigDelegate0;

	private SwigDelegateOdDbXrefGraph_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdDbGraphNode) };

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbXrefGraph(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbXrefGraph obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbXrefGraph(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbXrefGraph()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbXrefGraph(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbXrefGraph) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDbXrefGraphNode xrefNode(string name)
	{
		OdDbXrefGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbXrefGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_xrefNode__SWIG_0(swigCPtr, name), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbXrefGraphNode xrefNode(OdDbObjectId blockId)
	{
		OdDbXrefGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbXrefGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_xrefNode__SWIG_1(swigCPtr, OdDbObjectId.getCPtr(blockId)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbXrefGraphNode xrefNode(OdDbDatabase pDb)
	{
		OdDbXrefGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbXrefGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_xrefNode__SWIG_2(swigCPtr, OdDbDatabase.getCPtr(pDb)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbXrefGraphNode xrefNode(int nodeIndex)
	{
		OdDbXrefGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbXrefGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_xrefNode__SWIG_3(swigCPtr, nodeIndex), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbXrefGraphNode hostDwg()
	{
		OdDbXrefGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbXrefGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_hostDwg(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public bool markUnresolvedTrees()
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_markUnresolvedTrees(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public static void getFrom(OdDbDatabase pDb, OdDbXrefGraph xrefGraph, bool includeGhosts)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_getFrom__SWIG_0(OdDbDatabase.getCPtr(pDb), getCPtr(xrefGraph), includeGhosts);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static void getFrom(OdDbDatabase pDb, OdDbXrefGraph xrefGraph)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_getFrom__SWIG_1(OdDbDatabase.getCPtr(pDb), getCPtr(xrefGraph));
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbXrefGraph_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbXrefGraph));
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
