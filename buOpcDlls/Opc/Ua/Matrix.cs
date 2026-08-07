// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Matrix
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Matrix : ICloneable, IFormattable
{
  private Array m_elements;
  private int[] m_dimensions;
  private TypeInfo m_typeInfo;

  public Matrix(Array value, BuiltInType builtInType)
  {
    this.m_elements = value != null ? value : throw new ArgumentNullException(nameof (value));
    this.m_dimensions = new int[value.Rank];
    for (int dimension = 0; dimension < this.m_dimensions.Length; ++dimension)
      this.m_dimensions[dimension] = value.GetLength(dimension);
    this.m_elements = Utils.FlattenArray(value);
    this.m_typeInfo = new TypeInfo(builtInType, this.m_dimensions.Length);
  }

  public Matrix(Array elements, BuiltInType builtInType, params int[] dimensions)
  {
    this.m_elements = elements != null ? elements : throw new ArgumentNullException(nameof (elements));
    this.m_dimensions = dimensions;
    if (dimensions != null && dimensions.Length != 0)
    {
      if (Matrix.ValidateDimensions((Int32Collection) dimensions).flatLength != elements.Length)
        throw new ArgumentException("The number of elements in the array does not match the dimensions.");
    }
    else
      this.m_dimensions = new int[1]{ elements.Length };
    this.m_typeInfo = new TypeInfo(builtInType, this.m_dimensions.Length);
  }

  public Array Elements => this.m_elements;

  public int[] Dimensions => this.m_dimensions;

  public TypeInfo TypeInfo => this.m_typeInfo;

  public Array ToArray()
  {
    try
    {
      Array instance = Array.CreateInstance(this.m_elements.GetType().GetElementType(), this.m_dimensions);
      int[] numArray = new int[this.m_dimensions.Length];
      for (int index1 = 0; index1 < this.m_elements.Length; ++index1)
      {
        instance.SetValue(this.m_elements.GetValue(index1), numArray);
        for (int index2 = numArray.Length - 1; index2 >= 0; --index2)
        {
          ++numArray[index2];
          if (numArray[index2] >= this.m_dimensions[index2])
            numArray[index2] = 0;
          else
            break;
        }
      }
      return instance;
    }
    catch (OutOfMemoryException ex)
    {
      throw ServiceResultException.Create(2148007936U /*0x80080000*/, ex.Message);
    }
  }

  public override bool Equals(object obj)
  {
    if (this == obj)
      return true;
    return obj is Matrix matrix && this.m_typeInfo.Equals((object) matrix.TypeInfo) && Utils.IsEqual((object) this.m_dimensions, (object) matrix.Dimensions) && Utils.IsEqual((object) this.m_elements, (object) matrix.Elements);
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    if (this.m_elements != null)
      hashCode.Add<Array>(this.m_elements);
    if (this.m_typeInfo != null)
      hashCode.Add<TypeInfo>(this.m_typeInfo);
    if (this.m_dimensions != null)
      hashCode.Add<int[]>(this.m_dimensions);
    return hashCode.ToHashCode();
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("{0}[", (object) this.m_elements.GetType().GetElementType().Name);
      for (int index = 0; index < this.m_dimensions.Length; ++index)
      {
        if (index > 0)
          stringBuilder.Append(',');
        stringBuilder.AppendFormat(formatProvider, "{0}", (object) this.m_dimensions[index]);
      }
      stringBuilder.AppendFormat(formatProvider, "]");
      return stringBuilder.ToString();
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return (object) new Matrix((Array) Utils.Clone((object) this.m_elements), this.m_typeInfo.BuiltInType, (int[]) Utils.Clone((object) this.m_dimensions));
  }

  [Conditional("DEBUG")]
  private static void SanityCheckArrayElements(Array elements, BuiltInType builtInType)
  {
  }

  public static (bool valid, int flatLength) ValidateDimensions(
    bool allowZeroDimension,
    Int32Collection dimensions,
    int maxArrayLength)
  {
    return Matrix.ValidateDimensions(dimensions, maxArrayLength, new Matrix.ValidateDimensionsFunction(ValidateWithSideEffect));

    bool ValidateWithSideEffect(int i, Int32Collection dimCollection)
    {
      if ((allowZeroDimension ? (dimCollection[i] < 0 ? 1 : 0) : (dimCollection[i] <= 0 ? 1 : 0)) != 0)
      {
        Utils.LogTrace("ReadArray read dimensions[{0}] = {1}. Matrix will have 0 elements.", (object) i, (object) dimCollection);
        dimCollection[i] = 0;
        return false;
      }
      if (maxArrayLength > 0 && dimCollection[i] > maxArrayLength)
        throw ServiceResultException.Create(2148007936U /*0x80080000*/, "ArrayDimensions [{0}] = {1} is greater than MaxArrayLength {2}.", (object) i, (object) dimCollection[i], (object) maxArrayLength);
      return true;
    }
  }

  public static (bool valid, int flatLength) ValidateDimensions(
    Int32Collection dimensions,
    int flatLength,
    int maxArrayLength)
  {
    return Matrix.ValidateDimensions(dimensions, maxArrayLength, new Matrix.ValidateDimensionsFunction(ValidateAgainstExpectedFlatLength));

    bool ValidateAgainstExpectedFlatLength(int i, Int32Collection dimCollection)
    {
      if (dimCollection[i] == 0 && flatLength > 0)
        throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("ArrayDimensions [{0}] is zero in Variant object.", (object) i));
      if (dimCollection[i] > flatLength && flatLength > 0)
        throw new ServiceResultException(2147942400U /*0x80070000*/, Utils.Format("ArrayDimensions [{0}] = {1} is greater than length {2}.", (object) i, (object) dimCollection[i], (object) flatLength));
      return true;
    }
  }

  public static (bool valid, int flatLength) ValidateDimensions(Int32Collection dimensions)
  {
    return Matrix.ValidateDimensions(dimensions, 0, (Matrix.ValidateDimensionsFunction) null);
  }

  private static (bool valid, int flatLength) ValidateDimensions(
    Int32Collection dimensions,
    int maxArrayLength,
    Matrix.ValidateDimensionsFunction customValidation)
  {
    bool flag = false;
    int num = 1;
    try
    {
      for (int index = 0; index < dimensions.Count; ++index)
      {
        if (customValidation != null && !(flag = customValidation(index, dimensions)))
          return (flag, 0);
        checked { num *= dimensions[index]; }
      }
    }
    catch (OverflowException ex)
    {
      throw new ArgumentException("The dimensions of the matrix are invalid and overflow when used to calculate the size.");
    }
    return maxArrayLength <= 0 || num <= maxArrayLength ? (flag, num) : throw ServiceResultException.Create(2148007936U /*0x80080000*/, "Maximum array length of {0} was exceeded while summing up to {1} from the array dimensions", (object) maxArrayLength, (object) num);
  }

  public delegate bool ValidateDimensionsFunction(int idx, Int32Collection dimensions);
}
