using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb1
{
    class Program
    {
        static void init()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            Gl.glShadeModel(Gl.GL_FLAT);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
        }

        static void display()
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

        static void reshape(int w, int h)
        {
            Gl.glViewport(0, 0, w/2, h/2);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(75f, (float) w / (float) h, 0.1f, 100f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(10f, 10f, 15f, 0f, 0f, 0f, 0f, 1f, 0f);
        }

        static void Main(string[] args)
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(600, 600);
            Glut.glutCreateWindow("OPENGL LB1");
            init();

            Glut.glutReshapeFunc(reshape);
            Glut.glutDisplayFunc(display);

            Glut.glutMainLoop();
        }
    }
}
