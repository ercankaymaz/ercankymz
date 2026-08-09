using System.Collections.Generic;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public interface IEyeIfcObject
{
	string GUID { get; set; }

	string Parent { get; set; }

	Dictionary<string, string> Identification { get; set; }

	Dictionary<string, Dictionary<string, object>> Properties { get; set; }

	Transformation LocalTransformation { get; set; }

	Transformation GlobalTransformation { get; set; }
}
