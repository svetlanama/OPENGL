using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb1_Alexander
{


    class Program
    {
        static void Initialization()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
        }


        static void Reshape(int w, int h)
        {
            Gl.glViewport(-w / 2 + 10 , 0, w, h); // вывод в певром квадрате клиентской области
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-1, 1, -1, 1, -1, 1); // установка ортографического проектирования

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
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

            Gl.glDisable(Gl.GL_LINE_STIPPLE);
            Gl.glPopMatrix();
            Glut.glutSwapBuffers();
        }

        static void Main(string[] args)
        {

            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(800, 800);
            Glut.glutCreateWindow("Display Axis using Orto projection");
            Initialization();

            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Display);

            Glut.glutMainLoop();
        }
    }
}
