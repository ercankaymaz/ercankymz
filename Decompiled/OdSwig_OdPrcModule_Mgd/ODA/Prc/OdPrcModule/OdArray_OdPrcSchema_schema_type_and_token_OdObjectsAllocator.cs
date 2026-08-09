using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator : IDisposable, IEnumerable, IList<OdPrcSchema.schema_type_and_token>, ICollection<OdPrcSchema.schema_type_and_token>, IEnumerable<OdPrcSchema.schema_type_and_token>
{
	public class OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<OdPrcSchema.schema_type_and_token>, IDisposable
	{
		private OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPrcSchema.schema_type_and_token Current
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
				return (OdPrcSchema.schema_type_and_token)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocatorEnumerator(OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator collection)
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

	public OdPrcSchema.schema_type_and_token this[int index]
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
	public OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPrcSchema.schema_type_and_token item in c)
		{
			Add(item);
		}
	}

	public OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator other, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(int capacity, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPrcSchema.schema_type_and_token[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPrcSchema.schema_type_and_token[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPrcSchema.schema_type_and_token[] array, int arrayIndex, int count)
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

	IEnumerator<OdPrcSchema.schema_type_and_token> IEnumerable<OdPrcSchema.schema_type_and_token>.GetEnumerator()
	{
		return new OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocatorEnumerator(this);
	}

	public OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocatorEnumerator(this);
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_capacity(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_reserve(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_resize(swigCPtr, logicalLength);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPrcSchema.schema_type_and_token val)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_Add(swigCPtr, OdPrcSchema.schema_type_and_token.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPrcSchema.schema_type_and_token getitemcopy(int index)
	{
		OdPrcSchema.schema_type_and_token result = new OdPrcSchema.schema_type_and_token(OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_getitemcopy(swigCPtr, index), cMemoryOwn: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdPrcSchema.schema_type_and_token getitem(int index)
	{
		OdPrcSchema.schema_type_and_token result = new OdPrcSchema.schema_type_and_token(OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_getitem(swigCPtr, index), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(int index, OdPrcSchema.schema_type_and_token val)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_setitem(swigCPtr, index, OdPrcSchema.schema_type_and_token.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator values)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_AddRange(swigCPtr, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator GetRange(int index, int count)
	{
		OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator result = new OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_GetRange(swigCPtr, index, count), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPrcSchema.schema_type_and_token x)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_Insert(swigCPtr, index, OdPrcSchema.schema_type_and_token.getCPtr(x));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator values)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_InsertRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_RemoveAt(swigCPtr, index);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_RemoveRange(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator Repeat(OdPrcSchema.schema_type_and_token value, int count)
	{
		OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator result = new OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator(OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_Repeat(OdPrcSchema.schema_type_and_token.getCPtr(value), count), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_Reverse__SWIG_0(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_Reverse__SWIG_1(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator values)
	{
		OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_SetRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPrcSchema.schema_type_and_token value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_Contains(swigCPtr, OdPrcSchema.schema_type_and_token.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPrcSchema.schema_type_and_token value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_IndexOf(swigCPtr, OdPrcSchema.schema_type_and_token.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPrcSchema.schema_type_and_token value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_LastIndexOf(swigCPtr, OdPrcSchema.schema_type_and_token.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPrcSchema.schema_type_and_token value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdArray_OdPrcSchema_schema_type_and_token_OdObjectsAllocator_Remove(swigCPtr, OdPrcSchema.schema_type_and_token.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
