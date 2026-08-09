using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace Xbim.Common.Step21;

public class StepFileHeader : IStepFileHeader, INotifyPropertyChanged
{
	public enum HeaderCreationMode
	{
		LeaveEmpty,
		InitWithXbimDefaults
	}

	private IStepFileDescription _fileDescription;

	private IStepFileName _fileName;

	private IStepFileSchema _fileSchema;

	public IStepFileDescription FileDescription
	{
		get
		{
			return _fileDescription;
		}
		set
		{
			_fileDescription = value;
			OnPropertyChanged("FileDescription");
			if (_fileDescription != null)
			{
				_fileDescription.PropertyChanged += delegate
				{
					OnPropertyChanged("FileDescription");
				};
			}
		}
	}

	public IStepFileName FileName
	{
		get
		{
			return _fileName;
		}
		set
		{
			_fileName = value;
			OnPropertyChanged("FileName");
			if (_fileName != null)
			{
				_fileName.PropertyChanged += delegate
				{
					OnPropertyChanged("FileName");
				};
			}
		}
	}

	public IStepFileSchema FileSchema
	{
		get
		{
			return _fileSchema;
		}
		set
		{
			_fileSchema = value;
			OnPropertyChanged("FileSchema");
			if (_fileSchema != null)
			{
				_fileSchema.PropertyChanged += delegate
				{
					OnPropertyChanged("FileSchema");
				};
			}
		}
	}

	public string SchemaVersion
	{
		get
		{
			if (_fileSchema != null && _fileSchema.Schemas != null && _fileSchema.Schemas.Count > 0)
			{
				return string.Join(", ", _fileSchema.Schemas);
			}
			return "";
		}
	}

	public string CreatingApplication
	{
		get
		{
			if (_fileName != null && _fileName.OriginatingSystem != null)
			{
				return _fileName.OriginatingSystem;
			}
			return "";
		}
	}

	public string ModelViewDefinition
	{
		get
		{
			if (_fileDescription != null && _fileDescription.Description != null)
			{
				return string.Join(", ", _fileDescription.Description);
			}
			return "";
		}
	}

	public string Name
	{
		get
		{
			if (_fileName != null && _fileName.Name != null)
			{
				return _fileName.Name;
			}
			return "";
		}
	}

	public string TimeStamp
	{
		get
		{
			if (_fileName != null && _fileName.TimeStamp != null)
			{
				return _fileName.TimeStamp;
			}
			return "";
		}
	}

	public XbimSchemaVersion XbimSchemaVersion
	{
		get
		{
			foreach (string schema in FileSchema.Schemas)
			{
				if (schema.StartsWith("Ifc4x3", StringComparison.OrdinalIgnoreCase))
				{
					return XbimSchemaVersion.Ifc4x3;
				}
				if (string.Compare(schema, "Ifc4", StringComparison.OrdinalIgnoreCase) == 0 || schema.StartsWith("Ifc4RC", StringComparison.OrdinalIgnoreCase))
				{
					return XbimSchemaVersion.Ifc4;
				}
				if (schema.StartsWith("Ifc2x", StringComparison.OrdinalIgnoreCase))
				{
					return XbimSchemaVersion.Ifc2X3;
				}
				if (schema.StartsWith("Cobie2X4", StringComparison.OrdinalIgnoreCase))
				{
					return XbimSchemaVersion.Cobie2X4;
				}
			}
			return XbimSchemaVersion.Unsupported;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public StepFileHeader(HeaderCreationMode mode, IModel model)
	{
		if (mode == HeaderCreationMode.InitWithXbimDefaults)
		{
			Assembly assembly = model.GetType().GetTypeInfo().Assembly;
			Assembly assembly2 = Assembly.GetEntryAssembly() ?? assembly;
			XbimAssemblyInfo xbimAssemblyInfo = new XbimAssemblyInfo(assembly);
			XbimAssemblyInfo xbimAssemblyInfo2 = new XbimAssemblyInfo(assembly2);
			FileDescription = new StepFileDescription("2;1");
			FileName = new StepFileName(DateTime.UtcNow)
			{
				PreprocessorVersion = "xbim Toolkit v" + xbimAssemblyInfo.FileVersion,
				OriginatingSystem = assembly2.GetName().Name + " v" + xbimAssemblyInfo2.FileVersion
			};
			FileSchema = new StepFileSchema();
		}
		else
		{
			FileDescription = new StepFileDescription();
			FileName = new StepFileName();
			FileSchema = new StepFileSchema();
		}
	}

	public void Write(BinaryWriter binaryWriter)
	{
		_fileDescription.Write(binaryWriter);
		_fileName.Write(binaryWriter);
		_fileSchema.Write(binaryWriter);
	}

	public void Read(BinaryReader binaryReader)
	{
		_fileDescription.Read(binaryReader);
		_fileName.Read(binaryReader);
		_fileSchema.Read(binaryReader);
	}

	public void StampXbimApplication(XbimSchemaVersion schemaVersion, IModel model)
	{
		Assembly assembly = model.GetType().GetTypeInfo().Assembly;
		FileDescription = new StepFileDescription("2;1");
		FileName = new StepFileName(DateTime.Now)
		{
			PreprocessorVersion = $"Processor version {assembly.GetName().Version}",
			OriginatingSystem = assembly.GetName().Name
		};
		FileSchema = new StepFileSchema(schemaVersion);
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
