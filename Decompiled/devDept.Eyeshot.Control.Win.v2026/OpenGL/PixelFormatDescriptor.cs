using System.Runtime.InteropServices;

namespace OpenGL;

[StructLayout(LayoutKind.Sequential)]
public class PixelFormatDescriptor
{
	public short Size = 40;

	public short Version = 1;

	public int dwFlags;

	public byte PixelType;

	public byte ColorBits;

	public byte RedBits;

	public byte RedShift;

	public byte GreenBits;

	public byte GreenShift;

	public byte BlueBits;

	public byte BlueShift;

	public byte AlphaBits;

	public byte AlphaShift;

	public byte AccumBits;

	public byte AccumRedBits;

	public byte AccumGreenBits;

	public byte AccumBlueBits;

	public byte AccumAlphaBits;

	public byte DepthBits;

	public byte StencilBits;

	public byte AuxBuffers;

	public byte LayerType;

	public byte Reserved;

	public int dwLayerMask;

	public int dwVisibleMask;

	public int dwDamageMask;
}
