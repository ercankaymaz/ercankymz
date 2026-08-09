using System;
using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.Fluent;

public interface IModelFileBuilder
{
	IModel Model { get; }

	ITransaction Transaction { get; }

	EntityCreator Factory { get; }

	XbimEditorCredentials? Editor { get; }

	IIfcOwnerHistory? OwnerHistory { get; set; }

	DateTime EffectiveDateTime { get; }

	void NewTransaction(string name = "");
}
