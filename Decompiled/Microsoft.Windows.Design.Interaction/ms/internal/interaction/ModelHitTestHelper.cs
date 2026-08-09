using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Windows.Design.Interaction;

namespace MS.Internal.Interaction;

internal static class ModelHitTestHelper
{
	private class HitTestResultCallbackWrapper
	{
		private HitTestResultCallback _resultCallback;

		private HitTestResultBehavior _onHitFoundBehavior;

		private List<HitTestResult> _results;

		private HitTestResultCallback _wrappedResultCallback;

		private int _resultInsertionIndex;

		public HitTestResultCallback ResultCallback => _wrappedResultCallback;

		public HitTestResult TopMostHit
		{
			get
			{
				if (_results != null && _results.Count > 0)
				{
					return _results[0];
				}
				return null;
			}
		}

		private List<HitTestResult> RawResults
		{
			get
			{
				if (_results == null)
				{
					_results = new List<HitTestResult>(1);
				}
				return _results;
			}
		}

		public HitTestResultCallbackWrapper(HitTestResultCallback resultCallback, HitTestResultBehavior behaviorOnResult)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			_resultCallback = resultCallback;
			_resultInsertionIndex = 0;
			_results = null;
			_onHitFoundBehavior = behaviorOnResult;
			_wrappedResultCallback = new HitTestResultCallback(OnResult);
		}

		internal void InsertResult(HitTestResult result)
		{
			if (RawResults.Count > 0 && _resultInsertionIndex < RawResults.Count)
			{
				RawResults.Insert(_resultInsertionIndex, result);
			}
			else
			{
				RawResults.Add(result);
			}
			_resultInsertionIndex++;
		}

