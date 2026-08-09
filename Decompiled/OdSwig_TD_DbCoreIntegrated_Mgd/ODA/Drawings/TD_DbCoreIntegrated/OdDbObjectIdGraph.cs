using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbObjectIdGraph : OdDbGraph
{
	public delegate bool SwigDelegateOdDbObjectIdGraph_0(IntPtr pStart);

	public delegate bool SwigDelegateOdDbObjectIdGraph_1();

	private object locker = new object();

	private HandleRef swigCPtr;

	private SwigDelegateOdDbObjectIdGraph_0 swigDelegate0;

	private SwigDelegateOdDbObjectIdGraph_1 swigDelegate1;

	private static Type[] swigMethodTypes0 = new Type[1] { typeof(OdDbGraphNode) };

	private static Type[] swigMethodTypes1 = new Type[0];

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbObjectIdGraph(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIdGraph_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbObjectIdGraph obj)
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbObjectIdGraph(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public OdDbObjectIdGraph()
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbObjectIdGraph(), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		_ = typeof(OdDbObjectIdGraph) != GetType();
		SwigDirectorConnect();
		DelegateHolder.OnHoldSwigDirectorDelegates(this);
		MemoryManager.GetMemoryManager().GetCurrentTransaction();
	}

	public OdDbObjectIdGraphNode findNode(OdDbObjectId arg0)
	{
		OdDbObjectIdGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectIdGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIdGraph_findNode(swigCPtr, OdDbObjectId.getCPtr(arg0)), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdDbObjectIdGraphNode idNode(int idx)
	{
		OdDbObjectIdGraphNode rXObject = ODA.Kernel.TD_RootIntegrated.Helpers.GetRXObject<OdDbObjectIdGraphNode>(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIdGraph_idNode(swigCPtr, idx), bOwn: false, bTryAddToTransaction: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
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
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbObjectIdGraph_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
	}

	private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
	{
		return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(OdDbObjectIdGraph));
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
