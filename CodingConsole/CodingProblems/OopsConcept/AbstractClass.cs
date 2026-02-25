using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_interview_problems.OopsConcept
{
    public class TestAbstractEmployee
    {
        public TestAbstractEmployee()
        {
            // write your logic here to test the abstract class features.
            // CS0144: Cannot create an instance of the abstract type or interface 'AbstractParentClass'
            // Fix: Instantiate a concrete subclass instead.
            AbstractParentClass obj = new ChildClass();
            ChildClass obj1 = new ChildClass();

            obj.VirtualMethods();
            obj1.VirtualMethods();

        }
    }

    public interface HiringOperations
    {
        string HireNewEmployee(string namesss);
        string FireEmployee(int name);
    }
    public abstract class AbstractParentClass : HiringOperations
    {
        private const string Department = "HR";
        private static int EmpCounter = 0;

        public static List<Tuple<int, string, string>> EmployeeList { get; set; }

        public AbstractParentClass()
        {
            EmployeeList = new List<Tuple<int, string, string>>();
        }
        public bool AddRecord(int id, string name, string dept = Department)
        {
            bool result = false;
            try
            {
                if (id <= 0 || string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException($"Null Parameter found for EmployeeId: {id} , EmployeeName : {name}.");
                }
                EmployeeList.Add(new Tuple<int, string, string>(id, name, dept));
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine($"{ex}");
            }
            finally
            {
                Console.WriteLine($"Add Employee Operation completed. {result}");
            }
            return result;
        }

        public Tuple<int, string, string>? GetEmployeeDetails(int id)
        {
            return EmployeeList.FirstOrDefault(x => x.Item1 == id);
        }

        public virtual void VirtualMethods()
        {
            Console.WriteLine("Virtual method of the parent class.");
        }

        public string HireNewEmployee(string name)
        {
            AddRecord(EmpCounter++, name, Department);
            return $"Inherit Parent Class : New Employee Hired with the name {name}.";
        }

        public string FireEmployee(int id)
        {
            var temp = EmployeeList.Find(x => x.Item1 == id);
            EmployeeList.Remove(temp);
            return $"Inherit Parent Class : Employee fired with the name {id}.";
        }

        public abstract void StartInterviews();
        public abstract void EndInterviews();
    }

    public class ChildClass : AbstractParentClass
    {
        public ChildClass()
        {
            Console.WriteLine("Child class constructor calling.");
        }

        public void NonAbstractMethods()
        {
            Console.WriteLine("Non abstract method of the child class.");
        }

        public new virtual void VirtualMethods()
        {
            Console.WriteLine("Child Class virtual methods.");
        }

        public override void EndInterviews()
        {
            Console.WriteLine("Abstract child class will end the interviews.");
        }

        public override void StartInterviews()
        {
            Console.WriteLine("Abstract child class will start the interviews.");
        }
    }

}
