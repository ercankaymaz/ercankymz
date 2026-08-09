using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Xbim.Common.Step21;

public class StepFileName : IStepFileName, IPersist, IExpressHeaderType, INotifyPropertyChanged
{
	private string _name;

	private string _timeStamp;

	private readonly ObservableCollection<string> _authorName = new ObservableCollection<string>();

	private readonly ObservableCollection<string> _organization = new ObservableCollection<string>();

	private readonly ObservableCollection<string> _authorizationMailingAddress = new ObservableCollection<string>();

	private string _preprocessorVersion;

	private string _originatingSystem;

	private string _authorizationName = "";

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
			OnPropertyChanged("Name");
		}
	}

	public string TimeStamp
	{
		get
		{
			return _timeStamp;
		}
		set
		{
			_timeStamp = value;
			OnPropertyChanged("TimeStamp");
		}
	}

	public IList<string> AuthorName
	{
		get
		{
			return _authorName;
		}
		set
		{
			_authorName.Clear();
			if (value == null || !value.Any())
			{
				return;
			}
			foreach (string item in value)
			{
				_authorName.Add(item);
			}
		}
	}

	public IList<string> Organization
	{
		get
		{
			return _organization;
		}
		set
		{
			_organization.Clear();
			if (value == null || !value.Any())
			{
				return;
			}
			foreach (string item in value)
			{
				_organization.Add(item);
			}
		}
	}

	public string PreprocessorVersion
	{
		get
		{
			return _preprocessorVersion;
		}
		set
		{
			_preprocessorVersion = value;
			OnPropertyChanged("PreprocessorVersion");
		}
	}

	public string OriginatingSystem
	{
		get
		{
			return _originatingSystem;
		}
		set
		{
			_originatingSystem = value;
			OnPropertyChanged("OriginatingSystem");
		}
	}

	public string AuthorizationName
	{
		get
		{
			return _authorizationName;
		}
		set
		{
			_authorizationName = value;
			OnPropertyChanged("AuthorizationName");
		}
	}

	public IList<string> AuthorizationMailingAddress
	{
		get
		{
			return _authorizationMailingAddress;
		}
		set
		{
			_authorizationMailingAddress.Clear();
			if (value == null || !value.Any())
			{
				return;
			}
			foreach (string item in value)
			{
				_authorizationMailingAddress.Add(item);
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public StepFileName(DateTime time)
	{
		TimeStamp = string.Format(time.ToString("s"));
		Init();
	}

	public StepFileName()
	{
		SetTimeStampNow();
		Init();
	}

	private void Init()
	{
		_authorName.CollectionChanged += delegate
		{
			OnPropertyChanged("AuthorName");
		};
		_organization.CollectionChanged += delegate
		{
			OnPropertyChanged("Organization");
		};
		_authorizationMailingAddress.CollectionChanged += delegate
		{
			OnPropertyChanged("AuthorizationMailingAddress");
		};
	}

	public void SetTimeStampNow()
	{
		_timeStamp = string.Format(DateTimeOffset.Now.ToString("o"));
	}

	public void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_timeStamp = value.StringVal;
			break;
		case 2:
			_authorName.Add(value.StringVal);
			break;
		case 3:
			_organization.Add(value.StringVal);
			break;
		case 4:
			_preprocessorVersion = value.StringVal;
			break;
		case 5:
			_originatingSystem = value.StringVal;
			break;
		case 6:
			_authorizationName = value.StringVal;
			break;
		case 7:
			_authorizationMailingAddress.Add(value.StringVal);
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
		binaryWriter.Write(_name ?? "");
		binaryWriter.Write(_timeStamp ?? "");
		binaryWriter.Write(_authorName.Count);
		foreach (string item in _authorName)
		{
			binaryWriter.Write(item);
		}
		binaryWriter.Write(_organization.Count);
		foreach (string item2 in _organization)
		{
			binaryWriter.Write(item2);
		}
		binaryWriter.Write(_preprocessorVersion ?? "");
		binaryWriter.Write(_originatingSystem ?? "");
		binaryWriter.Write(_authorizationName ?? "");
		binaryWriter.Write(_authorizationMailingAddress.Count);
		foreach (string item3 in _authorizationMailingAddress)
		{
			binaryWriter.Write(item3);
		}
	}

	internal void Read(BinaryReader binaryReader)
	{
		_name = binaryReader.ReadString();
		_timeStamp = binaryReader.ReadString();
		int num = binaryReader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			_authorName.Add(binaryReader.ReadString());
		}
		num = binaryReader.ReadInt32();
		for (int j = 0; j < num; j++)
		{
			_organization.Add(binaryReader.ReadString());
		}
		_preprocessorVersion = binaryReader.ReadString();
		_originatingSystem = binaryReader.ReadString();
		_authorizationName = binaryReader.ReadString();
		num = binaryReader.ReadInt32();
		for (int k = 0; k < num; k++)
		{
			_authorizationMailingAddress.Add(binaryReader.ReadString());
		}
	}

	void IStepFileName.Write(BinaryWriter binaryWriter)
	{
		Write(binaryWriter);
	}

	void IStepFileName.Read(BinaryReader binaryReader)
	{
		Read(binaryReader);
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
