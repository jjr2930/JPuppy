using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// 직업의 요구 능력치 편집기
/// </summary>
public class BallJobDataEditor : EditorWindow
{
    const int WIDTH_JOBNAME = 100;
    const int WIDTH_SLIDER = 300;
    const int WIDTH_DELETE_BTN_WIDTH = 25;
    const int DEFAULT_ELEMENT_DISTANCE = 10;
    
    string path = "Tables/BallJobTable";
    BallJobList jobList = null;
    Vector2 scroll = Vector2.zero;
    [MenuItem( "Tools/TableEditor/BallJobTable" )]
    static void OpenWindow()
    {
        var window = GetWindow<BallJobDataEditor>();
        window.minSize = new Vector2( 1000, 300 );
        window.Initialize();
    }


    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        {
            OnGUI_ColumnName();
            OnGUI_Body();
            OnGUI_Button();
        }
        EditorGUILayout.EndVertical();
    }

    void OnGUI_ColumnName()
    {
        EditorGUILayout.BeginHorizontal();
        {
            EditorGUILayout.LabelField( "직업 이름", GUILayout.MaxWidth( WIDTH_JOBNAME + DEFAULT_ELEMENT_DISTANCE ) );
            EditorGUILayout.LabelField( "직경", GUILayout.MaxWidth( WIDTH_SLIDER + DEFAULT_ELEMENT_DISTANCE ) );
            EditorGUILayout.LabelField( "무게", GUILayout.MaxWidth( WIDTH_SLIDER + DEFAULT_ELEMENT_DISTANCE ) );
            EditorGUILayout.LabelField( "광택", GUILayout.MaxWidth( WIDTH_SLIDER + DEFAULT_ELEMENT_DISTANCE ) );
            EditorGUILayout.LabelField( "탄력", GUILayout.MaxWidth( WIDTH_SLIDER + DEFAULT_ELEMENT_DISTANCE ) );
            EditorGUILayout.LabelField( "초상화 주소", GUILayout.MaxWidth( WIDTH_SLIDER + DEFAULT_ELEMENT_DISTANCE ) );
            EditorGUILayout.LabelField( "설명 키", GUILayout.MaxWidth( WIDTH_SLIDER + DEFAULT_ELEMENT_DISTANCE ) );
        }
        EditorGUILayout.EndHorizontal();
    }

    void OnGUI_Body()
    {
        scroll = EditorGUILayout.BeginScrollView(scroll);
        {
            EditorGUILayout.BeginVertical();
            {
                for( int i = 0; i < jobList.list.Count; i++ )
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        //input job name data
                        jobList.list[ i ].job = ( BallJob )EditorGUILayout.EnumPopup( jobList.list[ i ].job, GUILayout.MaxWidth( WIDTH_JOBNAME ) );

                        //draw radius min max
                        DrawCustomSilder( ref jobList.list[ i ].minRadius, ref jobList.list[ i ].maxRadius, WIDTH_SLIDER );

                        //draw weight min max
                        DrawCustomSilder( ref jobList.list[ i ].minWeight, ref jobList.list[ i ].maxWeight, WIDTH_SLIDER );

                        //draw gloss min max
                        DrawCustomSilder( ref jobList.list[ i ].minGloss, ref jobList.list[ i ].maxGloss, WIDTH_SLIDER );

                        //draw elasticity min max
                        DrawCustomSilder( ref jobList.list[ i ].minElasticity, ref jobList.list[ i ].maxElasticity, WIDTH_SLIDER );

                        //draw potrait path
                        jobList.list[ i ].potraitPath = EditorGUILayout.TextField( jobList.list[ i ].potraitPath, GUILayout.MaxWidth( WIDTH_SLIDER ) );

                        //draw descriptKey
                        jobList.list[ i ].descriptKey = EditorGUILayout.TextField( jobList.list[ i ].descriptKey, GUILayout.MaxWidth( WIDTH_SLIDER ) );

                        //draw delete button
                        if( GUILayout.Button( "-", GUILayout.MaxWidth( WIDTH_DELETE_BTN_WIDTH ) ) ) 
                        {
                            jobList.list.RemoveAt(i);
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndScrollView();
    }

    void OnGUI_Button()
    {
        if(GUILayout.Button("+"))
        {
            jobList.list.Add( new BallJobData() );
        }

        if(GUILayout.Button("Save"))
        {
            Save();
        }
    }

    void DrawCustomSilder(ref float minValue, ref float maxValue, int width)
    {
        EditorGUILayout.LabelField( string.Format( "{0:f4}", minValue ), GUILayout.MaxWidth( 50 ) );
        EditorGUILayout.MinMaxSlider( ref minValue, ref maxValue, 0f, 100f, GUILayout.MaxWidth( width - 100) );
        EditorGUILayout.LabelField( string.Format( "{0:f4}", maxValue ), GUILayout.MaxWidth( 50 ) );
    }

    void Initialize()
    {
        TextAsset table = AssetDatabase.LoadAssetAtPath<TextAsset>( "Assets/Resources/" + path + ".txt" );
        if( null == table )
        {
            //create directory and file
            if( !Directory.Exists( @"./Assets/Resources/Tables" ) )
            {
                Directory.CreateDirectory( @"./Assets/Resources/Tables" );
            }
            FileStream stream = new FileStream( @"./Assets/Resources/" + path + ".txt",
                 FileMode.OpenOrCreate,
                 FileAccess.ReadWrite );
            //clear inside
            ClearSteam( stream );

            //create default data
            jobList = new BallJobList();
            jobList.list = new List<BallJobData>();
            jobList.list.Add( new BallJobData() );
            
            string json = JsonUtility.ToJson( jobList );
            byte[] bytes = Encoding.UTF8.GetBytes( json );

            stream.Write( bytes, 0, bytes.Length );
            stream.Close();
        }
        else
        {
            jobList = JsonUtility.FromJson<BallJobList>( table.text );
        }
    }
    public void ClearSteam( FileStream stream )
    {
        byte[] emptyBytes = new byte[ stream.Length ];
        stream.Write( emptyBytes, 0, emptyBytes.Length );
    }

    void Save()
    {
        string json = JsonUtility.ToJson( jobList, true );
        Debug.Log( json );
        if( !File.Exists( path ) )
        {
            var opened = File.Open( path, FileMode.OpenOrCreate );
            opened.Close();
        }
        File.WriteAllText( path, json );
    }
}
