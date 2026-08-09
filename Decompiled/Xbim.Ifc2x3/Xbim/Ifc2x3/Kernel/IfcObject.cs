using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcObject", 21)]
public abstract class IfcObject : IfcObjectDefinition, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IEquatable<IfcObject>, IExpressValidatable
{
	public enum IfcObjectClause
	{
		WR1
	}

	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _objectType;

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
			ObjectType = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	IEnumerable<IIfcRelDefinesByObject> IIfcObject.IsDeclaredBy => base.Model.Instances.Where((IIfcRelDefinesByObject e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelDefinesByObject> IIfcObject.Declares => base.Model.Instances.Where((IIfcRelDefinesByObject e) => e.RelatingObject as IfcObject == this, "RelatingObject", this);

	IEnumerable<IIfcRelDefinesByType> IIfcObject.IsTypedBy => base.Model.Instances.Where((IIfcRelDefinesByType e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	IEnumerable<IIfcRelDefinesByProperties> IIfcObject.IsDefinedBy => base.Model.Instances.Where((IIfcRelDefinesByProperties e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? ObjectType
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_objectType = v;
			}, _objectType, value, "ObjectType", 5);
		}
	}

	[InverseProperty("RelatedObjects")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 10)]
	public IEnumerable<IfcRelDefines> IsDefinedBy => base.Model.Instances.Where((IfcRelDefines e) => e.RelatedObjects != null && e.RelatedObjects.Contains(this), "RelatedObjects", this);

	public IEnumerable<IfcRelDefinesByProperties> IsDefinedByProperties => base.Model.Instances.Where((IfcRelDefinesByProperties r) => r.RelatedObjects.Contains(this));

	public IfcTypeObject IsTypedBy
	{
		get
		{
			IfcRelDefinesByType ifcRelDefinesByType = base.Model.Instances.OfType<IfcRelDefinesByType>().FirstOrDefault((IfcRelDefinesByType rd) => rd.RelatedObjects.Contains(this));
			if (!(ifcRelDefinesByType != null))
			{
				return null;
			}
			return ifcRelDefinesByType.RelatingType;
		}
		set
		{
			foreach (IfcRelDefinesByType item in base.Model.Instances.Where((IfcRelDefinesByType rd) => rd.RelatedObjects.Contains(this)))
			{
				item.RelatedObjects.Remove(this);
			}
			IfcRelDefinesByType ifcRelDefinesByType = base.Model.Instances.OfType<IfcRelDefinesByType>().FirstOrDefault((IfcRelDefinesByType rd) => rd.RelatingType == value);
			if (ifcRelDefinesByType == null)
			{
				IfcRelDefinesByType ifcRelDefinesByType2 = base.Model.Instances.New<IfcRelDefinesByType>();
				ifcRelDefinesByType2.RelatingType = value;
				ifcRelDefinesByType2.RelatedObjects.Add(this);
			}
			else
			{
				ifcRelDefinesByType.RelatedObjects.Add(this);
			}
		}
	}

	public IEnumerable<IfcPropertySet> PropertySets => IsDefinedByProperties.Select((IfcRelDefinesByProperties rel) => rel.RelatingPropertyDefinition).OfType<IfcPropertySet>();

	public IEnumerable<IIfcElementQuantity> ElementQuantities => from rel in IsDefinedByProperties
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
		IfcRelDefinesByProperties ifcRelDefinesByProperties = base.Model.Instances.OfType<IfcRelDefinesByProperties>().FirstOrDefault((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition == pSet);
		if (ifcRelDefinesByProperties == null)
		{
			ifcRelDefinesByProperties = base.Model.Instances.New<IfcRelDefinesByProperties>();
			ifcRelDefinesByProperties.RelatingPropertyDefinition = pSet;
		}
		ifcRelDefinesByProperties.RelatedObjects.Add(this);
	}

	public IfcPropertySet GetPropertySet(string pSetName, bool caseSensitive = true)
	{
		return PropertySets.FirstOrDefault(delegate(IfcPropertySet ps)
		{
			Xbim.Ifc2x3.MeasureResource.IfcLabel? name = ps.Name;
			return string.Compare(name.HasValue ? ((string)name.GetValueOrDefault()) : null, pSetName, !caseSensitive) == 0;
		});
	}

	public IfcPropertySingleValue GetPropertySingleValue(string pSetName, string propertyName)
	{
		IfcPropertySet propertySet = GetPropertySet(pSetName);
		if (!(propertySet != null))
		{
			return null;
		}
		return propertySet.HasProperties.OfType<IfcPropertySingleValue>().FirstOrDefault((IfcPropertySingleValue p) => p.Name == (Xbim.Ifc2x3.MeasureResource.IfcIdentifier)propertyName);
	}

	public TValueType GetPropertySingleValue<TValueType>(string pSetName, string propertyName) where TValueType : IIfcValue
	{
		IfcPropertySet propertySet = GetPropertySet(pSetName);
		if (propertySet == null)
		{
			return default(TValueType);
		}
		IfcPropertySingleValue ifcPropertySingleValue = propertySet.HasProperties.OfType<IfcPropertySingleValue>().FirstOrDefault((IfcPropertySingleValue p) => p.Name == (Xbim.Ifc2x3.MeasureResource.IfcIdentifier)propertyName);
		if (ifcPropertySingleValue != null && ifcPropertySingleValue.NominalValue is TValueType)
		{
			return (TValueType)ifcPropertySingleValue.NominalValue;
		}
		return default(TValueType);
	}

	public Xbim.Ifc2x3.MeasureResource.IfcValue GetPropertySingleNominalValue(string pSetName, string propertyName)
	{
		IfcPropertySingleValue propertySingleValue = GetPropertySingleValue(pSetName, propertyName);
		if (!(propertySingleValue == null))
		{
			return propertySingleValue.NominalValue;
		}
		return null;
	}

	public IfcPropertySingleValue SetPropertySingleValue(string pSetName, string propertyName, Type type)
	{
		if (typeof(Xbim.Ifc2x3.MeasureResource.IfcValue).GetTypeInfo().IsAssignableFrom(type))
		{
			Xbim.Ifc2x3.MeasureResource.IfcValue ifcValue = ((!typeof(Xbim.Ifc2x3.MeasureResource.IfcPositiveLengthMeasure).GetTypeInfo().IsAssignableFrom(type)) ? (Activator.CreateInstance(type) as Xbim.Ifc2x3.MeasureResource.IfcValue) : (Activator.CreateInstance(type, 1.0) as Xbim.Ifc2x3.MeasureResource.IfcValue));
			if (ifcValue != null)
			{
				return SetPropertySingleValue(pSetName, propertyName, ifcValue);
			}
			throw new Exception("Type '" + type.Name + "' can't be initialized.");
		}
		throw new ArgumentException("Type '" + type.Name + "' is not compatible with IfcValue type.");
	}

	public IfcPropertySingleValue SetPropertySingleValue(string pSetName, string propertyName, Xbim.Ifc2x3.MeasureResource.IfcValue value)
	{
		IfcPropertySet ifcPropertySet = GetPropertySet(pSetName);
		if (ifcPropertySet == null)
		{
			ifcPropertySet = base.Model.Instances.New<IfcPropertySet>();
			ifcPropertySet.Name = pSetName;
			IfcRelDefinesByProperties ifcRelDefinesByProperties = base.Model.Instances.New<IfcRelDefinesByProperties>();
			ifcRelDefinesByProperties.RelatingPropertyDefinition = ifcPropertySet;
			ifcRelDefinesByProperties.RelatedObjects.Add(this);
		}
		IfcPropertySingleValue ifcPropertySingleValue = GetPropertySingleValue(pSetName, propertyName);
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

	public static IEnumerable<IIfcElement> GetExternalElements(IModel model)
	{
		return (from rsb in model.Instances.OfType<IIfcRelSpaceBoundary>()
			where rsb.InternalOrExternalBoundary == Xbim.Ifc4.Interfaces.IfcInternalOrExternalEnum.EXTERNAL && rsb.PhysicalOrVirtualBoundary == Xbim.Ifc4.Interfaces.IfcPhysicalOrVirtualEnum.PHYSICAL && rsb.RelatedBuildingElement != null
			select rsb.RelatedBuildingElement).Distinct();
	}

	public IIfcElementQuantity GetElementQuantity(string pSetName, bool caseSensitive = true)
	{
		IfcRelDefinesByProperties ifcRelDefinesByProperties = (caseSensitive ? IsDefinedByProperties.FirstOrDefault((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.Name == (Xbim.Ifc2x3.MeasureResource.IfcLabel?)(Xbim.Ifc2x3.MeasureResource.IfcLabel)pSetName && r.RelatingPropertyDefinition is IIfcElementQuantity) : IsDefinedByProperties.FirstOrDefault((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.Name.ToString().ToLower() == pSetName.ToLower() && r.RelatingPropertyDefinition is IIfcElementQuantity));
		if (ifcRelDefinesByProperties != null)
		{
			return ifcRelDefinesByProperties.RelatingPropertyDefinition as IIfcElementQuantity;
		}
		return null;
	}

	public TQType GetQuantity<TQType>(string pSetName, string qName) where TQType : IIfcPhysicalQuantity
	{
		IfcRelDefinesByProperties ifcRelDefinesByProperties = IsDefinedByProperties.FirstOrDefault((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.Name == (Xbim.Ifc2x3.MeasureResource.IfcLabel?)(Xbim.Ifc2x3.MeasureResource.IfcLabel)pSetName && r.RelatingPropertyDefinition is IfcElementQuantity);
		if (ifcRelDefinesByProperties == null)
		{
			return default(TQType);
		}
		if (ifcRelDefinesByProperties.RelatingPropertyDefinition is IIfcElementQuantity ifcElementQuantity)
		{
			return ifcElementQuantity.Quantities.OfType<TQType>().FirstOrDefault((TQType q) => q.Name == (Xbim.Ifc4.MeasureResource.IfcLabel)qName);
		}
		return default(TQType);
	}

	public TQType GetQuantity<TQType>(string qName) where TQType : IIfcPhysicalQuantity
	{
		IfcRelDefinesByProperties ifcRelDefinesByProperties = IsDefinedByProperties.FirstOrDefault((IfcRelDefinesByProperties r) => r.RelatingPropertyDefinition is IIfcElementQuantity);
		if (ifcRelDefinesByProperties == null)
		{
			return default(TQType);
		}
		if (!(ifcRelDefinesByProperties.RelatingPropertyDefinition is IIfcElementQuantity ifcElementQuantity))
		{
			return default(TQType);
		}
		return ifcElementQuantity.Quantities.OfType<TQType>().FirstOrDefault((TQType q) => q.Name == (Xbim.Ifc4.MeasureResource.IfcLabel)qName);
	}

	public IfcElementQuantity AddQuantity(string propertySetName, IfcPhysicalQuantity quantity, string methodOfMeasurement)
	{
		IfcElementQuantity ifcElementQuantity = GetElementQuantity(propertySetName) as IfcElementQuantity;
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

	public IfcElementQuantity AddQuantity(string propertySetName, IfcPhysicalQuantity quantity)
	{
		return AddQuantity(propertySetName, quantity, null);
	}

	public IIfcPhysicalSimpleQuantity GetElementPhysicalSimpleQuantity(string pSetName, string qualityName)
	{
		IfcElementQuantity ifcElementQuantity = GetElementQuantity(pSetName) as IfcElementQuantity;
		if (ifcElementQuantity != null)
		{
			return ifcElementQuantity.Quantities.FirstOrDefault((IfcPhysicalSimpleQuantity sq) => sq.Name == (Xbim.Ifc2x3.MeasureResource.IfcLabel)qualityName);
		}
		return null;
	}

	public void SetElementPhysicalSimpleQuantity(string qSetName, string qualityName, double value, XbimQuantityTypeEnum quantityType, Xbim.Ifc2x3.MeasureResource.IfcNamedUnit unit)
	{
		IfcElementQuantity ifcElementQuantity = GetElementQuantity(qSetName) as IfcElementQuantity;
		if (ifcElementQuantity == null)
		{
			ifcElementQuantity = base.Model.Instances.New<IfcElementQuantity>();
			ifcElementQuantity.Name = qSetName;
			IfcRelDefinesByProperties ifcRelDefinesByProperties = base.Model.Instances.New<IfcRelDefinesByProperties>();
			ifcRelDefinesByProperties.RelatingPropertyDefinition = ifcElementQuantity;
			ifcRelDefinesByProperties.RelatedObjects.Add(this);
		}
		IfcPhysicalSimpleQuantity ifcPhysicalSimpleQuantity = GetElementPhysicalSimpleQuantity(qSetName, qualityName) as IfcPhysicalSimpleQuantity;
		if (ifcPhysicalSimpleQuantity == null)
		{
			switch (quantityType)
			{
			default:
				return;
			case XbimQuantityTypeEnum.Area:
				ifcPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityArea sq)
				{
					sq.AreaValue = value;
				});
				break;
			case XbimQuantityTypeEnum.Count:
				ifcPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityCount sq)
				{
					sq.CountValue = value;
				});
				break;
			case XbimQuantityTypeEnum.Length:
				ifcPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityLength sq)
				{
					sq.LengthValue = value;
				});
				break;
			case XbimQuantityTypeEnum.Time:
				ifcPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityTime sq)
				{
					sq.TimeValue = value;
				});
				break;
			case XbimQuantityTypeEnum.Volume:
				ifcPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityVolume sq)
				{
					sq.VolumeValue = value;
				});
				break;
			case XbimQuantityTypeEnum.Weight:
				ifcPhysicalSimpleQuantity = base.Model.Instances.New(delegate(IfcQuantityWeight sq)
				{
					sq.WeightValue = value;
				});
				break;
			}
		}
		else
		{
			switch (quantityType)
			{
			default:
				return;
			case XbimQuantityTypeEnum.Area:
				((IfcQuantityArea)ifcPhysicalSimpleQuantity).AreaValue = new Xbim.Ifc2x3.MeasureResource.IfcAreaMeasure(value);
				break;
			case XbimQuantityTypeEnum.Count:
				((IfcQuantityCount)ifcPhysicalSimpleQuantity).CountValue = new Xbim.Ifc2x3.MeasureResource.IfcCountMeasure(value);
				break;
			case XbimQuantityTypeEnum.Length:
				((IfcQuantityLength)ifcPhysicalSimpleQuantity).LengthValue = new Xbim.Ifc2x3.MeasureResource.IfcLengthMeasure(value);
				break;
			case XbimQuantityTypeEnum.Time:
				((IfcQuantityTime)ifcPhysicalSimpleQuantity).TimeValue = new Xbim.Ifc2x3.MeasureResource.IfcTimeMeasure(value);
				break;
			case XbimQuantityTypeEnum.Volume:
				((IfcQuantityVolume)ifcPhysicalSimpleQuantity).VolumeValue = new Xbim.Ifc2x3.MeasureResource.IfcVolumeMeasure(value);
				break;
			case XbimQuantityTypeEnum.Weight:
				((IfcQuantityWeight)ifcPhysicalSimpleQuantity).WeightValue = new Xbim.Ifc2x3.MeasureResource.IfcMassMeasure(value);
				break;
			}
		}
		ifcPhysicalSimpleQuantity.Unit = unit;
		ifcPhysicalSimpleQuantity.Name = qualityName;
		ifcElementQuantity.Quantities.Add(ifcPhysicalSimpleQuantity);
	}

	public bool ValidateClause(IfcObjectClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcObjectClause.WR1)
			{
				result = Functions.SIZEOF(IsDefinedBy.Where((IfcRelDefines temp) => Functions.TYPEOF(temp).Contains("IFC2X3.IFCRELDEFINESBYTYPE"))) <= 1;
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
		if (!ValidateClause(IfcObjectClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcObject.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
