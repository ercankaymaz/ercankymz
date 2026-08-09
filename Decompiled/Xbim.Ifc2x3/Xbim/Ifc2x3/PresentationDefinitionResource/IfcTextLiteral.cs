using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.PresentationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcTextLiteral", 29)]
public class IfcTextLiteral : IfcGeometricRepresentationItem, IIfcTextLiteral, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTextLiteral>
{
	private Xbim.Ifc2x3.PresentationResource.IfcPresentableText _literal;

	private IfcAxis2Placement _placement;

	private IfcTextPath _path;

	[CrossSchemaAttribute(typeof(IIfcTextLiteral), 1)]
	Xbim.Ifc4.PresentationAppearanceResource.IfcPresentableText IIfcTextLiteral.Literal
	{
		get
		{
			return new Xbim.Ifc4.PresentationAppearanceResource.IfcPresentableText(Literal);
		}
		set
		{
			Literal = new Xbim.Ifc2x3.PresentationResource.IfcPresentableText(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextLiteral), 2)]
	IIfcAxis2Placement IIfcTextLiteral.Placement
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

	[CrossSchemaAttribute(typeof(IIfcTextLiteral), 3)]
	Xbim.Ifc4.Interfaces.IfcTextPath IIfcTextLiteral.Path
	{
		get
		{
			return Path switch
			{
				IfcTextPath.LEFT => Xbim.Ifc4.Interfaces.IfcTextPath.LEFT, 
				IfcTextPath.RIGHT => Xbim.Ifc4.Interfaces.IfcTextPath.RIGHT, 
				IfcTextPath.UP => Xbim.Ifc4.Interfaces.IfcTextPath.UP, 
				IfcTextPath.DOWN => Xbim.Ifc4.Interfaces.IfcTextPath.DOWN, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTextPath.LEFT:
				Path = IfcTextPath.LEFT;
				break;
			case Xbim.Ifc4.Interfaces.IfcTextPath.RIGHT:
				Path = IfcTextPath.RIGHT;
				break;
			case Xbim.Ifc4.Interfaces.IfcTextPath.UP:
				Path = IfcTextPath.UP;
				break;
			case Xbim.Ifc4.Interfaces.IfcTextPath.DOWN:
				Path = IfcTextPath.DOWN;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.PresentationResource.IfcPresentableText Literal
	{
		get
		{
			if (_activated)
			{
				return _literal;
			}
			Activate();
			return _literal;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcPresentableText v)
			{
				_literal = v;
			}, _literal, value, "Literal", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
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
			}, _placement, value, "Placement", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 5)]
	public IfcTextPath Path
	{
		get
		{
			if (_activated)
			{
				return _path;
			}
			Activate();
			return _path;
		}
		set
		{
			SetValue(delegate(IfcTextPath v)
			{
				_path = v;
			}, _path, value, "Path", 3);
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

	internal IfcTextLiteral(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_literal = value.StringVal;
			break;
		case 1:
			_placement = (IfcAxis2Placement)value.EntityVal;
			break;
		case 2:
			_path = (IfcTextPath)Enum.Parse(typeof(IfcTextPath), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextLiteral other)
	{
		return this == other;
	}
}
