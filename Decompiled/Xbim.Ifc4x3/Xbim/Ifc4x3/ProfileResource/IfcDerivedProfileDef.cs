using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcDerivedProfileDef", 390)]
public class IfcDerivedProfileDef : IfcProfileDef, IIfcDerivedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcDerivedProfileDef>
{
	private IfcProfileDef _parentProfile;

	private IfcCartesianTransformationOperator2D _operator;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _label;

	[CrossSchemaAttribute(typeof(IIfcDerivedProfileDef), 3)]
	IIfcProfileDef IIfcDerivedProfileDef.ParentProfile
	{
		get
		{
			return ParentProfile;
		}
		set
		{
			ParentProfile = value as IfcProfileDef;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDerivedProfileDef), 4)]
	IIfcCartesianTransformationOperator2D IIfcDerivedProfileDef.Operator
	{
		get
		{
			return Operator;
		}
		set
		{
			Operator = value as IfcCartesianTransformationOperator2D;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDerivedProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcDerivedProfileDef.Label
	{
		get
		{
			if (!Label.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Label.Value);
		}
		set
		{
			Label = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcProfileDef ParentProfile
	{
		get
		{
			if (_activated)
			{
				return _parentProfile;
			}
			Activate();
			return _parentProfile;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_parentProfile = v;
			}, _parentProfile, value, "ParentProfile", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public virtual IfcCartesianTransformationOperator2D Operator
	{
		get
		{
			if (_activated)
			{
				return _operator;
			}
			Activate();
			return _operator;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianTransformationOperator2D v)
			{
				_operator = v;
			}, _operator, value, "Operator", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Label
	{
		get
		{
			if (_activated)
			{
				return _label;
			}
			Activate();
			return _label;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_label = v;
			}, _label, value, "Label", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ParentProfile != null)
			{
				yield return ParentProfile;
			}
			if (Operator != null)
			{
				yield return Operator;
			}
		}
	}

	internal IfcDerivedProfileDef(IModel model, int label, bool activated)
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
			_parentProfile = (IfcProfileDef)value.EntityVal;
			break;
		case 3:
			_operator = (IfcCartesianTransformationOperator2D)value.EntityVal;
			break;
		case 4:
			_label = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDerivedProfileDef other)
	{
		return this == other;
	}
}
