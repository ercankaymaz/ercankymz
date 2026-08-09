using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcTextureCoordinateGenerator", 733)]
public class IfcTextureCoordinateGenerator : IfcTextureCoordinate, IIfcTextureCoordinateGenerator, IIfcTextureCoordinate, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IEquatable<IfcTextureCoordinateGenerator>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel _mode;

	private readonly ItemSet<Xbim.Ifc2x3.MeasureResource.IfcSimpleValue> _parameter;

	[CrossSchemaAttribute(typeof(IIfcTextureCoordinateGenerator), 2)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcTextureCoordinateGenerator.Mode
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Mode);
		}
		set
		{
			Mode = new Xbim.Ifc2x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextureCoordinateGenerator), 3)]
	IEnumerable<Xbim.Ifc4.MeasureResource.IfcReal> IIfcTextureCoordinateGenerator.Parameter
	{
		get
		{
			foreach (Xbim.Ifc2x3.MeasureResource.IfcSimpleValue item in Parameter)
			{
				double result;
				if (item.UnderlyingSystemType == typeof(double) || item.UnderlyingSystemType == typeof(int))
				{
					yield return new Xbim.Ifc4.MeasureResource.IfcReal(Convert.ToDouble(item.Value));
				}
				else if (item.UnderlyingSystemType == typeof(string) && double.TryParse((string)item.Value, out result))
				{
					yield return new Xbim.Ifc4.MeasureResource.IfcReal(result);
				}
			}
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel Mode
	{
		get
		{
			if (_activated)
			{
				return _mode;
			}
			Activate();
			return _mode;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel v)
			{
				_mode = v;
			}, _mode, value, "Mode", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<Xbim.Ifc2x3.MeasureResource.IfcSimpleValue> Parameter
	{
		get
		{
			if (_activated)
			{
				return _parameter;
			}
			Activate();
			return _parameter;
		}
	}

	internal IfcTextureCoordinateGenerator(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_parameter = new ItemSet<Xbim.Ifc2x3.MeasureResource.IfcSimpleValue>(this, 0, 2);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_mode = value.StringVal;
			break;
		case 1:
			_parameter.InternalAdd((Xbim.Ifc2x3.MeasureResource.IfcSimpleValue)value.EntityVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextureCoordinateGenerator other)
	{
		return this == other;
	}
}
