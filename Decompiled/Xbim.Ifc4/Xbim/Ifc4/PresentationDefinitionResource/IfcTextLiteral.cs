using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.PresentationDefinitionResource;

[ExpressType("IfcTextLiteral", 29)]
public class IfcTextLiteral : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcTextLiteral, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcTextLiteral>
{
	private IfcPresentableText _literal;

	private IfcAxis2Placement _placement;

	private IfcTextPath _path;

	IfcPresentableText IIfcTextLiteral.Literal
	{
		get
		{
			return Literal;
		}
		set
		{
			Literal = value;
		}
	}

	IIfcAxis2Placement IIfcTextLiteral.Placement
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

	IfcTextPath IIfcTextLiteral.Path
	{
		get
		{
			return Path;
		}
		set
		{
			Path = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcPresentableText Literal
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
			SetValue(delegate(IfcPresentableText v)
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
