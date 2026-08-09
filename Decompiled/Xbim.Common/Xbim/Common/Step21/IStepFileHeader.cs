using System.ComponentModel;
using System.IO;

namespace Xbim.Common.Step21;

public interface IStepFileHeader : INotifyPropertyChanged
{
	IStepFileDescription FileDescription { get; set; }

	IStepFileName FileName { get; set; }

	IStepFileSchema FileSchema { get; set; }

	string SchemaVersion { get; }

	string CreatingApplication { get; }

	string ModelViewDefinition { get; }

	string Name { get; }

	string TimeStamp { get; }

	XbimSchemaVersion XbimSchemaVersion { get; }

	void Write(BinaryWriter binaryWriter);

	void Read(BinaryReader binaryReader);

	void StampXbimApplication(XbimSchemaVersion schemaVersion, IModel model);
}
