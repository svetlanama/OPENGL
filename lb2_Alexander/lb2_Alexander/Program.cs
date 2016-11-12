using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb2_Alexander
{
    class Program
    {
        private static float _figureScale = 3.0f;
        private static int _mlsec = 1000;

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
            // Уменьшение размеров фигуры
            Gl.glScalef(_figureScale, _figureScale, _figureScale);
        }

        static void CalculateNewFigureSize()
        {
            //Уменьшение  фигуры
            _figureScale = _figureScale >= 1 ? _figureScale - 0.95f : 3.0f;
        }

        static void DrawSquad()
        {
            //Четирех-угольник
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glColor3f(1.0f, 1.0f, 0.0f);
            Gl.glVertex3f(2f, 0f, 0f);
            Gl.glVertex3f(1f, 0f, 1f);
            Gl.glVertex3f(0f, 0f, 1f);
            Gl.glVertex3f(1f, 1f, 1f);
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

            CalculateNewFigureSize();
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
            Glut.glutCreateWindow("LB2: Squad");
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
