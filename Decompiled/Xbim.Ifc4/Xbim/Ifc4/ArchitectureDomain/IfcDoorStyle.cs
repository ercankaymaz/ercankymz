using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ArchitectureDomain;

[ExpressType("IfcDoorStyle", 492)]
public class IfcDoorStyle : IfcTypeProduct, IInstantiableEntity, IPersistEntity, IPersist, IIfcDoorStyle, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcDoorStyle>
{
	private IfcDoorStyleOperationEnum _operationType;

	private IfcDoorStyleConstructionEnum _constructionType;

	private IfcBoolean _parameterTakesPrecedence;

	private IfcBoolean _sizeable;

	IfcDoorStyleOperationEnum IIfcDoorStyle.OperationType
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

	IfcDoorStyleConstructionEnum IIfcDoorStyle.ConstructionType
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

	IfcBoolean IIfcDoorStyle.ParameterTakesPrecedence
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

	IfcBoolean IIfcDoorStyle.Sizeable
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
	public IfcDoorStyleOperationEnum OperationType
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
			SetValue(delegate(IfcDoorStyleOperationEnum v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcDoorStyleConstructionEnum ConstructionType
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
			SetValue(delegate(IfcDoorStyleConstructionEnum v)
			{
				_constructionType = v;
			}, _constructionType, value, "ConstructionType", 10);
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

	internal IfcDoorStyle(IModel model, int label, bool activated)
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
			_operationType = (IfcDoorStyleOperationEnum)Enum.Parse(typeof(IfcDoorStyleOperationEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_constructionType = (IfcDoorStyleConstructionEnum)Enum.Parse(typeof(IfcDoorStyleConstructionEnum), value.EnumVal, ignoreCase: true);
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

	public bool Equals(IfcDoorStyle other)
	{
		return this == other;
	}
}
