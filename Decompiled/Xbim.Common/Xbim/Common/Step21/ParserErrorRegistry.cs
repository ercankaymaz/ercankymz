using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;

namespace Xbim.Common.Step21;

public class ParserErrorRegistry : IDisposable
{
	private struct PropertyError(IPersist entity, int property, object value, Exception exception)
	{
		public readonly IPersist Entity = entity;

		public readonly int Property = property;

		public readonly Exception Exception = exception;

		public readonly object Value = value;

		public override bool Equals(object obj)
		{
			if (!(obj is PropertyError propertyError))
			{
				return false;
			}
			if (propertyError.Entity.GetType() == Entity.GetType() && propertyError.Value?.GetType() == Value?.GetType() && propertyError.Property == Property)
			{
				return propertyError.Exception?.GetType() == Exception?.GetType();
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 17;
			num = num * 31 + Entity.GetType().GetHashCode();
			int num2 = num * 31;
			int property = Property;
			num = num2 + property.GetHashCode();
			if (Exception != null)
			{
				num = num * 31 + Exception.GetType().GetHashCode();
			}
			if (Value != null)
			{
				num = num * 31 + Value.GetType().GetHashCode();
			}
			return num;
		}
	}

	private ConcurrentDictionary<string, int[]> _typesNotFound = new ConcurrentDictionary<string, int[]>();

	private ConcurrentDictionary<PropertyError, int[]> _propertyErrors = new ConcurrentDictionary<PropertyError, int[]>();

	public int TypesNotFound => _typesNotFound.Count;

	public int PropertyErrors => _propertyErrors.Count;

	public bool Any
	{
		get
		{
			if (TypesNotFound == 0)
			{
				return PropertyErrors != 0;
			}
			return true;
		}
	}

	public string Summary
	{
		get
		{
			if (!Any)
			{
				return "";
			}
			using StringWriter stringWriter = new StringWriter();
			foreach (KeyValuePair<string, int[]> item in _typesNotFound)
			{
				stringWriter.WriteLine($"Type '{item.Key}' not found {item.Value[0]} times.");
			}
			foreach (KeyValuePair<PropertyError, int[]> propertyError in _propertyErrors)
			{
				PropertyError key = propertyError.Key;
				stringWriter.WriteLine($"Property {key.Property} of {key.Entity.GetType().Name} failed to set value {key.Value} {propertyError.Value[0]} times with exception {key.Exception.GetType().Name}: {key.Exception.Message}");
			}
			return stringWriter.ToString();
		}
	}

	public bool AddTypeNotCreated(string type)
	{
		type = type.ToUpperInvariant();
		if (_typesNotFound.TryGetValue(type, out var value))
		{
			value[0]++;
			return false;
		}
		return _typesNotFound.TryAdd(type, new int[1] { 1 });
	}

	public bool AddPropertyNotSet(IPersist entity, int propIndex, object value, Exception exception)
	{
		PropertyError key = new PropertyError(entity, propIndex, value, exception);
		if (_propertyErrors.TryGetValue(key, out var value2))
		{
			value2[0]++;
			return false;
		}
		return _propertyErrors.TryAdd(key, new int[1] { 1 });
	}

	public void Dispose()
	{
		_typesNotFound.Clear();
	}
}
