using System.Collections;

namespace System.Management;

public class QualifierDataCollection : ICollection, IEnumerable
{
	public class QualifierDataEnumerator : IEnumerator
	{
		public QualifierData Current
		{
			get
			{
				throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
			}
		}

		object IEnumerator.Current
		{
			get
			{
				throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
			}
		}

		internal QualifierDataEnumerator()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}

		public bool MoveNext()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}

		public void Reset()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	public int Count
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	public bool IsSynchronized
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	public virtual QualifierData this[string qualifierName]
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	public object SyncRoot
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal QualifierDataCollection()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public virtual void Add(string qualifierName, object qualifierValue)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public virtual void Add(string qualifierName, object qualifierValue, bool isAmended, bool propagatesToInstance, bool propagatesToSubclass, bool isOverridable)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public void CopyTo(Array array, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public void CopyTo(QualifierData[] qualifierArray, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public QualifierDataEnumerator GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	public virtual void Remove(string qualifierName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
