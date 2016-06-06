using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.cs.Interfaces;


namespace AutomatedTesting.InternalActions.Shared
{
    public static class TestCaseExecutor
    {
               public static bool Executor(Action method)
        {
            bool testStatus = false;
            try
            {
                //Method that do the Test Steps
                method();
                testStatus = true;
            }
            catch(Exception e)
            {
                testStatus = false;
                //If one of the steps fails will tell in wich one broke
                Console.WriteLine(e.Message);
            }
            return testStatus;
        }
    }
}
