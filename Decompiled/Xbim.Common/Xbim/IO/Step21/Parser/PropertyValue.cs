using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Xbim.Common;
using Xbim.Common.Step21;

namespace Xbim.IO.Step21.Parser;

public struct PropertyValue : IPropertyValue
{
	private string _strVal;

	private StepParserType _stepParserType;

	private object _entityVal;

	public StepParserType Type => _stepParserType;

	public bool BooleanVal
	{
		get
		{
			if (_stepParserType == StepParserType.Boolean)
			{
				return _strVal == ".T.";
			}
			throw new Exception(string.Format("Wrong parameter type, found {0}, expected {1}", _stepParserType.ToString(), "Boolean"));
		}
	}

	public string EnumVal
	{
		get
		{
			if (_stepParserType == StepParserType.Enum)
			{
				return _strVal;
			}
			if (_stepParserType == StepParserType.String)
			{
				return _strVal.Trim('.', '\'');
			}
			throw new Exception(string.Format("Wrong parameter type, found {0}, expected {1}", _stepParserType.ToString(), "Enum"));
		}
	}

	public object EntityVal
	{
		get
		{
			if (_stepParserType == StepParserType.Entity)
			{
				return _entityVal;
			}
			throw new Exception(string.Format("Wrong parameter type, found {0}, expected {1}", _stepParserType.ToString(), "Entity"));
		}
	}

	public byte[] HexadecimalVal
	{
		get
		{
			if (_stepParserType != StepParserType.HexaDecimal)
			{
				throw new Exception(string.Format("Wrong parameter type, found {0}, expected {1}", _stepParserType.ToString(), "HexaDecimal"));
			}
			if (string.IsNullOrWhiteSpace(_strVal))
			{
				return new byte[0];
			}
			string text = ((_strVal[0] == '"') ? _strVal.Substring(1, _strVal.Length - 2) : _strVal);
			if (text.Length == 0)
			{
				return new byte[0];
			}
			if (text == "0")
			{
				return new byte[0];
			}
			text = ((text.Length % 2 == 0) ? text : text.Substring(1));
			int length = text.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
			}
			return array;
		}
	}

	public long IntegerVal
	{
		get
		{
			if (_stepParserType == StepParserType.Integer)
			{
				return Convert.ToInt64(_strVal);
			}
			throw new Exception(string.Format("Wrong parameter type, found {0}, expected {1}", _stepParserType.ToString(), "Integer"));
		}
	}

	public double NumberVal
	{
		get
		{
			if (_stepParserType == StepParserType.Integer || _stepParserType == StepParserType.Real)
			{
				return _strVal.ToDouble();
			}
			if (_stepParserType == StepParserType.HexaDecimal)
			{
				return Convert.ToDouble(Convert.ToInt64(_strVal, 16));
			}
			throw new Exception(string.Format("Wrong parameter type, found {0}, expected {1}", _stepParserType, "Number"));
		}
	}

	public double RealVal
	{
		get
		{
			if (_stepParserType == StepParserType.Real || _stepParserType == StepParserType.Integer)
			{
				return _strVal.ToDouble();
			}
			if (_stepParserType == StepParserType.Entity && _entityVal is IExpressValueType && typeof(double).GetTypeInfo().IsAssignableFrom(((IExpressValueType)_entityVal).UnderlyingSystemType))
			{
				return (double)((IExpressValueType)_entityVal).Value;
			}
			throw new Exception(string.Format("Wrong parameter type, found {0}, expected {1}", _stepParserType, "Real"));
		}
	}

	public string StringVal
	{
		get
		{
			string text = ((_strVal[0] == '\'') ? _strVal.Substring(1, _strVal.Length - 2) : _strVal);
			if (Enumerable.Contains(text, '\\') || text.Contains("'"))
			{
				text = new XbimP21StringDecoder().Unescape(text);
			}
			if (_stepParserType == StepParserType.String)
			{
				return text;
			}
			throw new Exception(string.Format("Wrong parameter type, found {0}, expected {1}", _stepParserType.ToString(), "String"));
		}
	}

	static PropertyValue()
	{
	}

	private static string ConvertFromHex(Match m)
	{
		return char.ConvertFromUtf32(Convert.ToInt32(m.Groups[1].Value, 16));
	}

	public void Init(string value, StepParserType type)
	{
		_strVal = value;
		_stepParserType = type;
	}

	public void Init(object value)
	{
		_entityVal = value;
		_stepParserType = StepParserType.Entity;
	}
}
