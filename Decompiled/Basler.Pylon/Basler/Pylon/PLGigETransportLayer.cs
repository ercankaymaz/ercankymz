namespace Basler.Pylon;

public static class PLGigETransportLayer
{
	public static IntegerName StatisticReadWriteTimeoutCount => (IntegerName)"@DeviceTransportLayer/StatisticReadWriteTimeoutCount";

	public static BooleanName CommandDuplicationEnable => (BooleanName)"@DeviceTransportLayer/CommandDuplicationEnable";

	public static IntegerName HeartbeatTimeout => (IntegerName)"@DeviceTransportLayer/HeartbeatTimeout";

	public static IntegerName MaxRetryCountWrite => (IntegerName)"@DeviceTransportLayer/MaxRetryCountWrite";

	public static IntegerName MaxRetryCountRead => (IntegerName)"@DeviceTransportLayer/MaxRetryCountRead";

	public static IntegerName WriteTimeout => (IntegerName)"@DeviceTransportLayer/WriteTimeout";

	public static IntegerName ReadTimeout => (IntegerName)"@DeviceTransportLayer/ReadTimeout";
}
