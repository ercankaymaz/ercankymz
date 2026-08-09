namespace DevAge.Text.FixedLength;

public interface IField
{
	string RegularExpressionPattern { get; }

	int Index { get; }

	string Name { get; }

	string ValueToString(object val);

	object StringToValue(string str);
}
