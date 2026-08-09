using System.Collections;
using System.Collections.Generic;
using System.ServiceModel.Security;

namespace System.ServiceModel.Channels;

public sealed class MessageProperties : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IDisposable
{
	internal struct Property(string name, object value) : IDisposable
	{
		private object _value = value;

		public string Name { get; } = name;

		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		public void Dispose()
		{
			if (_value is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}

	private Property[] _properties;

	private int _propertyCount;

	private MessageEncoder _encoder;

	private Uri _via;

	private object _allowOutputBatching;

	private SecurityMessageProperty _security;

	private bool _disposed;

	private const int InitialPropertyCount = 2;

	private const int MaxRecycledArrayLength = 8;

	private const string ViaKey = "Via";

	private const string AllowOutputBatchingKey = "AllowOutputBatching";

	private const string SecurityKey = "Security";

	private const string EncoderKey = "Encoder";

	private const int NotFoundIndex = -1;

	private const int ViaIndex = -2;

	private const int AllowOutputBatchingIndex = -3;

	private const int SecurityIndex = -4;

	private const int EncoderIndex = -5;

	private static object s_trueBool = true;

	private static object s_falseBool = false;

	public object this[string name]
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			if (!TryGetValue(name, out var value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.MessagePropertyNotFound, name)));
			}
			return value;
		}
		set
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			UpdateProperty(name, value, mustNotExist: false);
		}
	}

	internal bool CanRecycle
	{
		get
		{
			if (_properties != null)
			{
				return _properties.Length <= 8;
			}
			return true;
		}
	}

	public int Count
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			return _propertyCount;
		}
	}

	public MessageEncoder Encoder
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			return _encoder;
		}
		set
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			AdjustPropertyCount(_encoder == null, value == null);
			_encoder = value;
		}
	}

	public bool AllowOutputBatching
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			return _allowOutputBatching == s_trueBool;
		}
		set
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			AdjustPropertyCount(_allowOutputBatching == null, newValueIsNull: false);
			if (value)
			{
				_allowOutputBatching = s_trueBool;
			}
			else
			{
				_allowOutputBatching = s_falseBool;
			}
		}
	}

	public bool IsFixedSize
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			return false;
		}
	}

	public bool IsReadOnly
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			return false;
		}
	}

	public ICollection<string> Keys
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			List<string> list = new List<string>();
			if ((object)_via != null)
			{
				list.Add("Via");
			}
			if (_allowOutputBatching != null)
			{
				list.Add("AllowOutputBatching");
			}
			if (_encoder != null)
			{
				list.Add("Encoder");
			}
			if (_properties != null)
			{
				for (int i = 0; i < _properties.Length; i++)
				{
					string name = _properties[i].Name;
					if (name == null)
					{
						break;
					}
					list.Add(name);
				}
			}
			return list;
		}
	}

	public SecurityMessageProperty Security
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			return _security;
		}
		set
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			AdjustPropertyCount(_security == null, value == null);
			_security = value;
		}
	}

	public ICollection<object> Values
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			List<object> list = new List<object>();
			if ((object)_via != null)
			{
				list.Add(_via);
			}
			if (_allowOutputBatching != null)
			{
				list.Add(_allowOutputBatching);
			}
			if (_security != null)
			{
				list.Add(_security);
			}
			if (_encoder != null)
			{
				list.Add(_encoder);
			}
			if (_properties != null)
			{
				for (int i = 0; i < _properties.Length && _properties[i].Name != null; i++)
				{
					list.Add(_properties[i].Value);
				}
			}
			return list;
		}
	}

	public Uri Via
	{
		get
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			return _via;
		}
		set
		{
			if (_disposed)
			{
				ThrowDisposed();
			}
			AdjustPropertyCount((object)_via == null, (object)value == null);
			_via = value;
		}
	}

	public MessageProperties()
	{
	}

	public MessageProperties(MessageProperties properties)
	{
		CopyProperties(properties);
	}

	internal MessageProperties(KeyValuePair<string, object>[] array)
	{
		if (array == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("array"));
		}
		CopyProperties(array);
	}

	private void ThrowDisposed()
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(string.Empty, System.SR.Format(System.SR.ObjectDisposed, GetType().ToString())));
	}

	public void Add(string name, object property)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (property == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("property"));
		}
		UpdateProperty(name, property, mustNotExist: true);
	}

	private void AdjustPropertyCount(bool oldValueIsNull, bool newValueIsNull)
	{
		if (newValueIsNull)
		{
			if (!oldValueIsNull)
			{
				_propertyCount--;
			}
		}
		else if (oldValueIsNull)
		{
			_propertyCount++;
		}
	}

	public void Clear()
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (_properties != null)
		{
			for (int i = 0; i < _properties.Length && _properties[i].Name != null; i++)
			{
				_properties[i] = default(Property);
			}
		}
		_via = null;
		_allowOutputBatching = null;
		_security = null;
		_encoder = null;
		_propertyCount = 0;
	}

	public void CopyProperties(MessageProperties properties)
	{
		if (properties == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("properties");
		}
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (properties._properties != null)
		{
			for (int i = 0; i < properties._properties.Length && properties._properties[i].Name != null; i++)
			{
				Property property = properties._properties[i];
				this[property.Name] = property.Value;
			}
		}
		Via = properties.Via;
		AllowOutputBatching = properties.AllowOutputBatching;
		Security = ((properties.Security != null) ? ((SecurityMessageProperty)properties.Security.CreateCopy()) : null);
		Encoder = properties.Encoder;
	}

	internal void MergeProperties(MessageProperties properties)
	{
		if (properties == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("properties");
		}
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (properties._properties != null)
		{
			for (int i = 0; i < properties._properties.Length && properties._properties[i].Name != null; i++)
			{
				Property property = properties._properties[i];
				if (!TryGetValue(property.Name, out IMergeEnabledMessageProperty property2) || !property2.TryMergeWithProperty(property.Value))
				{
					this[property.Name] = property.Value;
				}
			}
		}
		Via = properties.Via;
		AllowOutputBatching = properties.AllowOutputBatching;
		Security = ((properties.Security != null) ? ((SecurityMessageProperty)properties.Security.CreateCopy()) : null);
		Encoder = properties.Encoder;
	}

	internal void CopyProperties(KeyValuePair<string, object>[] array)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		for (int i = 0; i < array.Length; i++)
		{
			KeyValuePair<string, object> keyValuePair = array[i];
			this[keyValuePair.Key] = keyValuePair.Value;
		}
	}

	public bool ContainsKey(string name)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		return FindProperty(name) switch
		{
			-2 => (object)_via != null, 
			-3 => _allowOutputBatching != null, 
			-4 => _security != null, 
			-5 => _encoder != null, 
			-1 => false, 
			_ => true, 
		};
	}

	private object CreateCopyOfPropertyValue(object propertyValue)
	{
		if (!(propertyValue is IMessageProperty messageProperty))
		{
			return propertyValue;
		}
		object obj = messageProperty.CreateCopy();
		if (obj == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.MessagePropertyReturnedNullCopy));
		}
		return obj;
	}

	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}
		_disposed = true;
		if (_properties != null)
		{
			for (int i = 0; i < _properties.Length && _properties[i].Name != null; i++)
			{
				_properties[i].Dispose();
			}
		}
		if (_security != null)
		{
			_security.Dispose();
		}
	}

	private int FindProperty(string name)
	{
		switch (name)
		{
		case "Via":
			return -2;
		case "AllowOutputBatching":
			return -3;
		case "Encoder":
			return -5;
		case "Security":
			return -4;
		default:
			if (_properties != null)
			{
				for (int i = 0; i < _properties.Length; i++)
				{
					string name2 = _properties[i].Name;
					if (name2 == null)
					{
						break;
					}
					if (name2 == name)
					{
						return i;
					}
				}
			}
			return -1;
		}
	}

	internal void Recycle()
	{
		_disposed = false;
		Clear();
	}

	public bool Remove(string name)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		int propertyCount = _propertyCount;
		UpdateProperty(name, null, mustNotExist: false);
		return propertyCount != _propertyCount;
	}

	public bool TryGetValue(string name, out object value)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		int num = FindProperty(name);
		switch (num)
		{
		case -2:
			value = _via;
			break;
		case -3:
			value = _allowOutputBatching;
			break;
		case -4:
			value = _security;
			break;
		case -5:
			value = _encoder;
			break;
		case -1:
			value = null;
			break;
		default:
			value = _properties[num].Value;
			break;
		}
		return value != null;
	}

	internal bool TryGetValue<TProperty>(string name, out TProperty property)
	{
		if (TryGetValue(name, out var value))
		{
			property = (TProperty)value;
			return true;
		}
		property = default(TProperty);
		return false;
	}

	internal TProperty GetValue<TProperty>(string name) where TProperty : class
	{
		return GetValue<TProperty>(name, ensureTypeMatch: false);
	}

	internal TProperty GetValue<TProperty>(string name, bool ensureTypeMatch) where TProperty : class
	{
		if (!TryGetValue(name, out var value))
		{
			return null;
		}
		if (!ensureTypeMatch)
		{
			return value as TProperty;
		}
		return (TProperty)value;
	}

	private void UpdateProperty(string name, object value, bool mustNotExist)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		int num = FindProperty(name);
		if (num != -1)
		{
			if (mustNotExist && num switch
			{
				-2 => (object)_via != null, 
				-3 => _allowOutputBatching != null, 
				-4 => _security != null, 
				-5 => _encoder != null, 
				_ => true, 
			})
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.Format(System.SR.DuplicateMessageProperty, name)));
			}
			if (num >= 0)
			{
				if (value == null)
				{
					_properties[num].Dispose();
					int i;
					for (i = num + 1; i < _properties.Length && _properties[i].Name != null; i++)
					{
						_properties[i - 1] = _properties[i];
					}
					_properties[i - 1] = default(Property);
					_propertyCount--;
				}
				else
				{
					_properties[num].Value = CreateCopyOfPropertyValue(value);
				}
				return;
			}
			switch (num)
			{
			case -2:
				Via = (Uri)value;
				break;
			case -3:
				AllowOutputBatching = (bool)value;
				break;
			case -4:
				if (Security != null)
				{
					Security.Dispose();
				}
				Security = (SecurityMessageProperty)CreateCopyOfPropertyValue(value);
				break;
			case -5:
				Encoder = (MessageEncoder)value;
				break;
			default:
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException());
			}
		}
		else
		{
			if (value == null)
			{
				return;
			}
			int j;
			if (_properties == null)
			{
				_properties = new Property[2];
				j = 0;
			}
			else
			{
				for (j = 0; j < _properties.Length && _properties[j].Name != null; j++)
				{
				}
				if (j == _properties.Length)
				{
					Property[] array = new Property[_properties.Length * 2];
					Array.Copy(_properties, array, _properties.Length);
					_properties = array;
				}
			}
			object value2 = CreateCopyOfPropertyValue(value);
			_properties[j] = new Property(name, value2);
			_propertyCount++;
		}
	}

	void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int index)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (array == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("array"));
		}
		if (array.Length < _propertyCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentException(System.SR.MessagePropertiesArraySize0));
		}
		if (index < 0 || index > array.Length - _propertyCount)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("index", index, System.SR.Format(System.SR.ValueMustBeInRange, 0, array.Length - _propertyCount)));
		}
		if (_via != null)
		{
			array[index++] = new KeyValuePair<string, object>("Via", _via);
		}
		if (_allowOutputBatching != null)
		{
			array[index++] = new KeyValuePair<string, object>("AllowOutputBatching", _allowOutputBatching);
		}
		if (_security != null)
		{
			array[index++] = new KeyValuePair<string, object>("Security", _security.CreateCopy());
		}
		if (_encoder != null)
		{
			array[index++] = new KeyValuePair<string, object>("Encoder", _encoder);
		}
		if (_properties == null)
		{
			return;
		}
		for (int i = 0; i < _properties.Length; i++)
		{
			string name = _properties[i].Name;
			if (name != null)
			{
				array[index++] = new KeyValuePair<string, object>(name, CreateCopyOfPropertyValue(_properties[i].Value));
				continue;
			}
			break;
		}
	}

	void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> pair)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (pair.Value == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("pair.Value"));
		}
		UpdateProperty(pair.Key, pair.Value, mustNotExist: true);
	}

	bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> pair)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (pair.Value == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("pair.Value"));
		}
		if (pair.Key == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("pair.Key"));
		}
		if (!TryGetValue(pair.Key, out var value))
		{
			return false;
		}
		return value.Equals(pair.Value);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		return ((IEnumerable<KeyValuePair<string, object>>)this).GetEnumerator();
	}

	IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>(_propertyCount);
		if (_via != null)
		{
			list.Add(new KeyValuePair<string, object>("Via", _via));
		}
		if (_allowOutputBatching != null)
		{
			list.Add(new KeyValuePair<string, object>("AllowOutputBatching", _allowOutputBatching));
		}
		if (_security != null)
		{
			list.Add(new KeyValuePair<string, object>("Security", _security));
		}
		if (_encoder != null)
		{
			list.Add(new KeyValuePair<string, object>("Encoder", _encoder));
		}
		if (_properties != null)
		{
			for (int i = 0; i < _properties.Length; i++)
			{
				string name = _properties[i].Name;
				if (name == null)
				{
					break;
				}
				list.Add(new KeyValuePair<string, object>(name, _properties[i].Value));
			}
		}
		return list.GetEnumerator();
	}

	bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> pair)
	{
		if (_disposed)
		{
			ThrowDisposed();
		}
		if (pair.Value == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("pair.Value"));
		}
		if (pair.Key == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("pair.Key"));
		}
		if (!TryGetValue(pair.Key, out var value))
		{
			return false;
		}
		if (!value.Equals(pair.Value))
		{
			return false;
		}
		Remove(pair.Key);
		return true;
	}
}
