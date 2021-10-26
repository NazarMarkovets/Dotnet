using System.Collections.Generic;
using System.Data;
using System.Collections;
using System;
using System.Threading;
/*
Один процес виробляє повідомлення, призначені для сприйняття та обробку
іншим процесом. Процес, що виробляє повідомлення, називають виробником, а
процес, що сприймає повідомлення – споживачем. Процеси взаємодіють через
деяку узагальнену область пам'яті, яка за змістом є критичним ресурсом. Необхідно
створити декілька виробників (5) та декілька споживачів (5), які намагаються
отримати доступ до змінної. До змінної може одночасно звертатися лише один
процес. Змінна повинна накопичувати повідомлення від виробників. Кожне
повідомлення несе у собі інформацію, який процес його створив. Коли споживач
отримує доступ до змінної, він зменшує кількість повідомлень, але тільки
встановленого виробника, ігноруючи повідомлення інших виробників. Якщо
змінна не містить жодного повідомлення необхідного виробника, споживач
звільнює ресурс та відпочиває. Після виробництва повідомлення процес-виробник
відпочиває. Після вдалого споживання процес-споживач теж відпочиває.
Промоделюйте ситуацію.
*/
namespace Lib.Async
{
    class MessageBuilder
    {
        Message message;
        private static readonly Object locker = new Object();

        Dictionary<string, Message> messageTable = new Dictionary<string, Message>(); // String -> String
        // int -> 
        public void CreateMessage(string name)
        {
            lock (messageTable)
            {
                System.Console.WriteLine($"[Builder Create ID:] {Thread.CurrentThread.ManagedThreadId}");
                messageTable.Add(name,
                                new Message()
                                {
                                    MessageGUID = Guid.NewGuid(),
                                    MessageContent = $"{Thread.CurrentThread.Name}"
                                });
            }
        }

        public void ReadMessage(string name)
        {
            // System.Console.WriteLine($"[Builder Read ID:] {threadID}");
            lock (messageTable)
            {
                System.Console.WriteLine("Deciding whether map contains key " + name);
                foreach (var key in messageTable.Keys)
                {
                    System.Console.WriteLine(key);
                }
                if (messageTable.ContainsKey(name))
                {
                    System.Console.WriteLine($"[MessageTable KEY] ID: {name}");
                    messageTable.Remove(name);
                }
            }
        }

        public void GetHashtable(){
            if(messageTable.Count == 0)
            System.Console.WriteLine("Table is empty");
            foreach (var key in messageTable.Keys)
            {
                Message msg = (Message)messageTable[key];
                Console.WriteLine("Table KEY:" + key + " Table VALUE: " + msg.MessageGUID);
            }
        }

    }



}
