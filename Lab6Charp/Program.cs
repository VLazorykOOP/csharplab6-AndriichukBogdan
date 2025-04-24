using System;
using System.Collections;

namespace LabWork
{
    interface Person
    {
        string Name { get; set; }
        int Age { get; set; }
        int Salary { get; set; }
        void Show();
    }

    class Student : Person, ICloneable
    {
        private string name;
        private int age;
        private int salary;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public int Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public Student(string n, int a, int s)
        {
            this.name = n;
            this.age = a;
            this.salary = s;
        }

        public void Show()
        {
            Console.WriteLine("Student: {0}, Age: {1}, Salary: {2}", name, age, salary);
        }

        public object Clone()
        {
            return new Student(name, age, salary);
        }
    }

    class Teacher : Person, ICloneable
    {
        private string name;
        private int age;
        private int salary;
        private string subject;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
        public int Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
            }
        }
        public Teacher(string n, int a, int s, string sub)
        {
            this.name = n;
            this.age = a;
            this.salary = s;
            this.subject = sub;
        }

        public void Show()
        {
            Console.WriteLine("Teacher: {0}, Age: {1}, Salary: {2}", name, age, salary);
        }

        public object Clone()
        {
            return new Teacher(this.name, this.age, this.salary, this.subject);
        }
    }

    interface Figure
    {
        void Show();
        double GetPerimeter();
        double GetArea();
    }

    class Circle : Figure, ICloneable
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public void Show()
        {
            Console.WriteLine("Circle: Radius = {0}, Perimeter = {1}, Area = {2}", radius, GetPerimeter(), GetArea());
        }

        public object Clone()
        {
            return new Circle(this.radius);
        }
    }

    class Rectangle : Figure, ICloneable
    {
        protected double width;
        protected double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double GetPerimeter()
        {
            return 2 * this.width + 2 * this.height;
        }

        public double GetArea()
        {
            return this.width * this.height;
        }

        public void Show()
        {
            Console.WriteLine("Width:{0}\nHeight:{1}\nPerimeter:{2}\nArea:{3}", this.width, this.height, this.GetPerimeter(), this.GetArea());
        }

        public object Clone()
        {
            return new Rectangle(width, height);
        }
    }

    class Triangle : Figure, ICloneable
    {
        private double a, b, c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double GetPerimeter()
        {
            return a + b + c;
        }

        public double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public void Show()
        {
            Console.WriteLine("Triangle: Sides = {0}, {1}, {2}, Perimeter = {3}, Area = {4}", a, b, c, GetPerimeter(), GetArea());
        }

        public object Clone()
        {
            return new Triangle(a, b, c);
        }
    }


    class VectorInt : IEnumerable
    {
        protected int[] IntArray;
        protected uint size;
        protected int codeError;
        protected static uint num_vec = 0;

        public VectorInt()
        {
            this.size = 1;
            this.IntArray = new int[this.size];
            this.IntArray[0] = 0;
            num_vec++;
        }

        public VectorInt(uint size)
        {
            this.size = size;
            this.IntArray = new int[this.size];
            for (int i = 0; i < this.size; i++)
            {
                this.IntArray[i] = 0;
            }
            num_vec++;
        }

        public VectorInt(uint size, int value)
        {
            this.size = size;
            this.IntArray = new int[this.size];
            for (int i = 0; i < this.size; i++)
            {
                this.IntArray[i] = value;
            }
            num_vec++;
        }

        ~VectorInt()
        {
            Console.WriteLine("Vector deleted.");
        }

        public void AssignValue(int value)
        {
            for (int i = 0; i < this.size; i++)
            {
                this.IntArray[i] = value;
            }
        }

        public static uint CountVectors()
        {
            return num_vec;
        }

        public uint Size => this.size;

        public int CodeError
        {
            get { return this.codeError; }
            set { this.codeError = value; }
        }

        public int this[int i]
        {
            get
            {
                if (i >= 0 && i < this.size) return this.IntArray[i];
                Console.WriteLine("Invalid index!");
                return 0;
            }
            set
            {
                if (i >= 0 && i < this.size) this.IntArray[i] = value;
                else this.codeError = -1;
            }
        }

        public static VectorInt operator ++(VectorInt v)
        {
            for (int i = 0; i < v.size; i++) v.IntArray[i]++;
            return v;
        }

        public static VectorInt operator --(VectorInt v)
        {
            for (int i = 0; i < v.size; i++) v.IntArray[i]--;
            return v;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.size; i++)
            {
                yield return this.IntArray[i];
            }
        }
    }


    class Program
    {
        static void task1()
        {
            Student st = new Student("Ivan", 20, 1000);
            st.Show();
            Teacher tc = new Teacher("Petro", 45, 3000, "CS");
            tc.Show();

            Teacher tc2 = (Teacher)tc.Clone();
            tc2.Show();
        }

        static void task2()
        {
            Circle circle = new Circle(5);
            circle.Show();
            Circle circle2 = (Circle)circle.Clone();
            circle2.Show();

            Rectangle rect = new Rectangle(4, 6);
            rect.Show();
            Rectangle rect2 = (Rectangle)rect.Clone();
            rect2.Show();

            Triangle triangle = new Triangle(3, 4, 5);
            triangle.Show();
            Triangle triangle2 = (Triangle)triangle.Clone();
            triangle2.Show();
        }

        static void task3()
        {
            Console.Write("Введіть розмір вектора: ");
            uint size = Convert.ToUInt32(Console.ReadLine());

            Console.Write("Введіть значення для заповнення: ");
            int value = Convert.ToUInt16(Console.ReadLine());

            VectorInt vec = new VectorInt(size, value);

            Console.WriteLine("Елементи вектора через foreach:");
            foreach (int num in vec)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine();
        }


        static void choose_task()
        {
            Console.Write("1. Point\n2. Figure\n3. Person and Figures\n");
            int answer = Convert.ToInt16(System.Console.ReadLine());

            switch (answer)
            {
                case 1:
                    {
                        task3();
                        Console.Write("\n\n\n");
                        choose_task();
                        break;
                    }
                case 2:
                    {
                        task2();
                        Console.Write("\n\n\n");
                        choose_task();
                        break;
                    }
                case 3:
                    {
                        task1();
                        Console.Write("\n\n\n");
                        choose_task();
                        break;
                    }
                default:
                    {
                        choose_task();
                        break;
                    }
            }
        }

        static void Main(string[] args)
        {
            choose_task();
        }
    }
}
