using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.ProductExtension;

[ExpressType("IfcSpatialStructureElement", 170)]
public abstract class IfcSpatialStructureElement : Xbim.Ifc2x3.Kernel.IfcProduct, IIfcSpatialStructureElement, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcSpatialStructureElement>, IExpressValidatable
{
	public enum IfcSpatialStructureElementClause
	{
		WR41
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _longName;

	private IfcElementCompositionEnum _compositionType;

	[CrossSchemaAttribute(typeof(IIfcSpatialStructureElement), 9)]
	Xbim.Ifc4.Interfaces.IfcElementCompositionEnum? IIfcSpatialStructureElement.CompositionType
	{
		get
		{
			return CompositionType switch
			{
				IfcElementCompositionEnum.COMPLEX => Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.COMPLEX, 
				IfcElementCompositionEnum.ELEMENT => Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.ELEMENT, 
				IfcElementCompositionEnum.PARTIAL => Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.PARTIAL, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.COMPLEX:
				CompositionType = IfcElementCompositionEnum.COMPLEX;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.ELEMENT:
				CompositionType = IfcElementCompositionEnum.ELEMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcElementCompositionEnum.PARTIAL:
				CompositionType = IfcElementCompositionEnum.PARTIAL;
				break;
			case null:
				CompositionType = IfcElementCompositionEnum.ELEMENT;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSpatialStructureElement), 8)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcSpatialElement.LongName
	{
		get
		{
			if (!LongName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(LongName.Value);
		}
		set
		{
			LongName = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcSpatialElement.ContainsElements => base.Model.Instances.Where((IIfcRelContainedInSpatialStructure e) => e.RelatingStructure as IfcSpatialStructureElement == this, "RelatingStructure", this);

	IEnumerable<IIfcRelServicesBuildings> IIfcSpatialElement.ServicedBySystems => base.Model.Instances.Where((IIfcRelServicesBuildings e) => e.RelatedBuildings != null && e.RelatedBuildings.Contains(this), "RelatedBuildings", this);

	IEnumerable<IIfcRelReferencedInSpatialStructure> IIfcSpatialElement.ReferencesElements => base.Model.Instances.Where((IIfcRelReferencedInSpatialStructure e) => e.RelatingStructure as IfcSpatialStructureElement == this, "RelatingStructure", this);

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? LongName
	{
		get
		{
			if (_activated)
			{
				return _longName;
			}
			Activate();
			return _longName;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 15)]
	public IfcElementCompositionEnum CompositionType
	{
		get
		{
			if (_activated)
			{
				return _compositionType;
			}
			Activate();
			return _compositionType;
		}
		set
		{
			SetValue(delegate(IfcElementCompositionEnum v)
			{
				_compositionType = v;
			}, _compositionType, value, "CompositionType", 9);
		}
	}

	[InverseProperty("RelatingStructure")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 16)]
	public IEnumerable<IfcRelReferencedInSpatialStructure> ReferencesElements => base.Model.Instances.Where((IfcRelReferencedInSpatialStructure e) => Equals(e.RelatingStructure), "RelatingStructure", this);

	[InverseProperty("RelatedBuildings")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 17)]
	public IEnumerable<IfcRelServicesBuildings> ServicedBySystems => base.Model.Instances.Where((IfcRelServicesBuildings e) => e.RelatedBuildings != null && e.RelatedBuildings.Contains(this), "RelatedBuildings", this);

	[InverseProperty("RelatingStructure")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 18)]
	public IEnumerable<IfcRelContainedInSpatialStructure> ContainsElements => base.Model.Instances.Where((IfcRelContainedInSpatialStructure e) => Equals(e.RelatingStructure), "RelatingStructure", this);

	internal IfcSpatialStructureElement(IModel model, int label, bool activated)
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
			_longName = value.StringVal;
			break;
		case 8:
			_compositionType = (IfcElementCompositionEnum)Enum.Parse(typeof(IfcElementCompositionEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpatialStructureElement other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcSpatialStructureElementClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSpatialStructureElementClause.WR41)
			{
				result = Functions.HIINDEX(base.Decomposes) == 1 && Functions.TYPEOF(base.Decomposes.ItemAt(0L)).Contains("IFC2X3.IFCRELAGGREGATES") && (Functions.TYPEOF(base.Decomposes.ItemAt(0L).RelatingObject).Contains("IFC2X3.IFCPROJECT") || Functions.TYPEOF(base.Decomposes.ItemAt(0L).RelatingObject).Contains("IFC2X3.IFCSPATIALSTRUCTUREELEMENT"));
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSpatialStructureElement>()?.LogError($"Exception thrown evaluating where-clause 'IfcSpatialStructureElement.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcSpatialStructureElementClause.WR41))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSpatialStructureElement.WR41",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
