using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf;

[DebuggerDisplay("{DebuggerDisplay}")]
public class PdfArray : PdfObject, IEnumerable<PdfItem>, IEnumerable
{
	public sealed class ArrayElements : IList<PdfItem>, ICollection<PdfItem>, IEnumerable<PdfItem>, IEnumerable, ICloneable
	{
		private List<PdfItem> _elements;

		private PdfArray _ownerArray;

		public PdfItem[] Items => _elements.ToArray();

		public bool IsReadOnly => false;

		public PdfItem this[int index]
		{
			get
			{
				return _elements[index];
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_elements[index] = value;
			}
		}

		public bool IsFixedSize => false;

		public bool IsSynchronized => false;

		public int Count => _elements.Count;

		public object SyncRoot => null;

		internal ArrayElements(PdfArray array)
		{
			_elements = new List<PdfItem>();
			_ownerArray = array;
		}

		object ICloneable.Clone()
		{
			ArrayElements arrayElements = (ArrayElements)MemberwiseClone();
			arrayElements._elements = new List<PdfItem>(arrayElements._elements);
			arrayElements._ownerArray = null;
			return arrayElements;
		}

		public ArrayElements Clone()
		{
			return (ArrayElements)((ICloneable)this).Clone();
		}

		internal void ChangeOwner(PdfArray array)
		{
			if (_ownerArray != null)
			{
			}
			_ownerArray = array;
			array._elements = this;
		}

		public bool GetBoolean(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
			}
			object obj = this[index];
			if (obj == null)
			{
				return false;
			}
			if (obj is PdfBoolean { Value: var value })
			{
				return value;
			}
			if (!(obj is PdfBooleanObject { Value: var value2 }))
			{
				throw new InvalidCastException("GetBoolean: Object is not a boolean.");
			}
			return value2;
		}

