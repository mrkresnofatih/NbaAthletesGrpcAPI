using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Core;
using Khonsu.KeyGenerator;
using Microsoft.Extensions.Logging;

namespace NbaAthletesGrpcAPI.API
{
    public class BookerService : Booker.BookerBase
    {
        private readonly KhonsuKeyGen _khonsuKeyGen;
        private readonly ILogger<BookerService> _logger;

        public BookerService(ILogger<BookerService> logger)
        {
            _logger = logger;
            _khonsuKeyGen = new KhonsuKeyGen(new HashSet<string>
            {"BK"});
        }

        public override Task<BookReply> SaveBook(BookCreateRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Save Book");
            return Task.FromResult(new BookReply
            {
                Id = _khonsuKeyGen.Generate("BK"),
                Title = request.Title,
                Author = request.Author,
                Pages = request.Pages,
                Date = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            });
        }

    }
}