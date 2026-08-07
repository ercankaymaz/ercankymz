// Decompiled with JetBrains decompiler
// Type: DevAge.Data.SqlClient.SqlCommandBuilder
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

#nullable disable
namespace DevAge.Data.SqlClient;

public class SqlCommandBuilder
{
  private DataTable dataTable;
  private DataColumn[] dataColumn_0;
  private DataColumn[] dataColumn_1;
  private DataColumn[] dataColumn_2;

  public SqlCommandBuilder(DataTable dataTable)
  {
    this.dataTable = dataTable;
    this.dataColumn_0 = this.dataTable.PrimaryKey;
    if ((this.dataColumn_0 == null ? 1 : (this.dataColumn_0.Length == 0 ? 1 : 0)) != 0)
      throw new ApplicationException("DataTable must have a primary key");
    this.dataColumn_2 = new DataColumn[this.dataTable.Columns.Count - this.dataColumn_0.Length];
    int index1 = 0;
    for (int index2 = 0; index2 < this.dataTable.Columns.Count; ++index2)
    {
      bool flag = false;
      for (int index3 = 0; index3 < this.dataColumn_0.Length; ++index3)
      {
        if (this.dataTable.Columns[index2].AutoIncrement)
          throw new ApplicationException("Autoincrement column not supported");
        if (this.dataTable.Columns[index2].ColumnName == this.dataColumn_0[index3].ColumnName)
        {
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        this.dataColumn_2[index1] = this.dataTable.Columns[index2];
        ++index1;
      }
    }
  }

  public DataTable DataTable
  {
    get => this.dataTable;
    set => this.dataTable = value;
  }

  public DataColumn[] PrimaryKeyColumns
  {
    get => this.dataColumn_0;
    set => this.dataColumn_0 = value;
  }

  public DataColumn[] IdentityColumns
  {
    get => this.dataColumn_1;
    set => this.dataColumn_1 = value;
  }

  public DataColumn[] NormalColumns
  {
    get => this.dataColumn_2;
    set => this.dataColumn_2 = value;
  }

  protected virtual string CreateSqlTableName() => $"[{this.dataTable.TableName}]";

  protected virtual string CreateSqlColumnName(DataColumn column) => $"[{column.ColumnName}]";

  protected virtual string CreateSqlInsertColumnName()
  {
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < this.dataColumn_0.Length; ++index)
    {
      stringBuilder.Append(this.CreateSqlColumnName(this.dataColumn_0[index]));
      if ((index < this.dataColumn_0.Length - 1 ? 1 : (this.dataColumn_2.Length != 0 ? 1 : 0)) != 0)
        stringBuilder.Append(",");
    }
    for (int index = 0; index < this.dataColumn_2.Length; ++index)
    {
      stringBuilder.Append(this.CreateSqlColumnName(this.dataColumn_2[index]));
      if (index < this.dataColumn_2.Length - 1)
        stringBuilder.Append(",");
    }
    return stringBuilder.ToString();
  }

  protected virtual string CreateSqlInsertParameters(SqlParameterCollection parameters)
  {
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < parameters.Count; ++index)
    {
      stringBuilder.Append(parameters[index].ParameterName);
      if (index < parameters.Count - 1)
        stringBuilder.Append(",");
    }
    return stringBuilder.ToString();
  }

  protected virtual string CreateSqlPKWhereColumn()
  {
    StringBuilder stringBuilder = new StringBuilder();
    int num = 0;
    for (int index = 0; index < this.dataColumn_0.Length; ++index)
    {
      stringBuilder.Append(this.CreateSqlColumnName(this.dataColumn_0[index]));
      stringBuilder.Append(" = ");
      stringBuilder.Append("@p" + num.ToString());
      if (index < this.dataColumn_0.Length - 1)
        stringBuilder.Append(" AND ");
      ++num;
    }
    return stringBuilder.ToString();
  }

  protected virtual string CreateSqlUpdateColumn()
  {
    StringBuilder stringBuilder = new StringBuilder();
    int length = this.dataColumn_0.Length;
    for (int index = 0; index < this.dataColumn_2.Length; ++index)
    {
      stringBuilder.Append(this.CreateSqlColumnName(this.dataColumn_2[index]));
      stringBuilder.Append(" = ");
      stringBuilder.Append("@p" + length.ToString());
      if (index < this.dataColumn_2.Length - 1)
        stringBuilder.Append(",");
      ++length;
    }
    return stringBuilder.ToString();
  }

  protected virtual void PopulateAllParameters(SqlParameterCollection parameters)
  {
    int num = 0;
    for (int index = 0; index < this.dataColumn_0.Length; ++index)
    {
      parameters.Add("@p" + num.ToString(), this.SqlDbTypeFromDataType(this.dataColumn_0[index].DataType), 0, this.dataColumn_0[index].ColumnName);
      ++num;
    }
    for (int index = 0; index < this.dataColumn_2.Length; ++index)
    {
      parameters.Add("@p" + num.ToString(), this.SqlDbTypeFromDataType(this.dataColumn_2[index].DataType), 0, this.dataColumn_2[index].ColumnName);
      ++num;
    }
  }

  protected virtual SqlDbType SqlDbTypeFromDataType(Type type)
  {
    if (type == typeof (string))
      return SqlDbType.VarChar;
    if (type == typeof (int))
      return SqlDbType.Int;
    if (type == typeof (long))
      return SqlDbType.BigInt;
    if (type == typeof (double) || type == typeof (float))
      return SqlDbType.Float;
    if (type == typeof (bool))
      return SqlDbType.Bit;
    if (type == typeof (DateTime))
      return SqlDbType.DateTime;
    if (type == typeof (Decimal))
      return SqlDbType.Decimal;
    if (type == typeof (Guid))
      return SqlDbType.UniqueIdentifier;
    if (type == typeof (byte[]))
      return SqlDbType.Image;
    throw new ApplicationException($"Type {type.Name} not supported");
  }

  public virtual SqlCommand GetInsertCommand()
  {
    SqlCommand insertCommand = new SqlCommand();
    insertCommand.CommandType = CommandType.Text;
    this.PopulateAllParameters(insertCommand.Parameters);
    string str = $"INSERT INTO {this.CreateSqlTableName()} ({this.CreateSqlInsertColumnName()}) VALUES ({this.CreateSqlInsertParameters(insertCommand.Parameters)})";
    insertCommand.CommandText = str;
    return insertCommand;
  }

  public virtual SqlCommand GetUpdateCommand()
  {
    SqlCommand updateCommand = new SqlCommand();
    updateCommand.CommandType = CommandType.Text;
    this.PopulateAllParameters(updateCommand.Parameters);
    string str = $"UPDATE {this.CreateSqlTableName()} SET {this.CreateSqlUpdateColumn()} WHERE {this.CreateSqlPKWhereColumn()}";
    updateCommand.CommandText = str;
    return updateCommand;
  }

  public virtual SqlCommand GetDeleteCommand()
  {
    SqlCommand deleteCommand = new SqlCommand();
    deleteCommand.CommandType = CommandType.Text;
    this.PopulateAllParameters(deleteCommand.Parameters);
    string str = $"DELETE {this.CreateSqlTableName()} WHERE {this.CreateSqlPKWhereColumn()}";
    deleteCommand.CommandText = str;
    return deleteCommand;
  }
}
