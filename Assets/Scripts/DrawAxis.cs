﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAxis : MonoBehaviour {

	[HideInInspector] public bool canDraw;

	static Material lineMaterial;
	void OnRenderObject()
	{
		if (canDraw)
		{
			CreateLineMaterial();
			lineMaterial.SetPass(0);
			GL.PushMatrix();
			// Set transformation matrix for drawing to
			// match our transform
			GL.MultMatrix(transform.localToWorldMatrix);

			// Draw lines
			GL.Begin(GL.LINES);
			//Draw X axis
			GL.Color(Color.red);
			GL.Vertex3(0, 0, 0);
			GL.Vertex3(2.0f, 0.0f, 0.0f);
			//Draw Y axis
			GL.Color(Color.green);
			GL.Vertex3(0, 0, 0);
			GL.Vertex3(0.0f, 2.0f, 0.0f);
			//Draw Z axis
			GL.Color(Color.blue);
			GL.Vertex3(0, 0, 0);
			GL.Vertex3(0.0f, 0.0f, 2.0f);
			GL.End();
			GL.PopMatrix();
		}
	}

	void CreateLineMaterial()
	{
		if (!lineMaterial)
		{
			// Unity has a built-in shader that is useful for drawing
			// simple colored things.
			Shader shader = Shader.Find("Hidden/Internal-Colored");
			lineMaterial = new Material(shader);
			lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			// Turn on alpha blending
			lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			// Turn backface culling off
			lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
			// Turn off depth writes
			lineMaterial.SetInt("_ZWrite", 0);
		}
	}
}
