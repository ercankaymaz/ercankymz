using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class StdListOdGePoint3dArray : IDisposable, IEnumerable
{
	public class StdListOdGePoint3dArrayEnumerator : IEnumerator
	{
		private StdListOdGePoint3dArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGePoint3dArray Current
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
				return (OdGePoint3dArray)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public StdListOdGePoint3dArrayEnumerator(StdListOdGePoint3dArray collection)
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
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	protected bool swigCMemOwn;

	public bool IsFixedSize => false;

	public bool IsReadOnly => false;

	public OdGePoint3dArray this[int index] => getitem(index);

	public int Count => (int)size();

	public bool IsSynchronized => false;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public StdListOdGePoint3dArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(StdListOdGePoint3dArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~StdListOdGePoint3dArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_StdListOdGePoint3dArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public StdListOdGePoint3dArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGePoint3dArray item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(Array array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(Array array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, Array array, int arrayIndex, int count)
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
			throw new ArgumentException("Multi dimensional array.");
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

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new StdListOdGePoint3dArrayEnumerator(this);
	}

	public StdListOdGePoint3dArrayEnumerator GetEnumerator()
	{
		return new StdListOdGePoint3dArrayEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGePoint3dArray value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_Add(swigCPtr, OdGePoint3dArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public StdListOdGePoint3dArray()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_StdListOdGePoint3dArray(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGePoint3dArray getitemcopy(int index)
	{
		OdGePoint3dArray result = new OdGePoint3dArray(TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdGePoint3dArray getitem(int index)
	{
		OdGePoint3dArray result = new OdGePoint3dArray(TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_getitem(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void AddRange(StdListOdGePoint3dArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public StdListOdGePoint3dArray GetRange(int index, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_GetRange(swigCPtr, index, count);
		StdListOdGePoint3dArray result = ((intPtr == IntPtr.Zero) ? null : new StdListOdGePoint3dArray(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGePoint3dArray value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_Insert(swigCPtr, index, OdGePoint3dArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, StdListOdGePoint3dArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static StdListOdGePoint3dArray Repeat(OdGePoint3dArray value, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_Repeat(OdGePoint3dArray.getCPtr(value), count);
		StdListOdGePoint3dArray result = ((intPtr == IntPtr.Zero) ? null : new StdListOdGePoint3dArray(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, StdListOdGePoint3dArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdGePoint3dArray value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_Contains(swigCPtr, OdGePoint3dArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdGePoint3dArray value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_IndexOf(swigCPtr, OdGePoint3dArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdGePoint3dArray value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_LastIndexOf(swigCPtr, OdGePoint3dArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Remove(OdGePoint3dArray value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdGePoint3dArray_Remove(swigCPtr, OdGePoint3dArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
