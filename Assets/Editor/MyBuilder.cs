using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyBuilder : MonoBehaviour {
	[UnityEditor.MenuItem("Tools/Build Project AllScene Android")]
	public static void BuildProjectAllSceneAndroid() {
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
		string[] allScene = new string[EditorBuildSettings.scenes.Length];
		int i = 0;
		foreach( EditorBuildSettingsScene scene in EditorBuildSettings.scenes ){
			allScene[i] = scene.path;
			i++;
		}
		PlayerSettings.bundleIdentifier = "com.yourcompany.newgame";
		PlayerSettings.statusBarHidden = true;
		BuildPipeline.BuildPlayer( allScene,
			"newgame.apk",
			BuildTarget.Android,
			BuildOptions.None
		);
	}
}
