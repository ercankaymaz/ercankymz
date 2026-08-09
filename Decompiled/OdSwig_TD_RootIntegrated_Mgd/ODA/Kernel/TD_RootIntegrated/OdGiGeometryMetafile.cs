using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiGeometryMetafile : OdRxObject
{
	public class Record : IDisposable
	{
		public delegate void SwigDelegateRecord_0(IntPtr pGeom, IntPtr pCtx);

		public delegate ulong SwigDelegateRecord_1();

		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		private SwigDelegateRecord_0 swigDelegate0;

		private SwigDelegateRecord_1 swigDelegate1;

		private static Type[] swigMethodTypes0 = new Type[2]
		{
			typeof(OdGiConveyorGeometry),
			typeof(OdGiConveyorContext)
		};

		private static Type[] swigMethodTypes1 = new Type[0];

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Record(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Record obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Record()
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
						TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGeometryMetafile_Record(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public Record()
			: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiGeometryMetafile_Record(), cMemoryOwn: true)
		{
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			_ = typeof(Record) != GetType();
			SwigDirectorConnect();
			DelegateHolder.OnHoldSwigDirectorDelegates(this);
			MemoryManager.GetMemoryManager().GetCurrentTransaction();
		}

		public Record tail()
		{
			IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_Record_tail__SWIG_0(swigCPtr);
			Record result = ((intPtr == IntPtr.Zero) ? null : new Record(intPtr, cMemoryOwn: false));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		public void setTail(Record pTail)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_Record_setTail(swigCPtr, getCPtr(pTail));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public void deleteList()
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_Record_deleteList(swigCPtr);
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual void play(OdGiConveyorGeometry pGeom, OdGiConveyorContext pCtx)
		{
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_Record_play(swigCPtr, pGeom.GetInterfaceCPtr(), pCtx.GetInterfaceCPtr());
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public virtual ulong recordSize()
		{
			ulong result = (SwigDerivedClassHasMethod("recordSize", swigMethodTypes1) ? TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_Record_recordSizeSwigExplicitRecord(swigCPtr) : TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_Record_recordSize(swigCPtr));
			if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}

		private void SwigDirectorConnect()
		{
			if (SwigDerivedClassHasMethod("play", swigMethodTypes0))
			{
				swigDelegate0 = SwigDirectorMethodplay;
			}
			if (SwigDerivedClassHasMethod("recordSize", swigMethodTypes1))
			{
				swigDelegate1 = SwigDirectorMethodrecordSize;
			}
			TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_Record_director_connect(swigCPtr, swigDelegate0, swigDelegate1);
		}

		private bool SwigDerivedClassHasMethod(string methodName, Type[] methodTypes)
		{
			return GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, methodTypes, null).DeclaringType.IsSubclassOf(typeof(Record));
		}

		private void SwigDirectorMethodplay(IntPtr pGeom, IntPtr pCtx)
		{
			try
			{
				play(new OdGiConveyorGeometry_Internal(pGeom, cMemoryOwn: false), new OdGiConveyorContext_Internal(pCtx, cMemoryOwn: false));
			}
			catch (OdEdEmptyInput err)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(err);
			}
			catch (OdEdOtherInput err2)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(err2);
			}
			catch (OdError err3)
			{
				TD_RootIntegrated_Globals.throw_native_OdError(err3);
			}
			catch (Exception ex)
			{
				TD_RootIntegrated_Globals.throw_native_exception_string(ex.ToString());
			}
		}

		private ulong SwigDirectorMethodrecordSize()
		{
			return recordSize();
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGiGeometryMetafile(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiGeometryMetafile obj)
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiGeometryMetafile(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public new static OdGiGeometryMetafile cast(OdRxObject pObj)
	{
		OdGiGeometryMetafile rXObject = Helpers.GetRXObject<OdGiGeometryMetafile>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdGiGeometryMetafile createObject()
	{
		OdGiGeometryMetafile rXObject = Helpers.GetRXObject<OdGiGeometryMetafile>(TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void play(OdGiConveyorGeometry pGeom, OdGiConveyorContext pCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_play__SWIG_0(swigCPtr, pGeom.GetInterfaceCPtr(), pCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void play(OdGiConveyorOutput output, OdGiConveyorContext pCtx)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_play__SWIG_1(swigCPtr, output.GetInterfaceCPtr(), pCtx.GetInterfaceCPtr());
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual ulong metafileSize()
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_metafileSize(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void setRecords(Record pRec)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_setRecords(swigCPtr, Record.getCPtr(pRec));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool isEmpty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_isEmpty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public Record firstRecord()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_firstRecord(swigCPtr);
		Record result = ((intPtr == IntPtr.Zero) ? null : new Record(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public Record lastRecord()
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_lastRecord(swigCPtr);
		Record result = ((intPtr == IntPtr.Zero) ? null : new Record(intPtr, cMemoryOwn: false));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdGiGeometryMetafile_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
