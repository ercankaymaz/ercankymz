using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;

namespace System.ComponentModel.Composition.ReflectionModel;

internal sealed class ReflectionMemberExportDefinition : ExportDefinition, ICompositionElement
{
	private readonly LazyMemberInfo _member;

	private readonly ExportDefinition _exportDefinition;

	private readonly ICompositionElement _origin;

	private IDictionary<string, object> _metadata;

	public override string ContractName => _exportDefinition.ContractName;

	public LazyMemberInfo ExportingLazyMember => _member;

	public override IDictionary<string, object?> Metadata => _metadata ?? (_metadata = _exportDefinition.Metadata.AsReadOnly());

	string ICompositionElement.DisplayName => GetDisplayName();

	ICompositionElement? ICompositionElement.Origin => _origin;

	public ReflectionMemberExportDefinition(LazyMemberInfo member, ExportDefinition exportDefinition, ICompositionElement? origin)
	{
		ArgumentNullException.ThrowIfNull(exportDefinition, "exportDefinition");
		_member = member;
		_exportDefinition = exportDefinition;
		_origin = origin;
	}

	public override string ToString()
	{
		return GetDisplayName();
	}

	public int GetIndex()
	{
		return ExportingLazyMember.ToReflectionMember().UnderlyingMember.MetadataToken;
	}

	public ExportingMember ToExportingMember()
	{
		return new ExportingMember(this, ToReflectionMember());
	}

	private ReflectionMember ToReflectionMember()
	{
		return ExportingLazyMember.ToReflectionMember();
	}

	private string GetDisplayName()
	{
		return ToReflectionMember().GetDisplayName() + " (ContractName=\"" + ContractName + "\")";
	}
}
