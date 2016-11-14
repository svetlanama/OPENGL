using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb4
{
    class Program
    {
        private static float[] no_mat = { 0.0f, 0.0f, 0.0f, 1.0f };
        private static float[] mat_ambient = { 0.7f, 0.7f, 0.7f, 1.0f };
        private static float[] mat_ambient_color = { 0.8f, 0.8f, 0.2f, 1.0f };
        private static float[] mat_diffuse = { 0.1f, 0.5f, 0.8f, 1.0f };
        private static float[] mat_specular = { .1f, .1f, .1f, .1f };
        private static float no_shininess = 0.0f;
        private static float low_shininess = 5.0f;
        private static float high_shininess = 100.0f;
        private static float[] mat_emission = { 0.3f, 0.2f, 0.2f, 0.0f };
        private static float[] lpt = {2, 1, 1};
        private static float[] rpt = {1, 1, 2};

        private static float _angleLight1 = 0;
        private static float _angleLight2 = 0;

        private static int _refreshMills = 15;

        static void Init()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f); // Set background color to black and opaque
            Gl.glClearDepth(1.0f);                   // Set background depth to farthest
            Gl.glEnable(Gl.GL_DEPTH_TEST);   // Enable depth testing for z-culling
            Gl.glDepthFunc(Gl.GL_LEQUAL);    // Set the type of depth-test
            Gl.glShadeModel(Gl.GL_SMOOTH);   // Enable smooth shading
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);  // Nice perspective corrections
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
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

            Gl.glPushMatrix();
                Gl.glRotatef(_angleLight1, 0f, 0f, 1f);
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lpt);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslatef(0f, 0f, 5f);
                Gl.glScalef(2f, 2f, 2f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, no_mat);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat_diffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, no_mat);
                Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, no_shininess);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, no_mat);
                Glut.glutSolidCone(1, 2, 50, 50);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glRotatef(_angleLight1, 0f, 1f, 0f);
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, rpt);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslatef(6f, 0f, 0f);
                Gl.glScalef(2f, 2f, 2f);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, mat_ambient);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, mat_diffuse);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, mat_specular);
                Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, no_shininess);
                Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, mat_emission);
                Glut.glutSolidSphere(1.0, 50, 50);
           Gl.glPopMatrix();

            Glut.glutSwapBuffers();

            // вращение
            _angleLight1 += 1f;
            _angleLight2 += 1.5f;
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
            Glut.glutCreateWindow("OPENGL LB4");
            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Display);
            Glut.glutTimerFunc(0, Timer, 0);

            Init();

            Glut.glutMainLoop();
        }
    }
}
