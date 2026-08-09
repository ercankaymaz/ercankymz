namespace Basler.Pylon;

public static class PLCameraInstance
{
	public static BooleanName UseExtendedIdIfAvailable => new BooleanName("@CameraInstance/UseExtendedIdIfAvailable");

	public static IntegerName StaticChunkNodeMapPoolSize => new IntegerName("@CameraInstance/StaticChunkNodeMapPoolSize");

	public static IntegerName OutputQueueSize => new IntegerName("@CameraInstance/OutputQueueSize");

	public static IntegerName NumReadyBuffers => new IntegerName("@CameraInstance/NumReadyBuffers");

	public static IntegerName NumQueuedBuffers => new IntegerName("@CameraInstance/NumQueuedBuffers");

	public static IntegerName NumEmptyBuffers => new IntegerName("@CameraInstance/NumEmptyBuffers");

	public static BooleanName MonitorModeActive => new BooleanName("@CameraInstance/MonitorModeActive");

	public static BooleanName MigrationModeActive => new BooleanName("@CameraInstance/MigrationModeActive");

	public static IntegerName MaxNumQueuedBuffer => new IntegerName("@CameraInstance/MaxNumQueuedBuffer");

	public static IntegerName MaxNumGrabResults => new IntegerName("@CameraInstance/MaxNumGrabResults");

	public static IntegerName MaxNumBuffer => new IntegerName("@CameraInstance/MaxNumBuffer");

	public static BooleanName InternalGrabEngineThreadPriorityOverride => new BooleanName("@CameraInstance/InternalGrabEngineThreadPriorityOverride");

	public static IntegerName InternalGrabEngineThreadPriority => new IntegerName("@CameraInstance/InternalGrabEngineThreadPriority");

	public static BooleanName GrabLoopThreadUseTimeout => new BooleanName("@CameraInstance/GrabLoopThreadUseTimeout");

	public static IntegerName GrabLoopThreadTimeout => new IntegerName("@CameraInstance/GrabLoopThreadTimeout");

	public static BooleanName GrabLoopThreadPriorityOverride => new BooleanName("@CameraInstance/GrabLoopThreadPriorityOverride");

	public static IntegerName GrabLoopThreadPriority => new IntegerName("@CameraInstance/GrabLoopThreadPriority");

	public static BooleanName GrabCameraEvents => new BooleanName("@CameraInstance/GrabCameraEvents");

	public static BooleanName ClearBufferModeEnable => new BooleanName("@CameraInstance/ClearBufferModeEnable");

	public static BooleanName ChunkNodeMapsEnable => new BooleanName("@CameraInstance/ChunkNodeMapsEnable");

	public static BooleanName AcquisitionStartStopExecutionEnable => new BooleanName("@CameraInstance/AcquisitionStartStopExecutionEnable");
}
