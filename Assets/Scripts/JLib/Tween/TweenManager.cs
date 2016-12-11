using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
namespace JLib
{
    public class TweenManager : MonoSingle<TweenManager>
    {
        Dictionary<int,Tween> tweens = new Dictionary<int, Tween>();

        public static void AddTween( Tween tween )
        {
            Instance.tweens.Add( tween.GetInstanceID() , tween );
        }

        void Awake()
        {
            GlobalEventQueue.RegisterListener( DefaultEvent.DoTween , ListenDoTween );
        }
        void Update()
        {
            ItorUpdate();

            //ForLinqUpdate();

            //ForeachUpdate();
        }


        private void ForeachUpdate()
        {
            foreach( var item in tweens )
            {
                if( item.Value.enabled )
                {
                    item.Value.UpdateTween();
                }

            }
        }
        private void ForLinqUpdate()
        {
            for( int i = 0 ; i < tweens.Count ; i++ )
            {
                var tween = tweens.ElementAt(i);
                if( tween.Value.enabled )
                {
                    tween.Value.UpdateTween();
                }
            }
        }

        private void ItorUpdate()
        {
            var enumerator = tweens.GetEnumerator();

            while( enumerator.MoveNext() )
            {
                var tween = enumerator.Current;
                if( tween.Value.enabled )
                {
                    tween.Value.UpdateTween();
                }
            }
        }

        public void ListenDoTween( object parameter )
        {
            ListenDoTweenParameter param = parameter as ListenDoTweenParameter;
            if( null == param )
            {
                Debug.LogErrorFormat( "TweenManger.ListenDoTween=> parameter({0}) is not ListenDoTweenParameter" ,
                    parameter.ToString() );
                return;
            }

            Tween foundedTween = null;
            if( !tweens.TryGetValue( param.instnaceID , out foundedTween ) )
            {
                Debug.LogErrorFormat( "TweenManger.ListenDoTween=> id: {0} is not founded" ,
                    param.instnaceID );
                return;
            }

            foundedTween.enabled = true;
        }
    }
}
