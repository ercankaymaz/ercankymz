using System.Collections.Generic;

namespace Xbim.IO.Step21.Parser;

public class StepP21Entity
{
	private int _id;

	private string _name;

	private string _parameters;

	private object _instance;

	private int _parseIndex;

	private readonly List<object> _propValues = new List<object>();

	public int ID
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public string Params
	{
		get
		{
			return _parameters;
		}
		set
		{
			_parameters = value;
		}
	}

	public object Instance
	{
		get
		{
			return _instance;
		}
		set
		{
			_instance = value;
		}
	}

	public StepP21Entity()
	{
	}

	public StepP21Entity(int id, string name, string parameters)
	{
		_id = id;
		_name = name;
		_parameters = parameters;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || GetType() != obj.GetType())
		{
			return false;
		}
		return ID == ((StepP21Entity)obj).ID;
	}

	public override int GetHashCode()
	{
		return _id;
	}

	public void SetProperty(object val)
	{
		_propValues.Add(val);
		_parseIndex++;
	}
}
