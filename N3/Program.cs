using System;
using N2;

namespace N2
{
    class Student
    {
        private string fullName;
        private int age;
        private string groupName;

        public Student(
            string fullName,
            int age,
            string groupName
        )
        {
            this.fullName = fullName;
            this.age = age;
            this.groupName = groupName;
        }

        public string FullName
        {
            get { return fullName; }
        }

        public int Age
        {
            get { return age; }
        }

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }
    }


    class Group
    {
        private string groupName;
        private string specialty;
        private int year;
        private List<Student> students;

        public Group(
            string groupName,
            string specialty,
            int year
        )
        {
            this.groupName = groupName;
            this.specialty = specialty;
            this.year = year;
            students = new List<Student>();
        }

        public string GroupName
        {
            get { return groupName; }
        }

        public string Specialty
        {
            get { return specialty; }
        }

        public int Year
        {
            get { return year; }
        }

        public List<Student> Students
        {
            get { return students; }
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }
    }


    class Course
    {
        private string courseName;
        private string teacher;

        public Course(
            string courseName,
            string teacher
        )
        {
            this.courseName = courseName;
            this.teacher = teacher;
        }

        public string CourseName
        {
            get { return courseName; }
        }

        public string Teacher
        {
            get { return teacher; }
        }
    }


    class Progress
    {
        private Student student;
        private Course course;
        private int grade;
        private DateTime date;

        public Progress(
            Student student,
            Course course,
            int grade,
            DateTime date
        )
        {
            this.student = student;
            this.course = course;
            this.grade = grade;
            this.date = date;
        }

        public Student Student
        {
            get { return student; }
        }

        public Course Course
        {
            get { return course; }
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }


    class University
    {
        static Dictionary<string, Student> students;
        static Dictionary<string, Group> groups;
        static Dictionary<string, Course> courses;
        static List<Progress> progressList;

        static University()
        {
            students = new Dictionary<string, Student>();
            groups = new Dictionary<string, Group>();
            courses = new Dictionary<string, Course>();
            progressList = new List<Progress>();
        }

        public static void AddStudent()
        {
            Console.Write("ФИО студента: ");
            string name = Console.ReadLine();

            Console.Write("Возраст студента: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Название группы: ");
            string groupName = Console.ReadLine();

            if (!groups.ContainsKey(groupName))
            {
                Console.WriteLine("Группа не найдена");
                return;
            }

            Student student = new Student(name, age, groupName);
            students.Add(name, student);
            groups[groupName].AddStudent(student);

            Console.WriteLine("Студент " + name + " добавлен в группу " + groupName);
        }

        public static void AddGroup()
        {
            Console.Write("Название группы: ");
            string groupName = Console.ReadLine();

            Console.Write("Специальность: ");
            string specialty = Console.ReadLine();

            Console.Write("Год обучения: ");
            int year = int.Parse(Console.ReadLine());

            groups.Add(groupName, new Group(groupName, specialty, year));
            Console.WriteLine("Группа " + groupName + " добавлена");
        }

        public static void AddCourse()
        {
            Console.Write("Название предмета: ");
            string courseName = Console.ReadLine();

            Console.Write("Преподаватель: ");
            string teacher = Console.ReadLine();

            courses.Add(courseName, new Course(courseName, teacher));
            Console.WriteLine("Предмет " + courseName + " добавлен");
        }

        public static void AddProgress()
        {
            Console.Write("ФИО студента: ");
            string name = Console.ReadLine();

            Console.Write("Название предмета: ");
            string courseName = Console.ReadLine();

            if (!students.ContainsKey(name))
            {
                Console.WriteLine("Студент не найден");
                return;
            }

            if (!courses.ContainsKey(courseName))
            {
                Console.WriteLine("Предмет не найден");
                return;
            }

            Console.Write("Оценка: ");
            int grade = int.Parse(Console.ReadLine());

            progressList.Add(new Progress(students[name], courses[courseName], grade, DateTime.Now));
            Console.WriteLine("Оценка добавлена");
        }

        public static void EditProgress()
        {
            Console.Write("ФИО студента: ");
            string name = Console.ReadLine();

            Console.Write("Название предмета: ");
            string courseName = Console.ReadLine();

            List<Progress> filteredProgress = new List<Progress>();
            foreach (var p in progressList)
            {
                if (p.Student.FullName == name && p.Course.CourseName == courseName)
                {
                    filteredProgress.Add(p);
                }
            }

            Progress entry = null;
            if (filteredProgress.Count > 0)
            {
                entry = filteredProgress[filteredProgress.Count - 1];
            }

            if (entry == null)
            {
                Console.WriteLine("Запись об успеваемости не найдена");
                return;
            }

            Console.WriteLine("Текущая оценка: " + entry.Grade);
            Console.Write("Новая оценка: ");
            int newGrade = int.Parse(Console.ReadLine());

            entry.Grade = newGrade;
            entry.Date = DateTime.Now;
            Console.WriteLine("Оценка обновлена");
        }

        public static void ShowStudentAverage()
        {
            Console.Write("ФИО студента: ");
            string name = Console.ReadLine();

            if (!students.ContainsKey(name))
            {
                Console.WriteLine("Студент не найден");
                return;
            }

            List<Progress> studentProgress = progressList.Where(p => p.Student.FullName == name).ToList();

            if (studentProgress.Count == 0)
            {
                Console.WriteLine("У студента нет оценок");
                return;
            }

            Console.WriteLine("Успеваемость студента: " + name);

            Dictionary<string, List<double>> courseGrades = new Dictionary<string, List<double>>();
            
            foreach (var progress in studentProgress)
            {
                string courseName = progress.Course.CourseName;
                double grade = progress.Grade;
                
                if (!courseGrades.ContainsKey(courseName))
                    courseGrades[courseName] = new List<double>();
                
                courseGrades[courseName].Add(grade);
            }

            foreach (var course in courseGrades)
            {
                double sum = 0;
                foreach (double grade in course.Value)
                    sum += grade;
                
                double avg = sum / course.Value.Count;
                Console.WriteLine("Предмет: " + course.Key + " Средняя оценка: " + avg.ToString("F2"));
            }

            double totalSum = 0;
            foreach (var progress in studentProgress)
                totalSum += progress.Grade;
            
            double totalAvg = totalSum / studentProgress.Count;
            Console.WriteLine("Общая средняя оценка: " + totalAvg.ToString("F2"));
        }

        public static void ShowGroupAverage()
        {
            Console.Write("Название группы: ");
            string groupName = Console.ReadLine();

            if (!groups.ContainsKey(groupName))
            {
                Console.WriteLine("Группа не найдена");
                return;
            }

            Group group = groups[groupName];

            if (group.Students.Count == 0)
            {
                Console.WriteLine("В группе нет студентов");
                return;
            }

            List<string> studentNames = new List<string>();
            foreach (var student in group.Students)
            {
                studentNames.Add(student.FullName);
            }

            List<Progress> groupProgress = new List<Progress>();
            foreach (var progress in progressList)
            {
                if (studentNames.Contains(progress.Student.FullName))
                {
                    groupProgress.Add(progress);
                }
            }

            if (groupProgress.Count == 0)
            {
                Console.WriteLine("У студентов группы нет оценок");
                return;
            }

            Console.WriteLine("Успеваемость группы: " + groupName);
            Console.WriteLine("Специальность: " + group.Specialty + " Год обучения: " + group.Year);

            Dictionary<string, List<double>> courseGrades = new Dictionary<string, List<double>>();
            
            foreach (var progress in groupProgress)
            {
                string courseName = progress.Course.CourseName;
                double grade = progress.Grade;
                
                if (!courseGrades.ContainsKey(courseName))
                {
                    courseGrades[courseName] = new List<double>();
                }
                
                courseGrades[courseName].Add(grade);
            }

            foreach (var courseGroup in courseGrades)
            {
                double sum = 0;
                int count = 0;
                
                foreach (double grade in courseGroup.Value)
                {
                    sum += grade;
                    count++;
                }
                
                double avg = sum / count;
                Console.WriteLine("Предмет: " + courseGroup.Key + " Средняя оценка: " + avg.ToString("F2"));
            }

            double totalSum = 0;
            int totalCount = 0;
            
            foreach (var progress in groupProgress)
            {
                totalSum += progress.Grade;
                totalCount++;
            }
            
            double totalAvg = totalSum / totalCount;
            
            Console.WriteLine("Общая средняя оценка по группе: " + totalAvg.ToString("F2"));
        }

        public static void ShowStudent()
        {
            Console.Write("ФИО студента: ");
            string name = Console.ReadLine();

            if (!students.ContainsKey(name))
            {
                Console.WriteLine("Студент не найден");
                return;
            }

            Student student = students[name];
            Console.WriteLine("ФИО студента: " + student.FullName);
            Console.WriteLine("Возраст: " + student.Age);
            Console.WriteLine("Группа: " + student.GroupName);
        }

        public static void ShowGroup()
        {
            Console.Write("Название группы: ");
            string groupName = Console.ReadLine();

            if (!groups.ContainsKey(groupName))
            {
                Console.WriteLine("Группа не найдена");
                return;
            }

            Group group = groups[groupName];
            Console.WriteLine("Группа: " + group.GroupName);
            Console.WriteLine("Специальность: " + group.Specialty);
            Console.WriteLine("Год обучения: " + group.Year);
            Console.WriteLine("Студенты (" + group.Students.Count + "):");
            foreach (Student s in group.Students)
            {
                Console.WriteLine("  - " + s.FullName);
            }
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        int m = 0;

        do
        {
            Console.WriteLine("1 - Добавить группу");
            Console.WriteLine("2 - Добавить студента");
            Console.WriteLine("3 - Добавить предмет");
            Console.WriteLine("4 - Добавить оценку");
            Console.WriteLine("5 - Редактировать оценку");
            Console.WriteLine("6 - Средняя оценка студента по предметам");
            Console.WriteLine("7 - Средняя оценка по группе");
            Console.WriteLine("8 - Информация о студенте");
            Console.WriteLine("9 - Информация о группе");
            Console.WriteLine("0 - Выход");

            m = int.Parse(Console.ReadLine());

            switch (m)
            {
                case 1: University.AddGroup(); break;
                case 2: University.AddStudent(); break;
                case 3: University.AddCourse(); break;
                case 4: University.AddProgress(); break;
                case 5: University.EditProgress(); break;
                case 6: University.ShowStudentAverage(); break;
                case 7: University.ShowGroupAverage(); break;
                case 8: University.ShowStudent(); break;
                case 9: University.ShowGroup(); break;
            }

        } while (m != 0);
    }
}