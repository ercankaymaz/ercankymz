using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdGsMarkerSet : IDisposable, IDictionary<int, OdGsSimpleParam>, ICollection<KeyValuePair<int, OdGsSimpleParam>>, IEnumerable<KeyValuePair<int, OdGsSimpleParam>>, IEnumerable
{
	public class OdGsMarkerSetEnumerator : IEnumerator, IEnumerator<KeyValuePair<int, OdGsSimpleParam>>, IDisposable
	{
		private OdGsMarkerSet collectionRef;

		private IList<int> keyCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public KeyValuePair<int, OdGsSimpleParam> Current
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
				return (KeyValuePair<int, OdGsSimpleParam>)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdGsMarkerSetEnumerator(OdGsMarkerSet collection)
		{
			collectionRef = collection;
			keyCollection = new List<int>(collection.Keys);
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
					int key = keyCollection[currentIndex];
					currentObject = new KeyValuePair<int, OdGsSimpleParam>(key, collectionRef[key]);
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

	public OdGsSimpleParam this[int key]
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

	public ICollection<int> Keys
	{
		get
		{
			ICollection<int> collection = new List<int>();
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

	public ICollection<OdGsSimpleParam> Values
	{
		get
		{
			ICollection<OdGsSimpleParam> collection = new List<OdGsSimpleParam>();
			using OdGsMarkerSetEnumerator odGsMarkerSetEnumerator = GetEnumerator();
			while (odGsMarkerSetEnumerator.MoveNext())
			{
				collection.Add(odGsMarkerSetEnumerator.Current.Value);
			}
			return collection;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdGsMarkerSet(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdGsMarkerSet obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdGsMarkerSet()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdGsMarkerSet(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool TryGetValue(int key, out OdGsSimpleParam value)
	{
		if (ContainsKey(key))
		{
			value = this[key];
			return true;
		}
		value = null;
		return false;
	}

	public void Add(KeyValuePair<int, OdGsSimpleParam> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Remove(KeyValuePair<int, OdGsSimpleParam> item)
	{
		if (Contains(item))
		{
			return Remove(item.Key);
		}
		return false;
	}

	public bool Contains(KeyValuePair<int, OdGsSimpleParam> item)
	{
		if (this[item.Key] == item.Value)
		{
			return true;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<int, OdGsSimpleParam>[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(KeyValuePair<int, OdGsSimpleParam>[] array, int arrayIndex)
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
		IList<int> list = new List<int>(Keys);
		for (int i = 0; i < list.Count; i++)
		{
			int key = list[i];
			array.SetValue(new KeyValuePair<int, OdGsSimpleParam>(key, this[key]), arrayIndex + i);
		}
	}

	IEnumerator<KeyValuePair<int, OdGsSimpleParam>> IEnumerable<KeyValuePair<int, OdGsSimpleParam>>.GetEnumerator()
	{
		return new OdGsMarkerSetEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdGsMarkerSetEnumerator(this);
	}

	public OdGsMarkerSetEnumerator GetEnumerator()
	{
		return new OdGsMarkerSetEnumerator(this);
	}

	public OdGsMarkerSet()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsMarkerSet__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdGsMarkerSet(OdGsMarkerSet other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdGsMarkerSet__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private OdGsSimpleParam getitem(int key)
	{
		OdGsSimpleParam rXObject = Helpers.GetRXObject<OdGsSimpleParam>(TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_getitem(swigCPtr, key), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	private void setitem(int key, OdGsSimpleParam x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_setitem(swigCPtr, key, OdGsSimpleParam.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ContainsKey(int key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_ContainsKey(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Add(int key, OdGsSimpleParam value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_Add(swigCPtr, key, OdGsSimpleParam.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Remove(int key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_Remove(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_create_iterator_begin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private int get_next_key(IntPtr swigiterator)
	{
		int result = TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_get_next_key(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdGsMarkerSet_destroy_iterator(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
