
using BusinessLogicLayer.Helpers;
using Models.Models;
using System;

namespace BusinessLogicLayer.Implementations
{
    public class FirstTestService : BaseTestService
    {
        private string _fileName;
        private FirstTest _firstTest;
        public FirstTestService(string fileName) : base(fileName)
        {
            _fileName = fileName;
            _firstTest = new FirstTest();
        }

        public override void SetAllValues()
        {
            _firstTest.Id = new Random().Next(0,10000);
            _firstTest.Name = GenerateValues.GenerateString(new Random().Next(1,20));      
        }

        public override string GetAllValues()
        {
            return _firstTest.Name + _firstTest.Id.ToString();
        }
    }
}
