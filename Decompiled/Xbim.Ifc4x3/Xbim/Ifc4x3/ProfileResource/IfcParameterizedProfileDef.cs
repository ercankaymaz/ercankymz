using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcParameterizedProfileDef", 104)]
public abstract class IfcParameterizedProfileDef : IfcProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IEquatable<IfcParameterizedProfileDef>
{
	private IfcAxis2Placement2D _position;

	[CrossSchemaAttribute(typeof(IIfcParameterizedProfileDef), 3)]
	IIfcAxis2Placement2D IIfcParameterizedProfileDef.Position
	{
		get
		{
			return Position;
		}
		set
		{
			Position = value as IfcAxis2Placement2D;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcAxis2Placement2D Position
	{
		get
		{
			if (_activated)
			{
				return _position;
			}
			Activate();
			return _position;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement2D v)
			{
				_position = v;
			}, _position, value, "Position", 3);
		}
	}

	internal IfcParameterizedProfileDef(IModel model, int label, bool activated)
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
			_position = (IfcAxis2Placement2D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcParameterizedProfileDef other)
	{
		return this == other;
	}
}
