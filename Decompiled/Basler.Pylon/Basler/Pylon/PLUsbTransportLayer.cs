namespace Basler.Pylon;

public static class PLUsbTransportLayer
{
	public static StringName Statistic_Last_Error_Status_Text => (StringName)"@DeviceTransportLayer/Statistic_Last_Error_Status_Text";

	public static IntegerName Statistic_Last_Error_Status => (IntegerName)"@DeviceTransportLayer/Statistic_Last_Error_Status";

	public static IntegerName Statistic_Write_Operations_Failed_Count => (IntegerName)"@DeviceTransportLayer/Statistic_Write_Operations_Failed_Count";

	public static IntegerName Statistic_Read_Operations_Failed_Count => (IntegerName)"@DeviceTransportLayer/Statistic_Read_Operations_Failed_Count";

	public static IntegerName Statistic_Write_Pipe_Reset_Count => (IntegerName)"@DeviceTransportLayer/Statistic_Write_Pipe_Reset_Count";

	public static IntegerName Statistic_Read_Pipe_Reset_Count => (IntegerName)"@DeviceTransportLayer/Statistic_Read_Pipe_Reset_Count";

	public static BooleanName MigrationModeEnable => (BooleanName)"@DeviceTransportLayer/MigrationModeEnable";
}
