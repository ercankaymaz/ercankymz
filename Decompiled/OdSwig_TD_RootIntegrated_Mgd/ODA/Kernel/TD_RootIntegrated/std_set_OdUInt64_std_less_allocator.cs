using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class std_set_OdUInt64_std_less_allocator : IDisposable, ISet<ulong>, ICollection<ulong>, IEnumerable<ulong>, IEnumerable
{
	public sealed class std_set_OdUInt64_std_less_allocatorEnumerator : IEnumerator, IEnumerator<ulong>, IDisposable
	{
		private std_set_OdUInt64_std_less_allocator collectionRef;

		private IList<ulong> ItemsCollection;

		private int currentIndex;

		private object currentObject;

		private int currentSize;

		public ulong Current
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
				return (ulong)currentObject;
			}
		}

		object IEnumerator.Current => Current;

		public std_set_OdUInt64_std_less_allocatorEnumerator(std_set_OdUInt64_std_less_allocator collection)
		{
			collectionRef = collection;
			ItemsCollection = new List<ulong>(collection.Items);
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

	private ICollection<ulong> Items
	{
		get
		{
			ICollection<ulong> collection = new List<ulong>();
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
	public std_set_OdUInt64_std_less_allocator(IntPtr cPtr, bool cMemoryOwn)
	{
		swigCMemOwn = cMemoryOwn;
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(std_set_OdUInt64_std_less_allocator obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	~std_set_OdUInt64_std_less_allocator()
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
					TD_RootIntegrated_GlobalsPINVOKE.delete_std_set_OdUInt64_std_less_allocator(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
		}
	}

	void ICollection<ulong>.Add(ulong item)
	{
		((ISet<ulong>)this).Add(item);
	}

	public bool TryGetValue(ulong equalValue, out ulong actualValue)
	{
		try
		{
			actualValue = getitem(equalValue);
			return true;
		}
		catch
		{
			actualValue = 0uL;
			return false;
		}
	}

	public void CopyTo(ulong[] array)
	{
		CopyTo(array, 0);
	}

	public void CopyTo(ulong[] array, int arrayIndex)
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
		using std_set_OdUInt64_std_less_allocatorEnumerator std_set_OdUInt64_std_less_allocatorEnumerator2 = GetEnumerator();
		while (std_set_OdUInt64_std_less_allocatorEnumerator2.MoveNext())
		{
			ulong current = std_set_OdUInt64_std_less_allocatorEnumerator2.Current;
			array.SetValue(current, arrayIndex++);
		}
	}

	public void ExceptWith(IEnumerable<ulong> other)
	{
		foreach (ulong item in other)
		{
			Remove(item);
		}
	}

	public void IntersectWith(IEnumerable<ulong> other)
	{
		std_set_OdUInt64_std_less_allocator std_set_OdUInt64_std_less_allocator2 = new std_set_OdUInt64_std_less_allocator(this);
		Clear();
		foreach (ulong item in other)
		{
			if (std_set_OdUInt64_std_less_allocator2.Contains(item))
			{
				Add(item);
			}
		}
	}

	private static int count_enum(IEnumerable<ulong> other)
	{
		int num = 0;
		foreach (ulong item in other)
		{
			_ = item;
			num++;
		}
		return num;
	}

	public bool IsProperSubsetOf(IEnumerable<ulong> other)
	{
		if (IsSubsetOf(other))
		{
			return Count < count_enum(other);
		}
		return false;
	}

	public bool IsProperSupersetOf(IEnumerable<ulong> other)
	{
		if (IsSupersetOf(other))
		{
			return Count > count_enum(other);
		}
		return false;
	}

	public bool IsSubsetOf(IEnumerable<ulong> other)
	{
		int num = 0;
		foreach (ulong item in other)
		{
			if (Contains(item))
			{
				num++;
			}
		}
		return num == Count;
	}

	public bool IsSupersetOf(IEnumerable<ulong> other)
	{
		foreach (ulong item in other)
		{
			if (!Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	public bool Overlaps(IEnumerable<ulong> other)
	{
		foreach (ulong item in other)
		{
			if (Contains(item))
			{
				return true;
			}
		}
		return false;
	}

	public bool SetEquals(IEnumerable<ulong> other)
	{
		if (IsSupersetOf(other))
		{
			return Count == count_enum(other);
		}
		return false;
	}

	public void SymmetricExceptWith(IEnumerable<ulong> other)
	{
		foreach (ulong item in other)
		{
			if (!Remove(item))
			{
				Add(item);
			}
		}
	}

	public void UnionWith(IEnumerable<ulong> other)
	{
		foreach (ulong item in other)
		{
			Add(item);
		}
	}

	IEnumerator<ulong> IEnumerable<ulong>.GetEnumerator()
	{
		return new std_set_OdUInt64_std_less_allocatorEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new std_set_OdUInt64_std_less_allocatorEnumerator(this);
	}

	public std_set_OdUInt64_std_less_allocatorEnumerator GetEnumerator()
	{
		return new std_set_OdUInt64_std_less_allocatorEnumerator(this);
	}

	public std_set_OdUInt64_std_less_allocator()
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_set_OdUInt64_std_less_allocator__SWIG_0(), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public std_set_OdUInt64_std_less_allocator(std_set_OdUInt64_std_less_allocator other)
		: this(TD_RootIntegrated_GlobalsPINVOKE.new_std_set_OdUInt64_std_less_allocator__SWIG_1(getCPtr(other)), cMemoryOwn: true)
	{
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	private uint size()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_size(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool empty()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_empty(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public void Clear()
	{
		TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_Clear(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public bool Add(ulong item)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_Add(swigCPtr, item);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Contains(ulong item)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_Contains(swigCPtr, item);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public bool Remove(ulong item)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_Remove(swigCPtr, item);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private ulong getitem(ulong item)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_getitem(swigCPtr, item);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private IntPtr create_iterator_begin()
	{
		IntPtr result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_create_iterator_begin(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private ulong get_next(IntPtr swigiterator)
	{
		ulong result = TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_get_next(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	private void destroy_iterator(IntPtr swigiterator)
	{
		TD_RootIntegrated_GlobalsPINVOKE.std_set_OdUInt64_std_less_allocator_destroy_iterator(swigCPtr, swigiterator);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}
}
