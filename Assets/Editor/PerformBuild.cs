using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

 class PerformBuild 
{
	/// <summary>
	/// Gets the build scenes.
	/// </summary>
	/// <returns>The build scenes.</returns>
	static string[] GetBuildScenes(){
	
	
	
		List<string> names = new List<string> ();

		foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes) 
		{

			if (e == null) {
				continue;
			}
			if (e.enabled) {
				names.Add (e.path);
			}

		}
	
		return names.ToArray ();
	
	
	}

	/// <summary>
	/// Gets the build path.
	/// </summary>
	/// <returns>The build path.</returns>
	static string GetBuildPath()
	{


		string dirPath = Application.dataPath + "/../../../build/android";
		if (!System.IO.Directory.Exists(dirPath)) {

			System.IO.Directory.CreateDirectory (dirPath);


		}

		return dirPath;

	}


	[UnityEditor.MenuItem("Tools/PerformBuild/Test Command Line Build Step Android")]


	/// <summary>
	/// Commands the line build android.
	/// </summary>
	static void CommandLineBuild()
	{

		Debug.Log("Command line build android version\n--------------------\n----------------------");


		string[] scenes = GetBuildScenes ();

		string path = GetBuildPath ();

		if (scenes == null || scenes.Length==0||path==null) {

			return;
		}

		Debug.Log (string.Format ("Path: \"{0}\"", path));

		for (int i = 0; i < scenes.Length; ++i) {


			Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));

		}

		Debug.Log ("Starting Android Build");

		BuildPipeline.BuildPlayer (scenes, path, BuildTarget.Android, BuildOptions.None);



	}









}

