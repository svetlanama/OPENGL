﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb2
{
    class Program
    {

        private static float quadPosZ = 0.0f;
        private static float quadScale = 0.0f;

        static void Init()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
        }

        static void Reshape(int w, int h)
        {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float)w / (float)h, 0.1f, 100f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(1f, 1f, 5f, 0f, 0f, 0f, 0f, 1f, 0f);
        }

        static void Display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glPushMatrix();

            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f); // ось x
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(10f, 0f, 0f);

            Gl.glColor3f(1.0f, 0.0f, 0.0f); // ось y
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 10f, 0f);

            Gl.glColor3f(0.0f, 0.0f, 1.0f); // ось z
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 10f);
            Gl.glEnd();

            // Смещение фигуры
            Gl.glTranslatef(0f, 0f, quadPosZ);
            Gl.glScalef(quadScale, quadScale, quadScale);

            //Четирех-угоьник
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(1.0f, 0.5f, 0.0f);  
            Gl.glVertex3i(2,1,0);
            Gl.glVertex3i(1,0,1);
            Gl.glVertex3i(0, 0, 1);
            Gl.glVertex3i(1, 1, 1);
            Gl.glEnd();



            Gl.glDisable(Gl.GL_LINE_STIPPLE);
            Gl.glPopMatrix();
            Glut.glutSwapBuffers();

            // Сымещение фигуры

            quadPosZ -= 0.01f;
            if (quadScale < 4)  {
                quadScale += 1.05f;
            } else {
                quadScale = 0.0f;
            }
   
        }

        static void Timer(int value)
        {
            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(1000, Timer, 0);
        }

        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(600, 600);
            Glut.glutCreateWindow("OPENGL LB1");
            Init();

            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Display);
            Glut.glutTimerFunc(0, Timer, 0);

            Glut.glutMainLoop();
        }
    }
}
