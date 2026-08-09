using System;

namespace SixLabors.ImageSharp.Metadata.Profiles.Icc;

internal readonly struct IccProfileDescription(uint deviceManufacturer, uint deviceModel, IccDeviceAttribute deviceAttributes, IccProfileTag technologyInformation, IccLocalizedString[] deviceManufacturerInfo, IccLocalizedString[] deviceModelInfo) : IEquatable<IccProfileDescription>
{
	public uint DeviceManufacturer { get; } = deviceManufacturer;

	public uint DeviceModel { get; } = deviceModel;

	public IccDeviceAttribute DeviceAttributes { get; } = deviceAttributes;

	public IccProfileTag TechnologyInformation { get; } = technologyInformation;

	public IccLocalizedString[] DeviceManufacturerInfo { get; } = deviceManufacturerInfo ?? throw new ArgumentNullException("deviceManufacturerInfo");

	public IccLocalizedString[] DeviceModelInfo { get; } = deviceModelInfo ?? throw new ArgumentNullException("deviceModelInfo");

	public bool Equals(IccProfileDescription other)
	{
		if (DeviceManufacturer == other.DeviceManufacturer && DeviceModel == other.DeviceModel && DeviceAttributes == other.DeviceAttributes && TechnologyInformation == other.TechnologyInformation && MemoryExtensions.SequenceEqual<IccLocalizedString>(MemoryExtensions.AsSpan<IccLocalizedString>(DeviceManufacturerInfo), (ReadOnlySpan<IccLocalizedString>)other.DeviceManufacturerInfo))
		{
			return MemoryExtensions.SequenceEqual<IccLocalizedString>(MemoryExtensions.AsSpan<IccLocalizedString>(DeviceModelInfo), (ReadOnlySpan<IccLocalizedString>)other.DeviceModelInfo);
		}
		return false;
	}

	public override bool Equals(object? obj)
	{
		if (obj is IccProfileDescription other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(DeviceManufacturer, DeviceModel, DeviceAttributes, TechnologyInformation, DeviceManufacturerInfo, DeviceModelInfo);
	}
}
