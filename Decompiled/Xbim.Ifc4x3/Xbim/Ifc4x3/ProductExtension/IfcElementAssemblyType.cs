using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.Kernel;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcElementAssemblyType", 1163)]
public class IfcElementAssemblyType : IfcElementType, IIfcElementAssemblyType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElementAssemblyType>
{
	private IfcElementAssemblyTypeEnum _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcElementAssemblyType), 10)]
	Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum IIfcElementAssemblyType.PredefinedType
	{
		get
		{
			return PredefinedType switch
			{
				IfcElementAssemblyTypeEnum.ABUTMENT => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.ACCESSORY_ASSEMBLY => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.ACCESSORY_ASSEMBLY, 
				IfcElementAssemblyTypeEnum.ARCH => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.ARCH, 
				IfcElementAssemblyTypeEnum.BEAM_GRID => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.BEAM_GRID, 
				IfcElementAssemblyTypeEnum.BRACED_FRAME => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.BRACED_FRAME, 
				IfcElementAssemblyTypeEnum.CROSS_BRACING => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.DECK => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.DILATATIONPANEL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.ENTRANCEWORKS => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.GIRDER => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.GIRDER, 
				IfcElementAssemblyTypeEnum.GRID => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.MAST => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.PIER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.PYLON => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.RAIL_MECHANICAL_EQUIPMENT_ASSEMBLY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.REINFORCEMENT_UNIT => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.REINFORCEMENT_UNIT, 
				IfcElementAssemblyTypeEnum.RIGID_FRAME => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.RIGID_FRAME, 
				IfcElementAssemblyTypeEnum.SHELTER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.SIGNALASSEMBLY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.SLAB_FIELD => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.SLAB_FIELD, 
				IfcElementAssemblyTypeEnum.SUMPBUSTER => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.SUPPORTINGASSEMBLY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.SUSPENSIONASSEMBLY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.TRACKPANEL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.TRACTION_SWITCHING_ASSEMBLY => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.TRAFFIC_CALMING_DEVICE => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.TRUSS => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.TRUSS, 
				IfcElementAssemblyTypeEnum.TURNOUTPANEL => this.GetUserDefined<Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum>(), 
				IfcElementAssemblyTypeEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.USERDEFINED, 
				IfcElementAssemblyTypeEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.ACCESSORY_ASSEMBLY:
				PredefinedType = IfcElementAssemblyTypeEnum.ACCESSORY_ASSEMBLY;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.ARCH:
				PredefinedType = IfcElementAssemblyTypeEnum.ARCH;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.BEAM_GRID:
				PredefinedType = IfcElementAssemblyTypeEnum.BEAM_GRID;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.BRACED_FRAME:
				PredefinedType = IfcElementAssemblyTypeEnum.BRACED_FRAME;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.GIRDER:
				PredefinedType = IfcElementAssemblyTypeEnum.GIRDER;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.REINFORCEMENT_UNIT:
				PredefinedType = IfcElementAssemblyTypeEnum.REINFORCEMENT_UNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.RIGID_FRAME:
				PredefinedType = IfcElementAssemblyTypeEnum.RIGID_FRAME;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.SLAB_FIELD:
				PredefinedType = IfcElementAssemblyTypeEnum.SLAB_FIELD;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.TRUSS:
				PredefinedType = IfcElementAssemblyTypeEnum.TRUSS;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.USERDEFINED:
				PredefinedType = IfcElementAssemblyTypeEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum.NOTDEFINED:
				PredefinedType = IfcElementAssemblyTypeEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 19)]
	public IfcElementAssemblyTypeEnum PredefinedType
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
			SetValue(delegate(IfcElementAssemblyTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", 10);
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
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
			foreach (Xbim.Ifc4x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcElementAssemblyType(IModel model, int label, bool activated)
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
		case 8:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 9:
			_predefinedType = (IfcElementAssemblyTypeEnum)Enum.Parse(typeof(IfcElementAssemblyTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElementAssemblyType other)
	{
		return this == other;
	}
}
