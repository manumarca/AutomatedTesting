using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomatedTesting.TestConditions.Login;

namespace AutomatedTesting.TestConditions.Dictionaries
{
    public static class TestCasesDictionaries
    {
        private static LoginTestCases logTestCases = new LoginTestCases();

        public static Dictionary<string, Action> LoginTestCases = new Dictionary<string, Action>()
        {
            {"Correct Login", new Action(logTestCases.CorrectLogin)},
            {"Incorrect Login entering wrong UserName", new Action(logTestCases.LoginWithIncorrectUserName)},
            {"Incorrect Login entering wrong Password", new Action(logTestCases.LoginWithIncorrectPassword)}
        };



    }
}
