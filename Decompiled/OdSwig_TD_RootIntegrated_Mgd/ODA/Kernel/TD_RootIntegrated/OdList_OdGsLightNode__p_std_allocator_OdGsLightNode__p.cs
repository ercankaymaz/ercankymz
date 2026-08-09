using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p : IDisposable, IEnumerable
{
	public class OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__pEnumerator : IEnumerator
	{
		private OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdGsLightNode Current
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
				return (OdGsLightNode)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__pEnumerator(OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p collection)
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

	public OdGsLightNode this[int index] => getitem(index);

	public int Count => (int)size();

	public bool IsSynchronized => false;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdGsLightNode item in c)
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
		return new OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__pEnumerator(this);
	}

	public OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__pEnumerator GetEnumerator()
	{
		return new OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__pEnumerator(this);
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdGsLightNode value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_Add(swigCPtr, OdGsLightNode.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsLightNode getitemcopy(int index)
	{
		OdGsLightNode rXObject = Helpers.GetRXObject<OdGsLightNode>(TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_getitemcopy(swigCPtr, index), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public OdGsLightNode getitem(int index)
	{
		OdGsLightNode rXObject = Helpers.GetRXObject<OdGsLightNode>(TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_getitem(swigCPtr, index), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void AddRange(OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_AddRange(swigCPtr, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p GetRange(int index, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_GetRange(swigCPtr, index, count);
		OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p result = ((intPtr == IntPtr.Zero) ? null : new OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdGsLightNode value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_Insert(swigCPtr, index, OdGsLightNode.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_InsertRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_RemoveAt(swigCPtr, index);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_RemoveRange(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p Repeat(OdGsLightNode value, int count)
	{
		IntPtr intPtr = TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_Repeat(OdGsLightNode.getCPtr(value), count);
		OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p result = ((intPtr == IntPtr.Zero) ? null : new OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p(intPtr, cMemoryOwn: true));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_Reverse__SWIG_0(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_Reverse__SWIG_1(swigCPtr, index, count);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p values)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdList_OdGsLightNode__p_std_allocator_OdGsLightNode__p_SetRange(swigCPtr, index, getCPtr(values));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
