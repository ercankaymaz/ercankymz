using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProductExtension;

[ExpressType("IfcSpatialElement", 1273)]
public abstract class IfcSpatialElement : IfcProduct, IIfcSpatialElement, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcSpatialElement>
{
	private IfcLabel? _longName;

	IfcLabel? IIfcSpatialElement.LongName
	{
		get
		{
			return LongName;
		}
		set
		{
			LongName = value;
		}
	}

	IEnumerable<IIfcRelContainedInSpatialStructure> IIfcSpatialElement.ContainsElements => ContainsElements;

	IEnumerable<IIfcRelServicesBuildings> IIfcSpatialElement.ServicedBySystems => ServicedBySystems;

	IEnumerable<IIfcRelReferencedInSpatialStructure> IIfcSpatialElement.ReferencesElements => ReferencesElements;

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public IfcLabel? LongName
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
			SetValue(delegate(IfcLabel? v)
			{
				_longName = v;
			}, _longName, value, "LongName", 8);
		}
	}

	[InverseProperty("RelatingStructure")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 21)]
	public IEnumerable<IfcRelContainedInSpatialStructure> ContainsElements => base.Model.Instances.Where((IfcRelContainedInSpatialStructure e) => Equals(e.RelatingStructure), "RelatingStructure", this);

	[InverseProperty("RelatedBuildings")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 22)]
	public IEnumerable<IfcRelServicesBuildings> ServicedBySystems => base.Model.Instances.Where((IfcRelServicesBuildings e) => e.RelatedBuildings != null && e.RelatedBuildings.Contains(this), "RelatedBuildings", this);

	[InverseProperty("RelatingStructure")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 23)]
	public IEnumerable<IfcRelReferencedInSpatialStructure> ReferencesElements => base.Model.Instances.Where((IfcRelReferencedInSpatialStructure e) => Equals(e.RelatingStructure), "RelatingStructure", this);

	internal IfcSpatialElement(IModel model, int label, bool activated)
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSpatialElement other)
	{
		return this == other;
	}
}
