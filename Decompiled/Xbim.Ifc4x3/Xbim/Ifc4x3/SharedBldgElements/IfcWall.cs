using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcWall", 452)]
public class IfcWall : IfcBuiltElement, IIfcWall, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcWall>
{
	private IfcWallTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcWall), 9)]
	Xbim.Ifc4.Interfaces.IfcWallTypeEnum? IIfcWall.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcWallTypeEnum.ELEMENTEDWALL => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.ELEMENTEDWALL, 
				IfcWallTypeEnum.MOVABLE => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.MOVABLE, 
				IfcWallTypeEnum.PARAPET => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PARAPET, 
				IfcWallTypeEnum.PARTITIONING => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PARTITIONING, 
				IfcWallTypeEnum.PLUMBINGWALL => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PLUMBINGWALL, 
				IfcWallTypeEnum.POLYGONAL => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.POLYGONAL, 
				IfcWallTypeEnum.RETAININGWALL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcWallTypeEnum>(), 
				IfcWallTypeEnum.SHEAR => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.SHEAR, 
				IfcWallTypeEnum.SOLIDWALL => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.SOLIDWALL, 
				IfcWallTypeEnum.STANDARD => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.STANDARD, 
				IfcWallTypeEnum.WAVEWALL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcWallTypeEnum>(), 
				IfcWallTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.USERDEFINED, 
				IfcWallTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcWallTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.MOVABLE:
				PredefinedType = IfcWallTypeEnum.MOVABLE;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PARAPET:
				PredefinedType = IfcWallTypeEnum.PARAPET;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PARTITIONING:
				PredefinedType = IfcWallTypeEnum.PARTITIONING;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.PLUMBINGWALL:
				PredefinedType = IfcWallTypeEnum.PLUMBINGWALL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.SHEAR:
				PredefinedType = IfcWallTypeEnum.SHEAR;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.SOLIDWALL:
				PredefinedType = IfcWallTypeEnum.SOLIDWALL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.STANDARD:
				PredefinedType = IfcWallTypeEnum.STANDARD;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.POLYGONAL:
				PredefinedType = IfcWallTypeEnum.POLYGONAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.ELEMENTEDWALL:
				PredefinedType = IfcWallTypeEnum.ELEMENTEDWALL;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.USERDEFINED:
				PredefinedType = IfcWallTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcWallTypeEnum.NOTDEFINED:
				PredefinedType = IfcWallTypeEnum.NOTDEFINED;
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
	public IfcWallTypeEnum? PredefinedType
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
			SetValue(delegate(IfcWallTypeEnum? v)
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

	internal IfcWall(IModel model, int label, bool activated)
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
			_predefinedType = (IfcWallTypeEnum)Enum.Parse(typeof(IfcWallTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWall other)
	{
		return this == other;
	}
}
