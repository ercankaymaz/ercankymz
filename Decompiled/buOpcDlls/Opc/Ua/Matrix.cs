using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Matrix : ICloneable, IFormattable
{
	public delegate bool ValidateDimensionsFunction(int idx, Int32Collection dimensions);

	private Array m_elements;

	private int[] m_dimensions;

	private TypeInfo m_typeInfo;

	public Array Elements => m_elements;

	public int[] Dimensions => m_dimensions;

	public TypeInfo TypeInfo => m_typeInfo;

	public Matrix(Array value, BuiltInType builtInType)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		m_elements = value;
		m_dimensions = new int[value.Rank];
		for (int i = 0; i < m_dimensions.Length; i++)
		{
			m_dimensions[i] = value.GetLength(i);
		}
		m_elements = Utils.FlattenArray(value);
		m_typeInfo = new TypeInfo(builtInType, m_dimensions.Length);
	}

	public Matrix(Array elements, BuiltInType builtInType, params int[] dimensions)
	{
		if (elements == null)
		{
			throw new ArgumentNullException("elements");
		}
		m_elements = elements;
		m_dimensions = dimensions;
		if (dimensions != null && dimensions.Length != 0)
		{
			if (ValidateDimensions(dimensions).flatLength != elements.Length)
			{
				throw new ArgumentException("The number of elements in the array does not match the dimensions.");
			}
		}
		else
		{
			m_dimensions = new int[1] { elements.Length };
		}
		m_typeInfo = new TypeInfo(builtInType, m_dimensions.Length);
	}

	public Array ToArray()
	{
		try
		{
			Array array = Array.CreateInstance(m_elements.GetType().GetElementType(), m_dimensions);
			int[] array2 = new int[m_dimensions.Length];
			for (int i = 0; i < m_elements.Length; i++)
			{
				array.SetValue(m_elements.GetValue(i), array2);
				for (int num = array2.Length - 1; num >= 0; num--)
				{
					array2[num]++;
					if (array2[num] < m_dimensions[num])
					{
						break;
					}
					array2[num] = 0;
				}
			}
			return array;
		}
		catch (OutOfMemoryException ex)
		{
			throw ServiceResultException.Create(2148007936u, ex.Message);
		}
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		if (obj is Matrix matrix)
		{
			if (!m_typeInfo.Equals(matrix.TypeInfo))
			{
				return false;
			}
			if (!Utils.IsEqual(m_dimensions, matrix.Dimensions))
			{
				return false;
			}
			return Utils.IsEqual(m_elements, matrix.Elements);
		}
		return false;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		if (m_elements != null)
		{
			hashCode.Add(m_elements);
		}
		if (m_typeInfo != null)
		{
			hashCode.Add(m_typeInfo);
		}
		if (m_dimensions != null)
		{
			hashCode.Add(m_dimensions);
		}
		return hashCode.ToHashCode();
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}[", m_elements.GetType().GetElementType().Name);
			for (int i = 0; i < m_dimensions.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.AppendFormat(formatProvider, "{0}", m_dimensions[i]);
			}
			stringBuilder.AppendFormat(formatProvider, "]");
			return stringBuilder.ToString();
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new Matrix((Array)Utils.Clone(m_elements), m_typeInfo.BuiltInType, (int[])Utils.Clone(m_dimensions));
	}

	[Conditional("DEBUG")]
	private static void SanityCheckArrayElements(Array elements, BuiltInType builtInType)
	{
	}

	public static (bool valid, int flatLength) ValidateDimensions(bool allowZeroDimension, Int32Collection dimensions, int maxArrayLength)
	{
		return ValidateDimensions(dimensions, maxArrayLength, ValidateWithSideEffect);
		bool ValidateWithSideEffect(int i, Int32Collection dimCollection)
		{
			if (allowZeroDimension ? (dimCollection[i] < 0) : (dimCollection[i] <= 0))
			{
				Utils.LogTrace("ReadArray read dimensions[{0}] = {1}. Matrix will have 0 elements.", i, dimCollection);
				dimCollection[i] = 0;
				return false;
			}
			if (maxArrayLength > 0 && dimCollection[i] > maxArrayLength)
			{
				throw ServiceResultException.Create(2148007936u, "ArrayDimensions [{0}] = {1} is greater than MaxArrayLength {2}.", i, dimCollection[i], maxArrayLength);
			}
			return true;
		}
	}

	public static (bool valid, int flatLength) ValidateDimensions(Int32Collection dimensions, int flatLength, int maxArrayLength)
	{
		return ValidateDimensions(dimensions, maxArrayLength, ValidateAgainstExpectedFlatLength);
		bool ValidateAgainstExpectedFlatLength(int i, Int32Collection dimCollection)
		{
			if (dimCollection[i] == 0 && flatLength > 0)
			{
				throw new ServiceResultException(2147942400u, Utils.Format("ArrayDimensions [{0}] is zero in Variant object.", i));
			}
			if (dimCollection[i] > flatLength && flatLength > 0)
			{
				throw new ServiceResultException(2147942400u, Utils.Format("ArrayDimensions [{0}] = {1} is greater than length {2}.", i, dimCollection[i], flatLength));
			}
			return true;
		}
	}

	public static (bool valid, int flatLength) ValidateDimensions(Int32Collection dimensions)
	{
		return ValidateDimensions(dimensions, 0, null);
	}

	private static (bool valid, int flatLength) ValidateDimensions(Int32Collection dimensions, int maxArrayLength, ValidateDimensionsFunction customValidation)
	{
		bool flag = false;
		int num = 1;
		try
		{
			for (int i = 0; i < dimensions.Count; i++)
			{
				if (customValidation != null)
				{
					flag = customValidation(i, dimensions);
					if (!flag)
					{
						return (valid: flag, flatLength: 0);
					}
				}
				num = checked(num * dimensions[i]);
			}
		}
		catch (OverflowException)
		{
			throw new ArgumentException("The dimensions of the matrix are invalid and overflow when used to calculate the size.");
		}
		if (maxArrayLength > 0 && num > maxArrayLength)
		{
			throw ServiceResultException.Create(2148007936u, "Maximum array length of {0} was exceeded while summing up to {1} from the array dimensions", maxArrayLength, num);
		}
		return (valid: flag, flatLength: num);
	}
}
