using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.PresentationDefinitionResource;

[ExpressType("IfcPlanarBox", 762)]
public class IfcPlanarBox : IfcPlanarExtent, IInstantiableEntity, IPersistEntity, IPersist, IIfcPlanarBox, IIfcPlanarExtent, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcPlanarBox>
{
	private IfcAxis2Placement _placement;

	IIfcAxis2Placement IIfcPlanarBox.Placement
	{
		get
		{
			return Placement;
		}
		set
		{
			Placement = value as IfcAxis2Placement;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcAxis2Placement Placement
	{
		get
		{
			if (_activated)
			{
				return _placement;
			}
			Activate();
			return _placement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement v)
			{
				_placement = v;
			}, _placement, value, "Placement", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Placement != null)
			{
				yield return Placement;
			}
		}
	}

	internal IfcPlanarBox(IModel model, int label, bool activated)
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
			_placement = (IfcAxis2Placement)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPlanarBox other)
	{
		return this == other;
	}
}
