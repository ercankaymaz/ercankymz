using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using ACadSharp.Attributes;
using ACadSharp.Objects;
using CSMath;
using CSUtilities.Converters;
using CSUtilities.Extensions;

namespace ACadSharp;

public abstract class DxfPropertyBase<T> where T : Attribute, ICodeValueAttribute
{
	protected int? _assignedCode;

	protected T _attributeData;

	protected PropertyInfo _property;

	protected object _storedValue;

	public int AssignedCode
	{
		get
		{
			if (_assignedCode.HasValue)
			{
				return _assignedCode.Value;
			}
			if (DxfCodes.Length == 1)
			{
				return DxfCodes.First();
			}
			return -9999;
		}
	}

	public int[] DxfCodes => _attributeData.ValueCodes.Select((DxfCode c) => (int)c).ToArray();

	public DxfReferenceType ReferenceType => _attributeData.ReferenceType;

	public object StoredValue
	{
		get
		{
			return _storedValue;
		}
		set
		{
			_storedValue = value;
		}
	}

	public GroupCodeValueType GroupCode => GroupCodeValue.TransformValue(DxfCodes[0]);

	protected DxfPropertyBase(PropertyInfo property)
	{
		_attributeData = property.GetCustomAttribute<T>();
		if (_attributeData == null)
		{
			throw new ArgumentException("The property does not implement the DxfCodeValueAttribute", "property");
		}
		_property = property;
	}

	public void SetValue<TCadObject>(TCadObject obj, object value) where TCadObject : CadObject
	{
		if (AssignedCode == -9999)
		{
			throw new InvalidOperationException("This property has multiple dxf values assigned or doesn't have a default value assigned");
		}
		SetValue(AssignedCode, obj, value);
	}

