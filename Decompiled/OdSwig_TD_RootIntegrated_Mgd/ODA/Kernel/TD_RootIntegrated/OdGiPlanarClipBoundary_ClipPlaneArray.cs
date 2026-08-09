using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGiPlanarClipBoundary_ClipPlaneArray : IDisposable, IEnumerable, IList<OdGiPlanarClipBoundary.ClipPlane>, ICollection<OdGiPlanarClipBoundary.ClipPlane>, IEnumerable<OdGiPlanarClipBoundary.ClipPlane>
{
	public class OdGiPlanarClipBoundary_ClipPlaneArrayEnumerator : IEnumerator, IEnumerator<OdGiPlanarClipBoundary.ClipPlane>, IDisposable
	{
		private OdGiPlanarClipBoundary_ClipPlaneArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGiPlanarClipBoundary.ClipPlane Current
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
				return (OdGiPlanarClipBoundary.ClipPlane)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdGiPlanarClipBoundary_ClipPlaneArrayEnumerator(OdGiPlanarClipBoundary_ClipPlaneArray collection)
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

	public OdGiPlanarClipBoundary.ClipPlane this[int index]
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
	public OdGiPlanarClipBoundary_ClipPlaneArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGiPlanarClipBoundary_ClipPlaneArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGiPlanarClipBoundary_ClipPlaneArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGiPlanarClipBoundary_ClipPlaneArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdGiPlanarClipBoundary_ClipPlaneArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGiPlanarClipBoundary.ClipPlane item in c)
		{
			Add(item);
		}
	}

	public OdGiPlanarClipBoundary_ClipPlaneArray(bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlanarClipBoundary_ClipPlaneArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiPlanarClipBoundary_ClipPlaneArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPlanarClipBoundary_ClipPlaneArray(OdGiPlanarClipBoundary_ClipPlaneArray other, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlanarClipBoundary_ClipPlaneArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiPlanarClipBoundary_ClipPlaneArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPlanarClipBoundary_ClipPlaneArray(int capacity, bool bGCMemory_Own = false)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGiPlanarClipBoundary_ClipPlaneArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdGiPlanarClipBoundary_ClipPlaneArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdGiPlanarClipBoundary.ClipPlane[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdGiPlanarClipBoundary.ClipPlane[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdGiPlanarClipBoundary.ClipPlane[] array, int arrayIndex, int count)
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

	IEnumerator<OdGiPlanarClipBoundary.ClipPlane> IEnumerable<OdGiPlanarClipBoundary.ClipPlane>.GetEnumerator()
	{
		return new OdGiPlanarClipBoundary_ClipPlaneArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdGiPlanarClipBoundary_ClipPlaneArrayEnumerator(this);
	}

	public OdGiPlanarClipBoundary_ClipPlaneArrayEnumerator GetEnumerator()
	{
		return new OdGiPlanarClipBoundary_ClipPlaneArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_resize(swigCPtr, logicalLength);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGiPlanarClipBoundary.ClipPlane val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_Add(swigCPtr, OdGiPlanarClipBoundary.ClipPlane.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGiPlanarClipBoundary.ClipPlane getitemcopy(int index)
	{
		OdGiPlanarClipBoundary.ClipPlane result = new OdGiPlanarClipBoundary.ClipPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdGiPlanarClipBoundary.ClipPlane getitem(int index)
	{
		OdGiPlanarClipBoundary.ClipPlane result = new OdGiPlanarClipBoundary.ClipPlane(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdGiPlanarClipBoundary.ClipPlane val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_setitem(swigCPtr, index, OdGiPlanarClipBoundary.ClipPlane.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdGiPlanarClipBoundary_ClipPlaneArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGiPlanarClipBoundary_ClipPlaneArray GetRange(int index, int count)
	{
		OdGiPlanarClipBoundary_ClipPlaneArray result = new OdGiPlanarClipBoundary_ClipPlaneArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGiPlanarClipBoundary.ClipPlane x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_Insert(swigCPtr, index, OdGiPlanarClipBoundary.ClipPlane.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdGiPlanarClipBoundary_ClipPlaneArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdGiPlanarClipBoundary_ClipPlaneArray Repeat(OdGiPlanarClipBoundary.ClipPlane value, int count)
	{
		OdGiPlanarClipBoundary_ClipPlaneArray result = new OdGiPlanarClipBoundary_ClipPlaneArray(TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_Repeat(OdGiPlanarClipBoundary.ClipPlane.getCPtr(value), count), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdGiPlanarClipBoundary_ClipPlaneArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdGiPlanarClipBoundary.ClipPlane value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_Contains(swigCPtr, OdGiPlanarClipBoundary.ClipPlane.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdGiPlanarClipBoundary.ClipPlane value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_IndexOf(swigCPtr, OdGiPlanarClipBoundary.ClipPlane.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdGiPlanarClipBoundary.ClipPlane value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_LastIndexOf(swigCPtr, OdGiPlanarClipBoundary.ClipPlane.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdGiPlanarClipBoundary.ClipPlane value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGiPlanarClipBoundary_ClipPlaneArray_Remove(swigCPtr, OdGiPlanarClipBoundary.ClipPlane.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
