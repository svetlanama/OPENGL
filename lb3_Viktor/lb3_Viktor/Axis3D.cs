using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb3_Viktor
{
    class Axis3D
    {

        public static void DrawAxis()
        {
            DrawAxisLines();
        }

        static void DrawAxisLines()
        {
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(10f, 0f, 0f);

            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 10f, 0f);

            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 10f);

            Gl.glColor3f(0.0f, 1.0f, 0.0f);
            Gl.glVertex3f(-10f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 0f);

            Gl.glColor3f(1.0f, 0.0f, 0.0f);
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, -10f, 0f);

            Gl.glColor3f(0.0f, 0.0f, 1.0f);
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, -10f);
            Gl.glEnd();
        }
    }
}
