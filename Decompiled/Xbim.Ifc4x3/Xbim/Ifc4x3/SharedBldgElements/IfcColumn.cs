using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcColumn", 383)]
public class IfcColumn : IfcBuiltElement, IIfcColumn, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcColumn>
{
	private IfcColumnTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcColumn), 9)]
	Xbim.Ifc4.Interfaces.IfcColumnTypeEnum? IIfcColumn.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcColumnTypeEnum.COLUMN => Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.COLUMN, 
				IfcColumnTypeEnum.PIERSTEM => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcColumnTypeEnum>(), 
				IfcColumnTypeEnum.PIERSTEM_SEGMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcColumnTypeEnum>(), 
				IfcColumnTypeEnum.PILASTER => Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.PILASTER, 
				IfcColumnTypeEnum.STANDCOLUMN => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcColumnTypeEnum>(), 
				IfcColumnTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.USERDEFINED, 
				IfcColumnTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.COLUMN:
				PredefinedType = IfcColumnTypeEnum.COLUMN;
				break;
			case Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.PILASTER:
				PredefinedType = IfcColumnTypeEnum.PILASTER;
				break;
			case Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.USERDEFINED:
				PredefinedType = IfcColumnTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcColumnTypeEnum.NOTDEFINED:
				PredefinedType = IfcColumnTypeEnum.NOTDEFINED;
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
	public IfcColumnTypeEnum? PredefinedType
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
			SetValue(delegate(IfcColumnTypeEnum? v)
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

	internal IfcColumn(IModel model, int label, bool activated)
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
			_predefinedType = (IfcColumnTypeEnum)Enum.Parse(typeof(IfcColumnTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcColumn other)
	{
		return this == other;
	}
}
