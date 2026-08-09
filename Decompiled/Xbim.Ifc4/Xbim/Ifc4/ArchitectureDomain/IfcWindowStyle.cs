using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ArchitectureDomain;

[ExpressType("IfcWindowStyle", 345)]
public class IfcWindowStyle : IfcTypeProduct, IInstantiableEntity, IPersistEntity, IPersist, IIfcWindowStyle, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWindowStyle>
{
	private IfcWindowStyleConstructionEnum _constructionType;

	private IfcWindowStyleOperationEnum _operationType;

	private IfcBoolean _parameterTakesPrecedence;

	private IfcBoolean _sizeable;

	IfcWindowStyleConstructionEnum IIfcWindowStyle.ConstructionType
	{
		get
		{
			return ConstructionType;
		}
		set
		{
			ConstructionType = value;
		}
	}

	IfcWindowStyleOperationEnum IIfcWindowStyle.OperationType
	{
		get
		{
			return OperationType;
		}
		set
		{
			OperationType = value;
		}
	}

	IfcBoolean IIfcWindowStyle.ParameterTakesPrecedence
	{
		get
		{
			return ParameterTakesPrecedence;
		}
		set
		{
			ParameterTakesPrecedence = value;
		}
	}

	IfcBoolean IIfcWindowStyle.Sizeable
	{
		get
		{
			return Sizeable;
		}
		set
		{
			Sizeable = value;
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 18)]
	public IfcWindowStyleConstructionEnum ConstructionType
	{
		get
		{
			if (_activated)
			{
				return _constructionType;
			}
			Activate();
			return _constructionType;
		}
		set
		{
			SetValue(delegate(IfcWindowStyleConstructionEnum v)
			{
				_constructionType = v;
			}, _constructionType, value, "ConstructionType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcWindowStyleOperationEnum OperationType
	{
		get
		{
			if (_activated)
			{
				return _operationType;
			}
			Activate();
			return _operationType;
		}
		set
		{
			SetValue(delegate(IfcWindowStyleOperationEnum v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcBoolean ParameterTakesPrecedence
	{
		get
		{
			if (_activated)
			{
				return _parameterTakesPrecedence;
			}
			Activate();
			return _parameterTakesPrecedence;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_parameterTakesPrecedence = v;
			}, _parameterTakesPrecedence, value, "ParameterTakesPrecedence", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public IfcBoolean Sizeable
	{
		get
		{
			if (_activated)
			{
				return _sizeable;
			}
			Activate();
			return _sizeable;
		}
		set
		{
			SetValue(delegate(IfcBoolean v)
			{
				_sizeable = v;
			}, _sizeable, value, "Sizeable", 12);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcWindowStyle(IModel model, int label, bool activated)
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
		case 4:
		case 5:
		case 6:
		case 7:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 8:
			_constructionType = (IfcWindowStyleConstructionEnum)Enum.Parse(typeof(IfcWindowStyleConstructionEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_operationType = (IfcWindowStyleOperationEnum)Enum.Parse(typeof(IfcWindowStyleOperationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 10:
			_parameterTakesPrecedence = value.BooleanVal;
			break;
		case 11:
			_sizeable = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWindowStyle other)
	{
		return this == other;
	}
}
