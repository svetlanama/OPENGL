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
        private static float[] ambient = { 0.0f, 0.0f, 0.0f, 1.0f };
        private static float[] diffuse = { 1.0f, 0.0f, 0.0f, 0.1f };
        private static float[] specular = { 0.2f, 0.1f, 0.1f, 0.1f };
        private static float[] emission = { 0.0f, 0.0f, 0.0f, 1.0f };

        private static float  shininess = 1.09f;

        private static float[] light1 = { 0, 0, 4 };
        private static float[] light2 = { 0, 0, -4 };

        private static float _angleSphereY = 0.0f;
        private static int _mlsec = 500;

        static void InitializeViewAppearance()
        {
            Gl.glClearColor(0.1f, 0.1f, 0.1f, 0.0f);

            Gl.glClearDepth(10.0f);          // Усиановка глубины
            Gl.glEnable(Gl.GL_DEPTH_TEST);   // Enable depth testing for z-culling
            Gl.glDepthFunc(Gl.GL_LEQUAL);    // Тип глубины
            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);

            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_LIGHT1);
        }

        static void CreateWindow()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA);
            Glut.glutInitWindowSize(_widowSize, _widowSize);
            Glut.glutCreateWindow("LB4: Glass sphere");
            InitializeViewAppearance();

            Glut.glutReshapeFunc(Reshape);
            Glut.glutDisplayFunc(Redraw);
            Glut.glutTimerFunc(0, Timer, 0);

            Glut.glutMainLoop();
        }

        static void Reshape(int w, int h)
        {
            if (h == 0) h = 1;
            float aspect = (float)w / (float)h;
            Gl.glViewport(0, 0, w, h);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(140.0f, aspect, 0.1f, 100.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(1f, 3f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);// пользователь смотрит с точки  1 3 5
        }

        static void Redraw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();

            Axis3D.DrawAxis();

            FigureMotion();

            // Установка материала шара
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light1);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light2);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, ambient);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, diffuse);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, specular);
            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_EMISSION, emission);
            Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, shininess);

            // Отрисовка шара
            Glut.glutSolidSphere(3.0, 50, 50); // шар с радиусом 3

            Gl.glPopMatrix();
            Glut.glutSwapBuffers(); // Переключение буфферов отрисовки

            CalculateNewFigureSize();
        }

        static void Timer(int value)
        {
            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(0, Timer, 0);
        }

        static void CalculateNewFigureSize()
        {
            _angleSphereY += 1;
        }

        static void FigureMotion()
        {
            // Вращение фигуры вокруг Y
            Gl.glRotatef(_angleSphereY, 0f, 1.0f, 0f);
        }

        static void Main(string[] args)
        {
            CreateWindow();
        }
    }
}
