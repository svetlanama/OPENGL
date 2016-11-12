using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace lb3_Alexander
{
    class Axis3D
    {

        public static void DrawAxis()
        {
            DrawAxisLines();
            DrawAxisDottedLines();
        }

        static void DrawAxisLines()
        {
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
        }

        static void DrawAxisDottedLines()
        {
            Gl.glEnable(Gl.GL_LINE_STIPPLE);				// Построение точесных линий - отрицательные координаты
            Gl.glLineStipple(1, 0x0101);				   // Узор для линий
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3f(0.0f, 1.0f, 0.0f);         // Green for x axis
            Gl.glVertex3f(-10f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, 0f);

            Gl.glColor3f(1.0f, 0.0f, 0.0f);             // Red for y axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, -10f, 0f);

            Gl.glColor3f(0.0f, 0.0f, 1.0f);             // Blue for z axis
            Gl.glVertex3f(0f, 0f, 0f);
            Gl.glVertex3f(0f, 0f, -10f);
            Gl.glEnd();
        }
    }
}
