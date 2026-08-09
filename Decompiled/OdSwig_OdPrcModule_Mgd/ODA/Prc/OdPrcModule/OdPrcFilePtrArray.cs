using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdPrcFilePtrArray : IDisposable, IEnumerable, IList<OdPrcFile>, ICollection<OdPrcFile>, IEnumerable<OdPrcFile>
{
	public class OdPrcFilePtrArrayEnumerator : IEnumerator, IEnumerator<OdPrcFile>, IDisposable
	{
		private OdPrcFilePtrArray collectionRef;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public OdPrcFile Current
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
				return (OdPrcFile)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdPrcFilePtrArrayEnumerator(OdPrcFilePtrArray collection)
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

	public OdPrcFile this[int index]
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
	public OdPrcFilePtrArray(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdPrcFilePtrArray obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdPrcFilePtrArray()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdPrcFilePtrArray(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public OdPrcFilePtrArray(ICollection c)
		: this()
	{
		if (c == null)
		{
			throw new ArgumentNullException("c");
		}
		foreach (OdPrcFile item in c)
		{
			Add(item);
		}
	}

	public OdPrcFilePtrArray(bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFilePtrArray__SWIG_0(), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcFilePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcFilePtrArray(OdPrcFilePtrArray other, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFilePtrArray__SWIG_1(getCPtr(other)), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcFilePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcFilePtrArray(int capacity, bool bGCMemory_Own = false)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdPrcFilePtrArray__SWIG_2(capacity), bGCMemory_Own || MemoryManager.GetMemoryManager().GetCurrentTransaction() == null)
	{
		MemoryTransaction currentTransaction = MemoryManager.GetMemoryManager().GetCurrentTransaction();
		if (!bGCMemory_Own)
		{
			currentTransaction?.AddObject(new OdPrcFilePtrArray(swigCPtr.Handle, cMemoryOwn: true));
		}
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void CopyTo(OdPrcFile[] array)
	{
		CopyTo(0, array, 0, Count);
	}

	public void CopyTo(OdPrcFile[] array, int arrayIndex)
	{
		CopyTo(0, array, arrayIndex, Count);
	}

	public void CopyTo(int index, OdPrcFile[] array, int arrayIndex, int count)
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

	IEnumerator<OdPrcFile> IEnumerable<OdPrcFile>.GetEnumerator()
	{
		return new OdPrcFilePtrArrayEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdPrcFilePtrArrayEnumerator(this);
	}

	public OdPrcFilePtrArrayEnumerator GetEnumerator()
	{
		return new OdPrcFilePtrArrayEnumerator(this);
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint capacity()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_capacity(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void reserve(uint n)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_reserve(swigCPtr, n);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void resize(uint logicalLength)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_resize(swigCPtr, logicalLength);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Add(OdPrcFile val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_Add(swigCPtr, OdPrcFile.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPrcFile getitemcopy(int index)
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_getitemcopy(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private OdPrcFile getitem(int index)
	{
		OdPrcFile rXObject = Helpers.GetRXObject<OdPrcFile>(OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_getitem(swigCPtr, index), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int index, OdPrcFile val)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_setitem(swigCPtr, index, OdPrcFile.getCPtr(val));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void AddRange(OdPrcFilePtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_AddRange(swigCPtr, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdPrcFilePtrArray GetRange(int index, int count)
	{
		OdPrcFilePtrArray result = Helpers.GetObject<OdPrcFilePtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_GetRange(swigCPtr, index, count), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Insert(int index, OdPrcFile x)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_Insert(swigCPtr, index, OdPrcFile.getCPtr(x));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void InsertRange(int index, OdPrcFilePtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_InsertRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveAt(int index)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_RemoveAt(swigCPtr, index);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void RemoveRange(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_RemoveRange(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public static OdPrcFilePtrArray Repeat(OdPrcFile value, int count)
	{
		OdPrcFilePtrArray result = Helpers.GetObject<OdPrcFilePtrArray>(OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_Repeat(OdPrcFile.getCPtr(value), count), bOwn: false, bTryAddToTransaction: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Reverse()
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_Reverse__SWIG_0(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void Reverse(int index, int count)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_Reverse__SWIG_1(swigCPtr, index, count);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public void SetRange(int index, OdPrcFilePtrArray values)
	{
		OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_SetRange(swigCPtr, index, getCPtr(values));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Contains(OdPrcFile value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_Contains(swigCPtr, OdPrcFile.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int IndexOf(OdPrcFile value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_IndexOf(swigCPtr, OdPrcFile.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public int LastIndexOf(OdPrcFile value)
	{
		int result = OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_LastIndexOf(swigCPtr, OdPrcFile.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(OdPrcFile value)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdPrcFilePtrArray_Remove(swigCPtr, OdPrcFile.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
