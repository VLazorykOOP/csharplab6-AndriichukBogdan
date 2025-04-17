namespace Lab6Charp
{
    using System;
    internal class Program
    {
        interface Person
        {
            string name
            {
                get;
                set;
            }
            int age
            {
                get;
                set;
            }
            int salary
            {
                get;
                set;
            }
            abstract void Show();
        }

        class Student : Person,IComparable
        {
            private string Name;
            private int Age;
            private int Salary;
            private string Faculty;

            public string name
            {
                get
                {
                    return this.Name;
                }
                set
                {
                    this.Name = value;
                }
            }
            public int age
            {
                get
                {
                    return this.Age;
                }
                set
                {
                    this.Age = value;
                }
            }
            public int salary
            {
                get
                {
                    return this.Salary;
                }
                set
                {
                    this.Salary = value;
                }
            }
            public string faculty
            {
                get
                {
                    return this.Faculty;
                }
            }

            public Student(string n, int a, int s, string f)
            {
                this.Name = n;
                this.Age = a;
                this.Salary = s;
                this.Faculty = f;
            }

            ~Student()
            {
                Console.WriteLine("Delete Student!");
            }

            public void Show()
            {
                Console.WriteLine("Name:{0}\nAge:{1}\nSalary:{2}\nFaculty:{3}", this.Name, this.Age, this.Salary, this.Faculty);
            }
            public int CompareTo(object obj)
            {

                if (obj == null) return 1;

                Student other = obj as Student;
                if (other != null)
                {
                    if (this.age > other.age) return 1;
                    if (this.age < other.age) return -1;
                    return 0;
                }
                else
                {
                    throw new ArgumentException("Error class");
                }
            }
        }

        class Teacher : Person
        {
            protected string Name;
            protected int Age;
            protected int Salary;
            protected string Subject;
            protected int Experience;

            public string name
            {
                get
                {
                    return this.Name;
                }
                set
                {
                    this.Name = value;
                }
            }
            public int age
            {
                get
                {
                    return this.Age;
                }
                set
                {
                    this.Age = value;
                }
            }
            public int salary
            {
                get
                {
                    return this.Salary;
                }
                set
                {
                    this.Salary = value;
                }
            }
            public string subject
            {
                get
                {
                    return this.Subject;
                }
            }
            public int experience
            {
                get
                {
                    return this.Experience;
                }
            }

            public Teacher(string n, int a, int s, string sub, int e)
            {
                this.Name = n;
                this.Age = a;
                this.Salary = s;
                this.Subject = sub;
                this.Experience = e;
            }
            ~Teacher()
            {
                Console.WriteLine("Delete Teacher!");
            }

            public void Show()
            {
                Console.WriteLine("Name:{0}\nAge:{1}\nSalary:{2}\nSubject:{3}\nExperiance:{4}", this.Name, this.Age, this.Salary, this.Subject, this.Experience);
            }
            public int CompareTo(object obj)
            {

                if (obj == null) return 1;

                Teacher other = obj as Teacher;
                if (other != null)
                {
                    if (this.age > other.age) return 1;
                    if (this.age < other.age) return -1;
                    return 0;
                }
                else
                {
                    throw new ArgumentException("Error class");
                }
            }
        }
        class HeadOfDepartment : Teacher
        {
            private string Department;
            public HeadOfDepartment(string n, int a, int s, string sub, int e, string d) : base(n, a, s, sub, e)
            {
                this.Department = d;
            }
            ~HeadOfDepartment()
            {
                Console.WriteLine("Delete HeadOfDepartment!");
            }

            public void Show()
            {
                Console.WriteLine("Name:{0}\nAge:{1}\nSalary:{2}\nSubject:{3}\nExperiance:{4}\nDepartment{5}", this.Name, this.Age, this.Salary, this.Subject, this.Experience, this.Department);
            }
            public int CompareTo(object obj)
            {

                if (obj == null) return 1;

                HeadOfDepartment other = obj as HeadOfDepartment;
                if (other != null)
                {
                    if (this.age > other.age) return 1;
                    if (this.age < other.age) return -1;
                    return 0;
                }
                else
                {
                    throw new ArgumentException("Error class");
                }
            }
        }

        interface Figure
        {
            void Show();
            double Perimeter();
            double Area();
        }
        class Rectangle : Figure
        {
            protected double width;
            protected double height;

            public Rectangle(double width, double height)
            {
                this.width = width;
                this.height = height;
            }

            public double Perimeter()
            {
                return 2 * this.width + 2 * this.height;
            }
            public double Area()
            {
                return this.width * this.height;
            }
            public void Show()
            {
                Console.WriteLine("Width:{0}\nHeight:{1}\nPerimeter:{2}\nArea:{3}",this.width,this.height,this.Perimeter(),this.Area());
            }
            public int CompareTo(object obj)
            {

                if (obj == null) return 1;

                Rectangle other = obj as Rectangle;
                if (other != null)
                {
                    if (this.Area() > other.Area()) return 1;
                    if (this.Area() < other.Area()) return -1;
                    return 0;
                }
                else
                {
                    throw new ArgumentException("Error class");
                }
            }

        }

        class Circle : Figure
        {

            protected double radius;

            public Circle(double radius)
            {
                this.radius = radius;
            }


            public double Perimeter()
            {
                return this.radius * 2 * Math.PI;
            }
            public double Area()
            {
                return this.radius * this.radius * Math.PI;
            }
            public void Show()
            {
                Console.WriteLine("Radius:{0}\nPerimetr:{1}\nArea:{2}",this.radius,this.Perimeter(),this.Area());
            }
            public int CompareTo(object obj)
            {

                if (obj == null) return 1;

                Circle other = obj as Circle;
                if (other != null)
                {
                    if (this.Area() > other.Area()) return 1;
                    if (this.Area() < other.Area()) return -1;
                    return 0;
                }
                else
                {
                    throw new ArgumentException("Error class");
                }
            }
        }

        class Triangle : Figure
        {
            protected double sideA;
            protected double sideB;
            protected double sideC;

            public Triangle(double sideA, double sideB, double sideC)
            {
                this.sideA = sideA;
                this.sideB = sideB;
                this.sideC = sideC;
            }

            public double Perimeter()
            {
                return this.sideA + this.sideB + this.sideC;
            }
            public double Area()
            {
                double s = this.Perimeter();
                return Math.Sqrt((s - this.sideA) * (s - this.sideB) * (s - this.sideC));
            }
            public void Show()
            {
                Console.WriteLine("Side A:{0}\nSide B:{1}\nSide C:{2}\nPerimetr:{3}\nArea:{4}",this.sideA,this.sideB,this.sideC,this.Perimeter(),this.Area());
            }
            public int CompareTo(object obj)
            {

                if (obj == null) return 1;

                Triangle other = obj as Triangle;
                if (other != null)
                {
                    if (this.Area() > other.Area()) return 1;
                    if (this.Area() < other.Area()) return -1;
                    return 0;
                }
                else
                {
                    throw new ArgumentException("Error class");
                }
            }
        }



        static void Main(string[] args)
        {
            Student joe = new Student("Joe", 24, 20000, "CS");
            joe.Show();
        }
    }
}