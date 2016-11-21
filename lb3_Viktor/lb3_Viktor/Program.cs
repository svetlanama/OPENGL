﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;


namespace lb3_Viktor
{
    class Program
    {
        private static float _anglePyramidZ = 0.0f;
        private static int _mlsec = 10;

        static void CreateWindow()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(800, 600);
            Glut.glutCreateWindow("Pyramid");
            InitializeViewAppearance();

            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Redraw);
            Glut.glutTimerFunc(0, Timer, 0);

            Glut.glutMainLoop();
        }

        static void InitializeViewAppearance()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LEQUAL);
            Gl.glShadeModel(Gl.GL_SMOOTH);
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
        }

        static void Reshape(int w, int h)
        {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float)w / (float)h, 0.1f, 200f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(1f, 1f, 5f, 0f, 0f, 0f, 0f, 3f, 0f);
        }

        static void Redraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();

            Axis3D.DrawAxis();
            RotatePyramid();
            DrawPyramid();

            Gl.glPopMatrix();
            Glut.glutSwapBuffers();
        }

        static void DrawPyramid()
        {
            Gl.glTranslatef(1f, 0f, 1f);
            Gl.glRotatef(_anglePyramidZ, 0f, 0.0f, 1.0f);
            Gl.glRotatef(_anglePyramidZ, 0f, 3.0f, 0.0f);
            Gl.glBegin(Gl.GL_TRIANGLES);

            //front triangle
            Gl.glColor4f(1.0f, 0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-1.0f, -1.0f, 0.0f);
            Gl.glVertex3f(1.0f, -1.0f, 0.0f);

            //right side triangle
            Gl.glColor4f(0.0f, 0.0f, 1.0f, 1.0f);
            Gl.glVertex3f(1.0f, -1.0f, 0.0f);
            Gl.glVertex3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.0f, -1.0f, -1.0f);

            //left side triangle
            Gl.glColor4f(1.0f, 1.0f, 1.0f, 1.0f);
            Gl.glVertex3f(-1.0f, -1.0f, 0.0f);
            Gl.glVertex3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0.0f, -1.0f, -1.0f);

            //bottom triangle
            Gl.glColor4f(0.0f, 1.0f, 0.0f, 1.0f);
            Gl.glVertex3f(-1.0f, -1.0f, 0.0f);
            Gl.glVertex3f(1.0f, -1.0f, 0.0f);
            Gl.glVertex3f(0.0f, -1.0f, -1.0f);

            Gl.glEnd();
        }

        static void RotatePyramid()
        {
            _anglePyramidZ += 1;
        }

        static void Timer(int value)
        {
            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(_mlsec, Timer, 0);
        }

        static void Main(string[] args)
        {
            CreateWindow();
        }
    }
}