	public void SetValue<TCadObject>(int code, TCadObject obj, object value) where TCadObject : CadObject
	{
		if (_property.PropertyType.IsEquivalentTo(typeof(XY)))
		{
			XY xY = (XY)_property.GetValue(obj);
			int index = code / 10 % 10 - 1;
			xY[index] = Convert.ToDouble(value);
			_property.SetValue(obj, xY);
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(XYZ)))
		{
			XYZ xYZ = (XYZ)_property.GetValue(obj);
			int index2 = code / 10 % 10 - 1;
			xYZ[index2] = Convert.ToDouble(value);
			_property.SetValue(obj, xYZ);
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(Color)))
		{
			switch (code)
			{
			case 62:
				_property.SetValue(obj, new Color((short)value));
				break;
			case 420:
			{
				byte[] bytes = LittleEndianConverter.Instance.GetBytes((int)value);
				_property.SetValue(obj, new Color(bytes[2], bytes[1], bytes[0]));
				break;
			}
			}
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(PaperMargin)))
		{
			PaperMargin paperMargin = (PaperMargin)_property.GetValue(obj);
			switch (code)
			{
			case 40:
				paperMargin = new PaperMargin((double)value, paperMargin.Bottom, paperMargin.Right, paperMargin.Top);
				break;
			case 41:
				paperMargin = new PaperMargin(paperMargin.Left, (double)value, paperMargin.Right, paperMargin.Top);
				break;
			case 42:
				paperMargin = new PaperMargin(paperMargin.Left, paperMargin.Bottom, (double)value, paperMargin.Top);
				break;
			case 43:
				paperMargin = new PaperMargin(paperMargin.Left, paperMargin.Bottom, paperMargin.Right, (double)value);
				break;
			}
			_property.SetValue(obj, paperMargin);
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(Transparency)))
		{
			_property.SetValue(obj, Transparency.FromAlphaValue((int)value));
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(bool)))
		{
			_property.SetValue(obj, Convert.ToBoolean(value));
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(char)))
		{
			_property.SetValue(obj, Convert.ToChar(value));
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(byte)))
		{
			_property.SetValue(obj, Convert.ToByte(value));
		}
		else if (_property.PropertyType.IsEnum)
		{
			_property.SetValue(obj, Enum.ToObject(_property.PropertyType, value));
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(ushort)))
		{
			_property.SetValue(obj, Convert.ToUInt16(value));
		}
		else
		{
			_property.SetValue(obj, value);
		}
	}

	internal void SetValue(int code, object obj, object value)
	{
		if (_property.PropertyType.IsEquivalentTo(typeof(XY)))
		{
			XY xY = (XY)_property.GetValue(obj);
			int index = code / 10 % 10 - 1;
			xY[index] = Convert.ToDouble(value);
			_property.SetValue(obj, xY);
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(XYZ)))
		{
			XYZ xYZ = (XYZ)_property.GetValue(obj);
			int index2 = code / 10 % 10 - 1;
			xYZ[index2] = Convert.ToDouble(value);
			_property.SetValue(obj, xYZ);
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(Color)))
		{
			switch (code)
			{
			case 62:
				_property.SetValue(obj, new Color((short)value));
				break;
			case 90:
			{
				byte[] bytes = LittleEndianConverter.Instance.GetBytes((int)value);
				_property.SetValue(obj, new Color(bytes[2], bytes[1], bytes[0]));
				break;
			}
			case 420:
			{
				byte[] bytes = LittleEndianConverter.Instance.GetBytes((int)value);
				_property.SetValue(obj, new Color(bytes[2], bytes[1], bytes[0]));
				break;
			}
			}
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(PaperMargin)))
		{
			PaperMargin paperMargin = (PaperMargin)_property.GetValue(obj);
			switch (code)
			{
			case 40:
				paperMargin = new PaperMargin((double)value, paperMargin.Bottom, paperMargin.Right, paperMargin.Top);
				break;
			case 41:
				paperMargin = new PaperMargin(paperMargin.Left, (double)value, paperMargin.Right, paperMargin.Top);
				break;
			case 42:
				paperMargin = new PaperMargin(paperMargin.Left, paperMargin.Bottom, (double)value, paperMargin.Top);
				break;
			case 43:
				paperMargin = new PaperMargin(paperMargin.Left, paperMargin.Bottom, paperMargin.Right, (double)value);
				break;
			}
			_property.SetValue(obj, paperMargin);
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(Transparency)))
		{
			_property.SetValue(obj, Transparency.FromAlphaValue((int)value));
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(bool)))
		{
			_property.SetValue(obj, Convert.ToBoolean(value));
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(char)))
		{
			_property.SetValue(obj, Convert.ToChar(value));
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(byte)))
		{
			_property.SetValue(obj, Convert.ToByte(value));
		}
		else if (_property.PropertyType.IsEnum)
		{
			_property.SetValue(obj, Enum.ToObject(_property.PropertyType, value));
		}
		else if (_property.PropertyType.IsEquivalentTo(typeof(ushort)))
		{
			_property.SetValue(obj, Convert.ToUInt16(value));
		}
		else
		{
			_property.SetValue(obj, value);
		}
	}

	protected int getCounterValue<TCadObject>(TCadObject obj)
	{
		if (!_property.PropertyType.HasInterface<IEnumerable>())
		{
			throw new ArgumentException();
		}
		IEnumerable enumerable = (IEnumerable)_property.GetValue(obj);
		if (enumerable == null)
		{
			return 0;
		}
		int num = 0;
		foreach (object item in enumerable)
		{
			_ = item;
			num++;
		}
		return num;
	}

	protected ulong? getHandledValue<TCadObject>(TCadObject obj)
	{
		if (!_property.PropertyType.HasInterface<IHandledCadObject>())
		{
			throw new ArgumentException("Property " + _property.Name + " for type : " + obj.GetType().FullName + " does not implement IHandledCadObject");
		}
		return ((IHandledCadObject)_property.GetValue(obj))?.Handle;
	}

	protected string getNamedValue<TCadObject>(TCadObject obj)
	{
		if (!_property.PropertyType.HasInterface<INamedCadObject>())
		{
			throw new ArgumentException("Property " + _property.Name + " for type : " + obj.GetType().FullName + " does not implement INamedCadObject");
		}
		return ((INamedCadObject)_property.GetValue(obj))?.Name;
	}

	public object GetRawValue(CadObject obj)
	{
		return getRawValue(AssignedCode, obj);
	}

	protected object getRawValue<TCadObject>(int code, TCadObject obj)
	{
		GroupCodeValueType groupCodeValueType = GroupCodeValue.TransformValue(code);
		if ((uint)(groupCodeValueType - 8) <= 1u || groupCodeValueType == GroupCodeValueType.ExtendedDataHandle)
		{
			return getHandledValue(obj);
		}
		if (_property.PropertyType.HasInterface<IVector>())
		{
			IVector obj2 = (IVector)_property.GetValue(obj);
			int index = code / 10 % 10 - 1;
			return obj2[index];
		}
		if (_property.PropertyType.IsEquivalentTo(typeof(DateTime)))
		{
			return CadUtils.ToJulianCalendar((DateTime)_property.GetValue(obj));
		}
		if (_property.PropertyType.IsEquivalentTo(typeof(TimeSpan)))
		{
			return ((TimeSpan)_property.GetValue(obj)).TotalDays;
		}
		if (_property.PropertyType.IsEquivalentTo(typeof(Color)))
		{
			Color color = (Color)_property.GetValue(obj);
			switch (code)
			{
			case 62:
			case 70:
				return color.Index;
			case 420:
				return color.TrueColor;
			default:
				return null;
			}
		}
		if (_property.PropertyType.IsEquivalentTo(typeof(PaperMargin)))
		{
			return code switch
			{
				40 => ((PaperMargin)_property.GetValue(obj)).Left, 
				41 => ((PaperMargin)_property.GetValue(obj)).Bottom, 
				42 => ((PaperMargin)_property.GetValue(obj)).Right, 
				43 => ((PaperMargin)_property.GetValue(obj)).Top, 
				_ => throw new Exception(), 
			};
		}
		if (_property.PropertyType.IsEquivalentTo(typeof(Transparency)))
		{
			return null;
		}
		return _property.GetValue(obj);
	}
}
