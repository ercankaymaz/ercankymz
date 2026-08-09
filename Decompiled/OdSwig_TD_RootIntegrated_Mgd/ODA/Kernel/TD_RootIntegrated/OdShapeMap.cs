using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdShapeMap : IDisposable, IDictionary<ushort, _OdShapeInfo>, ICollection<KeyValuePair<ushort, _OdShapeInfo>>, IEnumerable<KeyValuePair<ushort, _OdShapeInfo>>, IEnumerable
{
	public class OdShapeMapEnumerator : IEnumerator, IEnumerator<KeyValuePair<ushort, _OdShapeInfo>>, IDisposable
	{
		private OdShapeMap collectionRef;

		private IList<ushort> keyCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public KeyValuePair<ushort, _OdShapeInfo> Current
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
				return (KeyValuePair<ushort, _OdShapeInfo>)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public OdShapeMapEnumerator(OdShapeMap collection)
		{
			collectionRef = collection;
			keyCollection = new List<ushort>(collection.Keys);
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
					ushort key = keyCollection[currentIndex];
					currentObject = new KeyValuePair<ushort, _OdShapeInfo>(key, collectionRef[key]);
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

	public _OdShapeInfo this[ushort key]
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

	public ICollection<ushort> Keys
	{
		get
		{
			ICollection<ushort> collection = new List<ushort>();
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

	public ICollection<_OdShapeInfo> Values
	{
		get
		{
			ICollection<_OdShapeInfo> collection = new List<_OdShapeInfo>();
			using OdShapeMapEnumerator odShapeMapEnumerator = GetEnumerator();
			while (odShapeMapEnumerator.MoveNext())
			{
				collection.Add(odShapeMapEnumerator.Current.Value);
			}
			return collection;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdShapeMap(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdShapeMap obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~OdShapeMap()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdShapeMap(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	public bool TryGetValue(ushort key, out _OdShapeInfo value)
	{
		if (ContainsKey(key))
		{
			value = this[key];
			return true;
		}
		value = null;
		return false;
	}

	public void Add(KeyValuePair<ushort, _OdShapeInfo> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Remove(KeyValuePair<ushort, _OdShapeInfo> item)
	{
		if (Contains(item))
		{
			return Remove(item.Key);
		}
		return false;
	}

	public bool Contains(KeyValuePair<ushort, _OdShapeInfo> item)
	{
		if (this[item.Key] == item.Value)
		{
			return true;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<ushort, _OdShapeInfo>[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(KeyValuePair<ushort, _OdShapeInfo>[] array, int arrayIndex)
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
		IList<ushort> list = new List<ushort>(Keys);
		for (int i = 0; i < list.Count; i++)
		{
			ushort key = list[i];
			array.SetValue(new KeyValuePair<ushort, _OdShapeInfo>(key, this[key]), arrayIndex + i);
		}
	}

	IEnumerator<KeyValuePair<ushort, _OdShapeInfo>> IEnumerable<KeyValuePair<ushort, _OdShapeInfo>>.GetEnumerator()
	{
		return new OdShapeMapEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdShapeMapEnumerator(this);
	}

	public OdShapeMapEnumerator GetEnumerator()
	{
		return new OdShapeMapEnumerator(this);
	}

	public OdShapeMap()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdShapeMap__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public OdShapeMap(OdShapeMap other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_OdShapeMap__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private _OdShapeInfo getitem(ushort key)
	{
		_OdShapeInfo result = new _OdShapeInfo(TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_getitem(swigCPtr, key), cMemoryOwn: false);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void setitem(ushort key, _OdShapeInfo x)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_setitem(swigCPtr, key, _OdShapeInfo.getCPtr(x));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool ContainsKey(ushort key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_ContainsKey(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Add(ushort key, _OdShapeInfo value)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_Add(swigCPtr, key, _OdShapeInfo.getCPtr(value));
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Remove(ushort key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_Remove(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_create_iterator_begin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private ushort get_next_key(IntPtr swigiterator)
	{
		ushort result = TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_get_next_key(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdShapeMap_destroy_iterator(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
