using System;
using System.Collections.Generic;
using System.Windows;
using MS.Internal.Interaction;
using Microsoft.Win32;

namespace Microsoft.Windows.Design.Interaction;

public static class AdornerResources
{
	private static readonly object _syncLock;

	private static List<LoadResourcesCallback> _callbacks;

	private static ResourceDictionary _resources;

	private static int _loadIndex;

	private static bool _themeInUse;

	private static bool? _highContrast;

	[ThreadStatic]
	private static FrameworkElement _queryElement;

	internal static ResourceDictionary ThemeResources
	{
		get
		{
			EnsureResources(forceUpdate: false);
			_themeInUse = true;
			return _resources;
		}
	}

	static AdornerResources()
	{
		_syncLock = new object();
		_loadIndex = -1;
		SystemEvents.UserPreferenceChanged += delegate(object sender, UserPreferenceChangedEventArgs e)
		{
			if (_themeInUse && IsResourceCategory(e.Category))
			{
				EnsureResources(forceUpdate: true);
			}
		};
	}

	private static void EnsureResources(bool forceUpdate)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		bool flag = forceUpdate;
		lock (_syncLock)
		{
			if (_resources == null)
			{
				_resources = new ResourceDictionary();
				flag = true;
			}
			if (_highContrast != SystemParameters.HighContrast)
			{
				_highContrast = SystemParameters.HighContrast;
				flag = true;
			}
			if (!flag || _callbacks == null)
			{
				return;
			}
			_resources.BeginInit();
			try
			{
				_resources.MergedDictionaries.Clear();
				while (++_loadIndex < _callbacks.Count)
				{
					ResourceDictionary val = _callbacks[_loadIndex]();
					if (val != null)
					{
						_resources.MergedDictionaries.Add(val);
					}
				}
			}
			finally
			{
				_resources.EndInit();
				_loadIndex = -1;
			}
		}
	}

	public static object FindResource(ResourceKey key)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (FindResourceHelper(key, out var resource))
		{
			return resource;
		}
		if (_queryElement == null)
		{
			_queryElement = new FrameworkElement();
		}
		return _queryElement.FindResource((object)key);
	}

	public static object TryFindResource(ResourceKey key)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (FindResourceHelper(key, out var resource))
		{
			return resource;
		}
		if (_queryElement == null)
		{
			_queryElement = new FrameworkElement();
		}
		return _queryElement.TryFindResource((object)key);
	}

	private static bool FindResourceHelper(ResourceKey key, out object resource)
	{
		resource = null;
		lock (_syncLock)
		{
			if (_loadIndex != -1)
			{
				resource = _resources[(object)key];
				while (resource == null && ++_loadIndex < _callbacks.Count)
				{
					ResourceDictionary val = _callbacks[_loadIndex]();
					if (val != null)
					{
						_resources.MergedDictionaries.Add(val);
						resource = val[(object)key];
					}
				}
				return true;
			}
		}
		return false;
	}

	private static bool IsResourceCategory(UserPreferenceCategory category)
	{
		if (category != UserPreferenceCategory.Accessibility && category != UserPreferenceCategory.Color)
		{
			return category == UserPreferenceCategory.VisualStyle;
		}
		return true;
	}

	public static ResourceKey CreateResourceKey(Type owningType, string publicMember)
	{
		if ((object)owningType == null)
		{
			throw new ArgumentNullException("owningType");
		}
		if (publicMember == null)
		{
			throw new ArgumentNullException("publicMember");
		}
		return (ResourceKey)(object)new AdornerResourceKey(owningType, publicMember);
	}

	public static void RegisterResources(LoadResourcesCallback callback)
	{
		if (callback == null)
		{
			throw new ArgumentNullException("callback");
		}
		lock (_syncLock)
		{
			if (_callbacks == null)
			{
				_callbacks = new List<LoadResourcesCallback>();
			}
			_callbacks.Add(callback);
		}
		if (!_themeInUse)
		{
			return;
		}
		ResourceDictionary val = callback();
		if (val != null)
		{
			_resources.BeginInit();
			try
			{
				_resources.MergedDictionaries.Add(val);
			}
			finally
			{
				_resources.EndInit();
			}
		}
	}

	public static void Refresh()
	{
		EnsureResources(forceUpdate: true);
	}
}
