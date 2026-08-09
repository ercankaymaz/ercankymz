using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;

namespace Xbim.IO.Step21;

public static class Part21Writer
{
	private static readonly IFormatProvider _p21Provider = new Part21Formatter();

	public static void Write(IModel model, TextWriter output, ExpressMetaData metadata, IDictionary<int, int> map = null, ReportProgressDelegate progress = null)
	{
		IStepFileHeader stepFileHeader = model.Header ?? new StepFileHeader(StepFileHeader.HeaderCreationMode.InitWithXbimDefaults, model);
		string overridingSchema = null;
		if (stepFileHeader.FileSchema == null || !stepFileHeader.FileSchema.Schemas.Any())
		{
			IPersistEntity persistEntity = model.Instances.FirstOrDefault();
			if (persistEntity != null)
			{
				Type? type = (from t in persistEntity.GetType().GetTypeInfo().Assembly.GetTypes()
					where typeof(IEntityFactory).GetTypeInfo().IsAssignableFrom(t)
					select t).FirstOrDefault();
				if (type == null)
				{
					throw new XbimException("It wasn't possible to find valid schema definition");
				}
				if (!(Activator.CreateInstance(type) is IEntityFactory entityFactory))
				{
					throw new XbimException("It wasn't possible to find valid schema definition");
				}
				overridingSchema = string.Join(",", entityFactory.SchemasIds);
			}
		}
		WriteHeader(stepFileHeader, output, overridingSchema);
		long count = model.Instances.Count;
		int num = 0;
		bool flag = progress != null;
		foreach (IPersistEntity instance in model.Instances)
		{
			WriteEntity(instance, output, metadata, map);
			output.WriteLine();
			if (flag)
			{
				num++;
				if (num % 1000 == 0)
				{
					int percentProgress = (int)((float)num / (float)count);
					progress(percentProgress, null);
				}
			}
		}
		WriteFooter(output);
		progress?.Invoke(100, null);
	}

	public static void WriteHeader(IStepFileHeader header, TextWriter output, string overridingSchema = null)
	{
		output.WriteLine("ISO-10303-21;");
		output.WriteLine("HEADER;");
		output.Write("FILE_DESCRIPTION ((");
		int num = 0;
		if (header.FileDescription.Description.Count == 0)
		{
			output.Write("''");
		}
		else
		{
			foreach (string item in header.FileDescription.Description)
			{
				output.Write("{0}'{1}'", (num == 0) ? "" : ",", item.ToPart21());
				num++;
			}
		}
		output.Write("), '{0}');", header.FileDescription.ImplementationLevel);
		output.WriteLine();
		output.Write("FILE_NAME (");
		output.Write("'{0}'", (header.FileName != null && header.FileName.Name != null) ? header.FileName.Name.ToPart21() : "");
		output.Write(", '{0}'", (header.FileName != null) ? header.FileName.TimeStamp : "");
		output.Write(", (");
		num = 0;
		if (header.FileName != null && header.FileName.AuthorName.Count == 0)
		{
			output.Write("''");
		}
		else if (header.FileName != null)
		{
			foreach (string item2 in header.FileName.AuthorName)
			{
				output.Write("{0}'{1}'", (num == 0) ? "" : ",", item2.ToPart21());
				num++;
			}
		}
		output.Write("), (");
		num = 0;
		if (header.FileName != null && header.FileName.Organization.Count == 0)
		{
			output.Write("''");
		}
		else if (header.FileName != null)
		{
			foreach (string item3 in header.FileName.Organization)
			{
				output.Write("{0}'{1}'", (num == 0) ? "" : ",", item3.ToPart21());
				num++;
			}
		}
		if (header.FileName != null)
		{
			output.Write("), '{0}', '{1}', '{2}');", header.FileName.PreprocessorVersion.ToPart21(), header.FileName.OriginatingSystem.ToPart21(), header.FileName.AuthorizationName.ToPart21());
		}
		output.WriteLine();
		output.Write("FILE_SCHEMA (('{0}'));", overridingSchema ?? header.FileSchema.Schemas.FirstOrDefault());
		output.WriteLine();
		output.WriteLine("ENDSEC;");
		output.WriteLine("DATA;");
	}

	public static void WriteFooter(TextWriter output)
	{
		output.WriteLine("ENDSEC;");
		output.WriteLine("END-ISO-10303-21;");
	}

	public static void WriteEntity(IPersistEntity entity, TextWriter output, ExpressMetaData metadata, IDictionary<int, int> map = null, bool writeEntityLabelAndType = true)
	{
		ExpressType expressType = metadata.ExpressType(entity);
		if (map != null && map.Keys.Contains(entity.EntityLabel))
		{
			return;
		}
		if (writeEntityLabelAndType)
		{
			output.Write("#{0}={1}(", entity.EntityLabel, expressType.ExpressNameUpper);
		}
		else
		{
			output.Write("(");
		}
		bool flag = true;
		foreach (ExpressMetaProperty value2 in expressType.Properties.Values)
		{
			if (value2.EntityAttribute.State == EntityAttributeState.DerivedOverride)
			{
				if (!flag)
				{
					output.Write(',');
				}
				output.Write('*');
				flag = false;
				continue;
			}
			Type propertyType = value2.PropertyInfo.PropertyType;
			object value = value2.PropertyInfo.GetValue(entity, null);
			if (!flag)
			{
				output.Write(',');
			}
			WriteProperty(propertyType, value, output, map, metadata);
			flag = false;
		}
		output.Write(");");
	}