		private HitTestResultBehavior OnResult(HitTestResult hitItemsResult)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			RawResults.Add(hitItemsResult);
			return _onHitFoundBehavior;
		}

		internal void PlayResults()
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			if (_resultCallback == null)
			{
				return;
			}
			foreach (HitTestResult rawResult in RawResults)
			{
				HitTestResultBehavior val = _resultCallback.Invoke(rawResult);
				if ((int)val == 0)
				{
					break;
				}
			}
		}
	}

	private class HitTestFilterCallbackWrapper
	{
		private HitTestFilterCallback _filterCallback;

		private HitTestFilterCallback _wrappedFilterCallback;

		public HitTestFilterCallback FilterCallback => _wrappedFilterCallback;

		public HitTestFilterCallbackWrapper(HitTestFilterCallback filterCallback)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Expected O, but got Unknown
			_filterCallback = filterCallback;
			_wrappedFilterCallback = new HitTestFilterCallback(OnFilterHitResult);
		}

		private HitTestFilterBehavior OnFilterHitResult(DependencyObject hit)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			UIElement val = (UIElement)(object)((hit is UIElement) ? hit : null);
			if (val != null && !val.IsVisible)
			{
				return (HitTestFilterBehavior)0;
			}
			HitTestFilterBehavior result = (HitTestFilterBehavior)6;
			if (_filterCallback != null)
			{
				result = _filterCallback.Invoke(hit);
			}
			return result;
		}
	}

	[ThreadStatic]
	private static Dictionary<Type, HitTestProvider> _hitTestProviders;

	private static Dictionary<Type, HitTestProvider> HitTestProviders
	{
		get
		{
			if (_hitTestProviders == null)
			{
				_hitTestProviders = new Dictionary<Type, HitTestProvider>();
				_hitTestProviders[typeof(Panel)] = new ContainerHitTestProvider();
				_hitTestProviders[typeof(Decorator)] = new ContainerHitTestProvider();
				_hitTestProviders[typeof(ContentControl)] = new ContainerHitTestProvider();
			}
			return _hitTestProviders;
		}
	}

	public static HitTestProvider GetSingletonProvider(DependencyObject d)
	{
		Type type = ((object)d).GetType();
		while ((object)type != typeof(object))
		{
			if (HitTestProviders.ContainsKey(type))
			{
				return HitTestProviders[type];
			}
			type = type.BaseType;
		}
		return null;
	}

	public static HitTestResult HitTest(Visual reference, Point point, HitTestFilterCallback filterCallback)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		return HitTest(reference, filterCallback, null, (HitTestParameters)new PointHitTestParameters(point), null);
	}

	public static ViewHitTestResult HitTest(ViewItem reference, Point point, ViewHitTestFilterCallback filterCallback, ViewHitTestFilterCallback modelCallback)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		return reference.HitTest(filterCallback, null, (HitTestParameters)new PointHitTestParameters(point));
	}

	public static HitTestResult HitTest(Visual root, HitTestFilterCallback filterCallback, HitTestResultCallback resultCallback, HitTestParameters hitTestParameters, HitTestFilterCallback modelCallback)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Invalid comparison between Unknown and I4
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Invalid comparison between Unknown and I4
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Invalid comparison between Unknown and I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Invalid comparison between Unknown and I4
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Invalid comparison between Unknown and I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Invalid comparison between Unknown and I4
		HitTestFilterCallbackWrapper hitTestFilterCallbackWrapper = new HitTestFilterCallbackWrapper(filterCallback);
		HitTestResultCallbackWrapper hitTestResultCallbackWrapper = new HitTestResultCallbackWrapper(resultCallback, (HitTestResultBehavior)1);
		VisualTreeHelper.HitTest(root, hitTestFilterCallbackWrapper.FilterCallback, hitTestResultCallbackWrapper.ResultCallback, hitTestParameters);
		HitTestResult topMostHit = hitTestResultCallbackWrapper.TopMostHit;
		bool flag = filterCallback == null && resultCallback == null;
		VisualHitTestArgs visualHitTestArgs = new VisualHitTestArgs(root, root, hitTestParameters);
		PointHitTestParameters val = (PointHitTestParameters)(object)((hitTestParameters is PointHitTestParameters) ? hitTestParameters : null);
		GeometryHitTestParameters val2 = (GeometryHitTestParameters)(object)((hitTestParameters is GeometryHitTestParameters) ? hitTestParameters : null);
		foreach (DependencyObject item in GetDescendantsInZOrder((DependencyObject)(object)root))
		{
			if (item == null)
			{
				continue;
			}
			if (filterCallback == null && topMostHit != null && item == topMostHit.VisualHit)
			{
				hitTestResultCallbackWrapper.PlayResults();
				return hitTestResultCallbackWrapper.TopMostHit;
			}
			Visual val3 = (Visual)(object)((item is Visual) ? item : null);
			HitTestProvider singletonProvider = GetSingletonProvider(item);
			if (singletonProvider == null)
			{
				continue;
			}
			if (modelCallback != null)
			{
				HitTestFilterBehavior val4 = modelCallback.Invoke((DependencyObject)(object)val3);
				if ((int)val4 == 6)
				{
					continue;
				}
			}
			visualHitTestArgs.UpdateChild(item);
			HitTestResult val5 = null;
			if (val != null && val3 != null)
			{
				PointHitTestResult val6 = singletonProvider.HitTestPoint(visualHitTestArgs);
				if (val6 != null && val6.VisualHit != null)
				{
					val5 = (HitTestResult)(object)val6;
				}
			}
			else if (val2 != null && val3 != null)
			{
				GeometryHitTestResult val7 = singletonProvider.HitTestGeometry(visualHitTestArgs);
				if (val7 != null && (int)val7.IntersectionDetail != 1 && (int)val7.IntersectionDetail != 0)
				{
					val5 = (HitTestResult)(object)val7;
				}
			}
			if (val5 != null)
			{
				HitTestFilterBehavior val8 = hitTestFilterCallbackWrapper.FilterCallback.Invoke(item);
				if ((int)val8 == 6 || (int)val8 == 8)
				{
					hitTestResultCallbackWrapper.InsertResult(val5);
				}
				if ((flag && (int)val8 != 4) || (int)val8 == 8)
				{
					hitTestResultCallbackWrapper.PlayResults();
					return val5;
				}
			}
		}
		hitTestResultCallbackWrapper.PlayResults();
		return hitTestResultCallbackWrapper.TopMostHit;
	}

	private static IEnumerable<DependencyObject> GetDescendantsInZOrder(DependencyObject root)
	{
		if (root == null)
		{
			yield break;
		}
		int childCount = VisualTreeHelper.GetChildrenCount(root);
		if (childCount <= 0)
		{
			yield break;
		}
		for (int i = childCount - 1; i >= 0; i--)
		{
			DependencyObject child = VisualTreeHelper.GetChild(root, i);
			if (child != null)
			{
				foreach (DependencyObject grandchild in GetDescendantsInZOrder(child))
				{
					if (grandchild != null)
					{
						yield return grandchild;
					}
				}
				yield return child;
			}
		}
	}
}
