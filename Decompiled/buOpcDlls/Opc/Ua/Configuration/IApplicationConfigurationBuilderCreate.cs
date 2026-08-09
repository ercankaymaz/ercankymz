using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderCreate
{
	Task<ApplicationConfiguration> Create();
}
