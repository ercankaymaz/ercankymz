using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Prc.OdPrcModule;

public class std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator : IDisposable, IDictionary<OdPrcObjectId, OdPrcObjectIdArray>, ICollection<KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>>, IEnumerable<KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>>, IEnumerable
{
	public class std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator : IEnumerator, IEnumerator<KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>>, IDisposable
	{
		private std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator collectionRef;

		private IList<OdPrcObjectId> keyCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray> Current
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
				return (KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator(std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator collection)
		{
			collectionRef = collection;
			keyCollection = new List<OdPrcObjectId>(collection.Keys);
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
					OdPrcObjectId key = keyCollection[currentIndex];
					currentObject = new KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>(key, collectionRef[key]);
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

	public OdPrcObjectIdArray this[OdPrcObjectId key]
	{
		get
		{
			return getitem(key);
		}
		set
		{
			setitem(key, value);
		}
	}

	public int Count => (int)size();

	public bool IsReadOnly => false;

	public ICollection<OdPrcObjectId> Keys
	{
		get
		{
			ICollection<OdPrcObjectId> collection = new List<OdPrcObjectId>();
			int count = Count;
			if (count > 0)
			{
				IntPtr swigiterator = create_iterator_begin();
				for (int i = 0; i < count; i++)
				{
					collection.Add(get_next_key(swigiterator));
				}
				destroy_iterator(swigiterator);
			}
			return collection;
		}
	}

	public ICollection<OdPrcObjectIdArray> Values
	{
		get
		{
			ICollection<OdPrcObjectIdArray> collection = new List<OdPrcObjectIdArray>();
			using std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator2 = GetEnumerator();
			while (std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator2.MoveNext())
			{
				collection.Add(std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator2.Current.Value);
			}
			return collection;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator()
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
					OdPrcModule_GlobalsPINVOKE.delete_std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool TryGetValue(OdPrcObjectId key, out OdPrcObjectIdArray value)
	{
		if (ContainsKey(key))
		{
			value = this[key];
			return true;
		}
		value = null;
		return false;
	}

	public void Add(KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Remove(KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray> item)
	{
		if (Contains(item))
		{
			return Remove(item.Key);
		}
		return false;
	}

	public bool Contains(KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray> item)
	{
		if (this[item.Key] == item.Value)
		{
			return true;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
		}
		if (array.Rank > 1)
		{
			throw new ArgumentException("Multi dimensional array.", "array");
		}
		if (arrayIndex + Count > array.Length)
		{
			throw new ArgumentException("Number of elements to copy is too large.");
		}
		IList<OdPrcObjectId> list = new List<OdPrcObjectId>(Keys);
		for (int i = 0; i < list.Count; i++)
		{
			OdPrcObjectId key = list[i];
			array.SetValue(new KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>(key, this[key]), arrayIndex + i);
		}
	}

	IEnumerator<KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>> IEnumerable<KeyValuePair<OdPrcObjectId, OdPrcObjectIdArray>>.GetEnumerator()
	{
		return new std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator(this);
	}

	public std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator GetEnumerator()
	{
		return new std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocatorEnumerator(this);
	}

	public std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator()
		: this(OdPrcModule_GlobalsPINVOKE.new_std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator__SWIG_0(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator(std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator other)
		: this(OdPrcModule_GlobalsPINVOKE.new_std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_empty(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdPrcObjectIdArray getitem(OdPrcObjectId key)
	{
		OdPrcObjectIdArray result = new OdPrcObjectIdArray(OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_getitem(swigCPtr, OdPrcObjectId.getCPtr(key)), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(OdPrcObjectId key, OdPrcObjectIdArray x)
	{
		OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_setitem(swigCPtr, OdPrcObjectId.getCPtr(key), OdPrcObjectIdArray.getCPtr(x).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ContainsKey(OdPrcObjectId key)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_ContainsKey(swigCPtr, OdPrcObjectId.getCPtr(key));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Add(OdPrcObjectId key, OdPrcObjectIdArray value)
	{
		OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_Add(swigCPtr, OdPrcObjectId.getCPtr(key), OdPrcObjectIdArray.getCPtr(value).Handle);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Remove(OdPrcObjectId key)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_Remove(swigCPtr, OdPrcObjectId.getCPtr(key));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_create_iterator_begin(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdPrcObjectId get_next_key(IntPtr swigiterator)
	{
		OdPrcObjectId result = new OdPrcObjectId(OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_get_next_key(swigCPtr, swigiterator), cMemoryOwn: false);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		OdPrcModule_GlobalsPINVOKE.std_map_OdPrcObjectId_OdArray_OdPrcObjectId_OdObjectsAllocator_destroy_iterator(swigCPtr, swigiterator);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
