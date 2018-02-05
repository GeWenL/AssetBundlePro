
using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// 打包AssetBundle
public class ExportAssetBundles : Editor
{
    public static string BUNDLE_PATH = Application.dataPath + "/../MyBundle/";    // ab包所在路径

    [MenuItem("Tools/生成不压缩的ab包")]
	public static void DoCreateUncompressedAssetBundle()
    {
		BuildPipeline.BuildAssetBundles(GetPath(), BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
    }


	[MenuItem("Tools/生成LZMA的ab包")]
	public static void DoCreateLZMAAssetBundle()
	{
		BuildPipeline.BuildAssetBundles(GetPath(), BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
	}

	[MenuItem("Tools/生成LZ4的ab包")]
	public static void DoCreateLZ4AssetBundle()
	{
		BuildPipeline.BuildAssetBundles(GetPath(), BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
	}

	public static string GetPath()
	{
		string path = BUNDLE_PATH;
		if (Directory.Exists(path))
		{
			Directory.Delete(path, true);
		}
		Directory.CreateDirectory(path); 
		return path;
	}
}