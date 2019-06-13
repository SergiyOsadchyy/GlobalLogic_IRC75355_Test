using System;
using GlobalLogic_IRC75355_Test.Controllers;
using GlobalLogic_IRC75355_Test.Services;

namespace GlobalLogic_IRC75355_Test.Controllers
{
    public class Controller : IController
    {
        private IReadService _readService;
        
        public Controller(IReadService readService)
        {
            _readService = readService;
        }
        
        public void Execute(string pathToSource)
        {
            _readService.Read(pathToSource);
        }
    }
}