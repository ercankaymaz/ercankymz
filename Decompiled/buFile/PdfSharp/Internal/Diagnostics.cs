namespace PdfSharp.Internal;

internal static class Diagnostics
{
	private static NotImplementedBehaviour _notImplementedBehaviour;

	public static NotImplementedBehaviour NotImplementedBehaviour
	{
		get
		{
			return _notImplementedBehaviour;
		}
		set
		{
			_notImplementedBehaviour = value;
		}
	}
}
