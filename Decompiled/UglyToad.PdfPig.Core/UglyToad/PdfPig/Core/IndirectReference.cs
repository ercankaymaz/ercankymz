using System;
using System.Diagnostics;

namespace UglyToad.PdfPig.Core;

public readonly struct IndirectReference : IEquatable<IndirectReference>
{
	private const int NUMBER_OFFSET = 16;

	private static readonly long GENERATION_MASK = (long)Math.Pow(2.0, 16.0) - 1;

	private static readonly long MAX_OBJECT_NUMBER = (long)(Math.Pow(2.0, 48.0) - 1.0) / 2;

	private readonly long numberAndGeneration;

	public long ObjectNumber => numberAndGeneration >> 16;

	public int Generation => (int)(numberAndGeneration & GENERATION_MASK);

	[DebuggerStepThrough]
	public IndirectReference(long objectNumber, int generation)
	{
		if (generation < 0)
		{
			throw new ArgumentOutOfRangeException("generation", "Generation number must not be a negative value.");
		}
		if (objectNumber < -MAX_OBJECT_NUMBER || objectNumber > MAX_OBJECT_NUMBER)
		{
			throw new ArgumentOutOfRangeException("objectNumber", $"Object number must be between -{MAX_OBJECT_NUMBER:##,###} and {MAX_OBJECT_NUMBER:##,###}.");
		}
		numberAndGeneration = ComputeInternalHash(objectNumber, generation);
	}

	private static long ComputeInternalHash(long num, int gen)
	{
		return (num << 16) | (gen & GENERATION_MASK);
	}

	public bool Equals(IndirectReference other)
	{
		return other.numberAndGeneration == numberAndGeneration;
	}

	public override bool Equals(object? obj)
	{
		if (obj is IndirectReference other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return numberAndGeneration.GetHashCode();
	}

	public override string ToString()
	{
		return $"{ObjectNumber} {Generation}";
	}

	public static bool operator ==(IndirectReference left, IndirectReference right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(IndirectReference left, IndirectReference right)
	{
		return !(left == right);
	}
}
