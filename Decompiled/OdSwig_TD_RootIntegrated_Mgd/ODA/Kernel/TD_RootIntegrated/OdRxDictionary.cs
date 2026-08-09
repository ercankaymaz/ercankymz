using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class OdRxDictionary : OdRxObject, IEnumerable, IDictionary<string, OdRxObject>, ICollection<KeyValuePair<string, OdRxObject>>, IEnumerable<KeyValuePair<string, OdRxObject>>
{
	public sealed class OdRxDictionaryEnumerator : IEnumerator, IEnumerator<KeyValuePair<string, OdRxObject>>, IDisposable
	{
		private OdRxDictionary collectionRef;

		private OdRxDictionaryIterator iterator;

		private bool enumerationStarted;

		public KeyValuePair<string, OdRxObject> Current
		{
			get
			{
				if (!enumerationStarted)
				{
					throw new InvalidOperationException("Enumeration not started.");
				}
				if (iterator.done())
				{
					throw new InvalidOperationException("Enumeration finished.");
				}
				return new KeyValuePair<string, OdRxObject>(iterator.getKey(), iterator.getObject());
			}
		}

		object IEnumerator.Current => Current;

		public OdRxDictionaryEnumerator(OdRxDictionary collection)
		{
			collectionRef = collection;
			iterator = collectionRef.newIterator(OdRx_DictIterType.kDictCollated);
			enumerationStarted = false;
		}

		public bool MoveNext()
		{
			if (enumerationStarted && !iterator.done())
			{
				iterator.next();
			}
			else
			{
				enumerationStarted = true;
			}
			return !iterator.done();
		}

		public void Reset()
		{
			enumerationStarted = false;
			iterator = collectionRef.newIterator(OdRx_DictIterType.kDictCollated);
		}

		public void Dispose()
		{
			collectionRef = null;
			iterator = null;
		}
	}

	private object locker = new object();

	private HandleRef swigCPtr;

	public OdRxObject this[string key]
	{
		get
		{
			return getAt(key);
		}
		set
		{
			putAt(key, value, out var _);
		}
	}

	public bool IsReadOnly => false;

	public int Count => (int)numEntries();

	public ICollection<string> Keys
	{
		get
		{
			string[] array = new string[numEntries()];
			int num = 0;
			OdRxDictionaryIterator odRxDictionaryIterator = newIterator(OdRx_DictIterType.kDictCollated);
			while (!odRxDictionaryIterator.done())
			{
				array[++num] = odRxDictionaryIterator.getKey();
				odRxDictionaryIterator.next();
			}
			return array;
		}
	}

	public ICollection<OdRxObject> Values
	{
		get
		{
			OdRxObject[] array = new OdRxObject[numEntries()];
			int num = 0;
			OdRxDictionaryIterator odRxDictionaryIterator = newIterator(OdRx_DictIterType.kDictCollated);
			while (!odRxDictionaryIterator.done())
			{
				array[++num] = odRxDictionaryIterator.getObject();
				odRxDictionaryIterator.next();
			}
			return array;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public OdRxDictionary(IntPtr cPtr, bool cMemoryOwn)
		: base(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_SWIGUpcast(cPtr), cMemoryOwn)
	{
		swigCPtr = new HandleRef(this, cPtr);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static HandleRef getCPtr(OdRxDictionary obj)
	{
		return obj?.swigCPtr ?? new HandleRef(null, IntPtr.Zero);
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (swigCPtr.Handle != IntPtr.Zero)
			{
				if (swigCMemOwn)
				{
					swigCMemOwn = false;
					TD_RootIntegrated_GlobalsPINVOKE.delete_OdRxDictionary(swigCPtr);
				}
				swigCPtr = new HandleRef(null, IntPtr.Zero);
			}
			base.Dispose(disposing);
		}
	}

	public bool ContainsKey(string key)
	{
		return has(key);
	}

	public void Add(string key, OdRxObject value)
	{
		putAt(key, value, out var _);
	}

	public bool Remove(string key)
	{
		return remove(key) != null;
	}

	public bool TryGetValue(string key, out OdRxObject value)
	{
		value = getAt(key);
		return value != null;
	}

	public void Add(KeyValuePair<string, OdRxObject> p)
	{
		putAt(p.Key, p.Value, out var _);
	}

	public void Clear()
	{
		List<string> list = new List<string>();
		OdRxDictionaryIterator odRxDictionaryIterator = newIterator(OdRx_DictIterType.kDictCollated);
		while (!odRxDictionaryIterator.done())
		{
			list.Add(odRxDictionaryIterator.getKey());
			odRxDictionaryIterator.next();
		}
		foreach (string item in list)
		{
			remove(item);
		}
	}

	public bool Contains(KeyValuePair<string, OdRxObject> p)
	{
		if (!has(p.Key))
		{
			return false;
		}
		return OdRxObject.getCPtr(getAt(p.Key)).Handle == OdRxObject.getCPtr(p.Value).Handle;
	}

	public void CopyTo(KeyValuePair<string, OdRxObject>[] a, int N)
	{
		for (int i = N; i < a.Length; i++)
		{
			putAt(a[i].Key, a[i].Value, out var _);
		}
	}

	public bool Remove(KeyValuePair<string, OdRxObject> p)
	{
		return Remove(p.Key);
	}

	IEnumerator<KeyValuePair<string, OdRxObject>> IEnumerable<KeyValuePair<string, OdRxObject>>.GetEnumerator()
	{
		return new OdRxDictionaryEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new OdRxDictionaryEnumerator(this);
	}

	public new static OdRxDictionary cast(OdRxObject pObj)
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_cast(OdRxObject.getCPtr(pObj)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public new static OdRxClass desc()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_desc(), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxClass isA()
	{
		OdRxClass rXObject = Helpers.GetRXObject<OdRxClass>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_isA(swigCPtr), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public override OdRxObject queryX(OdRxClass protocolClass)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_queryX(swigCPtr, OdRxClass.getCPtr(protocolClass)), bOwn: false, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public static OdRxDictionary createObject()
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_createObject(), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual void reserve(uint minSize)
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_reserve(swigCPtr, minSize);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual OdRxObject getAt(string key)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_getAt__SWIG_0(swigCPtr, key), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject getAt(uint id)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_getAt__SWIG_1(swigCPtr, id), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject putAt(string key, OdRxObject pObject, out uint pRetId)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_putAt__SWIG_0(swigCPtr, key, OdRxObject.getCPtr(pObject), out pRetId), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject putAt(string key, OdRxObject pObject)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_putAt__SWIG_1(swigCPtr, key, OdRxObject.getCPtr(pObject)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject putAt(uint id, OdRxObject pObject)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_putAt__SWIG_2(swigCPtr, id, OdRxObject.getCPtr(pObject)), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool resetKey(uint id, string newKey)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_resetKey(swigCPtr, id, newKey);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxObject remove(string key)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_remove__SWIG_0(swigCPtr, key), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxObject remove(uint id)
	{
		OdRxObject rXObject = Helpers.GetRXObject<OdRxObject>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_remove__SWIG_1(swigCPtr, id), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public void removeAll()
	{
		TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_removeAll(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
	}

	public virtual bool has(string key)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_has__SWIG_0(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual bool has(uint id)
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_has__SWIG_1(swigCPtr, id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint idAt(string key)
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_idAt(swigCPtr, key);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual string keyAt(uint id)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_keyAt(swigCPtr, id);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual uint numEntries()
	{
		uint result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_numEntries(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public virtual OdRxDictionaryIterator newIterator(OdRx_DictIterType iterType)
	{
		OdRxDictionaryIterator rXObject = Helpers.GetRXObject<OdRxDictionaryIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_newIterator__SWIG_0(swigCPtr, (int)iterType), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual OdRxDictionaryIterator newIterator()
	{
		OdRxDictionaryIterator rXObject = Helpers.GetRXObject<OdRxDictionaryIterator>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_newIterator__SWIG_1(swigCPtr), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	public virtual bool isCaseSensitive()
	{
		bool result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_isCaseSensitive(swigCPtr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}

	public OdRxDictionary subDict(string path, int numSteps)
	{
		OdRxDictionary rXObject = Helpers.GetRXObject<OdRxDictionary>(TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_subDict(swigCPtr, path, numSteps), bOwn: true, bTryAddToTransaction: true);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return rXObject;
	}

	protected new static string getRealClassName(IntPtr ptr)
	{
		string result = TD_RootIntegrated_GlobalsPINVOKE.OdRxDictionary_getRealClassName(ptr);
		if (TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Pending)
		{
			throw TD_RootIntegrated_GlobalsPINVOKE.SWIGPendingException.Retrieve();
		}
		return result;
	}
}
