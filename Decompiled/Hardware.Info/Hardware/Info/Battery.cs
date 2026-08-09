using System;

namespace Hardware.Info;

public class Battery
{
	private string _batteryStatusDescription = string.Empty;

	public uint FullChargeCapacity { get; set; }

	public uint DesignCapacity { get; set; }

	public ushort BatteryStatus { get; set; }

	public ushort EstimatedChargeRemaining { get; set; }

	public uint EstimatedRunTime { get; set; }

	public uint ExpectedLife { get; set; }

	public uint MaxRechargeTime { get; set; }

	public uint TimeOnBattery { get; set; }

	public uint TimeToFullCharge { get; set; }

	public string BatteryStatusDescription
	{
		get
		{
			if (!string.IsNullOrEmpty(_batteryStatusDescription))
			{
				return _batteryStatusDescription;
			}
			return BatteryStatus switch
			{
				1 => "The battery is discharging", 
				2 => "The system has access to AC so no battery is being discharged. However, the battery is not necessarily charging.", 
				3 => "Fully Charged", 
				4 => "Low", 
				5 => "Critical", 
				6 => "Charging", 
				7 => "Charging and High", 
				8 => "Charging and Low", 
				9 => "Charging and Critical", 
				10 => "No battery is installed", 
				11 => "Partially Charged", 
				_ => string.Empty, 
			};
		}
		set
		{
			_batteryStatusDescription = value;
		}
	}

	public override string ToString()
	{
		return "FullChargeCapacity: " + FullChargeCapacity + Environment.NewLine + "DesignCapacity: " + DesignCapacity + Environment.NewLine + "BatteryStatusDescription: " + BatteryStatusDescription + Environment.NewLine + "EstimatedChargeRemaining: " + EstimatedChargeRemaining + Environment.NewLine + "EstimatedRunTime: " + EstimatedRunTime + Environment.NewLine + "ExpectedLife: " + ExpectedLife + Environment.NewLine + "MaxRechargeTime: " + MaxRechargeTime + Environment.NewLine + "TimeOnBattery: " + TimeOnBattery + Environment.NewLine + "TimeToFullCharge: " + TimeToFullCharge + Environment.NewLine;
	}
}
