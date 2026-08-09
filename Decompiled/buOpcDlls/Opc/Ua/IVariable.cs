using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IVariable : IVariableBase, ILocalNode, INode
{
	byte AccessLevel { get; set; }

	byte UserAccessLevel { get; set; }

	double MinimumSamplingInterval { get; set; }

	bool Historizing { get; set; }
}
