
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

    [MenuItem("Tools/生成ab包")]
    // 打包ab，不同平台打包到不同的文件夹下面
    public static void DoCreateAssetBundle()
    {
        string path = BUNDLE_PATH;
        if (Directory.Exists(path))
        {
            Directory.Delete(path, true);
        }
        Directory.CreateDirectory(path); 
        
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
    }
}