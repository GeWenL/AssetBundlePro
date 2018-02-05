
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections;

public class LoadPrefabAB : MonoBehaviour
{
    void Start()
    {

         AssetBundle bundle = AssetBundle.LoadFromFile(Application.dataPath + "/../MyBundle/prefabSp123");
		
		 if (bundle == null)
         {
             Debug.Log("未生成ab包，点击【Tools/生成ab包】生成");
             return;
         }
         AssetBundle bundle1 = AssetBundle.LoadFromFile(Application.dataPath + "/../MyBundle/tex1");
		 GameObject prefab = bundle.LoadAsset<GameObject> ("Sprite123");
		 GameObject Sprite1234 = Instantiate (prefab);
		 Sprite1234.transform.SetParent (transform);
		 Sprite1234.transform.localPosition = Vector3.zero;
    }


}