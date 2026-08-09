namespace ComponentFactory.Krypton.Toolkit;

public delegate void TypedHandler<T>(object sender, TypedCollectionEventArgs<T> e) where T : class;