	public static void WriteProperty(Type propType, object propVal, TextWriter output, IDictionary<int, int> map, ExpressMetaData metadata)
	{
		Type itemTypeFromGenericType;
		if (propVal == null)
		{
			output.Write('$');
		}
		else if (propVal is IOptionalItemSet && !((IOptionalItemSet)propVal).Initialized)
		{
			output.Write('$');
		}
		else if (propType.GetTypeInfo().IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
		{
			if (propVal is IExpressComplexType expressComplexType)
			{
				output.Write('(');
				bool flag = true;
				foreach (object property in expressComplexType.Properties)
				{
					if (!flag)
					{
						output.Write(',');
					}
					WriteProperty(property.GetType(), property, output, map, metadata);
					flag = false;
				}
				output.Write(')');
			}
			else if (propVal is IExpressValueType)
			{
				IExpressValueType expressValueType = (IExpressValueType)propVal;
				WriteValueType(expressValueType.UnderlyingSystemType, expressValueType.Value, output);
			}
			else
			{
				WriteValueType(propVal.GetType(), propVal, output);
			}
		}
		else if (typeof(IExpressComplexType).GetTypeInfo().IsAssignableFrom(propType))
		{
			output.Write('(');
			bool flag2 = true;
			foreach (object property2 in ((IExpressComplexType)propVal).Properties)
			{
				if (!flag2)
				{
					output.Write(',');
				}
				WriteProperty(property2.GetType(), property2, output, map, metadata);
				flag2 = false;
			}
			output.Write(')');
		}
		else if (typeof(IExpressValueType).GetTypeInfo().IsAssignableFrom(propType))
		{
			Type type = propVal.GetType();
			if (type != propType)
			{
				output.Write(type.Name.ToUpper());
				output.Write('(');
				WriteProperty(type, propVal, output, map, metadata);
				output.Write(')');
			}
			else
			{
				IExpressValueType expressValueType2 = (IExpressValueType)propVal;
				WriteValueType(expressValueType2.UnderlyingSystemType, expressValueType2.Value, output);
			}
		}
		else if (typeof(IExpressEnumerable).GetTypeInfo().IsAssignableFrom(propType) && (itemTypeFromGenericType = propType.GetItemTypeFromGenericType()) != null)
		{
			output.Write('(');
			bool flag3 = true;
			foreach (object item in (IExpressEnumerable)propVal)
			{
				if (!flag3)
				{
					output.Write(',');
				}
				WriteProperty(itemTypeFromGenericType, item, output, map, metadata);
				flag3 = false;
			}
			output.Write(')');
		}
		else if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(propType))
		{
			output.Write('#');
			int num = ((IPersistEntity)propVal).EntityLabel;
			if (map != null && map.TryGetValue(num, out var value))
			{
				num = value;
			}
			output.Write(num);
		}
		else if (propType.GetTypeInfo().IsValueType || propVal is string || propVal is byte[])
		{
			WriteValueType(propVal.GetType(), propVal, output);
		}
		else
		{
			if (!typeof(IExpressSelectType).GetTypeInfo().IsAssignableFrom(propType))
			{
				throw new Exception($"Entity  has illegal property {propType.Name} of type {propType.Name}");
			}
			if (propVal.GetType().GetTypeInfo().IsValueType)
			{
				ExpressType expressType = metadata.ExpressType(propVal.GetType());
				output.Write(expressType.ExpressNameUpper);
				output.Write('(');
				WriteProperty(propVal.GetType(), propVal, output, map, metadata);
				output.Write(')');
			}
			else
			{
				WriteProperty(propVal.GetType(), propVal, output, map, metadata);
			}
		}
	}

	private static void WriteValueType(Type pInfoType, object pVal, TextWriter output)
	{
		if (pInfoType == typeof(double))
		{
			output.Write(string.Format(_p21Provider, "{0:R}", pVal));
		}
		else if (pInfoType == typeof(string))
		{
			if (pVal == null)
			{
				output.Write('$');
				return;
			}
			output.Write('\'');
			output.Write(((string)pVal).ToPart21());
			output.Write('\'');
		}
		else if (pInfoType == typeof(byte[]))
		{
			output.Write("\"0");
			byte[] array = (byte[])pVal;
			foreach (byte b in array)
			{
				output.Write("{0:X2}", b);
			}
			output.Write('"');
		}
		else if (pInfoType == typeof(short) || pInfoType == typeof(int) || pInfoType == typeof(long))
		{
			output.Write(pVal.ToString());
		}
		else if (pInfoType.GetTypeInfo().IsEnum)
		{
			output.Write(".{0}.", pVal.ToString().ToUpper());
		}
		else if (pInfoType == typeof(bool))
		{
			if (pVal != null)
			{
				bool flag = (bool)pVal;
				output.Write(".{0}.", flag ? "T" : "F");
			}
		}
		else if (pInfoType == typeof(DateTime))
		{
			output.Write(string.Format(_p21Provider, "{0:T}", pVal));
		}
		else if (pInfoType == typeof(Guid))
		{
			if (pVal == null)
			{
				output.Write('$');
			}
			else
			{
				output.Write(string.Format(_p21Provider, "{0:G}", pVal));
			}
		}
		else
		{
			if (!(pInfoType == typeof(bool?)))
			{
				throw new ArgumentException($"Invalid Value Type {pInfoType.Name}", "pInfoType");
			}
			bool? flag2 = (bool?)pVal;
			output.Write((!flag2.HasValue) ? ".U." : string.Format(".{0}.", flag2.Value ? "T" : "F"));
		}
	}
}
