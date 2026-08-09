using System;
using Xbim.Common;

namespace Xbim.Ifc.Fluent.Internal;

internal class StableGuidGenerator : IGuidGenerator
{
	private readonly Guid baseGuid;

	public StableGuidGenerator(Guid baseGuid)
	{
		this.baseGuid = baseGuid;
	}

	public Guid GenerateForEntity(IPersistEntity entity)
	{
		if (entity.EntityLabel == 0)
		{
			return Guid.NewGuid();
		}
		Guid guid = baseGuid;
		byte[] array = guid.ToByteArray();
		byte[] bytes = BitConverter.GetBytes((long)entity.EntityLabel);
		if (!BitConverter.IsLittleEndian)
		{
			Array.Reverse((Array)bytes);
		}
		for (int i = 0; i < 8; i++)
		{
			array[15 - i] = bytes[i];
		}
		return new Guid(array);
	}
}
