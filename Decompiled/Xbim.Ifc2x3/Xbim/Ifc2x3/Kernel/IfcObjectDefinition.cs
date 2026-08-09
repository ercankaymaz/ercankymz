using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcObjectDefinition", 22)]
public abstract class IfcObjectDefinition : IfcRoot, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcObjectDefinition>
{
	IEnumerable<IIfcRelAssigns> IIfcObjectDefinition.HasAssignments => base.Model.Instances.Where((IIfcRelAssigns e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelNests> IIfcObjectDefinition.Nests => base.Model.Instances.Where((IIfcRelNests e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelNests> IIfcObjectDefinition.IsNestedBy => base.Model.Instances.Where((IIfcRelNests e) => e.RelatingObject as IfcObjectDefinition == this, "RelatingObject", this);

	IEnumerable<IIfcRelDeclares> IIfcObjectDefinition.HasContext => base.Model.Instances.Where((IIfcRelDeclares e) => e.RelatedDefinitions != null && e.RelatedDefinitions.Contains(this), "RelatedDefinitions", this);

	IEnumerable<IIfcRelAggregates> IIfcObjectDefinition.IsDecomposedBy => base.Model.Instances.Where((IIfcRelAggregates e) => e.RelatingObject as IfcObjectDefinition == this, "RelatingObject", this);

	IEnumerable<IIfcRelAggregates> IIfcObjectDefinition.Decomposes => base.Model.Instances.Where((IIfcRelAggregates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelAssociates> IIfcObjectDefinition.HasAssociations => base.Model.Instances.Where((IIfcRelAssociates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	public IIfcValue this[string property]
	{
		get
		{
			if (string.IsNullOrWhiteSpace(property))
			{
				return null;
			}
			List<IIfcPropertySetDefinition> list = null;
			if (this is IIfcObject ifcObject)
			{
				list = (from d in ifcObject.IsDefinedBy.SelectMany(GetDefinitions)
					where d != null
					select d).ToList();
			}
			if (this is IIfcTypeObject ifcTypeObject)
			{
				list = ifcTypeObject.HasPropertySets.ToList();
			}
			if (this is IIfcContext ifcContext)
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
				list = list.Where((IIfcPropertySetDefinition p) => p.Name == (IfcLabel?)(IfcLabel)parts[0]).ToList();
				property = parts[1];
			}
			IIfcPropertySingleValue ifcPropertySingleValue = list.OfType<IfcPropertySet>().SelectMany((IfcPropertySet p) => p.HasProperties.OfType<IIfcPropertySingleValue>()).FirstOrDefault((IIfcPropertySingleValue p) => p.Name == (IfcIdentifier)property);
			if (ifcPropertySingleValue != null)
			{
				return ifcPropertySingleValue.NominalValue;
			}
			IIfcPhysicalSimpleQuantity ifcPhysicalSimpleQuantity = list.OfType<IIfcElementQuantity>().SelectMany((IIfcElementQuantity p) => p.Quantities.OfType<IIfcPhysicalSimpleQuantity>()).FirstOrDefault((IIfcPhysicalSimpleQuantity p) => p.Name == (IfcLabel)property);
			if (ifcPhysicalSimpleQuantity == null)
			{
				return null;
			}
			if (ifcPhysicalSimpleQuantity is IIfcQuantityArea ifcQuantityArea)
			{
				return ifcQuantityArea.AreaValue;
			}
			if (ifcPhysicalSimpleQuantity is IIfcQuantityCount ifcQuantityCount)
			{
				return ifcQuantityCount.CountValue;
			}
			if (ifcPhysicalSimpleQuantity is IIfcQuantityLength ifcQuantityLength)
			{
				return ifcQuantityLength.LengthValue;
			}
			if (ifcPhysicalSimpleQuantity is IIfcQuantityTime ifcQuantityTime)
			{
				return ifcQuantityTime.TimeValue;
			}
			if (ifcPhysicalSimpleQuantity is IIfcQuantityVolume ifcQuantityVolume)
			{
				return ifcQuantityVolume.VolumeValue;
			}
			if (ifcPhysicalSimpleQuantity is IIfcQuantityWeight ifcQuantityWeight)
			{
				return ifcQuantityWeight.WeightValue;
			}
			return null;
		}
	}

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 5)]
	public IEnumerable<IfcRelAssigns> HasAssignments => base.Model.Instances.Where((IfcRelAssigns e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatingObject")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 6)]
	public IEnumerable<IfcRelDecomposes> IsDecomposedBy => base.Model.Instances.Where((IfcRelDecomposes e) => Equals(e.RelatingObject), "RelatingObject", this);

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 7)]
	public IEnumerable<IfcRelDecomposes> Decomposes => base.Model.Instances.Where((IfcRelDecomposes e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 8)]
	public IEnumerable<IfcRelAssociates> HasAssociations => base.Model.Instances.Where((IfcRelAssociates e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	public IIfcMaterialSelect Material => HasAssociations.OfType<IIfcRelAssociatesMaterial>().FirstOrDefault()?.RelatingMaterial;

	private static IEnumerable<IIfcPropertySetDefinition> GetDefinitions(IIfcRelDefinesByProperties r)
	{
		if (r.RelatingPropertyDefinition == null)
		{
			return null;
		}
		if (!(r.RelatingPropertyDefinition is IIfcPropertySetDefinition ifcPropertySetDefinition))
		{
			return null;
		}
		return new IIfcPropertySetDefinition[1] { ifcPropertySetDefinition };
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
