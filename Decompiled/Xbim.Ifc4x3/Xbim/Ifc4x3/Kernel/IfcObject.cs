using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.Kernel;

[ExpressType("IfcObject", 21)]
public abstract class IfcObject : IfcObjectDefinition, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcObject>
{
	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _objectType;

	[CrossSchemaAttribute(typeof(IIfcObject), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcObject.ObjectType
	{
		get
		{
			if (!ObjectType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(ObjectType.Value);
		}
		set
		{
			ObjectType = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcRelDefinesByObject> IIfcObject.IsDeclaredBy => base.Model.Instances.Where((IIfcRelDefinesByObject e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelDefinesByObject> IIfcObject.Declares => base.Model.Instances.Where((IIfcRelDefinesByObject e) => e.RelatingObject as IfcObject == this, "RelatingObject", this);

	IEnumerable<IIfcRelDefinesByType> IIfcObject.IsTypedBy => base.Model.Instances.Where((IIfcRelDefinesByType e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelDefinesByProperties> IIfcObject.IsDefinedBy => base.Model.Instances.Where((IIfcRelDefinesByProperties e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? ObjectType
	{
		get
		{
			if (_activated)
			{
				return _objectType;
			}
			Activate();
			return _objectType;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_objectType = v;
			}, _objectType, value, "ObjectType", 5);
		}
	}

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 13)]
	public IEnumerable<IfcRelDefinesByObject> IsDeclaredBy => base.Model.Instances.Where((IfcRelDefinesByObject e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatingObject")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 14)]
	public IEnumerable<IfcRelDefinesByObject> Declares => base.Model.Instances.Where((IfcRelDefinesByObject e) => Equals(e.RelatingObject), "RelatingObject", this);

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { 1 }, 15)]
	public IEnumerable<IfcRelDefinesByType> IsTypedBy => base.Model.Instances.Where((IfcRelDefinesByType e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 16)]
	public IEnumerable<IfcRelDefinesByProperties> IsDefinedBy => base.Model.Instances.Where((IfcRelDefinesByProperties e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	public IEnumerable<IIfcPropertySet> PropertySets => IsDefinedBy.SelectMany((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).OfType<IIfcPropertySet>();

	public IEnumerable<IIfcElementQuantity> ElementQuantities => IsDefinedBy.SelectMany((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).OfType<IIfcElementQuantity>();

	public IEnumerable<IIfcPhysicalSimpleQuantity> PhysicalSimpleQuantities => ElementQuantities.SelectMany((IIfcElementQuantity eq) => eq.Quantities).OfType<IIfcPhysicalSimpleQuantity>();

	internal IfcObject(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_objectType = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcObject other)
	{
		return this == other;
	}
}
