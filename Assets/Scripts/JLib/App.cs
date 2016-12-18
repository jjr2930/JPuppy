using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
namespace JLib
{ 
    public class App : MonoSingle<App>
    {
        public static Vector3 Gravity
        {
            get
            {
                return Instance.gravity;
            }
            set
            {
                Instance.gravity = value;
                Physics.gravity = value;
            }
        }
        
  

        public static JPlatformType Platform
        {
            get
            {
                if(JPlatformType.None == Instance._runtimePlatfom)
                {
                    int enumNumber = (int)Application.platform;
                    Instance._runtimePlatfom = (JPlatformType)enumNumber;
                }

                return Instance._runtimePlatfom;
            }
        }

        public static bool IsUseAssetBundle()
        {
            if(Instance._runtimePlatfom == JPlatformType.Android
                || Instance._runtimePlatfom == JPlatformType.IPhonePlayer)
            {
                return true;
            }

            return false;
        }


        JPlatformType _runtimePlatfom = JPlatformType.None;
        Vector3 gravity = Vector3.zero;


        [SerializeField]
        UnityEvent appStartMethod = null;

        //#region property
        //public bool IsLoadTable { get { return isLoadTable; } }

        //public bool IsLoadLocalizeTable { get { return isLoadLocalizeTable; } }
        //#endregion 
        void Awake()
        {
            TableLoader.Initialize(); 
            GlobalEventQueue.Initialize();
            JResources.Initialize();
            OnAwake();
            GlobalEventQueue.RegisterListener(DefaultEvent.LoadScene, ListenSceneChange);
            GlobalEventQueue.RegisterListener(DefaultEvent.AddScene, ListenAddScene);
            GlobalEventQueue.RegisterListener(DefaultEvent.UnloadScene, ListenUnloadScene);
            SceneManager.sceneLoaded += LoadedCompleteMethod;
            gravity = Physics.gravity;


            if( null != appStartMethod )
            {
                appStartMethod.Invoke();
            }
        }

        public void ListenSceneChange(object param )
        {
            string sceneName = param as string;
            if(!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene( sceneName );
            }
        }

        public void ListenAddScene( object sceneName )
        {
            string name = sceneName as string;
            if(!string.IsNullOrEmpty(name))
            {
                SceneManager.LoadScene( name, LoadSceneMode.Additive );
            }
        }

        public void ListenUnloadScene( object param )
        {
            string sceneName = param as string;
            if(!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.UnloadSceneAsync(sceneName);
            }
        }

        public void LoadedCompleteMethod(Scene scene, LoadSceneMode mode)
        {
            GlobalEventQueue.EnQueueEvent( DefaultEvent.CompleteLoadScene, scene.name );
        }

        public virtual void OnAwake() { }

        void OnDistroy()
        {
            GlobalEventQueue.RemoveListener(DefaultEvent.LoadScene, ListenSceneChange);
            GlobalEventQueue.RemoveListener(DefaultEvent.AddScene, ListenAddScene);
            GlobalEventQueue.RemoveListener(DefaultEvent.UnloadScene, ListenUnloadScene);

        }
    }
}
