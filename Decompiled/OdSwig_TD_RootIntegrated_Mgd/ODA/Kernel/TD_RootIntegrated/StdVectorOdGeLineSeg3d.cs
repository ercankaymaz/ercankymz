using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class StdVectorOdGeLineSeg3d : IDisposable, IEnumerable, IEnumerable<OdGeLineSeg3d>
{
	public class StdVectorOdGeLineSeg3dEnumerator : IEnumerator, IEnumerator<OdGeLineSeg3d>, IDisposable
	{
		private StdVectorOdGeLineSeg3d collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGeLineSeg3d Current
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
				return (OdGeLineSeg3d)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public StdVectorOdGeLineSeg3dEnumerator(StdVectorOdGeLineSeg3d collection)
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

	public OdGeLineSeg3d this[int index]
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
	public StdVectorOdGeLineSeg3d(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(StdVectorOdGeLineSeg3d obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~StdVectorOdGeLineSeg3d()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_StdVectorOdGeLineSeg3d(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public StdVectorOdGeLineSeg3d(IEnumerable c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGeLineSeg3d item in c)
		{
			Add(item);
		}
	}

	public StdVectorOdGeLineSeg3d(IEnumerable<OdGeLineSeg3d> c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGeLineSeg3d item in c)
		{
			Add(item);
		}
	}

	public void CopyTo(OdGeLineSeg3d[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdGeLineSeg3d[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdGeLineSeg3d[] array, int arrayIndex, int count)
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

	public OdGeLineSeg3d[] ToArray()
	{
		OdGeLineSeg3d[] array = new OdGeLineSeg3d[Count];
		CopyTo(array);
		return array;
	}

	IEnumerator<OdGeLineSeg3d> IEnumerable<OdGeLineSeg3d>.GetEnumerator()
	{
		return new StdVectorOdGeLineSeg3dEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new StdVectorOdGeLineSeg3dEnumerator(this);
	}

	public StdVectorOdGeLineSeg3dEnumerator GetEnumerator()
	{
		return new StdVectorOdGeLineSeg3dEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGeLineSeg3d x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_Add(swigCPtr, OdGeLineSeg3d.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_capacity(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_reserve(swigCPtr, n);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public StdVectorOdGeLineSeg3d()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_StdVectorOdGeLineSeg3d__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public StdVectorOdGeLineSeg3d(StdVectorOdGeLineSeg3d other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_StdVectorOdGeLineSeg3d__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public StdVectorOdGeLineSeg3d(int capacity)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_StdVectorOdGeLineSeg3d__SWIG_2(capacity), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGeLineSeg3d getitemcopy(int index)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdGeLineSeg3d getitem(int index)
	{
		OdGeLineSeg3d result = new OdGeLineSeg3d(TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_getitem(swigCPtr, index), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdGeLineSeg3d val)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_setitem(swigCPtr, index, OdGeLineSeg3d.getCPtr(val));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(StdVectorOdGeLineSeg3d values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public StdVectorOdGeLineSeg3d GetRange(int index, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_GetRange(swigCPtr, index, count);
		StdVectorOdGeLineSeg3d result = ((intPtr == IntPtr.Zero) ? null : new StdVectorOdGeLineSeg3d(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGeLineSeg3d x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_Insert(swigCPtr, index, OdGeLineSeg3d.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, StdVectorOdGeLineSeg3d values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static StdVectorOdGeLineSeg3d Repeat(OdGeLineSeg3d value, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_Repeat(OdGeLineSeg3d.getCPtr(value), count);
		StdVectorOdGeLineSeg3d result = ((intPtr == IntPtr.Zero) ? null : new StdVectorOdGeLineSeg3d(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, StdVectorOdGeLineSeg3d values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.StdVectorOdGeLineSeg3d_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
