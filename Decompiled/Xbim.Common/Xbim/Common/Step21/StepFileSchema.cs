using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Xbim.Common.Step21;

public class StepFileSchema : IStepFileSchema, IPersist, IExpressHeaderType, INotifyPropertyChanged
{
	private readonly ObservableCollection<string> _schemas = new ObservableCollection<string>();

	IList<string> IStepFileSchema.Schemas
	{
		get
		{
			return _schemas;
		}
		set
		{
			_schemas.Clear();
			if (value == null || !value.Any())
			{
				return;
			}
			foreach (string item in value)
			{
				_schemas.Add(item);
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public StepFileSchema()
	{
		Init();
	}

	public StepFileSchema(string version)
	{
		_schemas.Add(version);
		Init();
	}

	public StepFileSchema(XbimSchemaVersion schemaVersion)
	{
		_schemas.Add(schemaVersion.ToString().ToUpper());
		Init();
	}

	private void Init()
	{
		_schemas.CollectionChanged += delegate
		{
			OnPropertyChanged("Schemas");
		};
	}

	public void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			if (!_schemas.Contains(value.StringVal))
			{
				_schemas.Add(value.StringVal);
			}
		}
		else
		{
			this.HandleUnexpectedAttribute(propIndex, value);
		}
	}

	public string WhereRule()
	{
		return "";
	}

	internal void Write(BinaryWriter binaryWriter)
	{
		binaryWriter.Write(_schemas.Count);
		foreach (string schema in _schemas)
		{
			binaryWriter.Write(schema);
		}
	}

	internal void Read(BinaryReader binaryReader)
	{
		int num = binaryReader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			_schemas.Add(binaryReader.ReadString());
		}
	}

	void IStepFileSchema.Write(BinaryWriter binaryWriter)
	{
		Write(binaryWriter);
	}

	void IStepFileSchema.Read(BinaryReader binaryReader)
	{
		Read(binaryReader);
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
