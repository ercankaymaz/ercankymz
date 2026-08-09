using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdDbRecordIdCollectionView : IDisposable
{
	public class Iterator : IDisposable
	{
		private object locker = new object();

		private HandleRef swigCPtr;

		protected bool swigCMemOwn;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public Iterator(IntPtr cPtr, bool cMemoryOwn)
		{
			swigCMemOwn = cMemoryOwn;
			swigCPtr = new HandleRef(this, cPtr);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static HandleRef getCPtr(Iterator obj)
		{
			return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
		}

		~Iterator()
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
						TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbRecordIdCollectionView_Iterator(swigCPtr);
					}
					swigCPtr = new HandleRef(null, IntPtr.Zero);
				}
			}
		}

		public Iterator(OdDbSymbolTableIterator i)
			: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbRecordIdCollectionView_Iterator(OdDbSymbolTableIterator.getCPtr(i)), cMemoryOwn: true)
		{
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
		}

		public OdDbObjectId __ref__()
		{
			OdDbObjectId result = new OdDbObjectId(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRecordIdCollectionView_Iterator___ref__(swigCPtr), cMemoryOwn: true);
			if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
			{
				throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
			}
			return result;
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdDbRecordIdCollectionView(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdDbRecordIdCollectionView obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdDbRecordIdCollectionView()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdDbRecordIdCollectionView(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdDbRecordIdCollectionView(OdDbSymbolTableIterator i)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdDbRecordIdCollectionView(OdDbSymbolTableIterator.getCPtr(i)), cMemoryOwn: true)
	{
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public Iterator begin()
	{
		Iterator result = new Iterator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRecordIdCollectionView_begin(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public Iterator end()
	{
		Iterator result = new Iterator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdDbRecordIdCollectionView_end(swigCPtr), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
