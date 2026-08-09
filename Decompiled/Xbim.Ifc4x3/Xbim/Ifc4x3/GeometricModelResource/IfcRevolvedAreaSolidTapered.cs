using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.ProfileResource;

namespace Xbim.Ifc4x3.GeometricModelResource;

[ExpressType("IfcRevolvedAreaSolidTapered", 1260)]
public class IfcRevolvedAreaSolidTapered : IfcRevolvedAreaSolid, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcRevolvedAreaSolidTapered>, IIfcRevolvedAreaSolidTapered, IIfcRevolvedAreaSolid, IIfcSweptAreaSolid, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IIfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	private IfcProfileDef _endSweptArea;

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcProfileDef EndSweptArea
	{
		get
		{
			if (_activated)
			{
				return _endSweptArea;
			}
			Activate();
			return _endSweptArea;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProfileDef v)
			{
				_endSweptArea = v;
			}, _endSweptArea, value, "EndSweptArea", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SweptArea != null)
			{
				yield return base.SweptArea;
			}
			if (base.Position != null)
			{
				yield return base.Position;
			}
			if (base.Axis != null)
			{
				yield return base.Axis;
			}
			if (EndSweptArea != null)
			{
				yield return EndSweptArea;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcRevolvedAreaSolidTapered), 5)]
	IIfcProfileDef IIfcRevolvedAreaSolidTapered.EndSweptArea
	{
		get
		{
			return EndSweptArea;
		}
		set
		{
			EndSweptArea = value as IfcProfileDef;
		}
	}

	internal IfcRevolvedAreaSolidTapered(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_endSweptArea = (IfcProfileDef)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRevolvedAreaSolidTapered other)
	{
		return this == other;
	}
}
