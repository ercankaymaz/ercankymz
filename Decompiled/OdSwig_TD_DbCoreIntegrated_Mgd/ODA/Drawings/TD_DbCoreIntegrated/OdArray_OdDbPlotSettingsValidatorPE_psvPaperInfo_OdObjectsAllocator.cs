using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Drawings.TD_DbCoreIntegrated;

public class OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdDbPlotSettingsValidatorPE.psvPaperInfo>, ICollection<OdDbPlotSettingsValidatorPE.psvPaperInfo>, IEnumerable<OdDbPlotSettingsValidatorPE.psvPaperInfo>
{
	public class OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdDbPlotSettingsValidatorPE.psvPaperInfo>, IDisposable
	{
		private OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdDbPlotSettingsValidatorPE.psvPaperInfo Current
		{
			get
			{
				if (currentIndex == -1)
				{
					throw new InvalidOperationException("Enumeration not started.");
				}
				if (currentIndex > currentSize - 1)
				{
					throw new InvalidOperationException("Enumeration finished.");
				}
				if (currentObject == null)
				{
					throw new InvalidOperationException("Collection modified.");
				}
				return (OdDbPlotSettingsValidatorPE.psvPaperInfo)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocatorEnumerator(OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator collection)
		{
			collectionRef = collection;
			currentIndex = -1;
			currentObject = null;
			currentSize = collectionRef.Count;
		}

		public bool MoveNext()
		{
			int count = collectionRef.Count;
			int num;
			if (currentIndex + 1 < count)
			{
				num = ((count == currentSize) ? 1 : 0);
				if (num != 0)
				{
					currentIndex++;
					currentObject = collectionRef[currentIndex];
					return (byte)num != 0;
				}
			}
			else
			{
				num = 0;
			}
			currentObject = null;
			return (byte)num != 0;
		}

		public void Reset()
		{
			currentIndex = -1;
			currentObject = null;
			if (collectionRef.Count != currentSize)
			{
				throw new InvalidOperationException("Collection modified.");
			}
		}

		public void Dispose()
		{
			currentIndex = -1;
			currentObject = null;
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public OdDbPlotSettingsValidatorPE.psvPaperInfo this[int index]
	{
		get
		{
			return getitem(index);
		}
		set
		{
			setitem(index, value);
		}
	}

	public int Capacity
	{
		get
		{
			return (int)capacity();
		}
		set
		{
			if (value < size())
			{
				throw new ArgumentOutOfRangeException("Capacity");
			}
			reserve((uint)value);
		}
	}

	public int Count => (int)size();

	public bool IsSynchronized => false;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator()
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
					TD_DbCoreIntegrated_GlobalsPINVOKE.delete_OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdDbPlotSettingsValidatorPE.psvPaperInfo item in c)
		{
			Add(item);
		}
	}

	public OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(TD_DbCoreIntegrated_GlobalsPINVOKE.new_OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdDbPlotSettingsValidatorPE.psvPaperInfo[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdDbPlotSettingsValidatorPE.psvPaperInfo[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdDbPlotSettingsValidatorPE.psvPaperInfo[] array, int arrayIndex, int count)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index", "Value is less than zero");
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count", "Value is less than zero");
		}
		if (array.Rank > 1)
		{
			throw new ArgumentException("Multi dimensional array.", "array");
		}
		if (index + count > Count || arrayIndex + count > array.Length)
		{
			throw new ArgumentException("Number of elements to copy is too large.");
		}
		for (int i = 0; i < count; i++)
		{
			array.SetValue(getitemcopy(index + i), arrayIndex + i);
		}
	}

	IEnumerator<OdDbPlotSettingsValidatorPE.psvPaperInfo> IEnumerable<OdDbPlotSettingsValidatorPE.psvPaperInfo>.GetEnumerator()
	{
		return new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_size(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_capacity(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_reserve(swigCPtr, n);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_Clear(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdDbPlotSettingsValidatorPE.psvPaperInfo val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_Add(swigCPtr, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdDbPlotSettingsValidatorPE.psvPaperInfo getitemcopy(int index)
	{
		OdDbPlotSettingsValidatorPE.psvPaperInfo result = new OdDbPlotSettingsValidatorPE.psvPaperInfo(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdDbPlotSettingsValidatorPE.psvPaperInfo getitem(int index)
	{
		OdDbPlotSettingsValidatorPE.psvPaperInfo result = new OdDbPlotSettingsValidatorPE.psvPaperInfo(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdDbPlotSettingsValidatorPE.psvPaperInfo val)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_setitem(swigCPtr, index, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(val));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator result = new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdDbPlotSettingsValidatorPE.psvPaperInfo x)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_Insert(swigCPtr, index, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(x));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator Repeat(OdDbPlotSettingsValidatorPE.psvPaperInfo value, int count)
	{
		OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator result = new OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator(TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_Repeat(OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(value), count), cMemoryOwn: false);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator values)
	{
		TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdDbPlotSettingsValidatorPE.psvPaperInfo value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_Contains(swigCPtr, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdDbPlotSettingsValidatorPE.psvPaperInfo value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_IndexOf(swigCPtr, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdDbPlotSettingsValidatorPE.psvPaperInfo value)
	{
		int result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_LastIndexOf(swigCPtr, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdDbPlotSettingsValidatorPE.psvPaperInfo value)
	{
		bool result = TD_DbCoreIntegrated_GlobalsPINVOKE.OdArray_OdDbPlotSettingsValidatorPE_psvPaperInfo_OdObjectsAllocator_Remove(swigCPtr, OdDbPlotSettingsValidatorPE.psvPaperInfo.getCPtr(value));
		if (TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_DbCoreIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
