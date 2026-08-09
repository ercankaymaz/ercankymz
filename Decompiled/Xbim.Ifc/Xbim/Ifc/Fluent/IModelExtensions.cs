using System;
using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.Ifc2x3.UtilityResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc.Fluent;

public static class IModelExtensions
{
	public static IModel AddHeaders(this IModel model, string? filename)
	{
		return model.AddHeaders(delegate(IStepFileName f)
		{
			f.Name = filename;
		}, delegate
		{
		});
	}

	public static IModel AddHeaders(this IModel model, Action<IStepFileName> fileNameAction, Action<IStepFileDescription> fileDescriptionAction)
	{
		fileDescriptionAction(model.Header.FileDescription);
		fileNameAction(model.Header.FileName);
		return model;
	}

	public static EntityCreator Build(this IModel model)
	{
		return new EntityCreator(model);
	}

	public static T SetAttributes<T>(this T entity, Func<EntityDefaults, EntityDefaults> setter) where T : IIfcRoot
	{
		if (setter == null)
		{
			setter = (EntityDefaults x) => x;
		}
		EntityDefaults setter2 = setter(new EntityDefaults());
		return entity.SetAttributes(setter2);
	}

	public static T SetAttributes<T>(this T entity, EntityDefaults? setter = null) where T : IIfcRoot
	{
		if ((object)setter == null)
		{
			setter = new EntityDefaults();
		}
		if (setter.GlobalId != Guid.Empty)
		{
			entity.SetGlobalId(setter.GlobalId);
		}
		IfcLabel? name = setter.Name;
		T val;
		if (!string.IsNullOrEmpty(name.HasValue ? ((string)name.GetValueOrDefault()) : null))
		{
			ref T reference = ref entity;
			val = default(T);
			if (val == null)
			{
				val = reference;
				reference = ref val;
			}
			IfcLabel? name2 = setter.Name;
			reference.Name = name2;
		}
		IfcText? description = setter.Description;
		if (!string.IsNullOrEmpty(description.HasValue ? ((string)description.GetValueOrDefault()) : null))
		{
			ref T reference2 = ref entity;
			val = default(T);
			if (val == null)
			{
				val = reference2;
				reference2 = ref val;
			}
			IfcText? description2 = setter.Description;
			reference2.Description = description2;
		}
		if (setter.OwnerHistory != null)
		{
			ref T reference3;
			if (default(T) == null)
			{
				val = entity;
				reference3 = ref val;
			}
			else
			{
				reference3 = ref entity;
			}
			ref T reference4 = ref reference3;
			if (reference4.OwnerHistory == null)
			{
				IIfcOwnerHistory ownerHistory2;
				IIfcOwnerHistory ownerHistory = (ownerHistory2 = setter.OwnerHistory);
				reference4.OwnerHistory = ownerHistory;
			}
		}
		if (!string.IsNullOrEmpty(setter.PredefinedType))
		{
			SetPredefinedTypeValue(entity, setter);
		}
		return entity;
	}

	public static T WithDefaults<T>(this T entity, Func<EntityDefaults, EntityDefaults> initAction) where T : IIfcRoot
	{
		if (initAction == null)
		{
			initAction = (EntityDefaults x) => x;
		}
		EntityDefaults init = initAction(new EntityDefaults());
		return entity.WithDefaults(init);
	}

	public static T WithDefaults<T>(this T entity, EntityDefaults? init = null) where T : IIfcRoot
	{
		if ((object)init == null)
		{
			init = new EntityDefaults();
		}
		if (entity.GlobalId == null)
		{
			entity.SetGlobalId(init.GlobalId);
		}
		ref T reference = ref entity;
		T val;
		ref T reference2;
		if (default(T) == null)
		{
			val = reference;
			reference2 = ref val;
		}
		else
		{
			reference2 = ref reference;
		}
		ref T reference3 = ref reference2;
		if (!reference3.Name.HasValue)
		{
			ref T reference4 = ref reference3;
			IfcLabel? name2;
			IfcLabel? name = (name2 = init.Name);
			reference4.Name = name;
		}
		reference3 = ref entity;
		ref T reference5;
		if (default(T) == null)
		{
			val = reference3;
			reference5 = ref val;
		}
		else
		{
			reference5 = ref reference3;
		}
		reference = ref reference5;
		if (!reference.Description.HasValue)
		{
			ref T reference6 = ref reference;
			IfcText? description2;
			IfcText? description = (description2 = init.Description);
			reference6.Description = description;
		}
		reference = ref entity;
		ref T reference7;
		if (default(T) == null)
		{
			val = reference;
			reference7 = ref val;
		}
		else
		{
			reference7 = ref reference;
		}
		reference3 = ref reference7;
		if (reference3.OwnerHistory == null)
		{
			ref T reference8 = ref reference3;
			IIfcOwnerHistory ownerHistory2;
			IIfcOwnerHistory ownerHistory = (ownerHistory2 = init.OwnerHistory);
			reference8.OwnerHistory = ownerHistory;
		}
		SetPredefinedTypeValue(entity, init);
		return entity;
	}

