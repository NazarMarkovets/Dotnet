using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Collections;
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
    public class ThreadSync
    {
        private MessageBuilder messageBuilder = new MessageBuilder();
        private Reader GetReader => new Reader(messageBuilder);
        private Creator GetCreator => new Creator(messageBuilder);
        private int counter;
        public void ShowThreadWorking()
        {
            List<Thread> listOfThreads = new List<Thread>();
            listOfThreads.AddRange(new Thread[]{
   
                new Thread(()=>GetCreator.CreateMessage("Asus")),
                new Thread(()=>GetCreator.CreateMessage("HP")),
                new Thread(()=>GetCreator.CreateMessage("Dell")),
                new Thread(()=>GetCreator.CreateMessage("PS")),
                new Thread(()=>GetCreator.CreateMessage("MB")),

                new Thread(()=>GetReader.ReadMessage("Asus")),
                new Thread(()=>GetReader.ReadMessage("HP")),
                new Thread(()=>GetReader.ReadMessage("Dell")),
                new Thread(()=>GetReader.ReadMessage("PS")),
                new Thread(()=>GetReader.ReadMessage("MB"))
                
            });

            foreach (var item in listOfThreads)
            {
                System.Console.WriteLine("[Foreach ID:]" + item.ManagedThreadId);
                item.Start();
            }

            foreach (var item in listOfThreads)
            {
                System.Console.WriteLine("[Foreach WAIT ID:]" + item.ManagedThreadId);
                item.Join();
            }
            messageBuilder.GetHashtable();
            
        }
    }
}
