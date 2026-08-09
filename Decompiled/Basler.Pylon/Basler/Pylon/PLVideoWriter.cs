using System.ComponentModel;

namespace Basler.Pylon;

public static class PLVideoWriter
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class CompressionModeEnum : ParameterListEnum
	{
		public override string Name => "@VideoWriter/CompressionMode";

		public string Quality => "Quality";

		public string Bitrate => "Bitrate";

		public override string ToString()
		{
			return Name;
		}
	}

	private static CompressionModeEnum m_CompressionModeCached = null;

	public static IntegerName Width => new IntegerName("@VideoWriter/Width");

	public static IntegerName ThreadCount => new IntegerName("@VideoWriter/ThreadCount");

	public static FloatName Quality => new FloatName("@VideoWriter/Quality");

	public static FloatName PlaybackFrameRate => new FloatName("@VideoWriter/PlaybackFrameRate");

	public static IntegerName Height => new IntegerName("@VideoWriter/Height");

	public static IntegerName FrameCount => new IntegerName("@VideoWriter/FrameCount");

	public static CompressionModeEnum CompressionMode
	{
		get
		{
			if (m_CompressionModeCached == null)
			{
				m_CompressionModeCached = new CompressionModeEnum();
			}
			return m_CompressionModeCached;
		}
	}

	public static IntegerName BytesWritten => new IntegerName("@VideoWriter/BytesWritten");

	public static IntegerName Bitrate => new IntegerName("@VideoWriter/Bitrate");
}
