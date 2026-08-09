using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IParameterCollection : IEnumerable<IParameter>
{
	IArrayParameter this[ArrayName name] { get; }

	IEnumParameter this[EnumName name] { get; }

	IStringParameter this[StringName name] { get; }

	ICommandParameter this[CommandName name] { get; }

	IBooleanParameter this[BooleanName name] { get; }

	IFloatParameter this[FloatName name] { get; }

	IIntegerParameter this[IntegerName name] { get; }

	IParameter this[string name] { get; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	void Refresh();

	[EditorBrowsable(EditorBrowsableState.Never)]
	void Poll(long elapsedTime);

	[EditorBrowsable(EditorBrowsableState.Never)]
	IEnumerable<string> GetParameterRelation(string name, ParameterRelation relation, [MarshalAs(UnmanagedType.U1)] bool filterInternalParameters);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Contains(ArrayName name);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Contains(EnumName name);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Contains(StringName name);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Contains(CommandName name);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Contains(BooleanName name);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Contains(FloatName name);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Contains(IntegerName name);

	[return: MarshalAs(UnmanagedType.U1)]
	bool Contains(string name);

	void Load(string filename, string parameterPath);

	void Save(string filename, string parameterPath);
}
