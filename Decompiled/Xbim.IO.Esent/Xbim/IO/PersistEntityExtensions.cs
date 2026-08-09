using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Configuration;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;
using Xbim.IO.Esent;
using Xbim.IO.Step21;
using Xbim.IO.Step21.Parser;

namespace Xbim.IO;

public static class PersistEntityExtensions
{
	private static ILoggerFactory loggerFactory = XbimServices.Current.GetLoggerFactory();

	internal static XbimInstanceHandle GetHandle(this IPersistEntity entity)
	{
		return new XbimInstanceHandle(entity);
	}

	internal static void WriteEntity(this IPersistEntity entity, BinaryWriter entityWriter, ExpressMetaData metadata)
	{
		ExpressType expressType = metadata.ExpressType(entity);
		entityWriter.Write(Convert.ToByte(P21ParseAction.BeginList));
		foreach (ExpressMetaProperty value2 in expressType.Properties.Values)
		{
			if (value2.EntityAttribute.State == EntityAttributeState.DerivedOverride)
			{
				entityWriter.Write(Convert.ToByte(P21ParseAction.SetOverrideValue));
				continue;
			}
			Type propertyType = value2.PropertyInfo.PropertyType;
			object value = value2.PropertyInfo.GetValue(entity, null);
			WriteProperty(propertyType, value, entityWriter, metadata);
		}
		entityWriter.Write(Convert.ToByte(P21ParseAction.EndList));
		entityWriter.Write(Convert.ToByte(P21ParseAction.EndEntity));
	}

