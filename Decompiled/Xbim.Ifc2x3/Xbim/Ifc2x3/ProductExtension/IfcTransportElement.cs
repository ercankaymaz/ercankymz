using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcTransportElement", 416)]
public class IfcTransportElement : IfcElement, IIfcTransportElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTransportElement>
{
	private Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum? _predefinedType;

	private IfcTransportElementTypeEnum? _operationType;

	private IfcMassMeasure? _capacityByWeight;

	private IfcCountMeasure? _capacityByNumber;

	[CrossSchemaAttribute(typeof(IIfcTransportElement), 9)]
	Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum? IIfcTransportElement.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -9);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 27)]
	public IfcTransportElementTypeEnum? OperationType
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
			SetValue(delegate(IfcTransportElementTypeEnum? v)
			{
				_operationType = v;
			}, _operationType, value, "OperationType", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 28)]
	public IfcMassMeasure? CapacityByWeight
	{
		get
		{
			if (_activated)
			{
				return _capacityByWeight;
			}
			Activate();
			return _capacityByWeight;
		}
		set
		{
			SetValue(delegate(IfcMassMeasure? v)
			{
				_capacityByWeight = v;
			}, _capacityByWeight, value, "CapacityByWeight", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 29)]
	public IfcCountMeasure? CapacityByNumber
	{
		get
		{
			if (_activated)
			{
				return _capacityByNumber;
			}
			Activate();
			return _capacityByNumber;
		}
		set
		{
			SetValue(delegate(IfcCountMeasure? v)
			{
				_capacityByNumber = v;
			}, _capacityByNumber, value, "CapacityByNumber", 11);
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
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (base.ObjectPlacement != null)
			{
				yield return base.ObjectPlacement;
			}
			if (base.Representation != null)
			{
				yield return base.Representation;
			}
		}
	}

	internal IfcTransportElement(IModel model, int label, bool activated)
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
			_operationType = (IfcTransportElementTypeEnum)Enum.Parse(typeof(IfcTransportElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_capacityByWeight = value.RealVal;
			break;
		case 10:
			_capacityByNumber = value.NumberVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTransportElement other)
	{
		return this == other;
	}
}
