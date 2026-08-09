using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;
using Xbim.IO.Parser;

namespace Xbim.IO.Esent;

internal class XbimParserState
{
	private readonly ILogger _logger;

	private readonly ExpressMetaData _metadata;

	private readonly List<int> _nestedIndex = new List<int>();

	private readonly Stack<Part21Entity> _processStack = new Stack<Part21Entity>();

	private int _listNestLevel = -1;

	private Part21Entity _currentInstance;

	private readonly IndexPropertyValue _propertyValue = new IndexPropertyValue();

	public int[] NestedIndex
	{
		get
		{
			if (_listNestLevel <= 0)
			{
				return null;
			}
			return _nestedIndex.ToArray();
		}
	}

	internal ExpressMetaProperty CurrentProperty => _metadata.ExpressType(_currentInstance.Entity).Properties[_currentInstance.CurrentParamIndex + 1];

	internal short CurrentPropertyId => (short)_currentInstance.CurrentParamIndex;

	public bool InList => _listNestLevel > 0;

	public XbimParserState(IPersistEntity entity, ILoggerFactory loggerFactory)
	{
		loggerFactory = loggerFactory ?? XbimServices.Current.GetLoggerFactory();
		_logger = loggerFactory.CreateLogger<XbimParserState>();
		_currentInstance = new Part21Entity(entity);
		_processStack.Push(_currentInstance);
		_metadata = entity.Model.Metadata;
	}

	public void BeginList()
	{
		Part21Entity part21Entity = _processStack.Peek();
		if (part21Entity.CurrentParamIndex == -1)
		{
			part21Entity.CurrentParamIndex++;
		}
		_listNestLevel++;
		if (_listNestLevel >= 2)
		{
			if (_listNestLevel - 1 > _nestedIndex.Count)
			{
				_nestedIndex.Add(0);
			}
			else
			{
				_nestedIndex[_listNestLevel - 2]++;
			}
		}
	}

	public void EndList()
	{
		_listNestLevel--;
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
		if (_listNestLevel <= 0)
		{
			_nestedIndex.Clear();
		}
	}

	public void EndEntity()
	{
		_processStack.Pop();
	}

	internal void BeginNestedType(string typeName)
	{
		ExpressType expressType = _metadata.ExpressType(typeName);
		_currentInstance = new Part21Entity((IPersist)Activator.CreateInstance(expressType.Type));
		_processStack.Push(_currentInstance);
	}

	internal void EndNestedType()
	{
		_propertyValue.Init(_processStack.Pop().Entity);
		_currentInstance = _processStack.Peek();
		if (_currentInstance.Entity != null)
		{
			_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	private void SetEntityParameter()
	{
		if (_currentInstance.Entity != null)
		{
			try
			{
				_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
			}
			catch (Exception ex)
			{
				if (_logger != null)
				{
					_logger.LogError("Parser error, the Attribute {0} of {1} is incorrectly specified and has been ignored. {2}", _currentInstance.CurrentParamIndex, _currentInstance.Entity.GetType().Name, ex.Message);
				}
			}
		}
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	internal void SetIntegerValue(long value)
	{
		_propertyValue.Init(value, StepParserType.Integer);
		SetEntityParameter();
	}

	internal void SetHexValue(byte[] value)
	{
		_propertyValue.Init(value, StepParserType.HexaDecimal);
		SetEntityParameter();
	}

	internal void SetFloatValue(double value)
	{
		_propertyValue.Init(value, StepParserType.Real);
		SetEntityParameter();
	}

	internal void SetStringValue(string value)
	{
		_propertyValue.Init(value, StepParserType.String);
		SetEntityParameter();
	}

	internal void SetEnumValue(string value)
	{
		_propertyValue.Init(value, StepParserType.Enum);
		SetEntityParameter();
	}

	internal void SetBooleanValue(bool value)
	{
		_propertyValue.Init(value, StepParserType.Boolean);
		SetEntityParameter();
	}

	internal void SetNonDefinedValue()
	{
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	internal void SetOverrideValue()
	{
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	internal void SetObjectValue(IPersist value)
	{
		_propertyValue.Init(value);
		_currentInstance.Entity.Parse(_currentInstance.CurrentParamIndex, _propertyValue, NestedIndex);
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}

	internal void SkipProperty()
	{
		if (_listNestLevel == 0)
		{
			_currentInstance.CurrentParamIndex++;
		}
	}
}
