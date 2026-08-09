using System.Runtime.InteropServices;

namespace ModuleWorks;

internal class MarshalledDelegateTypes_003Cbool_002Cvoid_002Cvoid_002Cvoid_002Cvoid_002Cvoid_002Cvoid_002Cvoid_003E
{
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool Managed();

	public unsafe static delegate* unmanaged[Stdcall, Stdcall]<byte> Marshal(Managed @delegate)
	{
		if (@delegate == null)
		{
			return null;
		}
		return (delegate* unmanaged[Stdcall, Stdcall]<byte>)System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(@delegate).ToPointer();
	}
}
