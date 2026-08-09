using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;

namespace Xbim.Ifc2x3.PresentationDefinitionResource;

[ExpressType("IfcDefinedSymbol", 461)]
public class IfcDefinedSymbol : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcDefinedSymbol>
{
	private IfcDefinedSymbolSelect _definition;

	private IfcCartesianTransformationOperator2D _target;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcDefinedSymbolSelect Definition
	{
		get
		{
			if (_activated)
			{
				return _definition;
			}
			Activate();
			return _definition;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDefinedSymbolSelect v)
			{
				_definition = v;
			}, _definition, value, "Definition", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcCartesianTransformationOperator2D Target
	{
		get
		{
			if (_activated)
			{
				return _target;
			}
			Activate();
			return _target;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCartesianTransformationOperator2D v)
			{
				_target = v;
			}, _target, value, "Target", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Definition != null)
			{
				yield return Definition;
			}
			if (Target != null)
			{
				yield return Target;
			}
		}
	}

	internal IfcDefinedSymbol(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_definition = (IfcDefinedSymbolSelect)value.EntityVal;
			break;
		case 1:
			_target = (IfcCartesianTransformationOperator2D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDefinedSymbol other)
	{
		return this == other;
	}
}
