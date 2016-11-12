using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;


namespace lb3_Alexander
{
    class Program
    {
        private static int _widowSize = 800;
        private static float _anglePyramidY = 0.0f;
        private static float _anglePyramidX = 0.0f;
        private static int _mlsec = 100;

        static void CreateWindow()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(_widowSize, _widowSize);
            Glut.glutCreateWindow("LB1: Piramid");
            InitializeViewAppearance();

            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Redraw);
            Glut.glutTimerFunc(0, Timer, 0);

            Glut.glutMainLoop();
        }

        static void InitializeViewAppearance()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
           // Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
        }

        static void Reshape(int w, int h)
        {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float)w / (float)h, 0.1f, 200f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(1f, 1f, 5f, 0f, 0f, 0f, 0f, 1f, 0f);
        }

        static void Redraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();

            Axis3D.DrawAxis();
            FigureMotion();
            DrawTriangle();

            Gl.glDisable(Gl.GL_LINE_STIPPLE);
            Gl.glPopMatrix();
            Glut.glutSwapBuffers();

            CalculateNewFigureSize();
        }

        static void DrawTriangle()
        {
            Gl.glBegin(Gl.GL_TRIANGLES);

            // Front
            Gl.glColor3f(1.0f, 0.0f, 0.0f);     // красный
            Gl.glVertex3f(0.0f, 1.0f, 0.0f);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);     // зеленый
            Gl.glVertex3f(-1.0f, -1.0f, 1.0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);     // голубой
            Gl.glVertex3f(1.0f, -1.0f, 1.0f);

            // Right
            Gl.glColor3f(1.0f, 0.0f, 0.0f);     // красный
            Gl.glVertex3f(0.0f, 1.0f, 0.0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);     // голубой
            Gl.glVertex3f(1.0f, -1.0f, 1.0f);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);     // зеленый
            Gl.glVertex3f(1.0f, -1.0f, -1.0f);

            // Back
            Gl.glColor3f(1.0f, 0.0f, 0.0f);     // красный
            Gl.glVertex3f(0.0f, 1.0f, 0.0f);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);     // зеленый
            Gl.glVertex3f(1.0f, -1.0f, -1.0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);     // голубой
            Gl.glVertex3f(-1.0f, -1.0f, -1.0f);

            // Left
            Gl.glColor3f(1.0f, 0.0f, 0.0f);       // красный
            Gl.glVertex3f(0.0f, 1.0f, 0.0f);
            Gl.glColor3f(0.0f, 0.0f, 1.0f);       // голубой
            Gl.glVertex3f(-1.0f, -1.0f, -1.0f);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);       // зеленый
            Gl.glVertex3f(-1.0f, -1.0f, 1.0f);
            Gl.glEnd();
        }

        static void FigureMotion()
        {
            // Вращение фигуры вокруг Y
            Gl.glRotatef(_anglePyramidY, 0f, 1.0f, 0f);
            Gl.glRotatef(_anglePyramidX, 0f, 1.0f, 0f);
        }

        static void CalculateNewFigureSize()
        {
            _anglePyramidY += 1;
            _anglePyramidX += 1;
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
