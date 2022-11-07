using System;
using System.Text.RegularExpressions;

namespace lb1
{
    class EmployeeProfile
    {
        private string _FirstName;

        public string FirstName
        {
            get
            {
                if (_FirstName == null || FirstName == "") return ("FirstName");
                else return _FirstName;
            }
            set 
            {
                if (value == "" || value == null)
                    _FirstName = "FirstName";
            }
        }

        private string _LastName;

        public string LastName
        {
            get
            {
                if (_LastName == null || _LastName == "") return ("LastName");
                else return _LastName;
            }
            set
            {
                if (value == "" || value == null)
                    _LastName = "LastName";
            }
        }

        private string _MiddleName;

        public string MiddleName
        {
            get
            {
                if (_MiddleName == null || _MiddleName == "") return ("FirstName");
                else return _MiddleName;
            }
            set
            {
                if (value == "" || value == null)
                    _MiddleName = "First Name";
            }
        }

        private string _Post;
        public string Post
        {
            get
            {
                if (_Post != "директор" || _Post != "менеджер" || _Post != "інженер" || _Post != "різноробочий")
                    return default;
                return _Post;
            }
            set 
            {
                string s;
                Console.Write("Введіть посаду: ");
                s = Console.ReadLine();
                if (s != "директор" || s != "менеджер" || s != "інженер" || s != "різноробочий")
                    _Post = default;
                _Post = s;
            }
        }

        private int _Salary;
        public int Salary
        {
            get
            {
                switch (_Post)
                {
                    case "директор": return 50000;
                    case "менеджер": return 20000;
                    case "інженер": return 10000;
                    case "різноробочий": return 5000;
                    default: return 0;
                }
            }
            set
            {
                Console.Write("Введіть заробітну платню: ");
                _Salary = int.Parse(Console.ReadLine());
                if (Post == "директор") _Salary = 50000;
                if (Post == "менеджер") _Salary = 20000;
                if (Post == "інженер") _Salary = 10000;
                if (Post == "різноробочий") _Salary = 5000;
            }
        }

        private string[] _PostChangeHistory;
        public string[] PostChangeHistory
        {
            get
            {
                return _PostChangeHistory;
            }
            set
            {
                _PostChangeHistory = value;
            }
        }

        private string _DepName;
        public string DepName
        {
            get { return DepName; }
            set
            { 
                const string pattern = @"[a-z].*\d|\d.*[a-z]";
                var match = Regex.Match(value, pattern);
                if (match.Success) _DepName = value;
            }
        }

        private int _EmployeeBudget = 0;

        public EmployeeProfile(string firstName, string lastName, string middleName,
            string post, int salary, string[] postChange, string depName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Post = post;
            Salary = salary;
            PostChangeHistory = postChange;
            DepName = depName;
        }

        public EmployeeProfile()
        {
            FirstName = default;
            LastName = default;
            MiddleName = default;
            Post = default;
            Salary = default;
            PostChangeHistory = default;
            DepName = default;
        }

        public void changePost(string newPost)
        {
            Post = newPost;
        }

        public void changeDep(string newDep)
        {
            DepName = newDep;
        }

        public void accrueSalary()
        {
            switch (Post)
            {
                case "директор": _EmployeeBudget += 50000; break;
                case "менеджер": _EmployeeBudget += 20000; break;
                case "інженер": _EmployeeBudget += 10000; break;
                case "різноробочий": _EmployeeBudget += 5000; break;
                default: break;
            }
        }

        public string findInHistory(string post)
        {
            foreach(string s in PostChangeHistory)
            {
                if (s == post) return s;
            }
            return "Not Found";
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + MiddleName + "\n" +
            Post + "\n" + Salary + "\n" + PostChangeHistory
            + "\n" + DepName;
        }

        public bool compByPost(ref EmployeeProfile ep2)
        {
            if (Post == ep2.Post) return true;
            return false;
        }
    }
    internal class Program
    {
        static void Main()
        {
            string[] ep1History = new string[] { "різноробочий", "інженер", "менеджер", "директор" };
            string[] ep2History = new string[] { "різноробочий", "інженер", "менеджер" };
            string[] ep3History = new string[] { "різноробочий" };
            EmployeeProfile ep1 = new EmployeeProfile("Йцукен", "Йцукенов", "Йцукенович", "директор", 50000, ep1History, "D1");
            EmployeeProfile ep2 = new EmployeeProfile("Петров", "Пётр", "Петрович", "менеджер", 20001, ep2History, "D2");
            EmployeeProfile ep3 = new EmployeeProfile();
            ep3.PostChangeHistory = ep3History;
            ep1.changeDep("D3");
            Console.WriteLine(ep1.DepName);
            ep2.changePost("директор");
            Console.WriteLine(ep2.Post);
            ep1.accrueSalary();
            Console.WriteLine(ep2.findInHistory("інженер"));
            Console.WriteLine(ep3.ToString());
            Console.WriteLine(ep1.compByPost(ref ep2));
        }
    }
}