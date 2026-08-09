using System;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DevAge.Data;

public class DataSetHelper
{
	private static DataTable dataTable_0 = new DataTable();

	public static string ExpressionFormat(DateTime p_Date)
	{
		return "#" + p_Date.ToString("MM/dd/yyyy") + "#";
	}

	public static string ExpressionFormat(int p_data)
	{
		return p_data.ToString(CultureInfo.InvariantCulture.NumberFormat);
	}

	public static string ExpressionFormat(long p_data)
	{
		return p_data.ToString(CultureInfo.InvariantCulture.NumberFormat);
	}

	public static string ExpressionFormat(float p_data)
	{
		return p_data.ToString(CultureInfo.InvariantCulture.NumberFormat);
	}

	public static string ExpressionFormat(double p_data)
	{
		return p_data.ToString(CultureInfo.InvariantCulture.NumberFormat);
	}

	public static string ExpressionFormat(decimal p_data)
	{
		return p_data.ToString(CultureInfo.InvariantCulture.NumberFormat);
	}

	public static string ExpressionFormat(bool p_data)
	{
		return p_data.ToString(CultureInfo.InvariantCulture);
	}

	public static string ExpressionFormat(string p_data)
	{
		p_data = p_data.Replace("'", "''");
		return "'" + p_data + "'";
	}

	public static string ExpressionFormat(char p_data)
	{
		return ExpressionFormat(p_data.ToString());
	}

	public static string ExpressionFormat(DBNull p_data)
	{
		return "NULL";
	}

	public static string ExpressionFormat(object p_data)
	{
		if (!(p_data is DateTime))
		{
			if (!(p_data is int))
			{
				if (!(p_data is long))
				{
					if (!(p_data is float))
					{
						if (!(p_data is double))
						{
							if (!(p_data is decimal))
							{
								if (!(p_data is bool))
								{
									if (!(p_data is string))
									{
										if (!(p_data is char))
										{
											if (!(p_data is DBNull))
											{
												throw new DevAgeApplicationException("Type not supported for expression");
											}
											return ExpressionFormat((DBNull)p_data);
										}
										return ExpressionFormat((char)p_data);
									}
									return ExpressionFormat((string)p_data);
								}
								return ExpressionFormat((bool)p_data);
							}
							return ExpressionFormat((decimal)p_data);
						}
						return ExpressionFormat((double)p_data);
					}
					return ExpressionFormat((float)p_data);
				}
				return ExpressionFormat((long)p_data);
			}
			return ExpressionFormat((int)p_data);
		}
		return ExpressionFormat((DateTime)p_data);
	}

	public static string LikeExpression(string pFieldName, string pFieldValue)
	{
		string p_data = "%" + pFieldValue + "%";
		return pFieldName + " LIKE " + ExpressionFormat(p_data);
	}

	public static string StartWithExpression(string pFieldName, string pFieldValue)
	{
		string p_data = pFieldValue + "%";
		return pFieldName + " LIKE " + ExpressionFormat(p_data);
	}

	public static string EqualExpression(string pFieldName, object pFieldValue)
	{
		return pFieldName + " = " + ExpressionFormat(pFieldValue);
	}

	public static string NotEqualExpression(string pFieldName, object pFieldValue)
	{
		return pFieldName + " <> " + ExpressionFormat(pFieldValue);
	}

	public static bool ValEquals(object A, object B)
	{
		if (A != DBNull.Value || B != DBNull.Value)
		{
			if (A != DBNull.Value && B != DBNull.Value)
			{
				return A.Equals(B);
			}
			return false;
		}
		return true;
	}

	public static DataTable SelectDistinct(DataTable SourceTable, string FieldName, bool pAddEmptyValue, object EmptyValue)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
		if (pAddEmptyValue)
		{
			dataTable.Rows.Add(EmptyValue);
		}
		object obj = EmptyValue;
		DataRow[] array = SourceTable.Select("", FieldName);
		foreach (DataRow dataRow in array)
		{
			if (obj == null || !ValEquals(obj, dataRow[FieldName]))
			{
				obj = dataRow[FieldName];
				dataTable.Rows.Add(obj);
			}
		}
		return dataTable;
	}

	public static DataTable SampleDataByInterval(DataView sourceView, string[] columns, string samplingField, int intervalValue, DateTimeInterval intervalType)
	{
		DataTable dataTable = new DataTable();
		for (int i = 0; i < columns.Length; i++)
		{
			dataTable.Columns.Add(new DataColumn(columns[i], sourceView.Table.Columns[columns[i]].DataType));
		}
		if (sourceView.Count > 0)
		{
			DateTime dateB = (DateTime)sourceView[0][samplingField];
			DataRow dataRow = dataTable.NewRow();
			for (int j = 0; j < columns.Length; j++)
			{
				dataRow[columns[j]] = sourceView[0][columns[j]];
			}
			dataTable.Rows.Add(dataRow);
			for (int k = 1; k < sourceView.Count; k++)
			{
				DataRow row = sourceView[k].Row;
				DateTime dateA = (DateTime)row[samplingField];
				if (intervalType != DateTimeInterval.Months)
				{
					throw new ApplicationException("Interval not supported");
				}
				int num = DateTimeHelper.MonthsDifference(dateA, dateB);
				if (num >= intervalValue || k + 1 == sourceView.Count)
				{
					if (intervalType != DateTimeInterval.Months)
					{
						throw new ApplicationException("Interval not supported");
					}
					dateB = dateB.AddMonths(intervalValue);
					dataRow = dataTable.NewRow();
					for (int l = 0; l < columns.Length; l++)
					{
						dataRow[columns[l]] = row[columns[l]];
					}
					dataTable.Rows.Add(dataRow);
				}
			}
		}
		return dataTable;
	}

	public static object Eval(string expression, params object[] parameters)
	{
		object[] array = null;
		if (parameters != null)
		{
			object[] array2 = new string[parameters.Length];
			array = array2;
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = ExpressionFormat(parameters[i]);
			}
		}
		string expression2 = ((array != null) ? string.Format(expression, array) : expression);
		return dataTable_0.Compute(expression2, string.Empty);
	}

	public static object EvalRowExpression(DataRow row, string expression)
	{
		string text = expression;
		for (int i = 0; i < row.Table.Columns.Count; i++)
		{
			string pattern = Regex.Escape("[" + row.Table.Columns[i].ColumnName + "]");
			if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase))
			{
				text = Regex.Replace(text, pattern, ExpressionFormat(row[i]), RegexOptions.IgnoreCase);
			}
			pattern = "\\b" + Regex.Escape(row.Table.Columns[i].ColumnName) + "\\b";
			if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase))
			{
				text = Regex.Replace(text, pattern, ExpressionFormat(row[i]), RegexOptions.IgnoreCase);
			}
		}
		return Eval(text, null);
	}
}
