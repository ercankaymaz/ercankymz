using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.QuantityResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcObjectDefinition", 22)]
public abstract class IfcObjectDefinition : IfcRoot, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcDefinitionSelect, IEquatable<IfcObjectDefinition>
{
	IEnumerable<IIfcRelAssigns> IIfcObjectDefinition.HasAssignments => base.Model.Instances.Where((IIfcRelAssigns e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelNests> IIfcObjectDefinition.Nests => base.Model.Instances.Where((IIfcRelNests e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelNests> IIfcObjectDefinition.IsNestedBy => base.Model.Instances.Where((IIfcRelNests e) => e.RelatingObject as IfcObjectDefinition == this, "RelatingObject", this);

	IEnumerable<IIfcRelDeclares> IIfcObjectDefinition.HasContext => base.Model.Instances.Where((IIfcRelDeclares e) => e.RelatedDefinitions != null && e.RelatedDefinitions.Contains(this), "RelatedDefinitions", this);

	IEnumerable<IIfcRelAggregates> IIfcObjectDefinition.IsDecomposedBy => base.Model.Instances.Where((IIfcRelAggregates e) => e.RelatingObject as IfcObjectDefinition == this, "RelatingObject", this);

	IEnumerable<IIfcRelAggregates> IIfcObjectDefinition.Decomposes => base.Model.Instances.Where((IIfcRelAggregates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelAssociates> IIfcObjectDefinition.HasAssociations => base.Model.Instances.Where((IIfcRelAssociates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	public IIfcMaterialSelect Material => HasAssociations.OfType<IIfcRelAssociatesMaterial>().FirstOrDefault()?.RelatingMaterial;

	public IIfcValue this[string property]
	{
		get
		{
			if (string.IsNullOrWhiteSpace(property))
			{
				return null;
			}
			List<IfcPropertySetDefinition> list = null;
			IfcObject ifcObject = this as IfcObject;
			if (ifcObject != null)
			{
				list = (from d in ifcObject.IsDefinedBy.SelectMany(GetDefinitions)
					where d != null
					select d).ToList();
			}
			IfcTypeObject ifcTypeObject = this as IfcTypeObject;
			if (ifcTypeObject != null)
			{
				list = ifcTypeObject.HasPropertySets.ToList();
			}
			IfcContext ifcContext = this as IfcContext;
			if (ifcContext != null)
			{
				list = (from d in ifcContext.IsDefinedBy.SelectMany(GetDefinitions)
					where d != null
					select d).ToList();
			}
			if (list == null || !list.Any())
			{
				return null;
			}
			string[] parts = property.Split(new char[1] { '.' });
			if (parts.Length == 2)
			{
				list = list.Where((IfcPropertySetDefinition p) => p.Name == (Xbim.Ifc4x3.MeasureResource.IfcLabel?)(Xbim.Ifc4x3.MeasureResource.IfcLabel)parts[0]).ToList();
				property = parts[1];
			}
			IIfcPropertySingleValue ifcPropertySingleValue = list.OfType<IfcPropertySet>().SelectMany((IfcPropertySet p) => p.HasProperties.OfType<IIfcPropertySingleValue>()).FirstOrDefault((IIfcPropertySingleValue p) => p.Name == (Xbim.Ifc4.MeasureResource.IfcIdentifier)property);
			if (ifcPropertySingleValue != null)
			{
				return ifcPropertySingleValue.NominalValue;
			}
			IIfcPhysicalSimpleQuantity ifcPhysicalSimpleQuantity = list.OfType<IIfcElementQuantity>().SelectMany((IIfcElementQuantity p) => p.Quantities.OfType<IIfcPhysicalSimpleQuantity>()).FirstOrDefault((IIfcPhysicalSimpleQuantity p) => p.Name == (Xbim.Ifc4.MeasureResource.IfcLabel)property);
			if (ifcPhysicalSimpleQuantity == null)
			{
				return null;
			}
			IfcQuantityArea ifcQuantityArea = ifcPhysicalSimpleQuantity as IfcQuantityArea;
			if (ifcQuantityArea != null)
			{
				return ifcQuantityArea.AreaValue;
			}
			IfcQuantityCount ifcQuantityCount = ifcPhysicalSimpleQuantity as IfcQuantityCount;
			if (ifcQuantityCount != null)
			{
				return ifcQuantityCount.CountValue;
			}
			IfcQuantityLength ifcQuantityLength = ifcPhysicalSimpleQuantity as IfcQuantityLength;
			if (ifcQuantityLength != null)
			{
				return ifcQuantityLength.LengthValue;
			}
			IfcQuantityTime ifcQuantityTime = ifcPhysicalSimpleQuantity as IfcQuantityTime;
			if (ifcQuantityTime != null)
			{
				return ifcQuantityTime.TimeValue;
			}
			IfcQuantityVolume ifcQuantityVolume = ifcPhysicalSimpleQuantity as IfcQuantityVolume;
			if (ifcQuantityVolume != null)
			{
				return ifcQuantityVolume.VolumeValue;
			}
			IfcQuantityWeight ifcQuantityWeight = ifcPhysicalSimpleQuantity as IfcQuantityWeight;
			if (ifcQuantityWeight != null)
			{
				return ifcQuantityWeight.WeightValue;
			}
			return null;
		}
	}

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcRelAssigns> HasAssignments => base.Model.Instances.Where((IfcRelAssigns e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 6)]
	public IEnumerable<IfcRelNests> Nests => base.Model.Instances.Where((IfcRelNests e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatingObject")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 7)]
	public IEnumerable<IfcRelNests> IsNestedBy => base.Model.Instances.Where((IfcRelNests e) => Equals(e.RelatingObject), "RelatingObject", this);

	[InverseProperty("RelatedDefinitions")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 8)]
	public IEnumerable<IfcRelDeclares> HasContext => base.Model.Instances.Where((IfcRelDeclares e) => e.RelatedDefinitions != null && e.RelatedDefinitions.Contains(this), "RelatedDefinitions", this);

	[InverseProperty("RelatingObject")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 9)]
	public IEnumerable<IfcRelAggregates> IsDecomposedBy => base.Model.Instances.Where((IfcRelAggregates e) => Equals(e.RelatingObject), "RelatingObject", this);

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 10)]
	public IEnumerable<IfcRelAggregates> Decomposes => base.Model.Instances.Where((IfcRelAggregates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 11)]
	public IEnumerable<IfcRelAssociates> HasAssociations => base.Model.Instances.Where((IfcRelAssociates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	private static IEnumerable<IfcPropertySetDefinition> GetDefinitions(IfcRelDefinesByProperties r)
	{
		if (r.RelatingPropertyDefinition == null)
		{
			return null;
		}
		IfcPropertySetDefinitionSelect relatingPropertyDefinition = r.RelatingPropertyDefinition;
		IfcPropertySetDefinition ifcPropertySetDefinition = relatingPropertyDefinition as IfcPropertySetDefinition;
		if (ifcPropertySetDefinition != null)
		{
			return new IfcPropertySetDefinition[1] { ifcPropertySetDefinition };
		}
		if (relatingPropertyDefinition is IfcPropertySetDefinitionSet ifcPropertySetDefinitionSet)
		{
			return ifcPropertySetDefinitionSet.Value as IEnumerable<IfcPropertySetDefinition>;
		}
		return null;
	}

	internal IfcObjectDefinition(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 3u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcObjectDefinition other)
	{
		return this == other;
	}
}
