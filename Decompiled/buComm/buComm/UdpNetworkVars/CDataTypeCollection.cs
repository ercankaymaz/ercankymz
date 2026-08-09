namespace buComm.UdpNetworkVars;

public class CDataTypeCollection
{
	private int _0001 = 80;

	private DataTypes _0001;

	private object _0001;

	private string _0001;

	public DataTypes DataTypes
	{
		get
		{
			return this._0001;
		}
		set
		{
			this._0001 = value;
		}
	}

	public int FieldLength
	{
		get
		{
			return this._0001;
		}
		set
		{
			this._0001 = value;
		}
	}

	public object SendValue
	{
		get
		{
			return this._0001;
		}
		set
		{
			this._0001 = value;
		}
	}

	public string VariableName
	{
		get
		{
			return _0001;
		}
		set
		{
			_0001 = value;
		}
	}

	public CDataTypeCollection()
	{
	}

	public CDataTypeCollection(DataTypes dataTypes)
	{
		this._0001 = dataTypes;
	}

	public CDataTypeCollection(DataTypes dataTypes, int fieldLength)
	{
		this._0001 = dataTypes;
		this._0001 = fieldLength;
	}

	public CDataTypeCollection(object value, DataTypes dataTypes, int fieldLength)
	{
		this._0001 = dataTypes;
		this._0001 = fieldLength;
		this._0001 = value;
	}

	public CDataTypeCollection(object value, DataTypes dataTypes)
	{
		this._0001 = dataTypes;
		this._0001 = value;
	}
}
