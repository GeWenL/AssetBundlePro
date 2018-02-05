
using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Collections;

public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle bundle = null;

	public IEnumerator MyIEnumeratorFunc(float a)
	{
		yield return new WaitForSeconds (a);
		Debug.Log ("a="+a);
		StopCoroutine ("MyIEnumeratorFunc");
		Debug.Log ("after a="+a);
		yield return new WaitForSeconds (a);
		Debug.Log ("a2="+a);
	}

	public IEnumerator MyIEnumeratorFunc(float a,float b = 0f,float c = 0f)
	{
		yield return new WaitForSeconds (a);
		Debug.Log ("a="+a);
		yield return new WaitForSeconds (b);
		Debug.Log ("b="+b);
		yield return new WaitForSeconds (c);
		Debug.Log ("c="+c);
	}
    public void LoadFromFile()
    {
        Debug.Log("LoadFromFile:"+Application.dataPath + "/../MyBundle/res");
        bundle = AssetBundle.LoadFromFile(Application.dataPath + "/../MyBundle/res");
    }

    public void LoadAllAssets()
    {
        if (bundle != null)
        {
            bundle.LoadAllAssets();
        }
    }

    public void UnLoadFalse()
    {
        if (bundle != null)
        {
            bundle.Unload(false);
        }
    }

    public void UnLoadTrue()
    {
        if (bundle != null)
        {
            bundle.Unload(true);
        }
    }


    public void WWWLoadAB()
    {
		StartCoroutine (WWWLoadABIEnumerator());
    }

    public IEnumerator WWWLoadABIEnumerator()
    {
		Debug.Log("WWWLoadABIEnumerator:"+Application.dataPath + "/../MyBundle/res");
        WWW www = WWW.LoadFromCacheOrDownload(Application.dataPath + "/../MyBundle/res", 0);
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
            yield return null;
        }

		Debug.Log("[success]WWWLoadABIEnumerator:"+Application.dataPath + "/../MyBundle/res");
        bundle = www.assetBundle;

		www = null;
        // bundle = AssetBundle.LoadFromFile(Application.dataPath + "/../MyBundle/res");
    }

}