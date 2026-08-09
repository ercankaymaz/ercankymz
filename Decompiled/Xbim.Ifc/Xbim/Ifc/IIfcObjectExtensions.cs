using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc;

public static class IIfcObjectExtensions
{
	public static IIfcRelDefinesByType AddDefiningType(this IIfcObject obj, IIfcTypeObject theType)
	{
		List<IIfcRelDefinesByType> source = obj.Model.Instances.Where((IIfcRelDefinesByType r) => r.RelatingType == theType).ToList();
		IIfcRelDefinesByType ifcRelDefinesByType = source.FirstOrDefault((IIfcRelDefinesByType r) => r.RelatedObjects.Contains(obj));
		if (ifcRelDefinesByType != null)
		{
			return ifcRelDefinesByType;
		}
		IIfcRelDefinesByType ifcRelDefinesByType2 = source.FirstOrDefault();
		if (ifcRelDefinesByType2 != null)
		{
			ifcRelDefinesByType2.RelatedObjects.Add(obj);
			return ifcRelDefinesByType2;
		}
		IIfcRelDefinesByType ifcRelDefinesByType3 = new EntityCreator(obj.Model).RelDefinesByType(delegate(IIfcRelDefinesByType r)
		{
			r.RelatingType = theType;
		});
		ifcRelDefinesByType3.RelatedObjects.Add(obj);
		return ifcRelDefinesByType3;
	}

	public static void AddPropertySet(this IIfcObject obj, IIfcPropertySet pSet)
	{
		IIfcRelDefinesByProperties ifcRelDefinesByProperties = obj.Model.Instances.OfType<IIfcRelDefinesByProperties>().FirstOrDefault((IIfcRelDefinesByProperties r) => pSet.Equals(r.RelatingPropertyDefinition));
		if (ifcRelDefinesByProperties == null)
		{
			ifcRelDefinesByProperties = new EntityCreator(obj.Model).RelDefinesByProperties(delegate(IIfcRelDefinesByProperties r)
			{
				r.RelatingPropertyDefinition = pSet;
			});
		}
		ifcRelDefinesByProperties.RelatedObjects.Add(obj);
	}

	public static void AddPropertySet(this IIfcTypeObject obj, IIfcPropertySet pSet)
	{
		obj.HasPropertySets.Add(pSet);
	}

