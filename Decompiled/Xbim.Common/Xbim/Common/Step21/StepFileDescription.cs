using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Xbim.Common.Step21;

public class StepFileDescription : IStepFileDescription, IPersist, IExpressHeaderType, INotifyPropertyChanged
{
	private readonly ObservableCollection<string> _description = new ObservableCollection<string>();

	private string _implementationLevel;

	private int _entityCount;

	public IList<string> Description
	{
		get
		{
			return _description;
		}
		set
		{
			_description.Clear();
			if (value == null || !value.Any())
			{
				return;
			}
			foreach (string item in value)
			{
				_description.Add(item);
			}
		}
	}

	public string ImplementationLevel
	{
		get
		{
			return _implementationLevel;
		}
		set
		{
			_implementationLevel = value;
			OnPropertyChanged("ImplementationLevel");
		}
	}

	public int EntityCount
	{
		get
		{
			return _entityCount;
		}
		set
		{
			_entityCount = value;
			OnPropertyChanged("EntityCount");
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	private void MakeValid()
	{
		if (string.IsNullOrWhiteSpace(_implementationLevel))
		{
			_implementationLevel = "2;1";
		}
	}

	public StepFileDescription()
	{
		Init();
	}

	public StepFileDescription(string implementationLevel)
	{
		ImplementationLevel = implementationLevel;
		Init();
	}

	private void Init()
	{
		_description.CollectionChanged += delegate
		{
			OnPropertyChanged("Description");
		};
	}

	public void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_description.Add(value.StringVal);
			break;
		case 1:
			_implementationLevel = value.StringVal;
			break;
		default:
			this.HandleUnexpectedAttribute(propIndex, value);
			break;
		}
	}

	public string WhereRule()
	{
		return "";
	}

	internal void Write(BinaryWriter binaryWriter)
	{
		MakeValid();
		binaryWriter.Write(_description.Count);
		foreach (string item in _description)
		{
			binaryWriter.Write(item);
		}
		binaryWriter.Write(_implementationLevel);
	}

	internal void Read(BinaryReader binaryReader)
	{
		int num = binaryReader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			_description.Add(binaryReader.ReadString());
		}
		_implementationLevel = binaryReader.ReadString();
	}

	void IStepFileDescription.Write(BinaryWriter binaryWriter)
	{
		Write(binaryWriter);
	}

	void IStepFileDescription.Read(BinaryReader binaryReader)
	{
		Read(binaryReader);
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
