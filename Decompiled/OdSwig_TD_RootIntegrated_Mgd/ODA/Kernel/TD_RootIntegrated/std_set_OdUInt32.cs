using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class std_set_OdUInt32 : IDisposable, ISet<uint>, ICollection<uint>, IEnumerable<uint>, IEnumerable
{
	public sealed class std_set_OdUInt32Enumerator : IEnumerator, IEnumerator<uint>, IDisposable
	{
		private std_set_OdUInt32 collectionRef;

		private IList<uint> ItemsCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public uint Current
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
				return (uint)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public std_set_OdUInt32Enumerator(std_set_OdUInt32 collection)
		{
			collectionRef = collection;
			ItemsCollection = new List<uint>(collection.Items);
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
					currentObject = ItemsCollection[currentIndex];
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

	public int Count => (int)size();

	public bool IsReadOnly => false;

	private ICollection<uint> Items
	{
		get
		{
			ICollection<uint> collection = new List<uint>();
			int count = Count;
			if (count > 0)
			{
				IntPtr swigiterator = create_iterator_begin();
				for (int i = 0; i < count; i++)
				{
					collection.Add(get_next(swigiterator));
				}
				destroy_iterator(swigiterator);
			}
			return collection;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public std_set_OdUInt32(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(std_set_OdUInt32 obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~std_set_OdUInt32()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_std_set_OdUInt32(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	void ICollection<uint>.Add(uint item)
	{
		((ISet<uint>)this).Add(item);
	}

	public bool TryGetValue(uint equalValue, out uint actualValue)
	{
		try
		{
			actualValue = getitem(equalValue);
			return true;
		}
		catch
		{
			actualValue = 0u;
			return false;
		}
	}

	public void CopyTo(uint[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(uint[] array, int arrayIndex)
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
		using std_set_OdUInt32Enumerator std_set_OdUInt32Enumerator2 = GetEnumerator();
		while (std_set_OdUInt32Enumerator2.MoveNext())
		{
			uint current = std_set_OdUInt32Enumerator2.Current;
			array.SetValue(current, arrayIndex++);
		}
	}

	public void ExceptWith(IEnumerable<uint> other)
	{
		foreach (uint item in other)
		{
			Remove(item);
		}
	}

	public void IntersectWith(IEnumerable<uint> other)
	{
		std_set_OdUInt32 std_set_OdUInt33 = new std_set_OdUInt32(this);
		Clear();
		foreach (uint item in other)
		{
			if (std_set_OdUInt33.Contains(item))
			{
				Add(item);
			}
		}
	}

	private static int count_enum(IEnumerable<uint> other)
	{
		int num = 0;
		foreach (uint item in other)
		{
			_ = item;
			num++;
		}
		return num;
	}

	public bool IsProperSubsetOf(IEnumerable<uint> other)
	{
		if (IsSubsetOf(other))
		{
			return Count < count_enum(other);
		}
		return false;
	}

	public bool IsProperSupersetOf(IEnumerable<uint> other)
	{
		if (IsSupersetOf(other))
		{
			return Count > count_enum(other);
		}
		return false;
	}

	public bool IsSubsetOf(IEnumerable<uint> other)
	{
		int num = 0;
		foreach (uint item in other)
		{
			if (Contains(item))
			{
				num++;
			}
		}
		return num == Count;
	}

	public bool IsSupersetOf(IEnumerable<uint> other)
	{
		foreach (uint item in other)
		{
			if (!Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	public bool Overlaps(IEnumerable<uint> other)
	{
		foreach (uint item in other)
		{
			if (Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool SetEquals(IEnumerable<uint> other)
	{
		if (IsSupersetOf(other))
		{
			return Count == count_enum(other);
		}
		return false;
	}

	public void SymmetricExceptWith(IEnumerable<uint> other)
	{
		foreach (uint item in other)
		{
			if (!Remove(item))
			{
				Add(item);
			}
		}
	}

	public void UnionWith(IEnumerable<uint> other)
	{
		foreach (uint item in other)
		{
			Add(item);
		}
	}

	IEnumerator<uint> IEnumerable<uint>.GetEnumerator()
	{
		return new std_set_OdUInt32Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new std_set_OdUInt32Enumerator(this);
	}

	public std_set_OdUInt32Enumerator GetEnumerator()
	{
		return new std_set_OdUInt32Enumerator(this);
	}

	public std_set_OdUInt32()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_set_OdUInt32__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_set_OdUInt32(std_set_OdUInt32 other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_set_OdUInt32__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Add(uint item)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_Add(swigCPtr, item);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Contains(uint item)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_Contains(swigCPtr, item);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(uint item)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_Remove(swigCPtr, item);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint getitem(uint item)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_getitem(swigCPtr, item);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_create_iterator_begin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private uint get_next(IntPtr swigiterator)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_get_next(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt32_destroy_iterator(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
