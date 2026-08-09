using System.Runtime.InteropServices;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderTraceConfiguration : IApplicationConfigurationBuilderCreate
{
	IApplicationConfigurationBuilderTraceConfiguration SetOutputFilePath(string outputFilePath);

	IApplicationConfigurationBuilderTraceConfiguration SetDeleteOnLoad(bool deleteOnLoad);

	IApplicationConfigurationBuilderTraceConfiguration SetTraceMasks(int traceMasks);
}
