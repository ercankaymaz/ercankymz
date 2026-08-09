using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcTransportElement", 416)]
public class IfcTransportElement : IfcTransportationDevice, IIfcTransportElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcTransportElement>
{
	private IfcTransportElementTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcTransportElement), 9)]
	Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum? IIfcTransportElement.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcTransportElementTypeEnum.CRANEWAY => Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.CRANEWAY, 
				IfcTransportElementTypeEnum.ELEVATOR => Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.ELEVATOR, 
				IfcTransportElementTypeEnum.ESCALATOR => Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.ESCALATOR, 
				IfcTransportElementTypeEnum.HAULINGGEAR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum>(), 
				IfcTransportElementTypeEnum.LIFTINGGEAR => Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.LIFTINGGEAR, 
				IfcTransportElementTypeEnum.MOVINGWALKWAY => Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.MOVINGWALKWAY, 
				IfcTransportElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.USERDEFINED, 
				IfcTransportElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.ELEVATOR:
				PredefinedType = IfcTransportElementTypeEnum.ELEVATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.ESCALATOR:
				PredefinedType = IfcTransportElementTypeEnum.ESCALATOR;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.MOVINGWALKWAY:
				PredefinedType = IfcTransportElementTypeEnum.MOVINGWALKWAY;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.CRANEWAY:
				PredefinedType = IfcTransportElementTypeEnum.CRANEWAY;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.LIFTINGGEAR:
				PredefinedType = IfcTransportElementTypeEnum.LIFTINGGEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.USERDEFINED:
				PredefinedType = IfcTransportElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcTransportElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcTransportElementTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcTransportElementTypeEnum? PredefinedType
	{
		get
		{
			if (_activated)
			{
				return _predefinedType;
			}
			Activate();
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcTransportElementTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 9);
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
			_predefinedType = (IfcTransportElementTypeEnum)Enum.Parse(typeof(IfcTransportElementTypeEnum), value.EnumVal, ignoreCase: true);
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
