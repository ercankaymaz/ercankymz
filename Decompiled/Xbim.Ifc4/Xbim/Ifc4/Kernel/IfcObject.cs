using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.ProductExtension;
using Xbim.Ifc4.PropertyResource;
using Xbim.Ifc4.QuantityResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.Kernel;

[ExpressType("IfcObject", 21)]
public abstract class IfcObject : IfcObjectDefinition, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcObject>, IExpressValidatable
{
	public enum IfcObjectClause
	{
		UniquePropertySetNames
	}

	private IfcLabel? _objectType;

	IfcLabel? IIfcObject.ObjectType
	{
		get
		{
			return ObjectType;
		}
		set
		{
			ObjectType = value;
		}
	}

	IEnumerable<IIfcRelDefinesByObject> IIfcObject.IsDeclaredBy => IsDeclaredBy;

	IEnumerable<IIfcRelDefinesByObject> IIfcObject.Declares => Declares;

	IEnumerable<IIfcRelDefinesByType> IIfcObject.IsTypedBy => IsTypedBy;

	IEnumerable<IIfcRelDefinesByProperties> IIfcObject.IsDefinedBy => IsDefinedBy;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public IfcLabel? ObjectType
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
			SetValue(delegate(IfcLabel? v)
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

	public IEnumerable<IIfcElementQuantity> ElementQuantities => from rel in IsDefinedBy
		where rel.RelatingPropertyDefinition is IIfcElementQuantity
		select rel.RelatingPropertyDefinition as IIfcElementQuantity;

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

	public IfcRelDefinesByType AddDefiningType(IfcTypeObject theType)
	{
		List<IfcRelDefinesByType> source = base.Model.Instances.Where((IfcRelDefinesByType r) => r.RelatingType == theType).ToList();
		IfcRelDefinesByType ifcRelDefinesByType = source.FirstOrDefault((IfcRelDefinesByType r) => r.RelatedObjects.Contains(this));
		if (ifcRelDefinesByType != null)
		{
			return ifcRelDefinesByType;
		}
		IfcRelDefinesByType ifcRelDefinesByType2 = source.FirstOrDefault();
		if (ifcRelDefinesByType2 != null)
		{
			ifcRelDefinesByType2.RelatedObjects.Add(this);
			return ifcRelDefinesByType2;
		}
		IfcRelDefinesByType ifcRelDefinesByType3 = base.Model.Instances.New<IfcRelDefinesByType>();
		ifcRelDefinesByType3.RelatedObjects.Add(this);
		ifcRelDefinesByType3.RelatingType = theType;
		return ifcRelDefinesByType3;
	}

	public void AddPropertySet(IfcPropertySet pSet)
	{
		IfcRelDefinesByProperties ifcRelDefinesByProperties = base.Model.Instances.OfType<IfcRelDefinesByProperties>().FirstOrDefault((IfcRelDefinesByProperties r) => pSet.Equals(r.RelatingPropertyDefinition));
		if (ifcRelDefinesByProperties == null)
		{
			ifcRelDefinesByProperties = base.Model.Instances.New<IfcRelDefinesByProperties>();
			ifcRelDefinesByProperties.RelatingPropertyDefinition = pSet;
		}
		ifcRelDefinesByProperties.RelatedObjects.Add(this);
	}

	public IIfcPropertySet GetPropertySet(string pSetName, bool caseSensitive = true)
	{
		return PropertySets.FirstOrDefault(delegate(IIfcPropertySet pset)
		{
			string strA = pSetName;
			IfcLabel? name = pset.Name;
			return string.Compare(strA, name.HasValue ? ((string)name.GetValueOrDefault()) : null, !caseSensitive) == 0;
		});
	}

	public IIfcPropertySingleValue GetPropertySingleValue(string pSetName, string propertyName)
	{
		return GetPropertySet(pSetName)?.HasProperties.OfType<IIfcPropertySingleValue>().FirstOrDefault((IIfcPropertySingleValue p) => p.Name == (IfcIdentifier)propertyName);
	}

	public TValueType GetPropertySingleValue<TValueType>(string pSetName, string propertyName) where TValueType : IIfcValue
	{
		IIfcPropertySet propertySet = GetPropertySet(pSetName);
		if (propertySet == null)
		{
			return default(TValueType);
		}
		IIfcPropertySingleValue ifcPropertySingleValue = propertySet.HasProperties.OfType<IIfcPropertySingleValue>().FirstOrDefault((IIfcPropertySingleValue p) => p.Name == (IfcIdentifier)propertyName);
		if (ifcPropertySingleValue != null && ifcPropertySingleValue.NominalValue is TValueType)
		{
			return (TValueType)ifcPropertySingleValue.NominalValue;
		}
		return default(TValueType);
	}

	public IIfcValue GetPropertySingleNominalValue(string pSetName, string propertyName)
	{
		return GetPropertySingleValue(pSetName, propertyName)?.NominalValue;
	}

	public IIfcPropertySingleValue SetPropertySingleValue(string pSetName, string propertyName, Type type)
	{
		if (typeof(IfcValue).GetTypeInfo().IsAssignableFrom(type))
		{
			IfcValue ifcValue = ((!typeof(IfcPositiveLengthMeasure).GetTypeInfo().IsAssignableFrom(type)) ? (Activator.CreateInstance(type) as IfcValue) : (Activator.CreateInstance(type, 1.0) as IfcValue));
			if (ifcValue != null)
			{
				return SetPropertySingleValue(pSetName, propertyName, ifcValue);
			}
			throw new Exception("Type '" + type.Name + "' can't be initialized.");
		}
		throw new ArgumentException("Type '" + type.Name + "' is not compatible with IfcValue type.");
	}

	public IIfcPropertySingleValue SetPropertySingleValue(string pSetName, string propertyName, IfcValue value)
	{
		IIfcPropertySet ifcPropertySet = GetPropertySet(pSetName);
		if (ifcPropertySet == null)
		{
			ifcPropertySet = base.Model.Instances.New<IfcPropertySet>();
			ifcPropertySet.Name = pSetName;
			IfcRelDefinesByProperties ifcRelDefinesByProperties = base.Model.Instances.New<IfcRelDefinesByProperties>();
			ifcRelDefinesByProperties.RelatingPropertyDefinition = ifcPropertySet;
			ifcRelDefinesByProperties.RelatedObjects.Add(this);
		}
		IIfcPropertySingleValue ifcPropertySingleValue = GetPropertySingleValue(pSetName, propertyName);
		if (ifcPropertySingleValue != null)
		{
			ifcPropertySingleValue.NominalValue = value;
		}
		else
		{
			ifcPropertySingleValue = base.Model.Instances.New(delegate(IfcPropertySingleValue psv)
			{
				psv.Name = propertyName;
				psv.NominalValue = value;
			});
			ifcPropertySet.HasProperties.Add(ifcPropertySingleValue);
		}
		return ifcPropertySingleValue;
	}

	public IEnumerable<IIfcElement> GetExternalElements(IModel model)
	{
		return (from rsb in model.Instances.OfType<IIfcRelSpaceBoundary>()
			where rsb.InternalOrExternalBoundary == IfcInternalOrExternalEnum.EXTERNAL && rsb.PhysicalOrVirtualBoundary == IfcPhysicalOrVirtualEnum.PHYSICAL && rsb.RelatedBuildingElement != null
			select rsb.RelatedBuildingElement).Distinct();
	}

	public IIfcElementQuantity GetElementQuantity(string pSetName, bool caseSensitive = true)
	{
		return IsDefinedBy.SelectMany((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).OfType<IfcElementQuantity>().FirstOrDefault(delegate(IfcElementQuantity qset)
		{
			string strA = pSetName;
			IfcLabel? name = qset.Name;
			return string.Compare(strA, name.HasValue ? ((string)name.GetValueOrDefault()) : null, !caseSensitive) == 0;
		});
	}

	public TQType GetQuantity<TQType>(string pSetName, string qName) where TQType : IIfcPhysicalQuantity
	{
		IIfcPropertySetDefinition ifcPropertySetDefinition = IsDefinedBy.SelectMany((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).FirstOrDefault((IIfcPropertySetDefinition r) => r is IfcElementQuantity && r.Name == (IfcLabel?)(IfcLabel)pSetName);
		if (ifcPropertySetDefinition == null)
		{
			return default(TQType);
		}
		IfcElementQuantity ifcElementQuantity = ifcPropertySetDefinition as IfcElementQuantity;
		if (!(ifcElementQuantity == null))
		{
			return ifcElementQuantity.Quantities.OfType<TQType>().FirstOrDefault((TQType q) => q.Name == (IfcLabel)qName);
		}
		return default(TQType);
	}

	public TQType GetQuantity<TQType>(string qName) where TQType : IIfcPhysicalQuantity
	{
		return IsDefinedBy.SelectMany((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).OfType<IIfcElementQuantity>().SelectMany((IIfcElementQuantity qset) => qset.Quantities)
			.OfType<TQType>()
			.FirstOrDefault((TQType q) => q.Name == (IfcLabel)qName);
	}

	public IIfcElementQuantity AddQuantity(string propertySetName, IIfcPhysicalQuantity quantity, string methodOfMeasurement)
	{
		IIfcElementQuantity ifcElementQuantity = GetElementQuantity(propertySetName);
		if (ifcElementQuantity == null)
		{
			ifcElementQuantity = base.Model.Instances.New<IfcElementQuantity>();
			ifcElementQuantity.Name = propertySetName;
			IfcRelDefinesByProperties ifcRelDefinesByProperties = base.Model.Instances.New<IfcRelDefinesByProperties>();
			ifcRelDefinesByProperties.RelatingPropertyDefinition = ifcElementQuantity;
			ifcRelDefinesByProperties.RelatedObjects.Add(this);
		}
		ifcElementQuantity.Quantities.Add(quantity);
		if (!string.IsNullOrEmpty(methodOfMeasurement))
		{
			ifcElementQuantity.MethodOfMeasurement = methodOfMeasurement;
		}
		return ifcElementQuantity;
	}

	public IIfcElementQuantity AddQuantity(string propertySetName, IIfcPhysicalQuantity quantity)
	{
		return AddQuantity(propertySetName, quantity, null);
	}

	public IIfcPhysicalSimpleQuantity GetElementPhysicalSimpleQuantity(string pSetName, string qualityName)
	{
		return GetElementQuantity(pSetName)?.Quantities.FirstOrDefault((IIfcPhysicalSimpleQuantity sq) => sq.Name == (IfcLabel)qualityName);
	}

	public void SetElementPhysicalSimpleQuantity(string qSetName, string qualityName, double value, XbimQuantityTypeEnum quantityType, IIfcNamedUnit unit)
	{
		IIfcElementQuantity ifcElementQuantity = GetElementQuantity(qSetName);
		if (ifcElementQuantity == null)
		{
			ifcElementQuantity = base.Model.Instances.New<IfcElementQuantity>();
			ifcElementQuantity.Name = qSetName;
			IfcRelDefinesByProperties ifcRelDefinesByProperties = base.Model.Instances.New<IfcRelDefinesByProperties>();
			ifcRelDefinesByProperties.RelatingPropertyDefinition = ifcElementQuantity;
			ifcRelDefinesByProperties.RelatedObjects.Add(this);
		}
		IIfcPhysicalSimpleQuantity elementPhysicalSimpleQuantity = GetElementPhysicalSimpleQuantity(qSetName, qualityName);
		if (elementPhysicalSimpleQuantity != null)
		{
			GetElementQuantity(qSetName).Quantities.Remove(elementPhysicalSimpleQuantity);
			base.Model.Delete(elementPhysicalSimpleQuantity);
		}
		switch (quantityType)
		{
		default:
			return;
		case XbimQuantityTypeEnum.Area:
			elementPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityArea sq)
			{
				sq.AreaValue = value;
			});
			break;
		case XbimQuantityTypeEnum.Count:
			elementPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityCount sq)
			{
				sq.CountValue = value;
			});
			break;
		case XbimQuantityTypeEnum.Length:
			elementPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityLength sq)
			{
				sq.LengthValue = value;
			});
			break;
		case XbimQuantityTypeEnum.Time:
			elementPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityTime sq)
			{
				sq.TimeValue = value;
			});
			break;
		case XbimQuantityTypeEnum.Volume:
			elementPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityVolume sq)
			{
				sq.VolumeValue = value;
			});
			break;
		case XbimQuantityTypeEnum.Weight:
			elementPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityWeight sq)
			{
				sq.WeightValue = value;
			});
			break;
		}
		elementPhysicalSimpleQuantity.Unit = unit;
		elementPhysicalSimpleQuantity.Name = qualityName;
		ifcElementQuantity.Quantities.Add(elementPhysicalSimpleQuantity);
	}

	public void RemovePropertySingleValue(string pSetName, string propertyName)
	{
		IIfcPropertySet propertySet = GetPropertySet(pSetName);
		if (propertySet != null)
		{
			IIfcPropertySingleValue ifcPropertySingleValue = propertySet.HasProperties.FirstOrDefault((IIfcPropertySingleValue p) => p.Name == (IfcIdentifier)propertyName);
			if (ifcPropertySingleValue != null)
			{
				propertySet.HasProperties.Remove(ifcPropertySingleValue);
			}
		}
	}

	public void RemoveElementPhysicalSimpleQuantity(string pSetName, string qualityName)
	{
		IIfcElementQuantity elementQuantity = GetElementQuantity(pSetName);
		if (elementQuantity != null)
		{
			IIfcPhysicalSimpleQuantity ifcPhysicalSimpleQuantity = elementQuantity.Quantities.FirstOrDefault((IIfcPhysicalSimpleQuantity sq) => sq.Name == (IfcLabel)qualityName);
			if (ifcPhysicalSimpleQuantity != null)
			{
				elementQuantity.Quantities.Remove(ifcPhysicalSimpleQuantity);
			}
		}
	}

	public bool ValidateClause(IfcObjectClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcObjectClause.UniquePropertySetNames)
			{
				result = Functions.SIZEOF(IsDefinedBy) == 0 || Functions.IfcUniqueDefinitionNames(IsDefinedBy);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcObject>()?.LogError($"Exception thrown evaluating where-clause 'IfcObject.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcObjectClause.UniquePropertySetNames))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcObject.UniquePropertySetNames",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
