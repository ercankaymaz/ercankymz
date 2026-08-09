using System;
using Xbim.Common;
using Xbim.Ifc.Fluent.Internal;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.Fluent;

internal class ModelFileBuilder : IModelFileBuilder, IDisposable
{
	private bool disposedValue;

	private readonly FluentModelBuilder parent;

	public IModel Model { get; }

	public EntityCreator Factory { get; }

	public ITransaction Transaction { get; private set; }

	public XbimEditorCredentials? Editor => parent.Editor;

	public IIfcOwnerHistory? OwnerHistory { get; set; }

	public DateTime EffectiveDateTime => parent.DateTimeGenerator.Generate();

	private IGuidGenerator GuidGenerator => parent.GuidGenerator;

	public ModelFileBuilder(FluentModelBuilder parent, IModel model)
	{
		this.parent = parent;
		Model = model;
		Factory = new EntityCreator(model);
		Transaction = Model.BeginTransaction("Fluent Builder");
		model.EntityNew += EntityAdded;
	}

	public void NewTransaction(string name = "")
	{
		if (Model.CurrentTransaction != null)
		{
			throw new InvalidOperationException("A transaction already exists");
		}
		Transaction = Model.BeginTransaction(name ?? "Fluent Builder");
	}

	private void EntityAdded(IPersistEntity entity)
	{
		IIfcRoot root = entity as IIfcRoot;
		if (root != null)
		{
			root.WithDefaults((EntityDefaults t) => t with
			{
				GlobalId = GuidGenerator.GenerateForEntity(root),
				OwnerHistory = OwnerHistory
			});
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposedValue)
		{
			if (disposing)
			{
				Model.EntityNew -= EntityAdded;
				Transaction.Dispose();
				Model.Dispose();
			}
			disposedValue = true;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
