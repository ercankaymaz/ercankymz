#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Filters;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf;

[DebuggerDisplay("{DebuggerDisplay}")]
public class PdfDictionary : PdfObject, IEnumerable<KeyValuePair<string, PdfItem>>, IEnumerable
{
	[DebuggerDisplay("{DebuggerDisplay}")]
	public sealed class DictionaryElements : IDictionary<string, PdfItem>, ICollection<KeyValuePair<string, PdfItem>>, IEnumerable<KeyValuePair<string, PdfItem>>, IEnumerable, ICloneable
	{
		private Dictionary<string, PdfItem> _elements;

		private PdfDictionary _ownerDictionary;

		internal PdfDictionary Owner => _ownerDictionary;

		public bool IsReadOnly => false;

		public PdfItem this[string key]
		{
			get
			{
				_elements.TryGetValue(key, out var value);
				return value;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value is PdfObject { IsIndirect: not false } pdfObject)
				{
					value = pdfObject.Reference;
				}
				_elements[key] = value;
			}
		}

		public PdfItem this[PdfName key]
		{
			get
			{
				return this[key.Value];
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value is PdfDictionary pdfDictionary)
				{
					PdfDictionary pdfDictionary2 = pdfDictionary;
					if (pdfDictionary2._stream != null)
					{
						throw new ArgumentException("A dictionary with stream cannot be a direct value.");
					}
				}
				if (value is PdfObject { IsIndirect: not false } pdfObject)
				{
					value = pdfObject.Reference;
				}
				_elements[key.Value] = value;
			}
		}

		public PdfName[] KeyNames
		{
			get
			{
				ICollection keys = _elements.Keys;
				int count = keys.Count;
				string[] array = new string[count];
				keys.CopyTo(array, 0);
				PdfName[] array2 = new PdfName[count];
				for (int i = 0; i < count; i++)
				{
					array2[i] = new PdfName(array[i]);
				}
				return array2;
			}
		}

		public ICollection<string> Keys
		{
			get
			{
				ICollection keys = _elements.Keys;
				int count = keys.Count;
				string[] array = new string[count];
				keys.CopyTo(array, 0);
				return array;
			}
		}

		public ICollection<PdfItem> Values
		{
			get
			{
				ICollection values = _elements.Values;
				PdfItem[] array = new PdfItem[values.Count];
				values.CopyTo(array, 0);
				return array;
			}
		}

		public bool IsFixedSize => false;

		public bool IsSynchronized => false;

		public int Count => _elements.Count;

		public object SyncRoot => null;

		internal string DebuggerDisplay
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "key={0}:(", _elements.Count);
				bool flag = false;
				ICollection<string> keys = _elements.Keys;
				foreach (string item in keys)
				{
					if (flag)
					{
						stringBuilder.Append(' ');
					}
					flag = true;
					stringBuilder.Append(item);
				}
				stringBuilder.Append(")");
				return stringBuilder.ToString();
			}
		}

		internal DictionaryElements(PdfDictionary ownerDictionary)
		{
			_elements = new Dictionary<string, PdfItem>();
			_ownerDictionary = ownerDictionary;
		}

		object ICloneable.Clone()
		{
			DictionaryElements dictionaryElements = (DictionaryElements)MemberwiseClone();
			dictionaryElements._elements = new Dictionary<string, PdfItem>(dictionaryElements._elements);
			dictionaryElements._ownerDictionary = null;
			return dictionaryElements;
		}

		public DictionaryElements Clone()
		{
			return (DictionaryElements)((ICloneable)this).Clone();
		}

		internal void ChangeOwner(PdfDictionary ownerDictionary)
		{
			if (_ownerDictionary != null)
			{
			}
			_ownerDictionary = ownerDictionary;
			ownerDictionary._elements = this;
		}

		public bool GetBoolean(string key, bool create)
		{
			object obj = this[key];
			if (obj == null)
			{
				if (create)
				{
					this[key] = new PdfBoolean();
				}
				return false;
			}
			if (obj is PdfReference)
			{
				obj = ((PdfReference)obj).Value;
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

		public bool GetBoolean(string key)
		{
			return GetBoolean(key, create: false);
		}

		public void SetBoolean(string key, bool value)
		{
			this[key] = new PdfBoolean(value);
		}

		public int GetInteger(string key, bool create)
		{
			object obj = this[key];
			if (obj == null)
			{
				if (create)
				{
					this[key] = new PdfInteger();
				}
				return 0;
			}
			if (obj is PdfReference pdfReference)
			{
				obj = pdfReference.Value;
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

		public int GetInteger(string key)
		{
			return GetInteger(key, create: false);
		}

		public void SetInteger(string key, int value)
		{
			this[key] = new PdfInteger(value);
		}

		public double GetReal(string key, bool create)
		{
			object obj = this[key];
			if (obj == null)
			{
				if (create)
				{
					this[key] = new PdfReal();
				}
				return 0.0;
			}
			if (obj is PdfReference pdfReference)
			{
				obj = pdfReference.Value;
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

		public double GetReal(string key)
		{
			return GetReal(key, create: false);
		}

		public void SetReal(string key, double value)
		{
			this[key] = new PdfReal(value);
		}

		public string GetString(string key, bool create)
		{
			object obj = this[key];
			if (obj == null)
			{
				if (create)
				{
					this[key] = new PdfString();
				}
				return "";
			}
			if (obj is PdfReference pdfReference)
			{
				obj = pdfReference.Value;
			}
			if (obj is PdfString { Value: var value })
			{
				return value;
			}
			if (!(obj is PdfStringObject { Value: var value2 }))
			{
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
				throw new InvalidCastException("GetString: Object is not a string.");
			}
			return value2;
		}

		public string GetString(string key)
		{
			return GetString(key, create: false);
		}

		public bool TryGetString(string key, out string value)
		{
			value = null;
			object obj = this[key];
			if (obj == null)
			{
				return false;
			}
			if (obj is PdfReference pdfReference)
			{
				obj = pdfReference.Value;
			}
			if (obj is PdfString pdfString)
			{
				value = pdfString.Value;
				return true;
			}
			if (obj is PdfStringObject pdfStringObject)
			{
				value = pdfStringObject.Value;
				return true;
			}
			PdfName pdfName = obj as PdfName;
			if (pdfName != null)
			{
				value = pdfName.Value;
				return true;
			}
			PdfNameObject pdfNameObject = obj as PdfNameObject;
			if (pdfNameObject != null)
			{
				value = pdfNameObject.Value;
				return true;
			}
			return false;
		}

		public void SetString(string key, string value)
		{
			this[key] = new PdfString(value);
		}

		public string GetName(string key)
		{
			object obj = this[key];
			if (obj == null)
			{
				return string.Empty;
			}
			if (obj is PdfReference pdfReference)
			{
				obj = pdfReference.Value;
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

		public void SetName(string key, string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (value.Length == 0 || value[0] != '/')
			{
				value = "/" + value;
			}
			this[key] = new PdfName(value);
		}

		public PdfRectangle GetRectangle(string key, bool create)
		{
			PdfRectangle result = new PdfRectangle();
			object obj = this[key];
			if (obj == null)
			{
				if (create)
				{
					result = (PdfRectangle)(this[key] = new PdfRectangle());
				}
				return result;
			}
			if (obj is PdfReference)
			{
				obj = ((PdfReference)obj).Value;
			}
			return (PdfRectangle)((!(obj is PdfArray pdfArray) || pdfArray.Elements.Count != 4) ? ((PdfRectangle)obj) : (this[key] = new PdfRectangle(pdfArray.Elements.GetReal(0), pdfArray.Elements.GetReal(1), pdfArray.Elements.GetReal(2), pdfArray.Elements.GetReal(3))));
		}

		public PdfRectangle GetRectangle(string key)
		{
			return GetRectangle(key, create: false);
		}

		public void SetRectangle(string key, PdfRectangle rect)
		{
			_elements[key] = rect;
		}

		public XMatrix GetMatrix(string key, bool create)
		{
			XMatrix result = default(XMatrix);
			object obj = this[key];
			if (obj == null)
			{
				if (create)
				{
					this[key] = new PdfLiteral("[1 0 0 1 0 0]");
				}
				return result;
			}
			if (obj is PdfReference pdfReference)
			{
				obj = pdfReference.Value;
			}
			if (obj is PdfArray pdfArray && pdfArray.Elements.Count == 6)
			{
				return new XMatrix(pdfArray.Elements.GetReal(0), pdfArray.Elements.GetReal(1), pdfArray.Elements.GetReal(2), pdfArray.Elements.GetReal(3), pdfArray.Elements.GetReal(4), pdfArray.Elements.GetReal(5));
			}
			if (obj is PdfLiteral)
			{
				throw new NotImplementedException("Parsing matrix from literal.");
			}
			throw new InvalidCastException("Element is not an array with 6 values.");
		}

		public XMatrix GetMatrix(string key)
		{
			return GetMatrix(key, create: false);
		}

		public void SetMatrix(string key, XMatrix matrix)
		{
			_elements[key] = PdfLiteral.FromMatrix(matrix);
		}

		public DateTime GetDateTime(string key, DateTime defaultValue)
		{
			object obj = this[key];
			if (obj == null)
			{
				return defaultValue;
			}
			if (obj is PdfReference pdfReference)
			{
				obj = pdfReference.Value;
			}
			if (!(obj is PdfDate { Value: var value }))
			{
				string value2;
				if (obj is PdfString pdfString)
				{
					value2 = pdfString.Value;
				}
				else
				{
					if (!(obj is PdfStringObject pdfStringObject))
					{
						throw new InvalidCastException("GetName: Object is not a name.");
					}
					value2 = pdfStringObject.Value;
				}
				if (value2 != "")
				{
					try
					{
						defaultValue = Parser.ParseDateTime(value2, defaultValue);
					}
					catch
					{
					}
				}
				return defaultValue;
			}
			return value;
		}

		public void SetDateTime(string key, DateTime value)
		{
			_elements[key] = new PdfDate(value);
		}

		internal int GetEnumFromName(string key, object defaultValue, bool create)
		{
			if (!(defaultValue is Enum))
			{
				throw new ArgumentException("defaultValue");
			}
			object obj = this[key];
			if (obj == null)
			{
				if (create)
				{
					this[key] = new PdfName(defaultValue.ToString());
				}
				return (int)defaultValue;
			}
			Debug.Assert(obj is Enum);
			return (int)Enum.Parse(defaultValue.GetType(), obj.ToString().Substring(1), ignoreCase: false);
		}

		internal int GetEnumFromName(string key, object defaultValue)
		{
			return GetEnumFromName(key, defaultValue, create: false);
		}

		internal void SetEnumAsName(string key, object value)
		{
			if (!(value is Enum))
			{
				throw new ArgumentException("value");
			}
			_elements[key] = new PdfName("/" + value);
		}

		public PdfItem GetValue(string key, VCF options)
		{
			PdfItem pdfItem = this[key];
			if (pdfItem == null)
			{
				if (options != VCF.None)
				{
					Type valueType = GetValueType(key);
					if (!(valueType != null))
					{
						throw new NotImplementedException("Cannot create value for key: " + key);
					}
					Debug.Assert(typeof(PdfItem).IsAssignableFrom(valueType), "Type not allowed.");
					PdfObject pdfObject;
					if (typeof(PdfDictionary).IsAssignableFrom(valueType))
					{
						pdfItem = (pdfObject = CreateDictionary(valueType, null));
					}
					else
					{
						if (!typeof(PdfArray).IsAssignableFrom(valueType))
						{
							throw new NotImplementedException("Type other than array or dictionary.");
						}
						pdfItem = (pdfObject = CreateArray(valueType, null));
					}
					if (options == VCF.CreateIndirect)
					{
						_ownerDictionary.Owner._irefTable.Add(pdfObject);
						this[key] = pdfObject.Reference;
					}
					else
					{
						this[key] = pdfObject;
					}
				}
			}
			else
			{
				if (pdfItem is PdfReference pdfReference)
				{
					pdfItem = pdfReference.Value;
					if (pdfItem == null)
					{
						throw new InvalidOperationException("Indirect reference without value.");
					}
					bool flag = true;
					Type valueType2 = GetValueType(key);
					Debug.Assert(valueType2 != null, "No value type specified in meta information. Please send this file to PDFsharp support.");
					if (valueType2 != null && valueType2 != pdfItem.GetType())
					{
						if (typeof(PdfDictionary).IsAssignableFrom(valueType2))
						{
							Debug.Assert(pdfItem is PdfDictionary, "Bug in PDFsharp. Please send this file to PDFsharp support.");
							pdfItem = CreateDictionary(valueType2, (PdfDictionary)pdfItem);
						}
						else
						{
							if (!typeof(PdfArray).IsAssignableFrom(valueType2))
							{
								throw new NotImplementedException("Type other than array or dictionary.");
							}
							Debug.Assert(pdfItem is PdfArray, "Bug in PDFsharp. Please send this file to PDFsharp support.");
							pdfItem = CreateArray(valueType2, (PdfArray)pdfItem);
						}
					}
					return pdfItem;
				}
				bool flag2 = true;
				if (pdfItem is PdfDictionary pdfDictionary)
				{
					Debug.Assert(!pdfDictionary.IsIndirect);
					Type valueType3 = GetValueType(key);
					Debug.Assert(valueType3 != null, "No value type specified in meta information. Please send this file to PDFsharp support.");
					if (pdfDictionary.GetType() != valueType3)
					{
						pdfDictionary = CreateDictionary(valueType3, pdfDictionary);
					}
					return pdfDictionary;
				}
				if (pdfItem is PdfArray pdfArray)
				{
					Debug.Assert(!pdfArray.IsIndirect);
					Type valueType4 = GetValueType(key);
					if (valueType4 != null && valueType4 != pdfArray.GetType())
					{
						pdfArray = CreateArray(valueType4, pdfArray);
					}
					return pdfArray;
				}
			}
			return pdfItem;
		}

		public PdfItem GetValue(string key)
		{
			return GetValue(key, VCF.None);
		}

		private Type GetValueType(string key)
		{
			Type result = null;
			DictionaryMeta meta = _ownerDictionary.Meta;
			if (meta != null)
			{
				KeyDescriptor keyDescriptor = meta[key];
				if (keyDescriptor != null)
				{
					result = keyDescriptor.GetValueType();
				}
			}
			return result;
		}

		private PdfArray CreateArray(Type type, PdfArray oldArray)
		{
			ConstructorInfo constructor;
			if (oldArray == null)
			{
				constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(PdfDocument) }, null);
				Debug.Assert(constructor != null, "No appropriate constructor found for type: " + type.Name);
				return constructor.Invoke(new object[1] { _ownerDictionary.Owner }) as PdfArray;
			}
			constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(PdfArray) }, null);
			Debug.Assert(constructor != null, "No appropriate constructor found for type: " + type.Name);
			return constructor.Invoke(new object[1] { oldArray }) as PdfArray;
		}

		private PdfDictionary CreateDictionary(Type type, PdfDictionary oldDictionary)
		{
			ConstructorInfo constructor;
			if (oldDictionary == null)
			{
				constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(PdfDocument) }, null);
				Debug.Assert(constructor != null, "No appropriate constructor found for type: " + type.Name);
				return constructor.Invoke(new object[1] { _ownerDictionary.Owner }) as PdfDictionary;
			}
			constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(PdfDictionary) }, null);
			Debug.Assert(constructor != null, "No appropriate constructor found for type: " + type.Name);
			return constructor.Invoke(new object[1] { oldDictionary }) as PdfDictionary;
		}

		private PdfItem CreateValue(Type type, PdfDictionary oldValue)
		{
			ConstructorInfo constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(PdfDocument) }, null);
			PdfObject pdfObject = constructor.Invoke(new object[1] { _ownerDictionary.Owner }) as PdfObject;
			if (oldValue != null)
			{
				pdfObject.Reference = oldValue.Reference;
				pdfObject.Reference.Value = pdfObject;
				if (pdfObject is PdfDictionary)
				{
					PdfDictionary pdfDictionary = (PdfDictionary)pdfObject;
					pdfDictionary._elements = oldValue._elements;
				}
			}
			return pdfObject;
		}

		public void SetValue(string key, PdfItem value)
		{
			Debug.Assert((value is PdfObject && ((PdfObject)value).Reference == null) || !(value is PdfObject), "You try to set an indirect object directly into a dictionary.");
			_elements[key] = value;
		}

		public PdfObject GetObject(string key)
		{
			PdfItem pdfItem = this[key];
			if (!(pdfItem is PdfReference { Value: var value }))
			{
				return pdfItem as PdfObject;
			}
			return value;
		}

		public PdfDictionary GetDictionary(string key)
		{
			return GetObject(key) as PdfDictionary;
		}

		public PdfArray GetArray(string key)
		{
			return GetObject(key) as PdfArray;
		}

		public PdfReference GetReference(string key)
		{
			PdfItem pdfItem = this[key];
			return pdfItem as PdfReference;
		}

		public void SetObject(string key, PdfObject obj)
		{
			if (obj.Reference != null)
			{
				throw new ArgumentException("PdfObject must not be an indirect object.", "obj");
			}
			this[key] = obj;
		}

		public void SetReference(string key, PdfObject obj)
		{
			if (obj.Reference == null)
			{
				throw new ArgumentException("PdfObject must be an indirect object.", "obj");
			}
			this[key] = obj.Reference;
		}

		public void SetReference(string key, PdfReference iref)
		{
			if (iref == null)
			{
				throw new ArgumentNullException("iref");
			}
			this[key] = iref;
		}

		public IEnumerator<KeyValuePair<string, PdfItem>> GetEnumerator()
		{
			return _elements.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_elements).GetEnumerator();
		}

		public bool Remove(string key)
		{
			return _elements.Remove(key);
		}

		public bool Remove(KeyValuePair<string, PdfItem> item)
		{
			throw new NotImplementedException();
		}

		public bool ContainsKey(string key)
		{
			return _elements.ContainsKey(key);
		}

		public bool Contains(KeyValuePair<string, PdfItem> item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			_elements.Clear();
		}

		public void Add(string key, PdfItem value)
		{
			if (string.IsNullOrEmpty(key))
			{
				throw new ArgumentNullException("key");
			}
			if (key[0] != '/')
			{
				throw new ArgumentException("The key must start with a slash '/'.");
			}
			if (value is PdfObject { IsIndirect: not false } pdfObject)
			{
				value = pdfObject.Reference;
			}
			_elements.Add(key, value);
		}

		public void Add(KeyValuePair<string, PdfItem> item)
		{
			Add(item.Key, item.Value);
		}

		public bool TryGetValue(string key, out PdfItem value)
		{
			return _elements.TryGetValue(key, out value);
		}

		public void CopyTo(KeyValuePair<string, PdfItem>[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}
	}

	public sealed class PdfStream
	{
		public class Keys : KeysBase
		{
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string Length = "/Length";

			[KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
			public const string Filter = "/Filter";

			[KeyInfo(KeyType.ArrayOrDictionary | KeyType.Optional)]
			public const string DecodeParms = "/DecodeParms";

			[KeyInfo("1.2", KeyType.String | KeyType.Optional)]
			public const string F = "/F";

			[KeyInfo("1.2", KeyType.NameOrArray | KeyType.Optional)]
			public const string FFilter = "/FFilter";

			[KeyInfo("1.2", KeyType.ArrayOrDictionary | KeyType.Optional)]
			public const string FDecodeParms = "/FDecodeParms";

			[KeyInfo("1.5", KeyType.Integer | KeyType.Optional)]
			public const string DL = "/DL";
		}

		private PdfDictionary _ownerDictionary;

		private byte[] _value;

		public int Length => (_value != null) ? _value.Length : 0;

		internal bool HasDecodeParams
		{
			get
			{
				PdfDictionary dictionary = _ownerDictionary.Elements.GetDictionary("/DecodeParms");
				if (dictionary != null)
				{
					return true;
				}
				return false;
			}
		}

		internal int DecodePredictor => _ownerDictionary.Elements.GetDictionary("/DecodeParms")?.Elements.GetInteger("/Predictor") ?? 0;

		internal int DecodeColumns => _ownerDictionary.Elements.GetDictionary("/DecodeParms")?.Elements.GetInteger("/Columns") ?? 0;

		public byte[] Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_value = value;
				_ownerDictionary.Elements.SetInteger("/Length", value.Length);
			}
		}

		public byte[] UnfilteredValue
		{
			get
			{
				byte[] array = null;
				if (_value != null)
				{
					PdfItem pdfItem = _ownerDictionary.Elements["/Filter"];
					if (pdfItem != null)
					{
						array = Filtering.Decode(_value, pdfItem);
						if (array == null)
						{
							string s = $"«Cannot decode filter '{pdfItem}'»";
							array = PdfEncoders.RawEncoding.GetBytes(s);
						}
					}
					else
					{
						array = new byte[_value.Length];
						_value.CopyTo(array, 0);
					}
				}
				return array ?? new byte[0];
			}
		}

		internal PdfStream(PdfDictionary ownerDictionary)
		{
			if (ownerDictionary == null)
			{
				throw new ArgumentNullException("ownerDictionary");
			}
			_ownerDictionary = ownerDictionary;
		}

		internal PdfStream(byte[] value, PdfDictionary owner)
			: this(owner)
		{
			_value = value;
		}

		public PdfStream Clone()
		{
			PdfStream pdfStream = (PdfStream)MemberwiseClone();
			pdfStream._ownerDictionary = null;
			if (pdfStream._value != null)
			{
				pdfStream._value = new byte[pdfStream._value.Length];
				_value.CopyTo(pdfStream._value, 0);
			}
			return pdfStream;
		}

		internal void ChangeOwner(PdfDictionary dict)
		{
			if (_ownerDictionary != null)
			{
			}
			_ownerDictionary = dict;
			_ownerDictionary._stream = this;
		}

		public bool TryUnfilter()
		{
			if (_value != null)
			{
				PdfItem pdfItem = _ownerDictionary.Elements["/Filter"];
				if (pdfItem != null)
				{
					byte[] array = Filtering.Decode(_value, pdfItem);
					if (array == null)
					{
						return false;
					}
					_ownerDictionary.Elements.Remove("/Filter");
					Value = array;
				}
			}
			return true;
		}

		public void Zip()
		{
			if (_value != null && !_ownerDictionary.Elements.ContainsKey("/Filter"))
			{
				_value = Filtering.FlateDecode.Encode(_value, _ownerDictionary._document.Options.FlateEncodeMode);
				_ownerDictionary.Elements["/Filter"] = new PdfName("/FlateDecode");
				_ownerDictionary.Elements["/Length"] = new PdfInteger(_value.Length);
			}
		}

		public override string ToString()
		{
			if (_value == null)
			{
				return "«null»";
			}
			PdfItem pdfItem = _ownerDictionary.Elements["/Filter"];
			string result;
			if (pdfItem != null)
			{
				byte[] array = Filtering.Decode(_value, pdfItem);
				if (array == null)
				{
					throw new NotImplementedException("Unknown filter");
				}
				result = PdfEncoders.RawEncoding.GetString(array, 0, array.Length);
			}
			else
			{
				result = PdfEncoders.RawEncoding.GetString(_value, 0, _value.Length);
			}
			return result;
		}
	}

	internal DictionaryElements _elements;

	private PdfStream _stream;

	public DictionaryElements Elements => _elements ?? (_elements = new DictionaryElements(this));

	public PdfStream Stream
	{
		get
		{
			return _stream;
		}
		set
		{
			_stream = value;
		}
	}

	internal virtual DictionaryMeta Meta => null;

	private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "dictionary({0},[{1}])={2}", base.ObjectID.DebuggerDisplay, Elements.Count, _elements.DebuggerDisplay);

	public PdfDictionary()
	{
	}

	public PdfDictionary(PdfDocument document)
		: base(document)
	{
	}

	protected PdfDictionary(PdfDictionary dict)
		: base(dict)
	{
		if (dict._elements != null)
		{
			dict._elements.ChangeOwner(this);
		}
		if (dict._stream != null)
		{
			dict._stream.ChangeOwner(this);
		}
	}

	public new PdfDictionary Clone()
	{
		return (PdfDictionary)Copy();
	}

	protected override object Copy()
	{
		PdfDictionary pdfDictionary = (PdfDictionary)base.Copy();
		if (pdfDictionary._elements != null)
		{
			pdfDictionary._elements = pdfDictionary._elements.Clone();
			pdfDictionary._elements.ChangeOwner(pdfDictionary);
			PdfName[] keyNames = pdfDictionary._elements.KeyNames;
			PdfName[] array = keyNames;
			foreach (PdfName key in array)
			{
				if (pdfDictionary._elements[key] is PdfObject pdfObject)
				{
					PdfObject value = pdfObject.Clone();
					pdfDictionary._elements[key] = value;
				}
			}
		}
		if (pdfDictionary._stream != null)
		{
			pdfDictionary._stream = pdfDictionary._stream.Clone();
			pdfDictionary._stream.ChangeOwner(pdfDictionary);
		}
		return pdfDictionary;
	}

	public IEnumerator<KeyValuePair<string, PdfItem>> GetEnumerator()
	{
		return Elements.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public override string ToString()
	{
		PdfName[] keyNames = Elements.KeyNames;
		List<PdfName> list = new List<PdfName>(keyNames);
		list.Sort(PdfName.Comparer);
		list.CopyTo(keyNames, 0);
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<< ");
		PdfName[] array = keyNames;
		foreach (PdfName pdfName in array)
		{
			stringBuilder.Append(pdfName?.ToString() + " " + Elements[pdfName]?.ToString() + " ");
		}
		stringBuilder.Append(">>");
		return stringBuilder.ToString();
	}

	internal override void WriteObject(PdfWriter writer)
	{
		writer.WriteBeginObject(this);
		PdfName[] keyNames = Elements.KeyNames;
		if (_stream != null)
		{
			Debug.Assert(Elements.ContainsKey("/Length"), "Dictionary has a stream but no length is set.");
		}
		if (writer.Layout == PdfWriterLayout.Verbose)
		{
			List<PdfName> list = new List<PdfName>(keyNames);
			list.Sort(PdfName.Comparer);
			list.CopyTo(keyNames, 0);
		}
		PdfName[] array = keyNames;
		foreach (PdfName key in array)
		{
			WriteDictionaryElement(writer, key);
		}
		if (Stream != null)
		{
			WriteDictionaryStream(writer);
		}
		writer.WriteEndObject();
	}

	internal virtual void WriteDictionaryElement(PdfWriter writer, PdfName key)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		PdfItem pdfItem = Elements[key];
		if (pdfItem is PdfObject && ((PdfObject)pdfItem).IsIndirect)
		{
			pdfItem = ((PdfObject)pdfItem).Reference;
			Debug.Assert(condition: false, "Check when we come here.");
		}
		key.WriteObject(writer);
		pdfItem.WriteObject(writer);
		writer.NewLine();
	}

	internal virtual void WriteDictionaryStream(PdfWriter writer)
	{
		writer.WriteStream(this, (writer.Options & PdfWriterOptions.OmitStream) == PdfWriterOptions.OmitStream);
	}

	public PdfStream CreateStream(byte[] value)
	{
		if (_stream != null)
		{
			throw new InvalidOperationException("The dictionary already has a stream.");
		}
		_stream = new PdfStream(value, this);
		Elements["/Length"] = new PdfInteger(_stream.Length);
		return _stream;
	}
}
