using System;

namespace ModuleWorks;

[Serializable]
public struct ThreadTapSolidParameters<T>
{
	public enum Direction
	{
		LeftHanded,
		RightHanded
	}

	public T OuterRadius { get; set; }

	public T InnerRadius { get; set; }

	public T Height { get; set; }

	public T Pitch { get; set; }

	public Direction ThreadDirection { get; set; }
}
