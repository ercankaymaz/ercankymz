using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.ProfilePropertyResource;

[ExpressType("IfcRibPlateProfileProperties", 763)]
public class IfcRibPlateProfileProperties : IfcProfileProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRibPlateProfileProperties>
{
	private IfcPositiveLengthMeasure? _thickness;

	private IfcPositiveLengthMeasure? _ribHeight;

	private IfcPositiveLengthMeasure? _ribWidth;

	private IfcPositiveLengthMeasure? _ribSpacing;

	private IfcRibPlateDirectionEnum _direction;

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcPositiveLengthMeasure? Thickness
	{
		get
		{
			if (_activated)
			{
				return _thickness;
			}
			Activate();
			return _thickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_thickness = v;
			}, _thickness, value, "Thickness", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure? RibHeight
	{
		get
		{
			if (_activated)
			{
				return _ribHeight;
			}
			Activate();
			return _ribHeight;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_ribHeight = v;
			}, _ribHeight, value, "RibHeight", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcPositiveLengthMeasure? RibWidth
	{
		get
		{
			if (_activated)
			{
				return _ribWidth;
			}
			Activate();
			return _ribWidth;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_ribWidth = v;
			}, _ribWidth, value, "RibWidth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure? RibSpacing
	{
		get
		{
			if (_activated)
			{
				return _ribSpacing;
			}
			Activate();
			return _ribSpacing;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_ribSpacing = v;
			}, _ribSpacing, value, "RibSpacing", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 7)]
	public IfcRibPlateDirectionEnum Direction
	{
		get
		{
			if (_activated)
			{
				return _direction;
			}
			Activate();
			return _direction;
		}
		set
		{
			SetValue(delegate(IfcRibPlateDirectionEnum v)
			{
				_direction = v;
			}, _direction, value, "Direction", 7);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ProfileDefinition != null)
			{
				yield return base.ProfileDefinition;
			}
		}
	}

	internal IfcRibPlateProfileProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_thickness = value.RealVal;
			break;
		case 3:
			_ribHeight = value.RealVal;
			break;
		case 4:
			_ribWidth = value.RealVal;
			break;
		case 5:
			_ribSpacing = value.RealVal;
			break;
		case 6:
			_direction = (IfcRibPlateDirectionEnum)Enum.Parse(typeof(IfcRibPlateDirectionEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRibPlateProfileProperties other)
	{
		return this == other;
	}
}
