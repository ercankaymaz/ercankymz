using System;

namespace devDept.Eyeshot;

public interface IKeyedCollectionDisposableItem<T> : IKeyedCollectionItem<T>, INotifyKeyChanged, ICloneable, IEquatable<T>, IDisposable where T : IKeyedCollectionDisposableItem<T>
{
}
