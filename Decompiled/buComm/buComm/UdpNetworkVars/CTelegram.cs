namespace buComm.UdpNetworkVars;

public class CTelegram
{
	public byte[] Identity = new byte[4] { 0, 45, 83, 51 };

	public uint ID = 0u;

	public ushort Index = 1;

	public ushort SubIndex;

	public ushort Items;

	public ushort Length;

	public ushort Counter;

	public byte Flags;

	public byte Checksum;

	public byte[] Data;
}
