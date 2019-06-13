using System.Collections.Generic;
using GlobalLogic_IRC75355_Test.Models;
using GlobalLogic_IRC75355_Test.Services;

namespace GlobalLogic_IRC75355_Test.Controllers
{
    public class Controller : IController
    {
        private string _inputString;
        private IReadService _readService;
        private ISplitService _splitService;
        private List<Word> _words = new List<Word>();
        private IWriteService _writeService;
        
        public Controller(IReadService readService, ISplitService splitService, IWriteService writeService)
        {
            _readService = readService;
            _splitService = splitService;
            _writeService = writeService;
        }
        
        public void Execute(string pathToFolder, string sourceFileName, string resultFileName)
        {
            _inputString =_readService.Read(pathToFolder + sourceFileName);
            _words = _splitService.Split(_inputString);
            _writeService.Write(_words, pathToFolder, resultFileName);
        }
    }
}