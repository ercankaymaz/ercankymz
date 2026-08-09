using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;
using Xbim.Ifc4x3.ProductExtension;

namespace Xbim.Ifc4x3.SharedBldgElements;

[ExpressType("IfcPlate", 351)]
public class IfcPlate : IfcBuiltElement, IIfcPlate, IIfcBuildingElement, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPlate>
{
	private IfcPlateTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcPlate), 9)]
	Xbim.Ifc4.Interfaces.IfcPlateTypeEnum? IIfcPlate.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcPlateTypeEnum.BASE_PLATE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcPlateTypeEnum>(), 
				IfcPlateTypeEnum.COVER_PLATE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcPlateTypeEnum>(), 
				IfcPlateTypeEnum.CURTAIN_PANEL => Xbim.Ifc4.Interfaces.IfcPlateTypeEnum.CURTAIN_PANEL, 
				IfcPlateTypeEnum.FLANGE_PLATE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcPlateTypeEnum>(), 
				IfcPlateTypeEnum.GUSSET_PLATE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcPlateTypeEnum>(), 
				IfcPlateTypeEnum.SHEET => Xbim.Ifc4.Interfaces.IfcPlateTypeEnum.SHEET, 
				IfcPlateTypeEnum.SPLICE_PLATE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcPlateTypeEnum>(), 
				IfcPlateTypeEnum.STIFFENER_PLATE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcPlateTypeEnum>(), 
				IfcPlateTypeEnum.WEB_PLATE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcPlateTypeEnum>(), 
				IfcPlateTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcPlateTypeEnum.USERDEFINED, 
				IfcPlateTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcPlateTypeEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcPlateTypeEnum.CURTAIN_PANEL:
				PredefinedType = IfcPlateTypeEnum.CURTAIN_PANEL;
				break;
			case Xbim.Ifc4.Interfaces.IfcPlateTypeEnum.SHEET:
				PredefinedType = IfcPlateTypeEnum.SHEET;
				break;
			case Xbim.Ifc4.Interfaces.IfcPlateTypeEnum.USERDEFINED:
				PredefinedType = IfcPlateTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcPlateTypeEnum.NOTDEFINED:
				PredefinedType = IfcPlateTypeEnum.NOTDEFINED;
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
	public IfcPlateTypeEnum? PredefinedType
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
			SetValue(delegate(IfcPlateTypeEnum? v)
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

	internal IfcPlate(IModel model, int label, bool activated)
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
			_predefinedType = (IfcPlateTypeEnum)Enum.Parse(typeof(IfcPlateTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPlate other)
	{
		return this == other;
	}
}
