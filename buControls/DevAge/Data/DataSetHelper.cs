// Decompiled with JetBrains decompiler
// Type: DevAge.Data.DataSetHelper
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

#nullable disable
namespace DevAge.Data;

public class DataSetHelper
{
  private static DataTable dataTable_0 = new DataTable();

  public static string ExpressionFormat(DateTime p_Date) => $"#{p_Date.ToString("MM/dd/yyyy")}#";

  public static string ExpressionFormat(int p_data)
  {
    return p_data.ToString((IFormatProvider) CultureInfo.InvariantCulture.NumberFormat);
  }

  public static string ExpressionFormat(long p_data)
  {
    return p_data.ToString((IFormatProvider) CultureInfo.InvariantCulture.NumberFormat);
  }

  public static string ExpressionFormat(float p_data)
  {
    return p_data.ToString((IFormatProvider) CultureInfo.InvariantCulture.NumberFormat);
  }

  public static string ExpressionFormat(double p_data)
  {
    return p_data.ToString((IFormatProvider) CultureInfo.InvariantCulture.NumberFormat);
  }

  public static string ExpressionFormat(Decimal p_data)
  {
    return p_data.ToString((IFormatProvider) CultureInfo.InvariantCulture.NumberFormat);
  }

  public static string ExpressionFormat(bool p_data)
  {
    return p_data.ToString((IFormatProvider) CultureInfo.InvariantCulture);
  }

  public static string ExpressionFormat(string p_data)
  {
    p_data = p_data.Replace("'", "''");
    return $"'{p_data}'";
  }

  public static string ExpressionFormat(char p_data)
  {
    return DataSetHelper.ExpressionFormat(p_data.ToString());
  }

  public static string ExpressionFormat(DBNull p_data) => "NULL";

  public static string ExpressionFormat(object p_data)
  {
    switch (p_data)
    {
      case DateTime p_Date:
        return DataSetHelper.ExpressionFormat(p_Date);
      case int p_data1:
        return DataSetHelper.ExpressionFormat(p_data1);
      case long p_data2:
        return DataSetHelper.ExpressionFormat(p_data2);
      case float p_data3:
        return DataSetHelper.ExpressionFormat(p_data3);
      case double p_data4:
        return DataSetHelper.ExpressionFormat(p_data4);
      case Decimal p_data5:
        return DataSetHelper.ExpressionFormat(p_data5);
      case bool p_data6:
        return DataSetHelper.ExpressionFormat(p_data6);
      case string _:
        return DataSetHelper.ExpressionFormat((string) p_data);
      case char p_data7:
        return DataSetHelper.ExpressionFormat(p_data7);
      case DBNull _:
        return DataSetHelper.ExpressionFormat((DBNull) p_data);
      default:
        throw new DevAgeApplicationException("Type not supported for expression");
    }
  }

  public static string LikeExpression(string pFieldName, string pFieldValue)
  {
    string p_data = $"%{pFieldValue}%";
    return $"{pFieldName} LIKE {DataSetHelper.ExpressionFormat(p_data)}";
  }

  public static string StartWithExpression(string pFieldName, string pFieldValue)
  {
    string p_data = pFieldValue + "%";
    return $"{pFieldName} LIKE {DataSetHelper.ExpressionFormat(p_data)}";
  }

  public static string EqualExpression(string pFieldName, object pFieldValue)
  {
    return $"{pFieldName} = {DataSetHelper.ExpressionFormat(pFieldValue)}";
  }

  public static string NotEqualExpression(string pFieldName, object pFieldValue)
  {
    return $"{pFieldName} <> {DataSetHelper.ExpressionFormat(pFieldValue)}";
  }

  public static bool ValEquals(object A, object B)
  {
    return (A != DBNull.Value ? 0 : (B == DBNull.Value ? 1 : 0)) != 0 || (A == DBNull.Value ? 1 : (B == DBNull.Value ? 1 : 0)) == 0 && A.Equals(B);
  }

  public static DataTable SelectDistinct(
    DataTable SourceTable,
    string FieldName,
    bool pAddEmptyValue,
    object EmptyValue)
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
    if (pAddEmptyValue)
      dataTable.Rows.Add(EmptyValue);
    object A = EmptyValue;
    foreach (DataRow dataRow in SourceTable.Select("", FieldName))
    {
      if ((A == null ? 1 : (!DataSetHelper.ValEquals(A, dataRow[FieldName]) ? 1 : 0)) != 0)
      {
        A = dataRow[FieldName];
        dataTable.Rows.Add(A);
      }
    }
    return dataTable;
  }

  public static DataTable SampleDataByInterval(
    DataView sourceView,
    string[] columns,
    string samplingField,
    int intervalValue,
    DateTimeInterval intervalType)
  {
    DataTable dataTable = new DataTable();
    for (int index = 0; index < columns.Length; ++index)
      dataTable.Columns.Add(new DataColumn(columns[index], sourceView.Table.Columns[columns[index]].DataType));
    if (sourceView.Count > 0)
    {
      DateTime dateB = (DateTime) sourceView[0][samplingField];
      DataRow row1 = dataTable.NewRow();
      for (int index = 0; index < columns.Length; ++index)
        row1[columns[index]] = sourceView[0][columns[index]];
      dataTable.Rows.Add(row1);
      for (int recordIndex = 1; recordIndex < sourceView.Count; ++recordIndex)
      {
        DataRow row2 = sourceView[recordIndex].Row;
        DateTime dateA = (DateTime) row2[samplingField];
        if (intervalType != DateTimeInterval.Months)
          throw new ApplicationException("Interval not supported");
        if ((DateTimeHelper.MonthsDifference(dateA, dateB) >= intervalValue ? 1 : (recordIndex + 1 == sourceView.Count ? 1 : 0)) != 0)
        {
          if (intervalType != DateTimeInterval.Months)
            throw new ApplicationException("Interval not supported");
          dateB = dateB.AddMonths(intervalValue);
          DataRow row3 = dataTable.NewRow();
          for (int index = 0; index < columns.Length; ++index)
            row3[columns[index]] = row2[columns[index]];
          dataTable.Rows.Add(row3);
        }
      }
    }
    return dataTable;
  }

  public static object Eval(string expression, params object[] parameters)
  {
    object[] objArray = (object[]) null;
    if (parameters != null)
    {
      objArray = (object[]) new string[parameters.Length];
      for (int index = 0; index < parameters.Length; ++index)
        objArray[index] = (object) DataSetHelper.ExpressionFormat(parameters[index]);
    }
    string expression1 = objArray == null ? expression : string.Format(expression, objArray);
    return DataSetHelper.dataTable_0.Compute(expression1, string.Empty);
  }

  public static object EvalRowExpression(DataRow row, string expression)
  {
    string str = expression;
    for (int index = 0; index < row.Table.Columns.Count; ++index)
    {
      string pattern1 = Regex.Escape($"[{row.Table.Columns[index].ColumnName}]");
      if (Regex.IsMatch(str, pattern1, RegexOptions.IgnoreCase))
        str = Regex.Replace(str, pattern1, DataSetHelper.ExpressionFormat(row[index]), RegexOptions.IgnoreCase);
      string pattern2 = $"\\b{Regex.Escape(row.Table.Columns[index].ColumnName)}\\b";
      if (Regex.IsMatch(str, pattern2, RegexOptions.IgnoreCase))
        str = Regex.Replace(str, pattern2, DataSetHelper.ExpressionFormat(row[index]), RegexOptions.IgnoreCase);
    }
    return DataSetHelper.Eval(str, (object[]) null);
  }
}