	private static IEnumerable<IIfcPropertySet> GetPropertySets(this IIfcObjectDefinition obj)
	{
		IEnumerable<IIfcPropertySetDefinition> source = ((obj is IIfcObject ifcObject) ? ifcObject.IsDefinedBy.SelectMany((IIfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions) : ((!(obj is IIfcTypeObject ifcTypeObject)) ? null : ifcTypeObject.HasPropertySets));
		return source.OfType<IIfcPropertySet>();
	}

	public static IIfcPropertySet GetPropertySet(this IIfcObjectDefinition obj, string pSetName, bool caseSensitive = true)
	{
		return obj.GetPropertySets().FirstOrDefault(delegate(IIfcPropertySet pset)
		{
			string strA = pSetName;
			IfcLabel? name = pset.Name;
			return string.Compare(strA, name.HasValue ? ((string)name.GetValueOrDefault()) : null, !caseSensitive) == 0;
		});
	}

	private static IIfcPropertySet GetOrCreatePropertySet(this IIfcObjectDefinition obj, string propertySetName, EntityCreator factory)
	{
		IIfcPropertySet ifcPropertySet = ((obj is IIfcObject obj2) ? obj2.GetPropertySet(propertySetName) : ((!(obj is IIfcTypeObject obj3)) ? null : obj3.GetPropertySet(propertySetName)));
		IIfcPropertySet pset = ifcPropertySet;
		if (pset == null)
		{
			pset = factory.PropertySet();
			pset.Name = propertySetName;
			if (obj is IIfcTypeObject ifcTypeObject)
			{
				ifcTypeObject.HasPropertySets.Add(pset);
			}
			else
			{
				factory.RelDefinesByProperties(delegate(IIfcRelDefinesByProperties r)
				{
					r.RelatingPropertyDefinition = pset;
					r.RelatedObjects.Add(obj);
				});
			}
		}
		return pset;
	}

	public static TProp GetSimpleProperty<TProp>(this IIfcObjectDefinition obj, string pSetName, string propertyName) where TProp : IIfcSimpleProperty
	{
		IIfcPropertySet ifcPropertySet = ((obj is IIfcObject obj2) ? obj2.GetPropertySet(pSetName) : ((!(obj is IIfcTypeObject obj3)) ? null : obj3.GetPropertySet(pSetName)));
		IIfcPropertySet ifcPropertySet2 = ifcPropertySet;
		if (ifcPropertySet2 == null)
		{
			return default(TProp);
		}
		return ifcPropertySet2.HasProperties.OfType<TProp>().FirstOrDefault((TProp p) => p.Name == (IfcIdentifier)propertyName);
	}

	public static IIfcPropertySingleValue GetPropertySingleValue(this IIfcObjectDefinition obj, string pSetName, string propertyName)
	{
		return obj.GetSimpleProperty<IIfcPropertySingleValue>(pSetName, propertyName);
	}

	public static IIfcPropertyEnumeratedValue GetPropertyEnumeratedValue(this IIfcObjectDefinition obj, string pSetName, string propertyName)
	{
		return obj.GetSimpleProperty<IIfcPropertyEnumeratedValue>(pSetName, propertyName);
	}

	public static IIfcPropertyBoundedValue GetPropertyBoundedValue(this IIfcObjectDefinition obj, string pSetName, string propertyName)
	{
		return obj.GetSimpleProperty<IIfcPropertyBoundedValue>(pSetName, propertyName);
	}

	public static IIfcPropertyListValue GetPropertyListValue(this IIfcObjectDefinition obj, string pSetName, string propertyName)
	{
		return obj.GetSimpleProperty<IIfcPropertyListValue>(pSetName, propertyName);
	}

	public static TValueType GetPropertySingleValue<TValueType>(this IIfcObjectDefinition obj, string pSetName, string propertyName) where TValueType : IIfcValue
	{
		IIfcPropertySet ifcPropertySet = ((obj is IIfcObject obj2) ? obj2.GetPropertySet(pSetName) : ((!(obj is IIfcTypeObject obj3)) ? null : obj3.GetPropertySet(pSetName)));
		IIfcPropertySet ifcPropertySet2 = ifcPropertySet;
		if (ifcPropertySet2 == null)
		{
			return default(TValueType);
		}
		IIfcPropertySingleValue ifcPropertySingleValue = ifcPropertySet2.HasProperties.OfType<IIfcPropertySingleValue>().FirstOrDefault((IIfcPropertySingleValue p) => p.Name == (IfcIdentifier)propertyName);
		if (ifcPropertySingleValue != null && ifcPropertySingleValue.NominalValue is TValueType)
		{
			return (TValueType)ifcPropertySingleValue.NominalValue;
		}
		return default(TValueType);
	}

	public static IIfcValue GetPropertySingleNominalValue(this IIfcObjectDefinition obj, string pSetName, string propertyName)
	{
		return obj.GetPropertySingleValue(pSetName, propertyName)?.NominalValue;
	}

	public static IIfcPropertySingleValue SetPropertySingleValue<T>(this IIfcObjectDefinition obj, string pSetName, string propertyName) where T : IIfcValue
	{
		return obj.SetPropertySingleValue(pSetName, propertyName, typeof(T));
	}

	public static IIfcPropertySingleValue SetPropertySingleValue(this IIfcObjectDefinition obj, string pSetName, string propertyName, Type type)
	{
		if (typeof(IIfcValue).GetTypeInfo().IsAssignableFrom(type))
		{
			IIfcValue ifcValue = ((!typeof(IfcPositiveLengthMeasure).GetTypeInfo().IsAssignableFrom(type)) ? (Activator.CreateInstance(type) as IIfcValue) : (Activator.CreateInstance(type, 1.0) as IIfcValue));
			if (ifcValue != null)
			{
				if (!(obj is IIfcObject obj2))
				{
					if (obj is IIfcTypeObject obj3)
					{
						return obj3.SetPropertySingleValue(pSetName, propertyName, ifcValue);
					}
					return null;
				}
				return obj2.SetPropertySingleValue(pSetName, propertyName, ifcValue);
			}
			throw new Exception("Type '" + type.Name + "' can't be initialized.");
		}
		throw new ArgumentException("Type '" + type.Name + "' is not compatible with IfcValue type.");
	}

	public static IIfcPropertySingleValue SetPropertySingleValue(this IIfcObjectDefinition obj, string pSetName, string propertyName, IIfcValue value)
	{
		EntityCreator entityCreator = new EntityCreator(obj.Model);
		IIfcPropertySet orCreatePropertySet = obj.GetOrCreatePropertySet(pSetName, entityCreator);
		IIfcPropertySingleValue ifcPropertySingleValue = obj.GetPropertySingleValue(pSetName, propertyName);
		if (ifcPropertySingleValue != null)
		{
			ifcPropertySingleValue.NominalValue = value;
		}
		else
		{
			ifcPropertySingleValue = entityCreator.PropertySingleValue(delegate(IIfcPropertySingleValue psv)
			{
				psv.Name = propertyName;
				psv.NominalValue = value;
			});
			orCreatePropertySet.HasProperties.Add(ifcPropertySingleValue);
		}
		return ifcPropertySingleValue;
	}

	public static IIfcPropertyEnumeratedValue SetPropertyEnumeratedValue<TVal>(this IIfcObjectDefinition obj, string pSetName, string propertyName, TVal[] values) where TVal : IIfcValue
	{
		EntityCreator entityCreator = new EntityCreator(obj.Model);
		IIfcPropertySet orCreatePropertySet = obj.GetOrCreatePropertySet(pSetName, entityCreator);
		IIfcPropertyEnumeratedValue ifcPropertyEnumeratedValue = obj.GetSimpleProperty<IIfcPropertyEnumeratedValue>(pSetName, propertyName);
		if (ifcPropertyEnumeratedValue == null)
		{
			ifcPropertyEnumeratedValue = entityCreator.PropertyEnumeratedValue(delegate(IIfcPropertyEnumeratedValue psv)
			{
				psv.Name = propertyName;
			});
			orCreatePropertySet.HasProperties.Add(ifcPropertyEnumeratedValue);
		}
		foreach (TVal val in values)
		{
			ifcPropertyEnumeratedValue.EnumerationValues.Add(val);
		}
		return ifcPropertyEnumeratedValue;
	}

	public static IIfcPropertyBoundedValue SetPropertyBoundedValue(this IIfcObjectDefinition obj, string pSetName, string propertyName, IIfcValue lowerValue, IIfcValue upperValue, IIfcValue setPointValue)
	{
		EntityCreator entityCreator = new EntityCreator(obj.Model);
		IIfcPropertySet orCreatePropertySet = obj.GetOrCreatePropertySet(pSetName, entityCreator);
		IIfcPropertyBoundedValue ifcPropertyBoundedValue = obj.GetSimpleProperty<IIfcPropertyBoundedValue>(pSetName, propertyName);
		if (ifcPropertyBoundedValue == null)
		{
			ifcPropertyBoundedValue = entityCreator.PropertyBoundedValue(delegate(IIfcPropertyBoundedValue psv)
			{
				psv.Name = propertyName;
			});
			orCreatePropertySet.HasProperties.Add(ifcPropertyBoundedValue);
		}
		ifcPropertyBoundedValue.LowerBoundValue = lowerValue;
		ifcPropertyBoundedValue.UpperBoundValue = upperValue;
		ifcPropertyBoundedValue.SetPointValue = setPointValue;
		return ifcPropertyBoundedValue;
	}

	public static IIfcPropertyListValue SetPropertyListValue<TVal>(this IIfcObjectDefinition obj, string pSetName, string propertyName, TVal[] values) where TVal : IIfcValue
	{
		EntityCreator entityCreator = new EntityCreator(obj.Model);
		IIfcPropertySet orCreatePropertySet = obj.GetOrCreatePropertySet(pSetName, entityCreator);
		IIfcPropertyListValue ifcPropertyListValue = obj.GetSimpleProperty<IIfcPropertyListValue>(pSetName, propertyName);
		if (ifcPropertyListValue == null)
		{
			ifcPropertyListValue = entityCreator.PropertyListValue(delegate(IIfcPropertyListValue psv)
			{
				psv.Name = propertyName;
			});
			orCreatePropertySet.HasProperties.Add(ifcPropertyListValue);
		}
		foreach (TVal val in values)
		{
			ifcPropertyListValue.ListValues.Add(val);
		}
		return ifcPropertyListValue;
	}

	public static IEnumerable<IIfcElement> GetExternalElements(this IIfcObject obj)
	{
		return (from rsb in obj.Model.Instances.OfType<IIfcRelSpaceBoundary>()
			where rsb.InternalOrExternalBoundary == IfcInternalOrExternalEnum.EXTERNAL && rsb.PhysicalOrVirtualBoundary == IfcPhysicalOrVirtualEnum.PHYSICAL && rsb.RelatedBuildingElement != null
			select rsb.RelatedBuildingElement).Distinct();
	}

	public static IIfcElementQuantity GetElementQuantity(this IIfcObject obj, string quantityName, bool caseSensitive = true)
	{
		return obj.IsDefinedBy.SelectMany((IIfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).OfType<IIfcElementQuantity>().FirstOrDefault(delegate(IIfcElementQuantity qset)
		{
			string strA = quantityName;
			IfcLabel? name = qset.Name;
			return string.Compare(strA, name.HasValue ? ((string)name.GetValueOrDefault()) : null, !caseSensitive) == 0;
		});
	}

	public static TQType GetQuantity<TQType>(this IIfcObject obj, string pSetName, string quantityName) where TQType : IIfcPhysicalQuantity
	{
		IIfcPropertySetDefinition ifcPropertySetDefinition = obj.IsDefinedBy.SelectMany((IIfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).FirstOrDefault((IIfcPropertySetDefinition r) => r is IIfcElementQuantity && r.Name == (IfcLabel?)(IfcLabel)pSetName);
		if (ifcPropertySetDefinition == null)
		{
			return default(TQType);
		}
		if (ifcPropertySetDefinition is IIfcElementQuantity ifcElementQuantity)
		{
			return ifcElementQuantity.Quantities.OfType<TQType>().FirstOrDefault((TQType q) => q.Name == (IfcLabel)quantityName);
		}
		return default(TQType);
	}

	public static TQType GetQuantity<TQType>(this IIfcObject obj, string quantityName) where TQType : IIfcPhysicalQuantity
	{
		return obj.IsDefinedBy.SelectMany((IIfcRelDefinesByProperties r) => r.RelatingPropertyDefinition.PropertySetDefinitions).OfType<IIfcElementQuantity>().SelectMany((IIfcElementQuantity qset) => qset.Quantities)
			.OfType<TQType>()
			.FirstOrDefault((TQType q) => q.Name == (IfcLabel)quantityName);
	}

	public static IIfcElementQuantity AddQuantity(this IIfcObject obj, string psetName, IIfcPhysicalQuantity quantity, string methodOfMeasurement = null)
	{
		IIfcElementQuantity pset = obj.GetElementQuantity(psetName);
		if (pset == null)
		{
			EntityCreator entityCreator = new EntityCreator(obj.Model);
			pset = entityCreator.ElementQuantity(delegate(IIfcElementQuantity p)
			{
				p.Name = psetName;
			});
			entityCreator.RelDefinesByProperties(delegate(IIfcRelDefinesByProperties r)
			{
				r.RelatingPropertyDefinition = pset;
				r.RelatedObjects.Add(obj);
			});
		}
		pset.Quantities.Add(quantity);
		if (!string.IsNullOrEmpty(methodOfMeasurement))
		{
			pset.MethodOfMeasurement = methodOfMeasurement;
		}
		return pset;
	}

	public static IIfcPhysicalSimpleQuantity GetElementPhysicalSimpleQuantity(this IIfcObject obj, string pSetName, string quantityName)
	{
		return obj.GetElementQuantity(pSetName)?.Quantities.FirstOrDefault((IIfcPhysicalSimpleQuantity sq) => sq.Name == (IfcLabel)quantityName);
	}

	public static void RemovePropertySingleValue(this IIfcObject obj, string pSetName, string propertyName)
	{
		IIfcPropertySet propertySet = obj.GetPropertySet(pSetName);
		if (propertySet != null)
		{
			IIfcPropertySingleValue ifcPropertySingleValue = propertySet.HasProperties.FirstOrDefault((IIfcPropertySingleValue p) => p.Name == (IfcIdentifier)propertyName);
			if (ifcPropertySingleValue != null)
			{
				propertySet.HasProperties.Remove(ifcPropertySingleValue);
			}
		}
	}

	public static void RemoveElementPhysicalSimpleQuantity(this IIfcObject obj, string pSetName, string qualityName)
	{
		IIfcElementQuantity elementQuantity = obj.GetElementQuantity(pSetName);
		if (elementQuantity != null)
		{
			IIfcPhysicalSimpleQuantity ifcPhysicalSimpleQuantity = elementQuantity.Quantities.FirstOrDefault((IIfcPhysicalSimpleQuantity sq) => sq.Name == (IfcLabel)qualityName);
			if (ifcPhysicalSimpleQuantity != null)
			{
				elementQuantity.Quantities.Remove(ifcPhysicalSimpleQuantity);
			}
		}
	}

	public static void SetElementPhysicalSimpleQuantity(this IIfcObject obj, string qSetName, string quantityName, double value, XbimQuantityTypeEnum quantityType, IIfcNamedUnit unit)
	{
		EntityCreator entityCreator = new EntityCreator(obj.Model);
		IIfcElementQuantity qset = obj.GetElementQuantity(qSetName);
		if (qset == null)
		{
			qset = entityCreator.ElementQuantity(delegate(IIfcElementQuantity q)
			{
				q.Name = qSetName;
			});
			entityCreator.RelDefinesByProperties(delegate(IIfcRelDefinesByProperties prop)
			{
				prop.RelatingPropertyDefinition = qset;
				prop.RelatedObjects.Add(obj);
			});
		}
		IIfcPhysicalSimpleQuantity elementPhysicalSimpleQuantity = obj.GetElementPhysicalSimpleQuantity(qSetName, quantityName);
		if (elementPhysicalSimpleQuantity != null)
		{
			obj.GetElementQuantity(qSetName).Quantities.Remove(elementPhysicalSimpleQuantity);
			obj.Model.Delete(elementPhysicalSimpleQuantity);
		}
		elementPhysicalSimpleQuantity = quantityType switch
		{
			XbimQuantityTypeEnum.Area => entityCreator.QuantityArea(delegate(IIfcQuantityArea sq)
			{
				sq.AreaValue = value;
			}), 
			XbimQuantityTypeEnum.Length => entityCreator.QuantityLength(delegate(IIfcQuantityLength sq)
			{
				sq.LengthValue = value;
			}), 
			XbimQuantityTypeEnum.Volume => entityCreator.QuantityVolume(delegate(IIfcQuantityVolume sq)
			{
				sq.VolumeValue = value;
			}), 
			XbimQuantityTypeEnum.Count => entityCreator.QuantityCount(delegate(IIfcQuantityCount sq)
			{
				sq.CountValue = value;
			}), 
			XbimQuantityTypeEnum.Weight => entityCreator.QuantityWeight(delegate(IIfcQuantityWeight sq)
			{
				sq.WeightValue = value;
			}), 
			XbimQuantityTypeEnum.Time => entityCreator.QuantityTime(delegate(IIfcQuantityTime sq)
			{
				sq.TimeValue = value;
			}), 
			_ => null, 
		};
		if (elementPhysicalSimpleQuantity != null)
		{
			elementPhysicalSimpleQuantity.Unit = unit;
			elementPhysicalSimpleQuantity.Name = quantityName;
			qset.Quantities.Add(elementPhysicalSimpleQuantity);
		}
	}
}
