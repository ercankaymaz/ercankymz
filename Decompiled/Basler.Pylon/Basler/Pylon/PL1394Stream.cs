using System.ComponentModel;

namespace Basler.Pylon;

public static class PL1394Stream
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class StatusEnum : ParameterListEnum
	{
		public override string Name => "@StreamGrabber0/Status";

		public string Invalid => "Invalid";

		public string Locked => "Locked";

		public string Open => "Open";

		public string Closed => "Closed";

		public override string ToString()
		{
			return Name;
		}
	}

	public static StatusEnum Status => new StatusEnum();

	public static IntegerName ThreadPriority => (IntegerName)"@StreamGrabber0/ThreadPriority";

	public static BooleanName ThreadPriorityOverride => (BooleanName)"@StreamGrabber0/ThreadPriorityOverride";

	public static IntegerName ThreadTimeout => (IntegerName)"@StreamGrabber0/ThreadTimeout";

	public static IntegerName MaxBufferSize => (IntegerName)"@StreamGrabber0/MaxBufferSize";

	public static IntegerName MaxNumBuffer => (IntegerName)"@StreamGrabber0/MaxNumBuffer";
}
