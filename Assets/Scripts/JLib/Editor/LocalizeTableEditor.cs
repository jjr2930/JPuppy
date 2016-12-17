using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using JLib;
namespace JLibEditor
{
 
    public class LocalizeTableEditor : EditorWindow
    {
        string path = "";
        LocalizeTableEditorDataList table = null;
        Vector2 scrollPos = Vector2.zero;

        [MenuItem( "Tools/TableEditor/LocalizeTable" )]
        static void ShowWindow()
        {
            EditorWindow.GetWindow( typeof( LocalizeTableEditor ) );
        }

        void OnGUI()
        {
            CheckTableValidationAndInitial();
            scrollPos = EditorGUILayout.BeginScrollView( scrollPos );
            {
                EditorGUILayout.BeginVertical();
                {
                    OnGUI_ColumnName();
                    OnGUI_TableBody();
                    OnGUI_ETC();
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndScrollView();
        }

        void OnGUI_ColumnName()
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.LabelField( "Key" );
                EditorGUILayout.LabelField( "Korean" );
                EditorGUILayout.LabelField( "English" );
            }
            EditorGUILayout.EndHorizontal();
        }

        void OnGUI_TableBody()
        {
            for( int i = 0 ; i < table.table.Count ; i++ )
            {

                EditorGUILayout.BeginVertical();
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        table.table[ i ].key = EditorGUILayout.TextField( table.table[ i ].key );
                        table.table[ i ].list[ ( int )Enum_Local.Korean ] = EditorGUILayout.TextField( table.table[ i ].list[ ( int )Enum_Local.Korean ] );
                        table.table[ i ].list[ ( int )Enum_Local.English ] = EditorGUILayout.TextField( table.table[ i ].list[ ( int )Enum_Local.English ] );
                        if( GUILayout.Button( "-" , GUILayout.MinWidth( 30 ) , GUILayout.MaxWidth( 30 ) ) )
                        {
                            DeleteItem( i );
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndVertical();
            }
        }

        void OnGUI_ETC()
        {
            if( GUILayout.Button( "+" ) )
            {
                table.table.Add( new LocalizeTableEditorData() );
            }

            if( GUILayout.Button( "Save" ) )
            {
                Save();
            }
        }

        void DeleteItem( int index )
        {
            table.table.RemoveAt( index );
        }

        void Save()
        {
            string json = JsonUtility.ToJson(table,true);
            Debug.Log( json );
            if( !System.IO.File.Exists( path ) )
            {
                var opened = System.IO.File.Open(path, System.IO.FileMode.OpenOrCreate);
                opened.Close();
            }
            System.IO.File.WriteAllText( path , json );
        }
        void CheckTableValidationAndInitial()
        {
            if( null == table )
            {
                table = new LocalizeTableEditorDataList();
            }

            if( string.IsNullOrEmpty( path ) )
            {
                TextAsset txt =  AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Resources/Tables/TablePath.txt");
                string json = txt.text;
                TablePathList tpt = JsonUtility.FromJson<TablePathList>(json);
                for( int i = 0 ; i < tpt.tablesPath.Count ; i++ )
                {
                    if( "LocalizeTable" == tpt.tablesPath[ i ].name )
                    {
                        path = "Assets/Resources/Tables/" + tpt.tablesPath[ i ].path + ".txt";
                        if( !System.IO.File.Exists( path ) )
                        {
                            var opened = System.IO.File.Open(path, System.IO.FileMode.OpenOrCreate);
                            opened.Close();
                        }
                        TextAsset localAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(path);
                        table = JsonUtility.FromJson<LocalizeTableEditorDataList>(localAsset.text);
                        return;
                    }
                }
            }
        }
    }
}