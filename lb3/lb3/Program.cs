using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb3
{
    class Program
    {
        private static float _anglePyramidX = 0.0f;
        private static float _anglePyramidY = 0.0f;
        private static float _anglePyramidZ = 0.0f;

        private static int _refreshMills = 15;

        static void Init()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Set background color to black and opaque
            Gl.glClearDepth(1.0f);                   // Set background depth to farthest
            Gl.glEnable(Gl.GL_DEPTH_TEST);   // Enable depth testing for z-culling
            Gl.glDepthFunc(Gl.GL_LEQUAL);    // Set the type of depth-test
            Gl.glShadeModel(Gl.GL_SMOOTH);   // Enable smooth shading
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);  // Nice perspective corrections
        }

        static void Display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();

            Gl.glBegin(Gl.GL_LINES);
                Gl.glColor3f(0.0f, 1.0f, 0.0f); // ось x
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(14f, 0f, 0f);

                Gl.glColor3f(1.0f, 0.0f, 0.0f); // ось y
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, 14f, 0f);

                Gl.glColor3f(0.0f, 0.0f, 1.0f); // ось z
                Gl.glVertex3f(0f, 0f, 0f);
                Gl.glVertex3f(0f, 0f, 14f);
            Gl.glEnd();

            Gl.glTranslatef(3f, 3f, 3f);
            Gl.glScalef(3f, 3f, 3f);
            Gl.glRotatef(_anglePyramidX, 1.0f, 0f, 0f);
            Gl.glRotatef(_anglePyramidY, 0f, 1.0f, 0f);
            Gl.glRotatef(_anglePyramidZ, 0f, 0f, 1.0f);
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

            Gl.glPopMatrix();
            Glut.glutSwapBuffers();

            // вращение
            _anglePyramidX += 1f;
            _anglePyramidY += 1.5f;
            _anglePyramidZ += 0.5f;
        }

        static void Timer(int value)
        {
            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(_refreshMills, Timer, 0);
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

        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(600, 600);
            Glut.glutCreateWindow("OPENGL LB3");
            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Display);
            Glut.glutTimerFunc(0, Timer, 0);

            Init();

            Glut.glutMainLoop();
        }
    }
}
