using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcRailing", 350)]
public class IfcRailing : IfcBuiltElement, IIfcRailing, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRailing>
{
	private IfcRailingTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcRailing), 9)]
	Xbim.Ifc4.Interfaces.IfcRailingTypeEnum? IIfcRailing.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcRailingTypeEnum.BALUSTRADE => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.BALUSTRADE, 
				IfcRailingTypeEnum.FENCE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcRailingTypeEnum>(), 
				IfcRailingTypeEnum.GUARDRAIL => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.GUARDRAIL, 
				IfcRailingTypeEnum.HANDRAIL => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.HANDRAIL, 
				IfcRailingTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.USERDEFINED, 
				IfcRailingTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.HANDRAIL:
				PredefinedType = IfcRailingTypeEnum.HANDRAIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.GUARDRAIL:
				PredefinedType = IfcRailingTypeEnum.GUARDRAIL;
				break;
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.BALUSTRADE:
				PredefinedType = IfcRailingTypeEnum.BALUSTRADE;
				break;
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.USERDEFINED:
				PredefinedType = IfcRailingTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcRailingTypeEnum.NOTDEFINED:
				PredefinedType = IfcRailingTypeEnum.NOTDEFINED;
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
	public IfcRailingTypeEnum? PredefinedType
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
			SetValue(delegate(IfcRailingTypeEnum? v)
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

	internal IfcRailing(IModel model, int label, bool activated)
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
			_predefinedType = (IfcRailingTypeEnum)Enum.Parse(typeof(IfcRailingTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRailing other)
	{
		return this == other;
	}
}
