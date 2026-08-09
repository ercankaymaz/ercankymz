using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IBooleanParameter : IParameter
{
	void SetValue([MarshalAs(UnmanagedType.U1)] bool value);

	[return: MarshalAs(UnmanagedType.U1)]
	bool GetValue();
}
