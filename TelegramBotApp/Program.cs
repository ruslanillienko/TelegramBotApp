// add library
using Telegram.Bot;
using Telegram.Bot.Types;

// add object reciever
var token = "6768413846:AAHTqI_fwuU8GspCDtMfEvWuYtiAFqQsVBA";
var botClientMain = new TelegramBotClient(token);

var botInfo = await botClientMain.GetMeAsync();

Console.WriteLine(botInfo.Id);
Console.WriteLine(botInfo.Username);

botClientMain.StartReceiving(
    updateHandler: OnUpdateHandler,
    pollingErrorHandler: OnPoolErrorHandler);

Console.ReadLine();

async Task OnUpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    var chatId = update.Message.Chat.Id;
    string message = "Hello";
    await botClient.SendTextMessageAsync(chatId, message);
    await Task.CompletedTask;
}

async Task OnPoolErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    await Task.CompletedTask;
}