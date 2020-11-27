using System;
using System.Text;
using DesignPattern.BE.File;
using DesignPattern.Decorator;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DecoratorController : ControllerBase
    {
        [HttpPost]
        public IActionResult ZipFile(FileRequestEntity fileRequestEntity)
        {
            //設置初始化的被裝飾者
            DecoratorFactory factory = new DecoratorFactory(new FileProcess());

            //設置裝飾的順序
            factory.SetProcess(new ZipProcess() { FileName = "1.txt", PassWord = "1234567" });

            IProcess process = factory.GetProcess();

            byte[] data_buffer = Encoding.UTF8.GetBytes(fileRequestEntity.Content);
            process.Write(fileRequestEntity.FilePath, data_buffer);

            byte[] buffer = process.Read(fileRequestEntity.FilePath);
            Console.WriteLine(Encoding.UTF8.GetString(buffer));

            return this.Ok();
        }

        [HttpPost]
        public IActionResult AESCrypFile(FileRequestEntity fileRequestEntity)
        {
            //設置初始化的被裝飾者
            DecoratorFactory factory = new DecoratorFactory(new FileProcess());

            //設置裝飾的順序
            factory.SetProcess(new AESCrypProcess());

            IProcess process = factory.GetProcess();

            byte[] data_buffer = Encoding.UTF8.GetBytes(fileRequestEntity.Content);
            process.Write(fileRequestEntity.FilePath, data_buffer);

            byte[] buffer = process.Read(fileRequestEntity.FilePath);
            Console.WriteLine(Encoding.UTF8.GetString(buffer));

            return this.Ok();
        }

        [HttpPost]
        public IActionResult AESCrypAndZipFile(FileRequestEntity fileRequestEntity)
        {
            //設置初始化的被裝飾者
            DecoratorFactory factory = new DecoratorFactory(new FileProcess());

            //設置裝飾的順序
            factory.SetProcess(new ZipProcess() { FileName = "1.txt", PassWord = "1234567" })
                   .SetProcess(new AESCrypProcess());

            IProcess process = factory.GetProcess();

            byte[] data_buffer = Encoding.UTF8.GetBytes(fileRequestEntity.Content);
            process.Write(fileRequestEntity.FilePath, data_buffer);

            byte[] buffer = process.Read(fileRequestEntity.FilePath);
            Console.WriteLine(Encoding.UTF8.GetString(buffer));

            return this.Ok();
        }
    }
}
