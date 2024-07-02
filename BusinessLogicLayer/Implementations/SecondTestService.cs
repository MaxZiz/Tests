using Models.Models;
using System;


namespace BusinessLogicLayer.Implementations
{
    public class SecondTestService : BaseTestService
    {
        private string _fileName;
        private SecondTest _secondTest;

        public SecondTestService(string fileName): base(fileName)
        {
            _fileName = fileName;
            _secondTest = new SecondTest();
        }

        public override void SetAllValues()
        {
            _secondTest.CharValue = (char)new Random().Next(0,128);
            _secondTest.Id = new Guid();   
        }

        public override string GetAllValues()
        {
            return _secondTest.Id.ToString() + _secondTest.CharValue.ToString();
        }
    }
}
