using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.SharedComponentElements;

[ExpressType("IfcFastener", 535)]
public class IfcFastener : IfcElementComponent, IIfcFastener, IIfcElementComponent, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcFastener>
{
	private IfcFastenerTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcFastener), 9)]
	Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum? IIfcFastener.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcFastenerTypeEnum.GLUE => Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.GLUE, 
				IfcFastenerTypeEnum.MORTAR => Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.MORTAR, 
				IfcFastenerTypeEnum.WELD => Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.WELD, 
				IfcFastenerTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.USERDEFINED, 
				IfcFastenerTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.GLUE:
				PredefinedType = IfcFastenerTypeEnum.GLUE;
				break;
			case Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.MORTAR:
				PredefinedType = IfcFastenerTypeEnum.MORTAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.WELD:
				PredefinedType = IfcFastenerTypeEnum.WELD;
				break;
			case Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.USERDEFINED:
				PredefinedType = IfcFastenerTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcFastenerTypeEnum.NOTDEFINED:
				PredefinedType = IfcFastenerTypeEnum.NOTDEFINED;
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
	public IfcFastenerTypeEnum? PredefinedType
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
			SetValue(delegate(IfcFastenerTypeEnum? v)
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

	internal IfcFastener(IModel model, int label, bool activated)
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
			_predefinedType = (IfcFastenerTypeEnum)Enum.Parse(typeof(IfcFastenerTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFastener other)
	{
		return this == other;
	}
}
