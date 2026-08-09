using System.ComponentModel;

namespace Basler.Pylon;

public static class PLGigEEventGrabber
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class StatusEnum : ParameterListEnum
	{
		public override string Name => "@EventGrabber/Status";

		public string Open => "Open";

		public string Closed => "Closed";

		public override string ToString()
		{
			return Name;
		}
	}

	public static StatusEnum Status => new StatusEnum();

	public static IntegerName RetryCount => (IntegerName)"@EventGrabber/RetryCount";

	public static IntegerName Timeout => (IntegerName)"@EventGrabber/Timeout";

	public static IntegerName NumBuffer => (IntegerName)"@EventGrabber/NumBuffer";
}
