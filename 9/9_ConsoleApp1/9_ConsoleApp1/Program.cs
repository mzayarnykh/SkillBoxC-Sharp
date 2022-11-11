using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace _9_ConsoleApp1
{
    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("");

        /// Отслеживание сообщений и ответы
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                // ОТПРАВКА СООБЩЕНИЯ В ЧАТ
                var message = update.Message;
                if (message.Text == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                    return;
                }
                
                // ОТПРАВКА ФОТО В ЧАТ
                if (message.Text == "300")
                {
                    await botClient.SendPhotoAsync(chatId: "619340931", photo: "AgACAgIAAxkBAANzY24CUI7BRTjQo6YitX83g16x4UAAAlrGMRuKaHFLDwurhEbteqsBAAMCAAN5AAMrBA");
                    return;
                }

                // ОТПРАВКА ГОЛОСОВОГО СООБЩЕНИЯ В ЧАТ
                if (message.Text == "200")
                {
                    await botClient.SendVoiceAsync(chatId: "619340931", voice: "AwACAgIAAxkBAAORY24cY0lpJBY5ny_uGDUf12tJ0IMAAqgmAAKKaHFLgnK4K6RLXDkrBA");
                    return;
                }

                // ЗАГРУЗКА ДОКУМЕНТА В ПАПКУ БОТА
                if (message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
                {
                    DownLoad(message.Document.FileId, message.Document.FileName);
                }

                // ЗАГРУЗКА ГОЛОСОВОГО СООБЩЕНИЯ В ПАПКУ БОТА
                if (message.Type == Telegram.Bot.Types.Enums.MessageType.Voice)
                {
                    DownLoad(message.Voice.FileId, $"voice/{message.From}_{message.MessageId}.ogg");
                }

                // ЗАГРУЗКА ФОТОГРАФИИ В ПАПКУ БОТА
                if (message.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
                {
                    DownLoad(message.Photo[3].FileId, $"photo/{message.From}_{message.MessageId}.jpeg");
                }

                if (message.Text == null) return;

                var messageText = message.Text;
            }
        }


        /// Загрузчик файлов
        static async void DownLoad(string fileId, string path)
        {
            var file = await bot.GetFileAsync(fileId);
            FileStream fs = new FileStream(path, FileMode.Create);
            await bot.DownloadFileAsync(file.FilePath, fs);
            fs.Close();

            fs.Dispose();
        }

        /// отслеживание ошибок
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        /// Настройки запуска отслеживания
        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
