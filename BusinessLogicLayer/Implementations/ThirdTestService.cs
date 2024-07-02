
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implementations
{
    public class ThirdTestService : BaseTestService
    {
        private string _fileName;
        private ThirdTest thirdTest;

        public ThirdTestService(string fileName) : base(fileName)
        { 
            _fileName = fileName;
            thirdTest = new ThirdTest();
        }

        public override void SetAllValues()
        {
           thirdTest.DoubleValue = new Random().NextDouble();
        }

        public override string GetAllValues()
        {
            return thirdTest.DoubleValue.ToString();
        }
    }
}
