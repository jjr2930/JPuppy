using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
namespace JLib
{
    /// <summary> 
    /// 싱글톤으로 구현할 경우 자기 재귀호출이 됨 왜냐면 Instance 함수에서 JResources.Load를 호출하는데, 이 때 JResources가 없다면 다시 JResource.LOad를 호출하여
    /// 무한루프에 빠짐
    /// </summary>
    public static class JResources 
    {
        static BaseResourcesLoader resourcesLoader = null;
        public static void Initialize()
        {
            LoadLoader();
        }

        public static UnityEngine.Object Load(string path)
        {
            if(null == resourcesLoader)
            {
                LoadLoader();
            }

            return resourcesLoader.Load(path);
        }

        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            return Load(path) as T;

        }

        static void LoadLoader()
        {
            switch(Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.OSXPlayer:
                    resourcesLoader = EditorResourcesLoader.Instance;
                    break;

                case RuntimePlatform.Android:
                case RuntimePlatform.IPhonePlayer:
                    resourcesLoader = BundleResourcesLoader.Instance;
                    break;

                default:
                    Debug.LogErrorFormat("JResources.LoadLoader=> {0} is not supported", Application.platform);
                    break;
            }
        }
    }
}
