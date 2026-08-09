using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class StdListOdCmEntityColorArray : IDisposable, IEnumerable
{
	public class StdListOdCmEntityColorArrayEnumerator : IEnumerator
	{
		private StdListOdCmEntityColorArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdCmEntityColorArray Current
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
				return (OdCmEntityColorArray)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public StdListOdCmEntityColorArrayEnumerator(StdListOdCmEntityColorArray collection)
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

	public OdCmEntityColorArray this[int index] => getitem(index);

	public int Count => (int)size();

	public bool IsSynchronized => false;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public StdListOdCmEntityColorArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(StdListOdCmEntityColorArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~StdListOdCmEntityColorArray()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_StdListOdCmEntityColorArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public StdListOdCmEntityColorArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdCmEntityColorArray item in c)
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
		return new StdListOdCmEntityColorArrayEnumerator(this);
	}

	public StdListOdCmEntityColorArrayEnumerator GetEnumerator()
	{
		return new StdListOdCmEntityColorArrayEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdCmEntityColorArray value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_Add(swigCPtr, OdCmEntityColorArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public StdListOdCmEntityColorArray()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_StdListOdCmEntityColorArray(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdCmEntityColorArray getitemcopy(int index)
	{
		OdCmEntityColorArray result = new OdCmEntityColorArray(TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdCmEntityColorArray getitem(int index)
	{
		OdCmEntityColorArray result = new OdCmEntityColorArray(TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_getitem(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void AddRange(StdListOdCmEntityColorArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public StdListOdCmEntityColorArray GetRange(int index, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_GetRange(swigCPtr, index, count);
		StdListOdCmEntityColorArray result = ((intPtr == IntPtr.Zero) ? null : new StdListOdCmEntityColorArray(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdCmEntityColorArray value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_Insert(swigCPtr, index, OdCmEntityColorArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, StdListOdCmEntityColorArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static StdListOdCmEntityColorArray Repeat(OdCmEntityColorArray value, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_Repeat(OdCmEntityColorArray.getCPtr(value), count);
		StdListOdCmEntityColorArray result = ((intPtr == IntPtr.Zero) ? null : new StdListOdCmEntityColorArray(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, StdListOdCmEntityColorArray values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdCmEntityColorArray value)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_Contains(swigCPtr, OdCmEntityColorArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdCmEntityColorArray value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_IndexOf(swigCPtr, OdCmEntityColorArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdCmEntityColorArray value)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_LastIndexOf(swigCPtr, OdCmEntityColorArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Remove(OdCmEntityColorArray value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdListOdCmEntityColorArray_Remove(swigCPtr, OdCmEntityColorArray.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
