using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb4_Alexander
{
    class Program
    {
        private static int _widowSize = 800;
        private static float[] ambient = { 1.0f, 0.0f, 0.0f, 0.5f };
        private static float[] mat_diffuse = { 1.0f, 0.0f, 0.0f, 0.0f };


        static void InitializeViewAppearance()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

            Gl.glClearDepth(1.0f);                   // Set background depth to farthest
            Gl.glEnable(Gl.GL_DEPTH_TEST);   // Enable depth testing for z-culling
            Gl.glDepthFunc(Gl.GL_LEQUAL);    // Set the type of depth-test
            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
        }

        static void CreateWindow()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(_widowSize, _widowSize);
            Glut.glutCreateWindow("LB1: Piramid");
            InitializeViewAppearance();

            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Redraw);
           // Glut.glutTimerFunc(0, Timer, 0);

            Glut.glutMainLoop();
        }

        static void Reshape(int w, int h)
        {
            if (h == 0) h = 1;
            float aspect = (float)w / (float)h;
            Gl.glViewport(0, 0, w, h);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0f, aspect, 0.1f, 100.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(15f, 15f, 15.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
        }

        static void Redraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();

            Axis3D.DrawAxis();

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, ambient);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat_diffuse);

            Glut.glutSolidSphere(3.0, 50, 50); // шар с радиусом 3


            Gl.glPopMatrix();
            Glut.glutSwapBuffers(); // Переключение буфферов отрисовки
        }

        static void Main(string[] args)
        {
            CreateWindow();
        }
    }
}
