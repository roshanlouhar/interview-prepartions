using System;

namespace OopsConcept
{
    public class TestPolyMorphismClass
    {
        public TestPolyMorphismClass()
        {

        }
    }


    class polymorphismclass
    {
        // compile time polymorphism. method overloading/operator overloading
        private void privateMethod1()
        {
            Console.WriteLine("polymorphismclass privateMethod1 no parameter");
        }
        private void privateMethod1(string test)
        {
            Console.WriteLine("polymorphismclass privateMethod1 with parameter" + test);
        }

        // runtime polymorphism method overriding achived using virtual and abstract methods.

    }
}
