/****************************************************************************
 * Copyright (c) 2017 ~ 2018.5 liangxie
 * 
 * http://qframework.io
 * https://github.com/liangxiegame/QFramework
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ****************************************************************************/

using UnityEditor;
using System.IO;
using UnityEngine;

namespace ETEditor
{
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

		static string GetABName(string name)
        {
			string[] splits = name.ToLower().Split('.');
			if (splits.Length != 2) return null;
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
					ai.assetBundleName = "";
				}
				else
				{
					Menu.SetChecked(Mark_AssetBundle, true);
					ai.assetBundleName = GetABName(dir.Name);
				}

				AssetDatabase.RemoveUnusedAssetBundleNames();
			}
		}

		public static string GetSelectedPathOrFallback()
		{
			foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
			{
				return AssetDatabase.GetAssetPath(obj);
			}
			return null;
		}


		[MenuItem(Mark_AssetBundle)]
		public static void MarkPTABDir()
		{
			var path = GetSelectedPathOrFallback();
			if (path == null) return;
			MarkAB(path);
		}
	}
}