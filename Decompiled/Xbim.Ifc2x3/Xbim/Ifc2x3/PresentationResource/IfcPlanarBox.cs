using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.PresentationResource;

[ExpressType("IfcPlanarBox", 762)]
public class IfcPlanarBox : IfcPlanarExtent, IIfcPlanarBox, IIfcPlanarExtent, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPlanarBox>
{
	private IfcAxis2Placement _placement;

	[CrossSchemaAttribute(typeof(IIfcPlanarBox), 3)]
	IIfcAxis2Placement IIfcPlanarBox.Placement
	{
		get
		{
			if (Placement == null)
			{
				return null;
			}
			IfcAxis2Placement2D ifcAxis2Placement2D = Placement as IfcAxis2Placement2D;
			if (ifcAxis2Placement2D != null)
			{
				return ifcAxis2Placement2D;
			}
			IfcAxis2Placement3D ifcAxis2Placement3D = Placement as IfcAxis2Placement3D;
			if (ifcAxis2Placement3D != null)
			{
				return ifcAxis2Placement3D;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				Placement = null;
				return;
			}
			IfcAxis2Placement2D ifcAxis2Placement2D = value as IfcAxis2Placement2D;
			if (ifcAxis2Placement2D != null)
			{
				Placement = ifcAxis2Placement2D;
				return;
			}
			IfcAxis2Placement3D ifcAxis2Placement3D = value as IfcAxis2Placement3D;
			if (ifcAxis2Placement3D != null)
			{
				Placement = ifcAxis2Placement3D;
			}
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
