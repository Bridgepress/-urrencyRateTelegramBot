using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using TelegramBot;
using TelegramBot.Handler;

CurrencyDataHandler dataHandler = new CurrencyDataHandler();
ErrorHandler errorHandler = new ErrorHandler();
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
CancellationToken cancellationToken = cancellationTokenSource.Token;
ReceiverOptions receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { },
};
dataHandler.Bot.StartReceiving(
    dataHandler.UpdateAsync,
    errorHandler.ErrorAsync,
    receiverOptions,
    cancellationToken
);
Console.ReadLine();

