using System;
using System.Collections.Concurrent;
using Xbim.Common;
using Xbim.Common.Metadata;

namespace Xbim.IO.Step21.Parser;

public struct StepForwardReference(int referenceEntityLabel, short referencingProperty, IPersistEntity referencingEntity, int[] nestedIndex)
{
	public readonly int ReferenceEntityLabel = referenceEntityLabel;

	private readonly short _referencingPropertyId = referencingProperty;

	private readonly IPersistEntity _referencingEntity = referencingEntity;

	private readonly int[] _nestedIndex = nestedIndex;

	public bool Resolve(ConcurrentDictionary<int, IPersistEntity> references, ExpressMetaData metadata)
	{
		if (references.TryGetValue(ReferenceEntityLabel, out var value))
		{
			PropertyValue propertyValue = default(PropertyValue);
			propertyValue.Init(value);
			try
			{
				_referencingEntity.Parse(_referencingPropertyId, propertyValue, _nestedIndex);
				return true;
			}
			catch (Exception)
			{
				metadata.ExpressType(_referencingEntity);
				return false;
			}
		}
		return false;
	}
}
