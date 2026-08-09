using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.StructuralAnalysisDomain;

namespace Xbim.Ifc4x3.ProductExtension;

[ExpressType("IfcElementAssembly", 18)]
public class IfcElementAssembly : IfcElement, IIfcElementAssembly, IIfcElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IfcStructuralActivityAssignmentSelect, IIfcStructuralActivityAssignmentSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcElementAssembly>
{
	private IfcAssemblyPlaceEnum? _assemblyPlace;

	private IfcElementAssemblyTypeEnum? _predefinedType;

	[CrossSchemaAttribute(typeof(IIfcElementAssembly), 9)]
	Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum? IIfcElementAssembly.AssemblyPlace
	{
		get
		{
			return AssemblyPlace switch
			{
				IfcAssemblyPlaceEnum.FACTORY => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.FACTORY, 
				IfcAssemblyPlaceEnum.SITE => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.SITE, 
				IfcAssemblyPlaceEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.NOTDEFINED, 
				null => null, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.SITE:
				AssemblyPlace = IfcAssemblyPlaceEnum.SITE;
				break;
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.FACTORY:
				AssemblyPlace = IfcAssemblyPlaceEnum.FACTORY;
				break;
			case Xbim.Ifc4.Interfaces.IfcAssemblyPlaceEnum.NOTDEFINED:
				AssemblyPlace = IfcAssemblyPlaceEnum.NOTDEFINED;
				break;
			case null:
				AssemblyPlace = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcElementAssembly), 10)]
	Xbim.Ifc4.Interfaces.IfcElementAssemblyTypeEnum? IIfcElementAssembly.PredefinedType
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
				null => null, 
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
			case null:
				PredefinedType = null;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 35)]
	public IfcAssemblyPlaceEnum? AssemblyPlace
	{
		get
		{
			if (_activated)
			{
				return _assemblyPlace;
			}
			Activate();
			return _assemblyPlace;
		}
		set
		{
			SetValue(delegate(IfcAssemblyPlaceEnum? v)
			{
				_assemblyPlace = v;
			}, _assemblyPlace, value, "AssemblyPlace", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 36)]
	public IfcElementAssemblyTypeEnum? PredefinedType
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
			SetValue(delegate(IfcElementAssemblyTypeEnum? v)
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

	internal IfcElementAssembly(IModel model, int label, bool activated)
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
			_assemblyPlace = (IfcAssemblyPlaceEnum)Enum.Parse(typeof(IfcAssemblyPlaceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_predefinedType = (IfcElementAssemblyTypeEnum)Enum.Parse(typeof(IfcElementAssemblyTypeEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcElementAssembly other)
	{
		return this == other;
	}
}