		public int GetInteger(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
			}
			object obj = this[index];
			if (obj == null)
			{
				return 0;
			}
			if (obj is PdfInteger { Value: var value })
			{
				return value;
			}
			if (!(obj is PdfIntegerObject { Value: var value2 }))
			{
				throw new InvalidCastException("GetInteger: Object is not an integer.");
			}
			return value2;
		}

		public double GetReal(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
			}
			object obj = this[index];
			if (obj == null)
			{
				return 0.0;
			}
			if (obj is PdfReal { Value: var value })
			{
				return value;
			}
			if (!(obj is PdfRealObject { Value: var value2 }))
			{
				if (obj is PdfInteger pdfInteger)
				{
					return pdfInteger.Value;
				}
				if (obj is PdfIntegerObject pdfIntegerObject)
				{
					return pdfIntegerObject.Value;
				}
				throw new InvalidCastException("GetReal: Object is not a number.");
			}
			return value2;
		}

		public double? GetNullableReal(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
			}
			object obj = this[index];
			if (obj == null)
			{
				return null;
			}
			if (obj is PdfNull)
			{
				return null;
			}
			if (obj is PdfNullObject)
			{
				return null;
			}
			if (obj is PdfReal pdfReal)
			{
				return pdfReal.Value;
			}
			if (obj is PdfRealObject pdfRealObject)
			{
				return pdfRealObject.Value;
			}
			if (obj is PdfInteger pdfInteger)
			{
				return pdfInteger.Value;
			}
			if (obj is PdfIntegerObject pdfIntegerObject)
			{
				return pdfIntegerObject.Value;
			}
			throw new InvalidCastException("GetReal: Object is not a number.");
		}

		public string GetString(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
			}
			object obj = this[index];
			if (obj == null)
			{
				return string.Empty;
			}
			if (obj is PdfString { Value: var value })
			{
				return value;
			}
			if (!(obj is PdfStringObject { Value: var value2 }))
			{
				throw new InvalidCastException("GetString: Object is not a string.");
			}
			return value2;
		}

		public string GetName(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
			}
			object obj = this[index];
			if (obj == null)
			{
				return string.Empty;
			}
			PdfName pdfName = obj as PdfName;
			if (pdfName != null)
			{
				return pdfName.Value;
			}
			PdfNameObject pdfNameObject = obj as PdfNameObject;
			if (pdfNameObject != null)
			{
				return pdfNameObject.Value;
			}
			throw new InvalidCastException("GetName: Object is not a name.");
		}

		[Obsolete("Use GetObject, GetDictionary, GetArray, or GetReference")]
		public PdfObject GetIndirectObject(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
			}
			if (!(this[index] is PdfReference { Value: var value }))
			{
				return null;
			}
			return value;
		}

		public PdfObject GetObject(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.IndexOutOfRange);
			}
			PdfItem pdfItem = this[index];
			if (!(pdfItem is PdfReference { Value: var value }))
			{
				return pdfItem as PdfObject;
			}
			return value;
		}

		public PdfDictionary GetDictionary(int index)
		{
			return GetObject(index) as PdfDictionary;
		}

		public PdfArray GetArray(int index)
		{
			return GetObject(index) as PdfArray;
		}

		public PdfReference GetReference(int index)
		{
			PdfItem pdfItem = this[index];
			return pdfItem as PdfReference;
		}

		public void RemoveAt(int index)
		{
			_elements.RemoveAt(index);
		}

		public bool Remove(PdfItem item)
		{
			return _elements.Remove(item);
		}

		public void Insert(int index, PdfItem value)
		{
			_elements.Insert(index, value);
		}

		public bool Contains(PdfItem value)
		{
			return _elements.Contains(value);
		}

		public void Clear()
		{
			_elements.Clear();
		}

		public int IndexOf(PdfItem value)
		{
			return _elements.IndexOf(value);
		}

		public void Add(PdfItem value)
		{
			if (value is PdfObject { IsIndirect: not false } pdfObject)
			{
				_elements.Add(pdfObject.Reference);
			}
			else
			{
				_elements.Add(value);
			}
		}

		public void CopyTo(PdfItem[] array, int index)
		{
			_elements.CopyTo(array, index);
		}

		public IEnumerator<PdfItem> GetEnumerator()
		{
			return _elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _elements.GetEnumerator();
		}
	}

	private ArrayElements _elements;

	public ArrayElements Elements => _elements ?? (_elements = new ArrayElements(this));

	private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "array({0},[{1}])", base.ObjectID.DebuggerDisplay, (_elements != null) ? _elements.Count : 0);

	public PdfArray()
	{
	}

	public PdfArray(PdfDocument document)
		: base(document)
	{
	}

	public PdfArray(PdfDocument document, params PdfItem[] items)
		: base(document)
	{
		foreach (PdfItem value in items)
		{
			Elements.Add(value);
		}
	}

	protected PdfArray(PdfArray array)
		: base(array)
	{
		if (array._elements != null)
		{
			array._elements.ChangeOwner(this);
		}
	}

	public new PdfArray Clone()
	{
		return (PdfArray)Copy();
	}

	protected override object Copy()
	{
		PdfArray pdfArray = (PdfArray)base.Copy();
		if (pdfArray._elements != null)
		{
			pdfArray._elements = pdfArray._elements.Clone();
			int count = pdfArray._elements.Count;
			for (int i = 0; i < count; i++)
			{
				PdfItem pdfItem = pdfArray._elements[i];
				if (pdfItem is PdfObject)
				{
					pdfArray._elements[i] = pdfItem.Clone();
				}
			}
		}
		return pdfArray;
	}

	public virtual IEnumerator<PdfItem> GetEnumerator()
	{
		return Elements.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("[ ");
		int count = Elements.Count;
		for (int i = 0; i < count; i++)
		{
			stringBuilder.Append(Elements[i]?.ToString() + " ");
		}
		stringBuilder.Append("]");
		return stringBuilder.ToString();
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.WriteBeginObject(this);
		int count = Elements.Count;
		for (int i = 0; i < count; i++)
		{
			PdfItem pdfItem = Elements[i];
			pdfItem.WriteObject(writer);
		}
		writer.WriteEndObject();
	}
}
