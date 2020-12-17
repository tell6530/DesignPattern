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
            factory.SetProcess(new ZipProcess() { ZipFileName = "susu.zip", PassWord = "1234567" });

            IProcess process = factory.GetProcess();

            process.Write(fileRequestEntity.FilePath, fileRequestEntity.Content);

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

            process.Write(fileRequestEntity.FilePath, fileRequestEntity.Content);

            return this.Ok();
        }

        [HttpPost]
        public IActionResult AESCrypAndZipFile(FileRequestEntity fileRequestEntity)
        {
            //設置初始化的被裝飾者
            DecoratorFactory factory = new DecoratorFactory(new FileProcess());

            //設置裝飾的順序
            factory.SetProcess(new AESCrypProcess())
                   .SetProcess(new ZipProcess() { ZipFileName = "susu.zip", PassWord = "123456" });

            IProcess process = factory.GetProcess();

            process.Write(fileRequestEntity.FilePath, fileRequestEntity.Content);

            return this.Ok();
        }
    }
}