	private static void WriteProperty(Type propType, object propVal, BinaryWriter entityWriter, ExpressMetaData metadata)
	{
		if (propVal == null)
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetNonDefinedValue));
			return;
		}
		if (propVal is IOptionalItemSet && !((IOptionalItemSet)propVal).Initialized)
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetNonDefinedValue));
			return;
		}
		if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			if (propVal is IExpressComplexType expressComplexType)
			{
				entityWriter.Write(Convert.ToByte(P21ParseAction.BeginList));
				foreach (object property in expressComplexType.Properties)
				{
					WriteProperty(property.GetType(), property, entityWriter, metadata);
				}
				entityWriter.Write(Convert.ToByte(P21ParseAction.EndList));
			}
			else if (propVal is IExpressValueType)
			{
				IExpressValueType expressValueType = (IExpressValueType)propVal;
				WriteValueType(expressValueType.UnderlyingSystemType, expressValueType.Value, entityWriter);
			}
			else
			{
				WriteValueType(propVal.GetType(), propVal, entityWriter);
			}
			return;
		}
		if (typeof(IExpressComplexType).IsAssignableFrom(propType))
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.BeginList));
			foreach (object property2 in ((IExpressComplexType)propVal).Properties)
			{
				WriteProperty(property2.GetType(), property2, entityWriter, metadata);
			}
			entityWriter.Write(Convert.ToByte(P21ParseAction.EndList));
			return;
		}
		if (typeof(IExpressValueType).IsAssignableFrom(propType))
		{
			Type type = propVal.GetType();
			if (type != propType)
			{
				entityWriter.Write(Convert.ToByte(P21ParseAction.BeginNestedType));
				entityWriter.Write(type.Name.ToUpper());
				entityWriter.Write(Convert.ToByte(P21ParseAction.BeginList));
				WriteProperty(type, propVal, entityWriter, metadata);
				entityWriter.Write(Convert.ToByte(P21ParseAction.EndList));
				entityWriter.Write(Convert.ToByte(P21ParseAction.EndNestedType));
			}
			else
			{
				IExpressValueType expressValueType2 = (IExpressValueType)propVal;
				WriteValueType(expressValueType2.UnderlyingSystemType, expressValueType2.Value, entityWriter);
			}
			return;
		}
		Type itemTypeFromGenericType;
		if (typeof(IExpressEnumerable).IsAssignableFrom(propType) && (itemTypeFromGenericType = propType.GetItemTypeFromGenericType()) != null)
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.BeginList));
			foreach (object item in (IExpressEnumerable)propVal)
			{
				WriteProperty(itemTypeFromGenericType, item, entityWriter, metadata);
			}
			entityWriter.Write(Convert.ToByte(P21ParseAction.EndList));
			return;
		}
		if (typeof(IPersistEntity).IsAssignableFrom(propType))
		{
			int entityLabel = ((IPersistEntity)propVal).EntityLabel;
			if (entityLabel <= 65535)
			{
				entityWriter.Write((byte)16);
				entityWriter.Write(Convert.ToUInt16(entityLabel));
				return;
			}
			if (entityLabel <= int.MaxValue)
			{
				entityWriter.Write((byte)17);
				entityWriter.Write(Convert.ToInt32(entityLabel));
				return;
			}
			throw new Exception("Entity Label exceeds maximim value for a an int32 long number");
		}
		if (propType.IsValueType || propType == typeof(string) || propType == typeof(byte[]))
		{
			WriteValueType(propVal.GetType(), propVal, entityWriter);
			return;
		}
		if (typeof(IExpressSelectType).IsAssignableFrom(propType))
		{
			if (propVal.GetType().IsValueType)
			{
				ExpressType expressType = metadata.ExpressType(propVal.GetType());
				entityWriter.Write(Convert.ToByte(P21ParseAction.BeginNestedType));
				entityWriter.Write(expressType.ExpressNameUpper);
				entityWriter.Write(Convert.ToByte(P21ParseAction.BeginList));
				WriteProperty(propVal.GetType(), propVal, entityWriter, metadata);
				entityWriter.Write(Convert.ToByte(P21ParseAction.EndList));
				entityWriter.Write(Convert.ToByte(P21ParseAction.EndNestedType));
			}
			else
			{
				WriteProperty(propVal.GetType(), propVal, entityWriter, metadata);
			}
			return;
		}
		throw new Exception($"Entity  has illegal property {propType.Name} of type {propType.Name}");
	}

	private static void WriteValueType(Type pInfoType, object pVal, BinaryWriter entityWriter)
	{
		if (pInfoType == typeof(double))
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetFloatValue));
			entityWriter.Write((double)pVal);
			return;
		}
		if (pInfoType == typeof(string))
		{
			if (pVal == null)
			{
				entityWriter.Write(Convert.ToByte(P21ParseAction.SetNonDefinedValue));
				return;
			}
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetStringValue));
			entityWriter.Write((string)pVal);
			return;
		}
		if (pInfoType == typeof(short))
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetIntegerValue));
			entityWriter.Write((long)(short)pVal);
			return;
		}
		if (pInfoType == typeof(int))
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetIntegerValue));
			entityWriter.Write((long)(int)pVal);
			return;
		}
		if (pInfoType == typeof(long))
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetIntegerValue));
			entityWriter.Write((long)pVal);
			return;
		}
		if (pInfoType.IsEnum)
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetEnumValue));
			entityWriter.Write(pVal.ToString().ToUpper());
			return;
		}
		if (pInfoType == typeof(bool))
		{
			if (pVal == null)
			{
				entityWriter.Write(Convert.ToByte(P21ParseAction.SetNonDefinedValue));
				return;
			}
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetBooleanValue));
			entityWriter.Write((bool)pVal);
			return;
		}
		if (pInfoType == typeof(DateTime))
		{
			int value = ((DateTime)pVal).ToStep21();
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetIntegerValue));
			entityWriter.Write(value);
			return;
		}
		if (pInfoType == typeof(Guid))
		{
			if (pVal == null)
			{
				entityWriter.Write(Convert.ToByte(P21ParseAction.SetNonDefinedValue));
				return;
			}
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetStringValue));
			entityWriter.Write((string)pVal);
			return;
		}
		if (pInfoType == typeof(bool?))
		{
			bool? flag = (bool?)pVal;
			if (!flag.HasValue)
			{
				entityWriter.Write(Convert.ToByte(P21ParseAction.SetNonDefinedValue));
				return;
			}
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetBooleanValue));
			entityWriter.Write(flag.Value);
			return;
		}
		if (pInfoType == typeof(byte[]))
		{
			entityWriter.Write(Convert.ToByte(P21ParseAction.SetHexValue));
			if (pVal == null)
			{
				entityWriter.Write(0);
				return;
			}
			byte[] array = (byte[])pVal;
			entityWriter.Write(array.Length);
			if (array.Length != 0)
			{
				entityWriter.Write(array);
			}
			return;
		}
		throw new ArgumentException($"Invalid Value Type {pInfoType.Name}", "pInfoType");
	}

	private static int WriteEntityToSteam(MemoryStream entityStream, BinaryWriter entityWriter, IPersistEntity item, ExpressMetaData metadata)
	{
		entityWriter.Seek(0, SeekOrigin.Begin);
		entityWriter.Write(0);
		item.WriteEntity(entityWriter, metadata);
		int num = Convert.ToInt32(entityStream.Position);
		entityWriter.Seek(0, SeekOrigin.Begin);
		entityWriter.Write(num);
		entityWriter.Seek(0, SeekOrigin.Begin);
		return num;
	}

	internal static void ReadEntityProperties(this IPersistEntity entity, PersistedEntityInstanceCache cache, BinaryReader br, bool unCached = false, bool fromCache = false)
	{
		P21ParseAction p21ParseAction = (P21ParseAction)br.ReadByte();
		XbimParserState xbimParserState = new XbimParserState(entity, loggerFactory);
		while (p21ParseAction != P21ParseAction.EndEntity)
		{
			switch (p21ParseAction)
			{
			case P21ParseAction.BeginList:
				xbimParserState.BeginList();
				break;
			case P21ParseAction.EndList:
				xbimParserState.EndList();
				break;
			case P21ParseAction.SetIntegerValue:
				xbimParserState.SetIntegerValue(br.ReadInt64());
				break;
			case P21ParseAction.SetHexValue:
			{
				int num3 = br.ReadInt32();
				if (num3 == 0)
				{
					xbimParserState.SetHexValue(new byte[0]);
				}
				else
				{
					xbimParserState.SetHexValue(br.ReadBytes(num3));
				}
				break;
			}
			case P21ParseAction.SetFloatValue:
				xbimParserState.SetFloatValue(br.ReadDouble());
				break;
			case P21ParseAction.SetStringValue:
				xbimParserState.SetStringValue(br.ReadString());
				break;
			case P21ParseAction.SetEnumValue:
				xbimParserState.SetEnumValue(br.ReadString());
				break;
			case P21ParseAction.SetBooleanValue:
				xbimParserState.SetBooleanValue(br.ReadBoolean());
				break;
			case P21ParseAction.SetNonDefinedValue:
				xbimParserState.SetNonDefinedValue();
				break;
			case P21ParseAction.SetOverrideValue:
				xbimParserState.SetOverrideValue();
				break;
			case P21ParseAction.SetObjectValueUInt16:
				if (fromCache)
				{
					int num2 = br.ReadUInt16();
					if (!xbimParserState.InList && cache.Read.TryGetValue(num2, out var value2))
					{
						xbimParserState.SetObjectValue(value2);
						break;
					}
					cache.AddForwardReference(new StepForwardReference(num2, xbimParserState.CurrentPropertyId, entity, xbimParserState.NestedIndex));
					xbimParserState.SkipProperty();
				}
				else
				{
					xbimParserState.SetObjectValue(cache.GetInstance(br.ReadUInt16(), loadProperties: false, unCached));
				}
				break;
			case P21ParseAction.SetObjectValueInt32:
				if (fromCache)
				{
					int num = br.ReadInt32();
					if (!xbimParserState.InList && cache.Read.TryGetValue(num, out var value))
					{
						xbimParserState.SetObjectValue(value);
						break;
					}
					cache.AddForwardReference(new StepForwardReference(num, xbimParserState.CurrentPropertyId, entity, xbimParserState.NestedIndex));
					xbimParserState.SkipProperty();
				}
				else
				{
					xbimParserState.SetObjectValue(cache.GetInstance(br.ReadInt32(), loadProperties: false, unCached));
				}
				break;
			case P21ParseAction.SetObjectValueInt64:
				throw new XbimException("Entity Label is int64, this is not currently supported");
			case P21ParseAction.BeginNestedType:
				xbimParserState.BeginNestedType(br.ReadString());
				break;
			case P21ParseAction.EndNestedType:
				xbimParserState.EndNestedType();
				break;
			case P21ParseAction.EndEntity:
				xbimParserState.EndEntity();
				break;
			case P21ParseAction.NewEntity:
				xbimParserState = new XbimParserState(entity, loggerFactory);
				break;
			default:
				throw new XbimException("Invalid Property Record #" + entity.EntityLabel + " EntityType: " + entity.GetType().Name);
			case P21ParseAction.BeginComplex:
			case P21ParseAction.EndComplex:
				break;
			}
			p21ParseAction = (P21ParseAction)br.ReadByte();
		}
	}
}
