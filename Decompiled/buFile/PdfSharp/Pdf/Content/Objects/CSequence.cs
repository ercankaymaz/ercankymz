using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("(count={Count})")]
public class CSequence : CObject, IList<CObject>, ICollection<CObject>, IEnumerable<CObject>, IEnumerable
{
	private List<CObject> _items = new List<CObject>();

	public CObject this[int index]
	{
		get
		{
			return _items[index];
		}
		set
		{
			_items[index] = value;
		}
	}

	public int Count => _items.Count;

	CObject IList<CObject>.this[int index]
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	int ICollection<CObject>.Count
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	bool ICollection<CObject>.IsReadOnly
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public new CSequence Clone()
	{
		return (CSequence)Copy();
	}

	protected override CObject Copy()
	{
		CObject result = base.Copy();
		_items = new List<CObject>(_items);
		for (int i = 0; i < _items.Count; i++)
		{
			_items[i] = _items[i].Clone();
		}
		return result;
	}

	public void Add(CSequence sequence)
	{
		int count = sequence.Count;
		for (int i = 0; i < count; i++)
		{
			_items.Add(sequence[i]);
		}
	}

	public void Add(CObject value)
	{
		_items.Add(value);
	}

	public void Clear()
	{
		_items.Clear();
	}

	public bool Contains(CObject value)
	{
		return _items.Contains(value);
	}

	public int IndexOf(CObject value)
	{
		return _items.IndexOf(value);
	}

	public void Insert(int index, CObject value)
	{
		_items.Insert(index, value);
	}

	public bool Remove(CObject value)
	{
		return _items.Remove(value);
	}

	public void RemoveAt(int index)
	{
		_items.RemoveAt(index);
	}

	public void CopyTo(CObject[] array, int index)
	{
		_items.CopyTo(array, index);
	}

	public IEnumerator<CObject> GetEnumerator()
	{
		return _items.GetEnumerator();
	}

	public byte[] ToContent()
	{
		Stream stream = new MemoryStream();
		ContentWriter contentWriter = new ContentWriter(stream);
		WriteObject(contentWriter);
		contentWriter.Close(closeUnderlyingStream: false);
		stream.Position = 0L;
		int num = (int)stream.Length;
		byte[] array = new byte[num];
		stream.Read(array, 0, num);
		stream.Close();
		return array;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < _items.Count; i++)
		{
			stringBuilder.Append(_items[i]);
		}
		return stringBuilder.ToString();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	internal override void WriteObject(ContentWriter writer)
	{
		for (int i = 0; i < _items.Count; i++)
		{
			_items[i].WriteObject(writer);
		}
	}

	int IList<CObject>.IndexOf(CObject item)
	{
		throw new NotImplementedException();
	}

	void IList<CObject>.Insert(int index, CObject item)
	{
		throw new NotImplementedException();
	}

	void IList<CObject>.RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	void ICollection<CObject>.Add(CObject item)
	{
		throw new NotImplementedException();
	}

	void ICollection<CObject>.Clear()
	{
		throw new NotImplementedException();
	}

	bool ICollection<CObject>.Contains(CObject item)
	{
		throw new NotImplementedException();
	}

	void ICollection<CObject>.CopyTo(CObject[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	bool ICollection<CObject>.Remove(CObject item)
	{
		throw new NotImplementedException();
	}

	IEnumerator<CObject> IEnumerable<CObject>.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
