using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcAlignment", 1330)]
public class IfcAlignment : IfcLinearPositioningElement, IIfcAlignment, IIfcLinearPositioningElement, IIfcPositioningElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcAlignment>
{
	private IfcAlignmentTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcAlignment), 9)]
	Xbim.Ifc4.Interfaces.IfcAlignmentTypeEnum? IIfcAlignment.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcAlignmentTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcAlignmentTypeEnum.USERDEFINED, 
				IfcAlignmentTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAlignmentTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAlignmentTypeEnum.USERDEFINED:
				PredefinedType = IfcAlignmentTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcAlignmentTypeEnum.NOTDEFINED:
				PredefinedType = IfcAlignmentTypeEnum.NOTDEFINED;
				break;
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 24)]
	public IfcAlignmentTypeEnum? PredefinedType
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
			SetValue(delegate(IfcAlignmentTypeEnum? v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 8);
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

	internal IfcAlignment(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 7:
			_predefinedType = (IfcAlignmentTypeEnum)Enum.Parse(typeof(IfcAlignmentTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignment other)
	{
		return this == other;
	}
}
