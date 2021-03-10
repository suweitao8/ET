using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class ResKitAssetsMenu
{
	public const string AssetBundlesOutputPath = "AssetBundles";
	private const string Mark_AssetBundle = "Assets/@ResKit - AssetBundle Mark";

	static ResKitAssetsMenu()
	{
		Selection.selectionChanged = OnSelectionChanged;
	}

	public static void OnSelectionChanged()
	{
		var path = GetSelectedPathOrFallback();
		if (!string.IsNullOrEmpty(path))
		{
			Menu.SetChecked(Mark_AssetBundle, Marked(path));
		}
	}

	public static bool Marked(string path)
	{
		var ai = AssetImporter.GetAtPath(path);
		var dir = new DirectoryInfo(path);
		return string.Equals(ai.assetBundleName, GetABName(dir.Name));
	}

	public static string GetABName(string name)
    {
		name = name.ToLower();
		string[] splits = name.Split('.');
		if (splits.Length != 2)
        {
			return null;
        }
		return $"{splits[0]}.unity3d";
    }

	public static void MarkAB(string path)
	{
		if (!string.IsNullOrEmpty(path))
		{
			var ai = AssetImporter.GetAtPath(path);
			var dir = new DirectoryInfo(path);

			if (Marked(path))
			{
				Menu.SetChecked(Mark_AssetBundle, false);
				ai.assetBundleName = null;
			}
			else
			{
				Menu.SetChecked(Mark_AssetBundle, true);
				ai.assetBundleName = GetABName(dir.Name);
			}

			AssetDatabase.RemoveUnusedAssetBundleNames();
		}
	}


	[MenuItem(Mark_AssetBundle)]
	public static void MarkPTABDir()
	{
		var path = GetSelectedPathOrFallback();
		MarkAB(path);
	}

	public static string GetSelectedPathOrFallback()
	{
		foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
		{
			return AssetDatabase.GetAssetPath(obj);
		}
		return "";
	}
}
