using System.ComponentModel.Composition.Primitives;

namespace System.ComponentModel.Composition.ReflectionModel;

internal sealed class ImportingParameter : ImportingItem
{
	public ImportingParameter(ContractBasedImportDefinition definition, ImportType importType)
		: base(definition, importType)
	{
	}
}
