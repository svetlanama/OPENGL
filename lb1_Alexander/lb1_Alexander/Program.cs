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
        
        static void InitializeViewAppearance()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
        }

        static void Reshape(int w, int h)
        {
            Gl.glViewport(0, h / 2, w / 2, h / 2); // вывод в певром квадранте клиентской области
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-1, 1, -1, 1, -1, 1); // установка ортографической проекции

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        static void Display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glPushMatrix();

            Axis3D.DrawAxis();

            Gl.glDisable(Gl.GL_LINE_STIPPLE);
            Gl.glPopMatrix();
            Glut.glutSwapBuffers();
        }

        static void CreateWindow()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(800, 800);
            Glut.glutCreateWindow("Display Axis using Orto projection");
            InitializeViewAppearance();

            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Display);

            Glut.glutMainLoop();
        }

        static void Main(string[] args)
        {
            CreateWindow();
        }
    }
}
