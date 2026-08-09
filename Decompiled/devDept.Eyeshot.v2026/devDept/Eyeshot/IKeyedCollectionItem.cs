using System;

namespace devDept.Eyeshot;

public interface IKeyedCollectionItem<T> : INotifyKeyChanged, ICloneable, IEquatable<T> where T : IKeyedCollectionItem<T>
{
	string GetKey();

	void SetKey(string value);
}
