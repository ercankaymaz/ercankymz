// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NumericRange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public struct NumericRange : IFormattable, IEquatable<NumericRange>
{
  private static readonly NumericRange s_Empty = new NumericRange(-1, -1);
  private int m_begin;
  private int m_end;
  private NumericRange[] m_subranges;

  public NumericRange(int begin)
  {
    if (begin < -1)
      throw new ArgumentOutOfRangeException(nameof (begin));
    this.m_begin = -1;
    this.m_end = -1;
    this.m_subranges = (NumericRange[]) null;
    this.Begin = begin;
  }

  public NumericRange(int begin, int end)
  {
    this.m_begin = -1;
    this.m_end = -1;
    this.m_subranges = (NumericRange[]) null;
    this.Begin = begin;
    this.End = end;
  }

  public int Begin
  {
    get => this.m_begin;
    set
    {
      if (value < -1)
        throw new ArgumentOutOfRangeException(nameof (value), nameof (Begin));
      this.m_begin = this.m_end == -1 || this.m_begin <= this.m_end && this.m_begin >= 0 ? value : throw new ArgumentOutOfRangeException(nameof (value), "Begin > End");
    }
  }

  public int End
  {
    get => this.m_end;
    set
    {
      if (value < -1)
        throw new ArgumentOutOfRangeException(nameof (value), nameof (End));
      this.m_end = this.m_end == -1 || this.m_begin <= this.m_end && this.m_begin >= 0 ? value : throw new ArgumentOutOfRangeException(nameof (value), "Begin > End");
    }
  }

  public int Count
  {
    get
    {
      if (this.m_begin == -1)
        return 0;
      return this.m_end == -1 ? 1 : this.m_end - this.m_begin + 1;
    }
  }

  public int Dimensions
  {
    get
    {
      if (this.m_begin == -1)
        return 0;
      return this.m_subranges == null ? 1 : this.m_subranges.Length;
    }
  }

  public NumericRange[] SubRanges
  {
    get => this.m_subranges;
    set => this.m_subranges = value;
  }

  public bool EnsureValid(object value)
  {
    int count = -1;
    switch (value)
    {
      case ICollection collection:
        count = collection.Count;
        break;
      case Array array:
        count = array.Length;
        break;
    }
    return this.EnsureValid(count);
  }

  public bool EnsureValid(int count)
  {
    if (count == -1 || this.m_begin > count || this.m_end >= count)
      return false;
    if (this.m_begin < 0)
      this.m_begin = 0;
    if (this.m_end < 0)
      this.m_end = count;
    return true;
  }

  public override bool Equals(object obj) => obj is NumericRange other && this.Equals(other);

  public bool Equals(NumericRange other)
  {
    return other.m_begin == this.m_begin && other.m_end == this.m_end;
  }

  public static bool operator ==(NumericRange value1, NumericRange value2) => value1.Equals(value2);

  public static bool operator !=(NumericRange value1, NumericRange value2)
  {
    return !value1.Equals(value2);
  }

  public override int GetHashCode() => HashCode.Combine<int, int>(this.m_begin, this.m_end);

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
      return this.m_end < 0 ? string.Format(formatProvider, "{0}", (object) this.m_begin) : string.Format(formatProvider, "{0}:{1}", (object) this.m_begin, (object) this.m_end);
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public static NumericRange Empty => NumericRange.s_Empty;

  public static ServiceResult Validate(string textToParse, out NumericRange range)
  {
    range = NumericRange.Empty;
    if (string.IsNullOrEmpty(textToParse))
      return ServiceResult.Good;
    if (textToParse.IndexOf(',') >= 0)
    {
      int startIndex = 0;
      List<NumericRange> numericRangeList = new List<NumericRange>();
      for (int index = 0; index < textToParse.Length; ++index)
      {
        char ch = textToParse[index];
        if (ch == ',' || index == textToParse.Length - 1)
        {
          NumericRange range1 = new NumericRange();
          ServiceResult status = NumericRange.Validate(ch == ',' ? textToParse.Substring(startIndex, index - startIndex) : textToParse.Substring(startIndex), out range1);
          if (ServiceResult.IsBad(status))
            return status;
          numericRangeList.Add(range1);
          startIndex = index + 1;
        }
      }
      if (numericRangeList.Count < 2)
        return (ServiceResult) 2151022592U /*0x80360000*/;
      ref NumericRange local1 = ref range;
      NumericRange numericRange = numericRangeList[0];
      int begin = numericRange.Begin;
      local1.m_begin = begin;
      ref NumericRange local2 = ref range;
      numericRange = numericRangeList[0];
      int end = numericRange.End;
      local2.m_end = end;
      range.m_subranges = numericRangeList.ToArray();
      return ServiceResult.Good;
    }
    try
    {
      int length = textToParse.IndexOf(':');
      if (length != -1)
      {
        range.Begin = Convert.ToInt32(textToParse.Substring(0, length), (IFormatProvider) CultureInfo.InvariantCulture);
        range.End = Convert.ToInt32(textToParse.Substring(length + 1), (IFormatProvider) CultureInfo.InvariantCulture);
        if (range.End < 0)
          return ServiceResult.Create(2151022592U /*0x80360000*/, "NumericRange does not have a valid end index ({0}).", (object) range.End);
        if (range.Begin >= range.End)
          return ServiceResult.Create(2151022592U /*0x80360000*/, "NumericRange does not have a start index that is less than the end index ({0}).", (object) range);
      }
      else
      {
        range.Begin = Convert.ToInt32(textToParse, (IFormatProvider) CultureInfo.InvariantCulture);
        range.End = -1;
      }
      if (range.Begin < 0)
        return ServiceResult.Create(2151022592U /*0x80360000*/, "NumericRange does not have a valid start index ({0}).", (object) range.Begin);
    }
    catch (Exception ex)
    {
      object[] objArray = new object[1]
      {
        (object) textToParse
      };
      return ServiceResult.Create(ex, 2151022592U /*0x80360000*/, "NumericRange cannot be parsed ({0}).", objArray);
    }
    return ServiceResult.Good;
  }

  private StatusCode ApplyMultiRange(ref object value)
  {
    Array array1 = value as Array;
    if (array1 == null)
    {
      if (value is Matrix matrix && matrix.Dimensions.Length == this.m_subranges.Length)
      {
        array1 = matrix.ToArray();
      }
      else
      {
        value = (object) null;
        return (StatusCode) 2151088128U /*0x80370000*/;
      }
    }
    TypeInfo typeInfo = TypeInfo.Construct((object) array1);
    NumericRange? nullable = new NumericRange?();
    if (this.m_subranges.Length > typeInfo.ValueRank)
    {
      if ((typeInfo.BuiltInType == BuiltInType.ByteString || typeInfo.BuiltInType == BuiltInType.String) && this.m_subranges.Length == typeInfo.ValueRank + 1)
        nullable = new NumericRange?(this.m_subranges[this.m_subranges.Length - 1]);
      if (!nullable.HasValue)
      {
        value = (object) null;
        return (StatusCode) 2151088128U /*0x80370000*/;
      }
    }
    int[] numArray1 = new int[typeInfo.ValueRank];
    for (int dimension = 0; dimension < numArray1.Length; ++dimension)
    {
      if (this.m_subranges.Length > dimension)
      {
        if (this.m_subranges[dimension].m_begin < array1.GetLength(dimension))
        {
          numArray1[dimension] = this.m_subranges[dimension].Count;
        }
        else
        {
          value = (object) null;
          return (StatusCode) 2151088128U /*0x80370000*/;
        }
      }
      else
        numArray1[dimension] = array1.GetLength(dimension);
    }
    Array array2 = TypeInfo.CreateArray(typeInfo.BuiltInType, numArray1);
    int length1 = array2.Length;
    int[] numArray2 = new int[numArray1.Length];
    int[] numArray3 = new int[numArray1.Length];
    bool flag1 = false;
    for (int index = 0; index < length1; ++index)
    {
      int length2 = array2.Length;
      bool flag2 = false;
      for (int dimension = 0; dimension < numArray2.Length; ++dimension)
      {
        length2 /= numArray1[dimension];
        numArray2[dimension] = index / length2 % numArray1[dimension];
        numArray3[dimension] = numArray2[dimension] + this.m_subranges[dimension].m_begin;
        if (array1.GetLength(dimension) <= numArray3[dimension])
        {
          flag2 = true;
          break;
        }
      }
      if (!flag2)
      {
        object obj = array1.GetValue(numArray3);
        if (obj != null)
        {
          if (nullable.HasValue)
          {
            StatusCode code = nullable.Value.ApplyRange(ref obj);
            if (StatusCode.IsBad(code))
            {
              if (code != 2151088128U /*0x80370000*/)
              {
                value = (object) null;
                return code;
              }
              continue;
            }
          }
          flag1 = true;
          array2.SetValue(obj, numArray2);
        }
      }
    }
    if (!flag1)
    {
      value = (object) null;
      return (StatusCode) 2151088128U /*0x80370000*/;
    }
    value = (object) array2;
    return (StatusCode) 0U;
  }

  public StatusCode UpdateRange(ref object dst, object src)
  {
    if (dst == null)
      return (StatusCode) 2151088128U /*0x80370000*/;
    TypeInfo typeInfo1 = TypeInfo.Construct(dst);
    if (typeInfo1.ValueRank == -1)
    {
      if (this.Dimensions > 1)
        return (StatusCode) 2151022592U /*0x80360000*/;
      if (typeInfo1.BuiltInType == BuiltInType.String)
      {
        char[] charArray = ((string) dst).ToCharArray();
        if (!(src is string str) || str.Length != this.Count)
          return (StatusCode) 2151022592U /*0x80360000*/;
        if (this.m_begin >= charArray.Length || this.m_end > 0 && this.m_end >= charArray.Length)
          return (StatusCode) 2151088128U /*0x80370000*/;
        for (int index = 0; index < str.Length; ++index)
          charArray[this.m_begin + index] = str[index];
        dst = (object) new string(charArray);
        return (StatusCode) 0U;
      }
      if (typeInfo1.BuiltInType != BuiltInType.ByteString)
        return (StatusCode) 2151022592U /*0x80360000*/;
      byte[] numArray1 = (byte[]) dst;
      if (!(src is byte[] numArray2) || numArray2.Length != this.Count)
        return (StatusCode) 2151022592U /*0x80360000*/;
      if (this.m_begin >= numArray1.Length || this.m_end > 0 && this.m_end >= numArray1.Length)
        return (StatusCode) 2151088128U /*0x80370000*/;
      for (int index = 0; index < numArray2.Length; ++index)
        numArray1[this.m_begin + index] = numArray2[index];
      return (StatusCode) 0U;
    }
    Array array1 = src as Array;
    if (!(dst is Array array2))
    {
      if (!(dst is Matrix matrix) || this.m_subranges == null || matrix.Dimensions.Length != this.m_subranges.Length)
        return (StatusCode) 2151022592U /*0x80360000*/;
      array2 = matrix.ToArray();
    }
    if (array1 == null)
    {
      if (!(src is Matrix matrix) || this.m_subranges == null || matrix.Dimensions.Length != this.m_subranges.Length)
        return (StatusCode) 2151022592U /*0x80360000*/;
      array1 = matrix.ToArray();
    }
    TypeInfo typeInfo2 = TypeInfo.Construct((object) array1);
    if (typeInfo2.BuiltInType != typeInfo1.BuiltInType)
      return (StatusCode) 2151022592U /*0x80360000*/;
    if (typeInfo2.ValueRank != typeInfo1.ValueRank)
      return (StatusCode) 2151022592U /*0x80360000*/;
    if (this.m_subranges == null)
    {
      if (typeInfo1.ValueRank > 1)
        return (StatusCode) 2151022592U /*0x80360000*/;
      if (array1.Length != this.Count)
        return (StatusCode) 2151022592U /*0x80360000*/;
      if (this.m_begin >= array2.Length || this.m_end > 0 && this.m_end >= array2.Length)
        return (StatusCode) 2151088128U /*0x80370000*/;
      for (int index = 0; index < array1.Length; ++index)
        array2.SetValue(array1.GetValue(index), this.m_begin + index);
      if (dst is Matrix)
        dst = (object) new Matrix(array2, typeInfo1.BuiltInType);
      return (StatusCode) 0U;
    }
    NumericRange? nullable = new NumericRange?();
    if (this.m_subranges != null && this.m_subranges.Length > typeInfo2.ValueRank)
    {
      if ((typeInfo2.BuiltInType == BuiltInType.ByteString || typeInfo2.BuiltInType == BuiltInType.String) && this.m_subranges.Length == typeInfo2.ValueRank + 1)
        nullable = new NumericRange?(this.m_subranges[this.m_subranges.Length - 1]);
      if (!nullable.HasValue)
        return (StatusCode) 2151088128U /*0x80370000*/;
    }
    int num1 = 1;
    int[] numArray3 = new int[typeInfo2.ValueRank];
    for (int dimension = 0; dimension < numArray3.Length; ++dimension)
    {
      if (this.m_subranges.Length < dimension && this.m_subranges[dimension].Count != array1.GetLength(dimension))
        return (StatusCode) 2151022592U /*0x80360000*/;
      numArray3[dimension] = array1.GetLength(dimension);
      num1 *= numArray3[dimension];
    }
    int[] numArray4 = new int[numArray3.Length];
    for (int index = 0; index < num1; ++index)
    {
      int num2 = num1;
      for (int dimension = 0; dimension < numArray3.Length; ++dimension)
      {
        num2 /= numArray3[dimension];
        int num3 = index / num2 % numArray3[dimension];
        int num4 = 0;
        if (this.m_subranges.Length > dimension)
          num4 = this.m_subranges[dimension].m_begin;
        if (num4 + num3 >= array2.GetLength(dimension))
          return (StatusCode) 2151088128U /*0x80370000*/;
        numArray4[dimension] = num4 + num3;
      }
      if (nullable.HasValue)
      {
        int num5 = nullable.Value.m_begin;
        if (nullable.Value.m_end > 0)
          num5 = nullable.Value.m_end;
        object obj = array2.GetValue(numArray4);
        if (typeInfo1.BuiltInType == BuiltInType.String)
        {
          string str = (string) obj;
          if (str == null || num5 >= str.Length)
            return (StatusCode) 2151088128U /*0x80370000*/;
        }
        else if (typeInfo1.BuiltInType == BuiltInType.ByteString)
        {
          byte[] numArray5 = (byte[]) obj;
          if (numArray5 == null || num5 >= numArray5.Length)
            return (StatusCode) 2151088128U /*0x80370000*/;
        }
      }
    }
    int[] numArray6 = new int[numArray3.Length];
    for (int index1 = 0; index1 < num1; ++index1)
    {
      int num6 = num1;
      for (int dimension = 0; dimension < numArray3.Length; ++dimension)
      {
        num6 /= numArray3[dimension];
        int num7 = index1 / num6 % numArray3[dimension];
        int num8 = 0;
        if (this.m_subranges.Length > dimension)
          num8 = this.m_subranges[dimension].m_begin;
        if (num8 + num7 >= array2.GetLength(dimension))
          return (StatusCode) 2151088128U /*0x80370000*/;
        numArray6[dimension] = num7;
        numArray4[dimension] = num8 + num7;
      }
      object obj1 = array1.GetValue(numArray6);
      if (!nullable.HasValue)
      {
        array2.SetValue(obj1, numArray4);
      }
      else
      {
        object obj2 = array2.GetValue(numArray4);
        if (typeInfo1.BuiltInType == BuiltInType.String)
        {
          string str = (string) obj1;
          char[] charArray = ((string) obj2).ToCharArray();
          if (str != null)
          {
            for (int index2 = 0; index2 < str.Length; ++index2)
              charArray[nullable.Value.m_begin + index2] = str[index2];
          }
          array2.SetValue((object) new string(charArray), numArray4);
        }
        else if (typeInfo1.BuiltInType == BuiltInType.ByteString)
        {
          byte[] numArray7 = (byte[]) obj1;
          byte[] numArray8 = (byte[]) obj2;
          if (numArray7 != null)
          {
            for (int index3 = 0; index3 < numArray7.Length; ++index3)
              numArray8[nullable.Value.m_begin + index3] = numArray7[index3];
          }
        }
      }
    }
    if (dst is Matrix)
      dst = (object) new Matrix(array2, typeInfo1.BuiltInType);
    return (StatusCode) 0U;
  }

  public StatusCode ApplyRange(ref object value)
  {
    if (this.m_begin == -1 && this.m_end == -1)
      return (StatusCode) 0U;
    if (value == null)
      return (StatusCode) 0U;
    Array sourceArray = value as Array;
    list = (IList) null;
    TypeInfo typeInfo = (TypeInfo) null;
    if (sourceArray == null && value is IList list)
      typeInfo = TypeInfo.Construct((object) list);
    bool flag = false;
    if (sourceArray == null && list == null && value is string str)
    {
      flag = true;
      sourceArray = (Array) str.ToCharArray();
    }
    if (this.m_subranges != null)
      return this.ApplyMultiRange(ref value);
    if (list == null && sourceArray == null)
    {
      value = (object) null;
      return (StatusCode) 2151088128U /*0x80370000*/;
    }
    int num1 = list == null ? sourceArray.Length : list.Count;
    int sourceIndex = this.m_begin;
    if (sourceIndex == -1)
      sourceIndex = 0;
    if (sourceIndex >= num1)
    {
      value = (object) null;
      return (StatusCode) 2151088128U /*0x80370000*/;
    }
    int num2 = this.m_end;
    if (num2 == -1)
      num2 = sourceIndex;
    else if (num2 >= num1 - 1)
      num2 = num1 - 1;
    int length = num2 - sourceIndex + 1;
    if (list != null && typeInfo != null)
    {
      Array array = TypeInfo.CreateArray(typeInfo.BuiltInType, length);
      for (int index = sourceIndex; index < length; ++index)
        array.SetValue(list[index], index - sourceIndex);
      return (StatusCode) 0U;
    }
    Array destinationArray = !flag ? Array.CreateInstance(sourceArray.GetType().GetElementType(), length) : (Array) new char[length];
    Array.Copy(sourceArray, sourceIndex, destinationArray, 0, destinationArray.Length);
    value = !flag ? (object) destinationArray : (object) new string((char[]) destinationArray);
    return (StatusCode) 0U;
  }

  public static NumericRange Parse(string textToParse)
  {
    NumericRange range = NumericRange.Empty;
    ServiceResult status = NumericRange.Validate(textToParse, out range);
    if (ServiceResult.IsBad(status))
      throw new ServiceResultException(status);
    return range;
  }
}
