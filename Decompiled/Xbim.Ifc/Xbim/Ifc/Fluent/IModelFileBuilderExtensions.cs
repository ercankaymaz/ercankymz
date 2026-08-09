using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Step21;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.Fluent;

public static class IModelFileBuilderExtensions
{
	public static IModelFileBuilder SetOwnerHistory(this IModelFileBuilder builder, XbimEditorCredentials? editor = null, Action<IIfcOwnerHistory>? action = null)
	{
		if (editor == null)
		{
			editor = builder.Editor ?? throw new Exception("An editor must be defined to set OwnerHistory");
		}
		IIfcApplication app = builder.Model.GetOrCreateApplication(editor);
		IIfcPersonAndOrganization user = builder.Model.GetOrCreateDefaultUser(editor);
		Func<IIfcOwnerHistory, IIfcOwnerHistory> defaultValue = delegate(IIfcOwnerHistory o)
		{
			o.ChangeAction = IfcChangeActionEnum.ADDED;
			o.State = IfcStateEnum.READWRITE;
			o.OwningApplication = app;
			o.OwningUser = user;
			o.CreationDate = builder.EffectiveDateTime;
			o.LastModifiedDate = builder.EffectiveDateTime;
			return o;
		};
		if (action == null)
		{
			action = delegate
			{
			};
		}
		builder.OwnerHistory = builder.Factory.OwnerHistory(delegate(IIfcOwnerHistory o)
		{
			action(defaultValue(o));
		});
		return builder;
	}

	private static string GetDefaultViewDefinitionString(IModelFileBuilder builder)
	{
		return builder.Model.SchemaVersion switch
		{
			XbimSchemaVersion.Ifc2X3 => "ViewDefinition [CoordinationView_V2.0]", 
			XbimSchemaVersion.Ifc4 => "ViewDefinition [ReferenceView_V1.2]", 
			XbimSchemaVersion.Ifc4x3 => "ViewDefinition [ReferenceView]", 
			_ => "ViewDefinition [CoordinationView]", 
		};
	}

	public static IModelFileBuilder SetHeaders(this IModelFileBuilder builder, Action<IStepFileName>? stepFileName = null, Action<IStepFileDescription>? fileDescription = null)
	{
		string def = GetDefaultViewDefinitionString(builder);
		if (fileDescription == null)
		{
			fileDescription = delegate(IStepFileDescription fd)
			{
				fd.Description.Add(def);
			};
		}
		if (stepFileName == null)
		{
			stepFileName = delegate(IStepFileName f)
			{
				f.OriginatingSystem = (builder.Editor?.ApplicationFullName ?? "xbim Toolkit") + " " + builder.Editor?.ApplicationVersion;
				f.TimeStamp = string.Format(builder.EffectiveDateTime.ToString("s"));
				if (builder.Editor != null)
				{
					f.AuthorName.Add(builder.Editor.EditorsGivenName + " " + builder.Editor.EditorsFamilyName);
					f.Organization.Add(builder.Editor.EditorsOrganisationName ?? "");
				}
			};
		}
		builder.Model.AddHeaders(stepFileName, fileDescription);
		return builder;
	}

	public static IModelFileBuilder SaveAsIfc(this IModelFileBuilder fileBuilder, string fileName, bool keepOpen = false)
	{
		fileBuilder.Model.Header.FileName.Name = fileName;
		fileBuilder.Transaction.Commit();
		using FileStream stream = new FileStream(fileName, FileMode.Create);
		fileBuilder.Model.SaveAsIfc(stream);
		if (!keepOpen)
		{
			fileBuilder.Discard();
		}
		else
		{
			fileBuilder.NewTransaction();
		}
		return fileBuilder;
	}

	public static IModelFileBuilder CreateEntities(this IModelFileBuilder fileBuilder, Action<EntityCreator> config)
	{
		ModelInstanceBuilder modelInstanceBuilder = new ModelInstanceBuilder(fileBuilder);
		config(modelInstanceBuilder.Factory);
		return fileBuilder;
	}

	public static IModelFileBuilder CreateEntities(this IModelFileBuilder fileBuilder, Action<EntityCreator, IModelInstanceBuilder> config)
	{
		ModelInstanceBuilder modelInstanceBuilder = new ModelInstanceBuilder(fileBuilder);
		config(modelInstanceBuilder.Factory, modelInstanceBuilder);
		return fileBuilder;
	}

	public static void Discard(this IModelFileBuilder fileBuilder)
	{
		(fileBuilder as IDisposable).Dispose();
	}

	public static IEnumerable<ValidationResult> ValidateIfc(this IModelFileBuilder builder, ValidationFlags validationFlags = ValidationFlags.All)
	{
		return new Validator
		{
			ValidateLevel = validationFlags
		}.Validate(builder.Model);
	}

	public static IModelFileBuilder AssertValid(this IModelFileBuilder builder, ValidationFlags validationFlags = ValidationFlags.All)
	{
		IEnumerable<ValidationResult> source = builder.ValidateIfc(validationFlags);
		if (source.Any())
		{
			List<string> values = (from e in source.Take(10)
				select $"[{e.IssueSource}] {e.Message}: {e.Item}").ToList();
			string arg = string.Join("\n", values);
			throw new XbimException($"Model has {source.Count()} validation error(s): \n{arg}");
		}
		return builder;
	}
}
