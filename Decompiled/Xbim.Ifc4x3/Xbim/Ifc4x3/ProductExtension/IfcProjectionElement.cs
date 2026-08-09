using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcProjectionElement", 384)]
public class IfcProjectionElement : IfcFeatureElementAddition, IIfcProjectionElement, IIfcFeatureElementAddition, IIfcFeatureElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcProjectionElement>
{
	private IfcProjectionElementTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcProjectionElement), 9)]
	Xbim.Ifc4.Interfaces.IfcProjectionElementTypeEnum? IIfcProjectionElement.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcProjectionElementTypeEnum.BLISTER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcProjectionElementTypeEnum>(), 
				IfcProjectionElementTypeEnum.DEVIATOR => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcProjectionElementTypeEnum>(), 
				IfcProjectionElementTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcProjectionElementTypeEnum.USERDEFINED, 
				IfcProjectionElementTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcProjectionElementTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcProjectionElementTypeEnum.USERDEFINED:
				PredefinedType = IfcProjectionElementTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcProjectionElementTypeEnum.NOTDEFINED:
				PredefinedType = IfcProjectionElementTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 36)]
	public IfcProjectionElementTypeEnum? PredefinedType
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
			SetValue(delegate(IfcProjectionElementTypeEnum? v)
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

	internal IfcProjectionElement(IModel model, int label, bool activated)
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
			_predefinedType = (IfcProjectionElementTypeEnum)Enum.Parse(typeof(IfcProjectionElementTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProjectionElement other)
	{
		return this == other;
	}
}
