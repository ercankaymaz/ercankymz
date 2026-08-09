using System;

namespace ODA.PointCloud.RcsFileServices;

[Flags]
public enum OdPointCloudDataSource_Units
{
	kMillimeter = 0,
	kCentimeter = 1,
	kMeter = 2,
	kInch = 3,
	kFeet = 4,
	kUSFeet = 5
}