	public static T WithPropertySet<T>(this T entity, string propertySet) where T : IIfcObjectDefinition
	{
		if (entity is IIfcObject obj)
		{
			IIfcPropertySet ifcPropertySet = obj.GetPropertySet(propertySet);
			if (ifcPropertySet == null)
			{
				ifcPropertySet = entity.Model.Build().PropertySet(delegate(IIfcPropertySet o)
				{
					o.Name = propertySet;
				});
			}
			obj.AddPropertySet(ifcPropertySet);
		}
		else if (entity is IIfcTypeObject obj2)
		{
			IIfcPropertySet ifcPropertySet2 = obj2.GetPropertySet(propertySet);
			if (ifcPropertySet2 == null)
			{
				ifcPropertySet2 = entity.Model.Build().PropertySet(delegate(IIfcPropertySet o)
				{
					o.Name = propertySet;
				});
			}
			obj2.AddPropertySet(ifcPropertySet2);
		}
		return entity;
	}

	public static T WithPropertySingle<T>(this T entity, string propertySet, string propertyName, IIfcValue ifcValue) where T : IIfcObjectDefinition
	{
		Type type = ifcValue.GetType();
		entity.SetPropertySingleValue(propertySet, propertyName, type).NominalValue = ifcValue;
		return entity;
	}

	public static T WithEnumeratedProperty<T, V>(this T entity, string propertySet, string propertyName, V[] ifcValues) where T : IIfcObject where V : IIfcValue
	{
		entity.SetPropertyEnumeratedValue(propertySet, propertyName, ifcValues);
		return entity;
	}

	public static T WithBoundedProperty<T, V>(this T entity, string propertySet, string propertyName, V lowerValue, V upperValue, V? setPointVaue) where T : IIfcObject where V : IIfcValue
	{
		entity.SetPropertyBoundedValue(propertySet, propertyName, lowerValue, upperValue, setPointVaue);
		return entity;
	}

	public static T WithListValueProperty<T, V>(this T entity, string propertySet, string propertyName, V[] ifcValues) where T : IIfcObject where V : IIfcValue
	{
		entity.SetPropertyListValue(propertySet, propertyName, ifcValues);
		return entity;
	}

	public static T WithQuantity<T>(this T entity, string propertySet, string propertyName, double value, XbimQuantityTypeEnum quantityType, IIfcNamedUnit unit) where T : IIfcObject
	{
		entity.SetElementPhysicalSimpleQuantity(propertySet, propertyName, value, quantityType, unit);
		return entity;
	}

	private static void SetPredefinedTypeValue<T>(T entity, EntityDefaults init) where T : IIfcRoot
	{
		if (!(entity is IIfcObjectDefinition ifcObjectDefinition))
		{
			return;
		}
		if (string.IsNullOrEmpty(init.PredefinedType))
		{
			ifcObjectDefinition.SetPredefinedTypeValue("NOTDEFINED");
			return;
		}
		if (ifcObjectDefinition.IsPredefinedTypeEnum(init.PredefinedType))
		{
			ifcObjectDefinition.SetPredefinedTypeValue(init.PredefinedType);
			return;
		}
		if (ifcObjectDefinition is IIfcObject ifcObject)
		{
			ifcObject.ObjectType = init.PredefinedType;
		}
		else if (ifcObjectDefinition is IIfcElementType ifcElementType)
		{
			ifcElementType.ElementType = init.PredefinedType;
		}
		else if (ifcObjectDefinition is IIfcTypeProcess ifcTypeProcess)
		{
			ifcTypeProcess.ProcessType = init.PredefinedType;
		}
		ifcObjectDefinition.SetPredefinedTypeValue("USERDEFINED");
	}

	private static void SetGlobalId(this IIfcRoot entity, Guid? guid = null)
	{
		Guid valueOrDefault = guid.GetValueOrDefault();
		if (!guid.HasValue)
		{
			valueOrDefault = Guid.NewGuid();
			guid = valueOrDefault;
		}
		entity.GlobalId = IfcGloballyUniqueId.ConvertToBase64(guid.Value);
	}
}
