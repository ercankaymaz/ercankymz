using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using SharpGLTF.Schema2;

namespace SharpGLTF;

[DebuggerStepThrough]
internal static class Guard
{
	private static readonly IReadOnlyList<char> _InvalidRelativePathChars = (from c in Path.GetInvalidFileNameChars()
		where c != '/' && c != '\\'
		select c).ToArray();

	public static void NotNullOrEmpty(string target, string parameterName, string message = "")
	{
		if (target == null)
		{
			throw new ArgumentNullException(parameterName, message);
		}
		if (!string.IsNullOrWhiteSpace(target))
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(message))
		{
			message = parameterName + " cannot be null or empty and cannot contain only blanks.";
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void FileNameMustBeValid(string fileName, string parameterName, string message = "")
	{
		NotNullOrEmpty(fileName, parameterName, message);
		char[] invalid = Path.GetInvalidFileNameChars();
		if (!fileName.Any((char c) => Enumerable.Contains(invalid, c)))
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(message))
		{
			message = fileName + " is invalid or does not exist.";
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void FilePathMustBeValid(string filePath, string parameterName, string message = "")
	{
		NotNullOrEmpty(filePath, parameterName, message);
		filePath = Path.GetFullPath(filePath);
		bool flag = false;
		flag |= filePath.EndsWith(new string(Path.DirectorySeparatorChar, 1), StringComparison.Ordinal);
		if (!(flag | filePath.EndsWith(new string(Path.AltDirectorySeparatorChar, 1), StringComparison.Ordinal)))
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(message))
		{
			message = filePath + " is invalid or does not exist.";
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void FilePathMustExist(string filePath, string parameterName, string message = "")
	{
		if (File.Exists(filePath))
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(message))
		{
			message = filePath + " is invalid or does not exist.";
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void DirectoryPathMustExist(string dirPath, string parameterName, string message = "")
	{
		if (Directory.Exists(dirPath))
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(message))
		{
			message = dirPath + " is invalid or does not exist.";
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void MustExist(FileInfo finfo, string parameterName, string message = "")
	{
		if (finfo == null)
		{
			throw new ArgumentNullException("finfo");
		}
		if (finfo.Exists)
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(message))
		{
			message = finfo.FullName + " is invalid or does not exist.";
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void MustExist(DirectoryInfo dinfo, string parameterName, string message = "")
	{
		if (dinfo == null)
		{
			throw new ArgumentNullException("dinfo");
		}
		if (dinfo.Exists)
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(message))
		{
			message = dinfo.FullName + " is invalid or does not exist.";
		}
		throw new ArgumentException(message, parameterName);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NotNull(object target, string parameterName)
	{
		if (target == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void NotNull(object target, string parameterName, string message)
	{
		if (target == null)
		{
			throw new ArgumentNullException(parameterName, message);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void MustBeNull(object target, string parameterName, string message = "")
	{
		if (target == null)
		{
			return;
		}
		throw new ArgumentException(parameterName, message);
	}

	public static void NotNullOrEmpty<T>(IEnumerable<T> target, string parameterName, string message = "")
	{
		if (target == null)
		{
			throw new ArgumentNullException(parameterName, message);
		}
		if (target.Any())
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(message))
		{
			message = parameterName + " cannot be empty.";
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void MustBeEqualTo<TValue>(TValue value, TValue expected, string parameterName) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(expected) == 0)
		{
			return;
		}
		throw new ArgumentException(parameterName, $"{parameterName} {value} must be equal to {expected}.");
	}

	public static void MustBePositiveAndMultipleOf(int value, int padding, string parameterName, string message = "")
	{
		if (value < 0)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				message = parameterName + " must not be negative";
			}
			throw new ArgumentOutOfRangeException(message, parameterName);
		}
		if (value % padding != 0)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				message = $"{parameterName} is {value}; expected to be multiple of {padding}";
			}
			throw new ArgumentOutOfRangeException(message, parameterName);
		}
	}

	public static void MustBeLessThan<TValue>(TValue value, TValue max, string parameterName) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(max) < 0)
		{
			return;
		}
		throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} {value} must be less than {max}.");
	}

	public static void MustBeLessThanOrEqualTo<TValue>(TValue value, TValue max, string parameterName) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(max) > 0)
		{
			throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} {value} must be less than or equal to {max}.");
		}
	}

	public static void MustBeGreaterThan<TValue>(TValue value, TValue min, string parameterName) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(min) > 0)
		{
			return;
		}
		throw new ArgumentOutOfRangeException(parameterName, $"Value {value} must be greater than {min}.");
	}

	public static void MustBeGreaterThanOrEqualTo<TValue>(TValue value, TValue min, string parameterName) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(min) >= 0)
		{
			return;
		}
		throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} {value} must be greater than or equal to {min}.");
	}

	public static void MustBeBetweenOrEqualTo<TValue>(TValue value, TValue minInclusive, TValue maxInclusive, string parameterName) where TValue : IComparable<TValue>
	{
		if (value.CompareTo(minInclusive) >= 0 && value.CompareTo(maxInclusive) <= 0)
		{
			return;
		}
		throw new ArgumentOutOfRangeException(parameterName, $"{parameterName} {value} must be greater than or equal to {minInclusive} and less than or equal to {maxInclusive}.");
	}

	public static void IsTrue(bool target, string parameterName, string message = "")
	{
		if (target)
		{
			return;
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void IsFalse(bool target, string parameterName, string message = "")
	{
		if (!target)
		{
			return;
		}
		throw new ArgumentException(message, parameterName);
	}

	public static void IsValidURI(string parameterName, string gltfURI, params string[] validHeaders)
	{
		if (string.IsNullOrEmpty(gltfURI))
		{
			return;
		}
		foreach (string text in validHeaders)
		{
			if (gltfURI.StartsWith(text, StringComparison.OrdinalIgnoreCase))
			{
				string value = text + ",";
				if (gltfURI.StartsWith(value, StringComparison.OrdinalIgnoreCase) || gltfURI.StartsWith(text + ";base64,", StringComparison.OrdinalIgnoreCase))
				{
					return;
				}
				throw new ArgumentException(parameterName + " has invalid URI '" + gltfURI + "'.");
			}
		}
		if (gltfURI.Any((char c) => _InvalidRelativePathChars.Contains(c)))
		{
			throw new ArgumentException("Invalid URI '" + gltfURI + "'.");
		}
		if (gltfURI.Any((char chr) => char.IsWhiteSpace(chr)))
		{
			gltfURI = gltfURI._EscapeStringInternal();
		}
		if (Uri.TryCreate(gltfURI, UriKind.Relative, out Uri _))
		{
			return;
		}
		throw new ArgumentException("Invalid URI '" + gltfURI + "'.");
	}

	public static void MustShareLogicalParent(LogicalChildOfRoot a, LogicalChildOfRoot b, string parameterName)
	{
		MustShareLogicalParent(a?.LogicalParent, "LogicalParent", b, parameterName);
	}

	public static void MustShareLogicalParent(ModelRoot a, string aName, LogicalChildOfRoot b, string bName)
	{
		if (a == null)
		{
			throw new ArgumentNullException(aName);
		}
		if (b == null)
		{
			throw new ArgumentNullException(bName);
		}
		if (a != b.LogicalParent)
		{
			throw new ArgumentException("LogicalParent mismatch", bName);
		}
	}

	public static void HasDynamicallyAccessedMembers(Type t, bool hasConstructors, bool hasMethods, bool hasProperties, bool hasFields, string parameterName)
	{
	}
}
