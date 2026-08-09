using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ODA.Kernel.TD_RootIntegrated;

namespace ODA.Prc.OdPrcModule;

public class OdRxObject2OdRxObjectMap : IDisposable, IDictionary<OdRxObject, OdRxObject>, ICollection<KeyValuePair<OdRxObject, OdRxObject>>, IEnumerable<KeyValuePair<OdRxObject, OdRxObject>>, IEnumerable
{
	public class OdRxObject2OdRxObjectMapEnumerator : IEnumerator, IEnumerator<KeyValuePair<OdRxObject, OdRxObject>>, IDisposable
	{
		private OdRxObject2OdRxObjectMap collectionRef;

		private IList<OdRxObject> keyCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public KeyValuePair<OdRxObject, OdRxObject> Current
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
				return (KeyValuePair<OdRxObject, OdRxObject>)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdRxObject2OdRxObjectMapEnumerator(OdRxObject2OdRxObjectMap collection)
		{
			collectionRef = collection;
			keyCollection = new List<OdRxObject>(collection.Keys);
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
					OdRxObject key = keyCollection[currentIndex];
					currentObject = new KeyValuePair<OdRxObject, OdRxObject>(key, collectionRef[key]);
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

	public OdRxObject this[OdRxObject key]
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

	public ICollection<OdRxObject> Keys
	{
		get
		{
			ICollection<OdRxObject> collection = new List<OdRxObject>();
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

	public ICollection<OdRxObject> Values
	{
		get
		{
			ICollection<OdRxObject> collection = new List<OdRxObject>();
			using OdRxObject2OdRxObjectMapEnumerator odRxObject2OdRxObjectMapEnumerator = GetEnumerator();
			while (odRxObject2OdRxObjectMapEnumerator.MoveNext())
			{
				collection.Add(odRxObject2OdRxObjectMapEnumerator.Current.Value);
			}
			return collection;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxObject2OdRxObjectMap(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxObject2OdRxObjectMap obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdRxObject2OdRxObjectMap()
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
					OdPrcModule_GlobalsPINVOKE.delete_OdRxObject2OdRxObjectMap(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool TryGetValue(OdRxObject key, out OdRxObject value)
	{
		if (ContainsKey(key))
		{
			value = this[key];
			return true;
		}
		value = null;
		return false;
	}

	public void Add(KeyValuePair<OdRxObject, OdRxObject> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Remove(KeyValuePair<OdRxObject, OdRxObject> item)
	{
		if (Contains(item))
		{
			return Remove(item.Key);
		}
		return false;
	}

	public bool Contains(KeyValuePair<OdRxObject, OdRxObject> item)
	{
		if (this[item.Key] == item.Value)
		{
			return true;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<OdRxObject, OdRxObject>[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(KeyValuePair<OdRxObject, OdRxObject>[] array, int arrayIndex)
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
		IList<OdRxObject> list = new List<OdRxObject>(Keys);
		for (int i = 0; i < list.Count; i++)
		{
			OdRxObject key = list[i];
			array.SetValue(new KeyValuePair<OdRxObject, OdRxObject>(key, this[key]), arrayIndex + i);
		}
	}

	IEnumerator<KeyValuePair<OdRxObject, OdRxObject>> IEnumerable<KeyValuePair<OdRxObject, OdRxObject>>.GetEnumerator()
	{
		return new OdRxObject2OdRxObjectMapEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdRxObject2OdRxObjectMapEnumerator(this);
	}

	public OdRxObject2OdRxObjectMapEnumerator GetEnumerator()
	{
		return new OdRxObject2OdRxObjectMapEnumerator(this);
	}

	public OdRxObject2OdRxObjectMap()
		: this(OdPrcModule_GlobalsPINVOKE.new_OdRxObject2OdRxObjectMap__SWIG_0(), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdRxObject2OdRxObjectMap(OdRxObject2OdRxObjectMap other)
		: this(OdPrcModule_GlobalsPINVOKE.new_OdRxObject2OdRxObjectMap__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_size(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_empty(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_Clear(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdRxObject getitem(OdRxObject key)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_getitem(swigCPtr, OdRxObject.getCPtr(key)), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(OdRxObject key, OdRxObject x)
	{
		OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_setitem(swigCPtr, OdRxObject.getCPtr(key), OdRxObject.getCPtr(x));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ContainsKey(OdRxObject key)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_ContainsKey(swigCPtr, OdRxObject.getCPtr(key));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Add(OdRxObject key, OdRxObject value)
	{
		OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_Add(swigCPtr, OdRxObject.getCPtr(key), OdRxObject.getCPtr(value));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Remove(OdRxObject key)
	{
		bool result = OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_Remove(swigCPtr, OdRxObject.getCPtr(key));
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_create_iterator_begin(swigCPtr);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private OdRxObject get_next_key(IntPtr swigiterator)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_get_next_key(swigCPtr, swigiterator), bOwn: true, bTryAddToTransaction: true);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		OdPrcModule_GlobalsPINVOKE.OdRxObject2OdRxObjectMap_destroy_iterator(swigCPtr, swigiterator);
		if (OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw OdPrcModule_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
