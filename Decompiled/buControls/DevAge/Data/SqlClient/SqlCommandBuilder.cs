using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevAge.Data.SqlClient;

public class SqlCommandBuilder
{
	private DataTable dataTable;

	private DataColumn[] dataColumn_0;

	private DataColumn[] dataColumn_1;

	private DataColumn[] dataColumn_2;

	public DataTable DataTable
	{
		get
		{
			return dataTable;
		}
		set
		{
			dataTable = value;
		}
	}

	public DataColumn[] PrimaryKeyColumns
	{
		get
		{
			return dataColumn_0;
		}
		set
		{
			dataColumn_0 = value;
		}
	}

	public DataColumn[] IdentityColumns
	{
		get
		{
			return dataColumn_1;
		}
		set
		{
			dataColumn_1 = value;
		}
	}

	public DataColumn[] NormalColumns
	{
		get
		{
			return dataColumn_2;
		}
		set
		{
			dataColumn_2 = value;
		}
	}

	public SqlCommandBuilder(DataTable dataTable)
	{
		this.dataTable = dataTable;
		dataColumn_0 = this.dataTable.PrimaryKey;
		if (dataColumn_0 != null && dataColumn_0.Length != 0)
		{
			dataColumn_2 = new DataColumn[this.dataTable.Columns.Count - dataColumn_0.Length];
			int num = 0;
			for (int i = 0; i < this.dataTable.Columns.Count; i++)
			{
				bool flag = false;
				for (int j = 0; j < dataColumn_0.Length; j++)
				{
					if (!this.dataTable.Columns[i].AutoIncrement)
					{
						if (this.dataTable.Columns[i].ColumnName == dataColumn_0[j].ColumnName)
						{
							flag = true;
							break;
						}
						continue;
					}
					throw new ApplicationException("Autoincrement column not supported");
				}
				if (!flag)
				{
					dataColumn_2[num] = this.dataTable.Columns[i];
					num++;
				}
			}
			return;
		}
		throw new ApplicationException("DataTable must have a primary key");
	}

	protected virtual string CreateSqlTableName()
	{
		return "[" + dataTable.TableName + "]";
	}

	protected virtual string CreateSqlColumnName(DataColumn column)
	{
		return "[" + column.ColumnName + "]";
	}

	protected virtual string CreateSqlInsertColumnName()
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < dataColumn_0.Length; i++)
		{
			stringBuilder.Append(CreateSqlColumnName(dataColumn_0[i]));
			if (i < dataColumn_0.Length - 1 || dataColumn_2.Length != 0)
			{
				stringBuilder.Append(",");
			}
		}
		for (int j = 0; j < dataColumn_2.Length; j++)
		{
			stringBuilder.Append(CreateSqlColumnName(dataColumn_2[j]));
			if (j < dataColumn_2.Length - 1)
			{
				stringBuilder.Append(",");
			}
		}
		return stringBuilder.ToString();
	}

	protected virtual string CreateSqlInsertParameters(SqlParameterCollection parameters)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < parameters.Count; i++)
		{
			stringBuilder.Append(parameters[i].ParameterName);
			if (i < parameters.Count - 1)
			{
				stringBuilder.Append(",");
			}
		}
		return stringBuilder.ToString();
	}

	protected virtual string CreateSqlPKWhereColumn()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		for (int i = 0; i < dataColumn_0.Length; i++)
		{
			stringBuilder.Append(CreateSqlColumnName(dataColumn_0[i]));
			stringBuilder.Append(" = ");
			stringBuilder.Append("@p" + num);
			if (i < dataColumn_0.Length - 1)
			{
				stringBuilder.Append(" AND ");
			}
			num++;
		}
		return stringBuilder.ToString();
	}

	protected virtual string CreateSqlUpdateColumn()
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = dataColumn_0.Length;
		for (int i = 0; i < dataColumn_2.Length; i++)
		{
			stringBuilder.Append(CreateSqlColumnName(dataColumn_2[i]));
			stringBuilder.Append(" = ");
			stringBuilder.Append("@p" + num);
			if (i < dataColumn_2.Length - 1)
			{
				stringBuilder.Append(",");
			}
			num++;
		}
		return stringBuilder.ToString();
	}

	protected virtual void PopulateAllParameters(SqlParameterCollection parameters)
	{
		int num = 0;
		for (int i = 0; i < dataColumn_0.Length; i++)
		{
			parameters.Add("@p" + num, SqlDbTypeFromDataType(dataColumn_0[i].DataType), 0, dataColumn_0[i].ColumnName);
			num++;
		}
		for (int j = 0; j < dataColumn_2.Length; j++)
		{
			parameters.Add("@p" + num, SqlDbTypeFromDataType(dataColumn_2[j].DataType), 0, dataColumn_2[j].ColumnName);
			num++;
		}
	}

	protected virtual SqlDbType SqlDbTypeFromDataType(Type type)
	{
		if (!(type == typeof(string)))
		{
			if (!(type == typeof(int)))
			{
				if (!(type == typeof(long)))
				{
					if (!(type == typeof(double)))
					{
						if (!(type == typeof(float)))
						{
							if (!(type == typeof(bool)))
							{
								if (!(type == typeof(DateTime)))
								{
									if (!(type == typeof(decimal)))
									{
										if (!(type == typeof(Guid)))
										{
											if (!(type == typeof(byte[])))
											{
												throw new ApplicationException("Type " + type.Name + " not supported");
											}
											return SqlDbType.Image;
										}
										return SqlDbType.UniqueIdentifier;
									}
									return SqlDbType.Decimal;
								}
								return SqlDbType.DateTime;
							}
							return SqlDbType.Bit;
						}
						return SqlDbType.Float;
					}
					return SqlDbType.Float;
				}
				return SqlDbType.BigInt;
			}
			return SqlDbType.Int;
		}
		return SqlDbType.VarChar;
	}

	public virtual SqlCommand GetInsertCommand()
	{
		SqlCommand sqlCommand = new SqlCommand();
		sqlCommand.CommandType = CommandType.Text;
		PopulateAllParameters(sqlCommand.Parameters);
		string commandText = $"INSERT INTO {CreateSqlTableName()} ({CreateSqlInsertColumnName()}) VALUES ({CreateSqlInsertParameters(sqlCommand.Parameters)})";
		sqlCommand.CommandText = commandText;
		return sqlCommand;
	}

	public virtual SqlCommand GetUpdateCommand()
	{
		SqlCommand sqlCommand = new SqlCommand();
		sqlCommand.CommandType = CommandType.Text;
		PopulateAllParameters(sqlCommand.Parameters);
		string commandText = $"UPDATE {CreateSqlTableName()} SET {CreateSqlUpdateColumn()} WHERE {CreateSqlPKWhereColumn()}";
		sqlCommand.CommandText = commandText;
		return sqlCommand;
	}

	public virtual SqlCommand GetDeleteCommand()
	{
		SqlCommand sqlCommand = new SqlCommand();
		sqlCommand.CommandType = CommandType.Text;
		PopulateAllParameters(sqlCommand.Parameters);
		string commandText = $"DELETE {CreateSqlTableName()} WHERE {CreateSqlPKWhereColumn()}";
		sqlCommand.CommandText = commandText;
		return sqlCommand;
	}
}
