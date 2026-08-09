using System;
using Xbim.Common;
using Xbim.Common.Step21;
using Xbim.IO.Memory;
using Xbim.Ifc.Fluent.Internal;
using Xbim.Ifc2x3;
using Xbim.Ifc4;
using Xbim.Ifc4x3;

namespace Xbim.Ifc.Fluent;

public class FluentModelBuilder
{
	public XbimEditorCredentials? Editor { get; private set; }

	internal IGuidGenerator GuidGenerator { get; private set; }

	internal IDateTimeGenerator DateTimeGenerator { get; private set; }

	public FluentModelBuilder()
	{
		GuidGenerator = new StandardGuidGenerator();
		DateTimeGenerator = new StandardDateTimeGenerator();
	}

	public IModelFileBuilder CreateModel(XbimSchemaVersion schemaVersion = XbimSchemaVersion.Ifc2X3)
	{
		MemoryModel model = new MemoryModel(GetFactory(schemaVersion));
		return new ModelFileBuilder(this, model);
	}

	public FluentModelBuilder AssignEditor(XbimEditorCredentials editor)
	{
		Editor = editor;
		return this;
	}

	private IEntityFactory GetFactory(XbimSchemaVersion schemaVersion)
	{
		return schemaVersion switch
		{
			XbimSchemaVersion.Ifc2X3 => new EntityFactoryIfc2x3(), 
			XbimSchemaVersion.Ifc4 => new EntityFactoryIfc4(), 
			XbimSchemaVersion.Ifc4x1 => new EntityFactoryIfc4x1(), 
			XbimSchemaVersion.Ifc4x3 => new EntityFactoryIfc4x3Add2(), 
			_ => throw new NotSupportedException(schemaVersion.ToString()), 
		};
	}

	public FluentModelBuilder UseStableGuids(Guid baseGuid)
	{
		GuidGenerator = new StableGuidGenerator(baseGuid);
		return this;
	}

	public FluentModelBuilder UseStandardGuids()
	{
		GuidGenerator = new StandardGuidGenerator();
		return this;
	}

	public FluentModelBuilder UseStableDateTime(DateTime baseDateTime)
	{
		DateTimeGenerator = new StableDateTimeGenerator(baseDateTime);
		return this;
	}

	public FluentModelBuilder UseStandardDateTime()
	{
		DateTimeGenerator = new StandardDateTimeGenerator();
		return this;
	}
}
