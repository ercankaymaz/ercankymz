namespace Basler.Pylon;

public enum GrabStopReason
{
	UserRequest = 1,
	GrabEngineError = -1,
	GrabStartedEventException = -2
}
