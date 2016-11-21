using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb2_Viktor
{
    class Program
    {
        private static float _moveF = 0.01f;
        private static int _mlsec = 50;

        static void InitializeViewAppearance()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
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

        static void FigureMotion()
        {
            Gl.glTranslatef(0f, 0f, _moveF);
            _moveF += 0.01f;

            if (_moveF > 3)
            {
                _moveF = 0.01f;
            }
        }

        static void DrawSquad()
        {
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(-1.0f, -1.0f, 0.0f); // The bottom left corner  
            Gl.glVertex3f(-1.0f, 1.0f, 0.0f); // The top left corner  
            Gl.glVertex3f(1.0f, 1.0f, 0.0f); // The top right corner  
            Gl.glVertex3f(1.0f, -1.0f, 0.0f); // The bottom right corner  
            Gl.glEnd();
        }

        static void Redraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glPushMatrix();

            Axis3D.DrawAxis();

            FigureMotion();
            DrawSquad();

            Gl.glPopMatrix();
            Glut.glutSwapBuffers();
        }

        static void SetupTimer(int value)
        {
            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(_mlsec, SetupTimer, 0);
        }

        static void CreateWindow()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(800, 800);
            Glut.glutCreateWindow("Animation");
            InitializeViewAppearance();

            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Redraw);
            Glut.glutTimerFunc(0, SetupTimer, 0);

            Glut.glutMainLoop();
        }


        static void Main(string[] args)
        {
            CreateWindow();
        }
    }
}
