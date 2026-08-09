using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Reflection;

namespace System.ComponentModel.Composition.AttributedModel;

internal sealed class AttributedExportDefinition : ExportDefinition
{
	private readonly AttributedPartCreationInfo _partCreationInfo;

	private readonly MemberInfo _member;

	private readonly ExportAttribute _exportAttribute;

	private readonly Type _typeIdentityType;

	private IDictionary<string, object> _metadata;

	public override IDictionary<string, object?> Metadata
	{
		get
		{
			if (_metadata == null)
			{
				_member.TryExportMetadataForMember(out IDictionary<string, object> dictionary);
				string value = (_exportAttribute.IsContractNameSameAsTypeIdentity() ? ContractName : _member.GetTypeIdentityFromExport(_typeIdentityType));
				dictionary.Add("ExportTypeIdentity", value);
				IDictionary<string, object> metadata = _partCreationInfo.GetMetadata();
				if (metadata != null && metadata.TryGetValue("System.ComponentModel.Composition.CreationPolicy", out var value2))
				{
					dictionary.Add("System.ComponentModel.Composition.CreationPolicy", value2);
				}
				if (_typeIdentityType != null && _member.MemberType != MemberTypes.Method && _typeIdentityType.ContainsGenericParameters)
				{
					dictionary.Add("System.ComponentModel.Composition.GenericExportParametersOrderMetadataName", GenericServices.GetGenericParametersOrder(_typeIdentityType));
				}
				_metadata = dictionary;
			}
			return _metadata;
		}
	}

	public AttributedExportDefinition(AttributedPartCreationInfo partCreationInfo, MemberInfo member, ExportAttribute exportAttribute, Type? typeIdentityType, string contractName)
		: base(contractName, null)
	{
		ArgumentNullException.ThrowIfNull(partCreationInfo, "partCreationInfo");
		ArgumentNullException.ThrowIfNull(member, "member");
		ArgumentNullException.ThrowIfNull(exportAttribute, "exportAttribute");
		_partCreationInfo = partCreationInfo;
		_member = member;
		_exportAttribute = exportAttribute;
		_typeIdentityType = typeIdentityType;
	}
}
