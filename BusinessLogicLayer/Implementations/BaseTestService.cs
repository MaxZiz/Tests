using BusinessLogicLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Implementations
{
    public abstract class BaseTestService
    {
        private string _fileName;
        public BaseTestService(string fileName) 
        {
            _fileName = fileName;
        }
        private string message;
        /// <summary>
        /// Инициализация переменных
        /// </summary>
        /// <returns></returns>
        public abstract void SetAllValues();
        public abstract string GetAllValues();
        /// <summary>
        /// Реализация задержки
        /// </summary>
        /// <returns></returns>
        public async Task RunTest(CancellationTokenSource cts)
        {
            await Task.Delay(new Random().Next(10000, 30000), cts.Token);
            SetAllValues();
            if (GenerateStatus()==false)
            {              
                throw new Exception($"Ошибка при выполнении в классе : {this.GetType()}");
            }        
        }

        private bool GenerateStatus()
        {
            if (new Random().Next(0, 2) % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetTypeOfClass()
        {
            return this.GetType().Name;
        }

        public void WriteLogs(string status)
        {
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();
            var logService = serviceProvider.GetService<IWriteable>();
            message = status + " :: "+ _fileName + " :: " + GetAllValues();
            logService.Write(message, _fileName);
        }     
    }
}
