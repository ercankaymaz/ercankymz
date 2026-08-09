using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface ICommandParameter : IParameter
{
	void Execute();

	[return: MarshalAs(UnmanagedType.U1)]
	bool IsExecuting();
}
