using System;
using System.Collections;

namespace Thamerhomework02
{

    class JsonBuilder
    {
        string json;
        /*

            {
               "id":6,
               "firstName":"Thamer",
               "isSaudi":true,
               "array":[
                  {
                     "item":"chair",
                     "price":"99$"
                  }
               ]
            }

         */
        public JsonBuilder()
        {
            this.json = "";
        }
        public JsonBuilder openCB() //open Curly Bracket
        {
            this.json += "{\n";
            return this;
        }
        public JsonBuilder name(string name)
        {
          
            this.json += " \"" + name + "\":";
            return this;
        }
        public JsonBuilder value(string value)
        {
            
            if (bool.TryParse(value, out bool boolean)||int.TryParse(value,out int num))
            {
                this.json += " " + value + " ";
            }
            else
            {
                this.json += " \"" + value + "\"";
            }
            return this;
        }

        public JsonBuilder newLine()
        {
            this.json += ",\n" ;
            return this;
        }
        public JsonBuilder openArray()
        {
            this.json += "[";
            return this;
        }
        public JsonBuilder closeArray()
        {
            this.json += "]";
            return this;
        }


        public JsonBuilder closeCB() //close Curly Bracket
        {
            this.json +=  "\n}";
            return this;
        }
        public string get()
        {
            return this.json;
        }

    }
    class TaskTwo
    {
        public static bool checkOrder(string str)
        {
            Stack stack = new Stack();

            foreach (var item in str)
            {
                if (stack.Count>0 && stack.Peek().ToString().Equals(item.ToString()))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(item);
                }
            }
            if (stack.Count == 0)
            {
                return true;
            }
            return false;
        }
    }

    class main
    {

        public static void Main(string[] args)
        {
            JsonBuilder res = new JsonBuilder();

            res.openCB()
                .name("id").value("6").newLine()
                .name("firstName").value("Thamer").newLine()
                .name("isSaudi").value("true").newLine()
                .name("array").openArray()
                                .openCB()
                                    .name("item").value("chair").newLine()
                                    .name("price").value("99$")
                                    .closeCB()
                                .closeArray()
                .closeCB();

            Console.WriteLine("~~~~ Josn Builder ~~~~");
            Console.WriteLine(res.get());
            Console.WriteLine("~~~~ end ~~~~");

            Console.WriteLine("\n\n~~~~ Order Check ~~~~");

            string[] tests = { "899899","12344312", "898898" , "00112233","windows","HHMMDDDD" };

            //string input = "898898";
            //bool ordered = TaskTwo.checkOrder(input);
            //Console.WriteLine("the result for input: {0}, is: {1}", input, ordered);

            foreach (var item in tests)
            {
                bool ordered = TaskTwo.checkOrder(item);
                Console.WriteLine("the result for input: {0}, is: {1}", item, ordered);

            }


            Console.WriteLine("\n~~~~ end ~~~~");

            //
        }
    }

}
