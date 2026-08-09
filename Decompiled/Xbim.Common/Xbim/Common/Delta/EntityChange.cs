using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;
using Xbim.IO.Step21;

namespace Xbim.Common.Delta;

public class EntityChange
{
	private readonly IPersistEntity _entity;

	private readonly ExpressType _eType;

	private readonly string _oldEntity;

	private readonly List<ChangeType> _changeTypes = new List<ChangeType>();

	private readonly Dictionary<int, PropertyInfo> _changedProperties = new Dictionary<int, PropertyInfo>();

	private readonly Dictionary<int, string> _oldValues = new Dictionary<int, string>();

	private readonly Dictionary<int, int> _dummy = new Dictionary<int, int>();

	private readonly StringWriter _writer = new StringWriter();

	public IPersistEntity Entity => _entity;

	public ChangeType ChangeType
	{
		get
		{
			if (_changeTypes.Any((ChangeType t) => t == ChangeType.Deleted))
			{
				return ChangeType.Deleted;
			}
			if (_changeTypes.Any((ChangeType t) => t == ChangeType.New))
			{
				return ChangeType.New;
			}
			return ChangeType.Modified;
		}
	}

	internal bool IsNewDeleted
	{
		get
		{
			if (_changeTypes.Contains(ChangeType.New))
			{
				return _changeTypes.Contains(ChangeType.Deleted);
			}
			return false;
		}
	}

	public string OriginalEntity
	{
		get
		{
			if (ChangeType != ChangeType.New)
			{
				return _oldEntity;
			}
			return "";
		}
	}

	public string CurrentEntity
	{
		get
		{
			if (ChangeType != ChangeType.Deleted)
			{
				return GetEntityString();
			}
			return "";
		}
	}

	public IEnumerable<PropertyChange> ChangedProperties
	{
		get
		{
			if (ChangeType != ChangeType.Modified)
			{
				return Enumerable.Empty<PropertyChange>();
			}
			return _changedProperties.Select((KeyValuePair<int, PropertyInfo> kvp) => new PropertyChange
			{
				PropertyInfo = kvp.Value,
				Name = kvp.Value.Name,
				Order = kvp.Key,
				OriginalValue = _oldValues[kvp.Key],
				CurrentValue = GetPropertyString(kvp.Key)
			});
		}
	}

	internal EntityChange(IPersistEntity entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		_entity = entity;
		_eType = _entity.ExpressType;
		_oldEntity = GetEntityString();
	}

	internal void AddChanging(ChangeType type, int property)
	{
		_changeTypes.Add(type);
		if (type == ChangeType.Modified && property > 0 && !_changedProperties.ContainsKey(property))
		{
			ExpressMetaProperty expressMetaProperty = _eType.Properties[property];
			_changedProperties.Add(property, expressMetaProperty.PropertyInfo);
			string propertyString = GetPropertyString(property);
			_oldValues.Add(property, propertyString);
		}
	}

	internal void AddChanged(ChangeType type, int property)
	{
		if (property <= 0 || _changedProperties.ContainsKey(property))
		{
			return;
		}
		throw new XbimException("Property change wasn't notified before the actual change. Change log will be inconsistent.");
	}

	private string GetPropertyString(int order)
	{
		PropertyInfo propertyInfo = _changedProperties[order];
		Part21Writer.WriteProperty(propertyInfo.PropertyType, propertyInfo.GetValue(_entity, null), _writer, _dummy, _entity.Model.Metadata);
		string result = _writer.ToString();
		ClearWriter();
		return result;
	}

	private string GetEntityString()
	{
		Part21Writer.WriteEntity(_entity, _writer, _entity.Model.Metadata, _dummy);
		string result = _writer.ToString();
		ClearWriter();
		return result;
	}

	private void ClearWriter()
	{
		StringBuilder stringBuilder = _writer.GetStringBuilder();
		stringBuilder.Remove(0, stringBuilder.Length);
	}
}
